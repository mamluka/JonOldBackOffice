Public Class cls_status
	Private m_error_no As Integer
	Private m_error_desc As String
	Private m_error_source As String
	Private m_connection_string As String

    Private m_lastmodify_user As String
    Private m_lastmodify_user_id As Int32

	Private m_transaction As System.Data.SqlClient.SqlTransaction
	Private m_connection As System.Data.SqlClient.SqlConnection

	Public zzoOrder As New ion_resources.cls_order
    Public oTmpOrder As ion_resources.cls_order_lgc()

	Public Function set_status(ByVal oOrder As ion_resources.cls_order, ByVal nStatus As Int16, ByVal nOrderId As Int32) As Boolean
		'--- Set status on an order
		On Error GoTo ErrorHandler

		'--- local definitions
		Dim bError As Boolean = False

		'--- Initiate Load Order
		Dim oTmpOrder As New ion_resources.cls_order_lgc
		oTmpOrder.connection_string = Me.connection_string


		'--- set status
		Select Case nStatus
			Case 2
				'--- Run the status - event - handler
				bError = set_status_direct(2, nOrderId)
				If Not bError Then
					'--- Load order
					bError = oTmpOrder.get_order_by_id(nOrderId, oOrder)
					If bError Then
						Me.error_no = oTmpOrder.error_no
						Me.error_desc = oTmpOrder.error_desc
						Me.error_source = oTmpOrder.error_source
						Return True
					End If

					'--- If everything OK Chage status
					oOrder.sts_waiting_for_authorization = True
					oOrder.sts_waiting_for_authorization_date = Date.Now
					oOrder.sts_curr_stat = "Waiting for authorization"
					oOrder.sts_curr_date = oOrder.sts_waiting_for_authorization_date
				End If

			Case 3
				'--- Run the status - event - handler
				bError = set_status_direct(3, nOrderId)
				If Not bError Then
					'--- Load order
					bError = oTmpOrder.get_order_by_id(nOrderId, oOrder)
					If bError Then
						Me.error_no = oTmpOrder.error_no
						Me.error_desc = oTmpOrder.error_desc
						Me.error_source = oTmpOrder.error_source
						Return True
					End If

					'--- If everything OK Chage status
					oOrder.sts_waiting_for_payment = True
					oOrder.sts_waiting_for_payment_date = Date.Now
					oOrder.sts_curr_stat = "Waiting for payment"
					oOrder.sts_curr_date = oOrder.sts_waiting_for_payment_date
				End If

			Case 4
				'--- Run the status - event - handler
				bError = set_status_direct(4, nOrderId)
				If Not bError Then
					'--- Load order
					bError = oTmpOrder.get_order_by_id(nOrderId, oOrder)
					If bError Then
						Me.error_no = oTmpOrder.error_no
						Me.error_desc = oTmpOrder.error_desc
						Me.error_source = oTmpOrder.error_source
						Return True
					End If

					'--- If everything OK Chage status
					oOrder.sts_order_confirmed = True
					oOrder.sts_order_confirmed_date = Date.Now
					oOrder.sts_curr_stat = "Order confirmed"
					oOrder.sts_curr_date = oOrder.sts_order_confirmed_date
				End If

			Case 5
				'--- Run the status - event - handler
				bError = set_status_direct(5, nOrderId)
				If Not bError Then
					'--- Load order
					bError = oTmpOrder.get_order_by_id(nOrderId, oOrder)
					If bError Then
						Me.error_no = oTmpOrder.error_no
						Me.error_desc = oTmpOrder.error_desc
						Me.error_source = oTmpOrder.error_source
						Return True
					End If

					'--- If everything OK Chage status
					oOrder.sts_partial_order_confirmed = True
					oOrder.sts_partial_order_confirmed_date = Date.Now
					oOrder.sts_curr_stat = "Partial order confirmed"
					oOrder.sts_curr_date = oOrder.sts_partial_order_confirmed_date
				End If

			Case 6
				'--- Run the status - event - handler
				bError = set_status_direct(6, nOrderId)
				If Not bError Then
					'--- Load order
					bError = oTmpOrder.get_order_by_id(nOrderId, oOrder)
					If bError Then
						Me.error_no = oTmpOrder.error_no
						Me.error_desc = oTmpOrder.error_desc
						Me.error_source = oTmpOrder.error_source
						Return True
					End If

					'--- If everything OK Chage status
					oOrder.sts_order_failed = True
					oOrder.sts_order_failed_date = Date.Now
					oOrder.sts_curr_stat = "Order failed"
					oOrder.sts_curr_date = oOrder.sts_order_failed_date
				End If

			Case 7
				'--- Run the status - event - handler
				bError = set_status_direct(7, nOrderId)
				If Not bError Then
					'--- Load order
					bError = oTmpOrder.get_order_by_id(nOrderId, oOrder)
					If bError Then
						Me.error_no = oTmpOrder.error_no
						Me.error_desc = oTmpOrder.error_desc
						Me.error_source = oTmpOrder.error_source
						Return True
					End If

					'--- If everything OK Chage status
					oOrder.sts_order_waiting_to_be_send = True
					oOrder.sts_order_waiting_to_be_send_date = Date.Now
					oOrder.sts_curr_stat = "Order waiting to be send"
					oOrder.sts_curr_date = oOrder.sts_order_waiting_to_be_send_date
				End If

			Case 8
				'--- Run the status - event - handler
				bError = set_status_direct(8, nOrderId)
				If Not bError Then
					'--- Load order
					bError = oTmpOrder.get_order_by_id(nOrderId, oOrder)
					If bError Then
						Me.error_no = oTmpOrder.error_no
						Me.error_desc = oTmpOrder.error_desc
						Me.error_source = oTmpOrder.error_source
						Return True
					End If

					'--- If everything OK Chage status
					oOrder.sts_order_send = True
					oOrder.sts_order_send_date = Date.Now
					oOrder.sts_curr_stat = "Order send"
					oOrder.sts_curr_date = oOrder.sts_order_send_date
				End If

			Case 9
				'--- Run the status - event - handler
				bError = set_status_direct(9, nOrderId)
				If Not bError Then
					'--- Load order
					bError = oTmpOrder.get_order_by_id(nOrderId, oOrder)
					If bError Then
						Me.error_no = oTmpOrder.error_no
						Me.error_desc = oTmpOrder.error_desc
						Me.error_source = oTmpOrder.error_source
						Return True
					End If

					'--- If everything OK Chage status
					oOrder.sts_partial_order_send = True
					oOrder.sts_partial_order_send_date = Date.Now
					oOrder.sts_curr_stat = "Partial order send"
					oOrder.sts_curr_date = oOrder.sts_partial_order_send_date
				End If

			Case 10
				'--- Run the status - event - handler
				bError = set_status_direct(10, nOrderId)
				If Not bError Then
					'--- Load order
					bError = oTmpOrder.get_order_by_id(nOrderId, oOrder)
					If bError Then
						Me.error_no = oTmpOrder.error_no
						Me.error_desc = oTmpOrder.error_desc
						Me.error_source = oTmpOrder.error_source
						Return True
					End If

					'--- If everything OK Chage status
					oOrder.sts_order_received_by_customer = True
					oOrder.sts_order_received_by_customer_date = Date.Now
					oOrder.sts_curr_stat = "Order received by customer"
					oOrder.sts_curr_date = oOrder.sts_order_received_by_customer_date
				End If

			Case 11
				'--- Run the status - event - handler
				bError = set_status_direct(11, nOrderId)
				If Not bError Then
					'--- Load order
					bError = oTmpOrder.get_order_by_id(nOrderId, oOrder)
					If bError Then
						Me.error_no = oTmpOrder.error_no
						Me.error_desc = oTmpOrder.error_desc
						Me.error_source = oTmpOrder.error_source
						Return True
					End If

					'--- If everything OK Chage status
					oOrder.sts_partial_order_received_by_customer = True
					oOrder.sts_partial_order_received_by_customer_date = Date.Now
					oOrder.sts_curr_stat = "Partial order received by customer"
					oOrder.sts_curr_date = oOrder.sts_partial_order_received_by_customer_date
				End If

			Case 12
				'--- Run the status - event - handler
				bError = set_status_direct(12, nOrderId)
				If Not bError Then
					'--- Load order
					bError = oTmpOrder.get_order_by_id(nOrderId, oOrder)
					If bError Then
						Me.error_no = oTmpOrder.error_no
						Me.error_desc = oTmpOrder.error_desc
						Me.error_source = oTmpOrder.error_source
						Return True
					End If

					'--- If everything OK Chage status
					oOrder.sts_customer_returning_order = True
					oOrder.sts_customer_returning_order_date = Date.Now
					oOrder.sts_curr_stat = "Customer returning order"
					oOrder.sts_curr_date = oOrder.sts_customer_returning_order_date
				End If

			Case 13
				'--- Run the status - event - handler
				bError = set_status_direct(13, nOrderId)
				If Not bError Then
					'--- Load order
					bError = oTmpOrder.get_order_by_id(nOrderId, oOrder)
					If bError Then
						Me.error_no = oTmpOrder.error_no
						Me.error_desc = oTmpOrder.error_desc
						Me.error_source = oTmpOrder.error_source
						Return True
					End If

					'--- If everything OK Chage status
					oOrder.sts_customer_returning_part_order = True
					oOrder.sts_customer_returning_part_order_date = Date.Now
					oOrder.sts_curr_stat = "Customer returning part order"
					oOrder.sts_curr_date = oOrder.sts_customer_returning_part_order_date
				End If

			Case 14
				'--- Run the status - event - handler
				bError = set_status_direct(14, nOrderId)
				If Not bError Then
					'--- Load order
					bError = oTmpOrder.get_order_by_id(nOrderId, oOrder)
					If bError Then
						Me.error_no = oTmpOrder.error_no
						Me.error_desc = oTmpOrder.error_desc
						Me.error_source = oTmpOrder.error_source
						Return True
					End If

					'--- If everything OK Chage status
					oOrder.sts_customer_refunded = True
					oOrder.sts_customer_refunded_date = Date.Now
					oOrder.sts_curr_stat = "Customer refunded"
					oOrder.sts_curr_date = oOrder.sts_customer_refunded_date
				End If

			Case 15
				'--- Run the status - event - handler
				bError = set_status_direct(15, nOrderId)
				If Not bError Then
					'--- Load order
					bError = oTmpOrder.get_order_by_id(nOrderId, oOrder)
					If bError Then
						Me.error_no = oTmpOrder.error_no
						Me.error_desc = oTmpOrder.error_desc
						Me.error_source = oTmpOrder.error_source
						Return True
					End If

					'--- If everything OK Chage status
					oOrder.sts_customer_partly_refunded = True
					oOrder.sts_customer_partly_refunded_date = Date.Now
					oOrder.sts_curr_stat = "Customer partly refunded"
					oOrder.sts_curr_date = oOrder.sts_customer_partly_refunded_date
				End If

			Case 16
				'--- Run the status - event - handler
				bError = set_status_direct(16, nOrderId)
				If Not bError Then
					'--- Load order
					bError = oTmpOrder.get_order_by_id(nOrderId, oOrder)
					If bError Then
						Me.error_no = oTmpOrder.error_no
						Me.error_desc = oTmpOrder.error_desc
						Me.error_source = oTmpOrder.error_source
						Return True
					End If

					'--- If everything OK Chage status
					oOrder.sts_order_closed = True
					oOrder.sts_order_closed_date = Date.Now
					oOrder.sts_curr_stat = "Order closed"
					oOrder.sts_curr_date = oOrder.sts_order_closed_date
				End If

			Case 17
				'--- Run the status - event - handler
				bError = set_status_direct(17, nOrderId)
				If Not bError Then
					'--- Load order
					bError = oTmpOrder.get_order_by_id(nOrderId, oOrder)
					If bError Then
						Me.error_no = oTmpOrder.error_no
						Me.error_desc = oTmpOrder.error_desc
						Me.error_source = oTmpOrder.error_source
						Return True
					End If

					'--- If everything OK Chage status
					oOrder.sts_order_cancelled = True
					oOrder.sts_order_cancelled_date = Date.Now
					oOrder.sts_curr_stat = "Order cancelled"
					oOrder.sts_curr_date = oOrder.sts_order_cancelled_date
				End If

		End Select

		'--- catch error and pass trou
		If bError Then
			Me.error_no = Me.error_no
			Me.error_desc = Me.error_desc
			Me.error_source = Me.error_source
			Return True
		End If

		'--- Save Order
		'TODO: Check if functions works correct -> update_order_new(oOrder)
		bError = oTmpOrder.update_order_new(oOrder, False)
		If bError Then
			Me.error_no = oTmpOrder.error_no
			Me.error_desc = oTmpOrder.error_desc
			Me.error_source = oTmpOrder.error_source
			Return True
		End If

		oTmpOrder = Nothing

		Return False
		Exit Function

ErrorHandler:
		Me.error_no = Err.Number
		Me.error_desc = Err.Description
		Me.error_source = Err.Source
		Return True

	End Function

	Public Function save_order(ByVal bInventoryRemove As Boolean)
		On Error GoTo ErrorHandler
		Dim bError As Boolean = False


		'--- Save Order
		Dim oTmpOrder As New ion_resources.cls_order_lgc
		'oTmpOrder.connection_string = Application("config").connection_string
		oTmpOrder.connection = Me.connection
		oTmpOrder.transaction = Me.transaction

		'bError = oTmpOrder.update_order_new(oOrder, bInventoryRemove)
		If bError Then
			If Not IsNothing(oTmpOrder.transaction) Then
				oTmpOrder.transaction.Rollback()
			End If
			Me.error_no = Err.Number
			Me.error_desc = Err.Description
			Me.error_source = Err.Source
			Return True
		End If


		Return False
		Exit Function

ErrorHandler:
		Me.error_no = Err.Number
		Me.error_desc = Err.Description
		Me.error_source = Err.Source
		Return True

	End Function

	'#################################################################
	Public Function set_status_direct(ByVal nStatus As Int16, ByVal nOrderId As Int32) As Boolean
		'--- Set status on an order
		'On Error GoTo ErrorHandler

		'--- local definitions
		Dim bError As Boolean = False

		Select Case nStatus
			Case 2
				bError = status_2_event(nOrderId)

			Case 3
				bError = status_3_event(nOrderId)

			Case 4
				bError = status_4_event(nOrderId)

			Case 5
				bError = status_5_event(nOrderId)

			Case 6
				bError = status_6_event(nOrderId)

			Case 7
				bError = status_7_event(nOrderId)

			Case 8
				bError = status_8_event(nOrderId)

			Case 9
				bError = status_9_event(nOrderId)

			Case 10
				bError = status_10_event(nOrderId)

			Case 11
				bError = status_11_event(nOrderId)

			Case 12
				bError = status_12_event(nOrderId)

			Case 13
				bError = status_13_event(nOrderId)

			Case 14
				bError = status_14_event(nOrderId)

			Case 15
				bError = status_15_event(nOrderId)

			Case 16
				bError = status_16_event(nOrderId)

			Case 17
				bError = status_17_event(nOrderId)

		End Select


		'--- catch error and pass trou
		If bError Then
			Me.error_no = Me.error_no
			Me.error_desc = Me.error_desc
			Me.error_source = Me.error_source
			Return True
		End If


		Return False
		Exit Function

ErrorHandler:
		Me.error_no = Err.Number
		Me.error_desc = Err.Description
		Me.error_source = Err.Source
		Return True

	End Function


	'#################################################################
	Private Function status_2_event(ByVal nOrderId As Int32)
		On Error GoTo ErrorHandler
		'--- waiting_for_authorization



		Return False
		Exit Function

ErrorHandler:
		Me.error_no = Err.Number
		Me.error_desc = Err.Description
		Me.error_source = Err.Source
		Return True

	End Function

	'#################################################################
	Private Function status_3_event(ByVal nOrderId As Int32)
		On Error GoTo ErrorHandler
		'--- waiting_for_payment



		Return False
		Exit Function

ErrorHandler:
		Me.error_no = Err.Number
		Me.error_desc = Err.Description
		Me.error_source = Err.Source
		Return True

	End Function

	'#################################################################
	Private Function status_4_event(ByVal nOrderId As Int32)
		On Error GoTo ErrorHandler
		'--- order_confirmed

		Dim bError As Boolean = False

		Dim oFunctionOrders As New ion_resources.cls_functions_order
		oFunctionOrders.connection_string = Me.connection_string
		Dim bOrderTransact As Boolean
		bError = oFunctionOrders.get_order_transact(nOrderId, bOrderTransact)
		If Not bOrderTransact Then
			'--- Collect data to move order to books
			Dim oTmpOrderTotal As New ion_resources.cls_order_totals
			oTmpOrderTotal.connection_string = Me.connection_string
			oTmpOrderTotal.connection = Me.connection
			oTmpOrderTotal.transaction = Me.transaction
			bError = oTmpOrderTotal.get_totals(nOrderId, Me.lastmodify_user, Me.lastmodify_user_id)
			If bError Then
				Me.error_no = oTmpOrderTotal.error_number
				Me.error_desc = oTmpOrderTotal.error_description
				Me.error_source = oTmpOrderTotal.error_source
				Return True
			End If


		Else
			Err.Raise(5015, "[cls_status-set_status]", "ERROR 5015: Transaction was already preformed! ")
		End If


		Return False
		Exit Function

ErrorHandler:
		Me.error_no = Err.Number
		Me.error_desc = Err.Description
		Me.error_source = Err.Source
		Return True

	End Function


	'#################################################################
	Private Function status_5_event(ByVal nOrderId As Int32)
		On Error GoTo ErrorHandler
		'--- partial_order_confirmed



		Return False
		Exit Function

ErrorHandler:
		Me.error_no = Err.Number
		Me.error_desc = Err.Description
		Me.error_source = Err.Source
		Return True

	End Function


	'#################################################################
	Private Function status_6_event(ByVal nOrderId As Int32)
		On Error GoTo ErrorHandler
		'--- order_failed



		Return False
		Exit Function

ErrorHandler:
		Me.error_no = Err.Number
		Me.error_desc = Err.Description
		Me.error_source = Err.Source
		Return True

	End Function

	'#################################################################
	Private Function status_7_event(ByVal nOrderId As Int32)
		On Error GoTo ErrorHandler
		'--- order_waiting_to_be_send




		Return False
		Exit Function

ErrorHandler:
		Me.error_no = Err.Number
		Me.error_desc = Err.Description
		Me.error_source = Err.Source
		Return True

	End Function

	'#################################################################
	Private Function status_8_event(ByVal nOrderId As Int32)
		On Error GoTo ErrorHandler
		'--- order_send



		Return False
		Exit Function

ErrorHandler:
		Me.error_no = Err.Number
		Me.error_desc = Err.Description
		Me.error_source = Err.Source
		Return True

	End Function

	'#################################################################
	Private Function status_9_event(ByVal nOrderId As Int32)
		On Error GoTo ErrorHandler
		'--- partial_order_send




		Return False
		Exit Function

ErrorHandler:
		Me.error_no = Err.Number
		Me.error_desc = Err.Description
		Me.error_source = Err.Source
		Return True

	End Function


	'#################################################################
	Private Function status_10_event(ByVal nOrderId As Int32)
		On Error GoTo ErrorHandler



		Return False
		Exit Function

ErrorHandler:
		Me.error_no = Err.Number
		Me.error_desc = Err.Description
		Me.error_source = Err.Source
		Return True

	End Function

	'#################################################################
	Private Function status_11_event(ByVal nOrderId As Int32)
		On Error GoTo ErrorHandler
		'--- partial_order_received_by_customer



		Return False
		Exit Function

ErrorHandler:
		Me.error_no = Err.Number
		Me.error_desc = Err.Description
		Me.error_source = Err.Source
		Return True

	End Function

	'#################################################################
	Private Function status_12_event(ByVal nOrderId As Int32)
		On Error GoTo ErrorHandler
		'--- customer_returning_orde



		Return False
		Exit Function

ErrorHandler:
		Me.error_no = Err.Number
		Me.error_desc = Err.Description
		Me.error_source = Err.Source
		Return True

	End Function

	'#################################################################
	Private Function status_13_event(ByVal nOrderId As Int32)
		On Error GoTo ErrorHandler
		'--- customer_returning_part_order



		Return False
		Exit Function

ErrorHandler:
		Me.error_no = Err.Number
		Me.error_desc = Err.Description
		Me.error_source = Err.Source
		Return True

	End Function

	'#################################################################
	Private Function status_14_event(ByVal nOrderId As Int32)
		On Error GoTo ErrorHandler
		'--- sts_customer_refunded



		Return False
		Exit Function

ErrorHandler:
		Me.error_no = Err.Number
		Me.error_desc = Err.Description
		Me.error_source = Err.Source
		Return True

	End Function

	'#################################################################
	Private Function status_15_event(ByVal nOrderId As Int32)
		On Error GoTo ErrorHandler
		'--- customer_partly_refunded



		Return False
		Exit Function

ErrorHandler:
		Me.error_no = Err.Number
		Me.error_desc = Err.Description
		Me.error_source = Err.Source
		Return True

	End Function


	'#################################################################
	Private Function status_16_event(ByVal nOrderId As Int32)
		On Error GoTo ErrorHandler
		'--- order_closed



		Return False
		Exit Function

ErrorHandler:
		Me.error_no = Err.Number
		Me.error_desc = Err.Description
		Me.error_source = Err.Source
		Return True

	End Function

	'#################################################################
	Private Function status_17_event(ByVal nOrderId As Int32)
		On Error GoTo ErrorHandler
		'--- order_cancelled

		Dim bError As Boolean = False

		'--- Remove order from Books
		Dim cSQLnumberUpdate As String
		Dim oUpdateCommand As New System.Data.SqlClient.SqlCommand

		'--- Update COUNTER LastNumber
		oUpdateCommand = New System.Data.SqlClient.SqlCommand(cSQLnumberUpdate, Me.connection)
		oUpdateCommand.Transaction = Me.transaction

		'--- delete in supplier books
		cSQLnumberUpdate = "delete from acc_suppliers_books where order_id = " + Convert.ToString(nOrderId)
		oUpdateCommand.CommandType = CommandType.Text
		oUpdateCommand.CommandText = cSQLnumberUpdate
		oUpdateCommand.ExecuteNonQuery()

		'--- delete in General books
		cSQLnumberUpdate = "delete from acc_general_books where order_id = " + Convert.ToString(nOrderId)
		oUpdateCommand.CommandType = CommandType.Text
		oUpdateCommand.CommandText = cSQLnumberUpdate
		oUpdateCommand.ExecuteNonQuery()

		'--- delete in Cashflow
		cSQLnumberUpdate = "delete from acc_cashflow where order_id = " + Convert.ToString(nOrderId)
		oUpdateCommand.CommandType = CommandType.Text
		oUpdateCommand.CommandText = cSQLnumberUpdate
		oUpdateCommand.ExecuteNonQuery()


		Return False
		Exit Function

ErrorHandler:
		Me.error_no = Err.Number
		Me.error_desc = Err.Description
		Me.error_source = Err.Source
		Return True

	End Function

	Public Property error_no() As Integer
		Get
			Return m_error_no
		End Get

		Set(ByVal Value As Integer)
			m_error_no = Value
		End Set
	End Property

	Public Property error_desc() As String
		Get
			Return m_error_desc
		End Get

		Set(ByVal Value As String)
			m_error_desc = Value
		End Set
	End Property

	Public Property error_source() As String
		Get
			Return m_error_source
		End Get

		Set(ByVal Value As String)
			m_error_source = Value
		End Set
	End Property

	Public Property connection_string() As String
		Get
			Return m_connection_string
		End Get

		Set(ByVal Value As String)
			m_connection_string = Value
		End Set
	End Property

	Public Property lastmodify_user() As String
		Get
			Return m_lastmodify_user
		End Get

		Set(ByVal Value As String)
			m_lastmodify_user = Value
		End Set
	End Property

	Public Property lastmodify_user_id() As Int32
		Get
			Return m_lastmodify_user_id
		End Get

		Set(ByVal Value As Int32)
			m_lastmodify_user_id = Value
		End Set
	End Property

	Public Property transaction() As System.Data.SqlClient.SqlTransaction
		Get
			Return m_transaction
		End Get

		Set(ByVal Value As System.Data.SqlClient.SqlTransaction)
			m_transaction = Value
		End Set
	End Property

	Public Property connection() As System.Data.SqlClient.SqlConnection
		Get
			Return m_connection
		End Get

		Set(ByVal Value As System.Data.SqlClient.SqlConnection)
			m_connection = Value
		End Set
	End Property

End Class
