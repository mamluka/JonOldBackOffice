Public Class cls_help
    Inherits ion_resources.cls_base_entity


    Private m_keyword As String
    Private m_help_header As String
    Private m_text As String


    Public Property keyword() As String
        Get
            Return m_keyword
        End Get

        Set(ByVal Value As String)
            m_keyword = Value
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

    Public Property help_header() As String
        Get
            Return m_help_header
        End Get

        Set(ByVal Value As String)
            m_help_header = Value
        End Set
    End Property






End Class
