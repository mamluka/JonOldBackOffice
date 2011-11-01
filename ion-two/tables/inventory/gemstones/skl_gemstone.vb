Public Class skl_gemstone
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
	Public _stonetype_id As Int32
	Public _origin_id As Int32
    Public _shape_id As Int32
    Public freecolor As String

	Public _color_id As Int32
	Public _colortype_id As Int32
	Public _colorto_id As Int32
	Public _colortypeto_id As Int32

	Public _clarity_id As Int32
	Public _claritytype_id As Int32
	Public _clarityto_id As Int32
	Public _claritytypeto_id As Int32

	Public _grade_id As Int32
	Public _brightness_id As Int32
	Public _luster_id As Int32
	Public _saturation_id As Int32
	Public _enhancement_id As Int32
	Public _cut_id As Int32
	Public _report_id As Int32


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
		Me._stonetype_id = 0
		Me._origin_id = 0
		Me._shape_id = 0
		Me._color_id = 0
		Me._colortype_id = 0
		Me._colorto_id = 0
		Me._colortypeto_id = 0
		Me._clarity_id = 0
		Me._claritytype_id = 0
		Me._clarityto_id = 0
		Me._claritytypeto_id = 0
		Me._grade_id = 0
		Me._brightness_id = 0
		Me._luster_id = 0
		Me._saturation_id = 0
		Me._enhancement_id = 0
		Me._cut_id = 0
		Me._report_id = 0
        Me.freecolor = ""
	End Sub


End Class
