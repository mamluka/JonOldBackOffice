Imports System.IO
Imports System.Web
Imports System.Text.RegularExpressions
Public Class cls_mod_metal
    Function semiPrice_bymetal(ByVal oldmetal As String, ByVal oldprice As Decimal, ByVal metalid As Int16, ByRef newprice As Decimal, ByVal modid As Int32)


        If InStr(oldmetal, "Gold") > 0 And metalid = 0 Then

            If modid = 1 Then
                newprice = oldprice + 350
            Else
                newprice = oldprice + 450
            End If
            ''  newprice = oldprice * Me.getconvetion_precent_byprice(oldprice)

        ElseIf InStr(oldmetal, "Plat") > 0 And metalid > 0 Then

            If modid = 1 Then
                newprice = oldprice - 350
            Else
                newprice = oldprice - 450
            End If
            'newprice = oldprice / Me.getconvetion_precent_byprice(oldprice)

        Else
            newprice = oldprice


        End If




    End Function

    Function getconvetion_precent_byprice(ByVal price As Decimal) As Decimal
        Select Case price
            Case price <= 2000
                Return 1.3
            Case (price >= 2000 And price <= 4000)
                Return 1.25
            Case Else
                Return 1.15
        End Select
    End Function
    ''also check if it exists
    Function GetImageUrlByMetalCode(ByRef imageurl As String, ByVal code As String) As Boolean
        Dim path_1 As String = Mid(imageurl, Split(imageurl, "/")(0).Length + Split(imageurl, "/")(2).Length + 3)

        Dim realPath As String = Web.HttpContext.Current.Server.MapPath(path_1)
        ''Dim path_parts() As String = realPath.Split("\")
        ''Dim imagerework As String = path_parts(path_parts.Length - 1)
        Dim ext As String = Path.GetExtension(realPath)


        Select Case code.ToUpper
            Case "P"
                If File.Exists(Regex.Replace(realPath, ext, "_pl" + ext)) Then
                    imageurl = Regex.Replace(imageurl, ext, "_pl" + ext)
                End If
            Case "Y"
                If File.Exists(Regex.Replace(realPath, ext, "_yg" + ext)) Then
                    imageurl = Regex.Replace(imageurl, ext, "_yg" + ext)
                End If
            Case "W"
                If File.Exists(Regex.Replace(realPath, ext, "_wg" + ext)) Then
                    imageurl = Regex.Replace(imageurl, ext, "_wg" + ext)
                End If

        End Select



        ''file.Exists(
    End Function
    Public Function GenerateAltMetalWithDelta(ByVal origmetal As String, ByVal delta As Int32, ByVal metallist As ArrayList) As Boolean

        Dim karat As String = Regex.Match(origmetal, "\s\d+\s[k|K]").Value()

        If karat = "" Then karat = "18"

        If Mid(origmetal, 1, 1) = "P" Then
            Dim pl As New Hashtable
            pl("Platinum") = "delta::0^metal::p"

            metallist.Add(pl)

            Dim wg As New Hashtable
            wg("White Gold " + karat + " Karat") = "delta::" + delta.ToString + "^metal::w"
            metallist.Add(wg)

            Dim yg As New Hashtable
            yg("Yellow Gold " + karat + " Karat") = "delta::" + delta.ToString + "^metal::y"

            metallist.Add(yg)


        End If

        If Mid(origmetal, 1, 1) = "W" Then

            Dim wg As New Hashtable
            wg("White Gold " + karat + " Karat") = "delta::0^metal::w"
            metallist.Add(wg)
            Dim pl As New Hashtable
            pl("Platinum") = "delta::" + delta.ToString + "^metal::p"
            metallist.Add(pl)
            Dim yg As New Hashtable
            yg("Yellow Gold " + karat + " Karat") = "delta::0^metal::y"
            metallist.Add(yg)


        End If

        If Mid(origmetal, 1, 1) = "Y" Then

            Dim yg As New Hashtable
            yg("Yellow Gold " + karat + " Karat") = "delta::0^metal::y"
            metallist.Add(yg)
            Dim pl As New Hashtable
            pl("Platinum") = "delta::" + delta.ToString + "^metal::p"
            metallist.Add(pl)
            Dim wg As New Hashtable
            wg("White Gold " + karat + " Karat") = "delta::0^metal::w"
            metallist.Add(wg)


        End If


    End Function
End Class
