Public Class cls_order

    Private m_order_dataset As DataSet
    Private m_order_items As New Collection()
    Private m_id As Int32
    Private m_ordernumber As Int32
    Private m_invoice_number As Int32
    Private m_invoice_date As DateTime
    Private m_Invoice_copy As Boolean
    Private m_ClubOrder As Boolean
    Private m_campaign As String
    Private m_affiliate As String
    Private m_referrer As String
    Private m_remote_ip As String
    Private m_order_transacted As Boolean

    Private m_user_id As Int32
    Private m_packaging_id As Int32
    Private m_payment_id As Int32
    Private m_shipping_id As Int32
    Private m_shipping_tracking_no As String
    Private m_jewelry_size As String

    Private m_OrderDate As DateTime
    Private m_Orderdeleted As Boolean
    Private m_merchant_notes As String
    Private m_customer_notes As String
    Private m_LastModify_Date As DateTime
    Private m_LastModify_User As String
    Private m_LastModify_User_id As Int32

    '--- Interest Calculation
    Private m_interest_start_date As DateTime
    Private m_interest_percentage As Decimal

    '--- Amounts
    Private m_amnt_items As Decimal
    Private m_amnt_labor As Decimal
    Private m_amnt_wrapping As Decimal
    Private m_amnt_extracharges As Decimal
    Private m_amnt_shipping As Decimal
    Private m_amnt_vat As Decimal
    Private m_amnt_vatperc As Decimal
    Private m_amnt_discount As Decimal
    Private m_amnt_subtotal As Decimal
    Private m_amnt_grandtotal As Decimal

    '--- Billing address
    Private m_adrs_billing_name As String
    Private m_adrs_billing_street As String
    Private m_adrs_billing_city As String
    Private m_adrs_billing_zip As String
    Private m_adrs_billing_state_id As Int32
    Private m_adrs_billing_country_id As Int32
    Private m_adrs_billing_phone As String

    '--- Shipping address
    Private m_adrs_shipping_name As String
    Private m_adrs_shipping_street As String
    Private m_adrs_shipping_city As String
    Private m_adrs_shipping_zip As String
    Private m_adrs_shipping_state_id As Int32
    Private m_adrs_shipping_country_id As Int32
    Private m_adrs_shipping_phone As String

    '--- Parameters
    Private m_cannot_be_edited As Boolean

    '--- Status
    Private m_sts_new_order_received As Boolean
    Private m_sts_new_order_received_date As DateTime
    Private m_sts_waiting_for_authorization As Boolean
    Private m_sts_waiting_for_authorization_date As DateTime
    Private m_sts_waiting_for_authorization_note As String
    Private m_sts_waiting_for_payment As Boolean
    Private m_sts_waiting_for_payment_date As DateTime
    Private m_sts_waiting_for_payment_note As String
    Private m_sts_order_confirmed As Boolean
    Private m_sts_order_confirmed_date As DateTime
    Private m_sts_order_confirmed_note As String
    Private m_sts_partial_order_confirmed As Boolean
    Private m_sts_partial_order_confirmed_date As DateTime
    Private m_sts_partial_order_confirmed_note As String
    Private m_sts_order_failed As Boolean
    Private m_sts_order_failed_date As DateTime
    Private m_sts_order_failed_note As String
    Private m_sts_order_waiting_to_be_send As Boolean
    Private m_sts_order_waiting_to_be_send_date As DateTime
    Private m_sts_order_waiting_to_be_send_note As String
    Private m_sts_order_send As Boolean
    Private m_sts_order_send_date As DateTime
    Private m_sts_order_send_note As String
    Private m_sts_partial_order_send As Boolean
    Private m_sts_partial_order_send_date As DateTime
    Private m_sts_partial_order_send_note As String
    Private m_sts_order_received_by_customer As Boolean
    Private m_sts_order_received_by_customer_date As DateTime
    Private m_sts_order_received_by_customer_note As String
    Private m_sts_partial_order_received_by_customer As Boolean
    Private m_sts_partial_order_received_by_customer_date As DateTime
    Private m_sts_partial_order_received_by_customer_note As String
    Private m_sts_customer_returning_order As Boolean
    Private m_sts_customer_returning_order_date As DateTime
    Private m_sts_customer_returning_order_note As String
    Private m_sts_customer_returning_part_order As Boolean
    Private m_sts_customer_returning_part_order_date As DateTime
    Private m_sts_customer_returning_part_order_note As String
    Private m_sts_customer_refunded As Boolean
    Private m_sts_customer_refunded_date As DateTime
    Private m_sts_customer_refunded_note As String
    Private m_sts_customer_partly_refunded As Boolean
    Private m_sts_customer_partly_refunded_date As DateTime
    Private m_sts_customer_partly_refunded_note As String
    Private m_sts_order_closed As Boolean
    Private m_sts_order_closed_date As DateTime
    Private m_sts_order_closed_note As String
    Private m_sts_order_cancelled As Boolean
    Private m_sts_order_cancelled_date As DateTime
    Private m_sts_order_cancelled_note As String

    Private m_order_currency As String = "USD"
    Private m_order_currency_rate As Decimal = 1


    Private m_sts_curr_stat As String
    Private m_sts_curr_date As DateTime

    Private m_include_receipt As Boolean
    Private m_hear_fromus As String





    Public Property order_dataset() As DataSet
        Get
            Return m_order_dataset
        End Get
        Set(ByVal Value As DataSet)
            m_order_dataset = Value
        End Set
    End Property

    Public Property campaign() As String
        Get
            Return m_campaign
        End Get
        Set(ByVal Value As String)
            m_campaign = Value
        End Set
    End Property

    Public Property affiliate() As String
        Get
            Return m_affiliate
        End Get
        Set(ByVal Value As String)
            m_affiliate = Value
        End Set
    End Property

    Public Property invoice_number() As Int32
        Get
            Return m_invoice_number
        End Get
        Set(ByVal Value As Int32)
            m_invoice_number = Value
        End Set
    End Property


    Public Property invoice_date() As DateTime
        Get
            Return m_invoice_date
        End Get
        Set(ByVal Value As DateTime)
            m_invoice_date = Value
        End Set
    End Property

    Public Property invoice_copy() As Boolean
        Get
            Return m_Invoice_copy
        End Get
        Set(ByVal Value As Boolean)
            m_Invoice_copy = Value
        End Set
    End Property

    Public Property cluborder() As Boolean
        Get
            Return m_ClubOrder
        End Get

        Set(ByVal Value As Boolean)
            m_ClubOrder = Value
        End Set
    End Property

    Public Property id() As Int32
        Get
            Return m_id
        End Get

        Set(ByVal Value As Int32)
            m_id = Value
        End Set
    End Property

    Public Property ordernumber() As Int32
        Get
            Return m_ordernumber
        End Get

        Set(ByVal Value As Int32)
            m_ordernumber = Value
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

    Public Property packaging_id() As Int32
        Get
            Return m_packaging_id
        End Get

        Set(ByVal Value As Int32)
            m_packaging_id = Value
        End Set
    End Property

    Public Property payment_id() As Int32
        Get
            Return m_payment_id
        End Get

        Set(ByVal Value As Int32)
            m_payment_id = Value
        End Set
    End Property

    Public Property shipping_id() As Int32
        Get
            Return m_shipping_id
        End Get

        Set(ByVal Value As Int32)
            m_shipping_id = Value
        End Set
    End Property

    Public Property shipping_tracking_no() As String
        Get
            Return m_shipping_tracking_no
        End Get

        Set(ByVal Value As String)
            m_shipping_tracking_no = Value
        End Set
    End Property

    Public Property jewelry_size() As String
        Get
            Return m_jewelry_size
        End Get

        Set(ByVal Value As String)
            m_jewelry_size = Value
        End Set
    End Property

    Public Property amnt_items() As Decimal
        Get
            Return m_amnt_items
        End Get

        Set(ByVal Value As Decimal)
            m_amnt_items = Value
        End Set
    End Property

    Public Property amnt_labor() As Decimal
        Get
            Return m_amnt_labor
        End Get

        Set(ByVal Value As Decimal)
            m_amnt_labor = Value
        End Set
    End Property

    Public Property amnt_shipping() As Decimal
        Get
            Return m_amnt_shipping
        End Get

        Set(ByVal Value As Decimal)
            m_amnt_shipping = Value
        End Set
    End Property

    Public Property amnt_wrapping() As Decimal
        Get
            Return m_amnt_wrapping
        End Get

        Set(ByVal Value As Decimal)
            m_amnt_wrapping = Value
        End Set
    End Property

    Public Property amnt_extracharges() As Decimal
        Get
            Return m_amnt_extracharges
        End Get

        Set(ByVal Value As Decimal)
            m_amnt_extracharges = Value
        End Set
    End Property

    Public Property amnt_discount() As Decimal
        Get
            Return m_amnt_discount
        End Get

        Set(ByVal Value As Decimal)
            m_amnt_discount = Value
        End Set
    End Property

    Public Property amnt_vat() As Decimal
        Get
            Return m_amnt_vat
        End Get

        Set(ByVal Value As Decimal)
            m_amnt_vat = Value
        End Set
    End Property

    Public Property amnt_vatperc() As Decimal
        Get
            Return m_amnt_vatperc
        End Get

        Set(ByVal Value As Decimal)
            m_amnt_vatperc = Value
        End Set
    End Property

    Public Property amnt_subtotal() As Decimal
        Get
            Return m_amnt_subtotal
        End Get

        Set(ByVal Value As Decimal)
            m_amnt_subtotal = Value
        End Set
    End Property

    Public Property amnt_grandtotal() As Decimal
        Get
            Return m_amnt_grandtotal
        End Get

        Set(ByVal Value As Decimal)
            m_amnt_grandtotal = Value
        End Set
    End Property

    Public Property adrs_billing_name() As String
        Get
            Return m_adrs_billing_name
        End Get

        Set(ByVal Value As String)
            m_adrs_billing_name = Value
        End Set
    End Property

    Public Property adrs_billing_street() As String
        Get
            Return m_adrs_billing_street
        End Get

        Set(ByVal Value As String)
            m_adrs_billing_street = Value
        End Set
    End Property

    Public Property adrs_billing_city() As String
        Get
            Return m_adrs_billing_city
        End Get

        Set(ByVal Value As String)
            m_adrs_billing_city = Value
        End Set
    End Property

    Public Property adrs_billing_zip() As String
        Get
            Return m_adrs_billing_zip
        End Get

        Set(ByVal Value As String)
            m_adrs_billing_zip = Value
        End Set
    End Property

    Public Property adrs_billing_state_id() As Int32
        Get
            Return m_adrs_billing_state_id
        End Get

        Set(ByVal Value As Int32)
            m_adrs_billing_state_id = Value
        End Set
    End Property

    Public Property adrs_billing_country_id() As Int32
        Get
            Return m_adrs_billing_country_id
        End Get

        Set(ByVal Value As Int32)
            m_adrs_billing_country_id = Value
        End Set
    End Property

    Public Property adrs_billing_phone() As String
        Get
            Return m_adrs_billing_phone
        End Get

        Set(ByVal Value As String)
            m_adrs_billing_phone = Value
        End Set
    End Property

    Public Property adrs_shipping_name() As String
        Get
            Return m_adrs_shipping_name
        End Get

        Set(ByVal Value As String)
            m_adrs_shipping_name = Value
        End Set
    End Property

    Public Property adrs_shipping_street() As String
        Get
            Return m_adrs_shipping_street
        End Get

        Set(ByVal Value As String)
            m_adrs_shipping_street = Value
        End Set
    End Property

    Public Property adrs_shipping_city() As String
        Get
            Return m_adrs_shipping_city
        End Get

        Set(ByVal Value As String)
            m_adrs_shipping_city = Value
        End Set
    End Property

    Public Property adrs_shipping_zip() As String
        Get
            Return m_adrs_shipping_zip
        End Get

        Set(ByVal Value As String)
            m_adrs_shipping_zip = Value
        End Set
    End Property

    Public Property adrs_shipping_state_id() As Int32
        Get
            Return m_adrs_shipping_state_id
        End Get

        Set(ByVal Value As Int32)
            m_adrs_shipping_state_id = Value
        End Set
    End Property

    Public Property adrs_shipping_country_id() As Int32
        Get
            Return m_adrs_shipping_country_id
        End Get

        Set(ByVal Value As Int32)
            m_adrs_shipping_country_id = Value
        End Set
    End Property

    Public Property adrs_shipping_phone() As String
        Get
            Return m_adrs_shipping_phone
        End Get

        Set(ByVal Value As String)
            m_adrs_shipping_phone = Value
        End Set
    End Property

    Public Property cannot_be_edited() As Boolean
        Get
            Return m_cannot_be_edited
        End Get

        Set(ByVal Value As Boolean)
            m_cannot_be_edited = Value
        End Set
    End Property

    Public Property sts_new_order_received() As Boolean
        Get
            Return m_sts_new_order_received
        End Get

        Set(ByVal Value As Boolean)
            m_sts_new_order_received = Value
        End Set
    End Property

    Public Property sts_new_order_received_date() As DateTime
        Get
            Return m_sts_new_order_received_date
        End Get

        Set(ByVal Value As DateTime)
            m_sts_new_order_received_date = Value
        End Set
    End Property

    Public Property sts_waiting_for_authorization() As Boolean
        Get
            Return m_sts_waiting_for_authorization
        End Get

        Set(ByVal Value As Boolean)
            m_sts_waiting_for_authorization = Value
        End Set
    End Property

    Public Property sts_waiting_for_authorization_date() As DateTime
        Get
            Return m_sts_waiting_for_authorization_date
        End Get

        Set(ByVal Value As DateTime)
            m_sts_waiting_for_authorization_date = Value
        End Set
    End Property

    Public Property sts_waiting_for_authorization_note() As String
        Get
            Return m_sts_waiting_for_authorization_note
        End Get

        Set(ByVal Value As String)
            m_sts_waiting_for_authorization_note = Value
        End Set
    End Property

    Public Property sts_waiting_for_payment() As Boolean
        Get
            Return m_sts_waiting_for_payment
        End Get

        Set(ByVal Value As Boolean)
            m_sts_waiting_for_payment = Value
        End Set
    End Property

    Public Property sts_waiting_for_payment_date() As DateTime
        Get
            Return m_sts_waiting_for_payment_date
        End Get

        Set(ByVal Value As DateTime)
            m_sts_waiting_for_payment_date = Value
        End Set
    End Property

    Public Property sts_waiting_for_payment_note() As String
        Get
            Return m_sts_waiting_for_payment_note
        End Get

        Set(ByVal Value As String)
            m_sts_waiting_for_payment_note = Value
        End Set
    End Property

    Public Property sts_order_confirmed() As Boolean
        Get
            Return m_sts_order_confirmed
        End Get

        Set(ByVal Value As Boolean)
            m_sts_order_confirmed = Value
        End Set
    End Property

    Public Property sts_order_confirmed_date() As DateTime
        Get
            Return m_sts_order_confirmed_date
        End Get

        Set(ByVal Value As DateTime)
            m_sts_order_confirmed_date = Value
        End Set
    End Property

    Public Property sts_order_confirmed_note() As String
        Get
            Return m_sts_order_confirmed_note
        End Get

        Set(ByVal Value As String)
            m_sts_order_confirmed_note = Value
        End Set
    End Property

    Public Property sts_partial_order_confirmed() As Boolean
        Get
            Return m_sts_partial_order_confirmed
        End Get

        Set(ByVal Value As Boolean)
            m_sts_partial_order_confirmed = Value
        End Set
    End Property

    Public Property sts_partial_order_confirmed_date() As DateTime
        Get
            Return m_sts_partial_order_confirmed_date
        End Get

        Set(ByVal Value As DateTime)
            m_sts_partial_order_confirmed_date = Value
        End Set
    End Property

    Public Property sts_partial_order_confirmed_note() As String
        Get
            Return m_sts_partial_order_confirmed_note
        End Get

        Set(ByVal Value As String)
            m_sts_partial_order_confirmed_note = Value
        End Set
    End Property

    Public Property sts_order_failed() As Boolean
        Get
            Return m_sts_order_failed
        End Get

        Set(ByVal Value As Boolean)
            m_sts_order_failed = Value
        End Set
    End Property

    Public Property sts_order_failed_date() As DateTime
        Get
            Return m_sts_order_failed_date
        End Get

        Set(ByVal Value As DateTime)
            m_sts_order_failed_date = Value
        End Set
    End Property

    Public Property sts_order_failed_note() As String
        Get
            Return m_sts_order_failed_note
        End Get

        Set(ByVal Value As String)
            m_sts_order_failed_note = Value
        End Set
    End Property

    Public Property sts_order_waiting_to_be_send() As Boolean
        Get
            Return m_sts_order_waiting_to_be_send
        End Get

        Set(ByVal Value As Boolean)
            m_sts_order_waiting_to_be_send = Value
        End Set
    End Property

    Public Property sts_order_waiting_to_be_send_date() As DateTime
        Get
            Return m_sts_order_waiting_to_be_send_date
        End Get

        Set(ByVal Value As DateTime)
            m_sts_order_waiting_to_be_send_date = Value
        End Set
    End Property

    Public Property sts_order_waiting_to_be_send_note() As String
        Get
            Return m_sts_order_waiting_to_be_send_note
        End Get

        Set(ByVal Value As String)
            m_sts_order_waiting_to_be_send_note = Value
        End Set
    End Property

    Public Property sts_order_send() As Boolean
        Get
            Return m_sts_order_send
        End Get

        Set(ByVal Value As Boolean)
            m_sts_order_send = Value
        End Set
    End Property

    Public Property sts_order_send_date() As DateTime
        Get
            Return m_sts_order_send_date
        End Get

        Set(ByVal Value As DateTime)
            m_sts_order_send_date = Value
        End Set
    End Property

    Public Property sts_order_send_note() As String
        Get
            Return m_sts_order_send_note
        End Get

        Set(ByVal Value As String)
            m_sts_order_send_note = Value
        End Set
    End Property

    Public Property sts_partial_order_send() As Boolean
        Get
            Return m_sts_partial_order_send
        End Get

        Set(ByVal Value As Boolean)
            m_sts_partial_order_send = Value
        End Set
    End Property

    Public Property sts_partial_order_send_date() As DateTime
        Get
            Return m_sts_partial_order_send_date
        End Get

        Set(ByVal Value As DateTime)
            m_sts_partial_order_send_date = Value
        End Set
    End Property

    Public Property sts_partial_order_send_note() As String
        Get
            Return m_sts_partial_order_send_note
        End Get

        Set(ByVal Value As String)
            m_sts_partial_order_send_note = Value
        End Set
    End Property

    Public Property sts_order_received_by_customer() As Boolean
        Get
            Return m_sts_order_received_by_customer
        End Get

        Set(ByVal Value As Boolean)
            m_sts_order_received_by_customer = Value
        End Set
    End Property

    Public Property sts_order_received_by_customer_date() As DateTime
        Get
            Return m_sts_order_received_by_customer_date
        End Get

        Set(ByVal Value As DateTime)
            m_sts_order_received_by_customer_date = Value
        End Set
    End Property

    Public Property sts_order_received_by_customer_note() As String
        Get
            Return m_sts_order_received_by_customer_note
        End Get

        Set(ByVal Value As String)
            m_sts_order_received_by_customer_note = Value
        End Set
    End Property

    Public Property sts_partial_order_received_by_customer() As Boolean
        Get
            Return m_sts_partial_order_received_by_customer
        End Get

        Set(ByVal Value As Boolean)
            m_sts_partial_order_received_by_customer = Value
        End Set
    End Property

    Public Property sts_partial_order_received_by_customer_date() As DateTime
        Get
            Return m_sts_partial_order_received_by_customer_date
        End Get

        Set(ByVal Value As DateTime)
            m_sts_partial_order_received_by_customer_date = Value
        End Set
    End Property

    Public Property sts_partial_order_received_by_customer_note() As String
        Get
            Return m_sts_partial_order_received_by_customer_note
        End Get

        Set(ByVal Value As String)
            m_sts_partial_order_received_by_customer_note = Value
        End Set
    End Property

    Public Property sts_customer_returning_order() As Boolean
        Get
            Return m_sts_customer_returning_order
        End Get

        Set(ByVal Value As Boolean)
            m_sts_customer_returning_order = Value
        End Set
    End Property

    Public Property sts_customer_returning_order_date() As DateTime
        Get
            Return m_sts_customer_returning_order_date
        End Get

        Set(ByVal Value As DateTime)
            m_sts_customer_returning_order_date = Value
        End Set
    End Property

    Public Property sts_customer_returning_order_note() As String
        Get
            Return m_sts_customer_returning_order_note
        End Get

        Set(ByVal Value As String)
            m_sts_customer_returning_order_note = Value
        End Set
    End Property

    Public Property sts_customer_returning_part_order() As Boolean
        Get
            Return m_sts_customer_returning_part_order
        End Get

        Set(ByVal Value As Boolean)
            m_sts_customer_returning_part_order = Value
        End Set
    End Property

    Public Property sts_customer_returning_part_order_date() As DateTime
        Get
            Return m_sts_customer_returning_part_order_date
        End Get

        Set(ByVal Value As DateTime)
            m_sts_customer_returning_part_order_date = Value
        End Set
    End Property

    Public Property sts_customer_returning_part_order_note() As String
        Get
            Return m_sts_customer_returning_part_order_note
        End Get

        Set(ByVal Value As String)
            m_sts_customer_returning_part_order_note = Value
        End Set
    End Property

    Public Property sts_customer_refunded() As Boolean
        Get
            Return m_sts_customer_refunded
        End Get

        Set(ByVal Value As Boolean)
            m_sts_customer_refunded = Value
        End Set
    End Property

    Public Property sts_customer_refunded_date() As DateTime
        Get
            Return m_sts_customer_refunded_date
        End Get

        Set(ByVal Value As DateTime)
            m_sts_customer_refunded_date = Value
        End Set
    End Property

    Public Property sts_customer_refunded_note() As String
        Get
            Return m_sts_customer_refunded_note
        End Get

        Set(ByVal Value As String)
            m_sts_customer_refunded_note = Value
        End Set
    End Property

    Public Property sts_customer_partly_refunded() As Boolean
        Get
            Return m_sts_customer_partly_refunded
        End Get

        Set(ByVal Value As Boolean)
            m_sts_customer_partly_refunded = Value
        End Set
    End Property

    Public Property sts_customer_partly_refunded_date() As DateTime
        Get
            Return m_sts_customer_partly_refunded_date
        End Get

        Set(ByVal Value As DateTime)
            m_sts_customer_partly_refunded_date = Value
        End Set
    End Property

    Public Property sts_customer_partly_refunded_note() As String
        Get
            Return m_sts_customer_partly_refunded_note
        End Get

        Set(ByVal Value As String)
            m_sts_customer_partly_refunded_note = Value
        End Set
    End Property

    Public Property sts_order_closed() As Boolean
        Get
            Return m_sts_order_closed
        End Get

        Set(ByVal Value As Boolean)
            m_sts_order_closed = Value
        End Set
    End Property

    Public Property sts_order_closed_date() As DateTime
        Get
            Return m_sts_order_closed_date
        End Get

        Set(ByVal Value As DateTime)
            m_sts_order_closed_date = Value
        End Set
    End Property

    Public Property sts_order_closed_note() As String
        Get
            Return m_sts_order_closed_note
        End Get

        Set(ByVal Value As String)
            m_sts_order_closed_note = Value
        End Set
    End Property

    Public Property sts_order_cancelled() As Boolean
        Get
            Return m_sts_order_cancelled
        End Get

        Set(ByVal Value As Boolean)
            m_sts_order_cancelled = Value
        End Set
    End Property

    Public Property sts_order_cancelled_date() As DateTime
        Get
            Return m_sts_order_cancelled_date
        End Get

        Set(ByVal Value As DateTime)
            m_sts_order_cancelled_date = Value
        End Set
    End Property

    Public Property sts_order_cancelled_note() As String
        Get
            Return m_sts_order_cancelled_note
        End Get

        Set(ByVal Value As String)
            m_sts_order_cancelled_note = Value
        End Set
    End Property

    Public Property sts_curr_stat() As String
        Get
            Return m_sts_curr_stat
        End Get

        Set(ByVal Value As String)
            m_sts_curr_stat = Value
        End Set
    End Property

    Public Property sts_curr_date() As DateTime
        Get
            Return m_sts_curr_date
        End Get

        Set(ByVal Value As DateTime)
            m_sts_curr_date = Value
        End Set
    End Property

    Public Property order_items() As Collection
        Get
            Return m_order_items
        End Get

        Set(ByVal Value As Collection)
            m_order_items = Value
        End Set
    End Property

    Public Property OrderDate() As DateTime
        Get
            Return m_OrderDate
        End Get

        Set(ByVal Value As DateTime)
            m_OrderDate = Value
        End Set
    End Property

    Public Property OrderDeleted() As Boolean
        Get
            Return m_Orderdeleted
        End Get

        Set(ByVal Value As Boolean)
            m_Orderdeleted = Value
        End Set
    End Property

    Public Property merchant_notes() As String
        Get
            Return m_merchant_notes
        End Get

        Set(ByVal Value As String)
            m_merchant_notes = Value
        End Set
    End Property

    Public Property customer_notes() As String
        Get
            Return m_customer_notes
        End Get

        Set(ByVal Value As String)
            m_customer_notes = Value
        End Set
    End Property

    Public Property LastModify_Date() As DateTime
        Get
            Return m_LastModify_Date
        End Get

        Set(ByVal Value As DateTime)
            m_LastModify_Date = Value
        End Set
    End Property

    Public Property LastModify_User() As String
        Get
            Return m_LastModify_User
        End Get

        Set(ByVal Value As String)
            m_LastModify_User = Value
        End Set
    End Property

    Public Property LastModify_User_id() As Int32
        Get
            Return m_LastModify_User_id
        End Get

        Set(ByVal Value As Int32)
            m_LastModify_User_id = Value
        End Set
    End Property

    Public Property interest_start_date() As DateTime
        Get
            Return m_interest_start_date
        End Get

        Set(ByVal Value As DateTime)
            m_interest_start_date = Value
        End Set
    End Property

    Public Property interest_percentage() As Decimal
        Get
            Return m_interest_percentage
        End Get

        Set(ByVal Value As Decimal)
            m_interest_percentage = Value
        End Set
    End Property

    Public Property referrer() As String
        Get
            Return m_referrer
        End Get

        Set(ByVal Value As String)
            m_referrer = Value
        End Set
    End Property

    Public Property remote_ip() As String
        Get
            Return m_remote_ip
        End Get

        Set(ByVal Value As String)
            m_remote_ip = Value
        End Set
    End Property

    Public Property order_transacted() As Boolean
        Get
            Return m_order_transacted
        End Get

        Set(ByVal Value As Boolean)
            m_order_transacted = Value
        End Set
    End Property


    Public Property order_currency() As String
        Get
            Return m_order_currency
        End Get

        Set(ByVal Value As String)
            m_order_currency = Value
        End Set
    End Property

    Public Property order_currency_rate() As Decimal
        Get
            Return m_order_currency_rate
        End Get

        Set(ByVal Value As Decimal)
            m_order_currency_rate = Value
        End Set
    End Property


    Public Property include_receipt() As Boolean
        Get
            Return m_include_receipt
        End Get

        Set(ByVal Value As Boolean)
            m_include_receipt = Value
        End Set
    End Property



    Public Property hear_fromus() As String
        Get
            Return m_hear_fromus
        End Get

        Set(ByVal Value As String)
            m_hear_fromus = Value
        End Set
    End Property

End Class



Public Class cls_order_items
    Private m_id As Int32
    Private m_order_id As Int32
    Private m_item_id As Int32
    Private m_item_no As String
    Private m_jewelsize As String
    Private m_item_quantity As Int32
    Private m_item_extrainfo As String '' idex stupid id
    Private m_deleted As Boolean
    Private m_price As Decimal
    Private m_description As String
    Private m_icon As String

    Public Property id() As Int32
        Get
            Return m_id
        End Get

        Set(ByVal Value As Int32)
            m_id = Value
        End Set
    End Property

    Public Property order_id() As Int32
        Get
            Return m_order_id
        End Get

        Set(ByVal Value As Int32)
            m_order_id = Value
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

    Public Property item_id() As Int32
        Get
            Return m_item_id
        End Get

        Set(ByVal Value As Int32)
            m_item_id = Value
        End Set
    End Property


    Public Property item_no() As String
        Get
            Return m_item_no
        End Get

        Set(ByVal Value As String)
            m_item_no = Value
        End Set
    End Property

    Public Property deleted() As Boolean
        Get
            Return m_deleted
        End Get

        Set(ByVal Value As Boolean)
            m_deleted = Value
        End Set
    End Property

    Public Property item_quantity() As Int32
        Get
            Return m_item_quantity
        End Get

        Set(ByVal Value As Int32)
            m_item_quantity = Value
        End Set
    End Property
    Public Property extrainfo() As String
        Get
            Return m_item_extrainfo
        End Get

        Set(ByVal Value As String)
            m_item_extrainfo = Value
        End Set
    End Property

    Public Property price As Decimal
        Get
            Return m_price
        End Get
        Set(value As Decimal)
            m_price = value
        End Set
    End Property

    Public Property description As String
        Get
            Return m_description
        End Get
        Set(value As String)
            m_description = value
        End Set
    End Property

    Public Property icon As String
        Get
            Return m_icon
        End Get
        Set(value As String)
            m_icon = value
        End Set
    End Property
End Class




