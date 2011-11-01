Public Class cls_box_items_lgc
	Inherits iFoundation.cls_logics

	Sub New()
		'--- Set working table
		Me._tablename = "bx_BOX_ITEMS"

		'--- Get module name
		Dim oTmpStack As New System.Diagnostics.StackFrame
		Me._module = oTmpStack.GetMethod.ReflectedType.FullName()
		oTmpStack = Nothing

	End Sub

	Function read(ByVal nId As Int32, ByRef oBoxMaster As skl_box_master) As Boolean
		On Error GoTo ErrorHandler
		Dim bError As Boolean = False

		'--- Get Item
		Dim oReadTransactor As New iDac.cls_T_read
		oReadTransactor._connection_string = Me._connection_string
		oReadTransactor._dbtype = Me._dbtype
		oReadTransactor._tablename = Me._tablename
		bError = oReadTransactor.transact_read("select * from " + Me._tablename + " where (boxmaster_no = " + Convert.ToString(oBoxMaster._boxmaster_no) + ") and (box_no = " + Convert.ToString(nId) + ") order by item_position")
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
		Dim oDataTable As New skl_box_item

		Dim nLoop As Int16
		For nLoop = 0 To oReadTransactor._datatable.Rows.Count - 1
			oDataTable = New skl_box_item
			oTmpDataRow = oReadTransactor._datatable.Rows(nLoop)

			oDataTable._id = oTmpDataRow("id")
			oDataTable._boxmaster_no = oTmpDataRow("boxmaster_no")
			oDataTable._box_no = oTmpDataRow("box_no")
			oDataTable._inventory_id = oTmpDataRow("inventory_id")
			oDataTable._position = oTmpDataRow("item_position")

			oBoxMaster._items.Add(oDataTable)

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


End Class
