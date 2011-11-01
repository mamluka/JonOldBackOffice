Public Class cls_search_library_jewelry
	Inherits ion_two.cls_search_library

	Public Function get_jewelry_price(ByVal nMidleStone As Int16, ByVal nSubCategory As Int32, ByVal nJewelSubCategory As String, ByVal nPrice As Decimal, ByVal bIsDealer As Boolean, ByRef cSQLstring As String)
		On Error GoTo ErrorHandler
		Dim bError As Boolean = False

		cSQLstring = "select * from vv_jewelry_full where (category_id = 7) and (subcategory_id = " + Convert.ToString(nSubCategory) + ") "

		'--- Get Shape
		bError = Me.get_jewel_subcategory(nJewelSubCategory, cSQLstring)
		If bError Then
			Return True
		End If

		'--- Get Price
		bError = Me.get_price(nPrice, bIsDealer, cSQLstring)
		If bError Then
			Return True
		End If

		'--- Get stone
		bError = Me.get_jewel_middlestone(nMidleStone, cSQLstring)
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

	Public Function get_jewelry_unique(ByVal nMidleStone As Int16, ByVal nSubCategory As Int32, ByVal cJewelSubCategory As String, ByVal nPrice As Decimal, ByVal bIsDealer As Boolean, ByRef cSQLstring As String)
		On Error GoTo ErrorHandler
		Dim bError As Boolean = False

		'cSQLstring = "select * from vv_jewelry_full where (category_id = 7) and (suppliernumber <> 99) and (subcategory_id = " + Convert.ToString(nSubCategory) + ") "
		cSQLstring = "select * from vv_jewelry_full where (category_id = 7) and (subcategory_id = " + Convert.ToString(nSubCategory) + ") "

		'--- Get Shape
		bError = Me.get_jewel_subcategory(cJewelSubCategory, cSQLstring)
		If bError Then
			Return True
		End If

		'--- Get Price
		bError = Me.get_price(nPrice, bIsDealer, cSQLstring)
		If bError Then
			Return True
		End If

		'--- Get stone
		bError = Me.get_jewel_middlestone(nMidleStone, cSQLstring)
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

	Public Function get_jewelry_certified(ByVal nMidleStone As Int16, ByVal nSubCategory As Int32, ByRef cSQLstring As String)
		On Error GoTo ErrorHandler
		Dim bError As Boolean = False

        cSQLstring = "select * from vv_jewelry_full where (category_id = 7) and (subcategory_id = " + Convert.ToString(nSubCategory) + ") and ( ((report <> '-' ) or ( certificate_name <>'' )) ) "

		'--- Get stone
		bError = Me.get_jewel_middlestone(nMidleStone, cSQLstring)
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


		cSQLstring = cSQLstring + " order by report_sort"



		Return False
		Exit Function

ErrorHandler:
		Me._err_number = Err.Number
		Me._err_description = Err.Description
		Me._err_source = Err.Source
		Return True

	End Function

	Private Function get_jewel_middlestone(ByVal nMidleStone As Int16, ByRef cSQLstring As String) As Boolean
		On Error GoTo ErrorHandler
		Dim bError As Boolean = False

		Select Case nMidleStone

			Case 1			 '-- Diamonds and fancy-diamonds
				cSQLstring = cSQLstring + " and (middlestone like '%diamond') "

			Case 2			 '--- Emerald
				cSQLstring = cSQLstring + " and (middlestone like 'emerald') "

			Case 3			 '--- Sapphire
				cSQLstring = cSQLstring + " and (middlestone like 'sapphire') "

			Case 4			 '--- Ruby
				cSQLstring = cSQLstring + " and (middlestone like 'ruby') "

			Case 5			 '--- Semi-precious
				cSQLstring = cSQLstring + " and (middlestone not like '%diamond') "
				cSQLstring = cSQLstring + " and (middlestone not like 'emerald') "
				cSQLstring = cSQLstring + " and (middlestone not like 'sapphire') "
				cSQLstring = cSQLstring + " and (middlestone not like 'ruby') "
				cSQLstring = cSQLstring + " and (middlestone not like '-') "

			Case 99			 '--- All except diamonds
				cSQLstring = cSQLstring + " and (middlestone not like '%diamond') "
				cSQLstring = cSQLstring + " and (middlestone not like '-') "

		End Select

		Return False
		Exit Function

ErrorHandler:
		Me._err_number = Err.Number
		Me._err_description = Err.Description
		Me._err_source = Err.Source
		Return True
	End Function

	Private Function get_jewel_subcategory(ByVal cJewelSubCategory As String, ByRef cSQLstring As String) As Boolean
		On Error GoTo ErrorHandler
		Dim bError As Boolean = False

		If LCase(cJewelSubCategory) <> "any category" Then
			cSQLstring = cSQLstring + " and (jewelsubtype = '" + cJewelSubCategory + "') "
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
