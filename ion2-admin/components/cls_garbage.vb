Public Class cls_garbage

    Private m_Branch As Integer
    Private m_Plate As Integer

    Private m_t1 As String
    Private m_t2 As String
    Private m_t3 As String
    Private m_t4 As String
    Private m_t5 As String

    Private m_n1 As Integer
    Private m_n2 As Integer
    Private m_n3 As Integer
    Private m_n4 As Integer
    Private m_n5 As Integer


    Public Sub clearall()

        Me.Branch = 0
        Me.Plate = 0
        Me.t1 = ""
        Me.t2 = ""
        Me.t3 = ""
        Me.t4 = ""
        Me.t5 = ""
        Me.n1 = 0
        Me.n2 = 0
        Me.n3 = 0
        Me.n4 = 0
        Me.n5 = 0

    End Sub



    Public Property Branch() As Integer
        Get
            Return m_Branch
        End Get

        Set(ByVal Value As Integer)
            m_Branch = Value
        End Set
    End Property
    Public Property Plate() As Integer
        Get
            Return m_Plate
        End Get

        Set(ByVal Value As Integer)
            m_Plate = Value
        End Set
    End Property

    Public Property t1() As String
        Get
            Return m_t1
        End Get

        Set(ByVal Value As String)
            m_t1 = Value
        End Set
    End Property

    Public Property t2() As String
        Get
            Return m_t2
        End Get

        Set(ByVal Value As String)
            m_t2 = Value
        End Set
    End Property
    Public Property t3() As String
        Get
            Return m_t3
        End Get

        Set(ByVal Value As String)
            m_t3 = Value
        End Set
    End Property
    Public Property t4() As String
        Get
            Return m_t4
        End Get

        Set(ByVal Value As String)
            m_t4 = Value
        End Set
    End Property
    Public Property t5() As String
        Get
            Return m_t5
        End Get

        Set(ByVal Value As String)
            m_t5 = Value
        End Set
    End Property

    Public Property n1() As Integer
        Get
            Return m_n1
        End Get

        Set(ByVal Value As Integer)
            m_n1 = Value
        End Set
    End Property

    Public Property n2() As Integer
        Get
            Return m_n2
        End Get

        Set(ByVal Value As Integer)
            m_n2 = Value
        End Set
    End Property
    Public Property n3() As Integer
        Get
            Return m_n3
        End Get

        Set(ByVal Value As Integer)
            m_n3 = Value
        End Set
    End Property
    Public Property n4() As Integer
        Get
            Return m_n4
        End Get

        Set(ByVal Value As Integer)
            m_n4 = Value
        End Set
    End Property
    Public Property n5() As Integer
        Get
            Return m_n5
        End Get

        Set(ByVal Value As Integer)
            m_n5 = Value
        End Set
    End Property



End Class
