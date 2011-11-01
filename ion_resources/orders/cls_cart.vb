Public Class cls_cart

    Private m_shopitem As New Collection()
    Private m_totalamount As Decimal
    Private m_oerror As Object
    Private m_dealer As Boolean
    Private m_connection_string As String
    Private m_categories As Collection
	Private m_cart_ready As Boolean
	Private m_clubbasket As Boolean	'--- when an club item is in the basket, we except only club item
	Public _backoffice As Boolean

    Function GetIdBatch(ByRef cBatch) As Boolean
        Dim xLoop As Integer
        cBatch = ""
        For xLoop = 1 To Me.shopitem.Count
            cBatch = cBatch + System.Convert.ToString(Me.shopitem(xLoop).id) + ","
        Next
    End Function


    Function FillCart(ByVal cIncomming As String) As Boolean
        Dim bError As Boolean = False

        Dim nTmpId As Int32
        Dim bAdditem As Boolean
        Dim nLoop As Integer
        For nLoop = 0 To cIncomming.Length
            nTmpId = getnumber(cIncomming)
            If nTmpId > 0 Then
                bError = ItemAdd(nTmpId)
                nLoop = cIncomming.Length
            Else
                cIncomming = cIncomming.Substring(1, cIncomming.Length - 1)
            End If

            If nLoop = 0 Then
                Exit For
            End If

        Next

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


    Function ItemRemove(ByVal nId As Int32, ByRef bRemoved As Boolean) As Boolean
        Dim bError As Boolean = False

		Dim nLoop As Integer
		For nLoop = 1 To Me.shopitem.Count
			If Me.shopitem.Item(nLoop).id = nId Then
				Me.shopitem.Remove(nLoop)
				bRemoved = True
				Exit For
			End If
		Next

		bError = recalc()


		'--- Check if there are club items
		For nLoop = 1 To Me.shopitem.Count
			If Me.shopitem(nLoop).clubitem Then
				Me.clubbasket = True
			End If
		Next

		'--- If no Items in Basket then clubbasket = false
		If Me.shopitem.Count = 0 Then
			Me.clubbasket = False
		End If

	End Function


	Function recalc() As Boolean
		'--- calculate total amount
		Dim nCount As Integer
		Me.totalamount = 0
		If Me.shopitem.Count > 0 Then
			For nCount = 1 To Me.shopitem.Count
				Me.totalamount = Me.totalamount + Me.shopitem(nCount).total_price
			Next
		End If
	End Function


    Function ItemAdd(ByVal nId As Int32, Optional ByVal nQty As Int32 = 1, Optional ByVal cJewelSize As String = "", Optional ByVal extrainfo As String = "None") As Boolean

        Dim bError As Boolean = False

        '--- Check if Item is in collection already
        Dim xLoop As Integer
        For xLoop = 1 To Me.shopitem.Count
            If nId = Me.shopitem(xLoop).id Then
                '--- Item already exist
                Return False
                Exit Function
            End If
        Next
        '--- Get item parameters
        Dim oTmpItem As New cls_getitem
        oTmpItem.itemid = nId
        oTmpItem.connection_string = Me.connection_string
        bError = oTmpItem.get_item()
        If oTmpItem.error_no = 5004 Then
            '--- Item not found
            oTmpItem = Nothing
            Return False
            Exit Function
        End If

        '--- restrict clubitems from mixing with regular items
        If Me.shopitem.Count > 0 Then
            If System.Convert.ToBoolean(oTmpItem.plate("club_item")) And Not Me.clubbasket Then
                Return False
                Exit Function

            ElseIf Not System.Convert.ToBoolean(oTmpItem.plate("club_item")) And Me.clubbasket Then
                Return False
                Exit Function

            End If
        End If

        '--- Level incomming Quantity
        If nQty = 0 Then
            nQty = 1
        End If

        '--- construct description
        Dim oDescrConstructor As New cls_cons_description
        oDescrConstructor.connection_string = Me.connection_string
        oDescrConstructor.id = nId
        oDescrConstructor.plate = oTmpItem.plate_no
        bError = oDescrConstructor.construct()

        '--- accept size only for jewelry
        If oTmpItem.plate_no <> 3 Then
            cJewelSize = ""
        End If
        '--- construct price
        'Dim oPriceConstructor As New cls_cons_itemprice()
        'oPriceConstructor.main_plate = oTmpItem.plate
        'oPriceConstructor.dealer = Me.dealer
        'bError = oPriceConstructor.getprice()

        '--- Construct price
        Dim oPriceConstructor As New ion_resources.cls_cons_price
        oPriceConstructor.purchase_price = 0
        oPriceConstructor.dealer_price = oTmpItem.plate("dealer_price")
        oPriceConstructor.sell_price = oTmpItem.plate("sell_price")
        oPriceConstructor.special_sell_price = oTmpItem.plate("special_sell_price")
        oPriceConstructor.special_dealer_price = oTmpItem.plate("special_dealer_price")
        oPriceConstructor.onspecial = oTmpItem.plate("onspecial")
        oPriceConstructor.onspecial_from = oTmpItem.plate("onspecial_from_date")
        oPriceConstructor.onbargain = oTmpItem.plate("onbargain")
        oPriceConstructor.onspecial_to = oTmpItem.plate("onspecial_to_date")

        '--- Get the correct price
        bError = oPriceConstructor.get_price(Me.dealer)


        '--- Read in
        '- (oTmpItem.plate("shopstatus") And Not oTmpItem.plate("itemdeleted")) OR (oTmpItem.plate("suppliernumber")=0 and oTmpItem.plate("branchnumber")=1)
        '- oTmpItem.plate("shopstatus") And Not oTmpItem.plate("itemdeleted") Then
        If Not oTmpItem.plate("itemdeleted") Or Me._backoffice Then
            'If oTmpItem.plate("qtyonstock_cur") > 0 Then
            '--- Define Row for Cart
            Dim oItem As New cls_cart_item

            oItem.id = System.Convert.ToInt32(oTmpItem.plate("id"))
            oItem.clubitem = System.Convert.ToBoolean(oTmpItem.plate("club_item"))
            oItem.notalone = System.Convert.ToBoolean(oTmpItem.plate("no_orderalone"))
            oItem.itemnumber = System.Convert.ToString(oTmpItem.plate("itemnumber"))
            oItem.description = oDescrConstructor.description
            oItem.price = oPriceConstructor.correct_price
            oItem.max_quantity = System.Convert.ToInt32(oTmpItem.plate("qtyonstock_cur"))
            oItem.quantity = nQty
            oItem.jewelsize = cJewelSize
            If System.Convert.ToString(oTmpItem.plate("icon_name")) <> "" Then
                oItem.icon = Me.categories.Item(System.Convert.ToInt32(oTmpItem.plate("category_id"))).relative_path + System.Convert.ToString(oTmpItem.plate("icon_name"))
            Else
                oItem.icon = ""
            End If
'            Dim oExtra As New cls_jewerly_extra
'            Select Case oExtra.get_extrainfo_type(extrainfo)
'                Case "None" '' the case that there are no changes
'                    Exit Select
'                Case "IDX"
'                    oItem.description = oExtra.get_savestr_params(extrainfo, 1)
'                    oItem.price = oExtra.get_savestr_params(extrainfo, 2)
'                Case "EXT"
'                    oItem.price = oExtra.get_savestr_params(extrainfo, 2)
'                    oItem.description = oItem.description + "<br>" + oExtra.get_savestr_params(extrainfo, 1)
'                Case "MDP"
'                    oItem.price = oExtra.get_savestr_params(extrainfo, 3)
'                    oItem.description = oExtra.get_savestr_params(extrainfo, 1)
'                Case "DGS"
'                    oItem.price = oExtra.get_savestr_params(extrainfo, 3)
'                    oItem.description = "This is a setting in :" + oExtra.get_savestr_params(extrainfo, 4)
'            End Select



            '--- Set Basket to Club
            If oItem.clubitem Then
                Me.clubbasket = True
            End If

            '--- Calculate total_price
            oItem.total_price = oItem.price * oItem.quantity

            '--- Add item to collection
            Me.shopitem.Add(oItem)

            'End If
        End If

        '--- calculate total amount
        Dim nCount As Integer
        Me.totalamount = 0
        If Me.shopitem.Count > 0 Then
            For nCount = 1 To Me.shopitem.Count
                Me.totalamount = Me.totalamount + Me.shopitem(nCount).total_price
            Next
        End If

        oTmpItem = Nothing
        oDescrConstructor = Nothing
        oPriceConstructor = Nothing

    End Function


    Public Property shopitem() As Collection
        Get
            Return m_shopitem
        End Get

        Set(ByVal Value As Collection)
            m_shopitem = Value
        End Set
    End Property

    Public Property totalamount() As Decimal
        Get
            Return m_totalamount
        End Get

        Set(ByVal Value As Decimal)
            m_totalamount = Value
        End Set
    End Property

    Public Property oerror() As Object
        Get
            Return m_oerror
        End Get

        Set(ByVal Value As Object)
            m_oerror = Value
        End Set
    End Property

    Public Property connection_string() As String
        Get
            Return m_connection_string
        End Get

        Set(ByVal Value As String)
            m_connection_string = Value
        End Set
    End Property

    Public Property dealer() As Boolean
        Get
            Return m_dealer
        End Get

        Set(ByVal Value As Boolean)
            m_dealer = Value
        End Set
    End Property

    Public Property categories() As Collection
        Get
            Return m_categories
        End Get

        Set(ByVal Value As Collection)
            m_categories = Value
        End Set
    End Property

    Public Property cart_ready() As Boolean
        Get
            Return m_cart_ready
        End Get

        Set(ByVal Value As Boolean)
            m_cart_ready = Value
        End Set
    End Property

    Public Property clubbasket() As Boolean
        Get
            Return m_clubbasket
        End Get

        Set(ByVal Value As Boolean)
            m_clubbasket = Value
        End Set
    End Property

End Class


Public Class cls_cart_item
	Private m_id As Int32
	Private m_description As String
	Private m_quantity As Integer
	Private m_max_quantity As Integer
	Private m_price As Decimal
	Private m_total_price As Decimal
	Private m_jewelsize As String
	Private m_clubitem As Boolean
	Private m_notalone As Boolean
	Private m_itemnumber As String
    Private m_icon As String
    Private m_extrainfo As String


	Public Property id() As Int32
		Get
			Return m_id
		End Get

		Set(ByVal Value As Int32)
			m_id = Value
		End Set
	End Property

	Public Property description() As String
		Get
			Return m_description
		End Get

		Set(ByVal Value As String)
			m_description = Value
		End Set
	End Property

	Public Property quantity() As Integer
		Get
			Return m_quantity
		End Get

		Set(ByVal Value As Integer)
			m_quantity = Value
		End Set
	End Property

	Public Property max_quantity() As Integer
		Get
			Return m_max_quantity
		End Get

		Set(ByVal Value As Integer)
			m_max_quantity = Value
		End Set
	End Property

	Public Property price() As Decimal
		Get
			Return m_price
		End Get

		Set(ByVal Value As Decimal)
			m_price = Value
		End Set
	End Property

	Public Property total_price() As Decimal
		Get
			Return m_total_price
		End Get

		Set(ByVal Value As Decimal)
			m_total_price = Value
		End Set
	End Property

	Public Property jewelsize() As String
		Get
			Return m_jewelsize
		End Get

		Set(ByVal Value As String)
			m_jewelsize = Value
		End Set
	End Property

	Public Property clubitem() As Boolean
		Get
			Return m_clubitem
		End Get

		Set(ByVal Value As Boolean)
			m_clubitem = Value
		End Set
	End Property

	Public Property notalone() As Boolean
		Get
			Return m_notalone
		End Get

		Set(ByVal Value As Boolean)
			m_notalone = Value
		End Set
	End Property

	Public Property itemnumber() As String
		Get
			Return m_itemnumber
		End Get

		Set(ByVal Value As String)
			m_itemnumber = Value
		End Set
	End Property

	Public Property icon() As String
		Get
			Return m_icon
		End Get

		Set(ByVal Value As String)
			m_icon = Value
		End Set
	End Property
    Public Property extrainfo() As String
        Get
            Return m_extrainfo
        End Get

        Set(ByVal Value As String)
            m_extrainfo = Value
        End Set
    End Property
End Class