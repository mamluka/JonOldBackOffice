
Public Class cls_search
	Inherits iFoundation.cls_error_connection

	Public _searchmode As Int16	'-- 1=Plate search,  2=Mix search,  3=PreDefined search
	Public _manualmode As Boolean	 '-- when a SQL string is already defined
	Public _plate As Int16
	Public _category_id As Int16
	Public _subcategory_id As Int16
	Public _category_name As String
	Public _subcategory_name As String
	Public _dataview As New DataView
	Public _sortcombo As System.Web.UI.WebControls.DropDownList
	Public _sort_defaults As cls_defaults_listings
	Public _master_search As Boolean	'--- applies to Itemnumber = if preceeded with # then can search in parts
	Public _only_active As Boolean
	Private _sort_string As String


	Public _weight_margin As Decimal
	Public _measure_margin As Decimal
	Public _isdealer As Boolean
	Public _search_description As String
	Public _search_string As String

	'--- Inventory
	Public _id As Int32
	Public _branch_no As Int32
	Public _supplier_no As Int32
	Public _item_no As Int32
	Public _itemnumber As String

	'--- Global
	Public _PriceFrom As Decimal
	Public _PriceTo As Decimal

	'--- Diamonds
	Public _diam_type As String
	Public _diam_shape As String
	Public _diam_colorfrom As Int32
	Public _diam_colorto As Int32
	Public _diam_clarityfrom As Int32
	Public _diam_clarityto As Int32
	Public _diam_measure As Int32
	Public _diam_report As String
	Public _diam_anyreport As Boolean
	Public _diam_weightfrom As Decimal
    Public _diam_weightto As Decimal
    Public _diam_color_freetxt As String

	'--- Gemstones
	Public _gem_type As String
	Public _gem_shape As String
	Public _gem_clarity As Int32
	Public _gem_measure As Int32
	Public _gem_report As String
	Public _gem_anyreport As Boolean
	Public _gem_weightfrom As Decimal
    Public _gem_weightto As Decimal
    Public _gem_color As String

	'--- Jewelry
	Public _jewel_category As String
	Public _jewel_type As String
	Public _jewel_middlestone As String
	Public _jewel_metal As String
	Public _jewel_report As String
	Public _jewel_anyreport As Boolean
	Public _jewel_setting As String
    Public _jewel_collection As String
    Public _jewel_sidestones As String

	Sub New()
		Me._searchmode = 0
		Me._manualmode = False
		Me._plate = 0
		Me._category_id = 0
		Me._subcategory_id = 0
		Me._category_name = ""
		Me._subcategory_name = ""

		Me._weight_margin = 0
		Me._measure_margin = 0
		Me._isdealer = False
		Me._search_description = ""
		Me._search_string = ""
		Me._sort_string = ""
        Me._only_active = False

       

		'--- Inventory
		Me._id = 0
		Me._branch_no = 0
		Me._supplier_no = 0
		Me._item_no = 0
		Me._itemnumber = ""

		'--- Global
		Me._PriceFrom = 0
		Me._PriceTo = 0

		'--- Diamonds
		Me._diam_type = "-"
		Me._diam_shape = "-"
		Me._diam_colorfrom = 0
		Me._diam_colorto = 0
		Me._diam_clarityfrom = 0
		Me._diam_clarityto = 0
		Me._diam_measure = 0
		Me._diam_report = "-"
		Me._diam_anyreport = False
		Me._diam_weightfrom = 0
        Me._diam_weightto = 0
        Me._diam_color_freetxt = ""


		'--- Gemstones
		Me._gem_type = "-"
		Me._gem_shape = "-"
		Me._gem_clarity = 0
		Me._gem_measure = 0
		Me._gem_report = "-"
		Me._gem_anyreport = False
		Me._gem_weightfrom = 0
		Me._gem_weightto = 0
        Me._gem_color = ""
		'--- Jewelry
		Me._jewel_category = "-"
		Me._jewel_type = "-"
		Me._jewel_middlestone = "-"
		Me._jewel_metal = "-"
		Me._jewel_report = "-"
		Me._jewel_anyreport = False
		Me._jewel_setting = "-"
        Me._jewel_collection = "-"
        Me._jewel_sidestones = ""


	End Sub

	Public Function get_items() As Boolean
		On Error GoTo ErrorHandler
		Dim bError As Boolean = False


		'---
		If Not Me._manualmode Then
			Select Case Me._searchmode
				Case 1 To 3			   '--- Plate search

					Dim oPlate_search As New ion_two.cls_search_plate
					oPlate_search._connection_string = Me._connection_string
					oPlate_search._dbtype = Me._dbtype
					oPlate_search._category_id = Me._category_id
					oPlate_search._subcategory_id = Me._subcategory_id
					oPlate_search._isdealer = Me._isdealer
					oPlate_search._only_active = Me._only_active
					oPlate_search._weight_margin = Me._weight_margin
					oPlate_search._plate = Me._plate
					oPlate_search._search_description = Me._search_description
                    oPlate_search._measure_margin = Me._measure_margin
					oPlate_search._diam_anyreport = Me._diam_anyreport
					oPlate_search._diam_clarityfrom = Me._diam_clarityfrom
					oPlate_search._diam_colorfrom = Me._diam_colorfrom
					oPlate_search._diam_colorto = Me._diam_colorto
					oPlate_search._diam_measure = Me._diam_measure
					oPlate_search._diam_report = Me._diam_report
					oPlate_search._diam_shape = Me._diam_shape
					oPlate_search._diam_type = Me._diam_type
					oPlate_search._diam_weightfrom = Me._diam_weightfrom
					oPlate_search._diam_weightto = Me._diam_weightto
                    oPlate_search._diam_color_freetxt = Me._diam_color_freetxt

					oPlate_search._gem_anyreport = Me._gem_anyreport
					oPlate_search._gem_clarity = Me._gem_clarity
					oPlate_search._gem_measure = Me._gem_measure
					oPlate_search._gem_report = Me._gem_report
					oPlate_search._gem_shape = Me._gem_shape
					oPlate_search._gem_type = Me._gem_type
					oPlate_search._gem_weightfrom = Me._gem_weightfrom
					oPlate_search._gem_weightto = Me._gem_weightto
                    oPlate_search._gem_color = Me._gem_color

					oPlate_search._jewel_anyreport = Me._jewel_anyreport
					oPlate_search._jewel_category = Me._jewel_category
					oPlate_search._jewel_collection = Me._jewel_collection
					oPlate_search._jewel_metal = Me._jewel_metal
					oPlate_search._jewel_middlestone = Me._jewel_middlestone
					oPlate_search._jewel_report = Me._jewel_report
					oPlate_search._jewel_setting = Me._jewel_setting
                    oPlate_search._jewel_type = Me._jewel_type
                    'for some reason the price params isn't included
                    oPlate_search._pricefrom = Me._PriceFrom
                    oPlate_search._priceto = Me._PriceTo
                    oPlate_search._jewel_sidestones = Me._jewel_sidestones
                    bError = oPlate_search.search_plate(Me._search_string)
                    If bError Then
                        Me._err_number = Me._err_number
                        Me._err_description = Me._err_description
                        Me._err_source = Me._err_source
                        Return True
                    End If

                    '--- Return Parameters
                    Me._plate = oPlate_search._plate
                    Me._search_description = oPlate_search._search_description
                    Me._category_name = oPlate_search._category_name
                    Me._subcategory_name = oPlate_search._subcategory_name

				Case 11				'--- Search New items
                        bError = Me.search_newitems
                        If bError Then
                            Me._err_number = Me._err_number
                            Me._err_description = Me._err_description
                            Me._err_source = Me._err_source
                            Return True
                        End If

				Case 12				'--- Search Special Items
                        bError = Me.search_specialitems
                        If bError Then
                            Me._err_number = Me._err_number
                            Me._err_description = Me._err_description
                            Me._err_source = Me._err_source
                            Return True
                        End If

				Case 13				'--- Search Special Items
                        bError = Me.search_newitems
                        If bError Then
                            Me._err_number = Me._err_number
                            Me._err_description = Me._err_description
                            Me._err_source = Me._err_source
                            Return True
                        End If

				Case 14
                        bError = Me.search_itemnumber
                        If bError Then
                            Me._err_number = Me._err_number
                            Me._err_description = Me._err_description
                            Me._err_source = Me._err_source
                            Return True
                        End If
                        'Case 15 '' new mode allows to look in all products for smart sort
                        '    bError = Me.search_smartsort
                        '    If bError Then
                        '        Me._err_number = Me._err_number
                        '        Me._err_description = Me._err_description
                        '        Me._err_source = Me._err_source
                        '        Return True
                        '    End If

            End Select
        End If

		'--- Fetch records
		If Me._search_string <> "" Then
			Dim oTmpDac As New iDac.cls_T_read
			oTmpDac._connection_string = Me._connection_string
			oTmpDac._dbtype = Me._dbtype
			bError = oTmpDac.transact_read(Me._search_string)
			If bError Then
				Me._err_number = oTmpDac._err_number
				Me._err_description = oTmpDac._err_description
				Me._err_source = oTmpDac._err_source
				Return True
			End If


			'--- Put Datatable into DataView
			Me._dataview.Table = oTmpDac._datatable

			'--- release
			oTmpDac = Nothing
		End If

		Return False
		Exit Function

ErrorHandler:
		Me._err_number = Err.Number
		Me._err_description = Err.Description
		Me._err_source = Err.Source
		Return True

	End Function

    Private Function search_newitems() As Boolean
        On Error GoTo ErrorHandler
        Dim bError As Boolean = False

        Dim dStartDate As DateTime
        Dim dEndDate As DateTime

        Dim oFunctionsDate As New iFunctions.cls_date
        oFunctionsDate._connection_string = Me._connection_string
        oFunctionsDate._dbtype = Me._dbtype
        bError = oFunctionsDate.get_db_date(-30, dStartDate)
        If bError Then
            Me._err_number = oFunctionsDate._err_number
            Me._err_description = oFunctionsDate._err_description
            Me._err_source = oFunctionsDate._err_source
            Return True
        End If

        bError = oFunctionsDate.get_db_date(1, dEndDate)
        If bError Then
            Me._err_number = oFunctionsDate._err_number
            Me._err_description = oFunctionsDate._err_description
            Me._err_source = oFunctionsDate._err_source
            Return True
        End If
        oFunctionsDate = Nothing

        '--- Create SQL 
        Dim cSQLstring As String = ""
        ''cSQLstring = "select * from vv_allitems_full where sell_price > 0 and shopstatus = 1 and createdate between '" + Convert.ToString(dStartDate) + ".000" + "' and '" + Convert.ToString(dEndDate) + ".000" + "' "
        cSQLstring = "select * from vv_allitems_full where sell_price > 0 and shopstatus = 1 and createdate between '" + dStartDate.ToString("yyyyMMdd") + "' and '" + dEndDate.ToString("yyyyMMdd") + "' "

        '--- Get Category/subcategory
        Dim oCategories As New ion_two.cls_search_general_categories
        oCategories._connection_string = Me._connection_string
        oCategories._dbtype = Me._dbtype
        oCategories._category_id = Me._category_id
        oCategories._category_name = Me._category_name
        oCategories._subcategory_id = Me._subcategory_id
        oCategories._subcategory_name = Me._subcategory_name
        bError = oCategories.addsearch_categories(cSQLstring)
        If bError Then
            Me._err_number = oCategories._err_number
            Me._err_description = oCategories._err_description
            Me._err_source = oCategories._err_source
            Return True
        End If
        '--- Read parameters
        Me._category_id = oCategories._category_id
        Me._category_name = oCategories._category_name
        Me._subcategory_id = oCategories._subcategory_id
        Me._subcategory_name = oCategories._subcategory_name
        oCategories = Nothing

        '--- set Active
        Dim oActive As New ion_two.cls_search_general_active
        oActive._only_active = Me._only_active
        bError = oActive.addsearch_active(cSQLstring)
        If bError Then
            Me._err_number = oActive._err_number
            Me._err_description = oActive._err_description
            Me._err_source = oActive._err_source
            Return True
        End If
        oActive = Nothing

        '--- Get Price
        Dim oPrice As New ion_two.cls_search_general_price
        oPrice._pricefrom = Me._PriceFrom
        oPrice._priceto = Me._PriceTo
        oPrice._isdealer = Me._isdealer
        bError = oPrice.addsearch_price(cSQLstring)
        If bError Then
            Me._err_number = oPrice._err_number
            Me._err_description = oPrice._err_description
            Me._err_source = oPrice._err_source
            Return True
        End If
        oPrice = Nothing


        '--- Add description
        Me._search_description = "New items"


        '---
        Me._search_string = cSQLstring


        Return False
        Exit Function

ErrorHandler:
        Me._err_number = Err.Number
        Me._err_description = Err.Description
        Me._err_source = Err.Source
        Return True

    End Function

    Private Function search_specialitems() As Boolean
        On Error GoTo ErrorHandler
        Dim bError As Boolean = False

        '--- Create SQL 
        Dim cSQLstring As String = ""
        cSQLstring = "select * from vv_allitems_full where sell_price > 0 and onspecial=1 and getdate() between onspecial_from_date and onspecial_to_date and shopstatus = 1"

        '--- Get Category/subcategory
        Dim oCategories As New ion_two.cls_search_general_categories
        oCategories._connection_string = Me._connection_string
        oCategories._dbtype = Me._dbtype
        oCategories._category_id = Me._category_id
        oCategories._category_name = Me._category_name
        oCategories._subcategory_id = Me._subcategory_id
        oCategories._subcategory_name = Me._subcategory_name
        bError = oCategories.addsearch_categories(cSQLstring)
        If bError Then
            Me._err_number = oCategories._err_number
            Me._err_description = oCategories._err_description
            Me._err_source = oCategories._err_source
            Return True
        End If
        '--- Read parameters
        Me._category_id = oCategories._category_id
        Me._category_name = oCategories._category_name
        Me._subcategory_id = oCategories._subcategory_id
        Me._subcategory_name = oCategories._subcategory_name
        oCategories = Nothing

        '--- set Active
        Dim oActive As New ion_two.cls_search_general_active
        oActive._only_active = Me._only_active
        bError = oActive.addsearch_active(cSQLstring)
        If bError Then
            Me._err_number = oActive._err_number
            Me._err_description = oActive._err_description
            Me._err_source = oActive._err_source
            Return True
        End If
        oActive = Nothing

        '--- Get Price
        Dim oPrice As New ion_two.cls_search_general_price
        oPrice._pricefrom = Me._PriceFrom
        oPrice._priceto = Me._PriceTo
        oPrice._isdealer = Me._isdealer
        bError = oPrice.addsearch_price(cSQLstring)
        If bError Then
            Me._err_number = oPrice._err_number
            Me._err_description = oPrice._err_description
            Me._err_source = oPrice._err_source
            Return True
        End If
        oPrice = Nothing

        '--- Add description
        Me._search_description = "Special offers"


        '---
        Me._search_string = cSQLstring

        Return False
        Exit Function

ErrorHandler:
        Me._err_number = Err.Number
        Me._err_description = Err.Description
        Me._err_source = Err.Source
        Return True

    End Function

    Private Function search_itemnumber() As Boolean
        On Error GoTo ErrorHandler
        Dim bError As Boolean = False


        '--- Create SQL 
        Dim cSQLstring As String = ""
        cSQLstring = "select * from vv_allitems_full where 0=0 "

        If Me._master_search Then
            If Me._branch_no > 0 Then
                cSQLstring = cSQLstring + " and branchnumber = " + Convert.ToString(Me._branch_no)
            End If

            If Me._supplier_no > 0 Then
                cSQLstring = cSQLstring + " and suppliernumber = " + Convert.ToString(Me._supplier_no)
            End If

            If Me._item_no > 0 Then
                cSQLstring = cSQLstring + " and itemnoint = " + Convert.ToString(Me._item_no)
            End If

        Else

            If Me._branch_no <> 0 And Me._supplier_no <> 0 And Me._item_no <> 0 Then
                cSQLstring = "select * from vv_allitems_full where branchnumber = " + Convert.ToString(Me._branch_no) + " and suppliernumber = " + Convert.ToString(Me._supplier_no) + " and itemnoint = " + Convert.ToString(Me._item_no)
            Else
                cSQLstring = ""
            End If
        End If


        If cSQLstring <> "" Then
            '--- set Active
            Dim oActive As New ion_two.cls_search_general_active
            oActive._only_active = Me._only_active
            bError = oActive.addsearch_active(cSQLstring)
            If bError Then
                Me._err_number = oActive._err_number
                Me._err_description = oActive._err_description
                Me._err_source = oActive._err_source
                Return True
            End If
            oActive = Nothing
        End If


        '--- Add description
        Me._search_description = "Searching for specific item(s)"

        '---
        Me._search_string = cSQLstring


        Return False
        Exit Function

ErrorHandler:
        Me._err_number = Err.Number
        Me._err_description = Err.Description
        Me._err_source = Err.Source
        Return True

    End Function
    Public Function search_smartsort(ByVal smart_String As String) As String
        On Error GoTo ErrorHandler
        Dim bError As Boolean = False


        '--- Create SQL 
        Dim cSQLstring As String = ""
        '' select all active items
        cSQLstring = "select * from vv_allitems_full where (smartsort='" + smart_String + "')"

        If cSQLstring <> "" Then
            '--- set Active
            Dim oActive As New ion_two.cls_search_general_active
            oActive._only_active = True
            bError = oActive.addsearch_active(cSQLstring)
            If bError Then
                Me._err_number = oActive._err_number
                Me._err_description = oActive._err_description
                Me._err_source = oActive._err_source
                Return True
            End If
            oActive = Nothing
        End If


        '--- Add description
        Me._search_description = "Searching for " + smart_String

        '---
        Me._search_string = cSQLstring
        Return cSQLstring


        Return False
        Exit Function

ErrorHandler:
        Me._err_number = Err.Number
        Me._err_description = Err.Description
        Me._err_source = Err.Source
        Return True

    End Function
    Public Function load_searchcombo() As Boolean
        On Error GoTo ErrorHandler
        Dim bError As Boolean = False

        Select Case Me._searchmode
            Case 1    '--- Plate search
                Me._sortcombo.Items.Clear()
                Me._sortcombo.Items.Add("-")
                Me._sortcombo.Items(0).Value = ""
                Me._sortcombo.Items.Add("Weight")
                Me._sortcombo.Items(1).Value = "weight"
                Me._sortcombo.Items.Add("Shape")
                Me._sortcombo.Items(2).Value = "shape"
                Me._sortcombo.Items.Add("Color/Clarity")
                Me._sortcombo.Items(3).Value = "color_sort, clarity_sort"
                Me._sortcombo.Items.Add("Price")
                Me._sortcombo.Items(4).Value = "sell_price"
                Me._sortcombo.Items.Add("Report")
                Me._sortcombo.Items(5).Value = "report_sort"
                Me._sortcombo.Items.Add("Item Number")
                Me._sortcombo.Items(6).Value = "itemnumber"
                '--- Set default sorting
                Me._sort_string = Me._sort_defaults._diamond_sort

            Case 2
                Me._sortcombo.Items.Clear()
                Me._sortcombo.Items.Add("-")
                Me._sortcombo.Items(0).Value = ""
                Me._sortcombo.Items.Add("Weight")
                Me._sortcombo.Items(1).Value = "weight"
                Me._sortcombo.Items.Add("Shape")
                Me._sortcombo.Items(2).Value = "shape"
                Me._sortcombo.Items.Add("Color/Clarity")
                Me._sortcombo.Items(3).Value = "color_sort, clarity_sort"
                Me._sortcombo.Items.Add("Price")
                Me._sortcombo.Items(4).Value = "sell_price"
                Me._sortcombo.Items.Add("Report")
                Me._sortcombo.Items(5).Value = "report_sort"
                Me._sortcombo.Items.Add("Item Number")
                Me._sortcombo.Items(6).Value = "itemnumber"
                '--- Set default sorting
                Me._sort_string = Me._sort_defaults._gemstone_sort

            Case 3
                Me._sortcombo.Items.Clear()
                Me._sortcombo.Items.Add("-")
                Me._sortcombo.Items(0).Value = ""
                Me._sortcombo.Items.Add("Jewel Type")
                Me._sortcombo.Items(1).Value = "platetype"
                Me._sortcombo.Items.Add("Brand")
                Me._sortcombo.Items(2).Value = "brand"
                Me._sortcombo.Items.Add("Center Stone Type")
                Me._sortcombo.Items(3).Value = "middlestone"
                'Me._sortcombo.Items.Add("Center Stone Shape")
                'Me._sortcombo.Items(3).Value = "middlestone_shape"
                Me._sortcombo.Items.Add("Weight")
                Me._sortcombo.Items(4).Value = "weight"
                Me._sortcombo.Items.Add("Metal")
                Me._sortcombo.Items(5).Value = "metal"
                Me._sortcombo.Items.Add("Price")
                Me._sortcombo.Items(6).Value = "sell_price"
                Me._sortcombo.Items.Add("Report")
                Me._sortcombo.Items(7).Value = "report_sort"
                Me._sortcombo.Items.Add("Item Number")
                Me._sortcombo.Items(8).Value = "itemnumber"
                '--- Set default sorting
                Me._sort_string = Me._sort_defaults._jewelry_sort


            Case 11 To 15
                Me._sortcombo.Items.Clear()
                Me._sortcombo.Items.Add("-")
                Me._sortcombo.Items(0).Value = ""
                Me._sortcombo.Items.Add("Item Type")
                Me._sortcombo.Items(1).Value = "platetype"
                Me._sortcombo.Items.Add("Price")
                Me._sortcombo.Items(2).Value = "sell_price"
                Me._sortcombo.Items.Add("Report")
                Me._sortcombo.Items(3).Value = "report_sort"
                Me._sortcombo.Items.Add("Item Number")
                Me._sortcombo.Items(4).Value = "itemnumber"
                '--- Set default sorting
                Me._sort_string = Me._sort_defaults._search_sort

        End Select


        Return False
        Exit Function

ErrorHandler:
        Me._err_number = Err.Number
        Me._err_description = Err.Description
        Me._err_source = Err.Source
        Return True

    End Function


    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub
End Class
