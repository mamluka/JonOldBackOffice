Imports System.Data.SqlClient

Public Class cls_slogging_brk
    Inherits ion_resources.cls_base_brk

    Private m_tablename As String

    '--- This broker works only for one table transaction


    '####################################################################3
    Function insert() As Boolean
        'On Error GoTo ErrorHandler

        '--- local definitions
        Dim bError As Boolean = False

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

    Public Property tablename() As String
        Get
            Return m_tablename
        End Get

        Set(ByVal Value As String)
            m_tablename = Value
        End Set
    End Property


End Class
