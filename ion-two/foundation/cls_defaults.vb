Public Class cls_defaults


	'--- Cart settings
	Public _cart_minimum As Decimal

	'--- Checkout settings
	Public _order_packaging As Decimal
	Public _order_registered As Decimal
	Public _order_minforcourier As Decimal
	Public _order_freeshippingfrom As Decimal
	Public _order_fedexindurenceperc As Decimal
	Public _order_minpayperc As Decimal
	Public _order_maxpayment As Decimal
	Public _order_minpayment As Decimal
	Public _order_waitforonlineconfirm As Boolean

	'--- Search settings
	Public _search_measure_accurcy As Decimal
	Public _search_weight_accuracy As Decimal

	'--- Interest Calculation
	Public _interest_perc As Decimal
	Public _interest_days As Int16

	'--- Sorting defaults
    Public _sorting As cls_defaults_listings

	'--- Search defaults
    Public _search As cls_defaults_search

	Sub New()

		'--- Cart settings
		Me._cart_minimum = 50

		'###--- Checkout settings
		'--- Packaging amount
		Me._order_packaging = 6
		'--- Registered mail amount
        Me._order_registered = 14.5
		'--- Minimal amount to be able to requet courier mail
        Me._order_minforcourier = 4000
		'--- Free shipping
		Me._order_freeshippingfrom = 1000
		'--- FedEx insurence percentage
		Me._order_fedexindurenceperc = 1
		'--- Minimal down-payment to be able to checkout - LAYAWAY
		Me._order_minpayperc = 10
		'--- Minimal and Maximal amount to checkout
		Me._order_minpayment = 50
		Me._order_maxpayment = 3000
		'--- Wait for online software to confirm the payment
		Me._order_waitforonlineconfirm = False

		'--- Interest Calculation
		Me._interest_perc = 0.06
		Me._interest_days = 90

		'--- Search Parameters
        Me._search_measure_accurcy = 0.5  '-- Millimeters
		Me._search_weight_accuracy = 0.1		'-- Carat

		'--- get sorting
		Dim oTmpsorting As New cls_defaults_listings
		Me._sorting = oTmpsorting
        oTmpsorting = Nothing

        Dim oTmpsearch As New cls_defaults_search
        Me._search = oTmpsearch
        oTmpsorting = Nothing

	End Sub



End Class
