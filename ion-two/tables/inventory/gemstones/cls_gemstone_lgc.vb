Public Class cls_gemstone_lgc
	Inherits iFoundation.cls_logics_sub

	Sub New()
		'--- Set working table
		Me._TableName = "inv_GEMSTONES"

		'--- Get module name
		Dim oTmpStack As New System.Diagnostics.StackFrame
		Me._module = oTmpStack.GetMethod.ReflectedType.FullName()
		oTmpStack = Nothing

	End Sub

	Function insert(ByRef oDataTable As skl_gemstone) As Boolean
		On Error GoTo ErrorHandler

		'--- local definitions
		Dim bError As Boolean = False

		'--- Get Dataset
		Dim oTmpDataset As DataSet = New ion_two.ds_gemstones
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
		oTmpDataRow("STONETYPE_ID") = oDataTable._stonetype_id
		oTmpDataRow("ORIGIN_ID") = oDataTable._origin_id
		oTmpDataRow("SHAPE_ID") = oDataTable._shape_id
		oTmpDataRow("COLOR_ID") = oDataTable._color_id
        oTmpDataRow("COLORTYPE_ID") = oDataTable._colortype_id
		oTmpDataRow("CLARITY_ID") = oDataTable._clarity_id
		oTmpDataRow("CLARITYTYPE_ID") = oDataTable._claritytype_id
		oTmpDataRow("COLORTO_ID") = oDataTable._colorto_id
		oTmpDataRow("COLORTYPETO_ID") = oDataTable._colortypeto_id
		oTmpDataRow("CLARITYTO_ID") = oDataTable._clarityto_id
		oTmpDataRow("CLARITYTYPETO_ID") = oDataTable._claritytypeto_id
		oTmpDataRow("GRADE_ID") = oDataTable._grade_id
		oTmpDataRow("BRIGHTNESS_ID") = oDataTable._brightness_id
		oTmpDataRow("LUSTER_ID") = oDataTable._luster_id
		oTmpDataRow("SATURATION_ID") = oDataTable._saturation_id
		oTmpDataRow("ENHANCEMENT_ID") = oDataTable._enhancement_id
		oTmpDataRow("CUT_ID") = oDataTable._cut_id
        oTmpDataRow("REPORT_ID") = oDataTable._report_id
        oTmpDataRow("FREECOLOR") = oDataTable.freecolor

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

	Function read(ByVal nId As Int32, ByRef oDataTable As skl_gemstone) As Boolean
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
		oDataTable._stonetype_id = oTmpDataRow("STONETYPE_ID")
		oDataTable._origin_id = oTmpDataRow("ORIGIN_ID")
		oDataTable._shape_id = oTmpDataRow("SHAPE_ID")
		oDataTable._color_id = oTmpDataRow("COLOR_ID")
        oDataTable._colortype_id = oTmpDataRow("COLORTYPE_ID")
		oDataTable._clarity_id = oTmpDataRow("CLARITY_ID")
		oDataTable._claritytype_id = oTmpDataRow("CLARITYTYPE_ID")
		oDataTable._colorto_id = oTmpDataRow("COLORTO_ID")
		oDataTable._colortypeto_id = oTmpDataRow("COLORTYPETO_ID")
		oDataTable._clarityto_id = oTmpDataRow("CLARITYTO_ID")
		oDataTable._claritytypeto_id = oTmpDataRow("CLARITYTYPETO_ID")
		oDataTable._grade_id = oTmpDataRow("GRADE_ID")
		oDataTable._brightness_id = oTmpDataRow("BRIGHTNESS_ID")
		oDataTable._luster_id = oTmpDataRow("LUSTER_ID")
		oDataTable._saturation_id = oTmpDataRow("SATURATION_ID")
		oDataTable._enhancement_id = oTmpDataRow("ENHANCEMENT_ID")
		oDataTable._cut_id = oTmpDataRow("CUT_ID")
        oDataTable._report_id = oTmpDataRow("REPORT_ID")

        If Not Convert.IsDBNull(oTmpDataRow("freecolor")) Then
            oDataTable.freecolor = oTmpDataRow("freecolor")
        End If


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

    Function update(ByRef oDataTable As skl_gemstone, Optional ByVal replicate As Boolean = False) As Boolean
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
        oTmpDataRow("STONETYPE_ID") = oDataTable._stonetype_id
        oTmpDataRow("ORIGIN_ID") = oDataTable._origin_id
        oTmpDataRow("SHAPE_ID") = oDataTable._shape_id
        oTmpDataRow("COLOR_ID") = oDataTable._color_id
        oTmpDataRow("COLORTYPE_ID") = oDataTable._colortype_id
        oTmpDataRow("CLARITY_ID") = oDataTable._clarity_id
        oTmpDataRow("CLARITYTYPE_ID") = oDataTable._claritytype_id
        oTmpDataRow("COLORTO_ID") = oDataTable._colorto_id
        oTmpDataRow("COLORTYPETO_ID") = oDataTable._colortypeto_id
        oTmpDataRow("CLARITYTO_ID") = oDataTable._clarityto_id
        oTmpDataRow("CLARITYTYPETO_ID") = oDataTable._claritytypeto_id
        oTmpDataRow("GRADE_ID") = oDataTable._grade_id
        oTmpDataRow("BRIGHTNESS_ID") = oDataTable._brightness_id
        oTmpDataRow("LUSTER_ID") = oDataTable._luster_id
        oTmpDataRow("SATURATION_ID") = oDataTable._saturation_id
        oTmpDataRow("ENHANCEMENT_ID") = oDataTable._enhancement_id
        oTmpDataRow("CUT_ID") = oDataTable._cut_id
        oTmpDataRow("REPORT_ID") = oDataTable._report_id
        oTmpDataRow("freecolor") = oDataTable.freecolor
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

    Function load(ByVal nMode As Int16, ByVal oDataRow As DataRow, ByRef oDataTable As skl_lst_gemstone, Optional ByVal oPictures As ion_two.cls_pictures = Nothing, Optional ByVal bIsdealer As Boolean = False, Optional ByVal bSSL As Boolean = False) As Boolean
        On Error GoTo ErrorHandler
        Dim bError As Boolean = False

        oDataTable._weight = oDataRow.Item("weight")
        oDataTable._quantity = oDataRow.Item("quantity")
        oDataTable._stonetype = oDataRow.Item("stonetype")
        oDataTable._shape = oDataRow.Item("shape")
        oDataTable._origin = oDataRow.Item("origin")
        oDataTable._report = oDataRow.Item("report")
        oDataTable._color_sort = oDataRow.Item("color_sort")
        oDataTable._clarity_sort = oDataRow.Item("clarity_sort")
        oDataTable._shape_sort = oDataRow.Item("shape_sort")
        oDataTable._report_sort = oDataRow.Item("report_sort")
        oDataTable._grade_sort = oDataRow.Item("grad_sort")
        oDataTable._grade = oDataRow.Item("grade")

        oDataTable._colorfrom = oDataRow.Item("colorfrom")
        oDataTable._clarityfrom = oDataRow.Item("clarityfrom")
        oDataTable._colorto = oDataRow.Item("colorto")
        oDataTable._clarityto = oDataRow.Item("clarityto")



        '--- Strip unneccery dashes at the end of the colors
        bError = Me.strimdash(oDataTable._colorfrom)
        bError = Me.strimdash(oDataTable._clarityfrom)
        bError = Me.strimdash(oDataTable._colorto)
        bError = Me.strimdash(oDataTable._clarityto)

        If nMode < 10 Then
            oDataTable._brightness = oDataRow.Item("brightness")
            oDataTable._luster = oDataRow.Item("luster")
            oDataTable._saturation = oDataRow.Item("saturation")
            oDataTable._enhancement = oDataRow.Item("enhancement")
            oDataTable._cut = oDataRow.Item("cut")
            If Not Convert.IsDBNull(oDataRow.Item("freecolor")) Then
                oDataTable.freecolor = oDataRow.Item("freecolor")
            End If
        End If

        '--- Format decimals
        Dim oStringFunctions As New iFunctions.cls_string
        bError = oStringFunctions.format_decimal(oDataTable._weight, oDataTable._s_weight, "Ct.")
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

    Public Function strimdash(ByRef cTmpVar As String) As Boolean
        On Error GoTo ErrorHandler
        Dim bError As Boolean = False

        '--- Trim var
        cTmpVar = Trim(cTmpVar)

        If cTmpVar.EndsWith("- -") Then
            If Len(cTmpVar) > 3 Then
                cTmpVar = Mid(cTmpVar, 1, Len(cTmpVar) - 3)
            Else
                cTmpVar = Mid(cTmpVar, 1, Len(cTmpVar) - 2)
            End If


        ElseIf cTmpVar.EndsWith("-") Then
            If Len(cTmpVar) > 1 Then
                cTmpVar = Mid(cTmpVar, 1, Len(cTmpVar) - 1)
            End If


        End If


        '--- Trim again var
        cTmpVar = Trim(cTmpVar)



        Return False
        Exit Function

ErrorHandler:
        Me._err_number = Err.Number
        Me._err_description = Err.Description
        Me._err_source = Err.Source
        Return True

    End Function

End Class
