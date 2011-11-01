Public Class skl_lst_jewelry

    Public _size As String
	Public _weight As Decimal
	Public _jewelrytype As String
	Public _jewelrysubtype As String
	Public _metal As String
	Public _middlestone As String
	Public _middlestone_desc As String
	Public _brand As String
	Public _report As String
	Public _relateditem_id As Int32
	Public _relateditem_link As String
	Public _relateditem_desc As String
	Public _collection As String
	Public _setting As String
	Public _anniversary As Boolean
	Public _engagement As Boolean

	Public _s_weight As String
	Public _s_size As String

	Public _jeweltype_sort As String
	Public _metal_sort As String
	Public _middlestone_sort As String
	Public _brand_sort As String
	Public _report_sort As String
	Public _setting_sort As String
    Public _collection_sort As String
    Public _extra_metal As String
    Public _extra_stone As String
    Public _stone_extended As String
    Public se_relateditem_id As Int32
    Public jewel_title As String = ""
    Public jewel_extended As String = ""
    Public jewel_extended_hash As New Hashtable
    Public _jewel_extended As New skl_jewel_extended

	'-- add field for middlestone description

	Sub New()
		Me._size = 0
		Me._weight = 0
		Me._jewelrytype = ""
		Me._jewelrysubtype = ""
		Me._metal = ""
		Me._middlestone = ""
		Me._middlestone_desc = ""
		Me._brand = ""
		Me._report = ""
		Me._collection = ""
		Me._setting = ""
		Me._relateditem_id = 0
		Me._relateditem_desc = ""
		Me._relateditem_link = ""
		Me._anniversary = False
		Me._engagement = False

		Me._s_weight = ""

		Me._jeweltype_sort = ""
		Me._metal_sort = ""
		Me._middlestone_sort = ""
		Me._brand_sort = ""
		Me._report_sort = ""
		Me._setting_sort = ""
		Me._collection_sort = ""
        Me._extra_stone = "None"
        Me._extra_metal = "None"
        Me._stone_extended = "None"
        Me.se_relateditem_id = 0
        Me.jewel_title = ""
    End Sub

   

End Class
