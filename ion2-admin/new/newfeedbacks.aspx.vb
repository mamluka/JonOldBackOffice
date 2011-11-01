Partial Class newfeedbacks
    Inherits System.Web.UI.Page

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
        If Not Page.IsPostBack Then
            Dim oFillcombo As New cls_datareader
            Dim oError As New cls_error
            oFillcombo.config = Application("config")
            oFillcombo.oerror = oError

            oFillcombo.combobox = Me.cmd_country
            oFillcombo.sqlstring = "select id, lang" & Session("user").language & "_longdescr from sys_COUNTRY order by lang" & Session("user").language & "_longdescr"
            oFillcombo.showfield = "lang" & Session("user").language & "_longdescr"
            oFillcombo.bind_combo()
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim oTmpDataset As DataSet = New ds_feedbacks
        Dim oTmpDataTable As DataTable = oTmpDataset.Tables("usr_new_feedback")

        '--- Assign Order
        Dim oTmpDataRow As DataRow
        oTmpDataRow = oTmpDataTable.NewRow

        Dim onumber As New ion_two.cls_itemnumber
        Dim itemid As Int32
        Dim errorstr As String
        onumber._connection_string = Application("config").connection_string
        onumber._dbtype = Application("config").connection_string_type
        onumber.getid_fromnumber(Me.txt_itemnumber.Text, itemid, errorstr)

        'oTmpDataRow("id") = oDataTable._id
        oTmpDataRow("item_id") = itemid
        oTmpDataRow("platetype") = Convert.ToInt32(Me.cmd_platetype.SelectedValue)
        oTmpDataRow("name") = Me.txt_name.Text

        oTmpDataRow("text") = Me.txt_text.Text
        oTmpDataRow("title") = Me.txt_title.Text
        oTmpDataRow("country") = Convert.ToInt32(Me.cmd_country.SelectedValue)
        oTmpDataRow("rating") = Convert.ToDecimal(Me.txt_rating.Text)
        oTmpDataRow("textdate") = Me.txt_date.Text
        oTmpDataRow("adddate") = Date.Now

        oTmpDataTable.Rows.Add(oTmpDataRow)

        Dim oTransaction As New iDac.cls_T_transaction
        oTransaction._connection_string = Application("config").connection_string
        oTransaction._dbtype = Application("config").connection_string_type
        oTransaction.start()



        Dim oTransactor_2 As New iDac.cls_T_transactor
        oTransactor_2._connection_string = Application("config").connection_string
        oTransactor_2._dbtype = Application("config").connection_string_type



        Dim oTable2 As New iDac.cls_cll_datatables
        oTable2._datatable = oTmpDataTable
        oTransactor_2._i_cll_datatables.Add(oTable2)

        '--- Assign the transaction to the transactor
        oTransactor_2._transaction = oTransaction._transaction

        '--- Write Table
        oTransactor_2.transact_insert()



        oTransaction.close()


        '### End transaction

        oTransactor_2 = Nothing
        oTransaction = Nothing

        Me.txt_date.Text = ""
        Me.txt_itemnumber.Text = ""
        Me.txt_rating.Text = ""
        Me.txt_text.Text = ""
        Me.txt_title.Text = ""
        Me.cmd_country.SelectedIndex = 0
        Me.cmd_platetype.SelectedIndex = 0

        '--- Assign datatable
        ''Me._datatable = oTmpDataTable
    End Sub

    Private Sub DropDownList1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub
End Class
