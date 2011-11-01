Partial Class edititem
    Inherits System.Web.UI.Page



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
        'Put user code to initialize the page here

        '--- Set culture of form
        System.Threading.Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.CreateSpecificCulture(Request.UserLanguages(0))
        System.Threading.Thread.CurrentThread.CurrentUICulture = New System.Globalization.CultureInfo(Request.UserLanguages(0))

        '--- Get querystring
        'cnt_plate.hid_id.Text = Convert.ToInt32(Request.QueryString("id"))
        'If cnt_plate.hid_id.Text > 0 Then
        'cnt_plate.hid_mode.Text = 2
        'Else
        '    cnt_plate.hid_mode.Text = 1
        'End If

        'cnt_plate.Visible = True

    End Sub

End Class
