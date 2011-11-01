Public Class cls_cons_itemprice
    '--- OLD MODULE NOT IN USE ----


    Private m_oerror As Object
    Private m_main_plate As DataRow
    Private m_price As Decimal
    Private m_dealer As Boolean

    Function getprice() As Boolean

        Dim bError As Boolean = False

        '--- declare price constructor
        Dim oTmpPrice As New ion_resources.cls_cons_price()
        oTmpPrice.purchase_price = 0
        oTmpPrice.dealer_price = Me.main_plate("dealer_price")
        oTmpPrice.sell_price = Me.main_plate("sell_price")
        oTmpPrice.special_sell_price = Me.main_plate("special_sell_price")
        oTmpPrice.special_dealer_price = Me.main_plate("special_dealer_price")
        oTmpPrice.onspecial = Me.main_plate("onspecial")
        oTmpPrice.onspecial_from = Me.main_plate("onspecial_from_date")
        oTmpPrice.onspecial_to = Me.main_plate("onspecial_to_date")

        '--- Get the correct price
        bError = oTmpPrice.get_price(Me.dealer)
        Me.price = Convert.ToString(Format(oTmpPrice.correct_price, "##,##0.00"))

        oTmpPrice = Nothing



        'If Me.dealer Then
        'Me.price = Convert.ToString(Format(Me.main_plate("dealer_price"), "##,##0.00"))
        'Else
        '    Me.price = Convert.ToString(Format(Me.main_plate("sell_price"), "##,##0.00"))
        'End If


        '--- if special
        'If Me.main_plate("onspecial") Then
        'If Today.Date >= Me.main_plate("onspecial_from_date") And Today.Date <= Me.main_plate("onspecial_to_date") Then
        '   If Me.dealer Then
        'Me.price = Convert.ToString(Format(Me.main_plate("special_dealer_price"), "##,##0.00"))

        '   Else
        '      Me.price = Convert.ToString(Format(Me.main_plate("special_sell_price"), "##,##0.00"))

        '  End If
        'End If
        'End If

    End Function


    Public Property oerror() As Object
        Get
            Return m_oerror
        End Get

        Set(ByVal Value As Object)
            m_oerror = Value
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

    Public Property main_plate() As DataRow
        Get
            Return m_main_plate
        End Get

        Set(ByVal Value As DataRow)
            m_main_plate = Value
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

End Class
