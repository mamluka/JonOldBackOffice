Public Class cls_defaults

    Private m_inv_sellprice As Integer
    Private m_inv_dealerprice As Integer
    Private m_inv_appraisalprice As Integer
    Private m_inv_spc_sellprice As Integer
    Private m_inv_spc_dealerprice As Integer
    Private m_inv_default_special_date As Integer
    Private m_inv_advance_special_date As Integer
    Private m_inv_active_special_date As Integer
    Private m_inv_default_rows As Integer
	Private m_order_packaging As Decimal
	Private m_order_registered As Decimal
	Private m_order_minforcourier As Decimal
    Private m_order_fedexInsurance As Decimal
	Public _order_freeshippingfrom As Decimal
	'--- Interest Calculation
	Private m_interest_days As Int16
	Private m_interest_percentage As Decimal

    Private m_ctg_categories As New Collection()
    Private m_ctg_pictures_root_path As String
    ''new rate vars for colculations
    Public _rate_doller As Decimal
    Public _rate_gram_gold As Decimal
    Public _rate_gram_platina As Decimal

    Public Function read_all(ByVal cPicDir As String)

        '--- Prices calculation in precentage
        Me.inv_sellprice = 150
        Me.inv_dealerprice = 120
        Me.inv_appraisalprice = 420
        Me.inv_spc_sellprice = 130
        Me.inv_spc_dealerprice = 120
        '--- default special-lenght in days
		Me.inv_default_special_date = 14
        '--- how many day can special be added in advance
		Me.inv_advance_special_date = 120
        '--- how long can special be active
		Me.inv_active_special_date = 356
        '--- how many lines in the listing screens
        Me.inv_default_rows = 50

        '--- Server directory leading to the Picture directories
        Me.ctg_pictures_root_path = cPicDir

        '--- Order
        Me.order_packaging = 6
        Me.order_registered = 14.5
		Me.order_minforcourier = 8000
		'--- Free shipping
		Me._order_freeshippingfrom = 1000
        Me.order_fedexInsurance = 1
        '--- Interest Calculation
        Me.interest_percentage = 7.5
        Me.interest_days = 7


        '--- Picture directories 
        Dim oTmpObj As ion_resources.cls_category

        '--- Diamonds
        oTmpObj = New ion_resources.cls_category()
        oTmpObj.category_id = 1
        oTmpObj.category_name = "Diamonds"
        oTmpObj.direct_path = Me.ctg_pictures_root_path + "\diamonds\"
        oTmpObj.relative_path = "/precious-stones/diamonds/"
        Me.ctg_categories.Add(oTmpObj)
        oTmpObj = Nothing

        '--- Fancy Diamonds
        oTmpObj = New ion_resources.cls_category()
        oTmpObj.category_id = 2
        oTmpObj.category_name = "Fancy-Diamonds"
        oTmpObj.direct_path = Me.ctg_pictures_root_path + "\fancy-diamonds\"
        oTmpObj.relative_path = "/precious-stones/fancy-diamonds/"
        Me.ctg_categories.Add(oTmpObj)
        oTmpObj = Nothing

        '--- Rubies
        oTmpObj = New ion_resources.cls_category()
        oTmpObj.category_id = 3
        oTmpObj.category_name = "Rubies"
        oTmpObj.direct_path = Me.ctg_pictures_root_path + "\rubies\"
        oTmpObj.relative_path = "/precious-stones/rubies/"
        Me.ctg_categories.Add(oTmpObj)
        oTmpObj = Nothing

        '--- Sapphires
        oTmpObj = New ion_resources.cls_category()
        oTmpObj.category_id = 4
        oTmpObj.category_name = "Sapphires"
        oTmpObj.direct_path = Me.ctg_pictures_root_path + "\sapphires\"
        oTmpObj.relative_path = "/precious-stones/sapphires/"
        Me.ctg_categories.Add(oTmpObj)
        oTmpObj = Nothing

        '--- Emeralds
        oTmpObj = New ion_resources.cls_category()
        oTmpObj.category_id = 5
        oTmpObj.category_name = "Emeralds"
        oTmpObj.direct_path = Me.ctg_pictures_root_path + "\emeralds\"
        oTmpObj.relative_path = "/precious-stones/emeralds/"
        Me.ctg_categories.Add(oTmpObj)
        oTmpObj = Nothing

        '--- Semi-Precious
        oTmpObj = New ion_resources.cls_category()
        oTmpObj.category_id = 6
        oTmpObj.category_name = "Semi-Precious"
        oTmpObj.direct_path = Me.ctg_pictures_root_path + "\semi-precious\"
        oTmpObj.relative_path = "/precious-stones/semi-precious/"
        Me.ctg_categories.Add(oTmpObj)
        oTmpObj = Nothing

        '--- Jewelry
        oTmpObj = New ion_resources.cls_category()
        oTmpObj.category_id = 7
        oTmpObj.category_name = "Jewelry"
        oTmpObj.direct_path = Me.ctg_pictures_root_path + "\jewelry\"
        oTmpObj.relative_path = "/precious-stones/jewelry/"
        Me.ctg_categories.Add(oTmpObj)
        oTmpObj = Nothing

        '--- Jewelry
        oTmpObj = New ion_resources.cls_category()
        oTmpObj.category_id = 8
        oTmpObj.category_name = "Jewelry"
        oTmpObj.direct_path = Me.ctg_pictures_root_path + "\jewelry\"
        oTmpObj.relative_path = "/precious-stones/jewelry/"
        Me.ctg_categories.Add(oTmpObj)
        oTmpObj = Nothing

        Me._rate_doller = 4.4
        Me._rate_gram_gold = 4
        Me._rate_gram_platina = 8
    End Function

    Public Function GetCategoryPath()


    End Function



    Public Property inv_sellprice() As Integer
        Get
            Return m_inv_sellprice
        End Get

        Set(ByVal Value As Integer)
            m_inv_sellprice = Value
        End Set
    End Property

    Public Property inv_dealerprice() As Integer
        Get
            Return m_inv_dealerprice
        End Get

        Set(ByVal Value As Integer)
            m_inv_dealerprice = Value
        End Set
    End Property

    Public Property inv_appraisalprice() As Integer
        Get
            Return m_inv_appraisalprice
        End Get

        Set(ByVal Value As Integer)
            m_inv_appraisalprice = Value
        End Set
    End Property

    Public Property inv_spc_sellprice() As Integer
        Get
            Return m_inv_spc_sellprice
        End Get

        Set(ByVal Value As Integer)
            m_inv_spc_sellprice = Value
        End Set
    End Property

    Public Property inv_spc_dealerprice() As Integer
        Get
            Return m_inv_spc_dealerprice
        End Get

        Set(ByVal Value As Integer)
            m_inv_spc_dealerprice = Value
        End Set
    End Property

    Public Property inv_default_special_date() As Integer
        Get
            Return m_inv_default_special_date
        End Get

        Set(ByVal Value As Integer)
            m_inv_default_special_date = Value
        End Set
    End Property

    Public Property inv_advance_special_date() As Integer
        Get
            Return m_inv_advance_special_date
        End Get

        Set(ByVal Value As Integer)
            m_inv_advance_special_date = Value
        End Set
    End Property

    Public Property inv_active_special_date() As Integer
        Get
            Return m_inv_active_special_date
        End Get

        Set(ByVal Value As Integer)
            m_inv_active_special_date = Value
        End Set
    End Property

    Public Property inv_default_rows() As Integer
        Get
            Return m_inv_default_rows
        End Get

        Set(ByVal Value As Integer)
            m_inv_default_rows = Value
        End Set
    End Property

    Public Property ctg_categories() As Collection
        Get
            Return m_ctg_categories
        End Get

        Set(ByVal Value As Collection)
            m_ctg_categories = Value
        End Set
    End Property

    Public Property ctg_pictures_root_path() As String
        Get
            Return m_ctg_pictures_root_path
        End Get

        Set(ByVal Value As String)
            m_ctg_pictures_root_path = Value
        End Set
    End Property

    Public Property order_packaging() As Decimal
        Get
            Return m_order_packaging
        End Get

        Set(ByVal Value As Decimal)
            m_order_packaging = Value
        End Set
    End Property

    Public Property order_registered() As Decimal
        Get
            Return m_order_registered
        End Get

        Set(ByVal Value As Decimal)
            m_order_registered = Value
        End Set
    End Property

    Public Property order_minforcourier() As Decimal
        Get
            Return m_order_minforcourier
        End Get

        Set(ByVal Value As Decimal)
            m_order_minforcourier = Value
        End Set
    End Property

    Public Property order_fedexInsurance() As Decimal
        Get
            Return m_order_fedexInsurance
        End Get

        Set(ByVal Value As Decimal)
            m_order_fedexInsurance = Value
        End Set
    End Property

    Public Property interest_days() As Int16
        Get
            Return m_interest_days
        End Get

        Set(ByVal Value As Int16)
            m_interest_days = Value
        End Set
    End Property

    Public Property interest_percentage() As Decimal
        Get
            Return m_interest_percentage
        End Get

        Set(ByVal Value As Decimal)
            m_interest_percentage = Value
        End Set
    End Property

End Class


