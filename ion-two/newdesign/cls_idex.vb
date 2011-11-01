Imports System.IO
''Imports ICSharpCode.SharpZipLib.Zip
Imports System.Net.WebClient
Public Class cls_idex_v2
    Public conn_string As String
    Public dbtype As String
    Public link As String
    Public path As String

    'Public Function ImportFromCSV(ByVal filename As String)

    '    Dim osql As New iDac.cls_T_command
    '    osql._dbtype = Me.dbtype
    '    osql._connection_string = Me.conn_string

    '    ''   Me.Label3.Text = "update sys_groups set group_items = '" + Join(tmparray.ToArray, "|") + "' where group_key = '" + Me.lst_group.SelectedValue + "'"
    '    osql._sqlstring = "delete from inv_idex"
    '    osql.transact_command()
    '    osql._sqlstring = "BULK INSERT inv_idex FROM '" + filename + "' WITH ( FIRSTROW = 2, FIELDTERMINATOR = ',',ROWTERMINATOR = '\n',KEEPIDENTITY,KEEPNULLS ) "
    '    osql.transact_command()









    'End Function
    'Function GetUpdateFromWeb_v1()
    '    Dim client As New System.Net.WebClient

    '    File.Delete(path + "/idex_tmp.zip")

    '    client.DownloadFile(Me.link, path + "/idex_tmp.zip")
    '    ''   http://www.idexonline.com/download_inventory_excel/TwinDiamondsFeed.asp?format=csv&item_type=1

    '    Dim s As New ZipInputStream(File.OpenRead(path + "/idex_tmp.zip"))
    '    Dim entry As ZipEntry
    '    entry = s.GetNextEntry
    '    ''While Not IsNothing(entry Is s.GetNextEntry())
    '    Dim filename = entry.Name
    '    If filename <> String.Empty Then
    '        Dim sw As FileStream = File.Create(path + "/idex_csv.csv")
    '        Dim size As Int32 = 2048
    '        Dim data1(2048) As Byte

    '        While (True)
    '            size = s.Read(data1, 0, data1.Length)
    '            If (size > 0) Then
    '                sw.Write(data1, 0, size)
    '            Else
    '                Exit While
    '            End If
    '        End While
    '        sw.Close()
    '        sw = Nothing

    '    End If
    '    s.Close()
    '    s = Nothing

    '    ImportFromCSV(path + "/idex_csv.csv")
    '    File.Delete(path + "/idex_csv.csv")
    '    File.Delete(path + "/idex_tmp.zip")
    'End Function


    'BULK INSERT inv_idex 
    '    FROM 'c:\a.csv' 
    '    WITH 
    '    ( 
    '	--FIRSTROW = 2, 
    '	FIELDTERMINATOR = ',',
    '        ROWTERMINATOR = '\n' ,
    '	 KEEPIDENTITY,
    '        KEEPNULLS

    '    )

    '    From: Hadas Levi [mailto:hadas.levi@gmail.com] 
    'Sent: Wednesday, October 24, 2007 2:58 PM
    'To: avi@twin-diamonds.com
    'Subject: Re: Link to IDEX Feed -Twin Diamonds



    'got it thanks!:-) 

    'On 10/24/07, Hadas Levi <hadas.levi@gmail.com> wrote: 

    'Hey Avi, 

    'The link is:

    'http://www.idexonline.com/download_inventory_excel/TwinDiamondsFeed.asp?format=csv&item_type=1

    'Link parameters

    '1. format=csv ; csv can be changed to txt for text file or xls for excel file

    '2. item_type=1 (1 – singles, 2 – parcels, 3 – pairs, 4 - sets) 

End Class
Public Class cls_idexPlateItem

    Public itemid As String

    Public shape As String
    Public weight As Decimal
    Public weight_formatted As String
    Public color As String
    Public clarity As String
    Public certificate As String
    Public certificate_number As String
    Public make As String
    Public location As String
    Public ppc As Decimal
    Public price As Decimal
    Public price_formatted As String
    Public measurements As String
    Public total_depth As String
    Public table_width As String
    Public crown_height As String
    Public pavilion As String

    Public girdle As String
    Public polish As String
    Public symmetry As String
    Public culet As String
    Public graining As String
    Public fluorescence As String
    Public supplier As String
    Public certificate_path As String

    ''backwords compatability


    Public _item_description As String
    Public _icon_pic As String
    Public _itemnumber As String = "0"
    Public _platetype As Int16 = 1
    Public _category_name As String = "Diamonds"
    Public _subcategory_name As String = "Diamonds, Loose"

    Public _category_id As Int16 = 1
    Public _subcategory_id As Int16 = 6
    Public _sell_price As Decimal = price
    Public _appraisal_price As Decimal = price * 3.8
    Public _item_sold As Boolean = False
    Public _picture_pic As String = ""
    Public _certificate_pic As String = ""
    Public _is_hires As Boolean = False
    Public _is_report As Boolean = False
    Public _is_gallery As Boolean = False
    Public _id As Int32 = itemid

    Public opthash As New Hashtable

End Class
Public Class cls_mod_idex_item
    Public description As String
    Public price As Decimal
    Public extrainfo As String
    Public iconpic As String
    Public idex_id As Int32
End Class
