Public Class cls_order_lgc
	Inherits iFoundation.cls_logics_sub

	Sub New()
		'--- Set working table
		Me._tablename = "acc_ORDERS"

		'--- Get module name
		Dim oTmpStack As New System.Diagnostics.StackFrame
		Me._module = oTmpStack.GetMethod.ReflectedType.FullName()
		oTmpStack = Nothing

	End Sub

	Function insert(ByRef oDataTable As skl_order) As Boolean
		On Error GoTo ErrorHandler
		Dim bError As Boolean = False


		'--- Get next Order Number
		Dim nOrderNumber As Int32
		Dim oSysCounters_logics As New ion_two.cls_syscounters_lgc
		oSysCounters_logics._connection_string = Me._connection_string
		oSysCounters_logics._dbtype = Me._dbtype
		bError = oSysCounters_logics.get_counter(1, nOrderNumber)
		If bError Then
			Me._err_number = oSysCounters_logics._err_number
			Me._err_description = oSysCounters_logics._err_description
			Me._err_source = oSysCounters_logics._err_source
			Return True
		End If
		oDataTable._ordernumber = nOrderNumber

		'--- Get Dataset
		Dim oTmpDataset As DataSet = New ion_two.ds_order
		Dim oTmpDataTable As DataTable = oTmpDataset.Tables(_tablename)

		'--- Assign Order
		Dim oTmpDataRow As DataRow
		oTmpDataRow = oTmpDataTable.NewRow

		oTmpDataRow("ordernumber") = oDataTable._ordernumber
		oTmpDataRow("orderdate") = oDataTable._orderdate
		oTmpDataRow("InvoiceNumber") = 0
		oTmpDataRow("InvoiceDate") = #1/1/1900#
		oTmpDataRow("InvoiceCopy") = 0
		oTmpDataRow("ClubOrder") = oDataTable._cluborder
		oTmpDataRow("campaign") = oDataTable._campaign
		oTmpDataRow("affiliate") = oDataTable._affiliate
		oTmpDataRow("referrer") = oDataTable._referrer
		oTmpDataRow("remote_ip") = oDataTable._remote_ip
		oTmpDataRow("order_transacted") = 0
		oTmpDataRow("JewelrySize") = ""

		oTmpDataRow("user_id") = oDataTable._user_id
		oTmpDataRow("packaging_id") = oDataTable._packaging_id
		oTmpDataRow("payment_id") = oDataTable._payment_id
		oTmpDataRow("shipping_id") = oDataTable._shipping_id
		oTmpDataRow("shipping_tracking_no") = ""

		oTmpDataRow("amnt_items") = oDataTable._amnt_items
		oTmpDataRow("amnt_wrapping") = oDataTable._amnt_wrapping
		oTmpDataRow("amnt_shipping") = oDataTable._amnt_shipping
		oTmpDataRow("amnt_extracharges") = oDataTable._amnt_extracharges
		oTmpDataRow("amnt_labor") = oDataTable._amnt_labor
		oTmpDataRow("amnt_vat") = oDataTable._amnt_vat
		oTmpDataRow("amnt_subtotal") = oDataTable._amnt_subtotal
		oTmpDataRow("amnt_discount") = oDataTable._amnt_discount
		oTmpDataRow("amnt_grandtotal") = oDataTable._amnt_grandtotal

		oTmpDataRow("adrs_billing_name") = oDataTable._adrs_billing_name
		oTmpDataRow("adrs_billing_street") = oDataTable._adrs_billing_street
		oTmpDataRow("adrs_billing_city") = oDataTable._adrs_billing_city
		oTmpDataRow("adrs_billing_zip") = oDataTable._adrs_billing_zip
		oTmpDataRow("adrs_billing_state_id") = oDataTable._adrs_billing_state_id
		oTmpDataRow("adrs_billing_country_id") = oDataTable._adrs_billing_country_id
		oTmpDataRow("adrs_billing_phone") = oDataTable._adrs_billing_phone

		oTmpDataRow("adrs_delivery_name") = oDataTable._adrs_shipping_name
		oTmpDataRow("adrs_delivery_street") = oDataTable._adrs_shipping_street
		oTmpDataRow("adrs_delivery_city") = oDataTable._adrs_shipping_city
		oTmpDataRow("adrs_delivery_zip") = oDataTable._adrs_shipping_zip
		oTmpDataRow("adrs_delivery_state_id") = oDataTable._adrs_shipping_state_id
		oTmpDataRow("adrs_delivery_country_id") = oDataTable._adrs_shipping_country_id
		oTmpDataRow("adrs_delivery_phone") = oDataTable._adrs_shipping_phone

		oTmpDataRow("cannot_be_edited") = False

		oTmpDataRow("sts1_new_order_received") = True
		oTmpDataRow("sts1_new_order_received_date") = Date.Now

		oTmpDataRow("sts2_waiting_for_authorization") = False
		oTmpDataRow("sts2_waiting_for_authorization_date") = #1/1/1900#
		oTmpDataRow("sts2_waiting_for_authorization_note") = ""

		oTmpDataRow("sts3_waiting_for_payment") = False
		oTmpDataRow("sts3_waiting_for_payment_date") = #1/1/1900#
		oTmpDataRow("sts3_waiting_for_payment_note") = ""

		oTmpDataRow("sts4_order_confirmed") = False
		oTmpDataRow("sts4_order_confirmed_date") = #1/1/1900#
		oTmpDataRow("sts4_order_confirmed_note") = ""

		oTmpDataRow("sts5_partial_order_confirmed") = False
		oTmpDataRow("sts5_partial_order_confirmed_date") = #1/1/1900#
		oTmpDataRow("sts5_partial_order_confirmed_note") = ""

		oTmpDataRow("sts6_order_failed") = False
		oTmpDataRow("sts6_order_failed_date") = #1/1/1900#
		oTmpDataRow("sts6_order_failed_note") = ""

		oTmpDataRow("sts7_order_waiting_to_be_send") = False
		oTmpDataRow("sts7_order_waiting_to_be_send_date") = #1/1/1900#
		oTmpDataRow("sts7_order_waiting_to_be_send_note") = ""

		oTmpDataRow("sts8_order_send") = False
		oTmpDataRow("sts8_order_send_date") = #1/1/1900#
		oTmpDataRow("sts8_order_send_note") = ""

		oTmpDataRow("sts9_partial_order_send") = False
		oTmpDataRow("sts9_partial_order_send_date") = #1/1/1900#
		oTmpDataRow("sts9_partial_order_send_note") = ""

		oTmpDataRow("sts10_order_received_by_customer") = False
		oTmpDataRow("sts10_order_received_by_customer_date") = #1/1/1900#
		oTmpDataRow("sts10_order_received_by_customer_note") = ""

		oTmpDataRow("sts11_partial_order_received_by_customer") = False
		oTmpDataRow("sts11_partial_order_received_by_customer_date") = #1/1/1900#
		oTmpDataRow("sts11_partial_order_received_by_customer_note") = ""

		oTmpDataRow("sts12_customer_returning_order") = False
		oTmpDataRow("sts12_customer_returning_order_date") = #1/1/1900#
		oTmpDataRow("sts12_customer_returning_order_note") = ""

		oTmpDataRow("sts13_customer_returning_part_order") = False
		oTmpDataRow("sts13_customer_returning_part_order_date") = #1/1/1900#
		oTmpDataRow("sts13_customer_returning_part_order_note") = ""

		oTmpDataRow("sts14_customer_refunded") = False
		oTmpDataRow("sts14_customer_refunded_date") = #1/1/1900#
		oTmpDataRow("sts14_customer_refunded_note") = ""

		oTmpDataRow("sts15_customer_partly_refunded") = False
		oTmpDataRow("sts15_customer_partly_refunded_date") = #1/1/1900#
		oTmpDataRow("sts15_customer_partly_refunded_note") = ""

		oTmpDataRow("sts16_order_closed") = False
		oTmpDataRow("sts16_order_closed_date") = #1/1/1900#
		oTmpDataRow("sts16_order_closed_note") = ""

		oTmpDataRow("sts17_order_cancelled") = False
		oTmpDataRow("sts17_order_cancelled_date") = #1/1/1900#
		oTmpDataRow("sts17_order_cancelled_note") = ""

		oTmpDataRow("sts_curr_stat") = "New order received"
		oTmpDataRow("sts_curr_date") = Date.Now

		oTmpDataRow("Interest_start_date") = oDataTable._interest_start_date
		oTmpDataRow("Interest_percent") = oDataTable._interest_percentage

		oTmpDataRow("OrderDeleted") = False
		oTmpDataRow("Merchant_Notes") = ""
		oTmpDataRow("Customer_Notes") = oDataTable._customer_notes

		'--- Handle Audit
		oTmpDataRow("LASTMODIFY_DATE") = Date.Now
		oTmpDataRow("LASTMODIFY_USER") = oDataTable._lastmodify_User
        oTmpDataRow("LASTMODIFY_USER_ID") = oDataTable._lastmodify_User_id
        oTmpDataRow("order_currency") = oDataTable._order_currency
        oTmpDataRow("order_currency_rate") = oDataTable._order_currency_rate

        oTmpDataRow("hear_fromus") = oDataTable._hear_fromus
        oTmpDataRow("include_receipt") = oDataTable._include_receipt
        ''handle idex
        ''  oTmpDataRow("IDEX") = oDataTable._idexid

		oTmpDataTable.Rows.Add(oTmpDataRow)



		If IsNothing(Me._idac_transaction) Then
			'### Start transaction
			Dim oTransaction As New iDac.cls_T_transaction
			oTransaction._connection_string = Me._connection_string
			oTransaction._dbtype = Me._dbtype
			bError = oTransaction.start()
			If bError Then
				Me._err_number = oTransaction._err_number
				Me._err_description = oTransaction._err_description
				Me._err_source = oTransaction._err_source
				Return True
			End If
			'--- Assign to ME
			Me._idac_transaction = oTransaction
			oTransaction = Nothing
		Else
			Me._inherited_transaction = True
		End If


		'### Set ORDER
		'--- Instantiate the Transactor
		Dim oTransactor As New iDac.cls_T_transactor
		oTransactor._transaction = Me._idac_transaction._transaction
		oTransactor._connection_string = Me._connection_string
		oTransactor._dbtype = Me._dbtype

		'--- Prepare and load table 1
		Dim oTable1 As New iDac.cls_cll_datatables
		oTable1._datatable = oTmpDataTable
		oTransactor._i_cll_datatables.Add(oTable1)

		'--- Write Table
		bError = oTransactor.transact_insert
		If bError Then
			Me._idac_transaction._transaction.Rollback()
			Me._err_number = oTransactor._err_number
			Me._err_description = oTransactor._err_description
			Me._err_source = oTransactor._err_source
			Return True
		End If
		'###


		'--- Get orderID from order
		Dim nOrder_id As Int32 = oTransactor._i_cll_datatables(1)._info(1)._id

		'--- Assign ID to return
		oDataTable._id = nOrder_id


		'--- Set ORDER ITEMS
		Dim oOrderItems_logics As New ion_two.cls_order_items_lgc
		oOrderItems_logics._connection_string = Me._connection_string
		oOrderItems_logics._dbtype = Me._dbtype
		oOrderItems_logics._idac_transaction = Me._idac_transaction
		bError = oOrderItems_logics.insert(oDataTable, nOrder_id, oDataTable._ordernumber)
		If bError Then
			Me._idac_transaction._transaction.Rollback()
			Me._err_number = oOrderItems_logics._err_number
			Me._err_description = oOrderItems_logics._err_description
			Me._err_source = oOrderItems_logics._err_source
			Return True
		End If

		'--- Set the counters
		oSysCounters_logics._idac_transaction = Me._idac_transaction
		bError = oSysCounters_logics.set_counter(1, nOrderNumber)
		If bError Then
			Me._idac_transaction._transaction.Rollback()
			Me._err_number = oSysCounters_logics._err_number
			Me._err_description = oSysCounters_logics._err_description
			Me._err_source = oSysCounters_logics._err_source
			Return True
		End If

		'--- Close the transaction
		If Not Me._inherited_transaction Then
			bError = Me._idac_transaction.close()
			If bError Then
				Me._err_number = Me._idac_transaction._err_number
				Me._err_description = Me._idac_transaction._err_description
				Me._err_source = Me._idac_transaction._err_source
				Return True
			End If
		End If

		'### End transaction

		oTable1 = Nothing
		oTransactor = Nothing
		oSysCounters_logics = Nothing

		Return False
		Exit Function

ErrorHandler:
		Me._err_number = Err.Number
		Me._err_description = Err.Description
		Me._err_source = Err.Source
		Return True
	End Function

	Function read(ByVal nId As Int32, ByRef oDataTable As skl_order) As Boolean
		On Error GoTo ErrorHandler
		Dim bError As Boolean = False

		'--- Get Item
		Dim oReadTransactor As New iDac.cls_T_read
		oReadTransactor._connection_string = Me._connection_string
		oReadTransactor._dbtype = Me._dbtype
		oReadTransactor._tablename = Me._tablename
		bError = oReadTransactor.transact_read(nId)
		If bError Then
			Me._err_number = oReadTransactor._err_number
			Me._err_description = oReadTransactor._err_description
			Me._err_source = oReadTransactor._err_source
			Return True
		End If

		'--- Return Error if no records were fatched
		If oReadTransactor._datatable.Rows.Count = 0 Then
			Err.Raise(7003, Me._module + ":read", "No records fetched.")
		End If

		'--- Map to Skeleton
		Dim oTmpDataRow As DataRow
		oTmpDataRow = oReadTransactor._datatable.Rows(0)

		oDataTable._id = oTmpDataRow("id")
		oDataTable._ordernumber = oTmpDataRow("ordernumber")
		oDataTable._orderdate = oTmpDataRow("orderdate")
		oDataTable._invoice_number = oTmpDataRow("InvoiceNumber")
		oDataTable._invoice_date = oTmpDataRow("InvoiceDate")
		oDataTable._invoice_iscopy = oTmpDataRow("InvoiceCopy")
		oDataTable._cluborder = oTmpDataRow("ClubOrder")
		oDataTable._campaign = oTmpDataRow("campaign")
		oDataTable._affiliate = oTmpDataRow("affiliate")
		oDataTable._referrer = oTmpDataRow("referrer")
		oDataTable._remote_ip = oTmpDataRow("remote_ip")
		oDataTable._order_transacted = oTmpDataRow("order_transacted")

		oDataTable._user_id = oTmpDataRow("user_id")
		oDataTable._packaging_id = oTmpDataRow("packaging_id")
		oDataTable._payment_id = oTmpDataRow("payment_id")
		oDataTable._shipping_id = oTmpDataRow("shipping_id")
		oDataTable._shipping_tracking_no = oTmpDataRow("shipping_tracking_no")

		oDataTable._amnt_items = oTmpDataRow("amnt_items")
		oDataTable._amnt_wrapping = oTmpDataRow("amnt_wrapping")
		oDataTable._amnt_shipping = oTmpDataRow("amnt_shipping")
		oDataTable._amnt_extracharges = oTmpDataRow("amnt_extracharges")
		oDataTable._amnt_labor = oTmpDataRow("amnt_labor")
		oDataTable._amnt_vat = oTmpDataRow("amnt_vat")
		oDataTable._amnt_subtotal = oTmpDataRow("amnt_subtotal")
		oDataTable._amnt_discount = oTmpDataRow("amnt_discount")
		oDataTable._amnt_grandtotal = oTmpDataRow("amnt_grandtotal")

		oDataTable._adrs_billing_name = oTmpDataRow("adrs_billing_name")
		oDataTable._adrs_billing_street = oTmpDataRow("adrs_billing_street")
		oDataTable._adrs_billing_city = oTmpDataRow("adrs_billing_city")
		oDataTable._adrs_billing_zip = oTmpDataRow("adrs_billing_zip")
		oDataTable._adrs_billing_state_id = oTmpDataRow("adrs_billing_state_id")
		oDataTable._adrs_billing_country_id = oTmpDataRow("adrs_billing_country_id")
		oDataTable._adrs_billing_phone = oTmpDataRow("adrs_billing_phone")

		oDataTable._adrs_shipping_name = oTmpDataRow("adrs_delivery_name")
		oDataTable._adrs_shipping_street = oTmpDataRow("adrs_delivery_street")
		oDataTable._adrs_shipping_city = oTmpDataRow("adrs_delivery_city")
		oDataTable._adrs_shipping_zip = oTmpDataRow("adrs_delivery_zip")
		oDataTable._adrs_shipping_state_id = oTmpDataRow("adrs_delivery_state_id")
		oDataTable._adrs_shipping_country_id = oTmpDataRow("adrs_delivery_country_id")
		oDataTable._adrs_shipping_phone = oTmpDataRow("adrs_delivery_phone")

		oDataTable._cannot_be_edited = oTmpDataRow("cannot_be_edited")

		oDataTable._sts_new_order_received = oTmpDataRow("sts1_new_order_received")
		oDataTable._sts_new_order_received_date = oTmpDataRow("sts1_new_order_received_date")
		oDataTable._sts_new_order_received_date = oTmpDataRow("sts1_new_order_received_date")

		oDataTable._sts_waiting_for_authorization = oTmpDataRow("sts2_waiting_for_authorization")
		oDataTable._sts_waiting_for_authorization_date = oTmpDataRow("sts2_waiting_for_authorization_date")
		oDataTable._sts_waiting_for_authorization_note = oTmpDataRow("sts2_waiting_for_authorization_note")

		oDataTable._sts_waiting_for_payment = oTmpDataRow("sts3_waiting_for_payment")
		oDataTable._sts_waiting_for_payment_date = oTmpDataRow("sts3_waiting_for_payment_date")
		oDataTable._sts_waiting_for_payment_note = oTmpDataRow("sts3_waiting_for_payment_note")

		oDataTable._sts_order_confirmed = oTmpDataRow("sts4_order_confirmed")
		oDataTable._sts_order_confirmed_date = oTmpDataRow("sts4_order_confirmed_date")
		oDataTable._sts_order_confirmed_note = oTmpDataRow("sts4_order_confirmed_note")

		oDataTable._sts_partial_order_confirmed = oTmpDataRow("sts5_partial_order_confirmed")
		oDataTable._sts_partial_order_confirmed_date = oTmpDataRow("sts5_partial_order_confirmed_date")
		oDataTable._sts_partial_order_confirmed_note = oTmpDataRow("sts5_partial_order_confirmed_note")

		oDataTable._sts_order_failed = oTmpDataRow("sts6_order_failed")
		oDataTable._sts_order_failed_date = oTmpDataRow("sts6_order_failed_date")
		oDataTable._sts_order_failed_note = oTmpDataRow("sts6_order_failed_note")

		oDataTable._sts_order_waiting_to_be_send = oTmpDataRow("sts7_order_waiting_to_be_send")
		oDataTable._sts_order_waiting_to_be_send_date = oTmpDataRow("sts7_order_waiting_to_be_send_date")
		oDataTable._sts_order_waiting_to_be_send_note = oTmpDataRow("sts7_order_waiting_to_be_send_note")

		oDataTable._sts_order_send = oTmpDataRow("sts8_order_send")
		oDataTable._sts_order_send_date = oTmpDataRow("sts8_order_send_date")
		oDataTable._sts_order_send_note = oTmpDataRow("sts8_order_send_note")

		oDataTable._sts_partial_order_send = oTmpDataRow("sts9_partial_order_send")
		oDataTable._sts_partial_order_send_date = oTmpDataRow("sts9_partial_order_send_date")
		oDataTable._sts_partial_order_send_note = oTmpDataRow("sts9_partial_order_send_note")

		oDataTable._sts_order_received_by_customer = oTmpDataRow("sts10_order_received_by_customer")
		oDataTable._sts_order_received_by_customer_date = oTmpDataRow("sts10_order_received_by_customer_date")
		oDataTable._sts_order_received_by_customer_note = oTmpDataRow("sts10_order_received_by_customer_note")

		oDataTable._sts_partial_order_received_by_customer = oTmpDataRow("sts11_partial_order_received_by_customer")
		oDataTable._sts_partial_order_received_by_customer_date = oTmpDataRow("sts11_partial_order_received_by_customer_date")
		oDataTable._sts_partial_order_received_by_customer_note = oTmpDataRow("sts11_partial_order_received_by_customer_note")

		oDataTable._sts_customer_returning_order = oTmpDataRow("sts12_customer_returning_order")
		oDataTable._sts_customer_returning_order_date = oTmpDataRow("sts12_customer_returning_order_date")
		oDataTable._sts_customer_returning_order_note = oTmpDataRow("sts12_customer_returning_order_note")

		oDataTable._sts_customer_returning_part_order = oTmpDataRow("sts13_customer_returning_part_order")
		oDataTable._sts_customer_returning_part_order_date = oTmpDataRow("sts13_customer_returning_part_order_date")
		oDataTable._sts_customer_returning_part_order_note = oTmpDataRow("sts13_customer_returning_part_order_note")

		oDataTable._sts_customer_refunded = oTmpDataRow("sts14_customer_refunded")
		oDataTable._sts_customer_refunded_date = oTmpDataRow("sts14_customer_refunded_date")
		oDataTable._sts_customer_refunded_note = oTmpDataRow("sts14_customer_refunded_note")

		oDataTable._sts_customer_partly_refunded = oTmpDataRow("sts15_customer_partly_refunded")
		oDataTable._sts_customer_partly_refunded_date = oTmpDataRow("sts15_customer_partly_refunded_date")
		oDataTable._sts_customer_partly_refunded_note = oTmpDataRow("sts15_customer_partly_refunded_note")

		oDataTable._sts_order_closed = oTmpDataRow("sts16_order_closed")
		oDataTable._sts_order_closed_date = oTmpDataRow("sts16_order_closed_date")
		oDataTable._sts_order_closed_note = oTmpDataRow("sts16_order_closed_note")

		oDataTable._sts_order_cancelled = oTmpDataRow("sts17_order_cancelled")
		oDataTable._sts_order_cancelled_date = oTmpDataRow("sts17_order_cancelled_date")
		oDataTable._sts_order_cancelled_note = oTmpDataRow("sts17_order_cancelled_note")

		oDataTable._sts_curr_stat = oTmpDataRow("sts_curr_stat")
		oDataTable._sts_curr_date = oTmpDataRow("sts_curr_date")

		oDataTable._interest_start_date = oTmpDataRow("Interest_start_date")
		oDataTable._interest_percentage = oTmpDataRow("Interest_percent")

		oDataTable._orderdeleted = oTmpDataRow("OrderDeleted")
		oDataTable._merchant_notes = oTmpDataRow("Merchant_Notes")
		oDataTable._customer_notes = oTmpDataRow("Customer_Notes")
		oDataTable._lastmodify_Date = oTmpDataRow("LastModify_Date")
		oDataTable._lastmodify_User = oTmpDataRow("LastModify_User")
		oDataTable._lastmodify_User_id = oTmpDataRow("LastModify_User_Id")
        oDataTable._order_currency = oTmpDataRow("order_currency")
        oDataTable._order_currency_rate = oTmpDataRow("order_currency_rate")

        oDataTable._hear_fromus = oTmpDataRow("hear_fromus")
        oDataTable._include_receipt = oTmpDataRow("include_receipt")
		'--- Get Order Items
		Dim oOrderItem_logics As New ion_two.cls_order_items_lgc
		oOrderItem_logics._connection_string = Me._connection_string
		oOrderItem_logics._dbtype = Me._dbtype
		bError = oOrderItem_logics.read(nId, oDataTable)
		If bError Then
			Me._err_number = oOrderItem_logics._err_number
			Me._err_description = oOrderItem_logics._err_description
			Me._err_source = oOrderItem_logics._err_source
			Return True
		End If


		'--- release
		oReadTransactor = Nothing

		Return False
		Exit Function

ErrorHandler:
		Me._err_number = Err.Number
		Me._err_description = Err.Description
		Me._err_source = Err.Source
		Return True
	End Function

	Function update(ByRef oDataTable As skl_order, Optional ByVal bUpdateSub As Boolean = False) As Boolean
		On Error GoTo ErrorHandler

		'--- local definitions
		Dim bError As Boolean = False

		'--- CUSTOM ERROR: Return Error if ID not passed in skeleton
		If oDataTable._id <= 0 Then
			Err.Raise(7006, Me._module + ":update", "No ID passed with skeleton.")
		End If

		Dim oTmpTransact As New iDac.cls_T_read
		oTmpTransact._connection_string = Me._connection_string
		oTmpTransact._dbtype = Me._dbtype
		oTmpTransact._tablename = Me._tablename
		bError = oTmpTransact.transact_read(oDataTable._id)
		If bError Then
			Me._err_number = oTmpTransact._err_number
			Me._err_description = oTmpTransact._err_description
			Me._err_source = oTmpTransact._err_source
			Return True
		End If

		'--- Get Dataset
		Dim oTmpDataTable As DataTable = oTmpTransact._datatable

		'--- Assign Order
		Dim oTmpDataRow As DataRow
		oTmpDataRow = oTmpDataTable.Rows(0)

		'oTmpDataRow("ordernumber") = oDataTable._ordernumber
		'oTmpDataRow("orderdate") = oDataTable._OrderDate
		oTmpDataRow("InvoiceNumber") = oDataTable._invoice_number
		oTmpDataRow("InvoiceDate") = oDataTable._invoice_date
		oTmpDataRow("InvoiceCopy") = oDataTable._invoice_iscopy
		oTmpDataRow("campaign") = oDataTable._campaign
		oTmpDataRow("affiliate") = oDataTable._affiliate
		oTmpDataRow("referrer") = oDataTable._referrer
		oTmpDataRow("remote_ip") = oDataTable._remote_ip
		oTmpDataRow("order_transacted") = oDataTable._order_transacted

		'oTmpDataRow("user_id") = oDataTable._user_id
		oTmpDataRow("packaging_id") = oDataTable._packaging_id
		oTmpDataRow("payment_id") = oDataTable._payment_id
		oTmpDataRow("shipping_id") = oDataTable._shipping_id
		oTmpDataRow("shipping_tracking_no") = oDataTable._shipping_tracking_no
		oTmpDataRow("cluborder") = oDataTable._cluborder

		oTmpDataRow("amnt_items") = oDataTable._amnt_items
		oTmpDataRow("amnt_wrapping") = oDataTable._amnt_wrapping
		oTmpDataRow("amnt_shipping") = oDataTable._amnt_shipping
		oTmpDataRow("amnt_extracharges") = oDataTable._amnt_extracharges
		oTmpDataRow("amnt_labor") = oDataTable._amnt_labor
		oTmpDataRow("amnt_vat") = oDataTable._amnt_vat
		oTmpDataRow("amnt_discount") = oDataTable._amnt_discount
		oTmpDataRow("amnt_subtotal") = oDataTable._amnt_subtotal
		oTmpDataRow("amnt_grandtotal") = oDataTable._amnt_grandtotal

		oTmpDataRow("adrs_billing_name") = oDataTable._adrs_billing_name
		oTmpDataRow("adrs_billing_street") = oDataTable._adrs_billing_street
		oTmpDataRow("adrs_billing_city") = oDataTable._adrs_billing_city
		oTmpDataRow("adrs_billing_zip") = oDataTable._adrs_billing_zip
		oTmpDataRow("adrs_billing_state_id") = oDataTable._adrs_billing_state_id
		oTmpDataRow("adrs_billing_country_id") = oDataTable._adrs_billing_country_id
		oTmpDataRow("adrs_billing_phone") = oDataTable._adrs_billing_phone

		oTmpDataRow("adrs_delivery_name") = oDataTable._adrs_shipping_name
		oTmpDataRow("adrs_delivery_street") = oDataTable._adrs_shipping_street
		oTmpDataRow("adrs_delivery_city") = oDataTable._adrs_shipping_city
		oTmpDataRow("adrs_delivery_zip") = oDataTable._adrs_shipping_zip
		oTmpDataRow("adrs_delivery_state_id") = oDataTable._adrs_shipping_state_id
		oTmpDataRow("adrs_delivery_country_id") = oDataTable._adrs_shipping_country_id
		oTmpDataRow("adrs_delivery_phone") = oDataTable._adrs_shipping_phone

		oTmpDataRow("cannot_be_edited") = oDataTable._cannot_be_edited

		oTmpDataRow("sts1_new_order_received") = oDataTable._sts_new_order_received
		oTmpDataRow("sts1_new_order_received_date") = oDataTable._sts_new_order_received_date

		oTmpDataRow("sts2_waiting_for_authorization") = oDataTable._sts_waiting_for_authorization
		oTmpDataRow("sts2_waiting_for_authorization_date") = oDataTable._sts_waiting_for_authorization_date
		oTmpDataRow("sts2_waiting_for_authorization_note") = oDataTable._sts_waiting_for_authorization_note

		oTmpDataRow("sts3_waiting_for_payment") = oDataTable._sts_waiting_for_payment
		oTmpDataRow("sts3_waiting_for_payment_date") = oDataTable._sts_waiting_for_payment_date
		oTmpDataRow("sts3_waiting_for_payment_note") = oDataTable._sts_waiting_for_payment_note

		oTmpDataRow("sts4_order_confirmed") = oDataTable._sts_order_confirmed
		oTmpDataRow("sts4_order_confirmed_date") = oDataTable._sts_order_confirmed_date
		oTmpDataRow("sts4_order_confirmed_note") = oDataTable._sts_order_confirmed_note

		oTmpDataRow("sts5_partial_order_confirmed") = oDataTable._sts_partial_order_confirmed
		oTmpDataRow("sts5_partial_order_confirmed_date") = oDataTable._sts_partial_order_confirmed_date
		oTmpDataRow("sts5_partial_order_confirmed_note") = oDataTable._sts_partial_order_confirmed_note

		oTmpDataRow("sts6_order_failed") = oDataTable._sts_order_failed
		oTmpDataRow("sts6_order_failed_date") = oDataTable._sts_order_failed_date
		oTmpDataRow("sts6_order_failed_note") = oDataTable._sts_order_failed_note

		oTmpDataRow("sts7_order_waiting_to_be_send") = oDataTable._sts_order_waiting_to_be_send
		oTmpDataRow("sts7_order_waiting_to_be_send_date") = oDataTable._sts_order_waiting_to_be_send_date
		oTmpDataRow("sts7_order_waiting_to_be_send_note") = oDataTable._sts_order_waiting_to_be_send_note

		oTmpDataRow("sts8_order_send") = oDataTable._sts_order_send
		oTmpDataRow("sts8_order_send_date") = oDataTable._sts_order_send_date
		oTmpDataRow("sts8_order_send_note") = oDataTable._sts_order_send_note

		oTmpDataRow("sts9_partial_order_send") = oDataTable._sts_partial_order_send
		oTmpDataRow("sts9_partial_order_send_date") = oDataTable._sts_order_waiting_to_be_send_date
		oTmpDataRow("sts9_partial_order_send_note") = oDataTable._sts_partial_order_send_note

		oTmpDataRow("sts10_order_received_by_customer") = oDataTable._sts_order_received_by_customer
		oTmpDataRow("sts10_order_received_by_customer_date") = oDataTable._sts_order_received_by_customer_date
		oTmpDataRow("sts10_order_received_by_customer_note") = oDataTable._sts_order_received_by_customer_note

		oTmpDataRow("sts11_partial_order_received_by_customer") = oDataTable._sts_partial_order_received_by_customer
		oTmpDataRow("sts11_partial_order_received_by_customer_date") = oDataTable._sts_partial_order_received_by_customer_date
		oTmpDataRow("sts11_partial_order_received_by_customer_note") = oDataTable._sts_partial_order_received_by_customer_note

		oTmpDataRow("sts12_customer_returning_order") = oDataTable._sts_customer_returning_order
		oTmpDataRow("sts12_customer_returning_order_date") = oDataTable._sts_customer_returning_order_date
		oTmpDataRow("sts12_customer_returning_order_note") = oDataTable._sts_customer_returning_order_note

		oTmpDataRow("sts13_customer_returning_part_order") = oDataTable._sts_customer_returning_part_order
		oTmpDataRow("sts13_customer_returning_part_order_date") = oDataTable._sts_customer_returning_part_order_date
		oTmpDataRow("sts13_customer_returning_part_order_note") = oDataTable._sts_customer_returning_part_order_note

		oTmpDataRow("sts14_customer_refunded") = oDataTable._sts_customer_refunded
		oTmpDataRow("sts14_customer_refunded_date") = oDataTable._sts_customer_refunded_date
		oTmpDataRow("sts14_customer_refunded_note") = oDataTable._sts_customer_refunded_note

		oTmpDataRow("sts15_customer_partly_refunded") = oDataTable._sts_customer_partly_refunded
		oTmpDataRow("sts15_customer_partly_refunded_date") = oDataTable._sts_customer_partly_refunded_date
		oTmpDataRow("sts15_customer_partly_refunded_note") = oDataTable._sts_customer_partly_refunded_note

		oTmpDataRow("sts16_order_closed") = oDataTable._sts_order_closed
		oTmpDataRow("sts16_order_closed_date") = oDataTable._sts_order_closed_date
		oTmpDataRow("sts16_order_closed_note") = oDataTable._sts_order_closed_note

		oTmpDataRow("sts17_order_cancelled") = oDataTable._sts_order_cancelled
		oTmpDataRow("sts17_order_cancelled_date") = oDataTable._sts_order_cancelled_date
		oTmpDataRow("sts17_order_cancelled_note") = oDataTable._sts_order_cancelled_note

		oTmpDataRow("sts_curr_stat") = oDataTable._sts_curr_stat
		oTmpDataRow("sts_curr_date") = oDataTable._sts_curr_date

		oTmpDataRow("Interest_start_date") = oDataTable._interest_start_date
		oTmpDataRow("Interest_percent") = oDataTable._interest_percentage

		oTmpDataRow("OrderDeleted") = oDataTable._orderdeleted
		oTmpDataRow("Merchant_Notes") = oDataTable._merchant_notes
        oTmpDataRow("Customer_Notes") = oDataTable._customer_notes

        oTmpDataRow("hear_fromus") = oDataTable._hear_fromus
        oTmpDataRow("include_receipt") = oDataTable._include_receipt

		'--- Handle Audit
		oTmpDataRow("LastModify_Date") = Date.Now
		oTmpDataRow("LastModify_User") = oDataTable._lastmodify_User
		oTmpDataRow("LastModify_User_Id") = oDataTable._lastmodify_User_id
        oTmpDataRow("order_currency") = oDataTable._order_currency
        oTmpDataRow("order_currency_rate") = oDataTable._order_currency_rate


		If IsNothing(Me._idac_transaction) Then
			'### Start transaction
			Dim oTransaction As New iDac.cls_T_transaction
			oTransaction._connection_string = Me._connection_string
			oTransaction._dbtype = Me._dbtype
			bError = oTransaction.start()
			If bError Then
				Me._err_number = oTransaction._err_number
				Me._err_description = oTransaction._err_description
				Me._err_source = oTransaction._err_source
				Return True
			End If
			'--- Assign to ME
			Me._idac_transaction = oTransaction
			oTransaction = Nothing
		Else
			Me._inherited_transaction = True
		End If


		'--- Instantiate the Transactor
		Dim oTransactor As New iDac.cls_T_transactor
		oTransactor._connection_string = Me._connection_string
		oTransactor._dbtype = Me._dbtype
		oTransactor._transaction = Me._idac_transaction._transaction

		'--- Prepare and load table 1
		Dim oTable1 As New iDac.cls_cll_datatables
		oTable1._datatable = oTmpDataTable
		oTransactor._i_cll_datatables.Add(oTable1)

		bError = oTransactor.transact_update
		If bError Then
			Me._idac_transaction._transaction.Rollback()
			Me._err_number = oTransactor._err_number
			Me._err_description = oTransactor._err_description
			Me._err_source = oTransactor._err_source
			Return True
		End If


		'--- update order-items
		If bUpdateSub Then
			Dim oOrderItems_logics As New ion_two.cls_order_items_lgc
			oOrderItems_logics._connection_string = Me._connection_string
			oOrderItems_logics._dbtype = Me._dbtype
			oOrderItems_logics._idac_transaction = Me._idac_transaction
			bError = oOrderItems_logics.update(oDataTable)
			If bError Then
				Me._err_number = oOrderItems_logics._err_number
				Me._err_description = oOrderItems_logics._err_description
				Me._err_source = oOrderItems_logics._err_source
				Return True
			End If
		End If

		'--- Close the transaction
		If Not Me._inherited_transaction Then
			bError = Me._idac_transaction.close()
			If bError Then
				Me._err_number = Me._idac_transaction._err_number
				Me._err_description = Me._idac_transaction._err_description
				Me._err_source = Me._idac_transaction._err_source
				Return True
			End If
		End If


		oTable1 = Nothing
		oTransactor = Nothing

		Return False
		Exit Function

ErrorHandler:
		Me._err_number = Err.Number
		Me._err_description = Err.Description
		Me._err_source = Err.Source
		Return True

	End Function


End Class
