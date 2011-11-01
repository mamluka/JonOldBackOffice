Public Class cls_customer

    Private m_customer_dataset As DataSet

    Private m_id As Int32
    Private m_email As String
    Private m_password As String
    Private m_firstname As String
    Private m_lastname As String
    Private m_street1 As String
    Private m_city1 As String
    Private m_state1_id As Int32
    Private m_country1_id As Int32
    Private m_zip1 As String
    Private m_pobox1 As String
    Private m_phone1 As String
    Private m_fax1 As String
    Private m_street2 As String
    Private m_city2 As String
    Private m_state2_id As Int32
    Private m_country2_id As Int32
    Private m_zip2 As String
    Private m_pobox2 As String
    Private m_phone2 As String
    Private m_fax2 As String
    Private m_inv_mail As Boolean
    Private m_inv_update As Boolean
    Private m_create_date As DateTime
    Private m_active As Boolean
    Private m_dealer As Boolean
    Private m_bname As String
    Private m_bstreet As String
    Private m_bcity As String
    Private m_bstate_id As Int32
    Private m_bcountry_id As Int32
    Private m_bpobox As String
    Private m_bzip As String
    Private m_bphone As String
    Private m_bfax As String
    Private m_btradingass As String
    Private m_btype_id As Int32
    Private m_bsiteurl As String
    Private m_bspecialization As String
    Private m_historical_user As Boolean
    Private m_old_id As Int32
    Private m_userdeleted As Boolean
    Private m_prf_strkey_diamonds As String
    Private m_prf_strkey_gemstones As String
    Private m_prf_strkey_jewelry As String
    Private m_prf_strkey_newitems As String
    Private m_prf_strkey_specials As String
    Private m_prf_strkey_search As String
    Private m_prf_list_amount As Int64
    Private m_prf_language_id As Int32
    Private m_prf_timesvisited As Int64
    Private m_online_message As String
    Private m_last_visit As DateTime
    Private m_dateofbirth As DateTime
    Private m_aid As Int32
    Private m_lastmodify_user As String
    Private m_lastmodify_user_id As Int32
	Private m_lastmodify_date As DateTime
	Private m_registration_ip As String
	Private m_idex_percent As Int16


    Sub New()
        Me.id = 0
        Me.email = ""
        Me.firstname = ""
        Me.lastname = ""
        Me.street1 = ""
        Me.city1 = ""
        Me.state1_id = 0
        Me.zip1 = ""
        Me.pobox1 = ""
        Me.country1_id = 0
        Me.phone1 = ""
        Me.fax1 = ""
        Me.street2 = ""
        Me.city2 = ""
        Me.state2_id = 0
        Me.zip2 = ""
        Me.pobox2 = ""
        Me.country2_id = 0
        Me.phone2 = ""
        Me.fax2 = ""
        Me.inv_mail = False
        Me.inv_update = False
        Me.lastmodify_date = #1/1/1900#
        Me.lastmodify_user = ""
        Me.lastmodify_user_id = 0
        Me.create_date = #1/1/1900#
        Me.active = False
        Me.dealer = False
        Me.bname = ""
        Me.bstreet = ""
        Me.bcity = ""
        Me.bstate_id = 0
        Me.bcountry_id = 0
        Me.bpobox = ""
        Me.bzip = ""
        Me.bphone = ""
        Me.bfax = ""
        Me.btradingass = ""
        Me.btype_id = 0
        Me.bsiteurl = ""
        Me.bspecialization = ""
        Me.historical_user = False
        Me.old_id = 0
        Me.userdeleted = False
        Me.prf_strkey_diamonds = ""
        Me.prf_strkey_gemstones = ""
        Me.prf_strkey_jewelry = ""
        Me.prf_strkey_newitems = ""
        Me.prf_strkey_specials = ""
        Me.prf_strkey_search = ""
        Me.prf_list_amount = 0
        Me.prf_language_id = 0
        Me.prf_timesvisited = 0
        Me.online_message = ""
        Me.last_visit = #1/1/1900#
        Me.dateofbirth = #1/1/1900#
		Me.aid = 0
		Me.idex_percent = 0
		Me.registration_ip = "000.000.000.000"

    End Sub


    Public Property customer_dataset() As DataSet
        Get
            Return m_customer_dataset
        End Get

        Set(ByVal Value As DataSet)
            m_customer_dataset = Value
        End Set
    End Property

    Public Property id() As Int32
        Get
            Return m_id
        End Get

        Set(ByVal Value As Int32)
            m_id = Value
        End Set
    End Property

    Public Property email() As String
        Get
            Return m_email
        End Get

        Set(ByVal Value As String)
            m_email = Value
        End Set
    End Property

    Public Property password() As String
        Get
            Return m_password
        End Get

        Set(ByVal Value As String)
            m_password = Value
        End Set
    End Property

    Public Property firstname() As String
        Get
            Return m_firstname
        End Get

        Set(ByVal Value As String)
            m_firstname = Value
        End Set
    End Property

    Public Property lastname() As String
        Get
            Return m_lastname
        End Get

        Set(ByVal Value As String)
            m_lastname = Value
        End Set
    End Property

    Public Property street1() As String
        Get
            Return m_street1
        End Get

        Set(ByVal Value As String)
            m_street1 = Value
        End Set
    End Property

    Public Property city1() As String
        Get
            Return m_city1
        End Get

        Set(ByVal Value As String)
            m_city1 = Value
        End Set
    End Property

    Public Property state1_id() As Int32
        Get
            Return m_state1_id
        End Get

        Set(ByVal Value As Int32)
            m_state1_id = Value
        End Set
    End Property

    Public Property country1_id() As Int32
        Get
            Return m_country1_id
        End Get

        Set(ByVal Value As Int32)
            m_country1_id = Value
        End Set
    End Property

    Public Property zip1() As String
        Get
            Return m_zip1
        End Get

        Set(ByVal Value As String)
            m_zip1 = Value
        End Set
    End Property

    Public Property pobox1() As String
        Get
            Return m_pobox1
        End Get

        Set(ByVal Value As String)
            m_pobox1 = Value
        End Set
    End Property

    Public Property phone1() As String
        Get
            Return m_phone1
        End Get

        Set(ByVal Value As String)
            m_phone1 = Value
        End Set
    End Property

    Public Property fax1() As String
        Get
            Return m_fax1
        End Get

        Set(ByVal Value As String)
            m_fax1 = Value
        End Set
    End Property

    Public Property street2() As String
        Get
            Return m_street2
        End Get

        Set(ByVal Value As String)
            m_street2 = Value
        End Set
    End Property

    Public Property city2() As String
        Get
            Return m_city2
        End Get

        Set(ByVal Value As String)
            m_city2 = Value
        End Set
    End Property

    Public Property state2_id() As Int32
        Get
            Return m_state2_id
        End Get

        Set(ByVal Value As Int32)
            m_state2_id = Value
        End Set
    End Property

    Public Property country2_id() As Int32
        Get
            Return m_country2_id
        End Get

        Set(ByVal Value As Int32)
            m_country2_id = Value
        End Set
    End Property

    Public Property zip2() As String
        Get
            Return m_zip2
        End Get

        Set(ByVal Value As String)
            m_zip2 = Value
        End Set
    End Property

    Public Property pobox2() As String
        Get
            Return m_pobox2
        End Get

        Set(ByVal Value As String)
            m_pobox2 = Value
        End Set
    End Property

    Public Property phone2() As String
        Get
            Return m_phone2
        End Get

        Set(ByVal Value As String)
            m_phone2 = Value
        End Set
    End Property

    Public Property fax2() As String
        Get
            Return m_fax2
        End Get

        Set(ByVal Value As String)
            m_fax2 = Value
        End Set
    End Property

    Public Property inv_mail() As Boolean
        Get
            Return m_inv_mail
        End Get

        Set(ByVal Value As Boolean)
            m_inv_mail = Value
        End Set
    End Property

    Public Property inv_update() As Boolean
        Get
            Return m_inv_update
        End Get

        Set(ByVal Value As Boolean)
            m_inv_update = Value
        End Set
    End Property

    Public Property create_date() As DateTime
        Get
            Return m_create_date
        End Get

        Set(ByVal Value As DateTime)
            m_create_date = Value
        End Set
    End Property

    Public Property active() As Boolean
        Get
            Return m_active
        End Get

        Set(ByVal Value As Boolean)
            m_active = Value
        End Set
    End Property

    Public Property dealer() As Boolean
        Get
            Return m_dealer
        End Get

        Set(ByVal Value As Boolean)
            m_dealer = Value
        End Set
    End Property

    Public Property bname() As String
        Get
            Return m_bname
        End Get

        Set(ByVal Value As String)
            m_bname = Value
        End Set
    End Property

    Public Property bstreet() As String
        Get
            Return m_bstreet
        End Get

        Set(ByVal Value As String)
            m_bstreet = Value
        End Set
    End Property

    Public Property bcity() As String
        Get
            Return m_bcity
        End Get

        Set(ByVal Value As String)
            m_bcity = Value
        End Set
    End Property

    Public Property bstate_id() As Int32
        Get
            Return m_bstate_id
        End Get

        Set(ByVal Value As Int32)
            m_bstate_id = Value
        End Set
    End Property

    Public Property bcountry_id() As Int32
        Get
            Return m_bcountry_id
        End Get

        Set(ByVal Value As Int32)
            m_bcountry_id = Value
        End Set
    End Property

    Public Property bpobox() As String
        Get
            Return m_bpobox
        End Get

        Set(ByVal Value As String)
            m_bpobox = Value
        End Set
    End Property

    Public Property bzip() As String
        Get
            Return m_bzip
        End Get

        Set(ByVal Value As String)
            m_bzip = Value
        End Set
    End Property

    Public Property bphone() As String
        Get
            Return m_bphone
        End Get

        Set(ByVal Value As String)
            m_bphone = Value
        End Set
    End Property

    Public Property bfax() As String
        Get
            Return m_bfax
        End Get

        Set(ByVal Value As String)
            m_bfax = Value
        End Set
    End Property

    Public Property btradingass() As String
        Get
            Return m_btradingass
        End Get

        Set(ByVal Value As String)
            m_btradingass = Value
        End Set
    End Property

    Public Property btype_id() As Int32
        Get
            Return m_btype_id
        End Get

        Set(ByVal Value As Int32)
            m_btype_id = Value
        End Set
    End Property

    Public Property bsiteurl() As String
        Get
            Return m_bsiteurl
        End Get

        Set(ByVal Value As String)
            m_bsiteurl = Value
        End Set
    End Property

    Public Property bspecialization() As String
        Get
            Return m_bspecialization
        End Get

        Set(ByVal Value As String)
            m_bspecialization = Value
        End Set
    End Property

    Public Property historical_user() As Boolean
        Get
            Return m_historical_user
        End Get

        Set(ByVal Value As Boolean)
            m_historical_user = Value
        End Set
    End Property

    Public Property old_id() As Int32
        Get
            Return m_old_id
        End Get

        Set(ByVal Value As Int32)
            m_old_id = Value
        End Set
    End Property

    Public Property userdeleted() As Boolean
        Get
            Return m_userdeleted
        End Get

        Set(ByVal Value As Boolean)
            m_userdeleted = Value
        End Set
    End Property

    Public Property prf_strkey_diamonds() As String
        Get
            Return m_prf_strkey_diamonds
        End Get

        Set(ByVal Value As String)
            m_prf_strkey_diamonds = Value
        End Set
    End Property

    Public Property prf_strkey_gemstones() As String
        Get
            Return m_prf_strkey_gemstones
        End Get

        Set(ByVal Value As String)
            m_prf_strkey_gemstones = Value
        End Set
    End Property

    Public Property prf_strkey_jewelry() As String
        Get
            Return m_prf_strkey_jewelry
        End Get

        Set(ByVal Value As String)
            m_prf_strkey_jewelry = Value
        End Set
    End Property

    Public Property prf_strkey_newitems() As String
        Get
            Return m_prf_strkey_newitems
        End Get

        Set(ByVal Value As String)
            m_prf_strkey_newitems = Value
        End Set
    End Property

    Public Property prf_strkey_specials() As String
        Get
            Return m_prf_strkey_specials
        End Get

        Set(ByVal Value As String)
            m_prf_strkey_specials = Value
        End Set
    End Property

    Public Property prf_strkey_search() As String
        Get
            Return m_prf_strkey_search
        End Get

        Set(ByVal Value As String)
            m_prf_strkey_search = Value
        End Set
    End Property

    Public Property prf_list_amount() As Int64
        Get
            Return m_prf_list_amount
        End Get

        Set(ByVal Value As Int64)
            m_prf_list_amount = Value
        End Set
    End Property

    Public Property prf_language_id() As Int32
        Get
            Return m_prf_language_id
        End Get

        Set(ByVal Value As Int32)
            m_prf_language_id = Value
        End Set
    End Property

    Public Property prf_timesvisited() As Int64
        Get
            Return m_prf_timesvisited
        End Get

        Set(ByVal Value As Int64)
            m_prf_timesvisited = Value
        End Set
    End Property

    Public Property online_message() As String
        Get
            Return m_online_message
        End Get

        Set(ByVal Value As String)
            m_online_message = Value
        End Set
    End Property

    Public Property last_visit() As DateTime
        Get
            Return m_last_visit
        End Get

        Set(ByVal Value As DateTime)
            m_last_visit = Value
        End Set
    End Property

    Public Property dateofbirth() As DateTime
        Get
            Return m_dateofbirth
        End Get

        Set(ByVal Value As DateTime)
            m_dateofbirth = Value
        End Set
    End Property

    Public Property aid() As Int32
        Get
            Return m_aid
        End Get

        Set(ByVal Value As Int32)
            m_aid = Value
        End Set
    End Property

    Public Property lastmodify_user() As String
        Get
            Return m_lastmodify_user
        End Get

        Set(ByVal Value As String)
            m_lastmodify_user = Value
        End Set
    End Property

    Public Property lastmodify_user_id() As Int32
        Get
            Return m_lastmodify_user_id
        End Get

        Set(ByVal Value As Int32)
            m_lastmodify_user_id = Value
        End Set
    End Property

    Public Property lastmodify_date() As DateTime
        Get
            Return m_lastmodify_date
        End Get

        Set(ByVal Value As DateTime)
            m_lastmodify_date = Value
        End Set
    End Property

	Public Property idex_percent() As Int16
		Get
			Return m_idex_percent
		End Get

		Set(ByVal Value As Int16)
			m_idex_percent = Value
		End Set
	End Property

	Public Property registration_ip() As String
		Get
			Return m_registration_ip
		End Get

		Set(ByVal Value As String)
			m_registration_ip = Value
		End Set
	End Property
End Class
