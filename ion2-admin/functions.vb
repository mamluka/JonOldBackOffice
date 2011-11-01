Module functions

    Public Function GetComboValue(ByVal oCombo As System.Web.UI.WebControls.DropDownList, ByVal nValue As Integer) As Integer

        If nValue = 0 Then Return 0

        Dim nLoop As Integer
        For nLoop = 0 To oCombo.Items.Count
            If oCombo.Items(nLoop).Value = nValue Then
                Return nLoop
            End If
        Next

        Return 0
    End Function

    Public Function GetComboIndex(ByVal oCombo As System.Web.UI.WebControls.DropDownList, ByVal cValue As String) As Integer

        If cValue = "" Then Return 0

        Dim nLoop As Integer
        For nLoop = 0 To oCombo.Items.Count
            If LCase(oCombo.Items(nLoop).Value) = LCase(cValue) Then
                Return nLoop
            End If
        Next

        Return 0
    End Function



End Module
