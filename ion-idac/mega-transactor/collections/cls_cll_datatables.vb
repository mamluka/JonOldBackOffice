Public Class cls_cll_datatables
	Inherits cls_cll_base_data

	Private m_datatable As datatable

	Public Property datatable() As datatable
		Get
			Return m_datatable
		End Get

		Set(ByVal Value As datatable)
			m_datatable = Value
		End Set
	End Property

End Class
