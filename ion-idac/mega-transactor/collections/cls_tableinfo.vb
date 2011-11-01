Public Class cls_tableinfo

	Private m_tablename As String
	Private m_id As Int32
	Private m_success As Boolean

	Sub New()
		Me.id = 0
		Me.m_tablename = ""
		Me.success = False

	End Sub

	Public Property tablename() As String
		Get
			Return m_tablename
		End Get

		Set(ByVal Value As String)
			m_tablename = Value
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

	Public Property success() As Boolean
		Get
			Return m_success
		End Get

		Set(ByVal Value As Boolean)
			m_success = Value
		End Set
	End Property

End Class
