Imports eBay.Service.Core.Soap
Imports eBay.Service.Core.Sdk
Imports eBay.Service.Call
Imports eBay.Service.Util
Imports System.Xml
Imports System.Data.SqlClient
Imports System.IO
Imports System.Text.RegularExpressions

Partial Class ebaycsv
    Inherits System.Web.UI.Page
    Public itemcount As Int32
    Public usertype As Int32
    Public csvfile As String
    Public oapicontext As New ApiContext
    Public oapicontext2 As New ApiContext

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

        oapicontext.ApiCredential.eBayAccount.Password = "37733773"
        oapicontext.ApiCredential.eBayAccount.UserName = "avigem"
        oapicontext.ApiCredential.eBayToken = "AgAAAA**AQAAAA**aAAAAA**7+16Sg**nY+sHZ2PrBmdj6wVnY+sEZ2PrA2dj6wJnY+pD5KDogmdj6x9nY+seQ**OloAAA**AAMAAA**FnjepJwyxzgzWBrMJqZdXGLcGmIOAKz2ci877u1CDjAvDk7Po27oaUO3EHCeOGCVcSO+x+LDcJWgT5NEBumTWRDaFSImkh906mLjlfQZqj7oMSKvSBHcI4CnBOboMAIo29czX1Eg4dwWGTnzieBfiDIIzTbJFD5f0rXgr8yWC7Za2YrFGHKjNGk9BwoR9YrW1FMLnNu1pVls/lJAodUXenfgJouu4L9+EEJk74ty83Vm6Rs6XINgk+XpDUCy2WRg+TMr4pyrvcQ4X9KhXpad9h+54hgm+4gcIc0FOXRZqEYazFXn5QsUo3RY/VN4afEeUX3T67cyKKxyvYFYjuBKhPVHDVLQg46/G5ve4RgPI5KLQri8Hp0CYvxqrbHMRq3ZKYpbtkw1eq0+onVaG3CvSPrb5OLByNyrDra65Vbbi5mxpssSQEFwPgVpdtAzOgp4RkioBkrIuIvdwJ14EATdbO+urRm9r2fPRmZRa/GbqYFF2wGtAHf6I1KNcvE0f25/Tq2kbQ0Hdaa84cqTo/oRQ0xCjMqdgL1sobAFiRippNzbJo5FXU/DvQgkyRVsZsKQMSCGIv7LKdSklMvSOVpWBae4O9DV1eWK0EMw35eNFzL7b1ARbokDg3VAjtfaU2GkVJG9qXjXK2ymZm64JN92vIC6oosW3YOiYBHtYLyyVcozA+dI1S7C6eQ+/inDB9CowejaJneWJnJKgoJkuZ6s7XYF4d1/zK7mqD5QoF6iSHYjFNU6lR2blpEh56GXVYUJ"

        oapicontext.SoapApiServerUrl = "https://api.ebay.com/wsapi"
        oapicontext.EPSServerUrl = "http://msa-b1.ebay.com/ws/eBayISAPI.dll?EpsBasicApp"

        oapicontext2.ApiCredential.ApiAccount.Application = "Twin-Dia-3f18-4f05-b81a-4ce4ba64f7a4"
        oapicontext2.ApiCredential.ApiAccount.Certificate = "caad245f-7914-4ece-8ada-7a1edfb4453c"
        oapicontext2.ApiCredential.ApiAccount.Developer = "57244916-441d-48cc-a2f4-7d3ea3b68472"

        oapicontext2.ApiCredential.eBayAccount.Password = "37733773"
        oapicontext2.ApiCredential.eBayAccount.UserName = "avigem"
        oapicontext2.ApiCredential.eBayToken = "AgAAAA**AQAAAA**aAAAAA**b+lOSw**nY+sHZ2PrBmdj6wVnY+sEZ2PrA2dj6wJnYahDJCDogWdj6x9nY+seQ**OloAAA**AAMAAA**WmFQzdoX0A4gkFg3iYKyYjFlh3XiO1RFLT5wNqKtHdHkzWeF3pqDbCGLUdb9/FsH9yXGXCmxI5DvWYXOpKRs77KKIG3GaCOmz4Ii62XECIMJvh0aJFvg/LpKt4VFa/zfuNc3FS82SX0dlLmIw7nWyGOlvq/ZKChpPHvLVrrFZ++yfJIJVcKg6qbp08DO1bgsp8eWvsOufVTGDI+GkKy3bcQLfc/7Hm3yG+dnM4T5DRQIVZ/B498VJuVpO3xZEcNOLZVelzgtjDWUAfOxfM8qwd4d3cgVI8g3X6wHZeIDMNFMqewVN5m4hY4twTo82q3uYJmnGUXj1CkCA5mkznNRRPzz8tffVmcVwl/yUdtCCEU/KCR+bq3aK+PpBnIo5EiGIAtq606smCNve+53uDlL3WeF9AdtvETbYD+SxxBiaGRLEjnF3IwatsJ511trGQBJB2OBlDRj/2q7MnRP4x08HYYt38Z5BtrE4LpDqngITPP/+rW/2AFpuzAmQNYJ4HxK3sxl0OQ31u5gp5N9oP2bZOLJ/C9L7d0HvyLzNotp/KgDtsvy4NJDdAa7zdb9lz8dhEVoblZusx0o/aSOMGC/dngH+0rYhyPGC1w0fHUKPOsdEoB7/OGb0mM6z0PlO7v5dUE8ZIoyN/UZk5OW6nP4tX98mcCCzxwodKUW56zZ7v/5IQfvTbIIMPfDRGMtYJEmEnaoKt5Eufj+NY8RoLrWphtxoGooj81FspJmOcoMq+IdIFnN0NOM73RUtQhvHMTU"

        oapicontext2.SoapApiServerUrl = "https://api.ebay.com/wsapi"
        oapicontext2.EPSServerUrl = "http://msa-b1.ebay.com/ws/eBayISAPI.dll?EpsBasicApp"






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

            ''store 2

            Dim ogetstore2 As New GetStoreCall(oapicontext2)
            ogetstore2.DetailLevelList.Add(DetailLevelCodeType.ReturnAll)
            ogetstore2.CategoryStructureOnly = True

            ogetstore2.LevelLimit = 3


            ostore = ogetstore2.GetStore()

            For i = 0 To ostore.CustomCategories.Count - 1
                If ostore.CustomCategories(i).ChildCategory.Count > 0 Then
                    Me.e_store_main_cat2.Items.Add(New WebControls.ListItem("-" + ostore.CustomCategories(i).Name(), ostore.CustomCategories(i).CategoryID))
                    Me.e_store_second_cat2.Items.Add(New WebControls.ListItem("-" + ostore.CustomCategories(i).Name(), ostore.CustomCategories(i).CategoryID))
                    Dim j As Int32

                    For j = 0 To ostore.CustomCategories(i).ChildCategory.Count - 1
                        Me.e_store_main_cat2.Items.Add(New WebControls.ListItem("-----" + ostore.CustomCategories(i).ChildCategory(j).Name, ostore.CustomCategories(i).ChildCategory(j).CategoryID))
                        Me.e_store_second_cat2.Items.Add(New WebControls.ListItem("-----" + ostore.CustomCategories(i).ChildCategory(j).Name, ostore.CustomCategories(i).ChildCategory(j).CategoryID))
                        Dim k As Int32
                        If ostore.CustomCategories(i).ChildCategory(j).ChildCategory.Count > 0 Then
                            For k = 0 To ostore.CustomCategories(i).ChildCategory(j).ChildCategory.Count - 1
                                Me.e_store_main_cat2.Items.Add(New WebControls.ListItem("--------" + ostore.CustomCategories(i).ChildCategory(j).ChildCategory(k).Name, ostore.CustomCategories(i).ChildCategory(j).ChildCategory(k).CategoryID))
                                Me.e_store_second_cat2.Items.Add(New WebControls.ListItem("--------" + ostore.CustomCategories(i).ChildCategory(j).ChildCategory(k).Name, ostore.CustomCategories(i).ChildCategory(j).ChildCategory(k).CategoryID))
                            Next
                        End If

                    Next
                Else
                    Me.e_store_main_cat2.Items.Add(New WebControls.ListItem(" " + ostore.CustomCategories(i).Name(), ostore.CustomCategories(i).CategoryID))
                    Me.e_store_second_cat2.Items.Add(New WebControls.ListItem(" " + ostore.CustomCategories(i).Name(), ostore.CustomCategories(i).CategoryID))
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
            csv.LoadItem(onumber._itemnumber_full, Convert.ToInt32(Me.cmb_site.SelectedValue), conv_rate, Me.txt_desc.Text, Me.chk_clarity.Checked, Me.e_cat.SelectedValue, Me.e_store_main_cat.SelectedValue, Me.e_store_second_cat.SelectedValue, Me.txt_desc.Text, Convert.ToDecimal(Me.e_currency.Text), Me.e_youtube.Text, Me.usertype, Me.e_subtitle.Text)

            Me.pnl_table.Controls.Add(csv)
            Dim br As New HtmlGenericControl
            br.TagName = "br"
            Me.pnl_table.Controls.Add(br)

        Next
    End Function

    Private Sub btn_save_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_save.Click
        Select Case Me.cmb_site.SelectedValue
            Case "0"
                Me.SaveCSV()
                '  item.Add("US")
            Case "3"
                Me.SaveCSV()
                ' item.Add("UK")
            Case "15"
                Me.SaveCSV_AU()
                '  item.Add("AU")
            Case "71"
                Me.SaveCSV_FR()
                '  item.Add("FR")
            Case Else
                Me.SaveCSV()

        End Select


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


            Select Case Me.cmb_site.SelectedValue
                Case "0"
                    hash("siteid") = "1"
                Case "3"
                    hash("siteid") = "2"
            End Select

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
            If Me.usertype = 2 Then
                omail.getHTML_byURL("http://www.twin-diamonds.com/ebay/verynewswhow2.aspx" + qs, body)
            Else
                omail.getHTML_byURL("http://www.twin-diamonds.com/ebay/verynewswhow.aspx" + qs, body)
            End If




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
                    item.Add("FR")
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

            item.Add(Chr(34) + d_title.Text + Chr(34))

            Dim d_subtitle As TextBox = Me.pnl_table.Controls(2 * i).FindControl("e_subtitle")
            If d_subtitle.Text <> "" Then
                item.Add(Chr(34) + d_subtitle.Text + Chr(34))
            Else

            End If



            item.Add(oPlate._itemnumber)

            Dim d_cat As TextBox = Me.pnl_table.Controls(2 * i).FindControl("e_category")

            Select Case Me.cmb_site.SelectedValue
                Case "0"
                    item.Add(Me.e_cat.SelectedValue)

                Case "3"
                    item.Add(Me.e_cat_uk.SelectedValue)
            End Select






            Dim d_storecat As TextBox = Me.pnl_table.Controls(2 * i).FindControl("e_store_category")

            If Me.usertype = 2 Then
                item.Add(Me.e_store_main_cat2.SelectedValue)
            Else
                item.Add(Me.e_store_main_cat.SelectedValue)
            End If
            Dim d_storecat2 As TextBox = Me.pnl_table.Controls(2 * i).FindControl("e_store_category2")

            If Me.usertype = 2 Then
                item.Add(Me.e_store_second_cat2.SelectedValue)
            Else
                item.Add(Me.e_store_second_cat.SelectedValue)
            End If




            item.Add("1")



            body = body.Replace(vbNewLine, " ")
            'body = body.Replace(vbCrLf, " ")
            'body = body.Replace(vbLf, " ")
            'body = body.Replace(vbCr, " ")
            'body = body.Replace(Chr(13), " ")
            'body = body.Replace(Chr(10), " ")


            body = body.Replace(Chr(34), "'")

            '' body = "test"
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
            Dim newprice As Decimal = Convert.ToDecimal(d_price.Text) * Convert.ToDecimal(Me.e_currency.Text)

            newprice = Math.Round(newprice)

            d_price.Text = newprice.ToString


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

















            item.Add("ShippingMethodStandard")

            item.Add("0")


            item.Add("1")
            item.Add("1")



            'item.Add("0")
            'item.Add("0")
            'item.Add("0")

























            item.Add("10")
            item.Add("StandardInternational")

            item.Add("0")


            item.Add("Worldwide")

            item.Add("1")






















            item.Add("Worldwide")







            item.Add("0")

            item.Add("1")



            item.Add("1")
            If oPlate._purchase_price * 1.3 > newprice * 0.88 Then
                item.Add(Math.Round((oPlate._purchase_price * 1.3)))
            Else
                item.Add(Math.Round((newprice * 0.95)))
            End If


            item.Add("1")

            item.Add(Math.Round((newprice * 0.88 / 100)) * 100)





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



            Dim oextra As New ion_two.cls_jewerly_extra
            oextra.get_stone_extended_string(oPlate._subplate._stone_extended)
            ''exect carat weight
            Dim carat_weight As String
            If Regex.Matches(d_title.Text, "\d{1,3}\.?\d{1,3}?(?=\sCt|\sCT)").Count > 0 Then
                carat_weight = Regex.Matches(d_title.Text, "\d{1,3}\.?\d{1,3}?(?=\sCt|\sCT)")(0).Value
            End If

            Dim clarity As String
            Dim color As String

            If Regex.Matches(d_title.Text, "\s(\w{1})/(\w{1,4})\s").Count > 0 Then
                clarity = Regex.Match(d_title.Text, "\s(\w{1})/(\w{1,4})\s").Groups(1).Value
                color = Regex.Match(d_title.Text, "\s(\w{1})/(\w{1,4})\s").Groups(2).Value
            End If



            If Me.cmb_site.SelectedValue = "0" Then
                Select Case Me.e_cat.SelectedValue
                    Case "152899"
                        item.Add("")
                        item.Add("")
                        Select Case oPlate._subplate._middlestone
                            Case "Ruby"
                                item.Add("Red")
                            Case "Emerald"
                                item.Add("Greeb")
                            Case "Sapphire"
                                item.Add("Blue")
                            Case Else
                                item.Add("White")
                        End Select

                        item.Add("")

                        item.Add("New")

                        item.Add("")
                        item.Add(oextra.c_cut.Replace(" Cut", ""))
                        item.Add(oextra.c_cut.Replace(" Cut", ""))


                        ''    item.Add("Gold-White")
                        If oPlate._subplate._metal.indexof("Yellow") > -1 Then
                            item.Add("Gold-Yellow")
                        ElseIf oPlate._subplate._metal.indexof("White") > -1 Then
                            item.Add("Gold-White")
                        ElseIf oPlate._subplate._metal.indexof("Rose") > -1 Then
                            item.Add("Gold-Rose")
                        Else
                            item.Add("Platinum")
                        End If
                        item.Add("Size Selectable")
                        item.Add("Other|" + clarity) ''weight
                        ''   item.Add("") ''c;larity
                        item.Add(carat_weight)
                        item.Add("")
                        If Me.chk_clarity.Checked Then
                            item.Add("Enhanced Natural")
                        Else
                            item.Add("Natural")
                        End If


                        item.Add("")
                        item.Add("Other|" + color)
                        item.Add("")
                        item.Add("Other|Certificate of Authenticity")
                        '' item.Add("")
                        item.Add("")
                        If oPlate._subplate._metal.indexof("Yellow") > -1 Then
                            item.Add("18k")
                        ElseIf oPlate._subplate._metal.indexof("White") > -1 Then
                            item.Add("18k")
                        ElseIf oPlate._subplate._metal.indexof("Rose") > -1 Then
                            item.Add("18k")
                        Else
                            item.Add("")
                        End If
                        item.Add("")
                        item.Add("")
                    Case "152869"
                        item.Add("")
                        item.Add("")
                        item.Add("")
                        item.Add("")

                        item.Add("New")


                        item.Add("")
                        item.Add(oextra.c_cut.Replace(" Cut", "") + "|" + oextra.c_cut.Replace(" Cut", ""))
                        item.Add(oextra.c_cut.Replace(" Cut", "") + "|" + oextra.c_cut.Replace(" Cut", ""))

                        ''    item.Add("Gold-White")
                        If oPlate._subplate._metal.indexof("Yellow") > -1 Then
                            item.Add("Gold-Yellow")
                        ElseIf oPlate._subplate._metal.indexof("White") > -1 Then
                            item.Add("Gold-White")
                        ElseIf oPlate._subplate._metal.indexof("Rose") > -1 Then
                            item.Add("Gold-Rose")
                        Else
                            item.Add("Platinum")
                        End If
                        item.Add("Size Selectable|Size Selectable")
                        item.Add("") ''weight
                        item.Add("") ''c;larity
                        item.Add(carat_weight)
                        If Me.chk_clarity.Checked Then
                            item.Add("Enhanced Natural|Enhanced Natural")
                        Else
                            item.Add("Natural|Natural")
                        End If

                        item.Add("")
                        item.Add("")
                        item.Add("")


                        item.Add("")
                        item.Add("Other|Certificate of Authenticity")
                        If oPlate._subplate._metal.indexof("Yellow") > -1 Then
                            item.Add("18k")
                        ElseIf oPlate._subplate._metal.indexof("White") > -1 Then
                            item.Add("18k")
                        ElseIf oPlate._subplate._metal.indexof("Rose") > -1 Then
                            item.Add("18k")
                        Else
                            item.Add("")
                        End If
                        item.Add("")
                        item.Add("")

                    Case "152872"
                        item.Add("")
                        item.Add("")
                        item.Add("")
                        item.Add("")

                        item.Add("New")


                        item.Add("")
                        '' item.Add("")
                        item.Add("")
                        If oextra.c_cut.Replace(" Cut", "") = "Princess" Then
                            item.Add(Chr(34) + "Square, Princess" + Chr(34))
                        Else
                            item.Add(oextra.c_cut.Replace(" Cut", ""))
                        End If



                        ''    item.Add("Gold-White")
                        If oPlate._subplate._metal.indexof("Yellow") > -1 Then
                            item.Add("Gold-Yellow")
                        ElseIf oPlate._subplate._metal.indexof("White") > -1 Then
                            item.Add("Gold-White")
                        ElseIf oPlate._subplate._metal.indexof("Rose") > -1 Then
                            item.Add("Gold-Rose")
                        Else
                            item.Add("Platinum")
                        End If
                        item.Add("Size Selectable")
                        item.Add("") ''weight
                        item.Add(carat_weight)
                        item.Add(carat_weight)

                        If Me.chk_clarity.Checked Then
                            item.Add("Enhanced Natural|Enhanced Natural")
                        Else
                            item.Add("Natural|Natural")
                        End If

                        item.Add("")
                        item.Add("")
                        item.Add("")


                        item.Add("")
                        If oPlate._subplate._report = "-" Then
                            item.Add("Other|" + "Certificate of Authenticity")
                        Else
                            item.Add("Other|" + oPlate._subplate._report)
                        End If

                        If oPlate._subplate._metal.indexof("Yellow") > -1 Then
                            item.Add("18k")
                        ElseIf oPlate._subplate._metal.indexof("White") > -1 Then
                            item.Add("18k")
                        ElseIf oPlate._subplate._metal.indexof("Rose") > -1 Then
                            item.Add("18k")
                        Else
                            item.Add("")
                        End If
                        item.Add("")
                        item.Add("")


                    Case "92909"
                        item.Add("Engagement + Band")
                        item.Add("")
                        item.Add("")
                        Select Case oPlate._subplate._jewelrysubtype
                            Case "Solitaire"
                                If oextra.s_desc = "" Then
                                    item.Add("Diamond Solitaire")
                                Else
                                    item.Add("Diamond Solitaire with Accents")
                                End If

                            Case "Three Stone"
                                item.Add("Diamond Three-Stone")
                            Case Else
                                item.Add("Eternity")

                        End Select


                        item.Add("New")


                        item.Add("Bands without Stones")
                        item.Add(oextra.c_cut.Replace(" Cut", ""))
                        item.Add(oextra.c_cut.Replace(" Cut", ""))

                        If oPlate._subplate._metal.indexof("Yellow") > -1 Then
                            item.Add("Gold-Yellow")
                        ElseIf oPlate._subplate._metal.indexof("White") > -1 Then
                            item.Add("Gold-White")
                        ElseIf oPlate._subplate._metal.indexof("Rose") > -1 Then
                            item.Add("Gold-Rose")
                        Else
                            item.Add("Platinum")
                        End If
                        item.Add("Size Selectable")
                        item.Add("") ''weight
                        item.Add("") ''c;larity
                        item.Add("|" + carat_weight)
                        item.Add("Natural Diamonds|Enhanced Natural Diamonds")

                        item.Add("")
                        item.Add("")
                        item.Add("")


                        item.Add("")
                        item.Add("")
                        item.Add("")
                        If oPlate._subplate._metal.indexof("Yellow") > -1 Then
                            item.Add("18k")
                        ElseIf oPlate._subplate._metal.indexof("White") > -1 Then
                            item.Add("18k")
                        ElseIf oPlate._subplate._metal.indexof("Rose") > -1 Then
                            item.Add("18k")
                        Else
                            item.Add("")
                        End If
                        item.Add("")
                        item.Add("")

                    Case "92853"
                        item.Add("")
                        item.Add("With Diamonds")
                        item.Add("")
                        item.Add("")

                        item.Add("New")


                        item.Add("")
                        item.Add(oextra.c_cut.Replace(" Cut", ""))
                        item.Add(oextra.c_cut.Replace(" Cut", ""))

                        If oPlate._subplate._metal.indexof("Yellow") > -1 Then
                            item.Add("Gold-Yellow")
                        ElseIf oPlate._subplate._metal.indexof("White") > -1 Then
                            item.Add("Gold-White")
                        ElseIf oPlate._subplate._metal.indexof("Rose") > -1 Then
                            item.Add("Gold-Rose")
                        Else
                            item.Add("Platinum")
                        End If





                        item.Add("Size Selectable")
                        item.Add("") ''weight
                        item.Add("") ''c;larity
                        item.Add("|" + carat_weight)

                        If Me.chk_clarity.Checked Then

                            If oextra.s_desc <> "" Then
                                item.Add("Natural Diamonds|Enhanced Natural Diamonds")
                            Else
                                item.Add("Enhanced Natural Diamonds")
                            End If
                        Else
                            item.Add("Natural Diamonds")
                        End If


                        item.Add("")
                        item.Add("")
                        item.Add("Women's")


                        item.Add("")
                        item.Add("")
                        If oPlate._subplate._metal.indexof("Yellow") > -1 Then
                            item.Add("18k")
                        ElseIf oPlate._subplate._metal.indexof("White") > -1 Then
                            item.Add("18k")
                        ElseIf oPlate._subplate._metal.indexof("Rose") > -1 Then
                            item.Add("18k")
                        Else
                            item.Add("")
                        End If
                        item.Add("")
                        item.Add("")

                    Case "92913"
                        item.Add("")
                        item.Add("Solitaire w/ Accent Stones")
                        Select Case oPlate._subplate._middlestone
                            Case "Ruby"
                                item.Add("Red")
                            Case "Emerald"
                                item.Add("Greeb")
                            Case "Sapphire"
                                item.Add("Blue")
                            Case Else
                                item.Add("White")
                        End Select

                        item.Add("")

                        item.Add("New")


                        item.Add("")
                        item.Add(oextra.c_cut.Replace(" Cut", ""))
                        item.Add(oextra.c_cut.Replace(" Cut", ""))

                        If oPlate._subplate._metal.indexof("Yellow") > -1 Then
                            item.Add("Gold-Yellow")
                        ElseIf oPlate._subplate._metal.indexof("White") > -1 Then
                            item.Add("Gold-White")
                        ElseIf oPlate._subplate._metal.indexof("Rose") > -1 Then
                            item.Add("Other|Rose Gold")
                        Else
                            item.Add("Other|Platinum")
                        End If





                        item.Add("Size Selectable")
                        item.Add("") ''weight
                        item.Add("") ''c;larity
                        item.Add("|" + carat_weight)
                        If oextra.c_type.Replace("Natural ", "") = "Diamonds" Then
                            item.Add("Diamond")
                        Else
                            item.Add(oextra.c_type.Replace("Natural ", "").Replace(" ( clarity Enhanced )", ""))
                        End If

                        item.Add("")

                        item.Add("")
                        item.Add("")
                        item.Add("")


                        item.Add("")
                        item.Add("")
                        If oPlate._subplate._metal.indexof("Yellow") > -1 Then
                            item.Add("18k")
                        ElseIf oPlate._subplate._metal.indexof("White") > -1 Then
                            item.Add("18k")
                        ElseIf oPlate._subplate._metal.indexof("Rose") > -1 Then
                            item.Add("18k")
                        Else
                            item.Add("")
                        End If
                        item.Add("")
                        item.Add("")

                    Case "67727"
                        item.Add("")
                        Select Case oPlate._subplate._jewelrysubtype
                            Case "Solitaire"
                                If oextra.s_desc = "" Then
                                    item.Add("Solitaire")
                                Else
                                    item.Add("Solitaire w/ Accent Stones")
                                End If

                            Case "Three Stone"
                                item.Add("Three-Stone")
                            Case Else
                                item.Add("Eternity")

                        End Select


                        Select Case oPlate._subplate._middlestone
                            Case "Ruby"
                                item.Add("Red")
                            Case "Emerald"
                                item.Add("Greeb")
                            Case "Sapphire"
                                item.Add("Blue")
                            Case Else
                                item.Add("White")
                        End Select

                        item.Add("")

                        item.Add("New")


                        item.Add("")
                        item.Add(oextra.c_cut.Replace(" Cut", ""))
                        item.Add(oextra.c_cut.Replace(" Cut", ""))


                        If oPlate._subplate._metal.indexof("Yellow") > -1 Then
                            item.Add("Gold-Yellow")
                        ElseIf oPlate._subplate._metal.indexof("White") > -1 Then
                            item.Add("Gold-White")
                        ElseIf oPlate._subplate._metal.indexof("Rose") > -1 Then
                            item.Add("Gold-Rose")
                        Else
                            item.Add("Platinum")
                        End If



                        item.Add("Size Selectable")
                        item.Add("") ''weight
                        item.Add("") ''c;larity
                        item.Add("|" + carat_weight)
                        item.Add(oextra.c_type.Replace("Natural ", "").Replace(" ( clarity Enhanced )", ""))

                        item.Add("")
                        item.Add("")
                        item.Add("")


                        item.Add("")
                        item.Add("")
                        If oPlate._subplate._metal.indexof("Yellow") > -1 Then
                            item.Add("18k")
                        ElseIf oPlate._subplate._metal.indexof("White") > -1 Then
                            item.Add("18k")
                        ElseIf oPlate._subplate._metal.indexof("Rose") > -1 Then
                            item.Add("18k")
                        Else
                            item.Add("")
                        End If
                        item.Add("")
                        item.Add("")

                    Case "164342"
                        item.Add("")
                        Select Case oPlate._subplate._jewelrysubtype
                            Case "Solitaire"
                                If oextra.s_desc = "" Then
                                    item.Add("Solitaire")
                                Else
                                    item.Add("Solitaire with Accents")
                                End If

                            Case "Three Stone"
                                item.Add("Three-Stone")
                            Case Else
                                item.Add("Solitaire")

                        End Select


                        Select Case oPlate._subplate._middlestone
                            Case "Ruby"
                                item.Add("Red")
                            Case "Emerald"
                                item.Add("Greeb")
                            Case "Sapphire"
                                item.Add("Blue")
                            Case Else
                                item.Add("White")
                        End Select

                        item.Add("")

                        item.Add("New")


                        item.Add("")
                        item.Add(oextra.c_cut.Replace(" Cut", ""))
                        item.Add(oextra.c_cut.Replace(" Cut", ""))


                        If oPlate._subplate._metal.indexof("Yellow") > -1 Then
                            item.Add("Gold-Yellow")
                        ElseIf oPlate._subplate._metal.indexof("White") > -1 Then
                            item.Add("Gold-White")
                        ElseIf oPlate._subplate._metal.indexof("Rose") > -1 Then
                            item.Add("Gold-Rose")
                        Else
                            item.Add("Platinum")
                        End If





                        item.Add("Size Selectable")
                        item.Add("") ''weight
                        '' item.Add("") ''c;larity
                        item.Add(carat_weight)
                        If oextra.c_type.Replace("Natural ", "") = "Diamonds" Then
                            item.Add("Diamond")
                        Else
                            item.Add(oextra.c_type.Replace("Natural ", "").Replace(" ( clarity Enhanced )", ""))
                        End If


                        item.Add("")
                        item.Add(Chr(34) + "Natural, Not Enhanced" + Chr(34))
                        item.Add("")


                        item.Add("")
                        item.Add("")
                        item.Add("")
                        If oPlate._subplate._metal.indexof("Yellow") > -1 Then
                            item.Add(Chr(34) + "18k (Solid, Unplated)" + Chr(34))
                        ElseIf oPlate._subplate._metal.indexof("White") > -1 Then
                            item.Add(Chr(34) + "18k (Solid, Unplated)" + Chr(34))
                        ElseIf oPlate._subplate._metal.indexof("Rose") > -1 Then
                            item.Add(Chr(34) + "18k (Solid, Unplated)" + Chr(34))
                        Else
                            item.Add("")
                        End If
                        item.Add("")
                        item.Add("")

                    Case "164343"
                        item.Add("")
                        Select Case oPlate._subplate._jewelrysubtype
                            Case "Solitaire"
                                If oextra.s_desc = "" Then
                                    item.Add("Solitaire")
                                Else
                                    item.Add("Solitaire with Accents")
                                End If

                            Case "Three Stone"
                                item.Add("Three-Stone")
                            Case Else
                                item.Add("Solitaire")

                        End Select


                        Select Case oPlate._subplate._middlestone
                            Case "Ruby"
                                item.Add("Red")
                            Case "Emerald"
                                item.Add("Greeb")
                            Case "Sapphire"
                                item.Add("Blue")
                            Case Else
                                item.Add("White")
                        End Select

                        item.Add("")

                        item.Add("New")


                        item.Add("")
                        item.Add(oextra.c_cut.Replace(" Cut", ""))
                        item.Add(oextra.c_cut.Replace(" Cut", ""))


                        If oPlate._subplate._metal.indexof("Yellow") > -1 Then
                            item.Add("Gold-Yellow")
                        ElseIf oPlate._subplate._metal.indexof("White") > -1 Then
                            item.Add("Gold-White")
                        ElseIf oPlate._subplate._metal.indexof("Rose") > -1 Then
                            item.Add("Gold-Rose")
                        Else
                            item.Add("Platinum")
                        End If





                        item.Add("Size Selectable")
                        item.Add("") ''weight
                        '' item.Add("") ''c;larity
                        item.Add(carat_weight)
                        If oextra.c_type.Replace("Natural ", "") = "Diamonds" Then
                            item.Add("Diamond")
                        Else
                            item.Add(oextra.c_type.Replace("Natural ", "").Replace(" ( clarity Enhanced )", ""))
                        End If


                        item.Add("")
                        item.Add(Chr(34) + "Natural, Not Enhanced" + Chr(34))
                        item.Add("")


                        item.Add("")
                        item.Add("")
                        item.Add("")
                        If oPlate._subplate._metal.indexof("Yellow") > -1 Then
                            item.Add(Chr(34) + "18k (Solid, Unplated)" + Chr(34))
                        ElseIf oPlate._subplate._metal.indexof("White") > -1 Then
                            item.Add(Chr(34) + "18k (Solid, Unplated)" + Chr(34))
                        ElseIf oPlate._subplate._metal.indexof("Rose") > -1 Then
                            item.Add(Chr(34) + "18k (Solid, Unplated)" + Chr(34))
                        Else
                            item.Add("")
                        End If
                        item.Add("")
                        item.Add("")

                    Case "45381"
                        item.Add("")
                        item.Add("")
                        item.Add("")
                        item.Add("")

                        item.Add("New")


                        item.Add("")
                        item.Add(oextra.c_cut.Replace(" Cut", ""))
                        item.Add(oextra.c_cut.Replace(" Cut", ""))

                        item.Add("")

                        item.Add("")



                        item.Add("")
                        item.Add("") ''weight
                        item.Add("") ''c;larity

                        item.Add("|" + carat_weight)

                        If oextra.c_type.Replace("Natural ", "") = "Diamonds" Then
                            item.Add("Diamond")
                        Else
                            item.Add(oextra.c_type.Replace("Natural ", "").Replace(" ( clarity Enhanced )", ""))
                        End If

                        '' item.Add(oextra.c_type.Replace("Natural ", "").Replace(" ( clarity Enhanced )", ""))

                        item.Add("")
                        item.Add("")
                        item.Add("")


                        item.Add("")
                        item.Add("")
                        item.Add("")
                        If oPlate._subplate._metal.indexof("Yellow") > -1 Then
                            item.Add("18k Yellow Gold")
                        ElseIf oPlate._subplate._metal.indexof("White") > -1 Then
                            item.Add("18k White Gold")
                        ElseIf oPlate._subplate._metal.indexof("Rose") > -1 Then
                            item.Add("18k Rose Gold")
                        Else
                            item.Add("Platinum")
                        End If

                        item.Add("")

                    Case "92852"
                        item.Add("")
                        item.Add("")
                        item.Add("")
                        item.Add("")

                        item.Add("New")


                        item.Add("")
                        item.Add(oextra.c_cut.Replace(" Cut", ""))
                        item.Add(oextra.c_cut.Replace(" Cut", ""))


                        If oPlate._subplate._metal.indexof("Yellow") > -1 Then
                            item.Add("Gold-Yellow")
                        ElseIf oPlate._subplate._metal.indexof("White") > -1 Then
                            item.Add("Gold-White")
                        ElseIf oPlate._subplate._metal.indexof("Rose") > -1 Then
                            item.Add("Gold-Rose")
                        Else
                            item.Add("Platinum")
                        End If





                        item.Add("Size Selectable")
                        item.Add("") ''weight
                        item.Add("") ''c;larity
                        item.Add("|" + carat_weight)
                        If oextra.c_type.Replace("Natural ", "") = "Diamonds" Then
                            item.Add("Diamond")
                        Else
                            item.Add(oextra.c_type.Replace("Natural ", "").Replace(" ( clarity Enhanced )", ""))
                        End If

                        item.Add("")
                        item.Add("")
                        item.Add("Women's")


                        item.Add("")
                        item.Add("")
                        If oPlate._subplate._metal.indexof("Yellow") > -1 Then
                            item.Add("18k (Solid, Unplated)")
                        ElseIf oPlate._subplate._metal.indexof("White") > -1 Then
                            item.Add("18k (Solid, Unplated)")
                        ElseIf oPlate._subplate._metal.indexof("Rose") > -1 Then
                            item.Add(Chr(34) + "18k (Solid, Unplated)" + Chr(34))
                        Else
                            item.Add("")
                        End If
                        item.Add("")
                        item.Add("")

                    Case "43348"
                        item.Add("")
                        item.Add("")
                        item.Add("New")
                        item.Add("")
                        item.Add("")
                        item.Add("")
                        item.Add("")
                        item.Add("")
                        item.Add(oPlate._subplate._metal)
                        item.Add(oextra.c_type)
                        item.Add(oPlate._itemnumber)
                        item.Add(oPlate._subplate._s_weight)
                        item.Add(oPlate._subplate._jewelrysubtype + " Bracelet")
                        item.Add(oPlate._subplate._setting)
                        'Select Case oPlate._subplate._jewelrysubtype
                        '    Case "Solitaire"
                        '        If oextra.s_desc = "" Then
                        '            item.Add("Solitaire")
                        '        Else
                        '            item.Add("Solitaire with Accents")
                        '        End If

                        '    Case "Three Stone"
                        '        item.Add("Three-Stone")

                        'End Select


                        'item.Add("White")
                        'item.Add("")

                        'item.Add("New")


                        'item.Add("")
                        'item.Add(oextra.c_cut.Replace(" Cut", ""))
                        'item.Add(oextra.c_cut.Replace(" Cut", ""))


                        'If oPlate._subplate._metal.indexof("Yellow") > -1 Then
                        '    item.Add("Gold-Yellow")
                        'ElseIf oPlate._subplate._metal.indexof("White") > -1 Then
                        '    item.Add("Gold-White")
                        'Else
                        '    item.Add("Platinum")
                        'End If





                        'item.Add("Size Selectable")
                        'item.Add("") ''weight
                        ''' item.Add("") ''c;larity
                        'item.Add(carat_weight)
                        'If oextra.c_type.Replace("Natural ", "") = "Diamonds" Then
                        '    item.Add("Diamond")
                        'Else
                        '    item.Add(oextra.c_type.Replace("Natural ", "").Replace(" ( clarity Enhanced )", ""))
                        'End If


                        'item.Add("")
                        'item.Add(Chr(34) + "Natural, Not Enhanced" + Chr(34))
                        'item.Add("")


                        'item.Add("")
                        'item.Add("")
                        'item.Add("")
                        'If oPlate._subplate._metal.indexof("Yellow") > -1 Then
                        '    item.Add(Chr(34) + "18k (Solid, Unplated)" + Chr(34))
                        'ElseIf oPlate._subplate._metal.indexof("White") > -1 Then
                        '    item.Add(Chr(34) + "18k (Solid, Unplated)" + Chr(34))
                        'Else
                        '    item.Add("")
                        'End If
                        'item.Add("")
                        'item.Add("")
                    Case "164314"
                        item.Add("Other|" + oPlate._subplate._jewelrysubtype)

                        Select Case oPlate._subplate._middlestone
                            Case "Ruby"
                                item.Add("Red")
                            Case "Emerald"
                                item.Add("Greeb")
                            Case "Sapphire"
                                item.Add("Blue")
                            Case Else
                                item.Add("White")
                        End Select

                        item.Add("New")

                        If oPlate._subplate._metal.indexof("Yellow") > -1 Then
                            item.Add("Gold-Yellow")
                        ElseIf oPlate._subplate._metal.indexof("White") > -1 Then
                            item.Add("Gold-White")
                        ElseIf oPlate._subplate._metal.indexof("Rose") > -1 Then
                            item.Add("Gold-Rose")
                        Else
                            item.Add("Platinum")
                        End If

                        item.Add(carat_weight)

                        If oextra.c_type.Replace("Natural ", "") = "Diamonds" Then
                            item.Add("Diamond")
                        Else
                            item.Add(oextra.c_type.Replace("Natural ", "").Replace(" ( clarity Enhanced )", ""))
                        End If
                        item.Add(Chr(34) + "Natural, Not Enhanced" + Chr(34))

                        If oPlate._subplate._metal.indexof("Yellow") > -1 Then
                            item.Add(Chr(34) + "18k (Solid, Unplated)" + Chr(34))
                        ElseIf oPlate._subplate._metal.indexof("White") > -1 Then
                            item.Add(Chr(34) + "18k (Solid, Unplated)" + Chr(34))
                        ElseIf oPlate._subplate._metal.indexof("Rose") > -1 Then
                            item.Add(Chr(34) + "18k (Solid, Unplated)" + Chr(34))
                        Else
                            item.Add("")
                        End If
                        item.Add("")
                        item.Add("")
                        item.Add("")
                        item.Add("")
                        item.Add("")
                        item.Add("")

                    Case "164320", "116136", "116127", "110590", "86023"
                        item.Add("Other|" + oPlate._subplate._jewelrysubtype)
                        Select Case oPlate._subplate._middlestone
                            Case "Ruby"
                                item.Add("Red")
                            Case "Emerald"
                                item.Add("Greeb")
                            Case "Sapphire"
                                item.Add("Blue")
                            Case Else
                                item.Add("White")
                        End Select

                        item.Add("New")
                        If oPlate._subplate._metal.indexof("Yellow") > -1 Then
                            item.Add("Gold-Yellow")
                        ElseIf oPlate._subplate._metal.indexof("White") > -1 Then
                            item.Add("Gold-White")
                        ElseIf oPlate._subplate._metal.indexof("Rose") > -1 Then
                            item.Add("Gold-Rose")
                        Else
                            item.Add("Platinum")
                        End If
                        item.Add(carat_weight)

                        If oextra.c_type.Replace("Natural ", "") = "Diamonds" Then
                            item.Add("Diamond")
                        Else
                            item.Add(oextra.c_type.Replace("Natural ", "").Replace(" ( clarity Enhanced )", ""))
                        End If

                        item.Add(Chr(34) + "Natural, Not Enhanced" + Chr(34))


                        If oPlate._subplate._metal.indexof("Yellow") > -1 Then
                            item.Add(Chr(34) + "18k (Solid, Unplated)" + Chr(34))
                        ElseIf oPlate._subplate._metal.indexof("White") > -1 Then
                            item.Add(Chr(34) + "18k (Solid, Unplated)" + Chr(34))
                        ElseIf oPlate._subplate._metal.indexof("Rose") > -1 Then
                            item.Add(Chr(34) + "18k (Solid, Unplated)" + Chr(34))
                        Else
                            item.Add("")
                        End If
                        item.Add(oPlate._subplate._jewelrysubtype)
                        item.Add(oextra.c_type)
                        item.Add(oPlate._subplate._metal)

                        item.Add(oextra.c_type)





                End Select
            Else
                Select Case Me.e_cat_uk.SelectedValue
                    ''UK

                    Case "10986"

                        item.Add("Earrings")
                        item.Add("Other|Twin-Diamonds")

                        Select Case oPlate._subplate._jewelrysubtype
                            Case "Stud"
                                item.Add("Studs")
                            Case "Hoop"
                                item.Add("Hoops")
                            Case "Drop"
                                item.Add("Drop / Dangling")
                            Case Else
                                item.Add("Other|" + oPlate._subplate._jewelrysubtype)
                        End Select
                        item.Add("New")
                        item.Add(oextra.c_cut.Replace(" Cut", ""))
                        item.Add("")

                        If oPlate._subplate._metal.indexof("Yellow") > -1 Then
                            item.Add("Yellow Gold")
                        ElseIf oPlate._subplate._metal.indexof("White") > -1 Then
                            item.Add("White Gold")
                        ElseIf oPlate._subplate._metal.indexof("Rose") > -1 Then
                            item.Add("Rose Gold")
                        Else
                            item.Add("Platinum")
                        End If
                        item.Add("")

                        item.Add(carat_weight)
                        item.Add("")
                        item.Add("")
                        item.Add("")
                        item.Add("")

                        If oextra.c_type.Replace("Natural ", "") = "Diamonds" Then
                            item.Add("Diamond")
                        Else
                            item.Add(oextra.c_type.Replace("Natural ", "").Replace(" ( clarity Enhanced )", ""))
                        End If


                        If oPlate._subplate._metal.indexof("Yellow") > -1 Then
                            item.Add("18 carat")
                        ElseIf oPlate._subplate._metal.indexof("White") > -1 Then
                            item.Add("18 carat")
                        ElseIf oPlate._subplate._metal.indexof("Rose") > -1 Then
                            item.Add("18 carat")
                        Else
                            item.Add("")
                        End If

                    Case "11002"

                        item.Add("Pendant/ Locket|Pendant/ Locket")
                        item.Add("Other|Twin-Diamonds")

                        item.Add("")

                        item.Add("New|New")
                        item.Add(oextra.c_cut)
                        item.Add("")

                        If oPlate._subplate._metal.indexof("Yellow") > -1 Then
                            item.Add("Yellow Gold|Yellow Gold")
                        ElseIf oPlate._subplate._metal.indexof("White") > -1 Then
                            item.Add("Yellow Gold|Yellow Gold")
                        ElseIf oPlate._subplate._metal.indexof("Rose") > -1 Then
                            item.Add("Rose Gold|Rose Gold")
                        Else
                            item.Add("Platinum|Platinum")
                        End If
                        item.Add("")

                        item.Add(carat_weight)
                        item.Add("")
                        item.Add("")
                        item.Add("")
                        item.Add("")

                        If oextra.c_type.Replace("Natural ", "") = "Diamonds" Then
                            item.Add("Diamond|Diamond")
                        Else
                            item.Add(oextra.c_type.Replace("Natural ", "").Replace(" ( clarity Enhanced )", "") + "|" + oextra.c_type.Replace("Natural ", "").Replace(" ( clarity Enhanced )", ""))
                        End If


                        If oPlate._subplate._metal.indexof("Yellow") > -1 Then
                            item.Add("18 carat|18 carat")
                        ElseIf oPlate._subplate._metal.indexof("White") > -1 Then
                            item.Add("18 carat|18 carat")
                        ElseIf oPlate._subplate._metal.indexof("Rose") > -1 Then
                            item.Add("18 carat|18 carat")
                        Else
                            item.Add("")
                        End If

                    Case "67726"

                        item.Add("Earrings")
                        item.Add("Other|Twin-Diamonds")

                        Select Case oPlate._subplate._jewelrysubtype
                            Case "Stud"
                                item.Add("Studs")
                            Case "Hoop"
                                item.Add("Hoops")
                            Case "Drop"
                                item.Add("Drop / Dangling")
                            Case Else
                                item.Add("Other|" + oPlate._subplate._jewelrysubtype)
                        End Select
                        item.Add("New")
                        Select Case oextra.c_cut.Replace(" Cut", "")
                            Case "Round"
                                item.Add("Round Brilliant")
                            Case "Princess"
                                item.Add("Square, Princess")
                            Case Else
                                item.Add("Other|" + oextra.c_cut.Replace(" Cut", ""))
                        End Select

                        Select Case oextra.c_cut.Replace(" Cut", "")
                            Case "Round"
                                item.Add("Round Brilliant")
                            Case "Princess"
                                item.Add("Square, Princess")
                            Case Else
                                item.Add("Other|" + oextra.c_cut.Replace(" Cut", ""))
                        End Select

                        If oPlate._subplate._metal.indexof("Yellow") > -1 Then
                            item.Add("18k Yellow Gold")
                        ElseIf oPlate._subplate._metal.indexof("White") > -1 Then
                            item.Add("18k White Gold")
                        ElseIf oPlate._subplate._metal.indexof("Rose") > -1 Then
                            item.Add("Other|18k Rose Gold")
                        Else
                            item.Add("Platinum")
                        End If
                        item.Add("")

                        item.Add(carat_weight)
                        item.Add(carat_weight)
                        If oextra.c_type.Replace("Natural ", "") = "Diamonds" Then
                            item.Add("Diamond")
                        Else
                            item.Add(oextra.c_type.Replace("Natural ", "").Replace(" ( clarity Enhanced )", ""))
                        End If

                        If Me.chk_clarity.Checked Then
                            item.Add("Other|Enhanced Natural")
                        Else
                            item.Add("Natural")
                        End If


                        item.Add("Women's")

                        item.Add("")
                        item.Add("")
                        item.Add("")
                End Select
            End If
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
        Dim oWrite As System.IO.StreamWriter
        Dim filename As String = "/ebay" + Date.Now.Ticks.ToString + ".csv"
        Me.csvfile = filename
        oWrite = oFile.CreateText(Server.MapPath(filename))
        ''write the thing
        Select Case Me.cmb_site.SelectedValue

            Case "0"
                Select Case Me.e_cat.SelectedValue
                    Case "43348", "164314"
                        ''
                        oWrite.WriteLine("Action(CC=Cp1252),SiteID,Format,Title,SubTitle,Custom Label,Category,StoreCategory,StoreCategory2,Quantity,Description,Currency,StartPrice,InsuranceOption,Duration,PrivateAuction,Country,ItemID,Counter,PicURL,BoldTitle,Featured,GalleryType,FeaturedFirstDuration,Highlight,Border,HomePageFeatured,Subtitle in search resutls,GiftIcon,ApplyShippingDiscount,Location,NowandNew,ImmediatePayRequired,PayPalAccepted,PayPalEmailAddress,AmEx,Discover,VisaMastercard,PaymentSeeDescription,ShippingType,ShippingService-1:Option,ShippingService-1:Cost,ShippingService-1:Priority,ShippingService-1:FreeShipping,DispatchTimeMax,IntlShippingService-1:Option,IntlShippingService-1:Cost,IntlShippingService-1:Locations,IntlShippingService-1:Priority,IntlAddnlShiptoLocations,ValuePackBundle,BestOfferEnabled,AutoAccept,BestOfferAutoAcceptPrice,AutoDecline,MinBestOfferPrice,SkypeChat,SkypeVoice,SkypeName,SkypeOption,SkypeID,BuyerRequirements:MinFeedbackScore,BuyerRequirements:MaxUnpaidItemsCount,BuyerRequirements:LinkedPayPalAccount,ListingDesigner:LayoutID,ListingDesigner:ThemeID,ProStores Enabled,Domestic Profile Discount,International Profile Discount,Apply Profile Domestic,Apply Profile International,PromoteCBT,ShipToLocations,CustomLabel,NowandNew (Sofort and Neu),ReturnsAcceptedOption,ReturnsWithinOption,RefundOption,ShippingCostPaidBy,A:Style,A:Main Stone Color,A:Condition,A:Metal,A:Exact Carat Total Weight,A:Main Stone,A:Main Stone Treatment,A:Metal Purity,C:Material,C:Center Stone,C:Item number,C:Weight,C:Style,C:Setting")
                    Case "164320", "116136", "116127", "110590", "86023"
                        oWrite.WriteLine("Action(CC=Cp1252),SiteID,Format,Title,SubTitle,Custom Label,Category,StoreCategory,StoreCategory2,Quantity,Description,Currency,StartPrice,InsuranceOption,Duration,PrivateAuction,Country,ItemID,Counter,PicURL,BoldTitle,Featured,GalleryType,FeaturedFirstDuration,Highlight,Border,HomePageFeatured,Subtitle in search resutls,GiftIcon,ApplyShippingDiscount,Location,NowandNew,ImmediatePayRequired,PayPalAccepted,PayPalEmailAddress,AmEx,Discover,VisaMastercard,PaymentSeeDescription,ShippingType,ShippingService-1:Option,ShippingService-1:Cost,ShippingService-1:Priority,ShippingService-1:FreeShipping,DispatchTimeMax,IntlShippingService-1:Option,IntlShippingService-1:Cost,IntlShippingService-1:Locations,IntlShippingService-1:Priority,IntlAddnlShiptoLocations,ValuePackBundle,BestOfferEnabled,AutoAccept,BestOfferAutoAcceptPrice,AutoDecline,MinBestOfferPrice,SkypeChat,SkypeVoice,SkypeName,SkypeOption,SkypeID,BuyerRequirements:MinFeedbackScore,BuyerRequirements:MaxUnpaidItemsCount,BuyerRequirements:LinkedPayPalAccount,ListingDesigner:LayoutID,ListingDesigner:ThemeID,ProStores Enabled,Domestic Profile Discount,International Profile Discount,Apply Profile Domestic,Apply Profile International,PromoteCBT,ShipToLocations,CustomLabel,NowandNew (Sofort and Neu),ReturnsAcceptedOption,ReturnsWithinOption,RefundOption,ShippingCostPaidBy,A:Style,A:Main Stone Color,A:Condition,A:Metal,A:Exact Carat Total Weight,A:Main Stone,A:Main Stone Treatment,A:Metal Purity,C:Style,C:Main Stone,C:Metal,C:Center Stone")

                    Case Else
                        oWrite.WriteLine("Action(CC=Cp1252),SiteID,Format,Title,SubTitle,Custom Label,Category,StoreCategory,StoreCategory2,Quantity,Description,Currency,StartPrice,InsuranceOption,Duration,PrivateAuction,Country,ItemID,Counter,PicURL,BoldTitle,Featured,GalleryType,FeaturedFirstDuration,Highlight,Border,HomePageFeatured,Subtitle in search resutls,GiftIcon,ApplyShippingDiscount,Location,NowandNew,ImmediatePayRequired,PayPalAccepted,PayPalEmailAddress,AmEx,Discover,VisaMastercard,PaymentSeeDescription,ShippingType,ShippingService-1:Option,ShippingService-1:Cost,ShippingService-1:Priority,ShippingService-1:FreeShipping,DispatchTimeMax,IntlShippingService-1:Option,IntlShippingService-1:Cost,IntlShippingService-1:Locations,IntlShippingService-1:Priority,IntlAddnlShiptoLocations,ValuePackBundle,BestOfferEnabled,AutoAccept,BestOfferAutoAcceptPrice,AutoDecline,MinBestOfferPrice,SkypeChat,SkypeVoice,SkypeName,SkypeOption,SkypeID,BuyerRequirements:MinFeedbackScore,BuyerRequirements:MaxUnpaidItemsCount,BuyerRequirements:LinkedPayPalAccount,ListingDesigner:LayoutID,ListingDesigner:ThemeID,ProStores Enabled,Domestic Profile Discount,International Profile Discount,Apply Profile Domestic,Apply Profile International,PromoteCBT,ShipToLocations,CustomLabel,NowandNew (Sofort and Neu),ReturnsAcceptedOption,ReturnsWithinOption,RefundOption,ShippingCostPaidBy,A:Type,A:Style,A:Main Stone Color,A:Engagement Ring Style,A:Condition,A:Band Style,A:Stone Shape,A:Main Stone Shape,A:Metal,A:Ring Size,A:Clarity,A:Exact Carat Total Weight,A:Main Stone,A:Stone Origin & Treatment,A:Main Stone Treatment,A:Color,A:Gender,A:Certification/Grading,A:Main Stone Certification/Grading,A:Metal Purity,C:Metal,C:Center Stone")
                End Select


            Case "3"
                Select Case Me.e_cat_uk.SelectedValue
                    Case "10986", "11002", "67726"
                        oWrite.WriteLine("Action(CC=Cp1252),SiteID,Format,Title,SubTitle,Custom Label,Category,StoreCategory,StoreCategory2,Quantity,Description,Currency,StartPrice,InsuranceOption,Duration,PrivateAuction,Country,ItemID,Counter,PicURL,BoldTitle,Featured,GalleryType,FeaturedFirstDuration,Highlight,Border,HomePageFeatured,Subtitle in search resutls,GiftIcon,ApplyShippingDiscount,Location,NowandNew,ImmediatePayRequired,PayPalAccepted,PayPalEmailAddress,AmEx,Discover,VisaMastercard,PaymentSeeDescription,ShippingType,ShippingService-1:Option,ShippingService-1:Cost,ShippingService-1:Priority,ShippingService-1:FreeShipping,DispatchTimeMax,IntlShippingService-1:Option,IntlShippingService-1:Cost,IntlShippingService-1:Locations,IntlShippingService-1:Priority,IntlAddnlShiptoLocations,ValuePackBundle,BestOfferEnabled,AutoAccept,BestOfferAutoAcceptPrice,AutoDecline,MinBestOfferPrice,SkypeChat,SkypeVoice,SkypeName,SkypeOption,SkypeID,BuyerRequirements:MinFeedbackScore,BuyerRequirements:MaxUnpaidItemsCount,BuyerRequirements:LinkedPayPalAccount,ListingDesigner:LayoutID,ListingDesigner:ThemeID,ProStores Enabled,Domestic Profile Discount,International Profile Discount,Apply Profile Domestic,Apply Profile International,PromoteCBT,ShipToLocations,CustomLabel,NowandNew (Sofort and Neu),ReturnsAcceptedOption,ReturnsWithinOption,RefundOption,ShippingCostPaidBy,A:Type,A:Designer,A:Sub-Type,A:Condition,A:Gemstone Shape/ Cut,A:Cut,A:Metal,A:Ring Size,A:Gemstone Carat Weight,A:Carat (gemstone),A:Gemstone,A:Natural/Lab Created,A:Gender,A:Main Gemstone,A:Gold Quality")
                End Select
        End Select

        For Each item As ArrayList In t_csv
            oWrite.WriteLine(Join(item.ToArray, ","))
        Next

        oWrite.Close()
    End Function

    Function SaveCSV_AU()
        Dim txt As TextBox = Me.pnl_table.Controls(0).FindControl("e_category")


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
            hash("siteid") = "3"
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
            If Me.usertype = 2 Then
                omail.getHTML_byURL("http://www.twin-diamonds.com/ebay/verynewswhow2.aspx" + qs, body)
            Else
                omail.getHTML_byURL("http://www.twin-diamonds.com/ebay/verynewswhow.aspx" + qs, body)
            End If






            Dim item As New ArrayList

            item.Add("Add")

            Select Case Me.cmb_site.SelectedValue
                Case "0"
                    item.Add("US")
                Case "3"
                    item.Add("UK")
                Case "15"
                    item.Add("Australia")
                Case "71"
                    item.Add("FR")
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

            item.Add(Me.e_cat_au.SelectedValue)





            Dim d_storecat As TextBox = Me.pnl_table.Controls(2 * i).FindControl("e_store_category")

            If Me.usertype = 2 Then
                item.Add(Me.e_store_main_cat2.SelectedValue)
            Else
                item.Add(Me.e_store_main_cat.SelectedValue)
            End If
            Dim d_storecat2 As TextBox = Me.pnl_table.Controls(2 * i).FindControl("e_store_category2")

            If Me.usertype = 2 Then
                item.Add(Me.e_store_second_cat2.SelectedValue)
            Else
                item.Add(Me.e_store_second_cat.SelectedValue)
            End If




            item.Add("1")



            body = body.Replace(vbNewLine, " ")
            'body = body.Replace(vbCrLf, " ")
            'body = body.Replace(vbLf, " ")
            'body = body.Replace(vbCr, " ")
            'body = body.Replace(Chr(13), " ")
            'body = body.Replace(Chr(10), " ")


            body = body.Replace(Chr(34), "'")

            ''  '' body = "test"
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

            Dim newprice As Decimal = Convert.ToDecimal(d_price.Text) * Convert.ToDecimal(Me.e_currency.Text)
            d_price.Text = newprice.ToString
            newprice = Math.Round(newprice)

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

















            item.Add("ShippingMethodStandard")

            item.Add("0")


            item.Add("1")
            item.Add("1")



            'item.Add("0")
            'item.Add("0")
            'item.Add("0")

























            item.Add("10")
            item.Add("StandardInternational")

            item.Add("0")


            item.Add("Worldwide")

            item.Add("1")






















            item.Add("Worldwide")







            item.Add("0")

            item.Add("1")
            item.Add("1")
            item.Add(Math.Round((newprice * 0.95), 3))



            item.Add("1")

            item.Add(Math.Round((oPlate._purchase_price * 1.1 / 100)) * 100)





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



            Dim oextra As New ion_two.cls_jewerly_extra
            oextra.get_stone_extended_string(oPlate._subplate._stone_extended)
            Select Case Me.e_cat_au.SelectedValue
                Case "67681"


                    item.Add("Ring")
                    item.Add("Other|" + oPlate._subplate._brand)
                    item.Add("Other|" + oPlate._subplate._metal)
                    item.Add("Returns Accepted|Returns Accepted")

                    item.Add("30 Days|30 Days")

                    item.Add("Money Back|Money Back")
                    item.Add("New")
                    ''  item.Add(oextra.c_cut.Replace(" Cut", "") + "|" + oextra.c_cut.Replace(" Cut", ""))
                    item.Add("Gold")

                    ''    item.Add("Gold-White")

                    item.Add("Women's")

                Case "164340"
                    item.Add("")
                    item.Add("")
                    item.Add("")
                    item.Add("Returns Accepted|Returns Accepted")

                    item.Add("30 Days|30 Days")

                    item.Add("Money Back|Money Back")
                    item.Add("New")
                    ''  item.Add(oextra.c_cut.Replace(" Cut", "") + "|" + oextra.c_cut.Replace(" Cut", ""))
                    item.Add("")

                    ''    item.Add("Gold-White")

                    item.Add("")


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
        Dim oWrite As System.IO.StreamWriter
        Dim filename As String = "/ebay" + Date.Now.Ticks.ToString + "-AU.csv"
        Me.csvfile = filename
        oWrite = oFile.CreateText(Server.MapPath(filename))
        ''write the thing
        oWrite.WriteLine("Action(CC=Cp1252),SiteID,Format,Title,SubTitle,Custom Label,Category,StoreCategory,StoreCategory2,Quantity,Description,Currency,StartPrice,InsuranceOption,Duration,PrivateAuction,Country,ItemID,Counter,PicURL,BoldTitle,Featured,GalleryType,FeaturedFirstDuration,Highlight,Border,HomePageFeatured,Subtitle in search resutls,GiftIcon,ApplyShippingDiscount,Location,NowandNew,ImmediatePayRequired,PayPalAccepted,PayPalEmailAddress,AmEx,Discover,VisaMastercard,PaymentSeeDescription,ShippingType,ShippingService-1:Option,ShippingService-1:Cost,ShippingService-1:Priority,ShippingService-1:FreeShipping,DispatchTimeMax,IntlShippingService-1:Option,IntlShippingService-1:Cost,IntlShippingService-1:Locations,IntlShippingService-1:Priority,IntlAddnlShiptoLocations,ValuePackBundle,BestOfferEnabled,AutoAccept,BestOfferAutoAcceptPrice,AutoDecline,MinBestOfferPrice,SkypeChat,SkypeVoice,SkypeName,SkypeOption,SkypeID,BuyerRequirements:MinFeedbackScore,BuyerRequirements:MaxUnpaidItemsCount,BuyerRequirements:LinkedPayPalAccount,ListingDesigner:LayoutID,ListingDesigner:ThemeID,ProStores Enabled,Domestic Profile Discount,International Profile Discount,Apply Profile Domestic,Apply Profile International,PromoteCBT,ShipToLocations,CustomLabel,NowandNew (Sofort and Neu),ReturnsAcceptedOption,ReturnsWithinOption,RefundOption,ShippingCostPaidBy,A:Product Type,A:Brand,A:Size,A:Material,A:Returns Accepted,A:Item must be returned within,A:Refund will be given as,A:Return policy details,A:Condition,A:Colour,A:Gender")
        For Each item As ArrayList In t_csv
            oWrite.WriteLine(Join(item.ToArray, ","))
        Next

        oWrite.Close()
    End Function
    Function SaveCSV_FR()
        Dim txt As TextBox = Me.pnl_table.Controls(0).FindControl("e_category")



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
            If Me.usertype = 2 Then
                omail.getHTML_byURL("http://www.twin-diamonds.com/ebay/verynewswhow_fr2.aspx" + qs, body)
            Else
                omail.getHTML_byURL("http://www.twin-diamonds.com/ebay/verynewswhow_fr.aspx" + qs, body)
            End If






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

            item.Add(Me.e_cat_fr.SelectedValue)





            Dim d_storecat As TextBox = Me.pnl_table.Controls(2 * i).FindControl("e_store_category")

            If Me.usertype = 2 Then
                item.Add(Me.e_store_main_cat2.SelectedValue)
            Else
                item.Add(Me.e_store_main_cat.SelectedValue)
            End If
            Dim d_storecat2 As TextBox = Me.pnl_table.Controls(2 * i).FindControl("e_store_category2")

            If Me.usertype = 2 Then
                item.Add(Me.e_store_second_cat2.SelectedValue)
            Else
                item.Add(Me.e_store_second_cat.SelectedValue)
            End If




            item.Add("1")



            body = body.Replace(vbNewLine, " ")
            'body = body.Replace(vbCrLf, " ")
            'body = body.Replace(vbLf, " ")
            'body = body.Replace(vbCr, " ")
            'body = body.Replace(Chr(13), " ")
            'body = body.Replace(Chr(10), " ")


            body = body.Replace(Chr(34), "'")

            ''  '' body = "test"
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




            Dim newprice As Decimal = Convert.ToDecimal(d_price.Text) * Convert.ToDecimal(Me.e_currency.Text)
            newprice = Math.Round(newprice)

            d_price.Text = newprice.ToString


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

            item.Add(Math.Round((newprice * 0.95)))



            item.Add("1")

            item.Add(Math.Round((newprice * 0.88 / 100)) * 100)





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
            Select Case Me.e_cat_fr.SelectedValue
                Case "115843"
                    item.Add("Neuf")
                    item.Add("Fantaisie")

                    Select Case oPlate._subplate._jewelrysubtype
                        Case "Solitaire"
                            If oextra.s_desc = "" Then
                                item.Add("Bague simple")
                            Else
                                item.Add("Bague simple")
                            End If

                        Case "Three Stone"
                            item.Add("Anneau simple")
                        Case Else

                            item.Add("Alliance")
                    End Select





                    ''    item.Add("Gold-White")
                    'If oPlate._subplate._metal.indexof("Yellow") > -1 Then
                    '    item.Add("Or jaune")
                    'ElseIf oPlate._subplate._metal.indexof("White") > -1 Then
                    '    item.Add("Or blanc")
                    'ElseIf oPlate._subplate._metal.indexof("Rose") > -1 Then
                    '    item.Add("Or rose")
                    'Else
                    '    item.Add("Platine")
                    'End If
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

        Dim filename As String = "/ebay" + Date.Now.Ticks.ToString + "-FR.csv"

        Me.csvfile = filename

        Dim oWrite As New System.IO.StreamWriter(Server.MapPath(filename), True, System.Text.Encoding.ASCII)



        '' oWrite = oFile.CreateText(Server.MapPath(filename))
        ''write the thing
        '',A:Matériau

        oWrite.WriteLine("Action(CC=Cp1252),SiteID,Format,Title,SubTitle,Custom Label,Category,StoreCategory,StoreCategory2,Quantity,Description,Currency,StartPrice,InsuranceOption,Duration,PrivateAuction,Country,ItemID,Counter,PicURL,BoldTitle,Featured,GalleryType,FeaturedFirstDuration,Highlight,Border,HomePageFeatured,Subtitle in search resutls,GiftIcon,ApplyShippingDiscount,Location,NowandNew,ImmediatePayRequired,PayPalAccepted,PayPalEmailAddress,AmEx,Discover,VisaMastercard,PaymentSeeDescription,ShippingType,ShippingService-1:Option,ShippingService-1:Cost,ShippingService-1:Priority,ShippingService-1:FreeShipping,DispatchTimeMax,IntlShippingService-1:Option,IntlShippingService-1:Cost,IntlShippingService-1:Locations,IntlShippingService-1:Priority,IntlAddnlShiptoLocations,ValuePackBundle,BestOfferEnabled,AutoAccept,BestOfferAutoAcceptPrice,AutoDecline,MinBestOfferPrice,SkypeChat,SkypeVoice,SkypeName,SkypeOption,SkypeID,BuyerRequirements:MinFeedbackScore,BuyerRequirements:MaxUnpaidItemsCount,BuyerRequirements:LinkedPayPalAccount,ListingDesigner:LayoutID,ListingDesigner:ThemeID,ProStores Enabled,Domestic Profile Discount,International Profile Discount,Apply Profile Domestic,Apply Profile International,PromoteCBT,ShipToLocations,CustomLabel,NowandNew (Sofort and Neu),ReturnsAcceptedOption,ReturnsWithinOption,RefundOption,ShippingCostPaidBy,A:J'accepte le renvoi des objets,A:L'objet doit être renvoyé dans un délai de:,A:Etat,A:Genre,A:Type,A:Pierre dominante,A:Sexe,A:Carat or")
        For Each item As ArrayList In t_csv
            oWrite.WriteLine(Join(item.ToArray, ","))
        Next

        oWrite.Close()
    End Function
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Response.Redirect("/ebay/ebaycsv.aspx")
    End Sub

    Private Sub cmb_site_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmb_site.SelectedIndexChanged
        If Me.chk_useconvertor.Checked Then
            Dim conv_rate As Double
            Dim oconv As New net.webservicex.www.CurrencyConvertor

            Select Case Me.cmb_site.SelectedValue
                Case 0
                    conv_rate = 1
                    Me.e_currency.Text = conv_rate.ToString

                Case 3
                    conv_rate = oconv.ConversionRate(net.webservicex.www.Currency.USD, net.webservicex.www.Currency.GBP)
                    Me.e_currency.Text = conv_rate.ToString


                Case 15
                    conv_rate = oconv.ConversionRate(net.webservicex.www.Currency.USD, net.webservicex.www.Currency.AUD)
                    Me.e_currency.Text = conv_rate.ToString

                Case 71, 101
                    conv_rate = oconv.ConversionRate(net.webservicex.www.Currency.USD, net.webservicex.www.Currency.EUR)
                    Me.e_currency.Text = conv_rate.ToString

            End Select

        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.usertype = 2
        Select Case Me.cmb_site.SelectedValue
            Case "0"
                Me.SaveCSV()
                '  item.Add("US")
            Case "3"
                Me.SaveCSV()
                ' item.Add("UK")
            Case "15"
                Me.SaveCSV_AU()
                '  item.Add("AU")
            Case "71"
                Me.SaveCSV_FR()
                '  item.Add("FR")
            Case Else
                Me.SaveCSV()

        End Select


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
End Class
