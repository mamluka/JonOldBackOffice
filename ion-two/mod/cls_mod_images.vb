Public Class cls_mod_images
    Inherits iFoundation.cls_error_connection
    Public conn_string As String '' the conn string
    ''images vars
    Public icon_pic
    Public banner_pic
    Public extended_pic
    Public icom_pic_bare
    Public banner_pic_bare
    Public exteded_pic_bare


    Function load_images(ByVal id As Int32) As Boolean
        Dim oDG_search As New iDac.cls_sql_read
        Dim sSql As String = "select * from inv_inventory where id=" + Convert.ToString(id)
     
        oDG_search._connection_string = Me.conn_string
        oDG_search._tablename = "inv_inventory"


        oDG_search.transact_read(sSql)

        Dim oData As DataTable = oDG_search._datatable

        Dim item_number As String

        item_number = oData.Rows(0).Item("itemnumber")


        Dim oTmpCategories As New ion_two.cls_categories
        oTmpCategories.get_category(oData.Rows(0).Item("category_id"))

        Me.icon_pic = oTmpCategories._relative_path + item_number + "_icn.jpg"
        Me.banner_pic = oTmpCategories._relative_path + item_number + "_pic.jpg"
        Me.extended_pic = oTmpCategories._relative_path + item_number + "_pih.jpg"

        Me.icom_pic_bare = item_number + "_icn.jpg"
        Me.banner_pic_bare = item_number + "_pic.jpg"
        Me.exteded_pic_bare=item_number + "_pih.jpg"
    End Function
    Public Function get_ss_image_byid(ByVal id As Int32, ByVal range As Decimal, ByRef outID As Int32) As Boolean

        If range <= 0.9 Then
            range = 1
        ElseIf (range > 0.9) And (range <= 1.5) Then
            range = 2
        Else
            range = 3
        End If

        Select Case id
            Case 5780 '' half moon
                If range = 2 Then
                    outID = 5803
                ElseIf range = 1 Then
                    outID = 5818
                Else
                    outID = id
                End If

            Case 5779 '' trap
                If range = 2 Then
                    outID = 5804
                ElseIf range = 1 Then
                    outID = 5819
                Else
                    outID = id
                End If

            Case 5781 '' taper
                If range = 2 Then
                    outID = 5805
                ElseIf range = 1 Then
                    outID = 5820
                Else
                    outID = id
                End If

            Case 5789 '' trrilain
                If range = 2 Then
                    outID = 5813
                ElseIf range = 1 Then
                    outID = 5829
                Else
                    outID = id
                End If

            Case 5795 '' princess
                If range = 2 Then
                    outID = 5810
                ElseIf range = 1 Then
                    outID = 5825
                Else
                    outID = id
                End If

            Case 5799 '' radian
                If range = 2 Then
                    outID = 5814
                ElseIf range = 1 Then
                    outID = 5830
                Else
                    outID = id
                End If

            Case 5794 '' emerald
                If range = 2 Then
                    outID = 5809
                ElseIf range = 1 Then
                    outID = 5824
                Else
                    outID = id
                End If

            Case 5800 '' asscher
                If range = 2 Then
                    outID = 5815
                ElseIf range = 1 Then
                    outID = 5831
                Else
                    outID = id
                End If

            Case 5783 '' pear
                If range = 2 Then
                    outID = 5807
                ElseIf range = 1 Then
                    outID = 5822
                Else
                    outID = id
                End If

            Case 5802 '' marquise
                If range = 2 Then
                    outID = 5817
                ElseIf range = 1 Then
                    outID = 5833
                Else
                    outID = id
                End If

            Case 5784 '' oval
                If range = 2 Then
                    outID = 5808
                ElseIf range = 1 Then
                    outID = 5823
                Else
                    outID = id
                End If

            Case 5796 ''round
                If range = 2 Then
                    outID = 5811
                ElseIf range = 1 Then
                    outID = 5827
                Else
                    outID = id
                End If

            Case 5801 '' shield
                If range = 2 Then
                    outID = 5816
                ElseIf range = 1 Then
                    outID = 5832
                Else
                    outID = id
                End If

            Case 5782 ''heart
                If range = 2 Then
                    outID = 5806
                ElseIf range = 1 Then
                    outID = 5821
                Else
                    outID = id
                End If

            Case 5797 '' baguette
                If range = 2 Then
                    outID = 5812
                ElseIf range = 1 Then
                    outID = 5828
                Else
                    outID = id
                End If
        End Select
    End Function

End Class
