Imports System.Web.Mail

Public Class cls_simplemail

    Private m_connection_string As String
    Private m_error_number As Int32
    Private m_error_source As String
    Private m_error_description As String

    Private m_mailto As String
    Private m_from As String
    Private m_subject As String
    Private m_content As String
    Private m_contenttype As Integer
    Private m_senderror As Boolean
    Private m_smptserver As String
    Private m_ionversion As String


    Function send() As Boolean
        On Error GoTo ErrorHandler
        Dim bError As Boolean = False

        Dim oMail As New MailMessage()

        If Me.from = "" Then
            oMail.From = "sales@twin-diamonds.com"
        Else
            oMail.From = Me.from
        End If


        oMail.To = Me.mailto.Trim
        oMail.Subject = Me.subject
        oMail.BodyFormat = MailFormat.Html
        oMail.Priority = MailPriority.High
        SmtpMail.SmtpServer = Me.smptserver


        Select Case Me.contenttype
            Case 0     '--- 
                oMail.Body = Me.content

            Case 1     '--- Admin mail
                oMail.Body = Me.content
                bError = admin_footer(oMail.Body)


        End Select


        SmtpMail.Send(oMail)

        Return False
        Exit Function

ErrorHandler:
		'--- when object is called in external DLL
		Me.error_number = Err.Number
		Me.error_source = Err.Source
		Me.error_description = Err.Description
		Return True

    End Function

    '####################################################################################
    Function InventoryItemBelowMinimum222(ByRef cMsg As String) As Boolean
        Dim bError As Boolean = False

        cMsg = cMsg + "<font color='#330066' face='verdana,arial' size='1'>"
        cMsg = cMsg + Me.content
        cMsg = cMsg + "</font>"


        bError = admin_footer(cMsg)

    End Function




    '####################################################################################
    Function admin_footer(ByRef cMsg As String) As Boolean
        cMsg = cMsg + "<br><hr align='left' color='#808080'>"
        cMsg = cMsg + ""
        cMsg = cMsg + "<table cellspacing='0' cellpadding='0' border='0' width='100%'>"
        cMsg = cMsg + "<tr><td>"
        cMsg = cMsg + "<font color='#330066' face='verdana,arial' size='1'>"
        cMsg = cMsg + "Generated:" & System.Convert.ToString(Now)
        cMsg = cMsg + "</font>"
        cMsg = cMsg + "</td>"
        cMsg = cMsg + "<td align='right'>"
        cMsg = cMsg + "<font color='#330066' face='verdana,arial' size='1'>"
        cMsg = cMsg + "Twin-diamonds.com - ion-sg ver. " + Me.ionversion
        cMsg = cMsg + "</font>"
        cMsg = cMsg + "</td></tr>"
        cMsg = cMsg + "</table>"
    End Function



    Public Property connection_string() As String
        Get
            Return m_connection_string
        End Get

        Set(ByVal Value As String)
            m_connection_string = Value
        End Set
    End Property

    Public Property error_number() As Int32
        Get
            Return m_error_number
        End Get

        Set(ByVal Value As Int32)
            m_error_number = Value
        End Set
    End Property

    Public Property error_description() As String
        Get
            Return m_error_description
        End Get

        Set(ByVal Value As String)
            m_error_description = Value
        End Set
    End Property

    Public Property error_source() As String
        Get
            Return m_error_source
        End Get

        Set(ByVal Value As String)
            m_error_source = Value
        End Set
    End Property

    Public Property mailto() As String
        Get
            Return m_mailto
        End Get

        Set(ByVal Value As String)
            m_mailto = Value
        End Set
    End Property

    Public Property from() As String
        Get
            Return m_from
        End Get

        Set(ByVal Value As String)
            m_from = Value
        End Set
    End Property

    Public Property subject() As String
        Get
            Return m_subject
        End Get

        Set(ByVal Value As String)
            m_subject = Value
        End Set
    End Property

    Public Property content() As String
        Get
            Return m_content
        End Get

        Set(ByVal Value As String)
            m_content = Value
        End Set
    End Property

    Public Property contenttype() As Integer
        Get
            Return m_contenttype
        End Get

        Set(ByVal Value As Integer)
            m_contenttype = Value
        End Set
    End Property

    Public Property senderror() As Boolean
        Get
            Return m_senderror
        End Get

        Set(ByVal Value As Boolean)
            m_senderror = Value
        End Set
    End Property

    Public Property smptserver() As String
        Get
            Return m_smptserver
        End Get

        Set(ByVal Value As String)
            m_smptserver = Value
        End Set
    End Property

    Public Property ionversion() As String
        Get
            Return m_ionversion
        End Get

        Set(ByVal Value As String)
            m_ionversion = Value
        End Set
    End Property


End Class
