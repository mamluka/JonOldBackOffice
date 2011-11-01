Public Class cls_search_library_semi_precious
	Inherits ion_two.cls_search_library

	Public _text_stonetype As String
	Sub New()
		Me._text_stonetype = ""

	End Sub

	Public Function get_semi_loose_1(ByVal nWeight As Int16, ByVal cShape As String, ByVal nPrice As Int16, ByVal bIsDealer As Boolean, ByVal cStoneType As String, ByRef cSQLstring As String) As Boolean
		On Error GoTo ErrorHandler
		Dim bError As Boolean = False

		cSQLstring = "select * from vv_gemstones_full where (category_id = 6) and (subcategory_id = 26) "

		'--- Get Color
		bError = Me.get_stonetype(cStoneType, cSQLstring)
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

	Public Function get_semi_fine(ByVal nMode As Int16, ByVal cShape As String, ByVal cStoneType As String, ByRef cSQLstring As String) As Boolean
		On Error GoTo ErrorHandler
		Dim bError As Boolean = False

		cSQLstring = "select * from vv_gemstones_full where (category_id = 6) and (subcategory_id = 26) "

		'--- Get Shape
		bError = Me.get_shape(cShape, cSQLstring)
		If bError Then
			Return True
		End If

		'--- Get Stone Type
		bError = Me.get_stonetype(cStoneType, cSQLstring)
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

	Public Function get_semi_pairs(ByVal cShape As String, ByVal cStoneType As String, ByRef cSQLstring As String) As Boolean
		On Error GoTo ErrorHandler
		Dim bError As Boolean = False

		cSQLstring = "select * from vv_gemstones_full where (category_id = 6) and (subcategory_id = 27) "

		'--- Get Shape
		bError = Me.get_shape(cShape, cSQLstring)
		If bError Then
			Return True
		End If

		'--- Get Stone Type
		bError = Me.get_stonetype(cStoneType, cSQLstring)
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


	Friend Function get_stonetype(ByVal cStoneType As String, ByRef cSQLstring As String) As Boolean
		On Error GoTo ErrorHandler
		Dim bError As Boolean = False

		If cStoneType <> "Any Stone Type" Then
            cSQLstring = cSQLstring + " and (stonetype like '%" + cStoneType + "%') "
		End If

		Me._text_stonetype = cStoneType

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

End Class
