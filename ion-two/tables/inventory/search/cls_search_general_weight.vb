Public Class cls_search_general_weight
	Inherits iFoundation.cls_error

	Public _weightfrom As Decimal
	Public _weightto As Decimal
	Public _weight_margin As Decimal

	Public Function addsearch_weight_carat(ByRef cSQLstring As String) As Boolean
		On Error GoTo ErrorHandler
		Dim bError As Boolean = False

		Dim cDiamWeightFrom As String = Convert.ToString(Me._weightfrom - Me._weight_margin)
		Dim cDiamWeightTo As String = Convert.ToString(Me._weightto + Me._weight_margin)

		If Me._weightfrom > 0 Then
			If Me._weightto > Me._weightfrom Then
				cSQLstring = cSQLstring + "and (weight between " + cDiamWeightFrom + " and " + cDiamWeightTo + ") "

			Else
				cSQLstring = cSQLstring + "and (weight = " + Convert.ToString(Me._weightfrom) + ") "

			End If
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
