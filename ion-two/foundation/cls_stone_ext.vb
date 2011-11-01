Public Class cls_stone_ext
    Public ext_info As New Collection
    Public ext_currentid As Integer
    Public Class extra_info_item
        Public ext_cur_stone_price As Int32 = 0
        Public ext_cur_metal_price As Int32 = 0
        Public ext_cur_metal_type As String
        Public ext_cur_stone_desc As String
        Public ext_metal_type_original As String
        Public is_changed As Boolean = False
        Public id As String = ""
        Public extra_metal_list_index As Int16 = 0
        Public extra_stone_list_index As Int16 = 0
        Public ext_new_price As Int32 '' not string cuz formatting occurs not here
        Public ext_savestr As String = ""
    End Class
    Public Function get_indexfrom_id(ByVal id As String) As Integer
        Dim i
        ''gets the id inside the collection using the real item id number
        If ext_info.Count <> 0 Then
            For i = 1 To ext_info.Count
                If ext_info.Item(i).id = id Then
                    Return i
                    Exit Function
                End If
            Next

            Return 0
        Else
            Return 0
        End If
    End Function
    ''uses so all oporation of the vars will use same id
    Public Function set_currentitemid(ByVal id As String)
        If get_indexfrom_id(id) > 0 Then
            Me.ext_currentid = get_indexfrom_id(id)
        Else
            Dim tmpadd As New extra_info_item
            tmpadd.id = id
            ext_info.Add(tmpadd)
            Me.ext_currentid = ext_info.Count
        End If

    End Function
    Public Function set_current_extra(ByVal stone As Int32, ByVal metal As String) As Boolean
        ext_info.Item(Me.ext_currentid).ext_cur_stone_price = stone '' set stone price
        ext_info.Item(Me.ext_currentid).ext_metal_type_original = metal '' set current metal string
    End Function
    Public Function release_currentid()
        Me.ext_currentid = 0
    End Function
    Public Function get_extra_cur_stone() As Int32
        Return ext_info.Item(Me.ext_currentid).ext_cur_stone_price
    End Function
    Public Function get_extra_cur_metal() As String
        Return ext_info.Item(Me.ext_currentid).ext_metal_type_original
    End Function

    Public Function set_extra_cur_stone(ByVal val As Int32) As Boolean
        ext_info.Item(Me.ext_currentid).ext_cur_stone_price = val
    End Function
    Public Function set_extra_cur_metal(ByVal val As Int32) As Boolean
        ext_info.Item(Me.ext_currentid).ext_cur_metal_price = val
    End Function
    ''to check if a item is changed with engine
    Public Function is_extra_info(ByVal id As String) As Boolean
        If Me.get_indexfrom_id(id) > 0 Then
            Me.ext_currentid = Me.get_indexfrom_id(id)
            If Not ext_info.Item(Me.ext_currentid).is_changed Then Return False
            Return True
        Else
            Return False
        End If
    End Function
    Public Function set_stone_desc(ByVal centerstone As String, ByVal stonetype As String, ByVal sidetype As String, ByVal sidestone As String, ByVal metaltype As String) As Boolean
        If (centerstone <> "") And (sidestone <> "") Then
            ext_info.Item(Me.ext_currentid).ext_cur_stone_desc = stonetype + ": " + centerstone + " - Side Stones: " + sidetype + ", " + sidestone
        ElseIf (centerstone <> "") And (sidestone = "") Then
            ext_info.Item(Me.ext_currentid).ext_cur_stone_desc = stonetype + ": " + centerstone
        ElseIf (centerstone = "") And (sidestone <> "") Then
            ext_info.Item(Me.ext_currentid).ext_cur_stone_desc = "Side Stones: " + sidetype + ", " + sidestone
        End If


        ext_info.Item(Me.ext_currentid).ext_cur_metal_type = metaltype
    End Function
    Public Function set_extra_price(ByVal price As Int32) As Boolean
        ext_info.Item(Me.ext_currentid).ext_new_price = price
    End Function
    Public Function get_extra_price() As Int32
        Return ext_info.Item(Me.ext_currentid).ext_new_price
    End Function
    ''must ran after desc builder format type|stone desc|price
    Public Function set_ext_savestr() As Boolean
        With Me.ext_info.Item(Me.ext_currentid)
            .ext_savestr = "EXT|" + .ext_cur_metal_type + "|" + .ext_cur_stone_desc + "|" + Convert.ToString(.ext_new_price) + "|"
        End With


    End Function
    Public Function get_ext_savestr() As String
        Return Me.ext_info.Item(Me.ext_currentid).ext_savestr
    End Function
    ''get stone desc from collection
    Public Function get_stone_desc() As String
        Return ext_info.Item(Me.ext_currentid).ext_cur_stone_desc

    End Function

    ''gets the desc var from collection
    Public Function get_metal_type()
        Return ext_info.Item(Me.ext_currentid).ext_cur_metal_type
    End Function
    Public Function set_metal_origtype(ByVal str As String)
        ext_info.Item(Me.ext_currentid).ext_metal_type_original = str
    End Function
    Public Function get_metal_origtype() As String
        Return ext_info.Item(Me.ext_currentid).ext_metal_type_original
    End Function

    Public Function set_metal_type(ByVal metal As String) As Boolean
        ext_info.Item(Me.ext_currentid).ext_cur_metal_type = metal
    End Function
    Public Function ext_savecmb(ByVal metal_index As Integer, ByVal stone_index As Integer)
        ext_info.Item(Me.ext_currentid).extra_metal_list_index = metal_index
        ext_info.Item(Me.ext_currentid).extra_stone_list_index = stone_index
    End Function
    Public Function ext_loadcmb(ByRef metal_index As Integer, ByRef stone_index As Integer)
        metal_index = ext_info.Item(Me.ext_currentid).extra_metal_list_index
        stone_index = ext_info.Item(Me.ext_currentid).extra_stone_list_index
    End Function
    Public Function ext_markaschanged()
        ext_info.Item(Me.ext_currentid).is_changed = True
    End Function
    Public Function ext_unmarkaschanged()
        ext_info.Item(Me.ext_currentid).is_changed = False
    End Function
    Public Function get_extra_metal_price(ByVal newmetal As String, ByVal newop As Boolean) As Int32
        ''Dim origindex As String = Mid(ext_info.Item(Me.ext_currentid).ext_metal_type_original, 1, 1)
        Dim newindex As String = Mid(newmetal, 1, 1)
        Dim price As Int32 = ext_info.Item(Me.ext_currentid).ext_cur_stone_price
        ''If newindex = origindex Then Return 0 '' if same metal gold to gold or platine to platina
        If newop Then '' if we add to the celected stone meaning it's a new op not changing price for the original prices
            Select Case newindex
                Case "P"
                    Return Convert.ToInt32(price * 0.1)
                Case "Y"
                    Return Convert.ToInt32(price * (0.0464))
                Case "W"
                    Return Convert.ToInt32(price * (0.0464))
            End Select
        Else
            Select Case newindex
                Case "P"
                    Return Convert.ToInt32(price * 0.1)
                Case "Y"
                    Return Convert.ToInt32(price * (-0.1))
                Case "W"
                    Return Convert.ToInt32(price * (-0.1))
            End Select
        End If

    End Function


End Class
