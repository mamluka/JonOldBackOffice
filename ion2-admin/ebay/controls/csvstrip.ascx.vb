Imports System.Text.RegularExpressions
Partial Class csvstrip
    Inherits System.Web.UI.UserControl

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

    End Sub

    Function LoadItem(ByVal itemnumber As String, ByVal siteid As Int32, ByVal convrate As Decimal, ByVal desc As String, ByVal clarity As Boolean, ByVal cat As String, ByVal storecat As String, ByVal storecat2 As String, ByVal story As String, ByVal convertrate As Decimal, ByVal movie As String, ByVal usertype As Int32, ByVal subtitle As String)
        Dim bError As Boolean = False


        Dim onumber As New ion_two.cls_itemnumber
        onumber._connection_string = Application("config").connection_string
        onumber._dbtype = Application("config").connection_string_type
        Dim itemid As Int32
        onumber.getid_fromnumber(itemnumber, itemid, bError)


        Dim oTmpInventory As New ion_two.cls_inventory_lgc
        oTmpInventory._connection_string = Application("config").connection_string
        oTmpInventory._dbtype = Application("config").connection_string_type

        Dim oPlate As New ion_two.skl_lst_inventory
        Dim opicture As New ion_two.cls_pictures
        opicture.load("http://www.twin-diamonds.com", "https://www.twin-diamonds.com")

        oTmpInventory.load(itemid, oPlate, opicture)


        ''   Dim oconv As New net.webservicex.www.CurrencyConvertor
        Dim conv_rate As Double = convertrate
        'Select Case siteid
        '    Case 0
        '        conv_rate = 1
        '        Me.e_currency.Text = "us$"

        '    Case 3
        '        ''  conv_rate = oconv.ConversionRate(net.webservicex.www.Currency.USD, net.webservicex.www.Currency.GBP)
        '        Me.e_currency.Text = "GBP"


        '    Case 15
        '        ''    conv_rate = oconv.ConversionRate(net.webservicex.www.Currency.USD, net.webservicex.www.Currency.AUD)
        '        Me.e_currency.Text = "au$"

        '    Case 71, 101
        '        ''   conv_rate = oconv.ConversionRate(net.webservicex.www.Currency.USD, net.webservicex.www.Currency.EUR)
        '        Me.e_currency.Text = "EUR"

        'End Select

        Me.e_currency.Text = "us$"
        Me.e_price.Text = Math.Round((oPlate._sell_price * conv_rate)).ToString
        Me.itemnumber.Text = itemnumber
        Me.e_subtitle.Text = subtitle
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
        If movie <> "" Then
            hash("movie") = movie
        End If
        hash("shipping") = 1
        hash("backoffice") = "1"
        Select Case siteid
            Case "0"
                hash("siteid") = "1"
            Case "15"
                hash("siteid") = "3"
            Case "71"
                hash("siteid") = "6"
            Case Else
                hash("siteid") = "1"
        End Select

        hash("apramount") = oPlate._appraisal_price.ToString
        If clarity Then
            hash("clarity") = "1"
        End If

        If desc <> "" Then
            hash("desc") = ostringfunc.EncodeProblematicChars(desc)
        End If
        Dim qs As String = ostringfunc.EncodeQuaryString(hash)

        Dim body As String
        Dim omail As New ion_two.cls_mod_mail
        omail.getHTML_byURL("http://www.twin-diamonds.com/ebay/verynewswhow.aspx" + qs, body)
        Select Case siteid
            Case "71"
                Me.link_preview.NavigateUrl = "http://www.twin-diamonds.com/ebay/verynewswhow_fr.aspx" + qs
                Me.link_preview2.NavigateUrl = "http://www.twin-diamonds.com/ebay/verynewswhow_fr2.aspx" + qs
            Case Else
                Me.link_preview.NavigateUrl = "http://www.twin-diamonds.com/ebay/verynewswhow.aspx" + qs
                Me.link_preview2.NavigateUrl = "http://www.twin-diamonds.com/ebay/verynewswhow2.aspx" + qs
        End Select

        Me.link_edit.NavigateUrl = "/inventory/edititem.aspx?mode=2&id=" + oPlate._id.ToString
        ''Me.e_onsite.NavigateUrl = "http://www.twin-diamonds.com/catalog/myitem.aspx?id=" + ID.ToString

        ''  Me.e_html.Text = body


        ''  Me.e_specs.Text = Regex.Match(body, "<!--specs-->.+?<!--specs-->", RegexOptions.Singleline).Value

        ''   If Not Page.IsPostBack Then

        If oPlate.opthash("ebaytitle") = "" Then

            Me.e_title.Text = Trim(Regex.Match(body, "<!--titlestart-->(.+?)<!--titleend-->", RegexOptions.Singleline).Groups(1).Value)
            ' Me.e_subtitle.Text = Trim(Regex.Match(body, "<!--titlestart-->(.+?)<!--titleend-->", RegexOptions.Singleline).Groups(1).Value)
            Me.e_title.Text = ostringfunc.ClearHTMLTagsReturn(Me.e_title.Text.Replace("<br>", " ").Replace("<BR>", " "))
            ' Me.e_subtitle.Text = ostringfunc.ClearHTMLTagsReturn(Me.e_subtitle.Text.Replace("<br>", " ").Replace("<BR>", " "))
        Else
            Me.e_title.Text = oPlate.opthash("ebaytitle")
            '  Me.e_subtitle.Text = oPlate.opthash("ebaytitle")

        End If
        'If Me.e_title.Text.Length > 55 Then
        '    Me.e_title.Text = Mid(Me.e_title.Text, 1, 52) + "..."
        'End If
        Me.e_category.Text = cat
        Me.e_store_category.Text = storecat
        Me.e_store_category2.Text = storecat2
        Me.e_story.Text = story
        '' Me.itemnumber.Text = body
    End Function


End Class
