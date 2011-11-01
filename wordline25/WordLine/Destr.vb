Public Class Destr
    Inherits WordLine.StrArr
    Private tbl As WordLine.Tables = New WordLine.Tables
    Private frm As String

    Public Sub New()

    End Sub

    Public Sub New(ByVal n As Integer)
        MyBase.New(n)
    End Sub

    Public Sub New(ByVal data As String)
        Dim proma As WordLine.Destr = New WordLine.Destr
        Dim i, k As Integer

        k = proma.opstra(data)
        frm = proma.fm
        arr = Array.CreateInstance(GetType(String), k + 1)

        For i = 0 To k
            arr.SetValue(proma.ar.GetValue(i), i)
        Next

        proma = Nothing
    End Sub

    Public Property arr() As System.Array
        Get
            Return Me.ar
        End Get
        Set(ByVal Value As System.Array)
            Me.ar = Value
        End Set
    End Property

    Public Property fm() As String
        Get
            Return frm
        End Get
        Set(ByVal Value As String)
            frm = Value
        End Set
    End Property

    Public Function opstra(ByVal data As String) As Integer
        Dim i, k, num As Integer
        Dim muvel As Double
        Dim prm0, prm1, pri, proma, promb As String
        Dim prm2(100) As String
        '
        pri = " "
        frm = ""
        data = Me.simb(data, ",")
        arr = Split(data, " ", -1)
        k = -1
        For i = 0 To arr.Length - 1
            prm0 = Trim(arr.GetValue(i))
            If IsNumeric(prm0) = False Then
                prm0 = tbl.conworda(prm0)
                tbl.cntb(prm0, frm)
            End If
            If Len(prm0) > 0 Then
                k += 1
                arr.SetValue(prm0, k)
            End If
        Next i
        '
        pri = ""
        num = -1
        For i = 0 To k
            prm0 = arr.GetValue(i)
            If IsNumeric(prm0) = True Then
                Select Case i
                    Case 0
                        If i = k Then
                            pri = "a"
                        Else
                            promb = arr.GetValue(i + 1)
                            If promb = "to" Then
                                If i + 2 <= k Then
                                    If IsNumeric(arr.GetValue(i + 2)) = False Then
                                        arr.SetValue("", i + 1)
                                        pri = "a"
                                    End If
                                Else
                                    arr.SetValue("", i + 1)
                                    pri = "a"
                                End If
                            Else
                                pri = "a"
                            End If
                        End If
                    Case k
                        proma = arr.GetValue(i - 1)
                        If proma = "to" Then
                            If i > 1 Then
                                If IsNumeric(arr.GetValue(i - 2)) = False Then
                                    num -= 1
                                    proma = ""
                                End If
                            Else
                                num -= 1
                                proma = ""
                            End If
                        End If
                        If proma <> "to" And proma <> "more" And proma <> "less" Then
                            pri = "a"
                        End If
                    Case Else
                        proma = arr.GetValue(i - 1)
                        promb = arr.GetValue(i + 1)
                        If proma = "to" Then
                            If i > 1 Then
                                If IsNumeric(arr.GetValue(i - 2)) = False Then
                                    num -= 1
                                    proma = ""
                                End If
                            Else
                                num -= 1
                                proma = ""
                            End If
                        End If
                        If promb = "to" Then
                            If i + 2 <= k Then
                                If IsNumeric(arr.GetValue(i + 2)) = False Then
                                    arr.SetValue("", i + 1)
                                    promb = ""
                                End If
                            Else
                                arr.SetValue("", i + 1)
                                promb = ""
                            End If
                        End If
                        If proma <> "from" And proma <> "to" And proma <> "more" _
                         And proma <> "less" And promb <> "to" Then
                            pri = "a"
                        End If
                End Select
                If pri = "a" Then
                    muvel = Val(prm0)
                    num += 1
                    prm2(num) = Trim(Str(muvel * 0.7))
                    num += 1
                    prm2(num) = "to"
                    num += 1
                    prm2(num) = Trim(Str(muvel * 1.3))
                End If
            End If
            If pri = "a" Then
                pri = ""
            Else
                If prm0 <> "" Then
                    num += 1
                    prm2(num) = prm0
                End If
            End If
        Next i
        '
        arr = prm2
        opstra = num
        '
    End Function

    'Public Shared Function connum(ByVal data As String) As String
    '    Dim kod As Integer
    '    connum = ""
    '    If Len(data) > 0 Then
    '        kod = Asc(data)
    '        If kod >= 48 And kod <= 57 Then
    '            connum = data
    '        End If
    '    End If
    'End Function

    Public Shared Function simb(ByVal data As String, ByVal sign As String) As String
        Dim mmm, lll As Integer
        Dim proma As String
        '
        mmm = 1
        proma = ""
        lll = Len(data)
        Do While mmm > 0
            mmm = InStr(data, sign, CompareMethod.Text)
            If mmm > 0 Then
                proma = proma + " " + Left(data, mmm - 1)
                lll = lll - mmm
                data = Right(data, lll)
            End If
        Loop
        simb = Trim(proma + " " + data)
        '
    End Function

    Protected Overrides Sub Finalize()
        tbl = Nothing
        MyBase.Finalize()
    End Sub

End Class
