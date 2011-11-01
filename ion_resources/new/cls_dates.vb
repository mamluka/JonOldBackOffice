Public Class cls_dates
	Inherits cls_base_general

	Function get_dbdate(ByVal nDays As Int16, ByRef dDateTime As DateTime) As Boolean
		On Error GoTo ErrorHandler

		'--- Define local vars
		Dim bError As Boolean = False

		'--- Define Connection String
		Dim bConnection_open As Boolean = False
		Dim bDatareader_open As Boolean = False
		Dim cSQL As String
		cSQL = "select DATEADD(day, " + Convert.ToString(nDays) + ", getdate()) as ddate"
		Dim objConn As New SqlClient.SqlConnection(Me.connection_string)
		Dim cSQLstring As SqlClient.SqlCommand = New SqlClient.SqlCommand(cSQL, objConn)
		objConn.Open()
		bConnection_open = True

		Dim dr_Reader As SqlClient.SqlDataReader = cSQLstring.ExecuteReader()
		bDatareader_open = True

		While dr_Reader.Read()
			dDateTime = dr_Reader.Item("ddate")
		End While

		objConn.Close()
		dr_Reader.Close()

		Return False
		Exit Function

ErrorHandler:
		If bDatareader_open Then
			dr_Reader.Close()
		End If
		If bConnection_open Then
			objConn.Close()
		End If

		'--- register the error
		Me.error_no = Err.Number
		Me.error_desc = Err.Description
		Me.error_source = Err.Source
		Return True

	End Function





End Class
