Public Class skl_order
	Inherits iFoundation.cls_error

	Public _order_items As New Collection
	Public _id As Int32
	Public _ordernumber As Int32
	Public _invoice_number As Int32
	Public _invoice_date As DateTime
	Public _invoice_iscopy As Boolean
	Public _cluborder As Boolean
	Public _order_transacted As Boolean
	Public _packaging_id As Int32
	Public _payment_id As Int32
	Public _shipping_id As Int32
	Public _shipping_tracking_no As String
	Public _orderdate As DateTime
	Public _orderdeleted As Boolean
	Public _merchant_notes As String
	Public _customer_notes As String
	Public _lastmodify_Date As DateTime
	Public _lastmodify_User As String
	Public _lastmodify_User_id As Int32

	'--- User
	Public _campaign As String
	Public _affiliate As String
	Public _referrer As String
	Public _remote_ip As String
	Public _user_id As Int32

	'--- Interest Calculation
	Public _interest_start_date As DateTime
	Public _interest_percentage As Decimal

	'--- Amounts
	Public _amnt_items As Decimal
	Public _amnt_labor As Decimal
	Public _amnt_wrapping As Decimal
	Public _amnt_extracharges As Decimal
	Public _amnt_shipping As Decimal
	Public _amnt_vat As Decimal
	Public _amnt_vatperc As Decimal
	Public _amnt_discount As Decimal
	Public _amnt_subtotal As Decimal
	Public _amnt_grandtotal As Decimal

	'--- Billing address
	Public _adrs_billing_name As String
	Public _adrs_billing_street As String
	Public _adrs_billing_city As String
	Public _adrs_billing_zip As String
	Public _adrs_billing_state_id As Int32
	Public _adrs_billing_country_id As Int32
	Public _adrs_billing_phone As String

	'--- Shipping address
	Public _adrs_shipping_name As String
	Public _adrs_shipping_street As String
	Public _adrs_shipping_city As String
	Public _adrs_shipping_zip As String
	Public _adrs_shipping_state_id As Int32
	Public _adrs_shipping_country_id As Int32
	Public _adrs_shipping_phone As String

	'--- Parameters
	Public _cannot_be_edited As Boolean

	'--- Status
	Public _sts_new_order_received As Boolean
	Public _sts_new_order_received_date As DateTime
	Public _sts_waiting_for_authorization As Boolean
	Public _sts_waiting_for_authorization_date As DateTime
	Public _sts_waiting_for_authorization_note As String
	Public _sts_waiting_for_payment As Boolean
	Public _sts_waiting_for_payment_date As DateTime
	Public _sts_waiting_for_payment_note As String
	Public _sts_order_confirmed As Boolean
	Public _sts_order_confirmed_date As DateTime
	Public _sts_order_confirmed_note As String
	Public _sts_partial_order_confirmed As Boolean
	Public _sts_partial_order_confirmed_date As DateTime
	Public _sts_partial_order_confirmed_note As String
	Public _sts_order_failed As Boolean
	Public _sts_order_failed_date As DateTime
	Public _sts_order_failed_note As String
	Public _sts_order_waiting_to_be_send As Boolean
	Public _sts_order_waiting_to_be_send_date As DateTime
	Public _sts_order_waiting_to_be_send_note As String
	Public _sts_order_send As Boolean
	Public _sts_order_send_date As DateTime
	Public _sts_order_send_note As String
	Public _sts_partial_order_send As Boolean
	Public _sts_partial_order_send_date As DateTime
	Public _sts_partial_order_send_note As String
	Public _sts_order_received_by_customer As Boolean
	Public _sts_order_received_by_customer_date As DateTime
	Public _sts_order_received_by_customer_note As String
	Public _sts_partial_order_received_by_customer As Boolean
	Public _sts_partial_order_received_by_customer_date As DateTime
	Public _sts_partial_order_received_by_customer_note As String
	Public _sts_customer_returning_order As Boolean
	Public _sts_customer_returning_order_date As DateTime
	Public _sts_customer_returning_order_note As String
	Public _sts_customer_returning_part_order As Boolean
	Public _sts_customer_returning_part_order_date As DateTime
	Public _sts_customer_returning_part_order_note As String
	Public _sts_customer_refunded As Boolean
	Public _sts_customer_refunded_date As DateTime
	Public _sts_customer_refunded_note As String
	Public _sts_customer_partly_refunded As Boolean
	Public _sts_customer_partly_refunded_date As DateTime
	Public _sts_customer_partly_refunded_note As String
	Public _sts_order_closed As Boolean
	Public _sts_order_closed_date As DateTime
	Public _sts_order_closed_note As String
	Public _sts_order_cancelled As Boolean
	Public _sts_order_cancelled_date As DateTime
	Public _sts_order_cancelled_note As String
	Public _sts_curr_stat As String
    Public _sts_curr_date As DateTime
    ''idex
    Public _idexid As Integer = 1000
    Public _order_currency As String = "USD"
    Public _order_currency_rate As Decimal = 1
    Public _include_receipt As Boolean = True
    Public _hear_fromus As String = "Other"


	Sub New()
		Me._id = 0
		Me._ordernumber = 0
		Me._invoice_number = 0
		Me._invoice_date = #1/1/1900#
		Me._invoice_iscopy = False
		Me._cluborder = False
		Me._order_transacted = False
		Me._packaging_id = 0
		Me._payment_id = 0
		Me._shipping_id = 0
		Me._shipping_tracking_no = ""
		Me._orderdate = #1/1/1900#
		Me._orderdeleted = False
		Me._merchant_notes = ""
		Me._customer_notes = ""
		Me._lastmodify_Date = #1/1/1900#
		Me._lastmodify_User = ""
		Me._lastmodify_User_id = 0

		'--- User
		Me._campaign = ""
		Me._affiliate = ""
		Me._referrer = ""
		Me._remote_ip = ""
		Me._user_id = 0

		'--- Interest Calculation
		Me._interest_start_date = #1/1/1900#
		Me._interest_percentage = 0

		'--- Amounts
		Me._amnt_items = 0
		Me._amnt_labor = 0
		Me._amnt_wrapping = 0
		Me._amnt_extracharges = 0
		Me._amnt_shipping = 0
		Me._amnt_vat = 0
		Me._amnt_vatperc = 0
		Me._amnt_discount = 0
		Me._amnt_subtotal = 0
		Me._amnt_grandtotal = 0

		'--- Billing address
		Me._adrs_billing_name = ""
		Me._adrs_billing_street = ""
		Me._adrs_billing_city = ""
		Me._adrs_billing_zip = ""
		Me._adrs_billing_state_id = 0
		Me._adrs_billing_country_id = 0
		Me._adrs_billing_phone = ""

		'--- Shipping address
		Me._adrs_shipping_name = ""
		Me._adrs_shipping_street = ""
		Me._adrs_shipping_city = ""
		Me._adrs_shipping_zip = ""
		Me._adrs_shipping_state_id = 0
		Me._adrs_shipping_country_id = 0
		Me._adrs_shipping_phone = ""

		'--- Parameters
		Me._cannot_be_edited = False

		'--- Status
		Me._sts_new_order_received = False
		Me._sts_new_order_received_date = #1/1/1900#
		Me._sts_waiting_for_authorization = False
		Me._sts_waiting_for_authorization_date = #1/1/1900#
		Me._sts_waiting_for_authorization_note = ""
		Me._sts_waiting_for_payment = False
		Me._sts_waiting_for_payment_date = #1/1/1900#
		Me._sts_waiting_for_payment_note = ""
		Me._sts_order_confirmed = False
		Me._sts_order_confirmed_date = #1/1/1900#
		Me._sts_order_confirmed_note = ""
		Me._sts_partial_order_confirmed = False
		Me._sts_partial_order_confirmed_date = #1/1/1900#
		Me._sts_partial_order_confirmed_note = ""
		Me._sts_order_failed = False
		Me._sts_order_failed_date = #1/1/1900#
		Me._sts_order_failed_note = ""
		Me._sts_order_waiting_to_be_send = False
		Me._sts_order_waiting_to_be_send_date = #1/1/1900#
		Me._sts_order_waiting_to_be_send_note = ""
		Me._sts_order_send = False
		Me._sts_order_send_date = #1/1/1900#
		Me._sts_order_send_note = ""
		Me._sts_partial_order_send = False
		Me._sts_partial_order_send_date = #1/1/1900#
		Me._sts_partial_order_send_note = ""
		Me._sts_order_received_by_customer = False
		Me._sts_order_received_by_customer_date = #1/1/1900#
		Me._sts_order_received_by_customer_note = ""
		Me._sts_partial_order_received_by_customer = False
		Me._sts_partial_order_received_by_customer_date = #1/1/1900#
		Me._sts_partial_order_received_by_customer_note = ""
		Me._sts_customer_returning_order = False
		Me._sts_customer_returning_order_date = #1/1/1900#
		Me._sts_customer_returning_order_note = ""
		Me._sts_customer_returning_part_order = False
		Me._sts_customer_returning_part_order_date = #1/1/1900#
		Me._sts_customer_returning_part_order_note = ""
		Me._sts_customer_refunded = False
		Me._sts_customer_refunded_date = #1/1/1900#
		Me._sts_customer_refunded_note = ""
		Me._sts_customer_partly_refunded = False
		Me._sts_customer_partly_refunded_date = #1/1/1900#
		Me._sts_customer_partly_refunded_note = ""
		Me._sts_order_closed = False
		Me._sts_order_closed_date = #1/1/1900#
		Me._sts_order_closed_note = ""
		Me._sts_order_cancelled = False
		Me._sts_order_cancelled_date = #1/1/1900#
		Me._sts_order_cancelled_note = ""
		Me._sts_curr_stat = ""
		Me._sts_curr_date = #1/1/1900#
	End Sub

	Public Function recalc() As Boolean
		On Error GoTo ErrorHandler
		Dim bError As Boolean = False

		'--- Calculate all costs
		Me._amnt_subtotal = Me._amnt_items + Me._amnt_wrapping + Me._amnt_shipping + Me._amnt_labor + Me._amnt_extracharges

		'--- Give DISCOUNT
		Me._amnt_subtotal = Me._amnt_subtotal - Me._amnt_discount

		'--- Calculate VAT
		Me._amnt_vat = (Me._amnt_subtotal / 100) * Me._amnt_vatperc

		'--- Calculate GRAND TOTAL
		Me._amnt_grandtotal = Me._amnt_subtotal + Me._amnt_vat


		Dim oFunctions As New iFunctions.cls_calc
		bError = oFunctions.get_rounddecimalby5(Me._amnt_grandtotal)
		If bError Then
			Me._err_number = oFunctions._err_number
			Me._err_description = oFunctions._err_description
			Me._err_source = oFunctions._err_source
			Return True
		End If
		oFunctions = Nothing


		Return False
		Exit Function

ErrorHandler:
		Me._err_number = Err.Number
		Me._err_description = Err.Description
		Me._err_source = Err.Source
		Return True
	End Function


End Class
