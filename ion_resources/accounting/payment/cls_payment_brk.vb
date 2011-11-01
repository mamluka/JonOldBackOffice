Imports System.Data.SqlClient

Public Class cls_payment_brk
	Private m_payment_id As Int32

    '################################################################################
	Function insert_payment(ByVal oSystem As ion_resources.cls_system) As Boolean
		'On Error GoTo ErrorHandler

		'--- local definitions
		Dim bError As Boolean = False

        Dim oTransact As New ion_resources.cls_trs_insert_payment()
		oTransact.dataset = oSystem.dataset
		oTransact.connection_string = oSystem.connection_string
		oTransact.mode_insert = True
		oTransact.cary_id = False
		oTransact.cary_id_multiple = False


		'-------------- Add tables to Collection
		'--- ### Table 1
		Dim oTable1 As New ion_resources.cls_trs_tables()
		oTable1.oTable = oTransact.dataset.Tables("acc_CASHFLOW")
		oTable1.TableName = "acc_CASHFLOW"
		oTransact.tables.Add(oTable1)
		oTable1 = Nothing


		bError = oTransact.transact

		'--- Return parameters
        Me.payment_id = oTransact.general_id


        Return False
		Exit Function

ErrorHandler:
		oSystem.error_no = Err.Number
		oSystem.error_desc = Err.Description
		oSystem.error_source = Err.Source
		Return True

	End Function


    '################################################################################
	Function get_payment(ByVal nPaymentId As Int32, ByVal oSystem As ion_resources.cls_system) As Boolean
		On Error GoTo ErrorHandler

		'--- local definitions
		Dim bError As Boolean = False

		'--- Create connection
		Dim oConnection As SqlConnection
		oConnection = New SqlConnection(oSystem.connection_string)

		Dim oDataAdapter1 As SqlDataAdapter = New SqlDataAdapter()
		oDataAdapter1.TableMappings.Add("Table", "acc_CASHFLOW")

		oConnection.Open()

		Dim oSQLcmd1 As SqlCommand = New SqlCommand("select * from acc_CASHFLOW where id=" & nPaymentId, oConnection)
		oSQLcmd1.CommandType = CommandType.Text
		oDataAdapter1.SelectCommand = oSQLcmd1


		Dim oDS As DataSet = New DataSet("ds_CASHFLOW")
		oDataAdapter1.Fill(oDS)


		'--- Close connection
		oConnection.Close()

		'--- assign dataset to return value
		oSystem.dataset = oDS

		'--- release objects
		oConnection = Nothing
		oDataAdapter1 = Nothing

		oSQLcmd1 = Nothing

		Return False
		Exit Function

ErrorHandler:
		oSystem.error_no = Err.Number
		oSystem.error_desc = Err.Description
		oSystem.error_source = Err.Source
		Return True

	End Function

    '################################################################################
	Function update_payment(ByVal oSystem As ion_resources.cls_system) As Boolean
		'On Error GoTo ErrorHandler

		'--- local definitions
		Dim bError As Boolean = False

		Dim oTransact As New ion_resources.cls_trs_update_payment()
        oTransact.dataset = oSystem.dataset
        oTransact.connection_string = oSystem.connection_string
		oTransact.mode_insert = False
		oTransact.cary_id = False
		oTransact.cary_id_multiple = False
		oTransact.general_id = Me.payment_id


		'-------------- Add tables to Collection
		'--- ### Table 1
		Dim oTable1 As New ion_resources.cls_trs_tables()
		oTable1.oTable = oTransact.dataset.Tables("acc_CASHFLOW")
		oTable1.TableName = "acc_CASHFLOW"
		oTransact.tables.Add(oTable1)
		oTable1 = Nothing


		bError = oTransact.transact


		Return False
		Exit Function

ErrorHandler:
		oSystem.error_no = Err.Number
		oSystem.error_desc = Err.Description
		oSystem.error_source = Err.Source
		Return True

	End Function





	Public Property payment_id() As Int32
		Get
			Return m_payment_id
		End Get

		Set(ByVal Value As Int32)
			m_payment_id = Value
		End Set
	End Property

End Class
