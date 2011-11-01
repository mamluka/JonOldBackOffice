Public Class cls_functions_order
	'--- Default properties for every class
	Private m_connection_string As String
	Private m_error_number As Int32
	Private m_error_source As String
	Private m_error_description As String


	'##########################################################################################
	Public Function get_lastorderno(ByRef nLastOrder As Int32) As Boolean
		'On Error GoTo ErrorHandler

		'--- Define local vars
		Dim bError As Boolean = False

		'--- Define Connection String
		Dim objConn As New SqlClient.SqlConnection(Me.connection_string)
        Dim cSQLstring As SqlClient.SqlCommand = New SqlClient.SqlCommand("select counter from sys_COUNTERS where id= 1", objConn)
		objConn.Open()

		Dim dr_Reader As SqlClient.SqlDataReader = cSQLstring.ExecuteReader()

		dr_Reader.Read()
        nLastOrder = dr_Reader.Item("counter")

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
	Function get_shipping(ByVal nCountryId As Int32, ByVal nStateId As Int32, ByRef nVat_amnt As Decimal, ByRef nCourier_amnt As Decimal, ByRef nCourier_days As Int16, ByRef nEms_amnt As Decimal, ByRef nEms_days As Int16, ByRef nFedex_amnt As Decimal, ByRef nFedex_days As Int16) As Boolean
		On Error GoTo ErrorHandler

		'--- Define local vars
		Dim bError As Boolean = False


		Dim nVat_amnt_cnt As Decimal
		Dim nCourier_amnt_cnt As Decimal
		Dim nCourier_days_cnt As Int16
		Dim nEms_amnt_cnt As Decimal
		Dim nEms_days_cnt As Int16
		Dim nFedex_amnt_cnt As Decimal
		Dim nFedex_days_cnt As Int16
		bError = get_shipping_country(nCountryId, nStateId, nVat_amnt_cnt, nCourier_amnt_cnt, nCourier_days_cnt, nEms_amnt_cnt, nEms_days_cnt, nFedex_amnt_cnt, nFedex_days_cnt)

		Dim nVat_amnt_sts As Decimal
		Dim nCourier_amnt_sts As Decimal
		Dim nCourier_days_sts As Int16
		Dim nEms_amnt_sts As Decimal
		Dim nEms_days_sts As Int16
		Dim nFedex_amnt_sts As Decimal
		Dim nFedex_days_sts As Int16
		bError = get_shipping_state(nCountryId, nStateId, nVat_amnt_sts, nCourier_amnt_sts, nCourier_days_sts, nEms_amnt_sts, nEms_days_sts, nFedex_amnt_sts, nFedex_days_sts)


		nVat_amnt = nVat_amnt_cnt + nVat_amnt_sts
		nCourier_amnt = nCourier_amnt_cnt + nCourier_amnt_sts
		nCourier_days = nCourier_days_cnt + nCourier_days_sts
		nEms_amnt = nEms_amnt_cnt + nEms_amnt_sts
		nEms_days = nEms_days_cnt + nEms_days_sts
		nFedex_amnt = nFedex_amnt_cnt + nFedex_amnt_sts
		nFedex_days = nFedex_days_cnt + nFedex_days_sts


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
	Private Function get_shipping_country(ByVal nCountryId As Int32, ByVal nStateId As Int32, ByRef nVat_amnt As Decimal, ByRef nCourier_amnt As Decimal, ByRef nCourier_days As Int16, ByRef nEms_amnt As Decimal, ByRef nEms_days As Int16, ByRef nFedex_amnt As Decimal, ByRef nFedex_days As Int16) As Boolean
		On Error GoTo ErrorHandler

		'--- Define local vars
		Dim bError As Boolean = False

		'--- Define Connection String
		Dim bConnection_open As Boolean = False
		Dim bDatareader_open As Boolean = False
		Dim cSQL As String
		cSQL = "select vat, courier_charges, courier_time, ems_charges, ems_time, fedex_charges, fedex_time  from sys_country where ID =" & nCountryId
		Dim objConn As New SqlClient.SqlConnection(Me.connection_string)
		Dim cSQLstring As SqlClient.SqlCommand = New SqlClient.SqlCommand(cSQL, objConn)
		objConn.Open()
		bConnection_open = True

		Dim dr_Reader As SqlClient.SqlDataReader = cSQLstring.ExecuteReader()
		bDatareader_open = True

		While dr_Reader.Read()
			nVat_amnt = dr_Reader.Item("vat")
			nCourier_amnt = dr_Reader.Item("courier_charges")
			nCourier_days = dr_Reader.Item("courier_time")
			nEms_amnt = dr_Reader.Item("ems_charges")
			nEms_days = dr_Reader.Item("ems_time")
			nFedex_amnt = dr_Reader.Item("fedex_charges")
			nFedex_days = dr_Reader.Item("fedex_time")
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
	Private Function get_shipping_state(ByVal nCountryId As Int32, ByVal nStateId As Int32, ByRef nVat_amnt As Decimal, ByRef nCourier_amnt As Decimal, ByRef nCourier_days As Int16, ByRef nEms_amnt As Decimal, ByRef nEms_days As Int16, ByRef nFedex_amnt As Decimal, ByRef nFedex_days As Int16) As Boolean
		On Error GoTo ErrorHandler

		'--- Define local vars
		Dim bError As Boolean = False

		'--- Define Connection String
		Dim bConnection_open As Boolean = False
		Dim bDatareader_open As Boolean = False
		Dim cSQL As String
		cSQL = "select vat, courier_charges, courier_time, ems_charges, ems_time, fedex_charges, fedex_time  from sys_state where ID =" & nStateId
		Dim objConn As New SqlClient.SqlConnection(Me.connection_string)
		Dim cSQLstring As SqlClient.SqlCommand = New SqlClient.SqlCommand(cSQL, objConn)
		objConn.Open()
		bConnection_open = True

		Dim dr_Reader As SqlClient.SqlDataReader = cSQLstring.ExecuteReader()
		bDatareader_open = True

		While dr_Reader.Read()
			nVat_amnt = dr_Reader.Item("vat")
			nCourier_amnt = dr_Reader.Item("courier_charges")
			nCourier_days = dr_Reader.Item("courier_time")
			nEms_amnt = dr_Reader.Item("ems_charges")
			nEms_days = dr_Reader.Item("ems_time")
			nFedex_amnt = dr_Reader.Item("fedex_charges")
			nFedex_days = dr_Reader.Item("fedex_time")
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
	Public Function get_cc_codes(ByVal nCCId As Int32, ByRef nExtraCharges As Decimal, ByRef nArrivalDays As Int16, ByRef nProviderCode As Int16) As Boolean
		'On Error GoTo ErrorHandler

		'--- Define local vars
		Dim bError As Boolean = False

		'--- Define Connection String
		Dim bConnection_open As Boolean = False
		Dim bDatareader_open As Boolean = False
		Dim cSQL As String
		cSQL = "select ExtraCharges, ArrivalDays, ProviderCode from acc_CREDITCARD where ID =" & nCCId
		Dim objConn As New SqlClient.SqlConnection(Me.connection_string)
		Dim cSQLstring As SqlClient.SqlCommand = New SqlClient.SqlCommand(cSQL, objConn)
		objConn.Open()
		bConnection_open = True

		Dim dr_Reader As SqlClient.SqlDataReader = cSQLstring.ExecuteReader()
		bDatareader_open = True

		While dr_Reader.Read()
			nExtraCharges = dr_Reader.Item("ExtraCharges")
			nArrivalDays = dr_Reader.Item("ArrivalDays")
			nProviderCode = dr_Reader.Item("ProviderCode")
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
    Public Function get_ordernumber(ByVal nOrderId As Int32, ByRef nOrderNumber As Int32) As Boolean
        On Error GoTo ErrorHandler

        '--- Define local vars
        Dim bError As Boolean = False

        '--- Define Connection String
        Dim bConnection_open As Boolean = False
        Dim bDatareader_open As Boolean = False
        Dim cSQL As String
        cSQL = "select id, ordernumber  from acc_ORDERS where ID =" & nOrderId
        Dim objConn As New SqlClient.SqlConnection(Me.connection_string)
        Dim cSQLstring As SqlClient.SqlCommand = New SqlClient.SqlCommand(cSQL, objConn)
        objConn.Open()
        bConnection_open = True

        Dim dr_Reader As SqlClient.SqlDataReader = cSQLstring.ExecuteReader()
        bDatareader_open = True


        While dr_Reader.Read()
            nOrderNumber = dr_Reader.Item("ordernumber")
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
    Public Function get_order_total(ByVal nOrderId As Int32, ByRef nOrderTotal As Decimal) As Boolean
        On Error GoTo ErrorHandler

        '--- Define local vars
        Dim bError As Boolean = False

        '--- Define Connection String
        Dim bConnection_open As Boolean = False
        Dim bDatareader_open As Boolean = False
        Dim cSQL As String
        cSQL = "select id, amnt_grandtotal from acc_ORDERS where ID =" & nOrderId
        Dim objConn As New SqlClient.SqlConnection(Me.connection_string)
        Dim cSQLstring As SqlClient.SqlCommand = New SqlClient.SqlCommand(cSQL, objConn)
        objConn.Open()
        bConnection_open = True

        Dim dr_Reader As SqlClient.SqlDataReader = cSQLstring.ExecuteReader()
        bDatareader_open = True


        dr_Reader.Read()
        nOrderTotal = dr_Reader.Item("amnt_grandtotal")


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
    Public Function get_orderuserid(ByVal nOrderId As Int32, ByRef nOrderuserId As Int32) As Boolean
        On Error GoTo ErrorHandler

        '--- Define local vars
        Dim bError As Boolean = False

        '--- Define Connection String
        Dim bConnection_open As Boolean = False
        Dim bDatareader_open As Boolean = False
        Dim cSQL As String
        cSQL = "select id, user_id  from acc_ORDERS where ID =" & nOrderId
        Dim objConn As New SqlClient.SqlConnection(Me.connection_string)
        Dim cSQLstring As SqlClient.SqlCommand = New SqlClient.SqlCommand(cSQL, objConn)
        objConn.Open()
        bConnection_open = True

        Dim dr_Reader As SqlClient.SqlDataReader = cSQLstring.ExecuteReader()
        bDatareader_open = True

        While dr_Reader.Read()
            nOrderuserId = dr_Reader.Item("user_id")
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
    Public Function get_initpaymentmethod(ByVal nOrderId As Int32, ByRef nPaymentType As Int16, ByRef cPaymentName As String) As Boolean
        On Error GoTo ErrorHandler

        '--- Define local vars
        Dim bError As Boolean = False

        '--- Define Connection String
        Dim bConnection_open As Boolean = False
        Dim bDatareader_open As Boolean = False
        Dim cSQL As String
        cSQL = "select acc_cashflow.id, acc_cashflow.payment_type, acc_payment_methods.lang1_longdescr as payment_name "
        cSQL = cSQL + "from acc_cashflow, acc_payment_methods "
        cSQL = cSQL + "where   acc_cashflow.payment_type =  acc_payment_methods.id "
        cSQL = cSQL + "and master = 1 and order_id = " & nOrderId
        Dim objConn As New SqlClient.SqlConnection(Me.connection_string)
        Dim cSQLstring As SqlClient.SqlCommand = New SqlClient.SqlCommand(cSQL, objConn)
        objConn.Open()
        bConnection_open = True

        Dim dr_Reader As SqlClient.SqlDataReader = cSQLstring.ExecuteReader()
        bDatareader_open = True

        While dr_Reader.Read()
            nPaymentType = dr_Reader.Item("payment_type")
            cPaymentName = dr_Reader.Item("payment_name")
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


    '#########################################################################################
    Public Function get_initpayment(ByVal nOrderId As Int32, ByRef nInitPayment As Decimal) As Boolean
        On Error GoTo ErrorHandler

        '--- Define local vars
        Dim bError As Boolean = False

        '--- Define Connection String
        Dim bConnection_open As Boolean = False
        Dim bDatareader_open As Boolean = False
        Dim cSQL As String
        cSQL = "select id, amount_total from acc_CASHFLOW where master = 1 and order_id =" & nOrderId
        Dim objConn As New SqlClient.SqlConnection(Me.connection_string)
        Dim cSQLstring As SqlClient.SqlCommand = New SqlClient.SqlCommand(cSQL, objConn)
        objConn.Open()
        bConnection_open = True

        Dim dr_Reader As SqlClient.SqlDataReader = cSQLstring.ExecuteReader()
        bDatareader_open = True

        While dr_Reader.Read()
            nInitPayment = dr_Reader.Item("amount_total")
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


    '#########################################################################################
    Public Function get_isapproved(ByVal nOrderId As Int32, ByRef bApproved As Boolean) As Boolean
        On Error GoTo ErrorHandler

        '--- Define local vars
        Dim bError As Boolean = False

        '--- Define Connection String
        Dim bConnection_open As Boolean = False
        Dim bDatareader_open As Boolean = False
        Dim cSQL As String
        'cSQL = "select approved, amount_total from acc_cashflow where master = 1 and order_id = " & nOrderId
        cSQL = "select approved, amount_total from acc_cashflow where approved = 0 and order_id = " & nOrderId

        Dim objConn As New SqlClient.SqlConnection(Me.connection_string)
        Dim cSQLstring As SqlClient.SqlCommand = New SqlClient.SqlCommand(cSQL, objConn)
        objConn.Open()
        bConnection_open = True

        Dim dr_Reader As SqlClient.SqlDataReader = cSQLstring.ExecuteReader()
        bDatareader_open = True

        Dim nLoop As Int16 = 0
        While dr_Reader.Read()
            bApproved = dr_Reader.Item("approved")
            nLoop = nLoop + 1
        End While

        '--- If no data was read from SELECTION then no 'NOT-APPROVED' transactions found
        If nLoop = 0 Then
            bApproved = True
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


    '#########################################################################################
    Public Function get_interest(ByVal nOrderId As Int32, ByRef Interest_rate As Decimal, ByRef Interest_startdate As Date) As Boolean
        On Error GoTo ErrorHandler

        '--- Define local vars
        Dim bError As Boolean = False

        '--- Define Connection String
        Dim bConnection_open As Boolean = False
        Dim bDatareader_open As Boolean = False
        Dim cSQL As String
        cSQL = "select Interest_percent, Interest_start_date from acc_orders where id = " & nOrderId
        Dim objConn As New SqlClient.SqlConnection(Me.connection_string)
        Dim cSQLstring As SqlClient.SqlCommand = New SqlClient.SqlCommand(cSQL, objConn)
        objConn.Open()
        bConnection_open = True

        Dim dr_Reader As SqlClient.SqlDataReader = cSQLstring.ExecuteReader()
        bDatareader_open = True

        While dr_Reader.Read()
            Interest_rate = dr_Reader.Item("Interest_percent")
            Interest_startdate = dr_Reader.Item("Interest_start_date")
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



    '########################################################################################
    Public Function set_approved(ByVal nOrder_Id) As Boolean
        On Error GoTo ErrorHandler

        '--- Define local vars
        Dim bError As Boolean = False

        '--- Define Connection String
        Dim bConnection_open As Boolean = False
        Dim bDatareader_open As Boolean = False
        Dim objConn As New SqlClient.SqlConnection(Me.connection_string)
        Dim cSQLstring As SqlClient.SqlCommand

        cSQLstring = New SqlClient.SqlCommand("update acc_cashflow set approved = 1 where master = 1 and order_id=" & nOrder_Id, objConn)

        objConn.Open()
        bConnection_open = True

        Dim dr_Reader As SqlClient.SqlDataReader = cSQLstring.ExecuteReader()
        bDatareader_open = True

        If dr_Reader.RecordsAffected <> 1 Then
            bError = True
        End If

        objConn.Close()
        dr_Reader.Close()

        Return bError
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

	'########################################################################################
	Public Function set_cur_inventory(ByVal nItem_Id, ByVal nQuantity) As Boolean
		On Error GoTo ErrorHandler

		'--- Define local vars
		Dim bError As Boolean = False

		'--- Define Connection String
		Dim bConnection_open As Boolean = False
		Dim bDatareader_open As Boolean = False
		Dim objConn As New SqlClient.SqlConnection(Me.connection_string)
		Dim cSQLstring As SqlClient.SqlCommand

		cSQLstring = New SqlClient.SqlCommand("update inv_inventory set qtyonstock_cur = qtyonstock_cur -" + Convert.ToString(nQuantity) + " where id=" & nItem_Id, objConn)

		objConn.Open()
		bConnection_open = True

		Dim dr_Reader As SqlClient.SqlDataReader = cSQLstring.ExecuteReader()
		bDatareader_open = True

		If dr_Reader.RecordsAffected <> 1 Then
			bError = True
		End If

		objConn.Close()
		dr_Reader.Close()

		Return bError
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
	Public Function get_order_transact(ByVal nOrderId As Int32, ByRef nOrder_Transact As Boolean) As Boolean
		On Error GoTo ErrorHandler

		'--- Define local vars
		Dim bError As Boolean = False

		'--- Define Connection String
		Dim bConnection_open As Boolean = False
		Dim bDatareader_open As Boolean = False
		Dim cSQL As String
		cSQL = "select id, order_transacted from acc_ORDERS where ID =" & nOrderId
		Dim objConn As New SqlClient.SqlConnection(Me.connection_string)
		Dim cSQLstring As SqlClient.SqlCommand = New SqlClient.SqlCommand(cSQL, objConn)
		objConn.Open()
		bConnection_open = True

		Dim dr_Reader As SqlClient.SqlDataReader = cSQLstring.ExecuteReader()
		bDatareader_open = True


		While dr_Reader.Read()
			nOrder_Transact = dr_Reader.Item("order_Transacted")
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
	Public Function get_order_readonly(ByVal nOrderId As Int32, ByRef bOrderReadOnly As Boolean) As Boolean
		On Error GoTo ErrorHandler

		'--- Define local vars
		Dim bError As Boolean = False

		'--- Define Connection String
		Dim bConnection_open As Boolean = False
		Dim bDatareader_open As Boolean = False
		Dim cSQL As String
		cSQL = "select id, cannot_be_edited  from acc_ORDERS where ID =" & nOrderId
		Dim objConn As New SqlClient.SqlConnection(Me.connection_string)
		Dim cSQLstring As SqlClient.SqlCommand = New SqlClient.SqlCommand(cSQL, objConn)
		objConn.Open()
		bConnection_open = True

		Dim dr_Reader As SqlClient.SqlDataReader = cSQLstring.ExecuteReader()
		bDatareader_open = True


		While dr_Reader.Read()
			bOrderReadOnly = dr_Reader.Item("cannot_be_edited")
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
