Imports System.Web
Public Class cls_advanced_cart
    Inherits iFoundation.cls_error_connection
    ''each type of item will get each own collection to be looped apon
    Public normal_items As New ArrayList '' like stuff we get via id=
    Public ocj_items As New ArrayList '' we send a ocjitem obj
    Public mod_items As New ArrayList '' all items that are modded and not like id number
    Public se_items As New ArrayList '' all stone exchange items

    ''get stuff
    Public total_amount As Decimal
    Public pictures As New ion_two.cls_pictures
    Public total_amount_withshipping As Decimal
    Public shipping_price As Decimal
    Public shipping_id As Int32
    Public shipping_recommended As Int32

    Public slot_config As New Hashtable
    Public paypal_hash As New Hashtable
    Public convertrate As Decimal = 1
    Public isdealer As Boolean
    Public googlehash As New Hashtable
    ''this func return the formatted string of money to save params
    Sub New()
        total_amount = 0
        Dim oshipping As New cls_shipping
        oshipping._convertrate = Me.convertrate
        oshipping.get_fixedprice_bytype(1, Me.shipping_price)
        Me.shipping_id = 1


    End Sub
    Function CreatePayPalExtras()

        ''create  desc for all items

        Dim desc As String

        Dim itemcounter As Int16 = 0
        itemcounter += Me.normal_items.Count
        itemcounter += Me.se_items.Count
        itemcounter += Me.ocj_items.Count
        Dim ostringfunc As New iFunctions.cls_string
        If itemcounter = 1 Then

            If Me.normal_items.Count > 0 Then
                desc += Me.normal_items(0).desc.replace("<br>", " ")
                desc = ostringfunc.ClearHTMLTagsReturn(desc)
            End If

            If Me.ocj_items.Count > 0 Then
                desc += Me.ocj_items(0).cs.desc.replace("<br>", " ") + " Custom Ring"
                desc = ostringfunc.ClearHTMLTagsReturn(desc)
            End If

            If Me.se_items.Count > 0 Then
                desc += Me.se_items(0).cs.desc.replace("<br>", " ") + " Custom Ring"
                desc = ostringfunc.ClearHTMLTagsReturn(desc)
            End If


        Else

            desc = "Combined items"

        End If

        Me.paypal_hash("item_name") = desc

        ''Dim ostringfunc As New iFunctions.cls_string
        ''ostringfunc.format_decimal(Me.total_amount_withshipping, Me.paypal_hash("amount"))
        Me.paypal_hash("amount") = Format(Me.total_amount, "####0.00")
        Me.paypal_hash("shipping") = Me.shipping_price




        ''For Each item As cls_advanced_cart_item_atom In Me.normal_items

        ''desc()

        ''Next

    End Function
    Function formatMoney(ByVal price As Decimal) As String
        Dim ostringfunc As New iFunctions.cls_string
        Dim tmp As String
        ostringfunc.format_currency(price, tmp, " $")

        Return tmp
    End Function

    Function formatItemNumber(ByRef number As String, ByVal no_itemnumber As Boolean) As String
        If no_itemnumber Then
            Return ""
        Else
            Return number
        End If
    End Function
    Function checkOption(ByVal str As String, ByVal options As ArrayList) As Boolean

        Dim i As Int32

        For i = 0 To options.Count - 1
            If options(i) = str Then
                Return True
            End If
        Next

        Return False

    End Function
    Function bool2display(ByVal bool As Boolean) As String
        If bool Then
            Return "inline"
        Else
            Return "none"
        End If
    End Function
    Function checkItemURL(ByVal str1 As String, ByVal str2 As String) As String

        If str2 <> "" Then
            Return str2
        Else
            Return str1
        End If

    End Function
    Function get_email_desc_bymodid(ByVal modid As Int16, ByVal item_number As String)
        Select Case modid
            Case 0
                Return "item number " + item_number
            Case 1
                Return "those side stones"
            Case 2
                Return "this setting/mouting"
            Case 4
                Return "this setting style"
            Case 3
                Return "item number " + item_number

        End Select
    End Function

    Function add_normal_item(ByVal nid As Int32, Optional ByVal nquantity As Int32 = 1, Optional ByVal nJewelrysize As String = "") As Boolean
        On Error GoTo ErrorHandler
        Dim bError As Boolean = False
        ''check for double items

        Dim i As Int32

        For i = 0 To Me.normal_items.Count - 1

            If nid = Me.normal_items(i).id And Me.normal_items(i).tmpdelete = False Then
                Return False
                Exit Function

            End If
        Next

        Dim oPlate As New ion_two.skl_lst_inventory
        Dim oTmpInventory As New ion_two.cls_inventory_lgc
        oTmpInventory._connection_string = Me._connection_string
        oTmpInventory._dbtype = Me._dbtype

        bError = oTmpInventory.load(nid, oPlate, Me.pictures, Me.isdealer, False)
        If bError Then
            Me._err_number = oTmpInventory._err_number
            Me._err_description = oTmpInventory._err_description
            Me._err_source = oTmpInventory._err_source
            Return True
        End If
        '----- load price

        Dim oPriceConstructor As New ion_two.cons_price
        oPriceConstructor._sell_price = oPlate._sell_price
        oPriceConstructor._special_sell_price = oPlate._special_sell_price
        oPriceConstructor._dealer_price = oPlate._dealer_price
        oPriceConstructor._special_dealer_price = oPlate._special_dealer_price
        oPriceConstructor._isspecial = oPlate._onspecial
        oPriceConstructor._special_from = oPlate._onspecial_from_date
        oPriceConstructor._special_to = oPlate._onspecial_to_date
        oPriceConstructor._isdealer = Me.isdealer
        oPriceConstructor._onbargain = oPlate.onbargain
        bError = oPriceConstructor.get_price()
        If bError Then
            Me._err_number = oPriceConstructor._err_number
            Me._err_description = oPriceConstructor._err_description
            Me._err_source = oPriceConstructor._err_source
            Return True
        End If



        '---- load cart item
        Dim oCartItem As New cls_advanced_cart_item_atom
        oCartItem.price = oPriceConstructor._correct_price
        oCartItem.desc = oPlate._item_description

        If oPlate.opthash("usepayments") = "1" Then
            Dim ostringfunc As New iFunctions.cls_string
            Dim payment_dim As Int32 = Convert.ToInt32(oPlate.opthash("payments"))
            ''   Dim ostringfunc As New iFunctions.cls_string
            Dim payment_amount As String
            ostringfunc.format_currency(Math.Round(oPlate._pricing._correct_price / payment_dim), payment_amount, " $")
            oCartItem.desc += "<br><br>" + oPlate.opthash("payments") + " payments of: " + payment_amount
        End If

        oCartItem.id = oPlate._id

        oCartItem.item_number = oPlate._itemnumber
        oCartItem.placeholder = False

        If IsNothing(nJewelrysize) Then
            nJewelrysize = ""
        End If


        ''If special_url = "itemid" Then
        oCartItem.special_link = HttpContext.Current.Session("user")._domain + "/catalog/myitem.aspx?id=" + oCartItem.id.ToString
        ' '  Else
        ''     oCartItem.special_link = special_url
        ''
        ''  End If

        oCartItem.ringsize = nJewelrysize
        oCartItem.icon = oPlate._icon_pic
        oCartItem.quantity = nquantity

        If HttpContext.Current.Session("ext_info").is_extra_info(oPlate._id) Then
            oCartItem.price = HttpContext.Current.Session("ext_info").get_extra_price
            oCartItem.extrainfo = HttpContext.Current.Session("ext_info").get_ext_savestr
        End If

        If InStr(oPlate._subcategory_name, "Ring") > 0 And nJewelrysize = "" Then
            oCartItem.ringsize = "Not Set"
        End If

        If oPlate._platetype = 2 And InStr(oPlate._subcategory_name.ToLower, "loose") > 0 Then
            oCartItem.options.Add("designring")
        End If

        oCartItem.total_price = oCartItem.quantity * oCartItem.price

        Me.normal_items.Add(oCartItem)

        ''   Me.recalc()

        Return False

ErrorHandler:
        Me._err_number = Err.Number
        Me._err_description = Err.Description
        Me._err_source = Err.Source
        Return True

    End Function

    Function add_idex_item(ByVal idex As ion_two.cls_idex, Optional ByVal nquantity As Int32 = 0, Optional ByVal nJewelrysize As String = "") As Boolean
        On Error GoTo ErrorHandler
        Dim bError As Boolean = False

        idex.make_desc()

        Dim oPlate As New ion_two.skl_lst_inventory
        Dim oTmpInventory As New ion_two.cls_inventory_lgc
        oTmpInventory._connection_string = Me._connection_string
        oTmpInventory._dbtype = Me._dbtype

        Dim shapeid As Int32

        If idex._idexid <> 1111 Then

            Select Case idex._cut
                Case "Round"
                    shapeid = 5727
                    '';shapeid = 5218
                Case "Oval"
                    shapeid = 5728
                Case "Princess"
                    shapeid = 5729
                Case "Pear"
                    shapeid = 5730
                Case "Heart"
                    shapeid = 5731
                Case "Emerald"
                    shapeid = 5732
                Case Else
                    shapeid = 5733
            End Select
        End If

        bError = oTmpInventory.load(shapeid, oPlate, Me.pictures, Me.isdealer, False)


        If bError Then
            Me._err_number = oTmpInventory._err_number
            Me._err_description = oTmpInventory._err_description
            Me._err_source = oTmpInventory._err_source
            Return True
        End If
        '----- load item
        Dim oCartItem As New cls_advanced_cart_item_atom
        oCartItem.price = idex._price
        oCartItem.desc = idex._description

        oCartItem.id = oPlate._id
        oCartItem.no_itemnumber = True
        oCartItem.placeholder = False
        ''oCartItem.ringsize = nJewelrysize
        oCartItem.icon = oPlate._icon_pic
        oCartItem.quantity = nquantity


        oCartItem.total_price = oCartItem.quantity * oCartItem.price
        Me.normal_items.Add(oCartItem)

        ''    Me.recalc()

        Return False

ErrorHandler:
        Me._err_number = Err.Number
        Me._err_description = Err.Description
        Me._err_source = Err.Source
        Return True
    End Function

    Public Function add_mod_item(ByVal nId As Int32, ByVal modid As Int16, ByVal omodInfo As Object, Optional ByVal nQuantity As Int32 = 1, Optional ByVal nJewelrysize As String = "", Optional ByVal bSSL As Boolean = False, Optional ByVal special_url As String = "itemid") As Boolean
        On Error GoTo ErrorHandler
        Dim bError As Boolean = False


        ''--- Check if Item allready Exists
        Select Case modid
            Case 3
                Dim nItemLoop As Int16
                For nItemLoop = 0 To Me.normal_items.Count - 1
                    If Me.normal_items(nItemLoop).id = nId And Me.normal_items(nItemLoop).tmpdelete = False Then
                        Return False
                        Exit Function
                    End If
                Next
            Case 6
                Dim nItemLoop As Int16
                For nItemLoop = 0 To Me.normal_items.Count - 1
                    If Me.normal_items(nItemLoop).id = nId And Me.normal_items(nItemLoop).tmpdelete = False Then
                        Return False
                        Exit Function
                    End If
                Next
        End Select
        '''check for dual idex items
        'For nItemLoop = 1 To Me._shopitem.Count
        '    If Me._shopitem(nItemLoop)._idexid = nId Then
        '        Return False
        '        Exit Function
        '    End If
        'Next

        '--- Give JewelrySize a string value
        If IsNothing(nJewelrysize) Then
            nJewelrysize = ""
        End If


        '--- Get item
        Dim oPlate As New ion_two.skl_lst_inventory
        Dim oTmpInventory As New ion_two.cls_inventory_lgc
        oTmpInventory._connection_string = Me._connection_string
        oTmpInventory._dbtype = Me._dbtype
        bError = oTmpInventory.load(nId, oPlate, Me.pictures, Me.isdealer, bSSL)
        If bError Then
            Me._err_number = oTmpInventory._err_number
            Me._err_description = oTmpInventory._err_description
            Me._err_source = oTmpInventory._err_source
            Return True
        End If

        '--- Set Basket to Club




        '--- Get correct price
        Dim oPriceConstructor As New ion_two.cons_price
        oPriceConstructor._sell_price = oPlate._sell_price
        oPriceConstructor._special_sell_price = oPlate._special_sell_price
        oPriceConstructor._dealer_price = oPlate._dealer_price
        oPriceConstructor._special_dealer_price = oPlate._special_dealer_price
        oPriceConstructor._isspecial = oPlate._onspecial
        oPriceConstructor._special_from = oPlate._onspecial_from_date
        oPriceConstructor._special_to = oPlate._onspecial_to_date
        oPriceConstructor._isdealer = Me.isdealer
        oPriceConstructor._onbargain = oPlate.onbargain
        bError = oPriceConstructor.get_price()
        If bError Then
            Me._err_number = oPriceConstructor._err_number
            Me._err_description = oPriceConstructor._err_description
            Me._err_source = oPriceConstructor._err_source
            Return True
        End If


        '--- Create a new Cart Item
        Dim oCartItem As New cls_advanced_cart_item_atom


        oCartItem.id = oPlate._id


        oCartItem.item_number = oPlate._itemnumber
        ''oCartItem._max_quantity = oPlate._qtyonstock_cur
        oCartItem.quantity = nQuantity
        oCartItem.ringsize = nJewelrysize
        oCartItem.icon = oPlate._icon_pic
        ''oCartItem._ssl_icon = oPlate._ssl_icon_pic
        oCartItem.price = oPriceConstructor._correct_price


        oCartItem.desc = oPlate._item_description

        Select Case modid
            Case 1
                oCartItem.desc = omodInfo.description.replace("|", "<br>")
                oCartItem.price = omodInfo.price
                oCartItem.extrainfo = omodInfo.extrainfo
                oCartItem.no_link = True
                oCartItem.no_itemnumber = True
                oCartItem.modid = 1

                ''oCartItem.item_number = "Side Stones"
            Case 2 '' the case of setting style that comes from CJ and can have pic that is non  DB

                oCartItem.desc = omodInfo.description
                oCartItem.price = omodInfo.price
                oCartItem.extrainfo = omodInfo.extrainfo
                oCartItem.no_link = True
                oCartItem.icon = omodInfo.picsrc
                oCartItem.ringsize = omodInfo.set_ring_size
                oCartItem.no_itemnumber = True
                oCartItem.modid = 2
                ''   If nId = 5836 Then ''if the setting is the special change item

                '' Else
                ''oCartItem._icon = omodInfo.picsrc
            Case 3 '' SE stone
                ''                oCartItem._description = oPlate._subcategory_name + " " + oPlate._category_name + "<br>"
                ''make complex desc
                oCartItem.desc += omodInfo.description
                oCartItem.modid = 3
            Case 4 '' SE setting

                oCartItem.price = omodInfo.price

                Dim tmpdesc As String = oPlate._item_description
                Dim tmpdesc2() As String

                tmpdesc = tmpdesc.Replace("<br>", "^")

                tmpdesc2 = tmpdesc.Split("^")

                If Me.slot_config.ContainsKey(nId) Then

                    tmpdesc = "This ring will be made for you from <br>" + Me.slot_config(nId)("metal") + ",<br>"


                Else

                    tmpdesc = "This ring will be made for you from <br>" + tmpdesc2(1) + ",<br>"

                End If
                tmpdesc += "with the following stone:<br> " + omodInfo.stone_desc + ".<br>"
                'Dim oextra As New cls_jewerly_extra

                'oextra.get_stone_extended_string(oPlate._subplate._stone_extended)

                If oPlate._subplate._jewel_extended.ss_desc <> "" Then
                    tmpdesc += "<b>This ring will include: <br>"
                    tmpdesc += oPlate._subplate._jewel_extended.ss_type + " " + oPlate._subplate._jewel_extended.ss_desc + ", " + oPlate._subplate._jewel_extended.ss_cut + "</b>"
                End If
                oCartItem.desc = tmpdesc
                oCartItem.modid = 4
            Case 5 ''earrings
                oCartItem.desc = omodInfo.description.replace("|", "<br>")
                oCartItem.price = omodInfo.price
                oCartItem.extrainfo = omodInfo.extrainfo
                oCartItem.no_link = True
                oCartItem.no_itemnumber = True
                oCartItem.modid = 1
                oCartItem.icon = omodInfo.picsrc
                oCartItem.pichw = "72x72"
                oCartItem.modid = 5
            Case 6 ''extra
                oCartItem.desc = omodInfo.description
                If omodInfo.price > 0 Then
                    oCartItem.price = omodInfo.price
                End If
                oCartItem.modid = 6

            Case 7
                oCartItem.price = omodInfo.price
                oCartItem.desc = omodInfo.description
                oCartItem.modid = 7
            Case 8 '' idex
                oCartItem.desc = omodInfo.description
                oCartItem.price = omodInfo.price
                oCartItem.extrainfo = omodInfo.extrainfo
                oCartItem.icon = omodInfo.iconpic
                oCartItem.modid = 8
                oCartItem.no_itemnumber = True

                oCartItem.special_link = "/catalog/myitem.aspx?modid=6&id=" + omodInfo.idex_id.ToString
            Case 9 '' only price
                oCartItem.price = omodInfo.price
        End Select


        If oCartItem.no_link = False Then

            If special_url = "itemid" Then
                oCartItem.special_link = "http://www.twin-diamonds.com/catalog/myitem.aspx?id=" + oCartItem.id.ToString
            Else
                oCartItem.special_link = special_url
            End If

        End If

        If Not IsNothing(HttpContext.Current.Session("ext_info")) Then
            If HttpContext.Current.Session("ext_info").is_extra_info(oPlate._id) Then
                oCartItem.price = HttpContext.Current.Session("ext_info").get_extra_price
                oCartItem.extrainfo = HttpContext.Current.Session("ext_info").get_ext_savestr
            End If
        End If

        If InStr(oPlate._subcategory_name, "Ring") > 0 And nJewelrysize = "" Then
            oCartItem.ringsize = ""
        End If

        oCartItem.total_price = oCartItem.price * oCartItem.quantity

        '--- Add to collection
        Me.normal_items.Add(oCartItem)


        '--- release
        oPriceConstructor = Nothing
        oPlate = Nothing

        Return False
        Exit Function

ErrorHandler:
        Me._err_number = Err.Number
        Me._err_description = Err.Description
        Me._err_source = Err.Source
        Return True
    End Function

    Function add_ocjitem_item(ByVal ocjitem As ion_two.cls_custom_jewel_skl) As Boolean
        On Error GoTo ErrorHandler
        Dim bError As Boolean = False

        ''create a new ocjitem class for cart and fill it
        ''use normal item add to over use the function
        Dim ocartitem As New ocj_item
        ''cs
        If ocjitem.has_cs Then
            Me.add_normal_item(ocjitem.cs_item_id)



            ocartitem.cs = Me.normal_items(Me.normal_items.Count - 1)
            ocartitem.cs.placeholder = False
            Me.normal_items.RemoveAt(Me.normal_items.Count - 1)
        End If


        If ocjitem.has_ss Then
            Dim omodPair As New ion_two.cls_mod_diam_pair_item

            omodPair.description = ocjitem.ss_desc
            omodPair.extrainfo = ocjitem.ss_extrainfo
            omodPair.price = ocjitem.ss_price

            Me.add_mod_item(ocjitem.ss_trueid, 1, omodPair, , , False)



            ocartitem.ss = Me.normal_items(Me.normal_items.Count - 1)
            ocartitem.ss.placeholder = False
            Me.normal_items.RemoveAt(Me.normal_items.Count - 1)

        End If

        If ocjitem.has_style Then
            Dim omodsetting As New ion_two.cls_mod_setting_item
            Dim osetting As New ion_two.cls_mod_setting

            osetting.ds_create_desc(ocjitem.set_metal_type, ocjitem.set_model_id, ocjitem.deliver_mathod, omodsetting.description)



            omodsetting.price = ocjitem.set_price

            omodsetting.picsrc = ocjitem.set_model_picsrc
            omodsetting.set_ring_size = ocjitem.set_ring_size
            If ocjitem.deliver_mathod > 1 Then
                osetting.ds_create_extrainfo(ocjitem.set_price, ocjitem.set_metal_type, ocjitem.set_model_id, omodsetting.extrainfo, ocjitem.set_ring_size, ocjitem.set_model_picsrc)
            Else
                osetting.ds_create_extrainfo(ocjitem.set_price, ocjitem.set_metal_type, ocjitem.set_model_id, omodsetting.extrainfo, ocjitem.set_ring_size)
            End If

            add_mod_item(ocjitem.set_model_id, 2, omodsetting, , , False)

            ocartitem.style_semi = Me.normal_items(Me.normal_items.Count - 1)
            ocartitem.style_semi.placeholder = False
            Me.normal_items.RemoveAt(Me.normal_items.Count - 1)

            ocartitem.ringsize = ocjitem.set_ring_size
            ocartitem.style_semi.ringsize = ocjitem.set_ring_size

        End If

        If ocjitem.has_semi Then

            Dim omodsetting As New ion_two.cls_mod_setting_item
            Dim osetting As New ion_two.cls_mod_setting

            osetting.semi_create_desc(ocjitem.semi_metal_type, ocjitem.semi_model_id, ocjitem.deliver_mathod, ocjitem.semi_ss_full_desc, omodsetting.description)



            omodsetting.price = ocjitem.semi_price

            omodsetting.picsrc = ocjitem.semi_model_picsrc
            omodsetting.set_ring_size = ocjitem.semi_ring_size
            If ocjitem.deliver_mathod > 1 Then
                osetting.ds_create_extrainfo(ocjitem.semi_price, ocjitem.semi_metal_type, ocjitem.semi_model_id, omodsetting.extrainfo, ocjitem.semi_model_picsrc)
            Else
                osetting.ds_create_extrainfo(ocjitem.semi_price, ocjitem.semi_metal_type, ocjitem.semi_model_id, omodsetting.extrainfo)
            End If

            Me.add_mod_item(ocjitem.semi_model_id, 2, omodsetting, , , False)

            ocartitem.style_semi = Me.normal_items(Me.normal_items.Count - 1)
            ocartitem.style_semi.placeholder = False
            Me.normal_items.RemoveAt(Me.normal_items.Count - 1)

            ocartitem.ringsize = ocjitem.semi_ring_size
        End If

        ocartitem.price = ocartitem.cs.total_price + ocartitem.ss.total_price + ocartitem.style_semi.total_price

        ocartitem.total_price = ocartitem.price * ocartitem.quantity
        ocartitem.ocjitem = ocjitem

        Me.ocj_items.Add(ocartitem)


        ''  Me.recalc()

        Return False

ErrorHandler:
        Me._err_number = Err.Number
        Me._err_description = Err.Description
        Me._err_source = Err.Source
        Return True

    End Function

    Function add_se_item(ByVal csid As Int32, ByVal itemid As Int32, ByVal price As Decimal, ByVal stone_desc As String, Optional ByVal njewelrysize As String = "") As Boolean
        On Error GoTo ErrorHandler
        Dim bError As Boolean = False

        ''create a new ocjitem class for cart and fill it
        ''use normal item add to over use the function

        Dim seitem As New se_item

        Dim omodcs As New ion_two.cls_mod_SE_stone

        '' omodcs.description = "<br>This stone will be added to the ring you have selected"


        Me.add_mod_item(csid, 3, omodcs, 1)

        seitem.cs = Me.normal_items(Me.normal_items.Count - 1)
        Me.normal_items.RemoveAt(Me.normal_items.Count - 1)


        Dim omodseitem As New ion_two.cls_mod_SE_ring_item
        omodseitem.price = price
        omodseitem.description = "<br>This ring will be made with the stone listed above"


        omodseitem.stone_desc = stone_desc
        Me.add_mod_item(itemid, 4, omodseitem, 1, njewelrysize)

        seitem.jewel = Me.normal_items(Me.normal_items.Count - 1)
        Me.normal_items.RemoveAt(Me.normal_items.Count - 1)

        seitem.price = seitem.cs.total_price + seitem.jewel.total_price

        seitem.total_price = seitem.price * seitem.quantity

        seitem.ringsize = seitem.jewel.ringsize
        Me.se_items.Add(seitem)

        Return False

ErrorHandler:
        Me._err_number = Err.Number
        Me._err_description = Err.Description
        Me._err_source = Err.Source
        Return True

    End Function

    Function add_class_item(ByVal item As Object) As Boolean
        On Error GoTo ErrorHandler

        Me.normal_items.Add(item)

        Return False

ErrorHandler:
        Me._err_number = Err.Number
        Me._err_description = Err.Description
        Me._err_source = Err.Source
        Return True

    End Function


    Public Function recalc(Optional ByVal removeTD As Boolean = False) As Boolean
        On Error GoTo ErrorHandler
        Dim bError As Boolean = False

        '--- calculate total amount
        Dim nCount As Integer
        Me.total_amount = 0
        Dim i As Int32 = 0
        ''remove tmpdelete to simplize ajax
        If removeTD Then
            i = 0
            While i < Me.normal_items.Count

                If Me.normal_items(i).tmpdelete = True Then
                    Me.normal_items.Remove(Me.normal_items(i))
                Else
                    i = i + 1
                End If


            End While

            i = 0
            While i < Me.ocj_items.Count

                If Me.ocj_items(i).tmpdelete = True Then
                    Me.ocj_items.Remove(Me.ocj_items(i))
                Else
                    i = i + 1
                End If


            End While

            i = 0
            While i < Me.se_items.Count

                If Me.se_items(i).tmpdelete = True Then
                    Me.se_items.Remove(Me.se_items(i))
                Else
                    i = i + 1
                End If


            End While
        End If
        'If removeTD Then
        '    For i = 0 To Me.normal_items.Count - 1
        '        If Me.normal_items(i).tmpdelete = True Then
        '            Me.normal_items.Remove(Me.normal_items(i))
        '        End If
        '    Next


        'End If



        'If removeTD Then
        '    For i = 0 To Me.ocj_items.Count - 1
        '        If Me.ocj_items(i).tmpdelete = True Then
        '            Me.ocj_items.Remove(Me.ocj_items(i))
        '        End If
        '    Next


        'End If



        'If removeTD Then
        '    For i = 0 To Me.se_items.Count - 1
        '        If Me.se_items(i).tmpdelete = True Then
        '            Me.se_items.Remove(Me.se_items(i))
        '        End If
        '    Next


        'End If
        ''check all the carts for total

        If Me.normal_items.Count > 0 Then
            For i = 0 To Me.normal_items.Count - 1
                Me.total_amount = Me.total_amount + Me.normal_items(i).total_price * Me.normal_items(i).quantity
            Next
        End If

        If Me.mod_items.Count > 0 Then
            For i = 0 To Me.mod_items.Count - 1
                Me.total_amount = Me.total_amount + Me.mod_items(i).total_price * Me.mod_items(i).quantity
            Next
        End If

        If Me.ocj_items.Count > 0 Then
            For i = 0 To Me.ocj_items.Count - 1
                Me.total_amount = Me.total_amount + Me.ocj_items(i).total_price * Me.normal_items(i).quantity
            Next
        End If

        If Me.se_items.Count > 0 Then
            For i = 0 To Me.se_items.Count - 1
                Me.total_amount = Me.total_amount + Me.se_items(i).total_price * Me.normal_items(i).quantity
            Next
        End If

        Dim oshipping As New ion_two.cls_shipping        ''update autoshipping

        oshipping._convertrate = Me.convertrate

        If Me.total_amount > 10000 * Me.convertrate And Me.shipping_id = 3 Then

            oshipping.get_fixedprice_bytype(5, Me.shipping_price)
            Me.total_amount_withshipping = Me.shipping_price + Me.total_amount
            Me.shipping_id = 3
            Me.shipping_recommended = 3


        ElseIf Me.total_amount > 3000 * Me.convertrate And Me.shipping_id = 4 Then

            oshipping.get_fixedprice_bytype(5, Me.shipping_price)
            Me.total_amount_withshipping = Me.shipping_price + Me.total_amount
            Me.shipping_id = 4
            Me.shipping_recommended = 4
        ElseIf Me.total_amount > 1000 * Me.convertrate And Me.shipping_id = 2 Then

            oshipping.get_fixedprice_bytype(5, Me.shipping_price)
            Me.total_amount_withshipping = Me.shipping_price + Me.total_amount
            Me.shipping_id = 2
            Me.shipping_recommended = 2
        ElseIf Me.total_amount > 3000 * Me.convertrate And Me.total_amount < 10000 * Me.convertrate And Me.shipping_id <> 3 Then

            oshipping.get_fixedprice_bytype(5, Me.shipping_price)
            Me.total_amount_withshipping = Me.shipping_price + Me.total_amount
            Me.shipping_id = 4
            Me.shipping_recommended = 4

        Else
            oshipping.get_fixedprice_bytype(Me.shipping_id, Me.shipping_price)
            Me.shipping_recommended = 1
            Me.total_amount_withshipping = Me.shipping_price + Me.total_amount

        End If




        Return False
        Exit Function

ErrorHandler:
        Me._err_number = Err.Number
        Me._err_description = Err.Description
        Me._err_source = Err.Source
        Return True
    End Function

    Function RecalcVIP() As Boolean

        Me.isdealer = True

        Dim tmparray As New ArrayList

        Dim i As Int32 = 0
        For i = 0 To Me.normal_items.Count - 1

            tmparray.Add(Me.normal_items(i))

        Next

        Me.normal_items.Clear()
        Me.recalc()

        For i = 0 To tmparray.Count - 1

            Me.add_normal_item(tmparray(i).id, 1, tmparray(i).ringsize)
            Me.normal_items(i).quantity = tmparray(i).quantity

        Next

        Me.recalc()




    End Function

    Public Class ocj_item

        Public cs As New cls_advanced_cart_item_atom
        Public ss As New cls_advanced_cart_item_atom
        Public style_semi As New cls_advanced_cart_item_atom
        Public total_price As Decimal
        Public quantity As Int32
        Public price As Decimal
        Public tmpdelete As Boolean
        Public ringsize As String = ""
        Public ocjitem As ion_two.cls_custom_jewel_skl

        Sub New()
            Me.cs.placeholder = True
            Me.ss.placeholder = True
            Me.style_semi.placeholder = True
            Me.tmpdelete = False
            Me.quantity = 1
        End Sub
    End Class

    Public Class se_item

        Public cs As New cls_advanced_cart_item_atom
        Public jewel As New cls_advanced_cart_item_atom
        Public total_price As Decimal
        Public quantity As Int32
        Public price As Decimal
        Public tmpdelete As Boolean
        Public ringsize As String = ""
        Public ocjitem As ion_two.cls_custom_jewel_skl

        Sub New()
            Me.cs.placeholder = True
            Me.tmpdelete = False
            Me.quantity = 1
        End Sub
    End Class




    Public Class cls_advanced_cart_item_atom
        Public id As Int32
        Public quantity As Int32
        Public price As Decimal
        Public ringsize As String = ""
        Public desc As String
        Public item_number As String
        Public icon As String
        Public placeholder As Boolean '' this is used not to mix up the css controls say if there ar no side stones
        Public no_link As Boolean
        Public no_itemnumber As Boolean
        Public extrainfo As String
        Public total_price As Decimal
        Public tmpDelete As Boolean = False
        Public options As New ArrayList
        Public hash As New Hashtable
        Public modid As Int32 = 0
        Public pichw As String = ""
        Public special_link As String = ""
        Public usepayments As Boolean = False

        Protected Overrides Sub Finalize()
            MyBase.Finalize()
        End Sub
    End Class

    Public Class cls_advanced_cart_js_solitaire_atom
        Public id As Int32
        Public quantity As Int32
        Public price As Decimal
        Public ringsize As String = ""
        Public desc As String
        Public item_number As String
        Public icon As String
        Public placeholder As Boolean '' this is used not to mix up the css controls say if there ar no side stones
        Public no_link As Boolean
        Public no_itemnumber As Boolean
        Public extrainfo As String
        Public total_price As Decimal
        Public tmpDelete As Boolean = False
        Public options As New ArrayList
        Public modid As Int32 = 1
        Public pichw As String = ""
        Public special_link As String = ""
        Public usepayments As Boolean = False

        Public diamondimg As String
        Public settingimg As String

        Protected Overrides Sub Finalize()
            MyBase.Finalize()
        End Sub
    End Class

End Class
