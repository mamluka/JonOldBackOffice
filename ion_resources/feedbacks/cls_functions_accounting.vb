Public Class cls_functions_accounting
	'--- Default properties for every class
	Private m_connection_string As String
	Private m_error_number As Int32
	Private m_error_source As String
	Private m_error_description As String


    '##########################################################################################
    Public Function get_account_total(ByVal nAccountId As Int32, ByRef nAccountTotal As Decimal) As Boolean
        On Error GoTo ErrorHandler

        '--- Define local vars
        Dim bError As Boolean = False

        '--- Define Connection String
        Dim bConnection_open As Boolean = False
        Dim bDatareader_open As Boolean = False
        Dim cSQL As String
        cSQL = "select sum(amount) as amount from v_general_books where account_id = " & nAccountId
        Dim objConn As New SqlClient.SqlConnection(Me.connection_string)
        Dim cSQLstring As SqlClient.SqlCommand = New SqlClient.SqlCommand(cSQL, objConn)
        objConn.Open()
        bConnection_open = True

        Dim dr_Reader As SqlClient.SqlDataReader = cSQLstring.ExecuteReader()
        bDatareader_open = True

        While dr_Reader.Read()
            nAccountTotal = dr_Reader.Item("amount")
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
    Public Function get_account_name(ByVal nAccountId As Int32, ByRef cAccountName As String) As Boolean
        On Error GoTo ErrorHandler

        '--- Define local vars
        Dim bError As Boolean = False

        '--- Define Connection String
        Dim bConnection_open As Boolean = False
        Dim bDatareader_open As Boolean = False
        Dim cSQL As String
        cSQL = "select lang1_longdescr from acc_account_names where id = " & nAccountId
        Dim objConn As New SqlClient.SqlConnection(Me.connection_string)
        Dim cSQLstring As SqlClient.SqlCommand = New SqlClient.SqlCommand(cSQL, objConn)
        objConn.Open()
        bConnection_open = True

        Dim dr_Reader As SqlClient.SqlDataReader = cSQLstring.ExecuteReader()
        bDatareader_open = True

        Dim nBranchId As Int32
        Dim nSupplierNumber As Int32
        While dr_Reader.Read()
            cAccountName = dr_Reader.Item("lang1_longdescr")
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
    Public Function set_rate(ByVal nCurId As Int32, ByVal dRateDate As DateTime, ByVal nRate As Decimal) As Boolean
        On Error GoTo ErrorHandler

        '--- Define local vars
        Dim bError As Boolean = False


        '--- Change Item
        '--- Define Connection String
        Dim objConn As New SqlClient.SqlConnection(Me.connection_string)
        Dim cSQLstring As SqlClient.SqlCommand

        cSQLstring = New SqlClient.SqlCommand("insert into sys_rates (cur_id, rate_date, rate) values (" & nCurId & ", '" & dRateDate & "', " & nRate & ")", objConn)
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
    Public Function get_rate(ByRef nRate As Decimal, Optional ByRef dDate As DateTime = #1/1/1900#) As Boolean
        On Error GoTo ErrorHandler

        '--- Define local vars
        Dim bError As Boolean = False

        '--- Define Connection String
        Dim bConnection_open As Boolean = False
        Dim bDatareader_open As Boolean = False
        Dim cSQL As String
        If dDate <> #1/1/1900# Then
            cSQL = "select rate_date, rate from sys_rates where rate_date = '" & dDate & "' order by rate_date desc"
        Else
            cSQL = "select rate_date, rate from sys_rates order by rate_date desc"
        End If

        Dim objConn As New SqlClient.SqlConnection(Me.connection_string)
        Dim cSQLstring As SqlClient.SqlCommand = New SqlClient.SqlCommand(cSQL, objConn)
        objConn.Open()
        bConnection_open = True

        Dim dr_Reader As SqlClient.SqlDataReader = cSQLstring.ExecuteReader()
        bDatareader_open = True

        While dr_Reader.Read()
            dDate = dr_Reader.Item("rate_date")
            nRate = dr_Reader.Item("rate")
            Exit While
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
