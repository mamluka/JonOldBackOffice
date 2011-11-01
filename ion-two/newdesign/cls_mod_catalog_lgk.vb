Imports System.Xml
Public Class cls_mod_catalog_lgk
    Public conn_string As String
    Public db_type As String
    Public currencyID As String
    Public isdealer As Boolean

    Public Function ModifyByModid(ByVal qhash As Hashtable, ByRef oface As ion_two.cls_catalog_face_v1, ByRef infoparts As ArrayList, ByRef priceparts As ArrayList, ByVal oplate As ion_two.skl_lst_inventory) As Boolean

        Select Case qhash("modid")

            Case "1"
                Me.SideStoneMod(qhash, oface, infoparts, priceparts)
            Case "3", "5"
                Me.StoneStripMod(qhash, oface, infoparts, priceparts, oplate)
            Case "4"
                Me.StoneStripModSS(qhash, oface, infoparts, priceparts)



        End Select



    End Function

    Public Function SideStoneMod(ByVal qhash As Hashtable, ByRef oface As ion_two.cls_catalog_face_v1, ByRef infoparts As ArrayList, ByRef priceparts As ArrayList) As Boolean

        Dim osize As New cls_diam_size
        osize.conn_string = Me.conn_string
        Dim size_coll As New Collection
        Dim ostringfunc As New iFunctions.cls_string
        Dim matchitem As New cls_diam_item
        osize.conn_string = Me.conn_string
        osize.read_sizes_by_shape(Convert.ToInt32(qhash("shapeid")), size_coll, True)

        For Each item As cls_diam_item In size_coll

            If item.weight = Convert.ToDecimal(qhash("weight")) Then
                matchitem = item
                Exit For
            End If

        Next

        priceparts.Clear()

        Dim price1 As New cls_catalog_lgk.pricepart_v1
        price1.desc = "Price:"
        price1.jid = "pr_price"
        price1.price = matchitem.price
        ostringfunc.format_currency(price1.price, price1.price_formatted, " $")

        priceparts.Add(price1)

        Dim image_item As Int32
        Dim opic As New ion_two.cls_mod_images
        Dim image_item_id As Int32
        opic.conn_string = Me.conn_string

        opic.get_ss_image_byid(Convert.ToInt32(qhash("id")), matchitem.weight * 2, image_item)

        opic.load_images(image_item)

        oface.pics.page = opic.banner_pic


        'For Each price As cls_catalog_lgk.pricepart_v1 In priceparts
        '    If price.tag = "price" Then
        '        price.price = matchitem.price

        '        ostringfunc.format_currency(price.price, price.price_formatted, " $")
        '    End If
        '    If price.tag = "retail" Then
        '        price.price = matchitem.price * 3.2

        '        ostringfunc.format_currency(price.price, price.price_formatted, " $")
        '    End If
        'Next

        For Each info As cls_catalog_lgk.infopart_v1 In infoparts
            If info.cat = "quality" Then

                Select Case qhash("quality")
                    Case "1"
                        info.text = "D-F"
                    Case "2"
                        info.text = "G-H"
                End Select

            End If

            If info.cat = "weight" Then
                ostringfunc.format_decimal(matchitem.weight * 2, info.text, " Ct.")

            End If
        Next

        oface.initjs_array.Add("Locals.mods['ssitem']=true")
        oface.initjs_array.Add("UpdateChangeObject('pr_price'," + Convert.ToString(priceparts(0).price) + ")")

    End Function
    Public Function StoneStripMod(ByVal qhash As Hashtable, ByRef oface As ion_two.cls_catalog_face_v1, ByRef infoparts As ArrayList, ByRef priceparts As ArrayList, ByVal oplate As ion_two.skl_lst_inventory) As Boolean
        'Dim ostringfunc As New iFunctions.cls_string
        'Dim ostrip As New ion_two.cls_stonestrip
        'ostrip.conn_string = Me.conn_string
        'ostrip.db_type = Me.db_type
        '''ostrip.key_xml_file = 
        'ostrip.GetXMLByKey(qhash("key"))

        'ostrip.GetPriceByStoneId(qhash("key"), Convert.ToInt32(qhash("stripid")), Convert.ToInt32(qhash("stoneid")), priceparts(1).price)

        'ostringfunc.format_currency(priceparts(1).price, priceparts(1).price_formatted, " $")
        'priceparts.RemoveAt(0)

        'oface.initjs_array.Add("Locals.mods['stonestrip']=true")
        'oface.initjs_array.Add("UpdateChangeObject('pr_price'," + Convert.ToString(priceparts(0).price) + ")")

        Dim ostringfunc As New iFunctions.cls_string
        Dim ostrip As New ion_two.cls_stonestrip
        ostrip.conn_string = Me.conn_string
        ostrip.db_type = Me.db_type
        ''ostrip.key_xml_file = 
        Dim ocatalog As New ion_two.cls_catalog_lgk
        Dim id As Int32

        ocatalog.FindPricePartByTag(priceparts, "price|special", id)
        ostrip.GetXMLByKey(qhash("key"))

        ostrip.GetPriceByStoneId(qhash("key"), Convert.ToInt32(qhash("stripid")), Convert.ToInt32(qhash("stoneid")), priceparts(id).price)
        priceparts(id).jid = "pr_price"

        oface.initjs_array.Add("Locals.origprice=" + priceparts(id).price.ToString + "")


        Dim textweight As String
        Dim weight As String
        ostrip.GetTextWeightByStoneId(qhash("key"), Convert.ToInt32(qhash("stripid")), Convert.ToInt32(qhash("stoneid")), textweight, weight)

        ostringfunc.format_currency(priceparts(id).price, priceparts(id).price_formatted, " $")
        '' priceparts.RemoveAt(0)


        oface.initjs_array.Add("Locals.mods['stonestrip']=true")
        oface.initjs_array.Add("UpdateChangeObject('pr_price'," + Convert.ToString(priceparts(id).price) + ")")

        ocatalog.FindPricePartByTag(priceparts, "retail", id)



        If id > -1 Then
            priceparts.RemoveAt(id)
        End If

        ocatalog.FindPricePartByTag(priceparts, "dealer", id)

        If id > -1 Then
            priceparts.RemoveAt(id)

        End If



        ''   ocatalog.FindInfoPartByCat(infoparts, "weight", id)
        ''  infoparts(id).text = textweight

        If qhash("modid") = "5" Then
            ocatalog.FindInfoPartByCat(infoparts, "pendant type:", id)
        Else
            ocatalog.FindInfoPartByCat(infoparts, "earrings type:", id)
        End If



        If qhash("modid") = "5" Then
            oface.page.title = textweight + " " + oplate._subplate._middlestone + " " + infoparts(id).text + " Pendant"
        Else
            oface.page.title = textweight + " " + oplate._subplate._middlestone + " " + infoparts(id).text + " Earrings"
        End If




        oface.initjs_array.Add("UpdateChangeObject('stoneshape','" + infoparts(id).text + "')")
        oface.initjs_array.Add("UpdateChangeObject('stonequality','E-F/VS')")
        oface.initjs_array.Add("UpdateChangeObject('stoneweight'," + weight + ")")
        oface.initjs_array.Add("UpdateChangeObject('stonetextweight','" + textweight + "')")
        oface.initjs_array.Add("UpdateChangeObject('stonekey','" + qhash("key") + "')")
        oface.initjs_array.Add("UpdateChangeObject('stonestripid','" + qhash("stripid") + "')")
        oface.initjs_array.Add("UpdateChangeObject('stonestripstoneid','" + qhash("stoneid") + "')")



    End Function
    Public Function StoneStripModSS(ByVal qhash As Hashtable, ByRef oface As ion_two.cls_catalog_face_v1, ByRef infoparts As ArrayList, ByRef priceparts As ArrayList) As Boolean
        Dim ostringfunc As New iFunctions.cls_string
        Dim ostrip As New ion_two.cls_stonestrip
        ostrip.conn_string = Me.conn_string
        ostrip.db_type = Me.db_type
        ''ostrip.key_xml_file = 
        Dim ocatalog As New ion_two.cls_catalog_lgk
        Dim id As Int32

        ocatalog.FindPricePartByTag(priceparts, "price", id)
        ostrip.GetXMLByKey(qhash("key"))

        ostrip.GetPriceByStoneId(qhash("key"), Convert.ToInt32(qhash("stripid")), Convert.ToInt32(qhash("stoneid")), priceparts(id).price)

        Dim ocurrency As New ion_two.cls_currency
        ocurrency._connection_string = Me.conn_string
        ocurrency._dbtype = Me.db_type

        Dim ocurrency_obj As New ion_two.skl_currency

        ocurrency.ReadCurrencyByCode(Me.currencyID, ocurrency_obj)

        priceparts(id).price *= ocurrency_obj.rate

        priceparts(id).jid = "pr_price"
        priceparts(id).middleline = False

        Dim textweight As String
        Dim weight As String
        ostrip.GetTextWeightByStoneId(qhash("key"), Convert.ToInt32(qhash("stripid")), Convert.ToInt32(qhash("stoneid")), textweight, weight)

        ostringfunc.format_currency(priceparts(id).price, priceparts(id).price_formatted, " $")
        '' priceparts.RemoveAt(0)


        oface.initjs_array.Add("Locals.mods['stonestrip']=true")
        oface.initjs_array.Add("UpdateChangeObject('pr_price'," + Convert.ToString(priceparts(id).price) + ")")

        ocatalog.FindPricePartByTag(priceparts, "retail", id)



        If id > -1 Then
            priceparts.RemoveAt(id)
        End If

        ocatalog.FindPricePartByTag(priceparts, "dealer", id)

        If id > -1 Then
            priceparts.RemoveAt(id)

        End If





        ocatalog.FindInfoPartByCat(infoparts, "weight:", id)
        infoparts(id).text = textweight


        ocatalog.FindInfoPartByCat(infoparts, "diamond cut:", id)

        oface.page.title = textweight + " " + infoparts(id).text + " Side Diamonds"


        oface.initjs_array.Add("UpdateChangeObject('stoneshape','" + infoparts(id).text + "')")
        oface.initjs_array.Add("UpdateChangeObject('stonequality','E-F/VS')")
        oface.initjs_array.Add("UpdateChangeObject('stoneweight'," + weight + ")")
        oface.initjs_array.Add("UpdateChangeObject('stonetextweight','" + textweight + "')")




    End Function
    Function ModifyPlateByMode(ByVal qhash As Hashtable, ByRef oface As ion_two.cls_catalog_face_v1, ByRef infoparts As ArrayList, ByRef priceparts As ArrayList, ByRef oplate As ion_two.skl_lst_inventory) As Boolean
        Select Case qhash("modid")

            Case "12" '' change back to enhanced
                Me.ChangeToEnhancedDiamonds(oplate)



        End Select

    End Function
    Function ChangeToEnhancedDiamonds(ByRef oplate As ion_two.skl_lst_inventory)

        ' Dim ocurrency As New cls_currency
        ' ocurrency._connection_string = Me.conn_string
        ' ocurrency._dbtype = Me.db_type
        'Dim ocurrency_obj As New skl_currency

        '' ocurrency.ReadCurrencyByCode(Me.currencyID, ocurrency_obj)
        oplate._appraisal_price *= 0.4
        oplate._sell_price *= 0.4
        oplate._dealer_price *= 0.4
        '' oplate._purchase_price *= ocurrency_obj.rate
        oplate._special_dealer_price *= 0.4
        oplate._special_sell_price *= 0.4





        Dim oPrice As New ion_two.cons_price
        oPrice._isdealer = Me.isdealer
        oPrice._sell_price = oplate._sell_price
        oPrice._isspecial = oplate._onspecial
        oPrice._special_from = oplate._onspecial_from_date
        oPrice._special_to = oplate._onspecial_to_date
        oPrice._dealer_price = oplate._dealer_price
        oPrice._special_dealer_price = oplate._special_dealer_price
        oPrice._special_sell_price = oplate._special_sell_price
        oPrice._onbargain = oplate.onbargain

        oPrice.get_price_html()
        
        oPrice.get_price()
        
        oplate._pricing = oPrice

        oplate._subplate._jewel_extended.cs_type += " (clarity enhanced)"


    End Function
End Class
