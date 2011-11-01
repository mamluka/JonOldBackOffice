Partial Class groups
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
        'Dim osql As New iDac.cls_T_command
        'osql._dbtype = Me.db_type
        'osql._connection_string = Me.conn_string
        'osql._sqlstring = "update acc_cashflow set approved =" + Convert.ToString(Convert.ToByte(cc_status)) + " where master = 1 and order_id =" + Convert.ToString(order_id)
        'osql.transact_command()

        If Not Page.IsPostBack Then
            Dim ogroups As New ion_two.cls_groups
            ogroups.conn_string = Application("config").connection_string
            ogroups.LoadGroupList(Me.lst_group.Items)
            ''   ogroups.LoadItemsByGroupKey(Me.lst_group.Items(0).Value, Me.lst_item.Items)
        End If


    End Sub




    Private Sub btn_addgroup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_addgroup.Click


        '' Me.lst_group.Items.Add(New System.Web.UI.WebControls.ListItem(Me.txt_addgroup.Text, Me.txt_groupkey.Text))

        Dim osql As New iDac.cls_T_command
        osql._dbtype = Application("config").connection_string_type
        osql._connection_string = Application("config").connection_string
        osql._sqlstring = "insert into sys_groups (group_name,group_key,group_items) values ('" + Me.txt_addgroup.Text + "','" + Me.txt_groupkey.Text + "','')"
        osql.transact_command()

        Me.LoadGroups()

    End Sub


    Private Sub btn_deletegroup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_deletegroup.Click
        Dim osql As New iDac.cls_T_command
        osql._dbtype = Application("config").connection_string_type
        osql._connection_string = Application("config").connection_string
        osql._sqlstring = "delete from sys_groups where group_key = '" + Me.lst_group.SelectedValue + "'"
        osql.transact_command()

        Me.LoadGroups()
    End Sub
    Public Function LoadGroups() As Boolean

        Dim ogroups As New ion_two.cls_groups
        ogroups.conn_string = Application("config").connection_string
        Me.lst_group.Items.Clear()
        ogroups.LoadGroupList(Me.lst_group.Items)

    End Function

    Private Sub btn_editgroup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_editgroup.Click
        Dim ogroups As New ion_two.cls_groups
        ogroups.conn_string = Application("config").connection_string
        Me.lst_item.Items.Clear()
        ogroups.LoadItemsByGroupKey(Me.lst_group.SelectedValue, Me.lst_item.Items)

        Me.lst_group.Enabled = False
        Me.btn_addgroup.Enabled = False


    End Sub

    Private Sub btn_additem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_additem.Click

        Dim onumber As New ion_two.cls_itemnumber
        onumber._connection_string = Application("config").connection_string
        onumber._dbtype = Application("config").connection_string_type
        Dim itemid As Int32
        Dim errorstr As String
        onumber.getid_fromnumber(Me.txt_additem.Text, itemid, errorstr)

        If itemid > 0 Then
            Me.lst_item.Items.Add(New WebControls.ListItem(Me.txt_additem.Text, itemid.ToString))
        End If




    End Sub

    Private Sub btn_itemsdone_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_itemsdone.Click

        Dim tmparray As New ArrayList
        For Each item As WebControls.ListItem In Me.lst_item.Items
            tmparray.Add(item.Text + "::" + item.Value)
        Next


        Dim osql As New iDac.cls_T_command
        osql._dbtype = Application("config").connection_string_type
        osql._connection_string = Application("config").connection_string
        Me.Label3.Text = "update sys_groups set group_items = '" + Join(tmparray.ToArray, "|") + "' where group_key = '" + Me.lst_group.SelectedValue + "'"
        osql._sqlstring = "update sys_groups set group_items = '" + Join(tmparray.ToArray, "|") + "' where group_key = '" + Me.lst_group.SelectedValue + "'"
        osql.transact_command()

        Me.lst_group.Enabled = True
        Me.btn_addgroup.Enabled = True

    End Sub

    Private Sub btn_deleteitem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_deleteitem.Click
        Me.lst_item.Items.Remove(Me.lst_item.SelectedItem)
    End Sub


    Private Sub lst_item_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lst_item.SelectedIndexChanged

    End Sub
End Class
