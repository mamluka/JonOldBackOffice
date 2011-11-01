Imports Microsoft.VisualBasic.FileSystem

Public Class cls_config
	Inherits iFoundation.cls_error_connection

	Public Shadows _connection_string As String
	Public _connection_logging As String
	Public _connection_string_type As String
	Public _connection_logging_type As String
	Public _current_directory As String
	Public _debug As Boolean
	Public _version As String
	Public _applicationup_since As DateTime

	Sub New()
		Me._connection_string = ""
		Me._connection_string_type = ""
		Me._connection_logging = ""
		Me._connection_logging_type = ""
		Me._current_directory = ""
		Me._applicationup_since = Date.Now
		Me._version = "00.01.10"
		Me._debug = False

	End Sub

	Function getconfig() As Boolean
		On Error GoTo ErrorHandler
		Dim bError As Boolean = False

		Dim nFile As Long
		Dim cLine As String

		'--- connection type 1 = SQL server  System.Data.SqlClient
		'--- connection type 2 = OLEDB       System.Data.OleDb
		'--- connection type 3 = ODBC        System.Data.Odbc
		'--- connection type 4 = ORACLE      System.Data.OracleClient

		'--- Open configuration file *
		nFile = FreeFile()
		FileSystem.FileOpen(nFile, Me._current_directory + "icrm-config.ini", OpenMode.Input)

		'--- Read configuration *
		Do
			cLine = FileSystem.LineInput(nFile)

			If cLine.ToUpper.StartsWith("CONNECTION_STRING_TYPE") Then
				Me._connection_string_type = cLine.Trim.Substring(23)

			ElseIf cLine.ToUpper.StartsWith("CONNECTION_LOGGING_TYPE") Then
				Me._connection_logging_type = cLine.Trim.Substring(24)

			ElseIf cLine.ToUpper.StartsWith("CONNECTION_STRING") Then
				Me._connection_string = cLine.Trim.Substring(18)

			ElseIf cLine.ToUpper.StartsWith("CONNECTION_LOGGING") Then
				Me._connection_logging = cLine.Trim.Substring(19)

			End If

		Loop While Not EOF(nFile)

		'--- Close File *
		FileSystem.FileClose(nFile)


		'--- Everything id OK *
		Return False
		Exit Function


ErrorHandler:
		Me._err_number = Err.Number
		Me._err_source = Err.Source
		Me._err_description = Err.Description
		Return True

	End Function

End Class
