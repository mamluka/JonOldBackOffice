Public Class cls_category
    Private m_category_name As String
    Private m_direct_path As String
    Private m_relative_path As String
    Private m_category_id As Integer

    Public Property category_name() As String
        Get
            Return m_category_name
        End Get

        Set(ByVal Value As String)
            m_category_name = Value
        End Set
    End Property

    Public Property direct_path() As String
        Get
            Return m_direct_path
        End Get

        Set(ByVal Value As String)
            m_direct_path = Value
        End Set
    End Property

    Public Property relative_path() As String
        Get
            Return m_relative_path
        End Get

        Set(ByVal Value As String)
            m_relative_path = Value
        End Set
    End Property

    Public Property category_id() As Integer
        Get
            Return m_category_id
        End Get

        Set(ByVal Value As Integer)
            m_category_id = Value
        End Set
    End Property

End Class
