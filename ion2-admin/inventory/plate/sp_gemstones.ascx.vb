Partial Class sp_gemstones
    Inherits iFoundation.wsc_usercontrol



#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()

    End Sub

#End Region

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Put user code to initialize the page here
    End Sub


    Public Function load_combos() As Boolean
        On Error GoTo ErrorHandler
        Dim bError As Boolean = False

        Dim oTmpCombo As New iFunctions.cls_combo
        oTmpCombo._connection_string = Application("config").connection_string
        oTmpCombo._dbtype = Application("config").connection_string_type


        '--- fill STONETYPE combo
        oTmpCombo._combobox = Me.cmb_stonetype
        oTmpCombo._sqlstring = "select id, lang" & Session("user").language & "_longdescr from inv_STONETYPE_GEM order by sortorder"
        oTmpCombo._textfield = "lang" & Session("user").language & "_longdescr"
        oTmpCombo._valuefield = "id"
        oTmpCombo._addrow = ""
        bError = oTmpCombo.BindCombo()
        If bError Then
            Me._err_number = oTmpCombo._err_number
            Me._err_description = oTmpCombo._err_description
            Me._err_source = oTmpCombo._err_source
            Return True
        End If


        '--- fill SHAPE combo
        oTmpCombo._combobox = Me.cmb_shape
        oTmpCombo._sqlstring = "select id, lang" & Session("user").language & "_longdescr from inv_SHAPE_GEM order by sortorder"
        oTmpCombo._textfield = "lang" & Session("user").language & "_longdescr"
        oTmpCombo._valuefield = "id"
        oTmpCombo._addrow = ""
        bError = oTmpCombo.BindCombo()
        If bError Then
            Me._err_number = oTmpCombo._err_number
            Me._err_description = oTmpCombo._err_description
            Me._err_source = oTmpCombo._err_source
            Return True
        End If


        '--- fill COLORFROM combo
        oTmpCombo._combobox = Me.cmb_colorfrom
        oTmpCombo._sqlstring = "select id, lang" & Session("user").language & "_longdescr from inv_COLOR_GEM order by sortorder"
        oTmpCombo._textfield = "lang" & Session("user").language & "_longdescr"
        oTmpCombo._valuefield = "id"
        oTmpCombo._addrow = ""
        bError = oTmpCombo.BindCombo()
        If bError Then
            Me._err_number = oTmpCombo._err_number
            Me._err_description = oTmpCombo._err_description
            Me._err_source = oTmpCombo._err_source
            Return True
        End If


        '--- fill COLORTYPEFROM combo
        oTmpCombo._combobox = Me.cmb_colortypefrom
        oTmpCombo._sqlstring = "select id, lang" & Session("user").language & "_longdescr from inv_COLORTYPE_GEM order by sortorder"
        oTmpCombo._textfield = "lang" & Session("user").language & "_longdescr"
        oTmpCombo._valuefield = "id"
        oTmpCombo._addrow = ""
        bError = oTmpCombo.BindCombo()
        If bError Then
            Me._err_number = oTmpCombo._err_number
            Me._err_description = oTmpCombo._err_description
            Me._err_source = oTmpCombo._err_source
            Return True
        End If


        '--- fill CLARITYFROM combo
        oTmpCombo._combobox = Me.cmb_clarityfrom
        oTmpCombo._sqlstring = "select id, lang" & Session("user").language & "_longdescr from inv_CLARITY_GEM order by sortorder"
        oTmpCombo._textfield = "lang" & Session("user").language & "_longdescr"
        oTmpCombo._valuefield = "id"
        oTmpCombo._addrow = ""
        bError = oTmpCombo.BindCombo()
        If bError Then
            Me._err_number = oTmpCombo._err_number
            Me._err_description = oTmpCombo._err_description
            Me._err_source = oTmpCombo._err_source
            Return True
        End If


        '--- fill CLARITYTYPEFROM combo
        oTmpCombo._combobox = Me.cmb_claritytypefrom
        oTmpCombo._sqlstring = "select id, lang" & Session("user").language & "_longdescr from inv_CLARITYTYPE_GEM order by sortorder"
        oTmpCombo._textfield = "lang" & Session("user").language & "_longdescr"
        oTmpCombo._valuefield = "id"
        oTmpCombo._addrow = ""
        bError = oTmpCombo.BindCombo()
        If bError Then
            Me._err_number = oTmpCombo._err_number
            Me._err_description = oTmpCombo._err_description
            Me._err_source = oTmpCombo._err_source
            Return True
        End If


        '--- fill COLORTO combo
        oTmpCombo._combobox = Me.cmb_colorto
        oTmpCombo._sqlstring = "select id, lang" & Session("user").language & "_longdescr from inv_COLOR_GEM order by sortorder"
        oTmpCombo._textfield = "lang" & Session("user").language & "_longdescr"
        oTmpCombo._valuefield = "id"
        oTmpCombo._addrow = ""
        bError = oTmpCombo.BindCombo()
        If bError Then
            Me._err_number = oTmpCombo._err_number
            Me._err_description = oTmpCombo._err_description
            Me._err_source = oTmpCombo._err_source
            Return True
        End If


        '--- fill COLORTYPETO combo
        oTmpCombo._combobox = Me.cmb_colortypeto
        oTmpCombo._sqlstring = "select id, lang" & Session("user").language & "_longdescr from inv_COLORTYPE_GEM order by sortorder"
        oTmpCombo._textfield = "lang" & Session("user").language & "_longdescr"
        oTmpCombo._valuefield = "id"
        oTmpCombo._addrow = ""
        bError = oTmpCombo.BindCombo()
        If bError Then
            Me._err_number = oTmpCombo._err_number
            Me._err_description = oTmpCombo._err_description
            Me._err_source = oTmpCombo._err_source
            Return True
        End If


        '--- fill CLARITYTO combo
        oTmpCombo._combobox = Me.cmb_clarityto
        oTmpCombo._sqlstring = "select id, lang" & Session("user").language & "_longdescr from inv_CLARITY_GEM order by sortorder"
        oTmpCombo._textfield = "lang" & Session("user").language & "_longdescr"
        oTmpCombo._valuefield = "id"
        oTmpCombo._addrow = ""
        bError = oTmpCombo.BindCombo()
        If bError Then
            Me._err_number = oTmpCombo._err_number
            Me._err_description = oTmpCombo._err_description
            Me._err_source = oTmpCombo._err_source
            Return True
        End If


        '--- fill CLARITYTYPETO combo
        oTmpCombo._combobox = Me.cmb_claritytypeto
        oTmpCombo._sqlstring = "select id, lang" & Session("user").language & "_longdescr from inv_CLARITYTYPE_GEM order by sortorder"
        oTmpCombo._textfield = "lang" & Session("user").language & "_longdescr"
        oTmpCombo._valuefield = "id"
        oTmpCombo._addrow = ""
        bError = oTmpCombo.BindCombo()
        If bError Then
            Me._err_number = oTmpCombo._err_number
            Me._err_description = oTmpCombo._err_description
            Me._err_source = oTmpCombo._err_source
            Return True
        End If


        '--- fill ORIGIN combo
        oTmpCombo._combobox = Me.cmb_origin
        oTmpCombo._sqlstring = "select id, lang" & Session("user").language & "_longdescr from inv_ORIGIN_GEM order by sortorder"
        oTmpCombo._textfield = "lang" & Session("user").language & "_longdescr"
        oTmpCombo._valuefield = "id"
        oTmpCombo._addrow = ""
        bError = oTmpCombo.BindCombo()
        If bError Then
            Me._err_number = oTmpCombo._err_number
            Me._err_description = oTmpCombo._err_description
            Me._err_source = oTmpCombo._err_source
            Return True
        End If


        '--- fill BRIGHTNESS combo
        oTmpCombo._combobox = Me.cmb_brightness
        oTmpCombo._sqlstring = "select id, lang" & Session("user").language & "_longdescr from inv_BRIGHTNESS_GEM order by sortorder"
        oTmpCombo._textfield = "lang" & Session("user").language & "_longdescr"
        oTmpCombo._valuefield = "id"
        oTmpCombo._addrow = ""
        bError = oTmpCombo.BindCombo()
        If bError Then
            Me._err_number = oTmpCombo._err_number
            Me._err_description = oTmpCombo._err_description
            Me._err_source = oTmpCombo._err_source
            Return True
        End If

        '--- fill LUSTER combo
        oTmpCombo._combobox = Me.cmb_luster
        oTmpCombo._sqlstring = "select id, lang" & Session("user").language & "_longdescr from inv_LUSTER_GEM order by sortorder"
        oTmpCombo._textfield = "lang" & Session("user").language & "_longdescr"
        oTmpCombo._valuefield = "id"
        oTmpCombo._addrow = ""
        bError = oTmpCombo.BindCombo()
        If bError Then
            Me._err_number = oTmpCombo._err_number
            Me._err_description = oTmpCombo._err_description
            Me._err_source = oTmpCombo._err_source
            Return True
        End If


        '--- fill STURATION combo
        oTmpCombo._combobox = Me.cmb_saturation
        oTmpCombo._sqlstring = "select id, lang" & Session("user").language & "_longdescr from inv_SATURATION_GEM order by sortorder"
        oTmpCombo._textfield = "lang" & Session("user").language & "_longdescr"
        oTmpCombo._valuefield = "id"
        oTmpCombo._addrow = ""
        bError = oTmpCombo.BindCombo()
        If bError Then
            Me._err_number = oTmpCombo._err_number
            Me._err_description = oTmpCombo._err_description
            Me._err_source = oTmpCombo._err_source
            Return True
        End If


        '--- fill ENHANCEMENTS combo
        oTmpCombo._combobox = Me.cmb_enhancements
        oTmpCombo._sqlstring = "select id, lang" & Session("user").language & "_longdescr from inv_ENHANCEMENT_GEM order by sortorder"
        oTmpCombo._textfield = "lang" & Session("user").language & "_longdescr"
        oTmpCombo._valuefield = "id"
        oTmpCombo._addrow = ""
        bError = oTmpCombo.BindCombo()
        If bError Then
            Me._err_number = oTmpCombo._err_number
            Me._err_description = oTmpCombo._err_description
            Me._err_source = oTmpCombo._err_source
            Return True
        End If


        '--- fill CUT combo
        oTmpCombo._combobox = Me.cmb_cut
        oTmpCombo._sqlstring = "select id, lang" & Session("user").language & "_longdescr from inv_CUT_GEM order by sortorder"
        oTmpCombo._textfield = "lang" & Session("user").language & "_longdescr"
        oTmpCombo._valuefield = "id"
        oTmpCombo._addrow = ""
        bError = oTmpCombo.BindCombo()
        If bError Then
            Me._err_number = oTmpCombo._err_number
            Me._err_description = oTmpCombo._err_description
            Me._err_source = oTmpCombo._err_source
            Return True
        End If


        '--- fill GRADE combo
        oTmpCombo._combobox = Me.cmb_grade
        oTmpCombo._sqlstring = "select id, lang" & Session("user").language & "_longdescr from inv_GRADE_GEM order by sortorder"
        oTmpCombo._textfield = "lang" & Session("user").language & "_longdescr"
        oTmpCombo._valuefield = "id"
        oTmpCombo._addrow = ""
        bError = oTmpCombo.BindCombo()
        If bError Then
            Me._err_number = oTmpCombo._err_number
            Me._err_description = oTmpCombo._err_description
            Me._err_source = oTmpCombo._err_source
            Return True
        End If


        '--- fill REPORT combo
        oTmpCombo._combobox = Me.cmb_report
        oTmpCombo._sqlstring = "select id, lang" & Session("user").language & "_longdescr from inv_REPORT_GEM order by sortorder"
        oTmpCombo._textfield = "lang" & Session("user").language & "_longdescr"
        oTmpCombo._valuefield = "id"
        oTmpCombo._addrow = ""
        bError = oTmpCombo.BindCombo()
        If bError Then
            Me._err_number = oTmpCombo._err_number
            Me._err_description = oTmpCombo._err_description
            Me._err_source = oTmpCombo._err_source
            Return True
        End If

        '--- Release
        oTmpCombo = Nothing

        Return False
        Exit Function

ErrorHandler:
        Me._err_number = Err.Number
        Me._err_description = Err.Description
        Me._err_source = Err.Source
        Return True

    End Function

    Public Function get_plate(ByVal oSkelet As ion_two.skl_inventory) As Boolean
        On Error GoTo ErrorHandler
        Dim bError As Boolean = False


        '--- Map subplate
        Dim oTmpSubPlate As ion_two.skl_gemstone
        oTmpSubPlate = oSkelet._subplate

        '--- set combo functions
        Dim oTmpCombo As New iFunctions.cls_combo

        '--- Set the ID of the loaded item
        Me.hid_subplate_id.Text = oTmpSubPlate._id

        Me.txt_weight.Text = oTmpSubPlate._weight
        Me.txt_quantity.Text = oTmpSubPlate._quantity
        Me.txt_measure1.Text = oTmpSubPlate._measure1from
        Me.txt_measure2.Text = oTmpSubPlate._measure2from
        Me.txt_measure3.Text = oTmpSubPlate._measure3from
        Me.txt_measure_to1.Text = oTmpSubPlate._measure1from
        Me.txt_measure_to2.Text = oTmpSubPlate._measure2to
        Me.txt_measure_to3.Text = oTmpSubPlate._measure3to

        Me.cmb_stonetype.SelectedIndex = GetComboValue(Me.cmb_stonetype, oTmpSubPlate._stonetype_id)
        Me.cmb_origin.SelectedIndex = GetComboValue(Me.cmb_origin, oTmpSubPlate._origin_id)
        Me.cmb_shape.SelectedIndex = GetComboValue(Me.cmb_shape, oTmpSubPlate._shape_id)
        Me.cmb_colorfrom.SelectedIndex = GetComboValue(Me.cmb_colorfrom, oTmpSubPlate._color_id)
        Me.cmb_colortypefrom.SelectedIndex = GetComboValue(Me.cmb_colortypefrom, oTmpSubPlate._colortype_id)
        Me.cmb_clarityfrom.SelectedIndex = GetComboValue(Me.cmb_clarityfrom, oTmpSubPlate._clarity_id)
        Me.cmb_claritytypefrom.SelectedIndex = GetComboValue(Me.cmb_claritytypefrom, oTmpSubPlate._claritytype_id)
        Me.cmb_colorto.SelectedIndex = GetComboValue(Me.cmb_colorto, oTmpSubPlate._colorto_id)
        Me.cmb_colortypeto.SelectedIndex = GetComboValue(Me.cmb_colortypeto, oTmpSubPlate._colortypeto_id)
        Me.cmb_clarityto.SelectedIndex = GetComboValue(Me.cmb_clarityto, oTmpSubPlate._clarityto_id)
        Me.cmb_claritytypeto.SelectedIndex = GetComboValue(Me.cmb_claritytypeto, oTmpSubPlate._claritytypeto_id)
        Me.cmb_grade.SelectedIndex = GetComboValue(Me.cmb_grade, oTmpSubPlate._grade_id)
        Me.cmb_brightness.SelectedIndex = GetComboValue(Me.cmb_brightness, oTmpSubPlate._brightness_id)
        Me.cmb_luster.SelectedIndex = GetComboValue(Me.cmb_luster, oTmpSubPlate._luster_id)
        Me.cmb_saturation.SelectedIndex = GetComboValue(Me.cmb_saturation, oTmpSubPlate._saturation_id)
        Me.cmb_enhancements.SelectedIndex = GetComboValue(Me.cmb_enhancements, oTmpSubPlate._enhancement_id)
        Me.cmb_cut.SelectedIndex = GetComboValue(Me.cmb_cut, oTmpSubPlate._cut_id)
        Me.cmb_report.SelectedIndex = GetComboValue(Me.cmb_report, oTmpSubPlate._report_id)
        Me.free_color_txt.Text = oTmpSubPlate.freecolor
        '--- Release
        oTmpCombo = Nothing


        Return False
        Exit Function

ErrorHandler:
        Me._err_number = Err.Number
        Me._err_description = Err.Description
        Me._err_source = Err.Source
        Return True

    End Function

    Public Function validate_form(ByRef bValid As Boolean, ByRef oLst_error As System.Web.UI.WebControls.ListBox) As Boolean
        On Error GoTo ErrorHandler
        Dim bError As Boolean = False

        '--- We assume everything is OK until we find a problem
        bValid = True

        If System.Convert.ToDecimal(Me.txt_weight.Text) <= 0 Then
            oLst_error.Items.Add("- A Gemstone must have some WEIGHT")
            bValid = False
        End If


        Return False
        Exit Function

ErrorHandler:
        Me._err_number = Err.Number
        Me._err_description = Err.Description
        Me._err_source = Err.Source
        Return True

    End Function

    Public Function set_plate(ByVal oSkelet As ion_two.skl_inventory) As Boolean
        On Error GoTo ErrorHandler
        Dim bError As Boolean = False

        '--- Create subplate
        Dim oTmpSubPlate As New ion_two.skl_gemstone

        oTmpSubPlate._id = Convert.ToInt32(Me.hid_subplate_id.Text)
        oTmpSubPlate._weight = System.Convert.ToDecimal(Me.txt_weight.Text)
        oTmpSubPlate._quantity = System.Convert.ToInt16(Me.txt_quantity.Text)
        oTmpSubPlate._measure1from = System.Convert.ToDecimal(Me.txt_measure1.Text)
        oTmpSubPlate._measure2from = System.Convert.ToDecimal(Me.txt_measure2.Text)
        oTmpSubPlate._measure3from = System.Convert.ToDecimal(Me.txt_measure3.Text)
        oTmpSubPlate._measure1to = System.Convert.ToDecimal(Me.txt_measure_to1.Text)
        oTmpSubPlate._measure2to = System.Convert.ToDecimal(Me.txt_measure_to2.Text)
        oTmpSubPlate._measure3to = System.Convert.ToDecimal(Me.txt_measure_to3.Text)
        oTmpSubPlate._stonetype_id = System.Convert.ToInt16(Me.cmb_stonetype.SelectedItem.Value)
        oTmpSubPlate._origin_id = System.Convert.ToInt16(Me.cmb_origin.SelectedItem.Value)
        oTmpSubPlate._shape_id = System.Convert.ToInt16(Me.cmb_shape.SelectedItem.Value)
        oTmpSubPlate._color_id = System.Convert.ToInt16(Me.cmb_colorfrom.SelectedItem.Value)
        oTmpSubPlate._colortype_id = System.Convert.ToInt16(Me.cmb_colortypefrom.SelectedItem.Value)
        oTmpSubPlate._clarity_id = System.Convert.ToInt16(Me.cmb_clarityfrom.SelectedItem.Value)
        oTmpSubPlate._claritytype_id = System.Convert.ToInt16(Me.cmb_claritytypefrom.SelectedItem.Value)
        oTmpSubPlate._colorto_id = System.Convert.ToInt16(Me.cmb_colorto.SelectedItem.Value)
        oTmpSubPlate._colortypeto_id = System.Convert.ToInt16(Me.cmb_colortypeto.SelectedItem.Value)
        oTmpSubPlate._clarityto_id = System.Convert.ToInt16(Me.cmb_clarityto.SelectedItem.Value)
        oTmpSubPlate._claritytypeto_id = System.Convert.ToInt16(Me.cmb_claritytypeto.SelectedItem.Value)
        oTmpSubPlate._grade_id = System.Convert.ToInt16(Me.cmb_grade.SelectedItem.Value)
        oTmpSubPlate._brightness_id = System.Convert.ToInt16(Me.cmb_brightness.SelectedItem.Value)
        oTmpSubPlate._luster_id = System.Convert.ToInt16(Me.cmb_luster.SelectedItem.Value)
        oTmpSubPlate._saturation_id = System.Convert.ToInt16(Me.cmb_saturation.SelectedItem.Value)
        oTmpSubPlate._enhancement_id = System.Convert.ToInt16(Me.cmb_enhancements.SelectedItem.Value)
        oTmpSubPlate._cut_id = System.Convert.ToInt16(Me.cmb_cut.SelectedItem.Value)
        oTmpSubPlate._report_id = System.Convert.ToInt16(Me.cmb_report.SelectedItem.Value)
        oTmpSubPlate.freecolor = Me.free_color_txt.Text


        '--- Map subplate
        oSkelet._subplate = oTmpSubPlate

        Return False
        Exit Function

ErrorHandler:
        Me._err_number = Err.Number
        Me._err_description = Err.Description
        Me._err_source = Err.Source
        Return True

    End Function


End Class
