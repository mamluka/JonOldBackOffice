Public Class cls_functions_orders
	Inherits iFoundation.cls_error_connection

	Public Function get_order_number(ByRef nOrder_Id As Int32, ByRef nNumber As Int32) As Boolean
		On Error GoTo ErrorHandler

		'--- local definitions
		Dim bError As Boolean = False

		'--- Define information to read
		Dim oTmpDataBroker As New iDac.cls_T_datareader
		oTmpDataBroker._dbtype = Me._dbtype
		oTmpDataBroker._connection_string = Me._connection_string
		oTmpDataBroker._table = "acc_ORDERS"
		oTmpDataBroker._id = nOrder_Id

		'--- Define records
		Dim oField1 As New iDac.cls_cll_datareader
		oField1._field = "id"
		oTmpDataBroker._fields.Add(oField1)
		oField1 = Nothing

		Dim oField2 As New iDac.cls_cll_datareader
		oField2._field = "ordernumber"
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
			nOrder_Id = oTmpDataBroker._fields.Item(1)._result
			nNumber = oTmpDataBroker._fields.Item(2)._result
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

	Public Function get_order_total(ByRef nOrder_Id As Int32, ByRef nTotal As Decimal) As Boolean
		On Error GoTo ErrorHandler

		'--- local definitions
		Dim bError As Boolean = False

		'--- Define information to read
		Dim oTmpDataBroker As New iDac.cls_T_datareader
		oTmpDataBroker._dbtype = Me._dbtype
		oTmpDataBroker._connection_string = Me._connection_string
		oTmpDataBroker._table = "acc_ORDERS"
		oTmpDataBroker._id = nOrder_Id

		'--- Define records
		Dim oField1 As New iDac.cls_cll_datareader
		oField1._field = "id"
		oTmpDataBroker._fields.Add(oField1)
		oField1 = Nothing

		Dim oField2 As New iDac.cls_cll_datareader
		oField2._field = "amnt_grandtotal"
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
			nOrder_Id = oTmpDataBroker._fields.Item(1)._result
			nTotal = oTmpDataBroker._fields.Item(2)._result
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

	Public Function get_order_userid(ByRef nOrder_Id As Int32, ByRef nUser_id As Int32) As Boolean
		On Error GoTo ErrorHandler

		'--- local definitions
		Dim bError As Boolean = False

		'--- Define information to read
		Dim oTmpDataBroker As New iDac.cls_T_datareader
		oTmpDataBroker._dbtype = Me._dbtype
		oTmpDataBroker._connection_string = Me._connection_string
		oTmpDataBroker._table = "acc_ORDERS"
		oTmpDataBroker._id = nOrder_Id

		'--- Define records
		Dim oField1 As New iDac.cls_cll_datareader
		oField1._field = "id"
		oTmpDataBroker._fields.Add(oField1)
		oField1 = Nothing

		Dim oField2 As New iDac.cls_cll_datareader
		oField2._field = "user_id"
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
			nOrder_Id = oTmpDataBroker._fields.Item(1)._result
			nUser_id = oTmpDataBroker._fields.Item(2)._result
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


	Public Function get_interest(ByRef nOrder_Id As Int32, ByRef Interest_rate As Decimal, ByRef Interest_startdate As Date) As Boolean
		On Error GoTo ErrorHandler
		Dim bError As Boolean = False

		'--- Define information to read
		Dim oTmpDataBroker As New iDac.cls_T_datareader
		oTmpDataBroker._dbtype = Me._dbtype
		oTmpDataBroker._connection_string = Me._connection_string
		oTmpDataBroker._table = "acc_ORDERS"
		oTmpDataBroker._id = nOrder_Id

		'--- Define records
		Dim oField1 As New iDac.cls_cll_datareader
		oField1._field = "id"
		oTmpDataBroker._fields.Add(oField1)
		oField1 = Nothing

		Dim oField2 As New iDac.cls_cll_datareader
		oField2._field = "Interest_percent"
		oTmpDataBroker._fields.Add(oField2)
		oField2 = Nothing

		Dim oField3 As New iDac.cls_cll_datareader
		oField3._field = "Interest_start_date"
		oTmpDataBroker._fields.Add(oField3)
		oField3 = Nothing

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
			nOrder_Id = oTmpDataBroker._fields.Item(1)._result
			Interest_rate = oTmpDataBroker._fields.Item(2)._result
			Interest_startdate = oTmpDataBroker._fields.Item(3)._result
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

	Public Function get_order_readonly(ByRef nOrder_Id As Int32, ByRef bReadOnly As Boolean) As Boolean
		On Error GoTo ErrorHandler

		'--- local definitions
		Dim bError As Boolean = False

		'--- Define information to read
		Dim oTmpDataBroker As New iDac.cls_T_datareader
		oTmpDataBroker._dbtype = Me._dbtype
		oTmpDataBroker._connection_string = Me._connection_string
		oTmpDataBroker._table = "acc_ORDERS"
		oTmpDataBroker._id = nOrder_Id

		'--- Define records
		Dim oField1 As New iDac.cls_cll_datareader
		oField1._field = "id"
		oTmpDataBroker._fields.Add(oField1)
		oField1 = Nothing

		Dim oField2 As New iDac.cls_cll_datareader
		oField2._field = "cannot_be_edited"
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
			nOrder_Id = oTmpDataBroker._fields.Item(1)._result
			bReadOnly = oTmpDataBroker._fields.Item(2)._result
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

	Public Function get_order_transacted(ByRef nOrder_Id As Int32, ByRef bTransacted As Boolean) As Boolean
		On Error GoTo ErrorHandler

		'--- local definitions
		Dim bError As Boolean = False

		'--- Define information to read
		Dim oTmpDataBroker As New iDac.cls_T_datareader
		oTmpDataBroker._dbtype = Me._dbtype
		oTmpDataBroker._connection_string = Me._connection_string
		oTmpDataBroker._table = "acc_ORDERS"
		oTmpDataBroker._id = nOrder_Id

		'--- Define records
		Dim oField1 As New iDac.cls_cll_datareader
		oField1._field = "id"
		oTmpDataBroker._fields.Add(oField1)
		oField1 = Nothing

		Dim oField2 As New iDac.cls_cll_datareader
		oField2._field = "order_transacted"
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
			nOrder_Id = oTmpDataBroker._fields.Item(1)._result
			bTransacted = oTmpDataBroker._fields.Item(2)._result
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

	Public Function get_order_club(ByRef nOrder_Id As Int32, ByRef bClub As Boolean) As Boolean
		On Error GoTo ErrorHandler

		'--- local definitions
		Dim bError As Boolean = False

		'--- Define information to read
		Dim oTmpDataBroker As New iDac.cls_T_datareader
		oTmpDataBroker._dbtype = Me._dbtype
		oTmpDataBroker._connection_string = Me._connection_string
		oTmpDataBroker._table = "acc_ORDERS"
		oTmpDataBroker._id = nOrder_Id

		'--- Define records
		Dim oField1 As New iDac.cls_cll_datareader
		oField1._field = "id"
		oTmpDataBroker._fields.Add(oField1)
		oField1 = Nothing

		Dim oField2 As New iDac.cls_cll_datareader
		oField2._field = "cluborder"
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
			nOrder_Id = oTmpDataBroker._fields.Item(1)._result
			bClub = oTmpDataBroker._fields.Item(2)._result
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

	Public Function get_order_shipping_id(ByRef nOrder_Id As Int32, ByRef nShipping_id As Int32) As Boolean
		On Error GoTo ErrorHandler

		'--- local definitions
		Dim bError As Boolean = False

		'--- Define information to read
		Dim oTmpDataBroker As New iDac.cls_T_datareader
		oTmpDataBroker._dbtype = Me._dbtype
		oTmpDataBroker._connection_string = Me._connection_string
		oTmpDataBroker._table = "acc_ORDERS"
		oTmpDataBroker._id = nOrder_Id

		'--- Define records
		Dim oField1 As New iDac.cls_cll_datareader
		oField1._field = "id"
		oTmpDataBroker._fields.Add(oField1)
		oField1 = Nothing

		Dim oField2 As New iDac.cls_cll_datareader
		oField2._field = "adrs_delivery_country_id"
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
			nOrder_Id = oTmpDataBroker._fields.Item(1)._result
			nShipping_id = oTmpDataBroker._fields.Item(2)._result
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

	Public Function get_order_user(ByRef nOrder_Id As Int32, ByRef nUser_id As Int32, ByRef cUser_name As String) As Boolean
		On Error GoTo ErrorHandler

		'--- local definitions
		Dim bError As Boolean = False

		'--- Define information to read
		Dim oTmpDataBroker As New iDac.cls_T_datareader
		oTmpDataBroker._dbtype = Me._dbtype
		oTmpDataBroker._connection_string = Me._connection_string
		oTmpDataBroker._table = "acc_ORDERS"
		oTmpDataBroker._id = nOrder_Id

		'--- Define records
		Dim oField1 As New iDac.cls_cll_datareader
		oField1._field = "id"
		oTmpDataBroker._fields.Add(oField1)
		oField1 = Nothing

		Dim oField2 As New iDac.cls_cll_datareader
		oField2._field = "user_id"
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
			nOrder_Id = oTmpDataBroker._fields.Item(1)._result
			nUser_id = oTmpDataBroker._fields.Item(2)._result

			'--- Get User name
			Dim cFirstName As String
			Dim cLastName As String
			Dim oFunction_Customers As New ion_two.cls_functions_user
			oFunction_Customers._connection_string = Me._connection_string
			oFunction_Customers._dbtype = Me._dbtype
			bError = oFunction_Customers.get_username(nUser_id, cFirstName, cLastName)
			If bError Then
				Me._err_number = oFunction_Customers._err_number
				Me._err_description = oFunction_Customers._err_description
				Me._err_source = oFunction_Customers._err_source
				Return True
			End If
			oFunction_Customers = Nothing

			cUser_name = cFirstName + " " + cLastName
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

	Public Function set_transacted(ByVal nOrder_id As Int32) As Boolean
		On Error GoTo ErrorHandler

		'--- local definitions
		Dim bError As Boolean = False

		Dim oDacCommand As New iDac.cls_T_command
		oDacCommand._connection_string = Me._connection_string
		oDacCommand._dbtype = Me._dbtype
		oDacCommand._transaction = Me._idac_transaction._transaction
		oDacCommand._sqlstring = "update acc_ORDERS set order_transacted = 1 where id='" + Convert.ToString(nOrder_id) + "'"
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

	Public Function set_approved(ByVal nOrder_id As Int32) As Boolean
		On Error GoTo ErrorHandler

		'--- local definitions
		Dim bError As Boolean = False

		Dim oDacCommand As New iDac.cls_T_command
		oDacCommand._connection_string = Me._connection_string
		oDacCommand._dbtype = Me._dbtype
		oDacCommand._transaction = Me._idac_transaction._transaction
		oDacCommand._sqlstring = "update acc_cashflow set approved = 1 where master = 1 and order_id='" + Convert.ToString(nOrder_id) + "'"
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
