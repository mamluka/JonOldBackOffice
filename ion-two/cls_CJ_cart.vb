Imports System.Web
Public Class cls_CJ_cart
    Inherits iFoundation.cls_error_connection
    Public ocart As New ion_two.cls_shopping_cart
    Public isSecure As Boolean = False
    Public Sub New()
        ocart = HttpContext.Current.Session("cart")
    End Sub
    Public Function cJ_addall(ByVal oCJobj As ion_two.cls_custom_jewel_skl)



        '' the mod for the pair side stone cart items
        If oCJobj.has_ss Then
            Dim omodPair As New ion_two.cls_mod_diam_pair_item

            omodPair.description = oCJobj.ss_desc
            omodPair.extrainfo = oCJobj.ss_extrainfo
            omodPair.price = oCJobj.ss_price

            ocart.add_mod_item(oCJobj.ss_trueid, 1, omodPair, , , isSecure)
        End If

        ''center stone added to cart
        If oCJobj.has_cs Then
            ocart.add_item(oCJobj.cs_item_id, , 1)
        End If

        ''settings style item test
        If oCJobj.has_style Then
            Dim omodsetting As New ion_two.cls_mod_setting_item
            Dim osetting As New ion_two.cls_mod_setting

            osetting.ds_create_desc(oCJobj.set_metal_type, oCJobj.set_model_id, oCJobj.deliver_mathod, omodsetting.description)



            omodsetting.price = oCJobj.set_price

            omodsetting.picsrc = oCJobj.set_model_picsrc
            omodsetting.set_ring_size = oCJobj.set_ring_size
            If oCJobj.deliver_mathod > 1 Then
                osetting.ds_create_extrainfo(oCJobj.set_price, oCJobj.set_metal_type, oCJobj.set_model_id, omodsetting.extrainfo, oCJobj.set_model_picsrc)
            Else
                osetting.ds_create_extrainfo(oCJobj.set_price, oCJobj.set_metal_type, oCJobj.set_model_id, omodsetting.extrainfo)
            End If

            ocart.add_mod_item(oCJobj.set_model_id, 2, omodsetting, , , isSecure)
            'if pics change with metal type for future ref
            'Select Case oCJobj.set_metal_type

            '    Case "Platinum"
            '        ocart.add_mod_item(oCJobj.set_model_id, 2, omodsetting, , , isSecure)
            '    Case "Yellow Gold" Or "18 Karat Yellow Gold"
            '        ocart.add_mod_item(oCJobj.set_model_id, 2, omodsetting, , , isSecure)
            '    Case "White Gold" Or "18 Karat White Gold"
            '        ocart.add_mod_item(oCJobj.set_model_id, 2, omodsetting, , , isSecure)
            'End Select
        End If
        If oCJobj.has_semi Then
            Dim omodsetting As New ion_two.cls_mod_setting_item
            Dim osetting As New ion_two.cls_mod_setting

            osetting.semi_create_desc(oCJobj.semi_metal_type, oCJobj.semi_model_id, oCJobj.deliver_mathod, oCJobj.semi_ss_full_desc, omodsetting.description)



            omodsetting.price = oCJobj.semi_price

            omodsetting.picsrc = oCJobj.semi_model_picsrc
            omodsetting.set_ring_size = oCJobj.semi_ring_size
            If oCJobj.deliver_mathod > 1 Then
                osetting.ds_create_extrainfo(oCJobj.semi_price, oCJobj.semi_metal_type, oCJobj.semi_model_id, omodsetting.extrainfo, oCJobj.semi_model_picsrc)
            Else
                osetting.ds_create_extrainfo(oCJobj.semi_price, oCJobj.semi_metal_type, oCJobj.semi_model_id, omodsetting.extrainfo)
            End If

            ocart.add_mod_item(oCJobj.semi_model_id, 2, omodsetting, , , isSecure)
        End If
        HttpContext.Current.Session("cart") = ocart

        ocart = Nothing
    End Function
    ''add custom earrings cE
    Function cE_addall(ByVal oceitem As ion_two.cls_custom_earrings_diamond_skl)
        Dim omodceitem As New ion_two.cls_mod_ce_diam_item
        Dim ologic As New ion_two.cls_custom_eattings_diamond_lgk

        ologic.create_desc(oceitem, omodceitem.description)

        ologic.create_extrainfo(oceitem.price, omodceitem.description, omodceitem.extrainfo)

        omodceitem.price = oceitem.price

        ocart.add_mod_item(oceitem.true_id, 1, omodceitem, 1, , True)

        HttpContext.Current.Session("cart") = ocart
    End Function

End Class
