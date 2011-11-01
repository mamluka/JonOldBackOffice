Public Class cls_connection

	Public _connection_string As String
	Public _connection_string_type As String
	Public _connection_logging As String
	Public _connection_logging_type As String
	Public _connection_mailing As String
	Public _connection_mailing_type As String

	Sub New()
		Me._connection_string = ""
		Me._connection_string_type = ""
		Me._connection_logging = ""
		Me._connection_logging_type = ""
		Me._connection_mailing = ""
		Me._connection_mailing_type = ""
	End Sub

End Class
