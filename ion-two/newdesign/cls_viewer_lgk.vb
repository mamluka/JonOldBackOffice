Imports System.Xml
Imports System.Reflection
Imports System.Text.RegularExpressions
Imports System.Web.UI.WebControls
Public Class cls_viewer_lgk
    Public xml_words_file As String
    Public xml_desc_file As String
    Public xml_q2w_file As String
    Public xml_filter_file As String
    Public items_coll As New ArrayList
    Public cascadeSQL As ArrayList
    Public conn_string, db_type As String
    Public pictures As ion_two.cls_pictures
    Public isDealer As Boolean



    Public Function makeSQL_bywords(ByVal wordparts As Hashtable, ByRef rsql As String)
        Dim a As String

        ''   Me.TranslateWordsToQuary(wordparts, a)

        Dim sqlstr As String

        sqlstr += "select CASE WHEN (onbargain=1) THEN special_sell_price WHEN (onspecial=1) and ( DATEDIFF(day, onspecial_to_date, getdate())  < 0 ) THEN special_sell_price ELSE  sell_price   END AS sell_price  , * from "

        ''getting the table to check

        Dim AllItemsGenra As New AllItemsGenraCount

        If wordparts.ContainsKey("group") Then
            sqlstr += " vv_allitems_full where "
            Dim ogroups As New ion_two.cls_groups
            ogroups.conn_string = Me.conn_string
            Dim items As New ArrayList
            ogroups.LoadItemsByGroupKey(wordparts("group"), items)
            sqlstr += "id in ( " + Join(items.ToArray, ",") + " )"

        ElseIf wordparts.ContainsKey("search") Then

            Dim osearch As New WordLine.AllView
            Dim sql = osearch.send(wordparts("search"))

            Dim osearch_sql As New iDac.cls_sql_read

            Dim sSql As String = sql



            osearch_sql._connection_string = Me.conn_string
            ''  osearch_sql._tablename = "v_feedbacks"



            osearch_sql.transact_read(sSql)

            Dim oData As DataTable = osearch_sql._datatable

            If oData.Rows.Count > 0 Then
                Dim items As New ArrayList
                Dim i2 As Int32
                For Each row As DataRow In oData.Rows
                    If i2 = 80 Then Exit For

                    items.Add(row("id"))
                    i2 += 1
                Next

                sqlstr += "vv_allitems_full where id in ( " + Join(items.ToArray, ",") + " )  "

            End If


        Else
            If Not IsNothing(wordparts.Item("genra")) Then


                Dim rtn As String
                If Not AllItemsGenra.Check(wordparts) Then
                    Me.Words2SQLObjects(wordparts.Item("genra"), rtn)
                Else
                    rtn = "vv_allitems_full"
                End If
                sqlstr += rtn

            Else
                Dim rtn As String
                If Not AllItemsGenra.Check(wordparts) Then
                    Me.Words2SQLObjects(wordparts.Item("genra"), rtn)
                Else
                    rtn = "vv_allitems_full"
                End If
                sqlstr += rtn

            End If
        End If
        If Not IsNothing(wordparts.Item("itemnumber")) Then

            Dim viewtype As String
            Dim itemnumber As String = wordparts("itemnumber")
            Dim odatabase As New cls_database_lgk
            Dim onumber As New ion_two.cls_itemnumber
            onumber.UnicodeItemNumber(itemnumber)
            odatabase.conn_string = Me.conn_string
            odatabase.GetViewTypeByItemNumber(itemnumber, viewtype)
            If Regex.Match(itemnumber, "^ledder\|\d{2}-?\d{2}$").Success Then
                sqlstr = "select * from vv_allitems_full where SUPPLIERNUMBER=" + Regex.Match(itemnumber, "\d{2}-?(\d{2})$").Groups(1).Value
            Else
                rsql = "select * from " + viewtype + " where itemnumber='" + itemnumber + "'"
                Exit Function
            End If



            ''            
        End If


        Dim sql_where As New ArrayList
        Dim sql_sort As New ArrayList
        Dim cascadewhere As New ArrayList

        For Each Key As String In wordparts.Keys

            Dim wordpart As String = wordparts.Item(Key)
            If Not wordpart.IndexOf("::") = -1 Then
                Dim params() As String = Split(wordpart, "::")

                Dim param2array() As String = Split(params(2), "~~")
                If param2array.Length = 0 Then param2array(0) = params(2)

                For Each param2 As String In param2array
                    Select Case params(0)

                        Case "1" '' normal where column
                            sql_where.Add("(" + params(1) + " = '" + param2 + "')")
                            cascadewhere.Add(wordpart)
                        Case "2" ''//between
                            Dim vals() As String = Split(param2, "to")
                            sql_where.Add("(" + params(1) + " BETWEEN " + vals(0) + " AND " + vals(1) + " )")
                            cascadewhere.Add(wordpart)
                        Case "3" ''like
                            sql_where.Add("(" + params(1) + " like '" + param2.Replace("per", "%") + "')")
                            cascadewhere.Add(wordpart)
                        Case "4" ''not like
                            sql_where.Add("(" + params(1) + " not like '" + param2.Replace("per", "%") + "')")
                            cascadewhere.Add(wordpart)

                        Case "6" '' in thingy
                            Dim tmparray As New ArrayList
                            For Each val As String In param2.Split(",")
                                tmparray.Add("'" + val + "'")

                            Next

                            sql_where.Add("(" + params(1) + " in (" + Join(tmparray.ToArray, ",") + ") )")
                            cascadewhere.Add(wordpart)
                        Case "5" ''order by
                            sql_sort.Add(params(1) + " " + param2)
                            ''cascadewhere.Add(wordpart)
                        Case "c" ''custom
                            If params(1).Substring(0, 4) = "func" Then
                                Dim ofunc As New ion_two.cls_wordpart_talkback
                                Dim refworks As Type
                                Dim rstring As String
                                refworks = ofunc.GetType
                                rstring = refworks.InvokeMember(param2, BindingFlags.InvokeMethod, Nothing, ofunc, Nothing)

                                If params(1).Substring(4) = "sort" Then
                                    sql_sort.Add(rstring)
                                ElseIf params(1).Substring(4) = "where" Then
                                    sql_where.Add("( " + rstring + " )")
                                    cascadewhere.Add(wordpart)
                                End If
                            ElseIf params(1).Substring(0, 4) = "csql" Then
                                Dim rtn As String
                                Me.Words2SQLObjects(param2, rtn)
                                If params(1).Substring(4) = "sort" Then
                                    sql_sort.Add(rtn)
                                ElseIf params(1).Substring(4) = "where" Then
                                    sql_where.Add("( " + rtn + " )")
                                    cascadewhere.Add(wordpart)
                                End If
                            End If
                    End Select
                Next
                ''handle multi and in same word
                If param2array.Length > 1 Then
                    Dim j As Int32
                    Dim tmporArray As New ArrayList
                    For j = sql_where.Count - 1 To sql_where.Count - param2array.Length Step -1
                        tmporArray.Add(sql_where(j))
                    Next
                    sql_where.RemoveRange(sql_where.Count - param2array.Length, param2array.Length)
                    sql_where.Add("( " + Join(tmporArray.ToArray, " or ") + " ) ")
                End If
            End If




        Next





        Dim i As Int32

        For i = 0 To sql_where.Count - 1
            If sql_where.Item(i).indexOf(" or ") > -1 Then
                sql_where.Item(i) = "(" + sql_where.Item(i) + ")"
            End If
        Next

        Dim sql_where_construct() As Object
        sql_where_construct = sql_where.ToArray()

        Dim ostringfunc As New iFunctions.cls_string

        If sql_where_construct.Length > 0 Then
            If sqlstr.IndexOf(" where ") > -1 Then
                ostringfunc.CreateCascadeByArray(sql_where, cascadewhere, sqlstr + " and ")
                sqlstr += " and " + Join(sql_where_construct, " and ")

            Else
                ostringfunc.CreateCascadeByArray(sql_where, cascadewhere, sqlstr + " where ")
                sqlstr += " WHERE " + Join(sql_where_construct, " and ")

            End If
            sqlstr += " and (itemdeleted = 0) and (qtyonstock_cur > 0) and (shopstatus = 1) and (sell_price > 0)"
        Else
            If sqlstr.IndexOf(" where ") > -1 Then
                sqlstr += " and (itemdeleted = 0) and (qtyonstock_cur > 0) and (shopstatus = 1) and (sell_price > 0)"
            Else
                sqlstr += " where (itemdeleted = 0) and (qtyonstock_cur > 0) and (shopstatus = 1) and (sell_price > 0)"
            End If

        End If


        Dim sql_sort_construct() As Object
        sql_sort_construct = sql_sort.ToArray()

        If sql_sort_construct.Length > 0 Then
            sqlstr += " ORDER BY " + Join(sql_sort_construct, ", ")
        End If

        rsql = sqlstr
        Me.cascadeSQL = cascadewhere

    End Function

    Public Function makeSQL_bywords_idex(ByVal wordparts As Hashtable, ByRef rsql As String)
        Dim a As String

        ''   Me.TranslateWordsToQuary(wordparts, a)

        Dim sqlstr As String

        sqlstr += "select * from inv_idex "

        ''getting the table to check

        
        'If Not IsNothing(wordparts.Item("genra")) Then
        '    Dim rtn As String
        '    Me.Words2SQLObjects(wordparts.Item("genra"), rtn)

        '    sqlstr += rtn

        'Else
        '    Dim rtn As String
        '    Me.DefWords2SQLObjects("genra", rtn)

        '    sqlstr += rtn

        'End If

       


        Dim sql_where As New ArrayList
        Dim sql_sort As New ArrayList
        Dim cascadewhere As New ArrayList
        For Each Key As String In wordparts.Keys

            Dim wordpart As String = wordparts.Item(Key)
            If Not wordpart.IndexOf("::") = -1 Then
                Dim params() As String = Split(wordpart, "::")

                Dim param2array() As String = Split(params(2), "~~")
                If param2array.Length = 0 Then param2array(0) = params(2)

                For Each param2 As String In param2array
                    Select Case params(0)

                        Case "1" '' normal where column
                            sql_where.Add("(" + params(1) + " = '" + param2 + "')")
                            cascadewhere.Add(wordpart)
                        Case "2" ''//between
                            Dim vals() As String = Split(param2, "to")
                            sql_where.Add("(" + params(1) + " BETWEEN " + vals(0) + " AND " + vals(1) + " )")
                            cascadewhere.Add(wordpart)
                        Case "3" ''like
                            sql_where.Add("(" + params(1) + " like '" + param2.Replace("per", "%") + "')")
                            cascadewhere.Add(wordpart)
                        Case "4" ''not like
                            sql_where.Add("(" + params(1) + " not like '" + param2.Replace("per", "%") + "')")
                            cascadewhere.Add(wordpart)

                        Case "6" '' in thingy
                            Dim tmparray As New ArrayList
                            For Each val As String In param2.Split(",")
                                tmparray.Add("'" + val + "'")

                            Next

                            sql_where.Add("(" + params(1) + " in (" + Join(tmparray.ToArray, ",") + ") )")
                            cascadewhere.Add(wordpart)

                        Case "5" ''order by
                            sql_sort.Add(params(1) + " " + param2)
                        Case "c" ''custom
                            If params(1).Substring(0, 4) = "func" Then
                                Dim ofunc As New ion_two.cls_wordpart_talkback
                                Dim refworks As Type
                                Dim rstring As String
                                refworks = ofunc.GetType
                                rstring = refworks.InvokeMember(param2, BindingFlags.InvokeMethod, Nothing, ofunc, Nothing)

                                If params(1).Substring(4) = "sort" Then
                                    sql_sort.Add(rstring)
                                ElseIf params(1).Substring(4) = "where" Then
                                    sql_where.Add("( " + rstring + " )")
                                    cascadewhere.Add(wordpart)
                                End If
                            ElseIf params(1).Substring(0, 4) = "csql" Then
                                Dim rtn As String
                                Me.Words2SQLObjects(param2, rtn)
                                If params(1).Substring(4) = "sort" Then
                                    sql_sort.Add(rtn)
                                ElseIf params(1).Substring(4) = "where" Then
                                    sql_where.Add("( " + rtn + " )")
                                    cascadewhere.Add(wordpart)
                                End If
                            End If
                    End Select
                Next
                ''handle multi and in same word
                If param2array.Length > 1 Then
                    Dim j As Int32
                    Dim tmporArray As New ArrayList
                    For j = sql_where.Count - 1 To sql_where.Count - param2array.Length Step -1
                        tmporArray.Add(sql_where(j))
                    Next
                    sql_where.RemoveRange(sql_where.Count - param2array.Length, param2array.Length)
                    sql_where.Add("( " + Join(tmporArray.ToArray, " or ") + " ) ")
                End If
            End If




        Next



        Dim ostringfunc As New iFunctions.cls_string

        Dim i As Int32

        For i = 0 To sql_where.Count - 1
            If sql_where.Item(i).indexOf("or") > -1 Then
                sql_where.Item(i) = "(" + sql_where.Item(i) + ")"
            End If
        Next

        Dim sql_where_construct() As Object
        sql_where_construct = sql_where.ToArray()


        If sql_where_construct.Length > 0 Then
            If sqlstr.IndexOf("where ") > -1 Then
                ostringfunc.CreateCascadeByArray(sql_where, cascadewhere, sqlstr + " and ")
                sqlstr += " and " + Join(sql_where_construct, " and ")
            Else
                ostringfunc.CreateCascadeByArray(sql_where, cascadewhere, sqlstr + " where ")
                sqlstr += " WHERE " + Join(sql_where_construct, " and ")
            End If
            ''  sqlstr += " and (itemdeleted = 0) and (qtyonstock_cur > 0) and (shopstatus = 1) and (sell_price > 0)"
        Else
            If sqlstr.IndexOf("where ") > -1 Then
                ''    sqlstr += " and (itemdeleted = 0) and (qtyonstock_cur > 0) and (shopstatus = 1) and (sell_price > 0)"
            Else
                ''      sqlstr += " where (itemdeleted = 0) and (qtyonstock_cur > 0) and (shopstatus = 1) and (sell_price > 0)"
            End If

        End If


        Dim sql_sort_construct() As Object
        sql_sort_construct = sql_sort.ToArray()

        If sql_sort_construct.Length > 0 Then
            sqlstr += " ORDER BY " + Join(sql_sort_construct, ", ")
        End If
        Me.cascadeSQL = cascadewhere
        rsql = sqlstr

    End Function

    Public Function LoadItems2Coll(ByVal sqlstr As String, ByVal pagesize As Int32, ByVal pagenumber As Int32, ByRef extra_str As String)
        Dim viewer_sql As New iDac.cls_sql_read

        Dim hash As New Hashtable
        Dim sSql As String = sqlstr
        '' Dim ssql = "exec usp_displayallusers ''"
        Dim ostringfunc As New iFunctions.cls_string



        viewer_sql._connection_string = Me.conn_string
        viewer_sql._tablename = "vv_jewelry_full"


        viewer_sql.transact_read(sSql)

        Dim oData As DataTable = viewer_sql._datatable

        If oData.Rows.Count > 0 Then

            Dim oTmpInventory As New ion_two.cls_inventory_lgc
            oTmpInventory._connection_string = Me.conn_string
            oTmpInventory._dbtype = Me.db_type

            Dim i, startIndex, endIndex As Int32
            startIndex = -1
            startIndex = (pagesize - 1) * (pagenumber - 1) + pagenumber - 1

            endIndex = startIndex + pagesize - 1

            If startIndex > oData.Rows.Count - 1 Then
                hash.Add("wrongindex", "1")
                startIndex = 0
            End If

            If endIndex > oData.Rows.Count - 1 Then

                endIndex = endIndex - (endIndex - oData.Rows.Count) - 1

            End If


            Dim ocatalog_lgk As New ion_two.cls_viewer_catalog_lgk
            ocatalog_lgk.desc_xml = Me.xml_desc_file
            '' Dim deschash As Hashtable = ocatalog_lgk.LoadDescriptionHash(Me.xml_desc_file)
            For i = startIndex To endIndex
                Dim oPlate As New ion_two.skl_lst_inventory
                oTmpInventory.load(oData.Rows(i).Item("id"), oPlate, Me.pictures)
                ocatalog_lgk.conn_string = Me.conn_string
                ocatalog_lgk.db_type = Me.db_type
                ocatalog_lgk.CreateDescription(oPlate, oPlate._item_description)


                oPlate._item_description_round = ostringfunc.ClearHTMLTagsReturn(oPlate._item_description.Replace("<br>", " ").Replace("<BR>", " "))

                Dim tmpItem As New viewer_item_v1
                tmpItem.item = oPlate

                ''  hash("link") = "/items/" + ostringfunc.ClearHTMLTagsReturn(oPlate._item_description.Replace("<br>", " ").Replace("<BR>", " ")).Replace(" ", "-") + "-ID" + oPlate._id.ToString.ToUpper
                Dim oseo As New ion_two.cls_seo

                tmpItem.isapi_link = oseo.CreateISAPILink(oPlate._item_description, oPlate._platetype, oPlate._id)
                'Select Case oPlate._platetype
                '    Case 1
                '        tmpItem.isapi_link = "/diamond/" + ostringfunc.ClearHTMLTagsReturn(Trim(oPlate._item_description).Replace("<br>", " ").Replace("<BR>", " ")).Replace(" ", "-").replace("--", "-") + "-ID" + oPlate._id.ToString.ToUpper
                '    Case 2
                '        tmpItem.isapi_link = "/gemstone/" + ostringfunc.ClearHTMLTagsReturn(Trim(oPlate._item_description).Replace("<br>", " ").Replace("<BR>", " ")).Replace(" ", "-").replace("--", "-") + "-ID" + oPlate._id.ToString.ToUpper
                '    Case 3
                '        tmpItem.isapi_link = "/jewelry/" + ostringfunc.ClearHTMLTagsReturn(Trim(oPlate._item_description).Replace("<br>", " ").Replace("<BR>", " ")).Replace(" ", "-").replace("--", "-") + "-ID" + oPlate._id.ToString.ToUpper

                'End Select



                ''price logic
                If oPlate.opthash("usepayments") <> "1" Then
                    If oPlate._pricing._onbargain Then

                        tmpItem.AddPrice("Our Price:", "<s>" + oPlate._pricing._hash("sell") + "<s>")
                        tmpItem.AddPrice("Bargain Price:", oPlate._pricing._hash("bargain"), "EC0006")
                    ElseIf oPlate._pricing._isspecial = True And Today.Date >= oPlate._pricing._special_from And Today.Date <= oPlate._pricing._special_to Then
                        If Me.isDealer Then
                            tmpItem.AddPrice("Regular Price:", oPlate._pricing._hash("special"))
                            tmpItem.AddPrice("<span style='color:red' >VIP</span> Price:", oPlate._pricing._hash("dealer special"), "EC0006")
                        Else

                            tmpItem.AddPrice("Our Price:", "<s>" + oPlate._pricing._hash("sell") + "<s>")
                            tmpItem.AddPrice("Special Price:", oPlate._pricing._hash("special"), "EC0006")
                        End If
                    ElseIf Me.isDealer Then
                        tmpItem.AddPrice("Regular Price:", oPlate._pricing._hash("sell"))
                        tmpItem.AddPrice("<span style='color:red' >VIP</span> Price:", oPlate._pricing._hash("dealer"), "EC0006")
                    Else
                        tmpItem.AddPrice("Our Price:", oPlate._pricing._hash("sell"))
                    End If
                Else
                    Dim word As String
                    'Select Case oPlate.opthash("payments")
                    '    Case "3"
                    '        word = "Three"
                    '    Case "5"
                    '        word = "Five"
                    '    Case "10"
                    '        word = "Ten"
                    '    Case "12"
                    '        word = "Twelve"

                    'End Select
                    tmpItem.AddPrice(oPlate.opthash("payments") + " payments of", oPlate._pricing._hash("sell"), "EC0006")
                End If
                ''icon logic
                Dim icon_js_array As New ArrayList
                If oPlate._is_hires Then

                    icon_js_array.Add(oPlate._picture_hires_pic)
                    icon_js_array.Add(2)
                    icon_js_array.Add("this")
                    icon_js_array.Add(19)
                    icon_js_array.Add(23)
                    tmpItem.AddIcons("icon_hres", "floatPictureUsingHook", icon_js_array)
                    icon_js_array.Clear()
                End If

                If oPlate._is_report Then

                    icon_js_array.Add(oPlate._certificate_pic)
                    icon_js_array.Add(2)
                    icon_js_array.Add("this")
                    icon_js_array.Add(19)
                    icon_js_array.Add(23)
                    tmpItem.AddIcons("icon_cert", "floatPictureUsingHook", icon_js_array)
                    icon_js_array.Clear()
                End If

                icon_js_array.Add(oPlate._id)
                icon_js_array.Add(2)
                icon_js_array.Add("this")
                icon_js_array.Add(27)
                icon_js_array.Add(0)
                tmpItem.AddIcons("icon_info", "floatInfoTreeUsingHook", icon_js_array)
                icon_js_array.Clear()

                ''oplate._item_description
                Me.items_coll.Add(tmpItem)
            Next

            ''make the extra info
        Else
            If Not IsNothing(Me.cascadeSQL) Then
                Dim i As Int32
                For i = Me.cascadeSQL.Count / 2 To Me.cascadeSQL.Count - 1
                    viewer_sql.transact_read(Me.cascadeSQL(i) + " and (itemdeleted = 0) and (qtyonstock_cur > 0) and (shopstatus = 1) and (sell_price > 0)")

                    If viewer_sql._datatable.Rows.Count = 0 Then
                        hash.Add("cascadeProblem", Me.cascadeSQL(i - Me.cascadeSQL.Count / 2).replace("::", "^^"))
                        Exit For
                    End If

                Next
            End If

            End If

            hash.Add("total", oData.Rows.Count)

            extra_str = ostringfunc.Hash2String(hash, "|", "::")

    End Function

    Public Function LoadItems2Coll_IDEX(ByVal sqlstr As String, ByVal pagesize As Int32, ByVal pagenumber As Int32, ByRef extra_str As String)
        Dim viewer_sql As New iDac.cls_sql_read

        Dim hash As New Hashtable
        Dim sSql As String = sqlstr
        '' Dim ssql = "exec usp_displayallusers ''"
        Dim ostringfunc As New iFunctions.cls_string



        viewer_sql._connection_string = Me.conn_string
        viewer_sql._tablename = "vv_jewelry_full"


        viewer_sql.transact_read(sSql)

        Dim oData As DataTable = viewer_sql._datatable

        If oData.Rows.Count > 0 Then

            Dim oTmpInventory As New ion_two.cls_inventory_lgc
            oTmpInventory._connection_string = Me.conn_string
            oTmpInventory._dbtype = Me.db_type

            Dim i, startIndex, endIndex As Int32
            startIndex = -1
            startIndex = (pagesize - 1) * (pagenumber - 1) + pagenumber - 1

            endIndex = startIndex + pagesize - 1

            If startIndex > oData.Rows.Count - 1 Then
                hash.Add("wrongindex", "1")
                startIndex = 0
            End If

            If endIndex > oData.Rows.Count - 1 Then

                endIndex = endIndex - (endIndex - oData.Rows.Count) - 1

            End If


            Dim ocatalog_lgk As New ion_two.cls_viewer_catalog_lgk
            ocatalog_lgk.desc_xml = Me.xml_desc_file
            '' Dim deschash As Hashtable = ocatalog_lgk.LoadDescriptionHash(Me.xml_desc_file)
            For i = startIndex To endIndex
                Dim oPlate As New ion_two.cls_idexPlateItem
                oTmpInventory.load_idex(oData.Rows(i).Item("idex_id"), oPlate)
                ''   ocatalog_lgk.CreateDescription(oPlate, oPlate._item_description)
                ''oplate._item_description  = 
                Dim tmpItem As New viewer_item_v1
                tmpItem.item = oPlate
                ''tmpItem.isapi_link = "/diamond/" + oPlate.itemid.ToString + ".htm"
                tmpItem.isapi_link = "/catalog/myitem.aspx?id=" + oPlate.itemid.ToString + "&modid=6"





                ''price logic
                'If oPlate._pricing._onbargain Then

                '    tmpItem.AddPrice("Our Price:", "<s>" + oPlate._pricing._hash("sell") + "<s>")
                '    tmpItem.AddPrice("Bargain Price:", oPlate._pricing._hash("bargain"), "EC0006")
                'ElseIf oPlate._pricing._isspecial = True And Today.Date >= oPlate._pricing._special_from And Today.Date <= oPlate._pricing._special_to Then
                '    If Me.isDealer Then
                '        tmpItem.AddPrice("Website Price:", oPlate._pricing._hash("special"))
                '        tmpItem.AddPrice("Dealer Price:", oPlate._pricing._hash("dealer special"), "EC0006")
                '    Else

                '        tmpItem.AddPrice("Our Price:", "<s>" + oPlate._pricing._hash("sell") + "<s>")
                '        tmpItem.AddPrice("Special Price:", oPlate._pricing._hash("special"), "EC0006")
                '    End If
                'ElseIf Me.isDealer Then
                '    tmpItem.AddPrice("Website Price:", oPlate._pricing._hash("sell"))
                '    tmpItem.AddPrice("Dealer Price:", oPlate._pricing._hash("dealer"), "EC0006")
                'Else
                '    tmpItem.AddPrice("Our Price:", oPlate._pricing._hash("sell"))
                'End If

                tmpItem.AddPrice("Our Price:", oPlate.price_formatted)
                ''icon logic
                Dim icon_js_array As New ArrayList
                'If oPlate._is_hires Then

                '    icon_js_array.Add(oPlate._picture_hires_pic)
                '    icon_js_array.Add(2)
                '    icon_js_array.Add("this")
                '    icon_js_array.Add(19)
                '    icon_js_array.Add(23)
                '    tmpItem.AddIcons("icon_hres", "floatPictureUsingHook", icon_js_array)
                '    icon_js_array.Clear()
                'End If

                If oPlate._is_report Then

                    icon_js_array.Add(oPlate.certificate_path)
                    icon_js_array.Add(2)
                    icon_js_array.Add("this")
                    icon_js_array.Add(19)
                    icon_js_array.Add(23)
                    tmpItem.AddIcons("icon_cert", "floatPictureUsingHook", icon_js_array)
                    icon_js_array.Clear()
                End If

                icon_js_array.Add(oPlate.itemid)
                icon_js_array.Add(2)
                icon_js_array.Add("this")
                icon_js_array.Add(27)
                icon_js_array.Add(0)
                tmpItem.AddIcons("icon_info", "floatInfoTreeUsingHook", icon_js_array)
                icon_js_array.Clear()


                ''oplate._item_description
                Me.items_coll.Add(tmpItem)
            Next

            ''make the extra info


        Else
            Dim i As Int32

            If Not IsNothing(Me.cascadeSQL) Then
                For i = Me.cascadeSQL.Count / 2 To Me.cascadeSQL.Count - 1
                    viewer_sql.transact_read(Me.cascadeSQL(i))

                    If viewer_sql._datatable.Rows.Count = 0 Then
                        hash.Add("cascadeProblem", Me.cascadeSQL(i - Me.cascadeSQL.Count / 2).replace("::", "^^"))
                        Exit For
                    End If

                Next
            End If

        End If


        hash.Add("total", oData.Rows.Count)

        extra_str = ostringfunc.Hash2String(hash, "|", "::")

    End Function

    Public Function TranslateQuaryToWordParts(ByVal key As String, ByVal val As String, ByRef words_js_obj As ArrayList, ByRef misc_js_commends As ArrayList, ByRef qs_memory As ArrayList, ByRef menu_blocks As ArrayList) As Boolean

        ''handle combos
        Dim oredcombo As New cls_redcombo
        Select Case key
            Case "genra"
                Dim tmpjs As String
                oredcombo.ChangeItemIndex("optGenra", val, tmpjs)
                misc_js_commends.Add(tmpjs)

                Return True
            Case "sort"
                Dim tmpjs As String
                oredcombo.ChangeItemIndex("optSort", val, tmpjs)
                misc_js_commends.Add(tmpjs)
                Return True
            Case "group"
                Dim ojs As New wordpart4js
                ojs.cat = "group"
                ojs.flags = "noextra"
                Dim ogroups As New ion_two.cls_groups
                ogroups.conn_string = Me.conn_string
                ogroups.GetGroupNameByKey(val, ojs.text)
                ojs.passcode = "group|" + val
                qs_memory.Add(qs_memory(qs_memory.Count - 1) + "&" + key + "=" + val)
                words_js_obj.Add(ojs)
                Dim tmpjs As String


                oredcombo.AddItemsFromArrayList("rcGenraItems", "'ChangeGenraInit()'", "Groups", "noaction|99::noaction::321", tmpjs)

                misc_js_commends.Add(tmpjs)

                oredcombo.ChangeItemIndex("optGenra", "4", tmpjs)
                misc_js_commends.Add(tmpjs)

                Return True
            Case "search"
                Dim ojs As New wordpart4js
                ojs.cat = "search"
                ojs.special = True
                ojs.flags = "search"
                ojs.passcode = val
                qs_memory.Add(qs_memory(qs_memory.Count - 1) + "&" + key + "=" + val)
                words_js_obj.Add(ojs)

                Dim tmpjs As String


                oredcombo.AddItemsFromArrayList("rcGenraItems", "'ChangeGenraInit()'", "All Items", "noaction|99::noaction::321", tmpjs)

                misc_js_commends.Add(tmpjs)

                oredcombo.ChangeItemIndex("optGenra", "4", tmpjs)
                misc_js_commends.Add(tmpjs)


            Case "itemnumber"
                Dim ojs As New wordpart4js
                ojs.cat = "itemnumber"
                ojs.special = True
                ojs.flags = "itemnumber"
                Dim onumber As New ion_two.cls_itemnumber
                val = val.Replace("ledder", "#")
                onumber.UnicodeItemNumber(val)

                ojs.passcode = val
                qs_memory.Add(qs_memory(qs_memory.Count - 1) + "&" + key + "=" + val)
                words_js_obj.Add(ojs)

        End Select

        Dim oxml As New ion_two.cls_nd_xmlread
        oxml.xml_file = Me.xml_filter_file
        oxml.Load()
        Dim trans_nodes As XmlNodeList = oxml.GetNodes_ByPath("//wpt/filter[@wordid='" + key + "']")

        If trans_nodes.Count > 0 Then
            Dim trans_node As XmlNode = trans_nodes(0)
            Select Case trans_node.Attributes("type").InnerText
                Case "options"
                    Dim ojs As New wordpart4js
                    ojs.cat = trans_node.Attributes("cattext").InnerText
                    ojs.text = trans_node.SelectSingleNode("filterpart[@qsid='" + val + "']").Attributes("text").InnerText
                    ojs.passcode = trans_node.Attributes("wordid").InnerText + "|" + trans_node.SelectSingleNode("filterpart[@qsid='" + val + "']").InnerText
                    qs_memory.Add(qs_memory(qs_memory.Count - 1) + "&" + key + "=" + val)
                    words_js_obj.Add(ojs)
                Case "range"
                    Dim ojs As New wordpart4js
                    ojs.cat = trans_node.Attributes("cattext").InnerText
                    If val.IndexOf("~") > -1 Then
                        Dim valparams() = val.Split("~")
                        Dim patternWordText As String = trans_node.SelectSingleNode("qs_translate").Attributes("patternWordText").InnerText
                        Dim patternOut As String = trans_node.SelectSingleNode("qs_translate").Attributes("patternOut").InnerText

                        Dim i As Int32

                        For i = 0 To valparams.Length - 1
                            patternWordText = patternWordText.Replace("~" + Convert.ToString(i + 1) + "~", valparams(i))
                            patternOut = patternOut.Replace("~" + Convert.ToString(i + 1) + "~", valparams(i))

                        Next
                        ojs.text = patternWordText
                        ojs.passcode = trans_node.Attributes("wordid").InnerText + "|" + patternOut
                    Else
                        ojs.cat = trans_node.Attributes("cattext").InnerText
                        If Not IsNothing(trans_node.SelectSingleNode("filterpart[@qsid='" + val + "']")) Then
                            ojs.text = trans_node.SelectSingleNode("filterpart[@qsid='" + val + "']").Attributes("text").InnerText

                            ojs.passcode = trans_node.Attributes("wordid").InnerText + "|" + trans_node.SelectSingleNode("filterpart[@qsid='" + val + "']").InnerText
                        Else
                            ojs.text = trans_node.SelectSingleNode("qs_translate").Attributes("patternWordTextSingle").InnerText.Replace("~1~", val)
                            ojs.passcode = trans_node.Attributes("wordid").InnerText + "|" + trans_node.SelectSingleNode("qs_translate").Attributes("patternOut").InnerText.Replace("~1~", val).Replace("~2~", val)
                        End If
                    End If

                    words_js_obj.Add(ojs)
                    qs_memory.Add(qs_memory(qs_memory.Count - 1) + "&" + key + "=" + val)

                Case "discrete"

                    Dim ojs As New wordpart4js
                    ojs.cat = trans_node.Attributes("cattext").InnerText

                    If val.Split("~").Length > 1 Then
                        Dim valparams() = val.Split("~")
                        Dim patternWordText As String = trans_node.SelectSingleNode("qs_translate").Attributes("patternWordText").InnerText
                        Dim patternOut As String = trans_node.SelectSingleNode("qs_translate").Attributes("patternOut").InnerText

                        Dim i As Int32

                        For i = 0 To valparams.Length - 1
                            patternWordText = patternWordText.Replace("~" + Convert.ToString(i + 1) + "~", valparams(i))

                            '' patternOut = patternOut.Replace("~" + Convert.ToString(i + 1) + "~", valparams(i))

                        Next
                        Dim inwords As New ArrayList
                        Me.GetDiscreteWordsArray(trans_node.Attributes("wordid").InnerText, valparams(0).toLower(), valparams(1).toLower, inwords)

                        If inwords.Count > 1 Then
                            patternOut = patternOut.Replace("inwords", Join(inwords.ToArray, ","))
                        End If


                        ojs.text = patternWordText
                        ojs.passcode = trans_node.Attributes("wordid").InnerText + "|" + patternOut
                    Else
                        ojs.cat = trans_node.Attributes("cattext").InnerText
                        ojs.text = trans_node.SelectSingleNode("filterpart[@qsid='" + val.ToLower + "']").Attributes("text").InnerText
                        ojs.passcode = trans_node.Attributes("wordid").InnerText + "|" + trans_node.SelectSingleNode("filterpart[@qsid='" + val.ToLower + "']").InnerText
                    End If

                    words_js_obj.Add(ojs)
                    qs_memory.Add(qs_memory(qs_memory.Count - 1) + "&" + key + "=" + val)


            End Select

            If Not IsNothing(trans_node.SelectSingleNode("filterpart[@qsid='" + val + "']")) Then
                If Not IsNothing(trans_node.SelectSingleNode("filterpart[@qsid='" + val + "']").Attributes("menublock")) Then
                    menu_blocks.Add(trans_node.SelectSingleNode("filterpart[@qsid='" + val + "']").Attributes("menublock").InnerText)
                End If

            End If
        End If

        ''  oxml.GetNodes_ByPath()

    End Function
    Function TranslateWordsToQuary(ByVal wordparts As Hashtable, ByVal navhash As Hashtable, ByRef qshash As Hashtable, ByRef viewhash As Hashtable)

        If navhash("pageSize") = "10000" Then
            viewhash("viewall") = True
        Else
            viewhash("viewall") = False
        End If

        Dim oxml As New ion_two.cls_nd_xmlread
        oxml.xml_file = Me.xml_filter_file
        oxml.Load()

        Dim tmparray As New Hashtable

        If wordparts.ContainsKey("genra") Then
            Dim ogenra As New genraTranslator(Convert.ToString(wordparts("genra")))
            tmparray("genra") = ogenra.genraIndex.ToString
            wordparts.Remove("genra")


        End If

        If wordparts.ContainsKey("noaction") Then
            wordparts.Remove("noaction")
        End If
        If wordparts.ContainsKey("sort") Then

            ''  tmparray("sort") = wordparts("sort")
            Dim sortstr() As String = Split(wordparts("sort"), "::")
            Dim typeid, wayid As Int32
            Me.SortFromWord(sortstr(1), sortstr(2), typeid, wayid)
            viewhash("sortType") = typeid.ToString
            viewhash("sortWay") = wayid.ToString
            wordparts.Remove("sort")
        Else
            viewhash("sortType") = ""
            viewhash("sortWay") = ""

        End If

        If wordparts.ContainsKey("group") Then

            tmparray("group") = wordparts("group")
            wordparts.Remove("group")

        End If

        If wordparts.ContainsKey("search") Then

            tmparray("search") = wordparts("search")
            wordparts.Remove("search")

        End If

        If wordparts.ContainsKey("itemnumber") Then

            tmparray("itemnumber") = wordparts("itemnumber")
            wordparts.Remove("itemnumber")

        End If

        viewhash("pageStart") = navhash("pageStart")

        ''viewhash("") = navhash("pageStart")







        For Each key As String In wordparts.Keys

            Dim filterpart As XmlNode = oxml.GetNode_ByPath("//wpt/filter[@wordid='" + key + "']")

            Dim type As String = filterpart.Attributes("type").InnerText

            ''  Select Case filterpart.Attributes("type").InnerText

            ''  Case "options"


            Dim qsid As XmlNode = oxml.GetNode_ByPath("//wpt/filter[@wordid='" + key + "']/filterpart[text()='" + wordparts(key) + "']")
            '' if we got qsid fast meaning only simple oporation is taken
            If Not IsNothing(qsid) Then
                If Not IsNothing(qsid.Attributes("qsid")) Then
                    tmparray(key) = qsid.Attributes("qsid").InnerText
                End If
            Else

                If type = "range" Then

                    ''    Dim patternOut As String = filterpart.SelectSingleNode("qs_translate").Attributes("patternOut").InnerText

                    Dim qfrom As String = Regex.Match(wordparts(key), "(\d{1,}\.?(\d{1,})?)to(\d{1,}\.?(\d{1,})?)").Groups(1).Value
                    Dim qto As String = Regex.Match(wordparts(key), "(\d{1,}\.?(\d{1,})?)to(\d{1,}\.?(\d{1,})?)").Groups(3).Value
                    If qfrom = qto Then
                        tmparray(key) = qfrom
                    Else
                        tmparray(key) = qfrom + "~" + qto
                    End If




                ElseIf type = "discrete" Then

                    Dim discrete_part As String = Split(wordparts(key), "::")(2)

                    Dim discrete_array() As String = discrete_part.Split(",")

                    Dim qfrom = discrete_array(0)
                    Dim qto = discrete_array(discrete_array.Length - 1)

                    If qfrom.length = 1 Then qfrom = qfrom.toupper
                    If qto.length = 1 Then qto = qto.toupper

                    tmparray(key) = qfrom + "~" + qto

                End If



            End If



            ''  End Select

        Next

        qshash = tmparray

    End Function

    Public Function WordParts2JSCommand(ByVal words_js_obj As ArrayList, ByRef Lit As Literal) As Boolean

        Dim tmpArray As New ArrayList
        Dim ostringfunc As New iFunctions.cls_string
        For Each ojs As wordpart4js In words_js_obj
            Dim tmpargs As New ArrayList

            If ojs.special = True Then
                tmpargs.Add(ojs.flags)
                tmpargs.Add(ojs.passcode)

                tmpArray.Add(ostringfunc.CreateJSFunc("AddSpecialWordPart", tmpargs))
            Else
                tmpargs.Add(ojs.cat)
                tmpargs.Add(ojs.text)
                tmpargs.Add(ojs.passcode)
                If ojs.flags <> "" Then
                    tmpargs.Add(ojs.flags)
                End If

                tmpArray.Add(ostringfunc.CreateJSFunc("AddWordPart", tmpargs))
            End If
        Next

        Lit.Text += Join(tmpArray.ToArray, ";")



    End Function

    Public Function Words2SQLObjects(ByVal wordstr As String, ByRef column As String)

        Dim oxml As New ion_two.cls_nd_xmlread
        oxml.xml_file = Me.xml_words_file
        oxml.Load("words")

        Dim xmlnode As XmlNodeList = oxml.GetNodes_ByPath("word[@id='" + wordstr + "']")

        If Not IsNothing(xmlnode) Then

            column = xmlnode(0).InnerText

        End If



    End Function

    Public Function DefWords2SQLObjects(ByVal wordstr As String, ByRef column As String)

        Dim oxml As New ion_two.cls_nd_xmlread
        oxml.xml_file = Me.xml_words_file
        oxml.Load("defaults")

        Dim xmlnode As XmlNodeList = oxml.GetNodes_ByPath("defword[@wordpartid='" + wordstr + "']")

        If Not IsNothing(xmlnode) Then

            column = xmlnode(0).InnerText

        End If

    End Function
    Public Function GetQWordById(ByVal wordid As String, ByVal id As Int32) As String

        Dim oxml As New ion_two.cls_nd_xmlread
        oxml.xml_file = Me.xml_q2w_file
        oxml.Load()
        Dim node As XmlNode = oxml.GetNodes_ByPath("//wpt/filter[@wordid='" + wordid + "']").Item(0).SelectNodes("filterpart").Item(id)
        Return node.Attributes("qsid").InnerText

    End Function
    Public Function GetDiscreteWordsArray(ByVal wordid As String, ByVal startword As String, ByVal endword As String, ByRef words As ArrayList)
        Dim oxml As New ion_two.cls_nd_xmlread
        oxml.xml_file = Me.xml_filter_file
        oxml.Load()
        Dim nodes As XmlNodeList = oxml.GetNodes_ByPath("//wpt/filter[@wordid='" + wordid + "']/filterpart")

        Dim start1 = 0
        Dim end1 = 0
        Dim i = 0
        For i = 0 To nodes.Count - 1

            If nodes(i).Attributes("qsid").InnerText = startword Then
                start1 = i
            End If

            If nodes(i).Attributes("qsid").InnerText = endword Then
                end1 = i
            End If

            words.Add(nodes(i).Attributes("text").InnerText)

        Next

        Dim tmpwords As New ArrayList

        For i = start1 To end1
            tmpwords.Add(words(i))
        Next

        words = tmpwords


        '' words.RemoveRange(0, start1)
        '' words.RemoveRange(end1 - start1 + 1, words.Count - end1 - start1 - 1)


    End Function
    Function SortFromWord(ByVal sorttype As String, ByVal sortway As String, ByRef typeid As Int32, ByRef wayid As Int32)

        Select Case sortway
            Case "asc"
                wayid = 1
            Case "desc"
                wayid = 0
        End Select

        Select Case sorttype
            Case "sell_price"
                typeid = 0
            Case "weight"
                typeid = 1
            Case "measure1"
                typeid = 2
            Case "createdate"
                typeid = 3
            Case "metal"
                typeid = 2
        End Select
    End Function

    Public Class wordpart4js
        Public cat As String
        Public text As String
        Public passcode As String
        Public flags As String = ""
        Public special As Boolean = False

    End Class
    Public Class AllItemsGenraCount
        Inherits Hashtable
        Sub New()
            Me.Add("newitems", True)
            Me.Add("sale", True)
            Me.Add("noaction", True)
        End Sub
        Function Check(ByVal hash As Hashtable) As Boolean

            For Each key As String In hash.Keys

                If Me.ContainsKey(key) Then
                    Return True
                End If
            Next
            Return False
        End Function
    End Class
    Public Class genraTranslator
        Public genraText As String
        Public passcodetext As String
        Public plateType As Int32
        Public genraIndex As Int32
        Sub New(ByVal genraid As Int32)
            Select Case genraid
                Case 0
                    Me.genraText = "Diamonds"
                    Me.passcodetext = "diamonds"
                    Me.plateType = 1
                    Me.genraIndex = 0
                Case 1
                    Me.genraText = "Gemstones"
                    Me.passcodetext = "gemstones"
                    Me.plateType = 2
                    Me.genraIndex = 1
                Case 2
                    Me.genraText = "Jewelry"
                    Me.passcodetext = "jewelry"
                    Me.plateType = 3
                    Me.genraIndex = 2
                Case 3
                    Me.genraText = "Fancy Diamonds"
                    Me.passcodetext = "fancy"
                    Me.plateType = 1
                    Me.genraIndex = 3
            End Select
        End Sub
        Sub New(ByVal genrastring As String)
            Select Case genrastring.ToLower
                Case "diamonds"
                    Me.genraText = "Diamonds"
                    Me.passcodetext = "diamonds"
                    Me.plateType = 1
                    Me.genraIndex = 0
                Case "gemstones"
                    Me.genraText = "Gemstones"
                    Me.passcodetext = "gemstones"
                    Me.plateType = 2
                    Me.genraIndex = 1
                Case "jewelry"
                    Me.genraText = "Jewelry"
                    Me.passcodetext = "jewelry"
                    Me.plateType = 3
                    Me.genraIndex = 2
                Case "fancy"
                    Me.genraText = "Fancy Diamonds"
                    Me.passcodetext = "fancy"
                    Me.plateType = 1
                    Me.genraIndex = 3

            End Select
        End Sub

    End Class

    Public Class viewer_item_v1
        Public item As New Object ''ion_two.skl_lst_inventory
        Public isapi_link As String
        Public price_coll As New ArrayList
        Public icon_coll As New ArrayList
        Public Function AddPrice(ByVal price_string As String, ByVal price As String, Optional ByVal color As String = "")
            Dim tmpprice As New price_item_v1
            tmpprice.price = price
            tmpprice.price_string = price_string
            If color <> "" Then
                tmpprice.color = "color:#" + color
            Else
                tmpprice.color = ""
            End If

            Me.price_coll.Add(tmpprice)

        End Function
        Public Function AddIcons(ByVal icon_pic As String, ByVal funcname As String, ByVal jsparams As ArrayList)

            Dim tmpIcon As New icon_item_v1
            tmpIcon.icon_pic = icon_pic
            Dim ostringfunc As New iFunctions.cls_string
            tmpIcon.jsfunc = ostringfunc.CreateJSFunc(funcname, jsparams)

            Me.icon_coll.Add(tmpIcon)

        End Function


        Private Class price_item_v1
            Public color As String
            Public price As String
            Public price_string As String
        End Class
        Private Class icon_item_v1
            Public icon_pic As String
            Public jsfunc As String
        End Class
    End Class
End Class
