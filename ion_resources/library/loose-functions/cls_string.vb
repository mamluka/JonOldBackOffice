Public Class cls_string
	Public _err_number As Int32
	Public _err_description As String
	Public _err_source As String


	Function set_searchstring(ByRef cString As String) As Boolean
		On Error GoTo ErrorHandler
		Dim bError As Boolean = False


		'--- Strip unneccecary chracters
		bError = Me.strip_specialcharacters(cString)
		cString = Trim(cString)

		'--- Strip string
		bError = Me.strip_string("and", cString)
		cString = Trim(cString)

		'--- Strip over spacing
		bError = Me.strip_overspaceing(cString)
		cString = Trim(cString)

		Dim nLen As Int16 = Len(cString)
		Dim nLoop As Int16 = 1
		Dim cTmpString As String = ""

		For nLoop = 1 To nLen + 2000
			cTmpString = Mid(cString, nLoop, 1)
			If cTmpString = Chr(32) Then
				cString = Mid(cString, 1, nLoop - 1) + " AND " + Mid(cString, nLoop + 1)
				nLoop = nLoop + 4
			End If
		Next

		Return False
		Exit Function

ErrorHandler:
		'--- register the error
		Me._err_number = Err.Number
		Me._err_description = Err.Description
		Me._err_source = Err.Source


	End Function

	Function strip_specialcharacters(ByRef cString As String) As Boolean
		On Error GoTo ErrorHandler
		Dim bError As Boolean = False

		Dim nLen As Int16 = Len(cString)
		Dim nLoop As Int16 = 1
		Dim cTmpString As String = ""

		For nLoop = 1 To nLen
			cTmpString = Mid(cString, nLoop, 1)
			If Me.get_specialcharacter(cTmpString) Then
				cString = Mid(cString, 1, nLoop - 1) + Mid(cString, nLoop + 1)
				bError = Me.strip_specialcharacters(cString)
				Exit For
			End If
		Next

		Return False
		Exit Function

ErrorHandler:
		'--- register the error
		Me._err_number = Err.Number
		Me._err_description = Err.Description
		Me._err_source = Err.Source


	End Function

	Function strip_overspaceing(ByRef cString As String) As Boolean
		On Error GoTo ErrorHandler
		Dim bError As Boolean = False

		Dim nLen As Int16 = Len(cString)
		Dim nLoop As Int16 = 1
		Dim cTmpString As String = ""

		For nLoop = 1 To nLen
			cTmpString = Mid(cString, nLoop, 1)
			If cTmpString = Chr(32) Then
				If Mid(cString, nLoop + 1, 1) = Chr(32) Then
					cString = Mid(cString, 1, nLoop) + Mid(cString, nLoop + 2)
					bError = Me.strip_overspaceing(cString)
					Exit For
				End If
			End If
		Next


		Return False
		Exit Function

ErrorHandler:
		'--- register the error
		Me._err_number = Err.Number
		Me._err_description = Err.Description
		Me._err_source = Err.Source


	End Function

	Function strip_string(ByVal cStripstring As String, ByRef cString As String) As Boolean
		On Error GoTo ErrorHandler
		Dim bError As Boolean = False

		Dim nLen As Int16 = Len(cString)
		Dim nLoop As Int16 = 1
		Dim cTmpString As String = ""
		cStripstring = Trim(LCase(cStripstring))

		For nLoop = 1 To nLen
			cTmpString = Mid(LCase(cString), nLoop, Len(cStripstring))
			If cTmpString = cStripstring Then
				cString = Mid(cString, 1, nLoop - 1) + Mid(cString, nLoop + 3)
				bError = Me.strip_string(cStripstring, cString)
				Exit For
			End If
		Next


		Return False
		Exit Function

ErrorHandler:
		'--- register the error
		Me._err_number = Err.Number
		Me._err_description = Err.Description
		Me._err_source = Err.Source


	End Function


	Private Function get_specialcharacter(ByRef cString As String) As Boolean
		On Error GoTo ErrorHandler
		Dim bError As Boolean = False

		If cString >= Chr(48) And cString <= Chr(57) Then
			Return False

		ElseIf cString >= Chr(65) And cString <= Chr(90) Then
			Return False

		ElseIf cString >= Chr(97) And cString <= Chr(122) Then
			Return False

		ElseIf cString = Chr(32) Then
			Return False

		ElseIf cString = Chr(46) Then
			Return False

		End If


		Return True
		Exit Function

ErrorHandler:
		'--- register the error
		Me._err_number = Err.Number
		Me._err_description = Err.Description
		Me._err_source = Err.Source


	End Function


End Class
