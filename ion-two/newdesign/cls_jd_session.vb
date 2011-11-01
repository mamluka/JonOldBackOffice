Public Class cls_jd_session
    Public has_diamond As Boolean = False
    Public is_gemstone As Boolean = False
    Public has_setting As Boolean = False
    Public has_sidestones As Boolean = False
    Public diamond_price As Decimal = 0
    Public setting_price As Decimal = 0
    Public diamond_id As Int32 = 0
    Public setting_id As Int32 = 0
    Public gemtype_id As Int32 = 1 '' 1 = emerald 2=ruby 3= sapphire
    Public cs_shape As String = ""
    Public centerstone_icon As String = ""
    Public centerstone_weight As Decimal = 0
    Public ss_weight As Decimal = 0
    Public ss_shapeid As Int32 = 0
    Public ss_clarity As Int32 = 0
    Public ss_price As Decimal = 0
End Class
