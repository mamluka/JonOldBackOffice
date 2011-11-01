Imports Microsoft.VisualBasic.FileSystem

Public Class cls_readconfig

    Private m_error_number As Int32
    Private m_error_source As String
    Private m_error_description As String

    Private m_connection_string As String
	Private m_connection_string_type As String
	Private m_connection_logging As String
	Private m_connection_mainlog As String
	Private m_connection_mailing As String
	Private m_domain As String
	Public masterdomain As String
	Private m_ssldomain As String
    Private m_smtpserver As String
    Private m_debug As Boolean
    Private m_picdir As String
    Private m_adsdir As String
    Private m_infodir As String

    Function getconfig(ByVal cPath As String) As Boolean
        On Error GoTo ErrorHandler

        Dim bError As Boolean
        Dim nFile As Long
        Dim cLine As String

        '--- Open configuration file *
        nFile = FreeFile()
        filesystem.FileOpen(nFile, cPath + "sg-config.ini", OpenMode.Input)

        '--- Read configuration *
        Do
            cLine = filesystem.LineInput(nFile)

			If cLine.ToUpper.StartsWith("CONNECTION_STRING_TYPE") Then
				Me.connection_string_type = cLine.Trim.Substring(23)

			ElseIf cLine.ToUpper.StartsWith("CONNECTION_STRING") Then
				Me.connection_string = cLine.Trim.Substring(18)

			ElseIf cLine.ToUpper.StartsWith("CONNECTION_LOGGING") Then
				Me.connection_logging = cLine.Trim.Substring(19)

			ElseIf cLine.ToUpper.StartsWith("CONNECTION_MAINLOG") Then
				Me.connection_mainlog = cLine.Trim.Substring(19)

			ElseIf cLine.ToUpper.StartsWith("CONNECTION_MAILING") Then
				Me.connection_mailing = cLine.Trim.Substring(19)

			ElseIf cLine.ToUpper.StartsWith("MASTERDOMAIN") Then
				Me.masterdomain = cLine.Trim.Substring(13)

			ElseIf cLine.ToUpper.StartsWith("DOMAIN") Then
				Me.domain = cLine.Trim.Substring(7)

			ElseIf cLine.ToUpper.StartsWith("SSLDOMAIN") Then
				Me.ssldomain = cLine.Trim.Substring(10)

			ElseIf cLine.ToUpper.StartsWith("SMTPSERVER") Then
				Me.smtpserver = cLine.Trim.Substring(11)

			ElseIf cLine.ToUpper.StartsWith("DEBUG") Then
				Me.debug = System.Convert.ToBoolean(cLine.Trim.Substring(6))

			ElseIf cLine.ToUpper.StartsWith("PICDIR") Then
				Me.picdir = cLine.Trim.Substring(7)

			ElseIf cLine.ToUpper.StartsWith("ADSDIR") Then
				Me.adsdir = cLine.Trim.Substring(7)

			ElseIf cLine.ToUpper.StartsWith("INFODIR") Then
				Me.infodir = cLine.Trim.Substring(8)

			End If

		Loop While Not EOF(nFile)

        '--- Close File *
        filesystem.FileClose(nFile)


        '--- Everything id OK *
        Return False
        Exit Function


ErrorHandler:

        '--- when object is called in external DLL
        Me.error_number = Err.Number
        Me.error_source = Err.Source
        Me.error_description = Err.Description
        Return True

    End Function



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

    Public Property connection_logging() As String
        Get
            Return m_connection_logging
        End Get

        Set(ByVal Value As String)
            m_connection_logging = Value
        End Set
    End Property

    Public Property connection_string() As String
        Get
            Return m_connection_string
        End Get

        Set(ByVal Value As String)
            m_connection_string = Value
        End Set
    End Property

	Public Property connection_string_type() As String
		Get
			Return m_connection_string_type
		End Get

		Set(ByVal Value As String)
			m_connection_string_type = Value
		End Set
	End Property

	Public Property connection_mainlog() As String
		Get
			Return m_connection_mainlog
		End Get

		Set(ByVal Value As String)
			m_connection_mainlog = Value
		End Set
	End Property

	Public Property connection_mailing() As String
		Get
			Return m_connection_mailing
		End Get

		Set(ByVal Value As String)
			m_connection_mailing = Value
		End Set
	End Property

	Public Property domain() As String
		Get
			Return m_domain
		End Get

		Set(ByVal Value As String)
			m_domain = Value
		End Set
	End Property

	Public Property ssldomain() As String
		Get
			Return m_ssldomain
		End Get

		Set(ByVal Value As String)
			m_ssldomain = Value
		End Set
	End Property

	Public Property smtpserver() As String
		Get
			Return m_smtpserver
		End Get

		Set(ByVal Value As String)
			m_smtpserver = Value
		End Set
	End Property

	Public Property debug() As Boolean
		Get
			Return m_debug
		End Get

		Set(ByVal Value As Boolean)
			m_debug = Value
		End Set
	End Property

	Public Property picdir() As String
		Get
			Return m_picdir
		End Get

		Set(ByVal Value As String)
			m_picdir = Value
		End Set
	End Property

	Public Property adsdir() As String
		Get
			Return m_adsdir
		End Get

		Set(ByVal Value As String)
			m_adsdir = Value
		End Set
	End Property

	Public Property infodir() As String
		Get
			Return m_infodir
		End Get

		Set(ByVal Value As String)
			m_infodir = Value
		End Set
	End Property

End Class
