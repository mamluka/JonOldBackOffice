Public MustInherit Class cls_search_library
	Inherits iFoundation.cls_error

	Public _text_shape As String
	Public _text_weight As String
	Public _text_price As String

	Sub New()
		Me._text_price = ""
		Me._text_shape = ""
		Me._text_weight = ""
	End Sub

	Friend Function get_weight(ByVal nWeight As Int16, ByRef cSQLstring As String) As Boolean
		On Error GoTo ErrorHandler
		Dim bError As Boolean = False

		Select Case nWeight
			Case 1
				cSQLstring = cSQLstring + " and (weight between 0 and 1) "
				Me._text_weight = "0.00-1.00 carat"

			Case 2
				cSQLstring = cSQLstring + " and (weight between 1 and 2) "
				Me._text_weight = "1.00-2.00 carat"

			Case 3
				cSQLstring = cSQLstring + " and (weight between 2 and 3) "
				Me._text_weight = "2.00-3.00 carat"

			Case 4
				cSQLstring = cSQLstring + " and (weight between 3 and 4) "
				Me._text_weight = "3.00-4.00 carat"

			Case 5
				cSQLstring = cSQLstring + " and (weight >= 4) "
                Me._text_weight = "4.00+ carat"
                ''special case for the gallery option for emeralds to lok for 0+
            Case 6
                cSQLstring = cSQLstring + " and (weight > 0) "
                Me._text_weight = "Any Weight"


        End Select


		Return False
		Exit Function

ErrorHandler:
		Me._err_number = Err.Number
		Me._err_description = Err.Description
		Me._err_source = Err.Source
		Return True
	End Function

	Friend Function get_price(ByVal nPrice As Int16, ByVal bIsDealer As Boolean, ByRef cSQLstring As String) As Boolean
		On Error GoTo ErrorHandler
		Dim bError As Boolean = False


		Select Case nPrice
			Case 0
				Me._text_price = "Any Price"

			Case 1
				If bIsDealer Then
					cSQLstring = cSQLstring + " and (dealer_price between 0 and 500) "
				Else
					cSQLstring = cSQLstring + " and (sell_price between 0 and 500) "
				End If

				Me._text_price = "Price up to 500$"

			Case 2
				If bIsDealer Then
					cSQLstring = cSQLstring + " and (dealer_price between 500 and 1000) "
				Else
					cSQLstring = cSQLstring + " and (sell_price between 500 and 1000) "
				End If

				Me._text_price = "Price 500$-1000$"

			Case 3
				If bIsDealer Then
					cSQLstring = cSQLstring + " and (dealer_price between 1000 and 1500) "
				Else
					cSQLstring = cSQLstring + " and (sell_price between 1000 and 1500) "
				End If

				Me._text_price = "Price 1000$-1500$"

			Case 4
				If bIsDealer Then
					cSQLstring = cSQLstring + " and (dealer_price between 1500 and 2000) "
				Else
					cSQLstring = cSQLstring + " and (sell_price between 1500 and 2000) "
				End If

				Me._text_price = "Price 1500$-2000$"

			Case 5
				If bIsDealer Then
					cSQLstring = cSQLstring + " and (dealer_price >= 2000) "
				Else
					cSQLstring = cSQLstring + " and (sell_price >= 2000) "
				End If

				Me._text_price = "Price 2000$ and higher"

		End Select


		Return False
		Exit Function

ErrorHandler:
		Me._err_number = Err.Number
		Me._err_description = Err.Description
		Me._err_source = Err.Source
		Return True
	End Function

	Friend Function get_shape(ByVal cShape As String, ByRef cSQLstring As String) As Boolean
		On Error GoTo ErrorHandler
		Dim bError As Boolean = False

		If LCase(cShape) <> "any shape" Then
			cSQLstring = cSQLstring + " and (shape like '" + Convert.ToString(cShape) + "')"
		End If

		Me._text_shape = cShape

		Return False
		Exit Function

ErrorHandler:
		Me._err_number = Err.Number
		Me._err_description = Err.Description
		Me._err_source = Err.Source
		Return True
	End Function
End Class
