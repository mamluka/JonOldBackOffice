Public Class cls_checkbook

    Private m_id As Int32
    Private m_description As String
    Private m_paymentdate As DateTime
    Private m_checknumber As Int32
    Private m_account As Int32
    Private m_nameto As String
    Private m_checkdate As DateTime
    Private m_cashed As Boolean
    Private m_amount As Decimal
    Private m_notes As String
    Private m_currency_id As Int32
    Private m_LastModify_Date As DateTime
    Private m_LastModify_User As String
    Private m_LastModify_User_id As Int32
    Private m_checkbook_dataset As DataSet


    Public Property id() As Int32
        Get
            Return m_id
        End Get

        Set(ByVal Value As Int32)
            m_id = Value
        End Set
    End Property

    Public Property description() As String
        Get
            Return m_description
        End Get

        Set(ByVal Value As String)
            m_description = Value
        End Set
    End Property

    Public Property paymentdate() As DateTime
        Get
            Return m_paymentdate
        End Get

        Set(ByVal Value As DateTime)
            m_paymentdate = Value
        End Set
    End Property

    Public Property checknumber() As Int32
        Get
            Return m_checknumber
        End Get

        Set(ByVal Value As Int32)
            m_checknumber = Value
        End Set
    End Property

    Public Property account() As Int32
        Get
            Return m_account
        End Get

        Set(ByVal Value As Int32)
            m_account = Value
        End Set
    End Property

    Public Property nameto() As String
        Get
            Return m_nameto
        End Get

        Set(ByVal Value As String)
            m_nameto = Value
        End Set
    End Property

    Public Property checkdate() As DateTime
        Get
            Return m_checkdate
        End Get

        Set(ByVal Value As DateTime)
            m_checkdate = Value
        End Set
    End Property

    Public Property cashed() As Boolean
        Get
            Return m_cashed
        End Get

        Set(ByVal Value As Boolean)
            m_cashed = Value
        End Set
    End Property

    Public Property amount() As Decimal
        Get
            Return m_amount
        End Get

        Set(ByVal Value As Decimal)
            m_amount = Value
        End Set
    End Property

    Public Property notes() As String
        Get
            Return m_notes
        End Get

        Set(ByVal Value As String)
            m_notes = Value
        End Set
    End Property

    Public Property currency_id() As Int32
        Get
            Return m_currency_id
        End Get

        Set(ByVal Value As Int32)
            m_currency_id = Value
        End Set
    End Property

    Public Property LastModify_Date() As DateTime
        Get
            Return m_LastModify_Date
        End Get

        Set(ByVal Value As DateTime)
            m_LastModify_Date = Value
        End Set
    End Property

    Public Property LastModify_User() As String
        Get
            Return m_LastModify_User
        End Get

        Set(ByVal Value As String)
            m_LastModify_User = Value
        End Set
    End Property

    Public Property LastModify_User_id() As Int32
        Get
            Return m_LastModify_User_id
        End Get

        Set(ByVal Value As Int32)
            m_LastModify_User_id = Value
        End Set
    End Property

    Public Property checkbook_dataset() As DataSet
        Get
            Return m_checkbook_dataset
        End Get

        Set(ByVal Value As DataSet)
            m_checkbook_dataset = Value
        End Set
    End Property

End Class
