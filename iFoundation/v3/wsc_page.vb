Public Class wsc_page
	Inherits System.Web.UI.Page

	Public _err_number As Int32
	Public _err_description As String
	Public _err_source As String
	Public _modulename As String

	Sub New()
		Me._err_number = 0
		Me._err_description = ""
		Me._err_source = ""
		Me._modulename = ""

	End Sub

End Class
