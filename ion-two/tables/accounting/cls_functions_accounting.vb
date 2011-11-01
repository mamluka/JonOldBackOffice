Public Class cls_functions_accounting
	Inherits iFoundation.cls_error_connection

	Public Function get_account_total(ByVal nAccount_Id As Int32, ByRef nAccountTotal As Decimal) As Boolean
		On Error GoTo ErrorHandler
		Dim bError As Boolean = False

		'--- Define information to read
		Dim oTmpDataBroker As New iDac.cls_T_datareader
		oTmpDataBroker._dbtype = Me._dbtype
		oTmpDataBroker._connection_string = Me._connection_string
		oTmpDataBroker._table = "v_general_books"

		Dim cSQL As String
		cSQL = "select sum(amount) as amount from v_general_books where account_id = " & Convert.ToString(nAccount_Id)

		'--- Define records
		Dim oField1 As New iDac.cls_cll_datareader
		oField1._field = "amount"
		oTmpDataBroker._fields.Add(oField1)
		oField1 = Nothing

		'--- Get info
		bError = oTmpDataBroker.read(cSQL)
		If bError Then
			Me._err_number = oTmpDataBroker._err_number
			Me._err_description = oTmpDataBroker._err_description
			Me._err_source = oTmpDataBroker._err_source
			Return True
		End If

		'--- Fill results
		If oTmpDataBroker._hasresult Then
			nAccountTotal = oTmpDataBroker._fields.Item(1)._result
		End If

		Return False
		Exit Function

ErrorHandler:
		Me._err_number = Err.Number
		Me._err_description = Err.Description
		Me._err_source = Err.Source
		Return True

	End Function

	Public Function get_account_name(ByRef nAccount_Id As Int32, ByRef cAccountName As String) As Boolean
		On Error GoTo ErrorHandler

		'--- local definitions
		Dim bError As Boolean = False

		'--- Define information to read
		Dim oTmpDataBroker As New iDac.cls_T_datareader
		oTmpDataBroker._dbtype = Me._dbtype
		oTmpDataBroker._connection_string = Me._connection_string
		oTmpDataBroker._table = "acc_account_names"
		oTmpDataBroker._id = nAccount_Id

		'--- Define records
		Dim oField1 As New iDac.cls_cll_datareader
		oField1._field = "id"
		oTmpDataBroker._fields.Add(oField1)
		oField1 = Nothing

		Dim oField2 As New iDac.cls_cll_datareader
		oField2._field = "lang1_longdescr"
		oTmpDataBroker._fields.Add(oField2)
		oField2 = Nothing

		'--- Get info
		bError = oTmpDataBroker.read()
		If bError Then
			Me._err_number = oTmpDataBroker._err_number
			Me._err_description = oTmpDataBroker._err_description
			Me._err_source = oTmpDataBroker._err_source
			Return True
		End If

		'--- Fill results
		If oTmpDataBroker._hasresult Then
			nAccount_Id = oTmpDataBroker._fields.Item(1)._result
			cAccountName = oTmpDataBroker._fields.Item(2)._result
		End If

		Return False
		Exit Function

ErrorHandler:

		'--- register the error
		Me._err_number = Err.Number
		Me._err_description = Err.Description
		Me._err_source = Err.Source
		Return True

	End Function

	Public Function get_rate(ByRef nRate As Decimal, Optional ByRef dDate As DateTime = #1/1/1900#) As Boolean
		On Error GoTo ErrorHandler
		Dim bError As Boolean = False

		'--- Define information to read
		Dim oTmpDataBroker As New iDac.cls_T_datareader
		oTmpDataBroker._dbtype = Me._dbtype
		oTmpDataBroker._connection_string = Me._connection_string
		oTmpDataBroker._table = "v_general_books"

		Dim cSQL As String
		If dDate <> #1/1/1900# Then
			cSQL = "select rate_date, rate from sys_rates where rate_date = '" & dDate & "' order by rate_date desc"
		Else
			cSQL = "select rate_date, rate from sys_rates order by rate_date desc"
		End If

		'--- Define records
		Dim oField1 As New iDac.cls_cll_datareader
		oField1._field = "rate_date"
		oTmpDataBroker._fields.Add(oField1)
		oField1 = Nothing

		Dim oField2 As New iDac.cls_cll_datareader
		oField2._field = "rate"
		oTmpDataBroker._fields.Add(oField2)
		oField2 = Nothing

		'--- Get info
		bError = oTmpDataBroker.read(cSQL)
		If bError Then
			Me._err_number = oTmpDataBroker._err_number
			Me._err_description = oTmpDataBroker._err_description
			Me._err_source = oTmpDataBroker._err_source
			Return True
		End If

		'--- Fill results
		If oTmpDataBroker._hasresult Then
			dDate = oTmpDataBroker._fields.Item(1)._result
			nRate = oTmpDataBroker._fields.Item(2)._result
		End If

		Return False
		Exit Function

ErrorHandler:
		Me._err_number = Err.Number
		Me._err_description = Err.Description
		Me._err_source = Err.Source
		Return True

	End Function

	Public Function set_rate(ByVal nCurId As Int32, ByVal dRateDate As DateTime, ByVal nRate As Decimal) As Boolean
		On Error GoTo ErrorHandler

		'--- local definitions
		Dim bError As Boolean = False

		Dim oDacCommand As New iDac.cls_T_command
		oDacCommand._connection_string = Me._connection_string
		oDacCommand._dbtype = Me._dbtype
		oDacCommand._transaction = Me._idac_transaction._transaction
		oDacCommand._sqlstring = "insert into sys_rates (cur_id, rate_date, rate) values (" & nCurId & ", '" & dRateDate & "', " & nRate & ")"
		bError = oDacCommand.transact_command
		If bError Then
			Me._idac_transaction._transaction.Rollback()
			Me._err_number = oDacCommand._err_number
			Me._err_description = oDacCommand._err_description
			Me._err_source = oDacCommand._err_source
			Return True
		End If


		Return False
		Exit Function

ErrorHandler:
		Me._err_number = Err.Number
		Me._err_description = Err.Description
		Me._err_source = Err.Source
		Return True

	End Function

	Public Function set_cancel_order_payment(ByVal nOrder_Id As Int32) As Boolean
		On Error GoTo ErrorHandler

		'--- local definitions
		Dim bError As Boolean = False

		Dim oDacCommand As New iDac.cls_T_command
		oDacCommand._connection_string = Me._connection_string
		oDacCommand._dbtype = Me._dbtype
		oDacCommand._transaction = Me._idac_transaction._transaction

		'--- Remove order from Supplier Books
		oDacCommand._sqlstring = "delete from acc_suppliers_books where order_id = " + Convert.ToString(nOrder_Id)
		bError = oDacCommand.transact_command
		If bError Then
			Me._idac_transaction._transaction.Rollback()
			Me._err_number = oDacCommand._err_number
			Me._err_description = oDacCommand._err_description
			Me._err_source = oDacCommand._err_source
			Return True
		End If

		'--- Remove order from General Books
		oDacCommand._sqlstring = "delete from acc_general_books where order_id = " + Convert.ToString(nOrder_Id)
		bError = oDacCommand.transact_command
		If bError Then
			Me._idac_transaction._transaction.Rollback()
			Me._err_number = oDacCommand._err_number
			Me._err_description = oDacCommand._err_description
			Me._err_source = oDacCommand._err_source
			Return True
		End If

		'--- Remove order from Cashflow
		oDacCommand._sqlstring = "delete from acc_cashflow where order_id = " + Convert.ToString(nOrder_Id)
		bError = oDacCommand.transact_command
		If bError Then
			Me._idac_transaction._transaction.Rollback()
			Me._err_number = oDacCommand._err_number
			Me._err_description = oDacCommand._err_description
			Me._err_source = oDacCommand._err_source
			Return True
		End If


		Return False
		Exit Function

ErrorHandler:
		Me._err_number = Err.Number
		Me._err_description = Err.Description
		Me._err_source = Err.Source
		Return True

	End Function

End Class
