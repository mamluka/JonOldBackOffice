Imports System.Data.SqlClient

Public Class cls_ion_plate_lgc

    Private m_error_no As Integer
    Private m_error_desc As String
    Private m_error_source As String
    Private m_dataset As dataset
    Private m_connection_string As String
    Private m_itemnumber As String
    Private m_itemid As Integer
    Private m_itemcategory As Integer


    Public Function update_plate() As Boolean
        On Error GoTo ErrorHandler

        '--- local definitions
        Dim bError As Boolean = False

        '--- define system object
        Dim oSystem As ion_resources.cls_system = New ion_resources.cls_system()
        oSystem.connection_string = Me.connection_string
        oSystem.dataset = Me.dataset

        Dim oUpdate_Plate As ion_resources.cls_ion_plate_brk = New ion_resources.cls_ion_plate_brk()
        bError = oUpdate_Plate.update_plate(oSystem)
        If bError Then
            Me.error_no = oSystem.error_no
            Me.error_desc = oSystem.error_desc
            Me.error_source = oSystem.error_source
            Return True
            Exit Function
        End If

        '--- Return values
        Me.dataset = oSystem.dataset

        '--- Return Itemnumber from Transaction
        Me.itemnumber = oUpdate_Plate.itemnumber
        Me.itemid = oUpdate_Plate.itemid
        Me.itemcategory = oUpdate_Plate.itemcategory

        oUpdate_Plate = Nothing
        oSystem = Nothing

        Return False
        Exit Function

ErrorHandler:
        Me.error_no = Err.Number
        Me.error_desc = Err.Description
        Me.error_source = Err.Source
        Return True

    End Function


    Public Function get_plate(ByVal nItemId As Integer) As Boolean
        On Error GoTo ErrorHandler

        '--- local definitions
        Dim bError As Boolean = False

        '--- define system object
        Dim oSystem As ion_resources.cls_system = New ion_resources.cls_system()
        oSystem.connection_string = Me.connection_string
        oSystem.dataset = Me.dataset

        Dim oGet_Plate As ion_resources.cls_ion_plate_brk = New ion_resources.cls_ion_plate_brk()
        bError = oGet_Plate.get_plate(nItemId, oSystem)
        If bError Then
            Me.error_no = oSystem.error_no
            Me.error_desc = oSystem.error_desc
            Me.error_source = oSystem.error_source
            Return True
            Exit Function
        End If

        '--- Return dataset to me
        Me.dataset = oGet_Plate.dataset

        oGet_Plate = Nothing
        oSystem = Nothing

        Return False
        Exit Function

ErrorHandler:
        Me.error_no = Err.Number
        Me.error_desc = Err.Description
        Me.error_source = Err.Source
        Return True
    End Function


    Public Function insert_plate() As Boolean
        On Error GoTo ErrorHandler

        '--- local definitions
        Dim bError As Boolean = False

        '--- define system object
        Dim oSystem As ion_resources.cls_system = New ion_resources.cls_system()
        oSystem.connection_string = Me.connection_string
        oSystem.dataset = Me.dataset

        Dim oInsert_Plate As ion_resources.cls_ion_plate_brk = New ion_resources.cls_ion_plate_brk()
        bError = oInsert_Plate.insert_plate(oSystem)
        If bError Then
            Me.error_no = oSystem.error_no
            Me.error_desc = oSystem.error_desc
            Me.error_source = oSystem.error_source
            Return True
            Exit Function
        End If

        '--- Return Itemnumber from Transaction
        Me.itemnumber = oInsert_Plate.itemnumber
        Me.itemid = oInsert_Plate.itemid
        Me.itemcategory = oInsert_Plate.itemcategory

        oInsert_Plate = Nothing
        oSystem = Nothing

        Return False
        Exit Function

ErrorHandler:
        Me.error_no = Err.Number
        Me.error_desc = Err.Description
        Me.error_source = Err.Source
        Return True

    End Function


    Public Function get_empty_plate(ByVal nPlateNumber As Integer) As Boolean
        On Error GoTo ErrorHandler

        '--- local definitions
        Dim bError As Boolean = False

        '--- define system object
        Dim oSystem As ion_resources.cls_system = New ion_resources.cls_system()

        '--- resolve plate number
		Dim oTmpResolvePlate As ion_resources.cls_resolve_plate = New ion_resources.cls_resolve_plate()
        bError = oTmpResolvePlate.resolve_plate(nPlateNumber, oSystem)
        If bError Then
            Me.error_no = oSystem.error_no
            Me.error_desc = oSystem.error_desc
            Me.error_source = oSystem.error_source
            Return True
            Exit Function
        End If

        '--- make platetype readonly
        Dim oTmp_mp As DataTable = oTmpResolvePlate.PlateObject.Tables("inv_INVENTORY")
        oTmp_mp.Columns("plateType").ReadOnly = True

        '--- assign dataset back to ME
        Me.dataset = oTmpResolvePlate.PlateObject

        oTmp_mp = Nothing
        oSystem = Nothing

        Return False
        Exit Function

ErrorHandler:
        Me.error_no = Err.Number
        Me.error_desc = Err.Description
        Me.error_source = Err.Source
        Return True

    End Function

    Public Function delete_item(ByVal nId As Integer)
        On Error GoTo ErrorHandler

        '--- Define local vars
        Dim bError As Boolean = False

        '--- Define Connection String
        Dim objConn As New SqlClient.SqlConnection(Me.connection_string)
        Dim cSQLstring As SqlClient.SqlCommand

        cSQLstring = New SqlClient.SqlCommand("update inv_inventory set itemdeleted = 1 where id=" & nId, objConn)
        objConn.Open()

        Dim dr_Reader As SqlClient.SqlDataReader = cSQLstring.ExecuteReader()

        If dr_Reader.RecordsAffected <> 1 Then
            bError = True
        End If

        objConn.Close()
        dr_Reader.Close()

        Return bError
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

    Public Property dataset() As dataset
        Get
            Return m_dataset
        End Get

        Set(ByVal Value As dataset)
            m_dataset = Value
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

    Public Property itemid() As Integer
        Get
            Return m_itemid
        End Get

        Set(ByVal Value As Integer)
            m_itemid = Value
        End Set
    End Property

    Public Property itemcategory() As Integer
        Get
            Return m_itemcategory
        End Get

        Set(ByVal Value As Integer)
            m_itemcategory = Value
        End Set
    End Property

End Class


