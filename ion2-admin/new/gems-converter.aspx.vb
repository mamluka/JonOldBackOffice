Imports eBay.Service.Core.Soap
Imports eBay.Service.Core.Sdk
Imports eBay.Service.Call
Imports eBay.Service.Util
Imports System.Xml
Imports System.Data.SqlClient
Imports System.IO
Imports System.Text.RegularExpressions
Partial Class gems_converter
    Inherits System.Web.UI.Page
    Public oapicontext As New ApiContext
    Public oapicontext2 As New ApiContext
    Public aviby_cats As New ArrayList

    Public gems_cats As New ArrayList


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
        oapicontext.ApiCredential.ApiAccount.Application = "Twin-Dia-3f18-4f05-b81a-4ce4ba64f7a4"
        oapicontext.ApiCredential.ApiAccount.Certificate = "caad245f-7914-4ece-8ada-7a1edfb4453c"
        oapicontext.ApiCredential.ApiAccount.Developer = "57244916-441d-48cc-a2f4-7d3ea3b68472"

        oapicontext.ApiCredential.eBayAccount.Password = "lianne3773"
        oapicontext.ApiCredential.eBayAccount.UserName = "aviby"
        oapicontext.ApiCredential.eBayToken = "AgAAAA**AQAAAA**aAAAAA**+2K5Rw**nY+sHZ2PrBmdj6wVnY+sEZ2PrA2dj6wJnY+pD5KDogmdj6x9nY+seQ**OloAAA**AAMAAA**dOC3IXc6+5ADdQn3UVhH+Kbnnj5GKAn1nhcGTk9f09Opk0fVChorEg308ok8dIqDHub+BGZG1zLpLy0uTuRD2bLgW76dAiVWh3OD8Gy/Insfetbp0nvKERM5tkufWBQRHPpdL6GfB4zwY62Q3wOhaqMIkP906CpKJK6eESdZmRelGdbS5M7HgdwgePAiJsrPHlIPu3ZfcBQRLo81hHc/X36G2fAfHyPABk27KVyq7j7lGDSKVX2cHuEYgIj1KC/nkFuur8jGd6yGkH4RU3A3baFC5bTO3SAHTM/q0kmIYnHCTLYEQYKibUO0aDNQ/2BEq7AXUgPSpP1TS56+QAUmag76IPzpwFhm4FhVrCklo5fmNl2c5C/iTtRibyUT6+1bFHKbY2mYbOlZIKc+2Tn1fX//3cRc0vcGHb5eBpbfSt/hf8KF/KMZ4MAnjjnNrmpLAeNMJhk67FPWlmt6KHuUCN5LDqOG/hnaWGx/nouNaEXDW48uXwoxDHzCe77fgb6+KurpnBSusfmLU0DgHV5HbLAXG4e06xt2NRCLoN0HSW06XCBpBvkNK3KW8ASTes5U8obz+lEbDqjQs7RmKvrxQnhD6zfJdfF937VZ643+VhkxymQqDnw6XMj8JpIdgEkNoYdhK8Q0ukrmLkrwMN0H+RhdWFfKzgBdghSIuMrZ5Ik5IGzwEHUq2ttG7ddZ617d0ran9MVnUd6RFBPcru82b3EIoQcsjIs5dCHiLYzfqL/AFyqgGccsWzutREh7yA/U"

        oapicontext.SoapApiServerUrl = "https://api.ebay.com/wsapi"
        oapicontext.EPSServerUrl = "http://msa-b1.ebay.com/ws/eBayISAPI.dll?EpsBasicApp"

        oapicontext2.ApiCredential.ApiAccount.Application = "Twin-Dia-3f18-4f05-b81a-4ce4ba64f7a4"
        oapicontext2.ApiCredential.ApiAccount.Certificate = "caad245f-7914-4ece-8ada-7a1edfb4453c"
        oapicontext2.ApiCredential.ApiAccount.Developer = "57244916-441d-48cc-a2f4-7d3ea3b68472"

        oapicontext2.ApiCredential.eBayAccount.Password = "37733773"
        oapicontext2.ApiCredential.eBayAccount.UserName = "avigem"
        oapicontext2.ApiCredential.eBayToken = "AgAAAA**AQAAAA**aAAAAA**+2K5Rw**nY+sHZ2PrBmdj6wVnY+sEZ2PrA2dj6wJnY+pD5KDogmdj6x9nY+seQ**OloAAA**AAMAAA**dOC3IXc6+5ADdQn3UVhH+Kbnnj5GKAn1nhcGTk9f09Opk0fVChorEg308ok8dIqDHub+BGZG1zLpLy0uTuRD2bLgW76dAiVWh3OD8Gy/Insfetbp0nvKERM5tkufWBQRHPpdL6GfB4zwY62Q3wOhaqMIkP906CpKJK6eESdZmRelGdbS5M7HgdwgePAiJsrPHlIPu3ZfcBQRLo81hHc/X36G2fAfHyPABk27KVyq7j7lGDSKVX2cHuEYgIj1KC/nkFuur8jGd6yGkH4RU3A3baFC5bTO3SAHTM/q0kmIYnHCTLYEQYKibUO0aDNQ/2BEq7AXUgPSpP1TS56+QAUmag76IPzpwFhm4FhVrCklo5fmNl2c5C/iTtRibyUT6+1bFHKbY2mYbOlZIKc+2Tn1fX//3cRc0vcGHb5eBpbfSt/hf8KF/KMZ4MAnjjnNrmpLAeNMJhk67FPWlmt6KHuUCN5LDqOG/hnaWGx/nouNaEXDW48uXwoxDHzCe77fgb6+KurpnBSusfmLU0DgHV5HbLAXG4e06xt2NRCLoN0HSW06XCBpBvkNK3KW8ASTes5U8obz+lEbDqjQs7RmKvrxQnhD6zfJdfF937VZ643+VhkxymQqDnw6XMj8JpIdgEkNoYdhK8Q0ukrmLkrwMN0H+RhdWFfKzgBdghSIuMrZ5Ik5IGzwEHUq2ttG7ddZ617d0ran9MVnUd6RFBPcru82b3EIoQcsjIs5dCHiLYzfqL/AFyqgGccsWzutREh7yA/U"

        oapicontext2.SoapApiServerUrl = "https://api.ebay.com/wsapi"
        oapicontext2.EPSServerUrl = "http://msa-b1.ebay.com/ws/eBayISAPI.dll?EpsBasicApp"

        'Dim aviby_cats As New ArrayList
        'Dim me.gems_cats As New ArrayList



        Dim ogetstore As New GetStoreCall(oapicontext)
        ogetstore.DetailLevelList.Add(DetailLevelCodeType.ReturnAll)
        ogetstore.CategoryStructureOnly = True

        ogetstore.LevelLimit = 3


        Dim ostore As StoreType = ogetstore.GetStore()
        Dim i As Int32
        For i = 0 To ostore.CustomCategories.Count - 1
            If ostore.CustomCategories(i).ChildCategory.Count > 0 Then
                Me.aviby_cats.Add(New WebControls.ListItem(ostore.CustomCategories(i).Name(), ostore.CustomCategories(i).CategoryID))
                Me.aviby_cats.Add(New WebControls.ListItem(ostore.CustomCategories(i).Name(), ostore.CustomCategories(i).CategoryID))
                Dim j As Int32

                For j = 0 To ostore.CustomCategories(i).ChildCategory.Count - 1
                    Me.aviby_cats.Add(New WebControls.ListItem(ostore.CustomCategories(i).ChildCategory(j).Name, ostore.CustomCategories(i).ChildCategory(j).CategoryID))
                    Me.aviby_cats.Add(New WebControls.ListItem(ostore.CustomCategories(i).ChildCategory(j).Name, ostore.CustomCategories(i).ChildCategory(j).CategoryID))
                    Dim k As Int32
                    If ostore.CustomCategories(i).ChildCategory(j).ChildCategory.Count > 0 Then
                        For k = 0 To ostore.CustomCategories(i).ChildCategory(j).ChildCategory.Count - 1
                            Me.aviby_cats.Add(New WebControls.ListItem(ostore.CustomCategories(i).ChildCategory(j).ChildCategory(k).Name, ostore.CustomCategories(i).ChildCategory(j).ChildCategory(k).CategoryID))
                            Me.aviby_cats.Add(New WebControls.ListItem(ostore.CustomCategories(i).ChildCategory(j).ChildCategory(k).Name, ostore.CustomCategories(i).ChildCategory(j).ChildCategory(k).CategoryID))
                        Next
                    End If

                Next
            Else
                Me.aviby_cats.Add(New WebControls.ListItem(ostore.CustomCategories(i).Name(), ostore.CustomCategories(i).CategoryID))
                Me.aviby_cats.Add(New WebControls.ListItem(ostore.CustomCategories(i).Name(), ostore.CustomCategories(i).CategoryID))
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
                Me.gems_cats.Add(New WebControls.ListItem(ostore.CustomCategories(i).Name(), ostore.CustomCategories(i).CategoryID))
                Me.gems_cats.Add(New WebControls.ListItem(ostore.CustomCategories(i).Name(), ostore.CustomCategories(i).CategoryID))
                Dim j As Int32

                For j = 0 To ostore.CustomCategories(i).ChildCategory.Count - 1
                    Me.gems_cats.Add(New WebControls.ListItem(ostore.CustomCategories(i).ChildCategory(j).Name, ostore.CustomCategories(i).ChildCategory(j).CategoryID))
                    Me.gems_cats.Add(New WebControls.ListItem(ostore.CustomCategories(i).ChildCategory(j).Name, ostore.CustomCategories(i).ChildCategory(j).CategoryID))
                    Dim k As Int32
                    If ostore.CustomCategories(i).ChildCategory(j).ChildCategory.Count > 0 Then
                        For k = 0 To ostore.CustomCategories(i).ChildCategory(j).ChildCategory.Count - 1
                            Me.gems_cats.Add(New WebControls.ListItem(ostore.CustomCategories(i).ChildCategory(j).ChildCategory(k).Name, ostore.CustomCategories(i).ChildCategory(j).ChildCategory(k).CategoryID))
                            Me.gems_cats.Add(New WebControls.ListItem(ostore.CustomCategories(i).ChildCategory(j).ChildCategory(k).Name, ostore.CustomCategories(i).ChildCategory(j).ChildCategory(k).CategoryID))
                        Next
                    End If

                Next
            Else
                Me.gems_cats.Add(New WebControls.ListItem(ostore.CustomCategories(i).Name(), ostore.CustomCategories(i).CategoryID))
                Me.gems_cats.Add(New WebControls.ListItem(ostore.CustomCategories(i).Name(), ostore.CustomCategories(i).CategoryID))
            End If
        Next

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        Dim oFile_in As System.IO.File
        Dim oFile_out As System.IO.File
        Dim oWrite_in As System.IO.StreamReader
        Dim oWrite_out As System.IO.StreamWriter
        Dim filename_in As String = Server.MapPath("/allitems.csv")

        oWrite_out = oFile_out.CreateText(Server.MapPath("/allitems_out.csv"))
        oWrite_in = oFile_in.OpenText(Server.MapPath("/allitems.csv"))


        Dim line As String
        Dim firstline As Int32 = 0
        Do


            line = oWrite_in.ReadLine()

            '' Console.WriteLine(Line)
            If Not IsNothing(line) Then




                'Dim storecat1_id As String = line.Split(",")(8)
                'Dim storecat2_id As String = line.Split(",")(9)

                'Dim storecat1 As String
                'Dim storecat2 As String

                'Dim storecat1_gems_id As String
                'Dim storecat2_gems_id As String
                '''a.Text += Me.aviby_cats.Count.ToString
                'For Each list As WebControls.ListItem In Me.aviby_cats

                '    If list.Value = storecat1_id Then storecat1 = list.Text
                '    If list.Value = storecat2_id Then storecat2 = list.Text

                '    ''  a.Text += list.Text + "<br>"


                'Next



                'For Each list As WebControls.ListItem In Me.gems_cats

                '    If list.Text = storecat1 Then
                '        storecat1_gems_id = list.Value
                '        ''   a.Text += list.Text + "<br>"
                '    End If

                '    If list.Text = storecat2 Then
                '        storecat2_gems_id = list.Value
                '        ''a.Text += list.Text + "<br>"
                '    End If

                '    ''a.Text += list.Value


                'Next

                ''' a.Text += storecat1_gems_id + " " + storecat2_gems_id + "<br>"

                'line.Replace(storecat1_id, storecat1_gems_id)
                'line.Replace(storecat2_id, storecat2_gems_id)

                line = line.Replace("header-banner.jpg", "header-banner2.jpg")
                line = line.Replace("http://stores.ebay.com/AVIBY-Twin-Diamonds", "http://stores.shop.ebay.com/New-Generation-Jewelry")
                line = line.Replace("http://members.ebay.com/aboutme/aviby", "http://myworld.ebay.com/aboutme/gems-wholesaler/")
                line = line.Replace("http://feedback.ebay.com/ws/eBayISAPI.dll?ViewFeedback&myWorld=true&userid=aviby", "http://feedback.ebay.com/ws/eBayISAPI.dll?ViewFeedback2&userid=gems-wholesaler&ftab=AllFeedback&myworld=true")
                line = line.Replace("http://feedback.ebay.com/ws/eBayISAPI.dll?ViewFeedback&amp;myWorld=true&amp;userid=aviby", "http://feedback.ebay.com/ws/eBayISAPI.dll?ViewFeedback2&userid=gems-wholesaler&ftab=AllFeedback&myworld=true")

                oWrite_out.Write(line)
                If firstline = 0 Then
                    oWrite_out.Write(Convert.ToChar(vbCr))
                    oWrite_out.Write(Convert.ToChar(vbLf))
                Else
                    If line.IndexOf(",~,~,~,~,~,~,,~,~,~,~,~") = -1 Then
                        oWrite_out.Write(Convert.ToChar(vbLf))
                    Else
                        oWrite_out.Write(Convert.ToChar(vbCr))
                        oWrite_out.Write(Convert.ToChar(vbLf))
                    End If
                End If
                firstline = 1
            End If
        Loop Until line Is Nothing

        oWrite_in.Close()
        oWrite_out.Close()
        ''write the thing

        '' For Each item As ArrayList In t_csv
        '' oWrite.WriteLine(Join(item.ToArray, ","))
        ''  Next


    End Sub
End Class
