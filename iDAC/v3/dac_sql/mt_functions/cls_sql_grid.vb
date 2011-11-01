Imports System.Data.SqlClient

Friend Class cls_sql_grid
	Inherits cls_error

	Public _sqlstring As String
	Public _dataadapter As SqlDataAdapter
	Public _connection As SqlConnection
	Public _sqlcommand As SqlCommand

	Function init() As Boolean
		On Error GoTo ErrorHandler
		Dim bError As Boolean = False

		'--- Define DB level function to load and bing Grid
		Dim oConnection As SqlClient.SqlConnection = New SqlClient.SqlConnection
		Dim oDataAdapter As SqlDataAdapter = New SqlDataAdapter
		Dim oSQLcommand As SqlCommand = New SqlCommand("", oConnection)

		oConnection.ConnectionString = Me._connection_string
		oSQLcommand.CommandText = Me._sqlstring
		oDataAdapter.SelectCommand = oSQLcommand
		oConnection.Open()

		'--- Return properties
		Me._connection = oConnection
		Me._dataadapter = oDataAdapter
		Me._sqlcommand = oSQLcommand

		Return False
		Exit Function

ErrorHandler:
		Me._err_number = Err.Number
		Me._err_description = Err.Description
		Me._err_source = Err.Source
		Return True

	End Function


End Class
