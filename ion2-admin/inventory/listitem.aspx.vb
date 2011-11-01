Imports System.Data.SqlClient

Partial Class listitem
    Inherits System.Web.UI.Page

    Protected WithEvents chk_special As System.Web.UI.WebControls.CheckBox

    Public oConnection As SqlClient.SqlConnection = New SqlClient.SqlConnection()
    Public oDataAdapter1 As SqlDataAdapter = New SqlDataAdapter()
    Public oSQLcmd1 As SqlCommand = New SqlCommand("", oConnection)
    Public nPage As Integer


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
        'Put user code to initialize the page here
        On Error GoTo ErrorHandler
        Dim bError As Boolean = False

        '--- Set culture of form
        System.Threading.Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.CreateSpecificCulture(Request.UserLanguages(0))
        System.Threading.Thread.CurrentThread.CurrentUICulture = New System.Globalization.CultureInfo(Request.UserLanguages(0))


        '--- Fill Combo
        If Not Page.IsPostBack Then
            bError = fill_stonetypecombo()
        End If

        If Me.hid_sql.Text = "" Then
            Me.hid_sql.Text = "select * from v_inventory_list order by id desc"
        End If


        '--- create connection
        oConnection.ConnectionString = Application("config").connection_string
        oConnection.Open()

        '--- set default listing size

        Me.grd_items.PageSize = Application("defaults").inv_default_rows

        lbl_inventory.Text = "Inventory"

        oDataAdapter1.TableMappings.Add("Table", "v_inventory_list")

        oSQLcmd1.CommandText = Me.hid_sql.Text
        oSQLcmd1.CommandType = CommandType.Text

        oDataAdapter1.SelectCommand = oSQLcmd1
        Dim oDs As DataSet
        oDs = New DataSet("inventory")

        oDataAdapter1.Fill(oDs)

        grd_items.DataSource = oDs
        grd_items.DataMember = "v_inventory_list"
        grd_items.DataBind()



        '--- set page for dataviewer
        If nPage > 0 And nPage < Me.grd_items.PageCount Then
            Me.grd_items.CurrentPageIndex = nPage
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
        Session("error").app_call = "listitem / PageLoad"
        Server.Transfer("/apperror.aspx")

    End Sub

    Private Sub grd_items_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles grd_items.PageIndexChanged
        grd_items.CurrentPageIndex = e.NewPageIndex
        grd_items.DataBind()
        'btn_search_Click(source, e)

    End Sub

    Private Sub grd_items_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grd_items.SelectedIndexChanged
        Dim oDataGridItem As DataGridItem = sender.selecteditem
        'oDataGridItem.Cells(0).Text()
    End Sub


    Sub Item_Created(ByVal sender As Object, ByVal e As DataGridItemEventArgs) Handles grd_items.ItemCreated


        If Not IsNothing(e.Item.DataItem) Then
            Dim chk_active As CheckBox = e.Item.FindControl("chk_active")

            chk_active.Attributes.Add("onclick", "ListItems.ActivateItemCheckBox(this," + e.Item.DataItem("id").ToString + ")")
            If e.Item.DataItem("status") = "1" Then
                chk_active.Checked = True



            End If
        End If

        If Not IsNothing(e.Item.DataItem) Then
            Dim chk_default As CheckBox = e.Item.FindControl("chk_default")

            chk_default.Attributes.Add("onclick", "ListItems.DefaultItemCheckBox(this," + e.Item.DataItem("id").ToString + ")")
            If e.Item.DataItem("default_model") = "1" Then
                chk_default.Checked = True



            End If
        End If


    End Sub 'Item_C

    Sub chk_active_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Dim box As CheckBox = sender
        Dim container As DataGridItem = box.NamingContainer



    End Sub
    Private Sub update_active_go_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles update_active_go.Click

    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        On Error GoTo ErrorHandler
        Dim bError As Boolean = False

        '--- declare error object to work with
        Dim oError As New cls_error

        '--- strip down ItemNumber
        Dim oTmpItemNumber As New ion_resources.cls_itemnumber
        Dim cErrorText, cSearchText As String
        oTmpItemNumber.itemnumber = Me.txt_itemnumber.Text
        bError = oTmpItemNumber.stripitemnumber(cErrorText, cSearchText)
        If bError Then
            Session("error").err_number = Err.Number
            Session("error").err_source = Err.Source
            Session("error").err_description = Err.Description
            '--- Our custom error
            Dim oTmpErrDB1 As New System.Diagnostics.StackFrame
            Session("error").app_module = Me.Request.CurrentExecutionFilePath
            Session("error").app_function = oTmpErrDB1.GetMethod.Name
            Session("error").app_call = "Button1_Click / ion_resources.cls_itemnumber"
            Server.Transfer("/apperror.aspx")
        End If

        '--- Create SQLceator object 
        Dim oTmpSql As New ion_resources.cls_inv_search
        oTmpSql.branch = oTmpItemNumber.branch
        oTmpSql.supplier = oTmpItemNumber.supplier
        oTmpSql.itemnumber = oTmpItemNumber.item
        oTmpSql.csstonetype = Me.cmb_csstonetype.SelectedItem.Text
        oTmpSql.stonetype = cmb_stonetype.SelectedItem.Text
        oTmpSql.itemcode = txt_itemcode.Text
        oTmpSql.defaults = Me.chk_defaults.Checked
        oTmpSql.onebay = Convert.ToInt16(Me.chk_onebay.Checked)
        oTmpSql.weight = System.Convert.ToDecimal(txt_weight.Text)

        If IsNumeric(Me.txt_weightto.Text) Then
            oTmpSql.weightto = System.Convert.ToDecimal(txt_weightto.Text)
        Else
            oTmpSql.weightto = System.Convert.ToDecimal(0)
        End If

        oTmpSql.active = cmb_active.SelectedItem.Value
        oTmpSql.special = cmb_special.SelectedItem.Value
        oTmpSql.stoneshape = Me.cmb_shape.SelectedItem.Text
        oTmpSql.create_sql()


        oTmpItemNumber = Nothing

        If Request.QueryString("tmpofficehack") = "1" Then
            Me.hid_sql.Text = "select * from v_inventory_list  where  DEALER_PRICE < SELL_PRICE*0.8"
        Else
            Me.hid_sql.Text = oTmpSql.sqlstring
        End If
        '' Dim lit As New Literal
        ''  lit.Text = oTmpSql.sqlstring
        ''  Me.Controls.Add(lit)
        '--- Define information to read
        Dim oTmpDataBroker As New iDac.cls_T_datareader
        oTmpDataBroker._dbtype = Application("config").connection_string_type
        oTmpDataBroker._connection_string = Application("config").connection_string
        oTmpDataBroker._table = "v_inventory_list"
        Dim cSQL As String
        Dim tmpSql As String
        cSQL = oTmpSql.sqlstring

        tmpSql = Mid(cSQL, InStr(cSQL, "where") + 5)

        cSQL = "select sum(weight) as total_w ,sum(purchase_price) as total_pp ,sum(sell_price) as total_sp from v_inventory_list where " + tmpSql.Replace(" order by id desc", "")


        '--- Define records
        Dim oField1 As New iDac.cls_cll_datareader
        oField1._field = "total_w"

        Dim oField2 As New iDac.cls_cll_datareader
        oField2._field = "total_pp"

        Dim oField3 As New iDac.cls_cll_datareader
        oField3._field = "total_sp"

        oTmpDataBroker._fields.Add(oField1)
        oTmpDataBroker._fields.Add(oField2)
        oTmpDataBroker._fields.Add(oField3)


        '--- Get info
        oTmpDataBroker.read(cSQL)


        '--- Fill results
        If oTmpDataBroker._hasresult Then
            Dim a, b, c As String
            Dim ostringfunc As New iFunctions.cls_string

            ''   ostringfunc.format_decimal(oTmpDataBroker._fields.Item(1)._result, a, " Ct.")
            ostringfunc.format_currency(oTmpDataBroker._fields.Item(2)._result, b, " $")
            ostringfunc.format_currency(oTmpDataBroker._fields.Item(3)._result, c, " $")

            ''   Me.total_w.Text = "Total Weight: <br>" + a
            Me.total_pp.Text = "Total Purchase Price: <br>" + b
            Me.total_sp.Text = "Total Sell Price: <br>" + c
            ''bExist = True
        End If

        '--- use connection
        oSQLcmd1.CommandText = Me.hid_sql.Text
        oSQLcmd1.CommandType = CommandType.Text
        oDataAdapter1.SelectCommand = oSQLcmd1

        Dim oDs As DataSet
        oDs = New DataSet("inventory")

        'oConnection.Open()
        oDataAdapter1.Fill(oDs)



        Me.grd_items.CurrentPageIndex = 0

        grd_items.DataSource = oDs
        grd_items.DataMember = "v_inventory_list"
        grd_items.DataBind()

        If Me.chk_icons.Checked Then
            Me.grd_items.Columns(0).Visible = True
        End If






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
        Session("error").app_call = "btn_file_report_delete_serverclick"
        Server.Transfer("/apperror.aspx")

    End Sub


    Private Function fill_stonetypecombo() As Boolean
        On Error GoTo ErrorHandler
        Dim bError As Boolean = False

        Dim oFillcombo As New cls_datareader
        Dim oError As New cls_error
        oFillcombo.config = Application("config")
        oFillcombo.oerror = oError

        '--- fill STONETYPE combo
        oFillcombo.combobox = Me.cmb_stonetype
        oFillcombo.sqlstring = "select id, lang" & Session("user").language & "_longdescr from inv_STONETYPE_DIAM order by sortorder"
        oFillcombo.showfield = "lang" & Session("user").language & "_longdescr"
        bError = oFillcombo.bind_combo()

        '--- fill STONETYPE combo
        oFillcombo.combobox = Me.cmb_stonetype
        oFillcombo.sqlstring = "select id, lang" & Session("user").language & "_longdescr from inv_stonetype_gem order by sortorder"
        oFillcombo.showfield = "lang" & Session("user").language & "_longdescr"
        bError = oFillcombo.fill_combo()

        '--- fill shape combo
        oFillcombo.combobox = Me.cmb_shape
        oFillcombo.sqlstring = "select id, lang" & Session("user").language & "_longdescr from inv_shape_diam order by sortorder"
        oFillcombo.showfield = "lang" & Session("user").language & "_longdescr"
        bError = oFillcombo.fill_combo()


        Dim oTmpCombo As New iFunctions.cls_combo
        oTmpCombo._connection_string = Application("config").connection_string
        oTmpCombo._dbtype = Application("config").connection_string_type

        '-- fill the c/s type combo
        oTmpCombo._combobox = Me.cmb_csstonetype
        oTmpCombo._sqlstring = "select id, lang" & Session("user").language & "_longdescr from inv_MIDDLESTONE_JEWEL order by sortorder"
        oTmpCombo._textfield = "lang" & Session("user").language & "_longdescr"
        oTmpCombo._valuefield = "id"
        oTmpCombo._addrow = ""
        bError = oTmpCombo.BindCombo()

        Me.cmb_csstonetype.Items.Add("Yellow Sapphire")
        Me.cmb_csstonetype.Items.Add("Pink Sapphire")

        '--- Add the Jewelry to the combo
        Me.cmb_stonetype.Items.Add("Jewelry")
        Me.cmb_stonetype.Items(Me.cmb_stonetype.Items.Count - 1).Value = Me.cmb_stonetype.Items.Count - 1
        Me.cmb_stonetype.SelectedIndex = Me.cmb_stonetype.Items.Count - 1

        '--- Add the N/A to the combo
        Me.cmb_stonetype.Items.Add("N/A")
        Me.cmb_stonetype.Items(Me.cmb_stonetype.Items.Count - 1).Value = Me.cmb_stonetype.Items.Count - 1
        Me.cmb_stonetype.SelectedIndex = Me.cmb_stonetype.Items.Count - 1

        oFillcombo = Nothing
        oError = Nothing

        '--- Enumarate combo
        Dim nLoop As Int32
        For nLoop = 0 To Me.cmb_stonetype.Items.Count - 1
            Me.cmb_stonetype.Items(nLoop).Value = nLoop
        Next

        Exit Function

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

    End Function



    Function GetIcon(ByVal icon_name As String, ByVal category_id As Int32)
        Dim oTmpInventory As New ion_two.cls_inventory_lgc
        oTmpInventory._connection_string = Application("config").connection_string
        oTmpInventory._dbtype = Application("config").connection_string_type

        Dim opictures As New ion_two.cls_pictures

        opictures.load("http://www.twin-diamonds.com", "https://www.twin-diamonds.com")

        Dim oPlate As New ion_two.skl_lst_inventory

        'oTmpInventory.load(id, oPlate, opictures)
        Dim ispic As Boolean
        opictures.format_picture(opictures, category_id, 1, icon_name, ispic)

        ''oDataTable._ssl_icon_pic = opictures._path_ssl

        'Dim imgurl As String = "http://www.twin-diamonds.com/precious-stones/"
        'Select Case platetype
        '    Case 1
        '        imgurl += "diamond"
        '    Case 2
        '        imgurl += "diamond"
        '    Case 3

        'End Select



        Return "<img src='" + opictures._result + "' />"

    End Function

    Private Sub btn_ebay_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_ebay.Click
        On Error GoTo ErrorHandler
        Dim bError As Boolean = False

        '--- declare error object to work with
        Dim oError As New cls_error

        '--- strip down ItemNumber
        Dim oTmpItemNumber As New ion_resources.cls_itemnumber
        Dim cErrorText, cSearchText As String
        oTmpItemNumber.itemnumber = Me.txt_itemnumber.Text
        bError = oTmpItemNumber.stripitemnumber(cErrorText, cSearchText)
        If bError Then
            Session("error").err_number = Err.Number
            Session("error").err_source = Err.Source
            Session("error").err_description = Err.Description
            '--- Our custom error
            Dim oTmpErrDB1 As New System.Diagnostics.StackFrame
            Session("error").app_module = Me.Request.CurrentExecutionFilePath
            Session("error").app_function = oTmpErrDB1.GetMethod.Name
            Session("error").app_call = "Button1_Click / ion_resources.cls_itemnumber"
            Server.Transfer("/apperror.aspx")
        End If



        '--- use connection
        oSQLcmd1.CommandText = Me.hid_sql.Text
        oSQLcmd1.CommandType = CommandType.Text
        oDataAdapter1.SelectCommand = oSQLcmd1

        Dim oDs As DataSet
        oDs = New DataSet("inventory")

        'oConnection.Open()
        oDataAdapter1.Fill(oDs)

        Server.Transfer("/ebay/twinlister.aspx?id=" + Convert.ToString(oDs.Tables(0).Rows(0).Item("id")))

        'Me.grd_items.CurrentPageIndex = 0

        'grd_items.DataSource = oDs
        'grd_items.DataMember = "v_inventory_list"
        'grd_items.DataBind()

        'If Me.chk_icons.Checked Then
        '    Me.grd_items.Columns(0).Visible = True
        'End If





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
End Class
