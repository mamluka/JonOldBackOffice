Partial Class editsidestones
    Inherits System.Web.UI.Page
    Public table_coll As New ArrayList
    Public edit_html As String = "none"
    Public edit_desc As String
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
        Dim id As Int32 = Convert.ToInt32(Request.QueryString("id"))
        If Not Page.IsPostBack Then
            Dim oTmpCombo As New iFunctions.cls_combo
            oTmpCombo._connection_string = Application("config").connection_string
            oTmpCombo._dbtype = Application("config").connection_string_type


            '--- fill shapeid
            oTmpCombo._combobox = Me.shape_select
            oTmpCombo._sqlstring = "select id,logicalorder, lang" & Session("user").language & "_longdescr from inv_SIDESTONE_SHAPE " ''where jeweltype_id= " & nSubType & " order by sortorder"
            oTmpCombo._textfield = "lang" & Session("user").language & "_longdescr"
            oTmpCombo._valuefield = "logicalorder"
            oTmpCombo._addrow = ""
            oTmpCombo.BindCombo()
            Me.shape_select.SelectedIndex = 0

            Select Case Request.QueryString("action")
                Case "edit"
                    Me.edit_html = "inline"
                    Dim tmpColl As New ArrayList
                    Me.load_table(tmpColl, id)
                    If tmpColl.Count > 0 Then
                        Me.edit_desc = "Now edit " + tmpColl(0).shape + " weighting: " + tmpColl(0).weight
                        Me.edit_price.Text = Convert.ToString(tmpColl(0).price)
                        Me.edit_size.Text = tmpColl(0).size

                        Me.load_table(Me.table_coll, , tmpColl(0).shapeid)
                        Me.shape_select.SelectedIndex = Me.shape_select.Items.IndexOf(Me.shape_select.Items.FindByValue(Convert.ToString(tmpColl(0).shapeid)))
                    End If

                Case "delete"
                    Me.delete_byid()
                Case Else
                    Me.load_table(Me.table_coll, , Me.shape_select.SelectedValue)
            End Select

        End If



    End Sub
    Function load_table(ByRef coll As ArrayList, Optional ByVal id As Int32 = 0, Optional ByVal shapeid As Int32 = 0)
        Dim oDG_search As New iDac.cls_sql_read
        Dim sSql As String
        If id > 0 Then
            sSql = "select * from inv_std_pricing_pairs where id = " + Convert.ToString(id)
        Else
            sSql = "select * from inv_std_pricing_pairs "
        End If

        If shapeid > 0 Then
            sSql += " where shapeid = " + Convert.ToString(shapeid) + " order by weight"
        End If
        '' Dim ssql = "exec usp_displayallusers ''"




        oDG_search._connection_string = Application("config").connection_string
        oDG_search._tablename = "inv_std_pricing_pairs"


        oDG_search.transact_read(sSql)

        Dim i As Int32

        Dim oData As DataTable = oDG_search._datatable

        For i = 0 To oData.Rows.Count - 1

            Dim tmpItem As New ss_item
            With tmpItem
                .id = oData.Rows(i).Item("id")
                .price = Math.Round(oData.Rows(i).Item("price"))

                .weight = Convert.ToString(oData.Rows(i).Item("weight")) + " Ct."
                .size = oData.Rows(i).Item("stone_size")
                .shapeid = oData.Rows(i).Item("shapeid")
                .total = Convert.ToString(Math.Round(oData.Rows(i).Item("weight") * 2 * .price))
                ''     .total2 = Math.Round(oldprice * 0.8).total
                Dim oshape As New ion_two.cls_shape

                oshape.getshape_byid(oData.Rows(i).Item("shapeid"), .shape)

            End With

            coll.Add(tmpItem)

        Next


    End Function
    Private Sub Go_Save_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles go_save.Click
        Dim price As String
        If Me.edit_price2.Text <> "" Then
            price = Convert.ToDecimal(Me.edit_price2.Text) * 1.25
        Else
            price = Me.edit_price.Text
        End If
        Dim osql As New iDac.cls_T_command
        osql._connection_string = Application("config").connection_string
        osql._dbtype = Application("config").connection_string_type
        osql._sqlstring = "update inv_std_pricing_pairs set stone_size='" + Me.edit_size.Text + "', price = " + price + " where id=" + Request.QueryString("id")
        osql.transact_command()
        Me.load_table(Me.table_coll, , Me.shape_select.SelectedValue)

    End Sub
    Function delete_byid()
        Dim osql As New iDac.cls_T_command
        osql._connection_string = Application("config").connection_string
        osql._dbtype = Application("config").connection_string_type
        osql._sqlstring = "delete from inv_std_pricing_pairs where id=" + Request.QueryString("id")
        osql.transact_command()
    End Function

    Private Sub shape_select_change(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles shape_select.SelectedIndexChanged
        Me.load_table(Me.table_coll, , Convert.ToInt32(Me.shape_select.SelectedValue))
    End Sub
    Class ss_item
        Public id As Int32
        Public price As Decimal
        Public price2 As Decimal
        Public weight As String
        Public size As String
        Public shape As String
        Public total As String
        Public total2 As String
        Public shapeid As Int32
    End Class
End Class
