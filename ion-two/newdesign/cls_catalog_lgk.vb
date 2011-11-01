Imports System.xml
Imports System.Reflection
Imports System.Text.RegularExpressions
Public Class cls_catalog_lgk
    Public xml_faces_file As String
    Public isDealer As Boolean
    Public conn_string As String
    Public dbtype As String
    Public Function LoadFace(ByVal oplate As Object, ByRef face As ion_two.cls_catalog_face_v1, ByVal qhash As Hashtable) As Int32
        Dim oxml As New ion_two.cls_nd_xmlread
        oxml.xml_file = Me.xml_faces_file
        oxml.Load()
        Dim oface As XmlNode

        face.oplate = oplate

        ''check for cat|subcat override
        If Not (oxml.GetNode_ByPath("//faces/face[@cat='" + oplate._category_id.ToString + "|" + oplate._subcategory_id.ToString + "']") Is Nothing) Then
            oface = oxml.GetNode_ByPath("//faces/face[@cat='" + oplate._category_id.ToString + "|" + oplate._subcategory_id.ToString + "']")
            face.xmlsource = oface
            Return 0
        End If
        ''mod override

        If Not (oxml.GetNode_ByPath("//faces/face[@modid='" + qhash("modid") + "']") Is Nothing) Then
            oface = oxml.GetNode_ByPath("//faces/face[@modid='" + qhash("modid") + "']")
            face.xmlsource = oface
            Return 0
        End If

        oface = oxml.GetNode_ByPath("//faces/face[@plate='" + oplate._platetype.ToString + "']")

        If oface Is Nothing Then
            oface = oxml.GetNode_ByPath("//faces/face[@plate='default']")
        End If

        face.xmlsource = oface

    End Function
    Public Function LoadInfoPartsColl(ByVal oplate As Object, ByVal infoparts_array As ArrayList, ByRef face As ion_two.cls_catalog_face_v1)

        Select Case oplate.GetType.Name
            Case "cls_idexPlateItem"
                Me.LoadSlimInfoPartsColl(oplate, infoparts_array, face)
                Return 0
        End Select

        Dim infoparts As XmlNodeList = face.xmlsource.SelectNodes("infopart")

        For Each info As XmlNode In infoparts
            Dim AddStopper As Boolean = False
            Dim otmpinfo As New infopart_v1

            If Not info.Attributes("condition") Is Nothing Then
                ''check condiction
                Dim ocondition As New cls_catalog_infopart_conditionals
                Dim oconditionref As Type
                Dim conditionstr As String = info.Attributes("condition").InnerText
                oconditionref = ocondition.GetType
                Dim params() As Object = {oplate, info, face}


                Dim compareCon As Boolean = oconditionref.InvokeMember(conditionstr.Split("|")(0), BindingFlags.DeclaredOnly Or BindingFlags.Public Or BindingFlags.NonPublic Or BindingFlags.Instance Or BindingFlags.InvokeMethod, Nothing, ocondition, params)

                If compareCon Then

                    If conditionstr.Split("|")(1) = "hide" Then
                        AddStopper = True
                    End If

                Else
                    If conditionstr.Split("|")(1) = "show" Then
                        AddStopper = True
                    End If


                End If

            End If

            If Not AddStopper Then

                Select Case info.Attributes("type").InnerText
                    Case "1", "3"

                     
                        Dim translateStr = info.InnerText
                        Dim odesc As New ion_two.cls_modular_description
                        Dim matches As MatchCollection = Regex.Matches(translateStr, "\|.[^\|]*\|")
                        Dim oplateref As Type
                        Dim osubplateref As Type
                        osubplateref = oplate._subplate.GetType
                        oplateref = oplate.GetType
                        For Each m As Match In matches
                            Dim matchstr As String = Mid(m.ToString, 2, m.ToString.Length - 2)
                            Dim rtn As String
                            If odesc.CheckSpecialKeys(matchstr) Then
                                odesc.SpecialKeysExec(matchstr, oplate, rtn)
                            Else
                                If matchstr.StartsWith("subplate") Then
                                    rtn = osubplateref.InvokeMember(matchstr.Split(".")(1), BindingFlags.GetField, Nothing, oplate._subplate, Nothing)
                                Else
                                    rtn = oplateref.InvokeMember(matchstr, BindingFlags.GetField, Nothing, oplate, Nothing)
                                End If
                            End If

                            If Trim(rtn) = info.Attributes("empty").InnerText Then
                                rtn = ""
                                AddStopper = True
                            End If

                            translateStr = translateStr.Replace(m.ToString, rtn)
                            translateStr = translateStr.Replace("-NL-", "<br>")
                        Next
                        otmpinfo.text = translateStr

                    Case "2" ''combos

                        Select Case info.Attributes("custom").InnerText

                            Case "extrametal"

                                Dim items As New ArrayList
                                Dim jsitems As String
                                Dim ometal As New ion_two.cls_mod_metal
                                Dim ostringfunc As New iFunctions.cls_string
                                Dim metalhash As Hashtable = ostringfunc.HashfromString(oplate._subplate._extra_metal.replace("system|", ""), "|", "::")





                                ometal.GenerateAltMetalWithDelta(oplate._subplate._metal, Convert.ToInt32(metalhash("delta")), items)

                                Dim oredcombo As New ion_two.cls_redcombo

                                oredcombo.AddItemsFromArrayList("rcExtraMetalItems", "RenderExtraMetal", items, jsitems)

                                Me.CreateRedComboCode_v1("JS_catalog_extra_metal", "optExtraMetal", "rcExtraMetalItems", jsitems, "comboExtraMetal", otmpinfo.customHash)

                                otmpinfo.customHash("modName") = "extrametal"
                                otmpinfo.customHash("changeOnloadItem") = "metal"

                                ''    face.initjs_array.Add("optExtraMetal.defaultIndex=1")
                                face.initjs_array.Add("JS_catalog_extra_metal()")

                                ''  face.talking_hash("extrametalindexs") = items
                        End Select


                End Select
                If Not AddStopper Then



                    otmpinfo.type = Convert.ToInt32(info.Attributes("type").InnerText)
                    If otmpinfo.type = 3 Then face.page.noextra = False
                    otmpinfo.cat = info.Attributes("cat").InnerText

                    If Not info.Attributes("jid") Is Nothing Then
                        otmpinfo.jid = info.Attributes("jid").InnerText
                    End If


                    If Not info.Attributes("bold") Is Nothing Then
                        otmpinfo.bold = True
                    End If


                    If Not info.Attributes("panelid") Is Nothing Then
                        otmpinfo.panelID = info.Attributes("panelid").InnerText
                    End If


                    If Not info.Attributes("key") Is Nothing Then
                        otmpinfo.key = info.Attributes("key").InnerText
                        Select Case otmpinfo.key
                            Case "report"
                                otmpinfo.text = "<a href='" + oplate._certificate_pic + "' target='_blank' >" + otmpinfo.text + "</a>"
                        End Select
                    End If

                    If Not info.Attributes("helpid") Is Nothing Then
                        otmpinfo.jsonclick = "onclick=" + Chr(34) + "PopupHelp(this," + info.Attributes("helpid").InnerText + ")" + Chr(34)
                    End If


                    infoparts_array.Add(otmpinfo)
                End If
            End If

        Next

    End Function
    Public Function LoadSlimInfoPartsColl(ByVal oplate As Object, ByVal infoparts_array As ArrayList, ByRef face As ion_two.cls_catalog_face_v1)



        Dim infoparts As XmlNodeList = face.xmlsource.SelectNodes("infopart")

        For Each info As XmlNode In infoparts
            Dim AddStopper As Boolean = False
            Dim otmpinfo As New infopart_v1

            If Not info.Attributes("condition") Is Nothing Then
                ''check condiction
                Dim ocondition As New cls_catalog_infopart_conditionals
                Dim oconditionref As Type
                Dim conditionstr As String = info.Attributes("condition").InnerText
                oconditionref = ocondition.GetType
                Dim params() As Object = {oplate, info, face}


                Dim compareCon As Boolean = oconditionref.InvokeMember(conditionstr.Split("|")(0), BindingFlags.DeclaredOnly Or BindingFlags.Public Or BindingFlags.NonPublic Or BindingFlags.Instance Or BindingFlags.InvokeMethod, Nothing, ocondition, params)

                If compareCon Then

                    If conditionstr.Split("|")(1) = "hide" Then
                        AddStopper = True
                    End If

                Else
                    If conditionstr.Split("|")(1) = "show" Then
                        AddStopper = True
                    End If


                End If

            End If

            If Not AddStopper Then

                Select Case info.Attributes("type").InnerText
                    Case "1", "3"


                        Dim translateStr = info.InnerText
                        Dim odesc As New ion_two.cls_modular_description
                        Dim matches As MatchCollection = Regex.Matches(translateStr, "\|.[^\|]*\|")
                        Dim oplateref As Type
                        ''   Dim osubplateref As Type
                        ''  osubplateref = oplate._subplate.GetType
                        oplateref = oplate.GetType
                        For Each m As Match In matches
                            Dim matchstr As String = Mid(m.ToString, 2, m.ToString.Length - 2)
                            Dim rtn As String
                            If odesc.CheckSpecialKeys(matchstr) Then
                                odesc.SpecialKeysExec(matchstr, oplate, rtn)
                            Else
                                ''If matchstr.StartsWith("subplate") Then
                                ''rtn = osubplateref.InvokeMember(matchstr.Split(".")(1), BindingFlags.GetField, Nothing, oplate._subplate, Nothing)
                                ''   Else
                                    rtn = oplateref.InvokeMember(matchstr, BindingFlags.GetField, Nothing, oplate, Nothing)
                                ''    End If
                            End If

                            If Trim(rtn) = info.Attributes("empty").InnerText Then
                                rtn = ""
                                AddStopper = True
                            End If

                            translateStr = translateStr.Replace(m.ToString, rtn)
                            translateStr = translateStr.Replace("-NL-", "<br>")
                        Next
                        otmpinfo.text = translateStr

                    Case "2" ''combos

                        Select Case info.Attributes("custom").InnerText

                            Case "extrametal"

                                Dim items As New ArrayList
                                Dim jsitems As String
                                Dim ometal As New ion_two.cls_mod_metal
                                Dim ostringfunc As New iFunctions.cls_string
                                Dim metalhash As Hashtable = ostringfunc.HashfromString(oplate._subplate._extra_metal.replace("system|", ""), "|", "::")





                                ometal.GenerateAltMetalWithDelta(oplate._subplate._metal, Convert.ToInt32(metalhash("delta")), items)

                                Dim oredcombo As New ion_two.cls_redcombo

                                oredcombo.AddItemsFromArrayList("rcExtraMetalItems", "RenderExtraMetal", items, jsitems)

                                Me.CreateRedComboCode_v1("JS_catalog_extra_metal", "optExtraMetal", "rcExtraMetalItems", jsitems, "comboExtraMetal", otmpinfo.customHash)

                                otmpinfo.customHash("modName") = "extrametal"
                                otmpinfo.customHash("changeOnloadItem") = "metal"


                                face.initjs_array.Add("JS_catalog_extra_metal()")
                        End Select


                End Select
                If Not AddStopper Then



                    otmpinfo.type = Convert.ToInt32(info.Attributes("type").InnerText)
                    If otmpinfo.type = 3 Then face.page.noextra = False
                    otmpinfo.cat = info.Attributes("cat").InnerText

                    If Not info.Attributes("jid") Is Nothing Then
                        otmpinfo.jid = info.Attributes("jid").InnerText
                    End If

                    If Not info.Attributes("helpid") Is Nothing Then
                        otmpinfo.jsonclick = "onclick=" + Chr(34) + "PopupHelp(this," + info.Attributes("helpid").InnerText + ")" + Chr(34)
                    End If
                    infoparts_array.Add(otmpinfo)
                End If
            End If

        Next

    End Function
    Function LoadPricePartsColl(ByVal oplate As Object, ByVal currency_symbol As String, ByRef price_coll As ArrayList)
        ''redirect price
        Select Case oplate.GetType.Name
            Case "cls_idexPlateItem"
                Me.LoadItemSlimPrice(oplate, price_coll)
                Return 0
        End Select
        Dim price_hash As New Hashtable
        Dim ostringfunc As New iFunctions.cls_string
        ostringfunc.currency_symbol = currency_symbol
        With oplate

            If ._appraisal_price > 0 Then

                Dim tmpprice As New pricepart_v1
                tmpprice.desc = "Retail Replacment Value:"
                tmpprice.price = ._appraisal_price
                tmpprice.jid = "pr_retail"
                tmpprice.tag = "retail"
                tmpprice.smallcaps = True
                price_hash.Add("retail", tmpprice)

            End If

            If ._sell_price >= 0 Then

                Dim tmpprice As New pricepart_v1
                If Me.isDealer Then
                    tmpprice.desc = "Regular Price:"
                    tmpprice.middleline = True
                Else
                    tmpprice.desc = "Our Price:"
                End If

                Dim se_price As Decimal = 0
                If oplate._platetype = 3 Then


                    If oplate._subplate.se_relateditem_id > 0 Then
                        Dim oseitem As New ion_two.cls_stone_exchange
                        Dim str As String
                        oseitem.Conn_String = Me.conn_string
                        oseitem.db_type = Me.dbtype
                        oseitem.load_stone_exchange_byid(oplate._subplate.se_relateditem_id, se_price)
                        tmpprice.desc = "Total Price:"
                    End If
                End If

                tmpprice.price = ._sell_price + se_price

                If Not Me.isDealer Then
                    tmpprice.jid = "pr_price"
                    tmpprice.CurrencyEnabled = True
                Else
                    tmpprice.jid = "pr_regular"
                End If
                tmpprice.tag = "price"

                price_hash.Add("sell", tmpprice)

            End If



            If Today.Date >= ._pricing._special_from And Today.Date <= ._pricing._special_to And ._onspecial = True Then

                Dim tmpprice As New pricepart_v1
                tmpprice.desc = "Special Price:"
                tmpprice.price = ._special_sell_price
                tmpprice.jid = "pr_price"
                tmpprice.tag = "special"
                price_hash.Add("special", tmpprice)
                price_hash.Remove("sell")


            End If

            If .onbargain Then
                Dim tmpprice As New pricepart_v1
                tmpprice.desc = "Bargain Price:"
                tmpprice.price = ._special_sell_price
                tmpprice.tag = "bargain"
                tmpprice.CurrencyEnabled = True
                price_hash.Add("bargain", tmpprice)
                price_hash.Remove("sell")

            End If

            If Me.isDealer And .opthash("usepayments") <> "1" Then
                If Not (Today.Date >= ._pricing._special_from And Today.Date <= ._pricing._special_to And ._onspecial = True) Then
                    Dim tmpprice As New pricepart_v1
                    tmpprice.desc = "VIP Price:"
                    tmpprice.price = ._dealer_price
                    tmpprice.tag = "dealer"
                    tmpprice.jid = "pr_price"
                    tmpprice.CurrencyEnabled = True
                    price_hash.Add("dealer", tmpprice)
                Else
                    Dim tmpprice As New pricepart_v1
                    tmpprice.desc = "VIP Price:"
                    tmpprice.price = ._special_dealer_price
                    tmpprice.tag = "special_dealer"
                    tmpprice.jid = "pr_price"
                    price_hash.Add("special_dealer", tmpprice)

                End If
                ''price_hash.Remove("sell")

            End If

            If .opthash("usepayments") = "1" Then

                Dim tmpprice As New pricepart_v1
                Dim payment_dim As Int32 = Convert.ToInt32(oplate.opthash("payments"))
                ''   Dim ostringfunc As New iFunctions.cls_string
                Dim payment_amount As String
                ostringfunc.format_currency(Math.Round(oplate._pricing._correct_price / payment_dim), payment_amount, " $")

                tmpprice.desc = .opthash("payments") + " Monthly payments(<a id='paymentlink' href='javascript:PaymentsHelpShow(this)' >?</a>):"
                tmpprice.price = Math.Round(oplate._pricing._correct_price / payment_dim)
                tmpprice.jid = "pr_payments"
                tmpprice.tag = "payments"
                tmpprice.CurrencyEnabled = True
                tmpprice.smallcaps = False
                price_hash.Add("payments", tmpprice)

            End If

        End With



        For Each price As pricepart_v1 In price_hash.Values
            If price.tag <> "payments" Then
                ostringfunc.format_currency(price.price, price.price_formatted, " $")
            Else
                ostringfunc.format_currency(price.price, price.price_formatted, " $")
                price.price_formatted = price.desc.Split(" ")(0) + "x" + price.price_formatted
            End If
        Next

        If price_hash.ContainsKey("retail") Then
            price_coll.Add(price_hash("retail"))
        End If

        If price_hash.ContainsKey("sell") Then
            price_coll.Add(price_hash("sell"))
        End If
        If price_hash.ContainsKey("dealer") Then
            price_coll.Add(price_hash("dealer"))
        End If
        If price_hash.ContainsKey("special_dealer") Then
            price_coll.Add(price_hash("special_dealer"))
        End If


        If price_hash.ContainsKey("special") Then
            price_coll.Add(price_hash("special"))
        End If
        If price_hash.ContainsKey("bargain") Then
            price_coll.Add(price_hash("bargain"))
        End If
        If price_hash.ContainsKey("payments") Then
            price_coll.Add(price_hash("payments"))
        End If




    End Function
    Public Function LoadItemSlimPrice(ByVal oplate As Object, ByRef price_coll As ArrayList)

        Dim price_hash As New Hashtable
        With oplate



            If .price >= 0 Then

                Dim tmpprice As New pricepart_v1
                tmpprice.desc = "Our Price:"


                tmpprice.price = .price

                If Not Me.isDealer Then
                    tmpprice.jid = "pr_price"
                End If
                tmpprice.tag = "price"
                price_hash.Add("sell", tmpprice)

            End If

        End With

        Dim ostringfunc As New iFunctions.cls_string

        For Each price As pricepart_v1 In price_hash.Values
            ostringfunc.format_currency(price.price, price.price_formatted, " $")
        Next


        If price_hash.ContainsKey("sell") Then
            price_coll.Add(price_hash("sell"))
        End If

    End Function
    Public Function LoadItemCommends(ByVal oplate As Object, ByRef oface As cls_catalog_face_v1, ByVal qhash As Hashtable)

        If oplate._item_sold Or qhash("modid") = "7" Then
            oface.page.item_command = 2
        Else
            oface.page.item_command = 1
        End If

    End Function
    Public Function LoadPictures(ByVal oplate As Object, ByRef oface As cls_catalog_face_v1, ByVal qhash As Hashtable)
        If oplate._picture_pic <> "" Then
            oface.pics.page = oplate._picture_pic
        End If

        If oplate._is_banner Then
            oface.pics.picmovie = oplate._banner_pic

        End If

        If oplate._is_gallery Then
            oface.pics.hand = oplate._gallery_pic

        End If


        If oplate._is_hires Then
            Dim opicbutton As New cls_catalog_face_v1.pictures.picture_buttons
            opicbutton.icon = "extra-pic-zoom"
            Dim ostringfunc As New iFunctions.cls_string
            Dim params As New ArrayList
            params.Add(oplate._picture_hires_pic)
            params.Add(1)
            opicbutton.jsfunc = ostringfunc.CreateJSFunc("floatPicture", params)
            oface.pics.buttons.Add(opicbutton)
            oface.pics.hires = oplate._picture_hires_pic
        End If


        If oplate._is_report Then
            Dim opicbutton As New cls_catalog_face_v1.pictures.picture_buttons
            opicbutton.icon = "extra-pic-cert"
            Dim ostringfunc As New iFunctions.cls_string
            Dim params As New ArrayList
            params.Add(oplate._certificate_pic)
            params.Add(1)
            opicbutton.jsfunc = ostringfunc.CreateJSFunc("floatPicture", params)
            oface.pics.buttons.Add(opicbutton)
            oface.pics.cert = oplate._certificate_pic
        Else
            Dim opicbutton As New cls_catalog_face_v1.pictures.picture_buttons
            opicbutton.icon = "extra-pic-cert"
            Dim ostringfunc As New iFunctions.cls_string
            Dim params As New ArrayList
            params.Add(oplate._id)

            opicbutton.jsfunc = ostringfunc.CreateJSFunc("gotoCert", params)
            oface.pics.buttons.Add(opicbutton)
            '' oface.pics.cert = oplate._certificate_pic
        End If

        If oplate._is_gallery And (qhash("modid") = "3" Or qhash("modid") = "5") Then
            Dim opicbutton As New cls_catalog_face_v1.pictures.picture_buttons
            opicbutton.icon = "extra-pic-measure"
            Dim ostringfunc As New iFunctions.cls_string
            Dim params As New ArrayList
            params.Add(oplate._gallery_pic)
            params.Add(1)
            opicbutton.jsfunc = ostringfunc.CreateJSFunc("floatPicture", params)
            oface.pics.buttons.Add(opicbutton)
            oface.pics.cert = oplate._gallery_pic
        End If

        If oplate._is_movie Then
            Dim opicbutton As New cls_catalog_face_v1.pictures.picture_buttons
            opicbutton.icon = "extra-pic-movie"
            Dim ostringfunc As New iFunctions.cls_string
            Dim params As New ArrayList
            params.Add(oplate._movie_pic)
            params.Add(1)
            params.Add("null")
            params.Add("true")
            opicbutton.jsfunc = ostringfunc.CreateJSFunc("floatPicture", params, "true")
            oface.pics.buttons.Add(opicbutton)
            oface.pics.movie = oplate._movie_pic
        End If



    End Function
    Public Function LoadDescription(ByVal oplate As Object, ByRef oface As cls_catalog_face_v1)
        ''check for exeptios

        Dim odesc As New ion_two.cls_modular_description
        odesc.desc_type = "catalog"
        odesc.desc_trans_string = oface.xmlsource.SelectSingleNode("desc").InnerText
        '' odesc.xml_file = "/xml/itemdesc.xml"

        Select Case oplate.GetType.Name
            Case "cls_idexPlateItem"
                odesc.CreateSlimDescription(oplate)
                ''Return 0
            Case Else
                odesc.CreateDescription(oplate)
        End Select

        oface.page.itemnumber = oplate._itemnumber

        Dim ostringfunc As New iFunctions.cls_string
        Dim brindex As Int32 = odesc.desc_multiline.Replace("<br>", "<BR>").IndexOf("<BR>")
        If brindex > -1 Then
            oface.page.title = odesc.desc_multiline.Remove(brindex, 4)
            oface.page.title = oface.page.title.Insert(brindex - 4, " ")
        Else

            oface.page.title = odesc.desc_multiline
        End If
        ''oface.page.title = odesc.desc_multiline.Replace("<br>", " ").Replace("<BR>", " ")

        oface.page.browser_title = ostringfunc.ClearHTMLTagsReturn(oface.page.title)

        If oplate._platetype = 3 Then
            If oplate._subplate.jewel_title <> "" Then

                brindex = oplate._subplate.jewel_title.Replace("<br>", "<BR>").IndexOf("<BR>")

                If brindex > -1 Then
                    oface.page.title = oplate._subplate.jewel_title.Remove(brindex, 4)
                    oface.page.title = oface.page.title.Insert(brindex, " ")
                Else

                    oface.page.title = oplate._subplate.jewel_title
                End If

                ''   oface.page.title = oplate._subplate.jewel_title.Replace("<br>", " ")

                oface.page.browser_title = ostringfunc.ClearHTMLTagsReturn(oplate._subplate.jewel_title)
            End If
        End If


    End Function
    Public Function LoadMoreAction(ByVal oplate As Object, ByRef oface As cls_catalog_face_v1) As Boolean
        If oface.page.item_command > 1 Then Exit Function
        Dim actions As XmlNodeList = oface.xmlsource.SelectNodes("moreaction")
        If actions.Count > 0 Then
            Dim oredcombo As New ion_two.cls_redcombo
            Dim jshash As New Hashtable
            Dim items As New ArrayList
            For Each action As XmlNode In actions
                Dim compareCon As Boolean = True
                If Not IsNothing(action.Attributes("condition")) Then
                    Dim ocondition As New cls_catalog_moreaction_conditionals
                    Dim oconditionref As Type
                    Dim conditionstr As String = action.Attributes("condition").InnerText
                    oconditionref = ocondition.GetType
                    Dim params() As Object = {oplate, oface}


                    compareCon = oconditionref.InvokeMember(conditionstr, BindingFlags.DeclaredOnly Or BindingFlags.Public Or BindingFlags.NonPublic Or BindingFlags.Instance Or BindingFlags.InvokeMethod, Nothing, ocondition, params)
                End If

                If compareCon Then

                    Dim tmphash As New Hashtable
                    Dim text As String = action.InnerText
                    Dim val As String = action.Attributes("val").InnerText
                    tmphash(text) = val

                    Select Case action.Attributes("val").InnerText
                        Case "addtoring1"
                            jshash(text) = "'AddToRing(1)'"
                        Case "addtoring2"
                            jshash(text) = "'AddToRing(2)'"
                        Case "addtoring3"
                            jshash(text) = "'AddToRing(3)'"
                        Case "addtoring4"
                            jshash(text) = "'AddToRing(4)'"
                    End Select

                    items.Add(tmphash)

                End If

            Next

            If jshash.Count > 0 Then
                Dim comboitems As String

                oredcombo.AddItemsFromArrayList("rcMoreActionItems", jshash, items, comboitems)

                oface.initjs_array.Add(comboitems)

                oface.initjs_array.Add("RedList(optMoreAction,rcMoreActionItems)")
            End If

        End If





    End Function
    Public Function CreateEnhancedDiamondLinkage(ByVal status As Boolean, ByVal oplate As Object, ByRef oface As cls_catalog_face_v1, ByVal oseo As cls_seo) As Boolean




        If status Then
            oface.page.transferprice = oplate._pricing._correct_price * 0.4
            oface.page.transferstring = "clarity enhanced diamond"
            oface.page.transferlink = oseo.CreateISAPILinkEnhanced(oplate._item_description, oplate._platetype, oplate._id)
        Else
            oface.page.transferprice = oplate._pricing._correct_price * 2.5
            oface.page.transferstring = "natural diamond"
            oface.page.transferlink = oseo.CreateISAPILink(oplate._item_description, oplate._platetype, oplate._id)
        End If

        Dim ostringfunc As New iFunctions.cls_string

        ostringfunc.format_currency(oface.page.transferprice, oface.page.transferprice_formatted, " $")



    End Function
    Public Function LoadPathBar(ByVal oface As cls_catalog_face_v1, ByRef pathbar As ion_two.cls_pathbar) As Boolean

        Dim paths As XmlNodeList = oface.xmlsource.SelectNodes("path_bar/link")
        For Each path As XmlNode In paths

            pathbar.Add(path.Attributes("text").InnerText, path.Attributes("link").InnerText)

        Next


    End Function
    Public Function CreateRedComboCode_v1(ByVal initFunc As String, ByVal optName As String, ByVal itemsName As String, ByVal items As String, ByVal comboid As String, ByRef customHash As Hashtable) As Boolean

        customHash("initFunc") = initFunc

        'Dim i As Int32
        'For i = 0 To items.Count - 1
        '    customHash("items" + (i + 1).ToString) = items(i)
        'Next
        customHash("items") = items

        customHash("optName") = optName
        customHash("itemsName") = itemsName
        customHash("comboId") = comboid


    End Function

    Public Function FindInfoPartByCat(ByVal infoparts As ArrayList, ByVal cat As String, ByRef id As Int32)
        Dim i As Int32 = 0
        For i = 0 To infoparts.Count - 1

            If infoparts(i).cat.ToLower = cat.ToLower Then
                id = i
            End If

        Next
    End Function
    Public Function FindPricePartByTag(ByVal priceparts As ArrayList, ByVal tag As String, ByRef id As Int32)
        Dim i As Int32 = 0

        If tag.IndexOf("|") > -1 Then

            For i = 0 To priceparts.Count - 1

                Dim j As Int32 = 0
                For j = 0 To Split(tag, "|").Length - 1
                    If priceparts(i).tag.ToLower = (Split(tag, "|"))(j) Then
                        id = i
                        Exit Function
                    End If
                Next

            Next
        Else


            For i = 0 To priceparts.Count - 1

                If priceparts(i).tag.ToLower = tag.ToLower Then
                    id = i
                    Exit Function
                End If

            Next
        End If



        id = -1
    End Function



    Public Class infopart_v1
        Public type As Int32
        Public cat As String
        Public text As String
        Public helpid As String
        Public rawcss As String
        Public jid As String
        Public customHash As New Hashtable
        Public jsonclick As String
        Public key As String
        Public bold As Boolean = False
        Public panelID As String = ""

    End Class

    Public Class pricepart_v1
        Public desc As String
        Public price As Int32
        Public price_formatted As String
        Public jid As String
        Public tag As String
        Public smallcaps As Boolean = False
        Public middleline As Boolean = False
        Public CurrencyEnabled As Boolean = False

    End Class

End Class
Public Class cls_catalog_face_v1
    Public pics As New pictures
    Public initjs_array As New ArrayList
    Public xmlsource As XmlNode
    Public oplate As Object
    Public page As New page_v1
    Public talking_hash As New Hashtable



    Public Class page_v1
        Public browser_title As String
        Public title As String
        Public item_command As Int32 = 1
        Public noextra As Boolean = True
        Public extraopen As String = "none"
        Public bestoffer As Boolean = False
        Public itemnumber As String
        Public modelsflash_movie As String
        Public modelsflash_folder As String
        Public noquestion_belowpic As Boolean = False
        Public transferprice As Decimal
        Public transferprice_formatted As String
        Public transferstring As String
        Public transferlink As String
    End Class
    Public Class pictures
        Public page As String
        Public cert As String
        Public hires As String
        Public movie As String
        Public picmovie As String
        Public hand As String
        Public buttons As New ArrayList
        Public Class picture_buttons
            Public icon As String
            Public jsfunc As String
        End Class
    End Class
End Class
Public Class cls_catalog_infopart_conditionals

    Public Function IsExtraMetal(ByVal oplate As Object, ByVal info As XmlNode, ByVal oface As ion_two.cls_catalog_face_v1)

        If oplate._subplate._extra_metal.tolower <> "none" And oplate.samplepic Then
            Return True
        Else
            Return False
        End If

    End Function
    Public Function IsColorFrom(ByVal oplate As Object, ByVal info As XmlNode, ByVal oface As ion_two.cls_catalog_face_v1)

        If oplate._subplate._colorto.tolower <> "-" Then
            Return True
        Else
            Return False
        End If

    End Function
    Public Function IsClarityFrom(ByVal oplate As Object, ByVal info As XmlNode, ByVal oface As ion_two.cls_catalog_face_v1)

        If oplate._subplate._clarityto.tolower <> "-" Then
            Return True
        Else
            Return False
        End If

    End Function


    Public Function IsStandartExtraMetal(ByVal oplate As Object, ByVal info As XmlNode, ByVal oface As ion_two.cls_catalog_face_v1)

        If oplate._subplate._extra_metal.tolower <> "none" Then
            Return True
        Else
            Return False
        End If

    End Function
    Public Function HasFancyText(ByVal oplate As Object, ByVal info As XmlNode, ByVal oface As ion_two.cls_catalog_face_v1)

        If oplate._subplate.fancy_freetxt <> "" Then
            Return True
        Else
            Return False
        End If

    End Function


End Class
Public Class cls_catalog_moreaction_conditionals

    ''made for make only single stone work in jewel design
    Public Function IsSingleStone(ByVal oplate As Object, ByVal oface As ion_two.cls_catalog_face_v1)

        If oplate._subcategory_name.ToLower.IndexOf("loose") > -1 Then
            Return True
        Else
            Return False
        End If

    End Function

End Class
