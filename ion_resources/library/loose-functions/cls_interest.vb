Public Class cls_interest
	Public m_days As Int16
	Public m_start_date As DateTime
	Public m_end_date As DateTime
	Public m_start_amount As Decimal
	Public m_end_amount As Decimal
	Public m_amount_intrest As Decimal
	Public m_interest As Decimal
	Public m_perday_interest As Decimal
	Public m_calculated As Boolean


	Public Function calc() As Boolean

		'--- Check to see if we have start-end date
		If Me.start_date <> #12:00:00 AM# And Me.end_date <> #12:00:00 AM# Then
			Dim oTmpTimeSpan As TimeSpan
			oTmpTimeSpan = Me.end_date.Subtract(Me.start_date)
			Me.days = oTmpTimeSpan.TotalDays
		End If

		'--- Calculate interest only if days are possitive
		If Me.days > 0 Then
			'--- Set defaults
			Dim nCalc_interest As Decimal = Me.interest / 100
			Dim nCalc_year_days As Int16 = 365

			'--- Calculate
			Me.perday_interest = nCalc_interest / nCalc_year_days
			Me.amount_intrest = Me.days * (Me.start_amount * Me.perday_interest)
			Me.end_amount = Me.start_amount + Me.amount_intrest

			'--- round up
			Me.perday_interest = Me.perday_interest.Round(Me.perday_interest, 8)
			Me.amount_intrest = Me.amount_intrest.Round(Me.amount_intrest, 3)
			Me.end_amount = Me.end_amount.Round(Me.end_amount, 3)
		Else
			Me.end_amount = Me.start_amount
		End If

		If Me.start_amount <> Me.end_amount Then
			Me.calculated = True
		Else
			Me.calculated = False
		End If


	End Function




	Public Property days() As Int16
		Get
			Return m_days
		End Get

		Set(ByVal Value As Int16)
			m_days = Value
		End Set
	End Property


	Public Property start_date() As Date
		Get
			Return m_start_date
		End Get

		Set(ByVal Value As DateTime)
			m_start_date = Value
		End Set
	End Property


	Public Property end_date() As Date
		Get
			Return m_end_date
		End Get

		Set(ByVal Value As DateTime)
			m_end_date = Value
		End Set
	End Property


	Public Property start_amount() As Decimal
		Get
			Return m_start_amount
		End Get

		Set(ByVal Value As Decimal)
			m_start_amount = Value
		End Set
	End Property


	Public Property end_amount() As Decimal
		Get
			Return m_end_amount
		End Get

		Set(ByVal Value As Decimal)
			m_end_amount = Value
		End Set
	End Property

	Public Property amount_intrest() As Decimal
		Get
			Return m_amount_intrest
		End Get

		Set(ByVal Value As Decimal)
			m_amount_intrest = Value
		End Set
	End Property

	Public Property interest() As Decimal
		Get
			Return m_interest
		End Get

		Set(ByVal Value As Decimal)
			m_interest = Value
		End Set
	End Property

	Public Property perday_interest() As Decimal
		Get
			Return m_perday_interest
		End Get

		Set(ByVal Value As Decimal)
			m_perday_interest = Value
		End Set
	End Property

	Public Property calculated() As Boolean
		Get
			Return m_calculated
		End Get

		Set(ByVal Value As Boolean)
			m_calculated = Value
		End Set
	End Property

End Class
