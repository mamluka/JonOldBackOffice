Imports System.Text.RegularExpressions
Imports System.Xml
Public Class cls_before_search
    Public isRedirect As Boolean = False
    Public Url As String
    Public words_xml As String
    Public conn_string As String
    Function checkItemNumber(ByVal text As String)


        If Regex.Match(text, "\d{2}-?\d{2}-\d{5}").Success Then

            

            Me.isRedirect = True
            Me.Url = "/viewer/xmyview.aspx?fromlink=1&itemnumber=" + Regex.Match(text, "\d{2}-?\d{2}-\d{5}").Value

        End If

        If Regex.Match(text, "^#\d{2}-?\d{2}$").Success Then
            Me.isRedirect = True
            Me.Url = "/viewer/xmyview.aspx?fromlink=1&itemnumber=ledder|" + Regex.Match(text, "\d{2}-?\d{2}$").Value

        End If


    End Function

    Function checkOnlyWeight(ByVal text As String)


        If Regex.Match(text, "\d{1,}\.?\d{0,}").Success And Regex.Match(text, "ct\.|carat|weight|kt|ct|ctw|tgw",RegexOptions.IgnoreCase).Success Then

            Me.isRedirect = True
            Me.Url = "/viewer/xmyview.aspx?weight=" + Regex.Match(text, "\d{1,}\.?\d{0,}").Value.ToString

        End If

        If Regex.Match(text, "^\d{1,}\.?\d{0,}$").Success Then

            Me.isRedirect = True
            Me.Url = "/viewer/xmyview.aspx?fromlink=1&weight=" + Regex.Match(text, "\d{1,}\.?\d{0,}").Value.ToString

        End If



    End Function

    Function checkCustomWords(ByVal text As String)
        'Dim oxml As New ion_two.cls_nd_xmlread
        'oxml.xml_file = Me.words_xml
        'oxml.Load()

        'Dim word As XmlNode = oxml.GetNode_ByPath("word[@text='" + text + "']")

        'If Not IsNothing(word) Then
        '    Me.isRedirect = True
        '    Me.Url = word.Attributes("link").InnerText
        'End If

        Dim sSql As String
        Dim sql_search As New iDac.cls_sql_read

        sql_search._connection_string = Me.conn_string
        sql_search._tablename = "sys_search_words"
        ''   sql_search._datatable = Application("connection")._connection_string_type

        sSql = "select * from sys_search_words where search_word = '" + text + "'"

        sql_search.transact_read(sSql)

        Dim oData As DataTable = sql_search._datatable

        Dim i As Int32

        If oData.Rows.Count > 0 Then
            Me.Url = oData.Rows(0)("url")
            Me.isRedirect = True

        End If

       
    End Function

    Sub Init(ByVal text As String)
        Me.checkCustomWords(text)
        Me.checkItemNumber(text)
        Me.checkOnlyWeight(text)
    End Sub

End Class
