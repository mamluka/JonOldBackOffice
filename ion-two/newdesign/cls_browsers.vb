Imports System.Web
Public Class cls_browsers

    Public firefoxok As Boolean = False

    Public Function HandleBrowsers(ByVal agent As String)


        If agent.ToLower.IndexOf("firefox") > -1 And Me.firefoxok = False Then
            HttpContext.Current.Response.Status = "301 Moved Permanently"
            HttpContext.Current.Response.AddHeader("Location", "/firefox.aspx")
        ElseIf agent.ToLower.IndexOf("safari") > -1 And Me.firefoxok = False Then
            HttpContext.Current.Response.Status = "301 Moved Permanently"
            HttpContext.Current.Response.AddHeader("Location", "/firefox.aspx")
        ElseIf agent.ToLower.IndexOf("gecko") > -1 And Me.firefoxok = False Then
            HttpContext.Current.Response.Status = "301 Moved Permanently"
            HttpContext.Current.Response.AddHeader("Location", "/firefox.aspx")
        End If

    End Function


End Class
