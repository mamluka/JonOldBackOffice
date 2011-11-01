Public Class cls_search_library_emeralds
	Inherits ion_two.cls_search_library

	Public Function get_emeralds_loose_1(ByVal nWeight As Int16, ByVal cShape As String, ByVal nPrice As Int16, ByVal bIsDealer As Boolean, ByRef cSQLstring As String) As Boolean
		On Error GoTo ErrorHandler
		Dim bError As Boolean = False

		cSQLstring = "select * from vv_gemstones_full where (category_id = 5) and (subcategory_id = 21) "

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

	Public Function get_emeralds_fine(ByVal nMode As Int16, ByVal cShape As String, ByRef cSQLstring As String) As Boolean
		On Error GoTo ErrorHandler
		Dim bError As Boolean = False

		cSQLstring = "select * from vv_gemstones_full where (category_id = 5) and (subcategory_id = 21) "

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

	Public Function get_emeralds_pairs(ByVal cShape As String, ByRef cSQLstring As String) As Boolean
		On Error GoTo ErrorHandler
		Dim bError As Boolean = False

		cSQLstring = "select * from vv_gemstones_full where (category_id = 5) and (subcategory_id = 22) "

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


