Partial Class _default
    Inherits System.Web.UI.Page
    Protected WithEvents Label1 As System.Web.UI.WebControls.Label
    Protected WithEvents Label2 As System.Web.UI.WebControls.Label
    Protected WithEvents Label3 As System.Web.UI.WebControls.Label
    Protected WithEvents Label4 As System.Web.UI.WebControls.Label
    Protected WithEvents Label5 As System.Web.UI.WebControls.Label
    Protected WithEvents Label6 As System.Web.UI.WebControls.Label
    Protected WithEvents Label7 As System.Web.UI.WebControls.Label
    Protected WithEvents Label8 As System.Web.UI.WebControls.Label
    Protected WithEvents Label10 As System.Web.UI.WebControls.Label
    Protected WithEvents Label9 As System.Web.UI.WebControls.Label

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub

#End Region

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        On Error GoTo ErrorHandler
        Dim bError As Boolean = False


        '--- Set culture of form
        System.Threading.Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.CreateSpecificCulture(Request.UserLanguages(0))
        System.Threading.Thread.CurrentThread.CurrentUICulture = New System.Globalization.CultureInfo(Request.UserLanguages(0))


        '--- Set Access
        If Session("user").userlevel < 9 Then

            '--- TESTING
            ''Me.lbl_testing.Visible = False
            Me.btn_text_email.Visible = False

            '--- CHECKBOOKS
            Me.lbl_checkbooks.Visible = False
            Me.btn_add_check_usd.Visible = False
            Me.btn_add_check_ils.Visible = False
            Me.btn_edit_checks.Visible = False

            '--- RATES
            Me.btn_rates.Visible = False

            '--- REPORTD
            Me.lbl_reports.Visible = False
            Me.btn_rpt_cacheflow.Visible = False

            Me.btn_tdgenerate.Visible = False
        End If


        If Session("user").userlevel < 6 Then
            '--- HELP
            Me.lbl_helpfiles.Visible = False
            Me.btn_addhelp.Visible = False
            Me.btn_edithelp.Visible = False

            'Me.lbl_suppliers.Visible = False
            'Me.lbl_accounts.Visible = False
            Me.btn_supplier_status.Enabled = False
            Me.btn_general_acc_balance.Enabled = False
            'Me.lbl_payments.Visible = False
            Me.btn_receive_payments.Enabled = False
        End If

        If Session("user").userlevel < 5 Then
            'lbl_orders
            Me.btn_ListOrders.Enabled = False
        End If



        Exit Sub

ErrorHandler:
        '--- when object is called in external DLL
        Session("error").err_number = Err.Number
        Session("error").err_source = Err.Source
        Session("error").err_description = Err.Description
        '--- Our custom error
        Dim oTmpErrDB As New System.Diagnostics.StackFrame
        Session("error").app_module = Me.Request.CurrentExecutionFilePath
        Session("error").app_function = oTmpErrDB.GetMethod.Name
        Session("error").app_call = "_default / Page_Load"
        Server.Transfer("/apperror.aspx")
        Exit Sub

    End Sub


    Private Sub btn_add_item_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_add_item.Click
        Server.Transfer("/inventory/additem.aspx?")
    End Sub

    Private Sub btn_edit_item_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_edit_item.Click
        Server.Transfer("/inventory/listitem.aspx")
    End Sub

    Private Sub btn_add_customer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_add_customer.Click
        Server.Transfer("/customers/addcustomer.aspx?mode=1")
    End Sub

    Private Sub btn_edit_customer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_edit_customer.Click
        Server.Transfer("/customers/listcustomers.aspx")
    End Sub

    Private Sub btn_ListOrders_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_ListOrders.Click
        Server.Transfer("/orders/list-orders.aspx")
    End Sub

    Private Sub btn_banners_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Server.Transfer("/new/banners.aspx")
    End Sub

    Private Sub btn_receive_payments_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_receive_payments.Click
        Server.Transfer("/accounting/list-cashflow.aspx")
    End Sub

    Private Sub btn_add_check_usd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_add_check_usd.Click
        Server.Transfer("/accounting/checkbooks/checkbook.aspx?cur=1")
    End Sub

    Private Sub btn_add_check_ils_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_add_check_ils.Click
        Server.Transfer("/accounting/checkbooks/checkbook.aspx?cur=2")
    End Sub

    Private Sub btn_edit_checks_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_edit_checks.Click
        Server.Transfer("/accounting/checkbooks/listcheckbooks.aspx(")
    End Sub

    Private Sub btn_text_email_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_text_email.Click
        Dim berror As Boolean = False
        Dim oemaillist As New ion_resources.cls_export_mail_list
        oemaillist.conn_string = Application("config").connection_string ' '= "initial catalog=ion-mailing;data source=(local);user id=ion_1;password=solytudine;"
        oemaillist.write_email_list()
        If berror Then
            '--- when object is called in external DLL
            Session("error").err_number = oemaillist._err_number
            Session("error").err_source = oemaillist._err_source
            Session("error").err_description = oemaillist._err_description
            '--- Custom error
            Dim oTmpErrDB2 As New System.Diagnostics.StackFrame
            Session("error").app_module = Me.Request.CurrentExecutionFilePath
            Session("error").app_function = oTmpErrDB2.GetMethod.Name
            Session("error").app_call = "btn_save_click"
            Server.Transfer("/apperror.aspx")
        End If
    End Sub

    Private Sub btn_general_acc_balance_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_general_acc_balance.Click
        Server.Transfer("/accounting/listaccounts.aspx")
    End Sub

    Private Sub btn_supplier_status_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_supplier_status.Click
        Server.Transfer("/suppliers/listsuppliers.aspx")
    End Sub

    Private Sub btn_addhelp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_addhelp.Click
        Server.Transfer("/help/addhelp.aspx?mode=1")
    End Sub

    Private Sub btn_edithelp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_edithelp.Click
        Server.Transfer("/help/listhelp.aspx")
    End Sub

    Private Sub btn_tdgenerate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_tdgenerate.Click
        Server.Transfer("/generate_td-htm.aspx")
    End Sub

    Private Sub btn_appraisal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_appraisal.Click
        Server.Transfer("/reports/appraisals/appraisal.aspx")
    End Sub

    Private Sub btn_rates_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_rates.Click
        Server.Transfer("/rates/rates.aspx")
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Server.Transfer("/ebay/ebayoffice.aspx")
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Server.Transfer("/new/editsidestones.aspx")
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Response.Redirect("/new/feedbacks.aspx")
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Response.Redirect("/new/search_edit.aspx")
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'Dim idex As New ion_two.cls_idex_v2
        'idex.link = "http://www.idexonline.com/download_inventory_excel/TwinDiamondsFeed.asp?format=csv&item_type=1"
        'idex.path = Server.MapPath("/")
        'idex.conn_string = Application("config").connection_string
        'idex.dbtype = Application("config").connection_string_type
        'idex.GetUpdateFromWeb_v1()
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim ogoogle As New ion_two.cls_google_products
        ogoogle.conn_string = Application("config").connection_string
        ogoogle.dbtype = Application("config").connection_string_type
        ogoogle.xmlfile = Server.MapPath("/google.xml")
        ogoogle.descxml = Server.MapPath("/xml/itemdesc.xml")
        ogoogle.CreateFeed()
    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        Response.Redirect("/new/feeds.aspx")

        Dim oalibaba As New ion_two.cls_alibaba
        oalibaba.conn_string = Application("config").connection_string
        oalibaba.dbtype = Application("config").connection_string_type
        oalibaba.xmlfile = Server.MapPath("/google.xml")
        oalibaba.descxml = Server.MapPath("/xml/itemdesc.xml")
        oalibaba.file = Server.MapPath("template_150904_tp.txt")
        oalibaba.file2 = Server.MapPath("template_150906_tp.txt")

        oalibaba.file3 = Server.MapPath("template_36090305_tp.txt")
        oalibaba.file4 = Server.MapPath("template_36090309_tp.txt")
        oalibaba.file5 = Server.MapPath("template_36093020_tp.txt")
        oalibaba.file6 = Server.MapPath("template_36093030_tp.txt")
        oalibaba.facefile = Server.MapPath("/xml/faces.xml")
        '' oalibaba.test()
        ''
        Dim ous As New ion_two.cls_us_products

        ous.conn_string = Application("config").connection_string
        ous.dbtype = Application("config").connection_string_type
        ous.xmlfile = Server.MapPath("/google.xml")
        ous.descxml = Server.MapPath("/xml/itemdesc.xml")
        ous.facefile = Server.MapPath("/xml/faces.xml")
        ous.file = Server.MapPath("us.txt")
        '' ous.GetCSV()

        Dim osortprice As New ion_two.cls_sortprice

        osortprice.conn_string = Application("config").connection_string
        osortprice.dbtype = Application("config").connection_string_type
        osortprice.xmlfile = Server.MapPath("/google.xml")
        osortprice.descxml = Server.MapPath("/xml/itemdesc.xml")
        osortprice.facefile = Server.MapPath("/xml/faces.xml")
        osortprice.file = Server.MapPath("sortprice.txt")
        '' osortprice.GetCSV()

        Dim osharesale As New ion_two.cls_sharesale

        osharesale.conn_string = Application("config").connection_string
        osharesale.dbtype = Application("config").connection_string_type
        osharesale.xmlfile = Server.MapPath("/google.xml")
        osharesale.descxml = Server.MapPath("/xml/itemdesc.xml")
        osharesale.facefile = Server.MapPath("/xml/faces.xml")
        osharesale.file = Server.MapPath("sharesale.txt")
        osharesale.GetCSV()

        Dim oshopping As New ion_two.cls_shopping

        oshopping.conn_string = Application("config").connection_string
        oshopping.dbtype = Application("config").connection_string_type
        oshopping.xmlfile = Server.MapPath("/google.xml")
        oshopping.descxml = Server.MapPath("/xml/itemdesc.xml")
        oshopping.facefile = Server.MapPath("/xml/faces.xml")
        oshopping.file = Server.MapPath("shopping.csv")
        ''oshopping.GetCSV()


    End Sub

    Private Sub LinkButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        Response.Redirect("/orders/addorder.aspx")
    End Sub

    Private Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button9.Click
        Response.Redirect("/new/seventytwo.aspx")
    End Sub

    Private Sub updatecurrency_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles updatecurrency.Click
        Dim ocurrency As New ion_two.cls_currency
        ocurrency._connection_string = Application("config").connection_string
        ocurrency._dbtype = Application("config").connection_string_type
        Dim oconv As New net.webservicex.www.CurrencyConvertor
        Dim conv_rate As Double = 1
        Dim currency_symbol As String
        Dim currency_array As New ArrayList

        ocurrency.ReadAllCurrency(currency_array)

        For Each currency_obj As ion_two.skl_currency In currency_array

            Select Case currency_obj.code
                Case "USA"
                    conv_rate = 1
                    currency_symbol = "$"

                Case "GBP"
                    conv_rate = oconv.ConversionRate(net.webservicex.www.Currency.USD, net.webservicex.www.Currency.GBP)
                    currency_symbol = "£"
                Case "EUR"
                    conv_rate = oconv.ConversionRate(net.webservicex.www.Currency.USD, net.webservicex.www.Currency.EUR)
                    currency_symbol = "Euro"
                Case "AUD"
                    conv_rate = oconv.ConversionRate(net.webservicex.www.Currency.USD, net.webservicex.www.Currency.AUD)
                    currency_symbol = "AUD"
                Case "CAD"
                    conv_rate = oconv.ConversionRate(net.webservicex.www.Currency.USD, net.webservicex.www.Currency.CAD)
                    currency_symbol = "CAD"
                Case "ILS"
                    conv_rate = oconv.ConversionRate(net.webservicex.www.Currency.USD, net.webservicex.www.Currency.ILS)

            End Select

            currency_obj.rate = conv_rate

            ocurrency.UpdateCurrencyById(currency_obj)

        Next
    End Sub
End Class
