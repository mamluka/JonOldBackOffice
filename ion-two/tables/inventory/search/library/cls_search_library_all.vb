Public Class cls_search_library_all
	Inherits ion_two.cls_search_library

	Public Function get_all_9specials(ByRef cSQLstring As String) As Boolean
		On Error GoTo ErrorHandler
		Dim bError As Boolean = False

		cSQLstring = "select top 12 * from vv_allitems_full where sell_price > 0"

		'--- set Special
		Dim oSpecial As New ion_two.cls_search_general_special
		bError = oSpecial.addsearch_special(cSQLstring)
		If bError Then
			Me._err_number = oSpecial._err_number
			Me._err_description = oSpecial._err_description
			Me._err_source = oSpecial._err_source
			Return True
		End If
		oSpecial = Nothing


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


		'--- Set order
        cSQLstring = cSQLstring + "  order by onspecial_to_date asc"


		Return False
		Exit Function

ErrorHandler:
		Me._err_number = Err.Number
		Me._err_description = Err.Description
		Me._err_source = Err.Source
		Return True

	End Function

End Class
