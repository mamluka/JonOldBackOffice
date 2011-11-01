Partial Class control
    Inherits System.Web.UI.UserControl

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

        '--- Set culture of form
        System.Threading.Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.CreateSpecificCulture(Request.UserLanguages(0))
        System.Threading.Thread.CurrentThread.CurrentUICulture = New System.Globalization.CultureInfo(Request.UserLanguages(0))



        Me.lbl_version.Text = "ION-ADM " + Application("config").ion_version
        If Request.ServerVariables("AUTH_USER") = "" Then
            Me.lbl_user.Text = "User: Not availiable "
        Else
            Me.lbl_user.Text = "User: " + Session("user").user_name
        End If


    End Sub

    Private Sub btn_home_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_home.Click
        Server.Transfer("/default.aspx")
    End Sub

    Private Sub btn_site_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_site.Click
        Response.Redirect("http://www.twin-diamonds.com")
    End Sub
End Class
