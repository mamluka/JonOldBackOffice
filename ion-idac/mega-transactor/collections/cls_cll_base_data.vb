Public MustInherit Class cls_cll_base_data
	Private m_info As New Collection
	Private m_ignoreget As Boolean

	Public Property info() As Collection
		Get
			Return m_info
		End Get

		Set(ByVal Value As Collection)
			m_info = Value
		End Set
	End Property

	Public Property ignoreget() As Boolean
		Get
			Return m_ignoreget
		End Get

		Set(ByVal Value As Boolean)
			m_ignoreget = Value
		End Set
	End Property

End Class
