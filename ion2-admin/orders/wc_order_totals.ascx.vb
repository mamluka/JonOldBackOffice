Partial Class order_totals
    Inherits System.Web.UI.UserControl

    Public WithEvents lbl_total_cart As System.Web.UI.WebControls.Label
    Public WithEvents txt_labor As System.Web.UI.WebControls.TextBox
    Public WithEvents txt_extra_charges As System.Web.UI.WebControls.TextBox
    Public WithEvents hid_subtotal As System.Web.UI.WebControls.Label
    Public WithEvents hid_grandtotal As System.Web.UI.WebControls.Label
    Public WithEvents hid_vat As System.Web.UI.WebControls.Label
    Public WithEvents hid_total_cart As System.Web.UI.WebControls.Label
    Public WithEvents hid_wrapping As System.Web.UI.WebControls.Label
    Public WithEvents hid_shipping As System.Web.UI.WebControls.Label
    Public WithEvents hid_vatperc As System.Web.UI.WebControls.Label
    Public WithEvents txt_discount As System.Web.UI.WebControls.TextBox
    Public WithEvents btn_getcart As System.Web.UI.WebControls.Button
    Public WithEvents hid_currency_code As System.Web.UI.WebControls.Label
    '---

    Public nExtraCharges As Decimal = 0
    Public nArrivalDays As Int16 = 0

    Public nProviderCode As Int16 = 0


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

        refresh_totals()

    End Sub

    Sub refresh_totals()

        '--- reCalculate totals

        recalc_totals()

        Dim ocurrency As New ion_two.cls_currency
        Dim currency_symbol As String = ocurrency.GetSymbolByCode(Me.hid_currency_code.Text)

        Me.lbl_wrapping.Text = Format(System.Convert.ToDecimal(hid_wrapping.Text), "##,##0") + currency_symbol
        Me.lbl_shipping.Text = Format(System.Convert.ToDecimal(hid_shipping.Text), "##,##0") + currency_symbol
        Me.lbl_subtotal.Text = Format(System.Convert.ToDecimal(hid_subtotal.Text), "##,##0") + currency_symbol
        Me.lbl_vat.Text = Format(System.Convert.ToDecimal(hid_vat.Text), "##,##0.00") + currency_symbol
        Me.lbl_vatperc.Text = Format(System.Convert.ToDecimal(hid_vatperc.Text), "##,##0.00") + "%"
        Me.lbl_grandtotal.Text = Format(System.Convert.ToDecimal(hid_grandtotal.Text), "##,##0") + currency_symbol

        Me.lbl_total_cart.Text = Format(System.Convert.ToDecimal(hid_total_cart.Text), "##,##0") + currency_symbol
        Me.txt_labor.Text = Format(System.Convert.ToDecimal(txt_labor.Text), "##,##0")
        Me.txt_extra_charges.Text = Format(System.Convert.ToDecimal(txt_extra_charges.Text), "##,##0")
        Me.txt_discount.Text = Format(System.Convert.ToDecimal(txt_discount.Text), "##,##0")

    End Sub

    Sub recalc_totals()

        If Not IsNumeric(lbl_total_cart.Text) Or lbl_total_cart.Text = "0" Then
            lbl_total_cart.Text = 0
        End If

        If Not IsNumeric(txt_labor.Text) Or txt_labor.Text = "0" Then
            txt_labor.Text = 0
        End If

        If Not IsNumeric(txt_extra_charges.Text) Or txt_extra_charges.Text = "0" Then
            txt_extra_charges.Text = 0
        End If

        If Not IsNumeric(txt_discount.Text) Or txt_discount.Text = "0" Then
            txt_discount.Text = 0
        End If

        hid_subtotal.Text = Convert.ToString(Convert.ToDecimal(hid_total_cart.Text) + Convert.ToDecimal(hid_shipping.Text) + Convert.ToDecimal(hid_wrapping.Text) + Convert.ToDecimal(txt_labor.Text) + Convert.ToDecimal(txt_extra_charges.Text) - Convert.ToDecimal(txt_discount.Text))
        hid_vat.Text = Convert.ToString((Convert.ToDecimal(hid_subtotal.Text) / 100) * Convert.ToDecimal(hid_vatperc.Text))
        Dim nGtotal As Decimal = Convert.ToString(Convert.ToDecimal(hid_subtotal.Text) + Convert.ToDecimal(hid_vat.Text))
        hid_grandtotal.Text = nGtotal.Round(nGtotal, 0)

    End Sub

    Private Sub Page_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.PreRender
        refresh_totals()
    End Sub


    Private Sub btn_getcart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim oTmpCart As ion_resources.cls_cart = Session("oTmpCart")
        hid_total_cart.Text = oTmpCart.totalamount()

        refresh_totals()
    End Sub
End Class
