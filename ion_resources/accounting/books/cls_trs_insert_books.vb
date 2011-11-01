Imports System.Data.SqlClient

Public Class cls_trs_insert_books
    Inherits ion_resources.cls_transactor

    Private m_trs_id As Int32


    Shared nLastTransaction As Int32 = 0
    Shared cSQLnumberUpdate As String
    Shared oUpdateCommand_1 As New SqlCommand()
    Shared oUpdateCommand_2 As New SqlCommand()
    Shared oUpdateCommand_3 As New SqlCommand()

    '###################################################################################
    Overrides Function init_transaction(ByRef error_no As Int32, ByRef error_desc As String, ByRef error_source As String) As Boolean
        On Error GoTo ErrorHandler
        Dim bError As Boolean = False

        '--- Update COUNTER LastNumber
        oUpdateCommand_1 = New SqlCommand(cSQLnumberUpdate, Me.oConnection)
        oUpdateCommand_1.Transaction = Me.oTransaction

        '--- Update INVENTORY items
        oUpdateCommand_2 = New SqlCommand(cSQLnumberUpdate, Me.oConnection)
        oUpdateCommand_2.Transaction = Me.oTransaction

        '--- Update ORDER
        oUpdateCommand_3 = New SqlCommand(cSQLnumberUpdate, Me.oConnection)
        oUpdateCommand_3.Transaction = Me.oTransaction

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
        Dim oTmpObject As New cls_functions_book()
        oTmpObject.connection_string = Me.connection_string
        bError = oTmpObject.get_LastTransactionNo(nLastTransaction)


        Dim nLoop_1 As Int16
        For nLoop_1 = 0 To Me.dataset.Tables("acc_GENERAL_BOOKS").Rows.Count - 1
            Me.dataset.Tables("acc_GENERAL_BOOKS").Rows(nLoop_1).Item("trs_id") = nLastTransaction
        Next

        Dim nLoop_2 As Int16
        For nLoop_2 = 0 To Me.dataset.Tables("acc_SUPPLIERS_BOOKS").Rows.Count - 1
            Me.dataset.Tables("acc_SUPPLIERS_BOOKS").Rows(nLoop_2).Item("trs_id") = nLastTransaction
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


        '--- Get Order Id
        Dim nOrderId As Int32 = Me.dataset.Tables("acc_SUPPLIERS_BOOKS").Rows(0).Item("order_id")

        '--- update all inventory QTY
        Dim nLoop As Int16
        Dim nItemId As Int32
        For nLoop = 0 To Me.dataset.Tables("acc_SUPPLIERS_BOOKS").Rows.Count - 1
            nItemId = Me.dataset.Tables("acc_SUPPLIERS_BOOKS").Rows(nLoop).Item("item_id")

            '--- Get Quantity
            Dim nQty_cur As Int16
            Dim nQty_min As Int16
            Dim nQty_new As Int16
            Dim oTmpfunction_inv As New ion_resources.cls_functions_inventory()
            oTmpfunction_inv.connection_string = Me.connection_string
            bError = oTmpfunction_inv.get_item_qty(nItemId, nQty_cur, nQty_min)
            nQty_new = nQty_cur - Convert.ToInt16(Me.dataset.Tables("acc_SUPPLIERS_BOOKS").Rows(nLoop).Item("item_qty"))

            '--- Update
            cSQLnumberUpdate = "update inv_INVENTORY set item_sold = 1, qtyonstock_cur = " + Convert.ToString(nQty_new) + " where id = " + Convert.ToString(nItemId)
            oUpdateCommand_2.CommandType = CommandType.Text
            oUpdateCommand_2.CommandText = cSQLnumberUpdate
            oUpdateCommand_2.ExecuteNonQuery()

            oTmpfunction_inv = Nothing
        Next


        '--- update ORDER - order_transact
        cSQLnumberUpdate = "update acc_ORDERS set order_transacted = 1 where id = " & nOrderId
        oUpdateCommand_3.CommandType = CommandType.Text
        oUpdateCommand_3.CommandText = cSQLnumberUpdate
        oUpdateCommand_3.ExecuteNonQuery()



        '--- update the transaction counter
        cSQLnumberUpdate = "update sys_COUNTERS set counter = " & nLastTransaction + 1 & " where id = 2"
        oUpdateCommand_1.CommandType = CommandType.Text
        oUpdateCommand_1.CommandText = cSQLnumberUpdate
        oUpdateCommand_1.ExecuteNonQuery()



        Return False
        Exit Function

ErrorHandler:
        error_no = Err.Number
        error_desc = Err.Description
        error_source = Err.Source
        Return True

    End Function


    Public Property trs_id() As Int32
        Get
            Return m_trs_id
        End Get

        Set(ByVal Value As Int32)
            m_trs_id = Value
        End Set
    End Property

End Class
