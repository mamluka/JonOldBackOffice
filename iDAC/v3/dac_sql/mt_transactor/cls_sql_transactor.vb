Imports System.Data.SqlClient

Public Class cls_sql_transactor
	Inherits cls_error


	'--- Ignoreget = Valid only when in update, = don't get current record info and exchange records
	'--- Carryid = Valid only when inseting a new redord, holds the field name where the ID returned  
	'---           from the 1st datatable insertion returned.aides to or more relational tables.



	Public _i_cll_datatables As New Collection
	Public _transaction As SqlTransaction

	Function transact_insert() As Boolean
		On Error GoTo ErrorHandler
		Dim bError As Boolean = False

		'--- Declare local status
		Dim bInTransaction As Boolean = False		  '-- Currently in transaction
		Dim bMasterTransaction As Boolean		'-- If we are already in previous defined transaction

		'--- Declare connection object
		Dim oConnection As SqlConnection
		Dim oTransaction As SqlTransaction

		'--- check if we are in transaction
		If Not IsNothing(Me._transaction) Then
			bMasterTransaction = True
			bInTransaction = True
			oTransaction = Me._transaction
		Else
			bMasterTransaction = False
			'--- Open Connection and start transation
			oConnection = New SqlConnection(Me._connection_string)
			oConnection.Open()

			'--- Get transaction-object from the conneection
			oTransaction = oConnection.BeginTransaction()
			bInTransaction = True
		End If

		'### Run PRE routine ###
		bError = pre_insert_transact()
		If bError Then
			Return True
		End If

		'--- Prepare writing
		Dim oMT_WriteTable As New cls_sql_write
		oMT_WriteTable._i_connection_string = Me._connection_string
		oMT_WriteTable._i_transaction = oTransaction

		Dim nLoop As Int32
		For nLoop = 1 To Me._i_cll_datatables.Count
			'--- prepare to collect results
			Dim oInfo As New cls_tableinfo

			'--- Set working table
			oMT_WriteTable._i_datatable = Me._i_cll_datatables.Item(nLoop)._datatable

			'--- Carry ID if requested
			If nLoop > 1 Then			'--- First table should return the ID
				If Me._i_cll_datatables(nLoop)._carryid <> "" Then

					Dim nLoop2 As Int32
					For nLoop2 = 0 To oMT_WriteTable._i_datatable.Rows.Count - 1
						oMT_WriteTable._i_datatable.Rows(nLoop2)(Me._i_cll_datatables(nLoop)._carryid) = Me._i_cll_datatables(1)._info(1)._id
					Next

				End If
			End If

			'--- Write the table
			bError = oMT_WriteTable.WriteTable()
			If bError Then
				oInfo._success = False
				'--- Roll transaction back
				oTransaction.Rollback()
				'--- Collect errors
				Me._err_number = oMT_WriteTable._err_number
				Me._err_description = oMT_WriteTable._err_description
				Me._err_source = oMT_WriteTable._err_source
				Return True

			Else
				oInfo._success = True

			End If

			'--- Update information
			oInfo._id = oMT_WriteTable._o_id
			oInfo._tablename = Me._i_cll_datatables.Item(nLoop)._datatable.tablename
			Me._i_cll_datatables.Item(nLoop)._info.Add(oInfo)
			oInfo = Nothing

			'### Run MID routine ###
			bError = mid_insert_transact(Me._i_cll_datatables.Item(nLoop)._datatable.tablename)
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
			oTransaction.Commit()
			bInTransaction = False

			'--- Close connection
			oConnection.Close()

			'--- Cleanup
			oTransaction = Nothing
			oConnection = Nothing

		End If


		Return False
		Exit Function

ErrorHandler:

		'--- Roll transaction back
		If bInTransaction Then
			oTransaction.Rollback()
		End If

		'--- Collect errors
		Me._err_number = Err.Number
		Me._err_description = Err.Description
		Me._err_source = Err.Source
		Return True

	End Function

	Function transact_update() As Boolean
		On Error GoTo ErrorHandler
		Dim bError As Boolean = False

		'--- Declare local status
		Dim bInTransaction As Boolean = False		  '-- Currently in transaction
		Dim bMasterTransaction As Boolean		'-- If we are already in previous defined transaction

		'--- Declare connection object
		Dim oConnection As SqlConnection
		Dim oTransaction As SqlTransaction

		'--- check if we are in transaction
		If Not IsNothing(Me._transaction) Then
			bMasterTransaction = True
			bInTransaction = True
			oTransaction = Me._transaction
		Else
			bMasterTransaction = False
			'--- Open Connection and start transation
			oConnection = New SqlConnection(Me._connection_string)
			oConnection.Open()
			'--- Initiate transaction
			oTransaction = oConnection.BeginTransaction()
			bInTransaction = True
		End If

		'### Run PRE routine ###
		bError = pre_update_transact()
		If bError Then
			Return True
		End If


		Dim nLoop1 As Int32
		For nLoop1 = 1 To Me._i_cll_datatables.Count

			'--- prepare to collect results
			Dim oInfo As New cls_tableinfo

			'--- Get Existing Record
			Dim oTmpGetRecord As New cls_sql_read
			oTmpGetRecord._connection_string = Me._connection_string
			oTmpGetRecord._tablename = Me._i_cll_datatables(nLoop1)._datatable.tablename

			If Not Me._i_cll_datatables(nLoop1)._ignoreget Then
				Dim oTmpDataRow As DataRow
				oTmpDataRow = Me._i_cll_datatables(nLoop1)._datatable.rows(0)

				bError = oTmpGetRecord.transact_read(Me._i_cll_datatables(nLoop1)._datatable.rows(0).item("id"))
				If bError Then
					oInfo._success = False
					'--- Roll transaction back
					oTransaction.Rollback()
					'--- Collect errors
					Me._err_number = oTmpGetRecord._err_number
					Me._err_description = oTmpGetRecord._err_description
					Me._err_source = oTmpGetRecord._err_source
					Return True

				Else
					oInfo._success = True

				End If

				'--- Exchange Rows between Existing record and NEW record
				Dim oTmpDatatableToUpdate As DataTable = Me._i_cll_datatables(nLoop1)._datatable
				Dim oTmpDatatableExisting As DataTable = oTmpGetRecord._datatable
				'--- Transfer ROW by ROW for this table
				Dim nLoop2 As Int32
				For nLoop2 = 0 To oTmpDatatableToUpdate.Rows.Count - 1
					Dim oTmpRowToUpdate As DataRow = oTmpDatatableToUpdate.Rows(nLoop2)
					Dim oTmpRowExisting As DataRow = oTmpDatatableExisting.Rows(nLoop2)

					oTmpRowExisting.ItemArray = oTmpRowToUpdate.ItemArray


					'--- Read Row.item by Row.item and if not empty then update
					'Dim oObject As New cls_object
					'Dim nLoop As Int32
					'For nLoop = 0 To oTmpRowExisting.ItemArray.GetUpperBound(0)
					'--- Get object type
					'bError = oObject.Isobject(oTmpRowToUpdate.Item(nLoop))
					'If Not oObject._isempty Then
					'oTmpRowExisting.Item(nLoop) = oTmpRowToUpdate.Item(nLoop)
					'End If
					'Next
					'--- release
					'oObject = Nothing
				Next

				'--- Change tables with original one
				Me._i_cll_datatables(nLoop1)._datatable = oTmpDatatableExisting

				'--- Release unneccery
				oTmpGetRecord = Nothing
				oTmpDatatableToUpdate = Nothing
				oTmpDatatableExisting = Nothing
			End If

			'############### Write Tables back #######################

			'--- Prepare writing
			Dim oMT_WriteTable As New cls_sql_write
			oMT_WriteTable._i_connection_string = Me._connection_string
			oMT_WriteTable._i_transaction = oTransaction

			'--- Write the table
			oMT_WriteTable._i_datatable = Me._i_cll_datatables.Item(nLoop1)._datatable
			bError = oMT_WriteTable.WriteTable()
			If bError Then
				oInfo._success = False
				'--- Roll transaction back
				oTransaction.Rollback()
				'--- Collect errors
				Me._err_number = oMT_WriteTable._err_number
				Me._err_description = oMT_WriteTable._err_description
				Me._err_source = oMT_WriteTable._err_source
				Return True

			Else
				oInfo._success = True

			End If

			'--- Update information
			oInfo._id = oMT_WriteTable._o_id
			oInfo._tablename = Me._i_cll_datatables.Item(nLoop1)._datatable.tablename
			Me._i_cll_datatables.Item(nLoop1)._info.Add(oInfo)
			oInfo = Nothing

			'### Run MID routine ###
			bError = mid_update_transact(Me._i_cll_datatables.Item(nLoop1)._datatable.tablename)
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
			oTransaction.Commit()
			bInTransaction = False

			'--- Close connection
			oConnection.Close()

			'--- Cleanup
			oTransaction = Nothing
			oConnection = Nothing

		End If


		Return False
		Exit Function

ErrorHandler:

		'--- Roll transaction back
		If bInTransaction Then
			oTransaction.Rollback()
		End If

		'--- Collect errors
		Me._err_number = Err.Number
		Me._err_description = Err.Description
		Me._err_source = Err.Source
		Return True

	End Function

	Overridable Function pre_insert_transact() As Boolean
		On Error GoTo ErrorHandler
		Dim bError As Boolean = False



		Return False
		Exit Function

ErrorHandler:
		Me._err_number = Err.Number
		Me._err_description = Err.Description
		Me._err_source = Err.Source
		Return True

	End Function

	Overridable Function mid_insert_transact(ByVal cLastTable As String) As Boolean
		On Error GoTo ErrorHandler
		Dim bError As Boolean = False



		Return False
		Exit Function

ErrorHandler:
		Me._err_number = Err.Number
		Me._err_description = Err.Description
		Me._err_source = Err.Source
		Return True

	End Function

	Overridable Function suf_insert_transact() As Boolean
		On Error GoTo ErrorHandler
		Dim bError As Boolean = False



		Return False
		Exit Function

ErrorHandler:
		Me._err_number = Err.Number
		Me._err_description = Err.Description
		Me._err_source = Err.Source
		Return True

	End Function
	Overridable Function pre_update_transact() As Boolean
		On Error GoTo ErrorHandler
		Dim bError As Boolean = False



		Return False
		Exit Function

ErrorHandler:
		Me._err_number = Err.Number
		Me._err_description = Err.Description
		Me._err_source = Err.Source
		Return True

	End Function

	Overridable Function mid_update_transact(ByVal cLastTable As String) As Boolean
		On Error GoTo ErrorHandler
		Dim bError As Boolean = False



		Return False
		Exit Function

ErrorHandler:
		Me._err_number = Err.Number
		Me._err_description = Err.Description
		Me._err_source = Err.Source
		Return True

	End Function

	Overridable Function suf_update_transact() As Boolean
		On Error GoTo ErrorHandler
		Dim bError As Boolean = False

		Return False
		Exit Function

ErrorHandler:
		Me._err_number = Err.Number
		Me._err_description = Err.Description
		Me._err_source = Err.Source
		Return True

	End Function

End Class

