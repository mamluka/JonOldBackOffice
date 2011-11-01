Public Class cls_functions_inventory
	Inherits iFoundation.cls_error_connection

	Public Function get_subcategory_name(ByRef nId As Int32, ByRef cName As String) As Boolean
		On Error GoTo ErrorHandler

		'--- local definitions
		Dim bError As Boolean = False

		'--- Define information to read
		Dim oTmpDataBroker As New iDac.cls_T_datareader
		oTmpDataBroker._dbtype = Me._dbtype
		oTmpDataBroker._connection_string = Me._connection_string
		oTmpDataBroker._table = "inv_SUBCATEGORIES"
		oTmpDataBroker._id = nId

		'--- Define records
		Dim oField1 As New iDac.cls_cll_datareader
		oField1._field = "id"
		oTmpDataBroker._fields.Add(oField1)
		oField1 = Nothing

		Dim oField2 As New iDac.cls_cll_datareader
		oField2._field = "lang1_longdescr"
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
		If oTmpDataBroker._hasresult Then
			nId = oTmpDataBroker._fields.Item(1)._result
			cName = oTmpDataBroker._fields.Item(2)._result
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

	Public Function set_cur_inventory(ByVal nOrder_id As Int32, ByVal nQuantity As Int16) As Boolean
		On Error GoTo ErrorHandler

		'--- local definitions
		Dim bError As Boolean = False

		Dim oDacCommand As New iDac.cls_T_command
		oDacCommand._connection_string = Me._connection_string
		oDacCommand._dbtype = Me._dbtype
		oDacCommand._transaction = Me._idac_transaction._transaction
		oDacCommand._sqlstring = "update inv_inventory set qtyonstock_cur = qtyonstock_cur -" + Convert.ToString(nQuantity) + " where id='" + Convert.ToString(nOrder_id) + "'"
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

	Public Function get_item_id(ByVal cItemNumber As String, ByRef nItem_id As Int32) As Boolean
		On Error GoTo ErrorHandler
		Dim bError As Boolean = False

		'--- Define information to read
		Dim oTmpDataBroker As New iDac.cls_T_datareader
		oTmpDataBroker._dbtype = Me._dbtype
		oTmpDataBroker._connection_string = Me._connection_string
		oTmpDataBroker._table = "inv_inventory"

		Dim cSQL As String
		cSQL = "select id from inv_inventory where (itemnumber = '" + cItemNumber + "')"

		'--- Define records
		Dim oField1 As New iDac.cls_cll_datareader
		oField1._field = "id"
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
			nItem_id = oTmpDataBroker._fields.Item(1)._result
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
