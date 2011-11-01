Public Class skl_lst_gemstone

	Public _weight As Decimal
	Public _quantity As Int16
	Public _measure_from As String
	Public _measure_to As String
	Public _stonetype As String
	Public _origin As String
	Public _shape As String
	Public _colorfrom As String
	Public _clarityfrom As String
	Public _colorto As String
	Public _clarityto As String
	Public _grade As String
	Public _brightness As String
	Public _luster As String
	Public _saturation As String
	Public _enhancement As String
	Public _cut As String
    Public _report As String
    Public freecolor As String
	Public _s_weight As String
	Public _s_measure As String
	Public _color_sort As String
	Public _clarity_sort As String
	Public _shape_sort As String
	Public _report_sort As String
	Public _grade_sort As String

	Sub New()
		Me._weight = 0
		Me._quantity = 0
		Me._measure_from = ""
		Me._measure_to = ""
		Me._stonetype = ""
		Me._origin = ""
		Me._shape = ""
		Me._colorfrom = ""
		Me._clarityfrom = ""
		Me._colorto = ""
		Me._clarityto = ""
		Me._grade = ""
		Me._brightness = ""
		Me._luster = ""
		Me._saturation = ""
		Me._enhancement = ""
		Me._cut = ""
		Me._report = ""

		Me._s_weight = ""
		Me._s_measure = ""
		Me._color_sort = ""
		Me._clarity_sort = ""
		Me._shape_sort = ""
		Me._report_sort = ""
        Me._grade_sort = ""
        Me.freecolor = ""
	End Sub

End Class
