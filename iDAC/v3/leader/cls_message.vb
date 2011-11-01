Public Class cls_message

	Public _listbox As New System.Web.UI.WebControls.ListBox
	Public _returnpath As String
	Public _tracking_action As String
	Public _tracking_text As String
	Public _tracking_value As String

	Sub New()
		Me._returnpath = ""
		Me._tracking_action = ""
		Me._tracking_text = ""
		Me._tracking_value = ""
	End Sub

End Class
