Public Class Form1
    Inherits System.Windows.Forms.Form
    Dim cnsql As New System.Data.SqlClient.SqlConnection
    Dim adsql As New System.Data.SqlClient.SqlDataAdapter
    Dim comsql As New System.Data.SqlClient.SqlCommand
    Dim tbl As System.Data.DataTable
    Dim www As New WordLine.AllView

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.TextBox1 = New System.Windows.Forms.TextBox
        Me.Button1 = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(16, 8)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(256, 20)
        Me.TextBox1.TabIndex = 0
        Me.TextBox1.Text = ""
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(184, 240)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(88, 24)
        Me.Button1.TabIndex = 1
        Me.Button1.Text = "Button1"
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(24, 40)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(248, 184)
        Me.Label1.TabIndex = 2
        '
        'Form1
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(292, 266)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.TextBox1)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '       Dim cnsql As New System.Data.SqlClient.SqlConnection
        cnsql.ConnectionString = "user id=sa;data source=""(local)"";initial catalog=diatest"
        cnsql.Open()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim aaa As System.Data.DataRow
        Dim fff(3000) As Integer
        Dim kk As Integer
        Dim qqq As String
        tbl = New System.Data.DataTable
        qqq = www.send(Me.TextBox1.Text)
        Me.Label1.Text = qqq
        comsql.CommandText = qqq
        comsql.Connection = cnsql
        adsql.SelectCommand = comsql
        adsql.Fill(tbl)
        '
        For kk = 0 To tbl.Rows.Count - 1
            aaa = tbl.Rows(kk)
            fff(kk) = aaa.ItemArray.GetValue(0)
        Next
        tbl = Nothing
    End Sub

    Protected Overrides Sub Finalize()
        www = Nothing
        cnsql.Close()
        MyBase.Finalize()
    End Sub

End Class
