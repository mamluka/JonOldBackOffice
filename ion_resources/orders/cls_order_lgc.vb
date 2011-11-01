Imports System.Data.SqlClient

Public Class cls_order_lgc

	Private m_error_no As Integer
	Private m_error_desc As String
	Private m_error_source As String
	Private m_connection_string As String

	Private m_transaction As System.Data.SqlClient.SqlTransaction
	Private m_connection As System.Data.SqlClient.SqlConnection

	Private m_order_id As Int32
	Private m_order_no As Int32

	Function insert_order(ByRef oOrder As cls_order) As Boolean
		On Error GoTo ErrorHandler

		'--- local definitions
		Dim bError As Boolean = False

		'--- Get Dataset
		Dim oTmpDataset As DataSet = New ion_resources.ds_orders()
		Dim oTmpOrders As DataTable = oTmpDataset.Tables("acc_ORDERS")
		Dim oTmpOrder_Items As DataTable = oTmpDataset.Tables("acc_ORDER_ITEMS")

		'--- Assign Order
		Dim oTmpDataRow As DataRow
		oTmpDataRow = oTmpOrders.NewRow

		oTmpDataRow("ordernumber") = 1
		oTmpDataRow("orderdate") = oOrder.OrderDate
		oTmpDataRow("InvoiceNumber") = 0
		oTmpDataRow("InvoiceDate") = #1/1/1900#
		oTmpDataRow("InvoiceCopy") = 0
		oTmpDataRow("ClubOrder") = oOrder.cluborder
		oTmpDataRow("campaign") = oOrder.campaign
		oTmpDataRow("affiliate") = oOrder.affiliate
        oTmpDataRow("referrer") = oOrder.referrer
        oTmpDataRow("remote_ip") = oOrder.remote_ip
        oTmpDataRow("order_transacted") = 0

        oTmpDataRow("user_id") = oOrder.user_id
		oTmpDataRow("packaging_id") = oOrder.packaging_id
		oTmpDataRow("payment_id") = oOrder.payment_id
		oTmpDataRow("shipping_id") = oOrder.shipping_id
		oTmpDataRow("shipping_tracking_no") = ""
		oTmpDataRow("jewelrysize") = oOrder.jewelry_size

		oTmpDataRow("amnt_items") = oOrder.amnt_items
        oTmpDataRow("amnt_wrapping") = oOrder.amnt_wrapping
        oTmpDataRow("amnt_shipping") = oOrder.amnt_shipping
		oTmpDataRow("amnt_extracharges") = oOrder.amnt_extracharges
		oTmpDataRow("amnt_labor") = oOrder.amnt_labor
        oTmpDataRow("amnt_vat") = oOrder.amnt_vat
		oTmpDataRow("amnt_subtotal") = oOrder.amnt_subtotal
		oTmpDataRow("amnt_discount") = oOrder.amnt_discount
		oTmpDataRow("amnt_grandtotal") = oOrder.amnt_grandtotal

		oTmpDataRow("adrs_billing_name") = oOrder.adrs_billing_name
		oTmpDataRow("adrs_billing_street") = oOrder.adrs_billing_street
		oTmpDataRow("adrs_billing_city") = oOrder.adrs_billing_city
		oTmpDataRow("adrs_billing_zip") = oOrder.adrs_billing_zip
		oTmpDataRow("adrs_billing_state_id") = oOrder.adrs_billing_state_id
		oTmpDataRow("adrs_billing_country_id") = oOrder.adrs_billing_country_id
		oTmpDataRow("adrs_billing_phone") = oOrder.adrs_billing_phone

		oTmpDataRow("adrs_delivery_name") = oOrder.adrs_shipping_name
		oTmpDataRow("adrs_delivery_street") = oOrder.adrs_shipping_street
		oTmpDataRow("adrs_delivery_city") = oOrder.adrs_shipping_city
		oTmpDataRow("adrs_delivery_zip") = oOrder.adrs_shipping_zip
		oTmpDataRow("adrs_delivery_state_id") = oOrder.adrs_shipping_state_id
		oTmpDataRow("adrs_delivery_country_id") = oOrder.adrs_shipping_country_id
		oTmpDataRow("adrs_delivery_phone") = oOrder.adrs_shipping_phone

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

		oTmpDataRow("Interest_start_date") = oOrder.interest_start_date
		oTmpDataRow("Interest_percent") = oOrder.interest_percentage

		oTmpDataRow("OrderDeleted") = False
		oTmpDataRow("Merchant_Notes") = ""
		oTmpDataRow("Customer_Notes") = oOrder.customer_notes
		oTmpDataRow("LastModify_Date") = Date.Now
		oTmpDataRow("LastModify_User") = oOrder.LastModify_User
        oTmpDataRow("LastModify_User_Id") = oOrder.LastModify_User_id
        oTmpDataRow("order_currency") = oOrder.order_currency
        oTmpDataRow("order_currency_rate") = oOrder.order_currency_rate

        oTmpDataRow("include_receipt") = oOrder.include_receipt
        oTmpDataRow("hear_fromus") = oOrder.hear_fromus

        oTmpOrders.Rows.Add(oTmpDataRow)


		'--- Assign Order_Items
		Dim nLoop As Integer
		Dim oTmpDataRow_item As DataRow
		For nLoop = 1 To oOrder.order_items.Count
			oTmpDataRow_item = oTmpOrder_Items.NewRow

			oTmpDataRow_item("OrderNumber") = 0
			oTmpDataRow_item("Item_id") = oOrder.order_items.Item(nLoop).Item_id
			oTmpDataRow_item("Item_no") = oOrder.order_items.Item(nLoop).Item_no
			oTmpDataRow_item("Item_quantity") = oOrder.order_items.Item(nLoop).Item_quantity
			oTmpDataRow_item("jewelsize") = oOrder.order_items.Item(nLoop).jewelsize

			oTmpOrder_Items.Rows.Add(oTmpDataRow_item)
		Next


		'--- Instantiate the Transactor
		Dim oTransactor As New ion_resources.cls_mt_orders
		oTransactor.connection_string = Me.connection_string
		oTransactor.connection = Me.connection
		oTransactor.transaction = Me.transaction

		'--- Prepare and load table 1
		Dim oTable1 As New ion_idac.cls_cll_datatables
		oTable1.datatable = oTmpOrders
		oTransactor.i_cll_datatables.Add(oTable1)

		'--- Prepare and load table 2
		Dim oTable2 As New ion_idac.cls_cll_datatables
		oTable2.datatable = oTmpOrder_Items
		oTable2.ignoreget = True
		oTransactor.i_cll_datatables.Add(oTable2)

		oTransactor.id = oOrder.id

		bError = oTransactor.transact_insert
		If bError Then
			Me.error_no = oTransactor.error_no
			Me.error_desc = oTransactor.error_desc
			Me.error_source = oTransactor.error_source
			Return True
		End If

		'--- Get Order Number
		Me.order_id = oTransactor.id
		Me.order_no = oTransactor.i_cll_datatables(1).datatable.rows(0).itemarray(1)

		oTable1 = Nothing
		oTable2 = Nothing
		oTransactor = Nothing



		'--- define system object
		'Dim oSystem As ion_resources.cls_system = New ion_resources.cls_system
		'oSystem.connection_string = Me.connection_string
		'oSystem.dataset = oTmpDataset

		'Dim oTmpBroker As ion_resources.cls_order_brk = New ion_resources.cls_order_brk
		'bError = oTmpBroker.insert_order(oSystem)
		'If bError Then
		'Me.error_no = oSystem.error_no
		'Me.error_desc = oSystem.error_desc
		'Me.error_source = oSystem.error_source
		'Return True
		'Exit Function
		'End If

		'--- Receive 
		'Me.order_id = oTmpBroker.order_id
		'Me.order_no = oTmpBroker.order_no

		'oTmpBroker = Nothing
		'oSystem = Nothing

		Return False
		Exit Function

ErrorHandler:
		Me.error_no = Err.Number
		Me.error_desc = Err.Description
		Me.error_source = Err.Source
		Return True

	End Function


	Function get_order_by_no(ByVal nOrderNumber As Int32) As Boolean
		'On Error GoTo ErrorHandler

		'--- local definitions
		Dim bError As Boolean = False


		Return False
		Exit Function

ErrorHandler:
		Me.error_no = Err.Number
		Me.error_desc = Err.Description
		Me.error_source = Err.Source
		Return True

	End Function


	Function get_order_by_id(ByVal nOrderId As Int32, ByRef oOrder As cls_order) As Boolean
		'On Error GoTo ErrorHandler

		'--- local definitions
		Dim bError As Boolean = False

		'--- define system object
		Dim oSystem As ion_resources.cls_system = New ion_resources.cls_system()
		oSystem.connection_string = Me.connection_string
		oSystem.dataset = New ion_resources.ds_orders()


		Dim oTmpBroker As ion_resources.cls_order_brk = New ion_resources.cls_order_brk()
		bError = oTmpBroker.get_order(nOrderId, oSystem)
		If bError Then
			Me.error_no = oSystem.error_no
			Me.error_desc = oSystem.error_desc
			Me.error_source = oSystem.error_source
			Return True
			Exit Function
		End If

		oOrder.order_dataset = oSystem.dataset

		'Dim oOrder As New ion_resources.cls_order()
		Dim oOrders As DataTable = oSystem.dataset.Tables("acc_ORDERS")
        Dim diamonnd_oOrder_Items As DataTable = oSystem.dataset.Tables("acc_DIAMOND_ORDER_ITEMS")
        Dim customjewelry_oOrder_Items As DataTable = oSystem.dataset.Tables("acc_CUSTOMJEWEL_ORDER_ITEMS")
        Dim jewelry_oOrder_Items As DataTable = oSystem.dataset.Tables("acc_JEWELRY_ORDER_ITEMS")

		'--- Current Record
		Dim oOrder_record As DataRow = oOrders.Rows(0)

		oOrder.id = oOrder_record("id")
		oOrder.ordernumber = oOrder_record("ordernumber")
		oOrder.OrderDate = oOrder_record("orderdate")

		oOrder.campaign = oOrder_record("campaign")
		oOrder.affiliate = oOrder_record("affiliate")

        oOrder.referrer = oOrder_record("referrer")
        oOrder.remote_ip = oOrder_record("remote_ip")
        oOrder.order_transacted = oOrder_record("order_transacted")

        oOrder.invoice_number = oOrder_record("InvoiceNumber")
        oOrder.invoice_date = oOrder_record("InvoiceDate")
		oOrder.invoice_copy = oOrder_record("InvoiceCopy")
		oOrder.cluborder = oOrder_record("clubOrder")

		oOrder.user_id = oOrder_record("user_id")
		oOrder.packaging_id = oOrder_record("packaging_id")
		oOrder.payment_id = oOrder_record("payment_id")
		oOrder.shipping_id = oOrder_record("shipping_id")
		oOrder.shipping_tracking_no = oOrder_record("shipping_tracking_no")
		oOrder.jewelry_size = oOrder_record("jewelrysize")

		oOrder.amnt_items = oOrder_record("amnt_items")
        oOrder.amnt_wrapping = oOrder_record("amnt_wrapping")
        oOrder.amnt_shipping = oOrder_record("amnt_shipping")
		oOrder.amnt_labor = oOrder_record("amnt_labor")
		oOrder.amnt_extracharges = oOrder_record("amnt_extracharges")
		oOrder.amnt_discount = oOrder_record("amnt_discount")
		oOrder.amnt_vat = oOrder_record("amnt_vat")
		oOrder.amnt_subtotal = oOrder_record("amnt_subtotal")
		oOrder.amnt_grandtotal = oOrder_record("amnt_grandtotal")

        oOrder.adrs_billing_name = oOrder_record("adrs_billing_firstname") + " " + oOrder_record("adrs_billing_lastname")
        oOrder.adrs_billing_street = oOrder_record("adrs_billing_street")
		oOrder.adrs_billing_city = oOrder_record("adrs_billing_city")
		oOrder.adrs_billing_zip = oOrder_record("adrs_billing_zip")
		oOrder.adrs_billing_state_id = oOrder_record("adrs_billing_state_id")
		oOrder.adrs_billing_country_id = oOrder_record("adrs_billing_country_id")
		oOrder.adrs_billing_phone = oOrder_record("adrs_billing_phone")

        oOrder.adrs_shipping_name = oOrder_record("adrs_delivery_firstname") + " " + oOrder_record("adrs_delivery_lastname")
		oOrder.adrs_shipping_street = oOrder_record("adrs_delivery_street")
		oOrder.adrs_shipping_city = oOrder_record("adrs_delivery_city")
		oOrder.adrs_shipping_zip = oOrder_record("adrs_delivery_zip")
		oOrder.adrs_shipping_state_id = oOrder_record("adrs_delivery_state_id")
		oOrder.adrs_shipping_country_id = oOrder_record("adrs_delivery_country_id")
		oOrder.adrs_shipping_phone = oOrder_record("adrs_delivery_phone")

		oOrder.cannot_be_edited = oOrder_record("cannot_be_edited")

		oOrder.sts_new_order_received = oOrder_record("sts1_new_order_received")
		oOrder.sts_new_order_received_date = oOrder_record("sts1_new_order_received_date")
		oOrder.sts_new_order_received_date = oOrder_record("sts1_new_order_received_date")

		oOrder.sts_waiting_for_authorization = oOrder_record("sts2_waiting_for_authorization")
		oOrder.sts_waiting_for_authorization_date = oOrder_record("sts2_waiting_for_authorization_date")
		oOrder.sts_waiting_for_authorization_note = oOrder_record("sts2_waiting_for_authorization_note")

		oOrder.sts_waiting_for_payment = oOrder_record("sts3_waiting_for_payment")
		oOrder.sts_waiting_for_payment_date = oOrder_record("sts3_waiting_for_payment_date")
		oOrder.sts_waiting_for_payment_note = oOrder_record("sts3_waiting_for_payment_note")

		oOrder.sts_order_confirmed = oOrder_record("sts4_order_confirmed")
		oOrder.sts_order_confirmed_date = oOrder_record("sts4_order_confirmed_date")
		oOrder.sts_order_confirmed_note = oOrder_record("sts4_order_confirmed_note")

		oOrder.sts_partial_order_confirmed = oOrder_record("sts5_partial_order_confirmed")
		oOrder.sts_partial_order_confirmed_date = oOrder_record("sts5_partial_order_confirmed_date")
		oOrder.sts_partial_order_confirmed_note = oOrder_record("sts5_partial_order_confirmed_note")

		oOrder.sts_order_failed = oOrder_record("sts6_order_failed")
		oOrder.sts_order_failed_date = oOrder_record("sts6_order_failed_date")
		oOrder.sts_order_failed_note = oOrder_record("sts6_order_failed_note")

		oOrder.sts_order_waiting_to_be_send = oOrder_record("sts7_order_waiting_to_be_send")
		oOrder.sts_order_waiting_to_be_send_date = oOrder_record("sts7_order_waiting_to_be_send_date")
		oOrder.sts_order_waiting_to_be_send_note = oOrder_record("sts7_order_waiting_to_be_send_note")

		oOrder.sts_order_send = oOrder_record("sts8_order_send")
		oOrder.sts_order_send_date = oOrder_record("sts8_order_send_date")
		oOrder.sts_order_send_note = oOrder_record("sts8_order_send_note")

		oOrder.sts_partial_order_send = oOrder_record("sts9_partial_order_send")
		oOrder.sts_partial_order_send_date = oOrder_record("sts9_partial_order_send_date")
		oOrder.sts_partial_order_send_note = oOrder_record("sts9_partial_order_send_note")

		oOrder.sts_order_received_by_customer = oOrder_record("sts10_order_received_by_customer")
		oOrder.sts_order_received_by_customer_date = oOrder_record("sts10_order_received_by_customer_date")
		oOrder.sts_order_received_by_customer_note = oOrder_record("sts10_order_received_by_customer_note")

		oOrder.sts_partial_order_received_by_customer = oOrder_record("sts11_partial_order_received_by_customer")
		oOrder.sts_partial_order_received_by_customer_date = oOrder_record("sts11_partial_order_received_by_customer_date")
		oOrder.sts_partial_order_received_by_customer_note = oOrder_record("sts11_partial_order_received_by_customer_note")

		oOrder.sts_customer_returning_order = oOrder_record("sts12_customer_returning_order")
		oOrder.sts_customer_returning_order_date = oOrder_record("sts12_customer_returning_order_date")
		oOrder.sts_customer_returning_order_note = oOrder_record("sts12_customer_returning_order_note")

		oOrder.sts_customer_returning_part_order = oOrder_record("sts13_customer_returning_part_order")
		oOrder.sts_customer_returning_part_order_date = oOrder_record("sts13_customer_returning_part_order_date")
		oOrder.sts_customer_returning_part_order_note = oOrder_record("sts13_customer_returning_part_order_note")

		oOrder.sts_customer_refunded = oOrder_record("sts14_customer_refunded")
		oOrder.sts_customer_refunded_date = oOrder_record("sts14_customer_refunded_date")
		oOrder.sts_customer_refunded_note = oOrder_record("sts14_customer_refunded_note")

		oOrder.sts_customer_partly_refunded = oOrder_record("sts15_customer_partly_refunded")
		oOrder.sts_customer_partly_refunded_date = oOrder_record("sts15_customer_partly_refunded_date")
		oOrder.sts_customer_partly_refunded_note = oOrder_record("sts15_customer_partly_refunded_note")

		oOrder.sts_order_closed = oOrder_record("sts16_order_closed")
		oOrder.sts_order_closed_date = oOrder_record("sts16_order_closed_date")
		oOrder.sts_order_closed_note = oOrder_record("sts16_order_closed_note")

		oOrder.sts_order_cancelled = oOrder_record("sts17_order_cancelled")
		oOrder.sts_order_cancelled_date = oOrder_record("sts17_order_cancelled_date")
		oOrder.sts_order_cancelled_note = oOrder_record("sts17_order_cancelled_note")

		oOrder.sts_curr_stat = oOrder_record("sts_curr_stat")
		oOrder.sts_curr_date = oOrder_record("sts_curr_date")

		oOrder.interest_start_date = oOrder_record("Interest_start_date")
		oOrder.interest_percentage = oOrder_record("Interest_percent")

		oOrder.OrderDeleted = oOrder_record("OrderDeleted")
		oOrder.merchant_notes = oOrder_record("Merchant_Notes")
		oOrder.customer_notes = oOrder_record("Customer_Notes")
		oOrder.LastModify_Date = oOrder_record("LastModify_Date")
		oOrder.LastModify_User = oOrder_record("LastModify_User")
		oOrder.LastModify_User_id = oOrder_record("LastModify_User_Id")
        oOrder.order_currency = oOrder_record("order_currency")
        oOrder.order_currency_rate = oOrder_record("order_currency_rate")

        oOrder.include_receipt = oOrder_record("include_receipt")
        oOrder.hear_fromus = oOrder_record("hear_fromus")
		Dim nLoop As Int32
        For nLoop = 0 To jewelry_oOrder_Items.Rows.Count - 1
            Dim oOrderItem As New cls_order_items
            Dim oRow As DataRow = jewelry_oOrder_Items.Rows.Item(nLoop)


            oOrderItem.item_id = oRow("item_id")
            oOrderItem.item_quantity = 1
            oOrderItem.jewelsize = oRow("jewelsize")

            If oRow("onspecial") Then
                oOrderItem.price = oRow("special_sell_price")
            Else
                oOrderItem.price = oRow("sell_price")
            End If

            oOrderItem.description = oRow("jewel_title")


            '' oOrderItem.extrainfo = oRow("extrainfo") ''idex id number
            oOrder.order_items.Add(oOrderItem)
        Next

        For nLoop = 0 To customjewelry_oOrder_Items.Rows.Count - 1
            Dim oOrderItem As New cls_order_items
            Dim oRow As DataRow = customjewelry_oOrder_Items.Rows.Item(nLoop)

            oOrderItem.item_quantity = 1
            oOrderItem.jewelsize = oRow("size")

            oOrderItem.item_id = 1
            oOrderItem.price = oRow("price")


            oOrderItem.description = oRow("description")


            '' oOrderItem.extrainfo = oRow("extrainfo") ''idex id number
            oOrder.order_items.Add(oOrderItem)
        Next

        For nLoop = 0 To diamonnd_oOrder_Items.Rows.Count - 1
            Dim oOrderItem As New cls_order_items
            Dim oRow As DataRow = diamonnd_oOrder_Items.Rows.Item(nLoop)

            oOrderItem.item_quantity = 1
            oOrderItem.jewelsize = ""

            oOrderItem.item_id = oRow("item_id")
            oOrderItem.price = oRow("totalprice")


            oOrderItem.description = oRow("description")


            '' oOrderItem.extrainfo = oRow("extrainfo") ''idex id number
            oOrder.order_items.Add(oOrderItem)
        Next


		Return False
		Exit Function

ErrorHandler:
		Me.error_no = Err.Number
		Me.error_desc = Err.Description
		Me.error_source = Err.Source
		Return True

	End Function

	Function update_order_old(ByRef oOrder As cls_order) As Boolean
		On Error GoTo ErrorHandler

		'--- local definitions
		Dim bError As Boolean = False

		'--- Get Dataset
		Dim oTmpDataset As DataSet = oOrder.order_dataset
		Dim oTmpOrders As DataTable = oTmpDataset.Tables("acc_ORDERS")
		Dim oTmpOrder_Items As DataTable = oTmpDataset.Tables("acc_ORDER_ITEMS")

		'--- Assign Order
		Dim oTmpDataRow As DataRow
		oTmpDataRow = oTmpOrders.Rows(0)

		'oTmpDataRow("ordernumber") = oOrder.ordernumber
		'oTmpDataRow("orderdate") = oOrder.OrderDate
		oTmpDataRow("InvoiceNumber") = oOrder.invoice_number
		oTmpDataRow("InvoiceDate") = oOrder.invoice_date
		oTmpDataRow("InvoiceCopy") = oOrder.invoice_copy
		oTmpDataRow("campaign") = oOrder.campaign
		oTmpDataRow("affiliate") = oOrder.affiliate
		oTmpDataRow("referrer") = oOrder.referrer
		oTmpDataRow("remote_ip") = oOrder.remote_ip
		oTmpDataRow("order_transacted") = oOrder.order_transacted

		'oTmpDataRow("user_id") = oOrder.user_id
		oTmpDataRow("packaging_id") = oOrder.packaging_id
		oTmpDataRow("payment_id") = oOrder.payment_id
		oTmpDataRow("shipping_id") = oOrder.shipping_id
		oTmpDataRow("shipping_tracking_no") = oOrder.shipping_tracking_no
		oTmpDataRow("cluborder") = oOrder.cluborder
		oTmpDataRow("jewelrysize") = oOrder.jewelry_size

		oTmpDataRow("amnt_items") = oOrder.amnt_items
		oTmpDataRow("amnt_wrapping") = oOrder.amnt_wrapping
		oTmpDataRow("amnt_shipping") = oOrder.amnt_shipping
		oTmpDataRow("amnt_extracharges") = oOrder.amnt_extracharges
		oTmpDataRow("amnt_labor") = oOrder.amnt_labor
		oTmpDataRow("amnt_vat") = oOrder.amnt_vat
		oTmpDataRow("amnt_discount") = oOrder.amnt_discount
		oTmpDataRow("amnt_subtotal") = oOrder.amnt_subtotal
		oTmpDataRow("amnt_grandtotal") = oOrder.amnt_grandtotal

		oTmpDataRow("adrs_billing_name") = oOrder.adrs_billing_name
		oTmpDataRow("adrs_billing_street") = oOrder.adrs_billing_street
		oTmpDataRow("adrs_billing_city") = oOrder.adrs_billing_city
		oTmpDataRow("adrs_billing_zip") = oOrder.adrs_billing_zip
		oTmpDataRow("adrs_billing_state_id") = oOrder.adrs_billing_state_id
		oTmpDataRow("adrs_billing_country_id") = oOrder.adrs_billing_country_id
		oTmpDataRow("adrs_billing_phone") = oOrder.adrs_billing_phone

		oTmpDataRow("adrs_delivery_name") = oOrder.adrs_shipping_name
		oTmpDataRow("adrs_delivery_street") = oOrder.adrs_shipping_street
		oTmpDataRow("adrs_delivery_city") = oOrder.adrs_shipping_city
		oTmpDataRow("adrs_delivery_zip") = oOrder.adrs_shipping_zip
		oTmpDataRow("adrs_delivery_state_id") = oOrder.adrs_shipping_state_id
		oTmpDataRow("adrs_delivery_country_id") = oOrder.adrs_shipping_country_id
		oTmpDataRow("adrs_delivery_phone") = oOrder.adrs_shipping_phone

		oTmpDataRow("cannot_be_edited") = oOrder.cannot_be_edited

		oTmpDataRow("sts1_new_order_received") = oOrder.sts_new_order_received
		oTmpDataRow("sts1_new_order_received_date") = oOrder.sts_new_order_received_date

		oTmpDataRow("sts2_waiting_for_authorization") = oOrder.sts_waiting_for_authorization
		oTmpDataRow("sts2_waiting_for_authorization_date") = oOrder.sts_waiting_for_authorization_date
		oTmpDataRow("sts2_waiting_for_authorization_note") = oOrder.sts_waiting_for_authorization_note

		oTmpDataRow("sts3_waiting_for_payment") = oOrder.sts_waiting_for_payment
		oTmpDataRow("sts3_waiting_for_payment_date") = oOrder.sts_waiting_for_payment_date
		oTmpDataRow("sts3_waiting_for_payment_note") = oOrder.sts_waiting_for_payment_note

		oTmpDataRow("sts4_order_confirmed") = oOrder.sts_order_confirmed
		oTmpDataRow("sts4_order_confirmed_date") = oOrder.sts_order_confirmed_date
		oTmpDataRow("sts4_order_confirmed_note") = oOrder.sts_order_confirmed_note

		oTmpDataRow("sts5_partial_order_confirmed") = oOrder.sts_partial_order_confirmed
		oTmpDataRow("sts5_partial_order_confirmed_date") = oOrder.sts_partial_order_confirmed_date
		oTmpDataRow("sts5_partial_order_confirmed_note") = oOrder.sts_partial_order_confirmed_note

		oTmpDataRow("sts6_order_failed") = oOrder.sts_order_failed
		oTmpDataRow("sts6_order_failed_date") = oOrder.sts_order_failed_date
		oTmpDataRow("sts6_order_failed_note") = oOrder.sts_order_failed_note

		oTmpDataRow("sts7_order_waiting_to_be_send") = oOrder.sts_order_waiting_to_be_send
		oTmpDataRow("sts7_order_waiting_to_be_send_date") = oOrder.sts_order_waiting_to_be_send_date
		oTmpDataRow("sts7_order_waiting_to_be_send_note") = oOrder.sts_order_waiting_to_be_send_note

		oTmpDataRow("sts8_order_send") = oOrder.sts_order_send
		oTmpDataRow("sts8_order_send_date") = oOrder.sts_order_send_date
		oTmpDataRow("sts8_order_send_note") = oOrder.sts_order_send_note

		oTmpDataRow("sts9_partial_order_send") = oOrder.sts_partial_order_send
		oTmpDataRow("sts9_partial_order_send_date") = oOrder.sts_order_waiting_to_be_send_date
		oTmpDataRow("sts9_partial_order_send_note") = oOrder.sts_partial_order_send_note

		oTmpDataRow("sts10_order_received_by_customer") = oOrder.sts_order_received_by_customer
		oTmpDataRow("sts10_order_received_by_customer_date") = oOrder.sts_order_received_by_customer_date
		oTmpDataRow("sts10_order_received_by_customer_note") = oOrder.sts_order_received_by_customer_note

		oTmpDataRow("sts11_partial_order_received_by_customer") = oOrder.sts_partial_order_received_by_customer
		oTmpDataRow("sts11_partial_order_received_by_customer_date") = oOrder.sts_partial_order_received_by_customer_date
		oTmpDataRow("sts11_partial_order_received_by_customer_note") = oOrder.sts_partial_order_received_by_customer_note

		oTmpDataRow("sts12_customer_returning_order") = oOrder.sts_customer_returning_order
		oTmpDataRow("sts12_customer_returning_order_date") = oOrder.sts_customer_returning_order_date
		oTmpDataRow("sts12_customer_returning_order_note") = oOrder.sts_customer_returning_order_note

		oTmpDataRow("sts13_customer_returning_part_order") = oOrder.sts_customer_returning_part_order
		oTmpDataRow("sts13_customer_returning_part_order_date") = oOrder.sts_customer_returning_part_order_date
		oTmpDataRow("sts13_customer_returning_part_order_note") = oOrder.sts_customer_returning_part_order_note

		oTmpDataRow("sts14_customer_refunded") = oOrder.sts_customer_refunded
		oTmpDataRow("sts14_customer_refunded_date") = oOrder.sts_customer_refunded_date
		oTmpDataRow("sts14_customer_refunded_note") = oOrder.sts_customer_refunded_note

		oTmpDataRow("sts15_customer_partly_refunded") = oOrder.sts_customer_partly_refunded
		oTmpDataRow("sts15_customer_partly_refunded_date") = oOrder.sts_customer_partly_refunded_date
		oTmpDataRow("sts15_customer_partly_refunded_note") = oOrder.sts_customer_partly_refunded_note

		oTmpDataRow("sts16_order_closed") = oOrder.sts_order_closed
		oTmpDataRow("sts16_order_closed_date") = oOrder.sts_order_closed_date
		oTmpDataRow("sts16_order_closed_note") = oOrder.sts_order_closed_note

		oTmpDataRow("sts17_order_cancelled") = oOrder.sts_order_cancelled
		oTmpDataRow("sts17_order_cancelled_date") = oOrder.sts_order_cancelled_date
		oTmpDataRow("sts17_order_cancelled_note") = oOrder.sts_order_cancelled_note

		oTmpDataRow("sts_curr_stat") = oOrder.sts_curr_stat
		oTmpDataRow("sts_curr_date") = oOrder.sts_curr_date

		oTmpDataRow("Interest_start_date") = oOrder.interest_start_date
		oTmpDataRow("Interest_percent") = oOrder.interest_percentage

		oTmpDataRow("OrderDeleted") = oOrder.OrderDeleted
		oTmpDataRow("Merchant_Notes") = oOrder.merchant_notes
		oTmpDataRow("Customer_Notes") = oOrder.customer_notes
		oTmpDataRow("LastModify_Date") = Date.Now
		oTmpDataRow("LastModify_User") = oOrder.LastModify_User
		oTmpDataRow("LastModify_User_Id") = oOrder.LastModify_User_id
        oTmpDataRow("order_currency") = oOrder.order_currency
        oTmpDataRow("order_currency_rate") = oOrder.order_currency_rate

		'--- Assign Order_Items
		Dim nLoop1, nLoop2 As Integer
		Dim oTmpDataRow_item As DataRow


		'--- Clear table and add all item again (=in the transaction we are going to delete all
		'--- existing records and re-add them instead of editting them)
		oTmpOrder_Items.Clear()

		'--- Add All Order_Items
		For nLoop2 = 1 To oOrder.order_items.Count
			oTmpDataRow_item = oTmpOrder_Items.NewRow

			oTmpDataRow_item("id") = oOrder.id
			oTmpDataRow_item("OrderNumber") = oOrder.ordernumber
			oTmpDataRow_item("Item_id") = oOrder.order_items.Item(nLoop2).Item_id
			oTmpDataRow_item("Item_no") = oOrder.order_items.Item(nLoop2).Item_no
			oTmpDataRow_item("Item_quantity") = oOrder.order_items.Item(nLoop2).Item_quantity

			oTmpOrder_Items.Rows.Add(oTmpDataRow_item)
		Next


		'--- define system object
		Dim oSystem As ion_resources.cls_system = New ion_resources.cls_system
		oSystem.connection_string = Me.connection_string
		oSystem.dataset = oTmpDataset

		Dim oTmpBroker As ion_resources.cls_order_brk = New ion_resources.cls_order_brk
		oTmpBroker.order_id = oOrder.id
		oTmpBroker.order_no = oOrder.ordernumber
		bError = oTmpBroker.update_order(oSystem)
		If bError Then
			Me.error_no = oSystem.error_no
			Me.error_desc = oSystem.error_desc
			Me.error_source = oSystem.error_source
			Return True
			Exit Function
		End If

		'--- Receive 
		Me.order_id = oTmpBroker.order_id
		Me.order_no = oTmpBroker.order_no

		oTmpBroker = Nothing
		oSystem = Nothing


		Return False
		Exit Function

ErrorHandler:
		Me.error_no = Err.Number
		Me.error_desc = Err.Description
		Me.error_source = Err.Source
		Return True

	End Function


	Function update_order_new(ByRef oOrder As cls_order, ByVal bInventoryRemove As Boolean) As Boolean
		On Error GoTo ErrorHandler

		'--- local definitions
		Dim bError As Boolean = False

		'--- Get Dataset
		Dim oTmpDataset As DataSet = oOrder.order_dataset
		Dim oTmpOrders As DataTable = oTmpDataset.Tables("acc_ORDERS")
		Dim oTmpOrder_Items As DataTable = oTmpDataset.Tables("acc_ORDER_ITEMS")

		'--- Assign Order
		Dim oTmpDataRow As DataRow
		oTmpDataRow = oTmpOrders.Rows(0)

		'oTmpDataRow("ordernumber") = oOrder.ordernumber
		'oTmpDataRow("orderdate") = oOrder.OrderDate
		oTmpDataRow("InvoiceNumber") = oOrder.invoice_number
		oTmpDataRow("InvoiceDate") = oOrder.invoice_date
		oTmpDataRow("InvoiceCopy") = oOrder.invoice_copy
		oTmpDataRow("campaign") = oOrder.campaign
		oTmpDataRow("affiliate") = oOrder.affiliate
		oTmpDataRow("referrer") = oOrder.referrer
		oTmpDataRow("remote_ip") = oOrder.remote_ip
		oTmpDataRow("order_transacted") = oOrder.order_transacted

		'oTmpDataRow("user_id") = oOrder.user_id
		oTmpDataRow("packaging_id") = oOrder.packaging_id
		oTmpDataRow("payment_id") = oOrder.payment_id
		oTmpDataRow("shipping_id") = oOrder.shipping_id
		oTmpDataRow("shipping_tracking_no") = oOrder.shipping_tracking_no
		oTmpDataRow("cluborder") = oOrder.cluborder
		oTmpDataRow("jewelrysize") = oOrder.jewelry_size

		oTmpDataRow("amnt_items") = oOrder.amnt_items
		oTmpDataRow("amnt_wrapping") = oOrder.amnt_wrapping
		oTmpDataRow("amnt_shipping") = oOrder.amnt_shipping
		oTmpDataRow("amnt_extracharges") = oOrder.amnt_extracharges
		oTmpDataRow("amnt_labor") = oOrder.amnt_labor
		oTmpDataRow("amnt_vat") = oOrder.amnt_vat
		oTmpDataRow("amnt_discount") = oOrder.amnt_discount
		oTmpDataRow("amnt_subtotal") = oOrder.amnt_subtotal
		oTmpDataRow("amnt_grandtotal") = oOrder.amnt_grandtotal

		oTmpDataRow("adrs_billing_name") = oOrder.adrs_billing_name
		oTmpDataRow("adrs_billing_street") = oOrder.adrs_billing_street
		oTmpDataRow("adrs_billing_city") = oOrder.adrs_billing_city
		oTmpDataRow("adrs_billing_zip") = oOrder.adrs_billing_zip
		oTmpDataRow("adrs_billing_state_id") = oOrder.adrs_billing_state_id
		oTmpDataRow("adrs_billing_country_id") = oOrder.adrs_billing_country_id
		oTmpDataRow("adrs_billing_phone") = oOrder.adrs_billing_phone

		oTmpDataRow("adrs_delivery_name") = oOrder.adrs_shipping_name
		oTmpDataRow("adrs_delivery_street") = oOrder.adrs_shipping_street
		oTmpDataRow("adrs_delivery_city") = oOrder.adrs_shipping_city
		oTmpDataRow("adrs_delivery_zip") = oOrder.adrs_shipping_zip
		oTmpDataRow("adrs_delivery_state_id") = oOrder.adrs_shipping_state_id
		oTmpDataRow("adrs_delivery_country_id") = oOrder.adrs_shipping_country_id
		oTmpDataRow("adrs_delivery_phone") = oOrder.adrs_shipping_phone

		oTmpDataRow("cannot_be_edited") = oOrder.cannot_be_edited

		oTmpDataRow("sts1_new_order_received") = oOrder.sts_new_order_received
		oTmpDataRow("sts1_new_order_received_date") = oOrder.sts_new_order_received_date

		oTmpDataRow("sts2_waiting_for_authorization") = oOrder.sts_waiting_for_authorization
		oTmpDataRow("sts2_waiting_for_authorization_date") = oOrder.sts_waiting_for_authorization_date
		oTmpDataRow("sts2_waiting_for_authorization_note") = oOrder.sts_waiting_for_authorization_note

		oTmpDataRow("sts3_waiting_for_payment") = oOrder.sts_waiting_for_payment
		oTmpDataRow("sts3_waiting_for_payment_date") = oOrder.sts_waiting_for_payment_date
		oTmpDataRow("sts3_waiting_for_payment_note") = oOrder.sts_waiting_for_payment_note

		oTmpDataRow("sts4_order_confirmed") = oOrder.sts_order_confirmed
		oTmpDataRow("sts4_order_confirmed_date") = oOrder.sts_order_confirmed_date
		oTmpDataRow("sts4_order_confirmed_note") = oOrder.sts_order_confirmed_note

		oTmpDataRow("sts5_partial_order_confirmed") = oOrder.sts_partial_order_confirmed
		oTmpDataRow("sts5_partial_order_confirmed_date") = oOrder.sts_partial_order_confirmed_date
		oTmpDataRow("sts5_partial_order_confirmed_note") = oOrder.sts_partial_order_confirmed_note

		oTmpDataRow("sts6_order_failed") = oOrder.sts_order_failed
		oTmpDataRow("sts6_order_failed_date") = oOrder.sts_order_failed_date
		oTmpDataRow("sts6_order_failed_note") = oOrder.sts_order_failed_note

		oTmpDataRow("sts7_order_waiting_to_be_send") = oOrder.sts_order_waiting_to_be_send
		oTmpDataRow("sts7_order_waiting_to_be_send_date") = oOrder.sts_order_waiting_to_be_send_date
		oTmpDataRow("sts7_order_waiting_to_be_send_note") = oOrder.sts_order_waiting_to_be_send_note

		oTmpDataRow("sts8_order_send") = oOrder.sts_order_send
		oTmpDataRow("sts8_order_send_date") = oOrder.sts_order_send_date
		oTmpDataRow("sts8_order_send_note") = oOrder.sts_order_send_note

		oTmpDataRow("sts9_partial_order_send") = oOrder.sts_partial_order_send
		oTmpDataRow("sts9_partial_order_send_date") = oOrder.sts_order_waiting_to_be_send_date
		oTmpDataRow("sts9_partial_order_send_note") = oOrder.sts_partial_order_send_note

		oTmpDataRow("sts10_order_received_by_customer") = oOrder.sts_order_received_by_customer
		oTmpDataRow("sts10_order_received_by_customer_date") = oOrder.sts_order_received_by_customer_date
		oTmpDataRow("sts10_order_received_by_customer_note") = oOrder.sts_order_received_by_customer_note

		oTmpDataRow("sts11_partial_order_received_by_customer") = oOrder.sts_partial_order_received_by_customer
		oTmpDataRow("sts11_partial_order_received_by_customer_date") = oOrder.sts_partial_order_received_by_customer_date
		oTmpDataRow("sts11_partial_order_received_by_customer_note") = oOrder.sts_partial_order_received_by_customer_note

		oTmpDataRow("sts12_customer_returning_order") = oOrder.sts_customer_returning_order
		oTmpDataRow("sts12_customer_returning_order_date") = oOrder.sts_customer_returning_order_date
		oTmpDataRow("sts12_customer_returning_order_note") = oOrder.sts_customer_returning_order_note

		oTmpDataRow("sts13_customer_returning_part_order") = oOrder.sts_customer_returning_part_order
		oTmpDataRow("sts13_customer_returning_part_order_date") = oOrder.sts_customer_returning_part_order_date
		oTmpDataRow("sts13_customer_returning_part_order_note") = oOrder.sts_customer_returning_part_order_note

		oTmpDataRow("sts14_customer_refunded") = oOrder.sts_customer_refunded
		oTmpDataRow("sts14_customer_refunded_date") = oOrder.sts_customer_refunded_date
		oTmpDataRow("sts14_customer_refunded_note") = oOrder.sts_customer_refunded_note

		oTmpDataRow("sts15_customer_partly_refunded") = oOrder.sts_customer_partly_refunded
		oTmpDataRow("sts15_customer_partly_refunded_date") = oOrder.sts_customer_partly_refunded_date
		oTmpDataRow("sts15_customer_partly_refunded_note") = oOrder.sts_customer_partly_refunded_note

		oTmpDataRow("sts16_order_closed") = oOrder.sts_order_closed
		oTmpDataRow("sts16_order_closed_date") = oOrder.sts_order_closed_date
		oTmpDataRow("sts16_order_closed_note") = oOrder.sts_order_closed_note

		oTmpDataRow("sts17_order_cancelled") = oOrder.sts_order_cancelled
		oTmpDataRow("sts17_order_cancelled_date") = oOrder.sts_order_cancelled_date
		oTmpDataRow("sts17_order_cancelled_note") = oOrder.sts_order_cancelled_note

		oTmpDataRow("sts_curr_stat") = oOrder.sts_curr_stat
		oTmpDataRow("sts_curr_date") = oOrder.sts_curr_date

		oTmpDataRow("Interest_start_date") = oOrder.interest_start_date
		oTmpDataRow("Interest_percent") = oOrder.interest_percentage

		oTmpDataRow("OrderDeleted") = oOrder.OrderDeleted
		oTmpDataRow("Merchant_Notes") = oOrder.merchant_notes
		oTmpDataRow("Customer_Notes") = oOrder.customer_notes
		oTmpDataRow("LastModify_Date") = Date.Now
		oTmpDataRow("LastModify_User") = oOrder.LastModify_User
		oTmpDataRow("LastModify_User_Id") = oOrder.LastModify_User_id
        oTmpDataRow("order_currency") = oOrder.order_currency
        oTmpDataRow("order_currency_rate") = oOrder.order_currency_rate
        oTmpDataRow("include_receipt") = oOrder.include_receipt
        oTmpDataRow("hear_fromus") = oOrder.hear_fromus
		'--- Assign Order_Items
		Dim nLoop1, nLoop2 As Integer
		Dim oTmpDataRow_item As DataRow


		'--- Clear table and add all item again (=in the transaction we are going to delete all
		'--- existing records and re-add them instead of editting them)
		oTmpOrder_Items.Clear()

		'--- Add All Order_Items
		For nLoop2 = 1 To oOrder.order_items.Count
			oTmpDataRow_item = oTmpOrder_Items.NewRow

			oTmpDataRow_item("order_id") = oOrder.id
			oTmpDataRow_item("OrderNumber") = oOrder.ordernumber
			oTmpDataRow_item("Item_id") = oOrder.order_items.Item(nLoop2).Item_id
			oTmpDataRow_item("Item_no") = oOrder.order_items.Item(nLoop2).Item_no
			oTmpDataRow_item("Item_quantity") = oOrder.order_items.Item(nLoop2).Item_quantity
			oTmpDataRow_item("jewelsize") = oOrder.order_items.Item(nLoop2).jewelsize

			oTmpOrder_Items.Rows.Add(oTmpDataRow_item)

			'--- Remove from inventory if needed
			If bInventoryRemove Then
				Dim oTmpOrderFunctions As New ion_resources.cls_functions_order
				oTmpOrderFunctions.connection_string = Me.connection_string
				bError = oTmpOrderFunctions.set_cur_inventory(oOrder.order_items.Item(nLoop2).Item_id, oOrder.order_items.Item(nLoop2).Item_quantity)
				If bError Then
					Me.error_no = Err.Number
					Me.error_source = Err.Source
					Me.error_desc = Err.Description
					Return True
				End If
				oTmpOrderFunctions = Nothing
			End If

		Next


		'--- Instantiate the Transactor
		Dim oTransactor As New ion_resources.cls_mt_orders
		oTransactor.connection_string = Me.connection_string
		oTransactor.connection = Me.connection
		oTransactor.transaction = Me.transaction

		'--- Prepare and load table 1
		Dim oTable1 As New ion_idac.cls_cll_datatables
		oTable1.datatable = oTmpOrders
		oTransactor.i_cll_datatables.Add(oTable1)

		'--- Prepare and load table 2
		Dim oTable2 As New ion_idac.cls_cll_datatables
		oTable2.datatable = oTmpOrder_Items
		oTable2.ignoreget = True
		oTransactor.i_cll_datatables.Add(oTable2)

		oTransactor.id = oOrder.id

		bError = oTransactor.transact_update
		If bError Then
			Me.error_no = oTransactor.error_no
			Me.error_desc = oTransactor.error_desc
			Me.error_source = oTransactor.error_source
			Return True
		End If

		'--- Get Order Number
		Me.order_no = oTransactor.i_cll_datatables(1).datatable.rows(0).itemarray(1)

		oTable1 = Nothing
		oTable2 = Nothing
		oTransactor = Nothing

		Return False
		Exit Function

ErrorHandler:
		Me.error_no = Err.Number
		Me.error_desc = Err.Description
		Me.error_source = Err.Source
		Return True

	End Function


	Public Property error_no() As Integer
		Get
			Return m_error_no
		End Get

		Set(ByVal Value As Integer)
			m_error_no = Value
		End Set
	End Property

	Public Property error_desc() As String
		Get
			Return m_error_desc
		End Get

		Set(ByVal Value As String)
			m_error_desc = Value
		End Set
	End Property

	Public Property error_source() As String
		Get
			Return m_error_source
		End Get

		Set(ByVal Value As String)
			m_error_source = Value
		End Set
	End Property

	Public Property connection_string() As String
		Get
			Return m_connection_string
		End Get

		Set(ByVal Value As String)
			m_connection_string = Value
		End Set
	End Property

	Public Property order_id() As Int32
		Get
			Return m_order_id
		End Get

		Set(ByVal Value As Int32)
			m_order_id = Value
		End Set
	End Property

	Public Property order_no() As Int32
		Get
			Return m_order_no
		End Get

		Set(ByVal Value As Int32)
			m_order_no = Value
		End Set
	End Property

	Public Property transaction() As System.Data.SqlClient.SqlTransaction
		Get
			Return m_transaction
		End Get

		Set(ByVal Value As System.Data.SqlClient.SqlTransaction)
			m_transaction = Value
		End Set
	End Property

	Public Property connection() As System.Data.SqlClient.SqlConnection
		Get
			Return m_connection
		End Get

		Set(ByVal Value As System.Data.SqlClient.SqlConnection)
			m_connection = Value
		End Set
	End Property

End Class
