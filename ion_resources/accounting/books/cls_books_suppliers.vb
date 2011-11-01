Public Class cls_books_suppliers

    Private m_trs_id As Int32
    Private m_order_id As Int32
    Private m_item_id As Int32
    Private m_item_qty As Int16
    Private m_supplier_id2 As Int32
    Private m_trs_date As DateTime
    Private m_description As String
    Private m_rate_ils As Decimal
    Private m_amount As Decimal
    Private m_lastmodify_date As DateTime
    Private m_lastmodify_user As String
    Private m_lastmodify_user_id As Int32


    Public Property trs_id() As Int32
        Get
            Return m_trs_id
        End Get

        Set(ByVal Value As Int32)
            m_trs_id = Value
        End Set
    End Property

    Public Property order_id() As Int32
        Get
            Return m_order_id
        End Get

        Set(ByVal Value As Int32)
            m_order_id = Value
        End Set
    End Property

    Public Property item_id() As Int32
        Get
            Return m_item_id
        End Get

        Set(ByVal Value As Int32)
            m_item_id = Value
        End Set
    End Property

    Public Property item_qty() As Int16
        Get
            Return m_item_qty
        End Get

        Set(ByVal Value As Int16)
            m_item_qty = Value
        End Set
    End Property

    Public Property supplier_id2() As Int32
        Get
            Return m_supplier_id2
        End Get

        Set(ByVal Value As Int32)
            m_supplier_id2 = Value
        End Set
    End Property

    Public Property trs_date() As DateTime
        Get
            Return m_trs_date
        End Get

        Set(ByVal Value As DateTime)
            m_trs_date = Value
        End Set
    End Property

    Public Property rate_ils() As Decimal
        Get
            Return m_rate_ils
        End Get

        Set(ByVal Value As Decimal)
            m_rate_ils = Value
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

    Public Property lastmodify_date() As DateTime
        Get
            Return m_lastmodify_date
        End Get

        Set(ByVal Value As DateTime)
            m_lastmodify_date = Value
        End Set
    End Property

    Public Property lastmodify_user_id() As Int32
        Get
            Return m_lastmodify_user_id
        End Get

        Set(ByVal Value As Int32)
            m_lastmodify_user_id = Value
        End Set
    End Property

    Public Property lastmodify_user() As String
        Get
            Return m_lastmodify_user
        End Get

        Set(ByVal Value As String)
            m_lastmodify_user = Value
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

End Class
