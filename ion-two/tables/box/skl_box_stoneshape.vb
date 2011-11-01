Public Class skl_box_stoneshape

	Public _id As Int16
	Public _name As String
	Public _pic As String

	Sub New()
		Me._id = 0
		Me._name = ""
		Me._pic = ""
	End Sub

	Public Function get_shape(ByVal nStoneType_id As Int16, ByVal nShape_Id As Int16) As Boolean
		On Error GoTo ErrorHandler
		Dim bError As Boolean = False


		Select Case nStoneType_id
			Case 1			  '--- Diamond
				Select Case nShape_Id
					Case 1
						Me._id = 1
						Me._name = "Round"
						Me._pic = "/pic/shapes/diamond-round-brilliant-cut.gif"

					Case 2
						Me._id = 2
						Me._name = "Princess"
						Me._pic = "/pic/shapes/diamond-princess-cut.gif"

					Case 3
						Me._id = 3
						Me._name = "Pear"
						Me._pic = "/pic/shapes/diamond-pear-shape.gif"

					Case 4
						Me._id = 4
						Me._name = "Oval"
						Me._pic = "/pic/shapes/diamond-oval-cut.gif"

					Case 5
						Me._id = 5
						Me._name = "Marquise"
						Me._pic = "/pic/shapes/diamond-marquise-cut.gif"

					Case 6
						Me._id = 6
						Me._name = "Heart"
						Me._pic = "/pic/shapes/diamond-heart-shape.gif"

					Case 7
						Me._id = 7
						Me._name = "Emerald"
						Me._pic = "/pic/shapes/diamond-emerald-cut.gif"

				End Select

			Case 2			  '--- Emerald
				Select Case nShape_Id
					Case 1
						Me._id = 1
						Me._name = "Round"
						Me._pic = "/pic/shapes/emerald-round-brilliant-cut.gif"

					Case 2
						Me._id = 2
						Me._name = "Princess"
						Me._pic = "/pic/shapes/emerald-princess-cut.gif"

					Case 3
						Me._id = 3
						Me._name = "Pear"
						Me._pic = "/pic/shapes/emerald-pear-shape.gif"

					Case 4
						Me._id = 4
						Me._name = "Oval"
						Me._pic = "/pic/shapes/emerald-oval-cut.gif"

					Case 5
						Me._id = 5
						Me._name = "Marquise"
						Me._pic = "/pic/shapes/emerald-marquise-cut.gif"

					Case 6
						Me._id = 6
						Me._name = "Heart"
						Me._pic = "/pic/shapes/emerald-heart-shape.gif"

					Case 7
						Me._id = 7
						Me._name = "Emerald"
						Me._pic = "/pic/shapes/emerald-emerald-cut.gif"

				End Select

			Case 3			  '--- Ruby
				Select Case nShape_Id
					Case 1
						Me._id = 1
						Me._name = "Round"
						Me._pic = "/pic/shapes/ruby-round-brilliant-cut.gif"

					Case 2
						Me._id = 2
						Me._name = "Princess"
						Me._pic = "/pic/shapes/ruby-princess-cut.gif"

					Case 3
						Me._id = 3
						Me._name = "Pear"
						Me._pic = "/pic/shapes/ruby-pear-shape.gif"

					Case 4
						Me._id = 4
						Me._name = "Oval"
						Me._pic = "/pic/shapes/ruby-oval-cut.gif"

					Case 5
						Me._id = 5
						Me._name = "Marquise"
						Me._pic = "/pic/shapes/ruby-marquise-cut.gif"

					Case 6
						Me._id = 6
						Me._name = "Heart"
						Me._pic = "/pic/shapes/ruby-heart-shape.gif"

					Case 7
						Me._id = 7
						Me._name = "Emerald"
						Me._pic = "/pic/shapes/ruby-emerald-cut.gif"

				End Select

			Case 4			  '--- Sapphire
				Select Case nShape_Id
					Case 1
						Me._id = 1
						Me._name = "Round"
						Me._pic = "/pic/shapes/sapphire-round-brilliant-cut.gif"

					Case 2
						Me._id = 2
						Me._name = "Princess"
						Me._pic = "/pic/shapes/sapphire-princess-cut.gif"

					Case 3
						Me._id = 3
						Me._name = "Pear"
						Me._pic = "/pic/shapes/sapphire-pear-shape.gif"

					Case 4
						Me._id = 4
						Me._name = "Oval"
						Me._pic = "/pic/shapes/sapphire-oval-cut.gif"

					Case 5
						Me._id = 5
						Me._name = "Marquise"
						Me._pic = "/pic/shapes/sapphire-marquise-cut.gif"

					Case 6
						Me._id = 6
						Me._name = "Heart"
						Me._pic = "/pic/shapes/sapphire-heart-shape.gif"

					Case 7
						Me._id = 7
						Me._name = "Emerald"
						Me._pic = "/pic/shapes/sapphire-emerald-cut.gif"

				End Select

		End Select




		Return False
		Exit Function

ErrorHandler:
		Return True
	End Function

End Class
