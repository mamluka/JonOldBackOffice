Public Class cls_SAMPLE

	Private m_connection_string As String
	Private m_error_number As Int32
	Private m_error_source As String
	Private m_error_description As String


	Function sample() As Boolean
		On Error GoTo ErrorHandler

		'--- Define local vars
		Dim bError As Boolean = False



		Return False
		Exit Function

ErrorHandler:
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
