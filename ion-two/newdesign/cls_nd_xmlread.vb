Imports System.Xml
Public Class cls_nd_xmlread
    Public xml_file As String

    Private xmlroot As XmlElement
    Private xmlLocalnode As XmlNode
    Private xmldoc As New XmlDocument
    Overloads Function Load(ByVal subload As String) As Boolean

        Me.Load()
        Me.xmlroot = xmldoc.ChildNodes(1).Item(subload)



    End Function
    Overloads Function Load() As XmlNode
        Me.xmldoc.Load(Me.xml_file)
        Me.LoadRootElement()
    End Function
    Function LoadRootElement()
        Me.xmlLocalnode = xmldoc.ChildNodes(1)
        If IsNothing(Me.xmlLocalnode) Then
            Me.xmlLocalnode = xmldoc.ChildNodes(0)
        End If
    End Function
    Function LoadNodeList_ByRootKey(ByVal key As String) As XmlNodeList
        Me.Load()
        Return Me.xmlLocalnode.SelectNodes(key)
    End Function


    Public Function GetText_ByPath(ByVal path() As String, Optional ByVal nodeI As Int32 = 1) As String
        Dim i As Int32

        Dim xpath As String = Join(path, "/")
        ''  xpath = String.Concat("/" + xmlroot.Name + "/", xpath)
        xpath += "[" + Convert.ToString(nodeI) + "]"

        Try
            Dim xmlchild As XmlElement = xmlroot.SelectSingleNode(xpath)
            Return xmlchild.InnerText

        Catch ex As Exception
            Return ""
        End Try







    End Function

    Public Function GetNodes_ByPath(ByVal path As String) As XmlNodeList
        Try
            If Not IsNothing(xmlroot) Then
                Return xmlroot.SelectNodes(path)
            Else
                Return Me.xmlLocalnode.SelectNodes(path)
            End If
            ''Return xmlchild.InnerText

        Catch ex As Exception
            Return Nothing
        End Try

    End Function
    Public Function GetNode_ByPath(ByVal path As String) As XmlNode
        Try
            If Not IsNothing(xmlroot) Then
                Return xmlroot.SelectSingleNode(path)
            Else
                Return Me.xmlLocalnode.SelectSingleNode(path)
            End If
            ''Return xmlchild.InnerText

        Catch ex As Exception
            Return Nothing
        End Try

    End Function
    Public Function PutAttrIntoHash(ByVal node As XmlNode, ByRef hash As Hashtable)
        For Each attr As XmlAttribute In node.Attributes
            hash(attr.Name) = attr.InnerText
        Next
        hash("innertext") = node.InnerText
    End Function
End Class
