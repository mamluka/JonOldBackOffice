Imports System.Data.SqlClient

Public Class cls_sql_r
	'Inherits cls_error

	Public _err_number As Int32
	Public _err_description As String
	Public _err_source As String
	Public _connection_string As String
	Public _dbtype As Int16
	Public _user_id As Int32

	Public _tablename As String
	Public _datatable As DataTable

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

		Dim oDataAdapter1 As SqlDataAdapter = New SqlDataAdapter
		oDataAdapter1.TableMappings.Add("Table", Me._tablename)

		oConnection.Open()

		Dim oSQLcmd1 As SqlCommand = New SqlCommand("select * from " + Trim(Me._tablename) + " where id=" & nId, oConnection)
		oSQLcmd1.CommandType = CommandType.Text
		oDataAdapter1.SelectCommand = oSQLcmd1


		Dim oDS As DataSet = New DataSet(Me._tablename)
		oDataAdapter1.Fill(oDS)


		'--- Close connection
		oConnection.Close()

		'--- Report Error
		If oDS.Tables.Count > 1 Then
			Err.Raise(9000, "cls_sql_read:transact_read", "iDAC: More then one record fetched")
		End If

		'--- assign dataset to return value
		Me._datatable = oDS.Tables(Me._tablename)

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

	Public Overloads Function transact_read(ByVal cSQL As String) As Boolean
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

		Dim oDataAdapter1 As SqlDataAdapter = New SqlDataAdapter
		oDataAdapter1.TableMappings.Add("Table", Me._tablename)

		oConnection.Open()

		Dim oSQLcmd1 As SqlCommand = New SqlCommand(cSQL, oConnection)
		oSQLcmd1.CommandType = CommandType.Text
		oDataAdapter1.SelectCommand = oSQLcmd1


		Dim oDS As DataSet = New DataSet(Me._tablename)
		oDataAdapter1.Fill(oDS)


		'--- Close connection
		oConnection.Close()

		'--- Report Error
		If oDS.Tables.Count > 1 Then
			Err.Raise(9000, "cls_sql_read:transact_read", "iDAC: More then one record fetched")
		End If

		'--- assign dataset to return value
		Me._datatable = oDS.Tables(Me._tablename)

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


	Public Overloads Function transact_read(ByVal nIdto As Int64) As Boolean

	End Function


End Class
