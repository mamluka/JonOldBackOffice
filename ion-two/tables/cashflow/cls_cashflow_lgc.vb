Public Class cls_cashflow_lgc
	Inherits iFoundation.cls_logics

	Sub New()
		'--- Set working table
		Me._tablename = "acc_CASHFLOW"

		'--- Get module name
		Dim oTmpStack As New System.Diagnostics.StackFrame
		Me._module = oTmpStack.GetMethod.ReflectedType.FullName()
		oTmpStack = Nothing

	End Sub

	Function insert(ByRef oDataTable As skl_cashflow) As Boolean
		On Error GoTo ErrorHandler

		'--- local definitions
		Dim bError As Boolean = False

		'--- Get Dataset
		Dim oTmpDataset As DataSet = New ion_two.ds_cashflow
		Dim oTmpDataTable As DataTable = oTmpDataset.Tables(_tablename)

		'--- Assign Order
		Dim oTmpDataRow As DataRow
		oTmpDataRow = oTmpDataTable.NewRow

		'oTmpDataRow("id") = oDataTable._id
		oTmpDataRow("payment_type") = oDataTable._payment_type
		oTmpDataRow("payment_date") = Date.Now

		oTmpDataRow("order_id") = oDataTable._order_id
		oTmpDataRow("user_id") = oDataTable._user_id
		oTmpDataRow("master") = oDataTable._master

		oTmpDataRow("cc_type_id") = oDataTable._cc_type_id
		oTmpDataRow("cc_name") = oDataTable._cc_name
		oTmpDataRow("cc_number") = oDataTable._cc_number
		oTmpDataRow("cc_cvv") = oDataTable._cc_cvv
		oTmpDataRow("cc_exp_year") = oDataTable._cc_exp_year
		oTmpDataRow("cc_exp_month") = oDataTable._cc_exp_month
		oTmpDataRow("cc_user_ssn") = oDataTable._cc_user_ssn
		oTmpDataRow("cc_confirmation") = oDataTable._cc_confermation
		oTmpDataRow("cc_clubmember") = oDataTable._cc_clubmember
		oTmpDataRow("cc_cleared") = oDataTable._cc_cleared
		oTmpDataRow("cc_batch") = oDataTable._cc_batch

		oTmpDataRow("mt_bank") = oDataTable._mt_bank
		oTmpDataRow("mt_name") = oDataTable._mt_name
		oTmpDataRow("mt_account") = oDataTable._mt_account
		oTmpDataRow("mt_code") = oDataTable._mt_code

		oTmpDataRow("cq_bank") = oDataTable._cq_bank
		oTmpDataRow("cq_name") = oDataTable._cq_name
		oTmpDataRow("cq_account") = oDataTable._cq_account
        oTmpDataRow("cq_date") = oDataTable._cq_date

        oTmpDataRow("paypal") = oDataTable._paypal

		oTmpDataRow("received") = oDataTable._received
		oTmpDataRow("received_date") = oDataTable._received_date
		oTmpDataRow("approved") = oDataTable._approved
		oTmpDataRow("approved_date") = oDataTable._approved_date
		oTmpDataRow("amount_total") = oDataTable._amount_total
		oTmpDataRow("amount_interest") = oDataTable._amount_interest
		oTmpDataRow("amount_actual") = oDataTable._amount_actual
		oTmpDataRow("amount_costs") = oDataTable._amount_costs
		oTmpDataRow("notes") = oDataTable._notes

		'--- Handle Audit
		oTmpDataRow("lastmodify_date") = Date.Now
		oTmpDataRow("lastmodify_user") = Me._user_name
		oTmpDataRow("lastmodify_user_id") = Me._user_id


		oTmpDataTable.Rows.Add(oTmpDataRow)

		'--- Instantiate the Transactor
		Dim oTransactor As New iDac.cls_T_transactor
		oTransactor._connection_string = Me._connection_string
		oTransactor._dbtype = Me._dbtype

		'--- Prepare and load table 1
		Dim oTable1 As New iDac.cls_cll_datatables
		oTable1._datatable = oTmpDataTable
		oTransactor._i_cll_datatables.Add(oTable1)

		'### Start transaction
		Dim oTransaction As New iDac.cls_T_transaction
		oTransaction._connection_string = Me._connection_string
		oTransaction._dbtype = Me._dbtype
		bError = oTransaction.start()
		If bError Then
			Me._err_number = oTransaction._err_number
			Me._err_description = oTransaction._err_description
			Me._err_source = oTransaction._err_source
			Return True
		End If

		'--- Assign the transaction to the transactor
		oTransactor._transaction = oTransaction._transaction

		'--- Write Table
		bError = oTransactor.transact_insert
		If bError Then
			Me._err_number = oTransactor._err_number
			Me._err_description = oTransactor._err_description
			Me._err_source = oTransactor._err_source
			Return True
		End If

		'--- Close the transaction
		bError = oTransaction.close()
		If bError Then
			Me._err_number = oTransaction._err_number
			Me._err_description = oTransaction._err_description
			Me._err_source = oTransaction._err_source
			Return True
		End If
		'### End transaction

		oTable1 = Nothing
		oTransactor = Nothing
		oTransaction = Nothing

		Return False
		Exit Function

ErrorHandler:
		Me._err_number = Err.Number
		Me._err_description = Err.Description
		Me._err_source = Err.Source
		Return True
	End Function

	Function read(ByVal nId As Int32, ByRef oDataTable As skl_cashflow) As Boolean
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
		oDataTable._payment_type = oTmpDataRow("payment_type")
		oDataTable._payment_date = oTmpDataRow("payment_date")

		oDataTable._order_id = oTmpDataRow("order_id")
		oDataTable._user_id = oTmpDataRow("user_id")
		oDataTable._master = oTmpDataRow("master")

		oDataTable._cc_type_id = oTmpDataRow("cc_type_id")
		oDataTable._cc_name = oTmpDataRow("cc_name")
		oDataTable._cc_number = oTmpDataRow("cc_number")
		oDataTable._cc_cvv = oTmpDataRow("cc_cvv")
		oDataTable._cc_exp_year = oTmpDataRow("cc_exp_year")
		oDataTable._cc_exp_month = oTmpDataRow("cc_exp_month")
		oDataTable._cc_user_ssn = oTmpDataRow("cc_user_ssn")
		oDataTable._cc_confermation = oTmpDataRow("cc_confirmation")
		oDataTable._cc_clubmember = oTmpDataRow("cc_clubmember")
		oDataTable._cc_cleared = oTmpDataRow("cc_cleared")
		oDataTable._cc_batch = oTmpDataRow("cc_batch")

		oDataTable._mt_bank = oTmpDataRow("mt_bank")
		oDataTable._mt_name = oTmpDataRow("mt_name")
		oDataTable._mt_account = oTmpDataRow("mt_account")
		oDataTable._mt_code = oTmpDataRow("mt_code")

		oDataTable._cq_bank = oTmpDataRow("cq_bank")
		oDataTable._cq_name = oTmpDataRow("cq_name")
		oDataTable._cq_account = oTmpDataRow("cq_account")
		oDataTable._cq_date = oTmpDataRow("cq_date")

		oDataTable._received = oTmpDataRow("received")
		oDataTable._received_date = oTmpDataRow("received_date")
		oDataTable._approved = oTmpDataRow("approved")
		oDataTable._approved_date = oTmpDataRow("approved_date")
		oDataTable._amount_total = oTmpDataRow("amount_total")
		oDataTable._amount_interest = oTmpDataRow("amount_interest")
		oDataTable._amount_actual = oTmpDataRow("amount_actual")
		oDataTable._amount_costs = oTmpDataRow("amount_costs")
		oDataTable._notes = oTmpDataRow("notes")

		oDataTable._lastmodify_date = oTmpDataRow("lastmodify_date")
		oDataTable._lastmodify_user = oTmpDataRow("lastmodify_user")
		oDataTable._lastmodify_user_id = oTmpDataRow("lastmodify_user_id")

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

	Function update(ByRef oDataTable As skl_cashflow) As Boolean
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

		'oTmpDataRow("id") = oDataTable._id
		oTmpDataRow("payment_type") = oDataTable._payment_type
		oTmpDataRow("payment_date") = oDataTable._payment_date

		oTmpDataRow("order_id") = oDataTable._order_id
		oTmpDataRow("user_id") = oDataTable._user_id
		oTmpDataRow("master") = oDataTable._master

		oTmpDataRow("cc_type_id") = oDataTable._cc_type_id
		oTmpDataRow("cc_name") = oDataTable._cc_name
		oTmpDataRow("cc_number") = oDataTable._cc_number
		oTmpDataRow("cc_cvv") = oDataTable._cc_cvv
		oTmpDataRow("cc_exp_year") = oDataTable._cc_exp_year
		oTmpDataRow("cc_exp_month") = oDataTable._cc_exp_month
		oTmpDataRow("cc_user_ssn") = oDataTable._cc_user_ssn
		oTmpDataRow("cc_confirmation") = oDataTable._cc_confermation
		oTmpDataRow("cc_clubmember") = oDataTable._cc_clubmember
		oTmpDataRow("cc_cleared") = oDataTable._cc_cleared
		oTmpDataRow("cc_batch") = oDataTable._cc_batch

		oTmpDataRow("mt_bank") = oDataTable._mt_bank
		oTmpDataRow("mt_name") = oDataTable._mt_name
		oTmpDataRow("mt_account") = oDataTable._mt_account
		oTmpDataRow("mt_code") = oDataTable._mt_code

		oTmpDataRow("cq_bank") = oDataTable._cq_bank
		oTmpDataRow("cq_name") = oDataTable._cq_name
		oTmpDataRow("cq_account") = oDataTable._cq_account
		oTmpDataRow("cq_date") = oDataTable._cq_date

		oTmpDataRow("received") = oDataTable._received
		oTmpDataRow("received_date") = oDataTable._received_date
		oTmpDataRow("approved") = oDataTable._approved
		oTmpDataRow("approved_date") = oDataTable._approved_date
		oTmpDataRow("amount_total") = oDataTable._amount_total
		oTmpDataRow("amount_interest") = oDataTable._amount_interest
		oTmpDataRow("amount_actual") = oDataTable._amount_actual
		oTmpDataRow("amount_costs") = oDataTable._amount_costs
		oTmpDataRow("notes") = oDataTable._notes

		'--- Handle Audit
		oTmpDataRow("lastmodify_date") = Date.Now
		oTmpDataRow("lastmodify_user") = Me._user_name
		oTmpDataRow("lastmodify_user_id") = Me._user_id


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
