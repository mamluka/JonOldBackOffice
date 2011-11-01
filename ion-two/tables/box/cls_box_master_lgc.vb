Public Class cls_box_master_lgc
	Inherits iFoundation.cls_logics

	Sub New()
		'--- Set working table
		Me._tablename = "bx_BOX_MASTER"

		'--- Get module name
		Dim oTmpStack As New System.Diagnostics.StackFrame
		Me._module = oTmpStack.GetMethod.ReflectedType.FullName()
		oTmpStack = Nothing

	End Sub

	Function insert(ByRef oDataTable As skl_cashflow) As Boolean
		On Error GoTo ErrorHandler
		Dim bError As Boolean = False

		Return False
		Exit Function

ErrorHandler:
		Me._err_number = Err.Number
		Me._err_description = Err.Description
		Me._err_source = Err.Source
		Return True
	End Function

	Function read(ByVal nBoxMaster As Int32, ByVal nBox As Int32, ByRef oBoxMaster As Collection) As Boolean
		On Error GoTo ErrorHandler
		Dim bError As Boolean = False

		'--- Get Item
		Dim oReadTransactor As New iDac.cls_T_read
		oReadTransactor._connection_string = Me._connection_string
		oReadTransactor._dbtype = Me._dbtype
		oReadTransactor._tablename = Me._tablename

		Dim cSQL As String
		cSQL = "select * from " + Me._tablename + " where (boxmaster_no= " + Convert.ToString(nBoxMaster) + ")"
		If nBox > 0 Then
			cSQL = cSQL + " and (box_no = " + Convert.ToString(nBox) + ")"
		End If

		bError = oReadTransactor.transact_read(cSQL)
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
		Dim oDataTable As New skl_box_master
		Dim oTmpDataRow As DataRow

		Dim nLoop As Int16
		For nLoop = 0 To oReadTransactor._datatable.Rows.Count - 1

			oDataTable = New skl_box_master
			oTmpDataRow = oReadTransactor._datatable.Rows(nLoop)

			oDataTable._id = oTmpDataRow("id")
			oDataTable._box_no = oTmpDataRow("box_no")
			oDataTable._boxmaster_no = oTmpDataRow("boxmaster_no")
			oDataTable._shape_id = oTmpDataRow("shape_id")
			oDataTable._stonetype_id = oTmpDataRow("stonetype_id")
			oDataTable._header_description = oTmpDataRow("header_description")
			oDataTable._platina_description = oTmpDataRow("platina_description")
			oDataTable._wgold_description = oTmpDataRow("wgold_description")
			oDataTable._ygold_description = oTmpDataRow("ygold_description")
			oDataTable._filename = Trim(oTmpDataRow("filename"))

			'--- Get shape parameters
			oDataTable._shape.get_shape(oDataTable._stonetype_id, oDataTable._shape_id)

			'--- Get Stonetype
			oDataTable._stonetype.get_stonetype(oDataTable._stonetype_id)

			'--- Get content
			'Dim oBoxItems As ion_two.skl_box_item
			Dim oBoxitems_logics As New ion_two.cls_box_items_lgc
			oBoxitems_logics._connection_string = Me._connection_string
			oBoxitems_logics._dbtype = Me._dbtype
			bError = oBoxitems_logics.read(oDataTable._box_no, oDataTable)
			If bError Then
				Me._err_number = oBoxitems_logics._err_number
				Me._err_description = oBoxitems_logics._err_description
				Me._err_source = oBoxitems_logics._err_source
				Return True
			End If
			'oDataTable._items.Add(oDataTable)

			oBoxMaster.Add(oDataTable)
			oDataTable = Nothing

		Next

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

	Function update(ByRef oDataTable As skl_cashflow) As Boolean
		On Error GoTo ErrorHandler
		Dim bError As Boolean = False

		Return False
		Exit Function

ErrorHandler:
		Me._err_number = Err.Number
		Me._err_description = Err.Description
		Me._err_source = Err.Source
		Return True

	End Function



End Class
