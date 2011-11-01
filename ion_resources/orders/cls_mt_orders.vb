Imports System.Data.SqlClient

Public Class cls_mt_orders
	Inherits ion_idac.cls_mt_transactor
	Private m_id As Int32
	Private m_order_number As Int32

	Overrides Function pre_insert_transact() As Boolean
		On Error GoTo ErrorHandler
		Dim bError As Boolean = False


		'--- Get Last nuber from Counters
		Dim oTmpObject As New cls_functions_order
		oTmpObject.connection_string = Me.connection_string
		bError = oTmpObject.get_lastorderno(Me.order_number)
		Me.order_number = Me.order_number + 1

		Me.i_cll_datatables(1).datatable.rows(0)("ordernumber") = Me.order_number

		Dim nLoop As Int32
		For nLoop = 0 To Me.i_cll_datatables(2).datatable.rows.count - 1
			Me.i_cll_datatables(2).datatable.rows(nLoop)("ordernumber") = Me.order_number
		Next

		Return False
		Exit Function

ErrorHandler:
		error_no = Err.Number
		error_desc = Err.Description
		error_source = Err.Source
		Return True
	End Function

	Overrides Function mid_insert_transact(ByVal cLastTable As String) As Boolean
		On Error GoTo ErrorHandler
		Dim bError As Boolean = False

		If LCase(cLastTable) = "acc_orders" Then
			Me.id = Me.i_cll_datatables(1).info(1).id
			Dim nLoop As Int32
			For nLoop = 0 To Me.i_cll_datatables(2).datatable.rows.count - 1
				Me.i_cll_datatables(2).datatable.rows(nLoop)("order_id") = Me.id
			Next
		End If


		Return False
		Exit Function

ErrorHandler:
		error_no = Err.Number
		error_desc = Err.Description
		error_source = Err.Source
		Return True

	End Function

	Overrides Function suf_insert_transact() As Boolean
		On Error GoTo ErrorHandler
		Dim bError As Boolean = False


		Dim cSQLnumberUpdate As String
		Dim oUpdateCommand As New SqlCommand

		'--- Update COUNTER LastNumber
		oUpdateCommand = New SqlCommand(cSQLnumberUpdate, Me.connection)
		oUpdateCommand.Transaction = Me.transaction
		cSQLnumberUpdate = "update sys_COUNTERS set counter = " & Me.order_number & " where id = 1"
		oUpdateCommand.CommandType = CommandType.Text
		oUpdateCommand.CommandText = cSQLnumberUpdate
		oUpdateCommand.ExecuteNonQuery()



		Return False
		Exit Function

ErrorHandler:
		error_no = Err.Number
		error_desc = Err.Description
		error_source = Err.Source
		Return True
	End Function

	Overrides Function pre_update_transact() As Boolean
		On Error GoTo ErrorHandler
		Dim bError As Boolean = False


		'--- Delete all ORDER_ITEMS of this ORDER before adding the new batch
		Dim cSQLnumberUpdate As String
		Dim oUpdateCommand As New SqlCommand

		oUpdateCommand = New SqlCommand(cSQLnumberUpdate, Me.connection)
		oUpdateCommand.Transaction = Me.transaction

		cSQLnumberUpdate = "delete acc_ORDER_ITEMS where order_id=" + System.Convert.ToString(Me.id)
		oUpdateCommand.CommandType = CommandType.Text
		oUpdateCommand.CommandText = cSQLnumberUpdate
		oUpdateCommand.ExecuteNonQuery()

		Return False
		Exit Function

ErrorHandler:
		error_no = Err.Number
		error_desc = Err.Description
		error_source = Err.Source
		Return True

	End Function

	Public Property id() As Int32
		Get
			Return m_id
		End Get

		Set(ByVal Value As Int32)
			m_id = Value
		End Set
	End Property

	Public Property order_number() As Int32
		Get
			Return m_order_number
		End Get

		Set(ByVal Value As Int32)
			m_order_number = Value
		End Set
	End Property

End Class
