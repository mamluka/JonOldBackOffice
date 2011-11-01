Public Class cls_functions_suppliers
	Inherits iFoundation.cls_error_connection

	Public Function get_supplier_id2(ByVal nSupplier_Id As Int32, ByVal nBranch_Id As Int32, ByRef nId2 As Int32) As Boolean
		On Error GoTo ErrorHandler
		Dim bError As Boolean = False

		'--- Define information to read
		Dim oTmpDataBroker As New iDac.cls_T_datareader
		oTmpDataBroker._dbtype = Me._dbtype
		oTmpDataBroker._connection_string = Me._connection_string
		oTmpDataBroker._table = "acc_cashflow"

		Dim cSQL As String
		cSQL = "select id2 from spl_suppliers where branch_id = " & nBranch_Id & " and suppliernumber = " & nSupplier_Id

		'--- Define records
		Dim oField1 As New iDac.cls_cll_datareader
		oField1._field = "id2"
		oTmpDataBroker._fields.Add(oField1)
		oField1 = Nothing

		'--- Get info
		bError = oTmpDataBroker.read(cSQL)
		If bError Then
			Me._err_number = oTmpDataBroker._err_number
			Me._err_description = oTmpDataBroker._err_description
			Me._err_source = oTmpDataBroker._err_source
			Return True
		End If

		'--- Fill results
		If oTmpDataBroker._hasresult Then
			nId2 = oTmpDataBroker._fields.Item(1)._result
		End If


		Return False
		Exit Function

ErrorHandler:

		'--- register the error
		Me._err_number = Err.Number
		Me._err_description = Err.Description
		Me._err_source = Err.Source
		Return True

	End Function

	Public Function get_supplier_total(ByVal nSupplier_Id As Int32, ByRef nSupplierTotal As Decimal) As Boolean
		On Error GoTo ErrorHandler
		Dim bError As Boolean = False

		'--- Define information to read
		Dim oTmpDataBroker As New iDac.cls_T_datareader
		oTmpDataBroker._dbtype = Me._dbtype
		oTmpDataBroker._connection_string = Me._connection_string
		oTmpDataBroker._table = "acc_cashflow"

		Dim cSQL As String
		cSQL = "select sum(amount) as amount from v_suppliers_books where supplier_id2 = " & nSupplier_Id

		'--- Define records
		Dim oField1 As New iDac.cls_cll_datareader
		oField1._field = "amount"
		oTmpDataBroker._fields.Add(oField1)
		oField1 = Nothing

		'--- Get info
		bError = oTmpDataBroker.read(cSQL)
		If bError Then
			Me._err_number = oTmpDataBroker._err_number
			Me._err_description = oTmpDataBroker._err_description
			Me._err_source = oTmpDataBroker._err_source
			Return True
		End If

		'--- Fill results
		If oTmpDataBroker._hasresult Then
			nSupplierTotal = oTmpDataBroker._fields.Item(1)._result
		End If


		Return False
		Exit Function

ErrorHandler:

		'--- register the error
		Me._err_number = Err.Number
		Me._err_description = Err.Description
		Me._err_source = Err.Source
		Return True

	End Function

	Public Function get_supplier_company(ByVal nSupplier_Id As Int32, ByRef cSupplierCompany As String) As Boolean
		On Error GoTo ErrorHandler
		Dim bError As Boolean = False

		'--- Define information to read
		Dim oTmpDataBroker As New iDac.cls_T_datareader
		oTmpDataBroker._dbtype = Me._dbtype
		oTmpDataBroker._connection_string = Me._connection_string
		oTmpDataBroker._table = "acc_cashflow"

		Dim cSQL As String
		cSQL = "select branch_id, suppliernumber, company from spl_suppliers where id2 = " & nSupplier_Id

		'--- Define records
		Dim oField1 As New iDac.cls_cll_datareader
		oField1._field = "branch_id"
		oTmpDataBroker._fields.Add(oField1)
		oField1 = Nothing

		Dim oField2 As New iDac.cls_cll_datareader
		oField2._field = "suppliernumber"
		oTmpDataBroker._fields.Add(oField2)
		oField2 = Nothing

		Dim oField3 As New iDac.cls_cll_datareader
		oField3._field = "company"
		oTmpDataBroker._fields.Add(oField3)
		oField3 = Nothing

		'--- Get info
		bError = oTmpDataBroker.read(cSQL)
		If bError Then
			Me._err_number = oTmpDataBroker._err_number
			Me._err_description = oTmpDataBroker._err_description
			Me._err_source = oTmpDataBroker._err_source
			Return True
		End If

		'--- Fill results
		Dim nBranchId As Int32
		Dim nSupplierNumber As Int32
		If oTmpDataBroker._hasresult Then
			cSupplierCompany = oTmpDataBroker._fields.Item(1)._result
			nBranchId = oTmpDataBroker._fields.Item(2)._result
			nSupplierNumber = oTmpDataBroker._fields.Item(3)._result
		End If

		'--- Create proper supplier company
		Dim cTmpName As String
		cTmpName = Convert.ToString(nBranchId).Trim
		If cTmpName.Length = 1 Then
			cTmpName = "0" + cTmpName
		End If
		cTmpName = cTmpName + "-" + cSupplierCompany.Trim
		cSupplierCompany = cTmpName

		Return False
		Exit Function

ErrorHandler:

		'--- register the error
		Me._err_number = Err.Number
		Me._err_description = Err.Description
		Me._err_source = Err.Source
		Return True

	End Function


End Class
