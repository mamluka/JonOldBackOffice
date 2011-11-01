Imports System.Data.SqlClient

Friend Class cls_sql_command
	Inherits cls_error

	Public _transaction As SqlTransaction
	Public _sqlstring As String

	Function transact_command() As Boolean
		On Error GoTo ErrorHandler

		'--- local definitions
		Dim bError As Boolean = False

		'--- Trim table property
		Me._sqlstring = Trim(Me._sqlstring)

		'--- Declare local status
		Dim bInTransaction As Boolean = False		  '-- Currently in transaction
		Dim bMasterTransaction As Boolean		'-- If we are already in previous defined transaction

		'--- Declare connection object
		Dim oConnection As SqlConnection
		Dim oTransaction As SqlTransaction


		If Not IsNothing(Me._transaction) Then
			bMasterTransaction = True
			bInTransaction = True
			oTransaction = Me._transaction
		Else
			bMasterTransaction = False
			'--- Open Connection and start transation
			oConnection = New SqlConnection(Me._connection_string)
			oConnection.Open()

			'--- Get transaction-object from the conneection
			oTransaction = oConnection.BeginTransaction()
			Me._transaction = oTransaction
			bInTransaction = True
		End If


		'--- go delete record
		Dim oCommand As New SqlCommand

		'--- Update COUNTER LastNumber
		oCommand.CommandText = Me._sqlstring
		oCommand = New SqlCommand(Me._sqlstring, oTransaction.Connection)
		oCommand.Transaction = Me._transaction
		oCommand.CommandType = CommandType.Text
		oCommand.ExecuteNonQuery()

		'--- If not in transaction close the connection
		If Not bMasterTransaction Then
			Me._transaction.Commit()
			Me._transaction = Nothing
			oConnection.Close()
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
