Public Class cls_payment_calc
	Inherits iFoundation.cls_error_connection

	Public _order_number As Int32
	Public _order_total As Decimal		'--- The total of the order
	Public _order_total_payed As Decimal	 '--- Total amount payed up till now
	Public _order_left_to_pay As Decimal	 '--- Total amount left to pay not including Interest
	Public _order_total_left_to_pay As Decimal	 '--- Total amount left to pay including Interest
	Public _order_initial_payment As Decimal	 '--- The initial payment that was made
	Public _order_interest As Decimal	 '--- Amount of interest calculated from order_total
	Public _order_club As Boolean	'--- if order is a club order
	Public _payment_type As Int32
	Public _payment_name As String

	Public Function calc_order(ByVal nOrder_id As Int32) As Boolean
		On Error GoTo ErrorHandler
		Dim bError As Boolean = False


		'--- instantiate order functions
		Dim oFunctions_orders As New ion_two.cls_functions_orders
		oFunctions_orders._connection_string = Me._connection_string
		oFunctions_orders._dbtype = Me._dbtype

		'--- instantiate payment functions
		Dim oFunctions_cashflow As New ion_two.cls_functions_cashflow
		oFunctions_cashflow._connection_string = Me._connection_string
		oFunctions_cashflow._dbtype = Me._dbtype


		'--- GET order NUMBER
		bError = oFunctions_orders.get_order_number(nOrder_id, Me._order_number)
		If bError Then
			Me._err_number = oFunctions_orders._err_number
			Me._err_description = oFunctions_orders._err_description
			Me._err_source = oFunctions_orders._err_source
			Return True
		End If

		'--- GET order TOTAL
		bError = oFunctions_orders.get_order_total(nOrder_id, Me._order_total)
		If bError Then
			Me._err_number = oFunctions_orders._err_number
			Me._err_description = oFunctions_orders._err_description
			Me._err_source = oFunctions_orders._err_source
			Return True
		End If

		'--- GET order USERID
		bError = oFunctions_orders.get_order_userid(nOrder_id, Me._user_id)
		If bError Then
			Me._err_number = oFunctions_orders._err_number
			Me._err_description = oFunctions_orders._err_description
			Me._err_source = oFunctions_orders._err_source
			Return True
		End If


		'--- GET payment INITIAL PAYMENT
		bError = oFunctions_cashflow.get_initialpayment(nOrder_id, Me._order_initial_payment)
		If bError Then
			Me._err_number = oFunctions_orders._err_number
			Me._err_description = oFunctions_orders._err_description
			Me._err_source = oFunctions_orders._err_source
			Return True
		End If


		'--- GET payment INITIAL PAYMENT METHOD
		bError = oFunctions_cashflow.get_initialpayment_method(nOrder_id, Me._payment_type, Me._payment_name)
		If bError Then
			Me._err_number = oFunctions_orders._err_number
			Me._err_description = oFunctions_orders._err_description
			Me._err_source = oFunctions_orders._err_source
			Return True
		End If

		'--- GET TOTAL PAYED
		bError = oFunctions_cashflow.get_totalpayed(nOrder_id, Me._order_total_payed)
		If bError Then
			Me._err_number = oFunctions_orders._err_number
			Me._err_description = oFunctions_orders._err_description
			Me._err_source = oFunctions_orders._err_source
			Return True
		End If

		'--- Calc interest
		Dim nInterestRate As Decimal
		Dim dInterestStartDate As Date
		bError = oFunctions_orders.get_interest(nOrder_id, nInterestRate, dInterestStartDate)
		If bError Then
			Me._err_number = oFunctions_orders._err_number
			Me._err_description = oFunctions_orders._err_description
			Me._err_source = oFunctions_orders._err_source
			Return True
		End If

		'--- Get club order
		bError = oFunctions_orders.get_order_club(nOrder_id, Me._order_club)
		If bError Then
			Me._err_number = oFunctions_orders._err_number
			Me._err_description = oFunctions_orders._err_description
			Me._err_source = oFunctions_orders._err_source
			Return True
		End If


		'--- Add interest
		'--- Make sure interest is not calculated below ZERO
		Dim nStartAmount As Decimal = (Me._order_total - Me._order_total_payed)
		If nStartAmount < 0 Then
			nStartAmount = 0
		End If


		'--- Calculate interest
		Dim oInterest As New iFunctions.cls_interest
		oInterest._start_date = dInterestStartDate
		oInterest._end_date = Date.Today
		oInterest._start_amount = nStartAmount
		oInterest._interest = nInterestRate
		bError = oInterest.calc
		If bError Then
			Me._err_number = oInterest._err_number
			Me._err_description = oInterest._err_description
			Me._err_source = oInterest._err_source
			Return True
		End If

		'--- Get interest
		Me._order_interest = oInterest._amount_intrest

		'--- Calculate LEFT TO PAY
		Me._order_total_left_to_pay = oInterest._end_amount

		Me._order_left_to_pay = Me._order_total - Me._order_total_payed


		'--- release
		oFunctions_cashflow = Nothing
		oFunctions_orders = Nothing
		oInterest = Nothing

		Return False
		Exit Function

ErrorHandler:
		Me._err_number = Err.Number
		Me._err_description = Err.Description
		Me._err_source = Err.Source
		Return True

	End Function



End Class
