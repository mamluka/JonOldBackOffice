Public Class cls_banners
    Private m_error_number As Int32
    Private m_error_source As String
    Private m_error_description As String
    Private m_connection_string As String

    Private m_item_id As Int32
    Private m_pic_path As String
    Private m_item_price As New ion_resources.cls_cons_price()
    Private m_description As String
    Private m_href As String


    '##########################################################################################
    Public Function get_picture(ByVal nLocation As Int32, ByVal cPath As String, ByVal cDomain As String) As Boolean
        On Error GoTo ErrorHandler

        '--- Define local vars
        Dim bError As Boolean = False
        Dim cLocation As String
        Dim nGetRecord As Int16
        Dim cSelectedFile As String


        '--- Convert the location 1 2 3 to string
        cLocation = Convert.ToString(nLocation)

        '### Randomize a file
        '--- Get The Files
        Dim aDirectory As Array = System.IO.Directory.GetFiles(cPath, cLocation + "-*.*")

        '-- Randomize a RecordNumber
        If aDirectory.GetUpperBound(0) > 0 Then
            Randomize()
            nGetRecord = CInt(Int((aDirectory.GetUpperBound(0) * Rnd()) + 1))

        Else
            nGetRecord = 0

        End If

        '--- Strip filename
        Dim cFile As String
        cSelectedFile = aDirectory(nGetRecord)
        cFile = Mid(cSelectedFile, cPath.Length + 2)

        Me.pic_path = "/precious-stones/ads/" + cFile

        '--- Check file validaty
        '--- Get ID
        Dim nId As Int32
        bError = get_id(cFile, nId)
        Me.item_id = nId


        '--- Creare Href
        Dim cShowFile As String = ""
        Dim oFunctions As New ion_resources.cls_functions_inventory()
        oFunctions.connection_string = Me.connection_string
        bError = oFunctions.get_showitemname(nId, cShowFile)
        oFunctions = Nothing

        '--- Construct description
        Dim oDescConstractor As New ion_resources.cls_cons_description()
        oDescConstractor.connection_string = Me.connection_string
        oDescConstractor.id = nId
        bError = oDescConstractor.construct
        Me.description = "Buy " + oDescConstractor.description + " from TWIN-DIAMONDS.COM"
        oDescConstractor = Nothing

		Me.href = "<a href='" + cDomain + cShowFile + Convert.ToString(nId) + ".htm ' title='" + Me.description + "'>"

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
    Private Function get_id(ByVal cFileName As String, ByRef nId As Int32) As Boolean

        On Error GoTo ErrorHandler

        '--- Define local vars
        Dim bError As Boolean = False


        Dim nLoop As Int16
        For nLoop = 3 To cFileName.Length
            If Not IsNumeric(Mid(cFileName, nLoop, 1)) Then
                nId = Convert.ToInt32(Mid(cFileName, 3, nLoop - 3))
                Exit For
            End If
        Next


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

    Public Property description() As String
        Get
            Return m_description
        End Get

        Set(ByVal Value As String)
            m_description = Value
        End Set
    End Property

    Public Property href() As String
        Get
            Return m_href
        End Get

        Set(ByVal Value As String)
            m_href = Value
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
