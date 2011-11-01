Public MustInherit Class cls_error_connection
	Inherits iFoundation.cls_error

	Public _connection_string As String
	Public _dbtype As Int16
	Public _user_id As Int32
	Public _idac_transaction As iDac.cls_T_transaction

	Sub New()
		Me._connection_string = ""
		Me._dbtype = 0
		Me._user_id = 0
		Me._idac_transaction = Nothing
	End Sub


End Class
