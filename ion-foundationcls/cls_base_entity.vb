Public Class cls_base_entity

    Private m_id As Int32
    Private m_dataset As DataSet
    Private m_date_created As DateTime
    Private m_user_created As String
    Private m_date_modified As DateTime
    Private m_user_modified As String
    Private m_deleted As Boolean
    Private m_active As Boolean
    Private m_ip As String

    Sub New()
        Me.date_modified = Date.Today

    End Sub

    Public Property dataset() As dataset
        Get
            Return m_dataset
        End Get

        Set(ByVal Value As dataset)
            m_dataset = Value
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

    Public Property date_created() As DateTime
        Get
            Return m_date_created
        End Get

        Set(ByVal Value As DateTime)
            m_date_created = Value
        End Set
    End Property

    Public Property user_created() As String
        Get
            Return m_user_created
        End Get

        Set(ByVal Value As String)
            m_user_created = Value
        End Set
    End Property

    Public Property date_modified() As DateTime
        Get
            Return m_date_modified
        End Get

        Set(ByVal Value As DateTime)
            m_date_modified = Value
        End Set
    End Property

    Public Property user_modified() As String
        Get
            Return m_user_modified
        End Get

        Set(ByVal Value As String)
            m_user_modified = Value
        End Set
    End Property

    Public Property deleted() As Boolean
        Get
            Return m_deleted
        End Get

        Set(ByVal Value As Boolean)
            m_deleted = Value
        End Set
    End Property

    Public Property active() As Boolean
        Get
            Return m_active
        End Get

        Set(ByVal Value As Boolean)
            m_active = Value
        End Set
    End Property

    Public Property ip() As String
        Get
            Return m_ip
        End Get

        Set(ByVal Value As String)
            m_ip = Value
        End Set
    End Property

End Class
