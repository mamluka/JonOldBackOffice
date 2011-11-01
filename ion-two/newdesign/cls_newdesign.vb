Imports System.Xml
Public Class cls_newdesign
    Public def_nd_paths As New nd_paths
    Public config_file_path As String
    Function load()

        Me.def_nd_paths.load(Me.config_file_path)
    End Function


    ''this is all new design
    Public Class nd_paths

        Public image_path As String
        ''this is a class defaulr paths read from xml
        Function load(ByVal config_file_path As String)
            Dim xmldoc As New XmlDocument
            Dim xmlpath As String = config_file_path
            xmldoc.Load(xmlpath)
            Dim xmlroot As XmlElement = xmldoc.Item("config")
            ''load
            Me.image_path = xmlroot.Item("imagepath").InnerText
        End Function
    End Class
End Class
