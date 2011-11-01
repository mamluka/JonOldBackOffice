Public Class skl_box_master

	Public _id As Int32
	Public _boxmaster_no As Int32
	Public _box_no As Int32
	Public _stonetype_id As Int32
	Public _shape_id As Int32
	Public _header_description As String
	Public _platina_description As String
	Public _wgold_description As String
	Public _ygold_description As String
	Public _filename As String
	Public _items As New Collection
	Public _shape As New ion_two.skl_box_stoneshape
	Public _stonetype As New ion_two.skl_box_stonetype

	Sub New()
		Me._id = 0
		Me._boxmaster_no = 0
		Me._box_no = 0
		Me._shape_id = 0
		Me._stonetype_id = 0
		Me._header_description = ""
		Me._platina_description = ""
		Me._wgold_description = ""
		Me._ygold_description = ""
		Me._filename = ""

	End Sub

End Class
