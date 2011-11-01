Public Class cls_search_keywords
    Public keys As New ArrayList
    Public conn_string As String
    Sub New()
        addkey("engagement", "/engagement-rings.aspx")
        addkey("new", "/new-items.aspx")
        addkey("search", "/search.aspx")

        ''load from db
       
        

    End Sub

    Function load_from_db()
        Dim sSql As String
        Dim sql_search As New iDac.cls_sql_read

        sql_search._connection_string = Me.conn_string
        sql_search._tablename = "sys_search_words"
        ''   sql_search._datatable = Application("connection")._connection_string_type

        sSql = "select * from sys_search_words"

        sql_search.transact_read(sSql)

        Dim oData As DataTable = sql_search._datatable

        Dim i As Int32

        If oData.Rows.Count = 0 Then Exit Function ''get out

        For i = 0 To oData.Rows.Count - 1
            addkey(oData.Rows(i).Item("search_word"), oData.Rows(i).Item("url"))
        Next
    End Function
    Private Function addkey(ByVal key As String, ByVal link As String)
        Dim tmpkey As New key_item
        tmpkey.link = link
        tmpkey.key = key
        Me.keys.Add(tmpkey)
    End Function
    Private Class key_item
        Public link As String
        Public key As String
    End Class

End Class
