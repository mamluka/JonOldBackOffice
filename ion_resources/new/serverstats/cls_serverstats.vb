Public Class cls_serverstats
    Inherits ion_resources.cls_base_entity

    Private m_serverup_site As DateTime
    Private m_sessions_site As Int32
    Private m_serverup_back As DateTime
    Private m_sessions_back As Int32

    Public Property serverup_back() As DateTime
        Get
            Return m_serverup_back
        End Get

        Set(ByVal Value As DateTime)
            m_serverup_back = Value
        End Set
    End Property

    Public Property sessions_back() As Int32
        Get
            Return m_sessions_back
        End Get

        Set(ByVal Value As Int32)
            m_sessions_back = Value
        End Set
    End Property

    Public Property serverup_site() As DateTime
        Get
            Return m_serverup_site
        End Get

        Set(ByVal Value As DateTime)
            m_serverup_site = Value
        End Set
    End Property

    Public Property sessions_site() As Int32
        Get
            Return m_sessions_site
        End Get

        Set(ByVal Value As Int32)
            m_sessions_site = Value
        End Set
    End Property
End Class
