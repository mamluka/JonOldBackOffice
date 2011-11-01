Public Class cls_cons_price
    '--- This is a new version of the price constructer

    '--- Default properties for every class
    Private m_connection_string As String
    Private m_error_number As Int32
    Private m_error_source As String
    Private m_error_description As String

    Private m_purchase_price As Decimal
    Private m_sell_price As Decimal
    Private m_dealer_price As Decimal
    Private m_special_sell_price As Decimal
    Private m_special_dealer_price As Decimal
    Private m_correct_price As Decimal
    Private m_onspecial As Boolean
    Private m_onspecial_from As DateTime
    Private m_onspecial_to As DateTime
    Private m_isdealer As Boolean
    Private m_onbargain As Boolean



    Function get_price(ByVal bIsDealer As Boolean) As Boolean

        If bIsDealer Then
            Me.isdealer = True
            Me.correct_price = Me.dealer_price
        Else
            Me.isdealer = False
            Me.correct_price = Me.sell_price
        End If


        '--- if special
        If Me.onspecial Then
            If Today.Date >= Me.onspecial_from And Today.Date <= Me.onspecial_to Then
                If bIsDealer Then
                    Me.correct_price = Me.special_dealer_price

                Else
                    Me.correct_price = Me.special_sell_price

                End If
            End If
        Else
            If Me.onbargain Then
                Me.correct_price = Me.special_sell_price
            End If
        End If

    End Function


    Public Property onspecial_to() As DateTime
        Get
            Return m_onspecial_to
        End Get

        Set(ByVal Value As DateTime)
            m_onspecial_to = Value
        End Set
    End Property

    Public Property onspecial_from() As DateTime
        Get
            Return m_onspecial_from
        End Get

        Set(ByVal Value As DateTime)
            m_onspecial_from = Value
        End Set
    End Property

    Public Property onspecial() As Boolean
        Get
            Return m_onspecial
        End Get

        Set(ByVal Value As Boolean)
            m_onspecial = Value
        End Set
    End Property

    Public Property correct_price() As Decimal
        Get
            Return m_correct_price
        End Get

        Set(ByVal Value As Decimal)
            m_correct_price = Value
        End Set
    End Property

    Public Property special_dealer_price() As Decimal
        Get
            Return m_special_dealer_price
        End Get

        Set(ByVal Value As Decimal)
            m_special_dealer_price = Value
        End Set
    End Property

    Public Property special_sell_price() As Decimal
        Get
            Return m_special_sell_price
        End Get

        Set(ByVal Value As Decimal)
            m_special_sell_price = Value
        End Set
    End Property

    Public Property dealer_price() As Decimal
        Get
            Return m_dealer_price
        End Get

        Set(ByVal Value As Decimal)
            m_dealer_price = Value
        End Set
    End Property

    Public Property sell_price() As Decimal
        Get
            Return m_sell_price
        End Get

        Set(ByVal Value As Decimal)
            m_sell_price = Value
        End Set
    End Property

    Public Property purchase_price() As Decimal
        Get
            Return m_purchase_price
        End Get

        Set(ByVal Value As Decimal)
            m_purchase_price = Value
        End Set
    End Property

    '---
    Public Property connection_string() As String
        Get
            Return m_connection_string
        End Get

        Set(ByVal Value As String)
            m_connection_string = Value
        End Set
    End Property

    Public Property error_number() As Int32
        Get
            Return m_error_number
        End Get

        Set(ByVal Value As Int32)
            m_error_number = Value
        End Set
    End Property

    Public Property error_description() As String
        Get
            Return m_error_description
        End Get

        Set(ByVal Value As String)
            m_error_description = Value
        End Set
    End Property

    Public Property error_source() As String
        Get
            Return m_error_source
        End Get

        Set(ByVal Value As String)
            m_error_source = Value
        End Set
    End Property

    Public Property isdealer() As Boolean
        Get
            Return m_isdealer
        End Get

        Set(ByVal Value As Boolean)
            m_isdealer = Value
        End Set
    End Property

    Public Property onbargain() As Boolean
        Get
            Return m_onbargain
        End Get

        Set(ByVal Value As Boolean)
            m_onbargain = Value
        End Set
    End Property
End Class
