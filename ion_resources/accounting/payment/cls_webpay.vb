Public Class cls_webpay

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
	Private m_amount As Decimal

	Public Function make_webpayment(ByRef bSuccess As Boolean, ByVal nMode As Int16) As Boolean
		'--- Mode 1 = Regular Account
		'--- Mode 2 = Club Account


		'--- Club payments have to be resolved in this module


		'--- If we have a confirmation number USE IT
		If Me.cc_confermation <> "" Then

		Else
			Me.cc_confermation = "OK"
		End If


		bSuccess = True
		Me.cc_cleared = True


	End Function



	Public Property cc_type_id() As String
		Get
			Return m_cc_type_id
		End Get

		Set(ByVal Value As String)
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

	Public Property amount() As Decimal
		Get
			Return m_amount
		End Get
		Set(ByVal Value As Decimal)
			m_amount = Value
		End Set
	End Property


End Class
