Public Class skl_books_general

	Public _trs_id As Int32
	Public _order_id As Int32
	Public _account_id As Int16
	Public _trs_date As DateTime
	Public _description As String
	Public _rate_ils As Decimal
	Public _amount As Decimal
	Public _lastmodify_date As DateTime
	Public _lastmodify_user As String
	Public _lastmodify_user_id As Int32

	Sub New()
		Me._trs_id = 0
		Me._order_id = 0
		Me._account_id = 0
		Me._trs_date = #1/1/1900#
		Me._description = ""
		Me._rate_ils = 0
		Me._amount = 0
		Me._lastmodify_date = #1/1/1900#
		Me._lastmodify_user = ""
		Me._lastmodify_user_id = 0
	End Sub

End Class
