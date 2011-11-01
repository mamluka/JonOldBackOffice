Imports System.Data.SqlClient

Public Class cls_sql_read
	Inherits cls_error

	Public _tablename As String
	Public _datatable As DataTable
	Public _searchfield As String

	Public Overloads Function transact_read(ByVal cSQL As String) As Boolean
		On Error GoTo ErrorHandler

		'--- this module reads a multiple records from a given table and puts it in a dataset
		'--- Must get a tablename to read
		'--- Result comes in _table

		'--- local definitions
		Dim bError As Boolean = False

		'--- Trim table property
		Me._tablename = Trim(Me._tablename)
		If Me._tablename = "" Then
			Me._tablename = "db_result"
		End If

		'--- Create connection
		Dim oConnection As SqlConnection
		oConnection = New SqlConnection(Me._connection_string)

		'--- Create Datadapter
		Dim oDataAdapter1 As SqlDataAdapter = New SqlDataAdapter

		'--- Create SQL statement
		Dim oSQLcmd1 As SqlCommand = New SqlCommand(cSQL, oConnection)
		oSQLcmd1.CommandType = CommandType.Text
		oDataAdapter1.SelectCommand = oSQLcmd1

		'--- create datatable
		Dim oDatatable As New DataTable
		oDatatable.TableName = Me._tablename

		'--- Instatiate a new datatable
		Me._datatable = New DataTable
		Me._datatable.TableName = Me._tablename

		'--- Open connection
		oConnection.Open()

		'--- Get datatable
		oDataAdapter1.Fill(Me._datatable)

		'--- Close connection
		oConnection.Close()

		'--- release objects
		oConnection = Nothing
		oDataAdapter1 = Nothing
		oSQLcmd1 = Nothing

		Return False
		Exit Function

ErrorHandler:
		Me._err_number = Err.Number
		Me._err_description = Err.Description
		Me._err_source = Err.Source
		Return True

	End Function

	Public Overloads Function transact_read(ByVal nId As Int32) As Boolean
		On Error GoTo ErrorHandler

		'--- this module reads a single record from a given table and puts it in a dataset
		'--- Must get a tablename to read
		'--- Result comes in _table

		'--- local definitions
		Dim bError As Boolean = False

		'--- Trim table property
		Me._tablename = Trim(Me._tablename)

		'--- Create connection
		Dim oConnection As SqlConnection
		oConnection = New SqlConnection(Me._connection_string)

		'--- Create DataAdapter
		Dim oDataAdapter1 As SqlDataAdapter = New SqlDataAdapter

		'--- Create datatable datatable
		Me._datatable = New DataTable
		Me._datatable.TableName = Me._tablename

		'--- Setup Query string
		Dim oSQLcmd1 As SqlCommand
		If Me._searchfield <> "" Then
			oSQLcmd1 = New SqlCommand("select * from " + Trim(Me._tablename) + " where " & Me._searchfield & "=" & nId, oConnection)
		Else
			oSQLcmd1 = New SqlCommand("select * from " + Trim(Me._tablename) + " where id=" & nId, oConnection)
		End If
		oSQLcmd1.CommandType = CommandType.Text
		oDataAdapter1.SelectCommand = oSQLcmd1

		'--- Open connection
		oConnection.Open()

		'--- Get datatable
		oDataAdapter1.Fill(Me._datatable)

		'--- Close connection
		oConnection.Close()

		'--- Report Error
		If Me._datatable.Rows.Count > 1 Then
			Err.Raise(9000, "cls_sql_read:transact_read", "iDAC: More then one record fetched")
		End If

		'--- release objects
		oConnection = Nothing
		oDataAdapter1 = Nothing

		oSQLcmd1 = Nothing

		Return False
		Exit Function

ErrorHandler:
		Me._err_number = Err.Number
		Me._err_description = Err.Description
		Me._err_source = Err.Source
		Return True

	End Function

End Class
