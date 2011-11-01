Public Class cls_live_search
    Public active As Boolean = False
    ''cs
    Public cs_type As Int32
    Public cs_shape As String
    Public cs_color_grade As Int32
    Public cs_color_index As Int32
    Public cs_min_price_val As String = "0"
    Public cs_max_price_val As String = "0"
    Public cs_min_weight_val As String = "0"
    Public cs_max_weight_val As String = "0"
    Public cs_minp, cs_maxp, cs_minw, cs_maxw As String
    Public total_items_found As String
    Public cs_outstr As String
    ''ss
    Public ss_shapeid As Int32
    Public ss_slider_val As Int32

    Public init_html_string As String

    Public conn_string As String
    Function init(ByVal cs_type As Int32, ByVal cs_shape As String, ByVal cs_color_genre As Int32, ByVal cs_color_index As Int32)
        Dim oajaxtable As New cls_ajax_maketable
        Dim ostringfunc As New iFunctions.cls_string
        Dim tmpShapelist As New ArrayList
        Dim oshape As New ion_two.cls_shape

        ostringfunc.get_params_fromstr(cs_shape, tmpShapelist)
        oajaxtable.conn_string = Me.conn_string

        oshape.Cj_shape_byid(tmpShapelist, tmpShapelist)

        oajaxtable.make_sql_str(cs_type, 0, 0, tmpShapelist, 0, 0, 0, 0)
        oajaxtable.get_table_info()

        Me.cs_maxp = oajaxtable.max_price
        Me.cs_minp = oajaxtable.min_price
        Me.cs_maxw = oajaxtable.max_weight
        Me.cs_minw = oajaxtable.min_weight

        Me.cs_max_price_val = oajaxtable.max_price
        Me.cs_min_price_val = oajaxtable.min_price
        Me.cs_max_weight_val = oajaxtable.max_weight
        Me.cs_min_weight_val = oajaxtable.min_weight

        Me.active = True
        Me.cs_type = cs_type
        Me.cs_shape = cs_shape
        Me.cs_color_grade = cs_color_grade
        Me.cs_color_index = cs_color_index

        Me.total_items_found = oajaxtable.total_items_found

        Dim ajaxoutstr As String

        Dim oajaxstr As New ion_two.cls_ajax_makestrings

        oajaxstr.stone_found_str(oajaxtable.total_items_found, cs_type, ajaxoutstr)

        Me.init_html_string = "(" + Convert.ToString(cs_type) + ",'" + cs_shape + "',1,0,0,0,0,0," + Convert.ToString(cs_minp) + "," + Convert.ToString(cs_maxp) + "," + Convert.ToString(cs_minw) + "," + Convert.ToString(cs_maxw) + "," + Convert.ToString(oajaxtable.total_items_found) + ",'" + ajaxoutstr + "',true)"
    End Function
    Function resave_params_cs(ByVal cs_type2 As String, ByVal cs_shape_str2 As String, ByVal cs_color_genre2 As Int32, ByVal cs_color_index2 As Int32, ByVal cs_price_minval2 As String, ByVal cs_price_maxval2 As String, ByVal cs_weight_minval2 As String, ByVal cs_weight_maxval2 As String, ByVal cs_minp2 As String, ByVal cs_maxp2 As String, ByVal cs_minw2 As String, ByVal cs_maxw2 As String, ByVal total_items As Int32, ByVal cs_outstr As String) As Boolean

        Me.cs_maxp = cs_maxp2
        Me.cs_minp = cs_minp2
        Me.cs_maxw = cs_maxw2
        Me.cs_minw = cs_minw2

        Me.cs_max_price_val = cs_price_maxval2
        Me.cs_min_price_val = cs_price_minval2
        Me.cs_max_weight_val = cs_weight_maxval2
        Me.cs_min_weight_val = cs_weight_minval2

        Me.active = True
        Me.cs_type = cs_type2
        Me.cs_shape = cs_shape_str2
        Me.cs_color_grade = cs_color_genre2
        Me.cs_color_index = cs_color_index2

        Me.cs_outstr = cs_outstr

        Me.total_items_found = Convert.ToString(total_items)

    End Function

    Function make_html_string()
        Me.init_html_string = "(" + Convert.ToString(Me.cs_type) + ",'" + Me.cs_shape + "'," + Convert.ToString(Me.cs_color_grade) + "," + Convert.ToString(Me.cs_color_index) + "," + Me.cs_min_price_val + "," + Me.cs_max_price_val + "," + Me.cs_min_weight_val + "," + Me.cs_max_weight_val + "," + Convert.ToString(Me.cs_minp) + "," + Convert.ToString(Me.cs_maxp) + "," + Convert.ToString(Me.cs_minw) + "," + Convert.ToString(Me.cs_maxw) + "," + Convert.ToString(Me.total_items_found) + ",'" + Me.cs_outstr + "',false)"
    End Function
End Class

