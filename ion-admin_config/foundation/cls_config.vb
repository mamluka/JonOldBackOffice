Public Class cls_config
	Inherits iFoundation.cls_error

	Public _domain As String
	Public _ssldomain As String
	Public _ionversion As String
	Public _domail As Boolean	'--- True = send emails
	Public _charge_online As Boolean
	Public _debug As Boolean
	Public _curdir As String
	Public _picdir As String
	Public _adsdir As String
	Public _infodir As String
	Public _serverup As DateTime

	Public _connection As New ion_two.cls_connection
	Public _defaults As New ion_admin_config.cls_defaults
	Public _pictures As New ion_two.cls_pictures
	Public _mail As New ion_two.cls_mail
	Public _colorscheme As String

	Sub New()
		Me._domain = ""
		Me._ssldomain = ""
		Me._ionversion = "1.0.1"
		Me._debug = True
		Me._domail = True
		Me._charge_online = False
		Me._curdir = ""
		Me._picdir = ""
		Me._adsdir = ""
		Me._infodir = ""
		Me._serverup = Today.Now
		Me._colorscheme = "/default.css"
	End Sub

	Public Function get_config(ByVal cFilePath As String) As Boolean
		On Error GoTo ErrorHandler
		Dim bError As Boolean = False

		'--- Read config file
		bError = Me.read_config(cFilePath)
		If bError Then
			Me._err_number = Err.Number
			Me._err_description = Err.Description
			Me._err_source = Err.Source
			Exit Function
		End If


		'--- More setitngs



		Return False
		Exit Function

ErrorHandler:
		Me._err_number = Err.Number
		Me._err_description = Err.Description
		Me._err_source = Err.Source
		Return True
		Exit Function

	End Function

	Private Function read_config(ByVal cFilePath As String) As Boolean
		On Error GoTo ErrorHandler
		Dim bError As Boolean = False

		Dim nFile As Long
		Dim cLine As String

		'--- Open configuration file *
		nFile = FreeFile()
		FileSystem.FileOpen(nFile, cFilePath + "adm-config.ini", OpenMode.Input, OpenAccess.Read, OpenShare.Shared)

		'--- Read configuration *
		Do
			cLine = FileSystem.LineInput(nFile)

			If cLine.ToUpper.StartsWith("CONNECTION_STRING_TYPE") Then
				Me._connection._connection_string_type = cLine.Trim.Substring(23)

			ElseIf cLine.ToUpper.StartsWith("CONNECTION_STRING") Then
				Me._connection._connection_string = cLine.Trim.Substring(18)


			ElseIf cLine.ToUpper.StartsWith("CONNECTION_LOGGING_TYPE") Then
				Me._connection._connection_logging_type = cLine.Trim.Substring(24)

			ElseIf cLine.ToUpper.StartsWith("CONNECTION_LOGGING") Then
				Me._connection._connection_logging = cLine.Trim.Substring(19)


			ElseIf cLine.ToUpper.StartsWith("CONNECTION_MAILING_TYPE") Then
				Me._connection._connection_mailing_type = cLine.Trim.Substring(24)

			ElseIf cLine.ToUpper.StartsWith("CONNECTION_MAILING") Then
				Me._connection._connection_mailing = cLine.Trim.Substring(19)


			ElseIf cLine.ToUpper.StartsWith("DOMAIN") Then
				Me._domain = cLine.Trim.Substring(7)

			ElseIf cLine.ToUpper.StartsWith("SSLDOMAIN") Then
				Me._ssldomain = cLine.Trim.Substring(10)

			ElseIf cLine.ToUpper.StartsWith("SMTPSERVER") Then
				Me._mail._smtpserver = cLine.Trim.Substring(11)

			ElseIf cLine.ToUpper.StartsWith("DEBUG") Then
				Me._debug = System.Convert.ToBoolean(cLine.Trim.Substring(6))

			ElseIf cLine.ToUpper.StartsWith("PICDIR") Then
				Me._picdir = cLine.Trim.Substring(7)

			ElseIf cLine.ToUpper.StartsWith("ADSDIR") Then
				Me._adsdir = cLine.Trim.Substring(7)

			ElseIf cLine.ToUpper.StartsWith("INFODIR") Then
				Me._infodir = cLine.Trim.Substring(8)

			End If

		Loop While Not EOF(nFile)

		'--- Close File *
		FileSystem.FileClose(nFile)

		Return False
		Exit Function

ErrorHandler:
		Me._err_number = Err.Number
		Me._err_description = Err.Description
		Me._err_source = Err.Source
		Return True
		Exit Function

	End Function



End Class
