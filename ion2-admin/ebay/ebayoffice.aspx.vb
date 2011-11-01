Imports eBay.Service.Core.Soap
Imports eBay.Service.Core.Sdk
Imports eBay.Service.Call
Imports eBay.Service.Util
Imports System.Xml
Imports System.Text.RegularExpressions
Partial Class ebayoffice
    Inherits System.Web.UI.Page
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

        oapicontext.ApiCredential.eBayAccount.Password = "37733773"
        oapicontext.ApiCredential.eBayAccount.UserName = "avigem"

        oapicontext.ApiCredential.eBayToken = "AgAAAA**AQAAAA**aAAAAA**b+lOSw**nY+sHZ2PrBmdj6wVnY+sEZ2PrA2dj6wJnYahDJCDogWdj6x9nY+seQ**OloAAA**AAMAAA**WmFQzdoX0A4gkFg3iYKyYjFlh3XiO1RFLT5wNqKtHdHkzWeF3pqDbCGLUdb9/FsH9yXGXCmxI5DvWYXOpKRs77KKIG3GaCOmz4Ii62XECIMJvh0aJFvg/LpKt4VFa/zfuNc3FS82SX0dlLmIw7nWyGOlvq/ZKChpPHvLVrrFZ++yfJIJVcKg6qbp08DO1bgsp8eWvsOufVTGDI+GkKy3bcQLfc/7Hm3yG+dnM4T5DRQIVZ/B498VJuVpO3xZEcNOLZVelzgtjDWUAfOxfM8qwd4d3cgVI8g3X6wHZeIDMNFMqewVN5m4hY4twTo82q3uYJmnGUXj1CkCA5mkznNRRPzz8tffVmcVwl/yUdtCCEU/KCR+bq3aK+PpBnIo5EiGIAtq606smCNve+53uDlL3WeF9AdtvETbYD+SxxBiaGRLEjnF3IwatsJ511trGQBJB2OBlDRj/2q7MnRP4x08HYYt38Z5BtrE4LpDqngITPP/+rW/2AFpuzAmQNYJ4HxK3sxl0OQ31u5gp5N9oP2bZOLJ/C9L7d0HvyLzNotp/KgDtsvy4NJDdAa7zdb9lz8dhEVoblZusx0o/aSOMGC/dngH+0rYhyPGC1w0fHUKPOsdEoB7/OGb0mM6z0PlO7v5dUE8ZIoyN/UZk5OW6nP4tX98mcCCzxwodKUW56zZ7v/5IQfvTbIIMPfDRGMtYJEmEnaoKt5Eufj+NY8RoLrWphtxoGooj81FspJmOcoMq+IdIFnN0NOM73RUtQhvHMTU"
        oapicontext.SoapApiServerUrl = "https://api.ebay.com/wsapi"
        oapicontext.EPSServerUrl = "http://msa-b1.ebay.com/ws/eBayISAPI.dll?EpsBasicApp"
    End Sub

    Private Sub e_updateinv_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles e_updateinv.Click
        Dim oselleritems As New GetSellerListCall(Me.oapicontext)
        oselleritems.DetailLevelList.Add(DetailLevelCodeType.ReturnAll)
        oselleritems.Pagination = New PaginationType
        oselleritems.Pagination.EntriesPerPage = 50
        oselleritems.StartTimeFrom = Now.AddMonths(-2)
        oselleritems.StartTimeTo = Now.AddMonths(1)
        oselleritems.EndTimeTo = Now.AddMonths(1)
        oselleritems.EndTimeFrom = Now

        ''oselleritems.GetSellerList()
        Dim osql As New iDac.cls_T_command
        osql._dbtype = Application("config").connection_string_type
        osql._connection_string = Application("config").connection_string

        Dim skuarray As New ArrayList
        Dim page As Int16 = 1
        Dim hasmoreitems As Boolean = True

        ''  If itemlist.Count > 0 Then
        osql._sqlstring = "update inv_inventory set EBAYID='', ONEBAY=0"
        osql.transact_command()

        ''  End If
        Do Until Not hasmoreitems
            oselleritems.Pagination.PageNumber = page
            Dim itemlist As ItemTypeCollection = oselleritems.GetSellerList()
            ''reset


            For Each item As ItemType In itemlist

                If item.SKU <> "" Then
                    osql._sqlstring = "update inv_inventory set EBAYID='" + item.ItemID + "', ONEBAY=1 where itemnumber='" + item.SKU + "'"
                    osql.transact_command()
                End If

            Next
            hasmoreitems = oselleritems.HasMoreItems
            page += 1

        Loop

        Me.DropDownList1.Items.Add(skuarray.Count.ToString)


    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Response.Redirect("/ebay/ebaycsv.aspx")
    End Sub
End Class
