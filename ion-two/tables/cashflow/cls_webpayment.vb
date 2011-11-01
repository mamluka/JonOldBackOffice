Public Class cls_webpayment
	Inherits iFoundation.cls_error

	Public _cc_type_id As Int16
	Public _cc_name As String
	Public _cc_number As String
	Public _cc_cvv As String
	Public _cc_exp_year As String
	Public _cc_exp_month As String
	Public _cc_user_ssn As String
	Public _cc_confermation As String
	Public _cc_clubmember As Boolean
	Public _cc_cleared As Boolean
	Public _amount As Decimal

	Public Function make_webpayment(ByRef bSuccess As Boolean, ByVal nAccount As Int16) As Boolean
		'--- nAccount 1 = Regular Account
		'--- nAccount 2 = Club Account


		'--- Club payments have to be resolved in this module


		'--- If we have a confirmation number USE IT
		If Me._cc_confermation <> "" Then

		Else
			Me._cc_confermation = "OK"
		End If


		bSuccess = True
		Me._cc_cleared = True


	End Function

End Class
