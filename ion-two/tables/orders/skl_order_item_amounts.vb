Public Class skl_order_item_amounts

	Public _item_number As String
	Public _item_id As Int32
	Public _item_cost As Decimal
	Public _item_sell As Decimal
	Public _item_sell_dealer As Decimal
	Public _item_sell_special As Decimal
	Public _item_sell_dealer_special As Decimal
	Public _quantity As Int16
	Public _item_special As Boolean
	Public _item_special_from As DateTime
	Public _item_special_to As DateTime
	Public _supplier_id As Int32
	Public _branch_id As Int32

	Sub New()
		Me._item_number = ""
		Me._item_id = 0
		Me._item_cost = 0
		Me._item_sell = 0
		Me._item_sell_dealer = 0
		Me._item_sell_special = 0
		Me._item_sell_dealer_special = 0
		Me._quantity = 0
		Me._item_special = False
		Me._item_special_from = #1/1/1900#
		Me._item_special_to = #1/1/1900#
		Me._supplier_id = 0
		Me._branch_id = 0
	End Sub

End Class
