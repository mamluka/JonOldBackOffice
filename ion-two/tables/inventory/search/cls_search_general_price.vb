Public Class cls_search_general_price
	Inherits iFoundation.cls_error

	Public _isdealer As Boolean
	Public _pricefrom As Decimal
	Public _priceto As Decimal

	Sub New()
		Me._isdealer = False
		Me._pricefrom = 0
		Me._priceto = 0
	End Sub


	Public Function addsearch_price(ByRef cSQLstring As String) As Boolean
		On Error GoTo ErrorHandler
		Dim bError As Boolean = False

		If Me._isdealer Then
			If Me._pricefrom > 0 Then
				If Me._priceto > Me._pricefrom Then
					cSQLstring = cSQLstring + "and (dealer_price between " + Convert.ToString(Me._pricefrom) + " and " + Convert.ToString(Me._priceto) + ") "
				Else
					cSQLstring = cSQLstring + "and (dealer_price = " + Convert.ToString(Me._pricefrom) + ") "
				End If
			End If

		Else
			If Me._pricefrom > 0 Then
				If Me._priceto > Me._pricefrom Then
					cSQLstring = cSQLstring + "and (sell_price between " + Convert.ToString(Me._pricefrom) + " and " + Convert.ToString(Me._priceto) + ") "
				Else
					cSQLstring = cSQLstring + "and (sell_price = " + Convert.ToString(Me._pricefrom) + ") "
				End If
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
