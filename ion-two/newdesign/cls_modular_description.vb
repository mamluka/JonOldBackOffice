Imports System.Text.RegularExpressions
Imports System.Reflection
Imports System.Xml
Public Class cls_modular_description
    Public desc_type As String
    Public desc_oneline As String
    Public desc_multiline As String
    Public xml_file As String
    Public desc_trans_string As String
    Public conn_string As String
    Public db_type As String

    Public Function CreateDescription(ByVal id As Int32, ByVal mode As Int32, Optional ByVal overridehash As Hashtable = Nothing) As Boolean

        Dim oTmpInventory As New ion_two.cls_inventory_lgc
        oTmpInventory._connection_string = Me.conn_string
        oTmpInventory._dbtype = Me.db_type

        Dim oPlate As New ion_two.skl_lst_inventory
        oTmpInventory.load(id, oPlate)

        Select Case mode
            Case 1
                Me.CreateDescription(oPlate)
            Case 2
                Me.CreateDescription(oPlate, overridehash)
        End Select

    End Function
    Public Function CreateDescription(ByVal oplate As ion_two.skl_lst_inventory) As Boolean
        Dim translateStr As String
        If Me.desc_trans_string = "" Then
            translateStr = Me.LoadDescription(Me.xml_file, oplate)

        Else
            translateStr = Me.desc_trans_string
        End If

Prosses:

        Dim matches As MatchCollection = Regex.Matches(translateStr, "\|.[^\|]*\|")
        Dim oplateref As Type
        Dim osubplateref As Type
        osubplateref = oplate._subplate.GetType
        oplateref = oplate.GetType
        For Each m As Match In matches
            Dim matchstr As String = Split(Mid(m.ToString, 2, m.ToString.Length - 2), ":::")(0)
            Dim rtn As String
            If Me.CheckSpecialKeys(matchstr) Then
                Me.SpecialKeysExec(matchstr, oplate, rtn)
            Else
                If matchstr.StartsWith("subplate") Then
                    rtn = osubplateref.InvokeMember(matchstr.Split(".")(1), BindingFlags.GetField, Nothing, oplate._subplate, Nothing)
                Else
                    rtn = oplateref.InvokeMember(matchstr, BindingFlags.GetField, Nothing, oplate, Nothing)
                End If
                If Trim(rtn) = Split(Mid(m.ToString, 2, m.ToString.Length - 2), ":::")(1) Then
                    rtn = ""

                End If
            End If

            translateStr = translateStr.Replace(m.ToString, rtn)

        Next
        translateStr = translateStr.Replace("-NL-", "<br>")
        translateStr = Regex.Replace(translateStr, "<strong>(\s{1,})?</strong>", "", RegexOptions.IgnoreCase)
        translateStr = Regex.Replace(translateStr, "<br>(\s{1,})?<br>", "<br>", RegexOptions.IgnoreCase)
        Me.desc_multiline = translateStr





    End Function
    Public Function CreateDescription(ByVal oplate As ion_two.skl_lst_inventory, ByVal transstring As String, ByRef outstring As String) As Boolean
        Dim translateStr As String
        translateStr = transstring


Prosses:

        Dim matches As MatchCollection = Regex.Matches(translateStr, "\|.[^\|]*\|")
        Dim oplateref As Type
        Dim osubplateref As Type
        osubplateref = oplate._subplate.GetType
        oplateref = oplate.GetType
        For Each m As Match In matches
            Dim matchstr As String = Split(Mid(m.ToString, 2, m.ToString.Length - 2), ":::")(0)
            Dim rtn As String
            If Me.CheckSpecialKeys(matchstr) Then
                Me.SpecialKeysExec(matchstr, oplate, rtn)
            Else
                If matchstr.StartsWith("subplate") Then
                    rtn = osubplateref.InvokeMember(matchstr.Split(".")(1), BindingFlags.GetField, Nothing, oplate._subplate, Nothing)
                Else
                    rtn = oplateref.InvokeMember(matchstr, BindingFlags.GetField, Nothing, oplate, Nothing)
                End If
                If Trim(rtn) = Split(Mid(m.ToString, 2, m.ToString.Length - 2), ":::")(1) Then
                    rtn = ""

                End If
            End If

            translateStr = translateStr.Replace(m.ToString, rtn)

        Next
        translateStr = translateStr.Replace("-NL-", "<br>")
        translateStr = Regex.Replace(translateStr, "<strong>(\s{1,})?</strong>", "", RegexOptions.IgnoreCase)
        translateStr = Regex.Replace(translateStr, "<br>(\s{1,})?<br>", "<br>", RegexOptions.IgnoreCase)
        outstring = translateStr





    End Function
    Public Function CreateSlimDescription(ByVal oplate As Object) As Boolean
        Dim translateStr As String
        If Me.desc_trans_string = "" Then
            translateStr = Me.LoadDescription(Me.xml_file, oplate)

        Else
            translateStr = Me.desc_trans_string
        End If

Prosses:

        Dim matches As MatchCollection = Regex.Matches(translateStr, "\|.[^\|]*\|")
        Dim oplateref As Type
        Dim osubplateref As Type
        '' osubplateref = oplate._subplate.GetType
        oplateref = oplate.GetType
        For Each m As Match In matches
            Dim matchstr As String = Split(Mid(m.ToString, 2, m.ToString.Length - 2), ":::")(0)
            Dim rtn As String
            If Me.CheckSpecialKeys(matchstr) Then
                Me.SpecialKeysExec(matchstr, oplate, rtn)
            Else
                '' If matchstr.StartsWith("subplate") Then
                ''  rtn = osubplateref.InvokeMember(matchstr.Split(".")(1), BindingFlags.GetField, Nothing, oplate._subplate, Nothing)
                '' Else
                rtn = oplateref.InvokeMember(matchstr, BindingFlags.GetField, Nothing, oplate, Nothing)
                ''   End If
                If Trim(rtn) = Split(Mid(m.ToString, 2, m.ToString.Length - 2), ":::")(1) Then
                    rtn = ""

                End If
            End If

            translateStr = translateStr.Replace(m.ToString, rtn)

        Next
        translateStr = translateStr.Replace("-NL-", "<br>")
        translateStr = Regex.Replace(translateStr, "<strong>(\s{1,})?</strong>", "", RegexOptions.IgnoreCase)
        translateStr = Regex.Replace(translateStr, "<br>(\s{1,})?<br>", "<br>", RegexOptions.IgnoreCase)
        Me.desc_multiline = translateStr





    End Function
    Public Function CreateDescription(ByVal oplate As ion_two.skl_lst_inventory, ByVal overrideHash As Hashtable) As Boolean


        Dim translateStr As String
        If Me.desc_trans_string = "" Then
            translateStr = Me.LoadDescription(Me.xml_file, oplate)

        Else
            translateStr = Me.desc_trans_string
        End If



Prosses:

        Dim matches As MatchCollection = Regex.Matches(translateStr, "\|.[^\|]*\|")
        Dim oplateref As Type
        Dim osubplateref As Type
        osubplateref = oplate._subplate.GetType
        oplateref = oplate.GetType
        For Each m As Match In matches
            Dim matchstr As String = Split(Mid(m.ToString, 2, m.ToString.Length - 2), ":::")(0)
            Dim rtn As String
            If Not overrideHash.ContainsKey(matchstr) Then

                If Me.CheckSpecialKeys(matchstr) Then
                    Me.SpecialKeysExec(matchstr, oplate, rtn, overrideHash)
                Else
                    If matchstr.StartsWith("subplate") Then
                        rtn = osubplateref.InvokeMember(matchstr.Split(".")(1), BindingFlags.GetField, Nothing, oplate._subplate, Nothing)
                    Else
                        rtn = oplateref.InvokeMember(matchstr, BindingFlags.GetField, Nothing, oplate, Nothing)
                    End If

                    If Trim(rtn) = Split(Mid(m.ToString, 2, m.ToString.Length - 2), ":::")(1) Then
                        rtn = ""

                    End If
                End If
            Else
                rtn = overrideHash(matchstr)
            End If

            translateStr = translateStr.Replace(m.ToString, rtn)

        Next


        translateStr = translateStr.Replace("-NL-", "<br>")
        translateStr = Regex.Replace(translateStr, "<strong>(\s{1,})?</strong>", "", RegexOptions.IgnoreCase)
        translateStr = Regex.Replace(translateStr, "<br>(\s{1,})?<br>", "<br>", RegexOptions.IgnoreCase)

        Me.desc_multiline = translateStr





    End Function
    Public Function LoadDescription(ByVal filename As String, ByVal oplate As ion_two.skl_lst_inventory) As String
        Dim hash As New Hashtable
        Dim oxml As New cls_nd_xmlread
        oxml.xml_file = filename
        oxml.Load()
        Dim nodes As XmlNodeList
        Dim stype As String
        If Me.FilterSpecialItems(oplate, stype) Then
        Else
            nodes = oxml.GetNodes_ByPath("//desc/desccode[@type='" + Me.desc_type + "'][@id='plate" + oplate._platetype.ToString + "']")
        End If

        Dim str As String
        str = nodes(0).InnerText

        Return str








    End Function

    Public Function FilterSpecialItems(ByVal oplate As ion_two.skl_lst_inventory, ByRef rstring As String) As Boolean

        Return False

    End Function

    Public Function CheckSpecialKeys(ByVal key As String) As Boolean

        If key.StartsWith("key::full_stone_extended") Then
            Return True
        ElseIf key.StartsWith("key::cs_stone_extended") Then
            Return True
        ElseIf key.StartsWith("key::cs_stone_extended_flat") Then
            Return True
        ElseIf key.StartsWith("key::jewel_extended") Then
            Return True
        ElseIf key.StartsWith("key::diamond_color") Then
            Return True
        ElseIf key.StartsWith("key::pair_of") Then
            Return True
        ElseIf key.StartsWith("key::jewel_bend") Then
            Return True
        ElseIf key.StartsWith("key::stoneexchange") Then
            Return True
        ElseIf key.StartsWith("key::spacedmeasurments") Then
            Return True
        Else
            Return False
        End If

    End Function

    Public Function SpecialKeysExec(ByVal key As String, ByVal oplate As skl_lst_inventory, ByRef rstring As String, Optional ByVal overridehash As Hashtable = Nothing) As Boolean

        Dim ostringfunc As New iFunctions.cls_string
        Dim ohtml As New iFunctions.cls_html

        Dim hash As New Hashtable
        hash = ostringfunc.HashfromString(key, "[", "::")



        Select Case hash("key")
            Case "full_stone_extended"

                If oplate._subplate._stone_extended = hash("exclude") Then
                    rstring = ""
                    Exit Select
                End If

                Dim cs_text, ss_text As String
                'Dim oextra As New ion_two.cls_jewerly_extra
                'oextra.get_stone_extended_string(oplate._subplate._stone_extended)
                If Not overridehash Is Nothing Then
                    If overridehash.ContainsKey("csinfo") Then
                        oplate._subplate._jewel_extended.cs_desc = overridehash("csinfo")
                    End If
                    If overridehash.ContainsKey("ssinfo") Then
                        oplate._subplate._jewel_extended.ss_desc = overridehash("ssinfo")
                    End If
                End If
                If oplate._subplate._jewel_extended.cs_desc <> "" Then

                    ohtml.wrapSpan(oplate._subplate._jewel_extended.cs_desc, cs_text, "stone_extended_cs_desc_title")

                    If oplate._subplate._relateditem_id > 1 Then

                        ohtml.wrapLink(oplate._subplate._relateditem_link, cs_text, cs_text)


                        '' Else
                        ''     cs_text = oplate._subplate._jewel_extended.cs_desc
                    End If



                    If oplate._subplate._jewel_extended.cs_type <> "-" Then cs_text += "<br>Natural " + oplate._subplate._jewel_extended.cs_type
                    If oplate._subplate._jewel_extended.cs_cut <> "-" Then cs_text += "<br>" + oplate._subplate._jewel_extended.cs_cut

                End If

                If oplate._subplate._jewel_extended.ss_desc <> "" Then
                    ss_text = oplate._subplate._jewel_extended.ss_desc
                    ss_text += "<br>" + oplate._subplate._jewel_extended.ss_type
                    If oplate._subplate._jewel_extended.ss_cut <> "-" Then ss_text += "<br>" + oplate._subplate._jewel_extended.ss_cut
                End If

                rstring = cs_text + hash("infodelim") + ss_text

            Case "cs_stone_extended"

                If oplate._subplate._stone_extended = hash("exclude") Then
                    rstring = ""
                    Exit Select
                End If

                If oplate._subcategory_name.ToLower.IndexOf("mountings") > -1 Then
                    Dim tmp As String
                    tmp = "Setting for a stone<br><strong>" + (oplate._subplate._extra_stone.split("[").length - 1).ToString + " options available</strong>"

                    rstring = tmp
                    Return True

                End If

                Dim cs_text As String
                Dim oextra As New ion_two.cls_jewerly_extra
                oextra.get_stone_extended_string(oplate._subplate._stone_extended)
                If Not overridehash Is Nothing Then
                    If overridehash.ContainsKey("csinfo") Then
                        oplate._subplate._jewel_extended.cs_desc = overridehash("csinfo")
                    End If
                    If overridehash.ContainsKey("ssinfo") Then
                        oplate._subplate._jewel_extended.ss_desc = overridehash("ssinfo")
                    End If
                End If
                If oplate._subplate._jewel_extended.cs_desc <> "" Then

                    ohtml.wrapSpan(oplate._subplate._jewel_extended.cs_desc, cs_text, "stone_extended_cs_desc_title")

                    If oplate._subplate._relateditem_id > 1 Then

                        ohtml.wrapLink(oplate._subplate._relateditem_link, cs_text, cs_text)


                        '' Else
                        ''     cs_text = oplate._subplate._jewel_extended.cs_desc
                    End If



                    If oplate._subplate._jewel_extended.cs_type <> "-" Then cs_text += "<br>Natural " + oplate._subplate._jewel_extended.cs_type
                    If oplate._subplate._jewel_extended.cs_cut <> "-" Then cs_text += "<br>" + oplate._subplate._jewel_extended.cs_cut

                End If



                rstring = cs_text

            Case "cs_stone_extended_flat"

                If oplate._subplate._stone_extended = hash("exclude") Then
                    rstring = ""
                    Exit Select
                End If

                Dim cs_text As String
                Dim oextra As New ion_two.cls_jewerly_extra
                oextra.get_stone_extended_string(oplate._subplate._stone_extended)
                If oplate._subplate._jewel_extended.cs_desc <> "" Then

                    ohtml.wrapSpan(oplate._subplate._jewel_extended.cs_desc, cs_text, "stone_extended_cs_desc_title")

                    If oplate._subplate._relateditem_id > 1 Then

                        ohtml.wrapLink(oplate._subplate._relateditem_link, cs_text, cs_text)


                        '' Else
                        ''     cs_text = oplate._subplate._jewel_extended.cs_desc
                    End If



                    If oplate._subplate._jewel_extended.cs_type <> "-" Then cs_text += " " + oplate._subplate._jewel_extended.cs_type
                    If oplate._subplate._jewel_extended.cs_cut <> "-" Then cs_text += "," + oplate._subplate._jewel_extended.cs_cut

                End If



                rstring = cs_text
            Case "jewel_extended"
                Dim je_hash As Hashtable = ostringfunc.HashfromString(oplate._subplate._jewel_extended, "|", "::")
                rstring = je_hash(hash("item"))
            Case "diamond_color"
                If oplate._category_name = "Fancy Diamonds" Then
                    If oplate._subplate.fancy_freetxt <> "" Then
                        rstring = oplate._subplate.fancy_freetxt
                    Else
                        rstring = oplate._subplate._colorfrom
                    End If
                Else
                    rstring = oplate._subplate._colorfrom
                End If

            Case "pair_of"
                If oplate._subplate._quantity = 2 Then
                    rstring = "Pair of"
                ElseIf oplate._subplate._quantity = 3 Then
                    rstring = "Three "
                ElseIf oplate._subplate._quantity > 3 Then
                    rstring = "Parcel of"
                End If

            Case "stoneexchange"

                Dim str As String

                Dim oPictures As New ion_two.cls_pictures

                Dim oSefunc As New ion_two.cls_stone_exchange
                oSefunc.Conn_String = Me.conn_string
                oSefunc.db_type = Me.db_type
                oSefunc.picture_obj = oPictures
                oSefunc.is_dealer = False
                ''get the type and color and stuff of the related stone
                Dim stone_type, stone_shape, stone_color As String
                Dim stone_weight, stone_price As Decimal

                oSefunc.original_stone_id = oplate._subplate.se_relateditem_id

                ''load
                oSefunc.load_stone_exchange_byid(oplate._subplate.se_relateditem_id, stone_type, stone_shape, stone_weight, stone_color, stone_price)






                ''set sql str
                If InStr(stone_color.ToLower, "pink") > 0 And stone_type = "Sapphire" Then
                    oSefunc.make_sql_str(stone_type, stone_shape, stone_weight, 1)
                ElseIf InStr(stone_color.ToLower, "yellow") > 0 And stone_type = "Sapphire" Then
                    oSefunc.make_sql_str(stone_type, stone_shape, stone_weight, 2)
                Else
                    oSefunc.make_sql_str(stone_type, stone_shape, stone_weight, 0)
                End If
                ''load collection of the table
                oSefunc.make_table()


                If oSefunc.SE_collection.Count > 1 Then
                    str = "This ring can <br>be made with <br><strong>" + oSefunc.SE_collection.Count.ToString + " stones</strong><br>to choose from"
                End If
                rstring = str
            Case "jewel_bend"
                If oplate.opthash.ContainsKey("bend_from") Then
                    rstring = "From " + oplate.opthash("bend_from") + "mm To " + oplate.opthash("bend_to") + "mm"
                Else
                    rstring = "0"
                End If
            Case "spacedmeasurments"
                rstring = oplate._subplate._s_measure.replace("x", " x ")


        End Select


    End Function
    ''items from subplate are listed as subplate.something
    Public Function GetPlateItem(ByVal oplate As skl_lst_inventory, ByVal item As String, ByRef rproperty As String) As Boolean

        Dim oplateref As Type
        Dim osubplateref As Type
        osubplateref = oplate._subplate.GetType
        oplateref = oplate.GetType

        If item.StartsWith("subplate") Then
            rproperty = osubplateref.InvokeMember(item.Split(".")(1), BindingFlags.GetField, Nothing, oplate._subplate, Nothing)
        Else
            rproperty = oplateref.InvokeMember(item, BindingFlags.GetField, Nothing, oplate, Nothing)
        End If



    End Function
    'Public Function AddStringEncodedProperties(ByVal obj As Object, ByVal str As String, ByVal itemdelim As String, ByVal valdelim As String) As Boolean

    '    Dim objtype As Type

    '    objtype = obj.GetType
    '    Dim ostringfunc As New iFunctions.cls_string
    '    Dim hash As Hashtable = ostringfunc.HashfromString(str, itemdelim, valdelim)

    '    Dim myTypeBuilder As Emit.TypeBuilder = DefineType("CustomerData", TypeAttributes.Public)

    '    For Each key As String In hash.Keys
    '        Dim oprop As Emit.PropertyBuilder
    '        oprop.defi()

    '    Next
    '    '' Reflection.Emit.PropertyBuilder()

    'End Function
End Class
