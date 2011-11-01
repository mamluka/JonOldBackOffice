Public Class cls_base_entity_s

	Private m_id As Int32
	Private m_dataset As DataSet

	Public Property dataset() As dataset
		Get
			Return m_dataset
		End Get

		Set(ByVal Value As dataset)
			m_dataset = Value
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


End Class
