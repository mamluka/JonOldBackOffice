Public Class cls_setting_metal_atom
    Public metal_string As String
    Public metal_id As Int16
    Function getMetalID_bykey(ByVal key As String)
        Select Case key
            Case "platinum"
                metal_id = 0
            Case "18kwg"
                metal_id = 2
            Case "18kyg"
                metal_id = 1
        End Select
    End Function
End Class
