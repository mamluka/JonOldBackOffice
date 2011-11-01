Public Class cls_defaults_listings

	'--- Item listing
	Public _itemscount As Int16

	Public _diamond_sort As String
	Public _diamond_sortdirection As Int16

	Public _gemstone_sort As String
	Public _gemstone_sortdirection As Int16

	Public _jewelry_sort As String
	Public _jewelry_sortdirection As Int16

	Public _newitems_sort As String
	Public _newitems_sortdirection As Int16

	Public _specials_sort As String
	Public _specials_sortdirection As Int16

	Public _search_sort As String
	Public _search_sortdirection As Int16



	Sub New()
		'--- Item listing
		Me._itemscount = 20

		'--- Sorting default
        Me._diamond_sort = "sell_price"
        Me._diamond_sortdirection = 1

        Me._gemstone_sort = "sell_price"
        Me._gemstone_sortdirection = 1

        Me._jewelry_sort = "sell_price"
        Me._jewelry_sortdirection = 1

		Me._newitems_sort = "platetype, stonetype"
		Me._newitems_sortdirection = 0

		Me._specials_sort = "platetype, stonetype"
		Me._specials_sortdirection = 0

		Me._search_sort = "platetype, stonetype"
		Me._search_sortdirection = 0

	End Sub


End Class
