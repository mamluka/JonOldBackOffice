
Public Class cls_stone_exchange
    Public SQLstring As String
    Public Conn_String As String
    Public SE_collection As New ArrayList
    Public picture_obj As ion_two.cls_pictures
    Public is_dealer As Boolean = False
    Public original_stone_id As Int32
    Public db_type As Int32

    ''this class allow to output the collection for the stone exhange table in jewelry    
    Public Function make_sql_str(ByVal stone_type As String, ByVal stone_shape As String, ByVal weight As Decimal, Optional ByVal PYS As Int32 = 0) As Boolean
        Select Case PYS '' select case to use pink/yellow sapphires

            Case 0
                Me.SQLstring = "select * from vv_gemstones_full where stonetype='" + stone_type + "' and shape = '" + stone_shape + "' and (weight between " + Convert.ToString(weight - 3) + " and " + Convert.ToString(weight + 3) + ") and (lower(subcategory_name) like '%loose%') and (itemdeleted = 0) and (qtyonstock_cur > 0) and (shopstatus = 1) and (sell_price > 0)"
            Case 1 '' pink
                Me.SQLstring = "select * from vv_gemstones_full where stonetype='" + stone_type + "' and shape = '" + stone_shape + "' and (weight between " + Convert.ToString(weight - 3) + " and " + Convert.ToString(weight + 3) + ") and lower(colorfrom) like '%pink%' and (itemdeleted = 0) and (lower(subcategory_name) like '%loose%') and (qtyonstock_cur > 0) and (shopstatus = 1) and (sell_price > 0)"
            Case 2 '' yellow
                Me.SQLstring = "select * from vv_gemstones_full where stonetype='" + stone_type + "' and shape = '" + stone_shape + "' and (weight between " + Convert.ToString(weight - 3) + " and " + Convert.ToString(weight + 3) + ") and lower(colorfrom) like '%yellow%' and (itemdeleted = 0) and (lower(subcategory_name) like '%loose%') and (qtyonstock_cur > 0) and (shopstatus = 1) and (sell_price > 0)"
        End Select
    End Function
    Public Function make_table()
        Dim oSQLRead As New iDac.cls_sql_read



        oSQLRead._connection_string = Me.Conn_String
        oSQLRead._tablename = "vv_gemstones_full"

        oSQLRead.transact_read(Me.SQLstring)

        Dim oData As DataTable = oSQLRead._datatable

        ''if stone is not active

        If oData.Rows.Count = 0 Then
            oSQLRead.transact_read("select * from vv_gemstones_full where id=" + Me.original_stone_id.ToString)
            oData = oSQLRead._datatable

        End If

        Dim i As Int32

        For i = 0 To oData.Rows.Count - 1
            Dim tmpItem As New se_item
            Dim oPrice As New ion_two.cons_price
            Dim ostringfunc As New iFunctions.cls_string
            ''   oPrice._isdealer = bIsdealer
            oPrice._sell_price = oData.Rows(i).Item("sell_price")
            oPrice._isspecial = oData.Rows(i).Item("onspecial")
            oPrice._special_from = oData.Rows(i).Item("onspecial_from_date")
            oPrice._special_to = oData.Rows(i).Item("onspecial_to_date")
            oPrice._dealer_price = oData.Rows(i).Item("dealer_price")
            oPrice._special_dealer_price = oData.Rows(i).Item("special_dealer_price")
            oPrice._special_sell_price = oData.Rows(i).Item("special_sell_price")
            oPrice.get_price()
            ''sets the format
            tmpItem.price = oPrice._correct_price



            tmpItem.id = oData.Rows(i).Item("id")
            tmpItem.weight = oData.Rows(i).Item("weight")

            Dim oPictures As ion_two.cls_pictures = Me.picture_obj

            oPictures.format_picture(oPictures, oData.Rows(i).Item("category_id"), 1, oData.Rows(i).Item("icon_name"), tmpItem.has_icon)

            tmpItem.icon_pic = oPictures._result

            ostringfunc.format_currency(tmpItem.price, tmpItem.price_formatted, " $")
            ostringfunc.format_decimal(tmpItem.weight, tmpItem.weight_formatted, " Ct.")

            If oData.Rows(i).Item("measure1") > 0 Or oData.Rows(i).Item("measure2") > 0 Then
                Dim tmpM1, tmpM2 As String
                If oData.Rows(i).Item("measure1") = 0 Then
                    ''account for round items
                    ostringfunc.format_decimal(oData.Rows(i).Item("measure2"), tmpM2)
                    tmpItem.size = tmpM2 + "x" + tmpM2
                Else
                    ostringfunc.format_decimal(oData.Rows(i).Item("measure1"), tmpM1)
                    ostringfunc.format_decimal(oData.Rows(i).Item("measure2"), tmpM2)
                    tmpItem.size = tmpM1 + "x" + tmpM2
                End If
            End If




            Dim ogem As New ion_two.cls_gemstone_lgc

            tmpItem.color = oData.Rows(i).Item("colorfrom")

            ogem.strimdash(tmpItem.color)

            Me.SE_collection.Add(tmpItem)
        Next
    End Function
    Public Function load_stone_exchange_byid(ByVal id As Int32, ByRef stone_Type As String, ByRef stone_shape As String, ByRef stone_weight As Decimal, ByRef stone_color As String, ByRef stone_price As Decimal)

        Dim oTmpInventory As New ion_two.cls_inventory_lgc
        oTmpInventory._connection_string = Me.Conn_String
        oTmpInventory._dbtype = Me.db_type
        ''oTmpInventory._dbtype = Application("connection")._connection_string_type
        Dim oPlate As New ion_two.skl_lst_inventory
        ''  Dim oextra As New ion_two.cls_jewerly_extra


        oTmpInventory.load(id, oPlate, Me.picture_obj, Me.is_dealer)

        stone_shape = oPlate._subplate._shape
        stone_Type = oPlate._subplate._stonetype
        stone_color = oPlate._subplate._colorfrom
        stone_weight = oPlate._subplate._weight

        Dim ostringfunc As New iFunctions.cls_string
        ostringfunc.deformat_currency(oPlate._pricing._line3txt, stone_price)


        'oextra.get_stone_extended_string(oPlate._subplate._stone_extended)

        'Stone_ext.c_cut = oextra.c_cut
        'Stone_ext.c_desc = oextra.c_desc
        'Stone_ext.c_type = oextra.c_type

        'Stone_ext.s_cut = oextra.s_cut
        'Stone_ext.s_desc = oextra.s_desc
        'Stone_ext.s_type = oextra.s_type

        ''      stone_type = oplate.

        oTmpInventory = Nothing
        ''  oextra = Nothing
        oPlate = Nothing


    End Function
    Public Function load_stone_exchange_byid(ByVal id As Int32, ByRef stone_price As Decimal)

        Dim oTmpInventory As New ion_two.cls_inventory_lgc
        oTmpInventory._connection_string = Me.Conn_String
        oTmpInventory._dbtype = Me.db_type
        ''oTmpInventory._dbtype = Application("connection")._connection_string_type
        Dim oPlate As New ion_two.skl_lst_inventory
        ''  Dim oextra As New ion_two.cls_jewerly_extra


        oTmpInventory.load(id, oPlate, Me.picture_obj, Me.is_dealer)


        Dim ostringfunc As New iFunctions.cls_string
        ostringfunc.deformat_currency(oPlate._pricing._correct_price, stone_price)


        'oextra.get_stone_extended_string(oPlate._subplate._stone_extended)

        'Stone_ext.c_cut = oextra.c_cut
        'Stone_ext.c_desc = oextra.c_desc
        'Stone_ext.c_type = oextra.c_type

        'Stone_ext.s_cut = oextra.s_cut
        'Stone_ext.s_desc = oextra.s_desc
        'Stone_ext.s_type = oextra.s_type

        ''      stone_type = oplate.

        oTmpInventory = Nothing
        ''  oextra = Nothing
        oPlate = Nothing


    End Function
    Private Class se_item
        Public price As Decimal
        Public price_formatted As String
        Public icon_pic As String
        Public id As Int32
        Public weight As Decimal
        Public weight_formatted As String
        Public has_icon As Boolean
        Public size As String
        Public color As String
    End Class

End Class
Public Class cls_stone_exchange_ajax
    Public csid As Int32
    Public itemid As Int32
    Public item_price As Decimal
    Public stone_desc As String
End Class
