Imports System.Web.Mail
Imports System.Web
Imports System.IO
Imports System.Net
Imports System.Text.RegularExpressions


Public Class cls_mod_mail
    Inherits iFoundation.cls_error_connection
    Public mail_to As String
    Public mail_from As String
    Public subject As String

    Public smptserver As String

    Public debug As String
    Public current_user_mail As String = "none" '' when init gets the user from the sattion 
    Public conn_string As String
    Public db_type As Int32
    Sub New()
        ''  Me.get_current_user_email()
    End Sub

    Public Function send_to_sales(ByVal bMsg As String) As Boolean
        On Error GoTo ErrorHandler

        '--- local definitions
        Dim bError As Boolean = False

        Dim omail As New MailMessage

        '' Me.get_current_user_email()

        ''  If Me.current_user_mail = "none" Then '' if no user email then use the param if no override param
        omail.From = Me.mail_from
        ''  Else
        ''       omail.From = Me.current_user_mail
        ''End If

        omail.Subject = Me.subject

        omail.To = "avi@twin-diamonds.com"
        omail.Bcc = "mamluka_xomix@hotmail.com;robi@twin-diamonds.com"
        omail.BodyFormat = MailFormat.Html

        omail.BodyFormat = MailFormat.Html
        omail.Priority = MailPriority.High

        SmtpMail.SmtpServer = "127.0.0.1" ''HttpContext.Current.Application("config")._mail._smtpserver()

        omail.Body = bMsg

        ''   Me.debug = "<!-- " + omail.From + " - " + omail.To + " - " + HttpContext.Current.Application("config")._mail._smtpserver() + "-" + omail.Subject + "-->"
        SmtpMail.Send(omail)

        Return False

ErrorHandler:
        Me._err_number = Err.Number
        Me._err_description = Err.Description
        Me._err_source = Err.Source
        Return True

    End Function
    ''inits the current user email when created
    Public Function send(ByVal bMsg As String) As Boolean
        On Error GoTo ErrorHandler

        '--- local definitions
        Dim bError As Boolean = False

        Dim omail As New MailMessage

        '' Me.get_current_user_email()

        ''  If Me.current_user_mail = "none" Then '' if no user email then use the param if no override param
        omail.From = Me.mail_from
        ''  Else
        ''       omail.From = Me.current_user_mail
        ''End If

        omail.Subject = Me.subject



        omail.To = Me.mail_to
        omail.Bcc = "avi@twin-diamonds.com;mamluka_xomix@hotmail.com;followup@twin-diamonds.com;robi@twin-diamonds.com"
        omail.BodyFormat = MailFormat.Html

        SmtpMail.SmtpServer = "127.0.0.1" ''   SmtpMail.SmtpServer = HttpContext.Current.Application("config")._mail._smtpserver()

        omail.Body = bMsg

        SmtpMail.Send(omail)

        Return False

ErrorHandler:
        Me._err_number = Err.Number
        Me._err_description = Err.Description
        Me._err_source = Err.Source
        Return True

    End Function
    Public Function send_direct(ByVal bMsg As String) As Boolean
        On Error GoTo ErrorHandler

        '--- local definitions
        Dim bError As Boolean = False

        Dim omail As New MailMessage

        '' Me.get_current_user_email()

        ''  If Me.current_user_mail = "none" Then '' if no user email then use the param if no override param
        omail.From = Me.mail_from
        ''  Else
        ''       omail.From = Me.current_user_mail
        ''End If

        omail.Subject = Me.subject

        omail.To = Me.mail_to
        ''    omail.Bcc = "avi@twin-diamonds.com;mamluka_xomix@hotmail.com"
        omail.BodyFormat = MailFormat.Html

        SmtpMail.SmtpServer = "127.0.0.1" '''  SmtpMail.SmtpServer = HttpContext.Current.Application("config")._mail._smtpserver()

        omail.Body = bMsg

        SmtpMail.Send(omail)

        Return False

ErrorHandler:
        Me._err_number = Err.Number
        Me._err_description = Err.Description
        Me._err_source = Err.Source
        Return True

    End Function
    Function getHTML_byURL(ByVal url As String, ByRef cbody As String)




        Dim request2 As System.Net.HttpWebRequest
        Dim response2 As System.Net.HttpWebResponse = Nothing
        Dim reader As StreamReader



        request2 = DirectCast(WebRequest.Create(url), HttpWebRequest)

        ' Get response   

        response2 = DirectCast(request2.GetResponse(), System.Net.HttpWebResponse)

        ' Get the response stream into a reader
        reader = New StreamReader(response2.GetResponseStream())

        ' Read the whole contents and return as a string   
        cbody = reader.ReadToEnd()
        ''clear view state
        Regex.Replace(cbody, "<input.+?name='__VIEWSTATE'.+?>", "")

        Me.remake_links(cbody)

        ''me.remake_links(cbody)

    End Function
    Public Function get_current_user_email()

        If HttpContext.Current.Session("user")._authenticated Then
            Me.current_user_mail = HttpContext.Current.Request.Cookies("twin").Item("mail")
        Else
            Me.current_user_mail = "none"

        End If
    End Function

    Public Function ReplaceLitaralsInBody(ByVal hash As Hashtable, ByRef body As String)

        For Each key As String In hash.Keys

            body = body.Replace("!~" + key + "~!", hash(key))

        Next
    End Function

    Public Function remake_links(ByRef bmsg As String)
        '' If Not Nothing(HttpContext.Current.Session("user")) Then
        '' bmsg = bmsg.Replace("src=" + Chr(34) + "/pic", "src=" + Chr(34) + HttpContext.Current.Session("user")._domain + "/pic")
        ''  Else
        bmsg = bmsg.Replace("src=" + Chr(34) + "/pic", "src=" + Chr(34) + "http://www.twin-diamonds.com" + "/pic")

        ''   End If
    End Function
    Public Function SaveEmail(ByVal email As String, ByVal type As Int32, Optional ByVal itemid As Int32 = 0, Optional ByVal url As String = "")

        Dim osql As New iDac.cls_T_command
        osql._dbtype = Me.db_type
        osql._connection_string = Me.conn_string

        ''   Me.Label3.Text = "update sys_groups set group_items = '" + Join(tmparray.ToArray, "|") + "' where group_key = '" + Me.lst_group.SelectedValue + "'"
        osql._sqlstring = "insert into acc_mail_list values('" + email + "'," + type.ToString + "," + itemid.ToString + ",'" + url + "')"
        osql.transact_command()


    End Function


End Class
