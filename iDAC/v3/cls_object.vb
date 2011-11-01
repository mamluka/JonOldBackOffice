Public Class cls_object
	Inherits cls_error
	Public _type As String
	Public _isempty As Boolean

	Public Function Isobject(ByVal oValue As Object) As Boolean
		On Error GoTo ErrorHandler
		Dim bError As Boolean = False

		Dim oType As System.Type = oValue.GetType

		'--- Get TypeName
		Me._type = LCase(oType.Name)


		If Me._type = "boolean" Then
			If oValue Then
				Me._isempty = False
			Else
				Me._isempty = True
			End If

		ElseIf Me._type = "string" Then
			If oValue = "" Then
				Me._isempty = True
			Else
				Me._isempty = False
			End If

		ElseIf Me._type = "datetime" Then
			If oValue = #1/1/1900# Then
				Me._isempty = True
			Else
				Me._isempty = False
			End If

		ElseIf Me._type = "byte" Then
			If oValue = 0 Then
				Me._isempty = True
			Else
				Me._isempty = False
			End If

		ElseIf Me._type = "sbyte" Then
			If oValue = 0 Then
				Me._isempty = True
			Else
				Me._isempty = False
			End If

		ElseIf Me._type = "int16" Then
			If oValue = 0 Then
				Me._isempty = True
			Else
				Me._isempty = False
			End If

		ElseIf Me._type = "uint16" Then
			If oValue = 0 Then
				Me._isempty = True
			Else
				Me._isempty = False
			End If

		ElseIf Me._type = "int32" Then
			If oValue = 0 Then
				Me._isempty = True
			Else
				Me._isempty = False
			End If

		ElseIf Me._type = "uint32" Then
			If oValue = 0 Then
				Me._isempty = True
			Else
				Me._isempty = False
			End If

		ElseIf Me._type = "int64" Then
			If oValue = 0 Then
				Me._isempty = True
			Else
				Me._isempty = False
			End If

		ElseIf Me._type = "uint63" Then
			If oValue = 0 Then
				Me._isempty = True
			Else
				Me._isempty = False
			End If

		ElseIf Me._type = "char" Then
			If oValue = "" Then
				Me._isempty = True
			Else
				Me._isempty = False
			End If

		ElseIf Me._type = "double" Then
			If oValue = 0 Then
				Me._isempty = True
			Else
				Me._isempty = False
			End If

		ElseIf Me._type = "single" Then
			If oValue = 0 Then
				Me._isempty = True
			Else
				Me._isempty = False
			End If

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
