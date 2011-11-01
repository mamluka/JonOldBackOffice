Partial Class aspxerror
    Inherits iFoundation.wsc_page

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
        '--- Set defaults

        '--- Set Screen
        If Application("config")._debug Then
            Me.tbl_long_error.Visible = True
            Me.tbl_short_error.Visible = False

            '--- Load Fields
            Me.lbl2_error_number.Text = Session("o_error")._Err_Number
            Me.lbl2_error_number.Text = Session("o_error")._Err_Number
            Me.lbl2_error_description.Text = Session("o_error")._Err_Description
            Me.lbl2_error_source.Text = Session("o_error")._Err_Source
            Me.lbl2_appcall.Text = Session("o_error")._Err_Call
            Me.lbl2_error_module.Text = Session("o_error")._Err_Module
            'Me.lbl2_function.Text = Session("o_error")._Err_Function

        Else
            Me.tbl_long_error.Visible = False
            Me.tbl_short_error.Visible = True
        End If


    End Sub

    Private Function LogError() As Boolean
        On Error GoTo ErrorHandler
        Dim bError As Boolean = False


        Dim oTmpLogging As New iLogging.cls_error_logging_lgc
        oTmpLogging._connection_string = Application("config")._connection_logging
        oTmpLogging._dbtype = Application("config")._connection_logging_type
        oTmpLogging._TableName = "log_ERROR"

        '--- Add user infomation
        Dim oLog As New iLogging.skl_error_logging
        oLog._User_id = Session("user")._id
        oLog._user_ip = Session("user")._ip
        oLog._SessionId = Session("user")._sessionid
        oLog._LogTime = Date.Now
        oLog._Note = Me.txt_note.Text
        oLog._Err_Version = Application("config")._version

        Dim oTmpStackFrame As New System.Diagnostics.StackFrame
        oLog._Framework = oTmpStackFrame.GetMethod.ReflectedType.Assembly.ImageRuntimeVersion
        oLog._DLLstat = oTmpStackFrame.GetMethod.ReflectedType.AssemblyQualifiedName

        '--- Log
        bError = oTmpLogging.insert(oLog)
        If bError Then
            Me._err_number = oTmpLogging._err_number
            Me._err_description = oTmpLogging._err_description
            Me._err_source = oTmpLogging._err_source
        End If

        '--- Clear
        oLog = Nothing
        oTmpStackFrame = Nothing

        Exit Function

ErrorHandler:
        Me._err_number = Err.Number
        Me._err_description = Err.Description
        Me._err_source = Err.Source

    End Function

    Private Sub btn_gomain_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_gomain.Click
        Server.Transfer("default.aspx")
    End Sub

    Private Sub btn_ok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_ok.Click
        On Error GoTo ErrorHandler
        Dim bError As Boolean = False

        '--- Don't log here
        Server.Transfer("default.aspx")


        'bError = Me.LogError
        'If bError Then

        'End If
        'Server.Transfer("frm_main.aspx")

        Exit Sub

ErrorHandler:
        Me._err_number = Err.Number
        Me._err_description = Err.Description
        Me._err_source = Err.Source

    End Sub


End Class
