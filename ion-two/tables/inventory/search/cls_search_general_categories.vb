Public Class cls_search_general_categories
	Inherits iFoundation.cls_error_connection

	Public _search_description As String

	Public _category_id As Int32
	Public _category_name As String
	Public _subcategory_id As Int32
	Public _subcategory_name As String

	Sub New()
		Me._search_description = ""

		Me._category_id = 0
		Me._category_name = ""
		Me._subcategory_id = 0
		Me._subcategory_name = ""
	End Sub

	Public Function addsearch_categories(ByRef cSQLstring As String) As Boolean
		On Error GoTo ErrorHandler
		Dim bError As Boolean = False

		If Me._category_id > 0 Then
			cSQLstring = cSQLstring + "and (category_id = '" + Convert.ToString(Me._category_id) + "') "

			'--- search also on SubCategory
			If Me._subcategory_id > 0 Then
				cSQLstring = cSQLstring + "and (subcategory_id = '" + Convert.ToString(Me._subcategory_id) + "') "

				Dim oTmpFunctionInventory As New ion_two.cls_functions_inventory
				oTmpFunctionInventory._connection_string = Me._connection_string
				oTmpFunctionInventory._dbtype = Me._dbtype
				bError = oTmpFunctionInventory.get_subcategory_name(Me._subcategory_id, Me._subcategory_name)
				If bError Then
					Me._err_number = oTmpFunctionInventory._err_number
					Me._err_description = oTmpFunctionInventory._err_description
					Me._err_source = oTmpFunctionInventory._err_source
					Return True
				End If

			End If

			'--- Add description
			If Me._subcategory_name = "" Then
				Me._search_description = Me._search_description + Convert.ToString(Me._category_name)
			Else
				Me._search_description = Me._search_description + Convert.ToString(Me._subcategory_name)
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
