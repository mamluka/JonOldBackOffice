Public Class cls_ajax_makestrings
    Inherits iFoundation.cls_error_connection
    Function stone_found_str(ByVal items_found As Int32, ByVal stone_type As String, ByRef rStr As String) As Boolean

        rStr = "We have " + Convert.ToString(items_found)
        Select Case stone_type
            Case "1"
                If items_found > 1 Then
                    rStr += " Emeralds"
                Else
                    rStr += " Emerald"
                End If
            Case "2"
                If items_found > 1 Then
                    rStr += " Sapphires"
                Else
                    rStr += " Sapphire"
                End If
            Case "3"
                If items_found > 1 Then
                    rStr += " Pink Sapphires"
                Else
                    rStr += " Pink Sapphire"
                End If
            Case "4"
                If items_found > 1 Then
                    rStr += " Yellow Sapphires"
                Else
                    rStr += " Yellow Sapphire"
                End If
            Case "5"
                If items_found > 1 Then
                    rStr += " Ruby"
                Else
                    rStr += " Rubies"
                End If



        End Select
        rStr += " matching your search criteria"
    End Function
End Class
