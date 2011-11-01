Partial Class test_mail
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
    End Sub

    Private Sub btn_send_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_send.Click
        On Error GoTo ErrorHandler
        Dim bError As Boolean = False

        '--- Send Email
        Dim oMail As New ion_resources.cls_simplemail()
        oMail.content = "Tesing email  " + Convert.ToString(Now)
        oMail.from = "admin@twin-diamonds.com"
        oMail.mailto = "peled@ion-software.com"
        oMail.contenttype = 1
        bError = oMail.send()
        If bError Then
            Me.lbl_result.Text = "Error occured: " + Convert.ToString(oMail.error_number) + "><+ oMail.error_description"
        Else
            Me.lbl_result.Text = "No error occured, email away !"
        End If


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
        Session("error").app_call = "btn_save_click"
        Server.Transfer("/apperror.aspx")

    End Sub
End Class
