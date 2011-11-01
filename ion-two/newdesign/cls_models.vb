Imports System.Text.RegularExpressions
Public Class cls_models
    Inherits iFoundation.cls_logics_sub
    Function GetInfoFromTitle(ByVal title As String, ByRef Hash As Hashtable) As Boolean
        Dim carat_weight As String
        If Regex.Matches(title, "\d{1,3}\.?\d{1,3}?(?=\sCt|\sCT)").Count > 0 Then
            carat_weight = Regex.Matches(title, "\d{1,3}\.?\d{1,3}?(?=\sCt|\sCT)")(0).Value
        End If

        Dim clarity As String
        Dim color As String

        'If Regex.Matches(title, "\s(\w{1})/(\w{1,4})\s").Count > 0 Then
        '    clarity = Regex.Match(title, "\s(\w{1})/(\w{1,4})\s").Groups(1).Value
        '    color = Regex.Match(title, "\s(\w{1})/(\w{1,4})\s").Groups(2).Value
        'End If

        Hash("totalcarat") = carat_weight
        Hash("color") = color
        Hash("clarity") = clarity


    End Function

    Function GetInfoFromStoneExtended(ByVal jewel_extended As skl_jewel_extended, ByRef hash As Hashtable) As Boolean
        ''   Dim oextra As New ion_two.cls_jewerly_extra
        ''load the params
        ''   oextra.get_stone_extended_string(extrastring)

        ''oplate._subplate._stone_extended
        Dim cs_carat_weight As String
        Dim ss_carat_weight As String

        If Regex.Matches(jewel_extended.cs_desc, "\d{1,3}\.?\d{1,3}?(?=\sCt|\sCT)").Count > 0 Then
            cs_carat_weight = Regex.Matches(jewel_extended.cs_desc, "\d{1,3}\.?\d{1,3}?(?=\sCt|\sCT)")(0).Value
        End If

        If Regex.Matches(jewel_extended.ss_desc, "\d{1,3}\.?\d{1,3}?(?=\sCt|\sCT)").Count > 0 Then
            ss_carat_weight = Regex.Matches(jewel_extended.ss_desc, "\d{1,3}\.?\d{1,3}?(?=\sCt|\sCT)")(0).Value
        End If

        Dim clarity As String
        Dim color As String

        Dim ss_clarity As String
        Dim ss_color As String

        If Regex.Matches(jewel_extended.cs_desc, "(\w{1})/(\w{1,4})").Count > 0 Then
            color = Regex.Match(jewel_extended.cs_desc, "(\w{1})/(\w{1,4})").Groups(1).Value
            clarity = Regex.Match(jewel_extended.cs_desc, "(\w{1})/(\w{1,4})").Groups(2).Value
        End If
        If Regex.Matches(jewel_extended.ss_desc, "(\w{1})/(\w{1,4})").Count > 0 Then
            ss_color = Regex.Match(jewel_extended.ss_desc, "(\w{1})/(\w{1,4})").Groups(1).Value
            ss_clarity = Regex.Match(jewel_extended.ss_desc, "(\w{1})/(\w{1,4})").Groups(2).Value
        End If

        hash("cs_carat_weight") = cs_carat_weight
        hash("ss_carat_weight") = ss_carat_weight
        hash("color") = color
        hash("clarity") = clarity

        hash("ss_color") = ss_color
        hash("ss_clarity") = ss_clarity


    End Function

    Function GetItemByModelColorClarity(ByRef oPlate As ion_two.skl_lst_inventory, ByVal itemcode As String, ByVal Color As String, ByVal Clarity As String, ByVal metal As String, Optional ByVal middlestone As String = "") As Boolean


        Dim viewer_sql As New iDac.cls_sql_read
        viewer_sql._connection_string = Me._connection_string
        viewer_sql._tablename = "vv_jewelry_full"
        Dim ssql As String
        If middlestone = "" Then
            ssql = "select id from vv_jewelry_full where itemcode='" + itemcode + "' and color = '" + Color + "'" + " and clarity = '" + Clarity + "' and metal = '" + metal + "'"
        Else
            ssql = "select id from vv_jewelry_full where itemcode='" + itemcode + "' and color = '" + Color + "'" + " and clarity = '" + Clarity + "' and metal = '" + metal + "' and cs_type='" + middlestone + "'"
        End If
        viewer_sql.transact_read(ssql)

        Dim oData As DataTable = viewer_sql._datatable

        If oData.Rows.Count > 0 Then
            Dim oTmpInventory As New ion_two.cls_inventory_lgc
            oTmpInventory._connection_string = Me._connection_string
            oTmpInventory._dbtype = 1

            oTmpInventory.load(oData.Rows(0)("id"), oPlate)

            Return True

        Else
            Return False
        End If


    End Function


    Function GetItemByModelSSColorClarity(ByRef oPlate As ion_two.skl_lst_inventory, ByVal itemcode As String, ByVal Color As String, ByVal Clarity As String, ByVal metal As String, Optional ByVal middlestone As String = "") As Boolean


        Dim viewer_sql As New iDac.cls_sql_read
        viewer_sql._connection_string = Me._connection_string
        viewer_sql._tablename = "vv_jewelry_full"
        Dim ssql As String
        If middlestone = "" Then
            ssql = "select id from vv_jewelry_full where itemcode='" + itemcode + "' and ss_color = '" + Color + "'" + " and ss_clarity = '" + Clarity + "' and metal = '" + metal + "'"
        Else
            ssql = "select id from vv_jewelry_full where itemcode='" + itemcode + "' and ss_color = '" + Color + "'" + " and ss_clarity = '" + Clarity + "' and metal = '" + metal + "' and middlestone='" + middlestone + "'"
        End If
        viewer_sql.transact_read(ssql)

        Dim oData As DataTable = viewer_sql._datatable

        If oData.Rows.Count > 0 Then
            Dim oTmpInventory As New ion_two.cls_inventory_lgc
            oTmpInventory._connection_string = Me._connection_string
            oTmpInventory._dbtype = 1

            oTmpInventory.load(oData.Rows(0)("id"), oPlate)

            Return True

        Else
            Return False
        End If


    End Function

End Class
