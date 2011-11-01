Imports System.Text.RegularExpressions
Public Class cls_jewel_extended_lgc
    Inherits iFoundation.cls_logics_sub

    Sub New()
        '--- Set working table
        Me._tablename = "inv_JEWEL_EXTENDED"

        '--- Get module name
        Dim oTmpStack As New System.Diagnostics.StackFrame
        Me._module = oTmpStack.GetMethod.ReflectedType.FullName()
        oTmpStack = Nothing

    End Sub

    Function insert(ByRef oDataTable As skl_jewel_extended) As Boolean
        On Error GoTo ErrorHandler

        '--- local definitions
        Dim bError As Boolean = False

        '--- Get Dataset
        Dim oTmpDataset As DataSet = New ion_two.ds_jewel_extended
        Dim oTmpDataTable As DataTable = oTmpDataset.Tables(_tablename)

        '--- Assign Order
        Dim oTmpDataRow As DataRow
        oTmpDataRow = oTmpDataTable.NewRow

        'oTmpDataRow("id") = oDataTable._id
        oTmpDataRow("INVENTORY_ID") = oDataTable.inventory_id

        oTmpDataRow("cs_desc") = oDataTable.cs_desc
        oTmpDataRow("cs_cut") = oDataTable.cs_cut
        oTmpDataRow("cs_type") = oDataTable.cs_type
        oTmpDataRow("ss_desc") = oDataTable.ss_desc
        oTmpDataRow("ss_cut") = oDataTable.ss_cut
        oTmpDataRow("ss_type") = oDataTable.ss_type

        oTmpDataRow("cs_weight") = oDataTable.cs_weight
        oTmpDataRow("ss_weight") = oDataTable.ss_weight
        oTmpDataRow("total_weight") = oDataTable.total_weight
        oTmpDataRow("measure_1") = oDataTable.measure_1
        oTmpDataRow("measure_2") = oDataTable.measure_2
        oTmpDataRow("measure_3") = oDataTable.measure_3
        oTmpDataRow("color") = oDataTable.color
        oTmpDataRow("color_freetxt") = oDataTable.color_freetxt
        oTmpDataRow("clarity") = oDataTable.clarity
        oTmpDataRow("clarity_freetxt") = oDataTable.clarity_freetxt
        oTmpDataRow("ss_color") = oDataTable.ss_color
        oTmpDataRow("ss_clarity") = oDataTable.ss_clarity
        oTmpDataRow("ss_count") = oDataTable.ss_count
        oTmpDataRow("cs_count") = oDataTable.cs_count
        oTmpDataRow("ss_color_free") = oDataTable.ss_color_freetxt
        oTmpDataRow("ss_clarity_free") = oDataTable.ss_clarity_freetxt
        oTmpDataRow("default_model") = oDataTable.default_model
        oTmpDataRow("has_sidestones") = oDataTable.has_sidestones
        oTmpDataRow("is_gemstone") = oDataTable.is_gemstone
        oTmpDataRow("is_partof_model") = oDataTable.is_partof_model

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

    Function read(ByVal nId As Int32, ByRef oDataTable As skl_jewel_extended) As Boolean
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

        oDataTable.id = oTmpDataRow("id")
        oDataTable.inventory_id = oTmpDataRow("INVENTORY_ID")

        oDataTable.cs_desc = oTmpDataRow("cs_desc")
        oDataTable.cs_cut = oTmpDataRow("cs_cut")
        oDataTable.cs_type = oTmpDataRow("cs_type")
        oDataTable.ss_desc = oTmpDataRow("ss_desc")
        oDataTable.ss_cut = oTmpDataRow("ss_cut")
        oDataTable.ss_type = oTmpDataRow("ss_type")

        oDataTable.cs_weight = Format(oTmpDataRow("cs_weight"), "####0.00")
        oDataTable.ss_weight = Format(oTmpDataRow("ss_weight"), "####0.00")
        oDataTable.total_weight = Format(oTmpDataRow("total_weight"), "####0.00")
        oDataTable.measure_1 = oTmpDataRow("measure_1")
        oDataTable.measure_2 = oTmpDataRow("measure_2")
        oDataTable.measure_3 = oTmpDataRow("measure_3")

        oDataTable.color = oTmpDataRow("color")
        oDataTable.color_freetxt = oTmpDataRow("color_freetxt")
        oDataTable.clarity_freetxt = oTmpDataRow("clarity_freetxt")
        oDataTable.clarity = oTmpDataRow("clarity")

        oDataTable.ss_color = oTmpDataRow("ss_color")
        oDataTable.ss_clarity = oTmpDataRow("ss_clarity")

        oDataTable.ss_color_freetxt = oTmpDataRow("ss_color_free")
        oDataTable.ss_clarity_freetxt = oTmpDataRow("ss_clarity_free")

        oDataTable.ss_count = oTmpDataRow("ss_count")
        oDataTable.cs_count = oTmpDataRow("cs_count")

        oDataTable.default_model = oTmpDataRow("default_model")
        oDataTable.has_sidestones = oTmpDataRow("has_sidestones")
        oDataTable.is_gemstone = oTmpDataRow("is_gemstone")
        oDataTable.is_partof_model = oTmpDataRow("is_partof_model")

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

    Function update(ByRef oDataTable As skl_jewel_extended) As Boolean
        On Error GoTo ErrorHandler

        '--- local definitions
        Dim bError As Boolean = False

        '--- CUSTOM ERROR: Return Error if ID not passed in skeleton
        If oDataTable.id <= 0 Then
            Err.Raise(7006, Me._module + ":update", "No ID passed with skeleton.")
        End If

        Dim oTmpTransact As New iDac.cls_T_read
        oTmpTransact._connection_string = Me._connection_string
        oTmpTransact._dbtype = Me._dbtype
        oTmpTransact._tablename = Me._tablename
        bError = oTmpTransact.transact_read(oDataTable.id)
        If bError Then
            Me._err_number = oTmpTransact._err_number
            Me._err_description = oTmpTransact._err_description
            Me._err_source = oTmpTransact._err_source
            Return True
        End If

        '--- Get DataTable
        Dim oTmpDataTable As DataTable = oTmpTransact._datatable

        Dim oTmpDataRow As DataRow
        oTmpDataRow = oTmpDataTable.Rows(0)
        '--- Assign Order
        ''    oTmpDataRow("INVENTORY_ID") = oDataTable.inventory_id

        oTmpDataRow("cs_desc") = oDataTable.cs_desc
        oTmpDataRow("cs_cut") = oDataTable.cs_cut
        oTmpDataRow("cs_type") = oDataTable.cs_type
        oTmpDataRow("ss_desc") = oDataTable.ss_desc
        oTmpDataRow("ss_cut") = oDataTable.ss_cut
        oTmpDataRow("ss_type") = oDataTable.ss_type

        oTmpDataRow("cs_weight") = oDataTable.cs_weight
        oTmpDataRow("ss_weight") = oDataTable.ss_weight
        oTmpDataRow("total_weight") = oDataTable.total_weight
        oTmpDataRow("measure_1") = oDataTable.measure_1
        oTmpDataRow("measure_2") = oDataTable.measure_2
        oTmpDataRow("measure_3") = oDataTable.measure_3
        oTmpDataRow("color") = oDataTable.color
        oTmpDataRow("color_freetxt") = oDataTable.color_freetxt
        oTmpDataRow("clarity") = oDataTable.clarity
        oTmpDataRow("clarity_freetxt") = oDataTable.clarity_freetxt

        oTmpDataRow("ss_color") = oDataTable.ss_color
        oTmpDataRow("ss_clarity") = oDataTable.ss_clarity

        oTmpDataRow("ss_color_free") = oDataTable.ss_color_freetxt
        oTmpDataRow("ss_clarity_free") = oDataTable.ss_clarity_freetxt

        oTmpDataRow("ss_count") = oDataTable.ss_count
        oTmpDataRow("cs_count") = oDataTable.cs_count

        oTmpDataRow("default_model") = oDataTable.default_model

        oTmpDataRow("has_sidestones") = oDataTable.has_sidestones
        oTmpDataRow("is_gemstone") = oDataTable.is_gemstone
        oTmpDataRow("is_partof_model") = oDataTable.is_partof_model


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

    Function load(ByVal oDataRow As DataRow, ByRef oDataTable As skl_jewel_extended) As Boolean
        On Error GoTo ErrorHandler
        Dim bError As Boolean = False


        oDataTable.id = oDataRow.Item("id")
        oDataTable.inventory_id = oDataRow.Item("inventory_id")


        oDataTable.cs_desc = oDataRow.Item("cs_desc")
        oDataTable.cs_cut = oDataRow.Item("cs_cut")
        oDataTable.cs_type = oDataRow.Item("cs_type")
        oDataTable.ss_desc = oDataRow.Item("ss_desc")
        oDataTable.ss_cut = oDataRow.Item("ss_cut")
        oDataTable.ss_type = oDataRow.Item("ss_type")


        oDataTable.cs_weight = Format(oDataRow.Item("cs_weight"), "####0.00")
        oDataTable.ss_weight = Format(oDataRow.Item("ss_weight"), "####0.00")
        oDataTable.total_weight = Format(oDataRow.Item("total_weight"), "####0.00")
        oDataTable.measure_1 = oDataRow.Item("measure_1")
        oDataTable.measure_2 = oDataRow.Item("measure_2")
        oDataTable.measure_3 = oDataRow.Item("measure_3")
        oDataTable.color = oDataRow.Item("color")
        oDataTable.color_freetxt = oDataRow.Item("color_freetxt")
        oDataTable.clarity = oDataRow.Item("clarity")
        oDataTable.clarity_freetxt = oDataRow.Item("clarity_freetxt")

        oDataTable.ss_color = oDataRow.Item("ss_color")
        oDataTable.ss_clarity = oDataRow.Item("ss_clarity")

        oDataTable.ss_color_freetxt = oDataRow.Item("ss_color_free")
        oDataTable.ss_clarity_freetxt = oDataRow.Item("ss_clarity_free")

        oDataTable.ss_count = oDataRow.Item("ss_count")
        oDataTable.cs_count = oDataRow.Item("cs_count")
        oDataTable.default_model = oDataRow.Item("default_model")
       
        oDataTable.has_sidestones = oDataRow.Item("has_sidestones")
        oDataTable.is_gemstone = oDataRow.Item("is_gemstone")
        oDataTable.is_partof_model = oDataRow.Item("is_partof_model")





        ''--- Format decimals
        'Dim oStringFunctions As New iFunctions.cls_string

        'bError = oStringFunctions.format_decimal(oDataTable._weight, oDataTable._s_weight, "Gr.")
        'If Regex.Match(oDataTable._size, "^\d{1,5}\.?\d{0,4}?\s*?$").Success Then
        '    bError = oStringFunctions.format_decimal(oDataTable._size, oDataTable._s_size)

        'Else
        '    oDataTable._s_size = oDataTable._size
        'End If



        'oStringFunctions = Nothing


        '--- make related item link


        Return False
        Exit Function

ErrorHandler:
        Me._err_number = Err.Number
        Me._err_description = Err.Description
        Me._err_source = Err.Source
        Return True

    End Function


End Class


