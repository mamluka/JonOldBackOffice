Imports System.Data.SqlClient
Partial Class banners
    Inherits System.Web.UI.Page
    Public banner_view_html(5) As String

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
        On Error GoTo ErrorHandler
        Dim bError As Boolean = False
        If Not Page.IsPostBack Then
            Me.load_banner()
        End If
        If bError Then
            Server.Transfer("/aspxerror.aspx")
        End If

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

    Private Sub TextBox2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Go1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Go1.Click

        Dim oFileObject As System.Web.UI.HtmlControls.HtmlInputFile
        Dim nErrorType As Integer = 0
        Dim cFileExtension As String
        Dim cNewFileName As String
        Dim cDirectory As String = ""

        If Me.clear1.Checked Then
            Me.update_bunner("", 1, "", True)
        End If
        If Me.clear2.Checked Then
            Me.update_bunner("", 2, "", True)
        End If
        If Me.clear3.Checked Then
            Me.update_bunner("", 3, "", True)
        End If
        If Me.clear4.Checked Then
            Me.update_bunner("", 4, "", True)
        End If
        If Me.clear5.Checked Then
            Me.update_bunner("", 5, "", True)
        End If




        '        --- PICTURE
        If Not IsNothing(Me.banner1_file.PostedFile) Then
            If Me.banner1_file.PostedFile.FileName <> "" Then
                '--- Assign the file object
                oFileObject = Me.banner1_file

                '--- Create New FileName
                cFileExtension = System.IO.Path.GetExtension(oFileObject.PostedFile.FileName)
                cNewFileName = "banner1" + cFileExtension

                '--- Get Save Directory
                cDirectory = Application("defaults").ctg_pictures_root_path + "\banners\"


                '--- Upload file
                Session("message").listbox.items.add("+ PICTURE: Coping from: " + oFileObject.PostedFile.FileName)

                sendfile(cNewFileName, cDirectory, oFileObject, nErrorType)
                If nErrorType = 0 Then     '--- everythinh id ok, update record

                    Me.update_bunner(Me.banner1_link.Text, 1, cNewFileName)
                    ''  Session("message").listbox.items.add("+ PICTURE: saved file: " + cDirectory + cNewFileName + " to " + cNewFileName + " (" + System.Convert.ToString(oFileObject.PostedFile.ContentLength) + ")")
                Else
                    Select Case nErrorType
                        Case 1
                            Session("message").listbox.items.add("- PICTURE: Error saving file: " + cNewFileName)
                        Case 2
                            Session("message").listbox.items.add("- PICTURE: Error Not an IMAGE file: " + cNewFileName)
                        Case 3
                            Session("message").listbox.items.add("- PICTURE: Error file larger then 0.5Mb: " + cNewFileName)
                    End Select
                End If
            End If
        End If

        If Not IsNothing(Me.banner2_file.PostedFile) Then
            If Me.banner2_file.PostedFile.FileName <> "" Then
                '--- Assign the file object
                oFileObject = Me.banner2_file

                '--- Create New FileName
                cFileExtension = System.IO.Path.GetExtension(oFileObject.PostedFile.FileName)
                cNewFileName = "banner2" + cFileExtension

                '--- Get Save Directory
                cDirectory = Application("defaults").ctg_pictures_root_path + "\banners\"


                '--- Upload file
                Session("message").listbox.items.add("+ PICTURE: Coping from: " + oFileObject.PostedFile.FileName)

                sendfile(cNewFileName, cDirectory, oFileObject, nErrorType)
                If nErrorType = 0 Then     '--- everythinh id ok, update record

                    Me.update_bunner(Me.banner2_link.Text, 2, cNewFileName)
                    ''  Session("message").listbox.items.add("+ PICTURE: saved file: " + cDirectory + cNewFileName + " to " + cNewFileName + " (" + System.Convert.ToString(oFileObject.PostedFile.ContentLength) + ")")
                Else
                    Select Case nErrorType
                        Case 1
                            Session("message").listbox.items.add("- PICTURE: Error saving file: " + cNewFileName)
                        Case 2
                            Session("message").listbox.items.add("- PICTURE: Error Not an IMAGE file: " + cNewFileName)
                        Case 3
                            Session("message").listbox.items.add("- PICTURE: Error file larger then 0.5Mb: " + cNewFileName)
                    End Select
                End If
            End If
        End If

        If Not IsNothing(Me.banner3_file.PostedFile) Then
            If Me.banner3_file.PostedFile.FileName <> "" Then
                '--- Assign the file object
                oFileObject = Me.banner3_file

                '--- Create New FileName
                cFileExtension = System.IO.Path.GetExtension(oFileObject.PostedFile.FileName)
                cNewFileName = "banner3" + cFileExtension

                '--- Get Save Directory
                cDirectory = Application("defaults").ctg_pictures_root_path + "\banners\"


                '--- Upload file
                Session("message").listbox.items.add("+ PICTURE: Coping from: " + oFileObject.PostedFile.FileName)

                sendfile(cNewFileName, cDirectory, oFileObject, nErrorType)
                If nErrorType = 0 Then     '--- everythinh id ok, update record

                    Me.update_bunner(Me.banner3_link.Text, 3, cNewFileName)
                    ''  Session("message").listbox.items.add("+ PICTURE: saved file: " + cDirectory + cNewFileName + " to " + cNewFileName + " (" + System.Convert.ToString(oFileObject.PostedFile.ContentLength) + ")")
                Else
                    Select Case nErrorType
                        Case 1
                            Session("message").listbox.items.add("- PICTURE: Error saving file: " + cNewFileName)
                        Case 2
                            Session("message").listbox.items.add("- PICTURE: Error Not an IMAGE file: " + cNewFileName)
                        Case 3
                            Session("message").listbox.items.add("- PICTURE: Error file larger then 0.5Mb: " + cNewFileName)
                    End Select
                End If
            End If
        End If

        If Not IsNothing(Me.banner4_file.PostedFile) Then
            If Me.banner4_file.PostedFile.FileName <> "" Then
                '--- Assign the file object
                oFileObject = Me.banner4_file

                '--- Create New FileName
                cFileExtension = System.IO.Path.GetExtension(oFileObject.PostedFile.FileName)
                cNewFileName = "banner4" + cFileExtension

                '--- Get Save Directory
                cDirectory = Application("defaults").ctg_pictures_root_path + "\banners\"


                '--- Upload file
                Session("message").listbox.items.add("+ PICTURE: Coping from: " + oFileObject.PostedFile.FileName)

                sendfile(cNewFileName, cDirectory, oFileObject, nErrorType)
                If nErrorType = 0 Then     '--- everythinh id ok, update record

                    Me.update_bunner(Me.banner4_link.Text, 4, cNewFileName)
                    ''  Session("message").listbox.items.add("+ PICTURE: saved file: " + cDirectory + cNewFileName + " to " + cNewFileName + " (" + System.Convert.ToString(oFileObject.PostedFile.ContentLength) + ")")
                Else
                    Select Case nErrorType
                        Case 1
                            Session("message").listbox.items.add("- PICTURE: Error saving file: " + cNewFileName)
                        Case 2
                            Session("message").listbox.items.add("- PICTURE: Error Not an IMAGE file: " + cNewFileName)
                        Case 3
                            Session("message").listbox.items.add("- PICTURE: Error file larger then 0.5Mb: " + cNewFileName)
                    End Select
                End If
            End If
        End If

        If Not IsNothing(Me.banner5_file.PostedFile) Then
            If Me.banner5_file.PostedFile.FileName <> "" Then
                '--- Assign the file object
                oFileObject = Me.banner5_file

                '--- Create New FileName
                cFileExtension = System.IO.Path.GetExtension(oFileObject.PostedFile.FileName)
                cNewFileName = "banner5" + cFileExtension

                '--- Get Save Directory
                cDirectory = Application("defaults").ctg_pictures_root_path + "\banners\"


                '--- Upload file
                Session("message").listbox.items.add("+ PICTURE: Coping from: " + oFileObject.PostedFile.FileName)

                sendfile(cNewFileName, cDirectory, oFileObject, nErrorType)
                If nErrorType = 0 Then     '--- everythinh id ok, update record

                    Me.update_bunner(Me.banner5_link.Text, 5, cNewFileName)
                    ''  Session("message").listbox.items.add("+ PICTURE: saved file: " + cDirectory + cNewFileName + " to " + cNewFileName + " (" + System.Convert.ToString(oFileObject.PostedFile.ContentLength) + ")")
                Else
                    Select Case nErrorType
                        Case 1
                            Session("message").listbox.items.add("- PICTURE: Error saving file: " + cNewFileName)
                        Case 2
                            Session("message").listbox.items.add("- PICTURE: Error Not an IMAGE file: " + cNewFileName)
                        Case 3
                            Session("message").listbox.items.add("- PICTURE: Error file larger then 0.5Mb: " + cNewFileName)
                    End Select
                End If
            End If
        End If
        Me.load_banner()
        ''clear the checkboxs
        Me.clear1.Checked = False
        Me.clear2.Checked = False
        Me.clear3.Checked = False
        Me.clear4.Checked = False
        Me.clear5.Checked = False
    End Sub


    Private Function sendfile(ByVal cFile As String, ByVal cDirectory As String, ByVal oFileObject As System.Web.UI.HtmlControls.HtmlInputFile, ByRef nErrorType As Integer) As Boolean
        Dim bError As Boolean = False

        '--- Check the file size
        If oFileObject.PostedFile.ContentLength > 500000 Then
            nErrorType = 3
            Return False
        End If

        '--- check if file is the correct format
        If oFileObject.PostedFile.ContentType <> "image/pjpeg" And oFileObject.PostedFile.ContentType <> "video/mpeg" And oFileObject.PostedFile.ContentType <> "image/gif" Then
            nErrorType = 2
            Return False
        End If


        '--- If File Exist delete it
        If System.IO.File.Exists(cDirectory + cFile) Then
            System.IO.File.Delete(cDirectory + cFile)
        End If



        '--- Upload file
        Try
            oFileObject.PostedFile.SaveAs(cDirectory + cFile)
            nErrorType = 0

        Catch Exp As Exception
            nErrorType = 1

        End Try

        Return False

        '---ERROR handled differently here
    End Function
    Function update_bunner(ByVal url As String, ByVal banner_id As Int32, ByVal banner_img_name As String, Optional ByVal clear As Boolean = False)

        Dim objConn As New SqlClient.SqlConnection(Application("config").connection_string)
        Dim cSQLstring As SqlClient.SqlCommand
        If clear Then
            cSQLstring = New SqlClient.SqlCommand("update ext_banner set banner_img = null,banner_link=null where banner_id=" + Convert.ToString(banner_id), objConn)
        Else
            cSQLstring = New SqlClient.SqlCommand("update ext_banner set banner_img = '" + banner_img_name + "',banner_link='" + url + "' where banner_id=" + Convert.ToString(banner_id), objConn)
        End If


        objConn.Open()

        Dim dr_Reader As SqlClient.SqlDataReader = cSQLstring.ExecuteReader()

        objConn.Close()
        dr_Reader.Close()


    End Function
    Function load_banner() As Boolean
        On Error GoTo ErrorHandler
        Dim bError As Boolean = False

        Dim oDG_search As New iDac.cls_sql_read

        oDG_search._connection_string = Application("config").connection_string ''backoffice string '' Application("connection")._connection_string
        oDG_search._tablename = "ext_banner"

        oDG_search.transact_read("select * from ext_banner")

        Dim oData As DataTable = oDG_search._datatable
        Dim i As Int32

        For i = 0 To 4
            Select Case i
                Case 0
                    If Not oData.Rows(0).Item("banner_img") Is Convert.DBNull Then
                        Me.banner_view_html(0) = "onClick=" + Chr(34) + "view_banner('" + Application("config").domain + "/precious-stones/banners/" + oData.Rows(0).Item("banner_img") + "')" + Chr(34) + " "
                        Me.banner1_link.Text = Trim(oData.Rows(0).Item("banner_link"))
                    Else
                        Me.banner1_link.Text = ""
                        Me.banner_view_html(0) = "disabled='disabled'"
                    End If
                Case 1
                    If Not oData.Rows(1).Item("banner_img") Is Convert.DBNull Then
                        Me.banner_view_html(1) = "onClick=" + Chr(34) + "view_banner('" + Application("config").domain + "/precious-stones/banners/" + oData.Rows(1).Item("banner_img") + "')" + Chr(34) + " "
                        Me.banner2_link.Text = Trim(oData.Rows(1).Item("banner_link"))
                    Else
                        Me.banner2_link.Text = ""
                        Me.banner_view_html(1) = "disabled='disabled'"
                    End If
                Case 2
                    If Not oData.Rows(2).Item("banner_img") Is Convert.DBNull Then
                        Me.banner_view_html(2) = "onClick=" + Chr(34) + "view_banner('" + Application("config").domain + "/precious-stones/banners/" + oData.Rows(2).Item("banner_img") + "')" + Chr(34) + " "
                        Me.banner3_link.Text = Trim(oData.Rows(2).Item("banner_link"))
                    Else
                        Me.banner3_link.Text = ""
                        Me.banner_view_html(2) = "disabled='disabled'"
                    End If
                Case 3
                    If Not oData.Rows(3).Item("banner_img") Is Convert.DBNull Then
                        Me.banner_view_html(3) = "onClick=" + Chr(34) + "view_banner('" + Application("config").domain + "/precious-stones/banners/" + oData.Rows(3).Item("banner_img") + "')" + Chr(34) + " "
                        Me.banner4_link.Text = Trim(oData.Rows(3).Item("banner_link"))
                    Else
                        Me.banner4_link.Text = ""
                        Me.banner_view_html(3) = "disabled='disabled'"
                    End If
                Case 4
                    If Not oData.Rows(4).Item("banner_img") Is Convert.DBNull Then
                        Me.banner_view_html(4) = "onClick=" + Chr(34) + "view_banner('" + Application("config").domain + "/precious-stones/banners/" + oData.Rows(4).Item("banner_img") + "')" + Chr(34) + " "
                        Me.banner5_link.Text = Trim(oData.Rows(4).Item("banner_link"))
                    Else
                        Me.banner5_link.Text = ""
                        Me.banner_view_html(4) = "disabled='disabled'"
                    End If
            End Select
        Next

        Return False
ErrorHandler:
        Session("o_error")._Err_Number = Err.Number
        Session("o_error")._Err_Description = Err.Description
        Session("o_error")._Err_Source = Err.Source
        Session("o_error")._Err_Module = Me.Request.CurrentExecutionFilePath
        Session("o_error")._Err_Call = "Page_Load [ErrorHandler]"
        Server.Transfer("/aspxerror.aspx")
        Return True
    End Function
End Class
