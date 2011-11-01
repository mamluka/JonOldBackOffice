Imports System.Data.SqlClient
Imports System.Web.UI.WebControls
Public Class cls_diam_size
    Inherits iFoundation.cls_error
    ''sql stuff conn string
    Public conn_string As String '' must be specified for read
    Public Function read_sizes_by_shape(ByVal shapeid As Int16, ByRef rSize_Collection As Collection, Optional ByVal SizeOverride As Boolean = False) As Boolean

        On Error GoTo ErrorHandler
        Dim bError As Boolean = False


        Dim oConnection As SqlClient.SqlConnection = New SqlClient.SqlConnection
        Dim oDataAdapter1 As SqlDataAdapter = New SqlDataAdapter
        Dim oSQLcmd1 As SqlCommand = New SqlCommand("", oConnection)
        ''
        ''  System.Threading.Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.CreateSpecificCulture(Request.UserLanguages(0))
        '' System.Threading.Thread.CurrentThread.CurrentUICulture = New System.Globalization.CultureInfo(Request.UserLanguages(0))
        '--- create connection
        oConnection.ConnectionString = Me.conn_string
        oDataAdapter1.TableMappings.Add("Table", "inv_std_pricing_pairs")

        oSQLcmd1.CommandText = "select * from inv_std_pricing_pairs where shapeid =" + Convert.ToString(shapeid) + " order by weight"
        oSQLcmd1.CommandType = CommandType.Text
        oDataAdapter1.SelectCommand = oSQLcmd1

        Dim oDs As DataSet
        oDs = New DataSet("std_pricing_pairs")

        oConnection.Open()
        oDataAdapter1.Fill(oDs)


        Dim tmpTable As DataTable = oDs.Tables("inv_std_pricing_pairs")
        Dim i As Int16

        For i = 0 To tmpTable.Rows.Count - 1
            Dim tmpItem As New ion_two.cls_diam_item
            tmpItem.id = i + 1
            tmpItem.weight = tmpTable.Rows(i).Item(2)
            tmpItem.size = tmpTable.Rows(i).Item(3)
            tmpItem.price = 2 * Math.Round(tmpTable.Rows(i).Item(4) * tmpTable.Rows(i).Item(2))
            If Not SizeOverride Then
                If Trim(tmpItem.size) <> "?" Then '' don't add items with no size in the DB
                    rSize_Collection.Add(tmpItem)
                End If
            Else
                If tmpItem.price > 0 Then
                    rSize_Collection.Add(tmpItem)
                End If
            End If

        Next


        Return False
ErrorHandler:
        Me._err_number = Err.Number
        Me._err_description = Err.Description
        Me._err_source = Err.Source
        Return True
    End Function

    Public Function custom_size_close_match(ByVal shapeid As Int16, ByVal ss_length As Decimal, ByRef tmpItem As ion_two.cls_diam_item, ByRef MatchIndex As Int32, Optional ByVal Below As Boolean = False) As Boolean

        On Error GoTo ErrorHandler
        Dim bError As Boolean = False

        Dim i, match_index As Int32
        Dim tmpsizeitems As New Collection
        Me.read_sizes_by_shape(shapeid, tmpsizeitems)

        For i = 1 To tmpsizeitems.Count

            Dim length1, length2 As Decimal
            Me.get_WL_fromstr(tmpsizeitems(i).size, length1, length2)

            If ss_length - length1 < 0 Then
                If Below Then
                    If i > 1 Then
                        tmpItem.price = tmpsizeitems(i - 1).price
                        tmpItem.weight = tmpsizeitems(i - 1).weight
                        tmpItem.size = tmpsizeitems(i - 1).size
                        MatchIndex = i - 1
                        Exit For
                    Else
                        tmpItem.price = tmpsizeitems(1).price
                        tmpItem.weight = tmpsizeitems(1).weight
                        tmpItem.size = tmpsizeitems(1).size
                        MatchIndex = 0
                    End If
                Else
                    tmpItem.price = tmpsizeitems(i).price
                    tmpItem.weight = tmpsizeitems(i).weight
                    tmpItem.size = tmpsizeitems(i).size
                    MatchIndex = i
                    Exit For
                End If

            End If

            If i = tmpsizeitems.Count Then
                tmpItem.price = tmpsizeitems(tmpsizeitems.Count).price
                tmpItem.weight = tmpsizeitems(tmpsizeitems.Count).weight
                tmpItem.size = tmpsizeitems(tmpsizeitems.Count).size
                MatchIndex = tmpsizeitems.Count - 1
            End If
        Next



        Return False
ErrorHandler:
        Me._err_number = Err.Number
        Me._err_description = Err.Description
        Me._err_source = Err.Source
        Return True
    End Function
    '' this function is specilly for the combo match inside ss change stones to find the best match for the stones using the combo string
    Public Function custom_weight_close_match_combo_works(ByVal shapeid As Int16, ByVal weight As Decimal, ByVal quality As String, ByRef rComboIndex As Int16) As Boolean

        On Error GoTo ErrorHandler
        Dim bError As Boolean = False

        Dim i, match_index As Int32
        Dim tmpsizeitems As New Collection
        Me.read_sizes_by_shape(shapeid, tmpsizeitems)

        For i = 1 To tmpsizeitems.Count


            If weight - tmpsizeitems(i).weight <= 0 Then
                If quality = "D-E-F/VVS-VS" Then
                    rComboIndex = i - 1
                Else
                    rComboIndex = (i - 1) + tmpsizeitems.Count
                End If
                Exit For

            End If

        Next



        Return False
ErrorHandler:
        Me._err_number = Err.Number
        Me._err_description = Err.Description
        Me._err_source = Err.Source
        Return True
    End Function


    Public Function fill_combo(ByVal shapeid As Int16, ByRef rCombo As System.Web.UI.WebControls.DropDownList, ByVal size As ion_two.cls_size_atom, ByRef IsCustom As Boolean, Optional ByVal SizeOverride As Boolean = False) As Boolean

        On Error GoTo ErrorHandler
        Dim bError As Boolean = False

        rCombo.Items.Clear()

        Dim i
        Dim tmpsizeitems As New Collection
        Me.read_sizes_by_shape(shapeid, tmpsizeitems, SizeOverride)

        For i = 1 To tmpsizeitems.Count
            If Not SizeOverride Then
                rCombo.Items.Add(Convert.ToString(tmpsizeitems(i).Weight * 2) + " Ct. - " + tmpsizeitems(i).size + " mm")
            Else
                rCombo.Items.Add(Convert.ToString(tmpsizeitems(i).Weight * 2) + " Ct.")
            End If

            rCombo.Items(i - 1).Value = Convert.ToString(tmpsizeitems(i).price)
        Next

        ''check if custom
        


        Return False
ErrorHandler:
        Me._err_number = Err.Number
        Me._err_description = Err.Description
        Me._err_source = Err.Source
        Return True
    End Function


    Public Function getsize_fromstr(ByVal str As String, ByRef rSize As String, Optional ByVal rDecimal As Boolean = False) As Boolean

        On Error GoTo ErrorHandler
        Dim bError As Boolean = False





        If InStr(str, "$", CompareMethod.Text) > 0 Then
            rSize = Mid(str, InStr(str, " - ", CompareMethod.Text) + 3, 50)
            rSize = Mid(rSize, 1, InStr(rSize, " - ", CompareMethod.Text) - 1)


        Else

            rSize = Mid(str, InStr(str, " - ", CompareMethod.Text) + 3, 50)
        End If

        If rDecimal Then
            rSize = rSize.Remove(rSize.Length - 3, 3)
        End If

        'If InStr(rSize, "x") > 0 Then
        '    rSize = +"Ø"
        'End If

        Return False
ErrorHandler:
        Me._err_number = Err.Number
        Me._err_description = Err.Description
        Me._err_source = Err.Source
        Return True
    End Function

    Public Function getweight_fromstr(ByVal str As String, ByRef rWeight As String, Optional ByVal MakeDecimal As Boolean = False) As Boolean

        On Error GoTo ErrorHandler
        Dim bError As Boolean = False

        rWeight = Mid(str, 1, InStr(str, " - ", CompareMethod.Text) - 1)


        If MakeDecimal Then
            rWeight = rWeight.Remove(rWeight.Length - 4, 4)
        End If
        'If InStr(rSize, "x") > 0 Then
        '    rSize = +"Ø"
        'End If

        Return False
ErrorHandler:
        Me._err_number = Err.Number
        Me._err_description = Err.Description
        Me._err_source = Err.Source
        Return True
    End Function

    Public Function get_WL_fromstr(ByVal str As String, ByRef rlength As Decimal, ByRef rWidth As Decimal) As Boolean

        On Error GoTo ErrorHandler
        Dim bError As Boolean = False

        str = str.Replace(" ", "") '' remove spaces for easy handle

        If InStr(str, "x", CompareMethod.Text) > 0 Then
            rlength = Convert.ToDecimal(Mid(str, 1, InStr(str, "x", CompareMethod.Text) - 1))
            rWidth = Convert.ToDecimal(Mid(str, InStr(str, "x", CompareMethod.Text) + 1, 10))
        Else
            rWidth = Convert.ToDecimal(str)


        End If


        Return False
ErrorHandler:
        Me._err_number = Err.Number
        Me._err_description = Err.Description
        Me._err_source = Err.Source
        Return True
    End Function

    Public Function fill_combo_ss_change(ByVal shapeid As Int16, ByRef rCombo As System.Web.UI.WebControls.DropDownList) As Boolean

        On Error GoTo ErrorHandler
        Dim bError As Boolean = False

        Dim i
        Dim tmpsizeitems As New Collection
        Me.read_sizes_by_shape(shapeid, tmpsizeitems)
        Dim ostringfunc As New iFunctions.cls_string

        rCombo.Items.Clear()

        For i = 1 To tmpsizeitems.Count
            Dim tmpprice As String

            Dim oquality As New ion_two.cls_diam_quality
            oquality.price_byquality("1", tmpsizeitems(i).price, tmpsizeitems(i).price)

            ostringfunc.format_currency(tmpsizeitems(i).price, tmpprice, "$")

            rCombo.Items.Add(Convert.ToString(tmpsizeitems(i).Weight) + " Ct. - " + tmpsizeitems(i).size + " mm - " + tmpprice + " (D-E-F/VVS-VS)")
            rCombo.Items(i - 1).Value = Convert.ToString(tmpsizeitems(i).price)
        Next

        Dim indexadd As Int32 = rCombo.Items.Count
        For i = 1 To tmpsizeitems.Count
            Dim tmpprice As String

            Dim oquality As New ion_two.cls_diam_quality
            oquality.price_byquality("2", tmpsizeitems(i).price, tmpsizeitems(i).price)

            ostringfunc.format_currency(tmpsizeitems(i).price, tmpprice, "$")

            rCombo.Items.Add(Convert.ToString(tmpsizeitems(i).Weight) + " Ct. - " + tmpsizeitems(i).size + " mm - " + tmpprice + " (G-H/VS-SI)")
            rCombo.Items(indexadd + i - 1).Value = Convert.ToString(tmpsizeitems(i).price)
        Next



        ''check if custom
        Dim FoundMatch As Boolean

        For i = 1 To rCombo.Items.Count

            rCombo.SelectedIndex = i - 1


        Next


        Return False
ErrorHandler:
        Me._err_number = Err.Number
        Me._err_description = Err.Description
        Me._err_source = Err.Source
        Return True
    End Function


End Class