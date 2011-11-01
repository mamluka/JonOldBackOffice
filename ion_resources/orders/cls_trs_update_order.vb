'--- This class is a template for running internal events in transactions
Imports System.Data.SqlClient

Public Class cls_trs_update_order
	Inherits ion_resources.cls_transactor

	Shared nLastOrder As Int32 = 0
	Shared cSQLnumberUpdate As String
	Shared oUpdateCommand As New SqlCommand()


	'###################################################################################
	Overrides Function init_transaction(ByRef error_no As Int32, ByRef error_desc As String, ByRef error_source As String) As Boolean
		On Error GoTo ErrorHandler
		Dim bError As Boolean = False

		oUpdateCommand = New SqlCommand(cSQLnumberUpdate, Me.oConnection)
		oUpdateCommand.Transaction = Me.oTransaction

		cSQLnumberUpdate = "delete acc_ORDER_ITEMS where id=" + System.Convert.ToString(Me.general_id)
		oUpdateCommand.CommandType = CommandType.Text
		oUpdateCommand.CommandText = cSQLnumberUpdate
		oUpdateCommand.ExecuteNonQuery()


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

End Class
