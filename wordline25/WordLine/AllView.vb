Public Class AllView
    Private decstr As WordLine.Destr
    Dim dtf As WordLine.DataFields = New WordLine.DataFields
    Dim dview As WordLine.DataDec = New WordLine.DataDec(dtf)
    Dim dmo As WordLine.GlobArr = New WordLine.GlobArr(dview.diamsdata, dview.diamsfield, dview.diamsbase)
    Dim gmo As WordLine.GlobArr = New WordLine.GlobArr(dview.gemsdata, dview.gemsfield, dview.gemsbase)
    Dim jwo As WordLine.GlobArr = New WordLine.GlobArr(dview.jewsdata, dview.jewsfield, dview.jewsbase)
    Dim proma As String
    Dim proma1 As String

    Public Function send(ByVal data As String) As String
        Dim i, nnn As Integer
        Dim mar(10) As String
        Dim kod As String
        '
        For i = 0 To 9
            mar(i) = ""
        Next i
        '
        mar = Split(data, "-", , CompareMethod.Text)
        nnn = 0
        For i = 0 To mar.Length - 1
            If IsNumeric(mar(i)) = True Then
                nnn += Len(mar(i))
            End If
        Next i
        If nnn = 9 And mar.Length = 3 Then
            send = "select id from inv_inventory where itemnumber='" & data & "'"
        Else
            ' ????????????????????????????????????????????????????????
            If nnn < 9 And mar.Length = 3 Then
                send = "select id from gemview"
            Else
                '
                send = ""
                For i = 0 To dview.customsname.ar.Length - 1
                    If StrComp(data, dview.customsname.ar.GetValue(i), CompareMethod.Text) = 0 Then
                        send = dview.customs.ar.GetValue(i)
                        Exit For
                    End If
                Next i
                If send = "" Then
                    '
                    decstr = New WordLine.Destr(data)
                    ' ??????????????????????????????????????????????????
                    If decstr.fm = "" Then
                        decstr.fm = "gem"
                    End If
                    proma = ""
                    If StrComp(decstr.fm, "diam", CompareMethod.Text) = 0 Then
                        proma = "select ID from " & dtf.views.ar.GetValue(2)
                        proma1 = dmo.decstr1(decstr)
                        If proma1 <> "" Then
                            proma += " where "
                        End If
                        proma += proma1
                    End If
                    '
                    If StrComp(decstr.fm, "gem", CompareMethod.Text) = 0 Then
                        proma = "select ID from " & dtf.views.ar.GetValue(1)
                        proma1 = gmo.decstr1(decstr)
                        If proma1 <> "" Then
                            proma += " where "
                        End If
                        proma += proma1
                    End If
                    '
                    If StrComp(decstr.fm, "jewel", CompareMethod.Text) = 0 Then
                        proma = "select ID from " & dtf.views.ar.GetValue(0)
                        proma1 = jwo.decstr1(decstr)
                        If proma1 <> "" Then
                            proma += " where "
                        End If
                        proma += proma1
                    End If
                    send = proma
                    decstr = Nothing
                End If
            End If
        End If
    End Function

    Public Sub New()

    End Sub

    Protected Overrides Sub Finalize()
        decstr = Nothing
        dtf = Nothing
        dview = Nothing
        dmo = Nothing
        jwo = Nothing
        gmo = Nothing
        MyBase.Finalize()
    End Sub

End Class

