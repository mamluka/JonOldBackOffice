Imports System.Xml
Imports System.Data.SqlClient
Partial Class inventory_ajax
    Inherits System.Web.UI.Page

    Protected WithEvents hid_sql As System.Web.UI.WebControls.Label
    Public oSQLcmd1 As SqlCommand = New SqlCommand("", oConnection)
    Public oConnection As SqlClient.SqlConnection = New SqlClient.SqlConnection
    Public oDataAdapter1 As SqlDataAdapter = New SqlDataAdapter


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
        Response.ClearHeaders()
        Response.Clear()
        Response.ContentType = "text/xml"
        Response.Write("<?xml version='1.0' encoding='UTF-8'?>")

        Dim dhtmlgrid As New ion_two.cls_dhtmlgrid
        Dim ohtml As New iFunctions.cls_html

        Dim oTmpInventory As New ion_two.cls_inventory_lgc
        oTmpInventory._connection_string = Application("config").connection_string
        oTmpInventory._dbtype = Application("config").connection_string_type

        Dim opictures As New ion_two.cls_pictures

        opictures.load("http://www.twin-diamonds.com", "https://www.twin-diamonds.com")




        Dim array As New ArrayList

        '--- create connection
        oConnection.ConnectionString = Application("config").connection_string
        oConnection.Open()

        '--- set default listing size

        ''  Me.grd_items.PageSize = Application("defaults").inv_default_rows

        ''  lbl_inventory.Text = "Inventory"

        oDataAdapter1.TableMappings.Add("Table", "v_inventory_list")

        Dim qhash As New Hashtable
        For Each qs As String In Request.QueryString.Keys
            qhash.Add(qs, Request.QueryString(qs))
        Next


        oSQLcmd1.CommandText = Me.CreateSql(qhash)


        oSQLcmd1.CommandType = CommandType.Text

        oDataAdapter1.SelectCommand = oSQLcmd1
        Dim oDs As DataSet

        oDs = New DataSet("inventory")

        oDataAdapter1.Fill(oDs)

        If Not Request.QueryString("count") = "1" Then
            Dim page As Int32 = Request.QueryString("page")
            Dim pagestart As Int32
            Dim pageend As Int32

            pagestart = (page - 1) * 100
            pageend = pagestart + 100


            If pageend > oDs.Tables(0).Rows.Count Then
                pageend = oDs.Tables(0).Rows.Count - 1
            End If

            Dim ostringfunc As New iFunctions.cls_string
            Dim price As String

            Dim i As Int32
            For i = pagestart To pageend
                Dim array2 As New ArrayList
                ''icon
                Dim oPlate As New ion_two.skl_lst_inventory
                oTmpInventory.load(oDs.Tables(0).Rows(i)("id"), oPlate, opictures)

                If qhash.ContainsKey("pictures") Then
                    array2.Add("<img src='" + oPlate._icon_pic + "' ></img>")
                Else
                    array2.Add("<a href='javascript:void(0)' onclick=" + Chr(34) + "ListItems.HoverPicture('" + oPlate._icon_pic + "',this)" + Chr(34) + " /*onmouseout='ListItems.KillHoverPicture()'*/ >Icon</a> &nbsp;<a href='javascript:void(0)' onclick=" + Chr(34) + "ListItems.HoverPicture('" + oPlate._picture_pic + "',this)" + Chr(34) + " /*onmouseout='ListItems.KillHoverPicture()' */ >Pic</a>")
                End If
                array2.Add(Me.GetCheckIMGByBoolean(oPlate._active, "onclick=" + Chr(34) + "ListItems.ActivateItem(this," + oDs.Tables(0).Rows(i)("id").ToString + ")" + Chr(34) + " "))
                array2.Add(oPlate._itemnumber)
                array2.Add((oDs.Tables(0).Rows(i)("stonetype_long")))
                ''  array2.Add(oPlate._subplate._s_weight)
                array2.Add(FormatNumber(oDs.Tables(0).Rows(i)("weight"), 2, TriState.False, TriState.False, TriState.False))
                If oPlate._platetype = 3 Then
                    array2.Add("Gr.")
                Else
                    array2.Add("Ct.")
                End If
                ''   array2.Add((oDs.Tables(0).Rows(i)("weight")))
                array2.Add((oDs.Tables(0).Rows(i)("shape_long")))

                '' ostringfunc.format_currency()
                array2.Add(" " + FormatNumber(oPlate._sell_price, 2, TriState.False, TriState.False, TriState.False))
                array2.Add("$")
                array2.Add(Me.GetCheckIMGByBoolean(oPlate._onspecial))
                array2.Add("<a href='/inventory/edititem.aspx?mode=2&id=" + oplate._id.ToString + "'>Edit Item</a> | <a href='/ebay/twinlister.aspx?id=" + oplate._id.ToString + "'>Ebay</a> ")
                array.Add(array2)
            Next

            Response.Write(dhtmlgrid.CreateRowFromArrayList(array))
        Else
            Response.Write("<count>" + oDs.Tables(0).Rows.Count.ToString + "</count>")
        End If


        Response.End()

    End Sub

    Function CreateSql(ByVal qhash As Hashtable, Optional ByVal count As Boolean = False) As String
        Dim sql As String
        Dim andarray As New ArrayList

        ''If Not count Then
        sql += "select * from v_inventory_list"
        '' Else
        '' sql += "select count(id) as 'total' from v_inventory_list"
        '' End If

        If qhash.ContainsKey("itemnumber") Then
            Dim onumber As New ion_two.cls_itemnumber
            Dim supid, branchid, itemid As Int32
            Dim number As String = qhash("itemnumber")
            onumber.UnicodeItemNumber(qhash("itemnumber"), branchid, supid, itemid)
            If number.StartsWith("#") Then
                andarray.Add("BRANCHNUMBER = " + branchid.ToString + " and SUPPLIERNUMBER = " + supid.ToString)
            Else
                andarray.Add("BRANCHNUMBER = " + branchid.ToString + " and SUPPLIERNUMBER = " + supid.ToString + " and ITEMNUMBERINT =" + itemid.ToString)
            End If
        End If

        If qhash.ContainsKey("type") Then
            andarray.Add("stonetype_long = '" + qhash("type") + "'")
        End If

        If qhash.ContainsKey("supcode") Then
            andarray.Add("ITEMCODE  = '" + qhash("supcode") + "'")
        End If

        If qhash.ContainsKey("onspecial") Then
            andarray.Add("onspecial = " + qhash("onspecial") + "")
        End If

        If qhash.ContainsKey("active") Then
            andarray.Add("status = " + qhash("active") + "")
        End If

        If qhash.ContainsKey("shape") Then
            andarray.Add("shape_long = '" + qhash("shape") + "'")
        End If

        If qhash.ContainsKey("price") Then
            andarray.Add("sell_price BETWEEN  " + Split(qhash("price"), "to")(0) + " and " + Split(qhash("price"), "to")(1))
        End If

        If qhash.ContainsKey("weight") Then
            andarray.Add("weight BETWEEN  " + Split(qhash("weight"), "to")(0) + " and " + Split(qhash("weight"), "to")(1))
        End If



        Dim i As Int32
        If andarray.Count > 0 Then
            For i = 0 To andarray.Count - 1
                andarray(i) = "(" + andarray(i) + ")"
                ''andarray(andarray.IndexOf(wherepart)) = "(" + wherepart + ")"
            Next
            sql += " where " + Join(andarray.ToArray, " and ")
        End If

        sql += " order by id asc"

        Return sql
    End Function

    Function GetCheckIMGByBoolean(ByVal bool As Boolean, Optional ByVal onclick As String = "") As String
        If bool Then
            Return "<img src='/pic/newconst/inventory/base/checkmark.gif' " + onclick + " active='1' ></img>"

        Else
            Return "<img src='/pic/newconst/inventory/base/xmark.gif' " + onclick + " active='0' ></img>"
        End If
    End Function

End Class
