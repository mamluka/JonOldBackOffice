Partial Class addorder
    Inherits System.Web.UI.Page
    '' Public ocart As ion_two.cls_advanced_cart

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents txt_merchant_notes As System.Web.UI.WebControls.TextBox
    Protected WithEvents Label4 As System.Web.UI.WebControls.Label
    Protected WithEvents Button2 As System.Web.UI.WebControls.Button
    'NOTE: The following placeholder declaration is required by the Web Form Designer.
    'Do not delete or move it.
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()

        Me.LoadCombo()
    End Sub

#End Region

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Put user code to initialize the page here
        ''If Page.IsPostBack Then
        '' ocart = Session("oTmpCart2")
        ''  End If
    End Sub

    Private Sub btn_start_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_start.Click

        Me.orderform.Visible = True
        ''  Application("config").connection_string()
        '' Application("config").connection_string_type()

        Dim oTmpInventory As New ion_two.cls_inventory_lgc
        oTmpInventory._connection_string = Application("config").connection_string
        oTmpInventory._dbtype = Application("config").connection_string_type

        Dim opicture As New ion_two.cls_pictures
        opicture.load("http://www.twin-diamonds.com", "https://www.twin-diamonds.com")

        Dim oPlate As New ion_two.skl_lst_inventory
        ''
        '' Dim id As Int32 = Convert.ToInt32(Me.t_itemid.Text)

        Dim oitemnumber As New ion_two.cls_itemnumber
        oitemnumber._connection_string = Application("config").connection_string
        oitemnumber._dbtype = Application("config").connection_string_type

        Dim itemnumber As String = Me.t_itemid.Text
        Dim id As Int32
        Dim error1 As Int32
        oitemnumber.UnicodeItemNumber(itemnumber)
        oitemnumber.getid_fromnumber(itemnumber, id, error1)


        oTmpInventory.load(id, oPlate, opicture)

        ''  Me.img_icon.ImageUrl = oPlate._icon_pic

        '' Me.hyp_item.NavigateUrl = "http://www.twin-diamonds.com/catalog/myitemv3.aspx?id=" + oPlate._id.ToString

        Dim ocart As New ion_two.cls_advanced_cart
        ocart._connection_string = Application("config").connection_string
        ocart._dbtype = Application("config").connection_string_type
        ocart.pictures = opicture
        Dim omodinfo As New ion_two.cls_mod_generic
        omodinfo.price = Me.t_price.Text

        ocart.add_mod_item(oPlate._id, 9, omodinfo)
        ocart.recalc()
        Session("oTmpCart2") = ocart


        Exit Sub
    End Sub
    Function LoadCombo() As Boolean


        On Error GoTo ErrorHandler
        Dim bError As Boolean = False

        Dim oFillcombo As New cls_datareader
        Dim oError As New cls_error
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
            Dim oTmpDB As New System.Diagnostics.StackFrame
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
            Dim oTmpDB As New System.Diagnostics.StackFrame
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
            Dim oTmpDB As New System.Diagnostics.StackFrame
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
            Dim oTmpDB As New System.Diagnostics.StackFrame
            Session("error").app_module = Me.Request.CurrentExecutionFilePath
            Session("error").app_function = oTmpDB.GetMethod.Name
            Session("error").app_call = "page_init / cls_datareader"
            Server.Transfer("/apperror.aspx")
        End If

        ''--- fill CC combo
        'oFillcombo.combobox = Me.cc_type
        'oFillcombo.sqlstring = "select id, lang" & Session("user")._language & "_longdescr from acc_CREDITCARD where active=1 order by lang" & Session("user")._language & "_longdescr"
        ''' oFillcombo.textfield = "lang" & Session("user")._language & "_longdescr"
        'oFillcombo.valuefield = "id"
        '''   oFillcombo.addrow = ""
        'bError = oFillcombo.bind_combo

        oFillcombo.combobox = Me.cc_type
        oFillcombo.sqlstring = "select id, lang" & Session("user").language & "_longdescr from acc_CREDITCARD order by lang" & Session("user").language & "_longdescr"
        oFillcombo.showfield = "lang" & Session("user").language & "_longdescr"
        bError = oFillcombo.bind_combo()
        If bError Then
            '--- when object is called in external DLL
            Session("error").err_number = oFillcombo.oerror.err_number
            Session("error").err_source = oFillcombo.oerror.err_source
            Session("error").err_description = oFillcombo.oerror.err_description
            '--- Our custom error
            Dim oTmpDB As New System.Diagnostics.StackFrame
            Session("error").app_module = Me.Request.CurrentExecutionFilePath
            Session("error").app_function = oTmpDB.GetMethod.Name
            Session("error").app_call = "page_init / cls_datareader"
            Server.Transfer("/apperror.aspx")
        End If




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
        Session("error").app_call = "Page_Init"
        Server.Transfer("/apperror.aspx")

    End Function

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim ocart As ion_two.cls_advanced_cart = Session("oTmpCart2")

        '' On Error GoTo ErrorHandler
        Dim bError As Boolean = False

        '        If Me.pay_mathod.SelectedIndex = 3 Then

        '            Dim postString As String
        '            Dim postReq As HttpWebRequest = WebRequest.Create("https://www.paypal.com/row/cgi-bin/webscr")
        '            postReq.Method = "POST"
        '            postReq.AllowAutoRedirect = False
        '            postReq.ContentType = "application/x-www-form-encoded"


        '            Dim bytedata() As Byte = Encoding.UTF8.GetBytes(postString)

        '            postReq.ContentLength = bytedata.Length
        '            Dim requestStream As Stream = postReq.GetRequestStream()
        '            requestStream.Write(bytedata, 0, bytedata.Length);
        'requestStream.Close();






        '        End If
        ''   Exit Sub
        Dim username_formail, pass_formail, user_Real_name As String


        Dim oShipping As New ion_two.cls_shipping
        oShipping._connection_string = Application("config").connection_string
        oShipping._dbtype = Application("config").connection_string_type
        bError = oShipping.get_shipping(Me.cmb_shp_country.SelectedValue, Me.cmb_shp_state.SelectedValue)
        If bError Then
            Session("error")._Err_Number = oShipping._err_number
            Session("error")._Err_Description = oShipping._err_description
            Session("error")._Err_Source = oShipping._err_source
            Session("error")._Err_Module = Me.Request.CurrentExecutionFilePath
            Session("error")._Err_Call = "Page_Load [ion_two.cls_shipping:get_shipping]"
            '' ''        Response.Redirect(Session("user")._domain + "/aspxerror.aspx")
        End If


        '' ''Session("message")._listbox.items.add("1")
        Dim userid As Int32 = 0

        ''    If Me.chk_register.Checked And Not Session("user")._authenticated Then
        '' If Not Session("user")._authenticated Then
        Dim oCustomer As New ion_two.skl_customers

        '--- declare logics
        Dim oCustomer_lgc As New ion_two.cls_customers_lgc
        oCustomer_lgc._connection_string = Application("config").connection_string
        oCustomer_lgc._dbtype = Application("config").connection_string_type
        '' oCustomer_lgc._user_name = Session("user")._name
        '' If Not Session("user")._authenticated Then
        If 1 = 1 Then
            oCustomer._password = Me.GetRandomPasswordUsingGUID(6)

            username_formail = Me.txt_email.Text '' saves for other emails
            pass_formail = oCustomer._password

            'Dim omail As New ion_two.cls_mod_mail
            'omail.mail_from = "sales@twin-diamonds.com"
            'omail.mail_to = Me.p_email.Text
            'Dim body As String
            'omail.getHTML_byURL(Session("user")._domain + "/htmlmail/mail-password.aspx?pass=" + oCustomer._password + "&user=" + Me.p_email.Text.Replace("@", "|"), body)
            'omail.subject = "Your password on Twin-Diamonds.com!"
            'omail.send(body)
            'ElseIf Me.chk_register.Checked Then
            '    oCustomer._password = Me.p_password.Text
            '    username_formail = Me.p_email.Text '' saves for other emails
            '    pass_formail = Me.p_password.Text
            'End If

            'If Me.chk_register.Checked Then
            '    oCustomer._password = Me.p_password.Text
            '    '' oCustomer_lgc._user_name = Me.p_email.Text
            'Else
            ''    oCustomer_lgc._user_name = Me.p_email.Text
            oCustomer._password = Me.GetRandomPasswordUsingGUID(6)
        End If
        ''End If
        '
        oCustomer._firstname = Me.txt_bln_firstname.Text
        oCustomer._lastname = Me.txt_bln_lastname.Text

        oCustomer._email = Me.txt_email.Text
        '' username_formail = Me.p_email.Text

        oCustomer._street1 = Me.txt_bln_street.Text
        oCustomer._city1 = Me.txt_bln_city.Text
        oCustomer._pobox1 = ""
        oCustomer._state1_id = Me.cmb_bln_state.SelectedValue
        oCustomer._country1_id = Me.cmb_shp_country.SelectedValue
        oCustomer._zip1 = Me.txt_bln_zip.Text
        oCustomer._phone1 = Me.txt_bln_phone.Text
        oCustomer._fax1 = ""
        '-
        oCustomer._active = True
        oCustomer._lastmodify_user = "twin-diamonds"
        oCustomer._dealer = False
        oCustomer._prf_language_id = 1
        oCustomer._inv_mail = False
        oCustomer._inv_update = 1
        oCustomer._registration_ip = "1.1.1.1"
        oCustomer._b_type_id = 1
        oCustomer._b_state_id = oCustomer._state1_id
        oCustomer._b_country_id = oCustomer._country1_id
        ''   oCustomer._state1_id = 1


        '--- Get birthdate
        'Dim cnt_birthdate As wc_date
        'cnt_birthdate = Me.FindControl("wc_date1")
        oCustomer._dateofbirth = Convert.ToDateTime("1/1/2000")

        'Dim nDealerRequest As Int16 = Request.QueryString("dl")
        ''If nDealerRequest = 1 Then
        'oCustomer._b_name = Me.txt_bname.Text
        'oCustomer._b_street = Me.txt_streetb.Text
        'oCustomer._b_city = Me.txt_cityb.Text
        'oCustomer._b_pobox = Me.txt_poboxb.Text
        'oCustomer._b_state_id = Me.cmb_stateb.SelectedValue
        'oCustomer._b_country_id = Me.cmb_countryb.SelectedValue
        'oCustomer._b_zip = Me.txt_zipb.Text
        'oCustomer._b_phone = Me.txt_phonebi.Text
        'oCustomer._b_fax = Me.txt_faxb.Text
        'oCustomer._b_siteurl = Me.txt_siteurl.Text
        'oCustomer._b_specialization = Me.txt_specialization.Text
        'oCustomer._b_type_id = Me.cmb_btype.SelectedValue
        'oCustomer._b_tradingass = Me.txt_tradingass.Text
        ''End If

        ''  ''Session("message")._listbox.items.add("2")
        '--- Clear messagebox
        ''   bError = ''Session("message").clear()

        '--- Save
        ''  If Not Session("user")._authenticated Then
        bError = oCustomer_lgc.insert(oCustomer)
        If bError Then
            Session("error")._Err_Number = oCustomer_lgc._err_number
            Session("error")._Err_Description = oCustomer_lgc._err_description
            Session("error")._Err_Source = oCustomer_lgc._err_source
            Session("error")._Err_Module = Me.Request.CurrentExecutionFilePath
            Session("error")._Err_Call = "btn_save_Click [ion_two.cls_customers_lgc:insert]"
            ''   Server.Transfer("/aspxerror.aspx")
        End If

        '--- If all OK then Login
        Dim oSession As New ion_two.cls_session
        oSession._connection_string = Application("config").connection_string
        oSession._dbtype = Application("config").connection_string_type
        '' oSession._session = Session("user")

        '--- Logon
        Dim nId As Int32
        ''oSession.load_user()
        bError = oSession.logon(nId, oCustomer._email, oCustomer._password)
        'If bError Then
        '    Session("error")._Err_Number = Err.Number
        '    Session("error")._Err_Description = Err.Description
        '    Session("error")._Err_Source = Err.Source
        '    Session("error")._Err_Module = Me.Request.CurrentExecutionFilePath
        '    Session("error")._Err_Call = "btn_logon_Click [ion_two.cls_session:logon]"
        '    ''   Server.Transfer("/aspxerror.aspx")
        'End If

        ''--- If user is logged on, save its cookie
        If nId > 0 Then
            '--- Save Cookie
            userid = nId

        End If

        'Session("message")._listbox.items.add("+ Customer information has been saved!")

        ''--- Release
        'oSession = Nothing
        'Else
        'oCustomer._id = Session("user")._id
        'oCustomer._password = Session("user")._password
        'oCustomer_lgc.update(oCustomer)
        'Dim nId As Int32
        'Dim oSession As New ion_two.cls_session

        'oSession._connection_string = Application("config").connection_string
        'oSession._dbtype = Application("config").connection_string_type
        'oSession._session = Session("user")

        'oSession.logon(nId, oCustomer._email, oCustomer._password)

        'If username_formail = "" And pass_formail = "" And Session("user")._authenticated Then

        '    username_formail = Session("user")._email
        '    pass_formail = Session("user")._password
        ''End If
        '' End If

        ''  Else

        ''  End If

        If userid = 0 Then userid = 1091



        user_Real_name = Me.txt_bln_firstname.Text + " " + Me.txt_bln_lastname.Text
        ''  ''Session("message")._listbox.items.add("3")
        '--- Get order
        Dim oOrder As New ion_two.skl_order



        '--- Addresses
        oOrder._adrs_billing_name = Convert.ToString(Me.txt_bln_firstname.Text + " " + Me.txt_bln_firstname.Text)
        oOrder._adrs_billing_street = Convert.ToString(Me.txt_bln_street.Text)
        oOrder._adrs_billing_city = Convert.ToString(Me.txt_bln_city.Text)
        oOrder._adrs_billing_zip = Convert.ToString(Me.txt_bln_zip.Text)
        oOrder._adrs_billing_state_id = Me.cmb_shp_state.SelectedItem.Value
        oOrder._adrs_billing_country_id = Me.cmb_shp_country.SelectedItem.Value
        oOrder._adrs_billing_phone = Convert.ToString(Me.txt_bln_phone.Text)
        ''  If Me.same_address.Checked Then
        'oOrder._adrs_shipping_name = Convert.ToString(Me.p_name.Text + " " + Me.p_lastname.Text)
        'oOrder._adrs_shipping_street = Convert.ToString(Me.pay_street.Text)
        'oOrder._adrs_shipping_city = Convert.ToString(Me.pay_city.Text)
        'oOrder._adrs_shipping_zip = Convert.ToString(Me.pay_zip.Text)
        'oOrder._adrs_shipping_state_id = Me.pay_state.SelectedItem.Value
        'oOrder._adrs_shipping_country_id = Me.pay_country.SelectedItem.Value
        'oOrder._adrs_shipping_phone = Convert.ToString(Me.p_phone.Text)
        '' Else
        oOrder._adrs_shipping_name = Convert.ToString(Me.txt_shp_name.Text + " " + Me.txt_shp_lastname.Text)
        oOrder._adrs_shipping_street = Convert.ToString(Me.txt_shp_street.Text)
        oOrder._adrs_shipping_city = Convert.ToString(Me.txt_shp_city.Text)
        oOrder._adrs_shipping_zip = Convert.ToString(Me.txt_shp_zip.Text)
        oOrder._adrs_shipping_state_id = Me.cmb_shp_state.SelectedItem.Value
        oOrder._adrs_shipping_country_id = Me.cmb_shp_country.SelectedItem.Value
        oOrder._adrs_shipping_phone = Convert.ToString(Me.txt_shp_phone.Text)
        oOrder._customer_notes = Convert.ToString(Me.txt_customer_notes.Text)
        ''  End If

        ''  ''Session("message")._listbox.items.add("4")
        '--- Shipping & wrapping
        oOrder._packaging_id = Me.rdo_wrapping.SelectedIndex
        oOrder._shipping_id = Me.rdo_shipping.SelectedIndex

        '--- Total amounts
        oOrder._amnt_extracharges = 0
        oOrder._amnt_grandtotal = Convert.ToDecimal(Convert.ToDecimal(Me.rdo_wrapping.SelectedValue) + ocart.total_amount + Convert.ToDecimal(Me.rdo_shipping.SelectedValue))
        'oOrder._amnt_items = Convert.ToDecimal(ocart._)
        oOrder._amnt_labor = 0
        oOrder._amnt_shipping = Convert.ToDecimal(Me.rdo_shipping.SelectedValue)
        oOrder._amnt_subtotal = Convert.ToDecimal(Convert.ToDecimal(Me.rdo_wrapping.SelectedValue) + ocart.total_amount + Convert.ToDecimal(Me.rdo_shipping.SelectedValue))
        oOrder._amnt_vat = oShipping._total_vat
        oOrder._amnt_vatperc = 0
        oOrder._amnt_wrapping = Convert.ToDecimal(Me.rdo_wrapping.SelectedValue)
        oOrder._amnt_items = ocart.total_amount

        '' ''Session("message")._listbox.items.add("5")
        Dim nDaysAhead As Int16 = System.Convert.ToInt16(30)
        oOrder._interest_start_date = DateAdd(DateInterval.Day, nDaysAhead, Date.Today)
        oOrder._interest_percentage = 0.001

        Dim odate As New DateTime(Convert.ToInt32(Me.txt_year.Text), Convert.ToInt32(Me.txt_month.Text), Convert.ToInt32(Me.txt_day.Text))


        oOrder._orderdate = odate
        oOrder._cluborder = False
        'If Session("user")._authenticated Then
        '    oOrder._user_id = Session("user")._id
        '    oOrder._campaign = Session("user")._campaign
        '    oOrder._affiliate = Session("user")._affiliate
        '    oOrder._referrer = Session("user")._referrer
        '    oOrder._remote_ip = Session("user")._ip

        '    ' oorder._idexid = 
        '    oOrder._lastmodify_Date = System.Convert.ToDateTime(Today.Now)
        '    oOrder._lastmodify_User = System.Convert.ToString(Session("user")._name)
        '    oOrder._lastmodify_User_id = System.Convert.ToInt32(Session("user")._id)
        'Else
        oOrder._user_id = userid
        oOrder._campaign = ""
        oOrder._affiliate = ""

        If Me.CheckBox1.Checked Then
            oOrder._referrer = "EBAY" + Me.txt_ebaynumber.Text
        Else
            oOrder._referrer = ""
        End If

        oOrder._remote_ip = Request.UserHostAddress.ToString

        ' oorder._idexid = 
        oOrder._lastmodify_Date = odate
        oOrder._lastmodify_User = ""
        oOrder._lastmodify_User_id = userid
        'End If

        ''    ''Session("message")._listbox.items.add("6")
        Dim oOrderLogics As New ion_two.cls_order_lgc
        oOrderLogics._connection_string = Application("config").connection_string
        oOrderLogics._dbtype = Application("config").connection_string_type

        '--- Get all items in cart
        '' run a convert statment for idex diamonds


        ''Dim ocart As ion_two.cls_advanced_cart = Session("cart2")
        Dim i As Int32
        For i = 0 To ocart.normal_items.Count - 1
            oOrder._order_items.Add(ocart.normal_items(i))

        Next

        For i = 0 To ocart.ocj_items.Count - 1
            oOrder._order_items.Add(ocart.ocj_items(i).cs)
            oOrder._order_items.Add(ocart.ocj_items(i).ss)
            oOrder._order_items.Add(ocart.ocj_items(i).style_semi)
        Next

        For i = 0 To ocart.se_items.Count - 1
            oOrder._order_items.Add(ocart.se_items(i).cs)
            oOrder._order_items.Add(ocart.se_items(i).jewel)
        Next


        ''
        ''      oOrder._order_items = Session("cart")._shopitem
        ''    ''Session("message")._listbox.items.add("7")

        '--- Clear messagebox
        ''   bError = ''Session("message").clear()


        '--- Insert order
        bError = oOrderLogics.insert(oOrder)
        ''Session("message")._listbox.items.add("8")
        If bError Then
            Session("error")._Err_Number = oOrderLogics._err_number
            Session("error")._Err_Description = oOrderLogics._err_description
            Session("error")._Err_Source = oOrderLogics._err_source
            Session("error")._Err_Module = Me.Request.CurrentExecutionFilePath
            Session("error")._Err_Call = "btn_save_Click [ion_two.cls_order_lgc:insert]"
            ''        Response.Redirect(Session("user")._domain + "/aspxerror.aspx")
        Else
            ''Session("message")._listbox.items.add("+ You order has been saved!  [order #" + Convert.ToString(oOrder._ordernumber) + "]")
        End If

        '--- Insert payment
        Dim oPayment As New ion_two.cls_payment
        oPayment._connection_string = Application("config").connection_string
        oPayment._dbtype = Application("config").connection_string_type
        oPayment._payment_type = Convert.ToInt16(Me.pay_mathod.SelectedValue)
        oPayment._initial_payment = Convert.ToDecimal(oOrder._amnt_grandtotal)
        'If Session("user")._authenticated Then
        '    oPayment._user_id = Session("user")._id
        '    oPayment._user_name = Session("user")._name
        'Else
        oPayment._user_id = userid
        oPayment._user_name = ""
        'End If

        '--- set CLib order
        If oOrder._cluborder Then
            oPayment._account = 1
        Else
            oPayment._account = 2
        End If


        Dim oPaymentSkelet As New ion_two.skl_cashflow
        Select Case Convert.ToInt16(Me.pay_mathod.SelectedValue)
            Case 1
                oPaymentSkelet._cc_type_id = Me.cc_type.SelectedItem.Value
                oPaymentSkelet._cc_name = Me.cc_name.Text
                oPaymentSkelet._cc_number = Me.cc_number.Text
                oPaymentSkelet._cc_cvv = Me.cc_cvv.Text
                oPaymentSkelet._cc_exp_year = Me.cc_exp_y.SelectedValue
                oPaymentSkelet._cc_exp_month = Me.cc_exp_m.SelectedValue
                oPaymentSkelet._cc_user_ssn = Me.cc_cvv.Text
                oPaymentSkelet._cc_clubmember = True
                oPaymentSkelet._master = True

            Case 2
                oPaymentSkelet._mt_bank = ""
                oPaymentSkelet._mt_account = ""
                oPaymentSkelet._mt_name = ""
                oPaymentSkelet._mt_code = ""
                oPaymentSkelet._master = True

            Case 3
                oPaymentSkelet._cq_bank = ""
                oPaymentSkelet._cq_name = ""
                oPaymentSkelet._cq_account = ""
                oPaymentSkelet._cq_date = #1/1/1900#
                oPaymentSkelet._master = True

            Case 4
                oPaymentSkelet._paypal = True
                oPaymentSkelet._master = True

        End Select


        '--- Make the payment
        Dim bSuccess As Boolean = False
        bError = oPayment.make_payment(oOrder._id, oPaymentSkelet, bSuccess)
        If bError Then
            Session("error")._Err_Number = oPayment._err_number
            Session("error")._Err_Description = oPayment._err_description
            Session("error")._Err_Source = oPayment._err_source
            Session("error")._Err_Module = Me.Request.CurrentExecutionFilePath
            Session("error")._Err_Call = "btn_save_Click [ion_two.cls_payment:make_payment]"
            ''        Response.Redirect(Session("user")._domain + "/aspxerror.aspx")
        End If








        ' Dim ocart As New ion_two.cls_advanced_cart
        ''  ocart._connection_string = Application("config").connection_string
        ''  ocart._dbtype = Application("config").connection_string_type
        ''   ocart.pictures = Session("pictures")
        ''   ocart.isdealer = False
        Application("cart_obj") = Session("cart")
        Application("order_obj") = oOrder
        Dim login_info As New ArrayList

        login_info.Add(username_formail)
        login_info.Add(pass_formail)
        login_info.Add(user_Real_name)
        Application("login_info") = login_info

        'Dim body2 As String
        'Dim omail2 As New ion_two.cls_mod_mail
        'omail2.getHTML_byURL(Session("user")._domain + "/htmlmail/mail-order-placed.aspx", body2)
        'omail2.mail_to = Me.txt_email.Text
        'omail2.mail_from = "sales@twin-diamonds.com"
        'omail2.subject = "Order #" + Convert.ToString(oOrder._ordernumber) + " On Twin-Diamonds.com"
        'omail2.send(body2)

        ''--- Send Email
        'Dim oMail As New ion_two.cls_mailing
        'oMail._Config = Application("config")
        'oMail._User = Session("user")
        'oMail._Cart = Session("cart")
        'oMail._Order = oOrder
        'oMail._mailto = Me.p_email.Text
        'oMail._subject = "Thank you for purchasing at TWIN-DIAMONDS.COM"
        'oMail._content = ""
        'oMail._contenttype = 2
        'oMail._connection_string = Application("config").connection_string
        'bError = oMail.send()
        'If bError Then
        '    ''Session("message")._listbox.items.add("- Error sending Email!")
        '    If oMail._err_number = 5 Then
        '        bError = False
        '    Else
        '        bError = True
        '        Session("error")._Err_Number = oMail._err_number
        '        Session("error")._Err_Description = oMail._err_description
        '        Session("error")._Err_Source = oMail._err_source
        '        Session("error")._Err_Module = Me.Request.CurrentExecutionFilePath
        '        Session("error")._Err_Call = "btn_save_Click [ion_two.cls_mailing:send]"
        '''        Response.Redirect(Session("user")._domain + "/aspxerror.aspx")
        '    End If
        'Else
        '    ''Session("message")._listbox.items.add("+ Email send!")
        'End If

        'Session("affiliate") = New Hashtable
        'Session("affiliate")("total") = oOrder._amnt_grandtotal
        'Session("affiliate")("orderid") = oOrder._ordernumber
        'Session("affiliate")("itemnumber") = ocart.normal_items(0)._item_number


        '--- Finelize with message
        ''  ''Session("message")._tracking_action = "01"
        ''Session("message")._tracking_text = "Purchase completed No:" + Convert.ToString(oOrder._ordernumber)
        ''Session("message")._tracking_userid = Session("user")._name
        ''Session("message")._tracking_value = oPaymentSkelet._amount_total
        ''Session("message")._returnpath = "/customer-status.aspx"

        'If Convert.ToInt16(Me.pay_mathod.SelectedValue) = 4 Then

        '    Server.Transfer("checkout-with-paypal.aspx", True)


        'End If

        ''--- Reset cart
        Dim oCart_new As New ion_two.cls_advanced_cart
        oCart_new._connection_string = Application("config").connection_string
        oCart_new._dbtype = Application("config").connection_string_type
        oCart_new.pictures = Session("oTmpCart2").pictures
        Session("oTmpCart2") = oCart_new
        oCart_new = Nothing

        Me.ClearChildViewState()





        ''  Response.Redirect(Session("user")._domain + "/checkout_end.aspx")


        '--- release
        oOrder = Nothing
        oOrderLogics = Nothing
        oPaymentSkelet = Nothing

        Exit Sub

ErrorHandler:
        '--- Reporting Error
        Session("error")._Err_Number = Err.Number
        Session("error")._Err_Description = Err.Description
        Session("error")._Err_Source = Err.Source
        Session("error")._Err_Module = Me.Request.CurrentExecutionFilePath
        Session("error")._Err_Call = "btn_save_Click [ErrorHandler]"
        ''        Response.Redirect(Session("user")._domain + "/aspxerror.aspx")


    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Exit Sub
    End Sub

    Public Function GetRandomPasswordUsingGUID(ByVal length As Integer) As String
        'Get the GUID
        Dim guidResult As String = System.Guid.NewGuid().ToString()

        'Remove the hyphens
        guidResult = guidResult.Replace("-", String.Empty)

        'Make sure length is valid
        If length <= 0 OrElse length > guidResult.Length Then
            Throw New ArgumentException("Length must be between 1 and " & guidResult.Length)
        End If

        'Return the first length bytes
        Return guidResult.Substring(0, length)
    End Function

    Private Sub t_itemid_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles t_itemid.TextChanged

        Dim oTmpInventory As New ion_two.cls_inventory_lgc
        oTmpInventory._connection_string = Application("config").connection_string
        oTmpInventory._dbtype = Application("config").connection_string_type

        Dim opicture As New ion_two.cls_pictures
        opicture.load("http://www.twin-diamonds.com", "https://www.twin-diamonds.com")

        Dim oPlate As New ion_two.skl_lst_inventory
        ''
        '' Dim id As Int32 = Convert.ToInt32(Me.t_itemid.Text)

        Dim oitemnumber As New ion_two.cls_itemnumber
        oitemnumber._connection_string = Application("config").connection_string
        oitemnumber._dbtype = Application("config").connection_string_type

        Dim itemnumber As String = Me.t_itemid.Text
        Dim id As Int32
        Dim error1 As Int32
        oitemnumber.UnicodeItemNumber(itemnumber)
        oitemnumber.getid_fromnumber(itemnumber, id, error1)


        oTmpInventory.load(id, oPlate, opicture)

        Me.img_icon.ImageUrl = oPlate._icon_pic

        Me.hyp_item.NavigateUrl = "http://www.twin-diamonds.com/catalog/myitemv3.aspx?id=" + oPlate._id.ToString

        Me.t_price.Text = oPlate._pricing._correct_price
    End Sub

    Private Sub txt_email_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_email.TextChanged

        Dim oSession As New ion_two.cls_session
        oSession._connection_string = Application("config").connection_string
        oSession._dbtype = Application("config").connection_string_type
        '' oSession._session = Session("user")

        '--- Logon
        Dim nId As Int32

        oSession.loadbyemail(nId, Me.txt_email.Text)

        '--- declare logics

        Dim oCustomer As New ion_two.skl_customers


        Dim oCustomer_lgc As New ion_two.cls_customers_lgc
        oCustomer_lgc._connection_string = Application("config").connection_string
        oCustomer_lgc._dbtype = Application("config").connection_string_type

        ''  Dim oCustomer_lgc As New ion_two.cls_customers_lgc

        oCustomer_lgc.read(nId, oCustomer)

        Me.txt_bln_firstname.Text = oCustomer._firstname
        Me.txt_bln_lastname.Text = oCustomer._lastname

        Me.txt_bln_city.Text = oCustomer._city1
        Me.txt_bln_street.Text = oCustomer._street1
        Me.txt_bln_zip.Text = oCustomer._zip1
        Me.txt_bln_phone.Text = oCustomer._phone1
        Me.cmb_bln_country.SelectedIndex = GetComboValue(Me.cmb_bln_country, oCustomer._b_country_id)
        Me.cmb_bln_state.SelectedIndex = GetComboValue(Me.cmb_bln_state, oCustomer._b_state_id)









    End Sub

    Private Sub CheckBox2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox2.CheckedChanged
        If Me.CheckBox2.Checked Then
            Me.txt_shp_name.Text = Me.txt_bln_firstname.Text
            Me.txt_shp_lastname.Text = Me.txt_bln_lastname.Text
            Me.txt_shp_street.Text = Me.txt_bln_street.Text

            Me.txt_shp_city.Text = Me.txt_bln_city.Text
            Me.txt_shp_zip.Text = Me.txt_bln_zip.Text
            Me.cmb_shp_state.SelectedIndex = Me.cmb_bln_state.SelectedIndex
            Me.cmb_shp_country.SelectedIndex = Me.cmb_bln_country.SelectedIndex
            Me.txt_shp_phone.Text = Me.txt_bln_phone.Text
        End If
    End Sub
End Class
