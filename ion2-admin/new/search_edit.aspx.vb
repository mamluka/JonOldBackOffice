Partial Class search_edit
    Inherits System.Web.UI.Page
    Public text_string As String
    Public url_string As String
    Public edit_mode As Boolean = False
    Public item_id As Int32

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
        If Not Page.IsPostBack Then
            Me.load_words()
        End If

    End Sub
    Function load_words(Optional ByVal id As Int32 = 0)
        Dim sSql As String
        Dim sql_search As New iDac.cls_sql_read

        sql_search._connection_string = Application("config").connection_string
        sql_search._tablename = "sys_search_words"
        ''   sql_search._datatable = Application("connection")._connection_string_type
        If id = 0 Then
            sSql = "select * from sys_search_words"
        Else
            sSql = "select * from sys_search_words where id=" + Convert.ToString(id)
        End If
        sql_search.transact_read(sSql)

        Dim oData As DataTable = sql_search._datatable

        Dim i As Int32

        If oData.Rows.Count = 0 Then
            Me.search_list.Items.Clear()
            Exit Function ''get out
        End If

        If id = 0 Then
            Me.search_list.Items.Clear()
            For i = 0 To oData.Rows.Count - 1

                Dim newitem As New System.Web.UI.WebControls.ListItem
                newitem.Text = oData.Rows(i).Item("search_word") + "- " + oData.Rows(i).Item("url")
                newitem.Value = Convert.ToString(oData.Rows(i).Item("id"))
                Me.search_list.Items.Add(newitem)

            Next
        Else
            Me.text_string = oData.Rows(i).Item("search_word")
            Me.url_string = oData.Rows(i).Item("url")

        End If
    End Function

    Private Sub btn_edit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_edit.Click
        Me.item_id = Convert.ToInt32(Me.search_list.SelectedValue)
        Me.load_words(Me.item_id)
        Me.string_txt.Text = Me.text_string
        Me.url_txt.Text = Me.url_string
        ''me.search_list.SelectedIndex = me.search_list.Items.FindByValue(convert.tostrme.item_id)
        Me.edit_mode = True
        Me.btm_add.Text = "Edit"
        Me.load_words()
        Me.search_list.SelectedIndex = Me.search_list.Items.IndexOf(Me.search_list.Items.FindByValue(Convert.ToString(Me.item_id)))
    End Sub

    Private Sub btn_delete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_delete.Click
        Me.item_id = Convert.ToInt32(Me.search_list.SelectedValue)
        Dim objConn As New SqlClient.SqlConnection(Application("config").connection_string)
        Dim cSQLstring As SqlClient.SqlCommand

        cSQLstring = New SqlClient.SqlCommand("delete sys_search_words where id = " + Convert.ToString(Me.item_id), objConn)



        objConn.Open()

        Dim dr_Reader As SqlClient.SqlDataReader = cSQLstring.ExecuteReader()

        objConn.Close()
        dr_Reader.Close()
        Me.load_words()
    End Sub

    Private Sub btm_add_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btm_add.Click

        Dim objConn As New SqlClient.SqlConnection(Application("config").connection_string)
        Dim cSQLstring As SqlClient.SqlCommand
        If Me.btm_add.Text = "Edit" Then
            Me.item_id = Convert.ToInt32(Me.search_list.SelectedValue)
            cSQLstring = New SqlClient.SqlCommand("update sys_search_words set search_word = '" + Me.string_txt.Text + "',url='" + Me.url_txt.Text + "' where id = " + Convert.ToString(Me.item_id), objConn)
        Else
            cSQLstring = New SqlClient.SqlCommand("insert into sys_search_words (search_word,url) values('" + Me.string_txt.Text + "','" + Me.url_txt.Text + "' )", objConn)
        End If






        objConn.Open()

        Dim dr_Reader As SqlClient.SqlDataReader = cSQLstring.ExecuteReader()

        objConn.Close()
        dr_Reader.Close()

        Me.btm_add.Text = "Add"
        Me.load_words()
    End Sub
End Class
