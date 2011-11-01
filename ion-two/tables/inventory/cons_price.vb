Public Class cons_price
	Inherits iFoundation.cls_error


	Public _isspecial As Boolean
	Public _special_from As DateTime
	Public _special_to As DateTime
	Public _sell_price As Decimal
	Public _isdealer As Boolean
	Public _dealer_price As Decimal
	Public _special_dealer_price As Decimal
	Public _special_sell_price As Decimal
    Public _correct_price As Decimal
    Public _purchase_price As Decimal
    Public _onbargain As Boolean
    Public _hash As New Hashtable

	Public _line1hlp As String
	Public _line2hlp As String
	Public _line3hlp As String
	Public _line1lbl As String
	Public _line2lbl As String
	Public _line3lbl As String
	Public _line1txt As String
	Public _line2txt As String
    Public _line3txt As String
    Public _line4txt As String


	Sub New()
		Me._isdealer = False
		Me._isspecial = False
		Me._sell_price = 0
		Me._dealer_price = 0
		Me._special_from = #1/1/1900#
		Me._special_to = #1/1/1900#
		Me._correct_price = 0
		Me._purchase_price = 0
		Me._line1hlp = "84"
		Me._line2hlp = "84"
		Me._line3hlp = "84"
		Me._line1lbl = ""
		Me._line2lbl = ""
		Me._line3lbl = ""
		Me._line1txt = ""
		Me._line2txt = ""
        Me._line3txt = ""
        Me._line4txt = ""

	End Sub


	Public Function get_price_html() As Boolean
		On Error GoTo ErrorHandler
		Dim bError As Boolean = False

		'--- Format currency to temporary var's
		Dim cSellPrice As String
		Dim cDealerPrice As String
		Dim cSpecialSellPrice As String
		Dim cSpecialDealerPrice As String

		Dim oStringFunctions As New iFunctions.cls_string
        bError = oStringFunctions.format_currency(Me._sell_price, cSellPrice, " $")
        bError = oStringFunctions.format_currency(Me._dealer_price, cDealerPrice, " $")
        bError = oStringFunctions.format_currency(Me._special_sell_price, cSpecialSellPrice, " $")
        bError = oStringFunctions.format_currency(Me._special_dealer_price, cSpecialDealerPrice, " $")
        oStringFunctions = Nothing

        Me._hash.Add("sell", cSellPrice)
        Me._hash.Add("dealer", cDealerPrice)
        Me._hash.Add("special", cSpecialSellPrice)
        Me._hash.Add("dealer special", cSpecialDealerPrice)



		If Me._isdealer Then
			Me._line1hlp = "84"
			Me._line2hlp = "8"
			Me._line3hlp = "9"

			Me._line1lbl = "&nbsp;"
            Me._line2lbl = "Our Price::"
            Me._line3lbl = "Dealer price:"

            Me._line1txt = "&nbsp;"
            Me._line2txt = "<s>" + cSellPrice + "</s>"
            Me._line3txt = cDealerPrice

        Else

            Me._line1hlp = "84"
            Me._line2hlp = "84"
            Me._line3hlp = "7"

            Me._line1lbl = "&nbsp;"
            Me._line2lbl = "&nbsp;"
            Me._line3lbl = "Our Price::"

            Me._line1txt = "&nbsp;"
            Me._line2txt = "&nbsp;"
            Me._line3txt = cSellPrice

        End If

        If Me._isspecial Then
            If Today.Date >= Me._special_from And Today.Date <= Me._special_to Then
                If Me._isdealer Then
                    Me._line1hlp = "7"
                    Me._line2hlp = "8"
                    Me._line3hlp = "9"

                    Me._line1lbl = "Our Price::"
                    Me._line2lbl = "Dealer price:"
                    Me._line3lbl = "Special price:"

                    Me._line1txt = "<s>" + cSellPrice + "</s>"
                    Me._line2txt = "<s>" + cDealerPrice + "</s>"
                    Me._line3txt = cSpecialDealerPrice
                End If

                '--- Special and NOT dealer
                Me._line1hlp = "84"
                Me._line2hlp = "7"
                Me._line3hlp = "10"

                Me._line1lbl = "&nbsp;"
                Me._line2lbl = "Our Price:"
                Me._line3lbl = "Special price:"

                Me._line1txt = "&nbsp;"
                Me._line2txt = "<s>" + cSellPrice + "</s>"
                Me._line3txt = cSpecialSellPrice


            End If
        End If
        If Me._onbargain Then
            Me._line4txt = cSpecialSellPrice
            Me._hash.Add("bargain", cSpecialSellPrice)
        End If


        Return False
        Exit Function

ErrorHandler:
        Me._err_number = Err.Number
        Me._err_description = Err.Description
        Me._err_source = Err.Source
        Return True

	End Function

	Public Function get_price() As Boolean
		On Error GoTo ErrorHandler
		Dim bError As Boolean = False

		If Me._isdealer Then
			Me._correct_price = Me._dealer_price
		Else
			Me._correct_price = Me._sell_price
		End If

		'--- if special
		If Me._isspecial Then
			If Today.Date >= Me._special_from And Today.Date <= Me._special_to Then
				If Me._isdealer Then
					Me._correct_price = Me._special_dealer_price

				Else
					Me._correct_price = Me._special_sell_price

				End If
            End If
        Else
            If Me._onbargain Then
                Me._correct_price = Me._special_sell_price
            End If
        End If

        Dim oStringFunctions As New iFunctions.cls_string
        Dim cCorrectPrice As String
        bError = oStringFunctions.format_currency(Me._correct_price, cCorrectPrice, " $")
        Me._hash.Add("correct price", cCorrectPrice)

        Return False
        Exit Function

ErrorHandler:
        Me._err_number = Err.Number
        Me._err_description = Err.Description
        Me._err_source = Err.Source
        Return True

	End Function

End Class
