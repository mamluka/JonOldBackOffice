Public Class cls_get_countrystate
	'--- Default properties for every class
	Private m_connection_string As String
	Private m_error_number As Int32
	Private m_error_source As String
	Private m_error_description As String


	Public Function get_state(ByVal nStateId As Int32, ByRef cStateName As String) As Boolean
		On Error GoTo ErrorHandler

		'--- Define local vars
		Dim bError As Boolean = False

		'--- Define Connection String
		Dim bConnection_open As Boolean = False
		Dim bDatareader_open As Boolean = False
		Dim cSQL As String
		cSQL = "select lang1_longdescr from sys_state where ID =" & nStateId
		Dim objConn As New SqlClient.SqlConnection(Me.connection_string)
		Dim cSQLstring As SqlClient.SqlCommand = New SqlClient.SqlCommand(cSQL, objConn)
		objConn.Open()
		bConnection_open = True

		Dim dr_Reader As SqlClient.SqlDataReader = cSQLstring.ExecuteReader()
		bDatareader_open = True

		While dr_Reader.Read()
			cStateName = dr_Reader.Item("lang1_longdescr")
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
		Me.error_number = Err.Number
		Me.error_description = Err.Description
		Me.error_source = Err.Source
		Return True

	End Function


	Public Function get_country(ByVal nCountryId As Int32, ByRef cCountryName As String) As Boolean
		On Error GoTo ErrorHandler

		'--- Define local vars
		Dim bError As Boolean = False

		'--- Define Connection String
		Dim bConnection_open As Boolean = False
		Dim bDatareader_open As Boolean = False
		Dim cSQL As String
		cSQL = "select lang1_longdescr from sys_country where ID =" & nCountryId
		Dim objConn As New SqlClient.SqlConnection(Me.connection_string)
		Dim cSQLstring As SqlClient.SqlCommand = New SqlClient.SqlCommand(cSQL, objConn)
		objConn.Open()
		bConnection_open = True

		Dim dr_Reader As SqlClient.SqlDataReader = cSQLstring.ExecuteReader()
		bDatareader_open = True

		While dr_Reader.Read()
			cCountryName = dr_Reader.Item("lang1_longdescr")
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
		Me.error_number = Err.Number
		Me.error_description = Err.Description
		Me.error_source = Err.Source
		Return True

	End Function



	Public Property connection_string() As String
		Get
			Return m_connection_string
		End Get

		Set(ByVal Value As String)
			m_connection_string = Value
		End Set
	End Property

	Public Property error_number() As Int32
		Get
			Return m_error_number
		End Get

		Set(ByVal Value As Int32)
			m_error_number = Value
		End Set
	End Property

	Public Property error_description() As String
		Get
			Return m_error_description
		End Get

		Set(ByVal Value As String)
			m_error_description = Value
		End Set
	End Property

	Public Property error_source() As String
		Get
			Return m_error_source
		End Get

		Set(ByVal Value As String)
			m_error_source = Value
		End Set
	End Property

End Class
