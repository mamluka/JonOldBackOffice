Public Class cls_T_datareader
	Inherits cls_leader

	Public _id As Int32
	Public _clause As String
	Public _order As String
	Public _table As String
	Public _hasresult As Boolean
	Public _fields As New Collection

	Public Function read(Optional ByVal cSQLstring As String = "") As Boolean
		On Error GoTo ErrorHandler
		Dim bError As Boolean = False

		'--- Get Broker type
		bError = Me.get_broker
		If bError Then
			Return True
		End If

		If Me._connection_string = "" Then
			Err.Raise(9004, "cls_T_datareader", "iDAC: No connection string found")
		End If

		If Me._dbtype = 0 Then
			Err.Raise(9005, "cls_T_datareader", "iDAC: No dbtype found")
		End If


		'--- Pass Properties
		Me._broker._connection_string = Me._connection_string
		Me._broker._id = Me._id
		Me._broker._clause = Me._clause
		Me._broker._order = Me._order
		Me._broker._table = Me._table
		Me._broker._hasresult = Me._hasresult
		Me._broker._fields = Me._fields

		'--- Call function
		bError = Me._broker.read(cSQLstring)
		If bError Then
			Me._err_number = Me._broker._err_number
			Me._err_description = Me._broker._err_description
			Me._err_source = Me._broker._err_source
			Return True
		End If

		'--- Receive Properties
		Me._id = Me._broker._id
		Me._clause = Me._broker._clause
		Me._order = Me._broker._order
		Me._table = Me._broker._table
		Me._hasresult = Me._broker._hasresult
		Me._fields = Me._broker._fields

		'--- Clear Objects
		Me._broker = Nothing

		Return False
		Exit Function

ErrorHandler:
		'--- register the error
		Me._err_number = Err.Number
		Me._err_description = Err.Description
		Me._err_source = Err.Source
		Return True

	End Function

	Public Function readcombo(ByVal cSQL As String, ByRef oCombo As System.Web.UI.WebControls.DropDownList) As Boolean
		On Error GoTo ErrorHandler
		Dim bError As Boolean = False

		'--- Get Broker type
		bError = Me.get_broker
		If bError Then
			Return True
		End If

		'--- Pass Properties
		Me._broker._connection_string = Me._connection_string
		Me._broker._id = Me._id
		Me._broker._clause = Me._clause
		Me._broker._order = Me._order
		Me._broker._table = Me._table
		Me._broker._hasresult = Me._hasresult
		Me._broker._fields = Me._fields

		'--- Call function
		bError = Me._broker.readcombo(cSQL, oCombo)
		If bError Then
			Me._err_number = Me._broker._err_number
			Me._err_description = Me._broker._err_description
			Me._err_source = Me._broker._err_source
			Return True
		End If

		'--- Receive Properties
		Me._id = Me._broker._id
		Me._clause = Me._broker._clause
		Me._order = Me._broker._order
		Me._table = Me._broker._table
		Me._hasresult = Me._broker._hasresult
		Me._fields = Me._broker._fields

		'--- Clear Objects
		Me._broker = Nothing

		Return False
		Exit Function

ErrorHandler:
		'--- register the error
		Me._err_number = Err.Number
		Me._err_description = Err.Description
		Me._err_source = Err.Source
		Return True

	End Function

	Private Function get_broker()
		On Error GoTo ErrorHandler
		Dim bError As Boolean = False

		'--- Set default to 4
		If Me._dbtype = 0 Then
			Me._dbtype = 4
		End If

		'--- Get the correct broker for this class
		Dim oBroker As New Object
		Select Case Me._dbtype
			Case 1
				Me._broker = New cls_sql_datadeader

			Case 2
				Me._broker = Nothing

			Case 3
				Me._broker = Nothing

			Case 4
				Me._broker = Nothing

		End Select

		Return False
		Exit Function

ErrorHandler:
		'--- register the error
		Me._err_number = Err.Number
		Me._err_description = Err.Description
		Me._err_source = Err.Source
		Return True

	End Function


End Class
