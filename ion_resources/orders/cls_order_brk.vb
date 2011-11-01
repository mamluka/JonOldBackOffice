Imports System.Data.SqlClient

Public Class cls_order_brk
	Private m_order_id As Int32
	Private m_order_no As Int32

	Function insert_order(ByVal oSystem As ion_resources.cls_system) As Boolean
		On Error GoTo ErrorHandler

		'--- local definitions
		Dim bError As Boolean = False

		Dim oTransact As New ion_resources.cls_trs_insert_order
		oTransact.dataset = oSystem.dataset
		oTransact.connection_string = oSystem.connection_string
		oTransact.mode_insert = True
		oTransact.cary_id = False
		oTransact.cary_id_multiple = True


		'-------------- Add tables to Collection
		'--- ### Table 1
		Dim oTable1 As New ion_resources.cls_trs_tables
		oTable1.oTable = oTransact.dataset.Tables("acc_ORDERS")
		oTable1.TableName = "acc_ORDERS"
		oTransact.tables.Add(oTable1)
		oTable1 = Nothing

		'--- ### Table 2
		Dim oTable2 As New ion_resources.cls_trs_tables
		oTable2.oTable = oTransact.dataset.Tables("acc_ORDER_ITEMS")
		oTable2.TableName = "acc_ORDER_ITEMS"
		oTransact.tables.Add(oTable2)
		oTable2 = Nothing


		bError = oTransact.transact

		'--- Return parameters
		Me.order_id = oTransact.order_id
		Me.order_no = oTransact.order_no


		Return False
		Exit Function

ErrorHandler:
		oSystem.error_no = Err.Number
		oSystem.error_desc = Err.Description
		oSystem.error_source = Err.Source
		Return True

	End Function


	Function get_order(ByVal nOrderId As Int32, ByVal oSystem As ion_resources.cls_system) As Boolean
		On Error GoTo ErrorHandler

		'--- local definitions
		Dim bError As Boolean = False

		'--- Create connection
		Dim oConnection As SqlConnection
		oConnection = New SqlConnection(oSystem.connection_string)

		Dim oDataAdapter1 As SqlDataAdapter = New SqlDataAdapter
		oDataAdapter1.TableMappings.Add("Table", "acc_ORDERS")

		Dim oDataAdapter2 As SqlDataAdapter = New SqlDataAdapter
        oDataAdapter2.TableMappings.Add("Table", "acc_DIAMOND_ORDER_ITEMS")

        Dim oDataAdapter3 As SqlDataAdapter = New SqlDataAdapter
        oDataAdapter3.TableMappings.Add("Table", "acc_CUSTOMJEWEL_ORDER_ITEMS")

        Dim oDataAdapter4 As SqlDataAdapter = New SqlDataAdapter
        oDataAdapter4.TableMappings.Add("Table", "acc_JEWELRY_ORDER_ITEMS")

		oConnection.Open()

		Dim oSQLcmd1 As SqlCommand = New SqlCommand("select * from acc_ORDERS where id=" & nOrderId, oConnection)
		oSQLcmd1.CommandType = CommandType.Text
		oDataAdapter1.SelectCommand = oSQLcmd1

        Dim oSQLcmd2 As SqlCommand = New SqlCommand("select item_id,totalprice,  'Diamond id is: ' + CONVERT(nvarchar,diamondid) + '<br> inventory code: ' + inventory_code +  ' <br>'+ CONVERT(varchar,[weight])+' '+shape+' '+color+'/'+clarity as description from acc_DIAMOND_ORDER_ITEMS  as item inner join v_jd_diamonds on item.item_id = v_jd_diamonds.diamondid where order_id = " & nOrderId, oConnection)
		oSQLcmd2.CommandType = CommandType.Text
        oDataAdapter2.SelectCommand = oSQLcmd2

        Dim oSQLcmd3 As SqlCommand = New SqlCommand("select size,metal,sell_price+totalprice as price,jewel_title + '<br>'+ 'Diamond id is: ' + CONVERT(nvarchar,diamondid) + '<br> inventory code: ' + inventory_code +  ' <br>'+ CONVERT(varchar,v_jd_diamonds.weight)+' '+shape+' '+color+'/'+clarity as [description] from  dbo.acc_CUSTOMJEWEL_ORDER_ITEMS as item inner join v_jd_diamonds on item.diamond_id = v_jd_diamonds.diamondid inner join inv_inventory on inv_inventory.id = item.setting_id inner join inv_jewelry on inv_jewelry.inventory_id = item.setting_id where order_id = " & nOrderId, oConnection)
        oSQLcmd3.CommandType = CommandType.Text
        oDataAdapter3.SelectCommand = oSQLcmd3

        Dim oSQLcmd4 As SqlCommand = New SqlCommand("select item_id,jewelsize,metal,onspecial,special_sell_price,sell_price,jewel_title from dbo.acc_JEWELRY_ORDER_ITEMS as item inner join inv_inventory on inv_inventory.id = item.item_id inner join inv_jewelry on inv_jewelry.inventory_id = item.item_id where order_id =" & nOrderId, oConnection)
        oSQLcmd4.CommandType = CommandType.Text
        oDataAdapter4.SelectCommand = oSQLcmd4

		Dim oDS As DataSet = New DataSet("ds_ORDERS")
		oDataAdapter1.Fill(oDS)
        oDataAdapter2.Fill(oDS)
        oDataAdapter3.Fill(oDS)
        oDataAdapter4.Fill(oDS)

		'--- Close connection
		oConnection.Close()


		'--- assign dataset to return value
		oSystem.dataset = oDS

		'--- release objects
		oConnection = Nothing
		oDataAdapter1 = Nothing
		oDataAdapter2 = Nothing
		oSQLcmd1 = Nothing
		oSQLcmd2 = Nothing

		Return False
		Exit Function

ErrorHandler:
		oSystem.error_no = Err.Number
		oSystem.error_desc = Err.Description
		oSystem.error_source = Err.Source
		Return True

	End Function

	Function update_order(ByVal oSystem As ion_resources.cls_system) As Boolean
		On Error GoTo ErrorHandler

		'--- local definitions
		Dim bError As Boolean = False

		Dim oTransact As New ion_resources.cls_trs_update_order
		oTransact.dataset = oSystem.dataset
		oTransact.connection_string = oSystem.connection_string
		oTransact.mode_insert = False
		oTransact.cary_id = False
		oTransact.cary_id_multiple = False
		oTransact.general_id = Me.order_id


		'-------------- Add tables to Collection
		'--- ### Table 1
		Dim oTable1 As New ion_resources.cls_trs_tables
		oTable1.oTable = oTransact.dataset.Tables("acc_ORDERS")
		oTable1.TableName = "acc_ORDERS"
		oTransact.tables.Add(oTable1)
		oTable1 = Nothing

		'--- ### Table 2
		Dim oTable2 As New ion_resources.cls_trs_tables
		oTable2.oTable = oTransact.dataset.Tables("acc_ORDER_ITEMS")
		oTable2.TableName = "acc_ORDER_ITEMS"
		oTransact.tables.Add(oTable2)
		oTable2 = Nothing

		bError = oTransact.transact


		Return False
		Exit Function

ErrorHandler:
		oSystem.error_no = Err.Number
		oSystem.error_desc = Err.Description
		oSystem.error_source = Err.Source
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
