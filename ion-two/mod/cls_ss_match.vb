Public Class cls_ss_match
    Inherits iFoundation.cls_error_connection
    Public ss_length, ss_width As Decimal
    ''takes the ss width and length and makes an exec measurments
    Public Function ss_matchby_size(ByRef S_length_from As Decimal, ByRef S_length_to As Decimal, ByRef s_width_from As Decimal, ByRef s_width_to As Decimal)
        ''tmp code for test
        If ss_length = 0 Then
            S_length_from = ss_length * 1.5 - 0.5
            S_length_to = ss_length * 1.5 + 0.5
        Else
            S_length_from = ss_length * 1.5 - 0.5
            S_length_to = ss_length * 1.5 + 0.5

        End If
        ''s_width_from = ss_width * 2.5 - 1
        ''   s_width_to = ss_width * 2.5 + 1
    End Function

End Class
