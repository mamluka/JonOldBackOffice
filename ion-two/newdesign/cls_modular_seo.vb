
Imports System.Xml
Public Class cls_modular_seo

    Public xml_file As String
    Public xml_seo As String
    Public metainfo As New Hashtable

    Public Function GetMetaDescription(ByRef seohash As Hashtable)

        Dim oxml As New cls_nd_xmlread

        oxml.xml_file = Me.xml_file
        oxml.Load()
        Dim seo As XmlNode = oxml.GetNode_ByPath("seo")
        seohash("desc") = seo.Item("desc").InnerText
        seohash("title") = seo.Item("title").InnerText
    End Function
    Public Function GetMetaDescription(ByRef desclit As String, ByVal titlelit As String)

        Dim oxml As New cls_nd_xmlread

        oxml.xml_file = Me.xml_file
        oxml.Load()
        Dim seo As XmlNode = oxml.GetNode_ByPath("seo")
        desclit = seo.Item("desc").InnerText
        titlelit = seo.Item("title").InnerText

        Me.BuildDescription(desclit, titlelit, desclit, titlelit)


    End Function

    Public Function BuildDescription(ByVal desc As String, ByVal title As String, ByRef seohash As Hashtable)
        seohash("desc") = desc
        seohash("title") = title
    End Function

    Public Function BuildDescription(ByVal desc As String, ByVal title As String, ByRef desclit As String, ByVal titlelit As String)
        desclit = "<META NAME='Description' CONTENT='" + desc + "'  >"
        titlelit = "<META NAME='Title' CONTENT='" + title + "'  >"
    End Function

    Public Function BuildSEO(ByVal urlkey As String, ByRef littext As String) As Boolean

        Dim oxml As New ion_two.cls_nd_xmlread
        oxml.xml_file = Me.xml_seo
        oxml.Load()

        If oxml.GetNodes_ByPath("seopage[@key='" + urlkey.ToLower + "']").Count > 0 Then

            Dim oseo As XmlNode = oxml.GetNodes_ByPath("seopage[@key='" + urlkey.ToLower + "']")(0)
            Dim desc As String = oseo("description").InnerText
            Dim title As String = oseo("title").InnerText
            Dim keywords As String = oseo("keywords").InnerText

            Me.metainfo("desc") = desc
            Me.metainfo("title") = title
            Me.metainfo("keywords") = keywords


            littext += "<META NAME=" + Chr(34) + "Description" + Chr(34) + " CONTENT=" + Chr(34) + desc + Chr(34) + "  >" + vbNewLine
            littext += "<META NAME=" + Chr(34) + "Title" + Chr(34) + " CONTENT=" + Chr(34) + title + Chr(34) + "  >" + vbNewLine
            littext += "<META NAME=" + Chr(34) + "Keywords" + Chr(34) + " CONTENT=" + Chr(34) + keywords + Chr(34) + "  >" + vbNewLine

            Return True

        Else

            Dim oseo As XmlNode = oxml.GetNodes_ByPath("seopage[@key='default']")(0)

            '' Dim oseo As XmlNode = oxml.GetNodes_ByPath("seopage[@key='" + urlkey.ToLower + "']")(0)
            Dim desc As String = oseo("description").InnerText
            Dim title As String = oseo("title").InnerText
            Dim keywords As String = oseo("keywords").InnerText

            Me.metainfo("desc") = desc
            Me.metainfo("title") = title
            Me.metainfo("keywords") = keywords

            littext += "<META NAME=" + Chr(34) + "Description" + Chr(34) + " CONTENT=" + Chr(34) + desc + Chr(34) + "  >" + vbNewLine
            littext += "<META NAME=" + Chr(34) + "Title" + Chr(34) + " CONTENT=" + Chr(34) + title + Chr(34) + "  >" + vbNewLine
            littext += "<META NAME=" + Chr(34) + "Keywords" + Chr(34) + " CONTENT=" + Chr(34) + keywords + Chr(34) + "  >" + vbNewLine

            Return False

        End If
    End Function

    Public Function BuildSEO(ByVal urlkey As String, ByRef littext As String, ByRef titletext As String) As Boolean

        Dim oxml As New ion_two.cls_nd_xmlread
        oxml.xml_file = Me.xml_seo
        oxml.Load()

        If oxml.GetNodes_ByPath("seopage[@key='" + urlkey.ToLower + "']").Count > 0 Then

            Dim oseo As XmlNode = oxml.GetNodes_ByPath("seopage[@key='" + urlkey.ToLower + "']")(0)
            Dim desc As String = oseo("description").InnerText
            Dim title As String = oseo("title").InnerText
            Dim keywords As String = oseo("keywords").InnerText

            Me.metainfo("desc") = desc
            Me.metainfo("title") = title
            Me.metainfo("keywords") = keywords

            titletext = title


            littext += "<META NAME=" + Chr(34) + "Description" + Chr(34) + " CONTENT=" + Chr(34) + desc + Chr(34) + "  >" + vbNewLine
            littext += "<META NAME=" + Chr(34) + "Title" + Chr(34) + " CONTENT=" + Chr(34) + title + Chr(34) + "  >" + vbNewLine
            littext += "<META NAME=" + Chr(34) + "Keywords" + Chr(34) + " CONTENT=" + Chr(34) + keywords + Chr(34) + "  >" + vbNewLine

            Return True

        Else

            Dim oseo As XmlNode = oxml.GetNodes_ByPath("seopage[@key='default']")(0)

            '' Dim oseo As XmlNode = oxml.GetNodes_ByPath("seopage[@key='" + urlkey.ToLower + "']")(0)
            Dim desc As String = oseo("description").InnerText
            Dim title As String = oseo("title").InnerText
            Dim keywords As String = oseo("keywords").InnerText

            Me.metainfo("desc") = desc
            Me.metainfo("title") = title
            Me.metainfo("keywords") = keywords

            littext += "<META NAME=" + Chr(34) + "Description" + Chr(34) + " CONTENT=" + Chr(34) + desc + Chr(34) + "  >" + vbNewLine
            littext += "<META NAME=" + Chr(34) + "Title" + Chr(34) + " CONTENT=" + Chr(34) + title + Chr(34) + "  >" + vbNewLine
            littext += "<META NAME=" + Chr(34) + "Keywords" + Chr(34) + " CONTENT=" + Chr(34) + keywords + Chr(34) + "  >" + vbNewLine

            Return False

        End If
    End Function


    Public Function BuildSEOForTabs(ByVal urlkey As String, ByRef littext As String) As Boolean

        Dim oxml As New ion_two.cls_nd_xmlread
        oxml.xml_file = Me.xml_seo
        oxml.Load()

        If oxml.GetNodes_ByPath("seopage[@key='" + urlkey.ToLower + "']").Count > 0 Then

            Dim oseo As XmlNode = oxml.GetNodes_ByPath("seopage[@key='" + urlkey.ToLower + "']")(0)
            Dim desc As String = oseo("description").InnerText
            Dim title As String = oseo("title").InnerText
            Dim keywords As String = oseo("keywords").InnerText

            littext += "<META NAME=" + Chr(34) + "Description" + Chr(34) + " CONTENT=" + Chr(34) + desc + Chr(34) + "  >" + vbNewLine
            littext += "<META NAME=" + Chr(34) + "Title" + Chr(34) + " CONTENT=" + Chr(34) + title + Chr(34) + "  >" + vbNewLine
            littext += "<META NAME=" + Chr(34) + "Keywords" + Chr(34) + " CONTENT=" + Chr(34) + keywords + Chr(34) + "  >" + vbNewLine
        Else

            Dim oseo As XmlNode = oxml.GetNodes_ByPath("seopage[@key='default']")(0)

            '' Dim oseo As XmlNode = oxml.GetNodes_ByPath("seopage[@key='" + urlkey.ToLower + "']")(0)
            Dim desc As String = oseo("description").InnerText
            Dim title As String = oseo("title").InnerText
            Dim keywords As String = oseo("keywords").InnerText

            littext += "<META NAME=" + Chr(34) + "Description" + Chr(34) + " CONTENT=" + Chr(34) + desc + Chr(34) + "  >" + vbNewLine
            littext += "<META NAME=" + Chr(34) + "Title" + Chr(34) + " CONTENT=" + Chr(34) + title + Chr(34) + "  >" + vbNewLine
            littext += "<META NAME=" + Chr(34) + "Keywords" + Chr(34) + " CONTENT=" + Chr(34) + keywords + Chr(34) + "  >" + vbNewLine

        End If
    End Function




End Class
