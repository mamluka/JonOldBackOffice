Public Class cls_message

	Public _listbox As New System.Web.UI.WebControls.ListBox
	Public _returnpath As String
	Public _tracking_action As String
	Public _tracking_text As String
	Public _tracking_value As String
	Public _tracking_userid As String
	Public _ssl As Boolean

	Sub New()
		Me._returnpath = "/default.aspx"
		Me._tracking_action = ""
		Me._tracking_text = ""
		Me._tracking_value = ""
		Me._tracking_userid = ""
		Me._ssl = False
	End Sub

	Public Function clear() As Boolean
		Me._listbox.Items.Clear()

		Return False
	End Function

End Class
