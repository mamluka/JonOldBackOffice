Imports System.Web
Imports System.Web.SessionState
Imports ion_resources

Public Class Global_asax
    Inherits System.Web.HttpApplication


    Public o_Error As New iLogging.skl_error_logging
    Public oError As New cls_error
    Public oSystem_Config As New cls_config()
    Public oUser As New cls_user()
    Public oGarbage As New cls_garbage()
    Public oDefaults As New cls_defaults()
    Public oMessage As New cls_message
    Public oTmpCart As New ion_resources.cls_cart()
    Public oTmpOrder As New ion_resources.cls_order()


#Region " Component Designer Generated Code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Component Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'Required by the Component Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Component Designer
    'It can be modified using the Component Designer.
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        components = New System.ComponentModel.Container()
    End Sub

#End Region

    Sub Application_Start(ByVal sender As Object, ByVal e As EventArgs)
        


    End Sub

    Sub Session_Start(ByVal sender As Object, ByVal e As EventArgs)
        ' Fires when the session is started

        Dim bError As Boolean = False


        oSystem_Config.curdir = HttpContext.Current.Request.PhysicalApplicationPath

        oSystem_Config.read_all()
        Me.oDefaults.read_all(oSystem_Config.picdir)
        Application("config") = oSystem_Config
        Application("defaults") = Me.oDefaults
        Application("sessioncount") = 0

        '--- Set server update
        Dim oTmpServerStats As New ion_resources.cls_serverstats()
        Dim oTmpBroker As New ion_resources.cls_serverstats_lgc()
        oTmpBroker.connection_string = Application("config").connection_logging
        bError = oTmpBroker.getrec(1, oTmpServerStats)

        oTmpServerStats.serverup_back = Date.Now

        bError = oTmpBroker.update(oTmpServerStats)

        oTmpServerStats = Nothing
        oTmpBroker = Nothing

        '--- Reload objects
        Dim o_Error As New iLogging.skl_error_logging
        Dim oError As New cls_error
        Dim oMessage As New cls_message
        Dim oUser As New cls_user
        Dim oDefaults As New cls_defaults



        oUser.session_id = Session.SessionID
        oUser.authenticated = Request.IsAuthenticated
        Session.Timeout = 30

        '###--- Remporary USE
        'oUser.authenticated = True

        If oUser.authenticated Then
            oUser.user_id = 0
            oUser.userlevel = 0
            oUser.user_name = Me.get_name(Request.ServerVariables("AUTH_USER"))

            '-- 9 can all
            '-- 8 can all becides stuff in test
            '-- 5 can inventory, customers, orders
            '-- 4 can inventory, customers
            '-- 3 can inventory, customers, no prices


            '###--- Remporary USE
            'oUser.user_name = "pby"



            Select Case LCase(oUser.user_name)
                Case "lory"
                    oUser.userlevel = 4

                Case "reuven"
                    oUser.userlevel = 4

                Case "camelia"
                    oUser.userlevel = 5

                Case "avi"
                    oUser.userlevel = 8

                Case "peled"
                    oUser.userlevel = 9

                Case "pby"
                    oUser.userlevel = 9

                Case "administrator"
                    oUser.userlevel = 9

                Case Else
                    oUser.userlevel = 0

            End Select


        Else
            'Response.Redirect("http://www.twin-diamonds.com")

            oUser.user_id = 0
            oUser.userlevel = 0
            oUser.user_name = "N/A"

        End If


        '--- Tmporary
        oUser.userlevel = 9


        '---
        Session("user") = oUser
        Session("error") = oError
        Session("o_error") = o_Error
        Session("garbage") = oGarbage
        Session("message") = oMessage

        '--- Count sessions
        Application.Lock()
        Application("sessioncount") = Application("sessioncount") + 1
        Application.UnLock()

        '--- Log incomming customer
        Dim oSlog As New ion_resources.cls_slogging
        oSlog.date_time = Date.Now
        oSlog.sessionid = Session.SessionID
        If Not IsNothing(Request.UrlReferrer) Then
            oSlog.refferer_url = Request.UrlReferrer.AbsoluteUri
        Else
            oSlog.refferer_url = "N/A"
        End If
        oSlog.remote_ip = Request.UserHostAddress
        oSlog.visit_count = 0
        oSlog.last_visit = #1/1/1900#
        oSlog.user_name = oUser.user_name
        oSlog.user_email = "N/A"
        oSlog.user_id = Session("user").user_id
        oSlog.browser_language = Request.UserLanguages(0)
        oSlog.user_agent = Request.UserAgent
        oSlog.campaign = ""

        Dim oTmpFunctionsLogging As New ion_resources.cls_functions_slogging
        oTmpFunctionsLogging.connection_string = Application("config").connection_logging
        bError = oTmpFunctionsLogging.compare_agent(Request.UserAgent, oSlog.spider_id)

        'Dim oTmpBroker2 As New ion_resources.cls_slogging_lgc
        'oTmpBroker2.connection_string = Application("config").connection_logging
        'bError = oTmpBroker.insert(2, oSlog)

        oSlog = Nothing
        oTmpBroker = Nothing
        oTmpFunctionsLogging = Nothing


        '--- Set Session counter
        Dim oTmpServerStats2 As New ion_resources.cls_serverstats
        Dim oTmpBroker22 As New ion_resources.cls_serverstats_lgc
        oTmpBroker22.connection_string = Application("config").connection_logging
        bError = oTmpBroker22.getrec(1, oTmpServerStats)


        oTmpServerStats2.sessions_back = Convert.ToInt32(Application("sessioncount"))

        oTmpServerStats2.sessions_back = 1



        bError = oTmpBroker22.update(oTmpServerStats2)

        oTmpServerStats = Nothing
        oTmpBroker22 = Nothing


        If LCase(Request.ServerVariables("AUTH_USER")) = "iondom\ophir" Then
            Session("message").listbox.items.add("- User rejected !")
            Session("message").returnpath = ""
            Server.Transfer("/message.aspx")

        End If


        Session.Timeout = 30

    End Sub

    Sub Application_BeginRequest(ByVal sender As Object, ByVal e As EventArgs)
        ' Fires at the beginning of each request
    End Sub

    Sub Application_AuthenticateRequest(ByVal sender As Object, ByVal e As EventArgs)
        ' Fires upon attempting to authenticate the use
    End Sub

    Sub Application_Error(ByVal sender As Object, ByVal e As EventArgs)
        ' Fires when an error occurs

        Session("error").err_number = Err.Number
        Session("error").err_description = Err.Description
        Session("error").err_source = Err.Source

        Dim oLogging As New ion_resources.cls_logging()
        oLogging.oerror = Session("error")
        oLogging.config = Application("config")
        oLogging.user = Session("user")
        oLogging.LogError()
        oLogging = Nothing
        Server.Transfer("apperror.aspx")

    End Sub

    Sub Session_End(ByVal sender As Object, ByVal e As EventArgs)
        Dim bError As Boolean = False

        Application.Lock()
        Application("sessioncount") = Application("sessioncount") - 1
        Application.UnLock()

        '--- Set Session counter
        Dim oTmpServerStats As New ion_resources.cls_serverstats()
        Dim oTmpBroker2 As New ion_resources.cls_serverstats_lgc()
        oTmpBroker2.connection_string = Application("config").connection_logging
        bError = oTmpBroker2.getrec(1, oTmpServerStats)

        oTmpServerStats.sessions_back = Convert.ToInt32(Application("sessioncount"))

        bError = oTmpBroker2.update(oTmpServerStats)

        oTmpServerStats = Nothing
        oTmpBroker2 = Nothing

        oUser = Nothing
        oError = Nothing

    End Sub

    Sub Application_End(ByVal sender As Object, ByVal e As EventArgs)
        ' Fires when the application ends



        oSystem_Config = Nothing


    End Sub

    Private Function get_name(ByVal cString As String) As String

        Dim nLoop As Int16
        For nLoop = 1 To Len(cString)
            If cString.Substring(nLoop, 1) = "\" Then
                Return cString.Substring(nLoop + 1)
            End If
        Next


    End Function


End Class
