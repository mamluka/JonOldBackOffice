Imports System.Data.SqlClient

Friend Class cls_sql_datadeader
	Inherits cls_error

	'--- This module reads data with a datareader
	'--- paramter _fields should contain a collection of fields

	Public _id As Int32
	Public _clause As String
	Public _order As String
	Public _table As String
	Public _hasresult As Boolean
	Public _fields As New Collection

	Sub New()
		Me._id = 0
		Me._clause = ""
		Me._order = ""
		Me._table = ""
		Me._hasresult = False
	End Sub

	Public Function read(Optional ByVal cSQLstring As String = "") As Boolean
		On Error GoTo ErrorHandler
		Dim bError As Boolean = False

		'--- Define Connection String
		Dim bConnection_open As Boolean = False
		Dim bDatareader_open As Boolean = False

		If Me._fields.Count = 0 Then
			Err.Raise(9002, "cls_sql_datadeader:read", "iDAC: Property _Fields not provided")
		End If

		'--- If an SQL string was passed no need to check and construct
		If cSQLstring = "" Then
			If Me._table = "" Then
				Err.Raise(9001, "cls_sql_datadeader:read", "iDAC: Property _Table not provided")
			End If

			bError = Me.construct_sql(cSQLstring)
			If bError Then
				Return True
			End If
		End If

		Dim oConnection As New SqlClient.SqlConnection(Me._connection_string)
		Dim cSQLcommand As SqlClient.SqlCommand = New SqlClient.SqlCommand(cSQLstring, oConnection)
		oConnection.Open()
		bConnection_open = True

		Dim oDataReader As SqlClient.SqlDataReader = cSQLcommand.ExecuteReader()
		bDatareader_open = True

		If oDataReader.HasRows Then
			Dim nLoop As Int32
			While oDataReader.Read()
				For nLoop = 1 To Me._fields.Count
					Me._fields.Item(nLoop)._result = oDataReader.Item(nLoop - 1)
				Next
			End While

			Me._hasresult = True
		Else

			Me._hasresult = False
		End If

		oConnection.Close()
		oDataReader.Close()

		Return False
		Exit Function

ErrorHandler:
		If bDatareader_open Then
			oDataReader.Close()
		End If
		If bConnection_open Then
			oConnection.Close()
		End If

		'--- register the error
		Me._err_number = Err.Number
		Me._err_description = Err.Description
		Me._err_source = Err.Source
		Return True

	End Function

	Public Function readcombo(ByVal cSQL As String, ByRef oCombo As System.Web.UI.WebControls.DropDownList) As Boolean
		On Error GoTo ErrorHandler
		Dim bError As Boolean = False

		'--- Define Connection String
		Dim bConnection_open As Boolean = False


		Dim oConnection As New SqlClient.SqlConnection(Me._connection_string)
		Dim cSQLstring As SqlClient.SqlCommand = New SqlClient.SqlCommand(cSQL, oConnection)

		'--- Open connection
		oConnection.Open()
		bConnection_open = True

		'--- Fetch Data
		oCombo.DataSource = cSQLstring.ExecuteReader()
		oCombo.DataBind()

		'--- Close Connection
		oConnection.Close()


		Return False
		Exit Function

ErrorHandler:
		If bConnection_open Then
			oConnection.Close()
		End If

		'--- register the error
		Me._err_number = Err.Number
		Me._err_description = Err.Description
		Me._err_source = Err.Source
		Return True

	End Function

	Private Function construct_sql(ByRef cSQL As String) As Boolean
		On Error GoTo ErrorHandler
		Dim bError As Boolean = False

		Dim cFieldList As String
		Dim nLoop As Int16
		For nLoop = 1 To Me._fields.Count
			If nLoop = Me._fields.Count Then
				cFieldList = cFieldList + Me._fields.Item(nLoop)._field
			Else
				cFieldList = cFieldList + Me._fields.Item(nLoop)._field + ", "
			End If
		Next

		'--- Convert ID to string
		Dim cClause As String = ""
		Dim cOrder As String = ""

		'--- If we have _CLAUSE
		If Me._clause <> "" Then
			cClause = " where " + Me._clause
		End If

		'--- If we have _ID
		If Me._id > 0 Then
			If Me._clause = "" Then
				cClause = cClause + " where id = '" + Convert.ToString(Me._id) + "'"
			Else
				cClause = cClause + " and id = '" + Convert.ToString(Me._id) + "'"
			End If
		End If

		'--- If we have ORDER
		If Me._order <> "" Then
			cOrder = "order by " + Me._order
		End If

		'--- complete SQL statement
		cSQL = "select " + Trim(cFieldList) + " from " + Trim(Me._table) + cClause + cOrder


		Return False
		Exit Function

ErrorHandler:
		'--- register the error
		Me._err_number = Err.Number
		Me._err_description = Err.Description
		Me._err_source = Err.Source
		Return True

	End Function



End Class
