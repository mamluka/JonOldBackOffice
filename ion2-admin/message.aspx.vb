Partial Class message
    Inherits System.Web.UI.Page


    Public cMessage, cReturnPath As String

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

        'cMessage = Request.QueryString("msg")
        'cReturnPath = Request.QueryString("path")

        'lsl_message.Items.Add(cMessage)


        If Not Page.IsPostBack Then
            '--- Clear box
            Me.lsl_message.Items.Clear()


            Dim nCount As Integer
            For nCount = 0 To Session("message").listbox.Items.Count
                If nCount = Session("message").listbox.Items.Count Then
                    Exit For
                Else
                    Me.lsl_message.Items.Add(Session("message").listbox.items(nCount).text)
                End If
            Next

            '--- after showing, clear message.listbox
            Session("message").listbox.Items.clear()

        End If



    End Sub

    Private Sub btn_ok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_ok.Click
        Dim cReturnpath As String
        cReturnpath = Session("message").returnpath

        If IsNothing(cReturnpath) Then
            cReturnpath = "/default.aspx"
            Server.Transfer(cReturnpath)
            Exit Sub
        End If

        If cReturnpath.Trim = "" Then
            cReturnpath = "/default.aspx"
            Server.Transfer(cReturnpath)
            Exit Sub
        End If

        Server.Transfer(cReturnpath)

    End Sub
End Class
