Imports System.Data.SqlClient

Friend Class cls_sql_delete
	Inherits cls_error

	Public _transaction As SqlTransaction
	Public _tablename As String
	Private _connection As SqlConnection

	Function transact_delete(ByVal nValue As Int32, Optional ByVal cField As String = "") As Boolean
		On Error GoTo ErrorHandler
		Dim bError As Boolean = False

		'- If the ID is transferred without the field, then the default field is ID
		'- otherwise we delete ID from the FIELD supplied

		'--- Trim table property
		If Me._tablename = "" Then
			Err.Raise(9003, "cls_sql_dalete:transact_delete", "iDAC: Property _DataTable not provided")
		Else
			Me._tablename = Trim(Me._tablename)
		End If


		'--- check if we are in transaction
		Dim bInTransaction As Boolean = False
		Dim bMasterTransaction As Boolean
		If Not IsNothing(Me._transaction) Then
			bMasterTransaction = True
		Else
			bMasterTransaction = False
			'--- Open Connection and start transation
			Me._connection = New SqlConnection(Me._connection_string)
			Me._connection.Open()
		End If


		'--- go delete record
		Dim cSQLnumberUpdate As String
		Dim oUpdateCommand As New SqlCommand

		'--- Update COUNTER LastNumber
		oUpdateCommand = New SqlCommand(cSQLnumberUpdate, Me._connection)
		If bMasterTransaction Then
			oUpdateCommand.Connection = Me._transaction.Connection
			oUpdateCommand.Transaction = Me._transaction
		End If

		'--- 
		If cField = "" Then
			cSQLnumberUpdate = "delete from " + Me._tablename + " where id = " + Convert.ToString(nValue)
		Else
			cSQLnumberUpdate = "delete from " + Me._tablename + " where " + Convert.ToString(cField) + " = " + Convert.ToString(nValue)
		End If


		oUpdateCommand.CommandType = CommandType.Text
		oUpdateCommand.CommandText = cSQLnumberUpdate
		oUpdateCommand.ExecuteNonQuery()


		'--- If not in transaction close the connection
		If Not bMasterTransaction Then
			Me._connection.Close()
		End If


		Return False
		Exit Function

ErrorHandler:
		If bInTransaction Then
			Me._transaction.Rollback()
		End If
		Me._err_number = Err.Number
		Me._err_description = Err.Description
		Me._err_source = Err.Source
		Return True
	End Function


End Class
