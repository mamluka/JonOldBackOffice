Public Class cls_fulltxt_search
    Inherits iFoundation.cls_error_connection
    Public conn_string As String
    Public exclude_list As New ArrayList

    Sub New()

        Me.exclude_list.Add("ring")
        Me.exclude_list.Add("pendat")
        Me.exclude_list.Add("earrings")
        Me.exclude_list.Add("setting")

    End Sub

    Public Function getkeys_fromstr(ByVal str As String, ByRef StrArray As ArrayList)
        Dim tmpstr() As String
        tmpstr = str.Split(" ")

        Dim i As Int32
        For i = 0 To tmpstr.Length - 1
            If IsNumeric(tmpstr(i)) Then '' if it's a number there are 2 cases

                If tmpstr(i).Length = 1 Then '' if someone write 3 and ment 3 carat then i add a point for search to understand 3.xx carat
                    tmpstr(i) = " " + tmpstr(i) + ".*"
                    ''elseif tmpstr(i)
                End If

            End If
            If tmpstr(i).Length <> 1 Then
                StrArray.Add(tmpstr(i))
            End If
        Next
        remake_words(str, StrArray)
        ''check for key words
    End Function

    Function remake_exclude(ByRef strarray As ArrayList)
        Dim i, j, rID As Int32

        rID = -1

        For i = 0 To strarray.Count - 1
            For j = 0 To Me.exclude_list.Count - 1
                If strarray(i) = Me.exclude_list(j) Then
                    rID = j
                    Exit For
                Else
                    rID = -1
                End If
            Next
            If rID > -1 Then Me.exclude_list.RemoveAt(rID)
        Next

        If strarray.IndexOf("solitaire") > -1 Then '' if solitair then allow ring
            Me.exclude_list.Remove("ring")
        End If


    End Function
    Function remake_words(ByVal str As String, ByRef strarray As ArrayList)

        If InStr(str, "ring") > 1 And InStr(str.ToLower, "emerald".ToLower) > 0 And InStr(str.ToLower, "cut".ToLower) = 0 Then
            Me.exclude_list.Add("emerald cut")
        End If

    End Function

    Public Function create_search_sql(ByVal strarray As ArrayList, ByRef cSQLstring As String) As Boolean
        On Error GoTo ErrorHandler
        Dim bError As Boolean = False

        '' select all active items

        cSQLstring = "select * from inv_search  inner join vv_allitems_full on  inv_search.inventory_id = vv_allitems_full.id where "
        cSQLstring += "CONTAINS(search,'"

        Dim i As Int32

        For i = 0 To strarray.Count - 1
            If i = strarray.Count - 1 Then
                cSQLstring += Chr(34) + strarray(i) + Chr(34) + "')"
                Exit For
            End If

            cSQLstring += Chr(34) + strarray(i) + Chr(34) + " and "

        Next

        remake_exclude(strarray)


        If Me.exclude_list.Count > 0 Then
            cSQLstring += " and "

            For i = 0 To Me.exclude_list.Count - 1
                If i = Me.exclude_list.Count - 1 Then
                    cSQLstring += "(lower(search) not like '%" + Me.exclude_list(i) + "%')"
                    Exit For
                End If
                cSQLstring += "(lower(search) not like '%" + Me.exclude_list(i) + "%') and "

            Next
        End If

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
