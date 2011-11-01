Public Class cls_shape
    ''Public shapeid 	
    Inherits iFoundation.cls_error_connection
    Public Function getshape_byid(ByVal id As Int32, ByRef rShape As String) As Boolean
        On Error GoTo ErrorHandler
        Dim bError As Boolean = False

        Select Case id
            Case 1
                rShape = "Half Moon Cut"
            Case 2
                rShape = "Trapezoid Cut"
            Case 3
                rShape = "Taper Cut"
            Case 4
                rShape = "Trillian Cut"
            Case 5
                rShape = "Princess Cut"
            Case 6
                rShape = "Radiant Cut"
            Case 7
                rShape = "Emerald Cut"
            Case 8
                rShape = "Asscher Cut"
            Case 9
                rShape = "Pear Cut"
            Case 10
                rShape = "Marquise Cut"
            Case 11
                rShape = "Oval Cut"
            Case 12
                rShape = "Cushion Cut"
            Case 13
                rShape = "Round Cut"
            Case 14
                rShape = "Shield Cut"
            Case 15
                rShape = "Heart Cut"
            Case 16
                rShape = "Baguette Cut"
        End Select


        Return False


ErrorHandler:
        Me._err_number = Err.Number
        Me._err_description = Err.Description
        Me._err_source = Err.Source
        Return True
    End Function
    ''get the standart stock item id for oplate
    Public Function getitem_byshape(ByVal id As Int32, ByRef rShapeItemId As Int32) As Boolean
        On Error GoTo ErrorHandler
        Dim bError As Boolean = False

        Select Case id

            Case 1
                rShapeItemId = 5780
            Case 2
                rShapeItemId = 5779
            Case 3
                rShapeItemId = 5781
            Case 4
                rShapeItemId = 5798
            Case 5
                rShapeItemId = 5795
            Case 6
                rShapeItemId = 5799
            Case 7
                rShapeItemId = 5794
            Case 8
                rShapeItemId = 5800
            Case 9
                rShapeItemId = 5783
            Case 10
                rShapeItemId = 5802
            Case 11
                rShapeItemId = 5784
                ''Case 12
                ''  rShapeItemId = "Cushion Cut"
            Case 13
                rShapeItemId = 5796
                ''Case 14
                ''  rShapeItemId = "Shield Cut"
            Case 15
                rShapeItemId = 5782
            Case 16
                rShapeItemId = 5797
        End Select



        Return False

ErrorHandler:
        Me._err_number = Err.Number
        Me._err_description = Err.Description
        Me._err_source = Err.Source
        Return True
    End Function
    Public Function translate_shapes(ByVal NewShape As String, ByRef rSiteShape As String) As Boolean
        On Error GoTo ErrorHandler
        Dim bError As Boolean = False
        Select Case NewShape

            Case "Heart Cut"
                rSiteShape = "Heart Shape"
            Case "Half Moon Cut"
                rSiteShape = "Half Moon Shape"
            Case Else
                rSiteShape = NewShape
        End Select


        Return False

ErrorHandler:
        Me._err_number = Err.Number
        Me._err_description = Err.Description
        Me._err_source = Err.Source
        Return True
    End Function

    Public Function is_one_measure(ByVal shapeid As Int32, ByRef rIsRound As Boolean) As Boolean
        On Error GoTo ErrorHandler
        Dim bError As Boolean = False

        Select Case shapeid
            Case 13
                rIsRound = True
            Case Else
                rIsRound = False
        End Select


        Return False

ErrorHandler:
        Me._err_number = Err.Number
        Me._err_description = Err.Description
        Me._err_source = Err.Source
        Return True
    End Function

    Public Function is_square(ByVal sizeAtom As ion_two.cls_size_atom, ByRef rIsSquare As Boolean) As Boolean
        On Error GoTo ErrorHandler
        Dim bError As Boolean = False


        If (sizeAtom.length / sizeAtom.width <= 1.15) And (sizeAtom.length / sizeAtom.width >= 0.85) Then
            rIsSquare = True
        Else
            rIsSquare = False
        End If

        Return False

ErrorHandler:
        Me._err_number = Err.Number
        Me._err_description = Err.Description
        Me._err_source = Err.Source
        Return True
    End Function
    ''translates the shape id from javascript icons to string shape for easy search and output
    Public Function Cj_shape_byid(ByVal shapeid_list As ArrayList, ByRef rShape_list As ArrayList) As Boolean
        On Error GoTo ErrorHandler
        Dim bError As Boolean = False

        Dim i As Int32


        For i = 0 To shapeid_list.Count - 1
            Select Case shapeid_list.Item(i)
                Case 1
                    rShape_list.Item(i) = "Any Shape"
                Case 2
                    rShape_list.Item(i) = "Oval Cut"
                Case 3
                    rShape_list.Item(i) = "Emerald Cut"
                Case 4
                    rShape_list.Item(i) = "Cushion Cut"
                Case 5
                    rShape_list.Item(i) = "Round Cut"
                Case 6
                    rShape_list.Item(i) = "Pear Cut"
                Case 7
                    rShape_list.Item(i) = "Marquise Cut"
                Case 8
                    rShape_list.Item(i) = "Heart Shape Cut"
                Case 9
                    rShape_list.Item(i) = "Radiant Cut"

            End Select
        Next

        Return False

ErrorHandler:
        Me._err_number = Err.Number
        Me._err_description = Err.Description
        Me._err_source = Err.Source
        Return True
    End Function


    Function GetViewerShapeIdByQS(ByVal word As String) As Int32
        Select Case word
            Case ""
        End Select


    End Function

End Class
