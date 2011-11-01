Public Class cls_gemstone
    Public Function GetTypeById(ByVal id As Int32) As String
        Select Case id
            Case 1
                Return "Natural Emerald"
            Case 2
                Return "Natural Ruby"
            Case 3
                Return "Natural Sapphire"
            Case 4
                Return "Natural Pink Sapphire"
            Case 5
                Return "Natural Yellow Sapphire"
        End Select
    End Function
End Class
