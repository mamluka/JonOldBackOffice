Imports System.IO
Imports System.Reflection
Public Class cls_diamond_importer

    Public conn_string As String
    Public dbtype As Int32
    Public filename As String
    Public Function StartImport(ByVal dataid As Int32)

        Dim headerhash As New Hashtable
        Dim propertieshash As New Hashtable

        Me.MapFileColumn(dataid, headerhash, propertieshash)

        Dim oreader As StreamReader = File.OpenText(Me.filename)
        Dim counter As Int32 = 0
        While oreader.Peek() <> -1
            Dim line As String = oreader.ReadLine()

            If counter >= 1 And line.Length > 10 Then

                Me.AddCSVLineToDatabase(line, dataid, propertieshash, headerhash)
            End If

            counter += 1
            '.. do whatever else you need to do ..
        End While



        oreader.Close()

    End Function


    Public Function MapFileColumn(ByVal dataid As Int32, ByRef headerhash As Hashtable, ByRef propertieshash As Hashtable) As Hashtable
        Dim oreader As StreamReader = File.OpenText(Me.filename)

        Dim csvheader As String = oreader.ReadLine()
        Dim i As Int32 = 0

        For i = 0 To csvheader.Split(",").Length - 1
            headerhash(Trim(csvheader.Split(",")(i))) = i
        Next

        oreader.Close()

        propertieshash = Me.MapCSVFieldsToPlateProperties(dataid, headerhash)


    End Function


    Public Function AddCSVLineToDatabase(ByVal line As String, ByVal dataid As Int32, ByVal propertieshash As Hashtable, ByVal headerhash As Hashtable)

        Dim fields() As String = line.Split(",")





        '--- Map fields
        Dim oplate As New ion_two.skl_inventory

        Dim oSubPlate As New skl_diamond
        oplate._subplate = oSubPlate

        Me.SetDefaultValuesByDataID(oplate, dataid)
        Me.FillInOplateWithReflection(oplate, propertieshash, fields, dataid)


        oplate._sell_price = oplate._purchase_price * 1.1
        oplate._dealer_price = oplate._purchase_price * 1.05
        oplate._appraisal_price = oplate._purchase_price * 3.5
        'oTmpPlate._id = Convert.ToInt16(Me.hid_item_id.Text)
        'oTmpPlate._platetype = Convert.ToInt16(Me.hid_plate_id.Text)
        'oTmpPlate._category_id = Convert.ToInt16(Me.cmb_category.SelectedItem.Value)
        'oTmpPlate._subcategory_id = Convert.ToInt16(Me.cmb_subcategory.SelectedItem.Value)
        'oTmpPlate._location_id = Convert.ToInt16(Me.cmb_location.SelectedItem.Value)
        'oTmpPlate._branchnumber = Convert.ToInt16(Me.hid_branch_id.Text)
        ''oTmpPlate._itemnumberint = 0
        'oTmpPlate._suppliernumber = Convert.ToInt16(Me.cmb_supplier.SelectedItem.Value)
        'oTmpPlate._itemcode = Convert.ToString(txt_supplier_code.Text.Trim)
        'oTmpPlate._active = Convert.ToBoolean(Me.chk_active_in_shop.Checked)
        'oTmpPlate._deleted = Convert.ToBoolean(Me.chk_deleted.Checked)
        'oTmpPlate._no_orderalone = Convert.ToBoolean(Me.chk_cannot_be_ordered_alone.Checked)
        'oTmpPlate._no_publicauction = Convert.ToBoolean(Me.chk_not_in_public_auction.Checked)
        'oTmpPlate._status_id = Convert.ToInt16(Me.cmb_status.SelectedItem.Value)
        'oTmpPlate._lang1_description = Convert.ToString(Me.txt_language1.Text.Trim)
        'oTmpPlate._lang2_description = Convert.ToString(Me.txt_language2.Text.Trim)
        'oTmpPlate._lang3_description = Convert.ToString(Me.txt_language3.Text.Trim)
        'oTmpPlate._lang4_description = Convert.ToString(Me.txt_language4.Text.Trim)
        'oTmpPlate._lang5_description = Convert.ToString(Me.txt_language5.Text.Trim)
        'oTmpPlate._lang6_description = Convert.ToString(Me.txt_language6.Text.Trim)
        'oTmpPlate._createdate = Convert.ToDateTime(Now)
        'oTmpPlate._onprocess = Convert.ToBoolean(Me.chk_in_process.Checked)
        'oTmpPlate._onauction = Convert.ToBoolean(Me.chk_on_local_auction.Checked)
        'oTmpPlate._club_item = Convert.ToBoolean(Me.chk_clubitem.Checked)
        'oTmpPlate._onspecial = Convert.ToBoolean(Me.chk_item_special.Checked)
        'oTmpPlate._onspecial_from_date = Convert.ToDateTime(Me.txt_special_from_date.Text)
        'oTmpPlate._onspecial_to_date = Convert.ToDateTime(Me.txt_special_to_date.Text)
        'oTmpPlate._qtyonstock_cur = Convert.ToInt16(Me.txt_stock_curr.Text)
        'oTmpPlate._qtyonstock_min = Convert.ToInt16(Me.txt_stock_min.Text)
        'oTmpPlate._purchase_price = Convert.ToDecimal(Me.txt_purchase_price.Text)
        'oTmpPlate._appraisal_price = Convert.ToDecimal(Me.txt_appraisal_price.Text)
        'oTmpPlate._dealer_price = Convert.ToDecimal(Me.txt_dealer_price.Text)
        'oTmpPlate._sell_price = Convert.ToDecimal(Me.txt_sell_price.Text)
        'oTmpPlate._special_sell_price = Convert.ToDecimal(Me.txt_special_sell_price.Text)
        'oTmpPlate._special_dealer_price = Convert.ToDecimal(Me.txt_special_dealer_price.Text)
        'oTmpPlate._notes = Convert.ToString(Me.txt_notes.Text.Trim)
        'oTmpPlate._remarks = Convert.ToString(Me.txt_remarks.Text.Trim)
        'oTmpPlate._indexwords = Convert.ToString(Me.txt_indexwords.Text.Trim)
        'oTmpPlate._lastmodify_user = Convert.ToString(Session("user").user_name)
        'oTmpPlate._lastmodify_date = Convert.ToDateTime(Now)
        'oTmpPlate._lastmodify_user_id = Convert.ToInt16(Session("user").user_id)
        'oTmpPlate._icon_pic = Convert.ToString(Me.txt_hdn_icon.Text)
        'oTmpPlate._picture_pic = Convert.ToString(Me.txt_hdn_picture.Text)
        'oTmpPlate._picture_hires_pic = Convert.ToString(Me.txt_hdn_hrpicture.Text)
        'oTmpPlate._certificate_pic = Convert.ToString(Me.txt_hdn_report.Text)
        'oTmpPlate._movie_pic = Convert.ToString(Me.txt_hdn_movie.Text)
        'oTmpPlate._gallery_pic = Convert.ToString(Me.txt_hdn_gallery.Text)
        'oTmpPlate._banner_pic = Convert.ToString(Me.txt_hdn_banner.Text)
        'oTmpPlate._similar_items = Convert.ToString(Me.txt_similaritems.Text)
        'oTmpPlate._autogenerated = Convert.ToBoolean(Me.chk_autogenerated.Checked)
        'oTmpPlate._item_sold = Convert.ToBoolean(Me.chk_itemsold.Checked)
        'oTmpPlate.onbargain = Convert.ToBoolean(Me.chk_bargain.Checked)
        'oTmpPlate.samplepic = Convert.ToBoolean(Me.chk_samplepic.Checked)
        'oTmpPlate.featured = Convert.ToBoolean(Me.chk_featured.Checked)


        oplate.opthash("extraopen") = 0
        oplate.opthash("bestoffer") = 0

        If fields(headerhash("CUT")) <> "" Then
            Select Case dataid
                Case 1
                    Dim odata1 As New Data1Translate
                    oplate.opthash("diamondcut") = odata1.GoodBadReverse(Convert.ToString(odata1.GoodBad(fields(headerhash("CUT")))))
            End Select

        Else
            oplate.opthash("diamondcut") = "-"
        End If

        'If Me.cmb_payments.SelectedIndex = 0 Then
        '    oTmpPlate.opthash("usepayments") = "0"
        'Else
        '    oTmpPlate.opthash("usepayments") = "1"
        '    oTmpPlate.opthash("payments") = Me.cmb_payments.SelectedValue
        'End If

        'If Me.smartsort_text.Text <> "" Then oTmpPlate._smartsort_txt = Me.smartsort_text.Text
        'If Me.chk_on_local_auction.Checked Then
        '    oTmpPlate.release_date = Convert.ToDateTime(Me.txt_auction_release.Text)
        '    If IsNumeric(Me.txt_auction_minbid.Text) Then
        '        oTmpPlate.auction_price = Convert.ToDecimal(Me.txt_auction_minbid.Text)
        '    End If
        'Else
        oplate.release_date = Now()
        'End If


        '--- Get SUBplate type




        ''--- Load SUBplate

        'bError = oSubPlate.set_plate(oTmpPlate)
        'If bError Then
        '    Session("o_error")._Err_Number = oSubPlate._err_number
        '    Session("o_error")._Err_Description = oSubPlate._err_description
        '    Session("o_error")._Err_Source = oSubPlate._err_source
        '    Session("o_error")._Err_Module = Me.Request.CurrentExecutionFilePath
        '    Session("o_error")._Err_Call = "loadPlate [get_plate]"
        '    Server.Transfer("/aspxerror.aspx")
        'End If

        ''--------opthash from subplates
        'Select Case oTmpPlate._platetype
        '    Case 1
        '    Case 2
        '    Case 3

        '        Dim txt1 As WebControls.TextBox = oSubPlate.findcontrol("txt_bend_from")
        '        Dim txt2 As WebControls.TextBox = oSubPlate.findcontrol("txt_bend_to")
        '        If txt1.Text <> "" Then
        '            oTmpPlate.opthash("bend_from") = txt1.Text
        '            oTmpPlate.opthash("bend_to") = txt2.Text

        '        End If

        '        Dim ebay_title As WebControls.TextBox = oSubPlate.findcontrol("txt_ebay_title")
        '        If ebay_title.Text <> "" Then
        '            oTmpPlate.opthash("ebaytitle") = ebay_title.Text
        '        End If

        '        'Dim default_model As WebControls.CheckBox = oSubPlate.findcontrol("chk_default_model")


        '        'If default_model.Checked Then
        '        '    oTmpPlate.opthash("defaultmodel") = "1"
        '        'End If

        'End Select


        ''--- SAVE
        Dim oTmpInventoryLogics As New ion_two.cls_inventory_lgc
        oTmpInventoryLogics._connection_string = Me.conn_string
        oTmpInventoryLogics._dbtype = Me.dbtype


        oTmpInventoryLogics.insert(oplate)
        '      
        '        Session("message").returnpath = "/default.aspx"

        '    Case 2    '--- EDIT
        '        bError = oTmpInventoryLogics.update(oTmpPlate)
        '        If bError Then
        '            Session("o_error")._Err_Number = oTmpInventoryLogics._err_number
        '            Session("o_error")._Err_Description = oTmpInventoryLogics._err_description
        '            Session("o_error")._Err_Source = oTmpInventoryLogics._err_source
        '            Session("o_error")._Err_Module = Me.Request.CurrentExecutionFilePath
        '            Session("o_error")._Err_Call = "btn_submit_Click [ion_two.cls_inventory_lgc:insert]"
        '            Server.Transfer("/aspxerror.aspx")
        '        End If
        '        Session("message").returnpath = "/inventory/listitem.aspx"

        'End Select

    End Function
    Public Function MapCSVFieldsToPlateProperties(ByVal dataid As Int32, ByVal headerhash As Hashtable) As Hashtable
        Dim propertieshash As New Hashtable

        Select Case dataid
            Case 1 ''indian guy
                propertieshash("_itemcode") = headerhash("Pkt No")
                propertieshash("_subplate._shape_id") = headerhash("Shape")
                propertieshash("_subplate._weight") = headerhash("Our Size")
                propertieshash("_subplate._color_id") = headerhash("Color")
                propertieshash("_subplate._clarity_id") = headerhash("Clarity")
                ''propertieshash("_itemcode") = headerhash("CUT")'' needs answer
                propertieshash("_subplate._polish_id") = headerhash("Polish")
                propertieshash("_subplate._symmetry_id") = headerhash("Sym")
                propertieshash("_subplate._report_id") = headerhash("LAB")
                propertieshash("_subplate._fluorecence_id") = headerhash("FLRN")
                propertieshash("_subplate._depth") = headerhash("Tot Depth %")
                propertieshash("_subplate._tablewidth") = headerhash("Tble %")
                propertieshash("_subplate._measure1from") = headerhash("DMTR Avg MM")
                propertieshash("_subplate._measure2from") = headerhash("Lnth MM")
                propertieshash("_subplate._measure3from") = headerhash("Tot Depth MM")
                propertieshash("_purchase_price") = headerhash("Dlr Rate")
                '' propertieshash("_measure2from") = headerhash("Lnth MM")
                '' propertieshash("_measure3from") = headerhash("Tot Depth MM")

        End Select

        Return propertieshash


    End Function

    Public Function RemakeValuesByDataID(ByVal dataid As Int32)

        Select Case dataid
            Case 1
                '' propertieshash("subplate._shape_id") = propertieshash("subplate._shape_id").toLower
        End Select



    End Function




    Public Function SetDefaultValuesByDataID(ByVal oplate As ion_two.skl_inventory, ByVal dataid As Int32) As Boolean

        oplate._id = 9999 '' only for things
        oplate._platetype = 1
        oplate._category_id = 1 ''Convert.ToInt16(Me.cmb_category.SelectedItem.Value)
        oplate._subcategory_id = 1 ''Convert.ToInt16(Me.cmb_subcategory.SelectedItem.Value)
        oplate._location_id = 1 ''Convert.ToInt16(Me.cmb_location.SelectedItem.Value)
        oplate._branchnumber = 1 ''Convert.ToInt16(Me.hid_branch_id.Text)
        'oplate._itemnumberint = 0
        oplate._suppliernumber = 1 ''Convert.ToInt16(Me.cmb_supplier.SelectedItem.Value)

        oplate._active = True
        oplate._deleted = False
        oplate._no_orderalone = False ''Convert.ToBoolean(Me.chk_cannot_be_ordered_alone.Checked)
        oplate._no_publicauction = False ''Convert.ToBoolean(Me.chk_not_in_public_auction.Checked)
        oplate._status_id = 1 ''Convert.ToInt16(Me.cmb_status.SelectedItem.Value)
        oplate._lang1_description = "" ''Convert.ToString(Me.txt_language1.Text.Trim)"
        oplate._lang2_description = "" ''Convert.ToString(Me.txt_language2.Text.Trim)
        oplate._lang3_description = "" ''Convert.ToString(Me.txt_language3.Text.Trim)
        oplate._lang4_description = "" ''Convert.ToString(Me.txt_language4.Text.Trim)
        oplate._lang5_description = "" 'Convert.ToString(Me.txt_language5.Text.Trim)
        oplate._lang6_description = "" ''Convert.ToString(Me.txt_language6.Text.Trim)
        oplate._createdate = Convert.ToDateTime(Now)
        oplate._onprocess = False
        oplate._onauction = False
        oplate._club_item = False
        oplate._onspecial = False
        oplate._onspecial_from_date = Convert.ToDateTime(Now)
        oplate._onspecial_to_date = Convert.ToDateTime(Now)
        oplate._qtyonstock_cur = 10 ''Convert.ToInt16(Me.txt_stock_curr.Text)
        oplate._qtyonstock_min = 1 ''Convert.ToInt16(Me.txt_stock_min.Text)
        ''oplate._purchase_price = Convert.ToDecimal(Me.txt_purchase_price.Text)
        ''oplate._appraisal_price = Convert.ToDecimal(Me.txt_appraisal_price.Text)
        '' oplate._dealer_price = Convert.ToDecimal(Me.txt_dealer_price.Text)
        '' oplate._sell_price = Convert.ToDecimal(Me.txt_sell_price.Text)
        ''  oplate._special_sell_price = Convert.ToDecimal(Me.txt_special_sell_price.Text)
        ''  oplate._special_dealer_price = Convert.ToDecimal(Me.txt_special_dealer_price.Text)
        ''  oplate._notes = Convert.ToString(Me.txt_notes.Text.Trim)
        ''  oplate._remarks = Convert.ToString(Me.txt_remarks.Text.Trim)
        ''  oplate._indexwords = Convert.ToString(Me.txt_indexwords.Text.Trim)
        '  oplate._lastmodify_user = Convert.ToString(Session("user").user_name)
        ''  oplate._lastmodify_date = Convert.ToDateTime(Now)
        '' oplate._lastmodify_user_id = Convert.ToInt16(Session("user").user_id)
        '' oplate._icon_pic = Convert.ToString(Me.txt_hdn_icon.Text)
        '' oplate._picture_pic = Convert.ToString(Me.txt_hdn_picture.Text)
        '' oplate._picture_hires_pic = Convert.ToString(Me.txt_hdn_hrpicture.Text)
        '' oplate._certificate_pic = Convert.ToString(Me.txt_hdn_report.Text)
        '' oplate._movie_pic = Convert.ToString(Me.txt_hdn_movie.Text)
        '' oplate._gallery_pic = Convert.ToString(Me.txt_hdn_gallery.Text)
        '' oplate._banner_pic = Convert.ToString(Me.txt_hdn_banner.Text)
        ''oplate._similar_items = Convert.ToString(Me.txt_similaritems.Text)
        oplate._autogenerated = True
        oplate._item_sold = False
        oplate.onbargain = False
        oplate.samplepic = False
        oplate.featured = False
        '' oplate._subplate._id = 0
        ''oplate._subplate._inventory_id = 0
        ''oplate._subplate._weight = 0
        oplate._subplate._quantity = 1

        ''   oplate._subplate._depth = 0
        ''    oplate._subplate._tablewidth = 0
        oplate._subplate._stonetype_id = 1
        ''   oplate._subplate._color_id = 0
        ''    oplate._subplate._clarity_id = 0
        oplate._subplate._colorto_id = 1
        oplate._subplate._clarityto_id = 1
        ''    oplate._subplate._shape_id = 0
        ''   oplate._subplate._polish_id = 0
        '' oplate._subplate._sym(oplate._subplate.try_id = 0
        '' oplate._subplate._fluorecence_id = 0
        oplate._subplate._girdle_id = 1
        oplate._subplate._culet_id = 1
        oplate._subplate.fancy_freetxt = ""
        '' oplate._subplate._report_id = 0



    End Function

    Public Function TranslateFieldsByDataID(ByVal dataid As Int32, ByVal fieldname As String, ByRef value As Object)

        Select Case dataid
            Case 1
                Dim data1 As New Data1Translate
                Select Case fieldname
                    Case "_subplate._shape_id"
                        value = data1.shapehash(value)
                    Case "_subplate._color_id"
                        value = data1.color(value)
                    Case "_subplate._clarity_id"
                        value = data1.clarity(value)
                    Case "_subplate._polish_id"
                        value = data1.GoodBad(value)
                    Case "_subplate._symmetry_id"
                        value = data1.GoodBad(value)
                    Case "_subplate._report_id"
                        value = data1.report(value)
                    Case "_subplate._fluorecence_id"
                        value = data1.fluorescence(value)
                    Case "_itemcode"
                        value = Convert.ToString(value)
                    Case Else
                        value = Convert.ToDecimal(value)
                End Select

        End Select

    End Function

    Public Function FillInOplateWithReflection(ByRef oplate As ion_two.skl_inventory, ByVal propertieshash As Hashtable, ByVal fields() As String, ByVal dataid As Int32) As Boolean


        Dim oplateref As Type
        Dim osubplateref As Type
        osubplateref = oplate._subplate.GetType
        oplateref = oplate.GetType

        Dim prop As FieldInfo


        For Each key As String In propertieshash.Keys
            Dim value As Object = fields(Convert.ToInt32(propertieshash(key)))
            Me.TranslateFieldsByDataID(dataid, key, value)

            If key.StartsWith("_subplate") Then
                osubplateref.InvokeMember(key.Split(".")(1), BindingFlags.SetField, Nothing, oplate._subplate, New Object() {value})
            Else
                oplateref.InvokeMember(key, BindingFlags.SetField, Nothing, oplate, New Object() {value})
            End If
        Next

    End Function
End Class

Public Class Data1Translate
    Public shapehash As New Hashtable
    Public color As New Hashtable
    Public clarity As New Hashtable

    Public GoodBad As New Hashtable
    Public GoodBadReverse As New Hashtable
    Public report As New Hashtable
    Public fluorescence As New Hashtable




    Sub New()
        Me.shapehash("ROUND") = 2
        Me.shapehash("PEAR") = 8
        Me.shapehash("MARQUISE") = 6
        Me.shapehash("CUSHION") = 10
        Me.shapehash("PRINCESS") = 3
        Me.shapehash("EMERALD") = 5
        Me.shapehash("RADIANT") = 4
        Me.shapehash("PRINCESS") = 3
        Me.shapehash("HEART") = 12

        Me.color("F+") = 4
        Me.color("D") = 2
        Me.color("E") = 3
        Me.color("F") = 4
        Me.color("G") = 5
        Me.color("H") = 6
        Me.color("I") = 7
        Me.color("J") = 8
        Me.color("K") = 9
        Me.color("L") = 10
        Me.color("M") = 11


        Me.clarity("F") = 2

        Me.clarity("IF") = 3
        Me.clarity("VVS1") = 4
        Me.clarity("VVS2") = 5
        Me.clarity("VS1") = 6
        Me.clarity("VS2") = 7
        Me.clarity("SI1") = 8
        Me.clarity("SI2") = 9
        Me.clarity("SI3") = 10
        Me.clarity("I1") = 11
        Me.clarity("I2") = 12
        Me.clarity("I3") = 13

        Me.GoodBad("EX") = 2
        Me.GoodBad("VG") = 3
        Me.GoodBad("GD") = 4
        Me.GoodBad("FR") = 5
        Me.GoodBad("ID") = 8

        Me.GoodBadReverse("2") = "Excellent"
        Me.GoodBadReverse("3") = "Very Good"
        Me.GoodBadReverse("4") = "Good"
        Me.GoodBadReverse("5") = "Fair"
        Me.GoodBadReverse("8") = "Ideal"

        '' Me.Symmetry("EX") = 2
        '' Me.Symmetry("EX") = 2
        '' Me.Symmetry("EX") = 2
        '' Me.Symmetry("EX") = 2
        '' Me.Symmetry("EX") = 2

        Me.report("HRD") = 4
        Me.report("IGI") = 5
        Me.report("GIA") = 2

        Me.fluorescence("NONE") = 2
        Me.fluorescence("SL") = 7
        Me.fluorescence("FNT") = 3
        Me.fluorescence("MED") = 4
        Me.fluorescence("VST") = 6
        Me.fluorescence("VSL") = 4
        Me.fluorescence("STG") = 5


    End Sub
End Class
