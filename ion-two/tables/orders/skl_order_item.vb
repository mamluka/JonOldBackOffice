Public Class skl_order_item

	Public _id As Int32
	Public _order_id As Int32
	Public _item_id As Int32
	Public _item_no As String
	Public _item_quantity As Int32
	Public _jewelsize As String
    Public _deleted As Boolean
    Public _extrainfo As String = "None"


    Sub New()
        Me._id = 0
        Me._order_id = 0
        Me._item_id = 0
        Me._item_no = ""
        Me._item_quantity = 0
        Me._jewelsize = ""
        Me._deleted = False
    End Sub

End Class
