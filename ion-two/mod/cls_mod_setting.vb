Public Class cls_mod_setting
    Inherits iFoundation.cls_error_connection
    Public Function ds_create_desc(ByVal metaltype As String, ByVal designid As Int32, ByVal delivery As Int16, ByRef desc As String)
        Select Case delivery
            Case 1

                desc = "A setting style from the gallery in " + metaltype + "<br>"
                desc += "This style is taken from item with id: " + Convert.ToString(designid)
            Case 2
                desc = "You have Emailed your setting style to Twin-Diamonds<br>"
                desc += "You have select a setting in " + metaltype
            Case 3
                desc = "You have uploaded your setting style to Twin-Diamonds<br>"
                desc += "You have select a setting in " + metaltype
        End Select

    End Function
    Public Function semi_create_desc(ByVal metaltype As String, ByVal designid As Int32, ByVal delivery As Int16, ByVal ss_full As String, ByRef desc As String)
        Select Case delivery
            Case 1

                desc = "A mounting in " + metaltype + "<br>"
                If ss_full <> "" Then
                    desc += "This mounting includes: " + Convert.ToString(ss_full)
                End If
            Case 2
                    desc = "You have Emailed your mounting to Twin-Diamonds<br>"

            Case 3
                    desc = "You have uploaded your mounting to Twin-Diamonds<br>"

        End Select

    End Function


    Public Function ds_create_extrainfo(ByVal price As Decimal, ByVal metaltype As String, ByVal designid As Int32, ByRef extrainfo As String, Optional ByVal ringsize As String = "Not Entered", Optional ByVal picsrc As String = "")

        If picsrc = "" Then
            extrainfo = "DGS|" + Convert.ToString(price) + "|" + metaltype + "|" + Convert.ToString(designid) + "|" + ringsize
        Else
            extrainfo = "DGS|" + Convert.ToString(price) + "|" + metaltype + "|" + Convert.ToString(designid) + "|" + ringsize + "|" + picsrc + "|"
        End If

    End Function
    Public Function semi_create_extrainfo(ByVal price As Decimal, ByVal metaltype As String, ByVal designid As Int32, ByRef extrainfo As String, Optional ByVal picsrc As String = "")

        If picsrc = "" Then
            extrainfo = "SMM|" + Convert.ToString(price) + "|" + metaltype + "|" + Convert.ToString(designid) + "|"
        Else
            extrainfo = "SMM|" + Convert.ToString(price) + "|" + metaltype + "|" + Convert.ToString(designid) + "|" + picsrc + "|"
        End If

    End Function
End Class
