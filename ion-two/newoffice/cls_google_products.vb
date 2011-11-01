Imports System.Xml
Imports System.Data.SqlClient

Public Class cls_google_products
    Public conn_string As String
    Public dbtype As Int32
    Public xmlfile As String
    Public descxml As String
    Public Function CreateFeed()

        On Error GoTo errorhandler

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

        '--- set default listing size

        ''  Me.grd_items.PageSize = Application("defaults").inv_default_rows

        ''  lbl_inventory.Text = "Inventory"

        oDataAdapter1.TableMappings.Add("Table", "v_inventory_list")




        oSQLcmd1.CommandText = "select * from vv_allitems_full where (itemdeleted = 0) and (qtyonstock_cur > 0) and (shopstatus = 1) and (sell_price > 0) and suppliernumber=99" ''where suppliernumber=46"



        oSQLcmd1.CommandType = CommandType.Text

        oDataAdapter1.SelectCommand = oSQLcmd1
        Dim oDs As DataSet

        oDs = New DataSet("inventory")

        oDataAdapter1.Fill(oDs)

        Dim oxml As New ion_two.cls_nd_xmlwrite
        oxml.xml_file = Me.xmlfile
        Dim nodearray As New ArrayList
        nodearray.Add("rss")

        Dim rootnode As XmlNode = oxml.CreateXMLNode(nodearray)
        Dim nsattr As XmlAttribute = oxml.CreateXmlAttribute("xmlns:g", "http://base.google.com/ns/1.0")
        Dim ver As XmlAttribute = oxml.CreateXmlAttribute("version", "2.0")
        rootnode.Attributes.Append(nsattr)
        rootnode.Attributes.Append(ver)



        oxml.WriteRootElement(rootnode)

        Dim channel As New ArrayList
        channel.Add("channel")
        channel.Add("title")
        channel.Add("description")
        channel.Add("link")




        Dim xmlchannel As XmlNode = oxml.CreateXMLNode(channel)
        xmlchannel("link").InnerText = "http://www.twin-diamonds.com"
        xmlchannel("title").InnerText = "Twin-Diamonds.com"
        xmlchannel("description").InnerText = "diamonds, diamond rings and gemstones, including emeralds, sapphires and rubies, available from Twin-Diamonds.com. Browse our wide selection of diamond jewelry and gemstone jewelry"
        Dim counter As Int32 = 0

        For Each row As DataRow In oDs.Tables(0).Rows
            counter += 1
            If counter = 88 Then
                counter += 1
            End If

            Dim oPlate As New ion_two.skl_lst_inventory
            oTmpInventory.load(row("id"), oPlate, opictures)

            Dim itemarray As New ArrayList
            itemarray.Add("item")
            itemarray.Add("description")
            itemarray.Add("g:id")
            itemarray.Add("link")
            itemarray.Add("g:price")
            itemarray.Add("title")
            itemarray.Add("g:condition")
            itemarray.Add("g:image_link")
            itemarray.Add("g:image_link")
            If oPlate._platetype <> 3 Then
                itemarray.Add("g:color")
            End If
            itemarray.Add("g:payment_accepted")
            itemarray.Add("g:payment_accepted")
            itemarray.Add("g:payment_accepted")
            itemarray.Add("g:quantity")
            itemarray.Add("g:weight")

            Dim item As XmlNode = oxml.CreateXMLNode(itemarray, "http://base.google.com/ns/1.0")



            Dim odesc As New ion_two.cls_viewer_catalog_lgk
            odesc.conn_string = Me.conn_string
            odesc.desc_xml = Me.descxml
            Dim desc As String
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

            Dim ostringfunc As New iFunctions.cls_string

            item("description").InnerText = ostringfunc.ClearHTMLTagsReturn(desc.Replace("<br>", " "))
            item("g:id").InnerText = oPlate._id.ToString
            item("link").InnerText = "http://www.twin-diamonds.com/catalog/myitem.aspx?id=" + oPlate._id.ToString
            item("g:price").InnerText = FormatNumber(oPlate._pricing._correct_price, 2, TriState.True, TriState.UseDefault, TriState.False)
            item("title").InnerText = ostringfunc.ClearHTMLTagsReturn(desc.Replace("<br>", " "))
            item("g:condition").InnerText = "New"
            Dim xmlnsmngr As New XmlNamespaceManager(oxml.xmldoc.NameTable)
            xmlnsmngr.AddNamespace("g", "http://base.google.com/ns/1.0")

            item.SelectSingleNode("g:image_link[1]", xmlnsmngr).InnerText = oPlate._icon_pic
            item.SelectSingleNode("g:image_link[2]", xmlnsmngr).InnerText = oPlate._picture_pic
            item.SelectSingleNode("g:payment_accepted[1]", xmlnsmngr).InnerText = "PayPal"
            item.SelectSingleNode("g:payment_accepted[2]", xmlnsmngr).InnerText = "Visa"
            item.SelectSingleNode("g:payment_accepted[3]", xmlnsmngr).InnerText = "Mastercard"
            If oPlate._platetype <> 3 Then
                item("g:color").InnerText = oPlate._subplate._colorfrom
            End If
            item("g:quantity").InnerText = oPlate._qtyonstock_cur
            item("g:weight").InnerText = oPlate._subplate._s_weight

            xmlchannel.AppendChild(item)






        Next
        rootnode.AppendChild(xmlchannel)

        oxml.SaveDoc()


errorhandler:
        Return Err.Description
        ''  Return Err.Source
    End Function




End Class
