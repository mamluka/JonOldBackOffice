Public Class cls_functions_payment
	'--- Default properties for every class
	Private m_connection_string As String
	Private m_error_number As Int32
	Private m_error_source As String
	Private m_error_description As String


	'##########################################################################################
	Public Function get_master_confirmation(ByVal nOrderId As Int32, ByRef cConfirmation As String) As Boolean
        '*** Get CreditCard confirmation code from master payment

        On Error GoTo ErrorHandler

		'--- Define local vars
		Dim bError As Boolean = False

		'--- Define Connection String
		Dim bConnection_open As Boolean = False
		Dim bDatareader_open As Boolean = False
		Dim cSQL As String
		cSQL = "select cc_confirmation as confirmation from acc_cashflow where master = 1 and order_id = " & nOrderId
		Dim objConn As New SqlClient.SqlConnection(Me.connection_string)
		Dim cSQLstring As SqlClient.SqlCommand = New SqlClient.SqlCommand(cSQL, objConn)
		objConn.Open()
		bConnection_open = True

		Dim dr_Reader As SqlClient.SqlDataReader = cSQLstring.ExecuteReader()
		bDatareader_open = True

		While dr_Reader.Read()
			cConfirmation = dr_Reader.Item("confirmation")
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
	Public Function get_ordertotalpayed(ByVal nOrderId As Int32, ByRef nTotalPayed As Decimal) As Boolean
		On Error GoTo ErrorHandler

		'--- Define local vars
		Dim bError As Boolean = False

		'--- Get Payment type
		Dim nPaymentType As Int16
		Dim nPaymentName As String
		Dim oTmpOrderFunctions As New ion_resources.cls_functions_order()
		oTmpOrderFunctions.connection_string = Me.connection_string
		bError = oTmpOrderFunctions.get_initpaymentmethod(nOrderId, nPaymentType, nPaymentName)
		If bError Then
			Me.error_number = oTmpOrderFunctions.error_number
			Me.error_description = oTmpOrderFunctions.error_description
			Me.error_source = oTmpOrderFunctions.error_source
			Return True
		End If

		'--- Define Connection String
		Dim bConnection_open As Boolean = False
		Dim bDatareader_open As Boolean = False
		Dim cSQL As String
		If nPaymentType = 1 Then
			cSQL = "select sum(amount_total) as amount from acc_cashflow where master = 0 and approved = 1 and order_id = " & nOrderId
		Else
			cSQL = "select sum(amount_total) as amount from acc_cashflow where approved = 1 and order_id = " & nOrderId
		End If

		Dim objConn As New SqlClient.SqlConnection(Me.connection_string)
		Dim cSQLstring As SqlClient.SqlCommand = New SqlClient.SqlCommand(cSQL, objConn)
		objConn.Open()
		bConnection_open = True

		Dim dr_Reader As SqlClient.SqlDataReader = cSQLstring.ExecuteReader()
		bDatareader_open = True

		'--- Read
		Dim oRec As Object
		While dr_Reader.Read()
			oRec = dr_Reader.Item("amount")
		End While


		If IsDBNull(oRec) Then
			nTotalPayed = 0
		Else
			nTotalPayed = oRec
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


	'########################################################################################
	Public Function get_lastpay_ok(ByVal nOrderId As Int32, ByRef bApproved As Boolean) As Boolean
		On Error GoTo ErrorHandler

		'--- Define local vars
		Dim bError As Boolean = False

		'--- Define Connection String
		Dim bConnection_open As Boolean = False
		Dim bDatareader_open As Boolean = False
		Dim cSQL As String
		cSQL = "select max(payment_date) as approved from acc_cashflow where approved = 0 and order_id = " & nOrderId

		Dim objConn As New SqlClient.SqlConnection(Me.connection_string)
		Dim cSQLstring As SqlClient.SqlCommand = New SqlClient.SqlCommand(cSQL, objConn)
		objConn.Open()
		bConnection_open = True

		Dim dr_Reader As SqlClient.SqlDataReader = cSQLstring.ExecuteReader()
		bDatareader_open = True

		'--- Read
		Dim oRec As Object
		While dr_Reader.Read()
			oRec = dr_Reader.Item("approved")
		End While

		'--- If nothing found, everything is approved!
		If IsDBNull(oRec) Then
			bApproved = True
		Else
			bApproved = False
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
    Public Function get_master_cardinfo(ByVal nOrderId As Int32, ByRef nCc_type_id As Int32, ByRef cCc_name As String, ByRef cCc_number As String, ByRef cCc_cvv As String, ByRef cCc_exp_year As String, ByRef cCc_exp_month As String, ByRef cCc_user_ssn As String, ByRef cCc_confirmation As String, ByRef cCc_clubmember As String) As Boolean
        '*** Get creditcard payment info from master payment

        On Error GoTo ErrorHandler

        '--- Define local vars
        Dim bError As Boolean = False

        '--- Define Connection String
        Dim bConnection_open As Boolean = False
        Dim bDatareader_open As Boolean = False
        Dim cSQL As String
        cSQL = "select cc_type_id, cc_name, cc_number, cc_cvv, cc_exp_year, cc_exp_month, cc_user_ssn, cc_confirmation,cc_clubmember from acc_cashflow where master = 1 and order_id = " & nOrderId
        Dim objConn As New SqlClient.SqlConnection(Me.connection_string)
        Dim cSQLstring As SqlClient.SqlCommand = New SqlClient.SqlCommand(cSQL, objConn)
        objConn.Open()
        bConnection_open = True

        Dim dr_Reader As SqlClient.SqlDataReader = cSQLstring.ExecuteReader()
        bDatareader_open = True

        While dr_Reader.Read()
            nCc_type_id = dr_Reader.Item("cc_type_id")
            cCc_name = dr_Reader.Item("cc_name")
            cCc_number = dr_Reader.Item("cc_number")
            cCc_cvv = dr_Reader.Item("cc_cvv")
            cCc_exp_year = dr_Reader.Item("cc_exp_year")
            cCc_exp_month = dr_Reader.Item("cc_exp_month")
            cCc_user_ssn = dr_Reader.Item("cc_user_ssn")
            cCc_confirmation = dr_Reader.Item("cc_confirmation")
            cCc_clubmember = dr_Reader.Item("cc_clubmember")
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
    Public Function get_total_transaction_costs(ByVal nOrderId As Int32, ByRef nTotal_trs_costs As Decimal) As Boolean
        '*** Get all the transaction costs for this order

        On Error GoTo ErrorHandler

        '--- Define local vars
        Dim bError As Boolean = False

        '--- Define Connection String
        Dim bConnection_open As Boolean = False
        Dim bDatareader_open As Boolean = False
        Dim cSQL As String
        cSQL = "select sum(amount_costs) as 'trs_costs' from acc_cashflow where order_id = " & nOrderId
        Dim objConn As New SqlClient.SqlConnection(Me.connection_string)
        Dim cSQLstring As SqlClient.SqlCommand = New SqlClient.SqlCommand(cSQL, objConn)
        objConn.Open()
        bConnection_open = True

        Dim dr_Reader As SqlClient.SqlDataReader = cSQLstring.ExecuteReader()
        bDatareader_open = True

        While dr_Reader.Read()
            nTotal_trs_costs = dr_Reader.Item("trs_costs")
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
    Public Function get_total_interest_payed(ByVal nOrderId As Int32, ByRef nTotal_Interest As Decimal) As Boolean
        '*** Get all the interest payed for this order

        On Error GoTo ErrorHandler

        '--- Define local vars
        Dim bError As Boolean = False

        '--- Define Connection String
        Dim bConnection_open As Boolean = False
        Dim bDatareader_open As Boolean = False
        Dim cSQL As String
        cSQL = "select sum(amount_interest) as 'interest'  from acc_cashflow where order_id =" & nOrderId
        Dim objConn As New SqlClient.SqlConnection(Me.connection_string)
        Dim cSQLstring As SqlClient.SqlCommand = New SqlClient.SqlCommand(cSQL, objConn)
        objConn.Open()
        bConnection_open = True

        Dim dr_Reader As SqlClient.SqlDataReader = cSQLstring.ExecuteReader()
        bDatareader_open = True

        While dr_Reader.Read()
            nTotal_Interest = dr_Reader.Item("interest")
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
