Imports System.Data.SqlClient
Imports System.Web.UI.WebControls


Partial Class old_note_prog
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

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim oConnection As SqlClient.SqlConnection = New SqlClient.SqlConnection
        Dim oDataAdapter1 As SqlDataAdapter = New SqlDataAdapter
        Dim oDataAdapter2 As SqlDataAdapter = New SqlDataAdapter
        Dim oSQLcmd1 As SqlCommand = New SqlCommand("", oConnection)
        ''
        ''  System.Threading.Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.CreateSpecificCulture(Request.UserLanguages(0))
        '' System.Threading.Thread.CurrentThread.CurrentUICulture = New System.Globalization.CultureInfo(Request.UserLanguages(0))
        '--- create connection


        '---- handle number
        Dim itemnumber As String = Me.Id_number.Text

        If itemnumber.Substring(2, 1) <> "-" Then
            itemnumber = itemnumber.Insert(2, "-")
        End If

        oConnection.ConnectionString = Application("config").connection_string
        oDataAdapter1.TableMappings.Add("Table", "inv_inventory")


        oSQLcmd1.CommandText = "select * from inv_inventory where itemnumber = '" + itemnumber + "'"
        oSQLcmd1.CommandType = CommandType.Text
        oDataAdapter1.SelectCommand = oSQLcmd1

        Dim oDs As DataSet
        oDs = New DataSet("inv_inventory")

        oConnection.Open()
        oDataAdapter1.Fill(oDs)




        If Not (oDs.Tables.Count = 0) Then
            Dim tmpTable As DataTable = oDs.Tables("inv_inventory")
            lbl_note.Text = tmpTable.Rows(0).Item("notes")

            If tmpTable.Rows(0).Item("platetype") <> 3 Then
                Me.lbl_middle_desc.Text = "Not a Ring"
                Exit Sub
            End If

            Dim tmpId As Integer = tmpTable.Rows(0).Item("id")

            '' oConnection.Close()


            oDataAdapter2.TableMappings.Add("Table", "inv_jewelry")


            oSQLcmd1.CommandText = "select * from inv_jewelry where inventory_id = " + Convert.ToString(tmpId)
            oSQLcmd1.CommandType = CommandType.Text
            oDataAdapter2.SelectCommand = oSQLcmd1

            Dim oDs2 As DataSet
            oDs2 = New DataSet("inv_jewelry")

            ''oConnection.Open()
            oDataAdapter2.Fill(oDs2)


            Dim tmpTable2 As DataTable = oDs2.Tables("inv_jewelry")

            If Not Convert.IsDBNull(tmpTable2.Rows(0).Item("middlestone_desc")) Then
                lbl_middle_desc.Text = tmpTable2.Rows(0).Item("middlestone_desc")
            Else
                lbl_middle_desc.Text = "None Present"
            End If
        End If
    End Sub
End Class
