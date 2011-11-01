Imports System.Data.SqlClient

Public Class cls_logging

    Private m_config As Object
    Private m_oerror As Object
    Private m_user As Object
    Private m_mode As Int16
    Private m_id As Int64

    Public oConnection As SqlConnection

    Public Function LogError() As Boolean
        On Error GoTo ErrorHandler

        '--- set mode to 1=Site
        If Me.mode = 0 Then
            Me.mode = 1
        End If

        '--- local definitions
        Dim bError As Boolean = False
        Dim oDataset As ds_log_ERRORLOG = New ds_log_ERRORLOG()
        Dim cDBfileName As String

        If Me.mode = 1 Then
            cDBfileName = "log_ERRORLOG_Site"
        ElseIf Me.mode = 2 Then
            cDBfileName = "log_ERRORLOG_Back"
        End If

        Dim oDataTable As DataTable = oDataset.Tables(cDBfileName)
        Dim oDataRow As DataRow
        Dim nLoop As Integer

        oDataRow = oDataTable.NewRow()
        oDataRow("date_time") = Now
        oDataRow("session_id") = Me.user.session_id
        oDataRow("user_name") = IIf(Me.user.user_name = "", "N/A", Me.user.user_name)
        oDataRow("user_id") = Me.user.user_id
        oDataRow("error_no") = Me.oerror.err_number
        oDataRow("error_description") = Me.oerror.err_description
        oDataRow("error_source") = Me.oerror.err_source
        oDataRow("app_module") = Me.oerror.app_module
        oDataRow("app_call") = Me.oerror.app_call
        oDataRow("app_function") = Me.oerror.app_function
        oDataRow("note") = Me.oerror.note

        '--- add row to table
        oDataTable.Rows.Add(oDataRow)

        '--- Create connection
        Dim oConnection As SqlClient.SqlConnection = New SqlClient.SqlConnection(Me.config.connection_logging)

        '--- Define DataAdapter 1 - 
        Dim oDataAdapter As SqlClient.SqlDataAdapter = New SqlClient.SqlDataAdapter()
        oDataAdapter.TableMappings.Add("table", "log_ERRORLOG_Back")
        oDataAdapter.SelectCommand = New SqlClient.SqlCommand("select * from " + cDBfileName + " where 0=1", oConnection)
        Dim oCB_mp As SqlClient.SqlCommandBuilder = New SqlClient.SqlCommandBuilder(oDataAdapter)

        oConnection.Open()

        AddHandler oDataAdapter.RowUpdated, New SqlRowUpdatedEventHandler(AddressOf OnRowUpdated)

        '**** Update ****************************
        oDataAdapter.Update(oDataset, cDBfileName)

        RemoveHandler oDataAdapter.RowUpdated, New SqlRowUpdatedEventHandler(AddressOf OnRowUpdated)

        '--- Clear all pending updates
        oDataTable.AcceptChanges()

        '--- Release objects
        oDataAdapter = Nothing
        oDataTable = Nothing
        oCB_mp = Nothing

        '--- Release connection object
        oConnection.Close()
        oConnection = Nothing

        '--- Send Email
        bError = Me.createmail


        Return False
        Exit Function

ErrorHandler:

        Return True

    End Function


    Sub OnRowUpdated(ByVal sender As Object, ByVal args As SqlRowUpdatedEventArgs)
        ' Include a variable and a command to retrieve the identity value from the Access database.
        Dim newID As Integer = 0
        Dim idCMD As SqlCommand = New SqlCommand("SELECT @@IDENTITY", sender.selectcommand.connection)

        If args.StatementType = StatementType.Insert Then
            'idCMD.Transaction = oTransaction
            Me.id = CInt(idCMD.ExecuteScalar())

        End If
    End Sub

    Private Function createmail() As Boolean

        Dim cEmail As String
        cEmail = cEmail + "<TABLE ID=tbl_border STYLE='BORDER-RIGHT: 1px groove; BORDER-TOP: 1px groove; BORDER-LEFT: 1px groove; BORDER-BOTTOM: 1px groove; background-color: Linen' CELLSPACING=0 CELLPADDING=1 WIDTH='100%' BORDER=0>"
        cEmail = cEmail + "<tr><td width='100'><font color=MidnightBlue face=verdana,arial size=1>No#</font></td>"
        cEmail = cEmail + "    <td><font color=MidnightBlue face=verdana,arial size=1><b>" + System.Convert.ToString(Me.id).PadLeft(10) + "</b></font></td></tr>"
        cEmail = cEmail + "<tr><td width='100'><font color=MidnightBlue face=verdana,arial size=1>Time</font></td>"
        cEmail = cEmail + "    <td><font color=MidnightBlue face=verdana,arial size=1><b>" + System.Convert.ToString(Now) + "</b></font></td></tr>"
        cEmail = cEmail + "<tr><td width='100'><font color=MidnightBlue face=verdana,arial size=1>Session id</font></td>"
        cEmail = cEmail + "    <td><font color=MidnightBlue face=verdana,arial size=1><b>" + System.Convert.ToString(Me.user.session_id) + "</b></font></td></tr>"
        cEmail = cEmail + "<tr><td width='100'><font color=MidnightBlue face=verdana,arial size=1>User name</font></td>"
        cEmail = cEmail + "	<td><font color=MidnightBlue face=verdana,arial size=1><b>" + IIf(Me.user.user_name = "", "N/A", Me.user.user_name) + "</b></font></td></tr>"
        cEmail = cEmail + "<tr><td width='100'><font color=MidnightBlue face=verdana,arial size=1>User id</font></td>"
        cEmail = cEmail + "	<td><font color=MidnightBlue face=verdana,arial size=1><b>" + System.Convert.ToString(Me.user.user_id).PadLeft(10) + "</b></font></td></tr>"
        cEmail = cEmail + "<tr><td width='100'><font color=MidnightBlue face=verdana,arial size=1>Error Number</font></td>"
        cEmail = cEmail + "	<td><font color=MidnightBlue face=verdana,arial size=1><b>" + System.Convert.ToString(Me.oerror.err_number).PadLeft(10) + "</b></font></td></tr>"
        cEmail = cEmail + "<tr><td width='100'><font color=MidnightBlue face=verdana,arial size=1>Error description</font></td>"
        cEmail = cEmail + "	<td><font color=MidnightBlue face=verdana,arial size=1><b>" + System.Convert.ToString(Me.oerror.err_description) + "</b></font></td></tr>"
        cEmail = cEmail + "<tr><td width='100'><font color=MidnightBlue face=verdana,arial size=1>Error source</font></td>"
        cEmail = cEmail + "	<td><font color=MidnightBlue face=verdana,arial size=1><b>" + System.Convert.ToString(Me.oerror.err_source) + "</b></font></td></tr>"
        cEmail = cEmail + "<tr><td width='100'><font color=MidnightBlue face=verdana,arial size=1>Module</font></td>"
        cEmail = cEmail + "	<td><font color=MidnightBlue face=verdana,arial size=1><b>" + System.Convert.ToString(Me.oerror.app_module) + " </b></font></td></tr>"
        cEmail = cEmail + "<tr><td width='100'><font color=MidnightBlue face=verdana,arial size=1>App. call</font></td>"
        cEmail = cEmail + " <td><font color=MidnightBlue face=verdana,arial size=1><b>" + System.Convert.ToString(Me.oerror.app_call) + "</b></font></td></tr>"
        cEmail = cEmail + "<tr><td width='100'><font color=MidnightBlue face=verdana,arial size=1>App. function</font></td>"
        cEmail = cEmail + "	<td><font color=MidnightBlue face=verdana,arial size=1><b>" + System.Convert.ToString(Me.oerror.app_function) + "</b></font></td></tr>"
        cEmail = cEmail + "<tr><td width='100'><font color=MidnightBlue face=verdana,arial size=1>Note</font></td>"
        cEmail = cEmail + "	<td><font color=MidnightBlue face=verdana,arial size=1><b>" + System.Convert.ToString(Me.oerror.note) + "</b></font></td></tr>"
        cEmail = cEmail + "</table>"

        Dim oMail As New ion_resources.cls_simplemail()
        If Me.mode = 1 Then
            oMail.subject = System.Convert.ToString(Me.id) + " - Bug report <web-site>  TWIN"
        ElseIf Me.mode = 2 Then
            oMail.subject = System.Convert.ToString(Me.id) + " - Bug report <back-office TWIN>"
        End If
        oMail.mailto = "tech-support@ion-integrations.com"
        If Me.user.email() <> "" Then
            oMail.from = Me.user.email
        Else
            oMail.from = "newsite@ion-integrations.com"
        End If
        oMail.content = cEmail
        oMail.contenttype = 1
        oMail.ionversion = Me.config.ion_version
        oMail.send()

    End Function



    Public Property config() As Object
        Get
            Return m_config
        End Get

        Set(ByVal Value As Object)
            m_config = Value
        End Set
    End Property


    Public Property oerror() As Object
        Get
            Return m_oerror
        End Get

        Set(ByVal Value As Object)
            m_oerror = Value
        End Set
    End Property

    Public Property user() As Object
        Get
            Return m_user
        End Get

        Set(ByVal Value As Object)
            m_user = Value
        End Set
    End Property

    Public Property mode() As Int16
        Get
            Return m_mode
        End Get

        Set(ByVal Value As Int16)
            m_mode = Value
        End Set
    End Property

    Public Property id() As Int64
        Get
            Return m_id
        End Get

        Set(ByVal Value As Int64)
            m_id = Value
        End Set
    End Property


End Class
