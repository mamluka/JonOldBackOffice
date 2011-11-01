
Public Class cls_database_lgk
    Public conn_string As String
    Public Function GetViewTypeByItemNumber(ByVal itemnumber As String, ByRef viewtable As String)
        Dim viewer_sql As New iDac.cls_sql_read
        viewer_sql._connection_string = Me.conn_string
        viewer_sql._tablename = "vv_jewelry_full"


        viewer_sql.transact_read("select PLATETYPE from inv_inventory where itemnumber = '" + itemnumber + "'")

        Dim oData As DataTable = viewer_sql._datatable
        If oData.Rows.Count > 0 Then
            Select Case oData.Rows(0).Item("PLATETYPE")
                Case 1
                    viewtable = "vv_diamonds_full"
                Case 2
                    viewtable = "vv_gemstones_full"
                Case 3
                    viewtable = "vv_jewelry_full"

            End Select
        End If

    End Function

    Public Function PutSingleQuoteOnArray(ByRef array() As String) As String

        If array.Length > 0 Then

            Dim i As Int32
            For i = 0 To array.Length - 1
                array(i) = "'" + array(i) + "'"
            Next

        End If

    End Function


End Class
