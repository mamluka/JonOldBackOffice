Imports System.Data.SqlClient

Public Class cls_mt_write
	Inherits cls_mt_error

	'--- USED BY MT_TRANSACTOR
	'---
	'--- This module saves tables.
	'--- If a DATATABLE is passed then the DATATABLE is saved
	'--- If a DATASET is passed then the DATASET is saved
	'---
	'--- The ID of the record handeled should be found in ME.O_ID

	Private m_i_connection_string As String

	Private m_o_id As Int32
	Private m_i_transaction As SqlTransaction
	Private m_i_datatable As DataTable	 '-- We can use OR  datatable OR Dataset
	Private m_i_connection As SqlConnection

	Function WriteTable() As Boolean
		On Error GoTo ErrorHandler
		Dim bError As Boolean = False


		'--- Prepare the dataadapter
		Dim oDataAdapter As New SqlDataAdapter
		oDataAdapter.TableMappings.Add("Table", Me.i_datatable.TableName)
		oDataAdapter.SelectCommand = New SqlCommand("select * from " + Me.i_datatable.TableName + " where 0=1", Me.i_connection)
		oDataAdapter.SelectCommand.Transaction = Me.i_transaction

		'--- prepare the command builder
		Dim oCommandBuilder As SqlCommandBuilder
		oCommandBuilder = New SqlCommandBuilder(oDataAdapter)


		AddHandler oDataAdapter.RowUpdated, New SqlRowUpdatedEventHandler(AddressOf OnRowUpdated)

		oDataAdapter.UpdateCommand = oCommandBuilder.GetUpdateCommand

		oDataAdapter.Update(Me.i_datatable)

		'Dim oDatasetChanges As DataSet = Me.i_datatable.DataSet
		'oDataAdapter.Update(oDatasetChanges)

		RemoveHandler oDataAdapter.RowUpdated, New SqlRowUpdatedEventHandler(AddressOf OnRowUpdated)

		'--- Release objects
		oDataAdapter = Nothing
		oCommandBuilder = Nothing


		Return False
		Exit Function

ErrorHandler:
		Me.error_no = Err.Number
		Me.error_desc = Err.Description
		Me.error_source = Err.Source
		Return True

	End Function

	Sub OnRowUpdated(ByVal sender As Object, ByVal args As SqlRowUpdatedEventArgs)
		' Include a variable and a command to retrieve the identity value from the Access database.
		Dim newID As Integer = 0
		Dim idCMD As SqlCommand = New SqlCommand("SELECT @@IDENTITY", Me.i_connection)

		If args.StatementType = StatementType.Insert Then
			idCMD.Transaction = Me.i_transaction
			Me.o_id = CInt(idCMD.ExecuteScalar())

		End If
	End Sub

	Public Property i_connection_string() As String
		Get
			Return m_i_connection_string
		End Get

		Set(ByVal Value As String)
			m_i_connection_string = Value
		End Set
	End Property

	Public Property o_id() As Int32
		Get
			Return m_o_id
		End Get

		Set(ByVal Value As Int32)
			m_o_id = Value
		End Set
	End Property

	Public Property i_transaction() As SqlTransaction
		Get
			Return m_i_transaction
		End Get

		Set(ByVal Value As SqlTransaction)
			m_i_transaction = Value
		End Set
	End Property

	Public Property i_datatable() As DataTable
		Get
			Return m_i_datatable
		End Get

		Set(ByVal Value As DataTable)
			m_i_datatable = Value
		End Set
	End Property

	Public Property i_connection() As SqlConnection
		Get
			Return m_i_connection
		End Get

		Set(ByVal Value As SqlConnection)
			m_i_connection = Value
		End Set
	End Property
End Class
