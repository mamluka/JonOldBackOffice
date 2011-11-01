Public Class cls_diamond_lgc
	Inherits iFoundation.cls_logics_sub

	Sub New()
		'--- Set working table
		Me._TableName = "inv_DIAMONDS"

		'--- Get module name
		Dim oTmpStack As New System.Diagnostics.StackFrame
		Me._module = oTmpStack.GetMethod.ReflectedType.FullName()
		oTmpStack = Nothing

	End Sub

	Function insert(ByRef oDataTable As skl_diamond) As Boolean
		On Error GoTo ErrorHandler

		'--- local definitions
		Dim bError As Boolean = False

		'--- Get Dataset
		Dim oTmpDataset As DataSet = New ion_two.ds_diamonds
		Dim oTmpDataTable As DataTable = oTmpDataset.Tables(_TableName)

		'--- Assign Order
		Dim oTmpDataRow As DataRow
		oTmpDataRow = oTmpDataTable.NewRow

		'oTmpDataRow("id") = oDataTable._id
		oTmpDataRow("INVENTORY_ID") = oDataTable._inventory_id
		oTmpDataRow("WEIGHT") = oDataTable._weight
		oTmpDataRow("QUANTITY") = oDataTable._quantity
		oTmpDataRow("MEASURE1") = oDataTable._measure1from
		oTmpDataRow("MEASURE2") = oDataTable._measure2from
		oTmpDataRow("MEASURE3") = oDataTable._measure3from
		oTmpDataRow("MEASURE1TO") = oDataTable._measure1to
		oTmpDataRow("MEASURE2TO") = oDataTable._measure2to
		oTmpDataRow("MEASURE3TO") = oDataTable._measure3to
		oTmpDataRow("DEPTH") = oDataTable._depth
		oTmpDataRow("TABLEWIDTH") = oDataTable._tablewidth
		oTmpDataRow("STONETYPE_ID") = oDataTable._stonetype_id
		oTmpDataRow("COLOR_ID") = oDataTable._color_id
		oTmpDataRow("CLARITY_ID") = oDataTable._clarity_id
		oTmpDataRow("COLORTO_ID") = oDataTable._colorto_id
		oTmpDataRow("CLARITYTO_ID") = oDataTable._clarityto_id
		oTmpDataRow("SHAPE_ID") = oDataTable._shape_id
		oTmpDataRow("POLISH_ID") = oDataTable._polish_id
		oTmpDataRow("SYMMETRY_ID") = oDataTable._symmetry_id
		oTmpDataRow("FLUORECENCE_ID") = oDataTable._fluorecence_id
		oTmpDataRow("GIRDLE_ID") = oDataTable._girdle_id
		oTmpDataRow("CULET_ID") = oDataTable._culet_id
		oTmpDataRow("REPORT_ID") = oDataTable._report_id
        oTmpDataRow("fancy_freetxt") = oDataTable.fancy_freetxt
		oTmpDataTable.Rows.Add(oTmpDataRow)

		'--- Assign datatable
		Me._datatable = oTmpDataTable

		Return False
		Exit Function

ErrorHandler:
		Me._err_number = Err.Number
		Me._err_description = Err.Description
		Me._err_source = Err.Source
		Return True
	End Function


	Function read(ByVal nId As Int32, ByRef oDataTable As skl_diamond) As Boolean
		On Error GoTo ErrorHandler

		'--- local definitions
		Dim bError As Boolean = False

		'--- Get Item
		Dim oReadTransactor As New iDac.cls_T_read
		oReadTransactor._connection_string = Me._connection_string
		oReadTransactor._dbtype = Me._dbtype
		oReadTransactor._tablename = Me._tablename
		oReadTransactor._searchfield = "INVENTORY_ID"
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
		oDataTable._inventory_id = oTmpDataRow("INVENTORY_ID")
		oDataTable._weight = oTmpDataRow("WEIGHT")
		oDataTable._quantity = oTmpDataRow("QUANTITY")
		oDataTable._measure1from = oTmpDataRow("MEASURE1")
		oDataTable._measure2from = oTmpDataRow("MEASURE2")
		oDataTable._measure3from = oTmpDataRow("MEASURE3")
		oDataTable._measure1to = oTmpDataRow("MEASURE1TO")
		oDataTable._measure2to = oTmpDataRow("MEASURE2TO")
		oDataTable._measure3to = oTmpDataRow("MEASURE3TO")
		oDataTable._depth = oTmpDataRow("DEPTH")
		oDataTable._tablewidth = oTmpDataRow("TABLEWIDTH")
		oDataTable._stonetype_id = oTmpDataRow("STONETYPE_ID")
		oDataTable._color_id = oTmpDataRow("COLOR_ID")
		oDataTable._clarity_id = oTmpDataRow("CLARITY_ID")
		oDataTable._colorto_id = oTmpDataRow("COLORTO_ID")
		oDataTable._clarityto_id = oTmpDataRow("CLARITYTO_ID")
		oDataTable._shape_id = oTmpDataRow("SHAPE_ID")
		oDataTable._polish_id = oTmpDataRow("POLISH_ID")
		oDataTable._symmetry_id = oTmpDataRow("SYMMETRY_ID")
		oDataTable._fluorecence_id = oTmpDataRow("FLUORECENCE_ID")
		oDataTable._girdle_id = oTmpDataRow("GIRDLE_ID")
		oDataTable._culet_id = oTmpDataRow("CULET_ID")
		oDataTable._report_id = oTmpDataRow("REPORT_ID")
        oDataTable.fancy_freetxt = oTmpDataRow("fancy_freetxt")
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

    Function update(ByRef oDataTable As skl_diamond, Optional ByVal replicate As Boolean = False) As Boolean
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

        '--- Get DataTable
        Dim oTmpDataTable As DataTable = oTmpTransact._datatable

        '--- Assign Order
        Dim oTmpDataRow As DataRow
        oTmpDataRow = oTmpDataTable.Rows(0)

        'oTmpDataRow("INVENTORY_ID") = oDataTable._inventory_id
        oTmpDataRow("WEIGHT") = oDataTable._weight
        oTmpDataRow("QUANTITY") = oDataTable._quantity
        oTmpDataRow("MEASURE1") = oDataTable._measure1from
        oTmpDataRow("MEASURE2") = oDataTable._measure2from
        oTmpDataRow("MEASURE3") = oDataTable._measure3from
        oTmpDataRow("MEASURE1TO") = oDataTable._measure1to
        oTmpDataRow("MEASURE2TO") = oDataTable._measure2to
        oTmpDataRow("MEASURE3TO") = oDataTable._measure3to
        oTmpDataRow("DEPTH") = oDataTable._depth
        oTmpDataRow("TABLEWIDTH") = oDataTable._tablewidth
        oTmpDataRow("STONETYPE_ID") = oDataTable._stonetype_id
        oTmpDataRow("COLOR_ID") = oDataTable._color_id
        oTmpDataRow("CLARITY_ID") = oDataTable._clarity_id
        oTmpDataRow("COLORTO_ID") = oDataTable._colorto_id
        oTmpDataRow("CLARITYTO_ID") = oDataTable._clarityto_id
        oTmpDataRow("SHAPE_ID") = oDataTable._shape_id
        oTmpDataRow("POLISH_ID") = oDataTable._polish_id
        oTmpDataRow("SYMMETRY_ID") = oDataTable._symmetry_id
        oTmpDataRow("FLUORECENCE_ID") = oDataTable._fluorecence_id
        oTmpDataRow("GIRDLE_ID") = oDataTable._girdle_id
        oTmpDataRow("CULET_ID") = oDataTable._culet_id
        oTmpDataRow("REPORT_ID") = oDataTable._report_id
        oTmpDataRow("fancy_freetxt") = oDataTable.fancy_freetxt


        '--- Assign datatable
        Me._datatable = oTmpDataTable


        Return False
        Exit Function

ErrorHandler:
        Me._err_number = Err.Number
        Me._err_description = Err.Description
        Me._err_source = Err.Source
        Return True

    End Function

    Function load(ByVal nMode As Int16, ByVal oDataRow As DataRow, ByRef oDataTable As skl_lst_diamond, Optional ByVal oPictures As ion_two.cls_pictures = Nothing, Optional ByVal bIsdealer As Boolean = False, Optional ByVal bSSL As Boolean = False) As Boolean
        On Error GoTo ErrorHandler
        Dim bError As Boolean = False

        oDataTable._weight = oDataRow.Item("weight")
        oDataTable._quantity = oDataRow.Item("quantity")
        oDataTable._stonetype = oDataRow.Item("stonetype")
        oDataTable._shape = oDataRow.Item("shape")
        oDataTable._colorfrom = oDataRow.Item("colorfrom")
        oDataTable._clarityfrom = oDataRow.Item("clarityfrom")
        oDataTable._colorto = oDataRow.Item("colorto")
        oDataTable._clarityto = oDataRow.Item("clarityto")
        oDataTable._report = oDataRow.Item("report")
        oDataTable._color_sort = oDataRow.Item("color_sort")
        oDataTable._clarity_sort = oDataRow.Item("clarity_sort")
        oDataTable._shape_sort = oDataRow.Item("shape_sort")
        oDataTable._report_sort = oDataRow.Item("report_sort")


        '--- if we are searching on plate not MIX mode
        If nMode < 10 Then
            oDataTable._depth = oDataRow.Item("depth")
            oDataTable._tablewidth = oDataRow.Item("tablewidth")
            oDataTable._polish = oDataRow.Item("polish")
            oDataTable._symmetry = oDataRow.Item("symmetry")
            oDataTable._fluorecence = oDataRow.Item("fluorecence")
            oDataTable._girdle = oDataRow.Item("girdle")
            oDataTable._culet = oDataRow.Item("culet")
            oDataTable.fancy_freetxt = oDataRow.Item("fancy_freetxt")
        End If

        '--- Format decimals
        Dim oStringFunctions As New iFunctions.cls_string
        bError = oStringFunctions.format_decimal(oDataTable._weight, oDataTable._s_weight, "Ct.")
        bError = oStringFunctions.format_decimal(oDataTable._depth, oDataTable._s_depth, "%")
        bError = oStringFunctions.format_decimal(oDataTable._tablewidth, oDataTable._s_tablewidth, "%")
        oStringFunctions = Nothing

        '--- Measurements
        Dim nMeasure1from As Decimal = oDataRow.Item("measure1")
        Dim nMeasure2from As Decimal = oDataRow.Item("measure2")
        Dim nMeasure3from As Decimal = oDataRow.Item("measure3")
        Dim nMeasure1to As Decimal = oDataRow.Item("measure1to")
        Dim nMeasure2to As Decimal = oDataRow.Item("measure2to")
        Dim nMeasure3to As Decimal = oDataRow.Item("measure3to")

        '--- get measurement
        Dim oTmpMeasurements As New ion_two.cls_measurement

        '--- RUN ONCE
        oTmpMeasurements._m1 = nMeasure1from
        oTmpMeasurements._m2 = nMeasure2from
        oTmpMeasurements._m3 = nMeasure3from
        bError = oTmpMeasurements.get_measurements
        If bError Then
            Me._err_number = oTmpMeasurements._err_number
            Me._err_description = oTmpMeasurements._err_description
            Me._err_source = oTmpMeasurements._err_source
            Return True
        End If
        oDataTable._measure_from = oTmpMeasurements._measurments_html
        oDataTable._s_measure = oTmpMeasurements._measurments

        '--- RUN SECOND TIME
        oTmpMeasurements = New ion_two.cls_measurement
        oTmpMeasurements._m1 = nMeasure1to
        oTmpMeasurements._m2 = nMeasure2to
        oTmpMeasurements._m3 = nMeasure3to
        bError = oTmpMeasurements.get_measurements
        If bError Then
            Me._err_number = oTmpMeasurements._err_number
            Me._err_description = oTmpMeasurements._err_description
            Me._err_source = oTmpMeasurements._err_source
            Return True
        End If
        oDataTable._measure_to = oTmpMeasurements._measurments_html


        '--- release
        oTmpMeasurements = Nothing

        Return False
        Exit Function

ErrorHandler:
        Me._err_number = Err.Number
        Me._err_description = Err.Description
        Me._err_source = Err.Source
        Return True

    End Function

End Class
