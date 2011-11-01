Public Class cls_functions_cashflow
	Inherits iFoundation.cls_error_connection

	Public Function get_cashflowid_from_orderid(ByRef nOrder_id As Int32, ByRef nCashflow_id As Int32) As Boolean
		On Error GoTo ErrorHandler
		Dim bError As Boolean = False

		'--- Define information to read
		'Dim oTmpDataBroker As New iDac.cls_mt_datadeader
		Dim oTmpDataBroker As New iDac.cls_T_datareader
		oTmpDataBroker._dbtype = Me._dbtype
		oTmpDataBroker._connection_string = Me._connection_string
		oTmpDataBroker._table = "acc_cashflow"
		'oTmpDataBroker._id = nId

		Dim cSQL As String
		cSQL = "select id from acc_cashflow where master = 1 and order_id = " & Convert.ToString(nOrder_id)

		'--- Define records
		Dim oField1 As New iDac.cls_cll_datareader
		oField1._field = "id"
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
			nCashflow_id = oTmpDataBroker._fields.Item(1)._result
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

	Public Function get_initialpayment(ByRef nOrder_Id As Int32, ByRef nInitialPayment As Decimal) As Boolean
		On Error GoTo ErrorHandler
		Dim bError As Boolean = False

		'--- Define information to read
		Dim oTmpDataBroker As New iDac.cls_T_datareader
		oTmpDataBroker._dbtype = Me._dbtype
		oTmpDataBroker._connection_string = Me._connection_string
		oTmpDataBroker._table = "acc_cashflow"
		'oTmpDataBroker._id = nId

		Dim cSQL As String
		cSQL = "select id, amount_total from acc_CASHFLOW where master = 1 and order_id =" & Convert.ToString(nOrder_Id)

		'--- Define records
		Dim oField1 As New iDac.cls_cll_datareader
		oField1._field = "id"
		oTmpDataBroker._fields.Add(oField1)
		oField1 = Nothing

		Dim oField2 As New iDac.cls_cll_datareader
		oField2._field = "amount_total"
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
			If IsNumeric(oTmpDataBroker._fields.Item(2)._result) Then
				nInitialPayment = oTmpDataBroker._fields.Item(2)._result
			Else
				nInitialPayment = 0
			End If
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

	Public Function get_initialpayment_method(ByRef nOrder_Id As Int32, ByRef nPaymentType As Int16, ByRef cPaymentName As String) As Boolean
		On Error GoTo ErrorHandler
		Dim bError As Boolean = False

		'--- Define information to read
		Dim oTmpDataBroker As New iDac.cls_T_datareader
		oTmpDataBroker._dbtype = Me._dbtype
		oTmpDataBroker._connection_string = Me._connection_string
		oTmpDataBroker._table = "acc_cashflow"
		'oTmpDataBroker._id = nId

		Dim cSQL As String
		cSQL = "select acc_cashflow.id, acc_cashflow.payment_type, acc_payment_methods.lang1_longdescr as payment_name "
		cSQL = cSQL + "from acc_cashflow, acc_payment_methods "
		cSQL = cSQL + "where acc_cashflow.payment_type =  acc_payment_methods.id "
		cSQL = cSQL + "and master = 1 and order_id = " & Convert.ToString(nOrder_Id)

		'--- Define records
		Dim oField1 As New iDac.cls_cll_datareader
		oField1._field = "id"
		oTmpDataBroker._fields.Add(oField1)
		oField1 = Nothing

		Dim oField2 As New iDac.cls_cll_datareader
		oField2._field = "payment_type"
		oTmpDataBroker._fields.Add(oField2)
		oField2 = Nothing

		Dim oField3 As New iDac.cls_cll_datareader
		oField3._field = "payment_name"
		oTmpDataBroker._fields.Add(oField3)
		oField3 = Nothing


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
			nPaymentType = oTmpDataBroker._fields.Item(2)._result
			cPaymentName = oTmpDataBroker._fields.Item(3)._result
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

	Public Function get_totalpayed(ByVal nOrder_Id As Int32, ByRef nTotalPayed As Decimal) As Boolean
		On Error GoTo ErrorHandler
		Dim bError As Boolean = False

		'--- Get Payment Method
		Dim nPaymentType As Int16
		Dim nPaymentName As String

		Dim oFunctions_cashflow As New ion_two.cls_functions_cashflow
		oFunctions_cashflow._connection_string = Me._connection_string
		oFunctions_cashflow._dbtype = Me._dbtype
		bError = oFunctions_cashflow.get_initialpayment_method(nOrder_id, nPaymentType, nPaymentName)
		If bError Then
			Me._err_number = oFunctions_cashflow._err_number
			Me._err_description = oFunctions_cashflow._err_description
			Me._err_source = oFunctions_cashflow._err_source
			Return True
		End If
		oFunctions_cashflow = Nothing

		'--- Get Total payed
		Dim oTmpDataBroker As New iDac.cls_T_datareader
		oTmpDataBroker._dbtype = Me._dbtype
		oTmpDataBroker._connection_string = Me._connection_string
		oTmpDataBroker._table = "acc_cashflow"
		'oTmpDataBroker._id = nId

		Dim cSQL As String
		If nPaymentType = 1 Then
			cSQL = "select sum(amount_total) as amount from acc_cashflow where master = 0 and approved = 1 and order_id = " & Convert.ToString(nOrder_Id)
		Else
			cSQL = "select sum(amount_total) as amount from acc_cashflow where approved = 1 and order_id = " & Convert.ToString(nOrder_Id)
		End If


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
			If IsDBNull(oTmpDataBroker._fields.Item(1)._result) Then
				nTotalPayed = 0
			Else
				If IsNumeric(oTmpDataBroker._fields.Item(1)._result) Then
					nTotalPayed = oTmpDataBroker._fields.Item(1)._result
				Else
					nTotalPayed = 0
				End If
			End If
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

	Public Function get_payment_made(ByRef nOrder_id As Int32, ByRef bPaymentMade As Boolean) As Boolean
		On Error GoTo ErrorHandler
		Dim bError As Boolean = False

		'--- Define information to read
		Dim oTmpDataBroker As New iDac.cls_T_datareader
		oTmpDataBroker._dbtype = Me._dbtype
		oTmpDataBroker._connection_string = Me._connection_string
		oTmpDataBroker._table = "acc_cashflow"
		'oTmpDataBroker._id = nId

		Dim cSQL As String
		cSQL = "select max(payment_date) as approved from acc_cashflow where order_id = " & Convert.ToString(nOrder_id)

		'--- Define records
		Dim oField1 As New iDac.cls_cll_datareader
		oField1._field = "approved"
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
			If IsDBNull(oTmpDataBroker._fields.Item(1)._result) Then
				bPaymentMade = False
			Else
				bPaymentMade = True
			End If
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

	Public Function get_last_payment_ok(ByRef nOrder_id As Int32, ByRef bApproved As Boolean) As Boolean
		On Error GoTo ErrorHandler
		Dim bError As Boolean = False

		'--- Define information to read
		Dim oTmpDataBroker As New iDac.cls_T_datareader
		oTmpDataBroker._dbtype = Me._dbtype
		oTmpDataBroker._connection_string = Me._connection_string
		oTmpDataBroker._table = "acc_cashflow"
		'oTmpDataBroker._id = nId

		Dim cSQL As String
		cSQL = "select max(payment_date) as approved from acc_cashflow where approved = 1 and order_id = " & Convert.ToString(nOrder_id)

		'--- Define records
		Dim oField1 As New iDac.cls_cll_datareader
		oField1._field = "approved"
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
			If IsDBNull(oTmpDataBroker._fields.Item(1)._result) Then
				bApproved = False
			Else
				bApproved = True
			End If
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

	Public Function get_total_transaction_costs(ByRef nOrder_id As Int32, ByRef nTransactionCosts As Decimal) As Boolean
		On Error GoTo ErrorHandler
		Dim bError As Boolean = False

		'--- Define information to read
		Dim oTmpDataBroker As New iDac.cls_T_datareader
		oTmpDataBroker._dbtype = Me._dbtype
		oTmpDataBroker._connection_string = Me._connection_string
		oTmpDataBroker._table = "acc_cashflow"

		Dim cSQL As String
		cSQL = "select sum(amount_costs) as 'trs_costs' from acc_cashflow where order_id = " & Convert.ToString(nOrder_id)

		'--- Define records
		Dim oField1 As New iDac.cls_cll_datareader
		oField1._field = "trs_costs"
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
			If IsDBNull(oTmpDataBroker._fields.Item(1)._result) Then
				nTransactionCosts = 0
			Else
				nTransactionCosts = oTmpDataBroker._fields.Item(1)._result
			End If
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

	Public Function get_total_interest_costs(ByRef nOrder_id As Int32, ByRef nInterestCosts As Decimal) As Boolean
		On Error GoTo ErrorHandler
		Dim bError As Boolean = False

		'--- Define information to read
		Dim oTmpDataBroker As New iDac.cls_T_datareader
		oTmpDataBroker._dbtype = Me._dbtype
		oTmpDataBroker._connection_string = Me._connection_string
		oTmpDataBroker._table = "acc_cashflow"

		Dim cSQL As String
		cSQL = "select sum(amount_interest) as 'interest'  from acc_cashflow where order_id =" & Convert.ToString(nOrder_id)

		'--- Define records
		Dim oField1 As New iDac.cls_cll_datareader
		oField1._field = "interest"
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
			If IsDBNull(oTmpDataBroker._fields.Item(1)._result) Then
				nInterestCosts = 0
			Else
				nInterestCosts = oTmpDataBroker._fields.Item(1)._result
			End If
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

End Class
