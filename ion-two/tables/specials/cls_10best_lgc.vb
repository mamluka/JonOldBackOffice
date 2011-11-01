Public Class cls_10best_lgc
	Inherits iFoundation.cls_logics

	Sub New()
		'--- Set working table
		Me._tablename = "vv_jewelry_full"

		'--- Get module name
		Dim oTmpStack As New System.Diagnostics.StackFrame
		Me._module = oTmpStack.GetMethod.ReflectedType.FullName()
		oTmpStack = Nothing

	End Sub

	Function read(ByRef o10Best As Collection) As Boolean
		On Error GoTo ErrorHandler
		Dim bError As Boolean = False

		'--- Get Item
		Dim oReadTransactor As New iDac.cls_T_read
		oReadTransactor._connection_string = Me._connection_string
		oReadTransactor._dbtype = Me._dbtype
		oReadTransactor._tablename = Me._tablename
		bError = oReadTransactor.transact_read("select * from " + Me._tablename + " where category_id = 7 and subcategory_id = 44 and shopstatus=1 and itemdeleted=0 and sell_price>1 and qtyonstock_cur>0 order by id")
		If bError Then
			Me._err_number = oReadTransactor._err_number
			Me._err_description = oReadTransactor._err_description
			Me._err_source = oReadTransactor._err_source
		End If

		'--- Return Error if no records were fatched
		If oReadTransactor._datatable.Rows.Count = 0 Then
			Err.Raise(7003, Me._module + ":read", "No records fetched.")
		End If

		'--- Map to Skeleton
		Dim oTmpDataRow As DataRow
		Dim oDataTable As New skl_10best

		'-- Randomize a RecordNumber
		Randomize()



		Dim nLoop As Int16
		For nLoop = 0 To 5
			oDataTable = New skl_10best

			'--- Take a random record
			Dim nRecords As Int32 = oReadTransactor._datatable.Rows.Count - 1
			Dim nRandom_Record As Int32 = CInt(Int((nRecords * Rnd()) + 1))
			oTmpDataRow = oReadTransactor._datatable.Rows(nRandom_Record)

			'--- Assign ID
			'oDataTable._id = oTmpDataRow("id")
			oDataTable._inventory_id = oTmpDataRow("id")

			Dim nLoop2 As Int16
			For nLoop2 = 1 To o10Best.Count
				If o10Best.Item(nLoop2)._inventory_id = oDataTable._inventory_id Then
					'--- Take a random record
					nRandom_Record = CInt(Int((nRecords * Rnd()) + 1))
					oTmpDataRow = oReadTransactor._datatable.Rows(nRandom_Record)
					oDataTable._inventory_id = oTmpDataRow("id")
					Exit For
				End If
			Next

			o10Best.Add(oDataTable)
		Next



		'For nLoop = 0 To oReadTransactor._datatable.Rows.Count - 1
		'oDataTable = New skl_10best
		'oTmpDataRow = oReadTransactor._datatable.Rows(nLoop)'

		'oDataTable._id = oTmpDataRow("id")
		'oDataTable._inventory_id = oTmpDataRow("inventory_id")

		'o10Best.Add(oDataTable)

		'Next

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
