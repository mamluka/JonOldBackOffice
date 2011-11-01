Imports System.Data.SqlClient

Public Class cls_trs_insert_order
	Inherits ion_resources.cls_transactor


	Private m_order_id As Int32
	Private m_order_no As Int32


	Shared nLastOrder As Int32 = 0
	Shared cSQLnumberUpdate As String
    Shared oUpdateCommand As New SqlCommand()


	'###################################################################################
	Overrides Function init_transaction(ByRef error_no As Int32, ByRef error_desc As String, ByRef error_source As String) As Boolean
		On Error GoTo ErrorHandler
		Dim bError As Boolean = False

		'--- Update COUNTER LastNumber
		oUpdateCommand = New SqlCommand(cSQLnumberUpdate, Me.oConnection)
		oUpdateCommand.Transaction = Me.oTransaction


		Return False
		Exit Function

ErrorHandler:
		error_no = Err.Number
		error_desc = Err.Description
		error_source = Err.Source
		Return True

	End Function

	'###################################################################################
	Overrides Function in_transaction(ByRef error_no As Int32, ByRef error_desc As String, ByRef error_source As String) As Boolean
		On Error GoTo ErrorHandler
		Dim bError As Boolean = False


		'--- Get Last nuber from Counters
		Dim oTmpObject As New cls_functions_order()
		oTmpObject.connection_string = Me.connection_string
		bError = oTmpObject.get_lastorderno(nLastOrder)

		'--- Pass order number to ORDERS
		Dim oOrder As DataRow = Me.dataset.Tables("acc_ORDERS").Rows(0)
		oOrder("ordernumber") = nLastOrder + 1


		'--- Set OrderNumber
		Dim nLoop As Int16
		For nLoop = 0 To Me.dataset.Tables("acc_ORDER_ITEMS").Rows.Count - 1
			Dim oOrder_Item As DataRow = Me.dataset.Tables("acc_ORDER_ITEMS").Rows(nLoop)
			oOrder_Item("ordernumber") = nLastOrder + 1
		Next


		Return False
		Exit Function

ErrorHandler:
		error_no = Err.Number
		error_desc = Err.Description
		error_source = Err.Source
		Return True

	End Function


	'###################################################################################
	Overrides Function pre_commit(ByRef error_no As Int32, ByRef error_desc As String, ByRef error_source As String) As Boolean
		On Error GoTo ErrorHandler
		Dim bError As Boolean = False


        cSQLnumberUpdate = "update sys_COUNTERS set counter = " & nLastOrder + 1 & " where id = 1"
		oUpdateCommand.CommandType = CommandType.Text
		oUpdateCommand.CommandText = cSQLnumberUpdate
		oUpdateCommand.ExecuteNonQuery()



		Dim oOrder As DataRow = Me.dataset.Tables("acc_ORDERS").Rows(0)
		Me.order_id = Me.general_id
		Me.order_no = oOrder("ordernumber")



		Return False
		Exit Function

ErrorHandler:
		error_no = Err.Number
		error_desc = Err.Description
		error_source = Err.Source
		Return True

	End Function






	Public Property order_id() As Int32
		Get
			Return m_order_id
		End Get

		Set(ByVal Value As Int32)
			m_order_id = Value
		End Set
	End Property

	Public Property order_no() As Int32
		Get
			Return m_order_no
		End Get

		Set(ByVal Value As Int32)
			m_order_no = Value
		End Set
	End Property


End Class
