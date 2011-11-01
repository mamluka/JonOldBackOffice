Imports System.Xml
Public Class cls_nd_lgk
    Public xml_file As String
    Public Function load_links(ByVal links_nod As String, ByRef link_coll As ArrayList)
        Dim oxml As New ion_two.cls_nd_xmlread
        oxml.xml_file = Me.xml_file
        oxml.Load(links_nod)

        Dim xmlnodes As XmlNodeList = oxml.GetNodes_ByPath("qlink")

        Dim i As Int32 = 0

        If xmlnodes.Count > 0 Then

            For i = 0 To xmlnodes.Count - 1
                Dim otmplink As New ion_two.cls_nd_linkpart
                otmplink.txt = xmlnodes.Item(i).InnerText
                otmplink.link = xmlnodes.Item(i).Attributes("link").InnerText

                'If IsNothing(xmlnodes.Item(i).Attributes("js")) Then
                '    otmplink.has_redDot = False
                'Else
                '    otmplink.has_redDot = True
                '    otmplink.javacript_command = xmlnodes.Item(i).Attributes("js").InnerText
                'End If

                If IsNothing(xmlnodes.Item(i).Attributes("reddotid")) Then
                    otmplink.has_redDot = False
                Else
                    otmplink.has_redDot = True
                    otmplink.link_rd_id = xmlnodes.Item(i).Attributes("reddotid").InnerText
                End If

                If Not IsNothing(xmlnodes.Item(i).Attributes("sepdown")) Then
                    otmplink.sepdown = xmlnodes.Item(i).Attributes("sepdown").InnerText
                End If

                If Not IsNothing(xmlnodes.Item(i).Attributes("sepup")) Then
                    otmplink.sepup = xmlnodes.Item(i).Attributes("sepup").InnerText
                End If


                If Not IsNothing(xmlnodes.Item(i).Attributes("more")) Then
                    otmplink.more = True
                End If

                If Not IsNothing(xmlnodes.Item(i).Attributes("title")) Then
                    otmplink.title = xmlnodes.Item(i).Attributes("title").InnerText
                End If

                If Not IsNothing(xmlnodes.Item(i).Attributes("aftermore")) Then
                    otmplink.aftermore = True
                End If


                If Not IsNothing(xmlnodes.Item(i).Attributes("linkid")) Then
                    otmplink.linkid = "id='" + xmlnodes.Item(i).Attributes("linkid").InnerText + "'"
                End If


                link_coll.Add(otmplink)


            Next

        End If





    End Function
    Public Function load_links(ByVal links_nod As XmlNodeList, ByRef link_coll As ArrayList)
       
        Dim i As Int32
        For i = 0 To links_nod.Count - 1
            Dim otmplink As New ion_two.cls_nd_linkpart
            otmplink.txt = links_nod.Item(i).InnerText
            otmplink.link = links_nod.Item(i).Attributes("link").InnerText

            'If IsNothing(xmlnodes.Item(i).Attributes("js")) Then
            '    otmplink.has_redDot = False
            'Else
            '    otmplink.has_redDot = True
            '    otmplink.javacript_command = xmlnodes.Item(i).Attributes("js").InnerText
            'End If

            If IsNothing(links_nod.Item(i).Attributes("reddotid")) Then
                otmplink.has_redDot = False
            Else
                otmplink.has_redDot = True
                otmplink.link_rd_id = links_nod.Item(i).Attributes("reddotid").InnerText
            End If

            If Not IsNothing(links_nod.Item(i).Attributes("more")) Then
                otmplink.more = True
            End If

            If Not IsNothing(links_nod.Item(i).Attributes("linkid")) Then
                otmplink.linkid = "id='" + links_nod.Item(i).Attributes("linkid").InnerText + "'"
            End If

            If Not IsNothing(links_nod.Item(i).Attributes("sepdown")) Then
                otmplink.sepdown = links_nod.Item(i).Attributes("sepdown").InnerText
            End If

            If Not IsNothing(links_nod.Item(i).Attributes("sepup")) Then
                otmplink.sepup = links_nod.Item(i).Attributes("sepup").InnerText
            End If


            link_coll.Add(otmplink)


        Next







    End Function

    Public Function LoadQRowTables(ByVal row_node As String, ByVal qitems_coll As ArrayList) As Boolean

        Dim oxml As New ion_two.cls_nd_xmlread
        oxml.xml_file = Me.xml_file
        oxml.Load(row_node)

        Dim qitems As XmlNodeList = oxml.GetNodes_ByPath("qrowitem")

        For Each item As XmlNode In qitems
            Dim oitem As New cls_nd_row_table
            If item.Attributes("sep") Is Nothing Then
                oitem.desc_text = item.Item("desctxt").InnerText.Replace("||", "<br>")
                oitem.button = item.Item("button").InnerText
                oitem.header_img = item.Item("subtitleimage").InnerText
                oitem.icon_pic = item.Item("icon").InnerText
                oitem.link = item.Item("link").InnerText

            Else
                oitem.sep = True
            End If


            qitems_coll.Add(oitem)
        Next


    End Function

    Public Function LoadMorePane(ByVal moreitems As ArrayList) As Boolean
        Dim oxml As New ion_two.cls_nd_xmlread
        oxml.xml_file = Me.xml_file


        Dim items As XmlNodeList = oxml.GetNodes_ByPath("item")


    End Function

    Public Function LoadCombo(ByVal id As String, ByVal combo As Web.UI.WebControls.DropDownList, Optional ByVal defval As String = "", Optional ByVal deftext As String = "")

        Dim oxml As New ion_two.cls_nd_xmlread
        oxml.xml_file = Me.xml_file
        oxml.Load()
        combo.Items.Clear()
        Dim items As XmlNodeList = oxml.GetNodes_ByPath("combo[@id='" + id + "']/item")

        For Each item As XmlNode In items
            combo.Items.Add(New Web.UI.WebControls.ListItem(item.Attributes("text").InnerText, item.Attributes("value").InnerText))
        Next
        If defval <> "" Then
            combo.Items.FindByValue(defval).Selected = True

        End If

        If deftext <> "" Then
            combo.Items.FindByText(deftext).Selected = True

        End If
    End Function

End Class
