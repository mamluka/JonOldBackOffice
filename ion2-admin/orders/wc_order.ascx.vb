Partial Class wc_order
    Inherits System.Web.UI.UserControl


    Public nOrderId As Int32
    Public cnt_CartContent As cart_content
    Public cnt_OrderTotals As order_totals
    Public cnt_OrderReconsile As wc_order_reconsile
    Public oCart As New ion_resources.cls_cart()

    Public oOrder As New ion_resources.cls_order


#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()

        On Error GoTo ErrorHandler
        Dim bError As Boolean = False

        Dim oFillcombo As New cls_datareader()
        Dim oError As New cls_error()
        oFillcombo.config = Application("config")
        oFillcombo.oerror = oError

        '--- fill Shipping STATE combo
        oFillcombo.combobox = Me.cmb_shp_state
        oFillcombo.sqlstring = "select id, lang" & Session("user").language & "_longdescr from sys_STATE  order by lang" & Session("user").language & "_longdescr"
        oFillcombo.showfield = "lang" & Session("user").language & "_longdescr"
        bError = oFillcombo.bind_combo()
        If bError Then
            '--- when object is called in external DLL
            Session("error").err_number = oFillcombo.oerror.err_number
            Session("error").err_source = oFillcombo.oerror.err_source
            Session("error").err_description = oFillcombo.oerror.err_description
            '--- Our custom error
            Dim oTmpDB As New System.Diagnostics.StackFrame()
            Session("error").app_module = Me.Request.CurrentExecutionFilePath
            Session("error").app_function = oTmpDB.GetMethod.Name
            Session("error").app_call = "page_init / cls_datareader"
            Server.Transfer("/apperror.aspx")
        End If

        '--- fill Shipping COUNTRY combo
        oFillcombo.combobox = Me.cmb_shp_country
        oFillcombo.sqlstring = "select id, lang" & Session("user").language & "_longdescr from sys_COUNTRY order by lang" & Session("user").language & "_longdescr"
        oFillcombo.showfield = "lang" & Session("user").language & "_longdescr"
        bError = oFillcombo.bind_combo()
        If bError Then
            '--- when object is called in external DLL
            Session("error").err_number = oFillcombo.oerror.err_number
            Session("error").err_source = oFillcombo.oerror.err_source
            Session("error").err_description = oFillcombo.oerror.err_description
            '--- Our custom error
            Dim oTmpDB As New System.Diagnostics.StackFrame()
            Session("error").app_module = Me.Request.CurrentExecutionFilePath
            Session("error").app_function = oTmpDB.GetMethod.Name
            Session("error").app_call = "page_init / cls_datareader"
            Server.Transfer("/apperror.aspx")
        End If

        '--- fill Delivery STATE combo
        oFillcombo.combobox = Me.cmb_bln_state
        oFillcombo.sqlstring = "select id, lang" & Session("user").language & "_longdescr from sys_STATE  order by lang" & Session("user").language & "_longdescr"
        oFillcombo.showfield = "lang" & Session("user").language & "_longdescr"
        bError = oFillcombo.bind_combo()
        If bError Then
            '--- when object is called in external DLL
            Session("error").err_number = oFillcombo.oerror.err_number
            Session("error").err_source = oFillcombo.oerror.err_source
            Session("error").err_description = oFillcombo.oerror.err_description
            '--- Our custom error
            Dim oTmpDB As New System.Diagnostics.StackFrame()
            Session("error").app_module = Me.Request.CurrentExecutionFilePath
            Session("error").app_function = oTmpDB.GetMethod.Name
            Session("error").app_call = "page_init / cls_datareader"
            Server.Transfer("/apperror.aspx")
        End If

        '--- fill Delivery COUNTRY combo
        oFillcombo.combobox = Me.cmb_bln_country
        oFillcombo.sqlstring = "select id, lang" & Session("user").language & "_longdescr from sys_COUNTRY order by lang" & Session("user").language & "_longdescr"
        oFillcombo.showfield = "lang" & Session("user").language & "_longdescr"
        bError = oFillcombo.bind_combo()
        If bError Then
            '--- when object is called in external DLL
            Session("error").err_number = oFillcombo.oerror.err_number
            Session("error").err_source = oFillcombo.oerror.err_source
            Session("error").err_description = oFillcombo.oerror.err_description
            '--- Our custom error
            Dim oTmpDB As New System.Diagnostics.StackFrame()
            Session("error").app_module = Me.Request.CurrentExecutionFilePath
            Session("error").app_function = oTmpDB.GetMethod.Name
            Session("error").app_call = "page_init / cls_datareader"
            Server.Transfer("/apperror.aspx")
        End If


        oFillcombo = Nothing
        oError = Nothing

        Exit Sub

ErrorHandler:
        '--- when object is called in external DLL
        Session("error").err_number = Err.Number
        Session("error").err_source = Err.Source
        Session("error").err_description = Err.Description
        '--- Custom error
        Dim oTmpErrDB As New System.Diagnostics.StackFrame()
        Session("error").app_module = Me.Request.CurrentExecutionFilePath
        Session("error").app_function = oTmpErrDB.GetMethod.Name
        Session("error").app_call = "Page_Init"
        Server.Transfer("/apperror.aspx")

    End Sub

#End Region



    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        On Error GoTo ErrorHandler
        Dim bError As Boolean = False

        '--- Set culture of form
        System.Threading.Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.CreateSpecificCulture(Request.UserLanguages(0))
        System.Threading.Thread.CurrentThread.CurrentUICulture = New System.Globalization.CultureInfo(Request.UserLanguages(0))

        '--- Get/Set Parameters
        nOrderId = Request.QueryString("id")

        '--- declare containers
        cnt_CartContent = Me.FindControl("wc_cart_content1")

        cnt_OrderTotals = Me.FindControl("wc_Order_totals1")
        cnt_OrderReconsile = Me.FindControl("wc_Order_reconsile1")


        'TODO: Fix reconsile in checkout
        '--- Disable reconsile temprarly
        cnt_OrderReconsile.Visible = False



        '--- Load stuff
        If Not Page.IsPostBack Then
            '--- Set default amount for registered mail
            cnt_OrderTotals.hid_shipping.Text = Application("defaults").order_registered

            '--- Load cart first time
            bError = Me.Load_Order(nOrderId)


            '--- Assign cart to session
            Session("oTmpCart") = Nothing
            Session("oTmpOrder") = Nothing

            Session("oTmpCart") = oCart
            Session("oTmpOrder") = oOrder

            '--- Show the CLUB label
            If oOrder.cluborder Then
                Me.lbl_cluborder.Visible = True
            Else
                Me.lbl_cluborder.Visible = False
            End If


        Else
            '--- Get cart from session
            oCart = Session("oTmpCart")
            oOrder = Session("oTmpOrder")

        End If

        '--- Assign Cart to show contents
        cnt_CartContent.orderItems = oOrder.order_items

        Dim ocurrency As New ion_two.cls_currency
        Dim currency_symbol As String = ocurrency.GetSymbolByCode(Me.oOrder.order_currency)

        cnt_CartContent.Currency_Symbol = currency_symbol
        cnt_CartContent.currency_rate = Me.oOrder.order_currency_rate

        cnt_OrderReconsile.oCart = oCart

        recalc_shipping_packaging()

        cnt_OrderTotals.hid_shipping.Text = rdo_shipping.SelectedItem.Value
        cnt_OrderTotals.hid_wrapping.Text = "0" ''rdo_wrapping.SelectedItem.Value

        ''  Dim tasklist As tasklist = Me.FindControl("Tasklist1")
        ''  tasklist.oOrder = oOrder


        '--- Change name of form
        Me.lbl_header.Text = "Editing order number: " + System.Convert.ToString(oOrder.ordernumber)

        If Not Page.IsPostBack Then
            '--- fill combo with items to delete
            bError = recalc_cmb_todelete()

        End If

        recalc_shipping_packaging()


        '--- If flags are on then disable screen
        If oOrder.cannot_be_edited Then
            bError = DisableOrder(False)
        End If

        If oOrder.order_transacted Then
            bError = DisableOrder(False)
        End If



        Exit Sub

ErrorHandler:
        '--- when object is called in external DLL
        Session("error").err_number = Err.Number
        Session("error").err_source = Err.Source
        Session("error").err_description = Err.Description
        '--- Custom error
        Dim oTmpErrDB As New System.Diagnostics.StackFrame
        Session("error").app_module = Me.Request.CurrentExecutionFilePath
        Session("error").app_function = oTmpErrDB.GetMethod.Name
        Session("error").app_call = "Page_Load"
        Server.Transfer("/apperror.aspx")

    End Sub

    '#####################################################################################
    Public Sub recalc_shipping_packaging()
        'On Error GoTo ErrorHandler

        '--- Define local vars
        Dim bError As Boolean = False

        '--- get shipping amounts
        Dim nCourier_amnt As Decimal
        Dim nCourier_days As Int16
        Dim nEms_amnt As Decimal
        Dim nEms_days As Int16
        Dim nFedex_amnt As Decimal
        Dim nFedex_days As Int16
        Dim nVat_amnt As Decimal

        Dim nCountryId = System.Convert.ToInt16(cmb_shp_country.SelectedItem.Value)
        Dim nStateId = System.Convert.ToInt16(cmb_shp_state.SelectedItem.Value)

        Dim oFunctions As New ion_resources.cls_functions_order()
        oFunctions.connection_string = Application("config").connection_string

        bError = oFunctions.get_shipping(nCountryId, nStateId, nVat_amnt, nCourier_amnt, nCourier_days, nEms_amnt, nEms_days, nFedex_amnt, nFedex_days)
        If bError Then
            '--- when object is called in external DLL
            Session("error").err_number = oFunctions.error_number
            Session("error").err_source = oFunctions.error_source
            Session("error").err_description = oFunctions.error_description
            '--- Custom error
            Dim oTmpErrDB1 As New System.Diagnostics.StackFrame()
            Session("error").app_module = Me.Request.CurrentExecutionFilePath
            Session("error").app_function = oTmpErrDB1.GetMethod.Name
            Session("error").app_call = "checkout / cls_functions_order"
            Server.Transfer("/apperror.aspx")
        End If

        Dim nPackaging As Decimal = Application("defaults").order_packaging
        Dim nRegistered As Decimal = Application("defaults").order_registered

        '--- Calculate FedEx Percentage
        If Application("defaults").order_fedexInsurance > 0 Then
            Dim nTmpFedExamnt As Decimal = System.Convert.ToDecimal(cnt_OrderTotals.hid_total_cart.Text)
            nFedex_amnt = nFedex_amnt + (nTmpFedExamnt / 100) * Application("defaults").order_fedexInsurance
        End If

        '--- Wrapping Radio
        rdo_wrapping.Items(0).Text = "Regular pakaging - <b>0.00 $us</b>"
        rdo_wrapping.Items(0).Value = 0.0

        rdo_wrapping.Items(1).Text = "Fancy pakaging   - <b>" + Format(0, "##,##0.00") + " $us </b>"
        rdo_wrapping.Items(1).Value = nPackaging


        Dim shipping_regular As Decimal = 0
        Dim shipping_fedex As Decimal = 49 * Me.oOrder.order_currency_rate
        Dim shipping_currier As Decimal = 179 * Me.oOrder.order_currency_rate
        Dim shipping_ems As Decimal = 39 * Me.oOrder.order_currency_rate

        ''tree of shipping by policy

        Dim total_order_amnt As Decimal = Convert.ToDecimal(cnt_OrderTotals.hid_total_cart.Text)

        If total_order_amnt > 10000 Then
            shipping_regular = 0
            shipping_fedex = 0
            shipping_currier = 0
            shipping_ems = 0
        ElseIf total_order_amnt > 3000 Then
            shipping_fedex = 0
            shipping_ems = 0
        ElseIf total_order_amnt > 1000 Then
            shipping_regular = 0
            shipping_ems = 0

        End If

        nRegistered = shipping_regular
        nCourier_amnt = shipping_currier
        nEms_amnt = shipping_ems

        Dim ocurrency As New ion_two.cls_currency
        Dim currency_symbol As String = ocurrency.GetSymbolByCode(Me.oOrder.order_currency)

        '--- Shipping Radio

        Me.rdo_shipping.Items(0).Text = "Registered mail - <b>" + Format(nRegistered, "##,##0 " + currency_symbol) + "</b>"
        Me.rdo_shipping.Items(0).Value = nRegistered



        Me.rdo_shipping.Items(1).Text = "EMS - <b>" + Format(nEms_amnt, "##,##0 " + currency_symbol) + "</b> (aprx." + System.Convert.ToString(nEms_days) + " days)"
        Me.rdo_shipping.Items(1).Value = nEms_amnt

        'Me.rdo_shipping.Items(2).Text = "FedEx - <b>" + Format(oShipping._total_fedex_amnt, "##,##0.00") + " $us </b> (aprx." + System.Convert.ToString(oShipping._total_fedex_days) + " days)"
        'Me.rdo_shipping.Items(2).Value = oShipping._total_fedex_amnt

        Me.rdo_shipping.Items(2).Text = "Diamond Courier - <b>" + Format(nCourier_amnt, "##,##0 " + currency_symbol) + "</b> (aprx." + System.Convert.ToString(nCourier_days) + " days)"
        Me.rdo_shipping.Items(2).Value = nCourier_amnt

        Me.rdo_shipping.Items(3).Text = "FedEx - <b>" + Format(shipping_fedex, "##,##0 " + currency_symbol) + "</b> (aprx." + System.Convert.ToString(4) + " days)"
        Me.rdo_shipping.Items(3).Value = shipping_fedex


        '--- Vat
        cnt_OrderTotals.hid_vatperc.Text = nVat_amnt

        oFunctions = Nothing
        Exit Sub

ErrorHandler:
        '--- when object is called in external DLL
        Session("error").err_number = Err.Number
        Session("error").err_source = Err.Source
        Session("error").err_description = Err.Description
        '--- Custom error
        Dim oTmpErrDB As New System.Diagnostics.StackFrame
        Session("error").app_module = Me.Request.CurrentExecutionFilePath
        Session("error").app_function = oTmpErrDB.GetMethod.Name
        Session("error").app_call = "checkout / recalc_shipping"
        Server.Transfer("/apperror.aspx")
    End Sub


    '#####################################################################################
    Public Sub recalc_order()
        'On Error GoTo ErrorHandler

        '--- Define local vars
        Dim bError As Boolean = False



        '--- Recalculate all
        cnt_OrderTotals.refresh_totals()



        Exit Sub

ErrorHandler:
        '--- when object is called in external DLL
        Session("error").err_number = Err.Number
        Session("error").err_source = Err.Source
        Session("error").err_description = Err.Description
        '--- Custom error
        Dim oTmpErrDB As New System.Diagnostics.StackFrame()
        Session("error").app_module = Me.Request.CurrentExecutionFilePath
        Session("error").app_function = oTmpErrDB.GetMethod.Name
        Session("error").app_call = "checkout / recalc_shipping"
        Server.Transfer("/apperror.aspx")
    End Sub


    '#####################################################################################
    Public Function Load_Order(ByVal nOrderId As Int16) As Boolean
        On Error GoTo ErrorHandler
        Dim bError As Boolean = False


        Dim oTmpOrder As New ion_resources.cls_order_lgc
        oTmpOrder.connection_string = Application("config").connection_string
        bError = oTmpOrder.get_order_by_id(nOrderId, oOrder)
        If bError Then
            '--- when object is called in external DLL
            Session("error").err_number = oTmpOrder.error_no
            Session("error").err_source = oTmpOrder.error_source
            Session("error").err_description = oTmpOrder.error_desc
            '--- Custom error
            Dim oTmpErrDB2 As New System.Diagnostics.StackFrame
            Session("error").app_module = Me.Request.CurrentExecutionFilePath
            Session("error").app_function = oTmpErrDB2.GetMethod.Name
            Session("error").app_call = "Load Order"
            Server.Transfer("/apperror.aspx")
        End If

        rdo_wrapping.SelectedIndex = oOrder.packaging_id
        If oOrder.shipping_id = 0 Then oOrder.shipping_id = 1
        rdo_shipping.SelectedIndex = rdo_shipping.Items.IndexOf(rdo_shipping.Items.FindByValue(oOrder.shipping_id.ToString))

        '--- Total amounts
        cnt_OrderTotals.hid_total_cart.Text = oOrder.amnt_items
        cnt_OrderTotals.hid_wrapping.Text = "0" ''oOrder.amnt_wrapping
        cnt_OrderTotals.hid_shipping.Text = oOrder.amnt_shipping
        cnt_OrderTotals.txt_labor.Text = oOrder.amnt_labor
        cnt_OrderTotals.txt_extra_charges.Text = oOrder.amnt_extracharges
        cnt_OrderTotals.txt_discount.Text = oOrder.amnt_discount
        cnt_OrderTotals.hid_vat.Text = oOrder.amnt_vat
        cnt_OrderTotals.hid_vatperc.Text = oOrder.amnt_vatperc
        cnt_OrderTotals.hid_subtotal.Text = oOrder.amnt_subtotal
        cnt_OrderTotals.hid_grandtotal.Text = oOrder.amnt_grandtotal
        cnt_OrderTotals.hid_currency_code.Text = oOrder.order_currency

        Me.chk_cannot_be_changed.Checked = oOrder.cannot_be_edited

        txt_interest_percent.Text = oOrder.interest_percentage
        txt_interest_start_date.Text = oOrder.interest_start_date

        '--- Addresses
        txt_bln_name.Text = oOrder.adrs_billing_name
        txt_bln_street.Text = oOrder.adrs_billing_street
        txt_bln_city.Text = oOrder.adrs_billing_city
        txt_bln_zip.Text = oOrder.adrs_billing_zip
        cmb_bln_state.SelectedIndex = GetComboValue(Me.cmb_bln_state, oOrder.adrs_billing_state_id)
        ''   cmb_bln_state.SelectedIndex = 5 ''oOrder.adrs_billing_state_id
        cmb_bln_country.SelectedIndex = GetComboValue(Me.cmb_bln_country, oOrder.adrs_billing_country_id)
        txt_bln_phone.Text = oOrder.adrs_billing_phone

        txt_shp_name.Text = oOrder.adrs_shipping_name
        txt_shp_street.Text = oOrder.adrs_shipping_street
        txt_shp_city.Text = oOrder.adrs_shipping_city
        txt_shp_zip.Text = oOrder.adrs_shipping_zip



        ''  If oOrder.adrs_shipping_state_id = 1 Then
        ''  cmb_shp_state.SelectedIndex = GetComboValue(Me.cmb_shp_state, oOrder.adrs_billing_state_id)
        ''  Else
        cmb_shp_state.SelectedIndex = GetComboValue(Me.cmb_shp_state, oOrder.adrs_shipping_state_id)
        '' End If

        cmb_shp_country.SelectedIndex = GetComboValue(Me.cmb_shp_country, oOrder.adrs_shipping_country_id)
        txt_shp_phone.Text = oOrder.adrs_shipping_phone
        txt_customer_notes.Text = oOrder.customer_notes
        txt_merchant_notes.Text = oOrder.merchant_notes

        '--- Load user info IP/referrer
        Me.txt_user_ip.Text = oOrder.remote_ip
        Me.txt_user_referrer.Text = oOrder.referrer
        Me.txt_lastuser_id.Text = oOrder.LastModify_User_id
        Me.txt_lastuser_name.Text = oOrder.LastModify_User
        Me.txt_lastuser_date.Text = oOrder.LastModify_Date

        If Me.txt_user_referrer.Text = "EBAY" Then
            Me.chk_ebay.Checked = True
        End If

        Me.txt_heartwin.Text = oOrder.hear_fromus
        Me.chk_include_receipt.Checked = oOrder.include_receipt

        '--- Get Dealer status for client
        Dim oFunctions As New ion_resources.cls_functions_customers
        Dim bIsDealer As Boolean
        oFunctions.connection_string = Application("config").connection_string
        bError = oFunctions.get_IsDealer(oOrder.user_id, bIsDealer)
        If bError Then
            '--- when object is called in external DLL
            Session("error").err_number = oFunctions.error_number
            Session("error").err_source = oFunctions.error_source
            Session("error").err_description = oFunctions.error_description
            '--- Custom error
            Dim oTmpErrDB2 As New System.Diagnostics.StackFrame
            Session("error").app_module = Me.Request.CurrentExecutionFilePath
            Session("error").app_function = oTmpErrDB2.GetMethod.Name
            Session("error").app_call = "Load Order"
            Server.Transfer("/apperror.aspx")
        End If

        '--- Parametize the cart
        oCart._backoffice = True
        oCart.dealer = bIsDealer
        oCart.connection_string = Application("config").connection_string
        oCart.categories = Application("defaults").ctg_categories
        '--- fill items in cart
        Dim nLoop As Int32
        For nLoop = 1 To oOrder.order_items.Count
            oCart.ItemAdd(oOrder.order_items.Item(nLoop).item_id, oOrder.order_items.Item(nLoop).item_quantity, oOrder.order_items.Item(nLoop).jewelsize, oOrder.order_items.Item(nLoop).extrainfo)
        Next

        '--- Disable
        If oOrder.order_transacted Then
            Me.DisableOrder(True)
        End If

        oFunctions = Nothing

        Return False
        Exit Function

ErrorHandler:
        '--- when object is called in external DLL
        Session("error").err_number = Err.Number
        Session("error").err_source = Err.Source
        Session("error").err_description = Err.Description
        '--- Custom error
        Dim oTmpErrDB As New System.Diagnostics.StackFrame
        Session("error").app_module = Me.Request.CurrentExecutionFilePath
        Session("error").app_function = oTmpErrDB.GetMethod.Name
        Session("error").app_call = "Page_Load"
        Server.Transfer("/apperror.aspx")

    End Function


    '#####################################################################################
    Private Sub cmb_bln_state_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmb_bln_state.SelectedIndexChanged
        If cmb_bln_state.SelectedIndex > 0 Then
            cmb_bln_country.SelectedIndex = GetComboValue(cmb_bln_country, "219")
        ElseIf cmb_bln_state.SelectedIndex = 0 Then
            cmb_bln_country.SelectedIndex = 0
        End If

        cmb_shp_state.SelectedIndex = cmb_bln_state.SelectedIndex
        cmb_shp_country.SelectedIndex = cmb_bln_country.SelectedIndex

        recalc_shipping_packaging()
    End Sub


    '#####################################################################################
    Private Sub cmb_bln_country_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmb_bln_country.SelectedIndexChanged
        If cmb_bln_country.SelectedItem.Value <> 219 Then
            cmb_bln_state.SelectedIndex = 0
        End If

        cmb_shp_country.SelectedIndex = cmb_bln_country.SelectedIndex

        recalc_shipping_packaging()
    End Sub


    '#####################################################################################
    Private Sub cmb_shp_state_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmb_shp_state.SelectedIndexChanged
        If cmb_shp_state.SelectedIndex > 0 Then
            cmb_shp_country.SelectedIndex = GetComboValue(cmb_shp_country, "219")
        ElseIf cmb_shp_state.SelectedIndex = 0 Then
            cmb_shp_country.SelectedIndex = 0
        End If

        recalc_shipping_packaging()
    End Sub


    '#####################################################################################
    Private Sub cmb_shp_country_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmb_shp_country.SelectedIndexChanged
        If cmb_shp_country.SelectedItem.Value <> 219 Then
            cmb_shp_state.SelectedIndex = 0

        End If

        recalc_shipping_packaging()
    End Sub


    '#####################################################################################
    Private Function validateOrder(ByRef bOKtoSave As Boolean) As Boolean

        If cnt_OrderTotals.hid_total_cart.Text = 0 Then
            Me.lst_error.Items.Add("- Total in cart cannot be 0.00")
            bOKtoSave = False
        End If


        '--- Fix input
        If Not IsNumeric(Me.txt_interest_percent.Text) Or Me.txt_interest_percent.Text = "0" Then
            Me.txt_interest_percent.Text = 0
        End If

        If Not IsDate(Me.txt_interest_start_date.Text) Then
            Me.txt_interest_start_date.Text = #1/1/1900#
        End If



    End Function


    '#####################################################################################
    Private Sub btn_save_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_save.Click
        'On Error GoTo ErrorHandler
        Dim bError As Boolean = False

        Me.btn_save.Enabled = False

        '--- Validate Order info
        Dim bOKtoSave As Boolean = True
        bError = validateOrder(bOKtoSave)
        If Not bOKtoSave Then
            lst_error.Visible = True

        Else
            '--- Save Cart
            oCart = Session("oTmpCart")

            oOrder.packaging_id = rdo_wrapping.SelectedIndex
            oOrder.shipping_id = rdo_shipping.SelectedIndex
            oOrder.cannot_be_edited = Me.chk_cannot_be_changed.Checked
            oOrder.cluborder = oCart.clubbasket

            '--- Total amounts
            oOrder.amnt_extracharges = cnt_OrderTotals.txt_extra_charges.Text
            oOrder.amnt_grandtotal = cnt_OrderTotals.hid_grandtotal.Text
            oOrder.amnt_items = cnt_OrderTotals.hid_total_cart.Text
            oOrder.amnt_labor = cnt_OrderTotals.txt_labor.Text
            oOrder.amnt_shipping = cnt_OrderTotals.hid_shipping.Text
            oOrder.amnt_subtotal = cnt_OrderTotals.hid_subtotal.Text
            oOrder.amnt_discount = cnt_OrderTotals.txt_discount.Text
            oOrder.amnt_vat = cnt_OrderTotals.hid_vat.Text.Trim
            oOrder.amnt_vatperc = cnt_OrderTotals.hid_vatperc.Text
            oOrder.amnt_wrapping = cnt_OrderTotals.hid_wrapping.Text
            'oOrder.amnt_initial_payment = cnt_OrderTotals.txt_initial_payment.Text

            '--- Addresses
            oOrder.adrs_billing_name = txt_bln_name.Text.Trim
            oOrder.adrs_billing_street = txt_bln_street.Text.Trim
            oOrder.adrs_billing_city = txt_bln_city.Text.Trim
            oOrder.adrs_billing_zip = txt_bln_zip.Text.Trim
            oOrder.adrs_billing_state_id = cmb_bln_state.SelectedItem.Value
            oOrder.adrs_billing_country_id = cmb_bln_country.SelectedItem.Value
            oOrder.adrs_billing_phone = txt_bln_phone.Text.Trim

            oOrder.adrs_shipping_name = txt_shp_name.Text.Trim
            oOrder.adrs_shipping_street = txt_shp_street.Text.Trim
            oOrder.adrs_shipping_city = txt_shp_city.Text.Trim
            oOrder.adrs_shipping_zip = txt_shp_zip.Text.Trim
            oOrder.adrs_shipping_state_id = cmb_shp_state.SelectedItem.Value
            oOrder.adrs_shipping_country_id = cmb_shp_country.SelectedItem.Value
            oOrder.adrs_shipping_phone = txt_shp_phone.Text.Trim
            oOrder.customer_notes = txt_customer_notes.Text.Trim
            oOrder.merchant_notes = txt_merchant_notes.Text

            oOrder.interest_percentage = txt_interest_percent.Text
            oOrder.interest_start_date = System.Convert.ToDateTime(txt_interest_start_date.Text).Date

            oOrder.LastModify_Date = System.Convert.ToDateTime(Now)
            oOrder.LastModify_User = System.Convert.ToString(Session("user").user_name)
            oOrder.LastModify_User_id = System.Convert.ToInt32(Session("user").user_id)

            '--- Load Cart into cls
            Dim nLoop As Integer

            '--- Clear the collection
            For nLoop = 1 To oOrder.order_items.Count
                oOrder.order_items.Remove(1)
            Next

            Dim oTmpCart As ion_resources.cls_cart = oCart
            For nLoop = 1 To oTmpCart.shopitem.Count
                Dim oTmpItems As New ion_resources.cls_order_items
                oTmpItems.item_id = oTmpCart.shopitem.Item(nLoop).id
                oTmpItems.item_no = oTmpCart.shopitem.Item(nLoop).ItemNumber
                oTmpItems.jewelsize = oTmpCart.shopitem.Item(nLoop).jewelsize
                oTmpItems.item_quantity = oTmpCart.shopitem.Item(nLoop).quantity
                oOrder.order_items.Add(oTmpItems)
                oTmpItems = Nothing
            Next

            '--- Save Order
            Dim oTmpOrder As New ion_resources.cls_order_lgc
            oTmpOrder.connection_string = Application("config").connection_string

            bError = oTmpOrder.update_order_new(oOrder, False)
            If bError Then
                '--- when object is called in external DLL
                Session("error").err_number = oTmpOrder.error_no
                Session("error").err_source = oTmpOrder.error_source
                Session("error").err_description = oTmpOrder.error_desc
                '--- Custom error
                Dim oTmpErrDB2 As New System.Diagnostics.StackFrame
                Session("error").app_module = Me.Request.CurrentExecutionFilePath
                Session("error").app_function = oTmpErrDB2.GetMethod.Name
                Session("error").app_call = "btn_save_click"
                Server.Transfer("/apperror.aspx")
            End If

            '--- Release all
            Session("oTmpCart") = Nothing
            Session("oTmpOrder") = Nothing

            '--- Give save message
            Session("message").listbox.items.add("Your order (" + System.Convert.ToString(oOrder.ordernumber) + ") has been updated!")
            Session("message").returnpath = "/orders/list-orders.aspx"
            Server.Transfer("/message.aspx")

            '--- Release further
            oTmpCart = Nothing
            oTmpOrder = Nothing

        End If

        Exit Sub

ErrorHandler:
        '--- when object is called in external DLL
        Session("error").err_number = Err.Number
        Session("error").err_source = Err.Source
        Session("error").err_description = Err.Description
        '--- Custom error
        Dim oTmpErrDB As New System.Diagnostics.StackFrame
        Session("error").app_module = Me.Request.CurrentExecutionFilePath
        Session("error").app_function = oTmpErrDB.GetMethod.Name
        Session("error").app_call = "btn_save"
        Server.Transfer("/apperror.aspx")


    End Sub

    Private Sub rdo_shipping_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdo_shipping.SelectedIndexChanged

        'If rdo_shipping.SelectedItem.Value = 0 Then
        'cnt_OrderTotals.chk_cannot_be_edited.Checked = True
        'End If


    End Sub

    Private Sub btn_item_to_delete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_item_to_delete.Click
        Dim bError As Boolean = False

        '--- Remove Item
        Dim bRemoved As Boolean = False
        Dim nItemId As Int32 = cmb_item_to_delete.SelectedItem.Value()
        bError = oCart.ItemRemove(nItemId, bRemoved)

        '--- Recalculate combo for to_delete_items
        bError = recalc_cmb_todelete()

        Session("oTmpCart") = oCart

        recalc_shipping_packaging()

    End Sub

    Private Sub btn_add_item_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_add_item.Click
        Dim bError As Boolean = False

        '--- Add item
        Dim oTmpFunction As New ion_resources.cls_itemnumber
        oTmpFunction.connection_string = Application("config").connection_string
        bError = oTmpFunction.GetItemIdFromNumber(txt_add_item.Text.Trim)
        If oTmpFunction.id > 0 Then
            bError = oCart.ItemAdd(oTmpFunction.id, Me.cmb_qty.SelectedValue, Me.cmb_size.SelectedValue)
        End If

        '--- Clear textbox
        txt_add_item.Text = ""

        '--- Recalculate combo for to_delete_items
        bError = recalc_cmb_todelete()

        oTmpFunction = Nothing

    End Sub

    Private Function recalc_cmb_todelete() As Boolean

        Dim nLoop As Int16
        cmb_item_to_delete.Items.Clear()
        For nLoop = 1 To oCart.shopitem.Count
            cmb_item_to_delete.Items.Add(oCart.shopitem.Item(nLoop).itemnumber)
            cmb_item_to_delete.Items(nLoop - 1).Value = oCart.shopitem.Item(nLoop).id
        Next

        '--- disable the remove_item option if only one item
        If oCart.shopitem.Count = 1 Then
            Me.cmb_item_to_delete.Enabled = False
            Me.btn_item_to_delete.Enabled = False
        Else
            Me.cmb_item_to_delete.Enabled = True
            Me.btn_item_to_delete.Enabled = True
        End If

    End Function


    '#####################################################################################
    Private Function DisableOrder(ByVal bEnable As Boolean) As Boolean
        lst_error.Enabled = bEnable
        txt_bln_name.Enabled = bEnable
        txt_bln_street.Enabled = bEnable
        txt_bln_city.Enabled = bEnable
        txt_bln_zip.Enabled = bEnable
        cmb_bln_state.Enabled = bEnable
        txt_bln_phone.Enabled = bEnable
        cmb_bln_country.Enabled = bEnable
        txt_shp_name.Enabled = bEnable
        txt_shp_street.Enabled = bEnable
        txt_shp_city.Enabled = bEnable
        txt_shp_zip.Enabled = bEnable
        cmb_shp_state.Enabled = bEnable
        txt_shp_phone.Enabled = bEnable
        cmb_shp_country.Enabled = bEnable
        rdo_shipping.Enabled = bEnable
        rdo_wrapping.Enabled = bEnable
        'btn_save.Enabled = bEnable
        txt_customer_notes.Enabled = bEnable
        txt_merchant_notes.Enabled = bEnable
        cmb_item_to_delete.Enabled = bEnable
        btn_item_to_delete.Enabled = bEnable
        txt_add_item.Enabled = bEnable
        btn_add_item.Enabled = bEnable
        txt_interest_start_date.Enabled = bEnable
        txt_interest_percent.Enabled = bEnable
        txt_lastuser_date.Enabled = bEnable
        txt_lastuser_name.Enabled = bEnable
        txt_lastuser_id.Enabled = bEnable
        txt_user_ip.Enabled = bEnable
        txt_user_referrer.Enabled = bEnable
        cnt_OrderTotals.btn_getcart.Enabled = bEnable
        cnt_OrderTotals.txt_labor.Enabled = bEnable
        cnt_OrderTotals.txt_discount.Enabled = bEnable
        cnt_OrderTotals.txt_extra_charges.Enabled = bEnable
        Me.cmb_size.Enabled = bEnable
        Me.cmb_qty.Enabled = bEnable
        Me.btn_save.Enabled = bEnable
        Me.chk_cannot_be_changed.Enabled = bEnable

    End Function


    Private Sub Page_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.PreRender
        Dim bError As Boolean = False
        bError = recalc_cmb_todelete()
    End Sub

    Private Sub chk_cannot_be_changed_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chk_cannot_be_changed.CheckedChanged
        Dim bError As Boolean = False

        If Me.chk_cannot_be_changed.Checked Then
            bError = Me.DisableOrder(False)
        Else
            bError = Me.DisableOrder(True)
        End If


    End Sub

    Private Sub txt_customer_notes_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_customer_notes.TextChanged

    End Sub
End Class
