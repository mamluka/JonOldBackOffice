Imports System.Web.UI.WebControls

Public Class cls_combo
    Inherits ion_resources.cls_base_general

    Private m_combobox As DropDownList
    Private m_sqlstring As String
    Private m_showfield As String
    Private m_valuefield As String

    Function fill_combo() As Boolean
        On Error GoTo ErrorHandler

        '--- Define local vars
        Dim bError As Boolean = False

        '--- Define Connection String
        Dim bConnection_open As Boolean = False
        Dim bDatareader_open As Boolean = False
        Dim objConn As New SqlClient.SqlConnection(Me.connection_string)
        Dim cSQLstring As SqlClient.SqlCommand = New SqlClient.SqlCommand(Me.sqlstring, objConn)
        objConn.Open()
        bConnection_open = True

        Dim dr_Reader As SqlClient.SqlDataReader = cSQLstring.ExecuteReader()
        bDatareader_open = True

        Dim nCount As Integer = Me.combobox.Items.Count
        While dr_Reader.Read()
            Me.combobox.Items.Add(dr_Reader.GetString(1))
            Me.combobox.Items(nCount).Value = dr_Reader.GetInt32(0)
            nCount = nCount + 1
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
        Me.error_no = Err.Number
        Me.error_desc = Err.Description
        Me.error_source = Err.Source
        Return True

    End Function

    '--- ID
    Function bind_combo() As Boolean
        On Error GoTo ErrorHandler

        '--- Define local vars
        Dim bError As Boolean = False

        '--- Define Connection String
        Dim bConnection_open As Boolean = False
        Dim bDatareader_open As Boolean = False
        Dim objConn As New SqlClient.SqlConnection(Me.connection_string)
        Dim cSQLstring As SqlClient.SqlCommand = New SqlClient.SqlCommand(Me.sqlstring, objConn)
        objConn.Open()
        bConnection_open = True

        Dim dr_Reader As SqlClient.SqlDataReader = cSQLstring.ExecuteReader()
        bDatareader_open = True

        Me.combobox.DataSource = dr_Reader
        Me.combobox.DataTextField = Me.showfield
        Me.combobox.DataValueField = "id"
        Me.combobox.DataBind()

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
        Me.error_no = Err.Number
        Me.error_desc = Err.Description
        Me.error_source = Err.Source
        Return True

    End Function







    Public Property combobox() As DropDownList
        Get
            Return m_combobox
        End Get

        Set(ByVal Value As DropDownList)
            m_combobox = Value
        End Set
    End Property

    Public Property sqlstring() As String
        Get
            Return m_sqlstring
        End Get

        Set(ByVal Value As String)
            m_sqlstring = Value
        End Set
    End Property

    Public Property showfield() As String
        Get
            Return m_showfield
        End Get

        Set(ByVal Value As String)
            m_showfield = Value
        End Set
    End Property

    Public Property valuefield() As String
        Get
            Return m_valuefield
        End Get

        Set(ByVal Value As String)
            m_valuefield = Value
        End Set
    End Property


End Class
