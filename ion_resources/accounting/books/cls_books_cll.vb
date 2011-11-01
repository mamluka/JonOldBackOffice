Public Class cls_books_cll

    Private m_general As New Collection()
    Private m_suppliers As New Collection()


    Public Property general() As Collection
        Get
            Return m_general
        End Get

        Set(ByVal Value As Collection)
            m_general = Value
        End Set
    End Property

    Public Property suppliers() As Collection
        Get
            Return m_suppliers
        End Get

        Set(ByVal Value As Collection)
            m_suppliers = Value
        End Set
    End Property

End Class
