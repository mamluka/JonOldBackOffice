Public Class cls_search_plate
	Inherits iFoundation.cls_error_connection

	Public _search_description As String
	Public _search_string As String

	Public _weight_margin As Decimal
	Public _measure_margin As Decimal
	Public _only_active As Boolean

	Public _plate As Int16
	Public _category_id As Int16
	Public _subcategory_id As Int16
	Public _category_name As String
	Public _subcategory_name As String

	Public _isdealer As Boolean
	Public _pricefrom As Decimal
	Public _priceto As Decimal


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

		Me._search_description = ""
		Me._search_string = ""

		Me._weight_margin = 0
		Me._measure_margin = 0
		Me._only_active = False

		Me._plate = 0
		Me._category_id = 0
		Me._subcategory_id = 0
		Me._category_name = ""
		Me._subcategory_name = ""

		Me._isdealer = False
        Me._pricefrom = 10000
        Me._priceto = 20000

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

	Public Function search_plate(ByRef cSQLstring As String) As Boolean
		On Error GoTo ErrorHandler
		Dim bError As Boolean = False

		'--- If we are searching by CATEGORY get the plate number
		If Me._category_id > 0 Then
			'--- Get plate we are searching for
			Dim oTmpCategories As New ion_two.cls_categories
			bError = oTmpCategories.get_category(Me._category_id)
			If bError Then
				Me._err_number = oTmpCategories._err_number
				Me._err_description = oTmpCategories._err_description
				Me._err_source = oTmpCategories._err_source
				Return True
			End If
			Me._plate = oTmpCategories._plate
			Me._category_name = oTmpCategories._name
			oTmpCategories = Nothing
		End If


		'--- At this stage we need the plate number or ERROR
		If Me._plate <= 0 Then
			Err.Raise(7005, "cls_search:search_plate", "No Plate number passed")
		End If


		Select Case Me._plate
			Case 1
				bError = Me.search_plate1(cSQLstring)
				If bError Then
					Me._err_number = Me._err_number
					Me._err_description = Me._err_description
					Me._err_source = Me._err_source
					Return True
				End If

			Case 2
				bError = Me.search_plate2(cSQLstring)
				If bError Then
					Me._err_number = Me._err_number
					Me._err_description = Me._err_description
					Me._err_source = Me._err_source
					Return True
				End If

			Case 3
				bError = Me.search_plate3(cSQLstring)
				If bError Then
					Me._err_number = Me._err_number
					Me._err_description = Me._err_description
					Me._err_source = Me._err_source
					Return True
				End If

		End Select

		'--- If search was on category then give it the sub-category name
		If Me._subcategory_name <> "" Then
			Me._search_description = Me._subcategory_name
		End If


		Return False
		Exit Function

ErrorHandler:
		Me._err_number = Err.Number
		Me._err_description = Err.Description
		Me._err_source = Err.Source
		Return True

	End Function


	Private Function search_plate1(ByRef cSQLstring As String) As Boolean
		On Error GoTo ErrorHandler
		Dim bError As Boolean = False

		Dim cSortIndex As String = "stonetype, color_sort, clarity_sort"
		cSQLstring = "select * from vv_diamonds_full where (platetype = 1) "

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


		'--- Get Stone Type
		If Not IsNothing(Me._diam_type) And Me._diam_type <> "-" Then
            cSQLstring = cSQLstring + "and (stonetype like '%" + Convert.ToString(Me._diam_type) + "%') "
			cSortIndex = cSortIndex + ""

			Me._search_description = "Search: " + Convert.ToString(Me._diam_type)
		End If

		'--- Get Stone Shape
		If Not IsNothing(Me._diam_shape) And Me._diam_shape <> "-" Then
			cSQLstring = cSQLstring + "and (shape = '" + Convert.ToString(Me._diam_shape) + "') "
			cSortIndex = cSortIndex + ", shape"

			Me._search_description = Me._search_description + Convert.ToString(Me._diam_shape)
		End If

		'--- Get Color
		If Me._diam_colorfrom > 1 Then
			If Me._diam_colorto > 1 Then
				cSQLstring = cSQLstring + "and (color_sort between " + Convert.ToString(Me._diam_colorfrom) + " and " + Convert.ToString(Me._diam_colorto) + ") "
			Else
				cSQLstring = cSQLstring + "and (color_sort = " + Convert.ToString(Me._diam_colorfrom) + ") "
			End If
			cSortIndex = cSortIndex + ""
		End If

		'--- Get Clarity
		If Me._diam_clarityfrom > 1 Then
			If Me._diam_clarityto > 1 Then
				cSQLstring = cSQLstring + "and (clarity_sort between " + Convert.ToString(Me._diam_clarityfrom) + " and " + Convert.ToString(Me._diam_clarityto) + ") "
			Else
				cSQLstring = cSQLstring + "and (clarity_sort = " + Convert.ToString(Me._diam_clarityfrom) + ") "
			End If
			cSortIndex = cSortIndex + ""
		End If

		'--- Get Weight
		Dim oWeight As New ion_two.cls_search_general_weight
		oWeight._weightfrom = Me._diam_weightfrom
		oWeight._weightto = Me._diam_weightto
		oWeight._weight_margin = Me._weight_margin
		bError = oWeight.addsearch_weight_carat(cSQLstring)
		If bError Then
			Me._err_number = oWeight._err_number
			Me._err_description = oWeight._err_description
			Me._err_source = oWeight._err_source
			Return True
		End If
		oWeight = Nothing

		'--- Get Measure
		If Me._diam_measure <> 0 Then
			Dim oMeasure As New ion_two.cls_search_general_measure
            oMeasure._measure_margin = Me._measure_margin
            oMeasure._sizeindex = Me._diam_measure
			bError = oMeasure.addsearch_measure(cSQLstring)
			If bError Then
				Me._err_number = oMeasure._err_number
				Me._err_description = oMeasure._err_description
				Me._err_source = oMeasure._err_source
				Return True
			End If
			oMeasure = Nothing
		End If

		'--- Get report
		If Not IsNothing(Me._diam_report) And Me._diam_report <> "-" Then
			cSQLstring = cSQLstring + "and (report = '" + Convert.ToString(Me._diam_report) + "') "
			cSortIndex = cSortIndex + ", report"
		End If

		'--- Get Any report
		If Me._diam_anyreport Then
			cSQLstring = cSQLstring + "and (report <> '-') "
			cSortIndex = cSortIndex + ", report"

			Me._search_description = Me._search_description + " - with REPORT"
        End If

        If Me._diam_color_freetxt <> "" Then
            cSQLstring += "and (fancy_freetxt like '%" + Me._diam_color_freetxt + "%' )"
            Me._search_description = Me._search_description + " - with Color"
        End If

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
        oPrice._pricefrom = Me._pricefrom
        oPrice._priceto = Me._priceto
        oPrice._isdealer = Me._isdealer
        bError = oPrice.addsearch_price(cSQLstring)
        If bError Then
            Me._err_number = oPrice._err_number
            Me._err_description = oPrice._err_description
            Me._err_source = oPrice._err_source
            Return True
        End If
        oPrice = Nothing


        Return False
        Exit Function

ErrorHandler:
        Me._err_number = Err.Number
        Me._err_description = Err.Description
        Me._err_source = Err.Source
        Return True

	End Function

	Private Function search_plate2(ByRef cSQLstring As String) As Boolean
		On Error GoTo ErrorHandler
		Dim bError As Boolean = False

		Dim cSortIndex As String = "stonetype, color_sort, clarity_sort"
		cSQLstring = "select * from vv_gemstones_full where (platetype = 2) "

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


		'--- Get Stone Type
        If Not IsNothing(Me._gem_type) And Me._gem_type <> "-" And Me._gem_type <> "Semi Precious" Then
            cSQLstring = cSQLstring + "and (stonetype like '%" + Convert.ToString(Me._gem_type) + "%') "
            cSortIndex = cSortIndex + ""

            Me._search_description = "Search: " + Convert.ToString(Me._gem_type)
        ElseIf Me._gem_type = "Semi Precious" Then
            cSQLstring = cSQLstring + "and (stonetype != 'Ruby') and (stonetype != 'Emerald') and (stonetype != 'Sapphire') and (stonetype not like '%Diamond%')"
            cSortIndex = cSortIndex + ""
            Me._search_description = "Search: " + Convert.ToString(Me._gem_type)
        End If

        '--- Get Stone Shape
        If Not IsNothing(Me._gem_shape) And Me._gem_shape <> "-" Then
            cSQLstring = cSQLstring + "and (shape = '" + Convert.ToString(Me._gem_shape) + "') "
            cSortIndex = cSortIndex + ", shape"

            Me._search_description = Me._search_description + " - " + Convert.ToString(Me._gem_shape)
        End If

        '--- Get Clarity
        If Me._gem_clarity > 1 Then
            cSQLstring = cSQLstring + "and (clarity_sort = " + Convert.ToString(Me._gem_clarity) + ") "
        End If

        '--- Get Weight
        Dim oWeight As New ion_two.cls_search_general_weight
        oWeight._weightfrom = Me._gem_weightfrom
        oWeight._weightto = Me._gem_weightto
        oWeight._weight_margin = Me._weight_margin
        bError = oWeight.addsearch_weight_carat(cSQLstring)
        If bError Then
            Me._err_number = oWeight._err_number
            Me._err_description = oWeight._err_description
            Me._err_source = oWeight._err_source
            Return True
        End If
        oWeight = Nothing

        '--- Get Measure
        If Me._gem_measure <> 0 Then
            Dim oMeasure As New ion_two.cls_search_general_measure
            oMeasure._measure_margin = Me._measure_margin
            oMeasure._sizeindex = Me._gem_measure
            bError = oMeasure.addsearch_measure(cSQLstring)
            If bError Then
                Me._err_number = oMeasure._err_number
                Me._err_description = oMeasure._err_description
                Me._err_source = oMeasure._err_source
                Return True
            End If
            oMeasure = Nothing
        End If

        '--- Get report
        If Not IsNothing(Me._gem_report) And Me._gem_report <> "-" Then
            cSQLstring = cSQLstring + "and (report = '" + Convert.ToString(Me._gem_report) + "') "
            cSortIndex = cSortIndex + ", report"
        End If

        '--- Get Any report
        If Me._gem_anyreport Then
            cSQLstring = cSQLstring + "and (report <> '-') "
            cSortIndex = cSortIndex + ", report"

            Me._search_description = Me._search_description + " - with REPORT"
        End If


        If Me._gem_color <> "" Then
            cSQLstring += "and (colorfrom like '%" + Me._gem_color + "%') "
            Me._search_description = Me._search_description + " - with Color"

        End If
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
        oPrice._pricefrom = Me._pricefrom
        oPrice._priceto = Me._priceto
        oPrice._isdealer = Me._isdealer
        bError = oPrice.addsearch_price(cSQLstring)
        If bError Then
            Me._err_number = oPrice._err_number
            Me._err_description = oPrice._err_description
            Me._err_source = oPrice._err_source
            Return True
        End If
        oPrice = Nothing


        Return False
        Exit Function

ErrorHandler:
        Me._err_number = Err.Number
        Me._err_description = Err.Description
        Me._err_source = Err.Source
        Return True

	End Function

	Private Function search_plate3(ByRef cSQLstring As String) As Boolean
		On Error GoTo ErrorHandler
		Dim bError As Boolean = False

		Dim cSortIndex As String = "stonetype, color_sort, clarity_sort"
		cSQLstring = "select * from vv_jewelry_full where (platetype = 3) "

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


		'--- Get Jewelry Category
		If Not IsNothing(Me._jewel_category) And Me._jewel_category <> "-" Then
			cSQLstring = cSQLstring + "and (jeweltype = '" + Convert.ToString(Me._jewel_category) + "') "
			cSortIndex = cSortIndex + ""

			Me._search_description = "Search: " + Convert.ToString(Me._jewel_category)
		End If

		'--- Get Jewelry Type
		If Not IsNothing(Me._jewel_type) And Me._jewel_type <> "-" Then
			cSQLstring = cSQLstring + "and (jewelsubtype = '" + Convert.ToString(Me._jewel_type) + "') "
			cSortIndex = cSortIndex + ""

			Me._search_description = Me._search_description + " - " + Convert.ToString(Me._jewel_type)
		End If

		'--- Get Jewelry MiddleStone
        If Not IsNothing(Me._jewel_middlestone) And Me._jewel_middlestone <> "-" Then
            If Me._jewel_middlestone.ToLower = "gemstone" Then
                cSQLstring = cSQLstring + "and (middlestone  like '%Ruby%' or middlestone like '%sapphire%' or middlestone like '%emerald%' ) "
            Else
                cSQLstring = cSQLstring + "and (middlestone = '" + Convert.ToString(Me._jewel_middlestone) + "') "
            End If

            cSortIndex = cSortIndex + ""
        End If

            '--- Get Jewelry Metal
            If Not IsNothing(Me._jewel_metal) And Me._jewel_metal <> "-" Then
                cSQLstring = cSQLstring + "and (metal = '" + Convert.ToString(Me._jewel_metal) + "') "
                cSortIndex = cSortIndex + ""
            End If

            '--- Get report
            If Not IsNothing(Me._jewel_report) And Me._jewel_report <> "-" Then
                cSQLstring = cSQLstring + "and (report = '" + Convert.ToString(Me._jewel_report) + "') "
                cSortIndex = cSortIndex + ", report"
            End If

            '--- Get Any report
            If Me._jewel_anyreport Then
                cSQLstring = cSQLstring + "and (report <> '-') "
                cSortIndex = cSortIndex + ", report"

                Me._search_description = Me._search_description + " - with REPORT"
            End If

            If Me._jewel_sidestones <> "" Then
                cSQLstring += "and (stone_extended like '%|%|%|%|%|%" + Me._jewel_sidestones + "%|')"
                Me._search_description = Me._search_description + " - with Side Stones"
            End If
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
            oPrice._pricefrom = Me._pricefrom
            oPrice._priceto = Me._priceto
            oPrice._isdealer = Me._isdealer
            bError = oPrice.addsearch_price(cSQLstring)
            If bError Then
                Me._err_number = oPrice._err_number
                Me._err_description = oPrice._err_description
                Me._err_source = oPrice._err_source
                Return True
            End If
            oPrice = Nothing


            Return False
            Exit Function

ErrorHandler:
            Me._err_number = Err.Number
            Me._err_description = Err.Description
            Me._err_source = Err.Source
            Return True

	End Function



End Class
