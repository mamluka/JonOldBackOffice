Imports System.Xml
Partial Class sp_jewelry
    Inherits iFoundation.wsc_usercontrol


    Public nSubType As Int16
    Public extra_metal_list_index As Int16
    Public extra_stone_list_index As Int16
    Public je_load_index As Int16 = 0







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

        ''   If Me.extra_schema.ses > 0 Then

        ''  End If
        Dim work_mode As WebControls.Label = Me.Parent.FindControl("hid_workmode")
        If work_mode.Text = "2" Then
            If Not Page.IsPostBack Then
                Me.LoadExtraSchemas()
                Me.LoadJewelExtendedSchemas()

            End If

            Me.CreateControlBySchemaID(Convert.ToInt32(Me.extra_schema.SelectedValue))
            Me.je_list.TabIndex = 2

            If Me.je_load_index = 0 Then
                Me.je_list.SelectedIndex = 2
                Me.CreateControlByJewelExtendedSchemaID(Convert.ToInt32(Me.je_list.SelectedValue))
            End If
            ''Else


            If Not Page.IsPostBack Then
                Me.je_list.SelectedIndex = Me.je_list.TabIndex
            End If
        Else
            If Me.Visible = True Then
                If Me.extra_schema.Items.Count = 0 Then
                    Me.LoadExtraSchemas()
                    Me.LoadJewelExtendedSchemas()
                End If

                Me.CreateControlBySchemaID(Convert.ToInt32(Me.extra_schema.SelectedValue))
                Me.je_list.SelectedIndex = 2
                Me.CreateControlByJewelExtendedSchemaID(2)
            End If
        End If

    End Sub

    Public Function load_combos() As Boolean
        On Error GoTo ErrorHandler
        Dim bError As Boolean = False

        Dim oTmpCombo As New iFunctions.cls_combo
        oTmpCombo._connection_string = Application("config").connection_string
        oTmpCombo._dbtype = Application("config").connection_string_type


        '--- fill JEWELTYPE combo
        oTmpCombo._combobox = Me.cmb_jeweltype
        oTmpCombo._sqlstring = "select id, lang" & Session("user").language & "_longdescr from inv_JEWELTYPE_JEWEL order by sortorder"
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


        '--- fill JEWELSUBTYPE combo
        oTmpCombo._combobox = Me.cmb_jewelsubtype
        oTmpCombo._sqlstring = "select id, lang" & Session("user").language & "_longdescr from inv_JEWELSUBTYPE_JEWEL where jeweltype_id= 2 order by sortorder"
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


        '--- fill METAL combo
        oTmpCombo._combobox = Me.cmb_metal
        oTmpCombo._sqlstring = "select id, lang" & Session("user").language & "_longdescr from inv_METAL_JEWEL order by sortorder"
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


        '--- fill MIDDLESTONE combo
        oTmpCombo._combobox = Me.cmb_middlestone
        oTmpCombo._sqlstring = "select id, lang" & Session("user").language & "_longdescr from inv_MIDDLESTONE_JEWEL order by sortorder"
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


        '--- fill BRAND combo
        oTmpCombo._combobox = Me.cmb_brand
        oTmpCombo._sqlstring = "select id, lang" & Session("user").language & "_longdescr from inv_BRAND_JEWEL order by sortorder"
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
        oTmpCombo._sqlstring = "select id, lang" & Session("user").language & "_longdescr from inv_REPORT_JEWEL order by sortorder"
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

        '--- fill COLLECTION combo
        oTmpCombo._combobox = Me.cmb_collection
        oTmpCombo._sqlstring = "select id, lang" & Session("user").language & "_longdescr from inv_COLLECTION_JEWEL order by sortorder"
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

        '--- fill SETTING combo
        oTmpCombo._combobox = Me.cmb_setting
        oTmpCombo._sqlstring = "select id, lang" & Session("user").language & "_longdescr from inv_SETTING_JEWEL order by sortorder"
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
        '-- fill the c/s type combo
        oTmpCombo._combobox = Me.ext_c_type
        oTmpCombo._sqlstring = "select id, lang" & Session("user").language & "_longdescr from inv_MIDDLESTONE_JEWEL order by sortorder"
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
        Me.ext_c_type.Items.Add("Yellow Sapphire")
        Me.ext_c_type.Items.Add("Pink Sapphire")

        oTmpCombo._combobox = Me.ext_s_type
        oTmpCombo._sqlstring = "select id, lang" & Session("user").language & "_longdescr from inv_MIDDLESTONE_JEWEL order by sortorder"
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

        Me.ext_s_type.Items.Add("Yellow Sapphire")
        Me.ext_s_type.Items.Add("Pink Sapphire")


        oTmpCombo._combobox = Me.extra_metal_type
        oTmpCombo._sqlstring = "select id, lang" & Session("user").language & "_longdescr from inv_METAL_JEWEL order by sortorder"
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
        oTmpCombo._combobox = Me.ext_s_cut
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

        oTmpCombo._combobox = Me.ext_c_cut
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
        Dim oTmpSubPlate As ion_two.skl_jewelry
        oTmpSubPlate = oSkelet._subplate

        '--- set combo functions
        Dim oTmpCombo As New iFunctions.cls_combo

        '--- Set the ID of the loaded item
        Me.hid_subplate_id.Text = oTmpSubPlate._id
        Me.hid_jewel_extended_id.Text = oTmpSubPlate._jewel_extended.id.ToString
        Me.txt_weight.Text = oTmpSubPlate._weight
        Me.txt_size.Text = oTmpSubPlate._size
        Me.txt_relateditem_id.Text = oTmpSubPlate._relateditem_id
        Me.txt_middlestone_desc.Text = oTmpSubPlate._middlestone_desc
        Me.cmb_jeweltype.SelectedIndex = GetComboValue(Me.cmb_jeweltype, oTmpSubPlate._jewelrytype_id)
        '---
        Me.regenerate_jewelsubtype(oTmpSubPlate._jewelrytype_id)
        Me.cmb_jewelsubtype.SelectedIndex = GetComboValue(Me.cmb_jewelsubtype, oTmpSubPlate._jewelrysubtype_id)
        Me.cmb_metal.SelectedIndex = GetComboValue(Me.cmb_metal, oTmpSubPlate._metal_id)
        Me.cmb_middlestone.SelectedIndex = GetComboValue(Me.cmb_middlestone, oTmpSubPlate._middlestone_id)
        Me.cmb_brand.SelectedIndex = GetComboValue(Me.cmb_brand, oTmpSubPlate._brand_id)
        Me.cmb_report.SelectedIndex = GetComboValue(Me.cmb_report, oTmpSubPlate._report_id)
        Me.cmb_setting.SelectedIndex = GetComboValue(Me.cmb_setting, oTmpSubPlate._setting_id)
        Me.cmb_collection.SelectedIndex = GetComboValue(Me.cmb_collection, oTmpSubPlate._collection_id)
        Me.chk_anniversary.Checked = oTmpSubPlate._anniversary
        Me.chk_engagement.Checked = oTmpSubPlate._engagement
        Dim oextra As New ion_two.cls_jewerly_extra
        'oextra.load_extra_metal(oTmpSubPlate._extra_metal, Me.extra_metal_list)
        'oextra.load_extra_stone(oTmpSubPlate._extra_stone, Me.extra_stone_list)
        oextra.DecodeExtraStoneString(oTmpSubPlate._extra_stone, Me.extra_list)
        oextra.get_stone_extended_string(oTmpSubPlate._stone_extended)
        Me.extra_metal_delta.Text = oextra.DecodeMetalDelta(oTmpSubPlate._extra_metal)

        ''load the stone extended stuff

        Me.ext_c_desc.Text = oextra.c_desc
        Me.ext_s_desc.Text = oextra.s_desc
        Me.ext_c_type.SelectedIndex = Me.ext_c_type.Items.IndexOf(Me.ext_c_type.Items.FindByText(oextra.c_type))
        Me.ext_c_cut.SelectedIndex = Me.ext_c_cut.Items.IndexOf(Me.ext_c_cut.Items.FindByText(oextra.c_cut))
        Me.ext_s_cut.SelectedIndex = Me.ext_s_cut.Items.IndexOf(Me.ext_s_cut.Items.FindByText(oextra.s_cut))
        Me.ext_s_type.SelectedIndex = Me.ext_s_type.Items.IndexOf(Me.ext_s_type.Items.FindByText(oextra.s_type))

        Me.ext_c_desc.Text = oTmpSubPlate._jewel_extended.cs_desc
        Me.ext_s_desc.Text = oTmpSubPlate._jewel_extended.ss_desc
        Me.ext_c_type.SelectedIndex = Me.ext_c_type.Items.IndexOf(Me.ext_c_type.Items.FindByText(oTmpSubPlate._jewel_extended.cs_type))
        Me.ext_c_cut.SelectedIndex = Me.ext_c_cut.Items.IndexOf(Me.ext_c_cut.Items.FindByText(oTmpSubPlate._jewel_extended.cs_cut))
        Me.ext_s_cut.SelectedIndex = Me.ext_s_cut.Items.IndexOf(Me.ext_s_cut.Items.FindByText(oTmpSubPlate._jewel_extended.ss_cut))
        Me.ext_s_type.SelectedIndex = Me.ext_s_type.Items.IndexOf(Me.ext_s_type.Items.FindByText(oTmpSubPlate._jewel_extended.ss_type))





        'If oTmpSubPlate.jewel_title = "" Then
        '    Dim oTmpInventory As New ion_two.cls_inventory_lgc
        '    oTmpInventory._connection_string = Application("config").connection_string
        '    oTmpInventory._dbtype = Application("config").connection_string_type

        '    Dim oPlate As New ion_two.skl_lst_inventory
        '    oTmpInventory.load(oSkelet._id, oPlate, Session("pictures"))

        '    Me.txt_title.Text = oPlate._item_description
        'Else
        '    Me.txt_title.Text = oTmpSubPlate.jewel_title
        '    '--- Map subplate
        'End If


        If oSkelet.opthash.ContainsKey("bend_from") Then
            Me.txt_bend_from.Text = oSkelet.opthash("bend_from")
            Me.txt_bend_to.Text = oSkelet.opthash("bend_to")
        End If

        If oSkelet.opthash.ContainsKey("ebaytitle") Then
            Me.txt_ebay_title.Text = oSkelet.opthash("ebaytitle")
        End If

        'If oSkelet.opthash.ContainsKey("defaulmodel") Then
        '    Me.chk_default_model.Checked = True
        'End If


        Me.txt_title.Text = oTmpSubPlate.jewel_title


        '' Dim odesc As New ion_two.cons_description
        '' odesc.construct(oplate

        ''get the stone echange
        If oTmpSubPlate.se_relateditem_id > 0 Then
            Me.chk_stone_exchange.Checked = True
            Me.txt_stone_exchange_itemid.Text = Convert.ToString(oTmpSubPlate.se_relateditem_id)
        End If

        '' If oTmpSubPlate._jewel_extended <> "" Then

        Dim ostringfunc As New iFunctions.cls_string
        Dim je_hash As New Hashtable  ''= ostringfunc.HashfromString(oTmpSubPlate.jewel_extended, "|", "::")

        je_hash("je_stoneweight") = oTmpSubPlate._jewel_extended.cs_weight
        je_hash("je_sidestoneweight") = oTmpSubPlate._jewel_extended.ss_weight
        je_hash("je_totalstoneweight") = oTmpSubPlate._jewel_extended.total_weight
        je_hash("je_stonew") = oTmpSubPlate._jewel_extended.measure_1
        je_hash("je_stoneh") = oTmpSubPlate._jewel_extended.measure_2
        je_hash("je_stoned") = oTmpSubPlate._jewel_extended.measure_3
        je_hash("je_stonecolor") = oTmpSubPlate._jewel_extended.color
        je_hash("je_stonecolorfree") = oTmpSubPlate._jewel_extended.color_freetxt
        je_hash("je_stoneclarityfree") = oTmpSubPlate._jewel_extended.clarity_freetxt
        je_hash("je_stoneclarity") = oTmpSubPlate._jewel_extended.clarity
        je_hash("je_defaultmodel") = oTmpSubPlate._jewel_extended.default_model
        je_hash("je_sidestonescount") = oTmpSubPlate._jewel_extended.ss_count
        je_hash("je_centerstonecount") = oTmpSubPlate._jewel_extended.cs_count
        je_hash("je_ssstoneclarity") = oTmpSubPlate._jewel_extended.ss_clarity
        je_hash("je_ssstonecolor") = oTmpSubPlate._jewel_extended.ss_color
        je_hash("je_sscolorfree") = oTmpSubPlate._jewel_extended.ss_color_freetxt
        je_hash("je_ssclarityfree") = oTmpSubPlate._jewel_extended.ss_clarity_freetxt
        je_hash("sid") = 2

        Me.CreateControlByJewelExtendedSchemaID(Convert.ToInt32(je_hash("sid")))
        Me.je_list.TabIndex = Convert.ToInt32(je_hash("sid"))

        Me.je_load_index = Convert.ToInt32(je_hash("sid"))
        ''  Me.CreateControlByJewelExtendedSchemaID(Convert.ToInt32(Me.je_list.SelectedValue))

        For Each control As System.Web.UI.Control In Me.je_panel.Controls

            If control.GetType().Name = "TextBox" Then
                Dim tmptext As WebControls.TextBox = schema_controls.FindControl(control.ID)
                If je_hash.ContainsKey(control.ID.Substring(5)) Then
                    tmptext.Text = je_hash(control.ID.Substring(5))
                End If
            End If

            If control.GetType().Name = "DropDownList" Then
                Dim tmpdrop As WebControls.DropDownList = schema_controls.FindControl(control.ID)
                If je_hash.ContainsKey(control.ID.Substring(5)) Then
                    tmpdrop.SelectedIndex = tmpdrop.Items.IndexOf(tmpdrop.Items.FindByText(je_hash(control.ID.Substring(5))))
                End If
            End If
            If control.GetType().Name = "CheckBox" Then
                Dim tmpdrop As WebControls.CheckBox = schema_controls.FindControl(control.ID)
                If je_hash.ContainsKey(control.ID.Substring(5)) Then
                    If je_hash(control.ID.Substring(5)) = "1" Then
                        tmpdrop.Checked = True
                    End If
                End If
            End If
            ''Me.extra_list.Items.Add(control.ID)
        Next
        ''  End If
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

    Private Sub cmb_jeweltype_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmb_jeweltype.SelectedIndexChanged
        On Error GoTo ErrorHandler
        Dim bError As Boolean = False

        Dim oTmpCombo As New iFunctions.cls_combo
        oTmpCombo._connection_string = Application("config").connection_string
        oTmpCombo._dbtype = Application("config").connection_string_type


        '--- fill JEWELTYPE combo
        oTmpCombo._combobox = Me.cmb_jewelsubtype
        oTmpCombo._sqlstring = "select id, lang" & Session("user").language & "_longdescr from inv_JEWELSUBTYPE_JEWEL where jeweltype_id= " & Me.cmb_jeweltype.SelectedItem.Value & " order by sortorder"
        oTmpCombo._textfield = "lang" & Session("user").language & "_longdescr"
        oTmpCombo._valuefield = "id"
        oTmpCombo._addrow = ""
        bError = oTmpCombo.BindCombo()
        If bError Then
            Session("o_error")._Err_Number = Me._err_number
            Session("o_error")._Err_Description = Me._err_description
            Session("o_error")._Err_Source = Me._err_source
            Session("o_error")._Err_Module = Me.Request.CurrentExecutionFilePath
            Session("o_error")._Err_Call = "cmb_jeweltype_SelectedIndexChanged [BindCombo]"
            Server.Transfer("/aspxerror.aspx")
        End If


        '--- Release
        oTmpCombo = Nothing


        Exit Sub

ErrorHandler:
        '--- Reporting Error
        Session("o_error")._Err_Number = Err.Number
        Session("o_error")._Err_Description = Err.Description
        Session("o_error")._Err_Source = Err.Source
        Session("o_error")._Err_Module = Me.Request.CurrentExecutionFilePath
        Session("o_error")._Err_Call = "cmb_jeweltype_SelectedIndexChanged [ErrorHandler]"
        Server.Transfer("/aspxerror.aspx")


    End Sub

    Public Sub regenerate_jewelsubtype(ByVal nSubType As Int32)
        On Error GoTo ErrorHandler
        Dim bError As Boolean = False

        Dim oTmpCombo As New iFunctions.cls_combo
        oTmpCombo._connection_string = Application("config").connection_string
        oTmpCombo._dbtype = Application("config").connection_string_type


        '--- fill JEWELTYPE combo
        oTmpCombo._combobox = Me.cmb_jewelsubtype
        oTmpCombo._sqlstring = "select id, lang" & Session("user").language & "_longdescr from inv_JEWELSUBTYPE_JEWEL where jeweltype_id= " & nSubType & " order by sortorder"
        oTmpCombo._textfield = "lang" & Session("user").language & "_longdescr"
        oTmpCombo._valuefield = "id"
        oTmpCombo._addrow = ""
        bError = oTmpCombo.BindCombo()
        If bError Then
            Session("o_error")._Err_Number = Me._err_number
            Session("o_error")._Err_Description = Me._err_description
            Session("o_error")._Err_Source = Me._err_source
            Session("o_error")._Err_Module = Me.Request.CurrentExecutionFilePath
            Session("o_error")._Err_Call = "regenerate_jewelsubtype [BindCombo]"
            Server.Transfer("/aspxerror.aspx")
        End If

        '--- Release
        oTmpCombo = Nothing

        Exit Sub

ErrorHandler:
        '--- Reporting Error
        Session("o_error")._Err_Number = Err.Number
        Session("o_error")._Err_Description = Err.Description
        Session("o_error")._Err_Source = Err.Source
        Session("o_error")._Err_Module = Me.Request.CurrentExecutionFilePath
        Session("o_error")._Err_Call = "regenerate_jewelsubtype [ErrorHandler]"
        Server.Transfer("/aspxerror.aspx")

    End Sub

    Public Function validate_form(ByRef bValid As Boolean, ByRef oLst_error As System.Web.UI.WebControls.ListBox) As Boolean
        On Error GoTo ErrorHandler
        Dim bError As Boolean = False

        '--- We assume everything is OK until we find a problem
        bValid = True

        If Not IsNumeric(Me.txt_weight.Text) Then
            oLst_error.Items.Add("- A Jewelry WEIGHT must have a numeric value")
            bValid = False
        End If

        'If Not IsNumeric(Me.txt_size.Text) Then
        '    oLst_error.Items.Add("- A Jewelry SIZE must have a numeric value")
        '    bValid = False
        'End If

        'if me.txt_relateditem_id

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
        Dim oTmpSubPlate As New ion_two.skl_jewelry

        oTmpSubPlate._id = Convert.ToInt32(Me.hid_subplate_id.Text)
        oTmpSubPlate._weight = System.Convert.ToDecimal(Me.txt_weight.Text)
        oTmpSubPlate._size = Me.txt_size.Text
        oTmpSubPlate._relateditem_id = System.Convert.ToDecimal(Me.txt_relateditem_id.Text)
        oTmpSubPlate._jewelrytype_id = System.Convert.ToInt16(Me.cmb_jeweltype.SelectedItem.Value)
        oTmpSubPlate._jewelrysubtype_id = System.Convert.ToInt16(Me.cmb_jewelsubtype.SelectedItem.Value)
        oTmpSubPlate._metal_id = System.Convert.ToInt16(Me.cmb_metal.SelectedItem.Value)
        oTmpSubPlate._middlestone_id = System.Convert.ToInt16(Me.cmb_middlestone.SelectedItem.Value)
        oTmpSubPlate._brand_id = System.Convert.ToInt16(Me.cmb_brand.SelectedItem.Value)
        oTmpSubPlate._report_id = System.Convert.ToInt16(Me.cmb_report.SelectedItem.Value)
        oTmpSubPlate._setting_id = System.Convert.ToInt16(Me.cmb_setting.SelectedItem.Value)
        oTmpSubPlate._collection_id = System.Convert.ToInt16(Me.cmb_collection.SelectedItem.Value)

        Dim ojewel_extended As New ion_two.skl_jewel_extended
        oTmpSubPlate._jewel_extended = ojewel_extended

        If Me.ext_c_desc.Text <> "" Then '' check if extra info presend
            ''           If Me.txt_middlestone_desc.Text = "" Then ''check for override
            oTmpSubPlate._middlestone_desc = Me.ext_c_desc.Text + " " + Me.ext_c_type.SelectedItem.Text + ", " + Me.ext_c_cut.SelectedItem.Text
            ''   Else
            ''     oTmpSubPlate._middlestone_desc = Convert.ToString(Me.txt_middlestone_desc.Text)
            '' End If
            '' Else
            ''     oTmpSubPlate._middlestone_desc = Convert.ToString(Me.txt_middlestone_desc.Text)
        End If

        oTmpSubPlate._anniversary = Me.chk_anniversary.Checked
        oTmpSubPlate._engagement = Me.chk_engagement.Checked
        '''use the oextra object to make the string

        Dim oExtra As New ion_two.cls_jewerly_extra
        If Me.extra_list.Items.Count > 0 Then
            oTmpSubPlate._extra_stone = oExtra.EncodeExtraStoneString(Me.extra_list)
        End If
        If Me.extra_metal_delta.Text <> "0" And Me.extra_metal_delta.Text <> "" Then
            oTmpSubPlate._extra_metal = oExtra.EncodeMetalDelta(Me.extra_metal_delta.Text)
        End If

        'If Me.extra_metal_list.Items.Count <> 0 Then
        '    ''            Me.extra_metal_list.Items.Add(Me.cmb_metal.SelectedItem.Text + " - " + oExtra.get_unset_metalprice(Convert.ToDecimal(Me.txt_weight.Text), Me.cmb_metal.SelectedItem.Text) + "$")
        '    oTmpSubPlate._extra_metal = oExtra.set_extra_item(extra_metal_list)
        'Else
        '    oTmpSubPlate._extra_metal = "None"
        'End If
        'If Me.extra_stone_list.Items.Count <> 0 Then
        '    oTmpSubPlate._extra_stone = oExtra.set_extra_item(extra_stone_list)
        'Else
        '    oTmpSubPlate._extra_stone = "None"
        'End If
        ''check if the extended info is present



        If Not ((Me.ext_c_desc.Text = "") And (Me.ext_s_desc.Text = "")) Then '' if totally empty
            If (Me.ext_c_desc.Text <> "") And (Me.ext_s_desc.Text <> "") Then
                oTmpSubPlate._stone_extended = oExtra.set_stone_extended_string(ext_c_desc.Text, ext_c_type.SelectedItem.Text, ext_c_cut.SelectedItem.Text, ext_s_desc.Text, ext_s_type.SelectedItem.Text, ext_s_cut.SelectedItem.Text)
            ElseIf (Me.ext_c_desc.Text <> "") And (Me.ext_s_desc.Text = "") Then
                oTmpSubPlate._stone_extended = oExtra.set_stone_extended_string(ext_c_desc.Text, ext_c_type.SelectedItem.Text, ext_c_cut.SelectedItem.Text, "None", ext_s_type.SelectedItem.Text, ext_s_cut.SelectedItem.Text)
            ElseIf (Me.ext_c_desc.Text = "") And (Me.ext_s_desc.Text <> "") Then
                oTmpSubPlate._stone_extended = oExtra.set_stone_extended_string("None", ext_c_type.SelectedItem.Text, ext_c_cut.SelectedItem.Text, ext_s_desc.Text, ext_s_type.SelectedItem.Text, ext_s_cut.SelectedItem.Text)




            End If
        Else
            ''none is
            oTmpSubPlate._stone_extended = "None"
        End If

        

                oTmpSubPlate._jewel_extended.cs_desc = Me.ext_c_desc.Text
                oTmpSubPlate._jewel_extended.cs_cut = ext_c_cut.SelectedItem.Text
                oTmpSubPlate._jewel_extended.cs_type = ext_c_type.SelectedItem.Text


                oTmpSubPlate._jewel_extended.ss_desc = Me.ext_s_desc.Text
                oTmpSubPlate._jewel_extended.ss_cut = ext_s_cut.SelectedItem.Text
                oTmpSubPlate._jewel_extended.ss_type = ext_s_type.SelectedItem.Text

        If ext_c_type.SelectedItem.Text.IndexOf("Diamond") = -1 Then
            oTmpSubPlate._jewel_extended.has_sidestones = True
        End If



          


        oTmpSubPlate._jewel_extended.is_gemstone = True




        ''---stone exchange
        If Me.chk_stone_exchange.Checked Then
            If IsNumeric(Me.txt_stone_exchange_itemid.Text) Then
                oTmpSubPlate.se_relateditem_id = Convert.ToInt32(Me.txt_stone_exchange_itemid.Text)
                ''write the new stuff to the cs desc XX stonetypes alvaible<br>shape

                Dim oSefunc As New ion_two.cls_stone_exchange
                oSefunc.Conn_String = Application("config").connection_string
                oSefunc.db_type = Application("config").connection_string_type
                oSefunc.picture_obj = New ion_two.cls_pictures
                oSefunc.is_dealer = False

                ''get the type and color and stuff of the related stone
                Dim stone_type, stone_shape, stone_color As String
                Dim stone_weight, stone_price As Decimal


                ''load
                oSefunc.load_stone_exchange_byid(oTmpSubPlate.se_relateditem_id, stone_type, stone_shape, stone_weight, stone_color, stone_price)

                ''set sql str
                If InStr(stone_color.ToLower, "pink") > 0 And stone_type = "Sapphire" Then
                    oSefunc.make_sql_str(stone_type, stone_shape, stone_weight, 1)
                ElseIf InStr(stone_color.ToLower, "yellow") > 0 And stone_type = "Sapphire" Then
                    oSefunc.make_sql_str(stone_type, stone_shape, stone_weight, 2)
                Else
                    oSefunc.make_sql_str(stone_type, stone_shape, stone_weight, 0)
                End If
                ''load collection of the table
                oSefunc.make_table()

                'Me.ext_c_desc.Text = oSefunc.SE_collection.Count.ToString + " " + stone_type + " available<br>"
                'Me.ext_c_desc.Text = Me.ext_c_desc.Text.Replace("Sapphire", "Sapphires")
                'Me.ext_c_desc.Text = Me.ext_c_desc.Text.Replace("Ruby", "Rubies")
                'Me.ext_c_desc.Text = Me.ext_c_desc.Text.Replace("Emerald", "Emeralds")
            End If
        End If

        oTmpSubPlate.jewel_title = Me.txt_title.Text

        ''--jewel extended
        If Me.je_list.SelectedIndex > 0 Then
            Dim key_val As New ArrayList


            '
            '' key_val.Add("sid::" + Me.je_list.SelectedValue)
            oTmpSubPlate._jewel_extended.id = Convert.ToInt32(Me.hid_jewel_extended_id.Text)
            oTmpSubPlate._jewel_extended.inventory_id = oTmpSubPlate._inventory_id


            For Each control As System.Web.UI.Control In Me.je_panel.Controls
                ''sid::2|je_stoneweight::0.90|je_sidestoneweight::1.25|je_totalstoneweight::2.15|je_stonew::|je_stoneh::|je_stoned::|je_stonecolor::D|je_stonecolorfree::|je_stoneclarity::F|je_stoneclarityfree::|je_defaultmodel::1
                If control.GetType().Name = "TextBox" Or control.GetType().Name = "DropDownList" Or control.GetType().Name = "CheckBox" Then

                    Select Case control.ID.Substring(5)
                        Case "je_stoneweight"
                            Dim tmptext As WebControls.TextBox = schema_controls.FindControl(control.ID)
                            oTmpSubPlate._jewel_extended.cs_weight = Convert.ToDecimal(tmptext.Text)
                        Case "je_sidestoneweight"
                            Dim tmptext As WebControls.TextBox = schema_controls.FindControl(control.ID)
                            oTmpSubPlate._jewel_extended.ss_weight = Convert.ToDecimal(tmptext.Text)
                        Case "je_totalstoneweight"
                            Dim tmptext As WebControls.TextBox = schema_controls.FindControl(control.ID)
                            oTmpSubPlate._jewel_extended.total_weight = Convert.ToDecimal(tmptext.Text)
                        Case "je_stonew"
                            Dim tmptext As WebControls.TextBox = schema_controls.FindControl(control.ID)
                            oTmpSubPlate._jewel_extended.measure_1 = Convert.ToDecimal(tmptext.Text)
                        Case "je_stoneh"
                            Dim tmptext As WebControls.TextBox = schema_controls.FindControl(control.ID)
                            oTmpSubPlate._jewel_extended.measure_2 = Convert.ToDecimal(tmptext.Text)
                        Case "je_stoned"
                            Dim tmptext As WebControls.TextBox = schema_controls.FindControl(control.ID)
                            oTmpSubPlate._jewel_extended.measure_3 = Convert.ToDecimal(tmptext.Text)
                        Case "je_stonecolor"
                            Dim tmptext As WebControls.DropDownList = schema_controls.FindControl(control.ID)
                            oTmpSubPlate._jewel_extended.color = tmptext.SelectedItem.Text
                        Case "je_stonecolorfree"
                            Dim tmptext As WebControls.TextBox = schema_controls.FindControl(control.ID)
                            oTmpSubPlate._jewel_extended.color_freetxt = tmptext.Text
                        Case "je_stoneclarity"
                            Dim tmptext As WebControls.DropDownList = schema_controls.FindControl(control.ID)
                            oTmpSubPlate._jewel_extended.clarity = tmptext.SelectedItem.Text
                        Case "je_stoneclarityfree"
                            Dim tmptext As WebControls.TextBox = schema_controls.FindControl(control.ID)
                            oTmpSubPlate._jewel_extended.clarity_freetxt = tmptext.Text
                        Case "je_sscolorfree"
                            Dim tmptext As WebControls.TextBox = schema_controls.FindControl(control.ID)
                            oTmpSubPlate._jewel_extended.ss_color_freetxt = tmptext.Text
                        Case "je_ssclarityfree"
                            Dim tmptext As WebControls.TextBox = schema_controls.FindControl(control.ID)
                            oTmpSubPlate._jewel_extended.ss_clarity_freetxt = tmptext.Text


                        Case "je_sidestonescount"
                            Dim tmptext As WebControls.TextBox = schema_controls.FindControl(control.ID)
                            oTmpSubPlate._jewel_extended.ss_count = tmptext.Text
                            If Convert.ToInt32(tmptext.Text) > 0 Then
                                oTmpSubPlate._jewel_extended.has_sidestones = True
                            End If
                        Case "je_centerstonecount"
                            Dim tmptext As WebControls.TextBox = schema_controls.FindControl(control.ID)
                            oTmpSubPlate._jewel_extended.cs_count = tmptext.Text

                        Case "je_ssstonecolor"
                            Dim tmptext As WebControls.DropDownList = schema_controls.FindControl(control.ID)
                            oTmpSubPlate._jewel_extended.ss_color = tmptext.SelectedItem.Text
                        Case "je_ssstoneclarity"
                            Dim tmptext As WebControls.DropDownList = schema_controls.FindControl(control.ID)
                            oTmpSubPlate._jewel_extended.ss_clarity = tmptext.SelectedItem.Text
                        Case "je_defaultmodel"
                            Dim tmpcheck As WebControls.CheckBox = schema_controls.FindControl(control.ID)
                            If tmpcheck.Checked Then
                                key_val.Add(control.ID.Substring(5) + "::1")
                                oTmpSubPlate._jewel_extended.default_model = True
                            End If



                    End Select

                End If     'If control.GetType().Name = "TextBox" Then

                '    Dim tmptext As WebControls.TextBox = schema_controls.FindControl(control.ID)
                '    key_val.Add(control.ID.Substring(5) + "::" + tmptext.Text)
                'End If
                'If control.GetType().Name = "DropDownList" Then
                '    Dim tmptext As WebControls.DropDownList = schema_controls.FindControl(control.ID)

                '    key_val.Add(control.ID.Substring(5) + "::" + tmptext.SelectedItem.Text)
                'End If
                'If control.GetType().Name = "CheckBox" Then
                '    Dim tmpcheck As WebControls.CheckBox = schema_controls.FindControl(control.ID)
                '    If tmpcheck.Checked Then
                '        key_val.Add(control.ID.Substring(5) + "::1")
                '    End If
                'End If


                ''Me.extra_list.Items.Add(control.ID)
            Next


            ''remove when change back
            ''  Dim valstr = Join(key_val.ToArray, "|")

            '' oTmpSubPlate.jewel_extended = valstr
        End If

        oSkelet._subplate = oTmpSubPlate

        Return False
        Exit Function

ErrorHandler:
        Me._err_number = Err.Number
        Me._err_description = Err.Description
        Me._err_source = Err.Source
        Return True

    End Function

    Private Sub txt_relateditem_id_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_relateditem_id.TextChanged
        On Error GoTo ErrorHandler
        Dim bError As Boolean = False


        '--- Load plate
        Dim oDataTable As New ion_two.skl_lst_inventory
        Dim oTmpInventory As New ion_two.cls_inventory_lgc
        oTmpInventory._connection_string = Application("config").connection_string
        oTmpInventory._dbtype = Application("config").connection_string_type

        If Me.txt_relateditem_id.Text = "0" Or Me.txt_relateditem_id.Text = "" Then
            Me.txt_relateditem_id.Text = "0"
            Exit Sub
        End If
        bError = oTmpInventory.load(Me.txt_relateditem_id.Text, oDataTable)
        If bError Then
            Me._err_number = oTmpInventory._err_number
            Me._err_description = oTmpInventory._err_description
            Me._err_source = oTmpInventory._err_source
        End If


        Dim nCarat As Decimal = oDataTable._subplate._weight
        Dim cCarat_regular As String = ""
        Dim cCarat_round As String = ""

        '--- Regular NOT rounded results
        cCarat_regular = Format(nCarat, "##,##0.00")

        '--- Round results if needed
        cCarat_round = Format(Decimal.Round(nCarat, 1), "##,##0.00")
        Dim nLen As Int16 = Len(cCarat_round)

        If Mid(cCarat_round, nLen - 2, nLen) = ".00" Then
            cCarat_round = Mid(cCarat_round, 1, nLen - 3)

        ElseIf Mid(cCarat_round, nLen - 1, nLen) = ".0" Then
            cCarat_round = Mid(cCarat_round, 1, nLen - 2)

        ElseIf Mid(cCarat_round, nLen, nLen) = "0" Then
            cCarat_round = Mid(cCarat_round, 1, nLen - 1)

        End If
        ''  cCarat_round = cCarat_round + " (" + Format(Decimal.Round(nCarat, 1), "##,##0.00") + ")"

        Select Case oDataTable._platetype
            Case 1 '' diamond
                Me.ext_c_desc.Text = cCarat_round + " Ct. - " + oDataTable._subplate._colorfrom + "/" + oDataTable._subplate._clarityfrom
                Me.ext_c_type.SelectedIndex = Me.ext_c_type.Items.IndexOf(Me.ext_c_type.Items.FindByText(oDataTable._category_name))
                Me.ext_c_cut.SelectedIndex = Me.ext_c_cut.Items.IndexOf(Me.ext_c_cut.Items.FindByText(oDataTable._subplate._shape))
            Case 2 '' gemstone
                Me.ext_c_desc.Text = cCarat_round + " Ct. " + oDataTable._subplate._origin
                If oDataTable._subplate._enhancement = "NOT treated or enhanced in any way!" Then Me.ext_c_desc.Text += "<br><b>Not Heated</b>"
                If oDataTable._subplate._report <> "-" Then Me.ext_c_desc.Text += "<br>Certified"
                Me.ext_c_type.SelectedIndex = Me.ext_c_type.Items.IndexOf(Me.ext_c_type.Items.FindByText(oDataTable._category_name))
                Me.ext_c_cut.SelectedIndex = Me.ext_c_cut.Items.IndexOf(Me.ext_c_cut.Items.FindByText(oDataTable._subplate._shape))

        End Select





        '--- Release
        oTmpInventory = Nothing

        ''--- Goto constructing description
        'If oDataTable._id > 0 Then
        '    bError = Me.Construct(oDataTable)
        '    If bError Then
        '        Me._err_number = Err.Number
        '        Me._err_description = Err.Description
        '        Me._err_source = Err.Source
        '    End If
        'End If




        ''---
        'If IsNumeric(Me.txt_relateditem_id.Text) Then
        '    Dim oConstructor As New ion_two.cons_description
        '    oConstructor._connection_string = Application("config").connection_string
        '    oConstructor._dbtype = Application("config").connection_string_type
        '    bError = oConstructor.construct(Convert.ToInt32(Me.txt_relateditem_id.Text))
        '    If bError Then
        '        If oConstructor._err_number = 7006 Then
        '            bError = False
        '        Else
        '            Session("o_error")._Err_Number = oConstructor._err_number
        '            Session("o_error")._Err_Description = oConstructor._err_description
        '            Session("o_error")._Err_Source = oConstructor._err_source
        '            Session("o_error")._Err_Module = Me.Request.CurrentExecutionFilePath
        '            Session("o_error")._Err_Call = "txt_relateditem_id_TextChanged [ion_two.cons_description:construct]"
        '            Server.Transfer("/aspxerror.aspx")
        '        End If
        '    End If

        '    Me.txt_middlestone_desc.Text = oConstructor._description
        'End If

        Exit Sub

ErrorHandler:
        '--- Reporting Error
        Session("o_error")._Err_Number = Err.Number
        Session("o_error")._Err_Description = Err.Description
        Session("o_error")._Err_Source = Err.Source
        Session("o_error")._Err_Module = Me.Request.CurrentExecutionFilePath
        Session("o_error")._Err_Call = "txt_relateditem_id_TextChanged [ErrorHandler]"
        Server.Transfer("/aspxerror.aspx")

    End Sub

    Private Sub go_addnewmetal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles go_addnewmetal.Click
        ''Dim a As Decimal = Me.get_metal_price(12.3, "P", "Y")
        If go_addnewmetal.Text = "Add" Then
            If extra_metal_type.SelectedItem.Text <> "-" Then
                extra_metal_list.Items.Add(extra_metal_type.SelectedItem.Text)
            End If
        Else
            go_addnewmetal.Text = "Add"
            extra_metal_list.SelectedItem.Text = extra_metal_type.SelectedItem.Text
        End If
    End Sub

    Private Sub extra_metal_edit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles extra_metal_edit.Click
        go_addnewmetal.Text = "Edit Metal"
        Dim str As String = extra_metal_list.SelectedItem.Text
        Dim oExtra As New ion_two.cls_jewerly_extra
        oExtra.get_metal_fromstr(str)
        extra_metal_type.SelectedIndex = extra_metal_type.Items.IndexOf(extra_metal_type.Items.FindByText(oExtra._metal_type))
        '' extra_metal_weight.Text = oExtra._metal_price
        extra_metal_list.SelectedIndex = extra_metal_list_index
    End Sub

    Private Sub extra_metal_list_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles extra_metal_list.SelectedIndexChanged
        extra_metal_list_index = extra_metal_list.SelectedIndex
    End Sub

    Private Sub extra_metal_delete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles extra_metal_delete.Click
        extra_metal_list.Items.Remove(extra_metal_list.SelectedItem)
    End Sub



    Private Sub extra_stone_edit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles extra_stone_edit.Click
        Dim str As String = extra_stone_list.SelectedItem.Text
        Dim oExtra As New ion_two.cls_jewerly_extra
        go_addnewstone.Text = "Edit Stone"
        oExtra.get_stone_fromstr(str)
        extra_stone_center.Text = oExtra._stone_center
        extra_stone_side.Text = oExtra._stone_side
        extra_stone_price.Text = oExtra._stone_price

        extra_stone_list.SelectedIndex = extra_stone_list_index


    End Sub

    Private Sub go_addnewstone_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles go_addnewstone.Click
        If go_addnewstone.Text = "Add" Then
            If IsNumeric(extra_stone_price.Text) Then ' check price
                If Me.extra_stone_center.Text <> "" Then ''check if center stone
                    If Me.extra_stone_side.Text <> "" Then '' check if only center stone
                        extra_stone_list.Items.Add("Center Stone: " + extra_stone_center.Text + " - Side Stones: " + extra_stone_side.Text + " - " + extra_stone_price.Text + "$")
                    Else '' yes only center
                        extra_stone_list.Items.Add("Center Stone: " + extra_stone_center.Text + " - " + extra_stone_price.Text + "$")
                    End If


                Else '' no center
                    go_addnewstone.Text = "Add"
                    If Me.extra_stone_side.Text <> "" Then ''check if side
                        extra_stone_list.Items.Add("Side Stones: " + extra_stone_side.Text + " - " + extra_stone_price.Text + "$")
                    End If
                End If
            End If
        Else

            If IsNumeric(extra_stone_price.Text) Then ' check price
                If Me.extra_stone_center.Text <> "" Then ''check if center stone
                    If Me.extra_stone_side.Text <> "" Then '' check if only center stone
                        extra_stone_list.SelectedItem.Text = "Center Stone: " + extra_stone_center.Text + " - Side Stones: " + extra_stone_side.Text + " - " + extra_stone_price.Text + "$"
                    Else '' yes only center
                        extra_stone_list.SelectedItem.Text = "Center Stone: " + extra_stone_center.Text + " - " + extra_stone_price.Text + "$"
                    End If


                Else '' no center
                    If Me.extra_stone_side.Text <> "" Then ''check if side
                        extra_stone_list.SelectedItem.Text = "Side Stones: " + extra_stone_side.Text + " - " + extra_stone_price.Text + "$"
                    End If
                End If
            End If
        End If

    End Sub

    Private Sub extra_stone_list_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles extra_stone_list.SelectedIndexChanged
        extra_stone_list_index = extra_stone_list.SelectedIndex
    End Sub

    Private Sub extra_stone_delete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles extra_stone_delete.Click
        extra_stone_list.Items.Remove(extra_stone_list.SelectedItem)
    End Sub
    Public Function get_metal_price(ByVal weight As Decimal, ByVal origmetal As String, ByVal newmetal As String) As Int32
        Dim newindex As String = Mid(newmetal, 1, 1)
        Dim origindex As String = Mid(origmetal, 1, 1)
        Dim tmpweight As Decimal = 0
        Select Case origindex
            Case "P"
                If ((newindex = "Y") Or (newindex = "W")) Then
                    tmpweight = Math.Round((weight * 1.7), 2)
                End If
            Case "Y"
                If newindex = "P" Then
                    tmpweight = Math.Round((weight / 1.7), 2)
                End If
            Case "W"
                If newindex = "P" Then
                    tmpweight = Math.Round((weight / 1.7), 2)
                End If
        End Select
        If tmpweight = 0 Then tmpweight = weight
        Dim orate As New ion_two.cls_rate
        Return Convert.ToInt32(Math.Floor(tmpweight * orate.get_metal_rate(newmetal)))


    End Function
    Function LoadExtraSchemas()
        Dim xmlschema_list As XmlNodeList
        Dim oxml As New ion_two.cls_nd_xmlread
        oxml.xml_file = Server.MapPath("plate/extra_schema.xml")
        xmlschema_list = oxml.LoadNodeList_ByRootKey("schema")

        Me.extra_schema.Items.Add(New WebControls.ListItem("Select Type", "0"))

        For Each xmlnode As XmlNode In xmlschema_list
            Dim tmpitem As New WebControls.ListItem
            tmpitem.Text = xmlnode.Attributes("text").InnerText
            tmpitem.Value = xmlnode.Attributes("id").InnerText
            Me.extra_schema.Items.Add(tmpitem)
        Next

        Me.extra_schema.SelectedIndex = 0

    End Function

    Function CreateControlBySchemaID(ByVal id As Int32)
        If id = 0 Then
            Me.schema_controls.Controls.Clear()
        Else
            Dim oxml As New ion_two.cls_nd_xmlread
            oxml.xml_file = Server.MapPath("plate/extra_schema.xml")
            oxml.Load()

            Dim schema_atom As XmlNode
            Me.schema_controls.Controls.Clear()
            schema_atom = oxml.GetNodes_ByPath("schema[@id='" + Convert.ToString(id) + "']").Item(0)

            Dim lbl_counter As Int32 = 1
            For Each control_node As XmlNode In schema_atom.ChildNodes

                Select Case control_node.Attributes("type").InnerText
                    Case "literal"
                        Dim econtrol As New WebControls.Label
                        Me.schema_controls.Controls.Add(econtrol)
                        econtrol.ID = "lbl_extra" + Convert.ToString(lbl_counter)
                        lbl_counter += 1
                        econtrol.Text = control_node.Attributes("text").InnerText

                    Case "textbox"
                        Dim econtrol As New WebControls.TextBox
                        Me.schema_controls.Controls.Add(econtrol)
                        econtrol.ID = "ekey_" + control_node.Attributes("key").InnerText
                        If Not IsNothing(control_node.Attributes("addspace")) Then

                            Dim spacelabel As New Label
                            Me.schema_controls.Controls.Add(spacelabel)
                            spacelabel.ID = "lbl_extra" + Convert.ToString(lbl_counter)
                            lbl_counter += 1
                            spacelabel.Text = " "

                            ''    Me.schema_controls.Controls.Add(New LiteralControl("&nbsp;"))
                        End If

                End Select

            Next

            'Dim price_lbl As New WebControls.Label
            'Dim price_txt As New WebControls.TextBox

            'Me.schema_controls.Controls.Add(New LiteralControl("<br>"))
            'Me.schema_controls.Controls.Add(price_lbl)
            'Me.schema_controls.Controls.Add(price_txt)

            'price_txt.ID = "ekey_price"
            'price_lbl.Text = "Price:"
        End If


    End Function

    Function LoadJewelExtendedSchemas()
        Dim xmlschema_list As XmlNodeList
        Dim oxml As New ion_two.cls_nd_xmlread
        oxml.xml_file = Server.MapPath("plate/jewel_extended.xml")
        xmlschema_list = oxml.LoadNodeList_ByRootKey("schema")

        Me.je_list.Items.Add(New WebControls.ListItem("Select Type", "0"))

        For Each xmlnode As XmlNode In xmlschema_list
            Dim tmpitem As New WebControls.ListItem
            tmpitem.Text = xmlnode.Attributes("text").InnerText
            tmpitem.Value = xmlnode.Attributes("id").InnerText
            Me.je_list.Items.Add(tmpitem)
        Next

        Me.je_list.SelectedIndex = 0

    End Function

    Function CreateControlByJewelExtendedSchemaID(ByVal id As Int32)
        If id = 0 Then
            Me.je_panel.Controls.Clear()
        Else
            Dim oxml As New ion_two.cls_nd_xmlread
            oxml.xml_file = Server.MapPath("plate/jewel_extended.xml")
            oxml.Load()

            Dim schema_atom As XmlNode
            Me.je_panel.Controls.Clear()
            schema_atom = oxml.GetNodes_ByPath("schema[@id='" + Convert.ToString(id) + "']").Item(0)

            Dim lbl_counter As Int32 = 1
            For Each control_node As XmlNode In schema_atom.ChildNodes

                Select Case control_node.Attributes("type").InnerText
                    Case "literal"
                        Dim econtrol As New WebControls.Label

                        Me.je_panel.Controls.Add(econtrol)
                        '' econtrol.CssClass = "formfield"

                        econtrol.ID = "lbl_je_extra" + Convert.ToString(lbl_counter)
                        lbl_counter += 1
                        econtrol.Text = control_node.Attributes("text").InnerText

                    Case "listbox"
                        Dim econtrol As New WebControls.DropDownList

                        Me.je_panel.Controls.Add(econtrol)
                        econtrol.CssClass = "formfield"

                        econtrol.ID = "ekey_je_" + control_node.Attributes("key").InnerText
                        lbl_counter += 1
                        For Each item As XmlNode In control_node.SelectNodes("item")
                            econtrol.Items.Add(New WebControls.ListItem(item.InnerText))
                        Next
                        If Not IsNothing(control_node.Attributes("width")) Then
                            econtrol.Width = Unit.Pixel(Convert.ToInt32(control_node.Attributes("width").InnerText))
                            econtrol.Style.Add("width", control_node.Attributes("width").InnerText + "px")

                        End If
                        ''econtrol.Text = control_node.Attributes("text").InnerText


                    Case "textbox"
                        Dim econtrol As New WebControls.TextBox
                        econtrol.CssClass = "formfield"
                        Me.je_panel.Controls.Add(econtrol)
                        econtrol.ID = "ekey_je_" + control_node.Attributes("key").InnerText
                        If Not IsNothing(control_node.Attributes("width")) Then
                            econtrol.Width = Unit.Pixel(Convert.ToInt32(control_node.Attributes("width").InnerText))
                            econtrol.Style.Add("width", control_node.Attributes("width").InnerText + "px")

                        End If

                        '' econtrol.change

                        If Not IsNothing(control_node.Attributes("addspace")) Then

                            Dim spacelabel As New Label
                            Me.je_panel.Controls.Add(spacelabel)
                            spacelabel.ID = "lbl_je_extra" + Convert.ToString(lbl_counter)
                            lbl_counter += 1
                            spacelabel.Text = " "

                            ''    Me.schema_controls.Controls.Add(New LiteralControl("&nbsp;"))
                        End If
                    Case "br"
                        Dim br As New HtmlGenericControl
                        br.TagName = "br"
                        Me.je_panel.Controls.Add(br)

                    Case "check"
                        Dim econtrol As New CheckBox
                        Me.je_panel.Controls.Add(econtrol)
                        econtrol.CssClass = "formfield"

                        econtrol.ID = "ekey_je_" + control_node.Attributes("key").InnerText
                        lbl_counter += 1



                End Select

            Next

            'Dim price_lbl As New WebControls.Label
            'Dim price_txt As New WebControls.TextBox

            'Me.schema_controls.Controls.Add(New LiteralControl("<br>"))
            'Me.schema_controls.Controls.Add(price_lbl)
            'Me.schema_controls.Controls.Add(price_txt)

            'price_txt.ID = "ekey_price"
            'price_lbl.Text = "Price:"
        End If


    End Function

    Private Sub extra_schema_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles extra_schema.SelectedIndexChanged

    End Sub

    Private Sub extra_Add_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles extra_save.Click

        Dim textstr As String
        Dim key_val As New ArrayList

        key_val.Add("sid::" + Me.extra_schema.SelectedValue)

        For Each control As System.Web.UI.Control In schema_controls.Controls

            If control.GetType().Name = "TextBox" Then
                Dim tmptext As WebControls.TextBox = schema_controls.FindControl(control.ID)
                textstr += tmptext.Text
                key_val.Add(control.ID.Substring(5) + "::" + tmptext.Text)
            ElseIf control.GetType().Name = "Label" Then
                Dim tmplable As WebControls.Label = schema_controls.FindControl(control.ID)
                textstr += tmplable.Text
            End If
            ''Me.extra_list.Items.Add(control.ID)
        Next
        Dim valstr = Join(key_val.ToArray, "^")
        If Me.extra_list.Enabled Then
            Me.extra_list.Items.Add(New WebControls.ListItem(textstr, valstr))
        Else
            Dim tmppos = Me.extra_list.SelectedIndex
            Me.extra_list.Items.RemoveAt(Me.extra_list.SelectedIndex)
            Me.extra_list.Items.Insert(tmppos, (New WebControls.ListItem(textstr, valstr)))
            Me.extra_list.Enabled = True
            Me.extra_schema.Enabled = True
        End If
    End Sub
    Private Sub extra_edit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles extra_edit.Click
        Dim oextralgk As New ion_two.cls_extra_lgk
        Dim hash As Hashtable = oextralgk.DecodeExtraStoneKeys(Me.extra_list.SelectedValue)
        Me.extra_schema.SelectedIndex = Me.extra_schema.Items.IndexOf(Me.extra_schema.Items.FindByValue(hash.Item("sid")))
        Me.extra_schema.Controls.Clear()
        Me.CreateControlBySchemaID(Convert.ToInt32(hash.Item("sid")))
        hash.Remove("sid")

        For Each key As String In hash.Keys
            Dim tmpText As WebControls.TextBox = Me.extra_schema.FindControl("ekey_" + key)
            tmpText.Text = hash(key)
        Next

        Me.extra_list.Enabled = False
        Me.extra_schema.Enabled = False
    End Sub

    Private Sub extra_delete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles extra_delete.Click
        Me.extra_list.Items.RemoveAt(Me.extra_list.SelectedIndex)
    End Sub

    Private Sub extra_paste_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles extra_paste.TextChanged
        '--- Define information to read
        Dim oTmpDataBroker As New iDac.cls_T_datareader
        oTmpDataBroker._dbtype = Application("config").connection_string_type
        oTmpDataBroker._connection_string = Application("config").connection_string
        oTmpDataBroker._table = "inv_jewelry"
        Dim cSQL As String

        cSQL = "select extra_stone,extra_metal from inv_jewelry where inventory_id = " + Me.extra_paste.Text


        '--- Define records
        Dim oField1 As New iDac.cls_cll_datareader
        oField1._field = "extra_stone"

        Dim oField2 As New iDac.cls_cll_datareader
        oField2._field = "extra_metal"

        oTmpDataBroker._fields.Add(oField1)
        oTmpDataBroker._fields.Add(oField2)

        '--- Get info
        oTmpDataBroker.read(cSQL)


        '--- Fill results
        If oTmpDataBroker._hasresult Then

            ''bExist = True
            Dim oextra As New ion_two.cls_jewerly_extra
            oextra.DecodeExtraStoneString(oTmpDataBroker._fields.Item(1)._result, Me.extra_list)

            Me.extra_metal_delta.Text = oextra.DecodeMetalDelta(oTmpDataBroker._fields.Item(2)._result)
        End If
    End Sub

    Private Sub txt_stone_exchange_itemid_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_stone_exchange_itemid.TextChanged
        If Me.chk_stone_exchange.Checked Then
            If IsNumeric(Me.txt_stone_exchange_itemid.Text) Then
                Dim id As Int32 = Me.txt_stone_exchange_itemid.Text
                ''   oTmpSubPlate.se_relateditem_id = Convert.ToInt32(Me.txt_stone_exchange_itemid.Text)
                ''write the new stuff to the cs desc XX stonetypes alvaible<br>shape

                Dim oSefunc As New ion_two.cls_stone_exchange
                oSefunc.Conn_String = Application("config").connection_string
                oSefunc.db_type = Application("config").connection_string_type
                oSefunc.picture_obj = New ion_two.cls_pictures
                oSefunc.is_dealer = False

                ''get the type and color and stuff of the related stone
                Dim stone_type, stone_shape, stone_color As String
                Dim stone_weight, stone_price As Decimal


                ''load
                oSefunc.load_stone_exchange_byid(id, stone_type, stone_shape, stone_weight, stone_color, stone_price)

                ''set sql str
                If InStr(stone_color.ToLower, "pink") > 0 And stone_type = "Sapphire" Then
                    oSefunc.make_sql_str(stone_type, stone_shape, stone_weight, 1)
                ElseIf InStr(stone_color.ToLower, "yellow") > 0 And stone_type = "Sapphire" Then
                    oSefunc.make_sql_str(stone_type, stone_shape, stone_weight, 2)
                Else
                    oSefunc.make_sql_str(stone_type, stone_shape, stone_weight, 0)
                End If
                ''load collection of the table
                oSefunc.make_table()

                Me.ext_c_cut.SelectedIndex = Me.ext_c_cut.Items.IndexOf(Me.ext_c_cut.Items.FindByText(stone_shape))

                Me.ext_c_desc.Text = oSefunc.SE_collection.Count.ToString + " " + stone_type + " available<br>"
                Me.ext_c_desc.Text = Me.ext_c_desc.Text.Replace("Sapphire", "Sapphires")
                Me.ext_c_desc.Text = Me.ext_c_desc.Text.Replace("Ruby", "Rubies")
                Me.ext_c_desc.Text = Me.ext_c_desc.Text.Replace("Emerald", "Emeralds")
            End If
        End If
    End Sub



    Private Sub je_list_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles je_list.SelectedIndexChanged
        ''  Me.CreateControlByJewelExtendedSchemaID(Convert.ToInt32(Me.je_list.SelectedValue))
        ''  Me.je_panel.Controls.Clear()
    End Sub

    Private Sub je_update_title_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles je_update_title.Click


        Dim text2 As TextBox = Me.je_panel.FindControl("ekey_je_stoneweight")
        ext_c_desc.Text = text2.Text + " Ct. - "

        Dim text3 As TextBox = Me.je_panel.FindControl("ekey_je_stonecolorfree")
        Dim text4 As TextBox = Me.je_panel.FindControl("ekey_je_stoneclarityfree")

        If text3.Text <> "" Then
            ext_c_desc.Text += text3.Text
        Else
            Dim drop1 As DropDownList = Me.je_panel.FindControl("ekey_je_stonecolor")
            ext_c_desc.Text += drop1.SelectedItem.Text
        End If

        If text3.Text <> "" Then
            ext_c_desc.Text += "/" + text4.Text

        Else
            Dim drop2 As DropDownList = Me.je_panel.FindControl("ekey_je_stoneclarity")
            ext_c_desc.Text += "/" + drop2.SelectedItem.Text
        End If
    End Sub

    Private Sub txt_title_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_title.TextChanged
        ''Me.txt_ebay_title.Text = Me.txt_title.Text
    End Sub
End Class


