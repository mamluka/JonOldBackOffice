Partial Class apperror
    Inherits System.Web.UI.Page

    Public cRoot As String

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

        Dim bError As Boolean = False


        '--- Set culture of form
        System.Threading.Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.CreateSpecificCulture(Request.UserLanguages(0))
        System.Threading.Thread.CurrentThread.CurrentUICulture = New System.Globalization.CultureInfo(Request.UserLanguages(0))

        Dim bDebug As Boolean = Application("config").debug


        '--- Log Error
        Dim oLogging As New ion_resources.cls_logging()
        oLogging.oerror = Session("error")
        oLogging.config = Application("config")
        oLogging.user = Session("user")
        oLogging.mode = 2 '--- Logging For Backoffice
        If Not bDebug Then
            oLogging.oerror.note = "Not in DEBUG mode!"
            bError = oLogging.LogError()
        End If


        '--- Build screen
        If bDebug Then
            Me.tbl_error_occured.Visible = False
            Me.tbl_main.Visible = True
        Else
            Me.tbl_error_occured.Visible = True
            Me.tbl_main.Visible = False
        End If

        Me.txt_error_number.Text = System.Convert.ToString(Session("error").err_number)
        Me.txt_error_description.Text = Session("error").err_description()
        Me.txt_error_source.Text = Session("error").err_source
        Me.txt_error_module.Text = Session("error").app_module
        Me.txt_appcall.Text = Session("error").app_call

        cRoot = Application("config").domain + "/default.aspx"

    End Sub


    Private Sub btn_ok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_ok.Click
        Dim bError As Boolean = False

        Dim bDebug As Boolean = Application("config").debug

        '--- Log Error
        Dim oLogging As New ion_resources.cls_logging()
        oLogging.oerror = Session("error")
        oLogging.config = Application("config")
        oLogging.user = Session("user")
        oLogging.mode = 2 '--- Logging For Backoffice
        If bDebug Then
            oLogging.oerror.note = Me.txt_note.Text.Trim
            bError = oLogging.LogError()
        End If
        cRoot = Application("config").domain + "/default.aspx"

        Server.Transfer("/default.aspx")
    End Sub
End Class
