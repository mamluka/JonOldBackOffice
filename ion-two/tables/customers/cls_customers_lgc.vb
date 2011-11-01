Public Class cls_customers_lgc
	Inherits iFoundation.cls_logics

	Sub New()
		'--- Set working table
		Me._tablename = "usr_CUSTOMERS"

		'--- Get module name
		Dim oTmpStack As New System.Diagnostics.StackFrame
		Me._module = oTmpStack.GetMethod.ReflectedType.FullName()
		oTmpStack = Nothing

	End Sub

	Function insert(ByRef oDataTable As skl_customers) As Boolean
		On Error GoTo ErrorHandler

		'--- local definitions
		Dim bError As Boolean = False

		'--- Get Dataset
		Dim oTmpDataset As DataSet = New ion_two.ds_customer
		Dim oTmpDataTable As DataTable = oTmpDataset.Tables(_tablename)

		'--- Assign Order
		Dim oTmpDataRow As DataRow
		oTmpDataRow = oTmpDataTable.NewRow

		'oTmpDataRow("id") = oDataTable._id
		oTmpDataRow("email") = oDataTable._email
		oTmpDataRow("password") = oDataTable._password
		oTmpDataRow("firstname") = oDataTable._firstname
		oTmpDataRow("lastname") = oDataTable._lastname
		oTmpDataRow("street1") = oDataTable._street1
		oTmpDataRow("city1") = oDataTable._city1
		oTmpDataRow("state1_id") = oDataTable._state1_id
		oTmpDataRow("zip1") = oDataTable._zip1
		oTmpDataRow("pobox1") = oDataTable._pobox1
		oTmpDataRow("country1_id") = oDataTable._country1_id
		oTmpDataRow("phone1") = oDataTable._phone1
		oTmpDataRow("fax1") = oDataTable._fax1
		oTmpDataRow("street2") = oDataTable._street2
		oTmpDataRow("city2") = oDataTable._city2
		oTmpDataRow("state2_id") = oDataTable._state2_id
		oTmpDataRow("zip2") = oDataTable._zip2
		oTmpDataRow("pobox2") = oDataTable._pobox2
		oTmpDataRow("country2_id") = oDataTable._country2_id
		oTmpDataRow("phone2") = oDataTable._phone2
		oTmpDataRow("fax2") = oDataTable._fax2
		oTmpDataRow("inv_mail") = oDataTable._inv_mail
		oTmpDataRow("inv_update") = oDataTable._inv_update
		oTmpDataRow("create_date") = Date.Now
		oTmpDataRow("active") = oDataTable._active
		oTmpDataRow("dealer") = oDataTable._dealer
		oTmpDataRow("b_name") = oDataTable._b_name
		oTmpDataRow("b_street") = oDataTable._b_street
		oTmpDataRow("b_city") = oDataTable._b_city
		oTmpDataRow("b_state_id") = oDataTable._b_state_id
		oTmpDataRow("b_country_id") = oDataTable._b_country_id
		oTmpDataRow("b_pobox") = oDataTable._b_pobox
		oTmpDataRow("b_zip") = oDataTable._b_zip
		oTmpDataRow("b_phone") = oDataTable._b_phone
		oTmpDataRow("b_fax") = oDataTable._b_fax
		oTmpDataRow("b_tradingass") = oDataTable._b_tradingass
		oTmpDataRow("b_type_id") = oDataTable._b_type_id
		oTmpDataRow("b_siteurl") = oDataTable._b_siteurl
		oTmpDataRow("b_specialization") = oDataTable._b_specialization
		oTmpDataRow("historical_user") = oDataTable._historical_user
		oTmpDataRow("old_id") = oDataTable._old_id
		oTmpDataRow("userdeleted") = oDataTable._userdeleted
		oTmpDataRow("prf_srtkey_diamonds") = oDataTable._prf_srtkey_diamonds
		oTmpDataRow("prf_srtkey_gemstones") = oDataTable._prf_srtkey_gemstones
		oTmpDataRow("prf_srtkey_jewelry") = oDataTable._prf_srtkey_jewelry
		oTmpDataRow("prf_srtkey_newitems") = oDataTable._prf_srtkey_newitems
		oTmpDataRow("prf_srtkey_specials") = oDataTable._prf_srtkey_specials
		oTmpDataRow("prf_srtkey_search") = oDataTable._prf_srtkey_search
		oTmpDataRow("prf_list_amount") = oDataTable._prf_list_amount
		oTmpDataRow("prf_language_id") = oDataTable._prf_language_id
		oTmpDataRow("prf_timesvisited") = 1
		oTmpDataRow("online_message") = oDataTable._online_message
		oTmpDataRow("last_visit") = Now
		oTmpDataRow("dateofbirth") = oDataTable._dateofbirth
		oTmpDataRow("aid") = oDataTable._aid
		oTmpDataRow("registration_ip") = oDataTable._registration_ip
        oTmpDataRow("idex_percent") = oDataTable._idex_percent
        oTmpDataRow("default_currency") = oDataTable._default_currencyID

		'--- Handle Audit
		oTmpDataRow("lastmodify_date") = Date.Now
		oTmpDataRow("lastmodify_user") = Me._user_name
		oTmpDataRow("lastmodify_user_id") = Me._user_id

		oTmpDataTable.Rows.Add(oTmpDataRow)

		'--- Instantiate the Transactor
		Dim oTransactor As New iDac.cls_T_transactor
		oTransactor._connection_string = Me._connection_string
		oTransactor._dbtype = Me._dbtype

		'--- Prepare and load table 1
		Dim oTable1 As New iDac.cls_cll_datatables
		oTable1._datatable = oTmpDataTable
		oTransactor._i_cll_datatables.Add(oTable1)

		'--- Write Table
		bError = oTransactor.transact_insert
		If bError Then
			Me._err_number = oTransactor._err_number
			Me._err_description = oTransactor._err_description
			Me._err_source = oTransactor._err_source
			Return True
		End If

		oTable1 = Nothing
		oTransactor = Nothing

		Return False
		Exit Function

ErrorHandler:
		Me._err_number = Err.Number
		Me._err_description = Err.Description
		Me._err_source = Err.Source
		Return True
	End Function

	Function read(ByVal nId As Int32, ByRef oDataTable As skl_customers) As Boolean
		On Error GoTo ErrorHandler

		'--- local definitions
		Dim bError As Boolean = False

		'--- Get Item
		Dim oReadTransactor As New iDac.cls_T_read
		oReadTransactor._connection_string = Me._connection_string
		oReadTransactor._dbtype = Me._dbtype
		oReadTransactor._tablename = Me._tablename
		bError = oReadTransactor.transact_read(nId)
		If bError Then
			Me._err_number = oReadTransactor._err_number
			Me._err_description = oReadTransactor._err_description
			Me._err_source = oReadTransactor._err_source
			Return True
		End If

		'--- Return Error if no records were fatched
		If oReadTransactor._datatable.Rows.Count = 0 Then
			Err.Raise(7003, Me._module + ":read", "No records fetched.")
		End If

		'--- Map to Skeleton
		Dim oTmpDataRow As DataRow
		oTmpDataRow = oReadTransactor._datatable.Rows(0)

		oDataTable._id = oTmpDataRow("id")
		oDataTable._email = oTmpDataRow("email")
		oDataTable._password = oTmpDataRow("password")
		oDataTable._firstname = oTmpDataRow("firstname")
		oDataTable._lastname = oTmpDataRow("lastname")
		oDataTable._street1 = oTmpDataRow("street1")
		oDataTable._city1 = oTmpDataRow("city1")
		oDataTable._state1_id = oTmpDataRow("state1_id")
		oDataTable._zip1 = oTmpDataRow("zip1")
		oDataTable._pobox1 = oTmpDataRow("pobox1")
		oDataTable._country1_id = oTmpDataRow("country1_id")
		oDataTable._phone1 = oTmpDataRow("phone1")
		oDataTable._fax1 = oTmpDataRow("fax1")
		oDataTable._street2 = oTmpDataRow("street2")
		oDataTable._city2 = oTmpDataRow("city2")
		oDataTable._state2_id = oTmpDataRow("state2_id")
		oDataTable._zip2 = oTmpDataRow("zip2")
		oDataTable._pobox2 = oTmpDataRow("pobox2")
		oDataTable._country2_id = oTmpDataRow("country2_id")
		oDataTable._phone2 = oTmpDataRow("phone2")
		oDataTable._fax2 = oTmpDataRow("fax2")
		oDataTable._inv_mail = oTmpDataRow("inv_mail")
		oDataTable._inv_update = oTmpDataRow("inv_update")
		oDataTable._create_date = oTmpDataRow("create_date")
		oDataTable._active = oTmpDataRow("active")
		oDataTable._dealer = oTmpDataRow("dealer")
		oDataTable._b_name = oTmpDataRow("b_name")
		oDataTable._b_street = oTmpDataRow("b_street")
		oDataTable._b_city = oTmpDataRow("b_city")
		oDataTable._b_state_id = oTmpDataRow("b_state_id")
		oDataTable._b_country_id = oTmpDataRow("b_country_id")
		oDataTable._b_pobox = oTmpDataRow("b_pobox")
		oDataTable._b_zip = oTmpDataRow("b_zip")
		oDataTable._b_phone = oTmpDataRow("b_phone")
		oDataTable._b_fax = oTmpDataRow("b_fax")
		oDataTable._b_tradingass = oTmpDataRow("b_tradingass")
		oDataTable._b_type_id = oTmpDataRow("b_type_id")
		oDataTable._b_siteurl = oTmpDataRow("b_siteurl")
		oDataTable._b_specialization = oTmpDataRow("b_specialization")
		oDataTable._historical_user = oTmpDataRow("historical_user")
		oDataTable._old_id = oTmpDataRow("old_id")
		oDataTable._userdeleted = oTmpDataRow("userdeleted")
		oDataTable._prf_srtkey_diamonds = oTmpDataRow("prf_srtkey_diamonds")
		oDataTable._prf_srtkey_gemstones = oTmpDataRow("prf_srtkey_gemstones")
		oDataTable._prf_srtkey_jewelry = oTmpDataRow("prf_srtkey_jewelry")
		oDataTable._prf_srtkey_newitems = oTmpDataRow("prf_srtkey_newitems")
		oDataTable._prf_srtkey_specials = oTmpDataRow("prf_srtkey_specials")
		oDataTable._prf_srtkey_search = oTmpDataRow("prf_srtkey_search")
		oDataTable._prf_list_amount = oTmpDataRow("prf_list_amount")
		oDataTable._prf_language_id = oTmpDataRow("prf_language_id")
		oDataTable._prf_timesvisited = oTmpDataRow("prf_timesvisited")
		oDataTable._online_message = oTmpDataRow("online_message")
		oDataTable._last_visit = oTmpDataRow("last_visit")
		oDataTable._dateofbirth = oTmpDataRow("dateofbirth")
		oDataTable._aid = oTmpDataRow("aid")
		oDataTable._lastmodify_date = oTmpDataRow("lastmodify_date")
		oDataTable._lastmodify_user = oTmpDataRow("lastmodify_user")
		oDataTable._lastmodify_user_id = oTmpDataRow("lastmodify_user_id")
		oDataTable._registration_ip = oTmpDataRow("registration_ip")
        oDataTable._idex_percent = oTmpDataRow("idex_percent")
        oDataTable._default_currencyID = oTmpDataRow("default_currency")

		'--- cleanup
		oTmpDataRow = Nothing

		Return False
		Exit Function

ErrorHandler:
		Me._err_number = Err.Number
		Me._err_description = Err.Description
		Me._err_source = Err.Source
		Return True
	End Function

	Function update(ByRef oDataTable As skl_customers) As Boolean
		On Error GoTo ErrorHandler

		'--- local definitions
		Dim bError As Boolean = False

		'--- CUSTOM ERROR: Return Error if ID not passed in skeleton
		If oDataTable._id <= 0 Then
			Err.Raise(7006, Me._module + ":update", "No ID passed with skeleton.")
		End If

		Dim oTmpTransact As New iDac.cls_T_read
		oTmpTransact._connection_string = Me._connection_string
		oTmpTransact._dbtype = Me._dbtype
		oTmpTransact._tablename = Me._tablename
		bError = oTmpTransact.transact_read(oDataTable._id)
		If bError Then
			Me._err_number = oTmpTransact._err_number
			Me._err_description = oTmpTransact._err_description
			Me._err_source = oTmpTransact._err_source
			Return True
		End If

		'--- Get Dataset
		Dim oTmpDataTable As DataTable = oTmpTransact._datatable

		'--- Assign Order
		Dim oTmpDataRow As DataRow
		oTmpDataRow = oTmpDataTable.Rows(0)

		'oTmpDataRow("id") = oDataTable._id
		oTmpDataRow("email") = oDataTable._email
		oTmpDataRow("password") = oDataTable._password
		oTmpDataRow("firstname") = oDataTable._firstname
		oTmpDataRow("lastname") = oDataTable._lastname
		oTmpDataRow("street1") = oDataTable._street1
		oTmpDataRow("city1") = oDataTable._city1
		oTmpDataRow("state1_id") = oDataTable._state1_id
		oTmpDataRow("zip1") = oDataTable._zip1
		oTmpDataRow("pobox1") = oDataTable._pobox1
		oTmpDataRow("country1_id") = oDataTable._country1_id
		oTmpDataRow("phone1") = oDataTable._phone1
		oTmpDataRow("fax1") = oDataTable._fax1
		oTmpDataRow("street2") = oDataTable._street2
		oTmpDataRow("city2") = oDataTable._city2
		oTmpDataRow("state2_id") = oDataTable._state2_id
		oTmpDataRow("zip2") = oDataTable._zip2
		oTmpDataRow("pobox2") = oDataTable._pobox2
		oTmpDataRow("country2_id") = oDataTable._country2_id
		oTmpDataRow("phone2") = oDataTable._phone2
		oTmpDataRow("fax2") = oDataTable._fax2
		oTmpDataRow("inv_mail") = oDataTable._inv_mail
		oTmpDataRow("inv_update") = oDataTable._inv_update
		oTmpDataRow("create_date") = oDataTable._create_date
		oTmpDataRow("active") = oDataTable._active
		oTmpDataRow("dealer") = oDataTable._dealer
		oTmpDataRow("b_name") = oDataTable._b_name
		oTmpDataRow("b_street") = oDataTable._b_street
		oTmpDataRow("b_city") = oDataTable._b_city
		oTmpDataRow("b_state_id") = oDataTable._b_state_id
		oTmpDataRow("b_country_id") = oDataTable._b_country_id
		oTmpDataRow("b_pobox") = oDataTable._b_pobox
		oTmpDataRow("b_zip") = oDataTable._b_zip
		oTmpDataRow("b_phone") = oDataTable._b_phone
		oTmpDataRow("b_fax") = oDataTable._b_fax
		oTmpDataRow("b_tradingass") = oDataTable._b_tradingass
		oTmpDataRow("b_type_id") = oDataTable._b_type_id
		oTmpDataRow("b_siteurl") = oDataTable._b_siteurl
		oTmpDataRow("b_specialization") = oDataTable._b_specialization
		oTmpDataRow("historical_user") = oDataTable._historical_user
		oTmpDataRow("old_id") = oDataTable._old_id
		oTmpDataRow("userdeleted") = oDataTable._userdeleted
		oTmpDataRow("prf_srtkey_diamonds") = oDataTable._prf_srtkey_diamonds
		oTmpDataRow("prf_srtkey_gemstones") = oDataTable._prf_srtkey_gemstones
		oTmpDataRow("prf_srtkey_jewelry") = oDataTable._prf_srtkey_jewelry
		oTmpDataRow("prf_srtkey_newitems") = oDataTable._prf_srtkey_newitems
		oTmpDataRow("prf_srtkey_specials") = oDataTable._prf_srtkey_specials
		oTmpDataRow("prf_srtkey_search") = oDataTable._prf_srtkey_search
		oTmpDataRow("prf_list_amount") = oDataTable._prf_list_amount
		oTmpDataRow("prf_language_id") = oDataTable._prf_language_id
		oTmpDataRow("prf_timesvisited") = oDataTable._prf_timesvisited
		oTmpDataRow("online_message") = oDataTable._online_message
		oTmpDataRow("last_visit") = oDataTable._last_visit
		oTmpDataRow("dateofbirth") = oDataTable._dateofbirth
		oTmpDataRow("aid") = oDataTable._aid
		oTmpDataRow("registration_ip") = oDataTable._registration_ip
        oTmpDataRow("idex_percent") = oDataTable._idex_percent
        oTmpDataRow("default_currency") = oDataTable._default_currencyID

		'--- Handle Audit
		oTmpDataRow("lastmodify_date") = Date.Now
		oTmpDataRow("lastmodify_user") = Me._user_name
		oTmpDataRow("lastmodify_user_id") = Me._user_id


		'--- Instantiate the Transactor
		Dim oTransactor As New iDac.cls_T_transactor
		oTransactor._connection_string = Me._connection_string
		oTransactor._dbtype = Me._dbtype

		'--- Prepare and load table 1
		Dim oTable1 As New iDac.cls_cll_datatables
		oTable1._datatable = oTmpDataTable
		oTransactor._i_cll_datatables.Add(oTable1)

		bError = oTransactor.transact_update
		If bError Then
			Me._err_number = oTransactor._err_number
			Me._err_description = oTransactor._err_description
			Me._err_source = oTransactor._err_source
			Return True
		End If

		oTable1 = Nothing
		oTransactor = Nothing

		Return False
		Exit Function

ErrorHandler:
		Me._err_number = Err.Number
		Me._err_description = Err.Description
		Me._err_source = Err.Source
		Return True

	End Function

End Class
