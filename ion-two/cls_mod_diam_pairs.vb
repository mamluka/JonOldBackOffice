Public Class cls_mod_diam_pairs
    Inherits iFoundation.cls_error
    Public Function create_description(ByVal shapeid As Int16, ByVal weight As String, ByVal size As String, ByVal quality As String, ByRef rtxt As String, Optional ByVal prop_value As String = "")
        On Error GoTo ErrorHandler
        Dim bError As Boolean = False

        Dim osize As New ion_two.cls_diam_size
        Dim oshape As New ion_two.cls_shape

        Dim tmpShape As String
        Dim tmpSize As String


        osize.getsize_fromstr(size, tmpSize)
        oshape.getshape_byid(shapeid, tmpShape)

        If prop_value <> "" Then
            rtxt = "Pair of " + tmpShape + " Diamonds - " + weight + " " + tmpSize + ", " + quality + ", " + prop_value + " proportions"
        Else

            rtxt = "Pair of " + tmpShape + " Diamonds - " + weight + " " + tmpSize + ", " + quality
        End If

        Return False

ErrorHandler:
        Me._err_number = Err.Number
        Me._err_description = Err.Description
        Me._err_source = Err.Source
        Return True
    End Function

    Public Function create_extrainfostr(ByVal shapeid As Int16, ByVal price As Decimal, ByVal size As String, ByVal weight As String, ByVal quality As String, ByRef rExtraInfo As String, Optional ByVal prop As String = "None")
        On Error GoTo ErrorHandler
        Dim bError As Boolean = False

        Dim osize As New ion_two.cls_diam_size
        Dim oshape As New ion_two.cls_shape

        Dim tmpShape As String
        Dim tmpSize As String


        '' osize.getsize_fromstr(size, tmpSize)
        oshape.getshape_byid(shapeid, tmpShape)

        'mdp - moded diamond pair
        rExtraInfo = "MDP|" + Convert.ToString(price) + "|" + tmpShape + "|" + quality + "|" + size + "|" + weight + "|"
        Return False

ErrorHandler:
        Me._err_number = Err.Number
        Me._err_description = Err.Description
        Me._err_source = Err.Source
        Return True
    End Function

    Public Function create_hyplink(ByVal price As Decimal, ByVal description As String, ByVal extrainfo As String, ByRef rLink As String)
        On Error GoTo ErrorHandler
        Dim bError As Boolean = False
        'mdp - moded diamond pair
        rLink = "&qty=1&modid=1&mprice=" + Convert.ToString(price) + "&mdesc=" + description + "&mextrainfo=" + extrainfo
        Return False

ErrorHandler:
        Me._err_number = Err.Number
        Me._err_description = Err.Description
        Me._err_source = Err.Source
        Return True
    End Function

End Class

