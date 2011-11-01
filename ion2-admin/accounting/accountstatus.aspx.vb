Imports System.Data.SqlClient

Partial Class accountstatus
    Inherits System.Web.UI.Page


#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()

        nId = Request.QueryString("id")

    End Sub

#End Region

    Public oConnection As SqlClient.SqlConnection = New SqlClient.SqlConnection()
    Public oDataAdapter1 As SqlDataAdapter = New SqlDataAdapter()
    Public oSQLcmd1 As SqlCommand = New SqlCommand("", oConnection)
    Public nId As Integer

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        On Error GoTo ErrorHandler
        Dim bError As Boolean = False

        '--- Set culture of form
        System.Threading.Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.CreateSpecificCulture(Request.UserLanguages(0))
        System.Threading.Thread.CurrentThread.CurrentUICulture = New System.Globalization.CultureInfo(Request.UserLanguages(0))

        '--- Get account total
        Dim nTmpTotal As Decimal
        Dim oTmpFunctionsAccounts As New ion_resources.cls_functions_accounting()
        oTmpFunctionsAccounts.connection_string = Application("config").connection_string
        bError = oTmpFunctionsAccounts.get_account_total(nId, nTmpTotal)
        Me.lbl_total.Text = Format(nTmpTotal, "##,##0.00") + " $us"


        '--- Get Account name
        Dim cAccountName As String
        bError = oTmpFunctionsAccounts.get_account_name(nId, cAccountName)
        Me.lbl_caption.Text = Me.lbl_caption.Text + " " + cAccountName

        oTmpFunctionsAccounts = Nothing



        '--- set default listing size
        Me.grd_items.PageSize = Application("defaults").inv_default_rows

        '--- create connection
        oConnection.ConnectionString = Application("config").connection_string
        oDataAdapter1.TableMappings.Add("Table", "v_general_books")

        oSQLcmd1.CommandText = "select * from v_general_books where account_id = " & nId
        oSQLcmd1.CommandType = CommandType.Text
        oDataAdapter1.SelectCommand = oSQLcmd1

        Dim oDs As DataSet
        oDs = New DataSet("accounts")

        oConnection.Open()
        oDataAdapter1.Fill(oDs)

        grd_items.DataSource = oDs
        grd_items.DataMember = "v_general_books"
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
        Session("error").app_call = "accountstatus / PageLoad"
        Server.Transfer("/apperror.aspx")

    End Sub

End Class
