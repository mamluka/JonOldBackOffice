Public Class cls_getitem

    Private m_error_no As Integer
    Private m_error_desc As String
    Private m_error_source As String
    Private m_connection_string As String
    Private m_itemid As Integer
    Private m_plate_no As Integer
    Private m_plate As DataRow
    Private m_subplate As DataRow


    Function get_item() As Boolean

        On Error GoTo ErrorHandler
        Dim bError As Boolean = False

        '--- Define MainPlate
        Dim oPlate As ion_resources.cls_ion_plate_lgc
        oPlate = New ion_resources.cls_ion_plate_lgc()
        oPlate.connection_string = Me.connection_string
        bError = oPlate.get_plate(Me.itemid)
        If bError Then
            Me.error_no = oPlate.error_no
            Me.error_desc = oPlate.error_desc
            Me.error_source = oPlate.error_source
            Exit Function
        End If

        Me.plate = oPlate.dataset.Tables("inv_INVENTORY").Rows(0)

        Select Case Me.plate("platetype")
            Case 1
                Me.plate_no = 1
                Me.subplate = oPlate.dataset.Tables("inv_DIAMONDS").Rows(0)

            Case 2
                Me.plate_no = 2
                Me.subplate = oPlate.dataset.Tables("inv_GEMSTONES").Rows(0)

            Case 3
                Me.plate_no = 3
                Me.subplate = oPlate.dataset.Tables("inv_JEWELRY").Rows(0)

        End Select

        Return False
        Exit Function

ErrorHandler:
        Me.error_no = Err.Number
        Me.error_desc = Err.Description
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

    Public Property error_no() As Integer
        Get
            Return m_error_no
        End Get

        Set(ByVal Value As Integer)
            m_error_no = Value
        End Set
    End Property

    Public Property error_desc() As String
        Get
            Return m_error_desc
        End Get

        Set(ByVal Value As String)
            m_error_desc = Value
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

    Public Property itemid() As Integer
        Get
            Return m_itemid
        End Get

        Set(ByVal Value As Integer)
            m_itemid = Value
        End Set
    End Property

    Public Property plate_no() As Integer
        Get
            Return m_plate_no
        End Get

        Set(ByVal Value As Integer)
            m_plate_no = Value
        End Set
    End Property

    Public Property plate() As DataRow
        Get
            Return m_plate
        End Get

        Set(ByVal Value As DataRow)
            m_plate = Value
        End Set
    End Property

    Public Property subplate() As DataRow
        Get
            Return m_subplate
        End Get

        Set(ByVal Value As DataRow)
            m_subplate = Value
        End Set
    End Property

End Class
