Imports System.IO
Partial Class fancydiamondsnet
    Inherits System.Web.UI.Page

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

    Public Function ReadFileToArrayList(ByVal filename As String, ByVal array As ArrayList) As Boolean


        Dim fs As FileStream = File.OpenRead(filename)

        Dim sr As StreamReader = New StreamReader(fs)

        While sr.Peek() > -1
            array.Add(sr.ReadLine)
        End While

        sr.Close()
        fs.Close()

    End Function

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim array As New ArrayList
        Me.ReadFileToArrayList(Me.csv_file.Value, array)

        Dim shapehash As New Hashtable

        shapehash.Add("round", 2)
        shapehash.Add("princess", 3)
        shapehash.Add("emerald", 5)
        shapehash.Add("marquise", 6)
        shapehash.Add("oval", 7)
        shapehash.Add("pear", 9)
        shapehash.Add("trillain", 9)
        shapehash.Add("cushion", 10)
        shapehash.Add("taper", 16)
        shapehash.Add("asscher", 17)
        shapehash.Add("heart", 12)
        shapehash.Add("radiant", 4)
        shapehash.Add("shield", 28)
        shapehash.Add("traingle", 29)
        shapehash.Add("octagon", 29)
        shapehash.Add("tralliant", 9)



        Dim certhash As New Hashtable

        certhash.Add("GIA", 2)
        certhash.Add("IGI", 5)
        certhash.Add("Other", 1)



        Dim item_array As New ArrayList

        For Each item As String In array
            Dim tmpitem As New fancy_obj
            Dim fields() As String = item.Split(",")
            Dim i As Int32
            For i = 0 To fields.Length - 1
                fields(i) = fields(i).Replace("|", ",")
            Next

            tmpitem.freecolor = fields(3)
            tmpitem.supplier_code = fields(0) + "/" + fields(2)

            tmpitem.sell_price = Convert.ToDecimal(fields(8))
            tmpitem.weight = fields(7)
            tmpitem.note = fields(4)
            If IsNumeric(fields(21)) Then
                tmpitem.h = Convert.ToDecimal(fields(21))
            End If
            If IsNumeric(fields(22)) Then
                tmpitem.w = Convert.ToDecimal(fields(22))
            End If
            If IsNumeric(fields(23)) Then
                tmpitem.d = Convert.ToDecimal(fields(23))
            End If
            tmpitem.cert = fields(13).Split(" ")(0)
            tmpitem.image = fields(11).Split(" ")(0)
            tmpitem.shape = fields(26)

            item_array.Add(tmpitem)









        Next

        ''inset items
        Dim oplate As New ion_two.skl_inventory
        '--- SAVE
        Dim oTmpInventoryLogics As New ion_two.cls_inventory_lgc
        oTmpInventoryLogics._connection_string = Application("config").connection_string
        oTmpInventoryLogics._dbtype = Application("config").connection_string_type



        For Each item As fancy_obj In item_array

            oplate._sell_price = item.sell_price
            oplate._dealer_price = item.sell_price
            oplate._purchase_price = Math.Floor(item.sell_price * 0.9)

            oplate._notes = item.note
            oplate._itemcode = item.supplier_code
            oplate._smartsort_txt = "fancydiamonds.net"

            oplate._category_id = 2
            oplate._subcategory_id = 6

            oplate._active = True
            oplate._qtyonstock_cur = 1
            oplate._qtyonstock_min = 1
            oplate._createdate = Convert.ToDateTime(Now)
            oplate._lastmodify_user = Convert.ToString(Session("user").user_name)
            oplate._lastmodify_date = Convert.ToDateTime(Now)
            oplate._lastmodify_user_id = Convert.ToInt16(Session("user").user_id)
            oplate.release_date = Convert.ToDateTime(Now)
            oplate._branchnumber = 1
            oplate._suppliernumber = 44
            oplate._platetype = 1
            Dim osub As New ion_two.skl_diamond

            osub.fancy_freetxt = item.freecolor
            osub._weight = item.weight
            If shapehash.ContainsKey(item.shape.ToLower) Then
                osub._shape_id = shapehash(item.shape.ToLower)
            Else
                osub._shape_id = 1
            End If

            If Not IsNothing(item.report) Then
                If certhash.ContainsKey(item.report) Then
                    osub._report_id = certhash(item.report)
                Else
                    osub._report_id = 1
                End If
            Else
                osub._report_id = 1
            End If

            osub._report_id = 2
            osub._measure1from = item.h
            osub._measure2from = item.w
            osub._measure3from = item.d
            osub._clarity_id = 1
            osub._color_id = 1
            osub._culet_id = 1
            osub._fluorecence_id = 1
            osub._girdle_id = 1
            osub._polish_id = 1
            osub._quantity = 1
            osub._stonetype_id = 2
            osub._symmetry_id = 1

            oplate._subplate = osub
            oTmpInventoryLogics.insert(oplate)
        Next


    End Sub



End Class
Public Class fancy_obj

    Public freecolor As String
    Public supplier_code As String
    Public note As String
    Public weight As Decimal
    Public sell_price As Decimal
    Public report As String
    Public image As String
    Public cert As String
    Public h As Decimal = 0
    Public w As Decimal = 0
    Public d As Decimal = 0
    Public clarity As String
    Public shape As String



End Class
