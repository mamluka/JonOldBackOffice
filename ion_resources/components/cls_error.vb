Public Class cls_error
    Private m_err_number As Integer = 0
    Private m_err_source As String = ""
    Private m_err_description As String = ""
    Private m_app_module As String = "" '-- module where called
    Private m_app_call As String = "" '-- called from where inside the function
    Private m_app_function As String = "" '-- function where called from
	Private m_note As String

	Public Property err_number() As Integer
		Get
			Return m_err_number
		End Get

		Set(ByVal Value As Integer)
			m_err_number = Value
		End Set
	End Property

	Public Property err_source() As String
		Get
			Return m_err_source
		End Get

		Set(ByVal Value As String)
			m_err_source = Value
		End Set
	End Property

	Public Property err_description() As String
		Get
			Return m_err_description
		End Get

		Set(ByVal Value As String)
			m_err_description = Value
		End Set
	End Property

	Public Property app_module() As String
		Get
			Return m_app_module
		End Get

		Set(ByVal Value As String)
			m_app_module = Value
		End Set
	End Property

	Public Property app_call() As String
		Get
			Return m_app_call
		End Get

		Set(ByVal Value As String)
			m_app_call = Value
		End Set
	End Property

	Public Property app_function() As String
		Get
			Return m_app_function
		End Get

		Set(ByVal Value As String)
			m_app_function = Value
		End Set
	End Property

	Public Property note() As String
		Get
			Return m_note
		End Get

		Set(ByVal Value As String)
			m_note = Value
		End Set
	End Property

End Class
