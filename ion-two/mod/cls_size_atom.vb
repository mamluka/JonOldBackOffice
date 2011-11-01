Public Class cls_size_atom
    Public str_size As String
    Public length As Decimal
    Public width As Decimal

    Public Function load(ByVal sizestr As String)
        Me.str_size = sizestr

        sizestr = sizestr.Replace(" ", "") '' remove spaces for easy handle

        If InStr(sizestr, "mm") > 0 Then
            sizestr = sizestr.Remove(sizestr.Length - 3, 3)
        End If

        If InStr(sizestr, "x", CompareMethod.Text) > 0 Then
            Me.length = Convert.ToDecimal(Mid(sizestr, 1, InStr(sizestr, "x", CompareMethod.Text) - 1))
            Me.width = Convert.ToDecimal(Mid(sizestr, InStr(sizestr, "x", CompareMethod.Text) + 1, 10))
        Else
            Me.length = Convert.ToDecimal(sizestr)


        End If

    End Function
End Class
