Imports System.Data.SqlClient

Public Class cls_ion_plate_brk

    Private m_dataset As dataset
    Private m_itemnumber As String
    Private m_itemid As Integer
    Private m_itemcategory As Integer

    Shared oConnection As SqlConnection
    Shared nUpdatedId As Integer = 0
    Shared oTransaction As SqlTransaction

    Public Function update_plate(ByVal oSystem As ion_resources.cls_system) As Boolean
        On Error GoTo ErrorHandler

        '--- local definitions
        Dim bError As Boolean = False
        Dim bIntransaction As Boolean = False

        '--- Create connection
        oConnection = New SqlConnection(oSystem.connection_string)

        '--- Get Platenumber from MP
        Dim nPlateNumber As Integer = oSystem.dataset.Tables("inv_INVENTORY").Rows(0)("platetype")

        '--- resolve plate number
		Dim oTmpResolvePlate As ion_resources.cls_resolve_plate = New ion_resources.cls_resolve_plate()
        bError = oTmpResolvePlate.resolve_plate(nPlateNumber, oSystem)
        If bError Then
            update_plate = True
            Exit Function
        End If

        '--- Define DataAdapter 1 - MAIN PLATE
        Dim oDataAdapter1 As SqlDataAdapter = New SqlDataAdapter()
        oDataAdapter1.TableMappings.Add("Table", "inv_INVENTORY")
        oDataAdapter1.SelectCommand = New SqlCommand("select * from inv_INVENTORY where 0=1", oConnection)
        Dim oCB_mp As SqlCommandBuilder = New SqlCommandBuilder(oDataAdapter1)

        '--- Define DataAdapter 2 - SUB PLATE
        Dim oDataAdapter2 As SqlDataAdapter = New SqlDataAdapter()
        oDataAdapter2.TableMappings.Add("Table", oTmpResolvePlate.TableName)
        oDataAdapter2.SelectCommand = New SqlCommand("select * from " & oTmpResolvePlate.TableName & " where 0=1", oConnection)
        Dim oCB_sp As SqlCommandBuilder = New SqlCommandBuilder(oDataAdapter2)

        oConnection.Open()

        '--- Initiate transaction
        oTransaction = oConnection.BeginTransaction()
        oDataAdapter1.SelectCommand.Transaction = oTransaction
        oDataAdapter2.SelectCommand.Transaction = oTransaction
        bIntransaction = True

        '**** Update MainPlate ****************************
        Dim oDataTable1 As DataTable = oSystem.dataset.Tables("inv_INVENTORY")
        If oDataTable1.Rows.Count <> 1 Then
            Err.Raise(5002, "[cls_ion_plate_brk]", "ERROR 5002: To many or to few Records assigned to dataset [MP]: <save_plate>")
        End If

        '--- Assign returning values to local object
        Me.itemid = oDataTable1.Rows(0)("id")
        Me.itemnumber = oDataTable1.Rows(0)("itemnumber")
        Me.itemcategory = oDataTable1.Rows(0)("category_id")

        '--- Get only the changes for the Dataset
        Dim oChanges1 As DataSet = oSystem.dataset.GetChanges

        '--- Update Inventory table
        oDataAdapter1.Update(oChanges1, "inv_INVENTORY")

        '--- Clear all pending updates
        oDataTable1.AcceptChanges()

        '--- Release objects
        oDataAdapter1 = Nothing
        oDataTable1 = Nothing
        oCB_mp = Nothing
        oChanges1 = Nothing

        '**** Update SubPlate *****************************************
        Dim oDataTable2 As DataTable = oSystem.dataset.Tables(oTmpResolvePlate.TableName)
        If oDataTable2.Rows.Count <> 1 Then
            Err.Raise(5003, "[cls_ion_plate_brk]", "ERROR 5003: To many or to few Records assigned to dataset [SP]: <save_plate>")
        End If

        '--- Get only the changes for the Dataset
        Dim oChanges2 As DataSet = oSystem.dataset.GetChanges

        '--- Update Inventory table
        oDataAdapter2.Update(oChanges2, oTmpResolvePlate.TableName)

        '--- Clear all pending updates
        oDataTable2.AcceptChanges()

        '--- Commit transaction
        oTransaction.Commit()
        bIntransaction = False

        '--- Release objects
        oDataAdapter2 = Nothing
        oDataTable2 = Nothing
        oCB_sp = Nothing
        oChanges2 = Nothing
        oTmpResolvePlate = Nothing

        '--- Release connection object
        oConnection.Close()
        oConnection = Nothing

		Return False
        Exit Function

ErrorHandler:
		If bIntransaction Then
			oTransaction.Rollback()
		End If
		oSystem.error_no = Err.Number
		oSystem.error_desc = Err.Description
		oSystem.error_source = Err.Source
		Return True

    End Function



    Public Function get_plate(ByVal nItemId As Integer, ByVal oSystem As ion_resources.cls_system) As Boolean
        On Error GoTo ErrorHandler

        '--- local definitions
        Dim bError As Boolean = False
        Dim nPlateNumber As Integer = 0

        '--- get plate type
        bError = GetItemPlate(nItemId, nPlateNumber, oSystem)
        If bError Then
			Return True
            Exit Function
        End If

        '--- resolve plate number
		Dim oTmpResolvePlate As ion_resources.cls_resolve_plate = New ion_resources.cls_resolve_plate()
        bError = oTmpResolvePlate.resolve_plate(nPlateNumber, oSystem)
        If bError Then
			Return True
            Exit Function
        End If

        '--- Create connection
        oConnection = New SqlConnection(oSystem.connection_string)

        Dim oDataAdapter1 As SqlDataAdapter = New SqlDataAdapter()
        oDataAdapter1.TableMappings.Add("Table", "inv_INVENTORY")

        Dim oDataAdapter2 As SqlDataAdapter = New SqlDataAdapter()
        oDataAdapter2.TableMappings.Add("Table", oTmpResolvePlate.TableName)

        oConnection.Open()

        Dim oSQLcmd1 As SqlCommand = New SqlCommand("select * from inv_INVENTORY where id=" & nItemId, oConnection)
        oSQLcmd1.CommandType = CommandType.Text
        oDataAdapter1.SelectCommand = oSQLcmd1

        Dim oSQLcmd2 As SqlCommand = New SqlCommand("select * from " & oTmpResolvePlate.TableName & " where id=" & nItemId, oConnection)
        oSQLcmd2.CommandType = CommandType.Text
        oDataAdapter2.SelectCommand = oSQLcmd2

        Dim oDS As Object = oTmpResolvePlate.PlateObject
        oDataAdapter1.Fill(oDS)
        ''turn off to avoid error
        '' oDataAdapter2.Fill(oDS)

        '--- Close connection
        oConnection.Close()

        '--- make platetype readonly
        Dim oTmp_mp As DataTable = oDS.Tables("inv_INVENTORY")
        oTmp_mp.Columns("plateType").ReadOnly = True
        oTmp_mp = Nothing

        '--- make ID on subplate readOnly
        Dim oTmp_sp As DataTable = oDS.Tables(oTmpResolvePlate.TableName)
        oTmp_sp.Columns("id").ReadOnly = True
        oTmp_sp = Nothing


        '--- assign dataset to return value
        Me.dataset = oDS

        '--- release objects
        oConnection = Nothing
        oTmpResolvePlate = Nothing
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


    Public Function insert_plate(ByVal oSystem As ion_resources.cls_system) As Boolean
        On Error GoTo ErrorHandler

        '--- local definitions
        Dim bError As Boolean = False
        Dim bIntransaction As Boolean = False

        '--- Create connection
        oConnection = New SqlConnection(oSystem.connection_string)

        '--- Get Platenumber from MP
        Dim nPlateNumber As Integer = oSystem.dataset.Tables("inv_INVENTORY").Rows(0)("platetype")

        '--- resolve plate number
		Dim oTmpResolvePlate As ion_resources.cls_resolve_plate = New ion_resources.cls_resolve_plate()
        bError = oTmpResolvePlate.resolve_plate(nPlateNumber, oSystem)
        If bError Then
			Return True
            Exit Function
        End If

        '--- Define DataAdapter 1 - MAIN PLATE
        Dim oDataAdapter1 As SqlDataAdapter = New SqlDataAdapter()
        oDataAdapter1.TableMappings.Add("Table", "inv_INVENTORY")
        oDataAdapter1.SelectCommand = New SqlCommand("select * from inv_INVENTORY where 0=1", oConnection)
        Dim oCB_mp As SqlCommandBuilder = New SqlCommandBuilder(oDataAdapter1)

        '--- Define DataAdapter 2 - SUB PLATE
        Dim oDataAdapter2 As SqlDataAdapter = New SqlDataAdapter()
        oDataAdapter2.TableMappings.Add("Table", oTmpResolvePlate.TableName)
        oDataAdapter2.SelectCommand = New SqlCommand("select * from " & oTmpResolvePlate.TableName & " where 0=1", oConnection)
        Dim oCB_sp As SqlCommandBuilder = New SqlCommandBuilder(oDataAdapter2)

        oConnection.Open()

        '--- Initiate transaction
        oTransaction = oConnection.BeginTransaction()
        oDataAdapter1.SelectCommand.Transaction = oTransaction
        oDataAdapter2.SelectCommand.Transaction = oTransaction

        '--- Prepare the SUPPLIERS update for transaction
        Dim cSQLnumberUpdate As String
        Dim oUpdateCommand As SqlCommand = New SqlCommand(cSQLnumberUpdate, oConnection)
        oUpdateCommand.Transaction = oTransaction

        bIntransaction = True

        '--- Get Last Itemnuber from supplier
        Dim nCounter As Integer = 0
        Dim oInventoryRow As DataRow = oSystem.dataset.Tables("inv_INVENTORY").Rows(0)
        bError = GetLastSupplierCounter(oInventoryRow("suppliernumber"), oInventoryRow("branchnumber"), nCounter, oSystem)
		If bError Then
			Err.Raise(5014, "[cls_ion_plate_brk]", "ERROR 5014: Cannot generate LastItemNumber for this supplier: <save_plate>")
		End If

		Dim oTmpformat As cls_formatitemnumber = New cls_formatitemnumber()
		oTmpformat.branchnumber = oInventoryRow("branchnumber")
		oTmpformat.suppliernumber = oInventoryRow("suppliernumber")
		oTmpformat.itemnumber = nCounter + 1
		bError = oTmpformat.FormatItemNumber()
		If bError Then
			Err.Raise(5005, "[cls_ion_plate_brk]", "ERROR 5005: Error generating ItemNumber [MP]: <save_plate>")
		End If
		Me.itemnumber = oTmpformat.newitemnumber

		'--- Format ItemNumber
		oInventoryRow("itemnumber") = oTmpformat.newitemnumber
		oInventoryRow("itemnumberint") = oTmpformat.itemnumber

		'--- Assign category id 
		Me.itemcategory = oInventoryRow("category_id")

		'**** Update MainPlate ****************************
		Dim oDataTable1 As DataTable = oSystem.dataset.Tables("inv_INVENTORY")
		If oDataTable1.Rows.Count <> 1 Then
			Err.Raise(5002, "[cls_ion_plate_brk]", "ERROR 5002: To many or to few Records assigned to dataset [MP]: <save_plate>")
		End If

		' Include an event to fill in the Autonumber value.
		AddHandler oDataAdapter1.RowUpdated, New SqlRowUpdatedEventHandler(AddressOf OnRowUpdated)
		nUpdatedId = 0

		'--- Get only the changes for the Dataset
		Dim oChanges1 As DataSet = oSystem.dataset.GetChanges

		'--- Update Inventory table
		oDataAdapter1.Update(oChanges1, "inv_INVENTORY")

		'--- Replace ID value in MP so that it will work also for SP
		oDataTable1.Columns("id").ReadOnly = False
		oDataTable1.Rows(0)("id") = nUpdatedId

		'--- Remove the event handler
		RemoveHandler oDataAdapter1.RowUpdated, New SqlRowUpdatedEventHandler(AddressOf OnRowUpdated)

		'--- Clear all pending updates
		oDataTable1.AcceptChanges()

		'--- Release objects
		oDataAdapter1 = Nothing
		oDataTable1 = Nothing
		oCB_mp = Nothing
		oChanges1 = Nothing

		'**** Update SubPlate *****************************************
		Dim oDataTable2 As DataTable = oSystem.dataset.Tables(oTmpResolvePlate.TableName)
		If oDataTable2.Rows.Count <> 1 Then
			Err.Raise(5003, "[cls_ion_plate_brk]", "ERROR 5003: To many or to few Records assigned to dataset [SP]: <save_plate>")
		End If

		'--- Assign SP the correct ID
		oDataTable2.Rows(0)("ID") = nUpdatedId
		Me.itemid = nUpdatedId

		'--- Get only the changes for the Dataset
		Dim oChanges2 As DataSet = oSystem.dataset.GetChanges

		'--- Update Inventory table
		oDataAdapter2.Update(oChanges2, oTmpResolvePlate.TableName)

		'--- Clear all pending updates
		oDataTable2.AcceptChanges()


		'--- Update Suppliers LastNumber
		cSQLnumberUpdate = "update spl_SUPPLIERS set LastItemNumber = " & nCounter + 1 & " where Branch_id = " & oTmpformat.branchnumber & " and SupplierNumber =" & oTmpformat.suppliernumber
		oUpdateCommand.CommandType = CommandType.Text
		oUpdateCommand.CommandText = cSQLnumberUpdate
		oUpdateCommand.ExecuteNonQuery()


		'--- Commit transaction
		oTransaction.Commit()
		bIntransaction = False

		'--- Release objects
		oDataAdapter2 = Nothing
		oDataTable2 = Nothing
		oCB_sp = Nothing
		oChanges2 = Nothing
		oTmpResolvePlate = Nothing

		oTmpformat = Nothing

		'--- Release connection object
		oConnection.Close()
		oConnection = Nothing

		Return False
		Exit Function

ErrorHandler:
		If bIntransaction Then
			oTransaction.Rollback()
		End If
		oSystem.error_no = Err.Number
		oSystem.error_desc = Err.Description
		oSystem.error_source = Err.Source
		Return True

    End Function

    Private Shared Sub OnRowUpdated(ByVal sender As Object, ByVal args As SqlRowUpdatedEventArgs)
        ' Include a variable and a command to retrieve the identity value from the Access database.
        Dim newID As Integer = 0
        Dim idCMD As SqlCommand = New SqlCommand("SELECT @@IDENTITY", oConnection)

        If args.StatementType = StatementType.Insert Then
            ' Retrieve the identity value and store it in the CategoryID column.
            'args.Row("ID") = nUpdatedId
            idCMD.Transaction = oTransaction
            nUpdatedId = CInt(idCMD.ExecuteScalar())
        End If
    End Sub

    Private Function GetItemPlate(ByVal nItemId As Integer, ByRef nPlateNumber As Integer, ByVal oSystem As ion_resources.cls_system) As Boolean
        On Error GoTo ErrorHandler

        '--- Define Connection String
        Dim bConnection_open As Boolean = False
        Dim bDatareader_open As Boolean = False
        Dim objConn As New SqlConnection(oSystem.connection_string)
        Dim cSQLstring As SqlCommand = New SqlCommand("select platetype from inv_INVENTORY where id=" & nItemId, objConn)
        objConn.Open()
        bConnection_open = True

        Dim dr_Reader As SqlDataReader = cSQLstring.ExecuteReader()
        dr_Reader.Read()
        bDatareader_open = True

        nPlateNumber = dr_Reader.Item("platetype")
        objConn.Close()
        dr_Reader.Close()

        '--- Everything id OK *
        Return False
        Exit Function

        '---- Handle ERROR *
ErrorHandler:
        If bConnection_open Then
            bConnection_open = False
            objConn.Close()
        End If
        If bDatareader_open Then
            bDatareader_open = False
            dr_Reader.Close()
        End If
        '--- If No rows found for this query
        If dr_Reader.RecordsAffected < 0 Then
            Err.Number = 5004
            Err.Source = "[cls_ion_plate_brk]"
            Err.Description = "ERROR 5004: ItemId does not exist: <GetItemPlate>"
        End If
        oSystem.error_no = Err.Number
        oSystem.error_desc = Err.Description
        oSystem.error_source = Err.Source
        Return True

    End Function


    Function GetLastSupplierCounter(ByVal nSupplierNo As Integer, ByVal nBranchNo As Integer, ByRef nCounter As Integer, ByVal oSystem As ion_resources.cls_system) As Boolean
        On Error GoTo ErrorHandler

        '--- Define local vars
        Dim bError As Boolean = False

        '--- Define Connection String
        Dim objConn As New SqlClient.SqlConnection(oSystem.connection_string)
        Dim cSQLstring As SqlClient.SqlCommand = New SqlClient.SqlCommand("select SupplierNumber, LastItemNumber from spl_SUPPLIERS where Branch_id= " & nBranchNo & " and SupplierNumber= " & nSupplierNo, objConn)
        objConn.Open()

        Dim dr_Reader As SqlClient.SqlDataReader = cSQLstring.ExecuteReader()

        dr_Reader.Read()
        nCounter = dr_Reader.Item("LastItemNumber")

        objConn.Close()
        dr_Reader.Close()

        Return False
        Exit Function

ErrorHandler:
        oSystem.error_no = Err.Number
        oSystem.error_desc = Err.Description
        oSystem.error_source = Err.Source
        Return True

    End Function


    Public Property dataset() As dataset
        Get
            Return m_dataset
        End Get

        Set(ByVal Value As dataset)
            m_dataset = Value
        End Set
    End Property


    Public Property itemnumber() As String
        Get
            Return m_itemnumber
        End Get

        Set(ByVal Value As String)
            m_itemnumber = Value
        End Set
    End Property

    Public Property itemid() As Integer
        Get
            Return m_itemid
        End Get

        Set(ByVal Value As Integer)
            m_itemid = Value
        End Set
    End Property

    Public Property itemcategory() As Integer
        Get
            Return m_itemcategory
        End Get

        Set(ByVal Value As Integer)
            m_itemcategory = Value
        End Set
    End Property

End Class
