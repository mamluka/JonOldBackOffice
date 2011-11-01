Imports System.Data.SqlClient

Partial Class listcustomers
    Inherits System.Web.UI.Page

    Public oConnection As SqlClient.SqlConnection = New SqlClient.SqlConnection()
    Public oDataAdapter1 As SqlDataAdapter = New SqlDataAdapter()
    Public oSQLcmd1 As SqlCommand = New SqlCommand("", oConnection)


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
        On Error GoTo ErrorHandler
        Dim bError As Boolean = False

        '--- Set culture of form
        System.Threading.Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.CreateSpecificCulture(Request.UserLanguages(0))
        System.Threading.Thread.CurrentThread.CurrentUICulture = New System.Globalization.CultureInfo(Request.UserLanguages(0))

        'Me.grd_items.Items

        '--- set default listing size
        Me.grd_items.PageSize = Application("defaults").inv_default_rows

        '--- create connection
        oConnection.ConnectionString = Application("config").connection_string
        oDataAdapter1.TableMappings.Add("Table", "v_customers")

        oSQLcmd1.CommandText = "select * from v_customers order by id desc"
        oSQLcmd1.CommandType = CommandType.Text
        oDataAdapter1.SelectCommand = oSQLcmd1

        Dim oDs As DataSet
        oDs = New DataSet("customers")

        oConnection.Open()
        oDataAdapter1.Fill(oDs)

        grd_items.DataSource = oDs
        grd_items.DataMember = "v_customers"
        grd_items.DataBind()

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
        grd_items.DataBind()

    End Sub

    Private Sub btn_search_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_search.Click
        On Error GoTo ErrorHandler
        Dim bError As Boolean = False
        Dim cSQL As String = "select * from v_customers where id > 0 "

        If txt_email.Text.Trim <> "" Then
            cSQL = cSQL + "and email like '" + txt_email.Text.Trim + "%'"
        End If

        If txt_firstname.Text.Trim <> "" Then
            cSQL = cSQL + "and firstname like '" + txt_firstname.Text.Trim + "%'"
        End If

        If txt_lastname.Text.Trim <> "" Then
            cSQL = cSQL + "and lastname like '" + txt_lastname.Text.Trim + "%'"
        End If

        If chk_dealers.Checked Then
            cSQL = cSQL + "and dealer = 1"
        End If

        cSQL = cSQL + " order by email, firstname, lastname"

        '--- use connection
        oSQLcmd1.CommandText = cSQL
        oSQLcmd1.CommandType = CommandType.Text
        oDataAdapter1.SelectCommand = oSQLcmd1

        Dim oDs As DataSet
        oDs = New DataSet("customers")

        oDataAdapter1.Fill(oDs)

        grd_items.DataSource = oDs
        grd_items.DataMember = "v_customers"
        grd_items.DataBind()

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
        Session("error").app_call = "btn_file_report_delete_serverclick"
        Server.Transfer("/apperror.aspx")
    End Sub


End Class
