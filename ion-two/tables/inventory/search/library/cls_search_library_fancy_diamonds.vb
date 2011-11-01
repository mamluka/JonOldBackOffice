Public Class cls_search_library_fancy_diamonds
	Inherits ion_two.cls_search_library

	Public _text_stonetype As String
	Public _text_clarity As String

	Sub New()
		Me._text_stonetype = ""
		Me._text_clarity = ""

	End Sub

	Public Function get_fancydiamonds_loose_1(ByVal nWeight As Int16, ByVal cShape As String, ByVal nPrice As Int16, ByVal bIsDealer As Boolean, ByVal cColor As String, ByRef cSQLstring As String) As Boolean
		On Error GoTo ErrorHandler
		Dim bError As Boolean = False

		cSQLstring = "select * from vv_diamonds_full where (category_id = 2) and (subcategory_id = 6) "

		'--- Get Color
		bError = Me.get_color(cColor, cSQLstring)
		If bError Then
			Return True
		End If


		'--- Get Shape
		bError = Me.get_shape(cShape, cSQLstring)
		If bError Then
			Return True
		End If

		'--- Get Weight
		bError = Me.get_weight(nWeight, cSQLstring)
		If bError Then
			Return True
		End If

		'--- Get Price
		bError = Me.get_price(nPrice, bIsDealer, cSQLstring)
		If bError Then
			Return True
		End If


		'--- set Active
		Dim oActive As New ion_two.cls_search_general_active
		oActive._only_active = True
		bError = oActive.addsearch_active(cSQLstring)
		If bError Then
			Me._err_number = oActive._err_number
			Me._err_description = oActive._err_description
			Me._err_source = oActive._err_source
			Return True
		End If
		oActive = Nothing

		Return False
		Exit Function

ErrorHandler:
		Me._err_number = Err.Number
		Me._err_description = Err.Description
		Me._err_source = Err.Source
		Return True

	End Function

	Public Function get_fancydiamonds_fine(ByVal nMode As Int16, ByVal cShape As String, ByRef cSQLstring As String) As Boolean
		On Error GoTo ErrorHandler
		Dim bError As Boolean = False

		cSQLstring = "select * from vv_diamonds_full where (category_id = 2) and (subcategory_id = 6) "

		'--- Get Shape
		bError = Me.get_shape(cShape, cSQLstring)
		If bError Then
			Return True
		End If

		'--- Get Clarity
		bError = Me.get_clarity(nMode, cSQLstring)
		If bError Then
			Return True
		End If

		'--- set Active
		Dim oActive As New ion_two.cls_search_general_active
		oActive._only_active = True
		bError = oActive.addsearch_active(cSQLstring)
		If bError Then
			Me._err_number = oActive._err_number
			Me._err_description = oActive._err_description
			Me._err_source = oActive._err_source
			Return True
		End If
		oActive = Nothing

		Return False
		Exit Function

ErrorHandler:
		Me._err_number = Err.Number
		Me._err_description = Err.Description
		Me._err_source = Err.Source
		Return True

	End Function

	Public Function get_fancydiamonds_pairs(ByVal cShape As String, ByRef cSQLstring As String) As Boolean
		On Error GoTo ErrorHandler
		Dim bError As Boolean = False

		cSQLstring = "select * from vv_diamonds_full where (category_id = 2) and (subcategory_id = 7) "

		'--- Get Shape
		bError = Me.get_shape(cShape, cSQLstring)
		If bError Then
			Return True
		End If

		'--- set Active
		Dim oActive As New ion_two.cls_search_general_active
		oActive._only_active = True
		bError = oActive.addsearch_active(cSQLstring)
		If bError Then
			Me._err_number = oActive._err_number
			Me._err_description = oActive._err_description
			Me._err_source = oActive._err_source
			Return True
		End If
		oActive = Nothing

		Return False
		Exit Function

ErrorHandler:
		Me._err_number = Err.Number
		Me._err_description = Err.Description
		Me._err_source = Err.Source
		Return True

	End Function

	Public Function get_fancydiamonds_certified(ByRef cSQLstring As String) As Boolean
		On Error GoTo ErrorHandler
		Dim bError As Boolean = False

		cSQLstring = "select * from vv_diamonds_full where (category_id = 2) and (report <> '-') "


		'--- set Active
		Dim oActive As New ion_two.cls_search_general_active
		oActive._only_active = True
		bError = oActive.addsearch_active(cSQLstring)
		If bError Then
			Me._err_number = oActive._err_number
			Me._err_description = oActive._err_description
			Me._err_source = oActive._err_source
			Return True
		End If
		oActive = Nothing

		cSQLstring = cSQLstring + " order by report_sort"

		Return False
		Exit Function

ErrorHandler:
		Me._err_number = Err.Number
		Me._err_description = Err.Description
		Me._err_source = Err.Source
		Return True

	End Function

	Friend Function get_color(ByVal cColor As String, ByRef cSQLstring As String) As Boolean
		On Error GoTo ErrorHandler
		Dim bError As Boolean = False


		Select Case cColor
			Case "Blue"
				cSQLstring = cSQLstring + " and (colorfrom like '%blue%' or notes like '%blue%') "

			Case "Pink"
				cSQLstring = cSQLstring + " and (colorfrom like '%pink%' or notes like '%pink%') "

			Case "Orange"
				cSQLstring = cSQLstring + " and (colorfrom like '%orange%' or notes like '%orange%') "

			Case "Yellow"
				cSQLstring = cSQLstring + " and (colorfrom like '%yellow%' or notes like '%yellow%') "

			Case "Green"
				cSQLstring = cSQLstring + " and (colorfrom like '%green%' or notes like '%green%') "

			Case "Congac"
				cSQLstring = cSQLstring + " and (colorfrom like '%congac%' or notes like '%congac%') "

			Case "Champagne"
				cSQLstring = cSQLstring + " and (colorfrom like '%champagne%' or notes like '%champagne%') "

			Case "Brown"
				cSQLstring = cSQLstring + " and (colorfrom like '%brown%' or notes like '%brown%') "

		End Select


		Return False
		Exit Function

ErrorHandler:
		Me._err_number = Err.Number
		Me._err_description = Err.Description
		Me._err_source = Err.Source
		Return True
	End Function

	Friend Function get_clarity(ByVal nMode As Int16, ByRef cSQLstring As String) As Boolean
		On Error GoTo ErrorHandler
		Dim bError As Boolean = False


		Select Case nMode
			Case 1			  '--- Finest
                ''cSQLstring = cSQLstring + " and (clarityfrom = 'IF' or clarityfrom = 'VVS1' or clarityfrom = 'VVS2' or clarityfrom = 'VS1' or clarityfrom = 'VS2' or clarityfrom = 'SI') "
                cSQLstring = cSQLstring + " and (colorfrom like '%pink%' or colorfrom like '%blue%' or fancy_freetxt like '%pink%' or fancy_freetxt like '%blue%' or fancy_freetxt like  '%yellow green%' ) "

			Case 2			 '-- Standard
                ''	cSQLstring = cSQLstring + " and (clarityfrom = 'SI2' or clarityfrom = 'I1' or clarityfrom = 'I2' or clarityfrom = 'I3') "
                cSQLstring = cSQLstring + " and (colorfrom not like '%pink%' or colorfrom not like '%blue%' or fancy_freetxt not like '%pink%' or fancy_freetxt not like '%blue%' or fancy_freetxt not like  '%yellow green%' ) "

		End Select


		Return False
		Exit Function

ErrorHandler:
		Me._err_number = Err.Number
		Me._err_description = Err.Description
		Me._err_source = Err.Source
		Return True
	End Function

End Class
