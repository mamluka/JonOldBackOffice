Partial Class calendar
    Inherits System.Web.UI.Page

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

        '--- Set culture of form
        System.Threading.Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.CreateSpecificCulture(Request.UserLanguages(0))
        System.Threading.Thread.CurrentThread.CurrentUICulture = New System.Globalization.CultureInfo(Request.UserLanguages(0))

    End Sub

    Private Sub Calendar1_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Calendar1.SelectionChanged
        Dim cJscript As String
        cJscript = "<script language=""javascript"">" + Chr(13)
        cJscript = cJscript + "window.opener.document." + Request.QueryString("formname") + ".value = '" + Calendar1.SelectedDate + "';" + Chr(13)
        If Request.QueryString("mode") = 1 Then
            cJscript = cJscript + "window.opener.document.Form1.submit();" + Chr(13)
        End If
        cJscript = cJscript + "window.close();" + Chr(13)
        cJscript = cJscript + "</script> " + Chr(13)
        'cJscript = cJscript + "</script" + "> " + Chr(13)

        Me.lit_1.Text = cJscript

    End Sub

    Private Sub Calendar1_DayRender(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DayRenderEventArgs) Handles Calendar1.DayRender
        If e.Day.Date = DateTime.Now.ToString("d") Then
            e.Cell.BackColor = System.Drawing.Color.LightGray
        End If

    End Sub
End Class
