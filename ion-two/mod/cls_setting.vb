Public Class cls_setting

    Function getprice_bymetalid(ByVal metalid As Int16, ByRef price As Decimal, ByRef price_formatted As String) As Boolean
        Dim ostringfunc As New iFunctions.cls_string
        Select Case metalid
            Case 0
                price = 1260
                ostringfunc.format_currency(price, price_formatted, " $")
            Case 1
                price = 680
                ostringfunc.format_currency(price, price_formatted, " $")

            Case 2
                price = 680
                ostringfunc.format_currency(price, price_formatted, " $")
        End Select
    End Function

End Class
