Imports System.Text.RegularExpressions
Public Class cls_jewelry_lgc
    Inherits iFoundation.cls_logics_sub

    Sub New()
        '--- Set working table
        Me._tablename = "inv_JEWELRY"

        '--- Get module name
        Dim oTmpStack As New System.Diagnostics.StackFrame
        Me._module = oTmpStack.GetMethod.ReflectedType.FullName()
        oTmpStack = Nothing

    End Sub

    Function insert(ByRef oDataTable As skl_jewelry) As Boolean
        On Error GoTo ErrorHandler

        '--- local definitions
        Dim bError As Boolean = False

        '--- Get Dataset
        Dim oTmpDataset As DataSet = New ion_two.ds_jewelry
        Dim oTmpDataTable As DataTable = oTmpDataset.Tables(_tablename)

        '--- Assign Order
        Dim oTmpDataRow As DataRow
        oTmpDataRow = oTmpDataTable.NewRow

        'oTmpDataRow("id") = oDataTable._id
        oTmpDataRow("INVENTORY_ID") = oDataTable._inventory_id
        oTmpDataRow("ITEM_SIZE") = oDataTable._size
        oTmpDataRow("WEIGHT") = oDataTable._weight
        oTmpDataRow("JEWELTYPE_ID") = oDataTable._jewelrytype_id
        oTmpDataRow("JEWELSUBTYPE_ID") = oDataTable._jewelrysubtype_id
        oTmpDataRow("METAL_ID") = oDataTable._metal_id
        oTmpDataRow("MIDDLESTONE_ID") = oDataTable._middlestone_id
        oTmpDataRow("BRAND_ID") = oDataTable._brand_id
        oTmpDataRow("REPORT_ID") = oDataTable._report_id
        oTmpDataRow("SETTING_ID") = oDataTable._setting_id
        oTmpDataRow("COLLECTION_ID") = oDataTable._collection_id
        oTmpDataRow("RELATEDITEM_ID") = oDataTable._relateditem_id
        oTmpDataRow("MIDDLESTONE_DESC") = oDataTable._middlestone_desc
        oTmpDataRow("ANNIVERSARY") = oDataTable._anniversary
        oTmpDataRow("ENGAGEMENT") = oDataTable._engagement
        oTmpDataRow("extra_metal") = oDataTable._extra_metal
        oTmpDataRow("extra_stone") = oDataTable._extra_stone
        oTmpDataRow("stone_extended") = oDataTable._stone_extended
        oTmpDataRow("se_relateditem_id") = oDataTable.se_relateditem_id
        oTmpDataRow("jewel_title") = oDataTable.jewel_title
        oTmpDataRow("jewel_extended") = oDataTable.jewel_extended
        ''  oTmpDataRow("jewel_extended_id") = oDataTable.jewel_extended
        oTmpDataTable.Rows.Add(oTmpDataRow)

        '--- Assign datatable
        Me._datatable = oTmpDataTable


        Return False
        Exit Function

ErrorHandler:
        Me._err_number = Err.Number
        Me._err_description = Err.Description
        Me._err_source = Err.Source
        Return True
    End Function

    Function read(ByVal nId As Int32, ByRef oDataTable As skl_jewelry) As Boolean
        On Error GoTo ErrorHandler

        '--- local definitions
        Dim bError As Boolean = False

        '--- Get Item
        Dim oReadTransactor As New iDac.cls_T_read
        oReadTransactor._connection_string = Me._connection_string
        oReadTransactor._dbtype = Me._dbtype
        oReadTransactor._tablename = Me._tablename
        oReadTransactor._searchfield = "INVENTORY_ID"
        bError = oReadTransactor.transact_read(nId)
        If bError Then
            Me._err_number = oReadTransactor._err_number
            Me._err_description = oReadTransactor._err_description
            Me._err_source = oReadTransactor._err_source
            Return True
        End If

        '--- Return Error if no records were fatched
        If oReadTransactor._datatable.Rows.Count = 0 Then
            Err.Raise(7003, Me._module + ":read", "No records fetched.")
        End If

        '--- Map to Skeleton
        Dim oTmpDataRow As DataRow
        oTmpDataRow = oReadTransactor._datatable.Rows(0)

        oDataTable._id = oTmpDataRow("id")
        oDataTable._inventory_id = oTmpDataRow("INVENTORY_ID")
        oDataTable._size = oTmpDataRow("ITEM_SIZE")
        oDataTable._weight = oTmpDataRow("WEIGHT")
        oDataTable._jewelrytype_id = oTmpDataRow("JEWELTYPE_ID")
        oDataTable._jewelrysubtype_id = oTmpDataRow("JEWELSUBTYPE_ID")
        oDataTable._metal_id = oTmpDataRow("METAL_ID")
        oDataTable._middlestone_id = oTmpDataRow("MIDDLESTONE_ID")
        oDataTable._brand_id = oTmpDataRow("BRAND_ID")
        oDataTable._report_id = oTmpDataRow("REPORT_ID")
        oDataTable._setting_id = oTmpDataRow("SETTING_ID")
        oDataTable._collection_id = oTmpDataRow("COLLECTION_ID")
        oDataTable._relateditem_id = oTmpDataRow("RELATEDITEM_ID")
        oDataTable._middlestone_desc = oTmpDataRow("MIDDLESTONE_DESC")
        oDataTable._anniversary = oTmpDataRow("ANNIVERSARY")
        oDataTable._engagement = oTmpDataRow("ENGAGEMENT")
        oDataTable.jewel_title = oTmpDataRow("jewel_title")
        If Not Convert.IsDBNull(oTmpDataRow("extra_metal")) Then
            oDataTable._extra_metal = oTmpDataRow("extra_metal")
        End If
        If Not Convert.IsDBNull(oTmpDataRow("se_relateditem_id")) Then
            oDataTable.se_relateditem_id = oTmpDataRow("se_relateditem_id")
        End If
        If Not Convert.IsDBNull(oTmpDataRow("extra_stone")) Then
            oDataTable._extra_stone = oTmpDataRow("extra_stone")
        End If
        If Not Convert.IsDBNull(oTmpDataRow.Item("stone_extended")) Then
            oDataTable._stone_extended = oTmpDataRow.Item("stone_extended")
        End If
        If Not Convert.IsDBNull(oTmpDataRow.Item("jewel_extended")) Then
            oDataTable.jewel_extended = oTmpDataRow.Item("jewel_extended")

        End If
        '--- cleanup
        oTmpDataRow = Nothing

        Return False
        Exit Function

ErrorHandler:
        Me._err_number = Err.Number
        Me._err_description = Err.Description
        Me._err_source = Err.Source
        Return True
    End Function

    Function update(ByRef oDataTable As skl_jewelry, Optional ByVal replicate As Boolean = False) As Boolean
        On Error GoTo ErrorHandler

        '--- local definitions
        Dim bError As Boolean = False

        '--- CUSTOM ERROR: Return Error if ID not passed in skeleton
        If oDataTable._id <= 0 Then
            Err.Raise(7006, Me._module + ":update", "No ID passed with skeleton.")
        End If

        Dim oTmpTransact As New iDac.cls_T_read
        oTmpTransact._connection_string = Me._connection_string
        oTmpTransact._dbtype = Me._dbtype
        oTmpTransact._tablename = Me._tablename
        bError = oTmpTransact.transact_read(oDataTable._id)
        If bError Then
            Me._err_number = oTmpTransact._err_number
            Me._err_description = oTmpTransact._err_description
            Me._err_source = oTmpTransact._err_source
            Return True
        End If

        '--- Get DataTable
        Dim oTmpDataTable As DataTable = oTmpTransact._datatable

        '--- Assign Order
        Dim oTmpDataRow As DataRow
        oTmpDataRow = oTmpDataTable.Rows(0)

        'oTmpDataRow("INVENTORY_ID") = oDataTable._inventory_id
        oTmpDataRow("ITEM_SIZE") = oDataTable._size
        oTmpDataRow("WEIGHT") = oDataTable._weight
        oTmpDataRow("JEWELTYPE_ID") = oDataTable._jewelrytype_id
        oTmpDataRow("JEWELSUBTYPE_ID") = oDataTable._jewelrysubtype_id
        If Not replicate Then
            oTmpDataRow("METAL_ID") = oDataTable._metal_id
        End If
        oTmpDataRow("MIDDLESTONE_ID") = oDataTable._middlestone_id
        oTmpDataRow("BRAND_ID") = oDataTable._brand_id
        oTmpDataRow("REPORT_ID") = oDataTable._report_id
        oTmpDataRow("SETTING_ID") = oDataTable._setting_id
        oTmpDataRow("COLLECTION_ID") = oDataTable._collection_id
        oTmpDataRow("RELATEDITEM_ID") = oDataTable._relateditem_id
        oTmpDataRow("MIDDLESTONE_DESC") = oDataTable._middlestone_desc
        oTmpDataRow("ANNIVERSARY") = oDataTable._anniversary
        oTmpDataRow("ENGAGEMENT") = oDataTable._engagement
        oTmpDataRow("se_relateditem_id") = oDataTable.se_relateditem_id
        If Not replicate Then
            oTmpDataRow("extra_metal") = oDataTable._extra_metal
            oTmpDataRow("extra_stone") = oDataTable._extra_stone
            oTmpDataRow("stone_extended") = oDataTable._stone_extended

            oTmpDataRow("jewel_title") = oDataTable.jewel_title
            oTmpDataRow("jewel_extended") = oDataTable.jewel_extended
        End If
        '--- Assign datatable
        Me._datatable = oTmpDataTable

        Return False
        Exit Function

ErrorHandler:
        Me._err_number = Err.Number
        Me._err_description = Err.Description
        Me._err_source = Err.Source
        Return True

    End Function

    Function load(ByVal nMode As Int16, ByVal oDataRow As DataRow, ByRef oDataTable As skl_lst_jewelry, Optional ByVal oPictures As ion_two.cls_pictures = Nothing, Optional ByVal bIsdealer As Boolean = False, Optional ByVal bSSL As Boolean = False) As Boolean
        On Error GoTo ErrorHandler
        Dim bError As Boolean = False

        oDataTable._weight = oDataRow.Item("weight")
        oDataTable._report = oDataRow.Item("report")
        oDataTable._brand_sort = oDataRow.Item("brand_sort")
        oDataTable._report_sort = oDataRow.Item("report_sort")


        '--- if we are searching on plate not MIX mode
        If nMode < 10 Then
            oDataTable._size = oDataRow.Item("size")
            oDataTable._middlestone_desc = oDataRow.Item("middlestone_desc")
            oDataTable._relateditem_id = oDataRow.Item("relateditem_id")
            oDataTable._setting = oDataRow.Item("setting")
            oDataTable._collection = oDataRow.Item("collection")
            oDataTable._jewelrytype = oDataRow.Item("jeweltype")
            oDataTable._jewelrysubtype = oDataRow.Item("jewelsubtype")
            oDataTable._metal = oDataRow.Item("metal")
            oDataTable._middlestone = oDataRow.Item("middlestone")
            oDataTable._brand = oDataRow.Item("brand")

            oDataTable._jeweltype_sort = oDataRow.Item("jeweltype_sort")
            oDataTable._metal_sort = oDataRow.Item("metal_sort")
            oDataTable._middlestone_sort = oDataRow.Item("middlestone_sort")
            oDataTable._setting_sort = oDataRow.Item("setting_sort")
            oDataTable._collection_sort = oDataRow.Item("collection_sort")
            oDataTable._middlestone_desc = oDataRow.Item("middlestone_desc")
            oDataTable.jewel_title = oDataRow.Item("jewel_title")
            If ((Not Convert.IsDBNull(oDataRow.Item("extra_metal"))) And (nMode <> 14)) Then
                oDataTable._extra_metal = oDataRow.Item("extra_metal")
            End If
            If ((Not Convert.IsDBNull(oDataRow.Item("extra_stone"))) And (nMode <> 14)) Then
                oDataTable._extra_stone = oDataRow.Item("extra_stone")
            End If
            If Not Convert.IsDBNull(oDataRow.Item("stone_extended")) Then
                oDataTable._stone_extended = oDataRow.Item("stone_extended")
            End If
            If Not Convert.IsDBNull(oDataRow.Item("se_relateditem_id")) Then
                oDataTable.se_relateditem_id = oDataRow.Item("se_relateditem_id")
            End If
            If Not Convert.IsDBNull(oDataRow.Item("jewel_extended")) Then
                oDataTable.jewel_extended = oDataRow.Item("jewel_extended")
                Dim ostringfunc As New iFunctions.cls_string
                oDataTable.jewel_extended_hash = ostringfunc.HashfromString(oDataRow.Item("jewel_extended"), "|", "::")
            End If

        ElseIf nMode = 16 Then
            oDataTable._size = oDataRow.Item("size")
            oDataTable._middlestone_desc = oDataRow.Item("middlestone_desc")
            oDataTable._relateditem_id = oDataRow.Item("relateditem_id")
            oDataTable._setting = oDataRow.Item("setting")
            oDataTable._collection = oDataRow.Item("collection")
            oDataTable._jewelrytype = oDataRow.Item("jeweltype")
            oDataTable._jewelrysubtype = oDataRow.Item("jewelsubtype")
            oDataTable._metal = oDataRow.Item("metal")
            oDataTable._middlestone = oDataRow.Item("middlestone")
            oDataTable._brand = oDataRow.Item("brand")

            oDataTable._jeweltype_sort = oDataRow.Item("jeweltype_sort")
            oDataTable._metal_sort = oDataRow.Item("metal_sort")
            oDataTable._middlestone_sort = oDataRow.Item("middlestone_sort")
            oDataTable._setting_sort = oDataRow.Item("setting_sort")
            oDataTable._collection_sort = oDataRow.Item("collection_sort")
            oDataTable._middlestone_desc = oDataRow.Item("middlestone_desc")

            If ((Not Convert.IsDBNull(oDataRow.Item("extra_metal"))) And (nMode <> 14)) Then
                oDataTable._extra_metal = oDataRow.Item("extra_metal")
            End If
            If ((Not Convert.IsDBNull(oDataRow.Item("extra_stone"))) And (nMode <> 14)) Then
                oDataTable._extra_stone = oDataRow.Item("extra_stone")
            End If
            If Not Convert.IsDBNull(oDataRow.Item("stone_extended")) Then
                oDataTable._stone_extended = oDataRow.Item("stone_extended")
            End If
            If Not Convert.IsDBNull(oDataRow.Item("se_relateditem_id")) Then
                oDataTable.se_relateditem_id = oDataRow.Item("se_relateditem_id")
            End If

        Else
            oDataTable._size = oDataRow.Item("quantity")
            oDataTable._jewelrytype = oDataRow.Item("stonetype")
            oDataTable._jewelrysubtype = oDataRow.Item("shape")
            oDataTable._metal = oDataRow.Item("origin")
            oDataTable._middlestone = oDataRow.Item("colorfrom")
            oDataTable._brand = oDataRow.Item("clarityfrom")
            oDataTable._middlestone_desc = oDataRow.Item("colorto")
            oDataTable._relateditem_id = oDataRow.Item("clarityto")

            oDataTable._jeweltype_sort = oDataRow.Item("color_sort")
            oDataTable._metal_sort = oDataRow.Item("clarity_sort")
            oDataTable._middlestone_sort = oDataRow.Item("shape_sort")
            If Not Convert.IsDBNull(oDataRow.Item("se_relateditem_id")) Then
                oDataTable.se_relateditem_id = oDataRow.Item("se_relateditem_id")
            End If
        End If





        '--- Format decimals
        Dim oStringFunctions As New iFunctions.cls_string

        bError = oStringFunctions.format_decimal(oDataTable._weight, oDataTable._s_weight, "Gr.")
        If Regex.Match(oDataTable._size, "^\d{1,5}\.?\d{0,4}?\s*?$").Success Then
            bError = oStringFunctions.format_decimal(oDataTable._size, oDataTable._s_size)

        Else
            oDataTable._s_size = oDataTable._size
        End If



        oStringFunctions = Nothing


        '--- make related item link
        If Me._connection_string <> "" Then
            If oDataTable._relateditem_id > 1 Then
                Dim oDescription As New ion_two.cons_description
                oDescription._connection_string = Me._connection_string
                oDescription._dbtype = Me._dbtype
                bError = oDescription.construct(oDataTable._relateditem_id)
                If bError Then
                    Me._err_number = oDescription._err_number
                    Me._err_description = oDescription._err_description
                    Me._err_source = oDescription._err_source
                End If

                '--- get extended description
                oDataTable._relateditem_desc = oDescription._description_extended

                '---  get link
                If Not oPictures Is Nothing Then
                    Select Case oDescription._plate
                        Case 1
                            oDataTable._relateditem_link = oPictures._domain + "/diamond/" + Convert.ToString(oDataTable._relateditem_id) + ".htm"
                        Case 2
                            oDataTable._relateditem_link = oPictures._domain + "/gemstone/" + Convert.ToString(oDataTable._relateditem_id) + ".htm"
                        Case 3
                            oDataTable._relateditem_link = oPictures._domain + "/jewelry/" + Convert.ToString(oDataTable._relateditem_id) + ".htm"
                    End Select
                End If
                '--- release
                oDescription = Nothing
            End If
        End If

        Return False
        Exit Function

ErrorHandler:
        Me._err_number = Err.Number
        Me._err_description = Err.Description
        Me._err_source = Err.Source
        Return True

    End Function


End Class
