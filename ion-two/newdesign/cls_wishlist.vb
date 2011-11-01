Public Class cls_wishlist
    Inherits iFoundation.cls_logics_sub




    Public Function AddToWishList(ByVal userid As Int32, ByVal item_id As Int32, ByVal description As String)
        On Error GoTo ErrorHandler
        Dim berror As Boolean = False

        

        Dim oTmpDataset As DataSet = New ion_two.usr_wishlist

        Dim oTmpDataTable As DataTable = oTmpDataset.Tables("usr_wishlist")

        '--- Assign Order
        Dim oTmpDataRow As DataRow
        oTmpDataRow = oTmpDataTable.NewRow

        oTmpDataRow("itemid") = item_id
        oTmpDataRow("userid") = userid
        oTmpDataRow("description") = description

        oTmpDataTable.Rows.Add(oTmpDataRow)

        '### Start transaction
        Dim oTransaction As New iDac.cls_T_transaction
        oTransaction._connection_string = Me._connection_string
        oTransaction._dbtype = Me._dbtype
        berror = oTransaction.start()
        If berror Then
            Me._err_number = oTransaction._err_number
            Me._err_description = oTransaction._err_description
            Me._err_source = oTransaction._err_source
            Return True
        End If


        Dim oTransactor_2 As New iDac.cls_T_transactor
        oTransactor_2._connection_string = Me._connection_string
        oTransactor_2._dbtype = Me._dbtype



        Dim oTable2 As New iDac.cls_cll_datatables
        oTable2._datatable = oTmpDataTable
        oTransactor_2._i_cll_datatables.Add(oTable2)

        '--- Assign the transaction to the transactor
        oTransactor_2._transaction = oTransaction._transaction

        '--- Write Table
        berror = oTransactor_2.transact_insert()
        If berror Then
            Me._err_number = oTransaction._err_number
            Me._err_description = oTransaction._err_description
            Me._err_source = oTransaction._err_source
            Return True
        End If


        berror = oTransaction.close()


        '### End transaction

        oTransactor_2 = Nothing
        oTransaction = Nothing
        Return True
        Exit Function

ErrorHandler:
        Me._err_number = Err.Number
        Me._err_description = Err.Description
        Me._err_source = Err.Source
        Return False

    End Function

    Function ReadWishList(ByVal userid As Int32, ByRef wishlist_coll As ArrayList) As Boolean

        Dim viewer_sql As New iDac.cls_sql_read
        viewer_sql._connection_string = Me._connection_string
        viewer_sql._tablename = "vv_jewelry_full"

        Dim ssql = "select * from usr_wishlist where userid=" + userid.ToString

        viewer_sql.transact_read(ssql)

        Dim oData As DataTable = viewer_sql._datatable

        If oData.Rows.Count > 0 Then

            For Each row As DataRow In oData.Rows

                Dim hash As New Hashtable
                hash("desc") = row("description")
                hash("itemid") = row("itemid")
                hash("id") = row("id")
                wishlist_coll.Add(hash)

            Next

        End If

    End Function

    Function RemoveFromWishList(ByVal id As Int32)
        Dim osqldelete As New iDac.cls_T_delete
        osqldelete._connection_string = Me._connection_string
        osqldelete._dbtype = Me._dbtype
        osqldelete._tablename = "usr_wishlist"
        osqldelete.transact_delete(id)


    End Function

    Function CheckByItemAndUserId(ByVal userid As Int32, ByVal itemid As Int32) As Boolean

        Dim viewer_sql As New iDac.cls_sql_read
        viewer_sql._connection_string = Me._connection_string
        viewer_sql._tablename = "vv_jewelry_full"

        Dim ssql = "select * from usr_wishlist where userid=" + userid.ToString + " and itemid = " + itemid.ToString

        viewer_sql.transact_read(ssql)

        Dim oData As DataTable = viewer_sql._datatable

        If oData.Rows.Count > 0 Then
            Return True
        Else
            Return False
        End If

    End Function

End Class
