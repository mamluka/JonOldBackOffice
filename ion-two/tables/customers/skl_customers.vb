Public Class skl_customers
	Inherits iFoundation.cls_skelet

	Public _id As Int32
	Public _email As String
	Public _password As String
	Public _firstname As String
	Public _lastname As String
	Public _street1 As String
	Public _city1 As String
	Public _state1_id As Int32
	Public _zip1 As String
	Public _pobox1 As String
	Public _country1_id As Int32
	Public _phone1 As String
	Public _fax1 As String
	Public _street2 As String
	Public _city2 As String
	Public _state2_id As Int32
	Public _zip2 As String
	Public _pobox2 As String
	Public _country2_id As Int32
	Public _phone2 As String
	Public _fax2 As String
	Public _inv_mail As Boolean
	Public _inv_update As Boolean
	Public _lastmodify_date As DateTime
	Public _lastmodify_user As String
	Public _lastmodify_user_id As Int32
	Public _create_date As DateTime
	Public _dealer As Boolean
	Public _b_name As String
	Public _b_street As String
	Public _b_city As String
	Public _b_state_id As Int32
	Public _b_country_id As Int32
	Public _b_pobox As String
	Public _b_zip As String
	Public _b_phone As String
	Public _b_fax As String
	Public _b_tradingass As String
	Public _b_type_id As Int32
	Public _b_siteurl As String
	Public _b_specialization As String
	Public _historical_user As Boolean
	Public _old_id As Int32
	Public _userdeleted As Boolean
	Public _active As Boolean
	Public _prf_srtkey_diamonds As String
	Public _prf_srtkey_gemstones As String
	Public _prf_srtkey_jewelry As String
	Public _prf_srtkey_newitems As String
	Public _prf_srtkey_specials As String
	Public _prf_srtkey_search As String
	Public _prf_list_amount As Decimal
	Public _prf_language_id As Int32
	Public _prf_timesvisited As Int32
	Public _online_message As String
	Public _last_visit As DateTime
	Public _dateofbirth As DateTime
	Public _aid As Int32
	Public _registration_ip As String
    Public _idex_percent As String
    Public _default_currencyID As String = "USD"



	Sub New()
		Me._id = 0
		Me._email = ""
		Me._password = ""
		Me._firstname = ""
		Me._lastname = ""
		Me._street1 = ""
		Me._city1 = ""
		Me._state1_id = 0
		Me._zip1 = ""
		Me._pobox1 = ""
		Me._country1_id = 0
		Me._phone1 = ""
		Me._fax1 = ""
		Me._street2 = ""
		Me._city2 = ""
		Me._state2_id = 0
		Me._zip2 = ""
		Me._pobox2 = ""
		Me._country2_id = 0
		Me._phone2 = ""
		Me._fax2 = ""
		Me._inv_mail = False
		Me._inv_update = False
		Me._lastmodify_date = #1/1/1900#
		Me._lastmodify_user = ""
		Me._lastmodify_user_id = 0
		Me._create_date = #1/1/1900#
		Me._dealer = False
		Me._b_name = ""
		Me._b_street = ""
		Me._b_city = ""
		Me._b_state_id = 0
		Me._b_country_id = 0
		Me._b_pobox = ""
		Me._b_zip = ""
		Me._b_phone = ""
		Me._b_fax = ""
		Me._b_tradingass = ""
		Me._b_type_id = 0
		Me._b_siteurl = ""
		Me._b_specialization = ""
		Me._historical_user = False
		Me._old_id = 0
		Me._active = True
		Me._userdeleted = False
		Me._prf_srtkey_diamonds = ""
		Me._prf_srtkey_gemstones = ""
		Me._prf_srtkey_jewelry = ""
		Me._prf_srtkey_newitems = ""
		Me._prf_srtkey_specials = ""
		Me._prf_srtkey_search = ""
		Me._prf_list_amount = 0
		Me._prf_language_id = 0
		Me._prf_timesvisited = 0
		Me._online_message = ""
		Me._last_visit = #1/1/1900#
		Me._dateofbirth = #1/1/1900#
		Me._aid = 0
		Me._registration_ip = "000.000.000.000"
		Me._idex_percent = 0
	End Sub

End Class
