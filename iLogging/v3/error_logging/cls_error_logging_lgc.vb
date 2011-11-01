Public Class cls_error_logging_lgc
	Inherits iFoundation.cls_logics

	Sub New()

		Me._TableName = ""

		'--- Get module name
		Dim oTmpStack As New System.Diagnostics.StackFrame
		Me._module = oTmpStack.GetMethod.ReflectedType.Name()
		oTmpStack = Nothing

	End Sub

	Function insert(ByRef oDataTable As skl_error_logging) As Boolean
		On Error GoTo ErrorHandler

		'--- local definitions
		Dim bError As Boolean = False

		'--- Get Dataset
		Dim oTmpDataset As DataSet = New ds_errorlogging
		Dim oTmpDataTable As DataTable = oTmpDataset.Tables(_tablename)


		'--- Assign Order
		Dim oTmpDataRow As DataRow
		oTmpDataRow = oTmpDataTable.NewRow

		oTmpDataRow("logtime") = Date.Now
		oTmpDataRow("sessionid") = oDataTable._sessionId
		oTmpDataRow("user_id") = oDataTable._user_id
		oTmpDataRow("user_name") = oDataTable._user_name
		oTmpDataRow("user_ip") = oDataTable._user_ip
		oTmpDataRow("framework") = oDataTable._framework
		'oTmpDataRow("dllstat") = Convert.ToString(oError_Logging._dllstat)
		oTmpDataRow("dllstat") = ""
		oTmpDataRow("err_number") = oDataTable._err_number
		oTmpDataRow("err_description") = oDataTable._err_description
		oTmpDataRow("err_version") = oDataTable._err_version
		oTmpDataRow("err_source") = oDataTable._err_source
		oTmpDataRow("err_module") = oDataTable._err_module
		oTmpDataRow("err_call") = oDataTable._err_call
		oTmpDataRow("note") = oDataTable._note

		oTmpDataTable.Rows.Add(oTmpDataRow)

		'--- Instantiate the Transactor
		Dim oTransactor As New iDac.cls_T_transactor
		oTransactor._connection_string = Me._connection_string
		oTransactor._dbtype = Me._dbtype

		'--- Prepare and load table 1
		Dim oTable1 As New iDac.cls_cll_datatables
		oTable1._datatable = oTmpDataTable
		oTransactor._i_cll_datatables.Add(oTable1)

		bError = oTransactor.transact_insert
		If bError Then
			Me._err_number = oTransactor._err_number
			Me._err_description = oTransactor._err_description
			Me._err_source = oTransactor._err_source
			Return True
		End If

		'--- return ID
		oDataTable._id = oTransactor._i_cll_datatables(1)._info(1)._id


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

	Function read(ByVal nId As Int32, ByRef oDataTable As skl_error_logging) As Boolean
		On Error GoTo ErrorHandler

		'--- local definitions
		Dim bError As Boolean = False

		'--- Get Item
		Dim oReadTransactor As New iDac.cls_T_read
		oReadTransactor._connection_string = Me._connection_string
		oReadTransactor._dbtype = Me._dbtype
		oReadTransactor._tablename = Me._tablename
		bError = oReadTransactor.transact_read(nId)
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
		oTmpDataRow = oReadTransactor._datatable.Rows(0)

		oDataTable._id = oTmpDataRow("id")
		oDataTable._logtime = oTmpDataRow("logtime")
		oDataTable._sessionId = oTmpDataRow("sessionid")
		oDataTable._user_id = oTmpDataRow("user_id")
		oDataTable._user_name = oTmpDataRow("user_name")
		oDataTable._user_ip = oTmpDataRow("user_ip")
		oDataTable._framework = oTmpDataRow("framework")
		oDataTable._dllstat = ""
		'Convert.ToString(oError_Logging._dllstat)=oTmpDataRow("dllstat")
		oDataTable._err_number = oTmpDataRow("err_number")
		oDataTable._err_description = oTmpDataRow("err_description")
		oDataTable._err_version = oTmpDataRow("err_version")
		oDataTable._err_source = oTmpDataRow("err_source")
		oDataTable._err_module = oTmpDataRow("err_module")
		oDataTable._err_call = oTmpDataRow("err_call")
		oDataTable._note = oTmpDataRow("note")

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

	Function update(ByRef oDataTable As skl_error_logging) As Boolean
		On Error GoTo ErrorHandler

		'--- local definitions
		Dim bError As Boolean = False

		'--- CUSTOM ERROR: Return Error if ID not passed in skeleton
		If oDataTable._id <= 0 Then
			Err.Raise(7006, Me._module + ":update", "No ID passed with skeleton.")
		End If

		Dim oTmpTransact As New iDac.cls_T_read
		oTmpTransact._connection_string = Me._connection_string
		oTmpTransact._dbtype = Me._dbtype
		oTmpTransact._tablename = Me._tablename
		bError = oTmpTransact.transact_read(oDataTable._id)
		If bError Then
			Me._err_number = oTmpTransact._err_number
			Me._err_description = oTmpTransact._err_description
			Me._err_source = oTmpTransact._err_source
		End If

		'--- Get Dataset
		Dim oTmpDataTable As DataTable = oTmpTransact._datatable

		'--- Assign Order
		Dim oTmpDataRow As DataRow
		oTmpDataRow = oTmpDataTable.Rows(0)

		'oTmpDataRow("id") = oDataTable._id
		oTmpDataRow("logtime") = Date.Now
		oTmpDataRow("sessionid") = oDataTable._sessionId
		oTmpDataRow("user_id") = oDataTable._user_id
		oTmpDataRow("user_name") = oDataTable._user_name
		oTmpDataRow("user_ip") = oDataTable._user_ip
		oTmpDataRow("framework") = oDataTable._framework
		'oTmpDataRow("dllstat") = Convert.ToString(oError_Logging._dllstat)
		oTmpDataRow("dllstat") = ""
		oTmpDataRow("err_number") = oDataTable._err_number
		oTmpDataRow("err_description") = oDataTable._err_description
		oTmpDataRow("err_version") = oDataTable._err_version
		oTmpDataRow("err_source") = oDataTable._err_source
		oTmpDataRow("err_module") = oDataTable._err_module
		oTmpDataRow("err_call") = oDataTable._err_call
		oTmpDataRow("note") = oDataTable._note

		'--- Instantiate the Transactor
		Dim oTransactor As New iDac.cls_T_transactor
		oTransactor._connection_string = Me._connection_string
		oTransactor._dbtype = Me._dbtype

		'--- Prepare and load table 1
		Dim oTable1 As New iDac.cls_cll_datatables
		oTable1._datatable = oTmpDataTable
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


End Class

