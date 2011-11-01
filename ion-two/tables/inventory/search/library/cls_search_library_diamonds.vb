Public Class cls_search_library_diamonds
	Inherits ion_two.cls_search_library

	Public _text_clarity As String

	Sub New()
		Me._text_clarity = ""

	End Sub

	Public Function get_diamonds_loose_1(ByVal nWeight As Int16, ByVal cShape As String, ByVal nPrice As Int16, ByVal bIsDealer As Boolean, ByRef cSQLstring As String) As Boolean
		On Error GoTo ErrorHandler
		Dim bError As Boolean = False

		cSQLstring = "select * from vv_diamonds_full where (category_id = 1) and (subcategory_id = 1) "

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

	Public Function get_diamonds_fine(ByVal nMode As Int16, ByVal cShape As String, ByRef cSQLstring As String) As Boolean
		On Error GoTo ErrorHandler
		Dim bError As Boolean = False

		cSQLstring = "select * from vv_diamonds_full where (category_id = 1) and (subcategory_id = 1) "

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

	Public Function get_diamond_pairs(ByVal cShape As String, ByRef cSQLstring As String) As Boolean
		On Error GoTo ErrorHandler
		Dim bError As Boolean = False

		cSQLstring = "select * from vv_diamonds_full where (category_id = 1) and (subcategory_id = 2) "

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

	Public Function get_diamonds_certified(ByRef cSQLstring As String) As Boolean
		On Error GoTo ErrorHandler
		Dim bError As Boolean = False

		cSQLstring = "select * from vv_diamonds_full where (category_id = 1) and (report <> '-') "


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

	Private Function get_clarity(ByVal nMode As Int16, ByRef cSQLstring As String) As Boolean
		On Error GoTo ErrorHandler
		Dim bError As Boolean = False


		Select Case nMode
			Case 1			  '--- Finest
				cSQLstring = cSQLstring + " and (clarityfrom = 'IF' or clarityfrom = 'VVS1' or clarityfrom = 'VVS2' or clarityfrom = 'VS1' or clarityfrom = 'VS2') "
				cSQLstring = cSQLstring + " and (colorfrom = 'D' or colorfrom = 'E' or colorfrom = 'F') "

			Case 2			 '-- Standard
				cSQLstring = cSQLstring + " and (clarityfrom = 'SI1' or clarityfrom = 'SI2' or clarityfrom = 'I1') "
				cSQLstring = cSQLstring + " and (colorfrom = 'G' or colorfrom = 'H' or colorfrom = 'I') "

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
