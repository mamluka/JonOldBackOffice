Imports System.Math
Public Class cls_custom_jewel_lgk
    Inherits iFoundation.cls_error_connection
    Public conn_string As String '' the conn string
    Public db_type As Int32
    Public Function load_settings_byid(ByVal id As Int32, ByVal price As Decimal) As Boolean


        Dim oDG_search As New iDac.cls_sql_read
        Dim sSql As String = "select * from vv_jewelry_full where (subcategory_id=44) and (shopstatus = 0) and (id =" + Convert.ToString(id) + ")"





        oDG_search._connection_string = Me.conn_string
        oDG_search._tablename = "vv_jewelry_full"


        oDG_search.transact_read(sSql)

        Dim oData As DataTable = oDG_search._datatable

        Dim oPrice As New ion_two.cons_price

        oPrice._sell_price = oData.Rows(0).Item("sell_price")
        oPrice._isspecial = oData.Rows(0).Item("onspecial")
        oPrice._special_from = oData.Rows(0).Item("onspecial_from_date")
        oPrice._special_to = oData.Rows(0).Item("onspecial_to_date")
        oPrice._dealer_price = oData.Rows(0).Item("dealer_price")
        oPrice._special_dealer_price = oData.Rows(0).Item("special_dealer_price")
        oPrice._special_sell_price = oData.Rows(0).Item("special_sell_price")
        oPrice.get_price()

        price = oPrice._correct_price

    End Function

    Public Overloads Function make_init_html_cs(ByVal stone_type As String, ByVal stone_shape As String, ByVal color_index As Int32, ByVal color_genre As Int16, ByVal price_val1 As String, ByVal price_val2 As String, ByVal weight_val1 As String, ByVal weight_val2 As String, ByVal minp As String, ByVal maxp As String, ByVal minw As String, ByVal maxw As String, ByVal new_search As Boolean, ByRef OutInitHTML As String)

        OutInitHTML = "("
        OutInitHTML += Convert.ToString(stone_type)
        OutInitHTML += ",'" + stone_shape
        OutInitHTML += "'," + Convert.ToString(color_genre)
        OutInitHTML += "," + Convert.ToString(color_index)
        OutInitHTML += "," + Convert.ToString(price_val1)
        OutInitHTML += "," + Convert.ToString(price_val2)
        OutInitHTML += "," + Convert.ToString(weight_val1)
        OutInitHTML += "," + Convert.ToString(weight_val2)
        OutInitHTML += "," + Convert.ToString(minp)
        OutInitHTML += "," + Convert.ToString(maxp)
        OutInitHTML += "," + Convert.ToString(minw)
        OutInitHTML += "," + Convert.ToString(maxw)
        OutInitHTML += "," + Convert.ToString(new_search.ToString.ToLower)
        OutInitHTML += ")"






    End Function
    ''this makes defaout
    Public Overloads Function make_init_html_cs(ByRef outInitHTML As String, Optional ByVal stoneid As Int32 = 1)
        Dim oajaxtable As New ion_two.cls_ajax_maketable
        oajaxtable.conn_string = Me.conn_string
        Dim otmpshape As New ArrayList
        otmpshape.Add("Any Shape")
        oajaxtable.make_sql_str(stoneid, 1, 0, otmpshape, 0, 0, 0, 0)
        oajaxtable.get_table_info()


        outInitHTML = "("
        outInitHTML += Convert.ToString(stoneid)
        outInitHTML += ",'" + "|1|"
        outInitHTML += "'," + Convert.ToString(1)
        outInitHTML += "," + Convert.ToString(0)
        outInitHTML += "," + Convert.ToString(oajaxtable.min_price)
        outInitHTML += "," + Convert.ToString(oajaxtable.max_price)
        outInitHTML += "," + Convert.ToString(oajaxtable.min_weight)
        outInitHTML += "," + Convert.ToString(oajaxtable.max_weight)
        outInitHTML += "," + Convert.ToString(oajaxtable.min_price)
        outInitHTML += "," + Convert.ToString(oajaxtable.max_price)
        outInitHTML += "," + Convert.ToString(oajaxtable.min_weight)
        outInitHTML += "," + Convert.ToString(oajaxtable.max_weight)
        outInitHTML += "," + "true"
        outInitHTML += ")"


    End Function

    Function save_cj_toDB(ByVal ocjitem As ion_two.cls_custom_jewel_skl, ByVal userid As Int32, ByRef randomid As Int64) As Boolean

        Dim berror As Boolean = False

        Randomize()
        Dim RandomCS_Id As Int64 = Abs(CInt(Int((10000000 - 99999999 + 1) * Rnd() + 1000000)))

        randomid = RandomCS_Id

        Dim oTmpDataset As DataSet = New ion_two.ds_custom_jewel
        Dim oTmpDataTable As DataTable = oTmpDataset.Tables("inv_jeweldesign_save")

        Dim oTmpDatarow As DataRow
        oTmpDatarow = oTmpDataTable.NewRow

        oTmpDatarow("random_index") = RandomCS_Id
        oTmpDatarow("userid") = userid

        '' has section
        oTmpDatarow("has_cs") = ocjitem.has_cs
        oTmpDatarow("has_ss") = ocjitem.has_ss
        oTmpDatarow("has_style") = ocjitem.has_style
        oTmpDatarow("has_semi") = ocjitem.has_semi
        '' cs section
        oTmpDatarow("cs_price") = ocjitem.cs_price
        oTmpDatarow("cs_price_formatted") = ocjitem.cs_price_formatted
        oTmpDatarow("cs_weight") = ocjitem.cs_weight
        oTmpDatarow("cs_weight_formatted") = ocjitem.cs_weight_formatted
        oTmpDatarow("cs_shapeid") = ocjitem.cs_shapeid
        oTmpDatarow("cs_shape") = ocjitem.cs_shape
        oTmpDatarow("cs_item_link") = ocjitem.cs_item_link
        oTmpDatarow("cs_icon_pic") = ocjitem.cs_icon_pic
        oTmpDatarow("cs_item_id") = ocjitem.cs_item_id
        oTmpDatarow("cs_size") = ocjitem.cs_size
        oTmpDatarow("cs_txt_type") = ocjitem.cs_txt_type
        oTmpDatarow("cs_color") = ocjitem.cs_color
        oTmpDatarow("cs_shape_txt_preview") = ocjitem.cs_shape_txt_preview

        ''ss
        oTmpDatarow("ss_price") = ocjitem.ss_price
        oTmpDatarow("ss_price_formatted") = ocjitem.ss_price_formatted
        oTmpDatarow("ss_weight") = ocjitem.ss_weight
        oTmpDatarow("ss_weight_formatted") = ocjitem.ss_weight_formatted
        oTmpDatarow("ss_shapeid") = ocjitem.ss_shapeid
        oTmpDatarow("ss_shape") = ocjitem.ss_shape
        oTmpDatarow("ss_quality") = ocjitem.ss_quality
        oTmpDatarow("ss_qualityid") = ocjitem.ss_qualityid
        oTmpDatarow("ss_size") = ocjitem.ss_size
        oTmpDatarow("ss_slider_val") = ocjitem.ss_slider_val
        oTmpDatarow("ss_desc") = ocjitem.ss_desc
        oTmpDatarow("ss_extrainfo") = ocjitem.ss_extrainfo
        oTmpDatarow("ss_trueid") = ocjitem.ss_trueid
        oTmpDatarow("ss_link") = ocjitem.ss_link
        oTmpDatarow("ss_full_link") = ocjitem.ss_full_link

        ''set

        oTmpDatarow("set_model_id") = ocjitem.set_model_id
        oTmpDatarow("set_price") = ocjitem.set_price
        oTmpDatarow("set_price_formatted") = ocjitem.set_price_formatted
        oTmpDatarow("set_metal_type") = ocjitem.set_metal_type
        oTmpDatarow("set_metal_id") = ocjitem.set_metal_id
        oTmpDatarow("set_model_picsrc") = ocjitem.set_model_picsrc
        oTmpDatarow("deliver_mathod") = ocjitem.deliver_mathod
        oTmpDatarow("set_ring_size") = ocjitem.set_ring_size
        ''semi
        oTmpDatarow("semi_model_id") = ocjitem.semi_model_id
        oTmpDatarow("semi_price") = ocjitem.semi_price
        oTmpDatarow("semi_price_formatted") = ocjitem.semi_price_formatted
        oTmpDatarow("semi_metal_type") = ocjitem.semi_metal_type
        oTmpDatarow("semi_metal_id") = ocjitem.semi_metal_id
        oTmpDatarow("semi_model_picsrc") = ocjitem.semi_model_picsrc
        oTmpDatarow("semi_ring_size") = ocjitem.semi_ring_size
        oTmpDatarow("semi_style") = ocjitem.semi_style
        oTmpDatarow("semi_weight_formatted") = ocjitem.semi_weight_formatted
        oTmpDatarow("semi_ss_full_desc") = ocjitem.semi_ss_full_desc

        oTmpDatarow("cs_inithtml") = ocjitem.cs_inithtml
        oTmpDatarow("ss_inithtml") = ocjitem.ss_inithtml
        oTmpDatarow("set_inithtml") = ocjitem.set_inithtml


        oTmpDataTable.Rows.Add(oTmpDatarow)

        Dim oTransaction As New iDac.cls_T_transaction
        oTransaction._connection_string = Me.conn_string
        oTransaction._dbtype = Me.db_type
        berror = oTransaction.start()
        If berror Then
            Me._err_number = oTransaction._err_number
            Me._err_description = oTransaction._err_description
            Me._err_source = oTransaction._err_source
            Return True
        End If

        Dim oTransactor_1 As New iDac.cls_T_transactor
        oTransactor_1._connection_string = Me.conn_string
        oTransactor_1._dbtype = Me.db_type

        '--- Prepare and load table 1
        Dim oTable1 As New iDac.cls_cll_datatables
        oTable1._datatable = oTmpDataTable
        oTransactor_1._i_cll_datatables.Add(oTable1)

        '--- Assign the transaction to the transactor
        oTransactor_1._transaction = oTransaction._transaction

        '--- Write Table
        berror = oTransactor_1.transact_insert
        If berror Then
            oTransaction._transaction.Rollback()
            Me._err_number = oTransactor_1._err_number
            Me._err_description = oTransactor_1._err_description
            Me._err_source = oTransactor_1._err_source
            Return True
        End If

        berror = oTransaction.close()
        If berror Then
            Me._err_number = oTransaction._err_number
            Me._err_description = oTransaction._err_description
            Me._err_source = oTransaction._err_source
            Return True
        End If


        oTable1 = Nothing
        oTransactor_1 = Nothing
        oTransaction = Nothing




    End Function
    Function read_cj_by_userid(ByVal userid As Int32, ByRef ocjitem_coll As Collection)

        Dim oSqlread As New iDac.cls_sql_read
        Dim sSql As String = "select * from inv_jeweldesign_save where userid = " + Convert.ToString(userid)





        oSqlread._connection_string = Me.conn_string
        oSqlread._tablename = "inv_jeweldesign_save"


        oSqlread.transact_read(sSql)

        Dim oData As DataTable = oSqlread._datatable

        Dim i As Int32
        ''puts inside the coll
        For i = 0 To oData.Rows.Count - 1
            Dim tmpOcjitem As New ion_two.cls_custom_jewel_skl
            Me.read_cj_row2obj(oData.Rows(i), tmpOcjitem)
            ocjitem_coll.Add(tmpOcjitem)
        Next

    End Function
    Function read_cj_by_randomid(ByVal randomid As Int64, ByRef ocjitem_coll As Collection)

        Dim oSqlread As New iDac.cls_sql_read
        Dim sSql As String = "select * from inv_jeweldesign_save where random_index = " + Convert.ToString(randomid)





        oSqlread._connection_string = Me.conn_string
        oSqlread._tablename = "inv_jeweldesign_save"


        oSqlread.transact_read(sSql)

        Dim oData As DataTable = oSqlread._datatable

        Dim i As Int32
        ''puts inside the coll
        For i = 0 To oData.Rows.Count - 1
            Dim tmpOcjitem As New ion_two.cls_custom_jewel_skl
            Me.read_cj_row2obj(oData.Rows(i), tmpOcjitem)
            ocjitem_coll.Add(tmpOcjitem)
        Next
    End Function
    Function read_cj_row2obj(ByVal oTmpDatarow As DataRow, ByRef ocjitem As ion_two.cls_custom_jewel_skl)

        ''load the save params

        Dim ocjsave As New ion_two.cls_custom_jewel_skl.cj_save_params
        ocjsave.randomid = (oTmpDatarow("random_index"))
        ocjsave.userid = oTmpDatarow("userid")

        ocjitem.save_params = ocjsave


        '' has section
        ocjitem.has_cs = oTmpDatarow("has_cs")
        ocjitem.has_ss = oTmpDatarow("has_ss")
        ocjitem.has_style = oTmpDatarow("has_style")
        ocjitem.has_semi = oTmpDatarow("has_semi")
        '' cs section
        ocjitem.cs_price = oTmpDatarow("cs_price")
        ocjitem.cs_price_formatted = oTmpDatarow("cs_price_formatted")
        ocjitem.cs_weight = oTmpDatarow("cs_weight")
        ocjitem.cs_weight_formatted = oTmpDatarow("cs_weight_formatted")
        ocjitem.cs_shapeid = oTmpDatarow("cs_shapeid")
        ocjitem.cs_shape = oTmpDatarow("cs_shape")
        ocjitem.cs_item_link = oTmpDatarow("cs_item_link")
        ocjitem.cs_icon_pic = oTmpDatarow("cs_icon_pic")
        ocjitem.cs_item_id = oTmpDatarow("cs_item_id")
        ocjitem.cs_size = oTmpDatarow("cs_size")
        ocjitem.cs_txt_type = oTmpDatarow("cs_txt_type")
        ocjitem.cs_color = oTmpDatarow("cs_color")
        ocjitem.cs_shape_txt_preview = oTmpDatarow("cs_shape_txt_preview")

        ''ss
        If ocjitem.has_ss Then
            ocjitem.ss_price = oTmpDatarow("ss_price")
            ocjitem.ss_price_formatted = oTmpDatarow("ss_price_formatted")
            ocjitem.ss_weight = oTmpDatarow("ss_weight")
            ocjitem.ss_weight_formatted = oTmpDatarow("ss_weight_formatted")
            ocjitem.ss_shapeid = oTmpDatarow("ss_shapeid")
            ocjitem.ss_shape = oTmpDatarow("ss_shape")
            ocjitem.ss_quality = oTmpDatarow("ss_quality")
            ocjitem.ss_qualityid = oTmpDatarow("ss_qualityid")
            ocjitem.ss_size = oTmpDatarow("ss_size")
            ocjitem.ss_slider_val = oTmpDatarow("ss_slider_val")
            ocjitem.ss_desc = oTmpDatarow("ss_desc")
            ocjitem.ss_extrainfo = oTmpDatarow("ss_extrainfo")
            ocjitem.ss_trueid = oTmpDatarow("ss_trueid")
            ocjitem.ss_link = oTmpDatarow("ss_link")
            ocjitem.ss_full_link = oTmpDatarow("ss_full_link")
        End If
        ''set
        If ocjitem.has_style Then
            ocjitem.set_model_id = oTmpDatarow("set_model_id")
            ocjitem.set_price = oTmpDatarow("set_price")
            ocjitem.set_price_formatted = oTmpDatarow("set_price_formatted")
            ocjitem.set_metal_type = oTmpDatarow("set_metal_type")
            ocjitem.set_metal_id = oTmpDatarow("set_metal_id")
            ocjitem.set_model_picsrc = oTmpDatarow("set_model_picsrc")
            ocjitem.deliver_mathod = oTmpDatarow("deliver_mathod")
            ocjitem.set_ring_size = oTmpDatarow("set_ring_size")
        End If
        ''semi
        If ocjitem.has_semi Then
            ocjitem.semi_model_id = oTmpDatarow("semi_model_id")
            ocjitem.semi_price = oTmpDatarow("semi_price")
            ocjitem.semi_price_formatted = oTmpDatarow("semi_price_formatted")
            ocjitem.semi_metal_type = oTmpDatarow("semi_metal_type")
            ocjitem.semi_metal_id = oTmpDatarow("semi_metal_id")
            ocjitem.semi_model_picsrc = oTmpDatarow("semi_model_picsrc")
            ocjitem.semi_ring_size = oTmpDatarow("semi_ring_size")
            ocjitem.semi_style = oTmpDatarow("semi_style")
            ocjitem.semi_weight_formatted = oTmpDatarow("semi_weight_formatted")
            ocjitem.semi_ss_full_desc = oTmpDatarow("semi_ss_full_desc")
        End If
        ocjitem.cs_inithtml = oTmpDatarow("cs_inithtml")
        ocjitem.ss_inithtml = oTmpDatarow("ss_inithtml")
        ocjitem.set_inithtml = oTmpDatarow("set_inithtml")

    End Function

End Class
