Imports System.Web.HttpContext
Imports System.Xml
Public Class cls_stonestrip
    Public xml_file As String
    Public key_xml_file As String = System.Web.HttpContext.Current.Server.MapPath("/xml/stripkeys.xml")
    Public conn_string As String
    Public db_type As String


    Public Function GetPriceByStoneId(ByVal key As String, ByVal stripid As Int32, ByVal id As Int32, ByRef price As Decimal) As Boolean

        ''    Dim a As New WordLine.AllView




        Dim oxml As New ion_two.cls_nd_xmlread
        oxml.xml_file = Me.xml_file
        oxml.Load()

        Dim strip As XmlNode = oxml.GetNodes_ByPath("strip").Item(stripid)
        Dim table As String = strip.Item("stones_options").Item("table").InnerText
        Dim shapeid As String = strip.Item("stones_options").Item("shapeid").InnerText
        Dim priceadd As Decimal = Convert.ToDecimal(strip.Item("priceadd").InnerText)
        Dim stoneid As String = ""
        If Not IsNothing(strip.Item("stones_options").Item("stoneid")) Then
            stoneid = strip.Item("stones_options").Item("stoneid").InnerText()
        End If
        Dim priceperstone As Boolean = False
        If Not IsNothing(strip.Item("stones_options").Item("priceperstone")) Then
            priceperstone = True
        Else
            priceperstone = False
        End If

        Dim stone As XmlNode = strip.SelectNodes("stone").Item(id)

        Dim weight As String = stone.Item("weight").InnerText

        If stone.Item("price").InnerText = "" Then

            Dim oTmpDataBroker As New iDac.cls_T_datareader
            oTmpDataBroker._dbtype = Me.db_type
            oTmpDataBroker._connection_string = Me.conn_string
            oTmpDataBroker._table = table
            oTmpDataBroker._id = 0

            Dim cSQL As String
            If stoneid = "" Then
                cSQL = "select price from " + table + " where shapeid = " + shapeid + " and weight = " + weight
            Else
                cSQL = "select price from " + table + " where shapeid = " + shapeid + " and weight = " + weight + " and stoneid=" + stoneid
            End If

            '--- Define records
            Dim oField1 As New iDac.cls_cll_datareader
            oField1._field = "price"
            oTmpDataBroker._fields.Add(oField1)
            oField1 = Nothing

            oTmpDataBroker.read(cSQL)


            If Not priceperstone = True Then
                price = oTmpDataBroker._fields.Item(1)._result * Convert.ToDecimal(weight)
            Else
                price = oTmpDataBroker._fields.Item(1)._result
            End If

            If Not IsNothing(stone.Item("pricemulti")) Then
                price = price * Convert.ToInt32(stone.Item("pricemulti").InnerText)
            End If

            price += priceadd



        Else
            price = Convert.ToDecimal(stone.Item("price").InnerText)
        End If

        '' price = oTmpDataBroker._fields.Item(1)._result * Convert.ToDecimal(weight) + priceadd

    End Function

    Public Function GetTextWeightByStoneId(ByVal key As String, ByVal stripid As Int32, ByVal id As Int32, ByRef textweight As String, ByRef weight As String) As Boolean

        ''    Dim a As New WordLine.AllView




        Dim oxml As New ion_two.cls_nd_xmlread
        oxml.xml_file = Me.xml_file
        oxml.Load()

        Dim strip As XmlNode = oxml.GetNodes_ByPath("strip").Item(stripid)


        Dim stone As XmlNode = strip.SelectNodes("stone").Item(id)

        textweight = stone.Item("textweight").InnerText
        weight = stone.Item("weight").InnerText


    End Function

    Public Function GetXMLByKey(ByVal key As String, ByRef xml_path As String)

        Dim oxml As New ion_two.cls_nd_xmlread
        oxml.xml_file = Me.key_xml_file
        oxml.Load()

        xml_path = oxml.GetNode_ByPath("key[@name='" + key + "']").Attributes("xmlfile").InnerText
        xml_path = System.Web.HttpContext.Current.Server.MapPath(xml_path)

        Me.xml_file = xml_path

    End Function


    Public Function GetXMLByKey(ByVal key As String)

        Dim oxml As New ion_two.cls_nd_xmlread
        oxml.xml_file = Me.key_xml_file
        oxml.Load()

        Me.xml_file = oxml.GetNode_ByPath("key[@name='" + key + "']").Attributes("xmlfile").InnerText
        Me.xml_file = System.Web.HttpContext.Current.Server.MapPath(Me.xml_file)



    End Function

End Class
