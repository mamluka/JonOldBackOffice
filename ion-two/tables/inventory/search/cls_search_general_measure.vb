Public Class cls_search_general_measure
	Inherits iFoundation.cls_error

	Public _sizeindex As Int32
	Public _measure_margin As Decimal

	Sub New()
		Me._measure_margin = 0
		Me._sizeindex = 0
	End Sub

	Public Function addsearch_measure(ByRef cSQLstring As String) As Boolean
		On Error GoTo ErrorHandler
		Dim bError As Boolean = False


		Select Case Me._sizeindex

			Case 1			 '- smaller then 3.0 x 5.0
				cSQLstring = cSQLstring + "and (measure1 < 3) and (measure2 < 5)"

			Case 100			 '- 3.0 x 5.0
                cSQLstring = cSQLstring + "and (measure1 between " + Convert.ToString(5 - Me._measure_margin) + "  and " + Convert.ToString(5 + Me._measure_margin) + " ) and (measure2 between 3 and " + Convert.ToString(3 + Me._measure_margin) + ")"

			Case 200			 '- 4.0 x 6.0
                cSQLstring = cSQLstring + "and (measure1 between " + Convert.ToString(6 - Me._measure_margin) + "  and " + Convert.ToString(6 + Me._measure_margin) + " ) and (measure2 between 4 and " + Convert.ToString(4 + Me._measure_margin) + ")"

			Case 300			 '- 5.0 x 7.0
                cSQLstring = cSQLstring + "and (measure1 between " + Convert.ToString(7 - Me._measure_margin) + "  and " + Convert.ToString(7 + Me._measure_margin) + " ) and (measure2 between 5 and " + Convert.ToString(5 + Me._measure_margin) + ")"

			Case 400			 '- 6.0 x 8.0
                cSQLstring = cSQLstring + "and (measure1 between " + Convert.ToString(8 - Me._measure_margin) + "  and " + Convert.ToString(8 + Me._measure_margin) + " ) and (measure2 between 6 and " + Convert.ToString(6 + Me._measure_margin) + ")"

			Case 500			 '- 7.0 x 9.0
                cSQLstring = cSQLstring + "and (measure1 between " + Convert.ToString(9 - Me._measure_margin) + "  and " + Convert.ToString(9 + Me._measure_margin) + " ) and (measure2 between 7 and " + Convert.ToString(7 + Me._measure_margin) + ")"

			Case 600			 '- 8.0 x 10.0
                cSQLstring = cSQLstring + "and (measure1 between " + Convert.ToString(10 - Me._measure_margin) + "  and " + Convert.ToString(10 + Me._measure_margin) + " ) and (measure2 between 8 and " + Convert.ToString(8 + Me._measure_margin) + ")"

			Case 700			 '- 9.0 x 11.0
                cSQLstring = cSQLstring + "and (measure1 between " + Convert.ToString(11 - Me._measure_margin) + "  and " + Convert.ToString(11 + Me._measure_margin) + " ) and (measure2 between 9 and " + Convert.ToString(9 + Me._measure_margin) + ")"

			Case 800			 '- Larger
                cSQLstring = cSQLstring + "and (measure1 > 11) and (measure2 > 9)"

			Case 8800			 '- Smaller
                cSQLstring = cSQLstring + "and ( ( (measure1 = 0) or ( measure1 between (measure2*0.97) and (measure2*1.03) ) ) and (measure2 < 2))"

			Case 8900			 '- 2.0
                cSQLstring = cSQLstring + "and ( ( (measure1 = 0) or (measure1 between (measure2*0.97) and (measure2*1.03)) ) and (measure2 between " + Convert.ToString(2 - Me._measure_margin) + " and " + Convert.ToString(2 + Me._measure_margin) + "))"


			Case 9000			 '- 3.0
                cSQLstring = cSQLstring + "and ( ( (measure1 = 0) or (measure1 between (measure2*0.97) and (measure2*1.03)) ) and (measure2 between " + Convert.ToString(3 - Me._measure_margin) + " and " + Convert.ToString(3 + Me._measure_margin) + "))"

			Case 9100			 '- 4.0
                cSQLstring = cSQLstring + "and ( ( (measure1 = 0) or (measure1 between (measure2*0.97) and (measure2*1.03)) ) and (measure2 between " + Convert.ToString(4 - Me._measure_margin) + " and " + Convert.ToString(4 + Me._measure_margin) + "))"

			Case 9200			 '- 5.0
                cSQLstring = cSQLstring + "and ( ( (measure1 = 0) or (measure1 between (measure2*0.97) and (measure2*1.03)) ) and (measure2 between " + Convert.ToString(5 - Me._measure_margin) + " and " + Convert.ToString(5 + Me._measure_margin) + "))"

			Case 9300			 '- 6.0
                cSQLstring = cSQLstring + "and ( ( (measure1 = 0) or (measure1 between (measure2*0.97) and (measure2*1.03)) ) and (measure2 between " + Convert.ToString(6 - Me._measure_margin) + " and " + Convert.ToString(6 + Me._measure_margin) + "))"

			Case 9400			 '- 7.0
                cSQLstring = cSQLstring + "and ( ( (measure1 = 0) or (measure1 between (measure2*0.97) and (measure2*1.03)) ) and (measure2 between " + Convert.ToString(7 - Me._measure_margin) + " and " + Convert.ToString(7 + Me._measure_margin) + "))"

			Case 9500			 '- 8.0
                cSQLstring = cSQLstring + "and ( ( (measure1 = 0) or (measure1 between (measure2*0.97) and (measure2*1.03)) ) and (measure2 between " + Convert.ToString(8 - Me._measure_margin) + " and " + Convert.ToString(8 + Me._measure_margin) + "))"

			Case 9600			 '- 9.0
                cSQLstring = cSQLstring + "and ( ( (measure1 = 0) or (measure1 between (measure2*0.97) and (measure2*1.03)) ) and (measure2 between " + Convert.ToString(9 - Me._measure_margin) + " and " + Convert.ToString(9 + Me._measure_margin) + "))"

			Case 9700			 '- 10.0
                cSQLstring = cSQLstring + "and ( ( (measure1 = 0) or (measure1 between (measure2*0.97) and (measure2*1.03)) ) and (measure2 between " + Convert.ToString(10 - Me._measure_margin) + " and " + Convert.ToString(10 + Me._measure_margin) + "))"

			Case 9800			 '- 11.0
                cSQLstring = cSQLstring + "and ( ( (measure1 = 0) or (measure1 between (measure2*0.97) and (measure2*1.03)) ) and (measure2 between " + Convert.ToString(11 - Me._measure_margin) + " and " + Convert.ToString(11 + Me._measure_margin) + "))"

			Case 9900			 '- 12.0
                cSQLstring = cSQLstring + "and ( ( (measure1 = 0) or (measure1 between (measure2*0.97) and (measure2*1.03)) ) and (measure2 between " + Convert.ToString(12 - Me._measure_margin) + " and " + Convert.ToString(12 + Me._measure_margin) + "))"

			Case 10000			 '- Larger
                cSQLstring = cSQLstring + "and ( ( (measure1 = 0) or (measure1 between (measure2*0.97) and (measure2*1.03)) ) and (measure2 > 12))"

		End Select


		Return False
		Exit Function

ErrorHandler:
		Me._err_number = Err.Number
		Me._err_description = Err.Description
		Me._err_source = Err.Source
		Return True

	End Function
End Class
