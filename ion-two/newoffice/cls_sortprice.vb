Imports System.Xml
Imports System.Data.SqlClient
Imports System.IO
Public Class cls_sortprice
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




        oSQLcmd1.CommandText = "select * from vv_allitems_full where (itemdeleted = 0) and (qtyonstock_cur > 0) and (shopstatus = 1) and (sell_price > 0) and (  ( (suppliernumber=96 or suppliernumber=99) and branchnumber=1 ) or ( (branchnumber=2 )   ))" ''where suppliernumber=46"



        oSQLcmd1.CommandType = CommandType.Text

        oDataAdapter1.SelectCommand = oSQLcmd1
        Dim oDs As DataSet

        oDs = New DataSet("inventory")

        oDataAdapter1.Fill(oDs)

        ''diamond jewelry

        Dim t_csv As New ArrayList
        Dim i As Int32

        For Each row As DataRow In oDs.Tables(0).Rows
            ''   i += 1
            '' If i = 100 Then Exit For
            '' Dim item As New ArrayList
            Dim oPlate As New ion_two.skl_lst_inventory
            oTmpInventory.load(row("id"), oPlate, opictures)

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


            Dim infoparts As New ArrayList
            Dim priceparts As New ArrayList

            Dim face As New ion_two.cls_catalog_face_v1

            Dim ocatalog As New ion_two.cls_catalog_lgk
            ocatalog.xml_faces_file = Me.facefile
            Dim qhash As New Hashtable
            ocatalog.LoadFace(oPlate, face, qhash)

            ocatalog.LoadInfoPartsColl(oPlate, infoparts, face)

            ''  item.Add(desc)

            Dim info As String = ""

            Dim j As Int32 = 0
            Dim jto As Int32
            If infoparts.Count > 5 Then
                jto = 4
            Else
                jto = infoparts.Count - 1
            End If
            For j = 1 To jto
                If j = jto Then
                    info += infoparts(j).cat + infoparts(j).text
                Else
                    info += infoparts(j).cat + infoparts(j).text + " , "
                End If
                ''info += infoparts(j).cat + infoparts(j).text + " , "
            Next

            ''info = Mid(info, 1, info.Length - 3)


            info = info.Replace(vbNewLine, " ")
            info = info.Replace(vbCrLf, " ")
            info = info.Replace(vbLf, " ")
            info = info.Replace(vbCr, " ")
            ''info = info + vbNewLine


            info = info.Replace("&Oslash;", "&")

            item.Add(Chr(34) + desc + Chr(34))
            item.Add("")
            If oPlate._platetype <> 3 Then
                item.Add(Me.SetCategory(oPlate._platetype, oPlate._category_id, oPlate._subcategory_id))
            Else
                item.Add(Me.SetCategory(oPlate._platetype, oPlate._category_id, oPlate._subcategory_id, oPlate._subplate._jewelrytype, oPlate._subplate._jewelrysubtype, oPlate._subplate._middlestone))
            End If
            item.Add(oPlate._pricing._correct_price.ToString)

            item.Add("http://www.twin-diamonds.com/catalog/myitem.aspx?id=" + oPlate._id.ToString)
            item.Add(oPlate._picture_hires_pic)
            item.Add(oPlate._itemnumber)
            item.Add(Chr(34) + info + Chr(34))

            ''item.Add(oPlate._pricing._correct_price)

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
