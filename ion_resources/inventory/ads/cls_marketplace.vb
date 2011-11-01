Public Class cls_marketplace
    Private m_error_number As Int32
    Private m_error_source As String
    Private m_error_description As String
    Private m_connection_string As String

    Private m_item_id As Int32
    Private m_pic_path As String
    Private m_item_price As New ion_resources.cls_cons_price()


    '##########################################################################################
    Public Function get_item(ByVal nType_id As Int32, ByVal nPossition As Int32, ByVal bIsDealer As Boolean) As Boolean

        On Error GoTo ErrorHandler

        '--- Define local vars
        Dim bError As Boolean = False

        Dim nCount As Int32
        Dim nGetRecord As Int32

        '--- Count how many Records we have for this Possition
        bError = count_picture(nType_id, nPossition, nCount)

        '-- Randomize a RecordNumber
        Randomize()
        nGetRecord = CInt(Int((nCount * Rnd()) + 1))

        '--- Get Item params
        bError = get_picture(nType_id, nPossition, nGetRecord)
        If bError Then

        End If

        '--- Get the price
        Dim oTmpInventory As New ion_resources.cls_functions_inventory()
        oTmpInventory.connection_string = Me.connection_string
        bError = oTmpInventory.get_item_price(Me.item_id, bIsDealer, 0, Me.item_price)


        oTmpInventory = Nothing

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
    Private Function get_picture(ByVal nType_id As Int32, ByVal nPossition As Int32, ByVal nGetRecord As Int32) As Boolean
        On Error GoTo ErrorHandler

        '--- Define local vars
        Dim bError As Boolean = False

        '--- Define Connection String
        Dim bConnection_open As Boolean = False
        Dim bDatareader_open As Boolean = False
        Dim cSQL As String
        cSQL = "select item_id, picture_path from mrk_items where active = 1 and possition = " & nPossition & " and type_id = " & nType_id
        Dim objConn As New SqlClient.SqlConnection(Me.connection_string)
        Dim cSQLstring As SqlClient.SqlCommand = New SqlClient.SqlCommand(cSQL, objConn)
        objConn.Open()
        bConnection_open = True

        Dim dr_Reader As SqlClient.SqlDataReader = cSQLstring.ExecuteReader()
        bDatareader_open = True

        Dim nLoop As Int32
        While dr_Reader.Read()
            nLoop = nLoop + 1
            If nLoop = nGetRecord Then
                Me.item_id = dr_Reader.Item("item_id")
                Me.pic_path = dr_Reader.Item("picture_path")
                Exit While
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



    '##########################################################################################
    Private Function count_picture(ByVal nType_id As Int32, ByVal nPossition As Int32, ByRef nCount As Int32) As Boolean
        On Error GoTo ErrorHandler

        '--- Define local vars
        Dim bError As Boolean = False

        '--- Define Connection String
        Dim bConnection_open As Boolean = False
        Dim bDatareader_open As Boolean = False
        Dim cSQL As String
        cSQL = "select count(id) as cnt from mrk_items where active = 1 and possition = " & nPossition & " and type_id = " & nType_id
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

    Public Property pic_path() As String
        Get
            Return m_pic_path
        End Get

        Set(ByVal Value As String)
            m_pic_path = Value
        End Set
    End Property

    Public Property item_id() As Int32
        Get
            Return m_item_id
        End Get

        Set(ByVal Value As Int32)
            m_item_id = Value
        End Set
    End Property

    Public Property item_price() As ion_resources.cls_cons_price
        Get
            Return m_item_price
        End Get

        Set(ByVal Value As ion_resources.cls_cons_price)
            m_item_price = Value
        End Set
    End Property


End Class
