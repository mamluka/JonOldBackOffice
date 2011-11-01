Public Class cls_customer_lgc

    Private m_error_no As Integer
    Private m_error_desc As String
    Private m_error_source As String
    Private m_connection_string As String
    Private m_customer_id As Int32

	Function insert_customer(ByRef oCustomer As cls_customer) As Boolean
		'On Error GoTo ErrorHandler

		'--- local definitions
		Dim bError As Boolean = False

		'--- Get Dataset
		Dim oTmpDataset As DataSet = New ion_resources.ds_customers
		Dim oTmpPayments As DataTable = oTmpDataset.Tables("usr_CUSTOMERS")

		'--- Assign Order
		Dim oTmpDataRow As DataRow
		oTmpDataRow = oTmpPayments.NewRow

		'oTmpDataRow("id") = 1
		oTmpDataRow("email") = System.Convert.ToString(oCustomer.email)
		oTmpDataRow("password") = System.Convert.ToString(oCustomer.password)
		oTmpDataRow("firstname") = System.Convert.ToString(oCustomer.firstname)
		oTmpDataRow("lastname") = System.Convert.ToString(oCustomer.lastname)
		oTmpDataRow("street1") = System.Convert.ToString(oCustomer.street1)
		oTmpDataRow("city1") = System.Convert.ToString(oCustomer.city1)
		oTmpDataRow("state1_id") = System.Convert.ToInt32(oCustomer.state1_id)
		oTmpDataRow("zip1") = System.Convert.ToString(oCustomer.zip1)
		oTmpDataRow("pobox1") = System.Convert.ToString(oCustomer.pobox1)
		oTmpDataRow("country1_id") = System.Convert.ToInt32(oCustomer.country1_id)
		oTmpDataRow("phone1") = System.Convert.ToString(oCustomer.phone1)
		oTmpDataRow("fax1") = System.Convert.ToString(oCustomer.fax1)
		oTmpDataRow("street2") = System.Convert.ToString(oCustomer.street2)
		oTmpDataRow("city2") = System.Convert.ToString(oCustomer.city2)
		oTmpDataRow("state2_id") = System.Convert.ToInt32(oCustomer.state2_id)
		oTmpDataRow("zip2") = System.Convert.ToString(oCustomer.zip2)
		oTmpDataRow("pobox2") = System.Convert.ToString(oCustomer.pobox2)
		oTmpDataRow("country2_id") = System.Convert.ToInt32(oCustomer.country2_id)
		oTmpDataRow("phone2") = System.Convert.ToString(oCustomer.phone2)
		oTmpDataRow("fax2") = System.Convert.ToString(oCustomer.fax2)
		oTmpDataRow("inv_mail") = System.Convert.ToBoolean(oCustomer.inv_mail)
		oTmpDataRow("inv_update") = System.Convert.ToBoolean(oCustomer.inv_update)
		oTmpDataRow("lastmodify_date") = System.Convert.ToDateTime(oCustomer.lastmodify_date)
		oTmpDataRow("lastmodify_user") = System.Convert.ToString(oCustomer.lastmodify_user)
		oTmpDataRow("lastmodify_user_id") = System.Convert.ToInt32(oCustomer.lastmodify_user_id)
		oTmpDataRow("create_date") = Date.Now		'--System.Convert.ToDateTime(oCustomer.create_date)
		oTmpDataRow("active") = System.Convert.ToBoolean(oCustomer.active)
		oTmpDataRow("dealer") = System.Convert.ToBoolean(oCustomer.dealer)
		oTmpDataRow("b_name") = System.Convert.ToString(oCustomer.bname)
		oTmpDataRow("b_street") = System.Convert.ToString(oCustomer.bstreet)
		oTmpDataRow("b_city") = System.Convert.ToString(oCustomer.bcity)
		oTmpDataRow("b_state_id") = System.Convert.ToInt32(oCustomer.bstate_id)
		oTmpDataRow("b_country_id") = System.Convert.ToInt32(oCustomer.bcountry_id)
		oTmpDataRow("b_pobox") = System.Convert.ToString(oCustomer.bpobox)
		oTmpDataRow("b_zip") = System.Convert.ToString(oCustomer.bzip)
		oTmpDataRow("b_phone") = System.Convert.ToString(oCustomer.bphone)
		oTmpDataRow("b_fax") = System.Convert.ToString(oCustomer.bfax)
		oTmpDataRow("b_tradingass") = System.Convert.ToString(oCustomer.btradingass)
		oTmpDataRow("b_type_id") = System.Convert.ToInt32(oCustomer.btype_id)
		oTmpDataRow("b_siteurl") = System.Convert.ToString(oCustomer.bsiteurl)
		oTmpDataRow("b_specialization") = System.Convert.ToString(oCustomer.bspecialization)
		oTmpDataRow("historical_user") = oCustomer.historical_user
		oTmpDataRow("old_id") = System.Convert.ToInt32(oCustomer.old_id)
		oTmpDataRow("userdeleted") = System.Convert.ToBoolean(oCustomer.userdeleted)
		oTmpDataRow("prf_srtkey_diamonds") = System.Convert.ToString(oCustomer.prf_strkey_diamonds)
		oTmpDataRow("prf_srtkey_gemstones") = System.Convert.ToString(oCustomer.prf_strkey_gemstones)
		oTmpDataRow("prf_srtkey_jewelry") = System.Convert.ToString(oCustomer.prf_strkey_jewelry)
		oTmpDataRow("prf_srtkey_newitems") = System.Convert.ToString(oCustomer.prf_strkey_newitems)
		oTmpDataRow("prf_srtkey_specials") = System.Convert.ToString(oCustomer.prf_strkey_specials)
		oTmpDataRow("prf_srtkey_search") = System.Convert.ToString(oCustomer.prf_strkey_search)
		oTmpDataRow("prf_list_amount") = System.Convert.ToInt64(oCustomer.prf_list_amount)
		oTmpDataRow("prf_language_id") = System.Convert.ToInt32(oCustomer.prf_language_id)
		oTmpDataRow("prf_timesvisited") = System.Convert.ToInt64(oCustomer.prf_timesvisited)
		oTmpDataRow("online_message") = System.Convert.ToString(oCustomer.online_message)
		oTmpDataRow("last_visit") = System.Convert.ToDateTime(oCustomer.last_visit)
		oTmpDataRow("dateofbirth") = System.Convert.ToDateTime(oCustomer.dateofbirth)
		oTmpDataRow("aid") = System.Convert.ToInt32(oCustomer.aid)
		oTmpDataRow("registration_ip") = System.Convert.ToString(oCustomer.registration_ip)
		oTmpDataRow("idex_percent") = System.Convert.ToInt16(oCustomer.idex_percent)
		oTmpPayments.Rows.Add(oTmpDataRow)

		'--- define system object
		Dim oSystem As ion_resources.cls_system = New ion_resources.cls_system
		oSystem.connection_string = Me.connection_string
		oSystem.dataset = oTmpDataset

		Dim oTmpBroker As New ion_resources.cls_customer_brk
		bError = oTmpBroker.insert_customer(oSystem)
		If bError Then
			Me.error_no = oSystem.error_no
			Me.error_desc = oSystem.error_desc
			Me.error_source = oSystem.error_source
			Return True
			Exit Function
		End If

		'--- Receive 
		Me.customer_id = oTmpBroker.customer_id

		oTmpBroker = Nothing
		oSystem = Nothing

		Return False
		Exit Function

ErrorHandler:
		Me.error_no = Err.Number
		Me.error_desc = Err.Description
		Me.error_source = Err.Source
		Return True

	End Function

	Function get_customer(ByVal nCustomerId As Int32, ByRef oCustomer As cls_customer) As Boolean
		'On Error GoTo ErrorHandler

		'--- local definitions
		Dim bError As Boolean = False

		'--- define system object
		Dim oSystem As ion_resources.cls_system = New ion_resources.cls_system
		oSystem.connection_string = Me.connection_string
		oSystem.dataset = New ion_resources.ds_customers


		Dim oTmpBroker As New ion_resources.cls_customer_brk
		bError = oTmpBroker.get_customer(nCustomerId, oSystem)
		If bError Then
			Me.error_no = oSystem.error_no
			Me.error_desc = oSystem.error_desc
			Me.error_source = oSystem.error_source
			Return True
			Exit Function
		End If

		oCustomer.customer_dataset = oSystem.dataset
		Dim oCustomers As DataTable = oSystem.dataset.Tables("usr_CUSTOMERS")

		'--- Current Record
		Dim oCustomer_record As DataRow = oCustomers.Rows(0)

		oCustomer.id = oCustomer_record("id")
		oCustomer.email = oCustomer_record("email")
		oCustomer.password = oCustomer_record("password")
		oCustomer.firstname = oCustomer_record("firstname")
		oCustomer.lastname = oCustomer_record("lastname")
		oCustomer.street1 = oCustomer_record("street1")
		oCustomer.city1 = oCustomer_record("city1")
		oCustomer.state1_id = oCustomer_record("state1_id")
		oCustomer.zip1 = oCustomer_record("zip1")
		oCustomer.pobox1 = oCustomer_record("pobox1")
		oCustomer.country1_id = oCustomer_record("country1_id")
		oCustomer.phone1 = oCustomer_record("phone1")
		oCustomer.fax1 = oCustomer_record("fax1")
		oCustomer.street2 = oCustomer_record("street2")
		oCustomer.city2 = oCustomer_record("city2")
		oCustomer.state2_id = oCustomer_record("state2_id")
		oCustomer.zip2 = oCustomer_record("zip2")
		oCustomer.pobox2 = oCustomer_record("pobox2")
		oCustomer.country2_id = oCustomer_record("country2_id")
		oCustomer.phone2 = oCustomer_record("phone2")
		oCustomer.fax2 = oCustomer_record("fax2")
		oCustomer.inv_mail = oCustomer_record("inv_mail")
		oCustomer.inv_update = oCustomer_record("inv_update")
		oCustomer.lastmodify_date = oCustomer_record("lastmodify_date")
		oCustomer.lastmodify_user = oCustomer_record("lastmodify_user")
		oCustomer.lastmodify_user_id = oCustomer_record("lastmodify_user_id")
		oCustomer.create_date = oCustomer_record("create_date")
		oCustomer.active = oCustomer_record("active")
		oCustomer.dealer = oCustomer_record("dealer")
		oCustomer.bname = oCustomer_record("b_name")
		oCustomer.bstreet = oCustomer_record("b_street")
		oCustomer.bcity = oCustomer_record("b_city")
		oCustomer.bstate_id = oCustomer_record("b_state_id")
		oCustomer.bcountry_id = oCustomer_record("b_country_id")
		oCustomer.bpobox = oCustomer_record("b_pobox")
		oCustomer.bzip = oCustomer_record("b_zip")
		oCustomer.bphone = oCustomer_record("b_phone")
		oCustomer.bfax = oCustomer_record("b_fax")
		oCustomer.btradingass = oCustomer_record("b_tradingass")
		oCustomer.btype_id = oCustomer_record("b_type_id")
		oCustomer.bsiteurl = oCustomer_record("b_siteurl")
		oCustomer.bspecialization = oCustomer_record("b_specialization")
		oCustomer.historical_user = oCustomer_record("historical_user")
		oCustomer.old_id = oCustomer_record("old_id")
		oCustomer.userdeleted = oCustomer_record("userdeleted")
		oCustomer.prf_strkey_diamonds = oCustomer_record("prf_srtkey_diamonds")
		oCustomer.prf_strkey_gemstones = oCustomer_record("prf_srtkey_gemstones")
		oCustomer.prf_strkey_jewelry = oCustomer_record("prf_srtkey_jewelry")
		oCustomer.prf_strkey_newitems = oCustomer_record("prf_srtkey_newitems")
		oCustomer.prf_strkey_specials = oCustomer_record("prf_srtkey_specials")
		oCustomer.prf_strkey_search = oCustomer_record("prf_srtkey_search")
		oCustomer.prf_list_amount = oCustomer_record("prf_list_amount")
		oCustomer.prf_language_id = oCustomer_record("prf_language_id")
		oCustomer.prf_timesvisited = oCustomer_record("prf_timesvisited")
		oCustomer.online_message = oCustomer_record("online_message")
		oCustomer.last_visit = oCustomer_record("last_visit")
		oCustomer.dateofbirth = oCustomer_record("dateofbirth")
		oCustomer.aid = oCustomer_record("aid")
		oCustomer.registration_ip = oCustomer_record("registration_ip")
		oCustomer.idex_percent = oCustomer_record("idex_percent")
		Return False
		Exit Function

ErrorHandler:
		Me.error_no = Err.Number
		Me.error_desc = Err.Description
		Me.error_source = Err.Source
		Return True

	End Function

	Function update_customer(ByRef oCustomer As cls_customer) As Boolean
		On Error GoTo ErrorHandler

		'--- local definitions
		Dim bError As Boolean = False

		'--- Get Dataset
		Dim oTmpDataset As DataSet = oCustomer.customer_dataset
		Dim oTmpCustomers As DataTable = oTmpDataset.Tables("usr_CUSTOMERS")


		'--- Assign Order
		Dim oTmpDataRow As DataRow
		oTmpDataRow = oTmpCustomers.Rows(0)

		'oTmpDataRow("id") = 1
		oTmpDataRow("email") = System.Convert.ToString(oCustomer.email)
		oTmpDataRow("password") = System.Convert.ToString(oCustomer.password)
		oTmpDataRow("firstname") = System.Convert.ToString(oCustomer.firstname)
		oTmpDataRow("lastname") = System.Convert.ToString(oCustomer.lastname)
		oTmpDataRow("street1") = System.Convert.ToString(oCustomer.street1)
		oTmpDataRow("city1") = System.Convert.ToString(oCustomer.city1)
		oTmpDataRow("state1_id") = System.Convert.ToInt32(oCustomer.state1_id)
		oTmpDataRow("zip1") = System.Convert.ToString(oCustomer.zip1)
		oTmpDataRow("pobox1") = System.Convert.ToString(oCustomer.pobox1)
		oTmpDataRow("country1_id") = System.Convert.ToInt32(oCustomer.country1_id)
		oTmpDataRow("phone1") = System.Convert.ToString(oCustomer.phone1)
		oTmpDataRow("fax1") = System.Convert.ToString(oCustomer.fax1)
		oTmpDataRow("street2") = System.Convert.ToString(oCustomer.street2)
		oTmpDataRow("city2") = System.Convert.ToString(oCustomer.city2)
		oTmpDataRow("state2_id") = System.Convert.ToInt32(oCustomer.state2_id)
		oTmpDataRow("zip2") = System.Convert.ToString(oCustomer.zip2)
		oTmpDataRow("pobox2") = System.Convert.ToString(oCustomer.pobox2)
		oTmpDataRow("country2_id") = System.Convert.ToInt32(oCustomer.country2_id)
		oTmpDataRow("phone2") = System.Convert.ToString(oCustomer.phone2)
		oTmpDataRow("fax2") = System.Convert.ToString(oCustomer.fax2)
		oTmpDataRow("inv_mail") = System.Convert.ToBoolean(oCustomer.inv_mail)
		oTmpDataRow("inv_update") = System.Convert.ToBoolean(oCustomer.inv_update)
		oTmpDataRow("lastmodify_date") = System.Convert.ToDateTime(oCustomer.lastmodify_date)
		oTmpDataRow("lastmodify_user") = System.Convert.ToString(oCustomer.lastmodify_user)
		oTmpDataRow("lastmodify_user_id") = System.Convert.ToInt32(oCustomer.lastmodify_user_id)
		oTmpDataRow("create_date") = System.Convert.ToDateTime(oCustomer.create_date)
		oTmpDataRow("active") = System.Convert.ToBoolean(oCustomer.active)
		oTmpDataRow("dealer") = System.Convert.ToBoolean(oCustomer.dealer)
		oTmpDataRow("b_name") = System.Convert.ToString(oCustomer.bname)
		oTmpDataRow("b_street") = System.Convert.ToString(oCustomer.bstreet)
		oTmpDataRow("b_city") = System.Convert.ToString(oCustomer.bcity)
		oTmpDataRow("b_state_id") = System.Convert.ToInt32(oCustomer.bstate_id)
		oTmpDataRow("b_country_id") = System.Convert.ToInt32(oCustomer.bcountry_id)
		oTmpDataRow("b_pobox") = System.Convert.ToString(oCustomer.bpobox)
		oTmpDataRow("b_zip") = System.Convert.ToString(oCustomer.bzip)
		oTmpDataRow("b_phone") = System.Convert.ToString(oCustomer.bphone)
		oTmpDataRow("b_fax") = System.Convert.ToString(oCustomer.bfax)
		oTmpDataRow("b_tradingass") = System.Convert.ToString(oCustomer.btradingass)
		oTmpDataRow("b_type_id") = System.Convert.ToInt32(oCustomer.btype_id)
		oTmpDataRow("b_siteurl") = System.Convert.ToString(oCustomer.bsiteurl)
		oTmpDataRow("b_specialization") = System.Convert.ToString(oCustomer.bspecialization)
		oTmpDataRow("historical_user") = oCustomer.historical_user
		oTmpDataRow("old_id") = System.Convert.ToInt32(oCustomer.old_id)
		oTmpDataRow("userdeleted") = System.Convert.ToBoolean(oCustomer.userdeleted)
		oTmpDataRow("prf_srtkey_diamonds") = System.Convert.ToString(oCustomer.prf_strkey_diamonds)
		oTmpDataRow("prf_srtkey_gemstones") = System.Convert.ToString(oCustomer.prf_strkey_gemstones)
		oTmpDataRow("prf_srtkey_jewelry") = System.Convert.ToString(oCustomer.prf_strkey_jewelry)
		oTmpDataRow("prf_srtkey_newitems") = System.Convert.ToString(oCustomer.prf_strkey_newitems)
		oTmpDataRow("prf_srtkey_specials") = System.Convert.ToString(oCustomer.prf_strkey_specials)
		oTmpDataRow("prf_srtkey_search") = System.Convert.ToString(oCustomer.prf_strkey_search)
		oTmpDataRow("prf_list_amount") = System.Convert.ToInt64(oCustomer.prf_list_amount)
		oTmpDataRow("prf_language_id") = System.Convert.ToInt32(oCustomer.prf_language_id)
		oTmpDataRow("prf_timesvisited") = System.Convert.ToInt64(oCustomer.prf_timesvisited)
		oTmpDataRow("online_message") = System.Convert.ToString(oCustomer.online_message)
		oTmpDataRow("last_visit") = System.Convert.ToDateTime(oCustomer.last_visit)
		oTmpDataRow("dateofbirth") = System.Convert.ToDateTime(oCustomer.dateofbirth)
		oTmpDataRow("aid") = System.Convert.ToInt32(oCustomer.aid)
		oTmpDataRow("registration_ip") = System.Convert.ToString(oCustomer.registration_ip)
		oTmpDataRow("idex_percent") = System.Convert.ToInt16(oCustomer.idex_percent)

		'--- define system object
		Dim oSystem As ion_resources.cls_system = New ion_resources.cls_system
		oSystem.connection_string = Me.connection_string
		oSystem.dataset = oTmpDataset

		Dim oTmpBroker As New ion_resources.cls_customer_brk
		oTmpBroker.customer_id = oCustomer.id
		bError = oTmpBroker.update_customer(oSystem)
		If bError Then
			Me.error_no = oSystem.error_no
			Me.error_desc = oSystem.error_desc
			Me.error_source = oSystem.error_source
			Return True
			Exit Function
		End If

		'--- Receive 
		Me.customer_id = oTmpBroker.customer_id


		oTmpBroker = Nothing
		oSystem = Nothing


		Return False
		Exit Function

ErrorHandler:
		Me.error_no = Err.Number
		Me.error_desc = Err.Description
		Me.error_source = Err.Source
		Return True

	End Function



	Public Property error_no() As Integer
		Get
			Return m_error_no
		End Get

		Set(ByVal Value As Integer)
			m_error_no = Value
		End Set
	End Property

	Public Property error_desc() As String
		Get
			Return m_error_desc
		End Get

		Set(ByVal Value As String)
			m_error_desc = Value
		End Set
	End Property

	Public Property error_source() As String
		Get
			Return m_error_source
		End Get

		Set(ByVal Value As String)
			m_error_source = Value
		End Set
	End Property

	Public Property connection_string() As String
		Get
			Return m_connection_string
		End Get

		Set(ByVal Value As String)
			m_connection_string = Value
		End Set
	End Property

	Public Property customer_id() As Int32
		Get
			Return m_customer_id
		End Get

		Set(ByVal Value As Int32)
			m_customer_id = Value
		End Set
	End Property


End Class
