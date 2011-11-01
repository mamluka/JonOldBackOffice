Imports System.Xml
Imports System.Data.SqlClient
Imports System.IO
Imports System.Text.RegularExpressions

Public Class cls_webidz
    Public file As String


    Public conn_string As String
    Public dbtype As Int32
    Public xmlfile As String
    Public descxml As String
    Public facefile As String

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




        oSQLcmd1.CommandText = "select * from vv_jewelry_full where (itemdeleted = 0) and (qtyonstock_cur > 0) and (shopstatus = 1) and (sell_price > 0) and jewel_title != '' and (  ( (suppliernumber=96 or suppliernumber=99) and branchnumber=1 ) or ( (branchnumber=2 )   )) and se_relateditem_id = 0  and id >= 16000 and id < 18000 "
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
            oTmpInventory.load(1, row, oPlate, opictures)
            Dim item As New ArrayList

            item.Add(i.ToString)
            item.Add(i.ToString)

            item.Add("1")
            item.Add("0")
            item.Add("0")

            Dim ostringfunction As New iFunctions.cls_string

            item.Add(ostringfunc.ClearHTMLTagsReturn(oPlate._subplate.jewel_title))

            If oPlate._subplate._jewel_extended.cs_type.indexof("Diamond") > -1 Then
                item.Add("Diamond")
            Else
                item.Add("Gemstone")
            End If

            item.Add("Body Jewelry")



            item.Add("6")
            ''desc
            Dim omail As New ion_two.cls_mod_mail
            Dim desc As String
            omail.getHTML_byURL("http://www.twin-diamonds.com/catalog/myebayitem.aspx?id=" + oPlate._id.ToString + "&apr=1", desc)

            ''  desc = Regex.Match(desc, "<!--PAGE START-->(.+?)<!--PAGE END-->", RegexOptions.Singleline).Groups(1).Value
            desc = desc.Replace(vbNewLine, " ")
            'body = body.Replace(vbCrLf, " ")
            'body = body.Replace(vbLf, " ")
            'body = body.Replace(vbCr, " ")
            'body = body.Replace(Chr(13), " ")
            'body = body.Replace(Chr(10), " ")


            desc = desc.Replace(Chr(34), "'")
            desc = desc.Replace(",", " ")



            '' ostringfunc.format_currency(, Me.ebayhash("apr_amount"), " " + Me.ebayhash("currencyType"))

            desc = Regex.Replace(desc, "!apr!", Format(Math.Round(oPlate._appraisal_price), "####0.00") + " $", RegexOptions.Singleline)
            '' body = "test"
            ''descritopmn
            item.Add(desc)
            ''
            '' item.Add("<table width='1070' border='0' cellpadding='0' cellspacing='0'>       <tr>                           <td width='346' valign='top'> <div id='car_specs'>               <table width='100%' border='0' cellspacing='0' cellpadding='0'>                 <tr>                   <td align='center' class='cat_info_title'><img src='http://www.twin-diamonds.com/pic/newstruct/catalog/item-sakal/spec-pic.jpg' width='171' height='14'></td>                 </tr>                 <tr>                   <td><!--specs--><table width='100%' border='0' cellspacing='0' cellpadding='0' style='BORDER-RIGHT:#b6b7cd 1px solid; BORDER-TOP:#b6b7cd 1px solid; BORDER-LEFT:#b6b7cd 1px solid; BORDER-BOTTOM:#b6b7cd 1px solid'>                                              <tr>                         <td width='35%' class='cat_info_part'><span style='WIDTH:80px; float:left; '     > Metal: </span> </td>                         <td width='65%' class='cat_info_part'><span  																																												> Rose Gold 18 Karat </span> </td>                       </tr>                                    <tr>                         <td width='35%' class='cat_info_part'><span style='WIDTH:80px; float:left; cursor: help' onclick='PopupHelp(this,17)'    onMouseOver='this.style.textDecoration='underline''  onmouseout='this.style.textDecoration='none''   > Ring Weight: </span> </td>                         <td width='65%' class='cat_info_part'><span  																																												> 15.40 Gr. </span> </td>                       </tr>                                    <tr>                         <td width='35%' class='cat_info_part'><span style='WIDTH:80px; float:left; '     > Brand: </span> </td>                         <td width='65%' class='cat_info_part'><span  																																												> Twin-diamonds Original </span> </td>                       </tr>                                    <tr>                         <td width='35%' class='cat_info_part'><span style='WIDTH:80px; float:left; '     >  </span> </td>                         <td width='65%' class='cat_info_part'><span  																																												> 6.31 Ct. Total weight. - 140 Stones<br> Diamonds are Excellent cut<BR>with Full Brilliance !<BR> <BR><BR><font face='Arial' size='1' color='#0000FF'>* FIRST CLASS JEWELRY GUARANTEED *</font><BR><BR> </span> </td>                       </tr>                                  <tr>                       <td colspan='2' ><table id='RightInfoPart' cellpadding='0' cellspacing='0' border='0' width='100%'><tr><td> 	 <link href='/catalog/catalog.css' rel='stylesheet' type='text/css' /> <table width='100%' border='0' cellspacing='0' cellpadding='0' >  <tr>     <td width='39%' class='cat_info_part' valign='top'>Center Stone:</td>     <td width='61%' class='cat_info_part'><span id='stone_extended_cs_desc' class=''>3.20 Ct. - E/VS2 - 2 stones</span><br>Natural Diamonds <a href='javascript:void(0)' onclick='PopupHelp(this,92)' >(clarity enhanced)</a><br>Princess Cut</td> </tr>  <tr>     <td width='39%' class='cat_info_part' valign='top'>Side Stones:</td>     <td width='61%' class='cat_info_part'>3.11 Ct. - E/VS2 - 138 stones<br>Natural Diamonds<br>Round Cut</td> </tr>  <tr>     <td width='39%' class='cat_info_part' valign='top'>Note:</td>     <td width='61%' class='cat_info_part'>02-02-16215</td> </tr>  </table>       </td></tr></table></td>                     </tr>                   </table><!--specs--></td>                 </tr>               </table>               <table id='BelowInfoParts' cellpadding='0' cellspacing='0' border='0' width='100%'><tr><td>  </td></tr></table>                                            <div class='cat_sep'><img src='http://www.twin-diamonds.com/pic/newstruct/catalog/item-sakal/cat-sep.jpg'></div>             </div>           <div id='cat_purchase'>             <table width='100%' border='0' cellspacing='0' cellpadding='0'>               <tr>                 <td><table width='100%' border='0' cellpadding='0' cellspacing='0' class='cat_price'>                                          <tr>                       <td style='PADDING-RIGHT:5px; PADDING-LEFT:5px; PADDING-BOTTOM:5px; PADDING-TOP:5px'><span style='WIDTH:180px; '>Retail Price:</span><span style='FONT-WEIGHT:bold;'     >!apr!</span></td>                     </tr>                                      </table></td>               </tr>               <tr>                 <td align='right' valign='top' style='PADDING-TOP:7px'>                                </table>             <div></div>             <table id='RightMods' cellpadding='0' cellspacing='0' border='0' width='100%'><tr><td>  </td></tr></table>           </div></td>         <td width='24' valign='top'>&nbsp;</td> <td width='730' valign='top'><table width='100%' border='0' cellspacing='0' cellpadding='0'>             <tr>               <td align='left' class='cat_item_title' id='catalog_item_title'  style='font-size:14px; background:#6699FF;padding:7px'><!--titlestart--><center><b>6.31 Ct.- E/VS2 - 18K Rose Gold <font face='arial'>TWO ROW PAVE<br>PRINCESS DROP EARRINGS</font></b></center><!--titleend--></td>             </tr>             <tr>               <td align='right' style=' PADDING-RIGHT:5px; PADDING-LEFT:5px; PADDING-BOTTOM:5px; PADDING-TOP:5px'><img src='http://www.twin-diamonds.com/precious-stones/jewelry/02-02-16130_pih.jpg' alt='' name='mainpic'   width='720' height='580' id='mainpic'><br>                 <br>  			             </tr>                 </table></td>       </tr>     </table> 	 	")




            item.Add(oPlate._picture_pic)




            item.Add("0")

            item.Add("1")

            item.Add("USD")

            Dim start_price As Decimal = Math.Round(oPlate._sell_price * 0.8)

            item.Add(start_price.ToString)

            item.Add("0")
            item.Add("1")
            item.Add(Math.Round(oPlate._sell_price).ToString)

            item.Add("1")
            item.Add("1")

            item.Add("1")
            item.Add("0")
            item.Add("1")

            item.Add("0")

            item.Add("0")

            item.Add("Airmail")



            item.Add("All our products are shipped FREE and are trackable and fullyinsured. We ship our jewelry from ourmanufacturing facility at the Diamond Exchange in Israel.All shipments are insured for lossand require buyers signature upon delivery or pickup.Shipping rate includes insurance.")


            item.Add("0")

            item.Add("0")

            item.Add("0")

            item.Add("0")
            item.Add("1")


            item.Add("Both")

            item.Add("52520")

            item.Add("IL")

            item.Add("1968")

            item.Add("121719")






            t_csv.Add(item)










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

        oWrite.WriteLine("item_id,profile_id,tab_status,is_deleted,closed,item_title,Category_1,Category_2,duration,description,item_picture_filename,auction_type,quantity,auction_currency,start_price,reserve_price,buy_out_flag,buy_out_price,private,auction_start,autorelist,autorelist_sold,pd_paypal_direct,shipping_cost,insurance,shipping_method,shipping_details,fee_homepage,fee_category,fee_highlighted,fee_bold,autorelist_nb,list_in,zipcode,state,country,payment_options")

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

