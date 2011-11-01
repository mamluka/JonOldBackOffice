Public Class cls_functions_book
    '--- Default properties for every class
    Private m_connection_string As String
    Private m_error_number As Int32
    Private m_error_source As String
    Private m_error_description As String

    '##########################################################################################
    Public Function get_LastTransactionNo(ByRef nLastNo As Int32) As Boolean
        'On Error GoTo ErrorHandler

        '--- Define local vars
        Dim bError As Boolean = False

        '--- Define Connection String
        Dim objConn As New SqlClient.SqlConnection(Me.connection_string)
        Dim cSQLstring As SqlClient.SqlCommand = New SqlClient.SqlCommand("select counter from sys_COUNTERS where id= 2", objConn)
        objConn.Open()

        Dim dr_Reader As SqlClient.SqlDataReader = cSQLstring.ExecuteReader()

        dr_Reader.Read()
        nLastNo = dr_Reader.Item("counter")

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
