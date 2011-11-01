Public Class cls_measurement
	Inherits iFoundation.cls_error

	Public _m1 As Decimal
	Public _m2 As Decimal
	Public _m3 As Decimal

	Public _sql As String
	Public _size_margin As Decimal
	Public _measurments_html As String
	Public _measurments As String

	Sub New()
		Me._m1 = 0
		Me._m2 = 0
		Me._m3 = 0

		Me._sql = ""
		Me._size_margin = 0
		Me._measurments_html = ""
		Me._measurments = ""
	End Sub

	Public Function get_measurements() As Boolean
		On Error GoTo ErrorHandler
		Dim bError As Boolean = False

		'--- all strings are full
		If Me._m1 <> 0 And Me._m2 <> 0 And Me._m3 <> 0 Then
            Me._measurments_html = System.Convert.ToString(Format(Me._m1, "##,##0.00")) + "x" + System.Convert.ToString(Format(Me._m2, "##,##0.00")) + "x" + System.Convert.ToString(Format(Me._m3, "##,##0.00")) + " mm."
            Me._measurments = System.Convert.ToString(Format(Me._m1, "##,##0.00")) + " " + "x" + " " + System.Convert.ToString(Format(Me._m2, "##,##0.00")) + " " + "x" + " " + System.Convert.ToString(Format(Me._m3, "##,##0.00")) + " mm."

            '--- regular stone only High x Width
        ElseIf Me._m1 <> 0 And Me._m2 <> 0 And Me._m3 = 0 Then
            Me._measurments_html = System.Convert.ToString(Format(Me._m1, "##,##0.00")) + " x " + System.Convert.ToString(Format(Me._m2, "##,##0.00")) + " mm."
            Me._measurments = System.Convert.ToString(Format(Me._m1, "##,##0.00")) + " " + "x" + " " + System.Convert.ToString(Format(Me._m2, "##,##0.00")) + " mm."

            '--- Round stone, m2=diameter / m3=depth
        ElseIf Me._m1 = 0 And Me._m2 <> 0 And Me._m3 <> 0 Then
            Me._measurments_html = System.Convert.ToString(Format(Me._m2, "##,##0.00")) + " &Oslash; " + System.Convert.ToString(Format(Me._m3, "##,##0.00")) + "mm."
            Me._measurments = System.Convert.ToString(Format(Me._m2, "##,##0.00")) + " " + Chr(216) + " " + System.Convert.ToString(Format(Me._m3, "##,##0.00")) + "mm."

            '--- Round stone, only m2=diameter
        ElseIf Me._m1 = 0 And Me._m2 <> 0 And Me._m3 = 0 Then
            Me._measurments_html = System.Convert.ToString(Format(Me._m2, "##,##0.00")) + " &Oslash;"
            Me._measurments = System.Convert.ToString(Format(Me._m2, "##,##0.00")) + " " + Chr(216)

        Else
            Me._measurments_html = "-"
            Me._measurments = "-"

        End If



        Return False
        Exit Function

ErrorHandler:
        Me._err_number = Err.Number
        Me._err_description = Err.Description
        Me._err_source = Err.Source
        Exit Function

	End Function
End Class
