Imports System.Web
Imports System.Text.RegularExpressions

Public Class cons_description
    Inherits iFoundation.cls_error_connection

    Public _description As String
    Public _description_round As String
    Public _description_extended As String
    Public _plate As Integer
    Public _id As Int32
    Public _round As Boolean
    Public _category_id As Int32

    Sub New()
        Me._description = ""
        Me._description_round = ""
        Me._description_extended = ""
        Me._plate = 0
        Me._round = False
        Me._category_id = 0
    End Sub
    Public Overloads Function construct(ByVal nId As Int32) As Boolean
        On Error GoTo ErrorHandler

        '--- Define local vars
        Dim bError As Boolean = False

        '--- Load plate
        Dim oDataTable As New ion_two.skl_lst_inventory
        Dim oTmpInventory As New ion_two.cls_inventory_lgc
        oTmpInventory._connection_string = Me._connection_string
        oTmpInventory._dbtype = Me._dbtype

        bError = oTmpInventory.load(nId, oDataTable)
        If bError Then
            Me._err_number = oTmpInventory._err_number
            Me._err_description = oTmpInventory._err_description
            Me._err_source = oTmpInventory._err_source
            Return True
        End If

        '--- Release
        oTmpInventory = Nothing

        '--- Goto constructing description
        If oDataTable._id > 0 Then
            bError = Me.construct(oDataTable)
            If bError Then
                Me._err_number = Err.Number
                Me._err_description = Err.Description
                Me._err_source = Err.Source
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

    Public Overloads Function construct(ByVal oDataTable As skl_lst_inventory) As Boolean
        On Error GoTo ErrorHandler

        '--- Define local vars
        Dim bError As Boolean = False

        Dim nCarat As Decimal = oDataTable._subplate._weight
        Dim cCarat_regular As String = ""
        Dim cCarat_round As String = ""
        Dim nCategory_id As Int32 = 0


        '--- Regular NOT rounded results
        cCarat_regular = Format(nCarat, "##,##0.00")

        '--- Round results if needed
        cCarat_round = Format(Decimal.Round(nCarat, 1), "##,##0.00")
        Dim nLen As Int16 = Len(cCarat_round)

        If Mid(cCarat_round, nLen - 2, nLen) = ".00" Then
            cCarat_round = Mid(cCarat_round, 1, nLen - 3)

        ElseIf Mid(cCarat_round, nLen - 1, nLen) = ".0" Then
            cCarat_round = Mid(cCarat_round, 1, nLen - 2)

        ElseIf Mid(cCarat_round, nLen, nLen) = "0" Then
            cCarat_round = Mid(cCarat_round, 1, nLen - 1)

        End If
        cCarat_round = cCarat_round + " (" + Format(Decimal.Round(nCarat, 1), "##,##0.00") + ")"


        '--- Get Category_id
        Me._category_id = oDataTable._category_id

        '--- set plate
        Me._plate = oDataTable._platetype

        Select Case oDataTable._platetype
            Case 1
                '--- Do the first part
                cCarat_round = oDataTable._subplate._stonetype + " " + cCarat_round + " carat"
                cCarat_regular = oDataTable._subplate._stonetype + " " + cCarat_regular + " carat"


                If oDataTable._subplate._shape <> "-" Then
                    Me._description = Me._description + "<br>" + oDataTable._subplate._shape + "<br>"
                    Me._description_extended = Me._description_extended + "<br>" + oDataTable._subplate._shape + "<br>"
                End If

                If oDataTable._subplate._colorfrom <> "-" And oDataTable._subplate._colorto.indexOf("note") = 0 Then
                    Me._description = Me._description + oDataTable._subplate._colorfrom
                    Me._description_extended = Me._description_extended + oDataTable._subplate._colorfrom
                End If

                'If oDataTable._subplate._clarityfrom <> "-" Then
                '    Me._description = Me._description + " " + oDataTable._subplate._clarityfrom
                '    Me._description_extended = Me._description_extended + "/" + oDataTable._subplate._clarityfrom
                'End If

                If oDataTable._subplate._colorto <> "-" And oDataTable._subplate._colorto.indexOf("note") = 0 Then
                    Me._description = Me._description + " - " + oDataTable._subplate._colorto
                    Me._description_extended = Me._description_extended + " - " + oDataTable._subplate._colorto
                End If

                'If oDataTable._subplate._clarityto <> "-" Then
                '    Me._description = Me._description + " " + oDataTable._subplate._clarityto
                '    Me._description_extended = Me._description_extended + "/" + oDataTable._subplate._clarityto
                'End If

                If oDataTable._subplate.fancy_freetxt <> "" Then
                    Me._description = Me._description + oDataTable._subplate.fancy_freetxt
                    Me._description_extended = Me._description_extended + oDataTable._subplate.fancy_freetxt

                End If

                '--- set description
                Me._description_round = cCarat_round + " " + Trim(Me._description)
                Me._description = cCarat_regular + " " + Trim(Me._description)
                Me._description_extended = cCarat_regular + Trim(Me._description_extended)

            Case 2
                '--- Do the first part
                cCarat_round = oDataTable._subplate._stonetype + " " + cCarat_round + " carat"
                cCarat_regular = oDataTable._subplate._stonetype + " " + cCarat_regular + " carat"

                If oDataTable._subplate._shape <> "-" Then
                    Me._description = Me._description + "<br>" + oDataTable._subplate._shape + "<br>"
                    Me._description_extended = Me._description_extended + "<br>" + oDataTable._subplate._shape + "<br>"
                End If

                If oDataTable._subplate._origin <> "-" Then
                    Me._description = Me._description + oDataTable._subplate._origin
                    Me._description_extended = Me._description_extended + "Origin: " + oDataTable._subplate._origin
                End If

                If oDataTable._subplate.freecolor <> "" Then
                    Me._description = Me._description + "<br>" + oDataTable._subplate.freecolor
                    Me._description_extended = Me._description_extended + ",Color: " + oDataTable._subplate.freecolor
                End If

                '--- set description
                Me._description_round = cCarat_round + Trim(Me._description)
                Me._description = cCarat_regular + Trim(Me._description)
                Me._description_extended = cCarat_regular + Trim(Me._description_extended)

            Case 3

                If oDataTable._subplate.jewel_title = "" Then
                    If oDataTable._subplate._middlestone <> "-" Then
                        Me._description = oDataTable._subplate._middlestone
                        Me._description_extended = oDataTable._subplate._middlestone
                    End If

                    Me._description = Trim(Me._description) + " " + oDataTable._subplate._jewelrysubtype
                    Me._description_extended = Trim(Me._description_extended) + " " + oDataTable._subplate._jewelrysubtype


                    Me._description = Me._description + " " + oDataTable._subplate._jewelrytype
                    Me._description_extended = Me._description_extended + " " + oDataTable._subplate._jewelrytype


                    If oDataTable._subplate._metal <> "-" Then
                        Me._description = Me._description + "<br>" + oDataTable._subplate._metal
                        Me._description_extended = Me._description_extended + "<br>" + oDataTable._subplate._metal
                    End If

                    If Trim(oDataTable._subplate._jewelrysubtype) <> "Solitaire Ring" Then
                        If oDataTable._subplate._middlestone_desc <> "" Then
                            If oDataTable._subplate._relateditem_id <= 1 Then
                                If oDataTable._subplate._jewel_extended.cs_desc <> "" Then
                                    '' Dim oextra As New cls_jewerly_extra
                                    '' oDataTable._subplate._jewel_extended.get_stone_extended_string(oDataTable._subplate._stone_extended)
                                    Me._description += "<br><span style='font-size:11px'><strong>" + Regex.Replace(oDataTable._subplate._jewel_extended.cs_desc, "<*?br*?>", " ", RegexOptions.IgnoreCase) + "</strong></span>"
                                    Me._description += "<br><strong>" + oDataTable._subplate._jewel_extended.cs_type + " " + oDataTable._subplate._jewel_extended.cs_cut + "</strong>"

                                    Me._description_extended += "<br><span style='font-size:11px'><strong>" + Regex.Replace(oDataTable._subplate._jewel_extended.cs_desc, "<*?br*?>", " ", RegexOptions.IgnoreCase) + "</strong></span>"
                                    Me._description_extended += "<br><strong>" + oDataTable._subplate._jewel_extended.cs_type + " " + oDataTable._subplate._jewel_extended.cs_cut + "</strong>"
                                    'oDataTable._subplate._middlestone_desc = oDataTable._subplate._middlestone_desc.replace(", ", "<br>")
                                    'oDataTable._subplate._middlestone_desc = oDataTable._subplate._middlestone_desc.replace(Split(oDataTable._subplate._middlestone_desc, "<br>")(0), "<span style='font-size:11px'>" + Split(oDataTable._subplate._middlestone_desc, "<br>")(0) + "</span>")
                                    'Me._description = Me._description + "<br><b>" + oDataTable._subplate._middlestone_desc + "<b>"

                                    'Me._description_extended = Me._description_extended + "<br><b>" + oDataTable._subplate._middlestone_desc + "</b>"
                                End If
                            End If
                        End If
                    End If
                    '--- set description
                    Me._description_round = Trim(Me._description)
                    Me._description = Trim(Me._description)
                    Me._description_extended = Trim(Me._description_extended)
                Else

                    Me._description_round = Trim(oDataTable._subplate.jewel_title)
                    Me._description = Trim(oDataTable._subplate.jewel_title)
                    Me._description_extended = Trim(oDataTable._subplate.jewel_title)
                End If
        End Select
        '--- take care of the extra info desc
        ''take care of non twin-diamonds website
        'remove before compile


        If Not HttpContext.Current.Session("ext_info") Is Nothing Then
            If ((HttpContext.Current.Session("ext_info").is_extra_info(oDataTable._id)) And (InStr(HttpContext.Current.Request.Url.ToString, "cart", CompareMethod.Text) > 0)) Then
                If oDataTable._subplate.se_relateditem_id = 0 Then
                    Me._description_extended = ""
                    Me._description = ""
                    If oDataTable._subplate._middlestone <> "-" Then
                        Me._description = oDataTable._subplate._middlestone
                        Me._description_extended = oDataTable._subplate._middlestone
                    End If

                    Me._description = Trim(Me._description) + " " + oDataTable._subplate._jewelrysubtype
                    Me._description_extended = Trim(Me._description_extended) + " " + oDataTable._subplate._jewelrysubtype


                    Me._description = Me._description + " " + oDataTable._subplate._jewelrytype
                    Me._description_extended = Me._description_extended + " " + oDataTable._subplate._jewelrytype


                    ''set metal as changed
                    Me._description = Me._description + ", " + HttpContext.Current.Session("ext_info").get_metal_type
                    Me._description_extended = Me._description_extended + ", " + HttpContext.Current.Session("ext_info").get_metal_type


                    'If oDataTable._subplate._middlestone_desc <> "" Then
                    '        If oDataTable._subplate._relateditem_id <= 1 Then
                    '            Me._description = Me._description + ", " + oDataTable._subplate._middlestone_desc
                    '            Me._description_extended = Me._description_extended + ", " + oDataTable._subplate._middlestone_desc
                    '        End If
                    '    End If


                    '--- set description
                    Me._description_round = Trim(Me._description) + "<br>" + HttpContext.Current.Session("ext_info").get_stone_desc
                    Me._description = Trim(Me._description) + "<br>" + HttpContext.Current.Session("ext_info").get_stone_desc
                    Me._description_extended = Trim(Me._description) + "<br>" + HttpContext.Current.Session("ext_info").get_stone_desc
                End If
            End If
        End If


        '--- Add certification
        Dim cReport As String = oDataTable._subplate._report
        If cReport.ToUpper.StartsWith("GIA") Then
            Me._description_extended = Me._description_extended + " <b>GIA Report</b>"

        ElseIf cReport.ToUpper.StartsWith("IGI") Then
            Me._description_extended = Me._description_extended + " <b>IGI Report</b>"

        ElseIf cReport.ToUpper.StartsWith("HRD") Then
            Me._description_extended = Me._description_extended + " <b>HRD Report</b>"

        ElseIf cReport.ToUpper.StartsWith("EGL") Then
            Me._description_extended = Me._description_extended + " <b>EGL Report</b>"

        ElseIf cReport.ToUpper.StartsWith("TGL") Then
            Me._description_extended = Me._description_extended + " <b>TGL Report</b>"

        ElseIf cReport.ToUpper.StartsWith("GUBELIN") Then
            Me._description_extended = Me._description_extended + " <b>GUBELIN Report</b>"

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
