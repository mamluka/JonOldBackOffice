Partial Class addhelp
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


    Public nMode As Int16
    Public nHelp_id As Int32


    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        On Error GoTo ErrorHandler
        Dim bError As Boolean = False

        '--- Set culture of form
        System.Threading.Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.CreateSpecificCulture(Request.UserLanguages(0))
        System.Threading.Thread.CurrentThread.CurrentUICulture = New System.Globalization.CultureInfo(Request.UserLanguages(0))


        If Request.QueryString("mode") = 1 Then '--- ADD
            nMode = 1
            Me.lbl_caption.Text = "Add Help"

        ElseIf Request.QueryString("mode") = 2 Then '--- EDIT
            nMode = 2
            Me.lbl_caption.Text = "Edit/Change Help"
            Me.txt_keyword.Enabled = False

            '--- Get Id
            nHelp_id = Request.QueryString("id")
            If nHelp_id = 0 Then
                Exit Sub
            End If

            '--- Load Company
            If Not Page.IsPostBack Then
                Dim oHelp As New ion_resources.cls_help()
                Dim oTmpBroker As New ion_resources.cls_help_lgc()
                oTmpBroker.connection_string = Application("config").connection_string
                bError = oTmpBroker.getrec(nHelp_id, oHelp)
                If bError Then
                    '--- when object is called in external DLL
                    Session("error").err_number = Err.Number
                    Session("error").err_source = Err.Source
                    Session("error").err_description = Err.Description
                    '--- Custom error
                    Dim oTmpErrDB1 As New System.Diagnostics.StackFrame()
                    Session("error").app_module = Me.Request.CurrentExecutionFilePath
                    Session("error").app_function = oTmpErrDB1.GetMethod.Name
                    Session("error").app_call = "ion_dbengine.cls_company_lgc"
                    Server.Transfer("/apperror.aspx")
                End If

                Me.txt_id.Text = oHelp.id
                Me.txt_keyword.Text = oHelp.keyword
                Me.txt_header.Text = oHelp.help_header
                Me.txt_text.Text = oHelp.text
            End If
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
        Session("error").app_call = "Page_Init"
        Server.Transfer("/apperror.aspx")

    End Sub

    Private Sub save_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles save.Click
        On Error GoTo ErrorHandler
        Dim bError As Boolean = False

        Select Case nMode
            Case 1   '--- ADD
                Dim oHelp As New ion_resources.cls_help()

                oHelp.keyword = Me.txt_keyword.Text
                oHelp.help_header = Me.txt_header.Text
                oHelp.text = Me.txt_text.Text

                Dim oBroker As New ion_resources.cls_help_lgc()
                oBroker.connection_string = Application("config").connection_string
                bError = oBroker.insert(oHelp)
                If bError Then
                    '--- when object is called in external DLL
                    Session("error").err_number = Err.Number
                    Session("error").err_source = Err.Source
                    Session("error").err_description = Err.Description
                    '--- Custom error
                    Dim oTmpErrDB1 As New System.Diagnostics.StackFrame()
                    Session("error").app_module = Me.Request.CurrentExecutionFilePath
                    Session("error").app_function = oTmpErrDB1.GetMethod.Name
                    Session("error").app_call = "ion_dbengine.cls_user_lgc"
                    Server.Transfer("/apperror.aspx")
                End If

                Session("message").listbox.items.add("+ Help line has been saved No: " + Convert.ToString(oBroker.id))
                Session("message").returnpath = "/help/listhelp.aspx"
                Server.Transfer("/message.aspx")

            Case 2   '--- Edit

                '--- Load Company
                Dim oHelp As New ion_resources.cls_help()
                Dim oTmpBroker As New ion_resources.cls_help_lgc()
                oTmpBroker.connection_string = Application("config").connection_string
                bError = oTmpBroker.getrec(nHelp_id, oHelp)
                If bError Then
                    '--- when object is called in external DLL
                    Session("error").err_number = Err.Number
                    Session("error").err_source = Err.Source
                    Session("error").err_description = Err.Description
                    '--- Custom error
                    Dim oTmpErrDB1 As New System.Diagnostics.StackFrame()
                    Session("error").app_module = Me.Request.CurrentExecutionFilePath
                    Session("error").app_function = oTmpErrDB1.GetMethod.Name
                    Session("error").app_call = "ion_dbengine.cls_user_lgc"
                    Server.Transfer("/apperror.aspx")
                End If

                '--- Replace Values
                oHelp.keyword = Me.txt_keyword.Text
                oHelp.help_header = Me.txt_header.Text
                oHelp.text = Me.txt_text.Text


                '--- Update 
                Dim oBroker As New ion_resources.cls_help_lgc()
                oBroker.connection_string = Application("config").connection_string
                bError = oBroker.update(oHelp)
                If bError Then
                    '--- when object is called in external DLL
                    Session("error").err_number = Err.Number
                    Session("error").err_source = Err.Source
                    Session("error").err_description = Err.Description
                    '--- Custom error
                    Dim oTmpErrDB1 As New System.Diagnostics.StackFrame()
                    Session("error").app_module = Me.Request.CurrentExecutionFilePath
                    Session("error").app_function = oTmpErrDB1.GetMethod.Name
                    Session("error").app_call = "ion_dbengine.cls_user_lgc"
                    Server.Transfer("/apperror.aspx")
                End If

                Session("message").listbox.items.add("+ Help line has been saved No: " + Convert.ToString(oHelp.id))
                Session("message").returnpath = "/help/listhelp.aspx"
                Server.Transfer("/message.aspx")

        End Select
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
        Session("error").app_call = "Page_Init"
        Server.Transfer("/apperror.aspx")

    End Sub

End Class
