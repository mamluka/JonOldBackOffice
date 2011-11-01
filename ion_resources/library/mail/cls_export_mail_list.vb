Imports System.IO
Imports System.Web.HttpContext
Imports System.Net


Public Class cls_export_mail_list
    Inherits iFoundation.cls_error
    Public conn_string As String
    Function write_email_list() As Boolean
        On Error GoTo ErrorHandler
        Dim fp As StreamWriter


        Dim oDG_search As New iDac.cls_sql_read

        oDG_search._connection_string = Me.conn_string '' Application("connection")._connection_string
        oDG_search._tablename = "usr_CUSTOMERS"

        oDG_search.transact_read("select email,id from usr_CUSTOMERS where userdeleted < 1 and inv_mail = 1")

        Dim oData As DataTable = oDG_search._datatable

        fp = File.CreateText(Web.HttpContext.Current.Server.MapPath("ion-mailing/" + Format(Now.Now, "d-MM-yy-")) + "maillist_inventory(first options).txt")

        Dim i
        For i = 1 To oData.Rows.Count - 1
            fp.WriteLine(Convert.ToString(oData.Rows(i).Item("id")) + "," + oData.Rows(i).Item("email"))
        Next
        fp.Close()

        oDG_search.transact_read("select email,id from usr_CUSTOMERS where userdeleted < 1 and inv_update = 1")

        ''  Dim oData As DataTable = oDG_search._datatable

        fp = File.CreateText(Web.HttpContext.Current.Server.MapPath("ion-mailing/" + Format(Now.Now, "d-MM-yy-")) + "maillist_update(second options).txt")

        For i = 1 To oData.Rows.Count - 1
            fp.WriteLine(Convert.ToString(oData.Rows(i).Item("id")) + "," + oData.Rows(i).Item("email"))
        Next
        fp.Close()


        ''get te page

        Dim request As System.Net.HttpWebRequest
        Dim response As System.Net.HttpWebResponse = Nothing
        Dim reader As StreamReader
        Dim result As String


        ' Create the web request   
        request = DirectCast(WebRequest.Create("http://www.twin-diamonds.com/litem.aspx?mode=12"), HttpWebRequest)

        ' Get response   
        response = DirectCast(request.GetResponse(), HttpWebResponse)

        ' Get the response stream into a reader   
        reader = New StreamReader(response.GetResponseStream())

        ' Read the whole contents and return as a string   
        result = reader.ReadToEnd()


        Dim html As String = result.Split("©")(1)

        'Open a file for reading
        Dim FILENAME As String = Web.HttpContext.Current.Server.MapPath("ion-mailing/template.htm")

        'Get a StreamReader class that can be used to read the file
        Dim objStreamReader As StreamReader
        objStreamReader = File.OpenText(FILENAME)

        Dim tamplate_txt As String = objStreamReader.ReadToEnd()

        Dim finel_html As String

        finel_html = tamplate_txt.Split("|")(0) + html + tamplate_txt.Split("|")(1)

        fp = File.CreateText(Web.HttpContext.Current.Server.MapPath("ion-mailing/" + Format(Now.Now, "d-MM-yy-")) + "maillist_bodyfile.html")

        fp.Write(finel_html)

        fp.Close()

        Exit Function

ErrorHandler:
        Me._err_number = Err.Number
        Me._err_description = Err.Description
        Me._err_source = Err.Source
        Return True
    End Function

End Class
