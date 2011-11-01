''Imports ICSharp
''Code.SharpZipLib.Zip
Imports System.Net.WebClient

Partial Class idex
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

        'Dim client As New System.Net.WebClient

        'File.Delete(Server.MapPath("/idex_tmp.zip"))

        'client.DownloadFile("http://www.idexonline.com/download_inventory_excel/TwinDiamondsFeed.asp?format=csv&item_type=1", Server.MapPath("/idex_tmp.zip"))
        '''   http://www.idexonline.com/download_inventory_excel/TwinDiamondsFeed.asp?format=csv&item_type=1

        'Dim s As New ZipInputStream(File.OpenRead(Server.MapPath("/idex_tmp.zip")))
        'Dim entry As ZipEntry
        'entry = s.GetNextEntry
        '''While Not IsNothing(entry Is s.GetNextEntry())
        'Dim filename = entry.Name
        'If filename <> String.Empty Then
        '    Dim sw As FileStream = File.Create(Server.MapPath("/idex_csv.csv"))
        '    Dim size As Int32 = 2048
        '    Dim data1(2048) As Byte

        '    While (True)
        '        size = s.Read(data1, 0, data1.Length)
        '        If (size > 0) Then
        '            sw.Write(data1, 0, size)
        '        Else
        '            Exit While
        '        End If
        '    End While
        '    sw.Close()
        '    sw = Nothing

        'End If
        's.Close()
        's = Nothing

        'Dim idex As New ion_two.cls_idex_v2
        'idex.conn_string = Application("config").connection_string
        'idex.dbtype = Application("config").connection_string_type
        '''idex.ImportFromCSV(Server.MapPath("/idex_csv.csv"))


        ''' File.Delete(Server.MapPath("/idex_csv.csv"))
        '''End While
        ''Dim a As New OrganicBit.Zip.ZipReader(Server.MapPath("/a.zip"))
        ''Dim buffer(1000000) As Byte
        ''Dim bytecount As Int64 = 0
        ''While a.MoveNext
        ''    Dim entry As OrganicBit.Zip.ZipEntry = a.Current
        ''    If entry.IsDirectory Then

        ''        Directory.CreateDirectory(entry.Name)
        ''    Else
        ''        Dim writer As FileStream = File.Open(Server.MapPath("/") + entry.Name, FileMode.Create)
        ''        While bytecount = a.Read(buffer, 0, buffer.Length) > 0
        ''            writer.Write(buffer, 0, bytecount)
        ''        End While
        ''        writer.Close()

        ''    End If
        ''End While
        ''a.Close()
    End Sub

End Class
