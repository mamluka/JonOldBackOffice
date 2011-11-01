Public Class cls_agents

    Private m_id As Int32
    Private m_sessionid As String
    Private m_date_time As DateTime
    Private m_refferer As String
    Private m_lang As String
    Private m_user_agent As String
    Private m_remote_ip As String
    Private m_remote_browser As String
    Private m_remote_name As String
    Private m_spider_id As Int32

    Public Property spider_id() As Int32
        Get
            Return m_spider_id
        End Get

        Set(ByVal Value As Int32)
            m_spider_id = Value
        End Set
    End Property

    Public Property remote_browser() As String
        Get
            Return m_remote_browser
        End Get

        Set(ByVal Value As String)
            m_remote_browser = Value
        End Set
    End Property

    Public Property remote_name() As String
        Get
            Return m_remote_name
        End Get

        Set(ByVal Value As String)
            m_remote_name = Value
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

    Public Property refferer() As String
        Get
            Return m_refferer
        End Get

        Set(ByVal Value As String)
            m_refferer = Value
        End Set
    End Property

    Public Property lang() As String
        Get
            Return m_lang
        End Get

        Set(ByVal Value As String)
            m_lang = Value
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
