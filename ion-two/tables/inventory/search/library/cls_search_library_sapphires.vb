Public Class cls_search_library_sapphires
	Inherits ion_two.cls_search_library

	Public _text_color As String
	Sub New()
		Me._text_color = ""

	End Sub

	Public Function get_sapphires_loose_1(ByVal nWeight As Int16, ByVal cShape As String, ByVal nPrice As Int16, ByVal bIsDealer As Boolean, ByVal cColor As String, ByRef cSQLstring As String) As Boolean
		On Error GoTo ErrorHandler
		Dim bError As Boolean = False

        cSQLstring = "select * from vv_gemstones_full where (category_id = 4)"  '' and (subcategory_id = 16) "

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

	Public Function get_sapphire_fine(ByVal nMode As Int16, ByVal cShape As String, ByVal cColor As String, ByRef cSQLstring As String) As Boolean
		On Error GoTo ErrorHandler
		Dim bError As Boolean = False

		cSQLstring = "select * from vv_gemstones_full where (category_id = 4) and (subcategory_id = 16) "

		'--- Get Shape
		bError = Me.get_shape(cShape, cSQLstring)
		If bError Then
			Return True
		End If

		'--- Get Color
		bError = Me.get_color(cColor, cSQLstring)
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

	Public Function get_sapphire_pairs(ByVal cShape As String, ByVal cColor As String, ByRef cSQLstring As String) As Boolean
		On Error GoTo ErrorHandler
		Dim bError As Boolean = False

		cSQLstring = "select * from vv_gemstones_full where (category_id = 4) and (subcategory_id = 17) "

		'--- Get Shape
		bError = Me.get_shape(cShape, cSQLstring)
		If bError Then
			Return True
		End If

		'--- Get Color
		bError = Me.get_color(cColor, cSQLstring)
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

	Friend Function get_clarity(ByVal nMode As Int16, ByRef cSQLstring As String) As Boolean
		On Error GoTo ErrorHandler
		Dim bError As Boolean = False


		Select Case nMode
			Case 1			  '--- Finest
				cSQLstring = cSQLstring + " and (grade like '%fine to finest%') "

			Case 2			 '--- Fine
				cSQLstring = cSQLstring + " and (grade like '%very very good%' or grade like '%very good%') "

			Case 3			 '--- standard
				cSQLstring = cSQLstring + " and (grade like '%good%' or grade like '%fair%') "
		End Select


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
			Case "Blue Sapphires"
				cSQLstring = cSQLstring + " and (colorfrom like '%blue%') "

			Case "Yellow Sapphires"
				cSQLstring = cSQLstring + " and (colorfrom like '%Yellow%') "

			Case "Pink Sapphires"
				cSQLstring = cSQLstring + " and (colorfrom like '%Pink%' or colorfrom like '%Purple%') "

			Case "Multi colored Sapphires"
				cSQLstring = cSQLstring + " and (colorfrom like '%green%' or colorfrom like '%Color change%') "

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
