Imports System.Web.UI.WebControls
Public Class cls_groups
    Public conn_string As String
    Public db_type As String
    Public Function LoadGroupList(ByRef items As ListItemCollection) As Boolean
        Dim osql As New iDac.cls_sql_read

        Dim sSql As String = "select * from sys_groups"

        osql._connection_string = Me.conn_string
        osql._tablename = "sys_groups"



        osql.transact_read(sSql)

        Dim oData As DataTable = osql._datatable

        For Each orow As DataRow In oData.Rows


            Dim oitem As New ListItem
            oitem.Text = orow("group_name")
            oitem.Value = orow("group_key")
            items.Add(oitem)

        Next

    End Function
    Public Function LoadItemsByGroupKey(ByVal key As String, ByRef items As ListItemCollection) As Boolean
        Dim osql As New iDac.cls_sql_read

        Dim sSql As String = "select * from sys_groups where group_key='" + key + "'"

        osql._connection_string = Me.conn_string
        osql._tablename = "sys_groups"



        osql.transact_read(sSql)

        Dim oData As DataTable = osql._datatable

        If oData.Rows.Count > 0 Then

            Dim item_str As String = oData.Rows(0)("group_items")
            If item_str <> "" Then
                For Each str As String In item_str.Split("|")

                    Dim oitem As New ListItem
                    oitem.Text = Split(str, "::")(0)
                    oitem.Value = Split(str, "::")(1)
                    items.Add(oitem)

                Next
            End If

        End If

    End Function
    Public Function LoadItemsByGroupKey(ByVal key As String, ByRef items As ArrayList) As Boolean
        Dim osql As New iDac.cls_sql_read

        Dim sSql As String = "select * from sys_groups where group_key='" + key + "'"

        osql._connection_string = Me.conn_string
        osql._tablename = "sys_groups"



        osql.transact_read(sSql)

        Dim oData As DataTable = osql._datatable

        If oData.Rows.Count > 0 Then

            Dim item_str As String = oData.Rows(0)("group_items")
            If item_str <> "" Then
                For Each str As String In item_str.Split("|")


                    items.Add(Convert.ToInt32(Split(str, "::")(1)))

                Next
            End If

        End If

    End Function
    Public Function GetGroupNameByKey(ByVal key As String, ByRef name As String) As Boolean
        Dim osql As New iDac.cls_sql_read

        Dim sSql As String = "select * from sys_groups where group_key='" + key + "'"

        osql._connection_string = Me.conn_string
        osql._tablename = "sys_groups"



        osql.transact_read(sSql)

        Dim oData As DataTable = osql._datatable

        If oData.Rows.Count > 0 Then

            name = oData.Rows(0)("group_name")
        End If

    End Function

    Public Function AddGroup(ByVal group_name As String, ByVal group_key As String) As Boolean

        Dim osql As New iDac.cls_T_command
        osql._dbtype = Me.db_type
        osql._connection_string = Me.conn_string
        osql._sqlstring = "insert into sys_groups (group_name,group_keys) values ('" + group_name + "','" + group_key + "')"
        osql.transact_command()


    End Function

    Function CreateSQLFromItems(ByVal items As ArrayList, ByRef sql As String) As Boolean
        Dim tmpstr = "select id from vv_allitems_full where id in (" + Join(items.ToArray, ",") + " )"


    End Function

End Class
