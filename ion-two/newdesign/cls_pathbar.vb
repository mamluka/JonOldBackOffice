Public Class cls_pathbar
    Public link_coll As New ArrayList
    Public Function Add(ByVal text As String, ByVal url As String) As Boolean
        Dim hash As New Hashtable
        hash("text") = text
        hash("url") = url
        link_coll.Add(hash)
    End Function
End Class
