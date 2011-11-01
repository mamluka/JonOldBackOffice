Public Class cls_stonesphere
    Public conn_string As String
    Public db_type As String
    Public pictures As ion_two.cls_pictures
    Public Function GetStoneByItem(ByVal id As Int32, ByRef stone_coll As ArrayList) As Boolean
        Dim oTmpInventory As New ion_two.cls_inventory_lgc
        oTmpInventory._connection_string = Me.conn_string
        oTmpInventory._dbtype = Me.db_type
        Dim oPlate As New ion_two.skl_lst_inventory
        oTmpInventory.load(id, oPlate, Me.pictures)

        Dim weight As String = Convert.ToDecimal(oPlate._subplate._weight)

        Dim sqllow = "select top 3 * from vv_gemstones_full where stonetype like '" + oPlate._subplate._stonetype + "' and  (subcategory_name like '%loose%' ) and (weight > " + weight + "*0.9 and weight <=" + weight + " ) and (itemdeleted = 0) and (qtyonstock_cur > 0) and (shopstatus = 1) and (sell_price > 0) and ( id != " + oPlate._id.ToString + " ) order by weight desc"
        Dim sqlhigh = "select top 3 * from vv_gemstones_full where stonetype like '" + oPlate._subplate._stonetype + "' and  (subcategory_name like '%loose%' ) and (weight < " + weight + "*1.1 and weight >=" + weight + " ) and (itemdeleted = 0) and (qtyonstock_cur > 0) and (shopstatus = 1) and (sell_price > 0) and ( id != " + oPlate._id.ToString + " ) order by weight desc"

        Dim osql As New iDac.cls_sql_read

        Dim hash As New Hashtable
        Dim sSql As String
        '' Dim ssql = "exec usp_displayallusers ''"
        Dim ostringfunc As New iFunctions.cls_string



        osql._connection_string = Me.conn_string
        osql._tablename = "vv_gemstones_full"


        osql.transact_read(sqllow)

        Dim oData As DataTable = osql._datatable

        Dim opicture As New ion_two.cls_pictures
        '' Dim ostringfunc As New iFunctions.cls_string

        For Each row As System.Data.DataRow In oData.Rows

            Dim oitem As New StoneSphereAtom

            opicture.format_picture(Me.pictures, row.Item("category_id"), 1, row.Item("icon_name"), oitem.has_pic)

            oitem.icon_pic = Me.pictures._result

            ostringfunc.format_currency(row.Item("sell_price"), oitem.price_formatted, "$")

            ostringfunc.format_decimal(row.Item("weight"), oitem.weight_formatted, " Ct.")

            oitem.id = row.Item("id")

            stone_coll.Add(oitem)

        Next



        osql.transact_read(sqlhigh)

        oData = osql._datatable


        '' Dim ostringfunc As New iFunctions.cls_string

        For Each row As System.Data.DataRow In oData.Rows

            Dim oitem As New StoneSphereAtom

            opicture.format_picture(Me.pictures, row.Item("category_id"), 1, row.Item("icon_name"), oitem.has_pic)

            oitem.icon_pic = opicture._result

            ostringfunc.format_currency(row.Item("sell_price"), oitem.price_formatted, "$")

            ostringfunc.format_decimal(row.Item("weight"), oitem.weight_formatted, " Ct.")

            oitem.id = row.Item("id")

            stone_coll.Add(oitem)

        Next

    End Function
    Public Class StoneSphereAtom
        Public icon_pic As String
        Public weight_formatted As String
        Public id As Int32
        Public price_formatted As String
        Public has_pic As Boolean


    End Class
End Class
