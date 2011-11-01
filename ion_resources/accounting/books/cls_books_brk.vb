Imports System.Data.SqlClient

Public Class cls_books_brk

    Function insert_books(ByVal oSystem As ion_resources.cls_system) As Boolean
        'On Error GoTo ErrorHandler

        '--- local definitions
        Dim bError As Boolean = False

        Dim oTransact As New ion_resources.cls_trs_insert_books()
        oTransact.dataset = oSystem.dataset
        oTransact.connection_string = oSystem.connection_string
        oTransact.mode_insert = True
        oTransact.cary_id = False
        oTransact.cary_id_multiple = False


        '-------------- Add tables to Collection
        '--- ### Table 1
        Dim oTable1 As New ion_resources.cls_trs_tables()
        oTable1.oTable = oTransact.dataset.Tables("acc_GENERAL_BOOKS")
        oTable1.TableName = "acc_GENERAL_BOOKS"
        oTransact.tables.Add(oTable1)
        oTable1 = Nothing

        '--- ### Table 2
        Dim oTable2 As New ion_resources.cls_trs_tables()
        oTable2.oTable = oTransact.dataset.Tables("acc_SUPPLIERS_BOOKS")
        oTable2.TableName = "acc_SUPPLIERS_BOOKS"
        oTransact.tables.Add(oTable2)
        oTable2 = Nothing



        bError = oTransact.transact
        If bError Then
            oSystem.error_no = oTransact.error_no
            oSystem.error_desc = oTransact.error_desc
            oSystem.error_source = oTransact.error_source
            Return True
        End If



        '--- Return parameters
        'Me.payment_id = oTransact.payment_id



        Return False
        Exit Function

ErrorHandler:
        oSystem.error_no = Err.Number
        oSystem.error_desc = Err.Description
        oSystem.error_source = Err.Source
        Return True

    End Function


End Class
