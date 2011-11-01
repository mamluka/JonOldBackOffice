Partial Class diamond_importer
    Inherits System.Web.UI.Page

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

    Private Sub btn_process_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_process.Click

        If Not datafile.PostedFile Is Nothing And datafile.PostedFile.ContentLength > 0 Then
            Dim fn As String = System.IO.Path.GetFileName(datafile.PostedFile.FileName)
            Dim SaveLocation As String = Server.MapPath("/diamond-xls") + "\" + fn
            Try
                datafile.PostedFile.SaveAs(SaveLocation)
                Me.lbl_status.Text = "File Uploaded"

                Dim oimporter As New ion_two.cls_diamond_importer

                Dim dataid As Int32 = Convert.ToInt32(Me.cmb_datatype.SelectedValue)
                Select Case Me.cmb_datatype.SelectedValue
                    Case "1", "2"
                        oimporter.conn_string = Application("config").connection_string
                        oimporter.dbtype = Application("config").connection_string_type
                        oimporter.filename = SaveLocation
                        oimporter.StartImport(dataid)



                End Select


            Catch Exc As Exception
                Me.lbl_status.Text = "Error: " & Exc.Message
            End Try
        Else
            Me.lbl_status.Text = "No file name"
        End If


    End Sub




End Class
