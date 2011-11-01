Partial Class sp_diamonds
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
        oTmpCombo._sqlstring = "select id, lang" & Session("user").language & "_longdescr from inv_STONETYPE_DIAM order by sortorder"
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
        oTmpCombo._sqlstring = "select id, lang" & Session("user").language & "_longdescr from inv_SHAPE_DIAM order by sortorder"
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


        '--- fill COLOR FROM combo
        oTmpCombo._combobox = Me.cmb_colorfrom
        oTmpCombo._sqlstring = "select id, lang" & Session("user").language & "_longdescr from inv_COLOR_DIAM order by sortorder"
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


        '--- fill CLARITY FROM combo
        oTmpCombo._combobox = Me.cmb_clarityfrom
        oTmpCombo._sqlstring = "select id, lang" & Session("user").language & "_longdescr from inv_CLARITY_DIAM order by sortorder"
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


        '--- fill COLOR TO combo
        oTmpCombo._combobox = Me.cmb_colorto
        oTmpCombo._sqlstring = "select id, lang" & Session("user").language & "_longdescr from inv_COLOR_DIAM order by sortorder"
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


        '--- fill CLARITY TO combo
        oTmpCombo._combobox = Me.cmb_clarityto
        oTmpCombo._sqlstring = "select id, lang" & Session("user").language & "_longdescr from inv_CLARITY_DIAM order by sortorder"
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

        '--- fill POLISH combo
        oTmpCombo._combobox = Me.cmb_polish
        oTmpCombo._sqlstring = "select id, lang" & Session("user").language & "_longdescr from inv_POLISH_DIAM order by sortorder"
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


        '--- fill SYMMETRY TO combo
        oTmpCombo._combobox = Me.cmb_symmetry
        oTmpCombo._sqlstring = "select id, lang" & Session("user").language & "_longdescr from inv_SYMMETRY_DIAM order by sortorder"
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


        '--- fill FLUORECENCE TO combo
        oTmpCombo._combobox = Me.cmb_fluorecence
        oTmpCombo._sqlstring = "select id, lang" & Session("user").language & "_longdescr from inv_FLUORECENCE_DIAM order by sortorder"
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


        '--- fill GIRDLE TO combo
        oTmpCombo._combobox = Me.cmb_girdle
        oTmpCombo._sqlstring = "select id, lang" & Session("user").language & "_longdescr from inv_GIRDLE_DIAM order by sortorder"
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


        '--- fill CULET TO combo
        oTmpCombo._combobox = Me.cmb_culet
        oTmpCombo._sqlstring = "select id, lang" & Session("user").language & "_longdescr from inv_CULET_DIAM order by sortorder"
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


        '--- fill REPORT TO combo
        oTmpCombo._combobox = Me.cmb_report
        oTmpCombo._sqlstring = "select id, lang" & Session("user").language & "_longdescr from inv_REPORT_DIAM order by sortorder"
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
        Dim oTmpSubPlate As ion_two.skl_diamond
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
        Me.txt_measure_to1.Text = oTmpSubPlate._measure1to
        Me.txt_measure_to2.Text = oTmpSubPlate._measure2to
        Me.txt_measure_to3.Text = oTmpSubPlate._measure3to
        Me.txt_depth.Text = oTmpSubPlate._depth
        Me.txt_tablewidth.Text = oTmpSubPlate._tablewidth
        Me.txt_fancycolor.Text = oTmpSubPlate.fancy_freetxt

        Me.cmb_stonetype.SelectedIndex = oTmpCombo.GetComboValue(Me.cmb_stonetype, oTmpSubPlate._stonetype_id)
        Me.cmb_colorfrom.SelectedIndex = oTmpCombo.GetComboValue(Me.cmb_colorfrom, oTmpSubPlate._color_id)
        Me.cmb_clarityfrom.SelectedIndex = oTmpCombo.GetComboValue(Me.cmb_clarityfrom, oTmpSubPlate._clarity_id)
        Me.cmb_colorto.SelectedIndex = oTmpCombo.GetComboValue(Me.cmb_colorto, oTmpSubPlate._colorto_id)
        Me.cmb_clarityto.SelectedIndex = oTmpCombo.GetComboValue(Me.cmb_clarityto, oTmpSubPlate._clarityto_id)
        Me.cmb_shape.SelectedIndex = oTmpCombo.GetComboValue(Me.cmb_shape, oTmpSubPlate._shape_id)
        Me.cmb_polish.SelectedIndex = oTmpCombo.GetComboValue(Me.cmb_polish, oTmpSubPlate._polish_id)
        Me.cmb_symmetry.SelectedIndex = oTmpCombo.GetComboValue(Me.cmb_symmetry, oTmpSubPlate._symmetry_id)
        Me.cmb_fluorecence.SelectedIndex = oTmpCombo.GetComboValue(Me.cmb_fluorecence, oTmpSubPlate._fluorecence_id)
        Me.cmb_girdle.SelectedIndex = oTmpCombo.GetComboValue(Me.cmb_girdle, oTmpSubPlate._girdle_id)
        Me.cmb_culet.SelectedIndex = oTmpCombo.GetComboValue(Me.cmb_culet, oTmpSubPlate._culet_id)
        Me.cmb_report.SelectedIndex = oTmpCombo.GetComboValue(Me.cmb_report, oTmpSubPlate._report_id)

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
            oLst_error.Items.Add("- A Diamond must have some WEIGHT")
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
        Dim oTmpSubPlate As New ion_two.skl_diamond

        oTmpSubPlate._id = Convert.ToInt32(Me.hid_subplate_id.Text)
        oTmpSubPlate._weight = System.Convert.ToDecimal(Me.txt_weight.Text)
        oTmpSubPlate._quantity = System.Convert.ToInt16(Me.txt_quantity.Text)
        oTmpSubPlate._measure1from = System.Convert.ToDecimal(Me.txt_measure1.Text)
        oTmpSubPlate._measure2from = System.Convert.ToDecimal(Me.txt_measure2.Text)
        oTmpSubPlate._measure3from = System.Convert.ToDecimal(Me.txt_measure3.Text)
        oTmpSubPlate._measure1to = System.Convert.ToDecimal(Me.txt_measure_to1.Text)
        oTmpSubPlate._measure2to = System.Convert.ToDecimal(Me.txt_measure_to2.Text)
        oTmpSubPlate._measure3to = System.Convert.ToDecimal(Me.txt_measure_to3.Text)
        oTmpSubPlate._depth = System.Convert.ToDecimal(Me.txt_depth.Text)
        oTmpSubPlate._tablewidth = System.Convert.ToDecimal(Me.txt_tablewidth.Text)
        oTmpSubPlate._stonetype_id = System.Convert.ToInt16(Me.cmb_stonetype.SelectedItem.Value)
        oTmpSubPlate._color_id = System.Convert.ToInt16(Me.cmb_colorfrom.SelectedItem.Value)
        oTmpSubPlate._clarity_id = System.Convert.ToInt16(Me.cmb_clarityfrom.SelectedItem.Value)
        oTmpSubPlate._colorto_id = System.Convert.ToInt16(Me.cmb_colorto.SelectedItem.Value)
        oTmpSubPlate._clarityto_id = System.Convert.ToInt16(Me.cmb_clarityto.SelectedItem.Value)
        oTmpSubPlate._shape_id = System.Convert.ToInt16(Me.cmb_shape.SelectedItem.Value)
        oTmpSubPlate._polish_id = System.Convert.ToInt16(Me.cmb_polish.SelectedItem.Value)
        oTmpSubPlate._symmetry_id = System.Convert.ToInt16(Me.cmb_symmetry.SelectedItem.Value)
        oTmpSubPlate._fluorecence_id = System.Convert.ToInt16(Me.cmb_fluorecence.SelectedItem.Value)
        oTmpSubPlate._girdle_id = System.Convert.ToInt16(Me.cmb_girdle.SelectedItem.Value)
        oTmpSubPlate._culet_id = System.Convert.ToInt16(Me.cmb_culet.SelectedItem.Value)
        oTmpSubPlate._report_id = System.Convert.ToInt16(Me.cmb_report.SelectedItem.Value)
        oTmpSubPlate.fancy_freetxt = Me.txt_fancycolor.Text

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
