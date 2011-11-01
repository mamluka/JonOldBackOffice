Public Class cls_itemnumber

    Private m_error_number As Int32
    Private m_error_source As String
    Private m_error_description As String
    Private m_connection_string As String

    Private m_branch As Integer
    Private m_supplier As Integer
    Private m_item As Int32
	Private m_itemnumber As String
	Private m_id As Int32


    '####################################################################################
    Public Function GetItemIdFromNumber(ByVal cItemNumber As String) As Boolean
        On Error GoTo ErrorHandler

        '--- Define local vars
        Dim bError As Boolean = False

        '--- Strip number first
        Dim nBranch As Int32
        Dim nSupplier As Int32
        Dim nItemNumer As Int32
        Dim cErrorText As String = ""
        Dim cSearchText As String = ""

        Me.itemnumber = cItemNumber

        Me.stripitemnumber(cErrorText, cSearchText)

        '--- Define Connection String
        Dim objConn As New SqlClient.SqlConnection(Me.connection_string)
        Dim cSQLstring As SqlClient.SqlCommand = New SqlClient.SqlCommand("select id from inv_inventory where branchnumber= " & Me.branch & " and suppliernumber= " & Me.supplier & " and itemnumberint= " & Me.item, objConn)
        objConn.Open()

        Dim dr_Reader As SqlClient.SqlDataReader = cSQLstring.ExecuteReader()

        While dr_Reader.Read()
            Me.id = dr_Reader.Item("id")
        End While

        objConn.Close()
        dr_Reader.Close()

        Return False
        Exit Function

ErrorHandler:
        Me.error_number = Err.Number
        Me.error_source = Err.Source
        Me.error_description = Err.Description
        Return True

    End Function


    '####################################################################################
    Public Function GetItemNumberFromId(ByVal nId As Int32) As Boolean
        On Error GoTo ErrorHandler
        '--DOES NOT WORK YET
        'TODO: Finish GetItemNumberFromId function

        '--- Define local vars
        Dim bError As Boolean = False
        Dim cSQL As String

        '--- Define Connection String
        Dim objConn As New SqlClient.SqlConnection(Me.connection_string)
        cSQL = "select itemnumber from inv_inventory where id = " & Convert.ToString(nId)
        Dim cSQLstring As SqlClient.SqlCommand = New SqlClient.SqlCommand(cSQL, objConn)
        objConn.Open()

        Dim dr_Reader As SqlClient.SqlDataReader = cSQLstring.ExecuteReader()

        While dr_Reader.Read()
            Me.itemnumber = dr_Reader.Item("itemnumber")
        End While


        objConn.Close()
        dr_Reader.Close()

        Return False
        Exit Function

ErrorHandler:
        Me.error_number = Err.Number
        Me.error_source = Err.Source
        Me.error_description = Err.Description
        Return True

    End Function


    '####################################################################################
    Public Function GetBranchName(ByRef cBranchName) As Boolean
        On Error GoTo ErrorHandler

        '--- Define local vars
        Dim bError As Boolean = False

        '--- Define Connection String
        Dim objConn As New SqlClient.SqlConnection(Me.connection_string)
        Dim cSQLstring As SqlClient.SqlCommand = New SqlClient.SqlCommand("select branch from sys_BRANCH where id= " & Me.branch & " and active=1 order by sortorder", objConn)
        objConn.Open()

        Dim dr_Reader As SqlClient.SqlDataReader = cSQLstring.ExecuteReader()

        dr_Reader.Read()
        cBranchName = dr_Reader.Item("branch")

        objConn.Close()
        dr_Reader.Close()

        Return False
        Exit Function

ErrorHandler:
        Me.error_number = Err.Number
        Me.error_source = Err.Source
        Me.error_description = Err.Description
        Return True

    End Function


    '####################################################################################
    Public Function GetBranchNumber() As Boolean
        On Error GoTo ErrorHandler

        '--- Trim incomming
        Dim cTmpItemNumber As String
        cTmpItemNumber = Trim(Me.itemnumber)

        '--- check for valid lenght
        If Len(cTmpItemNumber) < 10 Or Len(cTmpItemNumber) > 11 Then
            Err.Raise(5008, "[cls_itemnumber.get_branchnumber]", "ERROR 5008: Invalid Itemnumber")
            Return True
        End If

        '--- extract BranchNumber
        If Mid(cTmpItemNumber, 3, 1) = "-" And Mid(cTmpItemNumber, 6, 1) = "-" Then
            Me.branch = (Int(Mid(cTmpItemNumber, 1, 2)))
            Return False

        ElseIf Mid(cTmpItemNumber, 5, 1) = "-" Then
            Me.branch = Int(Mid(cTmpItemNumber, 1, 2))
            Return False

        End If

        Return False
        Exit Function

ErrorHandler:
        Me.error_number = Err.Number
        Me.error_source = Err.Source
        Me.error_description = Err.Description
        Return True

    End Function


    '####################################################################################
    Public Function GetSupplierNumber() As Boolean
        On Error GoTo ErrorHandler

        '--- Trim incomming
        Dim cTmpItemNumber As String
        cTmpItemNumber = Trim(Me.itemnumber)

        '--- check for valid lenght
        If Len(cTmpItemNumber) < 10 Or Len(cTmpItemNumber) > 11 Then
            Err.Raise(5007, "[cls_itemnumber.get_suppliernumber]", "ERROR 5007: Invalid Itemnumber")
            Return True
        End If

        '--- extract SupplierNumber
        If Mid(cTmpItemNumber, 3, 1) = "-" And Mid(cTmpItemNumber, 6, 1) = "-" Then
            Me.supplier = (Int(Mid(cTmpItemNumber, 4, 2)))
            Return False

        ElseIf Mid(cTmpItemNumber, 5, 1) = "-" Then
            Me.supplier = Int(Mid(cTmpItemNumber, 3, 2))
            Return False

        End If

        Return False
        Exit Function

ErrorHandler:
        Me.error_number = Err.Number
        Me.error_source = Err.Source
        Me.error_description = Err.Description
        Return True

    End Function


    '####################################################################################
    Public Function GetItemNumber() As Boolean
        On Error GoTo ErrorHandler

        '--- Trim incomming
        Dim cTmpItemNumber As String
        cTmpItemNumber = Trim(Me.itemnumber)

        '--- check for valid lenght
        If Len(cTmpItemNumber) < 10 Or Len(cTmpItemNumber) > 11 Then
            Err.Raise(5006, "[cls_itemnumber.get_itemnumber]", "ERROR 5006: Invalid Itemnumber")
            Return True
        End If

        '--- extract ItemNumber
        If Mid(cTmpItemNumber, 3, 1) = "-" And Mid(cTmpItemNumber, 6, 1) = "-" Then
            Me.item = System.Convert.ToInt32(cTmpItemNumber.Substring(7, 5))
            Return False

        ElseIf Mid(cTmpItemNumber, 5, 1) = "-" Then
            Me.item = System.Convert.ToInt32(cTmpItemNumber.Substring(6, 5))
            Return False

        End If

        Return False
        Exit Function

ErrorHandler:
        Me.error_number = Err.Number
        Me.error_source = Err.Source
        Me.error_description = Err.Description
        Return True
    End Function


    '####################################################################################
    '---- this function will strip the complete itemnumber in pices
    '---- according to the two methods we know
    Public Function stripitemnumber(ByRef cErrorText As String, ByRef cSearchText As String) As Boolean
        On Error GoTo ErrorHandler
        Dim bError As Boolean = False

        If Len(Me.itemnumber) = 0 Then
            Return False
        End If

        Dim cTmpPreNumber, cTmpSufNumber As String
        Dim nPos1 As Integer = -1
        Dim nPos2 As Integer = -1
        Me.itemnumber = Me.itemnumber.Trim
        cErrorText = ""
        cSearchText = ""

        '--- Get Position of dashes and split number in 2
        bError = GetDash(Me.itemnumber, nPos1, nPos2)
        If nPos1 = 4 Then    '--- xxxx-xxxxx
            cTmpPreNumber = Me.itemnumber.Substring(0, nPos1)
            cTmpSufNumber = Me.itemnumber.Substring(nPos1 + 1, Len(Me.itemnumber.Trim) - nPos1 - 1)
            '--- Get the item number
            If IsNum(cTmpSufNumber) Then
                Me.item = System.Convert.ToInt32(cTmpSufNumber)
            End If

        ElseIf nPos2 > -1 Then
            cTmpPreNumber = Me.itemnumber.Substring(0, nPos2)
            cTmpSufNumber = Me.itemnumber.Substring(nPos2 + 1, Len(Me.itemnumber.Trim) - nPos2 - 1)
            '--- Get the item number
            If IsNum(cTmpSufNumber) Then
                Me.item = System.Convert.ToInt32(cTmpSufNumber)
            End If

        Else
            cTmpPreNumber = Me.itemnumber
        End If


        '--- Work the PreNumber = Branch & Supplier
        If Len(cTmpPreNumber) = 1 Then
            If IsNum(cTmpPreNumber.Substring(0, 1)) Then     '--- x
                Me.branch = System.Convert.ToInt32(cTmpPreNumber.Substring(0, 1))
                cSearchText = "Searching for Branch"
                Return False
            Else
                cErrorText = "Item number not valid!"
                Return False
            End If

        ElseIf Len(cTmpPreNumber) = 2 Then
            If IsNum(cTmpPreNumber.Substring(0, 2)) Then     '--- xx
                Me.branch = System.Convert.ToInt16(cTmpPreNumber.Substring(0, 2))
                cSearchText = "Searching for Branch"
                Return False
            ElseIf IsNum(cTmpPreNumber.Substring(0, 1)) Then    '--- x-
                Me.branch = System.Convert.ToInt16(cTmpPreNumber.Substring(0, 1))
                cSearchText = "Searching for Branch"
                Return False
            Else
                cErrorText = "Item number not valid!"
                Return False
            End If

        ElseIf Len(cTmpPreNumber) = 3 Then
            If IsNum(cTmpPreNumber.Substring(0, 3)) Then     '--- xxx
                Me.branch = System.Convert.ToInt16(cTmpPreNumber.Substring(0, 2))
                Me.supplier = System.Convert.ToInt16(cTmpPreNumber.Substring(2, 1))
                cSearchText = "Searching for Branch and Supplier"
                Return False
            ElseIf IsNum(cTmpPreNumber.Substring(0, 2)) Then     '--- xx-
                Me.branch = System.Convert.ToInt16(cTmpPreNumber.Substring(0, 2))
                cSearchText = "Searching for Branch"
                Return False
            ElseIf IsNum(cTmpPreNumber.Substring(0, 1)) And cTmpPreNumber.Substring(1, 1) = "-" And IsNum(cTmpPreNumber.Substring(2, 1)) Then    '--- x-x
                Me.branch = System.Convert.ToInt16(cTmpPreNumber.Substring(0, 1))
                Me.supplier = System.Convert.ToInt16(cTmpPreNumber.Substring(2, 1))
                cSearchText = "Searching for Branch"
                Return False
            Else
                cErrorText = "Item number not valid!"
                Return False
            End If

        ElseIf Len(cTmpPreNumber) = 4 Then
            If IsNum(cTmpPreNumber.Substring(0, 4)) Then     '--- xxxx
                Me.branch = System.Convert.ToInt16(cTmpPreNumber.Substring(0, 2))
                Me.supplier = System.Convert.ToInt16(cTmpPreNumber.Substring(2, 2))
                cSearchText = "Searching for Branch and Supplier"
                Return False
            ElseIf IsNum(cTmpPreNumber.Substring(0, 1)) And cTmpPreNumber.Substring(1, 1) = "-" And IsNum(cTmpPreNumber.Substring(2, 2)) Then    '--- x-xx
                Me.branch = System.Convert.ToInt16(cTmpPreNumber.Substring(0, 1))
                Me.supplier = System.Convert.ToInt16(cTmpPreNumber.Substring(2, 2))
                cSearchText = "Searching for Branch and Supplier"
                Return False
            ElseIf IsNum(cTmpPreNumber.Substring(0, 2)) And cTmpPreNumber.Substring(2, 1) = "-" And IsNum(cTmpPreNumber.Substring(3, 1)) Then    '--- xx-x
                Me.branch = System.Convert.ToInt16(cTmpPreNumber.Substring(0, 2))
                Me.supplier = System.Convert.ToInt16(cTmpPreNumber.Substring(3, 1))
                cSearchText = "Searching for Branch and Supplier"
                Return False
            ElseIf IsNum(cTmpPreNumber.Substring(0, 3)) Then    '--- xxx-
                Me.branch = System.Convert.ToInt16(cTmpPreNumber.Substring(0, 2))
                Me.supplier = System.Convert.ToInt16(cTmpPreNumber.Substring(2, 1))
                cSearchText = "Searching for Branch and Supplier"
                Return False
            Else
                cErrorText = "Item number not valid!"
                Return False
            End If

        ElseIf Len(cTmpPreNumber) = 5 Then
            If IsNum(cTmpPreNumber.Substring(0, 4)) Then     '--- xxxx-
                Me.branch = System.Convert.ToInt16(cTmpPreNumber.Substring(0, 2))
                Me.supplier = System.Convert.ToInt16(cTmpPreNumber.Substring(2, 2))
                cSearchText = "Searching for Branch and Supplier"
                Return False
            ElseIf IsNum(cTmpPreNumber.Substring(0, 1)) And cTmpPreNumber.Substring(1, 1) = "-" And IsNum(cTmpPreNumber.Substring(2, 2)) Then    '--- x-xx-
                Me.branch = System.Convert.ToInt16(cTmpPreNumber.Substring(0, 1))
                Me.supplier = System.Convert.ToInt16(cTmpPreNumber.Substring(2, 2))
                cSearchText = "Searching for Branch and Supplier"
                Return False
            ElseIf IsNum(cTmpPreNumber.Substring(0, 2)) And cTmpPreNumber.Substring(2, 1) = "-" And IsNum(cTmpPreNumber.Substring(3, 2)) Then     '--- xx-xx
                Me.branch = System.Convert.ToInt16(cTmpPreNumber.Substring(0, 2))
                Me.supplier = System.Convert.ToInt16(cTmpPreNumber.Substring(3, 2))
                cSearchText = "Searching for Branch and Supplier"
                Return False
            ElseIf IsNum(cTmpPreNumber.Substring(0, 2)) And cTmpPreNumber.Substring(2, 1) = "-" And IsNum(cTmpPreNumber.Substring(3, 1)) Then    '--- xx-x-
                Me.branch = System.Convert.ToInt16(cTmpPreNumber.Substring(0, 2))
                Me.supplier = System.Convert.ToInt16(cTmpPreNumber.Substring(3, 1))
                cSearchText = "Searching for Branch and Supplier"
                Return False
            ElseIf IsNum(cTmpPreNumber.Substring(0, 1)) And cTmpPreNumber.Substring(1, 1) = "-" And IsNum(cTmpPreNumber.Substring(2, 1)) And cTmpPreNumber.Substring(3, 1) = "-" And IsNum(cTmpPreNumber.Substring(4, 1)) Then    '--- x-x-x
                Me.branch = System.Convert.ToInt16(cTmpPreNumber.Substring(0, 1))
                Me.supplier = System.Convert.ToInt16(cTmpPreNumber.Substring(2, 1))
                Me.item = System.Convert.ToInt32(cTmpPreNumber.Substring(4, 1))
                cSearchText = "Searching for Branch, Supplier and Itemnumber"
                Return False
            Else
                cErrorText = "Item number not valid!"
                Return False
            End If

        Else
            cErrorText = "Item number not valid!"
            Return False

        End If

        Return False
        Exit Function

ErrorHandler:
        Me.error_number = Err.Number
        Me.error_source = Err.Source
        Me.error_description = Err.Description
        Return True

    End Function


    '####################################################################################
    Private Function GetDash(ByVal cTmpString As String, ByRef nPos1 As Integer, ByRef nPos2 As Integer) As Boolean
        Dim nLoop As Integer
        nPos1 = -1
        nPos2 = -1
        For nLoop = 0 To Len(cTmpString.Trim) - 1
            If cTmpString.Substring(nLoop, 1) = "-" Then
                If nPos1 = -1 Then
                    nPos1 = nLoop
                Else
                    nPos2 = nLoop
                End If
            End If
        Next

        Return False
    End Function

    Private Function IsNum(ByVal cTmpString As String) As Boolean
        Dim nLoop As Integer
        For nLoop = 0 To Len(cTmpString.Trim) - 1
            If Asc(cTmpString.Substring(nLoop, 1)) < Asc("0") Or Asc(cTmpString.Substring(nLoop, 1)) > Asc("9") Then
                Return False
            End If
        Next

        Return True

    End Function

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

    Public Property branch() As Integer
        Get
            Return m_branch
        End Get

        Set(ByVal Value As Integer)
            m_branch = Value
        End Set
    End Property

    Public Property supplier() As Integer
        Get
            Return m_supplier
        End Get

        Set(ByVal Value As Integer)
            m_supplier = Value
        End Set
    End Property

    Public Property item() As Int32
        Get
            Return m_item
        End Get

        Set(ByVal Value As Int32)
            m_item = Value
        End Set
    End Property

    Public Property itemnumber() As String
        Get
            Return m_itemnumber
        End Get

        Set(ByVal Value As String)
            m_itemnumber = Value
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


End Class
