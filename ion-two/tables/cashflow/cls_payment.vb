Public Class cls_payment
	Inherits iFoundation.cls_error_connection

	Public _payment_type As Int16
	Public _account As Int16
	Public _initial_payment As Decimal
	Public _user_name As String

	Public Function make_payment(ByVal nOrder_id As Int32, ByRef oPayment As skl_cashflow, ByRef bSuccess As Boolean) As Boolean
		On Error GoTo ErrorHandler
		Dim bError As Boolean = False

		'--- nAccount = Type of payment, club or Regular
		'--- bInitialPayment = Is this the initial (1st) payment, CC usualy J5


		'--- Set the payment
		bError = Me.set_payment(oPayment)
		If bError Then
			Me._err_number = Err.Number
			Me._err_description = Err.Description
			Me._err_source = Err.Source
			Return True
		End If


		'---Calculate interest
		bError = Me.calc_interest(nOrder_id, oPayment)
		If bError Then
			Me._err_number = Err.Number
			Me._err_description = Err.Description
			Me._err_source = Err.Source
			Return True
		End If


		'--- Do web payment
		If Me._payment_type = 1 Then
			bError = Me.do_webpayment(oPayment, bSuccess)
			If bError Then
				Me._err_number = Err.Number
				Me._err_description = Err.Description
				Me._err_source = Err.Source
				Return True
			End If
		Else
			bSuccess = True
		End If


		If bSuccess Then
			oPayment._payment_type = Me._payment_type
			oPayment._payment_date = Date.Now
			oPayment._order_id = nOrder_id
			oPayment._user_id = Me._user_id
			oPayment._approved = False
			oPayment._approved_date = #1/1/1900#
			oPayment._received = False
			oPayment._received_date = #1/1/1900#
			oPayment._LastModify_Date = Date.Now
			oPayment._LastModify_User = Me._user_name
			oPayment._LastModify_User_id = Me._user_id

			'--- save payment
			Dim oCashflow_Logics As New ion_two.cls_cashflow_lgc
			oCashflow_Logics._connection_string = Me._connection_string
			oCashflow_Logics._dbtype = Me._dbtype
			oCashflow_Logics._user_name = Me._user_name
			oCashflow_Logics._user_id = Me._user_id
			bError = oCashflow_Logics.insert(oPayment)
			If bError Then
				Me._err_number = oCashflow_Logics._err_source
				Me._err_description = oCashflow_Logics._err_description
				Me._err_source = oCashflow_Logics._err_source
				Return True
			End If

		End If

		Return False
		Exit Function

ErrorHandler:
		Me._err_number = Err.Number
		Me._err_description = Err.Description
		Me._err_source = Err.Source
		Return True

	End Function

	Private Function do_webpayment(ByRef oPayment As skl_cashflow, ByRef bSuccess As Boolean) As Boolean
		On Error GoTo ErrorHandler
		Dim bError As Boolean = False

		'--- Set payment parameters
		Dim oTmpWebPayment As New ion_two.cls_webpayment
		oTmpWebPayment._cc_clubmember = oPayment._cc_clubmember
		oTmpWebPayment._cc_cvv = oPayment._cc_cvv
		oTmpWebPayment._cc_exp_month = oPayment._cc_exp_month
		oTmpWebPayment._cc_exp_year = oPayment._cc_exp_year
		oTmpWebPayment._cc_name = oPayment._cc_name
		oTmpWebPayment._cc_number = oPayment._cc_number
		oTmpWebPayment._cc_type_id = oPayment._cc_type_id
		oTmpWebPayment._cc_user_ssn = oPayment._cc_user_ssn
		oTmpWebPayment._amount = oPayment._amount_total

		'--- Get payment
		bError = oTmpWebPayment.make_webpayment(bSuccess, Me._account)
		If bError Then
			Me._err_number = oTmpWebPayment._err_number
			Me._err_description = oTmpWebPayment._err_description
			Me._err_source = oTmpWebPayment._err_source
			Return True
		End If

		'--- Return status
		oPayment._cc_confermation = oTmpWebPayment._cc_confermation
		oPayment._cc_cleared = oTmpWebPayment._cc_cleared


		'--- If Payment is real (not J5) and is CreditCard then Approve automaticly
		If Not oPayment._master Then
			If bSuccess Then
				oPayment._approved = True
				oPayment._approved_date = Date.Now
			End If
		End If

		'--- release
		oTmpWebPayment = Nothing


		Return False
		Exit Function

ErrorHandler:
		Me._err_number = Err.Number
		Me._err_description = Err.Description
		Me._err_source = Err.Source
		Return True

	End Function

	Private Function set_payment(ByRef oPayment As skl_cashflow) As Boolean
		On Error GoTo ErrorHandler
		Dim bError As Boolean = False

		Select Case Me._payment_type
			Case 1
				'--- CC

				'--- BT
				oPayment._mt_bank = ""
				oPayment._mt_account = ""
				oPayment._mt_name = ""
				oPayment._mt_code = ""

				'--- CQ
				oPayment._cq_bank = ""
				oPayment._cq_name = ""
				oPayment._cq_account = ""
				oPayment._cq_date = #1/1/1900#

			Case 2
				'--- CC
				oPayment._cc_type_id = 0
				oPayment._cc_name = ""
				oPayment._cc_number = ""
				oPayment._cc_cvv = ""
				oPayment._cc_exp_year = 0
				oPayment._cc_exp_month = 0
				oPayment._cc_user_ssn = ""
				oPayment._cc_clubmember = False
				oPayment._cc_confermation = ""
				oPayment._cc_cleared = False

				'--- BT
				oPayment._mt_bank = ""
				oPayment._mt_account = ""
				oPayment._mt_name = ""
				oPayment._mt_code = ""

				'--- CQ
				oPayment._cq_bank = ""
				oPayment._cq_name = ""
				oPayment._cq_account = ""
				oPayment._cq_date = #1/1/1900#

			Case 3
				'--- CC
				oPayment._cc_type_id = 0
				oPayment._cc_name = ""
				oPayment._cc_number = ""
				oPayment._cc_cvv = ""
				oPayment._cc_exp_year = 0
				oPayment._cc_exp_month = 0
				oPayment._cc_user_ssn = ""
				oPayment._cc_clubmember = False
				oPayment._cc_confermation = ""
				oPayment._cc_cleared = False

				'--- BT
				oPayment._mt_bank = ""
				oPayment._mt_account = ""
				oPayment._mt_name = ""
				oPayment._mt_code = ""

				'--- CQ
				oPayment._cq_bank = ""
				oPayment._cq_name = ""
				oPayment._cq_account = ""
                oPayment._cq_date = #1/1/1900#

            Case 4

                '--- CC
                oPayment._cc_type_id = 0
                oPayment._cc_name = ""
                oPayment._cc_number = ""
                oPayment._cc_cvv = ""
                oPayment._cc_exp_year = 0
                oPayment._cc_exp_month = 0
                oPayment._cc_user_ssn = ""
                oPayment._cc_clubmember = False
                oPayment._cc_confermation = ""
                oPayment._cc_cleared = False

                '--- BT
                oPayment._mt_bank = ""
                oPayment._mt_account = ""
                oPayment._mt_name = ""
                oPayment._mt_code = ""

                '--- CQ
                oPayment._cq_bank = ""
                oPayment._cq_name = ""
                oPayment._cq_account = ""
                oPayment._cq_date = #1/1/1900#


        End Select

		Return False
		Exit Function

ErrorHandler:
		Me._err_number = Err.Number
		Me._err_description = Err.Description
		Me._err_source = Err.Source
		Return True
	End Function

	Private Function calc_interest(ByVal nOrder_id As Int32, ByRef oPayment As skl_cashflow) As Boolean
		On Error GoTo ErrorHandler
		Dim bError As Boolean = False

		'--- Get interest from order
		Dim nInterestRate As Decimal
		Dim dInterestStartDate As Date
		'--- instantiate order functions
		Dim oFunctions_orders As New ion_two.cls_functions_orders
		oFunctions_orders._connection_string = Me._connection_string
		oFunctions_orders._dbtype = Me._dbtype
		bError = oFunctions_orders.get_interest(nOrder_id, nInterestRate, dInterestStartDate)
		If bError Then
			Me._err_number = oFunctions_orders._err_number
			Me._err_description = oFunctions_orders._err_description
			Me._err_source = oFunctions_orders._err_source
			Return True
		End If
		oFunctions_orders = Nothing

		'--- Calculate interest
		Dim oTmpInterest As New iFunctions.cls_interest
		oTmpInterest._start_date = dInterestStartDate
		oTmpInterest._end_date = Date.Today
		oTmpInterest._start_amount = Me._initial_payment
		oTmpInterest._interest = nInterestRate
		bError = oTmpInterest.calc()
		If bError Then
			Me._err_number = oTmpInterest._err_source
			Me._err_description = oTmpInterest._err_description
			Me._err_source = oTmpInterest._err_source
			Return True
		End If

		'--- Show Interest amount
		oPayment._amount_interest = oTmpInterest._amount_intrest
		oPayment._amount_total = oTmpInterest._end_amount

		'--- Release
		oTmpInterest = Nothing

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
