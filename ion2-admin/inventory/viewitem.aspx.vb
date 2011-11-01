Partial Class viewitem
    Inherits System.Web.UI.Page


#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub

#End Region

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Put user code to initialize the page here
        Dim cItem As String = Request.QueryString("pic")

        If cItem <> "" Then
            Me.img_picture.Visible = True
            Me.lbl_nothing.Visible = False
            Me.img_picture.Src = cItem
        Else
            Me.img_picture.Visible = False
            Me.lbl_nothing.Visible = True
            Me.lbl_nothing.Text = "No Picture to display"

        End If




    End Sub

End Class
