Public Class cls_sql_constructor
	Inherits iFoundation.cls_error_connection

	Public _fieldlist As String
	Public _tablename As String
	Public _sortstring As String
	Public _clause As String
	Public _sqlstring As String

	Sub New()
		Me._fieldlist = ""
		Me._tablename = ""
		Me._sortstring = ""
		Me._clause = ""
		Me._sqlstring = ""

	End Sub
	Public Function construct() As Boolean
		On Error GoTo ErrorHandler
		Dim bError As Boolean = False

		Dim cSQLstring As String = ""

		cSQLstring = "select " + Trim(Me._fieldlist) + " "
		cSQLstring = cSQLstring + "from " + Trim(Me._tablename) + " "

		'--- If we have a where
		If Me._clause <> "" Then
			cSQLstring = cSQLstring + " where " + Trim(Me._clause) + " "
		End If


		'--- If we have a sort
		If Me._sortstring <> "" Then
			cSQLstring = cSQLstring + "order by " + Me._sortstring
		End If


		Me._sqlstring = Trim(cSQLstring)


		Return False
		Exit Function

ErrorHandler:
		Me._err_number = Err.Number
		Me._err_description = Err.Description
		Me._err_source = Err.Source
		Return True

	End Function


End Class
