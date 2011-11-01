Imports System.Data.SqlClient

Public Class cls_mt_transactor
	Inherits cls_mt_error

	Private m_i_cll_datatables As New Collection
	Private m_transaction As SqlTransaction
	Private m_connection As SqlConnection

	Function transact_insert()
		'On Error GoTo ErrorHandler
		Dim bError As Boolean = False
		Dim bInTransaction As Boolean = False
		Dim bMasterTransaction As Boolean		'-- If we are already in transaction

		'--- check if we are in transaction
		If Not IsNothing(Me.transaction) Then
			bMasterTransaction = True
		Else
			bMasterTransaction = False
			'--- Open Connection and start transation
			Me.connection = New SqlConnection(Me.connection_string)
			Me.connection.Open()
			'--- Initiate transaction
			Me.transaction = Me.connection.BeginTransaction()
			bInTransaction = True
		End If

		'### Run PRE routine ###
		bError = pre_insert_transact()
		If bError Then
			Return True
		End If

		'--- Prepare writing
		Dim oMT_WriteTable As New cls_mt_write
		oMT_WriteTable.i_connection_string = Me.connection_string
		oMT_WriteTable.i_connection = Me.connection
		oMT_WriteTable.i_transaction = Me.transaction

		Dim nLoop As Int32
		For nLoop = 1 To i_cll_datatables.Count
			'--- prepare to collect results
			Dim oInfo As New ion_idac.cls_tableinfo

			'--- Write the table
			oMT_WriteTable.i_datatable = i_cll_datatables.Item(nLoop).datatable
			bError = oMT_WriteTable.WriteTable()
			If bError Then
				oInfo.success = False
				'--- Roll transaction back
				Me.transaction.Rollback()
				'--- Collect errors
				Me.error_no = oMT_WriteTable.error_no
				Me.error_desc = oMT_WriteTable.error_desc
				Me.error_source = oMT_WriteTable.error_source
				Return True

			Else
				oInfo.success = True

			End If

			'--- Update information
			oInfo.id = oMT_WriteTable.o_id
			oInfo.tablename = i_cll_datatables.Item(nLoop).datatable.tablename
			i_cll_datatables.Item(nLoop).info.Add(oInfo)
			oInfo = Nothing

			'### Run MID routine ###
			bError = mid_insert_transact(i_cll_datatables.Item(nLoop).datatable.tablename)
			If bError Then
				Return True
			End If

		Next

		'### Run SUF routine ###
		bError = suf_insert_transact()
		If bError Then
			Return True
		End If

		If Not bMasterTransaction Then
			'--- Commit transaction
			Me.transaction.Commit()
			bInTransaction = False

			'--- Close connection
			Me.connection.Close()

			'--- Cleanup
			Me.transaction = Nothing
			Me.connection = Nothing

		End If


		Return False
		Exit Function

ErrorHandler:

		'--- Roll transaction back
		If bInTransaction Then
			Me.transaction.Rollback()
		End If

		'--- Collect errors
		Me.error_no = Err.Number
		Me.error_desc = Err.Description
		Me.error_source = Err.Source
		Return True

	End Function

	Function transact_update()
		'On Error GoTo ErrorHandler
		Dim bError As Boolean = False
		Dim bInTransaction As Boolean = False
		Dim bMasterTransaction As Boolean		'-- If we are already in transaction

		'--- check if we are in transaction
		If Not IsNothing(Me.transaction) Then
			bMasterTransaction = True
		Else
			bMasterTransaction = False
			'--- Open Connection and start transation
			Me.connection = New SqlConnection(Me.connection_string)
			Me.connection.Open()
			'--- Initiate transaction
			Me.transaction = Me.connection.BeginTransaction()
			bInTransaction = True
		End If

		'### Run PRE routine ###
		bError = pre_update_transact()
		If bError Then
			Return True
		End If


		Dim nLoop1 As Int32
		For nLoop1 = 1 To Me.i_cll_datatables.Count

			'--- prepare to collect results
			Dim oInfo As New ion_idac.cls_tableinfo

			'--- Get Existing Record
			Dim oTmpGetRecord As New cls_mt_getitem
			oTmpGetRecord.connection_string = Me.connection_string
			oTmpGetRecord.tablename = Me.i_cll_datatables(nLoop1).datatable.tablename

			If Not Me.i_cll_datatables(nLoop1).ignoreget Then
				Dim oTmpDataRow As DataRow
				oTmpDataRow = Me.i_cll_datatables(nLoop1).datatable.rows(0)
				oTmpGetRecord.id = Me.i_cll_datatables(nLoop1).datatable.rows(0).item("id")

				bError = oTmpGetRecord.get_item
				If bError Then
					oInfo.success = False
					'--- Roll transaction back
					Me.transaction.Rollback()
					'--- Collect errors
					Me.error_no = oTmpGetRecord.error_no
					Me.error_desc = oTmpGetRecord.error_desc
					Me.error_source = oTmpGetRecord.error_source
					Return True

				Else
					oInfo.success = True

				End If

				'--- Exchange Rows between Existing record and NEW record
				Dim oTmpDatatableToUpdate As DataTable = Me.i_cll_datatables(nLoop1).datatable
				Dim oTmpDatatableExisting As DataTable = oTmpGetRecord.DataTable
				'--- Transfer ROW by ROW for this table
				Dim nLoop2 As Int32
				For nLoop2 = 0 To oTmpDatatableToUpdate.Rows.Count - 1
					Dim oTmpRowToUpdate As DataRow = oTmpDatatableToUpdate.Rows(nLoop2)
					Dim oTmpRowExisting As DataRow = oTmpDatatableExisting.Rows(nLoop2)
					oTmpRowExisting.ItemArray = oTmpRowToUpdate.ItemArray
				Next

				'--- Change tables with original one
				Me.i_cll_datatables(nLoop1).datatable = oTmpDatatableExisting

				'--- Release unneccery
				oTmpGetRecord = Nothing
				oTmpDatatableToUpdate = Nothing
				oTmpDatatableExisting = Nothing
			End If

			'############### Write Tables back #######################

			'--- Prepare writing
			Dim oMT_WriteTable As New cls_mt_write
			oMT_WriteTable.i_connection_string = Me.connection_string
			oMT_WriteTable.i_connection = Me.connection
			oMT_WriteTable.i_transaction = Me.transaction

			'--- Write the table
			oMT_WriteTable.i_datatable = i_cll_datatables.Item(nLoop1).datatable
			bError = oMT_WriteTable.WriteTable()
			If bError Then
				oInfo.success = False
				'--- Roll transaction back
				Me.transaction.Rollback()
				'--- Collect errors
				Me.error_no = oMT_WriteTable.error_no
				Me.error_desc = oMT_WriteTable.error_desc
				Me.error_source = oMT_WriteTable.error_source
				Return True

			Else
				oInfo.success = True

			End If

			'--- Update information
			oInfo.id = oMT_WriteTable.o_id
			oInfo.tablename = i_cll_datatables.Item(nLoop1).datatable.tablename
			i_cll_datatables.Item(nLoop1).info.Add(oInfo)
			oInfo = Nothing

			'### Run MID routine ###
			bError = mid_update_transact(i_cll_datatables.Item(nLoop1).datatable.tablename)
			If bError Then
				Return True
			End If

		Next

		'### Run SUF routine ###
		bError = suf_update_transact()
		If bError Then
			Return True
		End If


		If Not bMasterTransaction Then
			'--- Commit transaction
			Me.transaction.Commit()
			bInTransaction = False

			'--- Close connection
			Me.connection.Close()

			'--- Cleanup
			Me.transaction = Nothing
			Me.connection = Nothing

		End If


		Return False
		Exit Function

ErrorHandler:

		'--- Roll transaction back
		If bInTransaction Then
			Me.transaction.Rollback()
		End If

		'--- Collect errors
		Me.error_no = Err.Number
		Me.error_desc = Err.Description
		Me.error_source = Err.Source
		Return True

	End Function

	Overridable Function pre_insert_transact() As Boolean
		On Error GoTo ErrorHandler
		Dim bError As Boolean = False



		Return False
		Exit Function

ErrorHandler:
		error_no = Err.Number
		error_desc = Err.Description
		error_source = Err.Source
		Return True

	End Function

	Overridable Function mid_insert_transact(ByVal cLastTable As String) As Boolean
		On Error GoTo ErrorHandler
		Dim bError As Boolean = False



		Return False
		Exit Function

ErrorHandler:
		error_no = Err.Number
		error_desc = Err.Description
		error_source = Err.Source
		Return True

	End Function

	Overridable Function suf_insert_transact() As Boolean
		On Error GoTo ErrorHandler
		Dim bError As Boolean = False



		Return False
		Exit Function

ErrorHandler:
		error_no = Err.Number
		error_desc = Err.Description
		error_source = Err.Source
		Return True

	End Function
	Overridable Function pre_update_transact() As Boolean
		On Error GoTo ErrorHandler
		Dim bError As Boolean = False



		Return False
		Exit Function

ErrorHandler:
		error_no = Err.Number
		error_desc = Err.Description
		error_source = Err.Source
		Return True

	End Function

	Overridable Function mid_update_transact(ByVal cLastTable As String) As Boolean
		On Error GoTo ErrorHandler
		Dim bError As Boolean = False



		Return False
		Exit Function

ErrorHandler:
		error_no = Err.Number
		error_desc = Err.Description
		error_source = Err.Source
		Return True

	End Function

	Overridable Function suf_update_transact() As Boolean
		On Error GoTo ErrorHandler
		Dim bError As Boolean = False

		Return False
		Exit Function

ErrorHandler:
		error_no = Err.Number
		error_desc = Err.Description
		error_source = Err.Source
		Return True

	End Function

	Public Property i_cll_datatables() As Collection
		Get
			Return m_i_cll_datatables
		End Get

		Set(ByVal Value As Collection)
			m_i_cll_datatables = Value
		End Set
	End Property

	Public Property transaction() As SqlTransaction
		Get
			Return m_transaction
		End Get

		Set(ByVal Value As SqlTransaction)
			m_transaction = Value
		End Set
	End Property

	Public Property connection() As SqlConnection
		Get
			Return m_connection
		End Get

		Set(ByVal Value As SqlConnection)
			m_connection = Value
		End Set
	End Property

End Class

