Public Class cls_html
    Public Function wrapMailTo(ByVal email As String, ByVal text As String, ByRef rstring As String)
        rstring = "<a href=" + Chr(34) + "mailto:" + email + Chr(34) + " >" + text + "</a>"
    End Function

    Public Function wrapLink(ByVal link As String, ByVal text As String, ByRef rstring As String)
        rstring = "<a href=" + Chr(34) + link + Chr(34) + " >" + text + "</a>"
    End Function
    Public Function wrapSpan(ByVal text As String, ByRef rstring As String, Optional ByVal id As String = "", Optional ByVal cssclass As String = "") As Boolean

        rstring = "<span id=" + Chr(34) + id + Chr(34) + " class=" + Chr(34) + cssclass + Chr(34) + ">" + text + "</span>"
    End Function

    Public Function EncodeURL2Quary(ByRef url As String)

        url = url.Replace("&", "^and^")
        url = url.Replace("?", "^q^")

    End Function

    Public Function DecodeURLFromQuary(ByRef url As String)

        url = url.Replace("^and^", "&")
        url = url.Replace("^q^", "?")

    End Function

    


End Class

