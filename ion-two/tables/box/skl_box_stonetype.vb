Public Class skl_box_stonetype
	Public _id As Int16
	Public _name As String
	Public _pic As String

	Sub New()
		Me._id = 0
		Me._name = ""
		Me._pic = ""
	End Sub

	Public Function get_stonetype(ByVal nId As Int16) As Boolean
		On Error GoTo ErrorHandler
		Dim bError As Boolean = False


		Select Case nId
			Case 1
				Me._id = 1
				Me._name = "Diamond"
				Me._pic = "/pic/shapes/diamond-gemstone.gif"

			Case 2
				Me._id = 2
				Me._name = "Emerald"
				Me._pic = "/pic/shapes/emerald-gemstone.gif"

			Case 3
				Me._id = 3
				Me._name = "Ruby"
				Me._pic = "/pic/shapes/ruby-gemstone.gif"

			Case 4
				Me._id = 4
				Me._name = "Sapphire"
				Me._pic = "/pic/shapes/sapphire-gemstone.gif"

		End Select

		Return False
		Exit Function

ErrorHandler:
		Return True
	End Function

End Class
