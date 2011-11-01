Public Class cls_custom_jewel_skl
    ''gen
    Public id As Int32
    ''side stone
    Public ss_price As Decimal = 0
    Public ss_price_formatted As String = ""
    Public ss_weight As Decimal = 0
    Public ss_weight_formatted As String = ""
    Public ss_shapeid As Int16 = 0
    Public ss_shape As String = ""
    Public ss_quality As String = ""
    Public ss_qualityid As Int32
    Public ss_size As String
    Public ss_slider_val As Int32
    ''stuff for cart
    Public ss_desc As String = ""
    Public ss_prop As String = ""
    Public ss_extrainfo As String = ""
    Public ss_trueid As Int32 = 0 '' the real item number
    Public ss_link As String = "" ' the url for the ss page to save a function for full details
    Public ss_full_link As String = ""
    ''center stone

    Public cs_price As Decimal = 0
    Public cs_price_formatted As String = ""
    Public cs_weight As Decimal = 0
    Public cs_weight_formatted As String = ""
    Public cs_shapeid As Int16 = 0
    Public cs_shape As String = ""
    Public cs_item_link As String = ""
    Public cs_icon_pic As String = ""
    Public cs_item_id As String = ""
    Public cs_size As String = ""
    Public cs_txt_type As String = "" '' made to be able to know pink/yellow sapphire from regular
    Public cs_shape_txt_preview As String = ""
    Public cs_color As String = ""


    ''pass over vars= ""
    Public match_stone_type As String
    Public match_stone_shape As String

    ''settings info
    Public set_model_id As Int32 = 0 '' the item number of the setting style from the shop
    Public set_price As Decimal = 0 ''the price
    Public set_price_formatted As String = ""
    Public set_metal_type As String = "" ''the metal type
    Public set_metal_id As Int32 = 0
    Public set_model_picsrc As String = ""
    Public deliver_mathod As Int32 = 0
    Public set_ring_size As String = ""

    ''semi info
    Public semi_model_id As Int32 = 0
    Public semi_price As Decimal = 0
    Public semi_metal_type As String = ""
    Public semi_metal_id As Int16 = 0
    Public semi_ring_size As String = ""
    Public semi_model_picsrc As String = ""
    Public semi_price_formatted As String = ""
    Public semi_style As String = ""
    Public semi_weight_formatted As String = ""
    Public semi_ss_full_desc As String = ""
    ''gen
    Public ispurchested As Boolean = False
    Public match_stone_info_Redirect As Boolean = False
    Public save_params As cj_save_params
    ''search saves
    Public has_cs As Boolean = False
    Public has_ss As Boolean = False
    Public has_style As Boolean = False
    Public has_semi As Boolean = False



    Public cs_inithtml As String = ""
    Public ss_inithtml As String = ""
    Public set_inithtml As String = ""



    Public Class cj_save_params
        Public userid As Int16
        Public randomid As Int64
    End Class

End Class
