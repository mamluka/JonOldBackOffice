Imports eBay.Service.Core.Soap
Imports eBay.Service.Core.Sdk
Imports eBay.Service.Call
Imports eBay.Service.Util
Imports System.Xml
Imports System.Text.RegularExpressions
Partial Class twinlister
    Inherits System.Web.UI.Page
    Public oapicontext As New ApiContext
    Public oapicontext2 As New ApiContext
    ''   Public oPlate As New ion_two.skl_lst_inventory
#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub

    'NOTE: The following placeholder declaration is required by the Web Form Designer.
    'Do not delete or move it.
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub

#End Region

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Put user code to initialize the page here


        '' If Not Me.e_secondsite.Checked Then
        oapicontext.ApiCredential.ApiAccount.Application = "Twin-Dia-3f18-4f05-b81a-4ce4ba64f7a4"
        oapicontext.ApiCredential.ApiAccount.Certificate = "caad245f-7914-4ece-8ada-7a1edfb4453c"
        oapicontext.ApiCredential.ApiAccount.Developer = "57244916-441d-48cc-a2f4-7d3ea3b68472"

        oapicontext.ApiCredential.eBayAccount.Password = "37733773"
        oapicontext.ApiCredential.eBayAccount.UserName = "avigem"

        'oapicontext.ApiCredential.eBayAccount.Password = "avi591"
        'oapicontext.ApiCredential.eBayAccount.UserName = "gems-wholesaler"
        oapicontext.ApiCredential.eBayToken = "AgAAAA**AQAAAA**aAAAAA**b+lOSw**nY+sHZ2PrBmdj6wVnY+sEZ2PrA2dj6wJnYahDJCDogWdj6x9nY+seQ**OloAAA**AAMAAA**WmFQzdoX0A4gkFg3iYKyYjFlh3XiO1RFLT5wNqKtHdHkzWeF3pqDbCGLUdb9/FsH9yXGXCmxI5DvWYXOpKRs77KKIG3GaCOmz4Ii62XECIMJvh0aJFvg/LpKt4VFa/zfuNc3FS82SX0dlLmIw7nWyGOlvq/ZKChpPHvLVrrFZ++yfJIJVcKg6qbp08DO1bgsp8eWvsOufVTGDI+GkKy3bcQLfc/7Hm3yG+dnM4T5DRQIVZ/B498VJuVpO3xZEcNOLZVelzgtjDWUAfOxfM8qwd4d3cgVI8g3X6wHZeIDMNFMqewVN5m4hY4twTo82q3uYJmnGUXj1CkCA5mkznNRRPzz8tffVmcVwl/yUdtCCEU/KCR+bq3aK+PpBnIo5EiGIAtq606smCNve+53uDlL3WeF9AdtvETbYD+SxxBiaGRLEjnF3IwatsJ511trGQBJB2OBlDRj/2q7MnRP4x08HYYt38Z5BtrE4LpDqngITPP/+rW/2AFpuzAmQNYJ4HxK3sxl0OQ31u5gp5N9oP2bZOLJ/C9L7d0HvyLzNotp/KgDtsvy4NJDdAa7zdb9lz8dhEVoblZusx0o/aSOMGC/dngH+0rYhyPGC1w0fHUKPOsdEoB7/OGb0mM6z0PlO7v5dUE8ZIoyN/UZk5OW6nP4tX98mcCCzxwodKUW56zZ7v/5IQfvTbIIMPfDRGMtYJEmEnaoKt5Eufj+NY8RoLrWphtxoGooj81FspJmOcoMq+IdIFnN0NOM73RUtQhvHMTU"

        oapicontext.SoapApiServerUrl = "https://api.ebay.com/wsapi"
        oapicontext.EPSServerUrl = "http://msa-b1.ebay.com/ws/eBayISAPI.dll?EpsBasicApp"

        ''
        '' Else
        oapicontext2.ApiCredential.ApiAccount.Application = "Twin-Dia-3f18-4f05-b81a-4ce4ba64f7a4"
        oapicontext2.ApiCredential.ApiAccount.Certificate = "caad245f-7914-4ece-8ada-7a1edfb4453c"
        oapicontext2.ApiCredential.ApiAccount.Developer = "57244916-441d-48cc-a2f4-7d3ea3b68472"

        oapicontext2.ApiCredential.eBayAccount.Password = "37733773"
        oapicontext2.ApiCredential.eBayAccount.UserName = "avigem"

        oapicontext2.ApiCredential.eBayToken = "AgAAAA**AQAAAA**aAAAAA**b+lOSw**nY+sHZ2PrBmdj6wVnY+sEZ2PrA2dj6wJnYahDJCDogWdj6x9nY+seQ**OloAAA**AAMAAA**WmFQzdoX0A4gkFg3iYKyYjFlh3XiO1RFLT5wNqKtHdHkzWeF3pqDbCGLUdb9/FsH9yXGXCmxI5DvWYXOpKRs77KKIG3GaCOmz4Ii62XECIMJvh0aJFvg/LpKt4VFa/zfuNc3FS82SX0dlLmIw7nWyGOlvq/ZKChpPHvLVrrFZ++yfJIJVcKg6qbp08DO1bgsp8eWvsOufVTGDI+GkKy3bcQLfc/7Hm3yG+dnM4T5DRQIVZ/B498VJuVpO3xZEcNOLZVelzgtjDWUAfOxfM8qwd4d3cgVI8g3X6wHZeIDMNFMqewVN5m4hY4twTo82q3uYJmnGUXj1CkCA5mkznNRRPzz8tffVmcVwl/yUdtCCEU/KCR+bq3aK+PpBnIo5EiGIAtq606smCNve+53uDlL3WeF9AdtvETbYD+SxxBiaGRLEjnF3IwatsJ511trGQBJB2OBlDRj/2q7MnRP4x08HYYt38Z5BtrE4LpDqngITPP/+rW/2AFpuzAmQNYJ4HxK3sxl0OQ31u5gp5N9oP2bZOLJ/C9L7d0HvyLzNotp/KgDtsvy4NJDdAa7zdb9lz8dhEVoblZusx0o/aSOMGC/dngH+0rYhyPGC1w0fHUKPOsdEoB7/OGb0mM6z0PlO7v5dUE8ZIoyN/UZk5OW6nP4tX98mcCCzxwodKUW56zZ7v/5IQfvTbIIMPfDRGMtYJEmEnaoKt5Eufj+NY8RoLrWphtxoGooj81FspJmOcoMq+IdIFnN0NOM73RUtQhvHMTU"
        oapicontext2.SoapApiServerUrl = "https://api.ebay.com/wsapi"
        oapicontext2.EPSServerUrl = "http://msa-b1.ebay.com/ws/eBayISAPI.dll?EpsBasicApp"

        ''  End If
        'Dim fetchedItem As ItemType

        'Dim Apicall As GetItemCall = New GetItemCall(oapicontext)
        'Apicall.DetailLevelList.Add(DetailLevelCodeType.ReturnAll)
        'fetchedItem = Apicall.GetItem("320218380161")



        If Not Page.IsPostBack Then
            Me.LoadCombos()
            Me.LoadPlate(4646)

            Dim ogetstore As New GetStoreCall(oapicontext)
            ogetstore.DetailLevelList.Add(DetailLevelCodeType.ReturnAll)
            ogetstore.CategoryStructureOnly = True

            ogetstore.LevelLimit = 3


            Dim ostore As StoreType = ogetstore.GetStore()
            Dim i As Int32
            For i = 0 To ostore.CustomCategories.Count - 1
                If ostore.CustomCategories(i).ChildCategory.Count > 0 Then
                    Me.e_store_main_cat.Items.Add(New WebControls.ListItem("-" + ostore.CustomCategories(i).Name(), ostore.CustomCategories(i).CategoryID))
                    Me.e_store_second_cat.Items.Add(New WebControls.ListItem("-" + ostore.CustomCategories(i).Name(), ostore.CustomCategories(i).CategoryID))
                    Dim j As Int32

                    For j = 0 To ostore.CustomCategories(i).ChildCategory.Count - 1
                        Me.e_store_main_cat.Items.Add(New WebControls.ListItem("-----" + ostore.CustomCategories(i).ChildCategory(j).Name, ostore.CustomCategories(i).ChildCategory(j).CategoryID))
                        Me.e_store_second_cat.Items.Add(New WebControls.ListItem("-----" + ostore.CustomCategories(i).ChildCategory(j).Name, ostore.CustomCategories(i).ChildCategory(j).CategoryID))
                        Dim k As Int32
                        If ostore.CustomCategories(i).ChildCategory(j).ChildCategory.Count > 0 Then
                            For k = 0 To ostore.CustomCategories(i).ChildCategory(j).ChildCategory.Count - 1
                                Me.e_store_main_cat.Items.Add(New WebControls.ListItem("--------" + ostore.CustomCategories(i).ChildCategory(j).ChildCategory(k).Name, ostore.CustomCategories(i).ChildCategory(j).ChildCategory(k).CategoryID))
                                Me.e_store_second_cat.Items.Add(New WebControls.ListItem("--------" + ostore.CustomCategories(i).ChildCategory(j).ChildCategory(k).Name, ostore.CustomCategories(i).ChildCategory(j).ChildCategory(k).CategoryID))
                            Next
                        End If

                    Next
                Else
                    Me.e_store_main_cat.Items.Add(New WebControls.ListItem(" " + ostore.CustomCategories(i).Name(), ostore.CustomCategories(i).CategoryID))
                    Me.e_store_second_cat.Items.Add(New WebControls.ListItem(" " + ostore.CustomCategories(i).Name(), ostore.CustomCategories(i).CategoryID))
                End If
            Next


            ''javascript

            Me.catPath.Attributes.Add("onchange", "RemoveCategory(this)")
            Me.catPath2.Attributes.Add("onchange", "RemoveCategory(this)")

            Me.e_selling_format.Attributes.Add("onchange", "ChangeDurationByAuctionType(this.selectedIndex)")



            '    Dim typeselector As Int32 = 1
            '    Dim cat_zero = ocatlist(0).CategoryLevel
            '    For Each cat As CategoryType In ocatlist
            '        Select Case Me.e_site.SelectedValue
            '            Case 1, 2
            '                Select Case cat.CategoryID
            '                    Case 491
            '                        typeselector = 1
            '                    Case 67725
            '                        typeselector = 2
            '                    Case 10985
            '                        typeselector = 3
            '                    Case 10994
            '                        typeselector = 4
            '                    Case Else
            '                        typeselector = typeselector
            '                End Select
            '            Case 2
            '                Select Case cat.CategoryID
            '                    Case 110742
            '                        typeselector = 1
            '                    Case 10210, 152810
            '                        typeselector = 2
            '                    Case 10975, 11317, 10985
            '                        typeselector = 3
            '                    Case 67725
            '                        typeselector = 4
            '                    Case Else
            '                        typeselector = typeselector
            '                End Select
            '            Case 3
            '                Select Case cat.CategoryID
            '                    Case 491
            '                        typeselector = 1
            '                    Case 155096
            '                        typeselector = 2
            '                    Case 155115
            '                        typeselector = 3
            '                    Case 67725
            '                        typeselector = 4
            '                    Case Else
            '                        typeselector = typeselector
            '                End Select
            '            Case 6
            '        End Select

            '        Dim space As String
            '        Dim j As Int32 = 0
            '        space = ""
            '        For j = cat_zero + 2 To cat.CategoryLevel
            '            space += "----"
            '        Next
            '        If cat.LeafCategory Then

            '            Select Case typeselector
            '                Case 1
            '                    Me.e_primery_cat.Items.Add(New WebControls.ListItem(space + cat.CategoryName, cat.CategoryID.ToString))
            '                    Me.e_second_cat.Items.Add(New WebControls.ListItem(space + cat.CategoryName, cat.CategoryID.ToString))
            '                Case 2
            '                    Me.e_primery_cat_2.Items.Add(New WebControls.ListItem(space + cat.CategoryName, cat.CategoryID.ToString))
            '                    Me.e_second_cat_2.Items.Add(New WebControls.ListItem(space + cat.CategoryName, cat.CategoryID.ToString))
            '                Case 3
            '                    Me.e_primery_cat_3.Items.Add(New WebControls.ListItem(space + cat.CategoryName, cat.CategoryID.ToString))
            '                    Me.e_second_cat_3.Items.Add(New WebControls.ListItem(space + cat.CategoryName, cat.CategoryID.ToString))
            '                Case 4
            '                    Me.e_primery_cat_4.Items.Add(New WebControls.ListItem(space + cat.CategoryName, cat.CategoryID.ToString))
            '                    Me.e_second_cat_4.Items.Add(New WebControls.ListItem(space + cat.CategoryName, cat.CategoryID.ToString))
            '            End Select


            '        Else
            '            Select Case typeselector
            '                Case 1
            '                    Me.e_primery_cat.Items.Add(New WebControls.ListItem(space + cat.CategoryName, "0"))
            '                    Me.e_second_cat.Items.Add(New WebControls.ListItem(space + cat.CategoryName, "0"))
            '                Case 2
            '                    Me.e_primery_cat_2.Items.Add(New WebControls.ListItem(space + cat.CategoryName, "0"))
            '                    Me.e_second_cat_2.Items.Add(New WebControls.ListItem(space + cat.CategoryName, "0"))
            '                Case 3
            '                    Me.e_primery_cat_3.Items.Add(New WebControls.ListItem(space + cat.CategoryName, "0"))
            '                    Me.e_second_cat_3.Items.Add(New WebControls.ListItem(space + cat.CategoryName, "0"))
            '                Case 4
            '                    Me.e_primery_cat_4.Items.Add(New WebControls.ListItem(space + cat.CategoryName, "0"))
            '                    Me.e_second_cat_4.Items.Add(New WebControls.ListItem(space + cat.CategoryName, "0"))
            '            End Select
            '        End If
            '    Next
        End If





        'Dim oebaydetails As New GeteBayDetailsCall(oapicontext)
        'Dim oebaydetailslist As New DetailNameCodeTypeCollection
        'Dim oebaydetailsitem As New DetailNameCodeType
        'oebaydetailslist.Add(DetailNameCodeType.RegionDetails)
        '''oebaydetalsite\.ShippingServiceDetails()
        'oebaydetails.Site = SiteCodeType.US

        'oebaydetails.GeteBayDetails(oebaydetailslist)
        'Me.e_itemid.Text = oebaydetails.ShippingServiceDetailList.Count.ToString

        '''   Me.e_second_cat.Items.Clear()
        'For Each detail As RegionDetailsType In oebaydetails.RegionDetailList
        '    Me.e_shipping_services.Items.Add(detail.Description)
        'Next

        ''Dim oebaydetails As New GeteBayDetailsCall(oapicontext)
        ''Dim oebaydetailslist As New DetailNameCodeTypeCollection
        ''Dim oebaydetailsitem As New DetailNameCodeType
        'oebaydetailslist.Add(DetailNameCodeType.ShippingServiceDetails)
        '''oebaydetalsite\.ShippingServiceDetails()
        'oebaydetails.Site = SiteCodeType.UK


        'oebaydetails.GeteBayDetails(oebaydetailslist)
        'Me.e_itemid.Text = oebaydetails.ShippingServiceDetailList.Count.ToString

        '''   Me.e_second_cat.Items.Clear()
        'For Each detail As ShippingServiceDetailsType In oebaydetails.ShippingServiceDetailList
        '    Me.e_shipping_services.Items.Add(detail.ShippingService)
        'Next

        'oebaydetailslist.Add(DetailNameCodeType.ShippingServiceDetails)
        '''oebaydetalsite\.ShippingServiceDetails()
        'oebaydetails.Site = SiteCodeType.Australia


        'oebaydetails.GeteBayDetails(oebaydetailslist)
        'Me.e_itemid.Text = oebaydetails.ShippingServiceDetailList.Count.ToString

        '''   Me.e_second_cat.Items.Clear()
        'For Each detail As ShippingServiceDetailsType In oebaydetails.ShippingServiceDetailList
        '    Me.e_shipping_services.Items.Add(detail.ShippingService)
        'Next

        'oebaydetailslist.Add(DetailNameCodeType.ShippingServiceDetails)
        '''oebaydetalsite\.ShippingServiceDetails()
        'oebaydetails.Site = SiteCodeType.France


        'oebaydetails.GeteBayDetails(oebaydetailslist)
        'Me.e_itemid.Text = oebaydetails.ShippingServiceDetailList.Count.ToString

        '''   Me.e_second_cat.Items.Clear()
        'For Each detail As ShippingServiceDetailsType In oebaydetails.ShippingServiceDetailList
        '    Me.e_shipping_services.Items.Add(detail.ShippingService)
        'Next
        'Dim ocat As GetCategoriesCall = New GetCategoriesCall(oapicontext)

        'Dim ocatlist As New CategoryTypeCollection



        'ocat.Site = SiteCodeType.US
        'ocat.LevelLimit = 4
        'ocat.ViewAllNodes = True
        'ocat.DetailLevelList.Add(DetailLevelCodeType.ReturnAll)

        ''' ocat.CategoryParent = New StringCollection
        ''' ocat.CategoryParent.Add("Loose Diamonds & Gemstones")


        'ocatlist = ocat.GetCategories()

        'Me.e_primery_category.Items.Add(ocatlist(0).CategoryName)

        'Dim ocat1 As New CategoryType

        'For Each ocat1 In ocatlist
        '    If ocat1.LeafCategory Then
        '        Me.e_primery_category.Items.Add(" + " + ocat1.CategoryName)
        '    Else

        '        Me.e_primery_category.Items.Add(ocat1.CategoryName)
        '    End If
        'Next
        'Dim i As Int32
        'For i = 0 To ocat.CategoryCount
        '    Me.e_primery_category.Items.Add(ocat.CategoryList(i).CategoryName)
        'Next

        ''ocat.CategoryList



        'Me.e_selling_format.Items.Add(itemlist.Count)
        'For Each item As ItemType In itemlist
        '    Me.e_selling_format.Items.Add(item.SKU)
        'Next

    End Sub

    Public Function LoadCombos()

        '     Me.LoadCombo("primery_cat", Me.e_primery_cat)
        Me.LoadCombo("auction_type", Me.e_selling_format)
        Me.LoadCombo("duration", Me.e_duration)
        Me.LoadCombo("shipping", Me.e_shipping)

    End Function

    Public Function LoadCombo(ByVal comboid As String, ByRef combo As WebControls.DropDownList)

        Dim oxml As New ion_two.cls_nd_xmlread
        oxml.xml_file = Server.MapPath("/ebay/combos.xml")
        oxml.Load()
        Dim items As XmlNodeList = oxml.GetNodes_ByPath("combo[@id='" + comboid + "']/item")
        Dim i As Int32 = 0
        For Each item As XmlNode In items

            combo.Items.Add(New WebControls.ListItem(item.InnerText, item.Attributes("val").InnerText))
            If Not IsNothing(item.Attributes("default")) Then

                combo.SelectedIndex = i
            End If
            i += 1

        Next

    End Function

    Function LoadPlate(ByVal id As Int32)

        id = Convert.ToInt32(Request.QueryString("id"))

        Dim oTmpInventory As New ion_two.cls_inventory_lgc
        oTmpInventory._connection_string = Application("config").connection_string
        oTmpInventory._dbtype = Application("config").connection_string_type

        Dim oPlate As New ion_two.skl_lst_inventory
        Dim opicture As New ion_two.cls_pictures
        opicture.load("http://www.twin-diamonds.com", "https://www.twin-diamonds.com")

        oTmpInventory.load(id, oPlate, opicture)

        If Not Page.IsPostBack Then







            ''Me.oPlate = oPlate

            Me.e_title.Text = oPlate._item_description
            Me.e_u_gallery_pic.Checked = True

            Me.e_picture.ImageUrl = oPlate._picture_pic


            Me.e_inventory_code.Text = oPlate._itemnumber
            Me.e_apramount.Text = Convert.ToString(oPlate._appraisal_price)
            Me.e_price.Text = oPlate._sell_price.ToString

            Me.e_qty.Text = "1"
            Me.e_officelink.NavigateUrl = "/inventory/edititem.aspx?mode=2&id=" + id.ToString

            Dim oconv As New net.webservicex.www.CurrencyConvertor
            Dim conv_rate As Double = 1
            Select Case Me.e_site.SelectedValue
                Case 1
                    conv_rate = 1
                    Me.e_cur_apr.Text = "us$"
                    Me.e_cur_price.Text = "us$"
                Case 2
                    conv_rate = oconv.ConversionRate(net.webservicex.www.Currency.USD, net.webservicex.www.Currency.GBP)
                    Me.e_cur_apr.Text = "GBP"
                    Me.e_cur_price.Text = "GBP"

                Case 3
                    conv_rate = oconv.ConversionRate(net.webservicex.www.Currency.USD, net.webservicex.www.Currency.AUD)
                    Me.e_cur_apr.Text = "au$"
                    Me.e_cur_price.Text = "au$"
                Case 6
                    conv_rate = oconv.ConversionRate(net.webservicex.www.Currency.USD, net.webservicex.www.Currency.EUR)
                    Me.e_cur_apr.Text = "EUR"
                    Me.e_cur_price.Text = "EUR"
            End Select

            Me.e_price.Text = Math.Round((oPlate._sell_price * conv_rate)).ToString

            If Me.e_apramount.Text <> "" Then
                Me.e_apramount.Text = Math.Round((oPlate._appraisal_price * conv_rate)).ToString
            End If

            'Dim oxml As New ion_two.cls_nd_xmlread
            'oxml.xml_file = Server.MapPath("/ebaycat" + Me.e_site.SelectedValue + ".xml")
            'oxml.Load()
            'Dim autocat As XmlNodeList
            'Dim finelcat As XmlNode
            'Select Case Me.e_site.SelectedValue
            '    Case 1
            '        Select Case oPlate._platetype
            '            Case 2
            '                autocat = oxml.GetNodes_ByPath("item[@text='Loose Diamonds & Gemstones']/item[@text='Gemstones']/item[@text='" + oPlate._subplate._stonetype.replace("Natural ", "") + "']")
            '                If autocat(0).Attributes("child").InnerText = "1" Then
            '                    If Not IsNothing(autocat(0)(oPlate._subplate._shape.replace(" ", "_").replace(" Cut", ""))) Then
            '                        finelcat = autocat(0)(oPlate._subplate._shape)
            '                    Else
            '                        finelcat = autocat(0)(0)
            '                    End If
            '                End If
            '        End Select

            'End Select

            'Me.catPath.Text = finelcat("userdata").InnerText


        End If

        Dim hash As New Hashtable
        hash("id") = id.ToString
        '
        ''  Dim ohtml As New iFunctions.cls_html
        '' ohtml.EncodeURL2Quary(Me.TextBox2.Text)
        Dim ostringfunc As New iFunctions.cls_string



        ''Dim hash As New Hashtable
        If Me.e_alt_title.Text <> "" Then
            hash("title") = Me.e_alt_title.Text
        End If

        hash("shipping") = Me.e_shipping.SelectedValue.ToString
        hash("backoffice") = "1"
        hash("siteid") = Me.e_site.SelectedValue
        hash("apramount") = Me.e_apramount.Text
        If Me.chk_clarity.Checked Then
            hash("clarity") = "1"
        End If

        If Me.e_desc.Text <> "" Then
            hash("desc") = ostringfunc.EncodeProblematicChars(Me.e_desc.Text)
        End If
        Dim qs As String = ostringfunc.EncodeQuaryString(hash)

        Dim body As String
        Dim omail As New ion_two.cls_mod_mail
        If Me.e_secondsite.Checked Then
            omail.getHTML_byURL("http://www.twin-diamonds.com/ebay/verynewswhow2.aspx" + qs, body)
        Else
            omail.getHTML_byURL("http://www.twin-diamonds.com/ebay/verynewswhow.aspx" + qs, body)
        End If

        If Me.e_secondsite.Checked Then
            Me.e_preview.NavigateUrl = "http://www.twin-diamonds.com/ebay/verynewswhow2.aspx" + qs
        Else
            Me.e_preview.NavigateUrl = "http://www.twin-diamonds.com/ebay/verynewswhow.aspx" + qs
        End If

        Me.e_onsite.NavigateUrl = "http://www.twin-diamonds.com/catalog/myitemv3.aspx?id=" + id.ToString

        Me.e_html.Text = body


        Me.e_specs.Text = Regex.Match(body, "<!--specs-->.+?<!--specs-->", RegexOptions.Singleline).Value

        If Not Page.IsPostBack Then

            Me.e_title.Text = Trim(Regex.Match(body, "<!--titlestart-->(.+?)<!--titleend-->", RegexOptions.Singleline).Groups(1).Value)
            Me.e_alt_title.Text = Trim(Regex.Match(body, "<!--titlestart-->(.+?)<!--titleend-->", RegexOptions.Singleline).Groups(1).Value)
            Me.e_title.Text = ostringfunc.ClearHTMLTagsReturn(Me.e_title.Text)
            Me.e_alt_title.Text = ostringfunc.ClearHTMLTagsReturn(Me.e_alt_title.Text)

            If Me.e_title.Text.Length > 55 Then
                Me.e_title.Text = Mid(Me.e_title.Text, 1, 52) + "..."
            End If
        End If



    End Function
    Function GetPlate() As ion_two.skl_lst_inventory

        ID = Convert.ToInt32(Request.QueryString("id"))

        Dim oTmpInventory As New ion_two.cls_inventory_lgc
        oTmpInventory._connection_string = Application("config").connection_string
        oTmpInventory._dbtype = Application("config").connection_string_type

        Dim oPlate As New ion_two.skl_lst_inventory
        Dim opicture As New ion_two.cls_pictures
        opicture.load("http://www.twin-diamonds.com", "https://www.twin-diamonds.com")

        oTmpInventory.load(ID, oPlate, opicture)

        Return oPlate
    End Function


    Private Sub Go_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Go.Click

        Dim item As ItemType = Me.SetItem


        If Not Me.e_secondsite.Checked Then
            Dim ApiCall As VerifyAddItemCall = New VerifyAddItemCall(oapicontext)


            ''ospecific.Source =


            ''  ocat.
            Select Case Me.e_site.SelectedValue
                Case 1
                    ApiCall.Site = SiteCodeType.US
                Case 2
                    ApiCall.Site = SiteCodeType.UK
                Case 3
                    ApiCall.Site = SiteCodeType.Australia
                Case 6
                    ApiCall.Site = SiteCodeType.France
            End Select

            If Me.e_picture.Visible = True Then
                ApiCall.PictureFileList = New StringCollection
                item.PictureDetails = New PictureDetailsType

                If Me.e_u_gallery_pic.Checked Then
                    item.PictureDetails.GalleryType = GalleryTypeCodeType.Gallery
                End If
                If Me.e_u_gallery_plus.Checked Then
                    item.PictureDetails.GalleryType = GalleryTypeCodeType.Plus
                End If

                item.PictureDetails.PhotoDisplay = [Enum].Parse(GetType(PhotoDisplayCodeType), "None")
                item.PictureDetails.PictureURL = New StringCollection
                item.PictureDetails.PictureURL.Add(Me.e_picture.ImageUrl)
            End If






            Dim fees As FeeTypeCollection = ApiCall.VerifyAddItem(item)
            Dim fee As FeeType



            For Each fee In fees
                If fee.Name = "ListingFee" Then
                    Me.e_fees.Text = fee.Fee.Value.ToString
                End If
            Next
        Else

            Dim ApiCall As VerifyAddItemCall = New VerifyAddItemCall(oapicontext2)


            ''ospecific.Source =


            ''  ocat.
            Select Case Me.e_site.SelectedValue
                Case 1
                    ApiCall.Site = SiteCodeType.US
                Case 2
                    ApiCall.Site = SiteCodeType.UK
                Case 3
                    ApiCall.Site = SiteCodeType.Australia
                Case 6
                    ApiCall.Site = SiteCodeType.France
            End Select

            If Me.e_picture.Visible = True Then
                ApiCall.PictureFileList = New StringCollection
                item.PictureDetails = New PictureDetailsType

                If Me.e_u_gallery_pic.Checked Then
                    item.PictureDetails.GalleryType = GalleryTypeCodeType.Gallery
                End If
                If Me.e_u_gallery_plus.Checked Then
                    item.PictureDetails.GalleryType = GalleryTypeCodeType.Plus
                End If

                item.PictureDetails.PhotoDisplay = [Enum].Parse(GetType(PhotoDisplayCodeType), "None")
                item.PictureDetails.PictureURL = New StringCollection
                item.PictureDetails.PictureURL.Add(Me.e_picture.ImageUrl)
            End If






            Dim fees As FeeTypeCollection = ApiCall.VerifyAddItem(item)
            Dim fee As FeeType



            For Each fee In fees
                If fee.Name = "ListingFee" Then
                    Me.e_fees.Text = fee.Fee.Value.ToString
                End If
            Next
        End If



    End Sub

    Private Sub e_shipping_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles e_shipping.SelectedIndexChanged
        Me.LoadPlate(4646)
    End Sub

    Private Sub e_desc_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles e_desc.TextChanged
        Me.LoadPlate(4646)
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Upload.Click




    End Sub

    Function SetItem() As ItemType
        Dim item As New ItemType

        item.SubTitle = Me.e_subtitle.Text
        item.Title = Me.e_title.Text
        item.Description = Me.e_html.Text


        Dim opay As New BuyerPaymentMethodCodeType
        opay = BuyerPaymentMethodCodeType.PayPal

        item.PaymentMethods = New BuyerPaymentMethodCodeTypeCollection

        item.PaymentMethods.Add(opay)
        opay = BuyerPaymentMethodCodeType.AmEx
        item.PaymentMethods.Add(opay)
        opay = BuyerPaymentMethodCodeType.VisaMC
        item.PaymentMethods.Add(opay)

        item.PayPalEmailAddress = "robi@twin-diamonds.com"

        '' Dim oducation As New ListingDurationCodeType

        '' item.ListingDuration = "GTC"

        item.PrimaryCategory = New CategoryType
        item.PrimaryCategory.CategoryID = Me.e_primary_id.Text
        'If Me.e_primery_cat.SelectedValue <> 0 And Me.e_primery_cat.SelectedIndex > 0 Then

        '    item.PrimaryCategory.CategoryID = Me.e_primery_cat.SelectedValue
        'End If
        'If Me.e_primery_cat_2.SelectedValue <> 0 And Me.e_primery_cat_2.SelectedIndex > 0 Then

        '    item.PrimaryCategory.CategoryID = Me.e_primery_cat_2.SelectedValue
        'End If

        'If Me.e_primery_cat_3.SelectedValue <> 0 And Me.e_primery_cat_3.SelectedIndex > 0 Then

        '    item.PrimaryCategory.CategoryID = Me.e_primery_cat_3.SelectedValue
        'End If

        'If Me.e_primery_cat_4.SelectedValue <> 0 And Me.e_primery_cat_4.SelectedIndex > 0 Then

        '    item.PrimaryCategory.CategoryID = Me.e_primery_cat_4.SelectedValue
        'End If

        ''dim otime as 
        If Me.e_use_sch.Checked Then

            item.ScheduleTime = DateTime.ParseExact(Me.e_sch_time.Text, "dd-MM-yyyy H:mm:ss", Nothing)
        End If

        'If Me.e_second_cat.SelectedValue <> 0 And Me.e_second_cat.SelectedIndex > 0 Then
        If Me.e_secondary_id.Text <> "" Then
            item.SecondaryCategory = New CategoryType
            item.SecondaryCategory.CategoryID = Me.e_secondary_id.Text
        End If
        '    item.SecondaryCategory.CategoryID = Me.e_second_cat.SelectedValue
        'End If

        'If Me.e_second_cat_2.SelectedValue <> 0 And Me.e_second_cat_2.SelectedIndex > 0 Then
        '    item.SecondaryCategory = New CategoryType
        '    item.SecondaryCategory.CategoryID = Me.e_second_cat_2.SelectedValue
        'End If

        'If Me.e_second_cat_3.SelectedValue <> 0 And Me.e_second_cat_3.SelectedIndex > 0 Then
        '    item.SecondaryCategory = New CategoryType
        '    item.SecondaryCategory.CategoryID = Me.e_second_cat_3.SelectedValue
        'End If

        'If Me.e_second_cat_4.SelectedValue <> 0 And Me.e_second_cat_4.SelectedIndex > 0 Then
        '    item.SecondaryCategory = New CategoryType
        '    item.SecondaryCategory.CategoryID = Me.e_second_cat_4.SelectedValue
        'End If



        item.Storefront = New StorefrontType
        item.Storefront.StoreCategoryID = Convert.ToInt32(Me.e_store_main_cat.SelectedValue)
        item.Storefront.StoreCategory2ID = Convert.ToInt32(Me.e_store_second_cat.SelectedValue)

        item.PrivateNotes = Me.e_inventory_code.Text
        ''  ocat.
        Select Case Me.e_site.SelectedValue
            Case 1
                item.Site = SiteCodeType.US
            Case 2
                item.Site = SiteCodeType.UK
            Case 3
                item.Site = SiteCodeType.Australia
            Case 6
                item.Site = SiteCodeType.France
        End Select



        '' item.ListingType = New ListingDetailsType
        'item.ListingType = ListingTypeCodeType.StoresFixedPrice

        item.Country = CountryCodeType.IL

        item.SkypeContactOption = New SkypeContactOptionCodeTypeCollection
        item.SkypeContactOption.Add(SkypeContactOptionCodeType.Voice)
        item.SkypeContactOption.Add(SkypeContactOptionCodeType.Chat)
        item.SkypeEnabled = True
        item.SkypeID = "avi.by"


        item.ShipToLocations = New StringCollection
        item.ShipToLocations.Add("Worldwide")

        item.ShippingTermsInDescription = True

        item.SellerInventoryID = Me.e_inventory_code.Text


        item.Location = "International Diamond Exchange"
        ''  item.PostalCode = "52222"

        item.Quantity = Convert.ToInt32(Me.e_qty.Text)

        item.Currency = Me.ReturnCurrencyType

        '  item.Currency =  Me.ReturnCurrencyType


        'item.ItemSpecifics = New NameValueListTypeCollection

        'Dim ospecific As New NameValueListType
        If Me.e_private.Checked Then
            item.PrivateListing = True
            item.PrivateListingSpecified = True
        End If

        item.DispatchTimeMax = 10
        ''type
        item.ListingType = New ListingTypeCodeType
        Select Case Me.e_selling_format.SelectedValue
            Case 1

                item.StartPrice = New AmountType
                item.StartPrice.currencyID = Me.ReturnCurrencyType


                item.StartPrice.Value = Convert.ToDouble(Me.e_price.Text)
                item.ListingType = ListingTypeCodeType.Chinese
            Case 2

                item.ListingType = ListingTypeCodeType.StoresFixedPrice
                item.StartPrice = New AmountType
                item.StartPrice.currencyID = Me.ReturnCurrencyType
                item.StartPrice.Value = Convert.ToDouble(Me.e_price.Text)
            Case 3
                item.ListingType = ListingTypeCodeType.FixedPriceItem
                item.StartPrice = New AmountType
                item.StartPrice.currencyID = Me.ReturnCurrencyType
                item.StartPrice.Value = Convert.ToDouble(Me.e_price.Text)

        End Select

        ''duration
        If Me.e_bestoffer.Checked Then
            item.BestOfferDetails = New BestOfferDetailsType


            item.BestOfferDetails.BestOfferEnabled = Me.e_bestoffer.Checked

            '' item.ListingDetails.
            item.BestOfferEnabled = Me.e_bestoffer.Checked
            If Me.e_min_bestoffer.Text <> "" Then
                item.ListingDetails = New ListingDetailsType
                item.ListingDetails.MinimumBestOfferPrice = New AmountType
                item.ListingDetails.MinimumBestOfferPrice.currencyID = Me.ReturnCurrencyType
                item.ListingDetails.MinimumBestOfferPrice.Value = Convert.ToDouble(Me.e_min_bestoffer.Text)
            End If
        End If

        item.ListingDuration = Me.e_duration.SelectedValue

        item.ShippingTermsInDescription = True




        item.ApplicationData = Me.e_inventory_code.Text
        item.SKU = Me.e_inventory_code.Text

        item.ReturnPolicy = New ReturnPolicyType

        item.ReturnPolicy.ReturnsWithin = "Days_30"
        item.ReturnPolicy.ReturnsWithinOption = "Days_30"
        item.ReturnPolicy.ReturnsAcceptedOption = "ReturnsAccepted"
        item.ReturnPolicy.RefundOption = "MoneyBack"

        item.ShippingDetails = New ShippingDetailsType

        'item.ShippingDetails.InsuranceOption = InsuranceOptionCodeType.NotOffered
        'item.ShippingDetails.InsuranceOptionSpecified = True

        item.ShippingDetails.InternationalInsuranceDetails = New InsuranceDetailsType
        item.ShippingDetails.InternationalInsuranceDetails.InsuranceOption = InsuranceOptionCodeType.IncludedInShippingHandling
        item.ShippingDetails.InternationalInsuranceDetails.InsuranceOptionSpecified = True

        item.ShippingDetails.DefaultShippingCost = New AmountType
        item.ShippingDetails.DefaultShippingCost.Value = 5.5
        item.ShippingDetails.DefaultShippingCost.currencyID = Me.ReturnCurrencyType


        item.ShippingDetails.InsuranceDetails = New InsuranceDetailsType
        item.ShippingDetails.InsuranceDetails.InsuranceOption = InsuranceOptionCodeType.NotOffered
        item.ShippingDetails.InsuranceDetails.InsuranceOptionSpecified = True


        item.ShippingDetails.ShippingType = ShippingTypeCodeType.Flat
        item.ShippingDetails.ShippingTypeSpecified = True

        item.ShippingDetails.ShippingServiceOptions = New ShippingServiceOptionsTypeCollection
        Dim oshipping As New ShippingServiceOptionsType

        oshipping.ShippingServiceCost = New AmountType
        ''
        ''   Select Case Me.e_shipping.SelectedValue
        ''   Case 0
        oshipping.ShippingServiceCost.Value = Me.GetShippingBySiteId(0, Convert.ToInt32(Me.e_site.SelectedValue))
        ''  Case Else
        ''   oshipping.ShippingServiceCost.Value = Me.GetShippingBySiteId(9.9, Convert.ToInt32(Me.e_site.SelectedValue))
        'Case 2
        '    oshipping.ShippingServiceCost.Value = Me.GetShippingBySiteId(14.5, Convert.ToInt32(Me.e_site.SelectedValue))
        'Case 3
        '    oshipping.ShippingServiceCost.Value = Me.GetShippingBySiteId(39, Convert.ToInt32(Me.e_site.SelectedValue))
        'Case 4
        '    oshipping.ShippingServiceCost.Value = Me.GetShippingBySiteId(39, Convert.ToInt32(Me.e_site.SelectedValue))
        ''  End Select



        oshipping.ShippingServiceCost.currencyID = Me.ReturnCurrencyType
        Select Case Me.e_site.SelectedValue
            Case 1
                oshipping.ShippingService = "ShippingMethodStandard"
            Case 2
                oshipping.ShippingService = "UK_SellersStandardRate"
            Case 3
                oshipping.ShippingService = "AU_Registered"
            Case 6
                oshipping.ShippingService = "FR_PostOfficeLetterRecommended"
        End Select


        oshipping.ShippingServiceAdditionalCost = New AmountType
        oshipping.ShippingServiceAdditionalCost.Value = 0
        oshipping.ShippingServiceAdditionalCost.currencyID = Me.ReturnCurrencyType
        oshipping.ShippingServicePriority = 1
        oshipping.ShippingServicePrioritySpecified = True


        oshipping.ShippingInsuranceCost = New AmountType
        oshipping.ShippingInsuranceCost.Value = 0

        'Dim oshipping2 As New ShippingServiceOptionsType

        'oshipping2.ShippingServiceCost = New AmountType

        'Select Case Me.e_shipping.SelectedValue
        '    Case 0
        '        oshipping2.ShippingServiceCost.Value = Me.GetShippingBySiteId(0, Convert.ToInt32(Me.e_site.SelectedValue))
        '    Case Else
        '        oshipping2.ShippingServiceCost.Value = Me.GetShippingBySiteId(14.5, Convert.ToInt32(Me.e_site.SelectedValue))
        '        'Case 2
        '        '    oshipping2.ShippingServiceCost.Value = Me.GetShippingBySiteId(14.5, Convert.ToInt32(Me.e_site.SelectedValue))
        '        'Case 3
        '        '    oshipping2.ShippingServiceCost.Value = Me.GetShippingBySiteId(39, Convert.ToInt32(Me.e_site.SelectedValue))
        '        'Case 4
        '        '    oshipping2.ShippingServiceCost.Value = Me.GetShippingBySiteId(39, Convert.ToInt32(Me.e_site.SelectedValue))
        'End Select



        'oshipping2.ShippingServiceCost.currencyID = Me.ReturnCurrencyType
        'Select Case Me.e_site.SelectedValue
        '    Case 1
        '        oshipping2.ShippingService = "ShippingMethodExpress"
        '    Case 2
        '        oshipping2.ShippingService = "UK_OtherCourier48"
        '    Case 3
        '        oshipping2.ShippingService = "AU_Express"
        '    Case 6
        '        oshipping2.ShippingService = "FR_PostOfficeLetterRecommended"
        'End Select


        'oshipping2.ShippingServiceAdditionalCost = New AmountType
        'oshipping2.ShippingServiceAdditionalCost.Value = 0
        'oshipping2.ShippingServiceAdditionalCost.currencyID = Me.ReturnCurrencyType
        'oshipping2.ShippingServicePriority = 2
        'oshipping2.ShippingServicePrioritySpecified = True


        'oshipping2.ShippingInsuranceCost = New AmountType
        'oshipping2.ShippingInsuranceCost.Value = 0

        item.ShippingDetails.ShippingServiceOptions.Add(oshipping)
        'item.ShippingDetails.ShippingServiceOptions.Add(oshipping2)

        item.ShippingDetails.InternationalShippingServiceOption = New InternationalShippingServiceOptionsTypeCollection

        Dim ointshipping As New InternationalShippingServiceOptionsType

        ointshipping.ShipToLocation = New StringCollection

        ointshipping.ShipToLocation.Add("Worldwide")

        ointshipping.ShippingServicePriority = 1

        Select Case Me.e_site.SelectedValue
            Case 1
                ointshipping.ShippingService = "StandardInternational"
            Case 2
                ointshipping.ShippingService = "UK_SellersStandardInternationalRate"
            Case 3
                ointshipping.ShippingService = "AU_StandardInternational"
            Case 6
                ointshipping.ShippingService = "FR_StandardInternational"
        End Select

        '' Me.e_shipping_services.SelectedItem.Text

        ointshipping.ShippingServiceCost = New AmountType
        ''
        ''Select Case Me.e_shipping.SelectedValue
        ''  Case 0
        ointshipping.ShippingServiceCost.Value = Me.GetShippingBySiteId(0, Convert.ToInt32(Me.e_site.SelectedValue))
        '' Case Else
        ''    ointshipping.ShippingServiceCost.Value = Me.GetShippingBySiteId(9.9, Convert.ToInt32(Me.e_site.SelectedValue))
        'Case 2
        '    ointshipping.ShippingServiceCost.Value = Me.GetShippingBySiteId(14.5, Convert.ToInt32(Me.e_site.SelectedValue))
        'Case 3
        '    ointshipping.ShippingServiceCost.Value = Me.GetShippingBySiteId(39, Convert.ToInt32(Me.e_site.SelectedValue))
        'Case 4
        '    ointshipping.ShippingServiceCost.Value = Me.GetShippingBySiteId(39, Convert.ToInt32(Me.e_site.SelectedValue))
        ''  End Select


        ointshipping.ShippingServiceCost.currencyID = Me.ReturnCurrencyType

        ''shipping options 2
        'Dim ointshipping2 As New InternationalShippingServiceOptionsType

        'ointshipping2.ShipToLocation = New StringCollection
        'ointshipping2.ShippingServicePriority = 2
        'ointshipping2.ShipToLocation.Add("Worldwide")

        'Select Case Me.e_site.SelectedValue
        '    Case 1
        '        ointshipping2.ShippingService = "ExpeditedInternational"
        '    Case 2
        '        ointshipping2.ShippingService = "UK_OtherCourierOrDeliveryInternational"
        '    Case 3
        '        ointshipping2.ShippingService = "AU_ExpeditedInternational"
        '    Case 6
        '        ointshipping2.ShippingService = "FR_ExpeditedInternational"
        'End Select

        ''' Me.e_shipping_services.SelectedItem.Text

        'ointshipping2.ShippingServiceCost = New AmountType

        'Select Case Me.e_shipping.SelectedValue
        '    Case 0
        '        ointshipping2.ShippingServiceCost.Value = Me.GetShippingBySiteId(0, Convert.ToInt32(Me.e_site.SelectedValue))
        '    Case Else
        '        ointshipping2.ShippingServiceCost.Value = Me.GetShippingBySiteId(14.5, Convert.ToInt32(Me.e_site.SelectedValue))
        '        'Case 2
        '        '    ointshipping2.ShippingServiceCost.Value = Me.GetShippingBySiteId(14.5, Convert.ToInt32(Me.e_site.SelectedValue))
        '        'Case 3
        '        '    ointshipping2.ShippingServiceCost.Value = Me.GetShippingBySiteId(39, Convert.ToInt32(Me.e_site.SelectedValue))
        '        'Case 4
        '        '    ointshipping2.ShippingServiceCost.Value = Me.GetShippingBySiteId(39, Convert.ToInt32(Me.e_site.SelectedValue))
        'End Select


        'ointshipping2.ShippingServiceCost.currencyID = Me.ReturnCurrencyType


        item.ShippingDetails.InternationalShippingServiceOption.Add(ointshipping)
        '' item.ShippingDetails.InternationalShippingServiceOption.Add(ointshipping2)


        'If Me.e_site.SelectedValue = 1 Then

        '    Dim ointshipping3 As New InternationalShippingServiceOptionsType
        '    ointshipping3.ShippingServicePriority = 3
        '    ointshipping3.ShipToLocation = New StringCollection

        '    ointshipping3.ShipToLocation.Add("Worldwide")

        '    Select Case Me.e_site.SelectedValue
        '        Case 1
        '            ointshipping3.ShippingService = "OtherInternational"
        '        Case 2
        '            ointshipping3.ShippingService = "UK_ExpeditedInternationalFlatRatePostage"
        '        Case 3
        '            ointshipping3.ShippingService = "AU_ExpeditedInternational"
        '        Case 6
        '            ointshipping3.ShippingService = "FR_ExpeditedInternational"
        '    End Select

        '    '' Me.e_shipping_services.SelectedItem.Text

        '    ointshipping3.ShippingServiceCost = New AmountType

        '    Select Case Me.e_shipping.SelectedValue
        '        Case 0
        '            ointshipping3.ShippingServiceCost.Value = Me.GetShippingBySiteId(0, Convert.ToInt32(Me.e_site.SelectedValue))
        '        Case Else
        '            ointshipping3.ShippingServiceCost.Value = Me.GetShippingBySiteId(39, Convert.ToInt32(Me.e_site.SelectedValue))
        '            'Case 2
        '            '    ointshipping3.ShippingServiceCost.Value = Me.GetShippingBySiteId(14.5, Convert.ToInt32(Me.e_site.SelectedValue))
        '            'Case 3
        '            '    ointshipping3.ShippingServiceCost.Value = Me.GetShippingBySiteId(39, Convert.ToInt32(Me.e_site.SelectedValue))
        '            'Case 4
        '            '    ointshipping3.ShippingServiceCost.Value = Me.GetShippingBySiteId(39, Convert.ToInt32(Me.e_site.SelectedValue))
        '    End Select


        '    ointshipping3.ShippingServiceCost.currencyID = Me.ReturnCurrencyType
        '    item.ShippingDetails.InternationalShippingServiceOption.Add(ointshipping3)
        'End If

        item.ListingEnhancement = New ListingEnhancementsCodeTypeCollection

        If Me.e_u_highlight.Checked Then
            item.ListingEnhancement.Add(ListingEnhancementsCodeType.Highlight)
        End If

        If Me.e_u_bold.Checked Then
            item.ListingEnhancement.Add(ListingEnhancementsCodeType.BoldTitle)
        End If

        If Me.e_u_border.Checked Then
            item.ListingEnhancement.Add(ListingEnhancementsCodeType.Border)
        End If

        If Me.e_u_featured_plus.Checked Then
            item.ListingEnhancement.Add(ListingEnhancementsCodeType.Featured)
        End If
        item.AttributeSetArray = New AttributeSetTypeCollection

        Dim rp As New AttributeSetType
        rp.attributeSetID = 2135
        rp.Attribute = New AttributeTypeCollection

        Dim attr As New AttributeType  '' retuirn accpeted
        attr.attributeID = 3803
        attr.Value = New ValTypeCollection

        Dim val As New ValType
        val.ValueID = 32040

        attr.Value.Add(val)
        'attr.Value.Clear()

        rp.Attribute.Add(attr)

        Dim attr2 As New AttributeType  '' retuirn accpeted
        attr2.attributeID = 3804
        attr2.Value = New ValTypeCollection

        Dim val2 As New ValType
        val2.ValueID = 32035

        attr2.Value.Add(val2)
        'attr.Value.Clear()

        rp.Attribute.Add(attr2)



        'item specifics
        'Dim ocatmapping As New GetCategory2CSCall(Me.oapicontext)
        'ocatmapping.Site = SiteCodeType.UK
        'ocatmapping.CategoryID = item.PrimaryCategory.CategoryID
        'ocatmapping.DetailLevelList.Add(DetailLevelCodeType.ReturnAll)
        '''ocatmapping.MappedCategoryList(0).CharacteristicsSets(0)
        'Dim itemspeclist As CategoryTypeCollection = ocatmapping.GetCategory2CS()


        'Dim oitemspec As New GetAttributesCSCall(Me.oapicontext)
        'oitemspec.DetailLevelList.Add(DetailLevelCodeType.ReturnAll)
        'oitemspec.AttributeSetIDList = New Int32Collection
        'oitemspec.AttributeSetIDList.Add(itemspeclist(0).CharacteristicsSets(0).AttributeSetID)
        '''oitemspec.AttributeSetIDList.Add(2210)
        'oitemspec.GetAttributesCS()
        'Dim a As String = oitemspec.AttributeData
        '' Me.e_specs.Text = oitemspec.AttributeData
        ''itemspeclist(0).CharacteristicsSets
        'Dim orec As New GetItemRecommendationsCall(Me.oapicontext)
        'orec.DetailLevelList.Add(DetailLevelCodeType.ReturnAll)
        'orec.GetRecommendationsRequestContainerList = New GetRecommendationsRequestContainerTypeCollection
        'Dim orectype As New GetRecommendationsRequestContainerType
        'orectype.Item = item
        'orec.GetRecommendationsRequestContainerList.Add(orectype)
        '''orec.GetItemRecommendations
        'Dim orecget As GetRecommendationsResponseContainerTypeCollection = orec.GetItemRecommendations(orec.GetRecommendationsRequestContainerList)

        'Dim olist As NameValueListTypeCollection = orec.GetRecommendationsResponseContainerList(0).ItemSpecificsRecommendations.ItemSpecifics

        'For Each item2 As NameValueListType In olist
        '    Me.e_shipping_services.Items.Add(item2.Name)
        'Next
        'Dim ocatspecs As New GetCategorySpecificsCall(Me.oapicontext)
        'ocatspecs.DetailLevelList.Add(DetailLevelCodeType.ReturnAll)
        'ocatspecs.CategoryIDList = New StringCollection
        'ocatspecs.CategoryIDList.Add(item.PrimaryCategory.CategoryID)

        'Dim ocatspecsitems As CategoryItemSpecificsTypeCollection = ocatspecs.GetCategorySpecifics(ocatspecs.CategoryIDList)
        'Dim item1 As New NameValueListType

        'item1.Name = "test"
        'item1.Value = New StringCollection
        'item1.Value.Add("dgfdasgf")
        Dim oTmpInventory As New ion_two.cls_inventory_lgc
        oTmpInventory._connection_string = Application("config").connection_string
        oTmpInventory._dbtype = Application("config").connection_string_type

        Dim oPlate As New ion_two.skl_lst_inventory
        Dim opicture As New ion_two.cls_pictures
        opicture.load("http://www.twin-diamonds.com", "https://www.twin-diamonds.com")



        Dim id As Int32 = Request.QueryString("id")

        oTmpInventory.load(id, oPlate, opicture)

        Dim oxml As New ion_two.cls_nd_xmlread
        oxml.xml_file = Server.MapPath("itemspecifics.xml")
        oxml.Load()

        item.ItemSpecifics = New NameValueListTypeCollection

        Dim ospeclist As XmlNodeList = oxml.GetNodes_ByPath("rule[@plate='" + oPlate._platetype.ToString + "']/itemspecifics")
        Dim odesc As New ion_two.cls_modular_description

        For Each spec As XmlNode In ospeclist
            Dim specitem As New NameValueListType
            specitem.Name = spec.Attributes("name").InnerText
            specitem.Value = New StringCollection
            Dim desc As String
            odesc.CreateDescription(oPlate, spec.InnerText, desc)
            specitem.Value.Add(desc)
            item.ItemSpecifics.Add(specitem)
        Next







        ''orec.GetRecommendationsRequestContainerList.Add(

        item.AttributeSetArray.Add(rp)




        item.HitCounter = HitCounterCodeType.GreenLED











        Return item
    End Function

    'Public Function SaveRecentCategories()
    '    Dim oxml As New ion_two.cls_nd_xmlread
    '    oxml.xml_file = Server.MapPath("lastcat.xml")
    '    oxml.Load()
    '    Dim item As XmlElement = oxml.xmldoc.CreateElement("cat")

    '    Me.e_itemid.Visible = True

    '    Dim ocat As New GetCategoriesCall(oapicontext)
    '    ocat.CategoryParent = New StringCollection
    '    ''  ocat.
    '    ocat.LevelLimit = 5
    '    ocat.DetailLevelList.Add(DetailLevelCodeType.ReturnAll)
    '    '' ocat.CategoryParent.Add("110742") '' gemstones
    '    ocat.get()


    '    ocat.ViewAllNodes = True
    '    Dim ocatlist As CategoryTypeCollection = ocat.GetCategories()

    '    Me.e_itemid.Text = ocatlist(0).CategoryParentID.Count().ToString
    '    '' oxml.WriteToXpath("/categories/cat[last()]", item)
    'End Function

    Private Sub Upload_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Upload.Click
        Dim item As ItemType = Me.SetItem


        ''ospecific.Source =

        If Me.e_secondsite.Checked Then
            Dim ApiCall As AddItemCall = New AddItemCall(oapicontext)

            ''ospecific.Source =




            Select Case Me.e_site.SelectedValue
                Case 1
                    ApiCall.Site = SiteCodeType.US
                Case 2
                    ApiCall.Site = SiteCodeType.UK
                Case 3
                    ApiCall.Site = SiteCodeType.Australia
                Case 6
                    ApiCall.Site = SiteCodeType.France
            End Select


            If Me.e_picture.Visible = True Then
                ApiCall.PictureFileList = New StringCollection
                item.PictureDetails = New PictureDetailsType

                If Me.e_u_gallery_pic.Checked Then
                    item.PictureDetails.GalleryType = GalleryTypeCodeType.Gallery
                End If
                If Me.e_u_gallery_plus.Checked Then
                    item.PictureDetails.GalleryType = GalleryTypeCodeType.Plus
                End If

                item.PictureDetails.PhotoDisplay = [Enum].Parse(GetType(PhotoDisplayCodeType), "None")
                item.PictureDetails.PictureURL = New StringCollection
                item.PictureDetails.PictureURL.Add(Me.e_picture.ImageUrl)
            End If


            '' ApiCall.PictureFilList.Add(Me.e_picture.ImageUrl)





            Dim fees As FeeTypeCollection = ApiCall.AddItem(item)
            Dim fee As FeeType

            Me.e_itemid.Text = ApiCall.ItemID
            Me.e_itemid.Visible = True
            Me.e_itemid.NavigateUrl = "http://cgi.ebay.com/ws/eBayISAPI.dll?ViewItem&item=" + ApiCall.ItemID.ToString

            For Each fee In fees
                If fee.Name = "ListingFee" Then
                    Me.e_fees.Text = fee.Fee.Value.ToString + " us $"
                End If
            Next
        Else

            Dim ApiCall As AddItemCall = New AddItemCall(oapicontext)



            Select Case Me.e_site.SelectedValue
                Case 1
                    ApiCall.Site = SiteCodeType.US
                Case 2
                    ApiCall.Site = SiteCodeType.UK
                Case 3
                    ApiCall.Site = SiteCodeType.Australia
                Case 6
                    ApiCall.Site = SiteCodeType.France
            End Select


            If Me.e_picture.Visible = True Then
                ApiCall.PictureFileList = New StringCollection
                item.PictureDetails = New PictureDetailsType

                If Me.e_u_gallery_pic.Checked Then
                    item.PictureDetails.GalleryType = GalleryTypeCodeType.Gallery
                End If
                If Me.e_u_gallery_plus.Checked Then
                    item.PictureDetails.GalleryType = GalleryTypeCodeType.Plus
                End If

                item.PictureDetails.PhotoDisplay = [Enum].Parse(GetType(PhotoDisplayCodeType), "None")
                item.PictureDetails.PictureURL = New StringCollection
                item.PictureDetails.PictureURL.Add(Me.e_picture.ImageUrl)
            End If


            '' ApiCall.PictureFilList.Add(Me.e_picture.ImageUrl)





            Dim fees As FeeTypeCollection = ApiCall.AddItem(item)
            Dim fee As FeeType

            Me.e_itemid.Text = ApiCall.ItemID
            Me.e_itemid.Visible = True
            Me.e_itemid.NavigateUrl = "http://cgi.ebay.com/ws/eBayISAPI.dll?ViewItem&item=" + ApiCall.ItemID.ToString

            For Each fee In fees
                If fee.Name = "ListingFee" Then
                    Me.e_fees.Text = fee.Fee.Value.ToString + " us $"
                End If
            Next
        End If

    End Sub

    Private Sub e_alt_title_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles e_alt_title.TextChanged
        Me.LoadPlate(4646)
    End Sub

    Private Sub e_update_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles e_update.Click
        Me.LoadPlate(4646)
    End Sub

    Private Sub btn_save_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub e_site_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles e_site.SelectedIndexChanged
        'Dim ocat As New GetCategoriesCall(oapicontext)
        'ocat.CategoryParent = New StringCollection
        '''  ocat.
        'Select Case Me.e_site.SelectedValue
        '    Case 1
        '        ocat.Site = SiteCodeType.US
        '    Case 2
        '        ocat.Site = SiteCodeType.UK
        '    Case 3
        '        ocat.Site = SiteCodeType.Australia
        '    Case 6
        '        ocat.Site = SiteCodeType.France
        'End Select

        'Me.e_primery_cat.Items.Clear()
        'Me.e_primery_cat_2.Items.Clear()
        'Me.e_primery_cat_3.Items.Clear()
        'Me.e_primery_cat_4.Items.Clear()

        'Me.e_second_cat.Items.Clear()
        'Me.e_second_cat_2.Items.Clear()
        'Me.e_second_cat_3.Items.Clear()
        'Me.e_second_cat_4.Items.Clear()
        'Me.DropDownList1.Items.Clear()

        ''' ocat.LevelLimit = 20
        'ocat.DetailLevelList.Add(DetailLevelCodeType.ReturnAll)
        'Select Case Me.e_site.SelectedValue
        '    Case 1
        '        ocat.CategoryParent.Add("491")
        '        ocat.CategoryParent.Add("67725") '' jewelry

        '        ocat.CategoryParent.Add("10985")

        '        ocat.CategoryParent.Add("10994")
        '    Case 2
        '        ocat.CategoryParent.Add("491")
        '        ocat.CategoryParent.Add("67725") '' jewelry

        '        ocat.CategoryParent.Add("10985")

        '        ocat.CategoryParent.Add("10994")
        '        'ocat.CategoryParent.Add("110742")
        '        'ocat.CategoryParent.Add("10210")
        '        'ocat.CategoryParent.Add("152810")
        '        'ocat.CategoryParent.Add("67725")
        '        'ocat.CategoryParent.Add("10975")
        '        'ocat.CategoryParent.Add("11317")
        '        'ocat.CategoryParent.Add("10985")


        '    Case 3
        '        ocat.CategoryParent.Add("491")
        '        ocat.CategoryParent.Add("155096")
        '        ocat.CategoryParent.Add("155115")
        '        ocat.CategoryParent.Add("67725")
        '    Case 6


        'End Select
        ''' ocat.CategoryParent.Add("110742") '' gemstones


        'ocat.ViewAllNodes = True
        'Dim ocatlist As CategoryTypeCollection = ocat.GetCategories()

        'Dim typeselector As Int32 = 1
        'Dim cat_zero = ocatlist(0).CategoryLevel
        'For Each cat As CategoryType In ocatlist
        '    Select Case Me.e_site.SelectedValue
        '        Case 1, 2
        '            Select Case cat.CategoryID
        '                Case 491
        '                    typeselector = 1
        '                Case 67725
        '                    typeselector = 2
        '                Case 10985
        '                    typeselector = 3
        '                Case 10994
        '                    typeselector = 4
        '                Case Else
        '                    typeselector = typeselector
        '            End Select
        '        Case 2
        '            Select Case cat.CategoryID
        '                Case 110742
        '                    typeselector = 1
        '                Case 10210, 152810
        '                    typeselector = 2
        '                Case 10975, 11317, 10985
        '                    typeselector = 3
        '                Case 67725
        '                    typeselector = 4
        '                Case Else
        '                    typeselector = typeselector
        '            End Select
        '        Case 3
        '            Select Case cat.CategoryID
        '                Case 491
        '                    typeselector = 1
        '                Case 155096
        '                    typeselector = 2
        '                Case 155115
        '                    typeselector = 3
        '                Case 67725
        '                    typeselector = 4
        '                Case Else
        '                    typeselector = typeselector
        '            End Select
        '        Case 6
        '    End Select

        '    Dim space As String
        '    Dim j As Int32 = 0
        '    space = ""
        '    For j = cat_zero + 2 To cat.CategoryLevel
        '        space += "----"
        '    Next
        '    '' Me.DropDownList1.Items.Add(New WebControls.ListItem(cat.CategoryLevel.ToString + "--" + cat.CategoryID.ToString + "-- " + cat.CategoryName, cat.CategoryID.ToString))
        '    If cat.LeafCategory Then

        '        Select Case typeselector
        '            Case 1
        '                Me.e_primery_cat.Items.Add(New WebControls.ListItem(space + cat.CategoryName, cat.CategoryID.ToString))
        '                Me.e_second_cat.Items.Add(New WebControls.ListItem(space + cat.CategoryName, cat.CategoryID.ToString))
        '            Case 2
        '                Me.e_primery_cat_2.Items.Add(New WebControls.ListItem(space + cat.CategoryName, cat.CategoryID.ToString))
        '                Me.e_second_cat_2.Items.Add(New WebControls.ListItem(space + cat.CategoryName, cat.CategoryID.ToString))
        '            Case 3
        '                Me.e_primery_cat_3.Items.Add(New WebControls.ListItem(space + cat.CategoryName, cat.CategoryID.ToString))
        '                Me.e_second_cat_3.Items.Add(New WebControls.ListItem(space + cat.CategoryName, cat.CategoryID.ToString))
        '            Case 4
        '                Me.e_primery_cat_4.Items.Add(New WebControls.ListItem(space + cat.CategoryName, cat.CategoryID.ToString))
        '                Me.e_second_cat_4.Items.Add(New WebControls.ListItem(space + cat.CategoryName, cat.CategoryID.ToString))
        '        End Select


        '    Else
        '        Select Case typeselector
        '            Case 1
        '                Me.e_primery_cat.Items.Add(New WebControls.ListItem(space + cat.CategoryName, "0"))
        '                Me.e_second_cat.Items.Add(New WebControls.ListItem(space + cat.CategoryName, "0"))
        '            Case 2
        '                Me.e_primery_cat_2.Items.Add(New WebControls.ListItem(space + cat.CategoryName, "0"))
        '                Me.e_second_cat_2.Items.Add(New WebControls.ListItem(space + cat.CategoryName, "0"))
        '            Case 3
        '                Me.e_primery_cat_3.Items.Add(New WebControls.ListItem(space + cat.CategoryName, "0"))
        '                Me.e_second_cat_3.Items.Add(New WebControls.ListItem(space + cat.CategoryName, "0"))
        '            Case 4
        '                Me.e_primery_cat_4.Items.Add(New WebControls.ListItem(space + cat.CategoryName, "0"))
        '                Me.e_second_cat_4.Items.Add(New WebControls.ListItem(space + cat.CategoryName, "0"))
        '        End Select
        '    End If
        'Next

        Me.e_selling_format.SelectedIndex = 0

        'Me.e_shipping_services.Items.Clear()
        'Dim oebaydetails As New GeteBayDetailsCall(oapicontext)
        'oebaydetails.Site = SiteCodeType.US
        'Dim oebaydetailslist As New DetailNameCodeTypeCollection
        'Dim oebaydetailsitem As New DetailNameCodeType
        'oebaydetailslist.Add(DetailNameCodeType.ShippingServiceDetails)
        '''oebaydetailsitem.ShippingServiceDetails()
        'oebaydetails.GeteBayDetails(oebaydetailslist)
        'Me.e_itemid.Text = oebaydetails.ShippingServiceDetailList.Count.ToString
        ''oebaydetails.TimeZoneDetailList(0).

        ''   Me.e_second_cat.Items.Clear()
        'For Each detail As ShippingServiceDetailsType In oebaydetails.ShippingServiceDetailList
        '    Me.e_shipping_services.Items.Add(detail.ShippingService)
        'Next
        Dim oplate As ion_two.skl_lst_inventory = Me.GetPlate

        Dim oconv As New net.webservicex.www.CurrencyConvertor
        Dim conv_rate As Double = 1
        Select Case Me.e_site.SelectedValue
            Case 1
                conv_rate = 1
                Me.e_cur_apr.Text = "us$"
                Me.e_cur_price.Text = "us$"
            Case 2
                conv_rate = oconv.ConversionRate(net.webservicex.www.Currency.USD, net.webservicex.www.Currency.GBP)
                Me.e_cur_apr.Text = "GBP"
                Me.e_cur_price.Text = "GBP"

            Case 3
                conv_rate = oconv.ConversionRate(net.webservicex.www.Currency.USD, net.webservicex.www.Currency.AUD)
                Me.e_cur_apr.Text = "au$"
                Me.e_cur_price.Text = "au$"
            Case 6
                conv_rate = oconv.ConversionRate(net.webservicex.www.Currency.USD, net.webservicex.www.Currency.EUR)
                Me.e_cur_apr.Text = "EUR"
                Me.e_cur_price.Text = "EUR"
        End Select

        Me.e_price.Text = Math.Round((oplate._sell_price * conv_rate)).ToString

        If Me.e_apramount.Text <> "" Then
            Me.e_apramount.Text = Math.Round((oplate._appraisal_price * conv_rate)).ToString
        End If

        Me.LoadPlate(4646)



    End Sub
    Function ReturnCurrencyType() As CurrencyCodeType
        Select Case Me.e_site.SelectedValue
            Case 1
                Return CurrencyCodeType.USD
            Case 2
                Return CurrencyCodeType.GBP
            Case 3
                Return CurrencyCodeType.AUD
            Case 6
                Return CurrencyCodeType.EUR
        End Select
    End Function

    Private Sub e_apramount_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles e_apramount.TextChanged
        Me.LoadPlate(4646)
    End Sub

    Function GetShippingBySiteId(ByVal amount As Int32, ByVal id As Int32) As String
        Select Case amount
            Case 9.9
                Select Case id
                    Case 1
                        Return "9.90"
                    Case 2
                        Return "6.90"
                    Case 3
                        Return "11.90"
                    Case 6
                        Return "5.90"
                End Select
            Case 14.5
                Select Case id
                    Case 1
                        Return "14.5"
                    Case 2
                        Return "9.90"
                    Case 3
                        Return "15.00"
                    Case 6
                        Return "9.90"
                End Select
            Case 39
                Select Case id
                    Case 1
                        Return "39.00"
                    Case 2
                        Return "19.00"
                    Case 3
                        Return "41.00"
                    Case 6
                        Return "24.00"
                End Select
        End Select
    End Function

    Private Sub e_secondary_id_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles e_secondary_id.TextChanged

    End Sub

    Private Sub e_updatecat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles e_updatecat.Click
        Dim ocat As New GetCategoriesCall(oapicontext)
        ocat.CategoryParent = New StringCollection
        ''  ocat.
        Dim i As Int16 = 0
        For i = 0 To 3
            Select Case Me.e_site.Items(i).Value
                Case 1
                    ocat.Site = SiteCodeType.US
                Case 2
                    ocat.Site = SiteCodeType.UK
                Case 3
                    ocat.Site = SiteCodeType.Australia
                Case 6
                    ocat.Site = SiteCodeType.France
            End Select


            '' ocat.LevelLimit = 20
            ocat.DetailLevelList.Add(DetailLevelCodeType.ReturnAll)

            'Select Case Me.e_site.SelectedValue
            '    Case 1
            ocat.CategoryParent.Add("281")
            '        'ocat.CategoryParent.Add("491")
            '        'ocat.CategoryParent.Add("67725") '' jewelry

            '        'ocat.CategoryParent.Add("10985")

            '        'ocat.CategoryParent.Add("10994")
            '    Case 2
            '        ocat.CategoryParent.Add("281")
            '        'ocat.CategoryParent.Add("67725") '' jewelry

            '        'ocat.CategoryParent.Add("10985")

            '        'ocat.CategoryParent.Add("10994")
            '        'ocat.CategoryParent.Add("110742")
            '        'ocat.CategoryParent.Add("10210")
            '        'ocat.CategoryParent.Add("152810")
            '        'ocat.CategoryParent.Add("67725")
            '        'ocat.CategoryParent.Add("10975")
            '        'ocat.CategoryParent.Add("11317")
            '        'ocat.CategoryParent.Add("10985")


            '    Case 3
            '        ocat.CategoryParent.Add("281")
            '        'ocat.CategoryParent.Add("491")
            '        'ocat.CategoryParent.Add("155096")
            '        'ocat.CategoryParent.Add("155115")
            '        'ocat.CategoryParent.Add("67725")
            '    Case 6


            'End Select
            '' ocat.CategoryParent.Add("110742") '' gemstones


            ocat.ViewAllNodes = True
            ''ocat.DetailLev
            Dim ocatlist As CategoryTypeCollection = ocat.GetCategories()
            Dim oxml As New ion_two.cls_nd_xmlwrite
            oxml.xml_file = Server.MapPath("/ebaycat" + Me.e_site.Items(i).Value + ".xml")
            ''write root element
            Dim rootxml As XmlNode = oxml.CreateXMLNode("tree")
            Dim idattr As XmlAttribute = oxml.CreateXmlAttribute("id", "0")
            rootxml.Attributes.Append(idattr)

            Dim prevcat_level As Int32 = 2
            ocatlist.RemoveAt(0)

            For Each cat As CategoryType In ocatlist

                Dim catxml As XmlNode = oxml.CreateXMLNode("item")
                Dim attrtext As XmlAttribute = oxml.CreateXmlAttribute("text", cat.CategoryName)
                ' Dim attrselect As XmlAttribute = oxml.CreateXmlAttribute("call", "ClickCategory")
                Dim attrid As XmlAttribute = oxml.CreateXmlAttribute("id", cat.CategoryID.ToString)

                If cat.LeafCategory Then

                    Dim attrchild As XmlAttribute = oxml.CreateXmlAttribute("child", "0")
                    ' catxml.Attributes.Append(attrselect)
                    catxml.Attributes.Append(attrchild)

                    Dim parent_array As New ArrayList
                    Dim i2 As Int32

                    'For i2 = 0 To cat.CategoryParentID.Count - 1
                    '    parent_array.Add(cat.CategoryParentID(i2).ToString)
                    'Next
                    'Dim attrparent As XmlAttribute = oxml.CreateXmlAttribute("parent", Join(parent_array.ToArray, " -> "))
                    'catxml.Attributes.Append(attrparent)
                Else
                    Dim attrchild As XmlAttribute = oxml.CreateXmlAttribute("child", "1")
                    catxml.Attributes.Append(attrchild)
                End If
                catxml.Attributes.Append(attrtext)

                catxml.Attributes.Append(attrid)

                If cat.CategoryLevel = prevcat_level Then
                    If cat.LeafCategory Then
                        Dim str As String = cat.CategoryName
                        Dim userdata As XmlNode = oxml.CreateXMLNode("userdata")
                        userdata.Attributes.Append(oxml.CreateXmlAttribute("name", "parent"))
                        userdata.InnerText = str
                        catxml.AppendChild(userdata)
                    End If
                    rootxml.AppendChild(catxml)
                ElseIf cat.CategoryLevel = prevcat_level + 1 Then
                    If cat.LeafCategory Then
                        Dim str As String = rootxml.LastChild.Attributes("text").InnerText + " -> " + cat.CategoryName
                        Dim userdata As XmlNode = oxml.CreateXMLNode("userdata")
                        userdata.Attributes.Append(oxml.CreateXmlAttribute("name", "parent"))
                        userdata.InnerText = str
                        catxml.AppendChild(userdata)
                    End If
                    rootxml.LastChild.AppendChild(catxml)
                ElseIf cat.CategoryLevel = prevcat_level + 2 Then
                    If cat.LeafCategory Then
                        Dim str As String = rootxml.LastChild.Attributes("text").InnerText + " -> " + rootxml.LastChild.LastChild.Attributes("text").InnerText + " -> " + cat.CategoryName
                        Dim userdata As XmlNode = oxml.CreateXMLNode("userdata")
                        userdata.InnerText = str
                        userdata.Attributes.Append(oxml.CreateXmlAttribute("name", "parent"))
                        catxml.AppendChild(userdata)
                    End If
                    rootxml.LastChild.LastChild.AppendChild(catxml)

                ElseIf cat.CategoryLevel = prevcat_level + 3 Then
                    If cat.LeafCategory Then
                        Dim str As String = rootxml.LastChild.Attributes("text").InnerText + " -> " + rootxml.LastChild.LastChild.Attributes("text").InnerText + " -> " + rootxml.LastChild.LastChild.LastChild.Attributes("text").InnerText + " -> " + cat.CategoryName
                        Dim userdata As XmlNode = oxml.CreateXMLNode("userdata")
                        userdata.Attributes.Append(oxml.CreateXmlAttribute("name", "parent"))
                        userdata.InnerText = str
                        catxml.AppendChild(userdata)
                    End If
                    rootxml.LastChild.LastChild.LastChild.AppendChild(catxml)
                ElseIf cat.CategoryLevel = prevcat_level + 4 Then
                    If cat.LeafCategory Then
                        Dim str As String = rootxml.LastChild.Attributes("text").InnerText + " -> " + rootxml.LastChild.LastChild.Attributes("text").InnerText + " -> " + rootxml.LastChild.LastChild.LastChild.Attributes("text").InnerText + " -> " + rootxml.LastChild.LastChild.LastChild.LastChild.Attributes("text").InnerText + " -> " + cat.CategoryName
                        Dim userdata As XmlNode = oxml.CreateXMLNode("userdata")
                        userdata.Attributes.Append(oxml.CreateXmlAttribute("name", "parent"))
                        userdata.InnerText = str
                        catxml.AppendChild(userdata)
                    End If
                    rootxml.LastChild.LastChild.LastChild.LastChild.AppendChild(catxml)
                End If




                '' prevcat_level = cat.CategoryLevel
            Next


            rootxml.AppendChild(oxml.CreateXMLNode("var", ocat.CategoryVersionResponse.ToString))
            oxml.WriteRootElement(rootxml)
            oxml.SaveDoc()
        Next
    End Sub

    Private Sub chk_clarity_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chk_clarity.CheckedChanged
        Me.LoadPlate(4646)
    End Sub
End Class
