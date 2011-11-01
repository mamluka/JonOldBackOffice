Imports System.Xml
Imports System.Data.SqlClient
Imports System.IO
Imports System.Text.RegularExpressions

Public Class cls_prostore
    Public file As String


    Public conn_string As String
    Public dbtype As Int32
    Public xmlfile As String
    Public descxml As String
    Public facefile As String
    Public sql As String = ""

    Function GetCSV()
        On Error GoTo ErrorHandler

        Dim oConnection As SqlClient.SqlConnection = New SqlClient.SqlConnection
        Dim oDataAdapter1 As SqlDataAdapter = New SqlDataAdapter
        Dim oSQLcmd1 As SqlCommand = New SqlCommand("", oConnection)

        Dim oTmpInventory As New ion_two.cls_inventory_lgc
        oTmpInventory._connection_string = Me.conn_string
        oTmpInventory._dbtype = Me.dbtype

        Dim opictures As New ion_two.cls_pictures

        opictures.load("http://www.twin-diamonds.com", "https://www.twin-diamonds.com")

        oConnection.ConnectionString = Me.conn_string
        oConnection.Open()

        Dim ostringfunc As New iFunctions.cls_string

        '--- set default listing size

        ''  Me.grd_items.PageSize = Application("defaults").inv_default_rows

        ''  lbl_inventory.Text = "Inventory"

        oDataAdapter1.TableMappings.Add("Table", "v_inventory_list")



        If Me.sql = "" Then
            '' oSQLcmd1.CommandText = "select * from vv_jewelry_full where BRANCHNUMBER = 2 and suppliernumber in (12,13,14,15) and cs_type != 'Diamond'"
            oSQLcmd1.CommandText = "select * from vv_jewelry_full where BRANCHNUMBER = 2  and suppliernumber = 11 and cs_type != 'Diamond' and jeweltype='Ring' and cs_type != 'Diamonds'"
        Else
            oSQLcmd1.CommandText = Me.sql
        End If
        '' oSQLcmd1.CommandText = "select * from vv_jewelry_full where id > 16000 and id < 16100 and shopstatus = 1 and jewel_title != '' "


        oSQLcmd1.CommandType = CommandType.Text

        oDataAdapter1.SelectCommand = oSQLcmd1
        Dim oDs As DataSet

        oDs = New DataSet("inventory")

        oDataAdapter1.Fill(oDs)

        ''diamond jewelry

        Dim t_csv As New ArrayList
        Dim i As Int32 = 0

        For Each row As DataRow In oDs.Tables(0).Rows
            i += 1
            '' If i = 100 Then Exit For
            '' Dim item As New ArrayList
            Dim oPlate As New ion_two.skl_lst_inventory
            oTmpInventory.load(row("id"), oPlate, opictures)
            Dim osubplate As New Object
            osubplate = oPlate._subplate
            Dim item As New ArrayList

            Dim odesc As New ion_two.cls_viewer_catalog_lgk
            odesc.conn_string = Me.conn_string
            odesc.desc_xml = Me.descxml
            Dim desc As String = ""
            Select Case oPlate._platetype
                Case 3
                    If oPlate._subplate.se_relateditem_id > 0 Then
                        desc = oPlate._item_description
                        '' Return 0

                    ElseIf oPlate._subplate.jewel_title <> "" Then
                        desc = oPlate._subplate.jewel_title
                        '' Return 0
                    Else
                        odesc.CreateDescription(oPlate, desc)
                    End If
                Case Else
                    odesc.CreateDescription(oPlate, desc)
            End Select
            desc = desc.Replace("<br>", " ")
            desc = ostringfunc.ClearHTMLTagsReturn(desc)

            Dim ostringfunction As New iFunctions.cls_string
            Dim jeweltitle As String = desc
            ''  item.Add(i.ToString)
            item.Add("" + jeweltitle + "")



            item.Add(oPlate._itemnumber)
            item.Add("Normal")

            Dim price As String = oPlate._pricing._correct_price
            Dim retailprice As String


            item.Add(Math.Round(oPlate._pricing._correct_price).ToString)
            item.Add(Math.Round(oPlate._pricing._correct_price * 3.2).ToString)
            item.Add(Math.Round(oPlate._purchase_price).ToString)

            item.Add("Yes")
            item.Add("0")

            If oPlate._pricing._correct_price < 3000 Then
                item.Add("49")
            Else
                item.Add("0")
            End If


            item.Add("No")
            item.Add("0")
            item.Add("100")


            item.Add("0")
            item.Add("0")
            item.Add("0")
            item.Add("0")
            item.Add("0")
            item.Add("Self")
            item.Add(jeweltitle)


            ''desc
            Dim omail As New ion_two.cls_mod_mail
            Dim deschtml As String
            Dim fineldesc As String
            omail.getHTML_byURL("http://www.twin-diamonds.com/catalog/myitemv4.aspx?id=" + oPlate._id.ToString + "&nospecmodes=1", deschtml)

            fineldesc = "<link href=""http://www.twin-diamonds.com/catalog/catalogv4.css"" rel=""stylesheet"" type=""text/css"" />"
            fineldesc += "" + Regex.Match(deschtml, "<!--SPECS START-->(.+?)<!--SPECS END-->", RegexOptions.Singleline).Groups(1).Value + ""
            fineldesc = fineldesc.Replace(Chr(34), "'")
            fineldesc = Regex.Replace(fineldesc, "onclick='.+?'", "")


            '' desc = Regex.Replace(desc, "!apr!", Format(Math.Round(oPlate._appraisal_price), "####0.00") + " $", RegexOptions.Singleline)
            '' body = "test"
            ''descritopmn
            item.Add(Chr(34) + fineldesc.Replace(vbNewLine, " ") + Chr(34))
            ''
            '' item.Add("<table width='1070' border='0' cellpadding='0' cellspacing='0'>       <tr>                           <td width='346' valign='top'> <div id='car_specs'>               <table width='100%' border='0' cellspacing='0' cellpadding='0'>                 <tr>                   <td align='center' class='cat_info_title'><img src='http://www.twin-diamonds.com/pic/newstruct/catalog/item-sakal/spec-pic.jpg' width='171' height='14'></td>                 </tr>                 <tr>                   <td><!--specs--><table width='100%' border='0' cellspacing='0' cellpadding='0' style='BORDER-RIGHT:#b6b7cd 1px solid; BORDER-TOP:#b6b7cd 1px solid; BORDER-LEFT:#b6b7cd 1px solid; BORDER-BOTTOM:#b6b7cd 1px solid'>                                              <tr>                         <td width='35%' class='cat_info_part'><span style='WIDTH:80px; float:left; '     > Metal: </span> </td>                         <td width='65%' class='cat_info_part'><span  																																												> Rose Gold 18 Karat </span> </td>                       </tr>                                    <tr>                         <td width='35%' class='cat_info_part'><span style='WIDTH:80px; float:left; cursor: help' onclick='PopupHelp(this,17)'    onMouseOver='this.style.textDecoration='underline''  onmouseout='this.style.textDecoration='none''   > Ring Weight: </span> </td>                         <td width='65%' class='cat_info_part'><span  																																												> 15.40 Gr. </span> </td>                       </tr>                                    <tr>                         <td width='35%' class='cat_info_part'><span style='WIDTH:80px; float:left; '     > Brand: </span> </td>                         <td width='65%' class='cat_info_part'><span  																																												> Twin-diamonds Original </span> </td>                       </tr>                                    <tr>                         <td width='35%' class='cat_info_part'><span style='WIDTH:80px; float:left; '     >  </span> </td>                         <td width='65%' class='cat_info_part'><span  																																												> 6.31 Ct. Total weight. - 140 Stones<br> Diamonds are Excellent cut<BR>with Full Brilliance !<BR> <BR><BR><font face='Arial' size='1' color='#0000FF'>* FIRST CLASS JEWELRY GUARANTEED *</font><BR><BR> </span> </td>                       </tr>                                  <tr>                       <td colspan='2' ><table id='RightInfoPart' cellpadding='0' cellspacing='0' border='0' width='100%'><tr><td> 	 <link href='/catalog/catalog.css' rel='stylesheet' type='text/css' /> <table width='100%' border='0' cellspacing='0' cellpadding='0' >  <tr>     <td width='39%' class='cat_info_part' valign='top'>Center Stone:</td>     <td width='61%' class='cat_info_part'><span id='stone_extended_cs_desc' class=''>3.20 Ct. - E/VS2 - 2 stones</span><br>Natural Diamonds <a href='javascript:void(0)' onclick='PopupHelp(this,92)' >(clarity enhanced)</a><br>Princess Cut</td> </tr>  <tr>     <td width='39%' class='cat_info_part' valign='top'>Side Stones:</td>     <td width='61%' class='cat_info_part'>3.11 Ct. - E/VS2 - 138 stones<br>Natural Diamonds<br>Round Cut</td> </tr>  <tr>     <td width='39%' class='cat_info_part' valign='top'>Note:</td>     <td width='61%' class='cat_info_part'>02-02-16215</td> </tr>  </table>       </td></tr></table></td>                     </tr>                   </table><!--specs--></td>                 </tr>               </table>               <table id='BelowInfoParts' cellpadding='0' cellspacing='0' border='0' width='100%'><tr><td>  </td></tr></table>                                            <div class='cat_sep'><img src='http://www.twin-diamonds.com/pic/newstruct/catalog/item-sakal/cat-sep.jpg'></div>             </div>           <div id='cat_purchase'>             <table width='100%' border='0' cellspacing='0' cellpadding='0'>               <tr>                 <td><table width='100%' border='0' cellpadding='0' cellspacing='0' class='cat_price'>                                          <tr>                       <td style='PADDING-RIGHT:5px; PADDING-LEFT:5px; PADDING-BOTTOM:5px; PADDING-TOP:5px'><span style='WIDTH:180px; '>Retail Price:</span><span style='FONT-WEIGHT:bold;'     >!apr!</span></td>                     </tr>                                      </table></td>               </tr>               <tr>                 <td align='right' valign='top' style='PADDING-TOP:7px'>                                </table>             <div></div>             <table id='RightMods' cellpadding='0' cellspacing='0' border='0' width='100%'><tr><td>  </td></tr></table>           </div></td>         <td width='24' valign='top'>&nbsp;</td> <td width='730' valign='top'><table width='100%' border='0' cellspacing='0' cellpadding='0'>             <tr>               <td align='left' class='cat_item_title' id='catalog_item_title'  style='font-size:14px; background:#6699FF;padding:7px'><!--titlestart--><center><b>6.31 Ct.- E/VS2 - 18K Rose Gold <font face='arial'>TWO ROW PAVE<br>PRINCESS DROP EARRINGS</font></b></center><!--titleend--></td>             </tr>             <tr>               <td align='right' style=' PADDING-RIGHT:5px; PADDING-LEFT:5px; PADDING-BOTTOM:5px; PADDING-TOP:5px'><img src='http://www.twin-diamonds.com/precious-stones/jewelry/02-02-16130_pih.jpg' alt='' name='mainpic'   width='720' height='580' id='mainpic'><br>                 <br>  			             </tr>                 </table></td>       </tr>     </table> 	 	")
            item.Add("No")
            item.Add("No")
            item.Add("Yes")
            item.Add("No")
            item.Add("New")
            item.Add("Yes")

            Dim keywords As New ArrayList
            Dim category As String


            ''key words
            Select Case oPlate._platetype
                Case 3

                    keywords.Add(osubplate._jewelrytype)
                    keywords.Add(osubplate._jewelrysubtype)
                    keywords.Add(osubplate._setting)
                    keywords.Add(jeweltitle.Replace("-", "").Replace("&", "").Replace(" ", ",").Replace("'", " "))

                    category = osubplate._jewelrytype + ":" + osubplate._jewelrysubtype


                    'Select Case osubplate._jewelrytype
                    '    Case "Ring"
                    '        If osubplate._jewelrytype = "Mens Rings" Then
                    '            item.Add("Gemstone Jewelry:Gemstone Men's Rings")
                    '        Else
                    '            item.Add("Gemstone Jewelry:Gemstone Rings")
                    '        End If

                    '    Case "Earrings"
                    '        item.Add("Gemstone Jewelry:Gemstone Earrings")
                    '    Case "Bracelet"
                    '        item.Add("Gemstone Jewelry:Gemstone Bracelets")
                    '    Case "Pendant"
                    '        item.Add("Gemstone Jewelry:Gemstone Pendants")
                    '    Case Else
                    '        item.Add("Gemstone Jewelry:Gemstone Rings")
                    'End Select



                Case 2
                    keywords.Add(osubplate._s_weight)
                    keywords.Add(osubplate._shape)
                    keywords.Add(osubplate._colorfrom)
                    keywords.Add(osubplate._clarityfrom)
                    keywords.Add(osubplate._shape)
                    keywords.Add(osubplate._s_measure)
                    keywords.Add(osubplate._stonetype)
                    If osubplate._report <> "-" Then
                        keywords.Add(osubplate._report)
                    End If
                    keywords.Add(osubplate._origin)
                    category = oPlate._category_name + ":" + osubplate._stonetype
                Case 1
                    keywords.Add(osubplate._s_weight)
                    keywords.Add(osubplate._shape)
                    keywords.Add(osubplate._colorfrom)
                    keywords.Add(osubplate._clarityfrom)
                    keywords.Add(osubplate._shape)
                    keywords.Add(osubplate._s_measure)
                    keywords.Add(osubplate._stonetype)
                    If osubplate._report <> "-" Then
                        keywords.Add(osubplate._report)
                    End If
                    keywords.Add(osubplate.fancy_freetxt)
                    category = oPlate._category_name + ":" + osubplate._stonetype





            End Select
            item.Add(Chr(34) + Join(keywords.ToArray, ", ") + Chr(34))
            item.Add(Chr(34) + Join(keywords.ToArray, ", ") + Chr(34))
            item.Add(category)
            item.Add(Chr(34) + Join(keywords.ToArray, ",") + Chr(34))
            item.Add(oPlate._icon_pic)




            ''item.Add(oPlate._picture_pic)




            'item.Add("0")

            'item.Add("1")

            'item.Add("USD")

            'Dim start_price As Decimal = Math.Round(oPlate._sell_price * 0.8)

            'item.Add(start_price.ToString)

            'item.Add("0")
            'item.Add("1")
            'item.Add(Math.Round(oPlate._sell_price).ToString)

            'item.Add("1")
            'item.Add("1")

            'item.Add("1")
            'item.Add("0")
            'item.Add("1")

            'item.Add("0")

            'item.Add("0")

            'item.Add("Airmail")



            'item.Add("All our products are shipped FREE and are trackable and fullyinsured. We ship our jewelry from ourmanufacturing facility at the Diamond Exchange in Israel.All shipments are insured for lossand require buyers signature upon delivery or pickup.Shipping rate includes insurance.")


            'item.Add("0")

            'item.Add("0")

            'item.Add("0")

            'item.Add("0")
            'item.Add("1")


            'item.Add("Both")

            'item.Add("52520")

            'item.Add("IL")

            'item.Add("1968")

            'item.Add("121719")






            t_csv.Add(item)





            'If i = 4 Then
            '    Exit For
            'End If




        Next

        'Me.AddQuotes(t_diamondjewelry)
        'Me.AddQuotes(t_earrings)
        'Me.AddQuotes(t_gemstones)
        'Me.AddQuotes(t_semi)
        'Me.AddQuotes(t_rings)
        'Me.AddQuotes(t_goldjewelry)
        ''Dim oExcel As New Excel.Application
        'Dim oBooks As Excel.Workbooks, oBook As Excel.Workbook
        'Dim oSheets As Excel.Sheets, oSheet As Excel.Worksheet
        'Dim oCells As Excel.Range

        'oBooks = oExcel.Workbooks
        'oBooks.Open(Me.file)
        'oBook = oBooks.Item(1)

        'oSheets = oBook.Worksheets
        'oSheet = CType(oSheets.Item(1), Excel.Worksheet)
        'oSheet.Name = "First Sheet"
        'oCells = oSheet.Cells

        'oCells(2, 2) = "sdfsdf"

        'oSheet.SaveAs(Me.file)
        'oBook.Close()

        'Quit Excel and thoroughly deallocate everything
        'oExcel.Quit()




        ''Dim oexcel As New Excel
        '' ''   Dim oexcel As New Microsoft.Office.Interop.Excel.Application
        ''    Dim oworkbook As New Microsoft.Office.Interop.Excel.Workbook
        '' oworkbook = oexcel.Workbooks.Open(Me.file, 0, True, 5, "", "", True, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", False, False, 0, True)
        ''oexcel.work()
        ''  Dim sheet As Microsoft.Office.Interop.Excel.Worksheet = oworkbook.get


        Dim oFile As System.IO.File
        Dim oWrite As System.IO.StreamWriter
        oWrite = oFile.CreateText(Me.file)

        oWrite.WriteLine("Product,SKU,ProductType,Price,PriceRetail,Cost,Taxable,Surcharge,Shipping,ShippingExemptInd,SaleExclude,Quantity,Threshold,Weight,Length,Height,Width,ContainerCode,Brief,Description,Subscription,Featured,Active,AuthReq,Condition,Media,NaturalSearchKeywords,NaturalSearchDescription,Category,Keywords,MediaItem1")

        For Each item As ArrayList In t_csv
            oWrite.WriteLine(Join(item.ToArray, ","))
        Next

        oWrite.Close()





ErrorHandler:
        '--- when object is called in external DLL
        Return Err.Description
    End Function
    Function SetCategory(ByVal plate As Int16, ByVal catid As Int32, ByVal subcatid As Int32, Optional ByVal jewelcat As String = "0", Optional ByVal jewelsubcat As String = "0", Optional ByVal stone As String = "Other") As String

        Select Case plate
            Case 1
                Return "Jewelry & Watches -> Diamond Jewelry -> Loose Diamonds"
            Case 2
                Return "Jewelry & Watches -> Other Jewelry"
            Case 3
                If stone = "Diamond" Then
                    If jewelcat = "Earrings" Then
                        Return "Jewelry & Watches -> Diamond Jewelry -> Diamond Earrings"

                    ElseIf jewelcat = "Ring" Then
                        Return "Jewelry & Watches -> Diamond Jewelry -> Diamond Rings"

                    ElseIf jewelcat = "Necklace" Then
                        Return "Jewelry & Watches -> Diamond Jewelry -> Diamond Necklaces"

                    ElseIf jewelcat = "Pendant" Then
                        Return "Jewelry & Watches -> Diamond Jewelry -> Diamond Pendants"


                    Else
                        Return "Jewelry & Watches -> Other Jewelry"
                    End If
                Else
                    If jewelcat = "Earrings" Then
                        Return "Jewelry & Watches -> Women's Jewelry -> Diamond Earrings"

                    ElseIf jewelcat = "Ring" Then
                        Return "Jewelry & Watches -> Women's Jewelry -> Diamond Rings"

                    ElseIf jewelcat = "Necklace" Then
                        Return "Jewelry & Watches -> Women's Jewelry -> Diamond Necklaces"

                    ElseIf jewelcat = "Pendant" Then
                        Return "Jewelry & Watches -> Women's Jewelry -> Diamond Pendants"


                    Else
                        Return "Jewelry & Watches -> Other Jewelry"
                    End If
                End If



        End Select

    End Function
End Class

