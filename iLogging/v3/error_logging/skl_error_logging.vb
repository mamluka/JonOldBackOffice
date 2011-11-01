Public Class skl_error_logging

	Public _id As Int32
	Public _logtime As DateTime
	Public _sessionId As String
	Public _user_id As Int32
	Public _user_ip As String
	Public _user_name As String
	Public _framework As String
	Public _dllstat As String
	Public _err_number As Int32
	Public _err_version As String
	Public _err_description As String
	Public _err_source As String
	Public _err_module As String
	Public _err_call As String
	Public _note As String

	Sub New()
		Me._id = 0
		Me._LogTime = #1/1/1900#
		Me._SessionId = ""
		Me._user_id = 0
		Me._user_ip = ""
		Me._user_name = ""
		Me._framework = "00.00.00"
		Me._dllstat = ""
		Me._err_number = 0
		Me._err_description = ""
		Me._Err_Version = "00.00.00"
		Me._Err_Source = ""
		Me._Err_Module = ""
		Me._Err_Call = ""
		Me._note = ""

	End Sub



End Class
