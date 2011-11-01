Public Class cls_ajax_maketable

    Inherits iFoundation.cls_error_connection
    Public conn_string As String
    Public sqlstr As String
    Public opictures As New ion_two.cls_pictures
    Public total_items_found As Int32
    Public min_price As Int32
    Public max_price As Int32
    Public min_weight As Decimal
    Public max_weight As Decimal
    Public sort As String = "sell_price"
    Public sort_direction As String = "desc"

    Function make_sql_str(ByVal s_type As Int32, ByVal color_genre As Int32, ByVal color_index As Int32, ByVal s_shape_str As ArrayList, ByVal minp As String, ByVal maxp As String, ByVal minw As String, ByVal maxw As String)

        sqlstr = "select * from vv_gemstones_full where (platetype = 2) and (subcategory_id = 11 or subcategory_id = 16 or subcategory_id = 21 ) and "

        Select Case s_type
            Case 1 ''emerald
                sqlstr += " (stonetype like '%Emerald%' ) and "
            Case 2 '' sapphre
                sqlstr += " (stonetype like  '%Sapphire%') and ( colorfrom not like '%Pink%' ) and ( colorfrom not like '%Yellow%' ) and"
            Case 3 '' pink s
                sqlstr += " (stonetype like  '%Sapphire%') and ( colorfrom like '%Pink%' ) and "
            Case 4
                sqlstr += " (stonetype like  '%Sapphire%' ) and ( colorfrom like '%Yellow%' ) and "
            Case 5
                sqlstr += " (stonetype like '%Ruby%') and "
        End Select

        ''add shape
        Dim i As Int32



        If Not s_shape_str.Item(0) = "Any Shape" Then
            sqlstr += "("
            For i = 0 To s_shape_str.Count - 1
                If i = s_shape_str.Count - 1 Then
                    sqlstr += "( shape = '" + s_shape_str.Item(i) + "' )) and  "
                Else
                    sqlstr += "( shape = '" + s_shape_str.Item(i) + "' ) or "
                End If

            Next
        Else '' only use 8 shapes that we like
            sqlstr += "((shape like 'Heart Shape Cut') or (shape like 'Emerald Cut') or (shape like 'Oval Cut') or (shape like 'Pear Cut') or (shape like 'Radiant Cut') or (shape like 'Round Cut') or (shape like 'Marquise Cut') or (shape like 'Cushion Cut')) and"
        End If


        ''add price
        If minp > 0 Then
            sqlstr += "( sell_price between " + minp + " and " + maxp + " ) and "
        End If
        If minw > 0 Then
            sqlstr += "( weight between " + minw + " and " + maxw + " ) and "
        End If





        If (color_index <> 0) And (color_index <> 7) Then

            Dim ocolor As New ion_two.cls_gem_color
            ocolor.conn_string = Me.conn_string
            ocolor.language = "1"
            ocolor.getcolor_byid(s_type, color_genre, color_index)

            sqlstr += ocolor.color_str

        ElseIf color_index = 7 Then
            sqlstr += "(grade like 'Top of the line') and "
        End If



        sqlstr += "(itemdeleted = 0) and (qtyonstock_cur > 0) and (shopstatus = 1) and (sell_price > 0) and (weight < 30) and (sell_price < 20000 ) order by " + Me.sort + " " + Me.sort_direction

    End Function

    Function make_table(ByVal count As Int32, ByVal posstart As Int32, ByRef rTableColl As Collection)
        On Error GoTo ErrorHandler
        Dim bError As Boolean = False


        Dim oDG_search As New iDac.cls_sql_read

        oDG_search._connection_string = Me.conn_string '' Application("connection")._connection_string
        oDG_search._tablename = "vv_gemstones_full"

        oDG_search.transact_read(Me.sqlstr)

        Dim oData As DataTable = oDG_search._datatable

        Me.total_items_found = oData.Rows.Count

        If (oData.Rows.Count - posstart) < count Then
            count = oData.Rows.Count - posstart
        End If

        If count = 0 Then count = Me.total_items_found

        Dim i As Int32


        For i = posstart To count + posstart - 1

            Dim tmpTableItem As New ion_two.cls_ajax_cs_tablemember




            opictures.format_picture(opictures, oData.Rows(i).Item("category_id"), 1, oData.Rows(i).Item("icon_name"), tmpTableItem.has_icon)

            tmpTableItem.icon_pic = opictures._result

            tmpTableItem.id = oData.Rows(i).Item("id")
            tmpTableItem.color = oData.Rows(i).Item("colorfrom")
            tmpTableItem.item_number = oData.Rows(i).Item("itemnumber")
            tmpTableItem.price = oData.Rows(i).Item("sell_price")
            tmpTableItem.shape = oData.Rows(i).Item("shape")
            tmpTableItem.type = oData.Rows(i).Item("stonetype")
            tmpTableItem.weight = oData.Rows(i).Item("weight")

            ''extra non db
            Dim ostringfunc As New iFunctions.cls_string
            If (InStr(tmpTableItem.color, "-", CompareMethod.Text) > 0) And (tmpTableItem.color.Length > 3) Then
                tmpTableItem.color = Mid(tmpTableItem.color, 1, InStr(tmpTableItem.color, " -", CompareMethod.Text))
            ElseIf tmpTableItem.color.Length = 3 Then
                tmpTableItem.color = "No color specified"
            End If
            ostringfunc.format_currency(Convert.ToString(tmpTableItem.price), tmpTableItem.price_formatted, "$")
            ''= Convert.ToString(tmpTableItem.price) + "$"
            tmpTableItem.weight_formatted = Convert.ToString(Format(tmpTableItem.weight, "##0.00")) + " Ct."


            ''set max min price


            rTableColl.Add(tmpTableItem)
        Next

        'Dim tmpMinP, tmpMaxP As Decimal

        'tmpMinP = rTableColl.Item(1).price

        'tmpMaxP = rTableColl.Item(1).price

        'If rTableColl.Count > 1 Then
        '    For i = 2 To rTableColl.Count
        '        If rTableColl.Item(i).price > tmpMaxP Then tmpMaxP = rTableColl.Item(i).price
        '        If rTableColl.Item(i).price < tmpMinP Then tmpMinP = rTableColl.Item(i).price
        '    Next
        'End If

        'Me.max_price = Convert.ToInt32((tmpMaxP \ 100) * 100)
        'Me.min_price = Convert.ToInt32((tmpMinP \ 100) * 100)


        'Dim tmpMinW, tmpMaxW As Decimal

        'tmpMinW = rTableColl.Item(1).weight

        'tmpMaxW = rTableColl.Item(1).weight

        'If rTableColl.Count > 1 Then
        '    For i = 2 To rTableColl.Count
        '        If rTableColl.Item(i).weight < 70 Then
        '            If rTableColl.Item(i).weight > tmpMaxW Then tmpMaxW = rTableColl.Item(i).weight
        '            If rTableColl.Item(i).weight < tmpMinW Then tmpMinW = rTableColl.Item(i).weight
        '        End If
        '    Next
        'End If

        'Me.max_weight = Format(tmpMaxW, "#0.00")
        'Me.min_weight = Format(tmpMinW, "#0.00")




        Return False
ErrorHandler:
        Me._err_number = Err.Number
        Me._err_description = Err.Description
        Me._err_source = Err.Source
        Return True
    End Function

    Function get_table_info() As Boolean
        On Error GoTo ErrorHandler
        Dim bError As Boolean = False

        Dim rtablecoll As New Collection

        Dim oDG_search As New iDac.cls_sql_read

        oDG_search._connection_string = Me.conn_string '' Application("connection")._connection_string
        oDG_search._tablename = "vv_gemstones_full"

        oDG_search.transact_read(Me.sqlstr)

        Dim oData As DataTable = oDG_search._datatable

        Me.total_items_found = oData.Rows.Count

        Dim i

        For i = 0 To oData.Rows.Count - 1

            Dim tmpTableItem As New ion_two.cls_ajax_cs_tablemember




            opictures.format_picture(opictures, oData.Rows(i).Item("category_id"), 1, oData.Rows(i).Item("icon_name"), tmpTableItem.has_icon)

            tmpTableItem.icon_pic = opictures._result

            tmpTableItem.id = oData.Rows(i).Item("id")
            tmpTableItem.color = oData.Rows(i).Item("colorfrom")
            ''remove the - sign
            tmpTableItem.color = Mid(tmpTableItem.color, 1, InStr(tmpTableItem.color, " -", CompareMethod.Text))
            tmpTableItem.item_number = oData.Rows(i).Item("itemnumber")
            tmpTableItem.price = oData.Rows(i).Item("sell_price")
            tmpTableItem.shape = oData.Rows(i).Item("shape")
            tmpTableItem.type = oData.Rows(i).Item("stonetype")
            tmpTableItem.weight = oData.Rows(i).Item("weight")

            ''extra non db

            Dim ostringfunc As New iFunctions.cls_string
            ostringfunc.format_currency(Convert.ToString(tmpTableItem.price), tmpTableItem.price_formatted, "$")
            ''= Convert.ToString(tmpTableItem.price) + "$"
            tmpTableItem.weight_formatted = Convert.ToString(Format(tmpTableItem.weight, "##0.00")) + " Ct."


            ''set max min price

            If oData.Rows(i).Item("measure1") > 0 And oData.Rows(i).Item("measure2") > 0 Then
                rtablecoll.Add(tmpTableItem)
            End If
        Next

        Dim tmpMinP, tmpMaxP As Decimal

        tmpMinP = rtablecoll.Item(1).price

        tmpMaxP = rtablecoll.Item(1).price

        If rtablecoll.Count > 1 Then
            For i = 2 To rtablecoll.Count
                If rtablecoll.Item(i).weight < 30 Then
                    If rtablecoll.Item(i).price > tmpMaxP Then tmpMaxP = rtablecoll.Item(i).price
                    If rtablecoll.Item(i).price < tmpMinP Then tmpMinP = rtablecoll.Item(i).price
                End If
            Next
        End If

        Me.max_price = Convert.ToInt32(((tmpMaxP \ 100) * 100) + 100)
        Me.min_price = Convert.ToInt32(((tmpMinP \ 100) * 100) + 100)


        Dim tmpMinW, tmpMaxW As Decimal

        tmpMinW = rtablecoll.Item(1).weight

        tmpMaxW = rtablecoll.Item(1).weight

        If rtablecoll.Count > 1 Then
            For i = 2 To rtablecoll.Count
                If rtablecoll.Item(i).weight < 30 Then
                    If rtablecoll.Item(i).weight > tmpMaxW Then tmpMaxW = rtablecoll.Item(i).weight
                    If rtablecoll.Item(i).weight < tmpMinW Then tmpMinW = rtablecoll.Item(i).weight
                End If
            Next
        End If

        Me.max_weight = Format(tmpMaxW, "#0.00")
        Me.min_weight = Format(tmpMinW, "#0.00")




        Return False
ErrorHandler:
        Me._err_number = Err.Number
        Me._err_description = Err.Description
        Me._err_source = Err.Source
        Return True
    End Function
End Class
