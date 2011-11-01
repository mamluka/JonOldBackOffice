Imports System.Web.Mail
Imports System.Web
Imports System.IO
Imports System.Net

Public Class cls_mod_mail
    Inherits iFoundation.cls_error_connection
    Public mail_to As String
    Public mail_from As String
    Public subject As String

    Public smptserver As String

    Public debug As String
    Public current_user_mail As String = "none" '' when init gets the user from the sattion 
    Sub New()
        Me.get_current_user_email()
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

        omail.To = "sales@twin-diamonds.com"
        omail.Bcc = "avi@twin-diamonds.com;mamluka_xomix@hotmail.com"
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
        omail.Bcc = "avi@twin-diamonds.com;mamluka_xomix@hotmail.com"
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

    End Function
    Public Function get_current_user_email()

        If HttpContext.Current.Session("user")._authenticated Then
            Me.current_user_mail = HttpContext.Current.Request.Cookies("twin").Item("mail")
        Else
            Me.current_user_mail = "none"

        End If
    End Function
    Public Function remake_links(ByRef bmsg As String)
        bmsg = bmsg.Replace(Chr(34) + "/pic", Chr(34) + HttpContext.Current.Session("user")._domain + "/pic")
    End Function
End Class
