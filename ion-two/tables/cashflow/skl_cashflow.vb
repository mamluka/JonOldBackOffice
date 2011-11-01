Public Class skl_cashflow
	Inherits iFoundation.cls_skelet

	Public _payment_type As Int16	'-- 1=cc 2=mt 3=cq
	Public _payment_date As DateTime
	Public _master As Boolean

	Public _id As Int32
	Public _order_id As Int32
	Public _user_id As Int32

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
	Public _cc_batch As String

	Public _mt_bank As String
	Public _mt_name As String
	Public _mt_account As String
	Public _mt_code As String

	Public _cq_bank As String
	Public _cq_name As String
	Public _cq_account As String
    Public _cq_date As Date

    Public _paypal As Boolean
    



	Public _received As Boolean
	Public _received_date As DateTime
	Public _approved As Boolean
	Public _approved_date As DateTime
	Public _amount_total As Decimal
	Public _amount_interest As Decimal
	Public _amount_actual As Decimal
	Public _amount_costs As Decimal

	Public _LastModify_Date As DateTime
	Public _LastModify_User As String
	Public _LastModify_User_id As Int32
	Public _notes As String

	Sub New()

		Me._payment_type = 0
		Me._payment_date = #1/1/1900#
		Me._master = False

		Me._id = 0
		Me._order_id = 0
		Me._user_id = 0

		Me._cc_type_id = 0
		Me._cc_name = ""
		Me._cc_number = ""
		Me._cc_cvv = ""
		Me._cc_exp_year = ""
		Me._cc_exp_month = ""
		Me._cc_user_ssn = ""
		Me._cc_confermation = ""
		Me._cc_clubmember = False
		Me._cc_cleared = False
		Me._cc_batch = ""

		Me._mt_bank = ""
		Me._mt_name = ""
		Me._mt_account = ""
		Me._mt_code = ""

		Me._cq_bank = ""
		Me._cq_name = ""
		Me._cq_account = ""
		Me._cq_date = #1/1/1900#

		Me._received = False
		Me._received_date = #1/1/1900#
		Me._approved = False
		Me._approved_date = #1/1/1900#
		Me._amount_total = 0
		Me._amount_interest = 0
		Me._amount_actual = 0
		Me._amount_costs = 0

		Me._LastModify_Date = #1/1/1900#
		Me._LastModify_User = ""
		Me._LastModify_User_id = 0
        Me._notes = ""
        Me._paypal = False


	End Sub




End Class
