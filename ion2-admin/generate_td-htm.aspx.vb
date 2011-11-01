Partial Class generate_td_htm
    Inherits iFoundation.wsc_page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub

    'NOTE: The following placeholder declaration is required by the Web Form Designer.
    'Do not delete or move it.
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub

#End Region


    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Put user code to initialize the page here
    End Sub

    Private Sub btn_search_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_search.Click
        On Error GoTo ErrorHandler
        Dim bError As Boolean = False

        Dim ct As String = Context.Request.PhysicalApplicationPath


        Dim cPath As String = "c:\inet-sites\new-twin-admin\"
        Dim cFile_header As String = cPath + "td-header.pby"
        Dim cFile_footer As String = cPath + "td-footer.pby"
        'Dim cNewFile As String = "c:\inet-sites\twin-web\twin-diamonds.htm"
        Dim cNewFile As String = "c:\inet-sites\twin-diamonds.htm"

        '--- Open Header File
        Dim cReadLine1 As String
        Dim nFileH As Long = FreeFile()
        FileSystem.FileOpen(nFileH, cFile_header, OpenMode.Input)

        '--- Open NEW file
        Dim cWriteLine As String
        Dim nFileN As Long = FreeFile()
        FileSystem.FileOpen(nFileN, cNewFile, OpenMode.Output)


        Do
            cReadLine1 = FileSystem.LineInput(nFileH)
            cWriteLine = cReadLine1
            FileSystem.PrintLine(nFileN, cWriteLine)
        Loop While Not EOF(nFileH)
        '--- Close File *
        FileSystem.FileClose(nFileH)

        '--- Genrate Rows
        bError = get_contents(nFileN)

        '--- Add Footer
        '--- Open Header File
        Dim cReadLine2 As String
        Dim nFileF As Long = FreeFile()
        FileSystem.FileOpen(nFileF, cFile_footer, OpenMode.Input)

        Do
            cReadLine2 = FileSystem.LineInput(nFileF)
            cWriteLine = cReadLine2
            FileSystem.PrintLine(nFileN, cWriteLine)
        Loop While Not EOF(nFileH)
        '--- Close File *
        FileSystem.FileClose(nFileF)


        '--- Close File *
        FileSystem.FileClose(nFileN)

        Exit Sub

ErrorHandler:
        '--- Reporting Error
        Session("o_error")._Err_Number = Err.Number
        Session("o_error")._Err_Description = Err.Description
        Session("o_error")._Err_Source = Err.Source
        Session("o_error")._Err_Module = Me.Request.CurrentExecutionFilePath
        Session("o_error")._Err_Call = "Page_Load [ErrorHandler]"
        Server.Transfer("/aspxerror.aspx")

    End Sub

    Private Function get_contents(ByVal nFileHandle As Long) As Boolean
        On Error GoTo ErrorHandler
        Dim bError As Boolean = False


        '--- Define Connection String
        Dim bConnection_open As Boolean = False
        Dim bDatareader_open As Boolean = False
        Dim cSQL As String
        cSQL = "select id from inv_inventory where shopstatus = 1 and itemdeleted = 0 and qtyonstock_cur > 0 order by platetype, category_id, subcategory_id"
        Dim objConn As New SqlClient.SqlConnection(Application("config").connection_string)
        Dim cSQLstring As SqlClient.SqlCommand = New SqlClient.SqlCommand(cSQL, objConn)
        objConn.Open()
        bConnection_open = True

        Dim dr_Reader As SqlClient.SqlDataReader = cSQLstring.ExecuteReader()
        bDatareader_open = True

        Dim nId As Int32
        Dim cWriteLine As String
        Dim nCount As Int32 = 0
        While dr_Reader.Read()
            nCount = nCount + 1
            nId = dr_Reader.Item("id")
            bError = Me.get_line(nId, nFileHandle)
            If bError Then
                Me._err_number = Err.Number
                Me._err_description = Err.Description
                Me._err_source = Err.Source
                Return True
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

        Me._err_number = Err.Number
        Me._err_description = Err.Description
        Me._err_source = Err.Source
        Return True

    End Function

    Private Function get_line(ByVal nId As Int32, ByVal nFileHandle As Long) As Boolean
        On Error GoTo ErrorHandler
        Dim bError As Boolean = False


        '--- Get Item
        Dim oPlate As New ion_two.skl_lst_inventory
        Dim oTmpInventory As New ion_two.cls_inventory_lgc
        oTmpInventory._connection_string = Application("config").connection_string
        oTmpInventory._dbtype = 1
        bError = oTmpInventory.load(nId, oPlate, Nothing, False)
        If bError Then
            Session("o_error")._Err_Number = oTmpInventory._err_number
            Session("o_error")._Err_Description = oTmpInventory._err_description
            Session("o_error")._Err_Source = oTmpInventory._err_source
            Session("o_error")._Err_Module = Me.Request.CurrentExecutionFilePath
            Session("o_error")._Err_Call = "grd_items_ItemCreated [object plate logics:load]"
            Server.Transfer("/aspxerror.aspx")
        End If

        '--- release
        oTmpInventory = Nothing


        '--- Handle Showitem link
        Dim cLink As String
        Select Case oPlate._platetype
            Case 1
                cLink = "http://www.twin-diamonds.com/diamond/" + Convert.ToString(oPlate._id) + ".htm"
            Case 2
                cLink = "http://www.twin-diamonds.com/gemstone/" + Convert.ToString(oPlate._id) + ".htm"
            Case 3
                cLink = "http://www.twin-diamonds.com/jewel/" + Convert.ToString(oPlate._id) + ".htm"
        End Select


        '---
        bError = Me.write_line(oPlate._item_description_round, cLink, nFileHandle)
        If bError Then
            Me._err_number = Err.Number
            Me._err_description = Err.Description
            Me._err_source = Err.Source
            Return True
        End If


        Return False
        Exit Function

ErrorHandler:
        Me._err_number = Err.Number
        Me._err_description = Err.Description
        Me._err_source = Err.Source
        Return True
    End Function

    Private Function write_line(ByVal cDescription As String, ByVal cLink As String, ByVal nFileHandle As Long) As Boolean
        On Error GoTo ErrorHandler
        Dim bError As Boolean = False

        Dim cOutputLine As String

        cOutputLine = "<TR><TD><h1 class='small_link'>"
        cOutputLine = cOutputLine + "<a href='" + cLink + "'>" + cDescription + "</a>"
        cOutputLine = cOutputLine + "</h1></TR></TD>"

        FileSystem.PrintLine(nFileHandle, cOutputLine)

        Return False
        Exit Function

ErrorHandler:
        Me._err_number = Err.Number
        Me._err_description = Err.Description
        Me._err_source = Err.Source
        Return True
    End Function






    Private Sub btn_tst_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_tst.Click
        On Error GoTo ErrorHandler
        Dim bError As Boolean = False


        Dim nFileN As Long = FreeFile()
        bError = get_contents(nFileN)



        Exit Sub

ErrorHandler:
        '--- Reporting Error
        Session("o_error")._Err_Number = Err.Number
        Session("o_error")._Err_Description = Err.Description
        Session("o_error")._Err_Source = Err.Source
        Session("o_error")._Err_Module = Me.Request.CurrentExecutionFilePath
        Session("o_error")._Err_Call = "Page_Load [ErrorHandler]"
        Server.Transfer("/aspxerror.aspx")


    End Sub
End Class
