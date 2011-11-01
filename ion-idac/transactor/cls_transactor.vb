Imports System.Data.SqlClient

Public MustInherit Class cls_transactor
	Private m_tables As New Collection()
	Private m_dataset As dataset
	Private m_general_id As Int32
	Private m_cary_id As Boolean
	Private m_cary_id_multiple As Boolean
	Private m_error_no As Integer
	Private m_error_desc As String
	Private m_error_source As String
	Private m_connection_string As String
	Private m_mode_insert As Boolean
	Private m_intransaction As Boolean
	Private m_successful As Boolean


	Public oConnection As SqlConnection
	Public oTransaction As SqlTransaction
	Public nNewId As Int32

	Public Function transact() As Boolean
		On Error GoTo ErrorHandler

		'--- local definitions
		Dim bError As Boolean = False
		Me.intransaction = False
		Me.successful = False
		oConnection = New SqlConnection(Me.connection_string)

		'--- declare all
		Dim nLoop As Int16
		For nLoop = 1 To Me.tables.Count
			Me.tables.Item(nLoop).oDataAdapter.TableMappings.Add("Table", Me.tables.Item(nLoop).TableName)
			Me.tables.Item(nLoop).oDataAdapter.SelectCommand = New SqlCommand("select * from " + Me.tables.Item(nLoop).TableName + " where 0=1", oConnection)
			Me.tables.Item(nLoop).oCommandBuilder = New SqlCommandBuilder(Me.tables.Item(nLoop).oDataAdapter)
		Next

		'--- Run function PRE_OPENCONNECTION ######
		Dim nError_no As Int32
		Dim nError_desc As String
		Dim nError_source As String
		bError = pre_openconnection(nError_no, nError_desc, nError_source)
		If bError Then
			Me.error_no = nError_no
			Me.error_desc = nError_desc
			Me.error_source = nError_source
			Return True
		End If


		'--- Open conecction
		oConnection.Open()

		'--- Run function PRE_TRANSACTION ######
		bError = pre_transaction(nError_no, nError_desc, nError_source)
		If bError Then
			Me.error_no = nError_no
			Me.error_desc = nError_desc
			Me.error_source = nError_source
			oConnection.Close()
			oConnection = Nothing
			oTransaction = Nothing
			Return True
		End If


		'--- Initiate transaction
		oTransaction = oConnection.BeginTransaction()

		'--- Pass Transaction to function
		'Me.trs_function.oTransaction = oTransaction

		'--- Initiate transaction on all tables in collection
		For nLoop = 1 To Me.tables.Count
			Me.tables.Item(nLoop).oDataAdapter.SelectCommand.Transaction = oTransaction
		Next

		'--- Run function INIT_TRANSACTION ######
		bError = init_transaction(nError_no, nError_desc, nError_source)
		If bError Then
			Me.error_no = nError_no
			Me.error_desc = nError_desc
			Me.error_source = nError_source
			oTransaction.Rollback()
			oConnection.Close()
			oConnection = Nothing
			oTransaction = Nothing
			Return True
		End If


		Me.intransaction = True

		'--- Run function IN_TRANSACTION ######
		bError = in_transaction(nError_no, nError_desc, nError_source)
		If bError Then
			Me.error_no = nError_no
			Me.error_desc = nError_desc
			Me.error_source = nError_source
			oTransaction.Rollback()
			oConnection.Close()
			oConnection = Nothing
			oTransaction = Nothing
			Return True
		End If


		Dim nCurrentTable As Int16
		Dim oTmpTable As DataTable
		Dim cTableName As String
		Dim oTmpDataAdapter As SqlDataAdapter
		For nCurrentTable = 1 To Me.tables.Count

			'--- Declare temporarly vars for this loop
			oTmpDataAdapter = Me.tables.Item(nCurrentTable).oDataAdapter
			oTmpTable = Me.tables.Item(nCurrentTable).oTable
			cTableName = Me.tables.Item(nCurrentTable).TableName

			'--- Check the table
			If oTmpTable.Rows.Count < 1 Then
				Err.Raise(5013, "[cls_transactor]", "ERROR 5013: To few Records assigned to dataset [" + cTableName + "] <transactor>")
			End If


			'--- Include an event on the fist table to get the ID number
			If nCurrentTable = 1 Then
				AddHandler oTmpDataAdapter.RowUpdated, New SqlRowUpdatedEventHandler(AddressOf OnRowUpdated)
			Else
				'--- Replace ID with main ID
                If Me.mode_insert Then

                    '--- Cary Id 
                    If Me.cary_id Then
                        oTmpTable.Columns("id").ReadOnly = False
                        oTmpTable.Rows(0)("id") = nNewId
                    End If

                    '--- Cary Id to multiple records
                    If Me.cary_id_multiple Then
                        Dim nRecord As Int32
                        For nRecord = 0 To oTmpTable.Rows.Count - 1
                            oTmpTable.Columns("id").ReadOnly = False
                            oTmpTable.Rows(nRecord)("id") = nNewId
                        Next
                    End If

                End If
			End If


			'--- Get only the changes for the Dataset
			Dim oDatasetChanges As DataSet = Me.dataset.GetChanges

			'--- Update Inventory table
			oTmpDataAdapter.Update(oDatasetChanges, cTableName)

			'--- Remove the event handler
			If nCurrentTable = 1 Then
				Me.general_id = nNewId
				RemoveHandler oTmpDataAdapter.RowUpdated, New SqlRowUpdatedEventHandler(AddressOf OnRowUpdated)
			End If

            '--- Clear all pending updates
            Me.tables.Item(nCurrentTable).oTable.AcceptChanges()

            '--- Run function AFTER_TABLE ######
            bError = after_table(nError_no, nError_desc, nError_source, nCurrentTable, oTmpTable)
			If bError Then
				Me.error_no = nError_no
				Me.error_desc = nError_desc
				Me.error_source = nError_source
				oTransaction.Rollback()
				oConnection.Close()
				oConnection = Nothing
				oTransaction = Nothing
				Return True
			End If

		Next

		oTmpDataAdapter = Nothing
		oTmpTable = Nothing

		'--- Run function PRE_COMMIT ######
		bError = pre_commit(nError_no, nError_desc, nError_source)
		If bError Then
			Me.error_no = nError_no
			Me.error_desc = nError_desc
			Me.error_source = nError_source
			oTransaction.Rollback()
			oConnection.Close()
			oConnection = Nothing
			oTransaction = Nothing
			Return True
		End If

		'--- Commit transaction
		oTransaction.Commit()
		Me.intransaction = False
		Me.successful = True

		'--- Run function AFTER_COMMIT ######
		bError = after_commit(nError_no, nError_desc, nError_source)
		If bError Then
			Me.error_no = nError_no
			Me.error_desc = nError_desc
			Me.error_source = nError_source
			oTransaction.Rollback()
			oConnection.Close()
			oConnection = Nothing
			oTransaction = Nothing
			Return True
		End If

		oConnection.Close()
		oConnection = Nothing
		oTransaction = Nothing

		Return False
		Exit Function

ErrorHandler:
		If Me.intransaction Then
			oTransaction.Rollback()
			oConnection.Close()
			oConnection = Nothing
			oTransaction = Nothing
		End If

		Me.error_no = Err.Number
		Me.error_desc = Err.Description
		Me.error_source = Err.Source
		Return True

	End Function

	Sub OnRowUpdated(ByVal sender As Object, ByVal args As SqlRowUpdatedEventArgs)
		' Include a variable and a command to retrieve the identity value from the Access database.
		Dim newID As Integer = 0
		Dim idCMD As SqlCommand = New SqlCommand("SELECT @@IDENTITY", oConnection)

		If args.StatementType = StatementType.Insert Then
			idCMD.Transaction = oTransaction
			nNewId = CInt(idCMD.ExecuteScalar())

		End If
	End Sub


	'###################################################################################
	Overridable Function pre_openconnection(ByRef error_no As Int32, ByRef error_desc As String, ByRef error_source As String) As Boolean
		On Error GoTo ErrorHandler
		Dim bError As Boolean = False



		Return False
		Exit Function

ErrorHandler:
		error_no = Err.Number
		error_desc = Err.Description
		error_source = Err.Source
		Return True

	End Function



	'###################################################################################
	Overridable Function pre_transaction(ByRef error_no As Int32, ByRef error_desc As String, ByRef error_source As String) As Boolean
		On Error GoTo ErrorHandler
		Dim bError As Boolean = False



		Return False
		Exit Function

ErrorHandler:
		error_no = Err.Number
		error_desc = Err.Description
		error_source = Err.Source
		Return True

	End Function

	'###################################################################################
	Overridable Function init_transaction(ByRef error_no As Int32, ByRef error_desc As String, ByRef error_source As String) As Boolean
		On Error GoTo ErrorHandler
		Dim bError As Boolean = False



		Return False
		Exit Function

ErrorHandler:
		error_no = Err.Number
		error_desc = Err.Description
		error_source = Err.Source
		Return True

	End Function

	'###################################################################################
	Overridable Function in_transaction(ByRef error_no As Int32, ByRef error_desc As String, ByRef error_source As String) As Boolean
		On Error GoTo ErrorHandler
		Dim bError As Boolean = False



		Return False
		Exit Function

ErrorHandler:
		error_no = Err.Number
		error_desc = Err.Description
		error_source = Err.Source
		Return True

	End Function


	'###################################################################################
	Overridable Function after_table(ByRef error_no As Int32, ByRef error_desc As String, ByRef error_source As String, ByVal nCurrentTable As Int16, ByVal oDataTable As DataTable) As Boolean
		On Error GoTo ErrorHandler
		Dim bError As Boolean = False

		Dim cTableName As String = oDataTable.TableName


		Return False
		Exit Function

ErrorHandler:
		error_no = Err.Number
		error_desc = Err.Description
		error_source = Err.Source
		Return True

	End Function


	'###################################################################################
	Overridable Function pre_commit(ByRef error_no As Int32, ByRef error_desc As String, ByRef error_source As String) As Boolean
		On Error GoTo ErrorHandler
		Dim bError As Boolean = False



		Return False
		Exit Function

ErrorHandler:
		error_no = Err.Number
		error_desc = Err.Description
		error_source = Err.Source
		Return True

	End Function


	'###################################################################################
	Overridable Function after_commit(ByRef error_no As Int32, ByRef error_desc As String, ByRef error_source As String) As Boolean
		On Error GoTo ErrorHandler
		Dim bError As Boolean = False



		Return False
		Exit Function

ErrorHandler:
		error_no = Err.Number
		error_desc = Err.Description
		error_source = Err.Source
		Return True

	End Function


	'-----------------------------------------------------------------------------------
	'###################################################################################
	'-----------------------------------------------------------------------------------
	Public Property dataset() As dataset
		Get
			Return m_dataset
		End Get

		Set(ByVal Value As dataset)
			m_dataset = Value
		End Set
	End Property

	Public Property tables() As Collection
		Get
			Return m_tables
		End Get

		Set(ByVal Value As Collection)
			m_tables = Value
		End Set
	End Property

	Public Property general_id() As Int32
		Get
			Return m_general_id
		End Get

		Set(ByVal Value As Int32)
			m_general_id = Value
		End Set
	End Property

	Public Property error_no() As Integer
		Get
			Return m_error_no
		End Get

		Set(ByVal Value As Integer)
			m_error_no = Value
		End Set
	End Property

	Public Property error_desc() As String
		Get
			Return m_error_desc
		End Get

		Set(ByVal Value As String)
			m_error_desc = Value
		End Set
	End Property

	Public Property error_source() As String
		Get
			Return m_error_source
		End Get

		Set(ByVal Value As String)
			m_error_source = Value
		End Set
	End Property

	Public Property connection_string() As String
		Get
			Return m_connection_string
		End Get

		Set(ByVal Value As String)
			m_connection_string = Value
		End Set
	End Property

	Public Property mode_insert() As Boolean
		Get
			Return m_mode_insert
		End Get

		Set(ByVal Value As Boolean)
			m_mode_insert = Value
		End Set
	End Property

	Public Property intransaction() As Boolean
		Get
			Return m_intransaction
		End Get

		Set(ByVal Value As Boolean)
			m_intransaction = Value
		End Set
	End Property

	Public Property successful() As Boolean
		Get
			Return m_successful
		End Get

		Set(ByVal Value As Boolean)
			m_successful = Value
		End Set
	End Property

	Public Property cary_id() As Boolean
		Get
			Return m_cary_id
		End Get

		Set(ByVal Value As Boolean)
			m_cary_id = Value
		End Set
	End Property

	Public Property cary_id_multiple() As Boolean
		Get
			Return m_cary_id_multiple
		End Get

		Set(ByVal Value As Boolean)
			m_cary_id_multiple = Value
		End Set
	End Property


End Class
