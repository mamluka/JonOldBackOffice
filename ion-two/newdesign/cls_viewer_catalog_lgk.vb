Imports System.Reflection
Imports System.Text.RegularExpressions

Imports System.Xml
Public Class cls_viewer_catalog_lgk
    Public desc_xml As String
    Public conn_string As String
    Public db_type As Int32
    Public Function CreateDescription(ByVal oplate As ion_two.skl_lst_inventory, ByRef desc As String)

        ''check for exeptios
        Dim odesc As New ion_two.cls_modular_description

        Me.GetDescriptionType(oplate, odesc.desc_type)


        odesc.conn_string = Me.conn_string
        odesc.db_type = Me.db_type

        odesc.xml_file = Me.desc_xml
        odesc.CreateDescription(oplate)

        desc = odesc.desc_multiline





    End Function
    Public Function GetDescriptionType(ByVal oplate As ion_two.skl_lst_inventory, ByRef desc_type As String)
        Select Case oplate._platetype
            Case 3
                If oplate._subplate.se_relateditem_id > 0 Then
                    desc_type = "stoneexchange"
                    Return 0
                End If
                If oplate._subplate.jewel_title <> "" Then
                    desc_type = "readytitle"
                    Return 0
                End If
        End Select

        desc_type = "viewer"

    End Function

    Public Class FilterOrderSort
        Implements IComparer

        ' Calls CaseInsensitiveComparer.Compare with the parameters reversed.
        Public Function Compare(ByVal x As Object, ByVal y As Object) As Integer Implements IComparer.Compare

            If Convert.ToInt32(x.Attributes("order").InnerText) = Convert.ToInt32(y.Attributes("order").InnerText) Then
                Return 0
            ElseIf Convert.ToInt32(x.Attributes("order").InnerText) > Convert.ToInt32(y.Attributes("order").InnerText) Then
                Return 1
            Else
                Return -1
            End If


        End Function 'IComparer.Compare

    End Class 'myReverserClass

End Class
