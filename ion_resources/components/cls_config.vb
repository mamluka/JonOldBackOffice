Imports filesystem = Microsoft.VisualBasic.FileSystem

Public Class cls_config

    Private m_connection_string As String
	Private m_connection_string_type As String
	Private m_connection_logging As String
    Private m_connection_mainlog As String
	Private m_domain As String
	Public masterdomain As String
    Private m_smtpserver As String
    Private m_ion_version As String
    Private m_mail_webadmin As String
    Private m_mail_accountants As String
    Private m_mail_shipping As String
    Private m_mail_ionadmin As String
    Private m_mail_sales As String
    Private m_debug As Boolean
    Private m_curdir As String
    Private m_picdir As String
	Private m_serverup As DateTime
	Public _debug As Boolean


    Public Function read_all() As Boolean
        Dim bError As Boolean = False

        Me.serverup = Today.Now
		Me.ion_version = "1.0.1"
        Me.mail_accountants = "ion-accountants@twin-diamonds.com"
        Me.mail_shipping = "ion-webadmins@twin-diamonds.com"
        Me.mail_webadmin = "ion-shipping@twin-diamonds.com"
        Me.mail_ionadmin = "ion-admin@twin-diamonds.com"
        Me.mail_sales = "ion-sales@twin-diamonds.com"
        Me.debug = True

        '--- Read config file
        Dim oTmpReadConfig As New ion_resources.cls_readconfig()
        bError = oTmpReadConfig.getconfig(Me.curdir)

		Me.connection_string = oTmpReadConfig.connection_string
		Me.connection_string_type = oTmpReadConfig.connection_string_type
        Me.connection_logging = oTmpReadConfig.connection_logging
        Me.connection_mainlog = oTmpReadConfig.connection_mainlog
		Me.domain = oTmpReadConfig.domain
		Me.masterdomain = oTmpReadConfig.masterdomain
        Me.smtpserver = oTmpReadConfig.smtpserver
        Me.debug = oTmpReadConfig.debug
        Me.picdir = oTmpReadConfig.picdir

		'--- For compatibility
		Me._debug = Me.debug


        oTmpReadConfig = Nothing

    End Function

    Public Property serverup() As DateTime
        Get
            Return m_serverup
        End Get

        Set(ByVal Value As DateTime)
            m_serverup = Value
        End Set
    End Property

    Public Property connection_mainlog() As String
        Get
            Return m_connection_mainlog
        End Get

        Set(ByVal Value As String)
            m_connection_mainlog = Value
        End Set
    End Property

    Public Property connection_logging() As String
        Get
            Return m_connection_logging
        End Get

        Set(ByVal Value As String)
            m_connection_logging = Value
        End Set
    End Property

    Public Property connection_string() As String
        Get
            Return m_connection_string
        End Get

        Set(ByVal Value As String)
            m_connection_string = Value
        End Set
    End Property

	Public Property connection_string_type() As String
		Get
			Return m_connection_string_type
		End Get

		Set(ByVal Value As String)
			m_connection_string_type = Value
		End Set
	End Property

	Public Property domain() As String
		Get
			Return m_domain
		End Get

		Set(ByVal Value As String)
			m_domain = Value
		End Set
	End Property

	Public Property smtpserver() As String
		Get
			Return m_smtpserver
		End Get

		Set(ByVal Value As String)
			m_smtpserver = Value
		End Set
	End Property

	Public Property ion_version() As String
		Get
			Return m_ion_version
		End Get

		Set(ByVal Value As String)
			m_ion_version = Value
		End Set
	End Property

	Public Property mail_webadmin() As String
		Get
			Return m_mail_webadmin
		End Get

		Set(ByVal Value As String)
			m_mail_webadmin = Value
		End Set
	End Property

	Public Property mail_accountants() As String
		Get
			Return m_mail_accountants
		End Get

		Set(ByVal Value As String)
			m_mail_accountants = Value
		End Set
	End Property

	Public Property mail_shipping() As String
		Get
			Return m_mail_shipping
		End Get

		Set(ByVal Value As String)
			m_mail_shipping = Value
		End Set
	End Property

	Public Property mail_ionadmin() As String
		Get
			Return m_mail_ionadmin
		End Get

		Set(ByVal Value As String)
			m_mail_ionadmin = Value
		End Set
	End Property

	Public Property mail_sales() As String
		Get
			Return m_mail_sales
		End Get

		Set(ByVal Value As String)
			m_mail_sales = Value
		End Set
	End Property

	Public Property debug() As Boolean
		Get
			Return m_debug
		End Get

		Set(ByVal Value As Boolean)
			m_debug = Value
		End Set
	End Property

	Public Property curdir() As String
		Get
			Return m_curdir
		End Get

		Set(ByVal Value As String)
			m_curdir = Value
		End Set
	End Property

	Public Property picdir() As String
		Get
			Return m_picdir
		End Get

		Set(ByVal Value As String)
			m_picdir = Value
		End Set
	End Property

End Class
