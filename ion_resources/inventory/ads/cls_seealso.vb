Public Class cls_seealso
    Private m_error_number As Int32
    Private m_error_source As String
    Private m_error_description As String
    Private m_connection_string As String
    Private m_categories As New Collection()
    Private m_noicon As String

    Private m_item1_id As Int32
    Private m_item1_ico As String

    Private m_item2_id As Int32
    Private m_item2_ico As String

    Private m_item3_id As Int32
    Private m_item3_ico As String

    Private m_item4_id As Int32
    Private m_item4_ico As String

    Private m_item5_id As Int32
	Private m_item5_ico As String

	Private m_item6_id As Int32
	Private m_item6_ico As String

	Private m_item7_id As Int32
	Private m_item7_ico As String

	Private m_item8_id As Int32
	Private m_item8_ico As String

	Private m_item9_id As Int32
	Private m_item9_ico As String

	Private m_item10_id As Int32
	Private m_item10_ico As String

    '##########################################################################################
    Public Function get_item() As Boolean

        On Error GoTo ErrorHandler

        '--- Define local vars
        Dim bError As Boolean = False

        Dim nCount As Int32
        Dim nGetRecord As Int32

        '--- Count how many Records we have for this Possition
        bError = count_picture(nCount)

		Dim nCnt(10)
        Dim nLoop2 As Int16
        Dim nLoop3 As Int16

        '-- Randomize a RecordNumber
        Randomize()

		For nLoop2 = 1 To 10
			nCnt(nLoop2) = CInt(Int((nCount * Rnd()) + 1))
			'--- Check prev items
			For nLoop3 = 1 To nLoop2 - 1
				If nCnt(nLoop3) = nCnt(nLoop2) Then
					nCnt(nLoop2) = CInt(Int((nCount * Rnd()) + 1))
					Exit For
				End If
			Next

		Next




		'--- Get Item1 params
		bError = get_picture(nCnt(1), Me.item_id1, Me.item1_ico)
		If bError Then

		End If

		'--- Get Item2 params
		bError = get_picture(nCnt(2), Me.item_id2, Me.item2_ico)
		If bError Then

		End If

		'--- Get Item3 params
		bError = get_picture(nCnt(3), Me.item_id3, Me.item3_ico)
		If bError Then

		End If

		'--- Get Item4 params
		bError = get_picture(nCnt(4), Me.item_id4, Me.item4_ico)
		If bError Then

		End If

		'--- Get Item5 params
		bError = get_picture(nCnt(5), Me.item_id5, Me.item5_ico)
		If bError Then

		End If


		'--- Get Item6 params
		bError = get_picture(nCnt(6), Me.item_id6, Me.item6_ico)
		If bError Then

		End If

		'--- Get Item7 params
		bError = get_picture(nCnt(7), Me.item_id7, Me.item7_ico)
		If bError Then

		End If

		'--- Get Item8 params
		bError = get_picture(nCnt(8), Me.item_id8, Me.item8_ico)
		If bError Then

		End If

		'--- Get Item9 params
		bError = get_picture(nCnt(9), Me.item_id9, Me.item9_ico)
		If bError Then

		End If

		'--- Get Item10 params
		bError = get_picture(nCnt(10), Me.item_id10, Me.item10_ico)
		If bError Then

		End If




		'--- Get the price
		'Dim oTmpInventory As New ion_resources.cls_functions_inventory()
		'oTmpInventory.connection_string = Me.connection_string
		'bError = oTmpInventory.get_item_price(Me.item_id, bIsDealer, 0, Me.item_price)
		'oTmpInventory = Nothing

		'--- Everything id OK *
		Return False
		Exit Function


ErrorHandler:
		'--- when object is called in external DLL
		Me.error_description = Err.Number
		Me.error_source = Err.Source
		Me.error_description = Err.Description
		Return True
    End Function



    '##########################################################################################
    Private Function get_picture(ByVal nCounter As Int32, ByRef nId As Int32, ByRef cPath As String) As Boolean
        On Error GoTo ErrorHandler

        '--- Define local vars
        Dim bError As Boolean = False

        '--- Define Connection String
        Dim bConnection_open As Boolean = False
        Dim bDatareader_open As Boolean = False
        Dim cSQL As String
        cSQL = "select id, category_id, icon_name from inv_inventory where itemdeleted = 0 and club_item = 0 and shopstatus = 1"
        Dim objConn As New SqlClient.SqlConnection(Me.connection_string)
        Dim cSQLstring As SqlClient.SqlCommand = New SqlClient.SqlCommand(cSQL, objConn)
        objConn.Open()
        bConnection_open = True

        Dim dr_Reader As SqlClient.SqlDataReader = cSQLstring.ExecuteReader()
        bDatareader_open = True

        Dim nCategory_id As Int32
        Dim cIcon_name As String

        Dim nLoop As Int32
        While dr_Reader.Read()
            nLoop = nLoop + 1
            If nLoop = nCounter Then
                nId = dr_Reader.Item("id")
                nCategory_id = dr_Reader.Item("category_id")
                cIcon_name = dr_Reader.Item("icon_name")
                Exit While
            End If
        End While

        objConn.Close()
        dr_Reader.Close()

        '--- Construct Path
        If cIcon_name = "" Then
            cPath = Me.noicon
        Else
            cPath = Me.categories(nCategory_id).relative_path + cIcon_name
        End If




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
    Private Function count_picture(ByRef nCount As Int32) As Boolean
        On Error GoTo ErrorHandler

        '--- Define local vars
        Dim bError As Boolean = False

        '--- Define Connection String
        Dim bConnection_open As Boolean = False
        Dim bDatareader_open As Boolean = False
        Dim cSQL As String
        cSQL = "select count(id) as cnt from inv_inventory where itemdeleted = 0 and club_item = 0 and shopstatus = 1"
        Dim objConn As New SqlClient.SqlConnection(Me.connection_string)
        Dim cSQLstring As SqlClient.SqlCommand = New SqlClient.SqlCommand(cSQL, objConn)
        objConn.Open()
        bConnection_open = True

        Dim dr_Reader As SqlClient.SqlDataReader = cSQLstring.ExecuteReader()
        bDatareader_open = True


        While dr_Reader.Read()
            nCount = dr_Reader.Item("cnt")
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



    '##########################################################################################
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

    Public Property connection_string() As String
        Get
            Return m_connection_string
        End Get

        Set(ByVal Value As String)
            m_connection_string = Value
        End Set
    End Property

    Public Property item1_ico() As String
        Get
            Return m_item1_ico
        End Get

        Set(ByVal Value As String)
            m_item1_ico = Value
        End Set
    End Property

    Public Property item_id1() As Int32
        Get
            Return m_item1_id
        End Get

        Set(ByVal Value As Int32)
            m_item1_id = Value
        End Set
    End Property

    Public Property item2_ico() As String
        Get
            Return m_item2_ico
        End Get

        Set(ByVal Value As String)
            m_item2_ico = Value
        End Set
    End Property

    Public Property item_id2() As Int32
        Get
            Return m_item2_id
        End Get

        Set(ByVal Value As Int32)
            m_item2_id = Value
        End Set
    End Property

    Public Property item3_ico() As String
        Get
            Return m_item3_ico
        End Get

        Set(ByVal Value As String)
            m_item3_ico = Value
        End Set
    End Property

    Public Property item_id3() As Int32
        Get
            Return m_item3_id
        End Get

        Set(ByVal Value As Int32)
            m_item3_id = Value
        End Set
    End Property

    Public Property item4_ico() As String
        Get
            Return m_item4_ico
        End Get

        Set(ByVal Value As String)
            m_item4_ico = Value
        End Set
    End Property

    Public Property item_id4() As Int32
        Get
            Return m_item4_id
        End Get

        Set(ByVal Value As Int32)
            m_item4_id = Value
        End Set
    End Property

    Public Property item5_ico() As String
        Get
            Return m_item5_ico
        End Get

        Set(ByVal Value As String)
            m_item5_ico = Value
        End Set
    End Property

    Public Property item_id5() As Int32
        Get
            Return m_item5_id
        End Get

        Set(ByVal Value As Int32)
            m_item5_id = Value
        End Set
    End Property

	Public Property item6_ico() As String
		Get
			Return m_item6_ico
		End Get

		Set(ByVal Value As String)
			m_item6_ico = Value
		End Set
	End Property

	Public Property item_id6() As Int32
		Get
			Return m_item6_id
		End Get

		Set(ByVal Value As Int32)
			m_item6_id = Value
		End Set
	End Property

	Public Property item7_ico() As String
		Get
			Return m_item7_ico
		End Get

		Set(ByVal Value As String)
			m_item7_ico = Value
		End Set
	End Property

	Public Property item_id7() As Int32
		Get
			Return m_item7_id
		End Get

		Set(ByVal Value As Int32)
			m_item7_id = Value
		End Set
	End Property

	Public Property item8_ico() As String
		Get
			Return m_item8_ico
		End Get

		Set(ByVal Value As String)
			m_item8_ico = Value
		End Set
	End Property

	Public Property item_id8() As Int32
		Get
			Return m_item8_id
		End Get

		Set(ByVal Value As Int32)
			m_item8_id = Value
		End Set
	End Property

	Public Property item9_ico() As String
		Get
			Return m_item9_ico
		End Get

		Set(ByVal Value As String)
			m_item9_ico = Value
		End Set
	End Property

	Public Property item_id9() As Int32
		Get
			Return m_item9_id
		End Get

		Set(ByVal Value As Int32)
			m_item9_id = Value
		End Set
	End Property

	Public Property item10_ico() As String
		Get
			Return m_item10_ico
		End Get

		Set(ByVal Value As String)
			m_item10_ico = Value
		End Set
	End Property

	Public Property item_id10() As Int32
		Get
			Return m_item10_id
		End Get

		Set(ByVal Value As Int32)
			m_item10_id = Value
		End Set
	End Property

	Public Property categories() As Collection
		Get
			Return m_categories
		End Get

		Set(ByVal Value As Collection)
			m_categories = Value
		End Set
	End Property

	Public Property noicon() As String
		Get
			Return m_noicon
		End Get

		Set(ByVal Value As String)
			m_noicon = Value
		End Set
	End Property


End Class
