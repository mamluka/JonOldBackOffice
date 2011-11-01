Public Class skl_diamond
	Inherits iFoundation.cls_skelet

	Public _id As Int32
	Public _inventory_id As Int32
	Public _weight As Decimal
	Public _quantity As Int16
	Public _measure1from As Decimal
	Public _measure2from As Decimal
	Public _measure3from As Decimal
	Public _measure1to As Decimal
	Public _measure2to As Decimal
	Public _measure3to As Decimal
	Public _depth As Decimal
	Public _tablewidth As Decimal
	Public _stonetype_id As Int32
	Public _color_id As Int32
	Public _clarity_id As Int32
	Public _colorto_id As Int32
	Public _clarityto_id As Int32
	Public _shape_id As Int32
	Public _polish_id As Int32
	Public _symmetry_id As Int32
	Public _fluorecence_id As Int32
	Public _girdle_id As Int32
	Public _culet_id As Int32
    Public _report_id As Int32
    Public fancy_freetxt As String

	Sub New()
		Me._id = 0
		Me._inventory_id = 0
		Me._weight = 0
		Me._quantity = 0
		Me._measure1from = 0
		Me._measure2from = 0
		Me._measure3from = 0
		Me._measure1to = 0
		Me._measure2to = 0
		Me._measure3to = 0
		Me._depth = 0
		Me._tablewidth = 0
		Me._stonetype_id = 0
		Me._color_id = 0
		Me._clarity_id = 0
		Me._colorto_id = 0
		Me._clarityto_id = 0
		Me._shape_id = 0
		Me._polish_id = 0
		Me._symmetry_id = 0
		Me._fluorecence_id = 0
		Me._girdle_id = 0
		Me._culet_id = 0
		Me._report_id = 0

	End Sub

End Class
