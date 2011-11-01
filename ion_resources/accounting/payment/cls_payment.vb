Public Class cls_payment

	Private m_payment_dataset As dataset

	Private m_payment_type As Int16	'-- 1=cc 2=mt 3=cq
	Private m_payment_date As DateTime
	Private m_master As Boolean

	Private m_id As Int32
	Private m_order_id As Int32
	Private m_user_id As Int32

	Private m_cc_type_id As Int16
	Private m_cc_name As String
	Private m_cc_number As String
	Private m_cc_cvv As String
	Private m_cc_exp_year As String
	Private m_cc_exp_month As String
	Private m_cc_user_ssn As String
	Private m_cc_confermation As String
	Private m_cc_clubmember As Boolean
    Private m_cc_cleared As Boolean
    Private m_cc_batch As String

	Private m_mt_bank As String
	Private m_mt_name As String
	Private m_mt_account As String
	Private m_mt_code As String

	Private m_cq_bank As String
	Private m_cq_name As String
	Private m_cq_account As String
	Private m_cq_date As Date

	Private m_received As Boolean
	Private m_received_date As DateTime
	Private m_approved As Boolean
	Private m_approved_date As DateTime
	Private m_amount_total As Decimal
	Private m_amount_interest As Decimal
    Private m_amount_actual As Decimal
    Private m_amount_costs As Decimal

	Private m_LastModify_Date As DateTime
	Private m_LastModify_User As String
	Private m_LastModify_User_id As Int32
    Private m_notes As String


	Public Property payment_type() As Int16
		Get
			Return m_payment_type
		End Get

		Set(ByVal Value As Int16)
			m_payment_type = Value
		End Set
	End Property

	Public Property payment_date() As DateTime
		Get
			Return m_payment_date
		End Get

		Set(ByVal Value As DateTime)
			m_payment_date = Value
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

	Public Property order_id() As Int32
		Get
			Return m_order_id
		End Get

		Set(ByVal Value As Int32)
			m_order_id = Value
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

	Public Property master() As Boolean
		Get
			Return m_master
		End Get

		Set(ByVal Value As Boolean)
			m_master = Value
		End Set
	End Property

    Public Property cc_type_id() As Int16
        Get
            Return m_cc_type_id
        End Get

        Set(ByVal Value As Int16)
            m_cc_type_id = Value
        End Set
    End Property

    Public Property cc_name() As String
        Get
            Return m_cc_name
        End Get

        Set(ByVal Value As String)
            m_cc_name = Value
        End Set
    End Property

    Public Property cc_number() As String
        Get
            Return m_cc_number
        End Get

        Set(ByVal Value As String)
            m_cc_number = Value
        End Set
    End Property

    Public Property cc_cvv() As String
        Get
            Return m_cc_cvv
        End Get

        Set(ByVal Value As String)
            m_cc_cvv = Value
        End Set
    End Property

    Public Property cc_exp_year() As String
        Get
            Return m_cc_exp_year
        End Get

        Set(ByVal Value As String)
            m_cc_exp_year = Value
        End Set
    End Property

    Public Property cc_exp_month() As String
        Get
            Return m_cc_exp_month
        End Get

        Set(ByVal Value As String)
            m_cc_exp_month = Value
        End Set
    End Property

    Public Property cc_user_ssn() As String
        Get
            Return m_cc_user_ssn
        End Get

        Set(ByVal Value As String)
            m_cc_user_ssn = Value
        End Set
    End Property

    Public Property cc_confermation() As String
        Get
            Return m_cc_confermation
        End Get

        Set(ByVal Value As String)
            m_cc_confermation = Value
        End Set
    End Property

    Public Property cc_clubmember() As Boolean
        Get
            Return m_cc_clubmember
        End Get

        Set(ByVal Value As Boolean)
            m_cc_clubmember = Value
        End Set
    End Property

    Public Property cc_cleared() As Boolean
        Get
            Return m_cc_cleared
        End Get

        Set(ByVal Value As Boolean)
            m_cc_cleared = Value
        End Set
    End Property

    Public Property cc_batch() As String
        Get
            Return m_cc_batch
        End Get

        Set(ByVal Value As String)
            m_cc_batch = Value
        End Set
    End Property

    Public Property mt_bank() As String
        Get
            Return m_mt_bank
        End Get

        Set(ByVal Value As String)
            m_mt_bank = Value
        End Set
    End Property

    Public Property mt_name() As String
        Get
            Return m_mt_name
        End Get

        Set(ByVal Value As String)
            m_mt_name = Value
        End Set
    End Property

    Public Property mt_account() As String
        Get
            Return m_mt_account
        End Get

        Set(ByVal Value As String)
            m_mt_account = Value
        End Set
    End Property

    Public Property mt_code() As String
        Get
            Return m_mt_code
        End Get

        Set(ByVal Value As String)
            m_mt_code = Value
        End Set
    End Property

    Public Property cq_bank() As String
        Get
            Return m_cq_bank
        End Get

        Set(ByVal Value As String)
            m_cq_bank = Value
        End Set
    End Property

    Public Property cq_name() As String
        Get
            Return m_cq_name
        End Get

        Set(ByVal Value As String)
            m_cq_name = Value
        End Set
    End Property

    Public Property cq_account() As String
        Get
            Return m_cq_account
        End Get

        Set(ByVal Value As String)
            m_cq_account = Value
        End Set
    End Property

    Public Property cq_date() As Date
        Get
            Return m_cq_date
        End Get

        Set(ByVal Value As Date)
            m_cq_date = Value
        End Set
    End Property

    Public Property received() As Boolean
        Get
            Return m_received
        End Get

        Set(ByVal Value As Boolean)
            m_received = Value
        End Set
    End Property

    Public Property received_date() As DateTime
        Get
            Return m_received_date
        End Get

        Set(ByVal Value As DateTime)
            m_received_date = Value
        End Set
    End Property

    Public Property approved() As Boolean
        Get
            Return m_approved
        End Get

        Set(ByVal Value As Boolean)
            m_approved = Value
        End Set
    End Property

    Public Property approved_date() As DateTime
        Get
            Return m_approved_date
        End Get

        Set(ByVal Value As DateTime)
            m_approved_date = Value
        End Set
    End Property

    Public Property amount_total() As Decimal
        Get
            Return m_amount_total
        End Get

        Set(ByVal Value As Decimal)
            m_amount_total = Value
        End Set
    End Property

    Public Property amount_interest() As Decimal
        Get
            Return m_amount_interest
        End Get

        Set(ByVal Value As Decimal)
            m_amount_interest = Value
        End Set
    End Property

    Public Property amount_actual() As Decimal
        Get
            Return m_amount_actual
        End Get

        Set(ByVal Value As Decimal)
            m_amount_actual = Value
        End Set
    End Property

    Public Property amount_costs() As Decimal
        Get
            Return m_amount_costs
        End Get

        Set(ByVal Value As Decimal)
            m_amount_costs = Value
        End Set
    End Property

    Public Property payment_dataset() As DataSet
        Get
            Return m_payment_dataset
        End Get

        Set(ByVal Value As DataSet)
            m_payment_dataset = Value
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

    Public Property notes() As String
        Get
            Return m_notes
        End Get

        Set(ByVal Value As String)
            m_notes = Value
        End Set
    End Property

End Class
