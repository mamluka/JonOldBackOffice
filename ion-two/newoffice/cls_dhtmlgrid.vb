Imports System.Xml
Public Class cls_dhtmlgrid
    Public Function CreateRowFromArrayList(ByVal array As ArrayList) As String
        ''  Dim xmlroot As New Xml

        Dim xml As New XmlDocument

        Dim xmlroot As XmlElement = xml.CreateElement("rows")

        Dim i As Int32
        For i = 0 To array.Count - 1
            Dim xmlrow As XmlElement = xml.CreateElement("row")
            Dim xmlattr1 As XmlAttribute = xml.CreateAttribute("id")

            xmlattr1.InnerText = i.ToString
            xmlrow.Attributes.Append(xmlattr1)

            Dim j As Int32
            Dim cellarray As ArrayList = array.Item(i)

            For j = 0 To cellarray.Count - 1
                Dim xmlcell As XmlElement = xml.CreateElement("cell")
                xmlcell.InnerText = cellarray(j)
                ''  xmlcell.AppendChild(xml.CreateCDataSection("<img src='sfsdf' ></img>"))
                xmlrow.AppendChild(xmlcell)
            Next

            xmlroot.AppendChild(xmlrow)
        Next

        Return xmlroot.OuterXml.ToString


    End Function
End Class
