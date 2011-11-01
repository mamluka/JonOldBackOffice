Public Class cls_search_general_special
	Inherits iFoundation.cls_error


	Public Function addsearch_special(ByRef cSQLstring As String) As Boolean
		On Error GoTo ErrorHandler
		Dim bError As Boolean = False


		cSQLstring = cSQLstring + " and (onspecial=1) and (getdate() between onspecial_from_date and onspecial_to_date) "



		Return False
		Exit Function

ErrorHandler:
		Me._err_number = Err.Number
		Me._err_description = Err.Description
		Me._err_source = Err.Source
		Return True

	End Function


End Class
