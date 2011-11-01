Partial Class order_payment_edit
    Inherits System.Web.UI.Page
    Public pay_coll As New ArrayList
    Public cnt_Payments As wc_payment_methods
    Public user_id As Int32
    Public order_id As Int32

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
        Me.order_id = Request.QueryString("id")
        If Not Page.IsPostBack Then
            Me.init_payment()
        End If
        cnt_Payments = Me.FindControl("wc_payment_methods1")


    End Sub
    Function init_payment()

        Dim opmeneger As New ion_two.cls_payment_manager
        opmeneger.conn_string = Application("config").connection_string
        opmeneger.db_type = Application("config").connection_string_type

        Dim cc_valid As Boolean
        Dim payment_total As Decimal
        Dim payment_made As Decimal


        Me.pay_coll.Clear()
        opmeneger.get_init_details(Me.order_id, payment_total, payment_made, cc_valid, Me.user_id, Me.pay_coll)

        Dim ostringfunc As New iFunctions.cls_string
        ostringfunc.format_currency(payment_total, Me.pay_grandtotal.Text, " $")
        ostringfunc.format_currency(payment_total - payment_made, Me.pay_lefttopay.Text, " $")
        ostringfunc.format_currency(payment_made, Me.pay_payed.Text, " $")

        Me.val_tosave.MaximumValue = payment_total - payment_made
        Me.txt_amout_tosave.Text = Convert.ToString(payment_total - payment_made)
        'If Not Page.IsPostBack Then
        '    Me.val_tosave.MaximumValue = payment_total - payment_made
        '    ostringfunc.format_decimal(payment_total - payment_made, Me.txt_amout_tosave.Text)
        'Else
        '    Me.val_tosave.MaximumValue = payment_total - payment_made - Convert.ToDecimal(Me.txt_amout_tosave.Text)
        'End If



        chk_cc_verified.Checked = cc_valid
    End Function
    Private Sub btn_do_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_do.Click

        Dim opmeneger As New ion_two.cls_payment_manager
        opmeneger.conn_string = Application("config").connection_string
        opmeneger.db_type = Application("config").connection_string_type

        opmeneger.userid_byorderid(Me.order_id, Me.user_id)
        cnt_Payments.make_payment(Convert.ToDecimal(Me.txt_amout_tosave.Text), Me.user_id)

        Me.init_payment()
    End Sub

    Private Sub chk_cc_verified_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chk_cc_verified.CheckedChanged
        Dim opmeneger As New ion_two.cls_payment_manager
        opmeneger.conn_string = Application("config").connection_string
        opmeneger.db_type = Application("config").connection_string_type

        opmeneger.set_cc_status(Me.order_id, Me.chk_cc_verified.Checked)
    End Sub
End Class
