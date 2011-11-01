Public Class cls_cll_datatables

	Public _datatable As DataTable
	Public _info As New Collection
	Public _ignoreget As Boolean	   '--- Ignoreget = Valid only when in update, = don't get current record info and exchange records
	Public _carryid As String

	Sub New()
		Me._ignoreget = False
		Me._carryid = ""

	End Sub

End Class
