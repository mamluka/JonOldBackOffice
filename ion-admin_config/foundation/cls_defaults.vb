Public Class cls_defaults

	Public _inv_sellprice As Integer
	Public _inv_dealerprice As Integer
	Public _inv_appraisalprice As Integer
	Public _inv_spc_sellprice As Integer
	Public _inv_spc_dealerprice As Integer
	Public _inv_default_special_date As Integer
	Public _inv_advance_special_date As Integer
	Public _inv_active_special_date As Integer
	Public _inv_default_rows As Integer
	Public _order_packaging As Decimal
	Public _order_registered As Decimal
	Public _order_minforcourier As Decimal
	Public _order_fedexInsurance As Decimal
    Public _order_freeshippingfrom As Decimal
    '--- Interest Calculation
	Public _interest_days As Int16
	Public _interest_percentage As Decimal

	Public _ctg_categories As New Collection
	Public _ctg_pictures_root_path As String

	Sub New()
		'--- Prices calculation in precentage
		Me._inv_sellprice = 150
		Me._inv_dealerprice = 120
		Me._inv_appraisalprice = 420
		Me._inv_spc_sellprice = 130
		Me._inv_spc_dealerprice = 120

		'--- default special-lenght in days
		Me._inv_default_special_date = 14

		'--- how many day can special be added in advance
		Me._inv_advance_special_date = 120

		'--- how long can special be active
		Me._inv_active_special_date = 356

		'--- how many lines in the listing screens
		Me._inv_default_rows = 50

		'--- Server directory leading to the Picture directories
		'Me._ctg_pictures_root_path = cPicDir

		'--- Order
		Me._order_packaging = 6
		Me._order_registered = 14.5
		Me._order_minforcourier = 8000

		'--- Free shipping
		Me._order_freeshippingfrom = 1000
		Me._order_fedexInsurance = 1

		'--- Interest Calculation
		Me._interest_percentage = 7.5
		Me._interest_days = 7

	End Sub

End Class
