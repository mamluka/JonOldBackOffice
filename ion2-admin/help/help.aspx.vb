Partial Class help
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

    Public cText As String

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'On Error GoTo ErrorHandler
        Dim bError As Boolean = False

        '--- Set culture of form
        System.Threading.Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.CreateSpecificCulture(Request.UserLanguages(0))
        System.Threading.Thread.CurrentThread.CurrentUICulture = New System.Globalization.CultureInfo(Request.UserLanguages(0))


        Dim nHelpId As Int32 = Request.QueryString("id")
        Dim cKeyWord As String
        Dim cHelpHeader As String
        Dim cHelpContent As String

        bError = get_help(nHelpId, cKeyWord, cHelpHeader, cHelpContent)
        If bError Then
            '--- when object is called in external DLL
            Session("error").err_number = Err.Number
            Session("error").err_source = Err.Source
            Session("error").err_description = Err.Description
            '--- Our custom error
            Dim oTmpDB1 As New System.Diagnostics.StackFrame()
            Session("error").app_module = Me.Request.CurrentExecutionFilePath
            Session("error").app_function = oTmpDB1.GetMethod.Name
            Session("error").app_call = "page_load / help.aspx"
            Server.Transfer("/apperror.aspx")
        End If


        If nHelpId > 0 Then
            Me.lbl_header.Text = cHelpHeader
            cText = cHelpContent
            Me.div_text.InnerHtml = cHelpContent

        Else
            Me.lbl_header.Text = "No help availiable !"

        End If
        Exit Sub

ErrorHandler:
        '--- when object is called in external DLL
        Session("error").err_number = Err.Number
        Session("error").err_source = Err.Source
        Session("error").err_description = Err.Description
        '--- Our custom error
        Dim oTmpDB As New System.Diagnostics.StackFrame()
        Session("error").app_module = Me.Request.CurrentExecutionFilePath
        Session("error").app_function = oTmpDB.GetMethod.Name
        Session("error").app_call = "page_load / help.aspx"
        Server.Transfer("/apperror.aspx")

    End Sub


    Private Function get_help(ByVal nHelpId As Int32, ByVal cKeyWord As String, ByRef cHelpHeader As String, ByRef cHelpContent As String) As Boolean
        On Error GoTo ErrorHandler

        '--- Define local vars
        Dim bError As Boolean = False

        '--- Define Connection String
        Dim bConnection_open As Boolean = False
        Dim bDatareader_open As Boolean = False
        Dim cSQL As String
        cSQL = "select keyword, help_header, help_text from sys_help where ID =" & nHelpId
        Dim objConn As New SqlClient.SqlConnection(Application("config").connection_string)
        Dim cSQLstring As SqlClient.SqlCommand = New SqlClient.SqlCommand(cSQL, objConn)
        objConn.Open()
        bConnection_open = True

        Dim dr_Reader As SqlClient.SqlDataReader = cSQLstring.ExecuteReader()
        bDatareader_open = True

        While dr_Reader.Read()
            cKeyWord = dr_Reader.Item("keyword")
            cHelpHeader = Left(dr_Reader.Item("help_header"), 40)
            cHelpContent = dr_Reader.Item("help_text")
        End While

        objConn.Close()
        dr_Reader.Close()

        Return False
        Exit Function

ErrorHandler:
        If bDatareader_open Then
            dr_Reader.Close()
        End If
        If bConnection_open Then
            objConn.Close()
        End If

        '--- register the error
        Session("error").err_number = Err.Number
        Session("error").err_source = Err.Source
        Session("error").err_description = Err.Description
        '--- Our custom error
        Dim oTmpDB As New System.Diagnostics.StackFrame()
        Session("error").app_module = Me.Request.CurrentExecutionFilePath
        Session("error").app_function = oTmpDB.GetMethod.Name
        Session("error").app_call = "get_help / help.aspx"
        Return True

    End Function


End Class
