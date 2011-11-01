Public Class cls_supplier_no
	Inherits iFoundation.cls_error_connection

	Public _transaction As Object

	Sub New()
		Me._transaction = Nothing

	End Sub

	Public Function get_counter(ByVal nBranch_id As Int32, ByVal nSupplier_no As Int32, ByRef nCounter As Int32) As Boolean
		On Error GoTo ErrorHandler

		'--- local definitions
		Dim bError As Boolean = False

		'--- Define information to read
		'Dim oTmpDataBroker As New iDac.cls_mt_datadeader
		Dim oTmpDataBroker As New iDac.cls_T_datareader
		oTmpDataBroker._dbtype = Me._dbtype
		oTmpDataBroker._connection_string = Me._connection_string
		oTmpDataBroker._table = "spl_SUPPLIERS"
		oTmpDataBroker._clause = "suppliernumber = '" + Convert.ToString(nSupplier_no) + "' and branch_id ='" + Convert.ToString(nBranch_id) + "'"

		'--- Define records
		Dim oField1 As New iDac.cls_cll_datareader
		oField1._field = "id"
		oTmpDataBroker._fields.Add(oField1)
		oField1 = Nothing

		Dim oField2 As New iDac.cls_cll_datareader
		oField2._field = "lastitemnumber"
		oTmpDataBroker._fields.Add(oField2)
		oField2 = Nothing

		'--- Get info
		bError = oTmpDataBroker.read()
		If bError Then
			Me._err_number = oTmpDataBroker._err_number
			Me._err_description = oTmpDataBroker._err_description
			Me._err_source = oTmpDataBroker._err_source
			Return True
		End If

		'--- Fill results
		'nId = oTmpDataBroker._fields.Item(1)._result
		nCounter = oTmpDataBroker._fields.Item(2)._result + 1

		Return False
		Exit Function

ErrorHandler:

		'--- register the error
		Me._err_number = Err.Number
		Me._err_description = Err.Description
		Me._err_source = Err.Source
		Return True

	End Function

	Public Function set_counter(ByVal nBranch_no As Int16, ByVal nSupplier_no As Int32, ByVal nCounter As Int32) As Boolean
		On Error GoTo ErrorHandler

		'--- local definitions
		Dim bError As Boolean = False

		Dim oDacCommand As New iDac.cls_T_command
		oDacCommand._connection_string = Me._connection_string
		oDacCommand._dbtype = Me._dbtype
		oDacCommand._transaction = Me._transaction
		oDacCommand._sqlstring = "update spl_SUPPLIERS set LastItemNumber = " + Convert.ToString(nCounter) + " where branch_id='" + Convert.ToString(nBranch_no) + "' and suppliernumber ='" + Convert.ToString(nSupplier_no) + "'"
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
