Partial Class link_exchange
    Inherits System.Web.UI.Page
    Public link_coll As New ArrayList

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
            Dim oTmpCombo As New iFunctions.cls_combo
            oTmpCombo._connection_string = Application("config").connection_string
            oTmpCombo._dbtype = Application("config").connection_string_type


            '--- fill shapeid
            oTmpCombo._combobox = Me.cat_select_add
            oTmpCombo._sqlstring = "select description,id from lnk_links_categories"
            oTmpCombo._textfield = "description"
            oTmpCombo._valuefield = "id"
            oTmpCombo._addrow = ""
            oTmpCombo.BindCombo()

            oTmpCombo._combobox = Me.cat_select_update
            oTmpCombo._sqlstring = "select description,id from lnk_links_categories"
            oTmpCombo._textfield = "description"
            oTmpCombo._valuefield = "id"
            oTmpCombo._addrow = ""
            oTmpCombo.BindCombo()
            If Request.QueryString("id") <> "" Then
                Dim tmpcoll As New ArrayList
                Dim linkid As Int32 = Request.QueryString("id")
                Me.load_table(tmpcoll, linkid)
                Me.txt_link_update.Text = tmpcoll(0).url
                Me.txt_body_update.Text = tmpcoll(0).html
                Me.cat_select_update.SelectedIndex = tmpcoll(0).cat_index - 1
            End If
            Me.load_table(Me.link_coll)
            ' Me.shape_select.SelectedIndex = 0
        End If



    End Sub

    Private Sub btn_Add_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Add.Click
        Dim osql As New iDac.cls_T_command
        osql._connection_string = Application("config").connection_string
        osql._dbtype = Application("config").connection_string_type
        osql._sqlstring = "insert into lnk_links values('" + Me.txt_body_Add.Text.Replace("'", "''") + "','" + Me.txt_link_add.Text + "'," + Me.cat_select_add.SelectedValue + ",1)"
        osql.transact_command()
        Me.load_table(Me.link_coll)
    End Sub
    Function load_table(ByRef coll As ArrayList, Optional ByVal id As Int32 = 0, Optional ByVal shapeid As Int32 = 0)
        Dim oDG_search As New iDac.cls_sql_read
        Dim sSql As String
        If id > 0 Then
            sSql = "select * from lnk_links  INNER JOIN lnk_LINKS_CATEGORIES ON lnk_links.category_id = lnk_LINKS_CATEGORIES.id where lnk_links.id = " + Convert.ToString(id)
        Else
            sSql = "select * from lnk_links  INNER JOIN lnk_LINKS_CATEGORIES ON lnk_links.category_id = lnk_LINKS_CATEGORIES.id"
        End If




        oDG_search._connection_string = Application("config").connection_string
        oDG_search._tablename = "lnk_links"


        oDG_search.transact_read(sSql)

        Dim i As Int32

        Dim oData As DataTable = oDG_search._datatable

        For i = 0 To oData.Rows.Count - 1

            Dim tmpItem As New link_obj
            With tmpItem
                .id = oData.Rows(i).Item("id")
                .html = oData.Rows(i).Item("code")
                .url = oData.Rows(i).Item("url")
                .cat_index = oData.Rows(i).Item("category_id")
                .formatted_cat = oData.Rows(i).Item("description")

            End With

            coll.Add(tmpItem)

        Next


    End Function
    Public Class link_obj
        Public html As String
        Public url As String
        Public id As Int32
        Public cat_index As Int32
        Public formatted_cat As String
    End Class

    Private Sub btn_update_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_update.Click
        Dim osql As New iDac.cls_T_command
        osql._connection_string = Application("config").connection_string
        osql._dbtype = Application("config").connection_string_type
        osql._sqlstring = "update lnk_links set code ='" + Me.txt_body_update.Text + "',url='" + Me.txt_link_update.Text + "',category_id=" + Me.cat_select_update.SelectedValue + " where id =" + Request.QueryString("id")
        osql.transact_command()
        Me.load_table(Me.link_coll)
    End Sub
End Class
