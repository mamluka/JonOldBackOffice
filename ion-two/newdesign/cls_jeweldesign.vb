Public Class cls_jeweldesign
    Public conn_string As String
    Public db_type As String
    Public currencyid As String
    Public Function CalculateSettingPriceByPlate(ByVal oplate_setting As ion_two.skl_lst_inventory, ByRef metal_price As Decimal, Optional ByVal threestone As Boolean = False)

        Dim subplate_setting As ion_two.skl_lst_jewelry = oplate_setting._subplate
        If Not threestone Then

            If subplate_setting._jewelrysubtype = "Solitaire Pave" Or subplate_setting._jewelrysubtype = "Solitaire With Side Stones" Then
                metal_price = subplate_setting._jewel_extended.ss_weight * 812
            ElseIf subplate_setting._jewelrysubtype = "Three Stone" Or subplate_setting._jewelrysubtype = "Bridal Set" Then
                metal_price = subplate_setting._jewel_extended.ss_weight * 1412
            End If
        End If

        If subplate_setting._metal = "Platinum" Then
            metal_price += subplate_setting._weight * 175
        Else
            metal_price += subplate_setting._weight * 105
        End If


        Dim ocurrency As New ion_two.cls_currency
        Dim ocurrency_obj As New ion_two.skl_currency
        'ocurrency._connection_string = Application("connection")._connection_string
        'ocurrency._dbtype = Application("connection")._connection_string_type

        Dim currency_code As String = Me.currencyid

        ocurrency._connection_string = Me.conn_string
        ocurrency._dbtype = Me.db_type

        ocurrency.ReadCurrencyByCode(currency_code, ocurrency_obj)

        metal_price *= ocurrency_obj.rate



    End Function

    Public Function CreateDiamondDescription(ByVal oplate As ion_two.skl_lst_diamond, ByRef desc As String)

        desc = oplate._s_weight + " " + oplate._shape + " " + oplate._colorfrom + " color " + oplate._clarityfrom + "  clarity diamonds"

    End Function

    Public Function CreateGemstoneDescription(ByVal oplate As ion_two.skl_lst_gemstone, ByRef desc As String)

        desc = oplate._s_weight + " " + oplate._shape + " " + oplate._colorfrom + " color, " + oplate._stonetype

    End Function

    Public Function CreateSettingDescription(ByVal oplate As ion_two.skl_lst_jewelry, ByRef desc As String)
        Dim ostringfunc As New iFunctions.cls_string
        desc = oplate._metal + " " + oplate._jewelrysubtype + " Diamond " + oplate._jewelrytype
        If oplate._jewel_extended.has_sidestones Then
            desc += " with " + ostringfunc.format_decimal_return(oplate._jewel_extended.ss_weight, " Ct.") + " side stones"
        End If

    End Function
    Public Function CreateThreestoneSettingDescription(ByVal oplate As ion_two.skl_lst_jewelry, ByVal ss_weight As Decimal, ByVal clarityid As Int32, ByRef desc As String)
        Dim ostringfunc As New iFunctions.cls_string
        desc = oplate._metal + " " + oplate._jewelrysubtype + " Diamond " + oplate._jewelrytype
        If ss_weight > 0 Then
            desc += " with " + ostringfunc.format_decimal_return(ss_weight * 2, " Ct.")
        End If

        If clarityid = 2 Then
            desc += " F/VS2 "
        Else
            desc += " G/SI1"
        End If

    End Function




End Class
