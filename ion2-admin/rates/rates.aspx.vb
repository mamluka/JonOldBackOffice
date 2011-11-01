Imports System.Data.SqlClient
Partial Class rates
    Inherits System.Web.UI.Page
    Public oConnection As SqlClient.SqlConnection = New SqlClient.SqlConnection
    Public oDataAdapter1 As SqlDataAdapter = New SqlDataAdapter
    Public oSQLcmd1 As SqlCommand = New SqlCommand("", oConnection)



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
        'Put user code to initialize the page here
        System.Threading.Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.CreateSpecificCulture(Request.UserLanguages(0))
        System.Threading.Thread.CurrentThread.CurrentUICulture = New System.Globalization.CultureInfo(Request.UserLanguages(0))
        '--- create connection
        oConnection.ConnectionString = Application("config").connection_string
        oDataAdapter1.TableMappings.Add("Table", "acc_RATES")

        oSQLcmd1.CommandText = "select * from acc_rates order by id"
        oSQLcmd1.CommandType = CommandType.Text
        oDataAdapter1.SelectCommand = oSQLcmd1

        Dim oDs As DataSet
        oDs = New DataSet("rates")

        oConnection.Open()
        oDataAdapter1.Fill(oDs)

        grd_items.DataSource = oDs
        grd_items.DataMember = "acc_rates"

        grd_items.DataBind()

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim bError As Boolean = False
        Dim oTmpRateLogics As New ion_two.cls_rates_lgc
        oTmpRateLogics._connection_string = Application("config").connection_string
        oTmpRateLogics._dbtype = Application("config").connection_string_type

        Dim oTmpRate As New ion_two.skl_rates
        oTmpRate._name = name_txt.Text
        oTmpRate._code = code_txt.text
        oTmpRate._value = Convert.ToDecimal(value_txt.text)



        bError = oTmpRateLogics.insert(oTmpRate)
        If bError Then
            Session("o_error")._Err_Number = oTmpRateLogics._err_number
            Session("o_error")._Err_Description = oTmpRateLogics._err_description
            Session("o_error")._Err_Source = oTmpRateLogics._err_source
            Session("o_error")._Err_Module = Me.Request.CurrentExecutionFilePath
            Session("o_error")._Err_Call = "btn_add_Click [ion_two.cls_rate_lgc:insert]"
            Server.Transfer("/aspxerror.aspx")
        End If
        Session("message").returnpath = "/default.aspx"

    End Sub
End Class
