Public Class cls_cons_description
    Private m_oerror As Object
    Private m_connection_string As String
    Private m_description As String
    Private m_plate As Integer
    Private m_id As Int32
	Private m_round As Boolean
	Public category_id As Int32
	Public workingdomain As String
	Public seo_title As String
	Public seo_keywords As String
	Public seo_description As String
	Public seo_abstract As String


    Function construct() As Boolean
        On Error GoTo ErrorHandler

        '--- Define local vars
        Dim bError As Boolean = False

        '--- Get plate
        Dim oFunctions As New cls_functions_inventory()
        oFunctions.connection_string = Me.connection_string
        bError = oFunctions.get_plateno_by_id(Me.id, Me.plate)
        If bError Then
            Me.oerror.err_number = Err.Number
            Me.oerror.err_description = Err.Description
            Me.oerror.err_source = Err.Source
            Return True
        End If


        '--- Define Connection String
        Dim bConnection_open As Boolean = False
        Dim bDatareader_open As Boolean = False
        Dim cSQL As String
        Dim objConn As New SqlClient.SqlConnection(Me.connection_string)
        Select Case Me.m_plate
            Case 1
                cSQL = "select * from v_inventory_diamonds_fullinfo where id = " + System.Convert.ToString(Me.id)
            Case 2
                cSQL = "select * from v_inventory_gemstones_fullinfo where id = " + System.Convert.ToString(Me.id)
            Case 3
                cSQL = "select * from v_inventory_jewelry_fullinfo where id = " + System.Convert.ToString(Me.id)
        End Select

        Dim cSQLstring As SqlClient.SqlCommand = New SqlClient.SqlCommand(cSQL, objConn)
        objConn.Open()
        bConnection_open = True

        Dim dr_Reader As SqlClient.SqlDataReader = cSQLstring.ExecuteReader()
        bDatareader_open = True

        While dr_Reader.Read()

			Dim nCarat As Decimal = dr_Reader.Item("weight")
			Dim cCarat As String = ""
			Dim nCategory_id As Int32 = 0

			'--- Round results if needed
			If Me.round Then
				cCarat = Format(Decimal.Round(nCarat, 1), "##,##0.00")
				Dim nLen As Int16 = Len(cCarat)

				If Mid(cCarat, nLen - 2, nLen) = ".00" Then
					cCarat = Mid(cCarat, 1, nLen - 3)

				ElseIf Mid(cCarat, nLen - 1, nLen) = ".0" Then
					cCarat = Mid(cCarat, 1, nLen - 2)

				ElseIf Mid(cCarat, nLen, nLen) = "0" Then
					cCarat = Mid(cCarat, 1, nLen - 1)

				End If

				cCarat = cCarat + " (" + Format(Decimal.Round(nCarat, 1), "##,##0.00") + ")"

			Else
					cCarat = Format(nCarat, "##,##0.00")

				End If

				'--- Get Category_id
				Me.category_id = dr_Reader.Item("category_id")


				Select Case Me.m_plate
					Case 1

						Me.description = dr_Reader.Item("stonetype_short") + " "

						Me.description = Me.description + cCarat + " carat"

						If dr_Reader.Item("shape_short") <> "-" Then
							Me.description = Me.description + ", " + dr_Reader.Item("shape_short")
						End If

						If dr_Reader.Item("colorfrom_short") <> "-" Then
							Me.description = Me.description + ", " + dr_Reader.Item("colorfrom_short")
						End If
						If dr_Reader.Item("clarityfrom_short") <> "-" Then
							Me.description = Me.description + " " + dr_Reader.Item("clarityfrom_short")
						End If

						If dr_Reader.Item("colorto_short") <> "-" Then
							Me.description = Me.description + " - " + dr_Reader.Item("colorto_short")
						End If
						If dr_Reader.Item("clarityto_short") <> "-" Then
							Me.description = Me.description + " " + dr_Reader.Item("clarityto_short")
						End If

					Case 2
						Me.description = dr_Reader.Item("stonetype_short") + " "
						Me.description = Me.description + cCarat + " carat"
						If dr_Reader.Item("shape_short") <> "-" Then
							Me.description = Me.description + ", " + dr_Reader.Item("shape_short")
						End If

						If dr_Reader.Item("origin_short") <> "-" Then
							Me.description = Me.description + " Origin: " + dr_Reader.Item("origin_short")
						End If

					Case 3
						Me.description = Trim(dr_Reader.Item("jewelsubtype_short"))
						Me.description = Me.description + " " + Trim(dr_Reader.Item("jeweltype_short"))
						If dr_Reader.Item("middlestone_short") <> "-" Then
							Me.description = Trim(Me.description) + " - " + Trim(dr_Reader.Item("middlestone_short"))
						End If

						Me.description = Me.description + " - " + Convert.ToString(Format(dr_Reader.Item("weight"), "##,##0.00")) + " grams"

						If dr_Reader.Item("metal_short") <> "-" Then
							Me.description = Me.description + ", " + dr_Reader.Item("metal_short")
						End If

				End Select

		End While

		'--- set description
        Me.description = Trim(Me.description)

		'--- get SEO
		If Me.workingdomain <> "" Then
			Dim oTmpSEO As New ion_resources.cls_SEO
			bError = oTmpSEO.getSEO_categories(Me.workingdomain, Me.m_plate, Me.category_id)

			Me.seo_title = "<title> " + oTmpSEO._title + " </title>"
			Me.seo_keywords = "<meta content=" + Chr(34) + oTmpSEO._keywords + Chr(34) + " name=" + Chr(34) + "keywords" + Chr(34) + ">"
			Me.seo_description = "<meta content=" + Chr(34) + oTmpSEO._description + Chr(34) + " name=" + Chr(34) + "description" + Chr(34) + ">"
			Me.seo_abstract = "<meta content=" + Chr(34) + oTmpSEO._abstract + Chr(34) + " name" + Chr(34) + "abstract" + Chr(34) + ">"

			oTmpSEO = Nothing
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
		Me.oerror.err_number = Err.Number
		Me.oerror.err_description = Err.Description
		Me.oerror.err_source = Err.Source
		Return True

    End Function


    Public Property oerror() As Object
        Get
            Return m_oerror
        End Get

        Set(ByVal Value As Object)
            m_oerror = Value
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

    Public Property description() As String
        Get
            Return m_description
        End Get

        Set(ByVal Value As String)
            m_description = Value
        End Set
    End Property

    Public Property plate() As Integer
        Get
            Return m_plate
        End Get

        Set(ByVal Value As Integer)
            m_plate = Value
        End Set
    End Property

    Public Property id() As Int32
        Get
            Return m_id
        End Get

        Set(ByVal Value As Int32)
            m_id = Value
        End Set
    End Property

    Public Property round() As Boolean
        Get
            Return m_round
        End Get

        Set(ByVal Value As Boolean)
            m_round = Value
        End Set
    End Property
End Class
