Public Class cls_slogging

    Private m_id As Int32
    Private m_sessionid As String
    Private m_date_time As DateTime
    Private m_refferer_url As String
    Private m_browser_language As String
    Private m_user_id As Int32
    Private m_user_name As String
    Private m_user_email As String
    Private m_last_visit As DateTime
    Private m_visit_count As Int32
    Private m_remote_ip As String
    Private m_campaign As String
    Private m_user_agent As String
    Private m_spider_id As Int32

    Sub New()
        Me.browser_language = ""
        Me.campaign = ""
        Me.date_time = #1/1/1900#
        Me.id = 0
        Me.last_visit = #1/1/1900#
        Me.refferer_url = ""
        Me.remote_ip = ""
        Me.sessionid = ""
        Me.spider_id = 0
        Me.user_agent = ""
        Me.user_email = ""
        Me.user_id = 0
        Me.user_name = ""
        Me.visit_count = 0
    End Sub

    Public Property spider_id() As Int32
        Get
            Return m_spider_id
        End Get

        Set(ByVal Value As Int32)
            m_spider_id = Value
        End Set
    End Property

    Public Property user_agent() As String
        Get
            Return m_user_agent
        End Get

        Set(ByVal Value As String)
            m_user_agent = Value
        End Set
    End Property

    Public Property campaign() As String
        Get
            Return m_campaign
        End Get

        Set(ByVal Value As String)
            m_campaign = Value
        End Set
    End Property

    Public Property sessionid() As String
        Get
            Return m_sessionid
        End Get

        Set(ByVal Value As String)
            m_sessionid = Value
        End Set
    End Property

    Public Property date_time() As DateTime
        Get
            Return m_date_time
        End Get

        Set(ByVal Value As DateTime)
            m_date_time = Value
        End Set
    End Property

    Public Property refferer_url() As String
        Get
            Return m_refferer_url
        End Get

        Set(ByVal Value As String)
            m_refferer_url = Value
        End Set
    End Property

    Public Property browser_language() As String
        Get
            Return m_browser_language
        End Get

        Set(ByVal Value As String)
            m_browser_language = Value
        End Set
    End Property

    Public Property user_id() As Int32
        Get
            Return m_user_id
        End Get

        Set(ByVal Value As Int32)
            m_user_id = Value
        End Set
    End Property

    Public Property user_name() As String
        Get
            Return m_user_name
        End Get

        Set(ByVal Value As String)
            m_user_name = Value
        End Set
    End Property

    Public Property user_email() As String
        Get
            Return m_user_email
        End Get

        Set(ByVal Value As String)
            m_user_email = Value
        End Set
    End Property

    Public Property last_visit() As DateTime
        Get
            Return m_last_visit
        End Get

        Set(ByVal Value As DateTime)
            m_last_visit = Value
        End Set
    End Property

    Public Property visit_count() As Int32
        Get
            Return m_visit_count
        End Get

        Set(ByVal Value As Int32)
            m_visit_count = Value
        End Set
    End Property


    Public Property remote_ip() As String
        Get
            Return m_remote_ip
        End Get

        Set(ByVal Value As String)
            m_remote_ip = Value
        End Set
    End Property


    Public Property id() As Int32
        Get
            Return m_id
        End Get

        Set(ByVal Value As Int32)
            m_id = Value
        End Set
    End Property




End Class
