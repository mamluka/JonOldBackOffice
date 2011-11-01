Imports System.Data.SqlClient

Partial Class list_cashflow
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

    Public oConnection As SqlClient.SqlConnection = New SqlClient.SqlConnection()
    Public oDataAdapter1 As SqlDataAdapter = New SqlDataAdapter()
    Public oSQLcmd1 As SqlCommand = New SqlCommand("", oConnection)
    Public oDate As New ion_resources.cls_date()

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        On Error GoTo ErrorHandler
        Dim bError As Boolean = False

        '--- initiate search
        If Not Page.IsPostBack Then

            Me.cmb_date.Items.Clear()
            Dim nLoop As Int16
            For nLoop = 1 To oDate.text.Count
                Dim oItem As New System.Web.UI.WebControls.ListItem()
                oItem.Text = oDate.text.Item(nLoop).text
                oItem.Value = oDate.text.Item(nLoop).value
                Me.cmb_date.Items.Add(oItem)
                oItem = Nothing
            Next
        End If

        '--- set default listing size
        Me.grd_cashflow.PageSize = 20

        '--- create connection
        oConnection.ConnectionString = Application("config").connection_string
        oDataAdapter1.TableMappings.Add("Table", "v_cashflow")

        oSQLcmd1.CommandText = "select * from v_cashflow where master = 0 order by payment_date desc"
        oSQLcmd1.CommandType = CommandType.Text
        oDataAdapter1.SelectCommand = oSQLcmd1

        Dim oDs As DataSet
        oDs = New DataSet("reports")

        oConnection.Open()
        oDataAdapter1.Fill(oDs)



        grd_cashflow.DataSource = oDs
        grd_cashflow.DataMember = "v_cashflow"
        If oDs.Tables(0).Rows.Count > 0 Then
            grd_cashflow.DataBind()
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
        Session("error").app_call = "Page_load"
        Server.Transfer("/apperror.aspx")

    End Sub

    Private Sub grd_cashflow_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles grd_cashflow.PageIndexChanged
        grd_cashflow.CurrentPageIndex = e.NewPageIndex
        grd_cashflow.DataBind()

    End Sub


    Private Sub btn_search_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_search.Click
        On Error GoTo ErrorHandler
        Dim bError As Boolean = False


        '--- construct SQL
        Dim cSQL As String = "select * from v_cashflow where id > 0 "

        If Me.txt_order.Text <> "" Then
            cSQL = cSQL + "and order_number =" + Me.txt_order.Text.Trim
        End If

        If Me.txt_email.Text <> "" Then
            cSQL = cSQL + "and customer like '" + txt_email.Text.Trim + "%'"
        End If

        If Me.cmb_date.SelectedItem.Value > 0 Then
            bError = oDate.getdate(Me.cmb_date.SelectedItem.Value)
            cSQL = cSQL + "and payment_date BETWEEN '" + oDate.fromdate + "' AND '" + oDate.todate + "'"
        End If


        cSQL = cSQL + " order by payment_date desc"

        '--- use connection
        oSQLcmd1.CommandText = cSQL
        oSQLcmd1.CommandType = CommandType.Text
        oDataAdapter1.SelectCommand = oSQLcmd1

        Dim oDs As DataSet
        oDs = New DataSet("cashflow")

        oDataAdapter1.Fill(oDs)

        grd_cashflow.DataSource = oDs
        grd_cashflow.DataMember = "v_cashflow"
        grd_cashflow.DataBind()

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
        Session("error").app_call = "btn_search_click"
        Server.Transfer("/apperror.aspx")

    End Sub

    Private Sub grd_cashflow_DataBinding(ByVal sender As Object, ByVal e As System.EventArgs) Handles grd_cashflow.DataBinding
        Dim oDataTable As DataTable = sender.datasource.tables("v_cashflow")
        Dim nLoop As Int32

        'For nLoop = 0 To oDataTable.Rows.Count

        If oDataTable.Rows(nLoop).ItemArray(6) = "1" Then
            'oDataTable.Rows(nLoop).ItemArray(6) = "+"
        End If
        'Next
        IIf(nLoop = 0, "+", "")



    End Sub

    Private Sub grd_cashflow_ItemCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles grd_cashflow.ItemCreated
        On Error GoTo ErrorHandler
        Dim bError As Boolean = False

        'If e.Item.ItemIndex >= 0 Then
        'If Not IsNothing(e.Item.DataItem) Then
        '--- Get Current row
        '	Dim oTmpItemArray As Array = e.Item.DataItem.row.itemarray

        '	If oTmpItemArray(6) = "1" Then
        '		oTmpItemArray(6) = "+"
        '	End If

        'End If
        'End If
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
        Session("error").app_call = "listitem"
        Server.Transfer("/apperror.aspx")

    End Sub
End Class
