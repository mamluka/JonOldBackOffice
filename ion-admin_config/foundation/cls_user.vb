Public Class cls_user
	Inherits iFoundation.cls_user

	Public _userlevel As Int16
	Public _domain As String
	Public _ssldomain As String

	Sub New()
		Me._domain = ""
		Me._ssldomain = ""
		Me._userlevel = 0
	End Sub


End Class
