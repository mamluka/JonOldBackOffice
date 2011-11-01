Public Class cls_books_general_lgc
	Inherits iFoundation.cls_logics_sub

	Sub New()
		'--- Set working table
		Me._tablename = "acc_GENERAL_BOOKS"

		'--- Get module name
		Dim oTmpStack As New System.Diagnostics.StackFrame
		Me._module = oTmpStack.GetMethod.ReflectedType.FullName()
		oTmpStack = Nothing

	End Sub

	Function insert(ByRef oRowCollection As Collection) As Boolean
		On Error GoTo ErrorHandler

		'--- local definitions
		Dim bError As Boolean = False

		'--- Get Dataset
		Dim oTmpDataset As DataSet = New ion_two.ds_books_general
		Dim oTmpDataTable As DataTable = oTmpDataset.Tables(_tablename)

		'--- Assign Order
		Dim oTmpDataRow As DataRow

		Dim nLoop_1 As Int16
		For nLoop_1 = 1 To oRowCollection.Count
			oTmpDataRow = oTmpDataTable.NewRow

			oTmpDataRow("trs_id") = oRowCollection(nLoop_1)._trs_id
			oTmpDataRow("order_id") = oRowCollection(nLoop_1)._order_id
			oTmpDataRow("account_id") = oRowCollection(nLoop_1)._account_id
			oTmpDataRow("trs_date") = oRowCollection(nLoop_1)._trs_date
			oTmpDataRow("description") = oRowCollection(nLoop_1)._description
			oTmpDataRow("rate_ils") = oRowCollection(nLoop_1)._rate_ils
			oTmpDataRow("amount") = oRowCollection(nLoop_1)._amount
			oTmpDataRow("LastModify_date") = oRowCollection(nLoop_1)._LastModify_date
			oTmpDataRow("LastModify_user") = oRowCollection(nLoop_1)._LastModify_user
			oTmpDataRow("LastModify_user_id") = oRowCollection(nLoop_1)._LastModify_user_id

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
