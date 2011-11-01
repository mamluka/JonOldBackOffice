Public Class cls_books_suppliers_lgc
	Inherits iFoundation.cls_logics_sub

	Sub New()
		'--- Set working table
		Me._tablename = "acc_SUPPLIERS_BOOKS"

		'--- Get module name
		Dim oTmpStack As New System.Diagnostics.StackFrame
		Me._module = oTmpStack.GetMethod.ReflectedType.FullName()
		oTmpStack = Nothing

	End Sub

	Function insert(ByRef oRowCollection As Collection) As Boolean
		On Error GoTo ErrorHandler
		Dim bError As Boolean = False

		'--- Get Dataset
		Dim oTmpDataset As DataSet = New ion_two.ds_books_suppliers
		Dim oTmpDataTable As DataTable = oTmpDataset.Tables(_tablename)

		'--- Assign Order
		Dim oTmpDataRow As DataRow
		Dim nLoop As Int16
		For nLoop = 1 To oRowCollection.Count
			oTmpDataRow = oTmpDataTable.NewRow

			oTmpDataRow("trs_id") = oRowCollection(nLoop)._trs_id
			oTmpDataRow("order_id") = oRowCollection(nLoop)._order_id
			oTmpDataRow("item_id") = oRowCollection(nLoop)._item_id
			oTmpDataRow("item_qty") = oRowCollection(nLoop)._item_qty
			oTmpDataRow("supplier_id2") = oRowCollection(nLoop)._supplier_id2
			oTmpDataRow("trs_date") = oRowCollection(nLoop)._trs_date
			oTmpDataRow("description") = oRowCollection(nLoop)._description
			oTmpDataRow("rate_ils") = oRowCollection(nLoop)._rate_ils
			oTmpDataRow("amount") = oRowCollection(nLoop)._amount
			oTmpDataRow("LastModify_date") = oRowCollection(nLoop)._LastModify_date
			oTmpDataRow("LastModify_user") = oRowCollection(nLoop)._LastModify_user
			oTmpDataRow("LastModify_user_id") = oRowCollection(nLoop)._LastModify_user_id

			oTmpDataTable.Rows.Add(oTmpDataRow)
		Next

		'--- Instantiate the Transactor
		Dim oTransactor As New iDac.cls_T_transactor
		oTransactor._connection_string = Me._connection_string
		oTransactor._dbtype = Me._dbtype

		'--- Prepare and load table 1
		Dim oTable1 As New iDac.cls_cll_datatables
		oTable1._datatable = oTmpDataTable
		oTransactor._i_cll_datatables.Add(oTable1)
		oTransactor._transaction = Me._idac_transaction._transaction

		'--- Write Table
		bError = oTransactor.transact_insert
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



End Class
