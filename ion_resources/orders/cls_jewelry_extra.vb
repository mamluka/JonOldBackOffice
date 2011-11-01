Public Class cls_jewerly_extra
    Inherits iFoundation.cls_error
    ''the stone price/stone chane vars
    Public _stone_price As String
    Public _stone_center As String
    Public _stone_side As String
    Public _metal_type As String
    Public _metal_price As String

    Public c_desc As String
    Public c_type As String
    Public c_cut As String

    Public s_desc As String
    Public s_type As String
    Public s_cut As String


    Public Function set_extra_item(ByVal eml As System.Web.UI.WebControls.ListBox) As String
        Dim i As Int16
        Dim tmpStr As String = ""
        For i = 0 To eml.Items.Count - 1
            tmpStr = tmpStr + eml.Items(i).Text + "|"
        Next
        Return tmpStr
    End Function
    Public Function get_extra_items(ByVal eml As String, ByRef thelistbox As System.Web.UI.WebControls.DropDownList) As Boolean
        Dim i As Int16
        Dim tmpStr As String = eml
        Dim tmpitemadd As String = ""
        If eml = "None" Then Exit Function
        Do Until tmpStr.Length = 0
            i = i + 1
            tmpitemadd = Mid(tmpStr, 1, tmpStr.IndexOf("|"))
            tmpStr = Mid(tmpStr, tmpStr.IndexOf("|") + 2, tmpStr.Length)
            thelistbox.Items.Add(tmpitemadd)
            If i = 10 Then Exit Do

        Loop


    End Function
    Public Function load_extra_metal(ByVal eml As String, ByRef thelistbox As System.Web.UI.WebControls.ListBox) As Boolean
        Dim i As Int16
        Dim tmpStr As String = eml
        Dim tmpitemadd As String = ""
        If eml = "None" Then Exit Function
        Do Until tmpStr.Length = 0
            i = i + 1
            tmpitemadd = Mid(tmpStr, 1, tmpStr.IndexOf("|"))
            tmpStr = Mid(tmpStr, tmpStr.IndexOf("|") + 2, tmpStr.Length)
            thelistbox.Items.Add(tmpitemadd)
            If i = 1000 Then Exit Do

        Loop

    End Function
    Public Function load_extra_stone(ByVal eml As String, ByRef thelistbox As System.Web.UI.WebControls.ListBox) As Boolean
        Dim i As Int16
        Dim tmpStr As String = eml
        Dim tmpitemadd As String = ""
        If eml = "None" Then Exit Function
        Do Until tmpStr.Length = 0
            i = i + 1
            tmpitemadd = Mid(tmpStr, 1, tmpStr.IndexOf("|"))
            tmpStr = Mid(tmpStr, tmpStr.IndexOf("|") + 2, tmpStr.Length)
            thelistbox.Items.Add(tmpitemadd)
            ''secure not to make endless loop
            If i = 1000 Then Exit Do

        Loop


    End Function
    Public Function get_stone_fromstr(ByVal str As String) As Boolean
        Dim tmpmidpos As Int16 = InStr(str, " - ", CompareMethod.Text) - 1
        Me._stone_center = Mid(str, 15, tmpmidpos - 14)
        str = Mid(str, tmpmidpos + 4, str.Length)
        tmpmidpos = InStr(str, " - ", CompareMethod.Text) - 1
        Me._stone_side = Mid(str, 14, tmpmidpos - 13)
        Me._stone_price = Mid(str, tmpmidpos + 4, str.Length)
        Me._stone_price = Me._stone_price.Remove(Me._stone_price.Length - 1, 1)
    End Function
    Public Function get_metal_fromstr(ByVal str As String) As Boolean
        Dim tmpmidpos As Int16 = InStr(str, " - ", CompareMethod.Text) - 1
        Me._metal_type = Mid(str, 1, tmpmidpos)
        Me._metal_price = Mid(Mid(str, tmpmidpos + 4, 12), 1, Mid(str, tmpmidpos + 4, 12).Length - 1)
    End Function
    '' this func is for making the save string sep '|'
    Public Function set_stone_extended_string(ByVal c_desc As String, ByVal c_type As String, ByVal c_cut As String, ByVal s_desc As String, ByVal s_type As String, ByVal s_cut As String) As String
        ''make the str
        Return c_desc + "|" + c_type + "|" + c_cut + "|" + s_desc + "|" + s_type + "|" + s_cut + "|"
    End Function

    ''this func reads the stone_ext proparties
    Public Function get_stone_extended_string(ByVal sES)
        Dim i As Int16 = 1
        Dim tmpStr As String = sES
        Dim tmpitemadd As String = ""
        If sES = "None" Then Exit Function


        Do Until tmpStr.Length = 0

            tmpitemadd = Mid(tmpStr, 1, tmpStr.IndexOf("|"))
            tmpStr = Mid(tmpStr, tmpStr.IndexOf("|") + 2, tmpStr.Length)
            Select Case i
                Case 1
                    c_desc = tmpitemadd
                Case 2
                    c_type = tmpitemadd
                Case 3
                    c_cut = tmpitemadd
                Case 4
                    s_desc = tmpitemadd
                Case 5
                    s_type = tmpitemadd
                Case 6
                    s_cut = tmpitemadd
            End Select
            ''secure not to make endless loop
            i = i + 1
            If i = 7 Then Exit Do

        Loop
    End Function
    ''get the price of the metal that is original for product
    Public Function get_unset_metalprice(ByVal weight As Decimal, ByVal type As String) As Decimal
        Dim oRate As New cls_rate
        Return weight * oRate.get_metal_rate(type)
    End Function
    Public Function get_extrainfo_type(ByVal str As String) As String
        Return Mid(str, 1, 3)
    End Function
    Public Function get_savestr_params(ByVal str As String, ByVal type As Int32)
        Dim i As Int16 = 1
        Dim tmpStr() As String
        Dim tmpitemadd As String = ""
        Dim p1, p2, p3, p4, p5, p6 As String
        If str = "None" Then Exit Function
        tmpStr = str.Split("|")
        If tmpStr.Length > 0 Then
            p1 = tmpStr(0)
        End If
        If tmpStr.Length > 1 Then
            p2 = tmpStr(1)
        End If
        If tmpStr.Length > 2 Then
            p3 = tmpStr(2)
        End If
        If tmpStr.Length > 3 Then
            p4 = tmpStr(3)
        End If
        If tmpStr.Length > 4 Then
            p5 = tmpStr(4)

        End If
        If tmpStr.Length > 5 Then
            p6 = tmpStr(5)
        End If

        Select Case type
            Case 1
                If p1 = "IDX" Then
                    Return "This is IDEX item: " + p2
                ElseIf p1 = "EXT" Then
                    Return "Metal: " + p2 + "<br>" + p3
                ElseIf p1 = "MDP" Then
                    Return "This is a Side Stone Order<br>Cut:" + p3 + "<br>Qaulity:" + p4 + "<br>Size:" + p5 + "<br>Weight:" + p6
                ElseIf p1 = "DGS" Then
                    Return "This is a style select for Three-stone ring<br>The model selected is item:" + p4 + "<br>Metal selected is: " + p3
                End If
            Case 2 '' price for extrainfo/idex
                Return p4
            Case 3 ''price for pair side stones
                Return p2
            Case 4 '' return semi metal
                Return p3
        End Select

    End Function
End Class
