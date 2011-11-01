Imports eBay.Service.Core.Soap
Imports eBay.Service.Core.Sdk
Imports eBay.Service.Call
Imports eBay.Service.Util
Imports System.Xml
Imports System.Data.SqlClient
Imports System.IO
Imports System.Text.RegularExpressions

Partial Class ebaycsv_fr
    Inherits System.Web.UI.Page
    Public itemcount As Int32

    Public csvfile As String
    Protected WithEvents currancy_rate As System.Web.UI.WebControls.TextBox
    Public oapicontext As New ApiContext

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

        oapicontext.ApiCredential.ApiAccount.Application = "Twin-Dia-3f18-4f05-b81a-4ce4ba64f7a4"
        oapicontext.ApiCredential.ApiAccount.Certificate = "caad245f-7914-4ece-8ada-7a1edfb4453c"
        oapicontext.ApiCredential.ApiAccount.Developer = "57244916-441d-48cc-a2f4-7d3ea3b68472"

        oapicontext.ApiCredential.eBayAccount.Password = "lianne3773"
        oapicontext.ApiCredential.eBayAccount.UserName = "aviby"
        oapicontext.ApiCredential.eBayToken = "AgAAAA**AQAAAA**aAAAAA**b+lOSw**nY+sHZ2PrBmdj6wVnY+sEZ2PrA2dj6wJnYahDJCDogWdj6x9nY+seQ**OloAAA**AAMAAA**WmFQzdoX0A4gkFg3iYKyYjFlh3XiO1RFLT5wNqKtHdHkzWeF3pqDbCGLUdb9/FsH9yXGXCmxI5DvWYXOpKRs77KKIG3GaCOmz4Ii62XECIMJvh0aJFvg/LpKt4VFa/zfuNc3FS82SX0dlLmIw7nWyGOlvq/ZKChpPHvLVrrFZ++yfJIJVcKg6qbp08DO1bgsp8eWvsOufVTGDI+GkKy3bcQLfc/7Hm3yG+dnM4T5DRQIVZ/B498VJuVpO3xZEcNOLZVelzgtjDWUAfOxfM8qwd4d3cgVI8g3X6wHZeIDMNFMqewVN5m4hY4twTo82q3uYJmnGUXj1CkCA5mkznNRRPzz8tffVmcVwl/yUdtCCEU/KCR+bq3aK+PpBnIo5EiGIAtq606smCNve+53uDlL3WeF9AdtvETbYD+SxxBiaGRLEjnF3IwatsJ511trGQBJB2OBlDRj/2q7MnRP4x08HYYt38Z5BtrE4LpDqngITPP/+rW/2AFpuzAmQNYJ4HxK3sxl0OQ31u5gp5N9oP2bZOLJ/C9L7d0HvyLzNotp/KgDtsvy4NJDdAa7zdb9lz8dhEVoblZusx0o/aSOMGC/dngH+0rYhyPGC1w0fHUKPOsdEoB7/OGb0mM6z0PlO7v5dUE8ZIoyN/UZk5OW6nP4tX98mcCCzxwodKUW56zZ7v/5IQfvTbIIMPfDRGMtYJEmEnaoKt5Eufj+NY8RoLrWphtxoGooj81FspJmOcoMq+IdIFnN0NOM73RUtQhvHMTU"

        oapicontext.SoapApiServerUrl = "https://api.ebay.com/wsapi"
        oapicontext.EPSServerUrl = "http://msa-b1.ebay.com/ws/eBayISAPI.dll?EpsBasicApp"


        If Page.IsPostBack Then

            Me.LoadTable()
        Else
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
        End If

    End Sub

    Private Sub btn_load_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_load.Click

        ''   Me.LoadTable()

    End Sub

    Function LoadTable()
        Dim onumber As New ion_two.cls_itemnumber
        Dim berror As Boolean
        onumber._connection_string = Application("config").connection_string
        onumber._dbtype = Application("config").connection_string_type
        Dim item_from As Int32

        Dim item_to As Int32
        Dim item_count As Int32

        onumber.stripitemnumber(Me.txt_to.Text)
        item_to = onumber._item_no

        onumber.stripitemnumber(Me.txt_from.Text)
        item_from = onumber._item_no


        item_count = item_to - item_from + 1
        Me.itemcount = item_count

        Dim oconv As New net.webservicex.www.CurrencyConvertor
        Dim conv_rate As Double = 1
        'Select Case Convert.ToInt32(Me.cmb_site.SelectedValue)
        '    Case 0
        '        conv_rate = 1
        '        ' Me.e_currency.Text = "us$"

        '    Case 3
        '        conv_rate = oconv.ConversionRate(net.webservicex.www.Currency.USD, net.webservicex.www.Currency.GBP)
        '        ''    Me.e_currency.Text = "GBP"


        '    Case 15
        '        conv_rate = oconv.ConversionRate(net.webservicex.www.Currency.USD, net.webservicex.www.Currency.AUD)
        '        ''  Me.e_currency.Text = "au$"
        '        '
        '    Case 71, 101
        '        conv_rate = oconv.ConversionRate(net.webservicex.www.Currency.USD, net.webservicex.www.Currency.EUR)
        '        ''  Me.e_currency.Text = "EUR"

        'End Select

        Dim i As Int32 = 1
        For i = 1 To item_count
            Dim csv As csvstrip = Me.LoadControl("/ebay/controls/csvstrip.ascx")
            csv.ID = "csv" + i.ToString
            onumber._itemnumber_full = ""
            onumber.get_number(onumber._branch_no, onumber._supplier_no, item_from - 1 + i)
            csv.LoadItem(onumber._itemnumber_full, Convert.ToInt32(Me.cmb_site.SelectedValue), conv_rate, Me.txt_desc.Text, Me.chk_clarity.Checked, Me.e_cat.SelectedValue, Me.e_store_main_cat.SelectedValue, Me.e_store_second_cat.SelectedValue, Me.txt_desc.Text, Convert.ToDecimal(Me.e_currency.Text), Me.e_youtube.Text, 1, "")

            Me.pnl_table.Controls.Add(csv)
            Dim br As New HtmlGenericControl
            br.TagName = "br"
            Me.pnl_table.Controls.Add(br)

        Next
    End Function

    Private Sub btn_save_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_save.Click

        Me.SaveCSV()

        Dim path As String = Server.MapPath(Me.csvfile) 'get file object as FileInfo
        Dim file As System.IO.FileInfo = New System.IO.FileInfo(path) '-- if the file exists on the server
        If file.Exists Then 'set appropriate headers
            Response.Clear()
            Response.AddHeader("Content-Disposition", "attachment; filename=" & file.Name)
            ''   Response.AddHeader("Content-Length", file.Length.ToString())
            Response.ContentType = "text/plain"
            Response.WriteFile(file.FullName)
            Response.End() 'if file does not exist
        End If
    End Sub

    Function SaveCSV()
        Dim txt As TextBox = Me.pnl_table.Controls(0).FindControl("e_category")
        Me.Label1.Text = txt.Text


        Dim t_csv As New ArrayList




        Dim i As Int32


        Dim onumber As New ion_two.cls_itemnumber
        Dim berror As Boolean
        onumber._connection_string = Application("config").connection_string
        onumber._dbtype = Application("config").connection_string_type
        Dim item_from As Int32

        Dim item_to As Int32
        Dim item_count As Int32


        onumber.stripitemnumber(Me.txt_from.Text)
        item_from = onumber._item_no


        For i = 0 To Me.itemcount - 1



            onumber.get_number(onumber._branch_no, onumber._supplier_no, item_from + i)

            '' Dim onumber As New ion_two.cls_itemnumber
            onumber._connection_string = Application("config").connection_string
            onumber._dbtype = Application("config").connection_string_type
            Dim itemid As Int32
            onumber.getid_fromnumber(onumber._itemnumber_full, itemid, berror)


            Dim oTmpInventory As New ion_two.cls_inventory_lgc
            oTmpInventory._connection_string = Application("config").connection_string
            oTmpInventory._dbtype = Application("config").connection_string_type

            Dim oPlate As New ion_two.skl_lst_inventory
            Dim opicture As New ion_two.cls_pictures
            opicture.load("http://www.twin-diamonds.com", "https://www.twin-diamonds.com")

            oTmpInventory.load(itemid, oPlate, opicture)

            Dim hash As New Hashtable
            hash("id") = oPlate._id
            '
            ''  Dim ohtml As New iFunctions.cls_html
            '' ohtml.EncodeURL2Quary(Me.TextBox2.Text)
            Dim ostringfunc As New iFunctions.cls_string



            ''Dim hash As New Hashtable
            'If Me.e_alt_title.Text <> "" Then
            '    hash("title") = Me.e_alt_title.Text
            'End If
            If Me.e_youtube.Text <> "" Then
                hash("movie") = Me.e_youtube.Text
            End If
            hash("shipping") = 1
            hash("backoffice") = "1"
            hash("siteid") = "6" '' france
            hash("apramount") = oPlate._appraisal_price
            If Me.chk_clarity.Checked Then
                hash("clarity") = "1"
            End If
            Dim d_story As TextBox = Me.pnl_table.Controls(2 * i).FindControl("e_story")
            If d_story.Text <> "" Then
                hash("desc") = ostringfunc.EncodeProblematicChars(d_story.Text)
            End If
            Dim qs As String = ostringfunc.EncodeQuaryString(hash)

            Dim body As String
            Dim omail As New ion_two.cls_mod_mail
            omail.getHTML_byURL("http://www.twin-diamonds.com/ebay/verynewswhow_fr.aspx" + qs, body)





            Dim item As New ArrayList

            item.Add("Add")

            Select Case Me.cmb_site.SelectedValue
                Case "0"
                    item.Add("US")
                Case "3"
                    item.Add("UK")
                Case "15"
                    item.Add("AU")
                Case "71"
                    item.Add("France")
                Case "101"
                    item.Add("IT")
            End Select


            Select Case Me.cmb_format.SelectedValue
                Case "1"
                    item.Add("Auction")
                Case "7"
                    item.Add("StoresFixedPrice")
                Case "9"
                    item.Add("FixedPrice")
            End Select





            Dim d_title As TextBox = Me.pnl_table.Controls(2 * i).FindControl("e_title")

            item.Add(d_title.Text)

            Dim d_subtitle As TextBox = Me.pnl_table.Controls(2 * i).FindControl("e_subtitle")
            If d_subtitle.Text <> "" Then
                item.Add(d_subtitle.Text)
            Else

            End If



            item.Add(oPlate._itemnumber)

            Dim d_cat As TextBox = Me.pnl_table.Controls(2 * i).FindControl("e_category")

            item.Add(d_cat.Text)





            Dim d_storecat As TextBox = Me.pnl_table.Controls(2 * i).FindControl("e_store_category")

            item.Add(d_storecat.Text)

            Dim d_storecat2 As TextBox = Me.pnl_table.Controls(2 * i).FindControl("e_store_category2")

            item.Add(d_storecat2.Text)




            item.Add("1")



            body = body.Replace(vbNewLine, " ")
            'body = body.Replace(vbCrLf, " ")
            'body = body.Replace(vbLf, " ")
            'body = body.Replace(vbCr, " ")
            'body = body.Replace(Chr(13), " ")
            'body = body.Replace(Chr(10), " ")


            body = body.Replace(Chr(34), "'")

            body = "test"
            ''descritopmn
            item.Add(Chr(34) + body + Chr(34))

            ''currency
            Select Case Me.cmb_site.SelectedValue
                Case "0"
                    item.Add("USD")
                Case "3"
                    item.Add("GBP")
                Case "15"
                    item.Add("AUD")
                Case "71"
                    item.Add("EUR")
                Case "101"
                    item.Add("EUR")
            End Select


            Dim d_price As TextBox = Me.pnl_table.Controls(2 * i).FindControl("e_price")




            item.Add(d_price.Text)




            item.Add("IncludedInShippingHandling")









            item.Add(Me.cmb_duration.SelectedValue)
            item.Add("1")
            item.Add("IL")


            item.Add("260000000000")

            item.Add("RetroStyle")



            If oPlate._is_gallery Then
                item.Add(oPlate._gallery_pic)
            Else
                item.Add(oPlate._picture_pic)
            End If



            item.Add("0")

            item.Add("0")
            item.Add("Gallery")


            item.Add("7")

            item.Add("0")

            item.Add("0")

            item.Add("0")

            item.Add("0")

            item.Add("0")









            item.Add("0")




            item.Add("International Diamond Exchange")

            item.Add("0")

            item.Add("0")

            item.Add("1")

            item.Add("avi@twin-diamonds.com")





            item.Add("1")

            item.Add("1")

            item.Add("1")











            item.Add("0")

            item.Add("Flat")

















            item.Add("FR_AuteModeDenvoiDeColis")

            item.Add("0")


            item.Add("1")
            item.Add("1")



            'item.Add("0")
            'item.Add("0")
            'item.Add("0")

























            item.Add("0")
            item.Add("FR_ExpeditedInternational")

            item.Add("0")


            item.Add("Worldwide")

            item.Add("1")






















            item.Add("Worldwide")







            item.Add("0")

            item.Add("1")



            item.Add("1")

            item.Add(Math.Round(Convert.ToInt32(d_price.Text) * 0.88))





            item.Add("1")
            item.Add("1")
            item.Add("twin-diamonds")
            item.Add("1")

            item.Add("twin-diamonds")


            item.Add("-1")
            item.Add("2")


            item.Add("0")

            item.Add("10000")
















            item.Add("0")

            item.Add("10")

            item.Add("0||")
            item.Add("0||")
            item.Add("0")





            item.Add("0")
            item.Add("3")
            item.Add("Worldwide")
            item.Add(oPlate._itemnumber)
            item.Add("0")

            item.Add("ReturnsAccepted")
            item.Add("Days_30")
            item.Add("MoneyBack")
            item.Add("Buyer")

            item.Add("J'accepte le renvoi des objets")
            item.Add("14 jours suivant la réception")





            Dim oextra As New ion_two.cls_jewerly_extra
            oextra.get_stone_extended_string(oPlate._subplate._stone_extended)
            Select Case Me.e_cat.SelectedValue
                Case "115843"
                    item.Add("Neuf")
                    item.Add("Fantaisie")
                    item.Add("Alliance")





                    ''    item.Add("Gold-White")
                    If oPlate._subplate._metal.indexof("Yellow") > -1 Then
                        item.Add("Or jaune")
                    ElseIf oPlate._subplate._metal.indexof("White") > -1 Then
                        item.Add("Or blanc")
                    Else
                        item.Add("Platine")
                    End If
                    item.Add("Diamant")
                    item.Add("Femme") ''weight
                    If oPlate._subplate._metal.indexof("Yellow") > -1 Then
                        item.Add("18 ct")
                    ElseIf oPlate._subplate._metal.indexof("White") > -1 Then
                        item.Add("18 ct")
                    Else
                        item.Add("")
                    End If




            End Select


            ''A:Type	A:Style	A:Main Stone Color	A:Engagement Ring Style	A:Condition	A:Band Style	A:Stone Shape	A:Main Stone Shape	A:Metal	A:Ring Size	A:Clarity	A:Exact Carat Total Weight	A:Main Stone	A:Stone Origin & Treatment	A:Main Stone Treatment	A:Color	A:Gender	A:Certification/Grading	A:Main Stone Certification/Grading	A:Metal Purity	C:Metal	C:Center Stone




            'item.Add(" ")
            'item.Add(" ")
            'item.Add(" ")
            'item.Add(" ")
            'item.Add(" ")
            'item.Add(" ")




            '
            '''load the params
            'oextra.get_stone_extended_string(oPlate._subplate._stone_extended)


            'item.Add("New|New")
            'item.Add(oextra.c_cut.Replace(" Cut", "") + "|" + oextra.c_cut.Replace(" Cut", ""))
            'item.Add(oPlate._subplate._metal + "|" + oPlate._subplate._metal)
            'item.Add("Size Selectable|Size Selectable")

            'item.Add("Enhanced Natural|Enhanced Natural")
            'item.Add("Other|Certificate of Authenticity")
            'item.Add("18k|18k")

            t_csv.Add(item)







        Next




        Dim oFile As System.IO.File

        Dim filename As String = "/ebay" + Date.Now.Ticks.ToString + ".csv"

        Me.csvfile = filename

        Dim oWrite As New System.IO.StreamWriter(Server.MapPath(filename), True, System.Text.Encoding.ASCII)



        '' oWrite = oFile.CreateText(Server.MapPath(filename))
        ''write the thing
        oWrite.WriteLine("Action(CC=Cp1252),SiteID,Format,Title,SubTitle,Custom Label,Category,StoreCategory,StoreCategory2,Quantity,Description,Currency,StartPrice,InsuranceOption,Duration,PrivateAuction,Country,ItemID,Counter,PicURL,BoldTitle,Featured,GalleryType,FeaturedFirstDuration,Highlight,Border,HomePageFeatured,Subtitle in search resutls,GiftIcon,ApplyShippingDiscount,Location,NowandNew,ImmediatePayRequired,PayPalAccepted,PayPalEmailAddress,AmEx,Discover,VisaMastercard,PaymentSeeDescription,ShippingType,ShippingService-1:Option,ShippingService-1:Cost,ShippingService-1:Priority,ShippingService-1:FreeShipping,DispatchTimeMax,IntlShippingService-1:Option,IntlShippingService-1:Cost,IntlShippingService-1:Locations,IntlShippingService-1:Priority,IntlAddnlShiptoLocations,ValuePackBundle,BestOfferEnabled,AutoDecline,MinBestOfferPrice,SkypeChat,SkypeVoice,SkypeName,SkypeOption,SkypeID,BuyerRequirements:MinFeedbackScore,BuyerRequirements:MaxUnpaidItemsCount,BuyerRequirements:LinkedPayPalAccount,ListingDesigner:LayoutID,ListingDesigner:ThemeID,ProStores Enabled,Domestic Profile Discount,International Profile Discount,Apply Profile Domestic,Apply Profile International,PromoteCBT,ShipToLocations,CustomLabel,NowandNew (Sofort and Neu),ReturnsAcceptedOption,ReturnsWithinOption,RefundOption,ShippingCostPaidBy,A:J'accepte le renvoi des objets,A:L'objet doit être renvoyé dans un délai de:,A:Etat,A:Genre,A:Type,A:Matériau,A:Pierre dominante,A:Sexe,A:Carat or")
        For Each item As ArrayList In t_csv
            oWrite.WriteLine(Join(item.ToArray, ","))
        Next

        oWrite.Close()
    End Function

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Response.Redirect("/ebay/ebaycsv.aspx")
    End Sub
End Class
