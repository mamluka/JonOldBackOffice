Partial Class wc_order_reconsile
    Inherits System.Web.UI.UserControl



    Public oCart As ion_resources.cls_cart
    Public cOrderNumber As String

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

        Dim bError As Boolean = False

        '--- If we already reconsiled don't run this code
        If oCart.shopitem.Count <= 1 Then
            Me.Visible = False
            Exit Sub
        End If

        '--- 1
        If oCart.shopitem.Count >= 1 Then
            Me.chk_reconsile_1.Text = oCart.shopitem.Item(1).itemnumber
            Me.chk_reconsile_1.Visible = True
        End If

        '--- 2
        If oCart.shopitem.Count >= 2 Then
            Me.chk_reconsile_2.Text = oCart.shopitem.Item(2).itemnumber
            Me.chk_reconsile_2.Visible = True
        End If

        '--- 3
        If oCart.shopitem.Count >= 3 Then
            Me.chk_reconsile_3.Text = oCart.shopitem.Item(3).itemnumber
            Me.chk_reconsile_3.Visible = True
        End If

        '--- 4
        If oCart.shopitem.Count >= 4 Then
            Me.chk_reconsile_4.Text = oCart.shopitem.Item(4).itemnumber
            Me.chk_reconsile_4.Visible = True
        End If

        '--- 5
        If oCart.shopitem.Count >= 5 Then
            Me.chk_reconsile_5.Text = oCart.shopitem.Item(5).itemnumber
            Me.chk_reconsile_5.Visible = True
        End If

        '--- 6
        If oCart.shopitem.Count >= 6 Then
            Me.chk_reconsile_6.Text = oCart.shopitem.Item(6).itemnumber
            Me.chk_reconsile_6.Visible = True
        End If

        '--- 7
        If oCart.shopitem.Count >= 7 Then
            Me.chk_reconsile_7.Text = oCart.shopitem.Item(7).itemnumber
            Me.chk_reconsile_7.Visible = True
        End If

        '--- 8
        If oCart.shopitem.Count >= 8 Then
            Me.chk_reconsile_8.Text = oCart.shopitem.Item(8).itemnumber
            Me.chk_reconsile_8.Visible = True
        End If

        '--- 9
        If oCart.shopitem.Count >= 9 Then
            Me.chk_reconsile_9.Text = oCart.shopitem.Item(9).itemnumber
            Me.chk_reconsile_9.Visible = True
        End If

        '--- 10
        If oCart.shopitem.Count >= 10 Then
            Me.chk_reconsile_10.Text = oCart.shopitem.Item(10).itemnumber
            Me.chk_reconsile_10.Visible = True
        End If


        '--- 11
        If oCart.shopitem.Count >= 11 Then
            Me.chk_reconsile_11.Text = oCart.shopitem.Item(11).itemnumber
            Me.chk_reconsile_11.Visible = True
        End If

        '--- 12
        If oCart.shopitem.Count >= 12 Then
            Me.chk_reconsile_12.Text = oCart.shopitem.Item(12).itemnumber
            Me.chk_reconsile_12.Visible = True
        End If

        '--- 13
        If oCart.shopitem.Count >= 13 Then
            Me.chk_reconsile_13.Text = oCart.shopitem.Item(13).itemnumber
            Me.chk_reconsile_13.Visible = True
        End If

        '--- 14
        If oCart.shopitem.Count >= 14 Then
            Me.chk_reconsile_14.Text = oCart.shopitem.Item(14).itemnumber
            Me.chk_reconsile_14.Visible = True
        End If

        '--- 15
        If oCart.shopitem.Count >= 15 Then
            Me.chk_reconsile_15.Text = oCart.shopitem.Item(15).itemnumber
            Me.chk_reconsile_15.Visible = True
        End If

        '--- 16
        If oCart.shopitem.Count >= 16 Then
            Me.chk_reconsile_16.Text = oCart.shopitem.Item(16).itemnumber
            Me.chk_reconsile_16.Visible = True
        End If

        '--- 17
        If oCart.shopitem.Count >= 17 Then
            Me.chk_reconsile_17.Text = oCart.shopitem.Item(17).itemnumber
            Me.chk_reconsile_17.Visible = True
        End If

        '--- 18
        If oCart.shopitem.Count >= 18 Then
            Me.chk_reconsile_18.Text = oCart.shopitem.Item(18).itemnumber
            Me.chk_reconsile_18.Visible = True
        End If

        '--- 19
        If oCart.shopitem.Count >= 19 Then
            Me.chk_reconsile_19.Text = oCart.shopitem.Item(19).itemnumber
            Me.chk_reconsile_19.Visible = True
        End If

        '--- 20
        If oCart.shopitem.Count >= 20 Then
            Me.chk_reconsile_20.Text = oCart.shopitem.Item(20).itemnumber
            Me.chk_reconsile_20.Visible = True
        End If

    End Sub


    Private Sub btn_reconsile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_reconsile.Click
        On Error GoTo ErrorHandler
        Dim bError As Boolean = False

        Me.btn_reconsile.Enabled = False

        '--- If we already reconsiled don't run this code
        If oCart.shopitem.Count <= 1 Then
            Me.Visible = False
            Exit Sub
        End If

        Dim nCostPrice As Decimal
        Dim nSellPrice As Decimal
        Dim nAppraisalPrice As Decimal
        Dim nDealerPrice As Decimal

        '--- Total items for reconsiliation
        bError = TotalItems(nSellPrice, nCostPrice, nAppraisalPrice, nDealerPrice)


        '--- Declare Plate
        Dim oPlate As New ion_resources.cls_ion_plate_lgc()
        oPlate.connection_string = Application("config").connection_string

        bError = oPlate.get_empty_plate(3)
        If bError Then
            '--- when object is called in external DLL
            Session("error").err_number = oPlate.error_no
            Session("error").err_source = oPlate.error_source
            Session("error").err_description = oPlate.error_desc
            '--- Custom error
            Dim oTmpDB As New System.Diagnostics.StackFrame()
            Session("error").app_module = Me.Request.CurrentExecutionFilePath
            Session("error").app_function = oTmpDB.GetMethod.Name
            Session("error").app_call = "wc+order_reconsile / btn_reconsile_click"
        End If

        Dim oDataTable1 As DataTable = oPlate.dataset.Tables("inv_INVENTORY")
        Dim oDataRow1 As DataRow
        oDataRow1 = oDataTable1.NewRow()

        '--- Save Main Plate
        oDataRow1("platetype") = 3
        oDataRow1("category_id") = 7
        oDataRow1("subcategory_id") = 37
        oDataRow1("location_id") = 2
        oDataRow1("branchnumber") = 1
        oDataRow1("itemnumberint") = 0
        oDataRow1("suppliernumber") = 0
        oDataRow1("itemcode") = ""
        oDataRow1("shopstatus") = 0
        oDataRow1("itemdeleted") = 0
        oDataRow1("no_orderalone") = 0
        oDataRow1("no_publicauction") = 1
        oDataRow1("status_id") = 1
        oDataRow1("lang1_description") = "Custom Jewelry"
        oDataRow1("lang2_description") = ""
        oDataRow1("lang3_description") = ""
        oDataRow1("lang4_description") = ""
        oDataRow1("lang5_description") = ""
        oDataRow1("lang6_description") = ""
        oDataRow1("createdate") = System.Convert.ToDateTime(Now)
        oDataRow1("onprocess") = 0
        oDataRow1("onauction") = 0
        oDataRow1("club_item") = 0
        oDataRow1("onspecial") = 0
        oDataRow1("onspecial_from_date") = #1/1/1900#
        oDataRow1("onspecial_to_date") = #1/1/1900#
        oDataRow1("qtyonstock_cur") = 1
        oDataRow1("qtyonstock_min") = 0
        oDataRow1("purchase_price") = nCostPrice
        oDataRow1("appraisal_price") = nAppraisalPrice
        oDataRow1("dealer_price") = nDealerPrice
        oDataRow1("sell_price") = nSellPrice
        oDataRow1("special_sell_price") = 0
        oDataRow1("special_dealer_price") = 0
        oDataRow1("notes") = ""
        oDataRow1("remarks") = "Item is autogenerated due to reconsile in order: " + cOrderNumber
        oDataRow1("indexwords") = ""
        oDataRow1("lastmodify_user") = System.Convert.ToString(Session("user").user_name)
        oDataRow1("lastmodify_date") = System.Convert.ToDateTime(Now)
        oDataRow1("lastmodify_user_id") = System.Convert.ToInt16(Session("user").user_id)
        oDataRow1("icon_name") = ""
        oDataRow1("picture_name") = ""
        oDataRow1("picture_hires_name") = ""
        oDataRow1("certificate_name") = ""
        oDataRow1("movie_name") = ""
        oDataRow1("autogenerated") = 1
        oDataRow1("item_sold") = 0

        oDataTable1.Rows.Add(oDataRow1)

        Dim oDataTable2 As DataTable = oPlate.dataset.Tables("inv_JEWELRY")
        Dim oDataRow2 As DataRow
        oDataRow2 = oDataTable2.NewRow()

        oDataRow2("id") = 0
        oDataRow2("weight") = 0
        oDataRow2("item_size") = 0
        oDataRow2("jeweltype_id") = 9
        oDataRow2("jewelsubtype_id") = 37
        oDataRow2("metal_id") = 1
        oDataRow2("middlestone_id") = 0
        oDataRow2("brand_id") = 6
        oDataRow2("report_id") = 1
        oDataRow2("SETTING_ID") = 1
        oDataRow2("COLLECTION_ID") = 1
        oDataRow2("RELATEDITEM_ID") = 1
        oDataRow2("MIDDLESTONE_DESC") = ""

        oDataTable2.Rows.Add(oDataRow2)


        '--- Addplate
        bError = oPlate.insert_plate
        If bError Then
            '--- when object is called in external DLL
            Session("error").err_number = oPlate.error_no
            Session("error").err_source = oPlate.error_source
            Session("error").err_description = oPlate.error_desc
            '--- Custom error
            Dim oTmpDB As New System.Diagnostics.StackFrame()
            Session("error").app_module = Me.Request.CurrentExecutionFilePath
            Session("error").app_function = oTmpDB.GetMethod.Name
            Session("error").app_call = "ion_resources.cls_ion_plate_lgc / Insert_Plate"
            Server.Transfer("/apperror.aspx")
        End If

        '--- Get Id and Number from Transaction
        Dim nId As Int32
        Dim cItemNumber As String
        Dim nItemCategory As Int16

        nId = oPlate.itemid
        cItemNumber = oPlate.itemnumber
        nItemCategory = oPlate.itemcategory

        '--- release object
        oPlate = Nothing

        '--- Add new Item to cart
        Dim oTmp As New ion_resources.cls_itemnumber()
        oTmp.connection_string = Application("config").connection_string
        bError = oTmp.GetItemIdFromNumber(cItemNumber)
        oCart.ItemAdd(oTmp.id)

        oTmp = Nothing

        Session("oTmpCart") = oCart

        Me.Visible = False

        Exit Sub

ErrorHandler:
        '--- when object is called in external DLL
        Session("error").err_number = Err.Number
        Session("error").err_source = Err.Source
        Session("error").err_description = Err.Description
        '--- Custom error
        Dim oTmpErrDB As New System.Diagnostics.StackFrame()
        Session("error").app_module = Me.Request.CurrentExecutionFilePath
        Session("error").app_function = oTmpErrDB.GetMethod.Name
        Session("error").app_call = "btn_reconsile_Click"
        Server.Transfer("/apperror.aspx")

    End Sub

    Private Function TotalItems(ByRef nSellPrice As Decimal, ByRef nCostPrice As Decimal, ByRef nAppraisalPrice As Decimal, ByRef nDealerPrice As Decimal) As Boolean
        Dim bError As Boolean = False
        '--- 1=itemid, 2=quantity sold, 3=itemnumber
        Dim aItems(20, 3)


        '--- 1
        If Me.chk_reconsile_1.Checked Then
            nSellPrice = nSellPrice + oCart.shopitem.Item(1).total_price
            aItems(1, 1) = oCart.shopitem.Item(1).id
            aItems(1, 2) = oCart.shopitem.Item(1).quantity
            aItems(1, 3) = oCart.shopitem.Item(1).itemnumber
        End If

        '--- 2
        If Me.chk_reconsile_2.Checked Then
            nSellPrice = nSellPrice + oCart.shopitem.Item(2).total_price
            aItems(2, 1) = oCart.shopitem.Item(2).id
            aItems(2, 2) = oCart.shopitem.Item(2).quantity
            aItems(2, 3) = oCart.shopitem.Item(2).itemnumber
        End If

        '--- 3
        If Me.chk_reconsile_3.Checked Then
            nSellPrice = nSellPrice + oCart.shopitem.Item(3).total_price
            aItems(3, 1) = oCart.shopitem.Item(3).id
            aItems(3, 2) = oCart.shopitem.Item(3).quantity
            aItems(3, 3) = oCart.shopitem.Item(3).itemnumber
        End If

        '--- 4
        If Me.chk_reconsile_4.Checked Then
            nSellPrice = nSellPrice + oCart.shopitem.Item(4).total_price
            aItems(4, 1) = oCart.shopitem.Item(4).id
            aItems(4, 2) = oCart.shopitem.Item(4).quantity
            aItems(4, 3) = oCart.shopitem.Item(4).itemnumber
        End If

        '--- 5
        If Me.chk_reconsile_5.Checked Then
            nSellPrice = nSellPrice + oCart.shopitem.Item(5).total_price
            aItems(5, 1) = oCart.shopitem.Item(5).id
            aItems(5, 2) = oCart.shopitem.Item(5).quantity
            aItems(5, 3) = oCart.shopitem.Item(5).itemnumber
        End If

        '--- 6
        If Me.chk_reconsile_6.Checked Then
            nSellPrice = nSellPrice + oCart.shopitem.Item(6).total_price
            aItems(6, 1) = oCart.shopitem.Item(6).id
            aItems(6, 2) = oCart.shopitem.Item(6).quantity
            aItems(6, 3) = oCart.shopitem.Item(6).itemnumber
        End If

        '--- 7
        If Me.chk_reconsile_7.Checked Then
            nSellPrice = nSellPrice + oCart.shopitem.Item(7).total_price
            aItems(7, 1) = oCart.shopitem.Item(7).id
            aItems(7, 2) = oCart.shopitem.Item(7).quantity
            aItems(7, 3) = oCart.shopitem.Item(7).itemnumber
        End If

        '--- 8
        If Me.chk_reconsile_8.Checked Then
            nSellPrice = nSellPrice + oCart.shopitem.Item(8).total_price
            aItems(8, 1) = oCart.shopitem.Item(8).id
            aItems(8, 2) = oCart.shopitem.Item(8).quantity
            aItems(8, 3) = oCart.shopitem.Item(8).itemnumber
        End If

        '--- 9
        If Me.chk_reconsile_9.Checked Then
            nSellPrice = nSellPrice + oCart.shopitem.Item(9).total_price
            aItems(9, 1) = oCart.shopitem.Item(9).id
            aItems(9, 2) = oCart.shopitem.Item(9).quantity
            aItems(9, 3) = oCart.shopitem.Item(9).itemnumber
        End If

        '--- 10
        If Me.chk_reconsile_10.Checked Then
            nSellPrice = nSellPrice + oCart.shopitem.Item(10).total_price
            aItems(10, 1) = oCart.shopitem.Item(10).id
            aItems(10, 2) = oCart.shopitem.Item(10).quantity
            aItems(10, 3) = oCart.shopitem.Item(10).itemnumber
        End If

        '--- 11
        If Me.chk_reconsile_11.Checked Then
            nSellPrice = nSellPrice + oCart.shopitem.Item(11).total_price
            aItems(11, 1) = oCart.shopitem.Item(11).id
            aItems(11, 2) = oCart.shopitem.Item(11).quantity
            aItems(11, 3) = oCart.shopitem.Item(11).itemnumber
        End If

        '--- 12
        If Me.chk_reconsile_12.Checked Then
            nSellPrice = nSellPrice + oCart.shopitem.Item(12).total_price
            aItems(12, 1) = oCart.shopitem.Item(12).id
            aItems(12, 2) = oCart.shopitem.Item(12).quantity
            aItems(12, 3) = oCart.shopitem.Item(12).itemnumber
        End If

        '--- 13
        If Me.chk_reconsile_13.Checked Then
            nSellPrice = nSellPrice + oCart.shopitem.Item(13).total_price
            aItems(13, 1) = oCart.shopitem.Item(13).id
            aItems(13, 2) = oCart.shopitem.Item(13).quantity
            aItems(13, 3) = oCart.shopitem.Item(13).itemnumber
        End If

        '--- 14
        If Me.chk_reconsile_14.Checked Then
            nSellPrice = nSellPrice + oCart.shopitem.Item(14).total_price
            aItems(14, 1) = oCart.shopitem.Item(14).id
            aItems(14, 2) = oCart.shopitem.Item(14).quantity
            aItems(14, 3) = oCart.shopitem.Item(14).itemnumber
        End If

        '--- 15
        If Me.chk_reconsile_15.Checked Then
            nSellPrice = nSellPrice + oCart.shopitem.Item(15).total_price
            aItems(15, 1) = oCart.shopitem.Item(15).id
            aItems(15, 2) = oCart.shopitem.Item(15).quantity
            aItems(15, 3) = oCart.shopitem.Item(15).itemnumber
        End If

        '--- 16
        If Me.chk_reconsile_16.Checked Then
            nSellPrice = nSellPrice + oCart.shopitem.Item(16).total_price
            aItems(16, 1) = oCart.shopitem.Item(16).id
            aItems(16, 2) = oCart.shopitem.Item(16).quantity
            aItems(16, 3) = oCart.shopitem.Item(16).itemnumber
        End If

        '--- 17
        If Me.chk_reconsile_17.Checked Then
            nSellPrice = nSellPrice + oCart.shopitem.Item(17).total_price
            aItems(17, 1) = oCart.shopitem.Item(17).id
            aItems(17, 2) = oCart.shopitem.Item(17).quantity
            aItems(17, 3) = oCart.shopitem.Item(17).itemnumber
        End If

        '--- 18
        If Me.chk_reconsile_18.Checked Then
            nSellPrice = nSellPrice + oCart.shopitem.Item(18).total_price
            aItems(18, 1) = oCart.shopitem.Item(18).id
            aItems(18, 2) = oCart.shopitem.Item(18).quantity
            aItems(18, 3) = oCart.shopitem.Item(18).itemnumber
        End If

        '--- 19
        If Me.chk_reconsile_19.Checked Then
            nSellPrice = nSellPrice + oCart.shopitem.Item(19).total_price
            aItems(19, 1) = oCart.shopitem.Item(19).id
            aItems(19, 2) = oCart.shopitem.Item(19).quantity
            aItems(19, 3) = oCart.shopitem.Item(19).itemnumber
        End If

        '--- 20
        If Me.chk_reconsile_20.Checked Then
            nSellPrice = nSellPrice + oCart.shopitem.Item(20).total_price
            aItems(20, 1) = oCart.shopitem.Item(20).id
            aItems(20, 2) = oCart.shopitem.Item(20).quantity
            aItems(20, 3) = oCart.shopitem.Item(20).itemnumber
        End If

        '--- Calculte prices
        Dim nSellPrice_perc As Decimal = Application("defaults").inv_sellprice
        Dim nDealerPrice_perc As Decimal = Application("defaults").inv_dealerprice
        Dim nAppraisalPrice_perc As Decimal = Application("defaults").inv_appraisalprice

        '--- adjust sellprice to be dealerprice
        Dim nTmpPrice As Decimal = nSellPrice
        If oCart.dealer Then
            nDealerPrice = nTmpPrice
            nCostPrice = (nTmpPrice / nDealerPrice_perc) * 100
            nAppraisalPrice = (nCostPrice / 100) * nAppraisalPrice_perc
            nSellPrice = (nCostPrice / 100) * nSellPrice_perc

        Else
            nCostPrice = (nTmpPrice / nSellPrice_perc) * 100
            nDealerPrice = (nCostPrice / 100) * nDealerPrice_perc
            nAppraisalPrice = (nCostPrice / 100) * nAppraisalPrice_perc
            nSellPrice = nTmpPrice

        End If


        '--- Remove Items
        Dim oMarkItem As New ion_resources.cls_functions_inventory()
        Dim bNotify As Boolean
        oMarkItem.connection_string = Application("config").connection_string
        Dim nLoop As Int16
        For nLoop = 1 To 20
            If aItems(nLoop, 1) <> Nothing Then
                bError = delete_itemfromcart(aItems(nLoop, 1))

                '--- Set reconsiled items to SOLD
                bError = oMarkItem.mark_item_sold(aItems(nLoop, 1), aItems(nLoop, 2), bNotify)
                If bNotify Then
                    '--- Send Email
                    Dim oMail As New ion_resources.cls_mail()
                    oMail.oconfig = Application("config")
                    oMail.ouser = Session("user")
                    oMail.oerror = Session("error")
                    oMail.ocart = Session("cart")

                    oMail.mailto = Application("config").mail_webadmin
                    oMail.subject = "Item number " & aItems(nLoop, 3) & " just went below stock!"
                    oMail.hiddencontent = "Item number " & aItems(nLoop, 3) & " just went below stock!<br><br>"
                    oMail.hiddencontent = oMail.hiddencontent + "<a href='" & Application("config").domain & "//inventory/edititem.aspx?mode=2&id=" & aItems(nLoop, 1) & "'>Click here to edit item</a>"
                    oMail.contenttype = 52
                    oMail.local_domain = Application("config").domain
                    'bError = oMail.send()

                End If

            End If
        Next


    End Function


    Private Function delete_itemfromcart(ByVal nId) As Boolean
        Dim bError As Boolean = False
        Dim bRemoved As Boolean = False

        bError = oCart.ItemRemove(nId, bRemoved)
    End Function



End Class
