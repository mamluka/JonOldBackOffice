Public Class cls_order_totals
    '--- This module transfers a purchase to the books

    '--- Default properties for every class
    Private m_connection_string As String
    Private m_error_number As Int32
    Private m_error_source As String
    Private m_error_description As String

	Private m_transaction As System.Data.SqlClient.SqlTransaction
	Private m_connection As System.Data.SqlClient.SqlConnection

    '--- Locals
    Private m_amnt_cost As Decimal
    Private m_amnt_items As Decimal
    Private m_amnt_wrapping As Decimal
    Private m_amnt_labor As Decimal
    Private m_amnt_extracharges As Decimal
    Private m_amnt_vat As Decimal
    Private m_amnt_subtotal As Decimal
    Private m_amnt_discount As Decimal
    Private m_amnt_grandtotal As Decimal
    Private m_amnt_transactions As Decimal
    Private m_amnt_interest As Decimal
    Private m_amnt_shipping As Decimal
    Private m_items As New Collection()
    Private m_Isdealer As Boolean
    Private m_user_id As Int32
    Private m_order_id As Int32
    Private m_order_number As Int32
    Private m_invoice_number As Int32



    '######################################################################################
    Public Function get_totals(ByVal nOrderId As Int32, ByVal cLastModifyUserName As String, ByVal nLastModifyUserId As Int32) As Boolean
        '--- Get order and all its dependets
        On Error GoTo ErrorHandler

        '--- Define local vars
        Dim bError As Boolean = False


        '--- Get the order prices
        bError = Me.get_order(nOrderId)
        Me.order_id = nOrderId

        '--- Check if user is dealer
        Dim oFunctions As New ion_resources.cls_functions_customers()
        Dim bIsDealer As Boolean
        oFunctions.connection_string = Me.connection_string
        bError = oFunctions.get_IsDealer(Me.user_id, Me.Isdealer)
        oFunctions = Nothing

        '--- Get all the items of this order
        bError = Me.get_order_items(nOrderId)

        '--- Get all the Transaction costs for this order
        Dim oTmpFunctionsPayment As New ion_resources.cls_functions_payment()
        oTmpFunctionsPayment.connection_string = Me.connection_string
        oTmpFunctionsPayment.get_total_transaction_costs(nOrderId, Me.amnt_transactions)

        '--- Get all the Interest payed for this order
        oTmpFunctionsPayment.get_total_interest_payed(nOrderId, Me.amnt_interest)
        oTmpFunctionsPayment = Nothing


        '--- Create proper collections for saveing routine
        Dim oTmpCollection As New ion_resources.cls_books_cll()
        bError = make_collection(oTmpCollection, cLastModifyUserName, nLastModifyUserId)


        '--- Create collection for updating Inventory quantities


        '--- Save ME
        Dim oTmpBroker As New ion_resources.cls_books_lgc()
		oTmpBroker.connection_string = Me.connection_string
		oTmpBroker.connection = Me.connection
		oTmpBroker.transaction = Me.transaction
        bError = oTmpBroker.insert_books(oTmpCollection)
        If bError Then
            Me.error_number = oTmpBroker.error_no
            Me.error_description = oTmpBroker.error_desc
            Me.error_source = oTmpBroker.error_source
            Return True
        End If


        Return False
        Exit Function

ErrorHandler:
        '--- register the error
        Me.error_number = Err.Number
        Me.error_description = Err.Description
        Me.error_source = Err.Source
        Return True

    End Function


    '######################################################################################
    Public Function get_order_items(ByVal nOrderId As Int32) As Boolean
        '--- will get all the items in an order
        On Error GoTo ErrorHandler

        '--- Define local vars
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
		cSQL = cSQL + " and order_items.order_id = " & nOrderId


		Dim objConn As New SqlClient.SqlConnection(Me.connection_string)
        Dim cSQLstring As SqlClient.SqlCommand = New SqlClient.SqlCommand(cSQL, objConn)
        objConn.Open()
        bConnection_open = True

        Dim dr_Reader As SqlClient.SqlDataReader = cSQLstring.ExecuteReader()
        bDatareader_open = True

        While dr_Reader.Read()
            '--- initiate Item object
			Dim oTmpItem As New cls_OrderItem



            oTmpItem.item_id = dr_Reader.Item("item_id")
            oTmpItem.item_number = dr_Reader.Item("item_no")
            oTmpItem.item_cost = dr_Reader.Item("purchase_price")
            oTmpItem.item_sell = dr_Reader.Item("sell_price")
            oTmpItem.item_sell_dealer = dr_Reader.Item("dealer_price")
            oTmpItem.item_sell_special = dr_Reader.Item("special_sell_price")
            oTmpItem.item_sell_dealer_special = dr_Reader.Item("special_dealer_price")
            oTmpItem.quantity = dr_Reader.Item("item_quantity")
            oTmpItem.branch_id = dr_Reader.Item("branchnumber")
            oTmpItem.supplier_id = dr_Reader.Item("suppliernumber")
            oTmpItem.item_special = dr_Reader.Item("onspecial")
            oTmpItem.item_special_from = dr_Reader.Item("onspecial_from_date")
            oTmpItem.item_special_to = dr_Reader.Item("onspecial_to_date")


            '--- Check if item special
            If dr_Reader.Item("onspecial") Then
                If Today.Date >= dr_Reader.Item("onspecial_from_date") And Today.Date <= dr_Reader.Item("onspecial_to_date") Then
                    oTmpItem.item_special = True
                End If
            End If

            '--- Calculate total cost
            Me.amnt_cost = Me.amnt_cost + (oTmpItem.item_cost * oTmpItem.quantity)


            Me.items.Add(oTmpItem)
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
        Me.error_number = Err.Number
        Me.error_description = Err.Description
        Me.error_source = Err.Source
        Return True



    End Function

    '######################################################################################
    Public Function get_order(ByVal nOrderId As Int32) As Boolean
        '--- will get all the amounts of an order

        On Error GoTo ErrorHandler

        '--- Define local vars
        Dim bError As Boolean = False

        '--- Define Connection String
        Dim bConnection_open As Boolean = False
        Dim bDatareader_open As Boolean = False
        Dim cSQL As String
        cSQL = "select ordernumber, invoicenumber,user_id, amnt_items, amnt_wrapping, amnt_labor, amnt_shipping, amnt_extracharges, amnt_vat, amnt_subtotal, amnt_discount, amnt_grandtotal from acc_orders where id = " & nOrderId
        Dim objConn As New SqlClient.SqlConnection(Me.connection_string)
        Dim cSQLstring As SqlClient.SqlCommand = New SqlClient.SqlCommand(cSQL, objConn)
        objConn.Open()
        bConnection_open = True

        Dim dr_Reader As SqlClient.SqlDataReader = cSQLstring.ExecuteReader()
        bDatareader_open = True

        While dr_Reader.Read()
            Me.amnt_items = dr_Reader.Item("amnt_items")
            Me.amnt_wrapping = dr_Reader.Item("amnt_wrapping")
            Me.amnt_shipping = dr_Reader.Item("amnt_shipping")
            Me.amnt_labor = dr_Reader.Item("amnt_labor")
            Me.amnt_extracharges = dr_Reader.Item("amnt_extracharges")
            Me.amnt_vat = dr_Reader.Item("amnt_vat")
            Me.amnt_subtotal = dr_Reader.Item("amnt_subtotal")
            Me.amnt_discount = dr_Reader.Item("amnt_discount")
            Me.amnt_grandtotal = dr_Reader.Item("amnt_grandtotal")
            Me.user_id = dr_Reader.Item("user_id")
            Me.order_number = dr_Reader.Item("ordernumber")
            Me.invoice_number = dr_Reader.Item("invoicenumber")
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
        Me.error_number = Err.Number
        Me.error_description = Err.Description
        Me.error_source = Err.Source
        Return True

    End Function

    Private Function make_collection(ByVal oCollection As cls_books_cll, ByVal cLastModifyUserName As String, ByVal nLastModifyUserId As Int32) As Boolean
        On Error GoTo ErrorHandler

        '--- Define local vars
        Dim bError As Boolean = False

        '--- Create GENERAL collection
        Dim nId As Int32 = 9999
        Dim nOrder_id As Int32 = Me.order_id
        Dim dTransaction_date As DateTime = Today.Now
        Dim dLastModify_date As DateTime = Today.Now
        Dim cLastModify_user As String = cLastModifyUserName
        Dim nLastModify_user_id As Int32 = nLastModifyUserId
        Dim cDescription As String = "auto: Order no: " + Me.order_number.ToString + " Invoice no: " + Me.invoice_number.ToString

        '--- Get Rate
        Dim nRateIls As Decimal
        Dim oTmpAccountingFunctions As New ion_resources.cls_functions_accounting()
        oTmpAccountingFunctions.connection_string = Me.connection_string
        bError = oTmpAccountingFunctions.get_rate(nRateIls)
        oTmpAccountingFunctions = Nothing

        '---### Purchase Cost's
        Dim oGeneral_10 As New ion_resources.cls_books_general()
        oGeneral_10.trs_id = nId
        oGeneral_10.order_id = nOrder_id
        oGeneral_10.trs_date = dTransaction_date
        oGeneral_10.lastmodify_date = dLastModify_date
        oGeneral_10.lastmodify_user = cLastModify_user
        oGeneral_10.lastmodify_user_id = nLastModify_user_id
        oGeneral_10.description = cDescription
        oGeneral_10.account_id = 10
        oGeneral_10.rate_ils = nRateIls
        oGeneral_10.amount = Me.amnt_cost
        oCollection.general.Add(oGeneral_10)
        oGeneral_10 = Nothing


        '---### Wrapping
        If Me.amnt_wrapping <> 0 Then
            Dim oGeneral_11 As New ion_resources.cls_books_general()
            oGeneral_11.trs_id = nId
            oGeneral_11.order_id = nOrder_id
            oGeneral_11.trs_date = dTransaction_date
            oGeneral_11.lastmodify_date = dLastModify_date
            oGeneral_11.lastmodify_user = cLastModify_user
            oGeneral_11.lastmodify_user_id = nLastModify_user_id
            oGeneral_11.description = cDescription
            oGeneral_11.account_id = 11
            oGeneral_11.rate_ils = nRateIls
            oGeneral_11.amount = Me.amnt_wrapping
            oCollection.general.Add(oGeneral_11)
            oGeneral_11 = Nothing
        End If

        '---### Labor
        If Me.amnt_labor <> 0 Then
            Dim oGeneral_12 As New ion_resources.cls_books_general()
            oGeneral_12.trs_id = nId
            oGeneral_12.order_id = nOrder_id
            oGeneral_12.trs_date = dTransaction_date
            oGeneral_12.lastmodify_date = dLastModify_date
            oGeneral_12.lastmodify_user = cLastModify_user
            oGeneral_12.lastmodify_user_id = nLastModify_user_id
            oGeneral_12.description = cDescription
            oGeneral_12.account_id = 12
            oGeneral_12.rate_ils = nRateIls
            oGeneral_12.amount = Me.amnt_labor
            oCollection.general.Add(oGeneral_12)
            oGeneral_12 = Nothing
        End If

        '---### Extra Chrges
        If Me.amnt_extracharges <> 0 Then
            Dim oGeneral_13 As New ion_resources.cls_books_general()
            oGeneral_13.trs_id = nId
            oGeneral_13.order_id = nOrder_id
            oGeneral_13.trs_date = dTransaction_date
            oGeneral_13.lastmodify_date = dLastModify_date
            oGeneral_13.lastmodify_user = cLastModify_user
            oGeneral_13.lastmodify_user_id = nLastModify_user_id
            oGeneral_13.description = cDescription
            oGeneral_13.account_id = 13
            oGeneral_13.rate_ils = nRateIls
            oGeneral_13.amount = Me.amnt_extracharges
            oCollection.general.Add(oGeneral_13)
            oGeneral_13 = Nothing
        End If

        '---### VAT
        If Me.amnt_vat <> 0 Then
            Dim oGeneral_14 As New ion_resources.cls_books_general()
            oGeneral_14.trs_id = nId
            oGeneral_14.order_id = nOrder_id
            oGeneral_14.trs_date = dTransaction_date
            oGeneral_14.lastmodify_date = dLastModify_date
            oGeneral_14.lastmodify_user = cLastModify_user
            oGeneral_14.lastmodify_user_id = nLastModify_user_id
            oGeneral_14.description = cDescription
            oGeneral_14.account_id = 14
            oGeneral_14.rate_ils = nRateIls
            oGeneral_14.amount = Me.amnt_vat
            oCollection.general.Add(oGeneral_14)
            oGeneral_14 = Nothing
        End If

        '---### Discount
        If Me.amnt_discount <> 0 Then
            Dim oGeneral_15 As New ion_resources.cls_books_general()
            oGeneral_15.trs_id = nId
            oGeneral_15.order_id = nOrder_id
            oGeneral_15.trs_date = dTransaction_date
            oGeneral_15.lastmodify_date = dLastModify_date
            oGeneral_15.lastmodify_user = cLastModify_user
            oGeneral_15.lastmodify_user_id = nLastModify_user_id
            oGeneral_15.description = cDescription
            oGeneral_15.account_id = 15
            oGeneral_15.rate_ils = nRateIls
            oGeneral_15.amount = Me.amnt_labor
            oCollection.general.Add(oGeneral_15)
            oGeneral_15 = Nothing
        End If

        '---### Transaction
        If Me.amnt_transactions <> 0 Then
            Dim oGeneral_16 As New ion_resources.cls_books_general()
            oGeneral_16.trs_id = nId
            oGeneral_16.order_id = nOrder_id
            oGeneral_16.trs_date = dTransaction_date
            oGeneral_16.lastmodify_date = dLastModify_date
            oGeneral_16.lastmodify_user = cLastModify_user
            oGeneral_16.lastmodify_user_id = nLastModify_user_id
            oGeneral_16.description = cDescription
            oGeneral_16.account_id = 16
            oGeneral_16.rate_ils = nRateIls
            oGeneral_16.amount = Me.amnt_transactions
            oCollection.general.Add(oGeneral_16)
            oGeneral_16 = Nothing
        End If

        '---### Actual sell amount
        Dim oGeneral_17 As New ion_resources.cls_books_general()
        oGeneral_17.trs_id = nId
        oGeneral_17.order_id = nOrder_id
        oGeneral_17.trs_date = dTransaction_date
        oGeneral_17.lastmodify_date = dLastModify_date
        oGeneral_17.lastmodify_user = cLastModify_user
        oGeneral_17.lastmodify_user_id = nLastModify_user_id
        oGeneral_17.description = cDescription
        oGeneral_17.account_id = 17
        oGeneral_17.rate_ils = nRateIls
        oGeneral_17.amount = Me.amnt_grandtotal
        oCollection.general.Add(oGeneral_17)
        oGeneral_17 = Nothing

        '---### total Interest payed
        If Me.amnt_interest <> 0 Then
            Dim oGeneral_18 As New ion_resources.cls_books_general()
            oGeneral_18.trs_id = nId
            oGeneral_18.order_id = nOrder_id
            oGeneral_18.trs_date = dTransaction_date
            oGeneral_18.lastmodify_date = dLastModify_date
            oGeneral_18.lastmodify_user = cLastModify_user
            oGeneral_18.lastmodify_user_id = nLastModify_user_id
            oGeneral_18.description = cDescription
            oGeneral_18.account_id = 18
            oGeneral_18.rate_ils = nRateIls
            oGeneral_18.amount = Me.amnt_interest
            oCollection.general.Add(oGeneral_18)
            oGeneral_18 = Nothing
        End If

        '---### total Shipping charges
        If Me.amnt_shipping <> 0 Then
            Dim oGeneral_19 As New ion_resources.cls_books_general()
            oGeneral_19.trs_id = nId
            oGeneral_19.order_id = nOrder_id
            oGeneral_19.trs_date = dTransaction_date
            oGeneral_19.lastmodify_date = dLastModify_date
            oGeneral_19.lastmodify_user = cLastModify_user
            oGeneral_19.lastmodify_user_id = nLastModify_user_id
            oGeneral_19.description = cDescription
            oGeneral_19.account_id = 19
            oGeneral_19.rate_ils = nRateIls
            oGeneral_19.amount = Me.amnt_shipping
            oCollection.general.Add(oGeneral_19)
            oGeneral_19 = Nothing
        End If


        '--- Create SUPPLIERS collection
        Dim nLoop As Int16
        For nLoop = 1 To Me.items.Count
            Dim oSuppliers As New ion_resources.cls_books_suppliers()
            oSuppliers.trs_id = nId
            oSuppliers.order_id = nOrder_id
            oSuppliers.rate_ils = nRateIls
            oSuppliers.trs_date = dTransaction_date
            oSuppliers.lastmodify_date = dLastModify_date
            oSuppliers.lastmodify_user = cLastModify_user
            oSuppliers.lastmodify_user_id = nLastModify_user_id
            oSuppliers.amount = Me.items(nLoop).item_cost
            oSuppliers.item_id = Me.items(nLoop).item_id
            oSuppliers.item_qty = Me.items(nLoop).quantity

            '--- Get id2 for supplier
            Dim oTmpFunctionsSuppliers As New ion_resources.cls_functions_suppliers()
            oTmpFunctionsSuppliers.connection_string = Me.connection_string
            bError = oTmpFunctionsSuppliers.get_supplier_id2(Me.items(nLoop).supplier_id, Me.items(nLoop).branch_id, oSuppliers.supplier_id2)

            oTmpFunctionsSuppliers = Nothing

            '--- declare price constructor - to calculate profit
            Dim oTmpPrice As New ion_resources.cls_cons_price()
            oTmpPrice.purchase_price = Me.items(nLoop).item_cost
            oTmpPrice.dealer_price = Me.items(nLoop).item_sell_dealer
            oTmpPrice.sell_price = Me.items(nLoop).item_sell
            oTmpPrice.special_sell_price = Me.items(nLoop).item_sell_special
            oTmpPrice.special_dealer_price = Me.items(nLoop).item_sell_dealer_special
            oTmpPrice.onspecial = Me.items(nLoop).item_special
            oTmpPrice.onspecial_from = Me.items(nLoop).item_special_from
            oTmpPrice.onspecial_to = Me.items(nLoop).item_special_to

            '--- Get the correct price
            bError = oTmpPrice.get_price(Me.Isdealer)
            'Dim cProfit As String = Format(Convert.ToDecimal(oTmpPrice.correct_price - Me.items(nLoop).item_cost), "##,##0.00") + " $us"
            Dim cProfit As String = Convert.ToDecimal(oTmpPrice.correct_price - Me.items(nLoop).item_cost)
            oSuppliers.description = "auto: Sale of item no: " + Me.items(nLoop).item_number + " <" + cProfit + ">"



            oCollection.suppliers.Add(oSuppliers)
            oSuppliers = Nothing
        Next

        Return False



        Exit Function

ErrorHandler:
        '--- register the error
        Me.error_number = Err.Number
        Me.error_description = Err.Description
        Me.error_source = Err.Source
        Return True

    End Function





    Public Property invoice_number() As Int32
        Get
            Return m_invoice_number
        End Get

        Set(ByVal Value As Int32)
            m_invoice_number = Value
        End Set
    End Property

    Public Property order_number() As Int32
        Get
            Return m_order_number
        End Get

        Set(ByVal Value As Int32)
            m_order_number = Value
        End Set
    End Property

    Public Property Isdealer() As Boolean
        Get
            Return m_Isdealer
        End Get

        Set(ByVal Value As Boolean)
            m_Isdealer = Value
        End Set
    End Property

    Public Property user_id() As Int32
        Get
            Return m_user_id
        End Get

        Set(ByVal Value As Int32)
            m_user_id = Value
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

    Public Property items() As Collection
        Get
            Return m_items
        End Get

        Set(ByVal Value As Collection)
            m_items = Value
        End Set
    End Property


    Public Property amnt_grandtotal() As Decimal
        Get
            Return m_amnt_grandtotal
        End Get

        Set(ByVal Value As Decimal)
            m_amnt_grandtotal = Value
        End Set
    End Property

    Public Property amnt_discount() As Decimal
        Get
            Return m_amnt_discount
        End Get

        Set(ByVal Value As Decimal)
            m_amnt_discount = Value
        End Set
    End Property

    Public Property amnt_subtotal() As Decimal
        Get
            Return m_amnt_subtotal
        End Get

        Set(ByVal Value As Decimal)
            m_amnt_subtotal = Value
        End Set
    End Property

    Public Property amnt_vat() As Decimal
        Get
            Return m_amnt_vat
        End Get

        Set(ByVal Value As Decimal)
            m_amnt_vat = Value
        End Set
    End Property

    Public Property amnt_extracharges() As Decimal
        Get
            Return m_amnt_extracharges
        End Get

        Set(ByVal Value As Decimal)
            m_amnt_extracharges = Value
        End Set
    End Property

    Public Property amnt_labor() As Decimal
        Get
            Return m_amnt_labor
        End Get

        Set(ByVal Value As Decimal)
            m_amnt_labor = Value
        End Set
    End Property

    Public Property amnt_wrapping() As Decimal
        Get
            Return m_amnt_wrapping
        End Get

        Set(ByVal Value As Decimal)
            m_amnt_wrapping = Value
        End Set
    End Property

    Public Property amnt_items() As Decimal
        Get
            Return m_amnt_items
        End Get

        Set(ByVal Value As Decimal)
            m_amnt_items = Value
        End Set
    End Property

    Public Property amnt_cost() As Decimal
        Get
            Return m_amnt_cost
        End Get

        Set(ByVal Value As Decimal)
            m_amnt_cost = Value
        End Set
    End Property

    Public Property amnt_transactions() As Decimal
        Get
            Return m_amnt_transactions
        End Get

        Set(ByVal Value As Decimal)
            m_amnt_transactions = Value
        End Set
    End Property

    Public Property amnt_interest() As Decimal
        Get
            Return m_amnt_interest
        End Get

        Set(ByVal Value As Decimal)
            m_amnt_interest = Value
        End Set
    End Property

    Public Property amnt_shipping() As Decimal
        Get
            Return m_amnt_shipping
        End Get

        Set(ByVal Value As Decimal)
            m_amnt_shipping = Value
        End Set
    End Property


    '---
    Public Property connection_string() As String
        Get
            Return m_connection_string
        End Get

        Set(ByVal Value As String)
            m_connection_string = Value
        End Set
    End Property

    Public Property error_number() As Int32
        Get
            Return m_error_number
        End Get

        Set(ByVal Value As Int32)
            m_error_number = Value
        End Set
    End Property

    Public Property error_description() As String
        Get
            Return m_error_description
        End Get

        Set(ByVal Value As String)
            m_error_description = Value
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

    Private Class cls_OrderItem
        Private m_item_number As String
        Private m_item_id As Int32
        Private m_item_cost As Decimal
        Private m_item_sell As Decimal
        Private m_item_sell_dealer As Decimal
        Private m_item_sell_special As Decimal
        Private m_item_sell_dealer_special As Decimal
        Private m_quantity As Int16
        Private m_item_special As Boolean
        Private m_item_special_from As DateTime
        Private m_item_special_to As DateTime
        Private m_supplier_id As Int32
        Private m_branch_id As Int32

        Public Property quantity() As Int16
            Get
                Return m_quantity
            End Get

            Set(ByVal Value As Int16)
                m_quantity = Value
            End Set
        End Property

        Public Property item_sell_dealer_special() As Decimal
            Get
                Return m_item_sell_dealer_special
            End Get

            Set(ByVal Value As Decimal)
                m_item_sell_dealer_special = Value
            End Set
        End Property

        Public Property item_sell_special() As Decimal
            Get
                Return m_item_sell_special
            End Get

            Set(ByVal Value As Decimal)
                m_item_sell_special = Value
            End Set
        End Property

        Public Property item_sell_dealer() As Decimal
            Get
                Return m_item_sell_dealer
            End Get

            Set(ByVal Value As Decimal)
                m_item_sell_dealer = Value
            End Set
        End Property

        Public Property item_sell() As Decimal
            Get
                Return m_item_sell
            End Get

            Set(ByVal Value As Decimal)
                m_item_sell = Value
            End Set
        End Property

        Public Property item_cost() As Decimal
            Get
                Return m_item_cost
            End Get

            Set(ByVal Value As Decimal)
                m_item_cost = Value
            End Set
        End Property

        Public Property item_id() As Int32
            Get
                Return m_item_id
            End Get

            Set(ByVal Value As Int32)
                m_item_id = Value
            End Set
        End Property

        Public Property item_number() As String
            Get
                Return m_item_number
            End Get

            Set(ByVal Value As String)
                m_item_number = Value
            End Set
        End Property

        Public Property item_special_to() As DateTime
            Get
                Return m_item_special_to
            End Get

            Set(ByVal Value As DateTime)
                m_item_special_to = Value
            End Set
        End Property

        Public Property item_special_from() As DateTime
            Get
                Return m_item_special_from
            End Get

            Set(ByVal Value As DateTime)
                m_item_special_from = Value
            End Set
        End Property

        Public Property item_special() As Boolean
            Get
                Return m_item_special
            End Get

            Set(ByVal Value As Boolean)
                m_item_special = Value
            End Set
        End Property

        Public Property supplier_id() As Int32
            Get
                Return m_supplier_id
            End Get

            Set(ByVal Value As Int32)
                m_supplier_id = Value
            End Set
        End Property

        Public Property branch_id() As Int32
            Get
                Return m_branch_id
            End Get

            Set(ByVal Value As Int32)
                m_branch_id = Value
            End Set
        End Property

    End Class
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

