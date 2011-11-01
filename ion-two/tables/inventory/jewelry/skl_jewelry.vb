Public Class skl_jewelry
	Inherits iFoundation.cls_skelet

	Public _id As Int32
	Public _inventory_id As Int32
    Public _size As String
	Public _weight As Decimal
	Public _jewelrytype_id As Int32
	Public _jewelrysubtype_id As Int32
	Public _metal_id As Int32
	Public _middlestone_id As Int32
	Public _middlestone_desc As String
	Public _brand_id As Int32
	Public _report_id As Int32
	Public _relateditem_id As Int32
	Public _collection_id As Int32
	Public _setting_id As Int32
	Public _anniversary As Boolean
    Public _engagement As Boolean
    Public _extra_metal As String
    Public _extra_stone As String
    Public _stone_extended As String
    Public se_relateditem_id As Int32
    Public jewel_title As String = ""
    Public _jewel_extended As New skl_jewel_extended
    Public jewel_extended As String



	Sub New()
		Me._id = 0
		Me._inventory_id = 0
		Me._size = 0
		Me._weight = 0
		Me._jewelrytype_id = 0
		Me._jewelrysubtype_id = 0
		Me._metal_id = 0
		Me._middlestone_id = 0
		Me._middlestone_desc = ""
		Me._brand_id = 0
		Me._report_id = 0
		Me._collection_id = 0
		Me._setting_id = 0
		Me._relateditem_id = 0
		Me._anniversary = False
		Me._engagement = False
        Me._extra_metal = "None"
        Me._extra_stone = "None"
        Me._stone_extended = "None"
    End Sub


    


End Class

