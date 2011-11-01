Public Class cls_payment_calc
    '--- This module calculates all payments on a certain order

	Private m_error_no As Integer
	Private m_error_desc As String
	Private m_error_source As String
	Private m_connection_string As String

	Private m_order_number As Int32
    Private m_order_total As Decimal        '--- The total of the order
    Private m_order_total_payed As Decimal  '--- Total amount payed up till now
    Private m_order_left_to_pay As Decimal  '--- Total amount left to pay not including Interest
    Private m_order_total_left_to_pay As Decimal  '--- Total amount left to pay including Interest
    Private m_order_initial_payment As Decimal  '--- The initial payment that was made
    Private m_order_interest As Decimal  '--- Amount of interest calculated from order_total

    Private m_user_id As Int32
    Private m_payment_type As Int32
	Private m_payment_name As String

    Public Function calc_order(ByVal nOrder_id As Int32) As Boolean
        'On Error GoTo ErrorHandler
        Dim bError As Boolean = False

        Dim oTmpOrderFunctions As New ion_resources.cls_functions_order()
        oTmpOrderFunctions.connection_string = Me.connection_string

        '--- Get Order number
        bError = oTmpOrderFunctions.get_ordernumber(nOrder_id, Me.m_order_number)
        If bError Then
            Me.error_no = Err.Number
            Me.error_desc = Err.Description
            Me.error_source = Err.Source
            Return True
        End If


        '--- Get Order Total Amount
        bError = oTmpOrderFunctions.get_order_total(nOrder_id, Me.order_total)
        If bError Then
            Me.error_no = Err.Number
            Me.error_desc = Err.Description
            Me.error_source = Err.Source
            Return True
        End If

        '--- Get Order User Id
        bError = oTmpOrderFunctions.get_orderuserid(nOrder_id, Me.user_id)
        If bError Then
            Me.error_no = Err.Number
            Me.error_desc = Err.Description
            Me.error_source = Err.Source
            Return True
        End If


        '--- Get Initial Payment
        bError = oTmpOrderFunctions.get_initpayment(nOrder_id, Me.order_initial_payment)
        If bError Then
            Me.error_no = Err.Number
            Me.error_desc = Err.Description
            Me.error_source = Err.Source
            Return True
        End If


        '--- Get Payment type
        oTmpOrderFunctions.connection_string = Me.connection_string
        bError = oTmpOrderFunctions.get_initpaymentmethod(nOrder_id, Me.payment_type, Me.payment_name)
        If bError Then
            Me.error_no = Err.Number
            Me.error_desc = Err.Description
            Me.error_source = Err.Source
            Return True
        End If


        '--- Release
        oTmpOrderFunctions = Nothing


        '--- Get Order Amount Payed
        Dim oTmpAccountingFunctions As New ion_resources.cls_functions_payment()
        oTmpAccountingFunctions.connection_string = Me.connection_string

        bError = oTmpAccountingFunctions.get_ordertotalpayed(nOrder_id, Me.m_order_total_payed)
        If bError Then
            Me.error_no = Err.Number
            Me.error_desc = Err.Description
            Me.error_source = Err.Source
            Return True
        End If
        oTmpAccountingFunctions = Nothing

        '--- Calculate Interst
        '--- Get Interest param. from order
        Dim oTmpFunction As New ion_resources.cls_functions_order()
        oTmpFunction.connection_string = Me.connection_string
        Dim nInterestRate As Decimal
        Dim dInterestStartDate As Date
        bError = oTmpFunction.get_interest(nOrder_id, nInterestRate, dInterestStartDate)

        '--- Add interest
        '--- Make sure interest is not calculated below ZERO
        Dim nStartAmount As Decimal = (Me.order_total - Me.order_total_payed)
        If nStartAmount < 0 Then
            nStartAmount = 0
        End If
        Dim oTmpInterest As New ion_resources.cls_interest()
        oTmpInterest.start_date = dInterestStartDate
        oTmpInterest.end_date = Date.Today
        oTmpInterest.start_amount = nStartAmount
        oTmpInterest.interest = nInterestRate
        bError = oTmpInterest.calc()

        '--- Get interest
        Me.order_interest = oTmpInterest.amount_intrest

        '--- Calculate LEFT TO PAY
        Me.order_total_left_to_pay = oTmpInterest.end_amount

        Me.order_left_to_pay = Me.order_total - Me.order_total_payed

        oTmpInterest = Nothing
        oTmpFunction = Nothing
        oTmpAccountingFunctions = Nothing
        oTmpOrderFunctions = Nothing

        Return False
        Exit Function

ErrorHandler:
        Me.error_no = Err.Number
        Me.error_desc = Err.Description
        Me.error_source = Err.Source
        Return True

    End Function


    Public Property error_no() As Integer
        Get
            Return m_error_no
        End Get

        Set(ByVal Value As Integer)
            m_error_no = Value
        End Set
    End Property

    Public Property error_desc() As String
        Get
            Return m_error_desc
        End Get

        Set(ByVal Value As String)
            m_error_desc = Value
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

    Public Property connection_string() As String
        Get
            Return m_connection_string
        End Get

        Set(ByVal Value As String)
            m_connection_string = Value
        End Set
    End Property


    Public Property order_number() As Int32
        Get
            Return m_order_number
        End Get

        Set(ByVal Value As Int32)
            m_order_number = Value
        End Set
    End Property


    Public Property order_total() As Decimal
        Get
            Return m_order_total
        End Get

        Set(ByVal Value As Decimal)
            m_order_total = Value
        End Set
    End Property


    Public Property order_total_payed() As Decimal
        Get
            Return m_order_total_payed
        End Get

        Set(ByVal Value As Decimal)
            m_order_total_payed = Value
        End Set
    End Property

    Public Property order_left_to_pay() As Decimal
        Get
            Return m_order_left_to_pay
        End Get

        Set(ByVal Value As Decimal)
            m_order_left_to_pay = Value
        End Set
    End Property

    Public Property order_total_left_to_pay() As Decimal
        Get
            Return m_order_total_left_to_pay
        End Get

        Set(ByVal Value As Decimal)
            m_order_total_left_to_pay = Value
        End Set
    End Property

    Public Property order_initial_payment() As Decimal
        Get
            Return m_order_initial_payment
        End Get

        Set(ByVal Value As Decimal)
            m_order_initial_payment = Value
        End Set
    End Property

    Public Property order_interest() As Decimal
        Get
            Return m_order_interest
        End Get

        Set(ByVal Value As Decimal)
            m_order_interest = Value
        End Set
    End Property

    Public Property user_id() As Int32
        Get
            Return m_user_id
        End Get

        Set(ByVal Value As Int32)
            m_user_id = Value
        End Set
    End Property

    Public Property payment_type() As Int32
        Get
            Return m_payment_type
        End Get

        Set(ByVal Value As Int32)
            m_payment_type = Value
        End Set
    End Property

    Public Property payment_name() As String
        Get
            Return m_payment_name
        End Get

        Set(ByVal Value As String)
            m_payment_name = Value
        End Set
    End Property


End Class
