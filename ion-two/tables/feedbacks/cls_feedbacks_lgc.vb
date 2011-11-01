Public Class cls_feedbacks_lgc
	Inherits iFoundation.cls_logics

	Sub New()
		'--- Set working table
		Me._tablename = "usr_FEEDBACKS"

		'--- Get module name
		Dim oTmpStack As New System.Diagnostics.StackFrame
		Me._module = oTmpStack.GetMethod.ReflectedType.FullName()
		oTmpStack = Nothing

	End Sub

	Function insert(ByRef oDataTable As skl_feedbacks) As Boolean
		On Error GoTo ErrorHandler

		'--- local definitions
		Dim bError As Boolean = False

		'--- Get Dataset
		Dim oTmpDataset As DataSet = New ion_two.ds_feedbacks
		Dim oTmpDataTable As DataTable = oTmpDataset.Tables(_tablename)

		'--- Assign Order
		Dim oTmpDataRow As DataRow
		oTmpDataRow = oTmpDataTable.NewRow

		oTmpDataRow("user_id") = oDataTable._user_id
		oTmpDataRow("user_name") = oDataTable._user_name
		oTmpDataRow("user_email") = oDataTable._user_email
		oTmpDataRow("showemail") = oDataTable._showemail
		oTmpDataRow("active") = oDataTable._active
		oTmpDataRow("deleted") = oDataTable._deleted
		oTmpDataRow("createdate") = oDataTable._createdate
		oTmpDataRow("text") = oDataTable._text
		oTmpDataRow("country") = oDataTable._country
		oTmpDataRow("state") = oDataTable._state
		oTmpDataRow("item1_id") = oDataTable._item1_id
		oTmpDataRow("item2_id") = oDataTable._item2_id
		oTmpDataRow("item3_id") = oDataTable._item3_id

		oTmpDataTable.Rows.Add(oTmpDataRow)

		'--- Instantiate the Transactor
		Dim oTransactor As New iDac.cls_T_transactor
		oTransactor._connection_string = Me._connection_string
		oTransactor._dbtype = Me._dbtype

		'--- Prepare and load table 1
		Dim oTable1 As New iDac.cls_cll_datatables
		oTable1._datatable = oTmpDataTable
		oTransactor._i_cll_datatables.Add(oTable1)

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

	Function read(ByVal nId As Int32, ByRef oDataTable As skl_feedbacks) As Boolean
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
			Return True
		End If

		'--- Return Error if no records were fatched
		If oReadTransactor._datatable.Rows.Count = 0 Then
			Err.Raise(7003, Me._module + ":read", "No records fetched.")
		End If

		'--- Map to Skeleton
		Dim oTmpDataRow As DataRow
		oTmpDataRow = oReadTransactor._datatable.Rows(0)

		oDataTable._id = oTmpDataRow("id")
		oDataTable._user_id = oTmpDataRow("user_id")
		oDataTable._user_name = oTmpDataRow("user_name")
		oDataTable._user_email = oTmpDataRow("user_email")
		oDataTable._showemail = oTmpDataRow("showemail")
		oDataTable._active = oTmpDataRow("active")
		oDataTable._deleted = oTmpDataRow("deleted")
		oDataTable._createdate = oTmpDataRow("createdate")
		oDataTable._text = oTmpDataRow("text")
		oDataTable._country = oTmpDataRow("country")
		oDataTable._state = oTmpDataRow("state")
		oDataTable._item1_id = oTmpDataRow("item1_id")
		oDataTable._item2_id = oTmpDataRow("item2_id")
		oDataTable._item3_id = oTmpDataRow("item3_id")

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

	Function update(ByRef oDataTable As skl_feedbacks) As Boolean
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
			Return True
		End If

		'--- Get Dataset
		Dim oTmpDataTable As DataTable = oTmpTransact._datatable

		'--- Assign Order
		Dim oTmpDataRow As DataRow
		oTmpDataRow = oTmpDataTable.Rows(0)

		oTmpDataRow("user_id") = oDataTable._user_id
		oTmpDataRow("user_name") = oDataTable._user_name
		oTmpDataRow("user_email") = oDataTable._user_email
		oTmpDataRow("showemail") = oDataTable._showemail
		oTmpDataRow("active") = oDataTable._active
		oTmpDataRow("deleted") = oDataTable._deleted
		oTmpDataRow("createdate") = oDataTable._createdate
		oTmpDataRow("text") = oDataTable._text
		oTmpDataRow("country") = oDataTable._country
		oTmpDataRow("state") = oDataTable._state
		oTmpDataRow("item1_id") = oDataTable._item1_id
		oTmpDataRow("item2_id") = oDataTable._item2_id
		oTmpDataRow("item3_id") = oDataTable._item3_id

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
