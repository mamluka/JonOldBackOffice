Imports System.Web.UI.WebControls
Imports System.Text.RegularExpressions
Public Class cls_jewerly_extra
    Inherits iFoundation.cls_error
    ''the stone price/stone chane vars
    Public _stone_price As String
    Public _stone_center As String
    Public _stone_side As String = "None"
    Public _metal_type As String
    Public _metal_price As String

    Public c_desc As String = ""
    Public c_type As String = "-"
    Public c_cut As String = "-"

    Public s_desc As String = ""
    Public s_type As String = "-"
    Public s_cut As String = "-"


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
            ''check if maybe solitare
            thelistbox.Items.Add(tmpitemadd)
            ''secure not to make endless loop
            If i = 1000 Then Exit Do

        Loop


    End Function
    Public Function get_stone_fromstr(ByVal str As String) As Boolean
        Dim ostringfunc As New iFunctions.cls_string

        str = ostringfunc.ClearHTMLTags(str)
        Dim tmpmidpos As Int16 = InStr(str, " - ", CompareMethod.Text) - 1
        If Mid(str, 1, 1) = "C" Then
            Me._stone_center = Mid(str, 15, tmpmidpos - 14)
            Me._stone_side = ""
        Else
            tmpmidpos = InStr(str, " - ", CompareMethod.Text) - 1
            Me._stone_side = Mid(str, 14, tmpmidpos - 13)
            Me._stone_center = ""
        End If
        str = Mid(str, tmpmidpos + 4, str.Length)
        If InStr(str, " - ") > 0 Then
            tmpmidpos = InStr(str, " - ", CompareMethod.Text) - 1
            Me._stone_side = Mid(str, 14, tmpmidpos - 13)
            Me._stone_price = Mid(str, tmpmidpos + 4, str.Length)
            Me._stone_price = Me._stone_price.Remove(Me._stone_price.Length - 1, 1)
        Else
            Me._stone_price = str
            Me._stone_price = Me._stone_price.Remove(Me._stone_price.Length - 1, 1)
        End If
    End Function
    Public Function get_metal_fromstr(ByVal str As String) As Boolean
        ''Dim tmpmidpos As Int16 = InStr(str, " - ", CompareMethod.Text) - 1
        Me._metal_type = str
        ''Me._metal_price = Mid(Mid(str, tmpmidpos + 4, 12), 1, Mid(str, tmpmidpos + 4, 12).Length - 1)
    End Function
    '' this func is for making the save string sep '|'
    Public Function set_stone_extended_string(ByVal c_desc As String, ByVal c_type As String, ByVal c_cut As String, ByVal s_desc As String, ByVal s_type As String, ByVal s_cut As String) As String
        ''make the str
        Return c_desc + "|" + c_type + "|" + c_cut + "|" + s_desc + "|" + s_type + "|" + s_cut + "|"
    End Function

    ''this func reads the stone_ext proparties
    Public Function get_stone_extended_string(ByVal sES As String)
        Dim i As Int16 = 1
        Dim tmpStr As String = sES
        Dim tmpitemadd As String = ""
        If sES = "None" Then Exit Function


        Do Until tmpStr.Length = 0

            tmpitemadd = Mid(tmpStr, 1, tmpStr.IndexOf("|"))
            tmpStr = Mid(tmpStr, tmpStr.IndexOf("|") + 2, tmpStr.Length)
            Select Case i
                Case 1
                    If tmpitemadd = "None" Then
                        c_desc = ""
                    Else
                        c_desc = tmpitemadd
                    End If
                Case 2
                    c_type = tmpitemadd
                Case 3
                    c_cut = tmpitemadd
                Case 4
                    If tmpitemadd = "None" Then
                        s_desc = ""
                    Else
                        s_desc = tmpitemadd
                    End If
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
        Dim oRate As New ion_two.cls_rate
        Return weight * oRate.get_metal_rate(type)
    End Function
    Public Function get_extrainfo_type(ByVal str As String) As String
        Return Mid(str, 1, 3)
    End Function
    Public Function get_savestr_params(ByVal str As String, ByVal type As Int32)
        Dim i As Int16 = 1
        Dim tmpStr As String = str
        Dim tmpitemadd As String = ""
        Dim p1, p2, p3, p4, p5, p6 As String
        If str = "None" Then Exit Function
        Do Until tmpStr.Length = 0

            tmpitemadd = Mid(tmpStr, 1, tmpStr.IndexOf("|"))
            tmpStr = Mid(tmpStr, tmpStr.IndexOf("|") + 2, tmpStr.Length)
            Select Case i
                Case 1
                    p1 = tmpitemadd
                Case 2
                    p2 = tmpitemadd
                Case 3
                    p3 = tmpitemadd
                Case 4
                    p4 = tmpitemadd
                Case 5
                    p5 = tmpitemadd
                Case 6
                    p6 = tmpitemadd
            End Select
            ''secure not to make endless loop
            i = i + 1
            If i = 7 Then Exit Do

        Loop
        Select Case type
            Case 1
                If p1 = "IDX" Then
                    Return "This is IDEX item: " + p2
                ElseIf p1 = "EXT" Then
                    Return "Metal: " + p2 + "<br>" + p3
                ElseIf p1 = "MDP" Then
                    Return "This is a Side Stone Order<br>Cut:" + p3 + "<br>Qaulity:" + p4 + "<br>Size:" + p5 + "<br>Proportions:" + p6
                End If
            Case 2 '' price for extrainfo/idex
                Return p4
            Case 3 ''price for pair side stones
                Return p2
        End Select

    End Function
    Public Function set_metal_weight(ByVal weight As Decimal, ByVal newmetal As String, ByVal origmetal As String) As String
        ''weight here represents the original weight
        Dim newindex As String = Mid(newmetal, 1, 1)
        Dim origindex As String = Mid(origmetal, 1, 1)
        Select Case origindex
            Case "P"
                If ((newindex = "Y") Or (newindex = "W")) Then
                    Return Convert.ToString(Math.Round((weight / 1.7), 2)) + " Gr."
                End If
            Case "Y"
                If newindex = "P" Then
                    Return Convert.ToString(Math.Round((weight * 1.7), 2)) + " Gr."
                End If
            Case "W"
                If newindex = "P" Then
                    Return Convert.ToString(Math.Round((weight * 1.7), 2)) + " Gr."
                End If
        End Select
        Return Convert.ToString(Math.Round(weight, 2)) + " Gr."


    End Function
    Function EncodeExtraStoneString(ByVal extra_list As Web.UI.WebControls.ListBox) As String

        Dim tmpArray As New ArrayList

        For Each item As Web.UI.WebControls.ListItem In extra_list.Items

            tmpArray.Add(item.Text + "|" + item.Value)
        Next

        Return Join(tmpArray.ToArray, "[")


    End Function


    Overloads Function DecodeExtraStoneString(ByVal codestr As String, ByRef listbox As System.Web.UI.WebControls.ListBox) As Boolean
        listbox.Items.Clear()
        ''   Dim tmpListbox As New System.Web.UI.WebControls.ListBox
        If codestr.IndexOf("|") = -1 Then
            Return False
        End If

        Dim single_items() As String = codestr.Split("[")

        Dim i As Int32

        For i = 0 To single_items.Length - 1

            Dim text_val() As String = Split(single_items(i), "|")

            listbox.Items.Add(New System.Web.UI.WebControls.ListItem(text_val(0), text_val(1)))


        Next




    End Function

    Overloads Function DecodeExtraStoneString(ByVal codestr As String, ByRef listbox As System.Web.UI.WebControls.DropDownList) As Boolean
        listbox.Items.Clear()
        ''   Dim tmpListbox As New System.Web.UI.WebControls.ListBox
        If codestr.IndexOf("|") = -1 Then
            Return False
        End If

        Dim single_items() As String = codestr.Split("[")

        Dim i As Int32
        For i = 0 To single_items.Length - 1

            Dim text_val() As String = Split(single_items(i), "|")
            ''kill price info
            text_val(0) = Regex.Replace(text_val(0), "\s-\s\d*\$", String.Empty)
            text_val(0) = Regex.Replace(text_val(0), "\^.*?\^", String.Empty)
            listbox.Items.Add(New System.Web.UI.WebControls.ListItem(text_val(0), text_val(1)))


        Next




    End Function

    Overloads Function DecodeExtraStoneString(ByVal codestr As String, ByRef list As ArrayList) As Boolean
        ''  ListBo
        ''   Dim tmpListbox As New System.Web.UI.WebControls.ListBox
        If codestr.IndexOf("|") = -1 Then
            Return False
        End If

        Dim single_items() As String = codestr.Split("[")

        Dim i As Int32

        For i = 0 To single_items.Length - 1

            Dim text_val() As String = Split(single_items(i), "|")
            text_val(0) = Regex.Replace(text_val(0), "\s-\s\d*\$", String.Empty)
            text_val(0) = Regex.Replace(text_val(0), "\^.*?\^", String.Empty)
            Dim hash As New Hashtable
            hash.Add(text_val(0), text_val(1))

            list.Add(hash)


        Next




    End Function

    Public Function EncodeMetalDelta(ByVal delta As String) As String

        Return "system|delta::" + delta

    End Function

    Public Function DecodeMetalDelta(ByVal delta As String) As Decimal
        If delta.IndexOf("::") > -1 Then
            Return Convert.ToDecimal(Split(delta, "::")(1))
        Else
            Return "0"
        End If
    End Function


End Class

