Public Class cls_functions_customers
    '--- Default properties for every class
    Private m_connection_string As String
    Private m_error_number As Int32
    Private m_error_source As String
    Private m_error_description As String

    '##########################################################################################
    Public Function get_IsDealer(ByVal nUserId As Int32, ByRef bIsDealer As Boolean) As Boolean
        On Error GoTo ErrorHandler

        '--- Define local vars
        Dim bError As Boolean = False

        '--- Define Connection String
        Dim bConnection_open As Boolean = False
        Dim bDatareader_open As Boolean = False
        Dim cSQL As String
        cSQL = "select id, dealer  from usr_CUSTOMERS where ID =" & nUserId
        Dim objConn As New SqlClient.SqlConnection(Me.connection_string)
        Dim cSQLstring As SqlClient.SqlCommand = New SqlClient.SqlCommand(cSQL, objConn)
        objConn.Open()
        bConnection_open = True

        Dim dr_Reader As SqlClient.SqlDataReader = cSQLstring.ExecuteReader()
        bDatareader_open = True

        While dr_Reader.Read()
            bIsDealer = dr_Reader.Item("dealer")
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
    Public Function get_customer_exist(ByVal nUserId As Int32, ByRef bExist As Boolean) As Boolean
        On Error GoTo ErrorHandler

        '--- Define local vars
        Dim bError As Boolean = False

        '--- Define Connection String
        Dim bConnection_open As Boolean = False
        Dim bDatareader_open As Boolean = False
        Dim cSQL As String
        cSQL = "select id from usr_CUSTOMERS where ID =" & nUserId
        Dim objConn As New SqlClient.SqlConnection(Me.connection_string)
        Dim cSQLstring As SqlClient.SqlCommand = New SqlClient.SqlCommand(cSQL, objConn)
        objConn.Open()
        bConnection_open = True

        Dim dr_Reader As SqlClient.SqlDataReader = cSQLstring.ExecuteReader()
        bDatareader_open = True

        Dim nId As Int32
        While dr_Reader.Read()
            nId = dr_Reader.Item("id")
            bExist = True
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
    Function get_email_exist(ByVal cEmail As String, ByRef bExists As Boolean) As Boolean
        On Error GoTo ErrorHandler

        '--- Define local vars
        Dim bError As Boolean = False

        '--- Define Connection String
        Dim bConnection_open As Boolean = False
        Dim bDatareader_open As Boolean = False
        Dim cSQL As String
        cSQL = "select id from usr_CUSTOMERS where email='" + cEmail + "'"
        Dim objConn As New SqlClient.SqlConnection(Me.connection_string)
        Dim cSQLstring As SqlClient.SqlCommand = New SqlClient.SqlCommand(cSQL, objConn)
        objConn.Open()
        bConnection_open = True

        Dim dr_Reader As SqlClient.SqlDataReader = cSQLstring.ExecuteReader()
        bDatareader_open = True

        Dim nTmpId As Integer = 0
        Dim nCounter As Integer = 0
        While dr_Reader.Read()
            nTmpId = dr_Reader.Item("id")
            nCounter = nCounter + 1
        End While

        If nCounter > 0 Then
            bExists = True
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
    Function get_password(ByVal cEmail As String, ByRef cPassword As String) As Boolean
        On Error GoTo ErrorHandler

        '--- Define local vars
        Dim bError As Boolean = False

        '--- Define Connection String
        Dim bConnection_open As Boolean = False
        Dim bDatareader_open As Boolean = False
        Dim cSQL As String
        cSQL = "select id, password from usr_CUSTOMERS where active=1 and email='" + cEmail + "'"
        Dim objConn As New SqlClient.SqlConnection(Me.connection_string)
        Dim cSQLstring As SqlClient.SqlCommand = New SqlClient.SqlCommand(cSQL, objConn)
        objConn.Open()
        bConnection_open = True

        Dim dr_Reader As SqlClient.SqlDataReader = cSQLstring.ExecuteReader()
        bDatareader_open = True

        Dim nTmpId As Integer = 0
        While dr_Reader.Read()
            nTmpId = dr_Reader.Item("id")
            cPassword = dr_Reader.Item("password")
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
