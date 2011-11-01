Imports System.Xml
Public Class cls_nd_xmlwrite
    Public xml_file As String

    Private xmlroot As XmlElement
    Private xmlLocalnode As XmlNode
    Public xmldoc As New XmlDocument
    Overloads Function Load(ByVal subload As String) As Boolean

        Me.Load()
        Me.xmlroot = xmldoc.ChildNodes(1).Item(subload)

        Me.xmlLocalnode = xmldoc.ChildNodes(1).Item(subload)

    End Function
    Overloads Function Load() As XmlNode
        Me.xmldoc.Load(Me.xml_file)
        Me.LoadRootElement()
    End Function
    Function LoadRootElement()
        Me.xmlLocalnode = xmldoc.ChildNodes(1)
    End Function
    Function LoadNodeList_ByRootKey(ByVal key As String) As XmlNodeList
        Me.Load()
        Return Me.xmlLocalnode.SelectNodes(key)
    End Function
    Function CreateXMLNode(ByVal nodearray As ArrayList, Optional ByVal ns As String = "") As XmlNode
        On Error GoTo errorhandler
        Dim xmlnode As XmlNode

        If nodearray(0).indexof(":") > -1 Then
            xmlnode.Prefix = Split(nodearray(0), ":")(0)
            xmlnode = Me.xmldoc.CreateElement(Split(nodearray(0), ":")(1))
        Else
            xmlnode = Me.xmldoc.CreateElement(nodearray(0))
        End If
        Dim i As Int32

        For i = 1 To nodearray.Count - 1
            If nodearray(i).indexof(":") > -1 Then
                Dim xmlnodeitem As XmlNode = Me.xmldoc.CreateElement("g", Split(nodearray(i), ":")(1), ns)
                ''  xmlnodeitem.Prefix = Split(nodearray(i), ":")(0)
                xmlnode.AppendChild(xmlnodeitem)
            Else
                ''xmlnode = Me.xmldoc.CreateElement(nodearray(0))
                xmlnode.AppendChild(Me.xmldoc.CreateElement(nodearray(i)))
            End If

        Next

        Return xmlnode
errorhandler:
        Dim a As String = Err.Description()
    End Function
    Function CreateXMLNode(ByVal name As String) As XmlNode
        Dim xmlnode As XmlNode
        xmlnode = Me.xmldoc.CreateElement(name)


        Return xmlnode
    End Function
    Function CreateXMLNode(ByVal name As String, ByVal text As String) As XmlNode
        Dim xmlnode As XmlNode
        xmlnode = Me.xmldoc.CreateElement(name)

        xmlnode.InnerText = text
        Return xmlnode
    End Function
    Function CreateXmlAttribute(ByVal key As String, ByVal val As String) As XmlAttribute
        Dim attr As XmlAttribute = Me.xmldoc.CreateAttribute(key)
        attr.InnerText = val

        Return attr
    End Function
    Function WriteNodeToPath(ByVal path As String, ByVal node As XmlNode)

        ''xmldoc.ChildNodes(1).RemoveChild(xmldoc.SelectSingleNode("//banners_root/banner[2]"))
        If path <> "" Then
            xmldoc.ChildNodes(1).SelectSingleNode(path).AppendChild(node)
        Else
            xmldoc.ChildNodes(1).AppendChild(node)
        End If
        xmldoc.Save(Me.xml_file)
    End Function
    Function WriteRootElement(ByVal node As XmlNode) As Boolean
        xmldoc.AppendChild(node)
    End Function

    Function UpdateNodeToPath(ByVal path As String, ByVal node As XmlNode)

        ''xmldoc.ChildNodes(1).RemoveChild(xmldoc.SelectSingleNode("//banners_root/banner[2]"))
        If path.IndexOf("/") > -1 Then
            xmldoc.ChildNodes(1).SelectSingleNode(path).ParentNode.ReplaceChild(node, xmldoc.ChildNodes(1).SelectSingleNode(path))
        Else
            xmldoc.ChildNodes(1).ReplaceChild(node, xmldoc.ChildNodes(1).SelectSingleNode(path))
        End If
        xmldoc.Save(Me.xml_file)
    End Function


    Function DeleteNodeByPath(ByVal path As String)
        If path.IndexOf("/") > -1 Then
            xmldoc.ChildNodes(1).SelectSingleNode(path).ParentNode.RemoveChild(xmldoc.ChildNodes(1).SelectSingleNode(path))
        Else
            xmldoc.ChildNodes(1).RemoveChild(xmldoc.ChildNodes(1).SelectSingleNode(path))
        End If
        xmldoc.Save(Me.xml_file)
    End Function

    Function SaveDoc()
        Me.xmldoc.Save(Me.xml_file)
    End Function
End Class
