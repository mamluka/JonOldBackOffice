Imports System.Xml
Imports System.Reflection

Public Class cls_mills_lgk
    Public infotree_xml_file As String
    Public Function ReadInfoTreeSchema(ByVal xml_file As String, ByVal oplate As Object, ByRef schema_coll As XmlNodeList)
        Dim oxml As New ion_two.cls_nd_xmlread
        oxml.xml_file = xml_file
        oxml.Load()
        If oplate._platetype = 1 And oplate._category_name.ToLower.IndexOf("fancy") > -1 Then
            schema_coll = oxml.GetNodes_ByPath("//infotree/infotree_schema[@plate='fancy']/infopart")
            Return 0
        End If
        'If oplate._platetype = 1 And oplate._subcategory_name = "Diamonds, Loose" Then
        '    schema_coll = oxml.GetNodes_ByPath("//infotree/infotree_schema[@plate='idex']/infopart")
        '    Return 0
        'End If
        schema_coll = oxml.GetNodes_ByPath("//infotree/infotree_schema[@plate='" + Convert.ToString(oplate._platetype) + "']/infopart")

    End Function
    Public Function CreateSlimInfoTreeXML(ByVal oplate As Object, ByRef xmlout As XmlElement)

        Dim tmpXML As New XmlDocument
        tmpXML.AppendChild(tmpXML.CreateElement("xmlroot"))
        Dim shema_nodes As XmlNodeList
        Me.ReadInfoTreeSchema(Me.infotree_xml_file, oplate, shema_nodes)

        Dim oplateref As Type
        Dim osubplateref As Type

        ''osubplateref = oplate._subplate.GetType

        oplateref = oplate.GetType

        For Each shema As XmlNode In shema_nodes


            Dim infopart As XmlElement = tmpXML.CreateElement("infopart")

            Dim rtn As String
            Dim sourcestr As String = shema.Attributes("source").InnerText
            Dim AddStopper As Boolean = False



            '' If sourcestr.StartsWith("subplate") Then
            '' rtn = osubplateref.InvokeMember(sourcestr.Split(".")(1), BindingFlags.GetField, Nothing, oplate._subplate, Nothing)
            ''  ElseIf sourcestr.StartsWith("custom") Then
            '    Dim oextra As New ion_two.cls_jewerly_extra
            '    oextra.get_stone_extended_string(oplate._subplate._stone_extended)
            '    If sourcestr.Split(".")(1) = "cs" Then

            '        If oextra.c_type <> "-" Then
            '            rtn = oextra.c_type
            '        End If
            '        If oextra.c_cut <> "-" Then
            '            rtn += ", " + oextra.c_cut
            '        End If

            '    ElseIf sourcestr.Split(".")(1) = "ss" Then
            '        If oextra.s_type <> "-" Then
            '            rtn = oextra.s_type
            '        End If
            '        If oextra.s_cut <> "-" Then
            '            rtn += ", " + oextra.s_cut
            '        End If

            '    '' End If
            'Else
            rtn = oplateref.InvokeMember(sourcestr, BindingFlags.GetField, Nothing, oplate, Nothing)
            '' End If

            If Not IsNothing(shema.Attributes("empty")) Then
                If rtn = shema.Attributes("empty").InnerText Then
                    AddStopper = True
                End If
            End If


            infopart.InnerText = rtn
            Dim title_attr As XmlAttribute = tmpXML.CreateAttribute("title")
            title_attr.InnerText = shema.InnerText

            infopart.Attributes.Append(title_attr)
            If Not shema.Attributes.ItemOf("bold") Is Nothing Then
                Dim bold_attr As XmlAttribute = tmpXML.CreateAttribute("bold")
                bold_attr.InnerText = shema.Attributes("bold").InnerText

                infopart.Attributes.Append(bold_attr)
            End If

            If Not AddStopper Then
                tmpXML.FirstChild.AppendChild(infopart)
            End If

        Next


        xmlout = tmpXML.ChildNodes(0)


    End Function

    Public Function CreateInfoTreeXML(ByVal oplate As Object, ByRef xmlout As XmlElement)

        Dim tmpXML As New XmlDocument
        tmpXML.AppendChild(tmpXML.CreateElement("xmlroot"))
        Dim shema_nodes As XmlNodeList
        Me.ReadInfoTreeSchema(Me.infotree_xml_file, oplate, shema_nodes)

        Dim oplateref As Type
        Dim osubplateref As Type

        Dim ostringfunc As New iFunctions.cls_string

        osubplateref = oplate._subplate.GetType

        oplateref = oplate.GetType

        For Each shema As XmlNode In shema_nodes


            Dim infopart As XmlElement = tmpXML.CreateElement("infopart")

            Dim rtn As String
            Dim sourcestr As String = shema.Attributes("source").InnerText
            Dim AddStopper As Boolean = False



            If sourcestr.StartsWith("subplate") Then
                rtn = osubplateref.InvokeMember(sourcestr.Split(".")(1), BindingFlags.GetField, Nothing, oplate._subplate, Nothing)
            ElseIf sourcestr.StartsWith("custom") Then

                Dim subplate As skl_lst_jewelry = oplate._subplate
                'Dim oextra As New ion_two.cls_jewerly_extra
                'oextra.get_stone_extended_string(oplate._subplate._stone_extended)

                If sourcestr.Split(".")(1) = "cs" Then

                    'If subplate._jewel_extended.cs_weight > 0 Then
                    '    rtn += ostringfunc.format_decimal_return(subplate._jewel_extended.cs_weight, " Ctw.")
                    'End If
                    'If subplate._jewel_extended.color_freetxt <> "" Then
                    '    rtn += " " + subplate._jewel_extended.color_freetxt
                    'Else
                    '    rtn += " " + subplate._jewel_extended.color + "/" + subplate._jewel_extended.clarity
                    'End If

                    'If subplate._jewel_extended.cs_type <> "-" Then
                    '    rtn += "<br>" + subplate._jewel_extended.cs_type
                    'End If

                    'If subplate._jewel_extended.cs_count > 0 Then
                    '    rtn += "<br>" + subplate._jewel_extended.ss_count + " stone(s)"
                    'End If

                    If oplate._subplate._jewel_extended.cs_desc <> "-" Then
                        rtn = oplate._subplate._jewel_extended.cs_type
                    End If
                    If oplate._subplate._jewel_extended.cs_cut <> "-" Then
                        rtn += ", " + oplate._subplate._jewel_extended.cs_cut

                    End If
                    rtn += "<br>" + oplate._subplate._jewel_extended.cs_type

                ElseIf sourcestr.Split(".")(1) = "ss" Then
                    If subplate._jewel_extended.ss_desc <> "" Then
                        If oplate._subplate._jewel_extended.ss_desc <> "-" Then
                            rtn = oplate._subplate._jewel_extended.ss_desc
                        End If
                        If oplate._subplate._jewel_extended.ss_cut <> "-" Then
                            rtn += "<br>" + oplate._subplate._jewel_extended.ss_cut

                        End If
                        rtn += "<br>" + oplate._subplate._jewel_extended.ss_type
                    End If
                    ElseIf sourcestr.Split(".")(1) = "csdesc" Then

                    If oplate._subplate._jewel_extended.cs_desc <> "-" Then
                        rtn = oplate._subplate._jewel_extended.cs_desc
                    End If
                    If oplate._subplate._jewel_extended.cs_cut <> "-" Then
                        rtn += "<br>" + oplate._subplate._jewel_extended.cs_cut

                    End If
                    rtn += "<br>" + oplate._subplate._jewel_extended.cs_type
                    End If
            Else
                rtn = oplateref.InvokeMember(sourcestr, BindingFlags.GetField, Nothing, oplate, Nothing)
            End If

            If Not IsNothing(shema.Attributes("empty")) Then
                If rtn = shema.Attributes("empty").InnerText Then
                    AddStopper = True
                End If
            End If


            infopart.InnerText = rtn
            Dim title_attr As XmlAttribute = tmpXML.CreateAttribute("title")
            title_attr.InnerText = shema.InnerText

            infopart.Attributes.Append(title_attr)
            If Not shema.Attributes.ItemOf("bold") Is Nothing Then
                Dim bold_attr As XmlAttribute = tmpXML.CreateAttribute("bold")
                bold_attr.InnerText = shema.Attributes("bold").InnerText

                infopart.Attributes.Append(bold_attr)
            End If

            If (Not AddStopper) And (rtn <> "") Then
                tmpXML.FirstChild.AppendChild(infopart)
            End If
            rtn = ""


        Next


        xmlout = tmpXML.ChildNodes(0)


    End Function

End Class
