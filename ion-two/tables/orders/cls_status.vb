Public Class cls_status
	Inherits iFoundation.cls_error_connection


	'TODO: Add optin to send email when status is changed.

	Public _user_name As String

	Public Function set_status(ByVal nOrder_id As Int32, ByVal nStatus As Int16, Optional ByRef dDate As DateTime = #1/1/1900#, Optional ByVal cNote1 As String = "", Optional ByVal cNote2 As String = "") As Boolean
		On Error GoTo ErrorHandler
		Dim bError As Boolean = False

		'--- Set Date/Time
		dDate = Date.Now


		'--- Get order
		Dim oOrder As New ion_two.skl_order
		Dim oOrder_Logics As New ion_two.cls_order_lgc
		oOrder_Logics._connection_string = Me._connection_string
		oOrder_Logics._dbtype = Me._dbtype
		bError = oOrder_Logics.read(nOrder_id, oOrder)
		If bError Then
			Me._err_number = oOrder_Logics._err_number
			Me._err_description = oOrder_Logics._err_description
			Me._err_source = oOrder_Logics._err_source
			Return True
		End If


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
		'--- Assign Transaction to ME
		Me._idac_transaction = oTransaction


		Select Case nStatus
			Case 1
				bError = Me.set_status_1(oOrder, dDate, cNote1)

			Case 2
				bError = Me.set_status_2(oOrder, dDate, cNote1)

			Case 3
				bError = Me.set_status_3(oOrder, dDate, cNote1)

			Case 4
				bError = Me.set_status_4(oOrder, dDate, cNote1)

			Case 5
				bError = Me.set_status_5(oOrder, dDate, cNote1)

			Case 6
				bError = Me.set_status_6(oOrder, dDate, cNote1)

			Case 7
				bError = Me.set_status_7(oOrder, dDate, cNote1)

			Case 8
				bError = Me.set_status_8(oOrder, dDate, cNote1, cNote2)

			Case 9
				bError = Me.set_status_9(oOrder, dDate, cNote1)

			Case 10
				bError = Me.set_status_10(oOrder, dDate, cNote1)

			Case 11
				bError = Me.set_status_11(oOrder, dDate, cNote1)

			Case 12
				bError = Me.set_status_12(oOrder, dDate, cNote1)

			Case 13
				bError = Me.set_status_13(oOrder, dDate, cNote1)

			Case 14
				bError = Me.set_status_14(oOrder, dDate, cNote1)

			Case 15
				bError = Me.set_status_15(oOrder, dDate, cNote1)

			Case 16
				bError = Me.set_status_16(oOrder, dDate, cNote1)

			Case 17
				bError = Me.set_status_17(oOrder, dDate, cNote1)

		End Select

		If bError Then
			Me._idac_transaction._transaction.Rollback()
			Me._err_number = Err.Number
			Me._err_description = Err.Description
			Me._err_source = Err.Source
			Return True
		End If


		'--- Save order
		oOrder_Logics._idac_transaction = oTransaction
		bError = oOrder_Logics.update(oOrder)		 '--- update stock amount
		If bError Then
			Me._idac_transaction._transaction.Rollback()
			Me._err_number = oOrder_Logics._err_number
			Me._err_description = oOrder_Logics._err_description
			Me._err_source = oOrder_Logics._err_source
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
		oTransaction = Nothing
		'### End transaction

		Return False
		Exit Function

ErrorHandler:
		Me._err_number = Err.Number
		Me._err_description = Err.Description
		Me._err_source = Err.Source
		Return True

	End Function

	Private Function set_status_1(ByRef oOrder As ion_two.skl_order, ByRef dDate As DateTime, ByVal cNote1 As String) As Boolean
		'### New order received
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

	Private Function set_status_2(ByRef oOrder As ion_two.skl_order, ByRef dDate As DateTime, ByVal cNote1 As String) As Boolean
		'### Waiting for authorization
		On Error GoTo ErrorHandler
		Dim bError As Boolean = False

		'--- Set values
		oOrder._sts_waiting_for_authorization = True
		oOrder._sts_waiting_for_authorization_note = cNote1
		oOrder._sts_waiting_for_authorization_date = dDate
		'--- Set current values
		oOrder._sts_curr_stat = "Waiting for authorization"
		oOrder._sts_curr_date = dDate


		Return False
		Exit Function

ErrorHandler:
		Me._err_number = Err.Number
		Me._err_description = Err.Description
		Me._err_source = Err.Source
		Return True

	End Function

	Private Function set_status_3(ByRef oOrder As ion_two.skl_order, ByRef dDate As DateTime, ByVal cNote1 As String) As Boolean
		'### Waiting for payment
		On Error GoTo ErrorHandler
		Dim bError As Boolean = False

		'--- Set values
		oOrder._sts_waiting_for_payment = True
		oOrder._sts_waiting_for_payment_note = cNote1
		oOrder._sts_waiting_for_payment_date = dDate
		'--- Set current values
		oOrder._sts_curr_stat = "Waiting for payment"
		oOrder._sts_curr_date = dDate


		Return False
		Exit Function

ErrorHandler:
		Me._err_number = Err.Number
		Me._err_description = Err.Description
		Me._err_source = Err.Source
		Return True

	End Function

	Private Function set_status_4(ByRef oOrder As ion_two.skl_order, ByRef dDate As DateTime, ByVal cNote1 As String) As Boolean
		'### Order confirmed
		On Error GoTo ErrorHandler
		Dim bError As Boolean = False

		'--- Set values
		oOrder._sts_order_confirmed = True
		oOrder._sts_order_confirmed_note = cNote1
		oOrder._sts_order_confirmed_date = dDate
		'--- Set current values
		oOrder._sts_curr_stat = "Order confirmed"
		oOrder._sts_curr_date = dDate
		oOrder._order_transacted = True

		Dim bTransacted As Boolean
		Dim oOrder_functions As New ion_two.cls_functions_orders
		oOrder_functions._connection_string = Me._connection_string
		oOrder_functions._dbtype = Me._dbtype
		bError = oOrder_functions.get_order_transacted(oOrder._id, bTransacted)
		If bError Then
			Me._err_number = oOrder_functions._err_number
			Me._err_description = oOrder_functions._err_description
			Me._err_source = oOrder_functions._err_source
			Return True
		End If

		If Not bTransacted Then
			'--- Collect data to move order to books
			Dim oOrderTotals As New ion_two.cls_order_totals
			oOrderTotals._connection_string = Me._connection_string
			oOrderTotals._dbtype = Me._dbtype
			oOrderTotals._idac_transaction = Me._idac_transaction
			bError = oOrderTotals.get_totals(oOrder._id, Me._user_name, Me._user_id)
			If bError Then
				Me._idac_transaction._transaction.Rollback()
				Me._err_number = oOrderTotals._err_number
				Me._err_description = oOrderTotals._err_description
				Me._err_source = oOrderTotals._err_source
				Return True
			End If

			'--- Set item quantity 
			Dim oInventory_functions As New ion_two.cls_functions_inventory
			oInventory_functions._connection_string = Me._connection_string
			oInventory_functions._dbtype = Me._dbtype
			oInventory_functions._idac_transaction = Me._idac_transaction

			Dim nLoop As Int16
			For nLoop = 1 To oOrder._order_items.Count
				Dim nItem_id As Int32 = oOrder._order_items(nLoop)._item_id
				Dim nQuantity As Int16 = oOrder._order_items(nLoop)._item_quantity
				bError = oInventory_functions.set_cur_inventory(nItem_id, nQuantity)
				If bError Then
					Me._idac_transaction._transaction.Rollback()
					Me._err_number = oOrderTotals._err_number
					Me._err_description = oOrderTotals._err_description
					Me._err_source = oOrderTotals._err_source
					Return True
				End If
			Next

			oInventory_functions = Nothing
		End If


		oOrder_functions = Nothing

		Return False
		Exit Function

ErrorHandler:
		Me._idac_transaction._transaction.Rollback()
		Me._err_number = Err.Number
		Me._err_description = Err.Description
		Me._err_source = Err.Source
		Return True

	End Function

	Private Function set_status_5(ByRef oOrder As ion_two.skl_order, ByRef dDate As DateTime, ByVal cNote1 As String) As Boolean
		'### Partial oeder confirmed
		On Error GoTo ErrorHandler
		Dim bError As Boolean = False

		'--- Set values
		oOrder._sts_partial_order_confirmed = True
		oOrder._sts_partial_order_confirmed_date = dDate
		oOrder._sts_partial_order_confirmed_note = cNote1

		'--- Set current status for listings
		oOrder._sts_curr_stat = "Partial order confirmed"
		oOrder._sts_curr_date = dDate


		Return False
		Exit Function

ErrorHandler:
		Me._err_number = Err.Number
		Me._err_description = Err.Description
		Me._err_source = Err.Source
		Return True

	End Function

	Private Function set_status_6(ByRef oOrder As ion_two.skl_order, ByRef dDate As DateTime, ByVal cNote1 As String) As Boolean
		'### Order failed
		On Error GoTo ErrorHandler
		Dim bError As Boolean = False

		'--- Set values
		oOrder._sts_order_failed = True
		oOrder._sts_order_failed_date = dDate
		oOrder._sts_order_failed_note = cNote1

		'--- Set current status for listings
		oOrder._sts_curr_stat = "Order failed"
		oOrder._sts_curr_date = dDate

		Return False
		Exit Function

ErrorHandler:
		Me._err_number = Err.Number
		Me._err_description = Err.Description
		Me._err_source = Err.Source
		Return True

	End Function

	Private Function set_status_7(ByRef oOrder As ion_two.skl_order, ByRef dDate As DateTime, ByVal cNote1 As String) As Boolean
		'### Order waiting to be send
		On Error GoTo ErrorHandler
		Dim bError As Boolean = False

		'--- Set values
		oOrder._sts_order_waiting_to_be_send = True
		oOrder._sts_order_waiting_to_be_send_date = dDate
		oOrder._sts_order_waiting_to_be_send_note = cNote1

		'--- Set current status for listings
		oOrder._sts_curr_stat = "Order waiting to be send"
		oOrder._sts_curr_date = dDate


		Return False
		Exit Function

ErrorHandler:
		Me._err_number = Err.Number
		Me._err_description = Err.Description
		Me._err_source = Err.Source
		Return True

	End Function

	Private Function set_status_8(ByRef oOrder As ion_two.skl_order, ByRef dDate As DateTime, ByVal cNote1 As String, ByVal cNote2 As String) As Boolean
		'### Order send
		On Error GoTo ErrorHandler
		Dim bError As Boolean = False

		'--- Set values
		oOrder._sts_order_send = True
		oOrder._sts_order_send_date = dDate
		oOrder._sts_order_send_note = cNote1
		oOrder._shipping_tracking_no = cNote2

		'--- Set current status for listings
		oOrder._sts_curr_stat = "Order send"
		oOrder._sts_curr_date = dDate


		Return False
		Exit Function

ErrorHandler:
		Me._err_number = Err.Number
		Me._err_description = Err.Description
		Me._err_source = Err.Source
		Return True

	End Function

	Private Function set_status_9(ByRef oOrder As ion_two.skl_order, ByRef dDate As DateTime, ByVal cNote1 As String) As Boolean
		'### Partial order send
		On Error GoTo ErrorHandler
		Dim bError As Boolean = False

		'--- Set values
		oOrder._sts_partial_order_send = True
		oOrder._sts_partial_order_send_date = dDate
		oOrder._sts_partial_order_send_note = cNote1

		'--- Set current status for listings
		oOrder._sts_curr_stat = "Partial order send"
		oOrder._sts_curr_date = dDate


		Return False
		Exit Function

ErrorHandler:
		Me._err_number = Err.Number
		Me._err_description = Err.Description
		Me._err_source = Err.Source
		Return True

	End Function

	Private Function set_status_10(ByRef oOrder As ion_two.skl_order, ByRef dDate As DateTime, ByVal cNote1 As String) As Boolean
		'### Order received by customer
		On Error GoTo ErrorHandler
		Dim bError As Boolean = False

		'--- Set values
		oOrder._sts_order_received_by_customer = True
		oOrder._sts_order_received_by_customer_date = dDate
		oOrder._sts_order_received_by_customer_note = cNote1

		'--- Set current status for listings
		oOrder._sts_curr_stat = "Order received by customer"
		oOrder._sts_curr_date = dDate


		Return False
		Exit Function

ErrorHandler:
		Me._err_number = Err.Number
		Me._err_description = Err.Description
		Me._err_source = Err.Source
		Return True

	End Function

	Private Function set_status_11(ByRef oOrder As ion_two.skl_order, ByRef dDate As DateTime, ByVal cNote1 As String) As Boolean
		'### Order partialy received by customer
		On Error GoTo ErrorHandler
		Dim bError As Boolean = False

		'--- Set values
		oOrder._sts_partial_order_received_by_customer = True
		oOrder._sts_partial_order_received_by_customer_date = dDate
		oOrder._sts_partial_order_received_by_customer_note = cNote1

		'--- Set current status for listings
		oOrder._sts_curr_stat = "Order partialy received by customer"
		oOrder._sts_curr_date = dDate


		Return False
		Exit Function

ErrorHandler:
		Me._err_number = Err.Number
		Me._err_description = Err.Description
		Me._err_source = Err.Source
		Return True

	End Function

	Private Function set_status_12(ByRef oOrder As ion_two.skl_order, ByRef dDate As DateTime, ByVal cNote1 As String) As Boolean
		'### Customer returning order
		On Error GoTo ErrorHandler
		Dim bError As Boolean = False

		'--- Set values
		oOrder._sts_customer_returning_order = True
		oOrder._sts_customer_returning_order_date = dDate
		oOrder._sts_customer_returning_order_note = cNote1

		'--- Set current status for listings
		oOrder._sts_curr_stat = "Customer returning order"
		oOrder._sts_curr_date = dDate


		Return False
		Exit Function

ErrorHandler:
		Me._err_number = Err.Number
		Me._err_description = Err.Description
		Me._err_source = Err.Source
		Return True

	End Function

	Private Function set_status_13(ByRef oOrder As ion_two.skl_order, ByRef dDate As DateTime, ByVal cNote1 As String) As Boolean
		'### Customer returning part order
		On Error GoTo ErrorHandler
		Dim bError As Boolean = False

		'--- Set values
		oOrder._sts_customer_returning_part_order = True
		oOrder._sts_customer_returning_part_order_date = dDate
		oOrder._sts_customer_returning_part_order_note = cNote1

		'--- Set current status for listings
		oOrder._sts_curr_stat = "Customer returning part order"
		oOrder._sts_curr_date = dDate


		Return False
		Exit Function

ErrorHandler:
		Me._err_number = Err.Number
		Me._err_description = Err.Description
		Me._err_source = Err.Source
		Return True

	End Function

	Private Function set_status_14(ByRef oOrder As ion_two.skl_order, ByRef dDate As DateTime, ByVal cNote1 As String) As Boolean
		'### Customer refunded
		On Error GoTo ErrorHandler
		Dim bError As Boolean = False

		'--- Set values
		oOrder._sts_customer_refunded = True
		oOrder._sts_customer_refunded_date = dDate
		oOrder._sts_customer_refunded_note = cNote1

		'--- Set current status for listings
		oOrder._sts_curr_stat = "Customer refunded"
		oOrder._sts_curr_date = dDate

		Return False
		Exit Function

ErrorHandler:
		Me._err_number = Err.Number
		Me._err_description = Err.Description
		Me._err_source = Err.Source
		Return True

	End Function

	Private Function set_status_15(ByRef oOrder As ion_two.skl_order, ByRef dDate As DateTime, ByVal cNote1 As String) As Boolean
		'### customer partly refunded
		On Error GoTo ErrorHandler
		Dim bError As Boolean = False

		'--- Set values
		oOrder._sts_customer_partly_refunded = True
		oOrder._sts_customer_partly_refunded_date = dDate
		oOrder._sts_customer_partly_refunded_note = cNote1

		'--- Set current status for listings
		oOrder._sts_curr_stat = "Customer partly refunded"
		oOrder._sts_curr_date = dDate

		Return False
		Exit Function

ErrorHandler:
		Me._err_number = Err.Number
		Me._err_description = Err.Description
		Me._err_source = Err.Source
		Return True

	End Function

	Private Function set_status_16(ByRef oOrder As ion_two.skl_order, ByRef dDate As DateTime, ByVal cNote1 As String) As Boolean
		'### Order closed
		On Error GoTo ErrorHandler
		Dim bError As Boolean = False

		'--- Set values
		oOrder._sts_order_closed = True
		oOrder._sts_order_closed_date = dDate
		oOrder._sts_order_closed_note = cNote1

		'--- Set current status for listings
		oOrder._sts_curr_stat = "Order closed"
		oOrder._sts_curr_date = dDate

		Return False
		Exit Function

ErrorHandler:
		Me._err_number = Err.Number
		Me._err_description = Err.Description
		Me._err_source = Err.Source
		Return True

	End Function

	Private Function set_status_17(ByRef oOrder As ion_two.skl_order, ByRef dDate As DateTime, ByVal cNote1 As String) As Boolean
		'### Order cancelled
		On Error GoTo ErrorHandler
		Dim bError As Boolean = False

		'--- Set values
		oOrder._sts_order_cancelled = True
		oOrder._sts_order_cancelled_date = dDate
		oOrder._sts_order_cancelled_note = cNote1

		'--- Set current status for listings
		oOrder._sts_curr_stat = "Order cancelled"
		oOrder._sts_curr_date = dDate

		Dim oAccounting_functions As New ion_two.cls_functions_accounting
		oAccounting_functions._connection_string = Me._connection_string
		oAccounting_functions._dbtype = Me._dbtype
		oAccounting_functions._idac_transaction = Me._idac_transaction
		bError = oAccounting_functions.set_cancel_order_payment(oOrder._id)
		If bError Then
			Me._idac_transaction._transaction.Rollback()
			Me._err_number = oAccounting_functions._err_number
			Me._err_description = oAccounting_functions._err_description
			Me._err_source = oAccounting_functions._err_source
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

	Private Function get_username(ByVal nOrder_id) As Boolean
		On Error GoTo ErrorHandler
		Dim bError As Boolean = False

		'--- Get user from order
		Dim oOrder_functions As New ion_two.cls_functions_orders
		oOrder_functions._connection_string = Me._connection_string
		oOrder_functions._dbtype = Me._dbtype
		bError = oOrder_functions.get_order_user(nOrder_id, Me._user_id, Me._user_name)
		If bError Then
			Me._err_number = oOrder_functions._err_number
			Me._err_description = oOrder_functions._err_description
			Me._err_source = oOrder_functions._err_source
			Return True
		End If
		oOrder_functions = Nothing

		Return False
		Exit Function

ErrorHandler:
		Me._err_number = Err.Number
		Me._err_description = Err.Description
		Me._err_source = Err.Source
		Return True
	End Function

End Class
