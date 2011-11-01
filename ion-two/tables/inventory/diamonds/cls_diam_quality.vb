Public Class cls_diam_quality
    Inherits iFoundation.cls_error
    ''this function converts price by quality index from the combo
    Public Function price_byquality(ByVal qualityid As String, ByVal oldprice As Decimal, ByRef newprice As Decimal) As Boolean

        Select Case qualityid

            Case "2"
                newprice = Math.Round(oldprice * 0.8)

            Case Else
                newprice = oldprice
        End Select


        Return False
ErrorHandler:
        Me._err_number = Err.Number
        Me._err_description = Err.Description
        Me._err_source = Err.Source
        Return True
    End Function

    Public Function get_quality_fromstr(ByVal str As String, ByRef qualitystr As String) As Boolean

        If InStr(str, "D-E-F/VVS-VS", CompareMethod.Text) > 0 Then
            qualitystr = "D-E-F/VVS-VS"
        ElseIf InStr(str, "G-H/VS-SI", CompareMethod.Text) > 0 Then
            qualitystr = "G-H/VS-SI"
        Else
            qualitystr = "none"
        End If


        Return False
ErrorHandler:
        Me._err_number = Err.Number
        Me._err_description = Err.Description
        Me._err_source = Err.Source
        Return True
    End Function

    Public Function qualityid_bystr(ByVal str As String, ByRef qualityid As Int32) As Boolean

        If str = "D-E-F/VVS-VS" Then
            qualityid = 1
        ElseIf str = "G-H/VS-SI" Then
            qualityid = 2
        Else
            qualityid = 1
        End If


        Return False
ErrorHandler:
        Me._err_number = Err.Number
        Me._err_description = Err.Description
        Me._err_source = Err.Source
        Return True
    End Function


End Class
