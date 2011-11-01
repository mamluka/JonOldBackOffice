Public MustInherit Class cls_error

	Public _err_number As Int32
	Public _err_description As String
	Public _err_source As String
	Public _connection_string As String

	Sub New()
		Me._err_number = 0
		Me._err_description = ""
		Me._err_source = ""
		Me._connection_string = ""
	End Sub

End Class
