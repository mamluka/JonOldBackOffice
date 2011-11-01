Public Class cls_order_items_lgc
	Inherits iFoundation.cls_logics_sub

	Sub New()
		'--- Set working table
		Me._tablename = "acc_ORDER_ITEMS"

		'--- Get module name
		Dim oTmpStack As New System.Diagnostics.StackFrame
		Me._module = oTmpStack.GetMethod.ReflectedType.FullName()
		oTmpStack = Nothing

	End Sub

	Function insert(ByRef oDataTable As skl_order, ByVal nOrder_id As Int32, ByVal nOrderNumber As Int32) As Boolean
		On Error GoTo ErrorHandler
		Dim bError As Boolean = False

		'--- Get DataTable for Order Items
		Dim oTmpDataset As DataSet = New ion_two.ds_order_items
		Dim oTmpDataTable As DataTable = oTmpDataset.Tables("acc_ORDER_ITEMS")
		'--- Assign Order Items
		Dim oTmpDataRow As DataRow
		Dim nLoop As Int16
        For nLoop = 1 To oDataTable._order_items.Count

            If Not oDataTable._order_items.Item(nLoop).placeholder Then


                oTmpDataRow = oTmpDataTable.NewRow

                oTmpDataRow("order_id") = nOrder_id
                oTmpDataRow("OrderNumber") = nOrderNumber
                oTmpDataRow("Item_id") = oDataTable._order_items.Item(nLoop).id
                oTmpDataRow("Item_no") = oDataTable._order_items.Item(nLoop).item_number
                oTmpDataRow("Item_quantity") = oDataTable._order_items.Item(nLoop).quantity
                oTmpDataRow("jewelsize") = oDataTable._order_items.Item(nLoop).ringsize
                oTmpDataRow("extrainfo") = oDataTable._order_items.Item(nLoop).extrainfo

                oTmpDataTable.Rows.Add(oTmpDataRow)
            End If
        Next

        '--- Instantiate the Transactor
        Dim oTransactor As New iDac.cls_T_transactor
        oTransactor._transaction = Me._idac_transaction._transaction
        oTransactor._connection_string = Me._connection_string
        oTransactor._dbtype = Me._dbtype

        '--- Prepare and load table 
        Dim oTable1 As New iDac.cls_cll_datatables
        oTable1._datatable = oTmpDataTable
        oTransactor._i_cll_datatables.Add(oTable1)

        '--- Write Table
        bError = oTransactor.transact_insert
        If bError Then
            Me._idac_transaction._transaction.Rollback()
            Me._err_number = oTransactor._err_number
            Me._err_description = oTransactor._err_description
            Me._err_source = oTransactor._err_source
            Return True
        End If

        '--- Release
        oTransactor = Nothing

        Return False
        Exit Function

ErrorHandler:
        Me._err_number = Err.Number
        Me._err_description = Err.Description
        Me._err_source = Err.Source
        Return True
	End Function


	Function read(ByVal nId As Int32, ByRef oDataTable As skl_order) As Boolean
		On Error GoTo ErrorHandler
		Dim bError As Boolean = False

		'--- Get Item
		Dim oReadTransactor As New iDac.cls_T_read
		oReadTransactor._connection_string = Me._connection_string
		oReadTransactor._dbtype = Me._dbtype
		oReadTransactor._tablename = Me._tablename
		bError = oReadTransactor.transact_read("select * from acc_ORDER_ITEMS where order_id=" & nId)
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


		Dim nLoop As Int32
		For nLoop = 0 To oReadTransactor._datatable.Rows.Count - 1
			Dim oOrderItem As New skl_order_item
			Dim oRow As DataRow = oReadTransactor._datatable.Rows.Item(nLoop)

			oOrderItem._id = oRow("id")
			oOrderItem._order_id = oRow("ordernumber")
			oOrderItem._item_id = oRow("item_id")
			oOrderItem._item_no = oRow("item_no")
			oOrderItem._item_quantity = oRow("Item_quantity")
            oOrderItem._jewelsize = oRow("jewelsize")
            If Not Convert.IsDBNull(oRow("extrainfo")) Then
                oOrderItem._extrainfo = oRow("extrainfo")
            End If
            oDataTable._order_items.Add(oOrderItem)
        Next

		'--- release
		oReadTransactor = Nothing

		Return False
		Exit Function

ErrorHandler:
		Me._err_number = Err.Number
		Me._err_description = Err.Description
		Me._err_source = Err.Source
		Return True

	End Function

	Public Function update(ByRef oDataTable As skl_order) As Boolean
		On Error GoTo ErrorHandler
		Dim bError As Boolean = False


		Dim oTmpTransact As New iDac.cls_T_read
		oTmpTransact._connection_string = Me._connection_string
		oTmpTransact._dbtype = Me._dbtype
		oTmpTransact._tablename = Me._tablename
		bError = oTmpTransact.transact_read("select * from acc_ORDER_ITEMS where order_id=" & oDataTable._id)
		If bError Then
			Me._err_number = oTmpTransact._err_number
			Me._err_description = oTmpTransact._err_description
			Me._err_source = oTmpTransact._err_source
			Return True
		End If

		'--- Get Datatable
		Dim oTmpDataTable As DataTable = oTmpTransact._datatable

		'--- Clear records
		oTmpDataTable.Clear()


		'--- Assign Order_Items
		Dim nLoop As Integer
		Dim oTmpDataRow_item As DataRow


		'--- delete existing records
		bError = Me.delete_order_items(oDataTable._id)
		If bError Then
			Me._err_number = Err.Number
			Me._err_description = Err.Description
			Me._err_source = Err.Source
			Return True
		End If


		'--- Add All Order_Items
		For nLoop = 1 To oDataTable._order_items.Count
			oTmpDataRow_item = oTmpDataTable.NewRow

			oTmpDataRow_item("order_id") = oDataTable._id
			oTmpDataRow_item("OrderNumber") = oDataTable._ordernumber
			oTmpDataRow_item("Item_id") = oDataTable._order_items(nLoop)._item_id
			oTmpDataRow_item("Item_no") = oDataTable._order_items(nLoop)._item_no
			oTmpDataRow_item("Item_quantity") = oDataTable._order_items(nLoop)._item_quantity
			oTmpDataRow_item("jewelsize") = oDataTable._order_items(nLoop)._jewelsize
            oTmpDataRow_item("extrainfo") = oDataTable._order_items.Item(nLoop)._extrainfo
			oTmpDataTable.Rows.Add(oTmpDataRow_item)

		Next

		'--- Instantiate the Transactor
		Dim oTransactor As New iDac.cls_T_transactor
		oTransactor._connection_string = Me._connection_string
		oTransactor._dbtype = Me._dbtype
		oTransactor._transaction = Me._idac_transaction._transaction

		'--- Prepare and load table 1
		Dim oTable1 As New iDac.cls_cll_datatables
		oTable1._datatable = oTmpDataTable
		oTable1._ignoreget = True
		oTransactor._i_cll_datatables.Add(oTable1)

		bError = oTransactor.transact_update
		If bError Then
			Me._err_number = oTransactor._err_number
			Me._err_description = oTransactor._err_description
			Me._err_source = oTransactor._err_source
			Return True
		End If

		oTable1 = Nothing
		oTransactor = Nothing



		Return False
		Exit Function

ErrorHandler:
		Me._err_number = Err.Number
		Me._err_description = Err.Description
		Me._err_source = Err.Source
		Return True
	End Function

	Private Function delete_order_items(ByVal nId As Int32) As Boolean
		On Error GoTo ErrorHandler

		'--- local definitions
		Dim bError As Boolean = False

		Dim oDacCommand As New iDac.cls_T_command
		oDacCommand._connection_string = Me._connection_string
		oDacCommand._dbtype = Me._dbtype
		oDacCommand._transaction = Me._idac_transaction._transaction
		oDacCommand._sqlstring = "delete from " + Me._tablename + " where order_id=" + Convert.ToString(nId)
		bError = oDacCommand.transact_command
		If bError Then
			Me._err_number = oDacCommand._err_number
			Me._err_description = oDacCommand._err_description
			Me._err_source = oDacCommand._err_source
			Return True
		End If


		Return False
		Exit Function

ErrorHandler:
		Me._err_number = Err.Number
		Me._err_description = Err.Description
		Me._err_source = Err.Source
		Return True

	End Function



End Class
