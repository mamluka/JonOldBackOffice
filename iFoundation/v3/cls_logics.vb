Public Class cls_logics
	Public _err_number As Int32
	Public _err_description As String
	Public _err_source As String
	Public _connection_string As String
	Public _dbtype As Int16
	Public _user_id As Int32
	Public _user_name As String
	Public _tablename As String
	Public _module As String
	Public _ssl As Boolean

	Sub New()
		Me._err_number = 0
		Me._err_description = ""
		Me._err_source = ""
		Me._connection_string = ""
		Me._dbtype = 0
		Me._user_id = 0
		Me._user_name = ""
		Me._tablename = ""
		Me._module = ""
		Me._ssl = False
	End Sub

	Overridable Function remove(ByVal nId As Int32) As Boolean
		On Error GoTo ErrorHandler

		'--- local definitions
		Dim bError As Boolean = False

		'--- Delete Item
		Dim oDeleteTransactor As New iDac.cls_T_delete
		oDeleteTransactor._dbtype = Me._dbtype
		oDeleteTransactor._connection_string = Me._connection_string
		oDeleteTransactor._dbtype = Me._dbtype
		oDeleteTransactor._tablename = Me._tablename
		bError = oDeleteTransactor.transact_delete(nId)
		If bError Then
			Me._err_number = Err.Number
			Me._err_description = Err.Description
			Me._err_source = Err.Source
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
