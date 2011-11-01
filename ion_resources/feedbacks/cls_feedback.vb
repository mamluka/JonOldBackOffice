Public Class cls_feedback

    Private m_dataset As DataSet
    Private m_id As Int32
    Private m_user_id As Int32
    Private m_user_name As String
    Private m_user_email As String
    Private m_showemail As Boolean
    Private m_active As Boolean
    Private m_delete As Boolean
    Private m_createdate As DateTime
    Private m_text As String
    Private m_country As String
    Private m_state As String
    Private m_item1_id As Int32
    Private m_item2_id As Int32
    Private m_item3_id As Int32

    Public Property item3_id() As Int32
        Get
            Return m_item3_id
        End Get

        Set(ByVal Value As Int32)
            m_item3_id = Value
        End Set
    End Property

    Public Property item2_id() As Int32
        Get
            Return m_item2_id
        End Get

        Set(ByVal Value As Int32)
            m_item2_id = Value
        End Set
    End Property


    Public Property item1_id() As Int32
        Get
            Return m_item1_id
        End Get

        Set(ByVal Value As Int32)
            m_item1_id = Value
        End Set
    End Property

    Public Property country() As String
        Get
            Return m_country
        End Get

        Set(ByVal Value As String)
            m_country = Value
        End Set
    End Property

    Public Property state() As String
        Get
            Return m_state
        End Get

        Set(ByVal Value As String)
            m_state = Value
        End Set
    End Property

    Public Property text() As String
        Get
            Return m_text
        End Get

        Set(ByVal Value As String)
            m_text = Value
        End Set
    End Property

    Public Property createdate() As DateTime
        Get
            Return m_createdate
        End Get

        Set(ByVal Value As DateTime)
            m_createdate = Value
        End Set
    End Property

    Public Property delete() As Boolean
        Get
            Return m_delete
        End Get

        Set(ByVal Value As Boolean)
            m_delete = Value
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


    Public Property showemail() As Boolean
        Get
            Return m_showemail
        End Get

        Set(ByVal Value As Boolean)
            m_showemail = Value
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

    Public Property user_name() As String
        Get
            Return m_user_name
        End Get

        Set(ByVal Value As String)
            m_user_name = Value
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

    Public Property user_id() As Int32
        Get
            Return m_user_id
        End Get

        Set(ByVal Value As Int32)
            m_user_id = Value
        End Set
    End Property

    Public Property dataset() As dataset
        Get
            Return m_dataset
        End Get

        Set(ByVal Value As dataset)
            m_dataset = Value
        End Set
    End Property



End Class
