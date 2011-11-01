Partial Class currency_rates
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

        Me.txt_date.Text = Date.Today

    End Sub

    Private Sub btn_submit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_submit.Click
        On Error GoTo ErrorHandler
        Dim bError As Boolean = False

        Dim oTmpFunctions As New ion_resources.cls_functions_accounting()
        oTmpFunctions.connection_string = Application("config").connection_string
        bError = oTmpFunctions.set_rate(1, Convert.ToDateTime(Me.txt_date.Text), Convert.ToDecimal(Me.txt_amount.Text))
        If bError Then
            '--- when object is called in external DLL
            Session("error").err_number = oTmpFunctions.error_number
            Session("error").err_source = oTmpFunctions.error_source
            Session("error").err_description = oTmpFunctions.error_description
            '--- Our custom error
            Dim oTmpDB As New System.Diagnostics.StackFrame()
            Session("error").app_module = Me.Request.CurrentExecutionFilePath
            Session("error").app_function = oTmpDB.GetMethod.Name
            Session("error").app_call = "ion_resources.cls_functions_accounting"
            Server.Transfer("/apperror.aspx")
        End If

        oTmpFunctions = Nothing


        Server.Transfer("/default.aspx")
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
        Session("error").app_call = "Page_Load"
        Server.Transfer("/apperror.aspx")
    End Sub


End Class
