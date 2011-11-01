Public Class cls_order_totals
	Inherits iFoundation.cls_error_connection

	Public _amnt_cost As Decimal
	Public _amnt_items As Decimal
	Public _amnt_wrapping As Decimal
	Public _amnt_labor As Decimal
	Public _amnt_extracharges As Decimal
	Public _amnt_vat As Decimal
	Public _amnt_subtotal As Decimal
	Public _amnt_discount As Decimal
	Public _amnt_grandtotal As Decimal
	Public _amnt_transactions As Decimal
	Public _amnt_interest As Decimal
	Public _amnt_shipping As Decimal
	Public _items As New Collection
	Public _Isdealer As Boolean
	Public _order_id As Int32
	Public _order_number As Int32
	Public _invoice_number As Int32

	Sub New()
		Me._amnt_cost = 0
		Me._amnt_items = 0
		Me._amnt_wrapping = 0
		Me._amnt_labor = 0
		Me._amnt_extracharges = 0
		Me._amnt_vat = 0
		Me._amnt_subtotal = 0
		Me._amnt_discount = 0
		Me._amnt_grandtotal = 0
		Me._amnt_transactions = 0
		Me._amnt_interest = 0
		Me._amnt_shipping = 0
		Me._Isdealer = False
		Me._order_id = 0
		Me._order_number = 0
		Me._invoice_number = 0
	End Sub

	Public Function get_totals(ByVal nOrder_Id As Int32, ByVal cUserName As String, ByVal nUserId As Int32) As Boolean
		'--- Get order and all its dependets
		On Error GoTo ErrorHandler
		Dim bError As Boolean = False

		'--- Set order id
		Me._order_id = nOrder_Id

		'--- Get the order prices
		bError = Me.get_order_amounts(nOrder_Id)
		If bError Then
			Me._err_number = Err.Number
			Me._err_description = Err.Description
			Me._err_source = Err.Source
			Return True
		End If


		'--- Get Customer from order
		Dim nCustomerId As Int32
		Dim cCustomerName As String
		Dim oOrder_functions As New ion_two.cls_functions_orders
		oOrder_functions._connection_string = Me._connection_string
		oOrder_functions._dbtype = Me._dbtype
		bError = oOrder_functions.get_order_user(nOrder_Id, nCustomerId, cCustomerName)
		If bError Then
			Me._err_number = oOrder_functions._err_number
			Me._err_description = oOrder_functions._err_description
			Me._err_source = oOrder_functions._err_source
			Return True
		End If
		oOrder_functions = Nothing


		'--- Check if user is dealer
		Dim oCustomer_functions As New ion_two.cls_functions_user
		oCustomer_functions._connection_string = Me._connection_string
		oCustomer_functions._dbtype = Me._dbtype
		bError = oCustomer_functions.get_isdealer(nCustomerId, Me._Isdealer)
		If bError Then
			Me._err_number = Err.Number
			Me._err_description = Err.Description
			Me._err_source = Err.Source
			Return True
		End If
		oCustomer_functions = Nothing

		'--- Get all the items of this order
		bError = Me.get_order_items(nOrder_Id)
		If bError Then
			Me._err_number = Err.Number
			Me._err_description = Err.Description
			Me._err_source = Err.Source
			Return True
		End If

		'--- Get all the Transaction costs for this order
		Dim oFunctions_Cashflow As New ion_two.cls_functions_cashflow
		oFunctions_Cashflow._connection_string = Me._connection_string
		oFunctions_Cashflow._dbtype = Me._dbtype
		bError = oFunctions_Cashflow.get_total_transaction_costs(nOrder_Id, Me._amnt_transactions)
		If bError Then
			Me._err_number = Err.Number
			Me._err_description = Err.Description
			Me._err_source = Err.Source
			Return True
		End If

		'--- Get all the Interest payed for this order
		bError = oFunctions_Cashflow.get_total_interest_costs(nOrder_Id, Me._amnt_interest)
		If bError Then
			Me._err_number = Err.Number
			Me._err_description = Err.Description
			Me._err_source = Err.Source
			Return True
		End If
		oFunctions_Cashflow = Nothing


		'--- Create proper collections for saveing routine
		Dim oSuppliers As New Collection
		Dim oGeneral As New Collection
		bError = make_collection(oSuppliers, oGeneral, cUserName, nUserId)
		If bError Then
			Me._err_number = Err.Number
			Me._err_description = Err.Description
			Me._err_source = Err.Source
			Return True
		End If


		'--- Save Books
		'--- SET supplier books
		Dim oBooks_suppliers_logics As New ion_two.cls_books_suppliers_lgc
		oBooks_suppliers_logics._connection_string = Me._connection_string
		oBooks_suppliers_logics._dbtype = Me._dbtype
		oBooks_suppliers_logics._idac_transaction = Me._idac_transaction
		bError = oBooks_suppliers_logics.insert(oSuppliers)
		If bError Then
			Me._idac_transaction._transaction.Rollback()
			Me._err_number = oBooks_suppliers_logics._err_number
			Me._err_description = oBooks_suppliers_logics._err_description
			Me._err_source = oBooks_suppliers_logics._err_source
			Return True
		End If


		'--- SET General books
		Dim oBooks_general_logics As New ion_two.cls_books_general_lgc
		oBooks_general_logics._connection_string = Me._connection_string
		oBooks_general_logics._dbtype = Me._dbtype
		oBooks_general_logics._idac_transaction = Me._idac_transaction
		bError = oBooks_general_logics.insert(oGeneral)
		If bError Then
			Me._idac_transaction._transaction.Rollback()
			Me._err_number = oBooks_general_logics._err_number
			Me._err_description = oBooks_general_logics._err_description
			Me._err_source = oBooks_general_logics._err_source
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

	Public Function get_order_amounts(ByRef nOrder_Id As Int32) As Boolean
		On Error GoTo ErrorHandler
		Dim bError As Boolean = False

		'--- Define information to read
		Dim oTmpDataBroker As New iDac.cls_T_datareader
		oTmpDataBroker._dbtype = Me._dbtype
		oTmpDataBroker._connection_string = Me._connection_string
		oTmpDataBroker._table = "acc_ORDERS"
		oTmpDataBroker._id = nOrder_Id

		'--- Define records
		Dim oField1 As New iDac.cls_cll_datareader
		oField1._field = "id"
		oTmpDataBroker._fields.Add(oField1)
		oField1 = Nothing

		Dim oField2 As New iDac.cls_cll_datareader
		oField2._field = "ordernumber"
		oTmpDataBroker._fields.Add(oField2)
		oField2 = Nothing

		Dim oField3 As New iDac.cls_cll_datareader
		oField3._field = "user_id"
		oTmpDataBroker._fields.Add(oField3)
		oField3 = Nothing

		Dim oField4 As New iDac.cls_cll_datareader
		oField4._field = "amnt_items"
		oTmpDataBroker._fields.Add(oField4)
		oField4 = Nothing

		Dim oField5 As New iDac.cls_cll_datareader
		oField5._field = "amnt_wrapping"
		oTmpDataBroker._fields.Add(oField5)
		oField5 = Nothing

		Dim oField6 As New iDac.cls_cll_datareader
		oField6._field = "amnt_labor"
		oTmpDataBroker._fields.Add(oField6)
		oField6 = Nothing

		Dim oField7 As New iDac.cls_cll_datareader
		oField7._field = "amnt_shipping"
		oTmpDataBroker._fields.Add(oField7)
		oField7 = Nothing

		Dim oField8 As New iDac.cls_cll_datareader
		oField8._field = "amnt_extracharges"
		oTmpDataBroker._fields.Add(oField8)
		oField8 = Nothing

		Dim oField9 As New iDac.cls_cll_datareader
		oField9._field = "amnt_vat"
		oTmpDataBroker._fields.Add(oField9)
		oField9 = Nothing

		Dim oField10 As New iDac.cls_cll_datareader
		oField10._field = "amnt_subtotal"
		oTmpDataBroker._fields.Add(oField10)
		oField10 = Nothing

		Dim oField11 As New iDac.cls_cll_datareader
		oField11._field = "amnt_discount"
		oTmpDataBroker._fields.Add(oField11)
		oField11 = Nothing

		Dim oField12 As New iDac.cls_cll_datareader
		oField12._field = "amnt_grandtotal"
		oTmpDataBroker._fields.Add(oField12)
		oField12 = Nothing

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
			nOrder_Id = oTmpDataBroker._fields.Item(1)._result
			Me._order_number = oTmpDataBroker._fields.Item(2)._result
			Me._user_id = oTmpDataBroker._fields.Item(3)._result
			Me._amnt_items = oTmpDataBroker._fields.Item(4)._result
			Me._amnt_wrapping = oTmpDataBroker._fields.Item(5)._result
			Me._amnt_labor = oTmpDataBroker._fields.Item(6)._result
			Me._amnt_shipping = oTmpDataBroker._fields.Item(7)._result
			Me._amnt_extracharges = oTmpDataBroker._fields.Item(8)._result
			Me._amnt_vat = oTmpDataBroker._fields.Item(9)._result
			Me._amnt_subtotal = oTmpDataBroker._fields.Item(10)._result
			Me._amnt_discount = oTmpDataBroker._fields.Item(11)._result
			Me._amnt_grandtotal = oTmpDataBroker._fields.Item(12)._result
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

	Public Function get_order_items(ByVal nOrder_Id As Int32) As Boolean
		On Error GoTo ErrorHandler
		Dim bError As Boolean = False

		'--- Define Connection String
		Dim bConnection_open As Boolean = False
		Dim bDatareader_open As Boolean = False
		Dim cSQL As String
		cSQL = "select 	order_items.item_id, "
		cSQL = cSQL + "	order_items.item_no, "
		cSQL = cSQL + "	order_items.item_quantity, "
		cSQL = cSQL + "	inventory.purchase_price, "
		cSQL = cSQL + "	inventory.dealer_price, "
		cSQL = cSQL + "	inventory.sell_price, "
		cSQL = cSQL + "	inventory.special_sell_price, "
		cSQL = cSQL + "	inventory.special_dealer_price, "
		cSQL = cSQL + "	inventory.onspecial, "
		cSQL = cSQL + "	inventory.onspecial_from_date, "
		cSQL = cSQL + "	inventory.onspecial_to_date, "
		cSQL = cSQL + "	inventory.branchnumber, "
		cSQL = cSQL + "	inventory.suppliernumber "
		cSQL = cSQL + "from	acc_ORDER_ITEMS as order_items, "
		cSQL = cSQL + "	inv_INVENTORY as inventory "
		cSQL = cSQL + "where order_items.item_id = inventory.id "
		cSQL = cSQL + " and order_items.order_id = " & nOrder_Id


		Dim objConn As New SqlClient.SqlConnection(Me._connection_string)
		Dim cSQLstring As SqlClient.SqlCommand = New SqlClient.SqlCommand(cSQL, objConn)
		objConn.Open()
		bConnection_open = True

		Dim dr_Reader As SqlClient.SqlDataReader = cSQLstring.ExecuteReader()
		bDatareader_open = True

		While dr_Reader.Read()
			'--- initiate Item object
			Dim oTmpItem As New ion_two.skl_order_item_amounts

			oTmpItem._item_id = dr_Reader.Item("item_id")
			oTmpItem._item_number = dr_Reader.Item("item_no")
			oTmpItem._item_cost = dr_Reader.Item("purchase_price")
			oTmpItem._item_sell = dr_Reader.Item("sell_price")
			oTmpItem._item_sell_dealer = dr_Reader.Item("dealer_price")
			oTmpItem._item_sell_special = dr_Reader.Item("special_sell_price")
			oTmpItem._item_sell_dealer_special = dr_Reader.Item("special_dealer_price")
			oTmpItem._quantity = dr_Reader.Item("item_quantity")
			oTmpItem._branch_id = dr_Reader.Item("branchnumber")
			oTmpItem._supplier_id = dr_Reader.Item("suppliernumber")
			oTmpItem._item_special = dr_Reader.Item("onspecial")
			oTmpItem._item_special_from = dr_Reader.Item("onspecial_from_date")
			oTmpItem._item_special_to = dr_Reader.Item("onspecial_to_date")


			'--- Check if item special
			If dr_Reader.Item("onspecial") Then
				If Today.Date >= dr_Reader.Item("onspecial_from_date") And Today.Date <= dr_Reader.Item("onspecial_to_date") Then
					oTmpItem._item_special = True
				End If
			End If

			'--- Calculate total cost
			Me._amnt_cost = Me._amnt_cost + (oTmpItem._item_cost * oTmpItem._quantity)


			Me._items.Add(oTmpItem)
			oTmpItem = Nothing

		End While

		objConn.Close()
		dr_Reader.Close()


		Return False
		Exit Function

ErrorHandler:
		If bDatareader_open Then
			dr_Reader.Close()
		End If
		If bConnection_open Then
			objConn.Close()
		End If

		'--- register the error
		Me._err_number = Err.Number
		Me._err_description = Err.Description
		Me._err_source = Err.Source
		Return True

	End Function

	Private Function make_collection(ByVal oSuppliers As Collection, ByVal oGeneral As Collection, ByVal cUserName As String, ByVal nUserId As Int32) As Boolean
		On Error GoTo ErrorHandler
		Dim bError As Boolean = False


		'--- Create GENERAL collection
		Dim nId As Int32 = 9999
		Dim nOrder_id As Int32 = Me._order_id
		Dim dTransaction_date As DateTime = Today.Now
		Dim dLastModify_date As DateTime = Today.Now
		Dim cDescription As String = "auto: Order no: " + Me._order_number.ToString + " Invoice no: " + Me._invoice_number.ToString

		'--- Get Rate
		Dim nRateIls As Decimal
		Dim oAccounting_functions As New ion_two.cls_functions_accounting
		oAccounting_functions._connection_string = Me._connection_string
		oAccounting_functions._dbtype = Me._dbtype
		bError = oAccounting_functions.get_rate(nRateIls)
		If bError Then
			Me._err_number = oAccounting_functions._err_number
			Me._err_description = oAccounting_functions._err_description
			Me._err_source = oAccounting_functions._err_source
			Return True
		End If
		oAccounting_functions = Nothing

		'---### Purchase Cost's
		Dim oGeneral_10 As New ion_two.skl_books_general
		oGeneral_10._trs_id = nId
		oGeneral_10._order_id = nOrder_id
		oGeneral_10._trs_date = dTransaction_date
		oGeneral_10._lastmodify_date = dLastModify_date
		oGeneral_10._lastmodify_user = cUserName
		oGeneral_10._lastmodify_user_id = nUserId
		oGeneral_10._description = cDescription
		oGeneral_10._account_id = 10
		oGeneral_10._rate_ils = nRateIls
		oGeneral_10._amount = Me._amnt_cost
		oGeneral.Add(oGeneral_10)
		oGeneral_10 = Nothing


		'---### Wrapping
		If Me._amnt_wrapping <> 0 Then
			Dim oGeneral_11 As New ion_two.skl_books_general
			oGeneral_11._trs_id = nId
			oGeneral_11._order_id = nOrder_id
			oGeneral_11._trs_date = dTransaction_date
			oGeneral_11._lastmodify_date = dLastModify_date
			oGeneral_11._lastmodify_user = cUserName
			oGeneral_11._lastmodify_user_id = nUserId
			oGeneral_11._description = cDescription
			oGeneral_11._account_id = 11
			oGeneral_11._rate_ils = nRateIls
			oGeneral_11._amount = Me._amnt_wrapping
			oGeneral.Add(oGeneral_11)
			oGeneral_11 = Nothing
		End If

		'---### Labor
		If Me._amnt_labor <> 0 Then
			Dim oGeneral_12 As New ion_two.skl_books_general
			oGeneral_12._trs_id = nId
			oGeneral_12._order_id = nOrder_id
			oGeneral_12._trs_date = dTransaction_date
			oGeneral_12._lastmodify_date = dLastModify_date
			oGeneral_12._lastmodify_user = cUserName
			oGeneral_12._lastmodify_user_id = nUserId
			oGeneral_12._description = cDescription
			oGeneral_12._account_id = 12
			oGeneral_12._rate_ils = nRateIls
			oGeneral_12._amount = Me._amnt_labor
			oGeneral.Add(oGeneral_12)
			oGeneral_12 = Nothing
		End If

		'---### Extra Chrges
		If Me._amnt_extracharges <> 0 Then
			Dim oGeneral_13 As New ion_two.skl_books_general
			oGeneral_13._trs_id = nId
			oGeneral_13._order_id = nOrder_id
			oGeneral_13._trs_date = dTransaction_date
			oGeneral_13._lastmodify_date = dLastModify_date
			oGeneral_13._lastmodify_user = cUserName
			oGeneral_13._lastmodify_user_id = nUserId
			oGeneral_13._description = cDescription
			oGeneral_13._account_id = 13
			oGeneral_13._rate_ils = nRateIls
			oGeneral_13._amount = Me._amnt_extracharges
			oGeneral.Add(oGeneral_13)
			oGeneral_13 = Nothing
		End If

		'---### VAT
		If Me._amnt_vat <> 0 Then
			Dim oGeneral_14 As New ion_two.skl_books_general
			oGeneral_14._trs_id = nId
			oGeneral_14._order_id = nOrder_id
			oGeneral_14._trs_date = dTransaction_date
			oGeneral_14._lastmodify_date = dLastModify_date
			oGeneral_14._lastmodify_user = cUserName
			oGeneral_14._lastmodify_user_id = nUserId
			oGeneral_14._description = cDescription
			oGeneral_14._account_id = 14
			oGeneral_14._rate_ils = nRateIls
			oGeneral_14._amount = Me._amnt_vat
			oGeneral.Add(oGeneral_14)
			oGeneral_14 = Nothing
		End If

		'---### Discount
		If Me._amnt_discount <> 0 Then
			Dim oGeneral_15 As New ion_two.skl_books_general
			oGeneral_15._trs_id = nId
			oGeneral_15._order_id = nOrder_id
			oGeneral_15._trs_date = dTransaction_date
			oGeneral_15._lastmodify_date = dLastModify_date
			oGeneral_15._lastmodify_user = cUserName
			oGeneral_15._lastmodify_user_id = nUserId
			oGeneral_15._description = cDescription
			oGeneral_15._account_id = 15
			oGeneral_15._rate_ils = nRateIls
			oGeneral_15._amount = Me._amnt_labor
			oGeneral.Add(oGeneral_15)
			oGeneral_15 = Nothing
		End If

		'---### Transaction
		If Me._amnt_transactions <> 0 Then
			Dim oGeneral_16 As New ion_two.skl_books_general
			oGeneral_16._trs_id = nId
			oGeneral_16._order_id = nOrder_id
			oGeneral_16._trs_date = dTransaction_date
			oGeneral_16._lastmodify_date = dLastModify_date
			oGeneral_16._lastmodify_user = cUserName
			oGeneral_16._lastmodify_user_id = nUserId
			oGeneral_16._description = cDescription
			oGeneral_16._account_id = 16
			oGeneral_16._rate_ils = nRateIls
			oGeneral_16._amount = Me._amnt_transactions
			oGeneral.Add(oGeneral_16)
			oGeneral_16 = Nothing
		End If

		'---### Actual sell amount
		Dim oGeneral_17 As New ion_two.skl_books_general
		oGeneral_17._trs_id = nId
		oGeneral_17._order_id = nOrder_id
		oGeneral_17._trs_date = dTransaction_date
		oGeneral_17._lastmodify_date = dLastModify_date
		oGeneral_17._lastmodify_user = cUserName
		oGeneral_17._lastmodify_user_id = nUserId
		oGeneral_17._description = cDescription
		oGeneral_17._account_id = 17
		oGeneral_17._rate_ils = nRateIls
		oGeneral_17._amount = Me._amnt_grandtotal
		oGeneral.Add(oGeneral_17)
		oGeneral_17 = Nothing

		'---### total Interest payed
		If Me._amnt_interest <> 0 Then
			Dim oGeneral_18 As New ion_two.skl_books_general
			oGeneral_18._trs_id = nId
			oGeneral_18._order_id = nOrder_id
			oGeneral_18._trs_date = dTransaction_date
			oGeneral_18._lastmodify_date = dLastModify_date
			oGeneral_18._lastmodify_user = cUserName
			oGeneral_18._lastmodify_user_id = nUserId
			oGeneral_18._description = cDescription
			oGeneral_18._account_id = 18
			oGeneral_18._rate_ils = nRateIls
			oGeneral_18._amount = Me._amnt_interest
			oGeneral.Add(oGeneral_18)
			oGeneral_18 = Nothing
		End If

		'---### total Shipping charges
		If Me._amnt_shipping <> 0 Then
			Dim oGeneral_19 As New ion_two.skl_books_general
			oGeneral_19._trs_id = nId
			oGeneral_19._order_id = nOrder_id
			oGeneral_19._trs_date = dTransaction_date
			oGeneral_19._lastmodify_date = dLastModify_date
			oGeneral_19._lastmodify_user = cUserName
			oGeneral_19._lastmodify_user_id = nUserId
			oGeneral_19._description = cDescription
			oGeneral_19._account_id = 19
			oGeneral_19._rate_ils = nRateIls
			oGeneral_19._amount = Me._amnt_shipping
			oGeneral.Add(oGeneral_19)
			oGeneral_19 = Nothing
		End If


		'--- Create SUPPLIERS collection
		Dim nLoop As Int16
		For nLoop = 1 To Me._items.Count
			Dim oSuppliers_1 As New ion_two.skl_books_suppliers
			oSuppliers_1._trs_id = nId
			oSuppliers_1._order_id = nOrder_id
			oSuppliers_1._rate_ils = nRateIls
			oSuppliers_1._trs_date = dTransaction_date
			oSuppliers_1._lastmodify_date = dLastModify_date
			oSuppliers_1._lastmodify_user = cUserName
			oSuppliers_1._lastmodify_user_id = nUserId
			oSuppliers_1._amount = Me._items(nLoop)._item_cost
			oSuppliers_1._item_id = Me._items(nLoop)._item_id
			oSuppliers_1._item_qty = Me._items(nLoop)._quantity

			'--- Get id2 for supplier
			Dim oFunctions_Suppliers As New ion_two.cls_functions_suppliers
			oFunctions_Suppliers._connection_string = Me._connection_string
			oFunctions_Suppliers._dbtype = Me._dbtype
			bError = oFunctions_Suppliers.get_supplier_id2(Me._items(nLoop)._supplier_id, Me._items(nLoop)._branch_id, oSuppliers_1._supplier_id2)
			If bError Then
				Me._err_number = Err.Number
				Me._err_description = Err.Description
				Me._err_source = Err.Source
				Return True
			End If
			oFunctions_Suppliers = Nothing

			'--- declare price constructor - to calculate profit
			Dim oPrice_cons As New ion_two.cons_price
			oPrice_cons._purchase_price = Me._items(nLoop)._item_cost
			oPrice_cons._isdealer = Me._Isdealer
			oPrice_cons._dealer_price = Me._items(nLoop)._item_sell_dealer
			oPrice_cons._sell_price = Me._items(nLoop)._item_sell
			oPrice_cons._special_sell_price = Me._items(nLoop)._item_sell_special
			oPrice_cons._special_dealer_price = Me._items(nLoop)._item_sell_dealer_special
			oPrice_cons._isspecial = Me._items(nLoop)._item_special
			oPrice_cons._special_from = Me._items(nLoop)._item_special_from
			oPrice_cons._special_to = Me._items(nLoop)._item_special_to

			'--- Get the correct price
			bError = oPrice_cons.get_price()
			If bError Then
				Me._err_number = Err.Number
				Me._err_description = Err.Description
				Me._err_source = Err.Source
				Return True
			End If

			'Dim cProfit As String = Format(Convert.ToDecimal(oTmpPrice.correct_price - Me.items(nLoop).item_cost), "##,##0.00") + " $us"
			Dim cProfit As String = Convert.ToDecimal(oPrice_cons._correct_price - Me._items(nLoop)._item_cost)
			oSuppliers_1._description = "auto: Sale of item no: " + Me._items(nLoop)._item_number + " <" + cProfit + ">"

			oSuppliers.Add(oSuppliers_1)
			oSuppliers_1 = Nothing
		Next


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
