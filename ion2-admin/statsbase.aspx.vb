Imports System.Data.SqlClient

Partial Class statsbase
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

    Public oConnection As SqlClient.SqlConnection = New SqlClient.SqlConnection
    Public oDataAdapter1 As SqlDataAdapter = New SqlDataAdapter()
    Public oSQLcmd1 As SqlCommand = New SqlCommand("", oConnection)


    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        On Error GoTo ErrorHandler
        Dim bError As Boolean = False

        '--- Set culture of form
        System.Threading.Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.CreateSpecificCulture(Request.UserLanguages(0))
        System.Threading.Thread.CurrentThread.CurrentUICulture = New System.Globalization.CultureInfo(Request.UserLanguages(0))


        '--- Fill Combo
        If Not Page.IsPostBack Then
            If Me.grd_items.CurrentPageIndex > 0 Then
                Me.grd_items.CurrentPageIndex = 1
            End If

            Me.hid_table.Text = "-"
        End If


        Exit Sub

ErrorHandler:
        '--- when object is called in external DLL
        Session("error").err_number = Err.Number
        Session("error").err_source = Err.Source
        Session("error").err_description = Err.Description
        '--- Our custom error
        Dim oTmpErrDB As New System.Diagnostics.StackFrame()
        Session("error").app_module = Me.Request.CurrentExecutionFilePath
        Session("error").app_function = oTmpErrDB.GetMethod.Name
        Session("error").app_call = "listcustomers / PageLoad"
        Server.Transfer("/apperror.aspx")

    End Sub

    Private Sub grd_items_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles grd_items.PageIndexChanged
        grd_items.CurrentPageIndex = e.NewPageIndex
        Try
            grd_items.DataBind()
        Catch ex As Exception

        End Try

        'grd_items.CurrentPageIndex = e.NewPageIndex
        'grd_items.DataBind()

        Dim args As New System.EventArgs
        Me.btn_search_Click(Me.btn_search, args)

    End Sub

    Private Sub btn_search_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_search.Click
        On Error GoTo ErrorHandler
        Dim bError As Boolean = False

        If Me.hid_table.Text = "-" Then
            Exit Sub
        End If

        Dim cSQL As String
        cSQL = "select * from " + Me.hid_table.Text + " where clienthost like '" + Trim(Me.cmb_enginetype.SelectedItem.Text) + "' order by logtime"

        '--- set default listing size
        Me.grd_items.PageSize = 50

        '--- create connection
        oConnection.ConnectionString = Application("config").connection_mainlog
        oDataAdapter1.TableMappings.Add("Table", Me.hid_table.Text)

        oSQLcmd1.CommandText = cSQL
        oSQLcmd1.CommandType = CommandType.Text
        oDataAdapter1.SelectCommand = oSQLcmd1

        Dim oDs As DataSet
        oDs = New DataSet("sessions")

        oConnection.Open()
        oDataAdapter1.Fill(oDs)

        grd_items.DataSource = oDs
        grd_items.DataMember = Me.hid_table.Text
        grd_items.DataBind()

        If Me.chk_resolve.Checked Then
            If Len(Me.cmb_enginetype.SelectedItem.Text) > 1 Then
                bError = resolve_link(Trim(Me.cmb_enginetype.SelectedItem.Text), Me.lbl_resolve.Text)
            End If
        End If

        Exit Sub

ErrorHandler:
        '--- when object is called in external DLL
        Session("error").err_number = Err.Number
        Session("error").err_source = Err.Source
        Session("error").err_description = Err.Description
        '--- Our custom error
        Dim oTmpErrDB As New System.Diagnostics.StackFrame
        Session("error").app_module = Me.Request.CurrentExecutionFilePath
        Session("error").app_function = oTmpErrDB.GetMethod.Name
        Session("error").app_call = "listcustomers / PageLoad"
        Server.Transfer("/apperror.aspx")

    End Sub

    Private Function fill_enginetype(ByVal cTable As String) As Boolean
        On Error GoTo ErrorHandler
        Dim bError As Boolean = False

        '--- Define Connection String
        Dim cSQL As String = "select distinct clienthost from " + cTable + " where target like '/robots.txt'"
        Dim bConnection_open As Boolean = False
        Dim bDatareader_open As Boolean = False
        Dim objConn As New SqlClient.SqlConnection(Application("config").connection_mainlog)
        Dim cSQLstring As SqlClient.SqlCommand = New SqlClient.SqlCommand(cSQL, objConn)
        objConn.Open()
        bConnection_open = True

        Dim dr_Reader As SqlClient.SqlDataReader = cSQLstring.ExecuteReader()
        bDatareader_open = True

        If dr_Reader.HasRows Then
            Me.cmb_enginetype.Items.Clear()
            Me.cmb_enginetype.DataSource = dr_Reader
            Me.cmb_enginetype.DataTextField = "clienthost"
            Me.cmb_enginetype.DataValueField = "clienthost"
            Me.cmb_enginetype.DataBind()
        Else
            Me.cmb_enginetype.Items.Clear()
            Me.cmb_enginetype.Items.Add("No Rows found!")
        End If

        'Me.grd_items.PageCount
        If Me.grd_items.CurrentPageIndex > 0 Then
            Me.grd_items.CurrentPageIndex = 1
            grd_items.DataBind()
        End If

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

        '--- when object is called in external DLL
        Session("error").err_number = Err.Number
        Session("error").err_source = Err.Source
        Session("error").err_description = Err.Description
        '--- Custom error
        Dim oTmpErrDB As New System.Diagnostics.StackFrame
        Session("error").app_module = Me.Request.CurrentExecutionFilePath
        Session("error").app_function = oTmpErrDB.GetMethod.Name
        Session("error").app_call = "btn_file_report_delete_serverclick"
        Server.Transfer("/apperror.aspx")

    End Function

    Private Sub cmb_site_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmb_site.SelectedIndexChanged
        On Error GoTo ErrorHandler
        Dim bError As Boolean = False

        Select Case LCase(Me.cmb_site.SelectedItem.Text)
            Case "ben-yair.com"
                Me.hid_table.Text = "log_BEN_YAIR"

            Case "default"
                Me.hid_table.Text = "log_DEFAULT"

            Case "twin-diamonds.com"
                Me.hid_table.Text = "log_TWIN_WEB"

            Case "twin-diamonds - redirects"
                Me.hid_table.Text = "log_TWIN_REDIRECTS"

            Case "gem-resource.com"
                Me.hid_table.Text = "log_GEM_RESOURCE"

            Case "ion-integrations.com"
                Me.hid_table.Text = "log_ION"

            Case "-"
                Me.hid_table.Text = "-"

        End Select

        If Me.hid_table.Text <> "-" Then
            bError = fill_enginetype(Me.hid_table.Text)
        End If

        Exit Sub


ErrorHandler:
        '--- when object is called in external DLL
        Session("error").err_number = Err.Number
        Session("error").err_source = Err.Source
        Session("error").err_description = Err.Description
        '--- Custom error
        Dim oTmpErrDB As New System.Diagnostics.StackFrame
        Session("error").app_module = Me.Request.CurrentExecutionFilePath
        Session("error").app_function = oTmpErrDB.GetMethod.Name
        Session("error").app_call = "btn_file_report_delete_serverclick"
        Server.Transfer("/apperror.aspx")

    End Sub
    Private Function resolve_link(ByVal cIP As String, ByRef cUrl As String) As Boolean

        Try
            Dim oHostInfo As System.Net.IPHostEntry = System.Net.Dns.GetHostByAddress(cIP)
            cUrl = oHostInfo.AddressList(0).ToString

        Catch e As Exception
            'Me.resolve_error = e.Message
            cUrl = e.Message

        End Try

        cUrl = "[" + cUrl + "]"

        Return False
    End Function

End Class
