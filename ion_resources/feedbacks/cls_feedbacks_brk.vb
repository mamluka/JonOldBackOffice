Imports System.Data.SqlClient

Public Class cls_feedbacks_brk
    Private m_id As Int32

    '################################################################################
    Function insert(ByVal oSystem As ion_resources.cls_system) As Boolean
        'On Error GoTo ErrorHandler

        '--- local definitions
        Dim bError As Boolean = False

        Dim oTransact As New ion_resources.cls_trs_insert_feedbacks()
        oTransact.dataset = oSystem.dataset
        oTransact.connection_string = oSystem.connection_string
        oTransact.mode_insert = True
        oTransact.cary_id = False
        oTransact.cary_id_multiple = False


        '-------------- Add tables to Collection
        '--- ### Table 1
        Dim oTable1 As New ion_resources.cls_trs_tables()
        oTable1.oTable = oTransact.dataset.Tables("usr_FEEDBACKS")
        oTable1.TableName = "usr_FEEDBACKS"

        oTransact.tables.Add(oTable1)
        oTable1 = Nothing


        bError = oTransact.transact

        '--- Return parameters
        Me.id = oTransact.general_id


        Return False
        Exit Function

ErrorHandler:
        oSystem.error_no = Err.Number
        oSystem.error_desc = Err.Description
        oSystem.error_source = Err.Source
        Return True

    End Function


    '################################################################################
    Function update(ByVal oSystem As ion_resources.cls_system) As Boolean
        'On Error GoTo ErrorHandler

        '--- local definitions
        Dim bError As Boolean = False

        Dim oTransact As New ion_resources.cls_trs_update_feedbacks()
        oTransact.dataset = oSystem.dataset
        oTransact.connection_string = oSystem.connection_string
        oTransact.mode_insert = False
        oTransact.cary_id = False
        oTransact.cary_id_multiple = False
        oTransact.general_id = Me.id


        '-------------- Add tables to Collection
        '--- ### Table 1
        Dim oTable1 As New ion_resources.cls_trs_tables()
        oTable1.oTable = oTransact.dataset.Tables("usr_FEEDBACKS")
        oTable1.TableName = "usr_FEEDBACKS"

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
    Function getrec(ByVal nId As Int32, ByVal oSystem As ion_resources.cls_system) As Boolean
        On Error GoTo ErrorHandler

        '--- local definitions
        Dim bError As Boolean = False

        '--- Create connection
        Dim oConnection As SqlConnection
        oConnection = New SqlConnection(oSystem.connection_string)

        Dim oDataAdapter1 As SqlDataAdapter = New SqlDataAdapter()
        Dim oSQLcmd1 As SqlCommand
        oDataAdapter1.TableMappings.Add("Table", "usr_FEEDBACKS")
        oSQLcmd1 = New SqlCommand("select * from usr_FEEDBACKS where id=" & nId, oConnection)

        oConnection.Open()

        oSQLcmd1.CommandType = CommandType.Text
        oDataAdapter1.SelectCommand = oSQLcmd1


        Dim oDS As DataSet = New DataSet("usr_FEEDBACKS")
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





    Public Property id() As Int32
        Get
            Return m_id
        End Get

        Set(ByVal Value As Int32)
            m_id = Value
        End Set
    End Property


End Class
