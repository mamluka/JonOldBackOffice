Imports System.Data.SqlClient

Public Class cls_checkbook_brk
    Private m_payment_id As Int32
    Private m_checkbook As Int16

    '################################################################################
    Function insert_payment(ByVal oSystem As ion_resources.cls_system) As Boolean
        'On Error GoTo ErrorHandler

        '--- local definitions
        Dim bError As Boolean = False

        Dim oTransact As New ion_resources.cls_trs_insert_checkbook()
        oTransact.dataset = oSystem.dataset
        oTransact.connection_string = oSystem.connection_string
        oTransact.mode_insert = True
        oTransact.cary_id = False
        oTransact.cary_id_multiple = False


        '-------------- Add tables to Collection
        '--- ### Table 1
        Dim oTable1 As New ion_resources.cls_trs_tables()
        If Me.checkbook = 1 Then
            oTable1.oTable = oTransact.dataset.Tables("acc_CHECKBOOK_USD")
            oTable1.TableName = "acc_CHECKBOOK_USD"

        ElseIf Me.checkbook = 2 Then
            oTable1.oTable = oTransact.dataset.Tables("acc_CHECKBOOK_ILS")
            oTable1.TableName = "acc_CHECKBOOK_ILS"

        End If

        oTransact.tables.Add(oTable1)
        oTable1 = Nothing


        bError = oTransact.transact

        '--- Return parameters
        Me.payment_id = oTransact.general_id


        Return False
        Exit Function

ErrorHandler:
        oSystem.error_no = Err.Number
        oSystem.error_desc = Err.Description
        oSystem.error_source = Err.Source
        Return True

    End Function


    '################################################################################
    Function update_payment(ByVal oSystem As ion_resources.cls_system) As Boolean
        'On Error GoTo ErrorHandler

        '--- local definitions
        Dim bError As Boolean = False

        Dim oTransact As New ion_resources.cls_trs_update_checkbook()
        oTransact.dataset = oSystem.dataset
        oTransact.connection_string = oSystem.connection_string
        oTransact.mode_insert = False
        oTransact.cary_id = False
        oTransact.cary_id_multiple = False
        oTransact.general_id = Me.payment_id


        '-------------- Add tables to Collection
        '--- ### Table 1
        Dim oTable1 As New ion_resources.cls_trs_tables()
        If Me.checkbook = 1 Then
            oTable1.oTable = oTransact.dataset.Tables("acc_CHECKBOOK_USD")
            oTable1.TableName = "acc_CHECKBOOK_USD"

        ElseIf Me.checkbook = 2 Then
            oTable1.oTable = oTransact.dataset.Tables("acc_CHECKBOOK_ILS")
            oTable1.TableName = "acc_CHECKBOOK_ILS"

        End If
        oTransact.tables.Add(oTable1)
        oTable1 = Nothing


        bError = oTransact.transact


        Return False
        Exit Function

ErrorHandler:
        oSystem.error_no = Err.Number
        oSystem.error_desc = Err.Description
        oSystem.error_source = Err.Source
        Return True

    End Function


    '################################################################################
    Function get_payment(ByVal nPaymentId As Int32, ByVal oSystem As ion_resources.cls_system) As Boolean
        On Error GoTo ErrorHandler

        '--- local definitions
        Dim bError As Boolean = False

        '--- Create connection
        Dim oConnection As SqlConnection
        oConnection = New SqlConnection(oSystem.connection_string)

        Dim oDataAdapter1 As SqlDataAdapter = New SqlDataAdapter()
        Dim oSQLcmd1 As SqlCommand
        If Me.checkbook = 1 Then
            oDataAdapter1.TableMappings.Add("Table", "acc_CHECKBOOK_USD")
            oSQLcmd1 = New SqlCommand("select * from acc_CHECKBOOK_USD where id=" & nPaymentId, oConnection)

        ElseIf Me.checkbook = 2 Then
            oDataAdapter1.TableMappings.Add("Table", "acc_CHECKBOOK_ILS")
            oSQLcmd1 = New SqlCommand("select * from acc_CHECKBOOK_ILS where id=" & nPaymentId, oConnection)

        End If

        oConnection.Open()

        oSQLcmd1.CommandType = CommandType.Text
        oDataAdapter1.SelectCommand = oSQLcmd1


        Dim oDS As DataSet = New DataSet("ds_CHECKBOOK")
        oDataAdapter1.Fill(oDS)


        '--- Close connection
        oConnection.Close()

        '--- assign dataset to return value
        oSystem.dataset = oDS

        '--- release objects
        oConnection = Nothing
        oDataAdapter1 = Nothing

        oSQLcmd1 = Nothing

        Return False
        Exit Function

ErrorHandler:
        oSystem.error_no = Err.Number
        oSystem.error_desc = Err.Description
        oSystem.error_source = Err.Source
        Return True

    End Function





    Public Property payment_id() As Int32
        Get
            Return m_payment_id
        End Get

        Set(ByVal Value As Int32)
            m_payment_id = Value
        End Set
    End Property

    Public Property checkbook() As Int16
        Get
            Return m_checkbook
        End Get

        Set(ByVal Value As Int16)
            m_checkbook = Value
        End Set
    End Property

End Class
