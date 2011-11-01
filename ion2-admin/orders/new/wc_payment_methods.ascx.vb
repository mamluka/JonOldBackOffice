Partial Class wc_payment_methods
    Inherits System.Web.UI.UserControl
    Public order_id As Int32
    Public user_id As Int32
#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub

    'NOTE: The following placeholder declaration is required by the Web Form Designer.
    'Do not delete or move it.
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub

#End Region

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Put user code to initialize the page here

        ''  order_id = 777
        Me.order_id = Request.QueryString("id")
        If Not Page.IsPostBack Then
            Dim oFillcombo As New cls_datareader
            Dim oError As New cls_error
            oFillcombo.config = Application("config")
            oFillcombo.oerror = oError

            '--- fill Shipping STATE combo
            oFillcombo.combobox = Me.cc_type
            oFillcombo.sqlstring = "select id, lang" & Session("user").language & "_longdescr from acc_CREDITCARD  order by lang" & Session("user").language & "_longdescr"
            oFillcombo.showfield = "lang" & Session("user").language & "_longdescr"
            oFillcombo.bind_combo()

            oFillcombo = Nothing
            oError = Nothing

            Me.load_payment_info(order_id)
        End If
    End Sub
    Function load_payment_info(ByVal order_id As Int32)

        Dim opmeneger As New ion_two.cls_payment_manager
        opmeneger.conn_string = Application("config").connection_string
        opmeneger.db_type = Application("config").connection_string_type

        Dim opayment As New ion_two.skl_cashflow

        Dim ocombo As New iFunctions.cls_combo
        opmeneger.load_master_details(order_id, opayment)

        Select Case opayment._payment_type
            Case 1
                Me.cc_cvv.Text = opayment._cc_cvv
                Me.cc_type.SelectedIndex = ocombo.GetComboIndex(Me.cc_type, opayment._cc_type_id)
                Me.cc_number.Text = opayment._cc_number
                Me.cc_month.SelectedIndex = ocombo.GetComboIndex(Me.cc_month, opayment._cc_exp_month)
                Me.cc_year.SelectedIndex = ocombo.GetComboIndex(Me.cc_year, opayment._cc_exp_year)
                Me.cc_id.Text = opayment._cc_user_ssn
                Me.cc_name.Text = opayment._cc_name
                Me.chk_cc.Checked = True
            Case 2
                Me.wt_account.Text = opayment._mt_account
                Me.wt_bankname.Text = opayment._mt_bank
                Me.wt_code.Text = opayment._mt_code
                Me.wt_trasname.Text = opayment._mt_name
                Me.chk_wt.Checked = True
            Case 3
                Me.cq_bank.Text = opayment._cq_bank
                Me.cq_date.Text = opayment._cq_date
                Me.cq_name.Text = opayment._cq_name
                Me.cq_number.Text = opayment._cq_account
                Me.chk_cq.Checked = True
            Case 4
                Me.chk_paypal.Checked = True
        End Select

        ''   Me.user_id = opayment._user_id

    End Function


    Public Function make_payment(ByVal amount As Decimal, ByVal user_id As Int32)

        Dim opayment_lgk As New ion_two.cls_cashflow_lgc
        opayment_lgk._connection_string = Application("config").connection_string()
        opayment_lgk._dbtype = Application("config").connection_string_type

        Dim opayment As New ion_two.skl_cashflow

        Me.zeropayment(opayment)
        ''take care of payment type
        If Me.chk_cc.Checked Then
            opayment._payment_type = 1
        ElseIf Me.chk_wt.Checked Then
            opayment._payment_type = 2
        Else
            opayment._payment_type = 3
        End If

        opayment._payment_date = Date.Now

        Select Case opayment._payment_type
            Case 1
                opayment._cc_cvv = Me.cc_cvv.Text
                opayment._cc_type_id = Me.cc_type.SelectedValue
                opayment._cc_number = Me.cc_number.Text
                opayment._cc_exp_month = Me.cc_month.SelectedValue
                opayment._cc_exp_year = Me.cc_year.SelectedValue
                opayment._cc_user_ssn = Me.cc_id.Text
            Case 2
                opayment._mt_account = Me.wt_account.Text
                opayment._mt_bank = Me.wt_bankname.Text
                opayment._mt_code = Me.wt_code.Text
                opayment._mt_name = Me.wt_trasname.Text
            Case 3
                opayment._cq_bank = Me.cq_bank.Text
                opayment._cq_date = Me.cq_date.Text
                opayment._cq_name = Me.cq_name.Text
                opayment._cq_account = Me.cq_number.Text

        End Select
        opayment._amount_total = amount
        opayment._master = False

        opayment._user_id = user_id
        opayment._order_id = Me.order_id

        opayment_lgk.insert(opayment)



    End Function

    Private Sub chk_cc_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chk_cc.CheckedChanged
        Me.chk_cq.Checked = False
        Me.chk_wt.Checked = False
    End Sub

    Private Sub chk_wt_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chk_wt.CheckedChanged
        Me.chk_cc.Checked = False
        Me.chk_cq.Checked = False
    End Sub

    Private Sub chk_cq_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chk_cq.CheckedChanged
        Me.chk_cc.Checked = False
        Me.chk_wt.Checked = False
    End Sub

    Private Function zeropayment(ByVal oPayment As ion_two.skl_cashflow) As Boolean
        oPayment._payment_type = 0
        oPayment._payment_date = #1/1/1900#
        oPayment._order_id = 0
        oPayment._user_id = 0
        oPayment._approved = False
        oPayment._approved_date = #1/1/1900#
        oPayment._amount_total = 0
        oPayment._amount_interest = 0
        oPayment._cc_type_id = 0
        oPayment._cc_name = ""
        oPayment._cc_number = ""
        oPayment._cc_cvv = ""
        oPayment._cc_exp_year = ""
        oPayment._cc_exp_month = ""
        oPayment._cc_user_ssn = ""
        oPayment._cc_confermation = ""
        oPayment._cc_clubmember = False
        oPayment._cc_cleared = False
        oPayment._cc_batch = ""
        oPayment._mt_bank = ""
        oPayment._mt_account = ""
        oPayment._mt_name = ""
        oPayment._mt_code = ""
        oPayment._cq_bank = ""
        oPayment._cq_name = ""
        oPayment._cq_account = ""
        oPayment._cq_date = #1/1/1900#
        oPayment._notes = ""

    End Function
End Class
