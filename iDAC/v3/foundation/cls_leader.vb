Public MustInherit Class cls_leader

	Public _broker As Object	  '--- Holds the broker object at all times
	Public _dbtype As Int16
	Public _err_number As Int32
	Public _err_description As String
	Public _err_source As String
	Public _connection_string As String

	Sub New()
		Me._broker = Nothing
		Me._dbtype = 0
		Me._err_number = 0
		Me._err_description = ""
		Me._err_source = ""
		Me._connection_string = ""
	End Sub

End Class
