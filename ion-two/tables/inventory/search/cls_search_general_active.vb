Public Class cls_search_general_active
	Inherits iFoundation.cls_error

	Public _only_active As Boolean

	Sub New()
		Me._only_active = False
	End Sub

	Public Function addsearch_active(ByRef cSQLstring As String) As Boolean
		On Error GoTo ErrorHandler
		Dim bError As Boolean = False

		If Me._only_active Then
			cSQLstring = cSQLstring + "and (itemdeleted = 0) and (qtyonstock_cur > 0) and (shopstatus = 1) and (sell_price > 0)"
		End If

		Return False
		Exit Function

ErrorHandler:
		Me._err_number = Err.Number
		Me._err_description = Err.Description
		Me._err_source = Err.Source
		Return True
	End Function

End Class
