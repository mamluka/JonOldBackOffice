Public Class cls_quick_search

    Private m_search_string As String
    Private m_connection_string As String
    Private m_error_number As Int32
    Private m_error_source As String
    Private m_error_description As String

    Private m_itemtype As String
    Private m_shape As String
    Private m_price As Int32
    Private m_isdealer As Boolean
    Private m_validation_error As Boolean


    '###################################################################################
    Public Function get_inventory() As Boolean
        On Error GoTo ErrorHandler
        Dim bError As Boolean = False

		Dim cSQL As String = "select top 50 * from v_inventory_category_list where shopstatus=1 "


        If Me.ItemType <> "-" Then
            cSQL = cSQL + " and stonetype like '%" + Me.ItemType + "%'"
        End If


        If Me.shape <> "-" Then
            cSQL = cSQL + " and shape = '" + Me.shape + "'"
        End If


        If Me.price < 6 Then

            Dim nPriceFrom As Decimal
            Dim nPriceTo As Decimal

            Select Case Me.price
                Case 1    '--- to 500
                    nPriceFrom = 0
                    nPriceTo = 500

                Case 2    '--- 500 - 1000
                    nPriceFrom = 500
                    nPriceTo = 1000

                Case 3    '--- 1000 - 1500
                    nPriceFrom = 1000
                    nPriceTo = 1500

                Case 4    '--- 1500 - 2000
                    nPriceFrom = 1500
                    nPriceTo = 2000

                Case 5    '--- 2000 - up
                    nPriceFrom = 2000
                    nPriceTo = 999999999

            End Select

            If Me.isdealer Then
                cSQL = cSQL + " and dealer_price between " + Convert.ToString(nPriceFrom) + " and " + Convert.ToString(nPriceTo)
            Else
                cSQL = cSQL + " and sell_price between " + Convert.ToString(nPriceFrom) + " and " + Convert.ToString(nPriceTo)
            End If



        End If


		Me.search_string = cSQL
        Me.validation_error = False


        Return False
        Exit Function

ErrorHandler:
        Me.error_number = Err.Number
        Me.error_description = Err.Description
        Me.error_source = Err.Source
        Return True

    End Function



    Public Property search_string() As String
        Get
            Return m_search_string
        End Get

        Set(ByVal Value As String)
            m_search_string = Value
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

    Public Property ItemType() As String
        Get
            Return m_itemtype
        End Get

        Set(ByVal Value As String)
            m_itemtype = Value
        End Set
    End Property

    Public Property shape() As String
        Get
            Return m_shape
        End Get

        Set(ByVal Value As String)
            m_shape = Value
        End Set
    End Property

    Public Property price() As Int32
        Get
            Return m_price
        End Get

        Set(ByVal Value As Int32)
            m_price = Value
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


    Public Property validation_error() As Boolean
        Get
            Return m_validation_error
        End Get

        Set(ByVal Value As Boolean)
            m_validation_error = Value
        End Set
    End Property

End Class
