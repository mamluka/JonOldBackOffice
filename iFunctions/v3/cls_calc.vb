Public Class cls_calc
	Inherits iFoundation.cls_error

	Public Function get_roundnumer(ByVal nRoundBy As Int16, ByRef nInteger As Int16) As Boolean
		'### Round incomming int16 by 5, used to round minutes usualy  ###'

		On Error GoTo ErrorHandler
		Dim bError As Boolean = False

		Dim nTmpNumber As Int16

		nTmpNumber = nInteger / nRoundBy
		nInteger = Int(nTmpNumber) * nRoundBy


		Return False
		Exit Function

ErrorHandler:
		Me._err_number = Err.Number
		Me._err_description = Err.Description
		Me._err_source = Err.Source
		Return True
	End Function

	Public Function get_rounddecimalby5(ByRef nDecimal As Decimal) As Boolean
		'### Round Decimals  ###'

		On Error GoTo ErrorHandler
		Dim bError As Boolean = False

		'--- Roung to 1 decimal
		nDecimal = Math.Round(nDecimal, 1)

		'--- If left decimal endwith a 5 leave it
		Dim cTmpDecimal As String = Convert.ToString(nDecimal)
		If Not cTmpDecimal.EndsWith(5) Then
			nDecimal = Int(nDecimal)
		End If


		Return False
		Exit Function

ErrorHandler:
		Me._err_number = Err.Number
		Me._err_description = Err.Description
		Me._err_source = Err.Source
		Return True
	End Function

End Class
