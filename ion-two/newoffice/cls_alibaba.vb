Imports System.Xml
Imports System.Data.SqlClient
Imports System.IO




Public Class cls_alibaba
    Public file As String
    Public file2 As String
    Public file3 As String
    Public file4 As String
    Public file5 As String
    Public file6 As String

    Public conn_string As String
    Public dbtype As Int32
    Public xmlfile As String
    Public descxml As String
    Public facefile As String

    Function test()
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




        oSQLcmd1.CommandText = "select * from vv_allitems_full where (itemdeleted = 0) and (qtyonstock_cur > 0) and (shopstatus = 1) and (sell_price > 0)" ''where suppliernumber=46"



        oSQLcmd1.CommandType = CommandType.Text

        oDataAdapter1.SelectCommand = oSQLcmd1
        Dim oDs As DataSet

        oDs = New DataSet("inventory")

        oDataAdapter1.Fill(oDs)

        ''diamond jewelry

        Dim t_diamondjewelry As New ArrayList
        Dim t_goldjewelry As New ArrayList
        Dim t_earrings As New ArrayList
        Dim t_rings As New ArrayList
        Dim t_gemstones As New ArrayList
        Dim t_semi As New ArrayList
        Dim i As Int32
        For Each row As DataRow In oDs.Tables(0).Rows
            i += 1
            ''  If i = 100 Then Exit For
            '' Dim item As New ArrayList
            Dim oPlate As New ion_two.skl_lst_inventory
            oTmpInventory.load(row("id"), oPlate, opictures)


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

            For Each infopart As ion_two.cls_catalog_lgk.infopart_v1 In infoparts
                info += infopart.cat + infopart.text + "<br>"
            Next


            info = info.Replace(vbNewLine, " ")
            info = info.Replace(vbCrLf, " ")
            info = info.Replace(vbLf, " ")
            info = info.Replace(vbCr, " ")
            ''info = info + vbNewLine


            ''diamond jewelry
            If oPlate._platetype = 3 Then
                If oPlate._subplate._middlestone = "Diamond" Then
                    Dim item As New ArrayList
                    item.Clear()
                    item.Add(desc)
                    ''item.Add("Diamond Ring")
                    '' item.Add(desc)
                    item.Add("")
                    item.Add(oPlate._itemnumber)
                    item.Add("1")
                    item.Add("Piece/Pieces")
                    item.Add(info) '' saved for addition info
                    t_diamondjewelry.Add(item)
                End If
            End If
            ''gold jewelry
            If oPlate._platetype = 3 Then
                If oPlate._subplate._metal.tolower.indexof("gold") > -1 Then
                    Dim item As New ArrayList
                    item.Clear()
                    item.Add(desc)
                    If oPlate._subplate._middlestone <> "-" Then
                        item.Add(oPlate._subplate._middlestone + " Ring")
                    Else
                        item.Add("Ring")
                    End If
                    item.Add(desc)
                    item.Add("")
                    item.Add(oPlate._itemnumber)
                    item.Add("1")
                    item.Add("Piece/Pieces")
                    item.Add(info)
                    t_goldjewelry.Add(item)

                    ''item.Add() '' saved for addition info
                End If
            End If
            '' 
            ''earings
            If oPlate._platetype = 3 Then
                If oPlate._subcategory_name.ToLower.IndexOf("earring") > -1 Then
                    Dim item As New ArrayList
                    item.Clear()
                    item.Add(desc)
                    If oPlate._subplate._middlestone <> "-" Then
                        item.Add(oPlate._subplate._middlestone + " Earrings")
                    Else
                        item.Add("Earrings")
                    End If
                    item.Add(desc)
                    item.Add(oPlate._subplate._metal)
                    ''  Dim oextra As New ion_two.cls_jewerly_extra
                    If oPlate._subplate._jewel_extended.cs_desc <> "" Then
                        ''   oextra.get_stone_extended_string(oPlate._subplate._stone_extended)
                        item.Add(oPlate._subplate._jewel_extended.cs_cut)

                    Else
                        item.Add("Round")
                    End If

                    item.Add("")
                    item.Add(oPlate._itemnumber)
                    item.Add("1")
                    item.Add("Piece/Pieces")
                    item.Add(info)
                    '' item.Add() '' saved for addition info
                    t_earrings.Add(item)
                End If
            End If
            ''rings
            If oPlate._platetype = 3 Then
                If oPlate._subplate._jewelrytype.tolower.indexof("ring") > -1 Then
                    Dim item As New ArrayList
                    item.Clear()
                    item.Add(desc)
                    If oPlate._subplate._middlestone <> "-" Then
                        item.Add(oPlate._subplate._middlestone + " Ring")
                    Else
                        item.Add("Ring")
                    End If
                    item.Add(desc)
                    item.Add(oPlate._subplate._metal)
                    ''  Dim oextra As New ion_two.cls_jewerly_extra
                    If oPlate._subplate._jewel_extended.cs_desc <> "" Then
                        ''   oextra.get_stone_extended_string(oPlate._subplate._stone_extended)
                        item.Add(oPlate._subplate._jewel_extended.cs_cut)

                    Else
                        item.Add("Round")
                    End If

                    item.Add("")
                    item.Add(oPlate._itemnumber)
                    item.Add("1")
                    item.Add("Piece/Pieces")
                    item.Add(info)
                    t_rings.Add(item)
                    '' item.Add() '' saved for addition info

                End If
            End If
            ''gemstones
            If oPlate._platetype = 2 Then
                If Trim(oPlate._category_name) <> "Semi Precious" Then
                    Dim item As New ArrayList
                    item.Clear()
                    item.Add(desc)
                    item.Add(oPlate._subplate._stonetype)
                    item.Add(desc)
                    item.Add(oPlate._subplate._stonetype)


                    item.Add("")
                    item.Add(oPlate._itemnumber)
                    item.Add("1")
                    item.Add("Piece/Pieces")
                    item.Add(info)
                    '' item.Add() '' saved for addition info
                    t_gemstones.Add(item)
                End If
            End If
            ''semi
            If oPlate._platetype = 2 Then
                If Trim(oPlate._category_name) = "Semi Precious" Then
                    Dim item As New ArrayList
                    item.Clear()
                    item.Add(desc)
                    item.Add(oPlate._subplate._stonetype)
                    item.Add(desc)
                    item.Add(oPlate._subplate._stonetype)



                    item.Add("")
                    item.Add(oPlate._itemnumber)
                    item.Add("1")
                    item.Add("Piece/Pieces")
                    item.Add(info)
                    t_semi.Add(item)
                    '' item.Add() '' saved for addition info

                End If

            End If







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

        For Each item As ArrayList In t_diamondjewelry
            oWrite.WriteLine(Join(item.ToArray, ";"))
            ''oWrite.Write(vbNewLine)
        Next


        oWrite.Close()

        oWrite = oFile.CreateText(Me.file2)

        For Each item As ArrayList In t_goldjewelry
            oWrite.WriteLine(Join(item.ToArray, ";"))
            ''  oWrite.Write(vbNewLine)
        Next

        oWrite.Close()

        oWrite = oFile.CreateText(Me.file3)

        For Each item As ArrayList In t_earrings
            oWrite.WriteLine(Join(item.ToArray, ";"))
            '' oWrite.Write(vbNewLine)
        Next

        oWrite.Close()

        oWrite = oFile.CreateText(Me.file4)

        For Each item As ArrayList In t_rings
            oWrite.WriteLine(Join(item.ToArray, ";"))
            '' oWrite.Write(vbNewLine)
        Next

        oWrite.Close()

        oWrite = oFile.CreateText(Me.file5)

        For Each item As ArrayList In t_gemstones
            oWrite.WriteLine(Join(item.ToArray, ";"))
            '' oWrite.Write(vbNewLine)
        Next

        oWrite.Close()

        oWrite = oFile.CreateText(Me.file6)

        For Each item As ArrayList In t_semi
            oWrite.WriteLine(Join(item.ToArray, ";"))
            ''  oWrite.Write(vbNewLine)
        Next

        oWrite.Close()
        Exit Function

ErrorHandler:
        '--- when object is called in external DLL
        Return Err.Description


    End Function
    Function AddQuotes(ByRef list As ArrayList)
        Dim i, j As Int32
        For i = 0 To list.Count - 1
            For j = 0 To list(i).Count - 1
                list(i)(j) = Chr(34) + list(i)(j) + Chr(34)
            Next
        Next

    End Function
End Class
