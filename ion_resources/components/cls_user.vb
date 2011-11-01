Imports System.Web
Public Class cls_user

    Private m_session_id As String
    Private m_session_start As DateTime
    Private m_user_id As Integer
    Private m_user_name As String
    Private m_authenticated As Boolean
	Private m_language As Integer
	Private m_userlevel As Int16
    Public _pictures As New ion_two.cls_pictures
    Public _currencyID = "USD"


    Public Function read_all() As Boolean

        Me.session_start = Now

    End Function

    Public Property session_id() As String
        Get
            Return m_session_id
        End Get

        Set(ByVal Value As String)
            m_session_id = Value
        End Set
    End Property

    Public Property session_start() As DateTime
        Get
            Return m_session_start
        End Get

        Set(ByVal Value As DateTime)
            m_session_start = Value
        End Set
    End Property

    Public Property user_id() As Integer
        Get
            Return m_user_id
        End Get

        Set(ByVal Value As Integer)
            m_user_id = Value
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

    Public Property authenticated() As Boolean
        Get
            Return m_authenticated
        End Get

        Set(ByVal Value As Boolean)
            m_authenticated = Value
        End Set
    End Property

    Public Property language() As Integer
        Get
            If m_language < 1 Or m_language > 6 Then
                m_language = 1
            End If
            Return m_language
        End Get

        Set(ByVal Value As Integer)
            m_language = Value
        End Set
    End Property

	Public Property userlevel() As Int16
		Get
			Return m_userlevel
		End Get

		Set(ByVal Value As Int16)
			m_userlevel = Value
		End Set
	End Property

End Class
