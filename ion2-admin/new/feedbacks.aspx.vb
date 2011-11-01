Partial Class feedbacks
    Inherits System.Web.UI.Page
    Public feedback_coll As New ArrayList
    Public errorstr As String

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





        If Request.QueryString("id") <> "" Then
            Dim osql As New iDac.cls_T_command
            osql._connection_string = Application("config").connection_string
            osql._dbtype = Application("config").connection_string_type
            osql._sqlstring = "update usr_FEEDBACKS set text ='" + Request.QueryString("feed_text").Replace("'", "''") + "',item1_id=" + Request.QueryString("item_pic") + ",item2_id=" + Request.QueryString("item_sort") + ", active=" + Request.QueryString("active") + ", showemail=" + Request.QueryString("email") + " where id =" + Request.QueryString("id")
            osql.transact_command()
        End If
        ''Me.load_table(Me.link_coll)





        Dim oDG_search As New iDac.cls_sql_read
        Dim ssql As String = "select * from usr_FEEDBACKS ORDER BY id desc"

        oDG_search._connection_string = Application("config").connection_string
        oDG_search._tablename = "lnk_links"


        oDG_search.transact_read(ssql)

        Me.errorstr = oDG_search._err_description + " " + Application("config").connection_string + " " + oDG_search._err_source

        Dim i As Int32

        Dim oData As DataTable = oDG_search._datatable

        For i = 0 To oData.Rows.Count - 1
            Dim tmpitem As New feedback_item

            tmpitem.id = oData.Rows(i).Item("id")
            tmpitem.name = oData.Rows(i).Item("user_name")
            tmpitem.email = oData.Rows(i).Item("user_email")
            tmpitem.text = oData.Rows(i).Item("text")
            '' tmpitem.active = oData.Rows(i).Item("active")
            If oData.Rows(i).Item("active") Then
                tmpitem.active = "checked = " + Chr(34) + "checked" + Chr(34)
            Else
                tmpitem.active = ""
            End If
            tmpitem.country = oData.Rows(i).Item("country")

            If InStr(oData.Rows(i).Item("state"), "-") = 0 Then
                tmpitem.country += ", " + oData.Rows(i).Item("state")
            End If


            tmpitem.item_pic = oData.Rows(i).Item("item1_id")
            tmpitem.item_sort = oData.Rows(i).Item("item2_id")

            If oData.Rows(i).Item("showemail") Then
                tmpitem.showemail = "checked = " + Chr(34) + "checked" + Chr(34)
            Else
                tmpitem.showemail = ""
            End If


            Me.feedback_coll.Add(tmpitem)

        Next



    End Sub
    Public Class feedback_item
        Public id As Int32
        Public country As String
        Public name As String
        Public text As String
        Public item_pic As Int32
        Public item_sort As Int32
        Public active As String
        Public email As String
        Public showemail As String
    End Class

End Class
