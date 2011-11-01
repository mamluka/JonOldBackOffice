Imports System.Web
Public Class cls_shopping_cart
    Inherits iFoundation.cls_error_connection

    Public _shopitem As New Collection
    Public _shop_mod_item As New Collection ' 'add this to be able to add some modded items
    Public _pictures As New ion_two.cls_pictures
    Public _totalamount As Decimal
    Public _isdealer As Boolean
    Public _cart_ready As Boolean
    Public _clubbasket As Boolean '--- when an club item is in the basket, we except only club item
    Public _backoffice As Boolean
    Public _def_idex As cls_idex '' idex fed value for system use
    Public oExtra_info As New cls_stone_ext


    Sub New()
        Me._totalamount = 0
        Me._isdealer = False
        Me._cart_ready = True
        Me._clubbasket = False
        Me._backoffice = False
        Me._def_idex = New cls_idex(1111, 1, "def", "def", "def", "def", "def")

    End Sub

    Public Function add_item(ByVal nId As Int32, Optional ByVal idex As cls_idex = Nothing, Optional ByVal nQuantity As Int32 = 1, Optional ByVal cJewelsize As String = "", Optional ByVal bSSL As Boolean = False) As Boolean
        On Error GoTo ErrorHandler
        Dim bError As Boolean = False

        '--- Check if Item allready Exists
        Dim nItemLoop As Int16
        For nItemLoop = 1 To Me._shopitem.Count
            If Me._shopitem(nItemLoop)._id = nId Then
                Return False
                Exit Function
            End If
        Next


        '--- Give JewelrySize a string value
        If IsNothing(cJewelsize) Then
            cJewelsize = ""
        End If


        '--- Get item
        Dim oPlate As New ion_two.skl_lst_inventory
        Dim oTmpInventory As New ion_two.cls_inventory_lgc
        oTmpInventory._connection_string = Me._connection_string
        oTmpInventory._dbtype = Me._dbtype
        ''set a def item for idex standart 2190
        If (Not idex Is Nothing) Then
            If idex._idexid <> 1111 Then
                Dim shapeid As Int32
                Select Case idex._cut
                    Case "Round"
                        shapeid = 5727
                        '';shapeid = 5218
                    Case "Oval"
                        shapeid = 5728
                    Case "Princess"
                        shapeid = 5729
                    Case "Pear"
                        shapeid = 5730
                    Case "Heart"
                        shapeid = 5731
                    Case "Emerald"
                        shapeid = 5732
                    Case Else
                        shapeid = 5733
                End Select

                bError = oTmpInventory.load(shapeid, oPlate, Me._pictures, Me._isdealer, bSSL)
            Else
                bError = oTmpInventory.load(nId, oPlate, Me._pictures, Me._isdealer, bSSL)
            End If

        Else
            bError = oTmpInventory.load(nId, oPlate, Me._pictures, Me._isdealer, bSSL)
        End If
        If bError Then
            Me._err_number = oTmpInventory._err_number
            Me._err_description = oTmpInventory._err_description
            Me._err_source = oTmpInventory._err_source
            Return True
        End If

        '--- Set Basket to Club
        If oPlate._club_item Then
            Me._clubbasket = True
        Else
            Me._clubbasket = False
        End If


        '--- Get correct price
        Dim oPriceConstructor As New ion_two.cons_price
        oPriceConstructor._sell_price = oPlate._sell_price
        oPriceConstructor._special_sell_price = oPlate._special_sell_price
        oPriceConstructor._dealer_price = oPlate._dealer_price
        oPriceConstructor._special_dealer_price = oPlate._special_dealer_price
        oPriceConstructor._isspecial = oPlate._onspecial
        oPriceConstructor._special_from = oPlate._onspecial_from_date
        oPriceConstructor._special_to = oPlate._onspecial_to_date
        oPriceConstructor._isdealer = Me._isdealer
        bError = oPriceConstructor.get_price()
        If bError Then
            Me._err_number = oPriceConstructor._err_number
            Me._err_description = oPriceConstructor._err_description
            Me._err_source = oPriceConstructor._err_source
            Return True
        End If

        If oPlate.onbargain Then
            oPriceConstructor._correct_price = oPlate._special_sell_price
        End If
        '--- Create a new Cart Item
        Dim oCartItem As New cls_cart_item

        oCartItem._id = oPlate._id
        oCartItem._clubitem = oPlate._club_item
        oCartItem._notalone = oPlate._no_orderalone
        oCartItem._itemnumber = oPlate._itemnumber
        ''set desc for idex item it's not same as normal item
        If Not idex Is Nothing Then
            If idex._idexid <> 1111 Then
                oCartItem._description = idex._description
                oCartItem._price = idex._price
                oCartItem._extrainfo = "IDX|" + Convert.ToString(idex._idexid) + "|" + Convert.ToString(idex._price) + "|"
                oCartItem._nolink = True
            Else
                oCartItem._description = oPlate._item_description
                oCartItem._price = oPriceConstructor._correct_price
            End If

        Else
            oCartItem._description = oPlate._item_description
            oCartItem._price = oPriceConstructor._correct_price
        End If

        If HttpContext.Current.Session("ext_info").is_extra_info(oPlate._id) Then
            oCartItem._price = HttpContext.Current.Session("ext_info").get_extra_price
            oCartItem._extrainfo = HttpContext.Current.Session("ext_info").get_ext_savestr
        End If


        ''check if changed item

        ''oExtra_info = HttpContext.Current.Session("extra_info")
        ''If oExtra_info.is_extra_info(oPlate._id) Then
        ''ocartitem._description = oextra_info.
        ''End If
        oCartItem._max_quantity = oPlate._qtyonstock_cur
        oCartItem._quantity = nQuantity
        oCartItem._jewelsize = cJewelsize
        oCartItem._icon = oPlate._icon_pic
        oCartItem._ssl_icon = oPlate._ssl_icon_pic
        oCartItem._total_price = oCartItem._price * oCartItem._quantity

        '--- Add to collection
        Me._shopitem.Add(oCartItem)



        '--- release
        oPriceConstructor = Nothing
        oPlate = Nothing

        Return False
        Exit Function

ErrorHandler:
        Me._err_number = Err.Number
        Me._err_description = Err.Description
        Me._err_source = Err.Source
        Return True
    End Function

    Public Function add_mod_item(ByVal nId As Int32, ByVal modid As Int16, ByVal omodInfo As Object, Optional ByVal nQuantity As Int32 = 1, Optional ByVal cJewelsize As String = "", Optional ByVal bSSL As Boolean = False) As Boolean
        On Error GoTo ErrorHandler
        Dim bError As Boolean = False


        ''--- Check if Item allready Exists
        Select Case modid
            Case 3
                Dim nItemLoop As Int16
                For nItemLoop = 1 To Me._shopitem.Count
                    If Me._shopitem(nItemLoop)._id = nId Then
                        Return False
                        Exit Function
                    End If
                Next
        End Select
        '''check for dual idex items
        'For nItemLoop = 1 To Me._shopitem.Count
        '    If Me._shopitem(nItemLoop)._idexid = nId Then
        '        Return False
        '        Exit Function
        '    End If
        'Next

        '--- Give JewelrySize a string value
        If IsNothing(cJewelsize) Then
            cJewelsize = ""
        End If


        '--- Get item
        Dim oPlate As New ion_two.skl_lst_inventory
        Dim oTmpInventory As New ion_two.cls_inventory_lgc
        oTmpInventory._connection_string = Me._connection_string
        oTmpInventory._dbtype = Me._dbtype
        bError = oTmpInventory.load(nId, oPlate, Me._pictures, Me._isdealer, bSSL)
        If bError Then
            Me._err_number = oTmpInventory._err_number
            Me._err_description = oTmpInventory._err_description
            Me._err_source = oTmpInventory._err_source
            Return True
        End If

        '--- Set Basket to Club
        If oPlate._club_item Then
            Me._clubbasket = True
        Else
            Me._clubbasket = False
        End If


        '--- Get correct price
        Dim oPriceConstructor As New ion_two.cons_price
        oPriceConstructor._sell_price = oPlate._sell_price
        oPriceConstructor._special_sell_price = oPlate._special_sell_price
        oPriceConstructor._dealer_price = oPlate._dealer_price
        oPriceConstructor._special_dealer_price = oPlate._special_dealer_price
        oPriceConstructor._isspecial = oPlate._onspecial
        oPriceConstructor._special_from = oPlate._onspecial_from_date
        oPriceConstructor._special_to = oPlate._onspecial_to_date
        oPriceConstructor._isdealer = Me._isdealer
        bError = oPriceConstructor.get_price()
        If bError Then
            Me._err_number = oPriceConstructor._err_number
            Me._err_description = oPriceConstructor._err_description
            Me._err_source = oPriceConstructor._err_source
            Return True
        End If


        '--- Create a new Cart Item
        Dim oCartItem As New cls_cart_item


        oCartItem._id = oPlate._id
        oCartItem._clubitem = oPlate._club_item
        oCartItem._notalone = oPlate._no_orderalone
        oCartItem._itemnumber = oPlate._itemnumber
        oCartItem._max_quantity = oPlate._qtyonstock_cur
        oCartItem._quantity = nQuantity
        oCartItem._jewelsize = cJewelsize
        oCartItem._icon = oPlate._icon_pic
        oCartItem._ssl_icon = oPlate._ssl_icon_pic
        oCartItem._total_price = oCartItem._price * oCartItem._quantity
        oCartItem._price = oPriceConstructor._correct_price
        oCartItem._description = oPlate._item_description
        Select Case modid
            Case 1
                oCartItem._description = omodInfo.description
                oCartItem._price = omodInfo.price
                oCartItem._extrainfo = omodInfo.extrainfo
                oCartItem._nolink = True
                oCartItem.no_itemnumber = True
            Case 2 '' the case of setting style that comes from CJ and can have pic that is non  DB

                oCartItem._description = omodInfo.description
                oCartItem._price = omodInfo.price
                oCartItem._extrainfo = omodInfo.extrainfo
                oCartItem._nolink = True
                oCartItem._icon = omodInfo.picsrc
                oCartItem._jewelsize = omodInfo.set_ring_size
                oCartItem.no_itemnumber = True
                ''   If nId = 5836 Then ''if the setting is the special change item

                '' Else
                ''oCartItem._icon = omodInfo.picsrc
            Case 3 '' SE stone
                ''                oCartItem._description = oPlate._subcategory_name + " " + oPlate._category_name + "<br>"
                ''make complex desc
                oCartItem._description += omodInfo.description

            Case 4 '' SE setting

                oCartItem._price = omodInfo.price

                Dim tmpdesc As String = oPlate._item_description
                Dim tmpdesc2() As String

                tmpdesc = tmpdesc.Replace("<br>", "^")

                tmpdesc2 = tmpdesc.Split("^")

                tmpdesc = tmpdesc2(0) + "<br>" + tmpdesc2(1) + "<br>"
                ''   Dim oextra As New cls_jewerly_extra

                ''  oextra.get_stone_extended_string(oPlate._subplate._stone_extended)

                If oPlate._subplate._jewel_extended.ss_desc <> "" Then
                    tmpdesc += "<b>Including Side Stones:<br>"
                    tmpdesc += oPlate._subplate._jewel_extended.ss_type + " " + oPlate._subplate._jewel_extended.ss_desc + ", " + oPlate._subplate._jewel_extended.ss_cut + "</b>"
                End If
                oCartItem._description = tmpdesc
        End Select




        '--- Add to collection
        Me._shopitem.Add(oCartItem)


        '--- release
        oPriceConstructor = Nothing
        oPlate = Nothing

        Return False
        Exit Function

ErrorHandler:
        Me._err_number = Err.Number
        Me._err_description = Err.Description
        Me._err_source = Err.Source
        Return True
    End Function

    Public Function recalc() As Boolean
        On Error GoTo ErrorHandler
        Dim bError As Boolean = False

        '--- calculate total amount
        Dim nCount As Integer
        Me._totalamount = 0
        If Me._shopitem.Count > 0 Then
            For nCount = 1 To Me._shopitem.Count
                Me._totalamount = Me._totalamount + Me._shopitem(nCount)._total_price
            Next
        End If

        Return False
        Exit Function

ErrorHandler:
        Me._err_number = Err.Number
        Me._err_description = Err.Description
        Me._err_source = Err.Source
        Return True
    End Function

    Function ItemRemove(ByVal nId As Int32, ByRef bRemoved As Boolean) As Boolean
        On Error GoTo ErrorHandler
        Dim bError As Boolean = False


        '--- Remove item
        Dim nLoop As Integer
        For nLoop = 1 To Me._shopitem.Count
            If Me._shopitem.Item(nLoop)._id = nId Then
                Me._shopitem.Remove(nLoop)
                bRemoved = True
                Exit For
            End If
        Next

        '--- Recalc
        bError = Me.recalc()
        If bError Then
            Return True
        End If


        '--- Check if there are club items
        For nLoop = 1 To Me._shopitem.Count
            If Me._shopitem(nLoop)._clubitem Then
                Me._clubbasket = True
            End If
        Next

        '--- If no Items in Basket then clubbasket = false
        If Me._shopitem.Count = 0 Then
            Me._clubbasket = False
        End If

        Return False
        Exit Function

ErrorHandler:
        Me._err_number = Err.Number
        Me._err_description = Err.Description
        Me._err_source = Err.Source
        Return True

    End Function

    Function FillCart(ByVal cIncomming As String) As Boolean
        On Error GoTo ErrorHandler
        Dim bError As Boolean = False

        Dim nTmpId As Int32
        Dim bAdditem As Boolean
        Dim nLoop As Integer
        For nLoop = 0 To cIncomming.Length
            nTmpId = Me.getnumber(cIncomming)
            If nTmpId > 0 Then
                bError = Me.add_item(nTmpId, Me._def_idex)
                nLoop = cIncomming.Length
            Else
                cIncomming = cIncomming.Substring(1, cIncomming.Length - 1)
            End If

            If nLoop = 0 Then
                Exit For
            End If

        Next

        Return False
        Exit Function

ErrorHandler:
        Me._err_number = Err.Number
        Me._err_description = Err.Description
        Me._err_source = Err.Source
        Return True

    End Function

    Private Function getnumber(ByRef cTmpString As String) As Int32

        Dim cTmpResult As String
        Dim nLoop As Integer
        Do
            If IsNumeric(cTmpString.Substring(nLoop, 1)) Then
                cTmpResult = cTmpResult + cTmpString.Substring(nLoop, 1)
                nLoop = nLoop + 1
            Else
                Exit Do
            End If
        Loop Until nLoop = cTmpString.Length

        cTmpString = cTmpString.Substring(nLoop, cTmpString.Length - nLoop)

        Return System.Convert.ToInt32(cTmpResult)
    End Function

End Class


Public Class cls_cart_item
    Public _id As Int32
    Public _description As String
    Public _quantity As Integer
    Public _max_quantity As Integer
    Public _price As Decimal
    Public _total_price As Decimal
    Public _clubitem As Boolean
    Public _notalone As Boolean
    Public _itemnumber As String
    Public _jewelsize As String
    Public _icon As String
    Public _ssl_icon As String
    Public _idexid As String = "1000"
    Public _extrainfo As String
    Public _nolink As Boolean
    Public no_itemnumber As Boolean

    Sub New()
        Me._id = 0
        Me._description = ""
        Me._quantity = 0
        Me._max_quantity = 0
        Me._price = 0
        Me._total_price = 0
        Me._clubitem = False
        Me._notalone = False
        Me._itemnumber = ""
        Me._jewelsize = ""
        Me._icon = ""
        Me._ssl_icon = ""
        Me._extrainfo = ""
        Me._nolink = False
        Me.no_itemnumber = False
    End Sub
End Class