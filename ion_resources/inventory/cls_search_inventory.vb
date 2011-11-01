Imports System.Data.SqlClient

Public Class cls_search_inventory

    '--- SearchType
    '- 1 = ItemNumber
    '- 2 = Diamonds
    '- 3 = Gemstones
    '- 4 = Jewelry
    '- 5 = Id

	Private m_searchtype As Int16
    Private m_search_string As String
    Private m_connection_string As String
    Private m_error_number As Int32
    Private m_error_source As String
    Private m_error_description As String
    Private m_validation_error As Boolean
    Private m_lst_message As New System.Web.UI.WebControls.ListBox()
    Private m_mastersearch As Boolean
    Private m_weight_margin As Decimal
    Private m_measure_margin As Decimal
    Private m_isdealer As Boolean
    Private m_search_description As String

    Private m_id As Int32
    Private m_branch_no As Int32
    Private m_supplier_no As Int32
    Private m_item_no As Int32
    Private m_itemnumber As String

    Private m_diam_type As String
    Private m_diam_shape As String
    Private m_diam_colorfrom As Int32
    Private m_diam_colorto As Int32
    Private m_diam_clarityfrom As Int32
    Private m_diam_clarityto As Int32
    Private m_diam_measure As Int32
    Private m_diam_report As String
    Private m_diam_anyreport As Boolean
    Private m_diam_weightfrom As Decimal
    Private m_diam_weightto As Decimal

    Private m_gem_type As String
    Private m_gem_shape As String
    Private m_gem_clarity As Int32
    Private m_gem_measure As Int32
    Private m_gem_report As String
    Private m_gem_anyreport As Boolean
    Private m_gem_weightfrom As Decimal
    Private m_gem_weightto As Decimal

    Private m_jewel_category As String
    Private m_jewel_type As String
    Private m_jewel_middlestone As String
    Private m_jewel_metal As String
    Private m_jewel_report As String
    Private m_jewel_anyreport As Boolean

    Private m_PriceFrom As Decimal
    Private m_PriceTo As Decimal

    'Public oConnection As SqlClient.SqlConnection = New SqlClient.SqlConnection()
    'Public oDataAdapter1 As SqlDataAdapter = New SqlDataAdapter()
    'Public oSQLcmd1 As SqlCommand = New SqlCommand("", oConnection)


    '###################################################################################
    Public Function get_inventory() As Boolean
        On Error GoTo ErrorHandler
        Dim bError As Boolean = False

        Dim cSQL As String
        Dim cSortIndex As String = "stonetype, color_sort, clarity_sort"



        Select Case Me.searchtype
			Case 1		  '-- ItemNumber
				bError = Me.search_itemnumber(cSQL, cSortIndex)
			Case 2		  '-- Diamonds
				bError = Me.search_diamonds(cSQL, cSortIndex)
			Case 3		  '-- Gemstons
				bError = Me.search_gemstones(cSQL, cSortIndex)
			Case 4		  '-- Jewelry
				bError = Me.search_jewelry(cSQL, cSortIndex)
			Case 5		  '-- Id
				bError = Me.search_id(cSQL, cSortIndex)

		End Select


        '--- Get Price
        If Me.isdealer Then
            If Me.PriceFrom > 0 Then
                If Me.PricetTo > Me.PriceFrom Then
                    cSQL = cSQL + "and (dealer_price between " + Convert.ToString(Me.PriceFrom) + " and " + Convert.ToString(Me.PricetTo) + ") "
                Else
                    cSQL = cSQL + "and (dealer_price = " + Convert.ToString(Me.PriceFrom) + ") "
                End If
                cSortIndex = cSortIndex + ", dealer_price"
            End If

        Else
            If Me.PriceFrom > 0 Then
                If Me.PricetTo > Me.PriceFrom Then
                    cSQL = cSQL + "and (sell_price between " + Convert.ToString(Me.PriceFrom) + " and " + Convert.ToString(Me.PricetTo) + ") "
                Else
                    cSQL = cSQL + "and (sell_price = " + Convert.ToString(Me.PriceFrom) + ") "
                End If
                cSortIndex = cSortIndex + ", sell_price"
            End If

        End If

        '--- Add sorting
        cSQL = cSQL + " order by " + cSortIndex


        Me.m_search_string = cSQL

        Return False
        Exit Function

ErrorHandler:
        Me.error_number = Err.Number
        Me.error_description = Err.Description
        Me.error_source = Err.Source
        Return True

    End Function


    '###################################################################################
    Private Function search_itemnumber(ByRef cSQL As String, ByRef cSortIndex As String) As Boolean
        On Error GoTo ErrorHandler
        Dim bError As Boolean = False

        Dim cErrorText, cSearchText As String

        '--- Take Itemnumber appart
        Dim oItemNumber As New ion_resources.cls_itemnumber()
        oItemNumber.connection_string = Me.connection_string
        oItemNumber.itemnumber = Me.itemnumber
        bError = oItemNumber.stripitemnumber(cErrorText, cSearchText)

        '--- If an invalid Itemnumber
        If cErrorText <> "" Then
            Me.lst_message.Items.Add(cErrorText)
            Me.validation_error = True

        Else

            Me.search_description = "Searching by Item-number"
            '--- If Master search
            If Me.mastersearch Then
                cSQL = "select * from v_inventory_category_list where 0=0"
                If oItemNumber.branch > 0 Then
                    cSQL = cSQL + " and branchnumber = " + Convert.ToString(oItemNumber.branch)
                End If

                If oItemNumber.supplier > 0 Then
                    cSQL = cSQL + " and suppliernumber = " + Convert.ToString(oItemNumber.supplier)
                End If

                If oItemNumber.item > 0 Then
                    cSQL = cSQL + " and itemnoint = " + Convert.ToString(oItemNumber.item)
                End If

                Return False

            Else
                If oItemNumber.branch = 0 Or oItemNumber.supplier = 0 Or oItemNumber.item = 0 Then
                    Me.lst_message.Items.Add("Invalid Item number")
                    Me.validation_error = True
                    Return False
                End If

                cSQL = "select * from v_inventory_category_list where branchnumber = " + Convert.ToString(oItemNumber.branch) + " and suppliernumber = " + Convert.ToString(oItemNumber.supplier) + " and itemnoint = " + Convert.ToString(oItemNumber.item)

            End If

        End If

        Return False
        Exit Function

ErrorHandler:
        Me.error_number = Err.Number
        Me.error_description = Err.Description
        Me.error_source = Err.Source
        Return True

    End Function


    '###################################################################################
    Private Function search_diamonds(ByRef cSQL As String, ByRef cSortIndex As String) As Boolean
        On Error GoTo ErrorHandler
        Dim bError As Boolean = False


        cSQL = "select * from v_inventory_category_list where (platetype = 1) and (shopstatus = 1) and (sell_price > 0) "

        '--- Get Stone Type
        If Me.diam_type <> "-" Then
            cSQL = cSQL + "and (stonetype = '" + Convert.ToString(Me.diam_type) + "') "
            cSortIndex = cSortIndex + ""

            Me.search_description = "Searching  - " + Convert.ToString(Me.diam_type)
        End If

        '--- Get Stone Shape
        If Me.diam_shape <> "-" Then
            cSQL = cSQL + "and (shape = '" + Convert.ToString(Me.diam_shape) + "') "
            cSortIndex = cSortIndex + ", shape"

            Me.search_description = Me.search_description + " - " + Convert.ToString(Me.diam_shape)
        End If

        '--- Get Color
        If Me.diam_colorfrom > 1 Then
            If Me.diam_colorto > 1 Then
                cSQL = cSQL + "and (color_sort between " + Convert.ToString(Me.diam_colorfrom) + " and " + Convert.ToString(Me.diam_colorto) + ") "
            Else
                cSQL = cSQL + "and (color_sort = " + Convert.ToString(Me.diam_colorfrom) + ") "
            End If
            cSortIndex = cSortIndex + ""
        End If

        '--- Get Clarity
        If Me.diam_clarityfrom > 1 Then
            If Me.diam_clarityto > 1 Then
                cSQL = cSQL + "and (clarity_sort between " + Convert.ToString(Me.diam_clarityfrom) + " and " + Convert.ToString(Me.diam_clarityto) + ") "
            Else
                cSQL = cSQL + "and (clarity_sort = " + Convert.ToString(Me.diam_clarityfrom) + ") "
            End If
            cSortIndex = cSortIndex + ""
        End If

        '--- Get Weight
        Dim cDiamWeightFrom As String = Convert.ToString(Me.diam_weightfrom - Me.weight_margin)
        Dim cDiamWeightTo As String = Convert.ToString(Me.diam_weightto + Me.weight_margin)

        If Me.diam_weightfrom > 0 Then
            If Me.diam_weightto > Me.diam_weightfrom Then
                cSQL = cSQL + "and (weight between " + cDiamWeightFrom + " and " + cDiamWeightTo + ") "
            Else
                cSQL = cSQL + "and (weight = " + cDiamWeightFrom + ") "
            End If
            cSortIndex = cSortIndex + ""
        End If

        '--- Get Measure
        If Me.diam_measure <> 0 Then
            Dim oTmpMeasure As New ion_resources.cls_measurement()
            oTmpMeasure.size_margin = Me.measure_margin
            bError = oTmpMeasure.size_index(Me.diam_measure)
            cSQL = cSQL + oTmpMeasure.sql
            oTmpMeasure = Nothing
        End If

        '--- Get report
        If Me.diam_report <> "-" Then
            cSQL = cSQL + "and (report = '" + Convert.ToString(Me.diam_report) + "') "
            cSortIndex = cSortIndex + ", report"
        End If

        '--- Get Any report
        If Me.diam_anyreport Then
            cSQL = cSQL + "and (report <> '-') "
            cSortIndex = cSortIndex + ", report"

            Me.search_description = Me.search_description + " - with REPORT"
        End If


        Return False
        Exit Function

ErrorHandler:
        Me.error_number = Err.Number
        Me.error_description = Err.Description
        Me.error_source = Err.Source
        Return True

    End Function


    '###################################################################################
    Private Function search_gemstones(ByRef cSQL As String, ByRef cSortIndex As String) As Boolean
        On Error GoTo ErrorHandler
        Dim bError As Boolean = False

        cSQL = "select * from v_inventory_category_list where (platetype = 2) and (shopstatus = 1) and (sell_price > 0) "

        '--- Get Stone Type
        If Me.gem_type <> "-" Then
            cSQL = cSQL + "and (stonetype like '%" + Convert.ToString(Me.gem_type) + "%') "
            cSortIndex = cSortIndex + ""

            Me.search_description = "Searching - " + Convert.ToString(Me.gem_type)
        End If

        '--- Get Stone Shape
        If Me.gem_shape <> "-" Then
            cSQL = cSQL + "and (shape = '" + Convert.ToString(Me.gem_shape) + "') "
            cSortIndex = cSortIndex + ", shape"

            Me.search_description = Me.search_description + " - " + Convert.ToString(Me.gem_shape)
        End If

        '--- Get Clarity
        If Me.gem_clarity > 1 Then
            cSQL = cSQL + "and (clarity_sort = " + Convert.ToString(Me.gem_clarity) + ") "
        End If

        '--- Get Weight
        Dim cGemWeightFrom As String = Convert.ToString(Me.gem_weightfrom - Me.weight_margin)
        Dim cGemWeightTo As String = Convert.ToString(Me.gem_weightto + Me.weight_margin)

        If Me.gem_weightfrom > 0 Then
            If Me.gem_weightto > Me.gem_weightfrom Then
                cSQL = cSQL + "and (weight between " + cGemWeightFrom + " and " + cGemWeightTo + ") "
            Else
                cSQL = cSQL + "and (weight = " + cGemWeightFrom + ") "
            End If
            cSortIndex = cSortIndex + ""
        End If

        '--- Get Measure
        If Me.gem_measure <> 0 Then
            Dim oTmpMeasure As New ion_resources.cls_measurement()
            oTmpMeasure.size_margin = Me.measure_margin
            bError = oTmpMeasure.size_index(Me.gem_measure)
            cSQL = cSQL + oTmpMeasure.sql
            oTmpMeasure = Nothing
        End If

        '--- Get report
        If Me.gem_report <> "-" Then
            cSQL = cSQL + "and (report = '" + Convert.ToString(Me.gem_report) + "') "
            cSortIndex = cSortIndex + ", report"
        End If

        '--- Get Any report
        If Me.gem_anyreport Then
            cSQL = cSQL + "and (report <> '-') "
            cSortIndex = cSortIndex + ", report"

            Me.search_description = Me.search_description + " - with REPORT"
        End If


        Return False
        Exit Function

ErrorHandler:
        Me.error_number = Err.Number
        Me.error_description = Err.Description
        Me.error_source = Err.Source
        Return True

    End Function


    '###################################################################################
    Private Function search_jewelry(ByRef cSQL As String, ByRef cSortIndex As String) As Boolean
        On Error GoTo ErrorHandler
        Dim bError As Boolean = False

        cSQL = "select * from v_inventory_category_list where (platetype = 3) and (shopstatus = 1) and (sell_price > 0) "

        '--- Get Jewelry Category
        If Me.jewel_category <> "-" Then
            cSQL = cSQL + "and (stonetype = '" + Convert.ToString(Me.jewel_category) + "') "
            cSortIndex = cSortIndex + ""

            Me.search_description = "Searching  - " + Convert.ToString(Me.jewel_category)
        End If

        '--- Get Jewelry Type
        If Me.jewel_type <> "-" Then
            cSQL = cSQL + "and (shape = '" + Convert.ToString(Me.jewel_type) + "') "
            cSortIndex = cSortIndex + ""

            Me.search_description = Me.search_description + " - " + Convert.ToString(Me.jewel_type)
        End If

        '--- Get Jewelry MiddleStone
        If Me.jewel_middlestone <> "-" Then
            cSQL = cSQL + "and (colorfrom = '" + Convert.ToString(Me.jewel_middlestone) + "') "
            cSortIndex = cSortIndex + ""
        End If

        '--- Get Jewelry Metal
        If Me.jewel_metal <> "-" Then
            cSQL = cSQL + "and (origin = '" + Convert.ToString(Me.jewel_metal) + "') "
            cSortIndex = cSortIndex + ""
        End If

        '--- Get report
        If Me.jewel_report <> "-" Then
            cSQL = cSQL + "and (report = '" + Convert.ToString(Me.jewel_report) + "') "
            cSortIndex = cSortIndex + ", report"
        End If

        '--- Get Any report
        If Me.jewel_anyreport Then
            cSQL = cSQL + "and (report <> '-') "
            cSortIndex = cSortIndex + ", report"

            Me.search_description = Me.search_description + " - with REPORT"
        End If

        Return False
        Exit Function

ErrorHandler:
        Me.error_number = Err.Number
        Me.error_description = Err.Description
        Me.error_source = Err.Source
        Return True

    End Function

    '###################################################################################
    Private Function search_id(ByRef cSQL As String, ByRef cSortIndex As String) As Boolean
        On Error GoTo ErrorHandler
        Dim bError As Boolean = False





        Return False
        Exit Function

ErrorHandler:
        Me.error_number = Err.Number
        Me.error_description = Err.Description
        Me.error_source = Err.Source
        Return True

    End Function


    '--- General
    Public Property searchtype() As Int16
        Get
            Return m_searchtype
        End Get

        Set(ByVal Value As Int16)
            m_searchtype = Value
        End Set
    End Property

    Public Property search_string() As String
        Get
            Return m_search_string
        End Get

        Set(ByVal Value As String)
            m_search_string = Value
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

    Public Property error_number() As Int32
        Get
            Return m_error_number
        End Get

        Set(ByVal Value As Int32)
            m_error_number = Value
        End Set
    End Property

    Public Property error_description() As String
        Get
            Return m_error_description
        End Get

        Set(ByVal Value As String)
            m_error_description = Value
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

    Public Property mastersearch() As Boolean
        Get
            Return m_mastersearch
        End Get

        Set(ByVal Value As Boolean)
            m_mastersearch = Value
        End Set
    End Property

    Public Property validation_error() As Boolean
        Get
            Return m_validation_error
        End Get

        Set(ByVal Value As Boolean)
            m_validation_error = Value
        End Set
    End Property

    Public Property lst_message() As System.Web.UI.WebControls.ListBox
        Get
            Return m_lst_message
        End Get

        Set(ByVal Value As System.Web.UI.WebControls.ListBox)
            m_lst_message = Value
        End Set
    End Property

    Public Property weight_margin() As Decimal
        Get
            Return m_weight_margin
        End Get

        Set(ByVal Value As Decimal)
            m_weight_margin = Value
        End Set
    End Property

    Public Property measure_margin() As Decimal
        Get
            Return m_measure_margin
        End Get

        Set(ByVal Value As Decimal)
            m_measure_margin = Value
        End Set
    End Property

    Public Property isdealer() As Boolean
        Get
            Return m_isdealer
        End Get

        Set(ByVal Value As Boolean)
            m_isdealer = Value
        End Set
    End Property

    '--- diamonds
    Public Property diam_type() As String
        Get
            Return m_diam_type
        End Get

        Set(ByVal Value As String)
            m_diam_type = Value
        End Set
    End Property

    Public Property diam_shape() As String
        Get
            Return m_diam_shape
        End Get

        Set(ByVal Value As String)
            m_diam_shape = Value
        End Set
    End Property

    Public Property diam_colorfrom() As Int32
        Get
            Return m_diam_colorfrom
        End Get

        Set(ByVal Value As Int32)
            m_diam_colorfrom = Value
        End Set
    End Property

    Public Property diam_colorto() As Int32
        Get
            Return m_diam_colorto
        End Get

        Set(ByVal Value As Int32)
            m_diam_colorto = Value
        End Set
    End Property

    Public Property diam_clarityfrom() As Int32
        Get
            Return m_diam_clarityfrom
        End Get

        Set(ByVal Value As Int32)
            m_diam_clarityfrom = Value
        End Set
    End Property

    Public Property diam_clarityto() As Int32
        Get
            Return m_diam_clarityto
        End Get

        Set(ByVal Value As Int32)
            m_diam_clarityto = Value
        End Set
    End Property

    Public Property diam_measure() As Int32
        Get
            Return m_diam_measure
        End Get

        Set(ByVal Value As Int32)
            m_diam_measure = Value
        End Set
    End Property

    Public Property diam_report() As String
        Get
            Return m_diam_report
        End Get

        Set(ByVal Value As String)
            m_diam_report = Value
        End Set
    End Property

    Public Property diam_anyreport() As Boolean
        Get
            Return m_diam_anyreport
        End Get

        Set(ByVal Value As Boolean)
            m_diam_anyreport = Value
        End Set
    End Property

    Public Property diam_weightfrom() As Decimal
        Get
            Return m_diam_weightfrom
        End Get

        Set(ByVal Value As Decimal)
            m_diam_weightfrom = Value
        End Set
    End Property

    Public Property diam_weightto() As Decimal
        Get
            Return m_diam_weightto
        End Get

        Set(ByVal Value As Decimal)
            m_diam_weightto = Value
        End Set
    End Property

    '--- Gemstones
    Public Property gem_type() As String
        Get
            Return m_gem_type
        End Get

        Set(ByVal Value As String)
            m_gem_type = Value
        End Set
    End Property

    Public Property gem_shape() As String
        Get
            Return m_gem_shape
        End Get

        Set(ByVal Value As String)
            m_gem_shape = Value
        End Set
    End Property

    Public Property gem_clarity() As Int32
        Get
            Return m_gem_clarity
        End Get

        Set(ByVal Value As Int32)
            m_gem_clarity = Value
        End Set
    End Property

    Public Property gem_measure() As Int32
        Get
            Return m_gem_measure
        End Get

        Set(ByVal Value As Int32)
            m_gem_measure = Value
        End Set
    End Property

    Public Property gem_report() As String
        Get
            Return m_gem_report
        End Get

        Set(ByVal Value As String)
            m_gem_report = Value
        End Set
    End Property

    Public Property gem_anyreport() As Boolean
        Get
            Return m_gem_anyreport
        End Get

        Set(ByVal Value As Boolean)
            m_gem_anyreport = Value
        End Set
    End Property

    Public Property gem_weightfrom() As Decimal
        Get
            Return m_gem_weightfrom
        End Get

        Set(ByVal Value As Decimal)
            m_gem_weightfrom = Value
        End Set
    End Property

    Public Property gem_weightto() As Decimal
        Get
            Return m_gem_weightto
        End Get

        Set(ByVal Value As Decimal)
            m_gem_weightto = Value
        End Set
    End Property

    '--- Jewelry
    Public Property jewel_category() As String
        Get
            Return m_jewel_category
        End Get

        Set(ByVal Value As String)
            m_jewel_category = Value
        End Set
    End Property

    Public Property jewel_type() As String
        Get
            Return m_jewel_type
        End Get

        Set(ByVal Value As String)
            m_jewel_type = Value
        End Set
    End Property

    Public Property jewel_middlestone() As String
        Get
            Return m_jewel_middlestone
        End Get

        Set(ByVal Value As String)
            m_jewel_middlestone = Value
        End Set
    End Property

    Public Property jewel_metal() As String
        Get
            Return m_jewel_metal
        End Get

        Set(ByVal Value As String)
            m_jewel_metal = Value
        End Set
    End Property

    Public Property jewel_report() As String
        Get
            Return m_jewel_report
        End Get

        Set(ByVal Value As String)
            m_jewel_report = Value
        End Set
    End Property

    Public Property jewel_anyreport() As Boolean
        Get
            Return m_jewel_anyreport
        End Get

        Set(ByVal Value As Boolean)
            m_jewel_anyreport = Value
        End Set
    End Property

    '--- Price
    Public Property PriceFrom() As Decimal
        Get
            Return m_PriceFrom
        End Get

        Set(ByVal Value As Decimal)
            m_PriceFrom = Value
        End Set
    End Property

    Public Property PricetTo() As Decimal
        Get
            Return m_PriceTo
        End Get

        Set(ByVal Value As Decimal)
            m_PriceTo = Value
        End Set
    End Property

    '--- Plate
    Public Property itemnumber() As String
        Get
            Return m_itemnumber
        End Get

        Set(ByVal Value As String)
            m_itemnumber = Value
        End Set
    End Property


    Public Property item_no() As Int32
        Get
            Return m_item_no
        End Get

        Set(ByVal Value As Int32)
            m_item_no = Value
        End Set
    End Property

    Public Property supplier_no() As Int32
        Get
            Return m_supplier_no
        End Get

        Set(ByVal Value As Int32)
            m_supplier_no = Value
        End Set
    End Property

    Public Property branch_no() As Int32
        Get
            Return m_branch_no
        End Get

        Set(ByVal Value As Int32)
            m_branch_no = Value
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

    Public Property search_description() As String
        Get
            Return m_search_description
        End Get

        Set(ByVal Value As String)
            m_search_description = Value
        End Set
    End Property


End Class
