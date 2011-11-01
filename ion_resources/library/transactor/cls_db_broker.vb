Imports System.Data.SqlClient

Public Class cls_db_broker
    Inherits ion_resources.cls_base_brk

    Private m_tablename As String

    '--- This broker works only for one table transaction


    '####################################################################3
    Function insert() As Boolean
        'On Error GoTo ErrorHandler

        '--- local definitions
        Dim bError As Boolean = False

        '--- Set TableName
        Me.tablename = Me.dataset.Tables(0).TableName

        '---
        Dim oTransact As New ion_resources.cls_base_transactor()
        oTransact.dataset = Me.dataset
        oTransact.connection_string = Me.connection_string
        oTransact.mode_insert = True
        oTransact.cary_id = False
        oTransact.cary_id_multiple = False


        '-------------- Add tables to Collection
        Dim oTable1 As New ion_resources.cls_trs_tables()
        oTable1.oTable = oTransact.dataset.Tables(Me.tablename)
        oTable1.TableName = Me.tablename
        oTransact.tables.Add(oTable1)
        oTable1 = Nothing

        bError = oTransact.transact

        '--- Return parameters
        Me.id = oTransact.general_id

        Return False
        Exit Function

ErrorHandler:
        Me.error_no = Err.Number
        Me.error_desc = Err.Description
        Me.error_source = Err.Source
        Return True

    End Function


    '####################################################################3
    Function getrec(ByVal nId As Int32) As Boolean
        On Error GoTo ErrorHandler

        '--- local definitions
        Dim bError As Boolean = False

        '--- Set TableName
        Me.tablename = Me.dataset.Tables(0).TableName

        '--- Create connection
        Dim oConnection As SqlConnection
        oConnection = New SqlConnection(Me.connection_string)

        Dim oDataAdapter1 As SqlDataAdapter = New SqlDataAdapter()
        oDataAdapter1.TableMappings.Add("Table", Me.tablename)

        oConnection.Open()

        Dim oSQLcmd1 As SqlCommand = New SqlCommand("select * from " + Me.tablename + " where id=" & nId, oConnection)
        oSQLcmd1.CommandType = CommandType.Text
        oDataAdapter1.SelectCommand = oSQLcmd1


        Dim oDS As DataSet = New DataSet(Me.tablename)
        oDataAdapter1.Fill(oDS)


        '--- Close connection
        oConnection.Close()

        '--- assign dataset to return value
        Me.dataset = oDS

        '--- release objects
        oConnection = Nothing
        oDataAdapter1 = Nothing

        oSQLcmd1 = Nothing

        Return False
        Exit Function

ErrorHandler:
        Me.error_no = Err.Number
        Me.error_desc = Err.Description
        Me.error_source = Err.Source
        Return True

    End Function


    '#####################################################################################
    Function update() As Boolean
        'On Error GoTo ErrorHandler

        '--- local definitions
        Dim bError As Boolean = False

        '--- Set TableName
        Me.tablename = Me.dataset.Tables(0).TableName

        Dim oTransact As New ion_resources.cls_base_transactor()
        oTransact.dataset = Me.dataset
        oTransact.connection_string = Me.connection_string
        oTransact.mode_insert = False
        oTransact.cary_id = False
        oTransact.cary_id_multiple = False
        oTransact.general_id = Me.id


        '-------------- Add tables to Collection
        '--- ### Table 1
        Dim oTable1 As New ion_resources.cls_trs_tables()
        oTable1.oTable = oTransact.dataset.Tables(Me.tablename)
        oTable1.TableName = Me.tablename
        oTransact.tables.Add(oTable1)
        oTable1 = Nothing

        bError = oTransact.transact

        Return False
        Exit Function

ErrorHandler:
        Me.error_no = Err.Number
        Me.error_desc = Err.Description
        Me.error_source = Err.Source
        Return True

    End Function


    Public Property tablename() As String
        Get
            Return m_tablename
        End Get

        Set(ByVal Value As String)
            m_tablename = Value
        End Set
    End Property


End Class
