Imports eBay.Service.Core.Soap
Imports eBay.Service.Core.Sdk
Imports eBay.Service.Call
Imports eBay.Service.Util
Imports System.Xml
Imports System.Text.RegularExpressions
Partial Class syncitems
    Inherits System.Web.UI.Page
    Dim oapicontext As New ApiContext

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

        oapicontext.ApiCredential.eBayAccount.Password = "simba4884"
        oapicontext.ApiCredential.eBayAccount.UserName = "aviby"
        oapicontext.ApiCredential.eBayToken = "AgAAAA**AQAAAA**aAAAAA**+2K5Rw**nY+sHZ2PrBmdj6wVnY+sEZ2PrA2dj6wJnY+pD5KDogmdj6x9nY+seQ**OloAAA**AAMAAA**dOC3IXc6+5ADdQn3UVhH+Kbnnj5GKAn1nhcGTk9f09Opk0fVChorEg308ok8dIqDHub+BGZG1zLpLy0uTuRD2bLgW76dAiVWh3OD8Gy/Insfetbp0nvKERM5tkufWBQRHPpdL6GfB4zwY62Q3wOhaqMIkP906CpKJK6eESdZmRelGdbS5M7HgdwgePAiJsrPHlIPu3ZfcBQRLo81hHc/X36G2fAfHyPABk27KVyq7j7lGDSKVX2cHuEYgIj1KC/nkFuur8jGd6yGkH4RU3A3baFC5bTO3SAHTM/q0kmIYnHCTLYEQYKibUO0aDNQ/2BEq7AXUgPSpP1TS56+QAUmag76IPzpwFhm4FhVrCklo5fmNl2c5C/iTtRibyUT6+1bFHKbY2mYbOlZIKc+2Tn1fX//3cRc0vcGHb5eBpbfSt/hf8KF/KMZ4MAnjjnNrmpLAeNMJhk67FPWlmt6KHuUCN5LDqOG/hnaWGx/nouNaEXDW48uXwoxDHzCe77fgb6+KurpnBSusfmLU0DgHV5HbLAXG4e06xt2NRCLoN0HSW06XCBpBvkNK3KW8ASTes5U8obz+lEbDqjQs7RmKvrxQnhD6zfJdfF937VZ643+VhkxymQqDnw6XMj8JpIdgEkNoYdhK8Q0ukrmLkrwMN0H+RhdWFfKzgBdghSIuMrZ5Ik5IGzwEHUq2ttG7ddZ617d0ran9MVnUd6RFBPcru82b3EIoQcsjIs5dCHiLYzfqL/AFyqgGccsWzutREh7yA/U"

        oapicontext.SoapApiServerUrl = "https://api.ebay.com/wsapi"
        oapicontext.EPSServerUrl = "http://msa-b1.ebay.com/ws/eBayISAPI.dll?EpsBasicApp"



        Dim apicall As GetSellerListCall = New GetSellerListCall(oapicontext)

        apicall.DetailLevelList.Add(DetailLevelCodeType.ReturnAll)


        'Pagination is required
        apicall.StartTimeTo = Now.Today
        apicall.StartTimeFrom = Now.AddDays(-60)

        apicall.Pagination = New PaginationType

        apicall.Pagination.PageNumber = 1

        apicall.Pagination.EntriesPerPage = 200
        Dim list As New ItemTypeCollection
        list = apicall.GetSellerList()

        For Each item As ItemType In list
            If item.ListingDetails.EndTime >= Now.Today Then

                Me.ListBox1.Items.Add(item.ItemID.ToString + "----" + item.ListingDetails.EndTime.ToString)
            End If
        Next

    End Sub

End Class
