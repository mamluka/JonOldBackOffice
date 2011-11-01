Public Class cls_next_back_item
    Inherits iFoundation.cls_error_connection
    Public conn_string
    Function load_items(ByVal id As Int32, ByRef nextid As Int32, ByRef previd As Int32, ByVal cat As Int32, ByVal sub_cat As Int32) As Boolean
        Dim oDG_search As New iDac.cls_sql_read
        Dim sSql As String = "select * from inv_inventory where (category_id=" + Convert.ToString(cat) + ") and (subcategory_id=" + Convert.ToString(sub_cat) + ") and (shopstatus = 0) and (id - " + Convert.ToString(id) + " > 0)"
        Dim sSql2 As String = "select * from inv_inventory where (category_id=" + Convert.ToString(cat) + ") and (subcategory_id=" + Convert.ToString(sub_cat) + ") and (shopstatus = 0) and (id - " + Convert.ToString(id) + " < 0)"




        oDG_search._connection_string = Me.conn_string
        oDG_search._tablename = "inv_inventory"


        oDG_search.transact_read(sSql) ''read next id

        Dim oData As DataTable = oDG_search._datatable

        nextid = oData.Rows(0).Item("id")




        oDG_search.transact_read(sSql2) '' make the second read 

        oData = oDG_search._datatable

        previd = oData.Rows(oData.Rows.Count - 1).Item("id")



    End Function

End Class
