Imports System.Web.UI.WebControls

Public Class cls_combo
	Inherits iFoundation.cls_error_connection

	'--- local properties
	Public _combobox As DropDownList
	Public _sqlstring As String
	Public _textfield As String
	Public _valuefield As String
	Public _addrow As String
	Public _replacerow1 As String
	Public _startrow As Int16
	Public _bError As Boolean	 '--- Some function return Error in this property

	Sub New()
		Me._combobox = Nothing
		Me._sqlstring = ""
		Me._textfield = ""
		Me._valuefield = ""
		Me._addrow = ""
		Me._replacerow1 = ""
		Me._startrow = 0
		Me._bError = False
	End Sub

	Sub clear()
		Me._combobox = Nothing
		Me._sqlstring = ""
		Me._textfield = ""
		Me._valuefield = ""
		Me._addrow = ""
		Me._replacerow1 = ""
		Me._startrow = 0
		Me._bError = False
	End Sub

	Public Function FillCombo() As Boolean
		'--- Load ComboBox From Data Table
		On Error GoTo ErrorHandler


		'TODO: Convert procedure to iDAC procedure

		Err.Raise(9999, "FillCombo", "Convert procedure to iDAC procedure")

		'--- Define local vars
		Dim bError As Boolean = False

		'--- Define Connection String
		Dim bConnection_open As Boolean = False
		Dim bDatareader_open As Boolean = False
		Dim objConn As New SqlClient.SqlConnection(Me._connection_string)
		Dim cSQLstring As SqlClient.SqlCommand = New SqlClient.SqlCommand(Me._sqlstring, objConn)
		objConn.Open()
		bConnection_open = True

		Dim dr_Reader As SqlClient.SqlDataReader = cSQLstring.ExecuteReader()
		bDatareader_open = True

		Dim nCount As Integer = Me._combobox.Items.Count
		While dr_Reader.Read()
			Me._combobox.Items.Add(dr_Reader.GetString(1))
			Me._combobox.Items(nCount).Value = dr_Reader.GetInt32(0)
			nCount = nCount + 1
		End While

		objConn.Close()
		dr_Reader.Close()

		Return False
		Exit Function


ErrorHandler:
		If bDatareader_open Then
			dr_Reader.Close()
		End If
		If bConnection_open Then
			objConn.Close()
		End If

		'--- register the error
		Me._err_number = Err.Number
		Me._err_description = Err.Description
		Me._err_source = Err.Source
		Return True

	End Function

	Function BindCombo() As Boolean
		On Error GoTo ErrorHandler

		'--- Define local vars
		Dim bError As Boolean = False


		'--- Call the datareader
		Dim oDatareader As New iDac.cls_T_datareader
		oDatareader._connection_string = Me._connection_string
		oDatareader._dbtype = Me._dbtype
		Me._combobox.DataTextField = Me._textfield
		Me._combobox.DataValueField = Me._valuefield
		bError = oDatareader.readcombo(Me._sqlstring, Me._combobox)
		If bError Then
			Me._err_number = oDatareader._err_number
			Me._err_description = oDatareader._err_description
			Me._err_source = oDatareader._err_source
			Return True
		End If


		'--- Clear ROWS up to the requested one
		If Me._startrow > 0 Then
			Dim nLoop As Int16
			For nLoop = 1 To Me._startrow
				Me._combobox.Items.RemoveAt(0)
			Next

		End If

		'--- Replace text on first ROW
		If Me._replacerow1 <> "" Then
			Me._combobox.Items(0).Text = Trim(Me._replacerow1)
			Me._combobox.Items(0).Value = "1"
			Me._combobox.SelectedIndex() = 0
		End If

		'--- Insert a first ROW
		If Me._addrow <> "" Then
			Me._combobox.Items.Insert(0, "")
			Me._combobox.Items(0).Text = Trim(Me._addrow)
			Me._combobox.Items(0).Value = "0"
			Me._combobox.SelectedIndex() = 0
		End If


		Return False
		Exit Function


ErrorHandler:
		'--- register the error
		Me._err_number = Err.Number
		Me._err_description = Err.Description
		Me._err_source = Err.Source
		Return True

	End Function

	Public Function GetComboValue(ByVal oCombo As System.Web.UI.WebControls.DropDownList, ByVal nValue As Integer) As Integer
		On Error GoTo ErrorHandler
		'--- Define local vars
		Dim bError As Boolean = False

		Dim nLoop As Integer
		For nLoop = 0 To oCombo.Items.Count
			If oCombo.Items(nLoop).Value = nValue Then
				Return nLoop
			End If
		Next

		'--- Exeption , this function returns a value. 
		'--- Error status is returned in a property
		Me._bError = False

		Return 0
		Exit Function

ErrorHandler:
		'--- register the error
		Me._err_number = Err.Number
		Me._err_description = Err.Description
		Me._err_source = Err.Source
		Me._bError = True

	End Function

	Public Function GetComboIndex(ByVal oCombo As System.Web.UI.WebControls.DropDownList, ByVal cValue As String) As Integer
		On Error GoTo ErrorHandler

		'--- Define local vars
		Dim bError As Boolean = False

		Dim nLoop As Integer
		For nLoop = 0 To oCombo.Items.Count
            If Trim(LCase(oCombo.Items(nLoop).Value)) = Trim(LCase(cValue)) Then
                Return nLoop
            End If
        Next

		'--- Exeption , this function returns a value. 
		'--- Error status is returned in a property
		Me._bError = False

		Return 0
		Exit Function


ErrorHandler:
		'--- register the error
		Me._err_number = Err.Number
		Me._err_description = Err.Description
		Me._err_source = Err.Source
		Me._bError = True

	End Function

End Class
