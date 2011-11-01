Imports System.Data.SqlClient

Partial Class list_orders
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

        oConnection.ConnectionString = Application("config").connection_string
        oDataAdapter1.TableMappings.Add("Table", "v_orders_list")


        '--- set default listing size
        Me.grd_orders.PageSize = 50

        '--- create connection




        Select Case Me.sortorder.SelectedValue
            Case "1"
                oSQLcmd1.CommandText = "select * from v_orders_list order by customeremail"
            Case "2"
                oSQLcmd1.CommandText = "select * from v_orders_list order by sts_curr_stat desc"
            Case "3"
                oSQLcmd1.CommandText = "select * from v_orders_list order by customername"
            Case Else
                oSQLcmd1.CommandText = "select * from v_orders_list order by orderdate desc"
        End Select


        oSQLcmd1.CommandType = CommandType.Text
        oDataAdapter1.SelectCommand = oSQLcmd1

        Dim oDs As DataSet
        oDs = New DataSet("orders")

        oConnection.Open()
        oDataAdapter1.Fill(oDs)

        grd_orders.DataSource = oDs
        grd_orders.DataMember = "v_orders_list"
        grd_orders.DataBind()



    End Sub

    Private Sub grd_orders_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles grd_orders.PageIndexChanged
        grd_orders.CurrentPageIndex = e.NewPageIndex
        grd_orders.DataBind()

    End Sub

    Private Sub btn_search_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_search.Click
        On Error GoTo ErrorHandler
        Dim bError As Boolean = False

        '--- declare error object to work with
        Dim oError As New cls_error

        '--- Create SQLceator object 
        Dim oTmpSql As New ion_resources.cls_ord_search
        If IsNumeric(Me.txt_invoice.Text) Then
            oTmpSql.invoice = System.Convert.ToInt32(Me.txt_invoice.Text)
        End If
        If IsNumeric(Me.txt_order.Text) Then
            oTmpSql.order = System.Convert.ToInt32(Me.txt_order.Text)
        End If
        oTmpSql.email = Me.txt_email.Text
        oTmpSql.sort = Me.sortorder.SelectedValue
        oTmpSql.create_sql()

        '--- use connection
        oSQLcmd1.CommandText = oTmpSql.sqlstring
        oSQLcmd1.CommandType = CommandType.Text
        oDataAdapter1.SelectCommand = oSQLcmd1

        Dim oDs As DataSet
        oDs = New DataSet("orders")

        oDataAdapter1.Fill(oDs)

        grd_orders.DataSource = oDs
        grd_orders.DataMember = "v_orders_list"
        grd_orders.DataBind()

        oTmpSql = Nothing

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
        Session("error").app_call = "btn_search_click"
        Server.Transfer("/apperror.aspx")

    End Sub

    Private Sub grd_orders_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles grd_orders.SelectedIndexChanged

    End Sub

    Private Sub sortorder_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SortOrder.SelectedIndexChanged
        '        On Error GoTo ErrorHandler
        '        Dim bError As Boolean = False

        '        '--- declare error object to work with
        '        Dim oError As New cls_error

        '        '--- Create SQLceator object 
        '        Dim oTmpSql As New ion_resources.cls_ord_search
        '        If IsNumeric(Me.txt_invoice.Text) Then
        '            oTmpSql.invoice = System.Convert.ToInt32(Me.txt_invoice.Text)
        '        End If
        '        If IsNumeric(Me.txt_order.Text) Then
        '            oTmpSql.order = System.Convert.ToInt32(Me.txt_order.Text)
        '        End If
        '        oTmpSql.sort = Me.sortorder.SelectedValue
        '        oTmpSql.email = Me.txt_email.Text
        '        oTmpSql.create_sql()

        '        '--- use connection
        '        oSQLcmd1.CommandText = oTmpSql.sqlstring
        '        oSQLcmd1.CommandType = CommandType.Text
        '        oDataAdapter1.SelectCommand = oSQLcmd1

        '        Dim oDs As DataSet
        '        oDs = New DataSet("orders")

        '        oDataAdapter1.Fill(oDs)

        '        grd_orders.DataSource = oDs
        '        grd_orders.DataMember = "v_orders_list"
        '        grd_orders.DataBind()

        '        oTmpSql = Nothing

        '        Exit Sub

        'ErrorHandler:
        '        '--- when object is called in external DLL
        '        Session("error").err_number = Err.Number
        '        Session("error").err_source = Err.Source
        '        Session("error").err_description = Err.Description
        '        '--- Custom error
        '        Dim oTmpErrDB As New System.Diagnostics.StackFrame
        '        Session("error").app_module = Me.Request.CurrentExecutionFilePath
        '        Session("error").app_function = oTmpErrDB.GetMethod.Name
        '        Session("error").app_call = "btn_search_click"
        '        Server.Transfer("/apperror.aspx")
    End Sub
End Class
