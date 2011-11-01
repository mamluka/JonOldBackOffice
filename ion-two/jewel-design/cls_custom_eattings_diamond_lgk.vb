Public Class cls_custom_eattings_diamond_lgk

    Function create_desc(ByVal oceitem As ion_two.cls_custom_earrings_diamond_skl, ByRef DescStr As String)

        DescStr = "Diamond Stud Earrings<br>"
        DescStr += oceitem.metal_type + "<br>"
        DescStr += oceitem.weight_formatted + ", " + oceitem.quality + " " + oceitem.shape + "<br>"
        DescStr += "Setting: " + oceitem.setting_desc

    End Function

    Function create_extrainfo(ByVal price As Decimal, ByVal desc As String, ByVal setting_id As Int32, ByRef extrainfo As String) As Boolean
        extrainfo = "|CEI|" + Convert.ToString(price) + "|" + desc + "|" + Convert.ToString(setting_id) + "|"

    End Function

    Function getTrueid_byshapeid(ByVal shapeid As Int32, ByRef true_id As Int32)
        Select Case shapeid
            Case 5
                true_id = 6049
            Case 13
                true_id = 6050
            Case 7
                true_id = 6051
            Case 11
                true_id = 6052
            Case 9
                true_id = 6053
            Case 15
                true_id = 6054
            Case 8
                true_id = 6055
            Case 10
                true_id = 6056
            Case Else
                true_id = 6049
        End Select
    End Function
End Class
