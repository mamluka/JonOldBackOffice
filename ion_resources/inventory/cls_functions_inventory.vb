Public Class cls_functions_inventory
	'--- Default properties for every class
	Private m_connection_string As String
	Private m_error_number As Int32
	Private m_error_source As String
	Private m_error_description As String


	'##########################################################################################
	Public Function get_item_price(ByVal nItemId As Int32, ByVal bUserDealer As Boolean, ByRef nPrice As Decimal, Optional ByRef oItemPrice As ion_resources.cls_cons_price = Nothing) As Boolean
		'*** Get the correct price for an item by ID

		On Error GoTo ErrorHandler

		'--- Define local vars
		Dim bError As Boolean = False

		'--- Define Connection String
		Dim bConnection_open As Boolean = False
		Dim bDatareader_open As Boolean = False
		Dim cSQL As String
		cSQL = "select purchase_price,dealer_price,sell_price,special_sell_price,special_dealer_price,onspecial,onspecial_from_date,onspecial_to_date from inv_inventory where id =" & nItemId
		Dim objConn As New SqlClient.SqlConnection(Me.connection_string)
		Dim cSQLstring As SqlClient.SqlCommand = New SqlClient.SqlCommand(cSQL, objConn)
		objConn.Open()
		bConnection_open = True

		Dim dr_Reader As SqlClient.SqlDataReader = cSQLstring.ExecuteReader()
		bDatareader_open = True


		'--- declare price constructor
		'Dim oTmpPrice As New ion_resources.cls_cons_price()

		'TODO: optional parameter can cause problems

		While dr_Reader.Read()
			oItemPrice.purchase_price = dr_Reader.Item("purchase_price")
			oItemPrice.dealer_price = dr_Reader.Item("dealer_price")
			oItemPrice.sell_price = dr_Reader.Item("sell_price")
			oItemPrice.special_sell_price = dr_Reader.Item("special_sell_price")
			oItemPrice.special_dealer_price = dr_Reader.Item("special_dealer_price")
			oItemPrice.onspecial = dr_Reader.Item("onspecial")
			oItemPrice.onspecial_from = dr_Reader.Item("onspecial_from_date")
			oItemPrice.onspecial_to = dr_Reader.Item("onspecial_to_date")

		End While

		'--- Get the correct price
		bError = oItemPrice.get_price(bUserDealer)
		nPrice = oItemPrice.correct_price

		'oTmpPrice = Nothing

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
		Me.error_number = Err.Number
		Me.error_description = Err.Description
		Me.error_source = Err.Source
		Return True

	End Function


	'##########################################################################################
	Public Function mark_item_sold(ByVal nItemId As Int32, ByVal nQty As Int16, ByRef bNotify As Boolean) As Boolean
		On Error GoTo ErrorHandler

		'--- Define local vars
		Dim bError As Boolean = False

		'--- Get Item informastion
		Dim nItem_curr As Int32
		Dim nItem_min As Int32
		bError = get_item_qty(nItemId, nItem_curr, nItem_min)
		If bError Then
			Return True
		End If

		'--- Set values
		nItem_curr = nItem_curr - nQty
		If nItem_curr < nItem_min Then
			bNotify = True
		End If


		'--- Change Item
		'--- Define Connection String
		Dim objConn As New SqlClient.SqlConnection(Me.connection_string)
		Dim cSQLstring As SqlClient.SqlCommand

		cSQLstring = New SqlClient.SqlCommand("update inv_inventory set item_sold = 1, qtyonstock_cur = " & nItem_curr & " where id=" & nItemId, objConn)

		objConn.Open()

		Dim dr_Reader As SqlClient.SqlDataReader = cSQLstring.ExecuteReader()

		If dr_Reader.RecordsAffected <> 1 Then
			bError = True
		End If

		objConn.Close()
		dr_Reader.Close()

		Return False
		Exit Function


ErrorHandler:
		'--- register the error
		Me.error_number = Err.Number
		Me.error_description = Err.Description
		Me.error_source = Err.Source
		Return True

	End Function


	'##########################################################################################
	Public Function get_item_qty(ByVal nItemId As Int32, ByRef nQty_curr As Int32, ByRef nQty_min As Int32) As Boolean
		On Error GoTo ErrorHandler

		'--- Define local vars
		Dim bError As Boolean = False

		'--- Define Connection String
		Dim bConnection_open As Boolean = False
		Dim bDatareader_open As Boolean = False
		Dim cSQL As String
		cSQL = "select id, qtyonstock_cur, qtyonstock_min from inv_inventory where ID =" & nItemId
		Dim objConn As New SqlClient.SqlConnection(Me.connection_string)
		Dim cSQLstring As SqlClient.SqlCommand = New SqlClient.SqlCommand(cSQL, objConn)
		objConn.Open()
		bConnection_open = True

		Dim dr_Reader As SqlClient.SqlDataReader = cSQLstring.ExecuteReader()
		bDatareader_open = True

		While dr_Reader.Read()
			nQty_curr = dr_Reader.Item("qtyonstock_cur")
			nQty_min = dr_Reader.Item("qtyonstock_min")
		End While

		'--- check if Item below stock
		If nQty_curr <= nQty_min Then
			'TODO: Notify SYSADMIN Item below stock

		End If


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
		Me.error_number = Err.Number
		Me.error_description = Err.Description
		Me.error_source = Err.Source
		Return True

	End Function


	'##########################################################################################
	Public Function get_item_picture(ByVal nItemId As Int32, ByVal nMode As Int16, ByVal oCategories As Collection, ByRef cPath As String) As Boolean
		On Error GoTo ErrorHandler

		'--- Define local vars
		Dim bError As Boolean = False

		'--- Define Connection String
		Dim bConnection_open As Boolean = False
		Dim bDatareader_open As Boolean = False
		Dim cSQL As String
		cSQL = "select id, category_id, icon_name, picture_name, picture_hires_name, certificate_name, Movie_name from inv_inventory where ID =" & nItemId
		Dim objConn As New SqlClient.SqlConnection(Me.connection_string)
		Dim cSQLstring As SqlClient.SqlCommand = New SqlClient.SqlCommand(cSQL, objConn)
		objConn.Open()
		bConnection_open = True

		Dim dr_Reader As SqlClient.SqlDataReader = cSQLstring.ExecuteReader()
		bDatareader_open = True

		Dim cTmpPictureName As String
		Dim nCategory As Int32

		While dr_Reader.Read()

			nCategory = dr_Reader.Item("category_id")

			Select Case nMode
				Case 1			  '--- Icon
					cTmpPictureName = dr_Reader.Item("icon_name")

				Case 2			 '--- Picture
					cTmpPictureName = dr_Reader.Item("picture_name")

				Case 3			 '--- pic_hires
					cTmpPictureName = dr_Reader.Item("picture_hires_name")

				Case 4			 '--- certificate
					cTmpPictureName = dr_Reader.Item("certificate_name")

				Case 5			  '--- Movie
					cTmpPictureName = dr_Reader.Item("movie_name")

			End Select
		End While

		'--- Assign the path and icon to it
		If Trim(cTmpPictureName) = "" Then
			cPath = "/pic/no_icon.gif"
		Else
			cPath = oCategories.Item(nCategory).relative_path + cTmpPictureName
		End If


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
		Me.error_number = Err.Number
		Me.error_description = Err.Description
		Me.error_source = Err.Source
		Return True

	End Function

	'######################################################################################################
	Function get_plateno_by_id(ByVal nId As Integer, ByRef nPlate As Int16) As Boolean
		On Error GoTo ErrorHandler

		'--- Define local vars
		Dim bError As Boolean = False

		'--- Define Connection String
		Dim bConnection_open As Boolean = False
		Dim bDatareader_open As Boolean = False
		Dim cSQL As String
		cSQL = "select platetype from inv_inventory where ID =" & nId
		Dim objConn As New SqlClient.SqlConnection(Me.connection_string)
		Dim cSQLstring As SqlClient.SqlCommand = New SqlClient.SqlCommand(cSQL, objConn)
		objConn.Open()
		bConnection_open = True

		Dim dr_Reader As SqlClient.SqlDataReader = cSQLstring.ExecuteReader()
		bDatareader_open = True

		While dr_Reader.Read()
			nPlate = dr_Reader.Item("platetype")
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
		Me.error_number = Err.Number
		Me.error_description = Err.Description
		Me.error_source = Err.Source
		Return True

	End Function

	'######################################################################################################
	Function get_showitemname(ByVal nId As Int32, ByRef cFileName As String) As Boolean
		On Error GoTo ErrorHandler

		'--- Define local vars
		Dim bError As Boolean = False
		Dim nPlate As Int16
		bError = get_plateno_by_id(nId, nPlate)

		Select Case nPlate
			Case 1
				cFileName = "/diamond/"

			Case 2
				cFileName = "/gemstone/"

			Case 3
				cFileName = "/jewel/"

		End Select



		Return False
		Exit Function

ErrorHandler:
		'--- register the error
		Me.error_number = Err.Number
		Me.error_description = Err.Description
		Me.error_source = Err.Source
		Return True

	End Function

	Function get_item_stat(ByVal nId As Integer, ByRef bAvailable As Boolean) As Boolean
		On Error GoTo ErrorHandler

		'--- Define local vars
		Dim bError As Boolean = False

		'--- Define Connection String
		Dim bConnection_open As Boolean = False
		Dim bDatareader_open As Boolean = False

		Dim cSQL As String


		cSQL = "select itemdeleted, shopstatus, onprocess, qtyonstock_cur from inv_inventory where itemdeleted=0 and shopstatus=1 and qtyonstock_cur > 0 and ID =" & nId
		Dim objConn As New SqlClient.SqlConnection(Me.connection_string)
		Dim cSQLstring As SqlClient.SqlCommand = New SqlClient.SqlCommand(cSQL, objConn)
		objConn.Open()
		bConnection_open = True

		Dim dr_Reader As SqlClient.SqlDataReader = cSQLstring.ExecuteReader()
		bDatareader_open = True


		bAvailable = False
		While dr_Reader.Read()
			If Not dr_Reader.Item("itemdeleted") Then
				bAvailable = True
			End If

			If dr_Reader.Item("shopstatus") Then
				bAvailable = True
			End If

			If Not dr_Reader.Item("onprocess") Then
				bAvailable = True
			End If

			If dr_Reader.Item("qtyonstock_cur") > 0 Then
				bAvailable = True
			End If
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
		Me.error_number = Err.Number
		Me.error_description = Err.Description
		Me.error_source = Err.Source
		Return True

	End Function

	Public Property connection_string() As String
		Get
			Return m_connection_string
		End Get

		Set(ByVal Value As String)
			m_connection_string = Value
		End Set
	End Property

	Public Property error_number() As Int32
		Get
			Return m_error_number
		End Get

		Set(ByVal Value As Int32)
			m_error_number = Value
		End Set
	End Property

	Public Property error_description() As String
		Get
			Return m_error_description
		End Get

		Set(ByVal Value As String)
			m_error_description = Value
		End Set
	End Property

	Public Property error_source() As String
		Get
			Return m_error_source
		End Get

		Set(ByVal Value As String)
			m_error_source = Value
		End Set
	End Property

End Class
