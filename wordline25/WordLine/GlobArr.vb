Public Class GlobArr
    Private par As WordLine.StrArr
    Private fieldsname As WordLine.StrArr
    Private parbase As WordLine.StrArr
    Private twof(100, 2) As String
    Private twop(2) As String
    Private mestr As String
    Private k, met As Integer
    Private proma As WordLine.StrArr
    Private prmbase As WordLine.StrArr
    Private dstr As WordLine.Destr

    Public Sub New()

    End Sub

    Public Sub New(ByVal data As WordLine.StrArr, ByVal field As WordLine.StrArr, _
    ByVal database As WordLine.StrArr)
        '
        par = data
        parbase = database
        fieldsname = field
        '
    End Sub

    Public Property ar() As WordLine.StrArr
        Get
            Return par
        End Get
        Set(ByVal Value As WordLine.StrArr)
            par = Value
        End Set
    End Property

    Private Sub init()
        Dim j As Integer
        k = -1
        '
        j = 0
        While twof(j, 0) <> ""
            twof(j, 0) = ""
            twof(j, 1) = ""
            twof(j, 2) = 0
            j += 1
        End While
    End Sub

    Private Function minstr2(ByRef strfull As String, ByVal strin As WordLine.Destr, _
    ByVal base As WordLine.StrArr, ByVal field As String, ByVal numin1 As Integer) As Integer
        Dim i, j, win1, win2, wnn, num, kod, pri, prip As Integer
        Dim prm As String
        Dim wordbase
        Dim sfm(100) As String
        '
        pri = 0
        win1 = -1
        win2 = 0
        num = 0
        minstr2 = 0
        sfm = Split(strfull, " ", , CompareMethod.Text)
        For i = numin1 To strin.arr.Length - 1
            prm = strin.arr.GetValue(i)
            For j = 0 To base.ar.Length - 1
                If StrComp(prm, base.ar.GetValue(j), CompareMethod.Text) = 0 Then
                    pri += 1
                    wordbase = base.ar.GetValue(j)
                    Exit For
                End If
            Next j
            ''''' if prm is a number ''''''
            kod = Asc(prm)
            If kod >= 48 And kod <= 57 Then
                wnn = InStr(strfull, "%%", CompareMethod.Text)
                If wnn > 0 Then
                    strfull = Replace(strfull, "%%", prm, , 1, CompareMethod.Text)
                    sfm(win2 + 1) = prm
                End If
            End If
            ' 
            '            win1 = InStr(strfull, prm, CompareMethod.Text)
            For j = 0 To sfm.Length - 1
                If StrComp(sfm(j), prm, CompareMethod.Text) = 0 Then
                    win1 = j
                    Exit For
                End If
            Next j
            If win1 > -1 Then
                num += 1
                If num > 1 Then
                    If win1 <= win2 Then
                        num -= 1
                        Exit For
                    End If
                End If
                win2 = win1
            Else
                Exit For
            End If
        Next i
        If pri > 0 Then
            minstr2 = num
            If num - pri = 0 And StrComp(field, "stone", CompareMethod.Text) = 0 Then
                strfull = wordbase
            End If
        End If
        '
    End Function

    Private Sub identy4(ByVal data As WordLine.Destr, ByRef numw As Integer)
        Dim i, j, ipr, iprmax, num As Integer
        Dim prm As String
        Dim field As String
        Dim prof(20, 2) As String
        '
        num = -1
        i = 0
        Do While prof(i, 0) <> ""
            For j = 0 To 2
                prof(i, j) = ""
            Next j
            i += 1
        Loop
        '
        iprmax = 0
        For i = 0 To par.ar.Length - 1
            proma = par.ar.GetValue(i)
            prmbase = parbase.ar.GetValue(i)
            field = fieldsname.ar.GetValue(i)
            For j = 0 To proma.ar.Length - 1
                prm = proma.ar.GetValue(j)
                ipr = Me.minstr2(prm, data, prmbase, field, numw)
                If ipr > 0 Then
                    num += 1
                    prof(num, 0) = field
                    prof(num, 1) = prm
                    prof(num, 2) = ipr
                    If ipr > iprmax Then
                        iprmax = ipr
                    End If
                End If
            Next j
        Next i
        For i = 0 To num
            If prof(i, 2) = iprmax Then
                k += 1
                twof(k, 0) = prof(i, 0)
                twof(k, 1) = prof(i, 1)
                twof(k, 2) = prof(i, 2)
            End If
        Next i
        If num > -1 Then
            numw += iprmax - 1
        End If
    End Sub

    Public Function wsqlc() As String
        Dim i, j, nn As Integer
        Dim pr1, prv As String
        Dim prar(100) As String
        Dim pweight(6) As String
        '
        wsqlc = ""
        For i = 0 To k
            Select Case twof(i, 0)
                Case "weight"
                    pweight = Split(twof(i, 1))
                    If StrComp(pweight(1), "less", CompareMethod.Text) = 0 Then
                        If wsqlc = "" Then
                            wsqlc += " " & pweight(0) & " < " & pweight(2)
                        Else
                            wsqlc += " and " & pweight(0) & " < " & pweight(2)
                        End If
                    Else
                        If wsqlc = "" Then
                            wsqlc += " " & pweight(0) & " > " & pweight(2)
                        Else
                            wsqlc += " and " & pweight(0) & " > " & pweight(2)
                        End If
                    End If
                    If StrComp(pweight(1), "from", CompareMethod.Text) = 0 Then
                        wsqlc += " and " & pweight(0) & " < " & pweight(4)
                    End If

                Case "stone"
                    nn = -1
                    If twof(i, 0) <> "" Then
                        pr1 = twof(i, 0)
                        For j = i To k
                            If StrComp(pr1, twof(j, 0), CompareMethod.Text) = 0 Then
                                nn += 1
                                prar(nn) = twof(j, 1)
                                twof(j, 0) = ""
                            End If
                        Next j
                    End If
                    nn += 1
                    If nn > -1 Then
                        Me.sortpstone(prar, nn)
                        If wsqlc = "" Then
                            wsqlc += " ((" & pr1 & " LIKE '%" & prar(0) & "%')"
                        Else
                            wsqlc += " and ((" & pr1 & " LIKE '%" & prar(0) & "%')"
                        End If
                        If nn > 0 Then
                            For j = 1 To nn
                                wsqlc += " or (" & pr1 & " LIKE '%" & prar(j) & "%')"
                            Next
                        End If
                    End If
                    wsqlc += ")"

                Case Else
                    nn = -1
                    If twof(i, 0) <> "" Then
                        pr1 = twof(i, 0)
                        For j = i To k
                            If StrComp(pr1, twof(j, 0), CompareMethod.Text) = 0 Then
                                nn += 1
                                prar(nn) = twof(j, 1)
                                twof(j, 0) = ""
                            End If
                        Next j
                    End If
                    If nn > -1 Then
                        Me.sortp(prar, nn + 1)
                        If nn = 0 Then
                            If wsqlc = "" Then
                                wsqlc += " " & pr1 & " = '" & prar(0) & "'"
                            Else
                                wsqlc += " and " & pr1 & " = '" & prar(0) & "'"
                            End If
                        Else
                            If wsqlc = "" Then
                                wsqlc += " " & pr1 & " in('" & prar(0)
                            Else
                                wsqlc += " and " & pr1 & " in('" & prar(0)
                            End If
                            '
                            For j = 1 To nn
                                wsqlc += "','" & prar(j)
                            Next
                            wsqlc += "')"
                        End If
                    End If
            End Select
        Next i
        '
    End Function

    Public Sub sortp(ByRef data As System.Array, ByRef num As Integer)
        Dim i, j, nn As Integer
        Dim prm As String
        '
        For i = 0 To num - 1
            prm = data(i)
            If prm <> "" Then
                For j = i + 1 To num
                    If StrComp(prm, data(j), CompareMethod.Text) = 0 Then
                        data(j) = ""
                    End If
                Next j
            End If
        Next i
        '
        nn = -1
        For i = 0 To num
            If data(i) <> "" Then
                nn += 1
                data(nn) = data(i)
                If i > nn Then
                    data(i) = ""
                End If
            End If
        Next
        num = nn
        '
    End Sub
    Public Sub sortpstone(ByRef data As System.Array, ByRef num As Integer)
        Dim i, j, kk, gg, nn As Integer
        Dim prm As String
        Dim proma As WordLine.StrArr
        '
        For i = 0 To num - 1
            prm = data(i)
            If prm <> "" Then
                For j = i + 1 To num
                    If StrComp(prm, data(j), CompareMethod.Text) = 0 Then
                        data(j) = ""
                    End If
                Next j
            End If
        Next i
        '
        nn = -1
        For i = 0 To num - 1
            If data(i) <> "" Then
                nn += 1
                data(nn) = data(i)
                If i > nn Then
                    data(i) = ""
                End If
            End If
        Next
        num = nn
        '
        For i = 0 To num
            If data(i) <> "" Then
                For j = 0 To parbase.ar.Length - 1
                    proma = parbase.ar.GetValue(j)
                    For kk = 0 To proma.ar.Length - 1
                        If StrComp(data(i), proma.ar.GetValue(kk), CompareMethod.Text) = 0 Then
                            If i > 0 Then
                                For gg = 0 To i - 1
                                    If InStr(data(gg), data(i), CompareMethod.Text) > 0 Then
                                        data(gg) = ""
                                    End If
                                Next gg
                            End If
                            If i < num Then
                                For gg = i + 1 To num
                                    If InStr(data(gg), data(i), CompareMethod.Text) > 0 Then
                                        data(gg) = ""
                                    End If
                                Next gg
                            End If
                        End If
                    Next kk
                Next j
            End If
        Next i
        nn = -1
        For i = 0 To num
            If data(i) <> "" Then
                nn += 1
                data(nn) = data(i)
                If i > nn Then
                    data(i) = ""
                End If
            End If
        Next i
        num = nn
        '
    End Sub

    Public Function decstr1(ByVal data As WordLine.Destr) As String
        Dim i, j As Integer
        '
        Me.init()
        For i = 0 To data.ar.Length - 1
            Me.identy4(data, i)
        Next
        'creation of select
        decstr1 = Me.wsqlc()
        '
    End Function

    Protected Overrides Sub Finalize()
        par = Nothing
        parbase = Nothing
        prmbase = Nothing
        fieldsname = Nothing
        proma = Nothing
        dstr = Nothing
        MyBase.Finalize()
    End Sub

End Class
