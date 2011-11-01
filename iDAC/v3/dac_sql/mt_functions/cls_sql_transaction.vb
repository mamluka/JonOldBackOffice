Imports System.Data.SqlClient
Friend Class cls_sql_transaction
	Inherits cls_error

	'##### Call code for this object
	'#####
	'##### Dim oTransaction As New cls_sql_transaction
	'##### oTransaction._connection_string = Me._connection_string
	'##### oTransaction.start()
	'##### Me._transaction = oTransaction._transaction
	'#####
	'##### oTransaction.close()
	'#####


	Public _transaction As SqlTransaction

	Public Function start() As Boolean
		On Error GoTo ErrorHandler
		Dim bError As Boolean = False


		Dim oConnection As SqlConnection = New SqlConnection(Me._connection_string)
		oConnection.Open()

		Me._transaction = oConnection.BeginTransaction()


		Return False
		Exit Function

ErrorHandler:
		Me._err_number = Err.Number
		Me._err_description = Err.Description
		Me._err_source = Err.Source
		Return True
	End Function

	Public Function close() As Boolean
		On Error GoTo ErrorHandler
		Dim bError As Boolean = False

		Dim oConnection As SqlConnection
		oConnection = Me._transaction.Connection

		'--- Commit transaction
		Me._transaction.Commit()

		'--- Close Connection
		oConnection.Close()

		oConnection = Nothing

		Return False
		Exit Function

ErrorHandler:
		Me._err_number = Err.Number
		Me._err_description = Err.Description
		Me._err_source = Err.Source
		Return True
	End Function

End Class
