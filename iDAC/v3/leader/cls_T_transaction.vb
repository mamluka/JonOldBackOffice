Imports System.Data.SqlClient

Public Class cls_T_transaction
	Inherits cls_leader

	Public _transaction As SqlTransaction

	Public Function start() As Boolean
		On Error GoTo ErrorHandler
		Dim bError As Boolean = False

		'--- Get Broker type
		bError = Me.get_broker
		If bError Then
			Return True
		End If

		'--- Pass Properties
		Me._broker._connection_string = Me._connection_string
		Me._broker._transaction = Me._transaction

		'--- Call function
		bError = Me._broker.start
		If bError Then
			Me._err_number = Me._broker._err_number
			Me._err_description = Me._broker._err_description
			Me._err_source = Me._broker._err_source
			Return True
		End If

		'--- Receive Properties
		Me._transaction = Me._broker._transaction

		'--- Clear Objects
		Me._broker = Nothing

		Return False
		Exit Function

ErrorHandler:
		'--- register the error
		Me._err_number = Err.Number
		Me._err_description = Err.Description
		Me._err_source = Err.Source
		Return True


	End Function

	Public Function close() As Boolean
		On Error GoTo ErrorHandler
		Dim bError As Boolean = False

		'--- Get Broker type
		bError = Me.get_broker
		If bError Then
			Return True
		End If

		'--- Pass Properties
		Me._broker._connection_string = Me._connection_string
		Me._broker._transaction = Me._transaction

		'--- Call function
		bError = Me._broker.close
		If bError Then
			Me._err_number = Me._broker._err_number
			Me._err_description = Me._broker._err_description
			Me._err_source = Me._broker._err_source
			Return True
		End If

		'--- Receive Properties
		Me._connection_string = Me._broker._connection_string
		Me._transaction = Me._broker._transaction

		'--- Clear Objects
		Me._broker = Nothing

		Return False
		Exit Function

ErrorHandler:
		'--- register the error
		Me._err_number = Err.Number
		Me._err_description = Err.Description
		Me._err_source = Err.Source
		Return True

	End Function

	Private Function get_broker()
		On Error GoTo ErrorHandler
		Dim bError As Boolean = False

		'--- Set default to 4
		If Me._dbtype = 0 Then
			Me._dbtype = 4
		End If

		'--- Get the correct broker for this class
		Dim oBroker As New Object
		Select Case Me._dbtype
			Case 1
				Me._broker = New cls_sql_transaction

			Case 2
				Me._broker = Nothing

			Case 3
				Me._broker = Nothing

			Case 4
				Me._broker = Nothing

		End Select

		Return False
		Exit Function

ErrorHandler:
		'--- register the error
		Me._err_number = Err.Number
		Me._err_description = Err.Description
		Me._err_source = Err.Source
		Return True

	End Function

End Class
