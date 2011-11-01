Public Class cls_interest
	Inherits iFoundation.cls_error

	Public _days As Int16
	Public _start_date As DateTime
	Public _end_date As DateTime
	Public _start_amount As Decimal
	Public _end_amount As Decimal
	Public _amount_intrest As Decimal
	Public _interest As Decimal
	Public _perday_interest As Decimal
	Public _calculated As Boolean

	Public Function calc() As Boolean
		On Error GoTo ErrorHandler
		Dim bError As Boolean = False


		'--- Check to see if we have start-end date
		If Me._start_date <> #12:00:00 AM# And Me._end_date <> #12:00:00 AM# Then
			Dim oTmpTimeSpan As TimeSpan
			oTmpTimeSpan = Me._end_date.Subtract(Me._start_date)
			Me._days = oTmpTimeSpan.TotalDays
		End If

		'--- Calculate interest only if days are possitive
		If Me._days > 0 Then
			'--- Set defaults
			Dim nCalc_interest As Decimal = Me._interest / 100
			Dim nCalc_year_days As Int16 = 365

			'--- Calculate
			Me._perday_interest = nCalc_interest / nCalc_year_days
			Me._amount_intrest = Me._days * (Me._start_amount * Me._perday_interest)
			Me._end_amount = Me._start_amount + Me._amount_intrest

			'--- round up
			Me._perday_interest = Me._perday_interest.Round(Me._perday_interest, 8)
			Me._amount_intrest = Me._amount_intrest.Round(Me._amount_intrest, 3)
			Me._end_amount = Me._end_amount.Round(Me._end_amount, 3)
		Else
			Me._end_amount = Me._start_amount
		End If

		If Me._start_amount <> Me._end_amount Then
			Me._calculated = True
		Else
			Me._calculated = False
		End If

		Return False
		Exit Function

ErrorHandler:
		Me._err_number = Err.Number
		Me._err_description = Err.Description
		Me._err_source = Err.Source
		Return True

	End Function

End Class
