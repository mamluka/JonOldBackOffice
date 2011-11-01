Public Class cls_search_smartsort
    Inherits ion_two.cls_search_library
    Public Function get_smartsort(ByVal smart_string As String, ByRef cSQLstring As String) As Boolean
        On Error GoTo ErrorHandler
        Dim bError As Boolean = False

        '' select all active items
        cSQLstring = "select * from vv_allitems_full where (smartsort='" + smart_String + "')"

        If cSQLstring <> "" Then
            '--- set Active
            Dim oActive As New ion_two.cls_search_general_active
            oActive._only_active = True
            bError = oActive.addsearch_active(cSQLstring)
            If bError Then
                Me._err_number = oActive._err_number
                Me._err_description = oActive._err_description
                Me._err_source = oActive._err_source
                Return True
            End If
            oActive = Nothing
        End If


        Return False
        Exit Function

ErrorHandler:
        Me._err_number = Err.Number
        Me._err_description = Err.Description
        Me._err_source = Err.Source
        Return True


    End Function
End Class
