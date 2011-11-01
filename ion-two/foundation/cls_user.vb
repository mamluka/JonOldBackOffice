Public Class cls_user
	Inherits iFoundation.cls_user

	Public _domain As String
	Public _ssldomain As String
    Public _isdealer As Boolean
    Public _firefoxok As Boolean = False
	Public _campaign As String
	Public _affiliate As String
	Public _sorting As cls_defaults_listings
	Public _search As cls_defaults_search
    Public _reject As New ion_two.cls_reject
    Public _currencyID As String = "USD"
    Public _countrySTRING As String = "USA"
    Public _countryID As Int32 = 1
    Public _countryCode As String = "US"
    Public _countryName As String = "USA"
    Public _aweberPopup As Boolean = False




	Sub New()
		Me._domain = ""
		Me._ssldomain = ""
		Me._isdealer = False
		Me._campaign = ""
        Me._affiliate = ""
        Me._firefoxok = False

		'--- get sorting
		Dim oTmpSorting As New cls_defaults_listings
		Me._sorting = oTmpSorting
		oTmpSorting = Nothing

		'--- Get search
		Dim oTmpSearch As New cls_defaults_search
		Me._search = oTmpSearch
		oTmpSearch = Nothing

	End Sub

End Class
