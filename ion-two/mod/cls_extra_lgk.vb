Imports System.Web.UI.WebControls
Imports System.Text.RegularExpressions
Public Class cls_extra_lgk
    Public Function DecodeExtraStoneKeys(ByVal key As String) As Hashtable
        Dim hash As New Hashtable
        Dim keys() As String = Split(key, "^")
        For Each item As String In keys
            hash.Add(Split(item, "::")(0), Split(item, "::")(1))
        Next

        Return hash
    End Function

    Public Function ReEncodePriceKeyByMetal(ByVal delta As Decimal, ByRef dropdown As System.Web.UI.WebControls.DropDownList) As Boolean

        If delta <> 0 Then
            Dim i As Int32
            Dim till As Int32 = dropdown.Items.Count - 1
            While till > 0
                Dim tmpitem As New Web.UI.WebControls.ListItem

                Dim m As Match = Regex.Match(dropdown.Items(1).Value, "\^price::\d+")
                '' Dim m2 As Match = Regex.Match(dropdown.Items(0).Text, )
                Dim delta_str As String = "^price::" + Convert.ToString(Convert.ToDecimal(Split(m.Value, "::")(1)) + delta)
                tmpitem.Text = Regex.Replace(dropdown.Items(1).Text, "\s\d+\$", " " + Convert.ToString(Convert.ToDecimal(Split(m.Value, "::")(1)) + delta) + "$")
                tmpitem.Value = Regex.Replace(dropdown.Items(1).Value, "\^price::\d+", delta_str)
                dropdown.Items.RemoveAt(1)
                dropdown.Items.Add(tmpitem)
                till -= 1

            End While
        End If

    End Function


End Class
Public Class cls_extra_saveatom
    Public desc As String
    Public price As Decimal
End Class

