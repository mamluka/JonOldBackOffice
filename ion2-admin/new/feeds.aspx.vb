Partial Class feeds
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

    Private Sub feed_shopping_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles feed_shopping.Click
        Dim oshopping As New ion_two.cls_shopping

        oshopping.conn_string = Application("config").connection_string
        oshopping.dbtype = Application("config").connection_string_type
        oshopping.xmlfile = Server.MapPath("/google.xml")
        oshopping.descxml = Server.MapPath("/xml/itemdesc.xml")
        oshopping.facefile = Server.MapPath("/xml/faces.xml")
        oshopping.file = Server.MapPath("shopping.csv")
        oshopping.GetCSV()

        Dim path As String = oshopping.file 'get file object as FileInfo
        Dim file As System.IO.FileInfo = New System.IO.FileInfo(path) '-- if the file exists on the server

        If file.Exists Then 'set appropriate headers
            Response.Clear()
            Response.AddHeader("Content-Disposition", "attachment; filename=" & file.Name)
            ''   Response.AddHeader("Content-Length", file.Length.ToString())
            Response.ContentType = "text/plain"
            Response.WriteFile(file.FullName)
            Response.End() 'if file does not exist
        End If
    End Sub

    Private Sub feed_google_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles feed_google.Click
        Dim ogoogle As New ion_two.cls_google_products
        ogoogle.conn_string = Application("config").connection_string
        ogoogle.dbtype = Application("config").connection_string_type
        ogoogle.xmlfile = Server.MapPath("/google.xml")
        ogoogle.descxml = Server.MapPath("/xml/itemdesc.xml")
        ogoogle.CreateFeed()


        Dim path As String = ogoogle.xmlfile  'get file object as FileInfo
        Dim file As System.IO.FileInfo = New System.IO.FileInfo(path) '-- if the file exists on the server

        If file.Exists Then 'set appropriate headers
            Response.Clear()
            Response.AddHeader("Content-Disposition", "attachment; filename=" & file.Name)
            ''   Response.AddHeader("Content-Length", file.Length.ToString())
            Response.ContentType = "text/plain"
            Response.WriteFile(file.FullName)
            Response.End() 'if file does not exist
        End If

    End Sub

    Private Sub feed_sharesale_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles feed_sharesale.Click
        Dim osharesale As New ion_two.cls_sharesale

        osharesale.conn_string = Application("config").connection_string
        osharesale.dbtype = Application("config").connection_string_type
        osharesale.xmlfile = Server.MapPath("/google.xml")
        osharesale.descxml = Server.MapPath("/xml/itemdesc.xml")
        osharesale.facefile = Server.MapPath("/xml/faces.xml")
        osharesale.file = Server.MapPath("sharesale.txt")
        osharesale.GetCSV()


        Dim path As String = osharesale.file    'get file object as FileInfo
        Dim file As System.IO.FileInfo = New System.IO.FileInfo(path) '-- if the file exists on the server

        If file.Exists Then 'set appropriate headers
            Response.Clear()
            Response.AddHeader("Content-Disposition", "attachment; filename=" & file.Name)
            ''   Response.AddHeader("Content-Length", file.Length.ToString())
            Response.ContentType = "text/plain"
            Response.WriteFile(file.FullName)
            Response.End() 'if file does not exist
        End If


    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim owebidz As New ion_two.cls_webidz

        owebidz.conn_string = Application("config").connection_string
        owebidz.dbtype = Application("config").connection_string_type
        owebidz.xmlfile = Server.MapPath("/google.xml")
        owebidz.descxml = Server.MapPath("/xml/itemdesc.xml")
        owebidz.facefile = Server.MapPath("/xml/faces.xml")
        owebidz.file = Server.MapPath("webidz.csv")
        owebidz.GetCSV()


        Dim path As String = owebidz.file    'get file object as FileInfo
        Dim file As System.IO.FileInfo = New System.IO.FileInfo(path) '-- if the file exists on the server

        If file.Exists Then 'set appropriate headers
            Response.Clear()
            Response.AddHeader("Content-Disposition", "attachment; filename=" & file.Name)
            ''   Response.AddHeader("Content-Length", file.Length.ToString())
            Response.ContentType = "text/plain"
            Response.WriteFile(file.FullName)
            Response.End() 'if file does not exist
        End If

    End Sub

    Private Sub btn_prostore_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_prostore.Click
        Dim oprostore As New ion_two.cls_prostore

        oprostore.conn_string = Application("config").connection_string
        oprostore.dbtype = Application("config").connection_string_type
        oprostore.xmlfile = Server.MapPath("/google.xml")
        oprostore.descxml = Server.MapPath("/xml/itemdesc.xml")
        oprostore.facefile = Server.MapPath("/xml/faces.xml")
        oprostore.file = Server.MapPath("prostore.csv")
        If Me.txt_sql.Text <> "" Then
            oprostore.sql = Me.txt_sql.Text
        End If

        oprostore.GetCSV()


        Dim path As String = oprostore.file    'get file object as FileInfo
        Dim file As System.IO.FileInfo = New System.IO.FileInfo(path) '-- if the file exists on the server

        If file.Exists Then 'set appropriate headers
            Response.Clear()
            Response.AddHeader("Content-Disposition", "attachment; filename=" & file.Name)
            ''   Response.AddHeader("Content-Length", file.Length.ToString())
            Response.ContentType = "text/plain"
            Response.WriteFile(file.FullName)
            Response.End() 'if file does not exist
        End If

    End Sub
End Class
