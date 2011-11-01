Imports System.IO
Imports System.Text.RegularExpressions

Public Class cls_jeweleye
    Public site_doamin As String
    Public Function CheckItemNumberPic(ByVal picdir As String, ByVal originalpath As String) As String
        Dim itemnumber As String = Regex.Match(originalpath, "\d\d-\d\d-\d{5}").Value

        If File.Exists(picdir + "\jeweldesign\jeweleye\" + itemnumber + "_icn.jpg") Then
            Return Me.site_doamin + "/precious-stones/jeweldesign/jeweleye/" + itemnumber + "_icn.jpg"
        Else
            If originalpath = "" Then
                Return "none"
            Else
                Return originalpath
            End If
        End If



    End Function



End Class
