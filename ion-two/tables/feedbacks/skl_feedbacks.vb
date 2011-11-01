Public Class skl_feedbacks

	Public _id As Int32
	Public _user_id As Int32
	Public _user_name As String
	Public _user_email As String
	Public _showemail As Boolean
	Public _active As Boolean
	Public _deleted As Boolean
	Public _createdate As DateTime
	Public _text As String
	Public _country As String
	Public _state As String
	Public _item1_id As Int32
	Public _item2_id As Int32
	Public _item3_id As Int32

	Sub New()
		Me._id = 0
		Me._user_id = 0
		Me._user_name = ""
		Me._user_email = ""
		Me._showemail = False
		Me._active = False
		Me._deleted = False
		Me._createdate = #1/1/1900#
		Me._text = ""
		Me._country = ""
		Me._state = ""
		Me._item1_id = 0
		Me._item2_id = 0
		Me._item3_id = 0
	End Sub


End Class
