Public Class cls_base_general
    Private m_error_no As Integer
    Private m_error_desc As String
    Private m_error_source As String
    Private m_connection_string As String


    Public Property error_no() As Int32
        Get
            Return m_error_no
        End Get

        Set(ByVal Value As Int32)
            m_error_no = Value
        End Set
    End Property

    Public Property error_desc() As String
        Get
            Return m_error_desc
        End Get

        Set(ByVal Value As String)
            m_error_desc = Value
        End Set
    End Property


    Public Property error_source() As String
        Get
            Return m_error_source
        End Get

        Set(ByVal Value As String)
            m_error_source = Value
        End Set
    End Property


    Public Property connection_string() As String
        Get
            Return m_connection_string
        End Get

        Set(ByVal Value As String)
            m_connection_string = Value
        End Set
    End Property


End Class
