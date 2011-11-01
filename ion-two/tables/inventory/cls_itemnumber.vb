Imports System.Text.RegularExpressions
Public Class cls_itemnumber
    Inherits iFoundation.cls_error_connection

    Public _branch_no As Int16
    Public _supplier_no As Int32
    Public _item_no As Int32
    Public _itemnumber_full As String
    Public _search_description As String
    Public _search_error_description As String

    Sub New()
        Me._branch_no = 0
        Me._supplier_no = 0
        Me._item_no = 0
        Me._itemnumber_full = ""
        Me._search_description = ""
        Me._search_error_description = ""
    End Sub

    Public Function get_number(ByVal nBranch_no As Int16, ByVal nSupplier_no As Int32, ByVal nItem_no As Int32) As Boolean
        On Error GoTo ErrorHandler

        '--- local definitions
        Dim bError As Boolean = False

        '--- Check parameters
        If nBranch_no <= 0 Then
            Err.Raise(7002, "ion_two:cls_itemnumber", "No Branch Number passed")
        End If

        If nSupplier_no <= 0 Then
            Err.Raise(7003, "ion_two:cls_itemnumber", "No Supplier Number passed")
        End If

        If nItem_no <= 0 Then
            Err.Raise(7004, "ion_two:cls_itemnumber", "No Item Number passed")
        End If


        '--- Handle BRANCH
        Me._branch_no = nBranch_no
        Dim cBranch_no As String = Convert.ToString(nBranch_no)
        If cBranch_no = 1 Then
            Me._itemnumber_full = "0" + cBranch_no + "-"

        ElseIf cBranch_no = 2 Then
            Me._itemnumber_full = "0" + cBranch_no + "-"

        End If


        '--- Handle SUPPLIER
        Me._supplier_no = nSupplier_no
        Dim cSupplier_no As String = Convert.ToString(nSupplier_no)
        If Len(cSupplier_no) = 1 Then
            Me._itemnumber_full = Me._itemnumber_full + "0" + cSupplier_no + "-"

        ElseIf Len(nBranch_no) = 2 Then
            Me._itemnumber_full = Me._itemnumber_full + cSupplier_no + "-"

        End If


        '--- Handle ITEMNUMBER
        Me._item_no = nItem_no
        Dim cItem_no As String = Convert.ToString(nItem_no)
        If Len(cItem_no) = 1 Then
            Me._itemnumber_full = Me._itemnumber_full + "0000" + cItem_no

        ElseIf Len(cItem_no) = 2 Then
            Me._itemnumber_full = Me._itemnumber_full + "000" + cItem_no

        ElseIf Len(cItem_no) = 3 Then
            Me._itemnumber_full = Me._itemnumber_full + "00" + cItem_no

        ElseIf Len(cItem_no) = 4 Then
            Me._itemnumber_full = Me._itemnumber_full + "0" + cItem_no

        ElseIf Len(cItem_no) = 5 Then
            Me._itemnumber_full = Me._itemnumber_full + cItem_no

        End If

        Return False
        Exit Function

ErrorHandler:

        '--- register the error
        Me._err_number = Err.Number
        Me._err_description = Err.Description
        Me._err_source = Err.Source
        Return True

    End Function

    '---- this function will strip the complete itemnumber in pices
    '---- according to the two methods we know
    Public Function stripitemnumber(ByVal cItemNumber As String) As Boolean
        On Error GoTo ErrorHandler
        Dim bError As Boolean = False


        '---
        Me._itemnumber_full = cItemNumber
        Me._itemnumber_full = Me._itemnumber_full.Trim


        '--- Check incomming
        If Len(cItemNumber) = 0 Then
            Return False
        End If

        If Len(Me._itemnumber_full) = 0 Then
            Return False
        End If

        '--- Define
        Dim cTmpPreNumber, cTmpSufNumber As String
        Dim nPos1 As Integer = -1
        Dim nPos2 As Integer = -1
        Me._search_description = ""
        Me._search_error_description = ""



        '--- Get Position of dashes and split number in 2
        bError = GetDash(Me._itemnumber_full, nPos1, nPos2)
        If nPos1 = 4 Then    '--- xxxx-xxxxx
            cTmpPreNumber = Me._itemnumber_full.Substring(0, nPos1)
            cTmpSufNumber = Me._itemnumber_full.Substring(nPos1 + 1, Len(Me._itemnumber_full.Trim) - nPos1 - 1)
            '--- Get the item number
            If IsNumeric(cTmpSufNumber) Then
                Me._item_no = System.Convert.ToInt32(cTmpSufNumber)
            End If

        ElseIf nPos2 > -1 Then
            cTmpPreNumber = Me._itemnumber_full.Substring(0, nPos2)
            cTmpSufNumber = Me._itemnumber_full.Substring(nPos2 + 1, Len(Me._itemnumber_full.Trim) - nPos2 - 1)
            '--- Get the item number
            If IsNumeric(cTmpSufNumber) Then
                Me._item_no = System.Convert.ToInt32(cTmpSufNumber)
            End If

        Else
            cTmpPreNumber = Me._itemnumber_full
        End If


        '--- Work the PreNumber = Branch & Supplier
        If Len(cTmpPreNumber) = 1 Then
            If IsNumeric(cTmpPreNumber.Substring(0, 1)) Then     '--- x
                Me._branch_no = System.Convert.ToInt32(cTmpPreNumber.Substring(0, 1))
                Me._search_description = "Searching for Branch"
                Return False
            Else
                Me._search_error_description = "Item number not valid!"
                Return False
            End If

        ElseIf Len(cTmpPreNumber) = 2 Then
            If IsNumeric(cTmpPreNumber.Substring(0, 2)) Then     '--- xx
                Me._branch_no = System.Convert.ToInt16(cTmpPreNumber.Substring(0, 2))
                Me._search_description = "Searching for Branch"
                Return False
            ElseIf IsNumeric(cTmpPreNumber.Substring(0, 1)) Then    '--- x-
                Me._branch_no = System.Convert.ToInt16(cTmpPreNumber.Substring(0, 1))
                Me._search_description = "Searching for Branch"
                Return False
            Else
                Me._search_error_description = "Item number not valid!"
                Return False
            End If

        ElseIf Len(cTmpPreNumber) = 3 Then
            If IsNumeric(cTmpPreNumber.Substring(0, 3)) Then     '--- xxx
                Me._branch_no = System.Convert.ToInt16(cTmpPreNumber.Substring(0, 2))
                Me._supplier_no = System.Convert.ToInt16(cTmpPreNumber.Substring(2, 1))
                Me._search_description = "Searching for Branch and Supplier"
                Return False
            ElseIf IsNumeric(cTmpPreNumber.Substring(0, 2)) Then     '--- xx-
                Me._branch_no = System.Convert.ToInt16(cTmpPreNumber.Substring(0, 2))
                Me._search_description = "Searching for Branch"
                Return False
            ElseIf IsNumeric(cTmpPreNumber.Substring(0, 1)) And cTmpPreNumber.Substring(1, 1) = "-" And IsNumeric(cTmpPreNumber.Substring(2, 1)) Then    '--- x-x
                Me._branch_no = System.Convert.ToInt16(cTmpPreNumber.Substring(0, 1))
                Me._supplier_no = System.Convert.ToInt16(cTmpPreNumber.Substring(2, 1))
                Me._search_description = "Searching for Branch"
                Return False
            Else
                Me._search_error_description = "Item number not valid!"
                Return False
            End If

        ElseIf Len(cTmpPreNumber) = 4 Then
            If IsNumeric(cTmpPreNumber.Substring(0, 4)) Then     '--- xxxx
                Me._branch_no = System.Convert.ToInt16(cTmpPreNumber.Substring(0, 2))
                Me._supplier_no = System.Convert.ToInt16(cTmpPreNumber.Substring(2, 2))
                Me._search_description = "Searching for Branch and Supplier"
                Return False
            ElseIf IsNumeric(cTmpPreNumber.Substring(0, 1)) And cTmpPreNumber.Substring(1, 1) = "-" And IsNumeric(cTmpPreNumber.Substring(2, 2)) Then    '--- x-xx
                Me._branch_no = System.Convert.ToInt16(cTmpPreNumber.Substring(0, 1))
                Me._supplier_no = System.Convert.ToInt16(cTmpPreNumber.Substring(2, 2))
                Me._search_description = "Searching for Branch and Supplier"
                Return False
            ElseIf IsNumeric(cTmpPreNumber.Substring(0, 2)) And cTmpPreNumber.Substring(2, 1) = "-" And IsNumeric(cTmpPreNumber.Substring(3, 1)) Then    '--- xx-x
                Me._branch_no = System.Convert.ToInt16(cTmpPreNumber.Substring(0, 2))
                Me._supplier_no = System.Convert.ToInt16(cTmpPreNumber.Substring(3, 1))
                Me._search_description = "Searching for Branch and Supplier"
                Return False
            ElseIf IsNumeric(cTmpPreNumber.Substring(0, 3)) Then    '--- xxx-
                Me._branch_no = System.Convert.ToInt16(cTmpPreNumber.Substring(0, 2))
                Me._supplier_no = System.Convert.ToInt16(cTmpPreNumber.Substring(2, 1))
                Me._search_description = "Searching for Branch and Supplier"
                Return False
            Else
                Me._search_error_description = "Item number not valid!"
                Return False
            End If

        ElseIf Len(cTmpPreNumber) = 5 Then
            If IsNumeric(cTmpPreNumber.Substring(0, 4)) Then     '--- xxxx-
                Me._branch_no = System.Convert.ToInt16(cTmpPreNumber.Substring(0, 2))
                Me._supplier_no = System.Convert.ToInt16(cTmpPreNumber.Substring(2, 2))
                Me._search_description = "Searching for Branch and Supplier"
                Return False
            ElseIf IsNumeric(cTmpPreNumber.Substring(0, 1)) And cTmpPreNumber.Substring(1, 1) = "-" And IsNumeric(cTmpPreNumber.Substring(2, 2)) Then    '--- x-xx-
                Me._branch_no = System.Convert.ToInt16(cTmpPreNumber.Substring(0, 1))
                Me._supplier_no = System.Convert.ToInt16(cTmpPreNumber.Substring(2, 2))
                Me._search_description = "Searching for Branch and Supplier"
                Return False
            ElseIf IsNumeric(cTmpPreNumber.Substring(0, 2)) And cTmpPreNumber.Substring(2, 1) = "-" And IsNumeric(cTmpPreNumber.Substring(3, 2)) Then     '--- xx-xx
                Me._branch_no = System.Convert.ToInt16(cTmpPreNumber.Substring(0, 2))
                Me._supplier_no = System.Convert.ToInt16(cTmpPreNumber.Substring(3, 2))
                Me._search_description = "Searching for Branch and Supplier"
                Return False
            ElseIf IsNumeric(cTmpPreNumber.Substring(0, 2)) And cTmpPreNumber.Substring(2, 1) = "-" And IsNumeric(cTmpPreNumber.Substring(3, 1)) Then    '--- xx-x-
                Me._branch_no = System.Convert.ToInt16(cTmpPreNumber.Substring(0, 2))
                Me._supplier_no = System.Convert.ToInt16(cTmpPreNumber.Substring(3, 1))
                Me._search_description = "Searching for Branch and Supplier"
                Return False
            ElseIf IsNumeric(cTmpPreNumber.Substring(0, 1)) And cTmpPreNumber.Substring(1, 1) = "-" And IsNumeric(cTmpPreNumber.Substring(2, 1)) And cTmpPreNumber.Substring(3, 1) = "-" And IsNumeric(cTmpPreNumber.Substring(4, 1)) Then    '--- x-x-x
                Me._branch_no = System.Convert.ToInt16(cTmpPreNumber.Substring(0, 1))
                Me._supplier_no = System.Convert.ToInt16(cTmpPreNumber.Substring(2, 1))
                Me._item_no = System.Convert.ToInt32(cTmpPreNumber.Substring(4, 1))
                Me._search_description = "Searching for Branch, Supplier and Itemnumber"
                Return False
            Else
                Me._search_error_description = "Item number not valid!"
                Return False
            End If

        Else
            Me._search_error_description = "Item number not valid!"
            Return False

        End If

        Return False
        Exit Function

ErrorHandler:
        Me._err_number = Err.Number
        Me._err_description = Err.Description
        Me._err_source = Err.Source
        Return True

    End Function

    Private Function GetDash(ByVal cTmpString As String, ByRef nPos1 As Integer, ByRef nPos2 As Integer) As Boolean
        Dim nLoop As Integer
        nPos1 = -1
        nPos2 = -1
        For nLoop = 0 To Len(cTmpString.Trim) - 1
            If cTmpString.Substring(nLoop, 1) = "-" Then
                If nPos1 = -1 Then
                    nPos1 = nLoop
                Else
                    nPos2 = nLoop
                End If
            End If
        Next

        Return False
    End Function

    Private Function IsNum(ByVal cTmpString As String) As Boolean
        Dim nLoop As Integer
        For nLoop = 0 To Len(cTmpString.Trim) - 1
            If Asc(cTmpString.Substring(nLoop, 1)) < Asc("0") Or Asc(cTmpString.Substring(nLoop, 1)) > Asc("9") Then
                Return False
            End If
        Next

        Return True

    End Function

    Public Function recode_branch_supplier(ByVal branchin As Int32, ByVal supplierin As Int32, ByRef branchout As String, ByRef supplierout As String)
        If branchin >= 10 Then
            branchout = Convert.ToString(branchin)
        Else
            branchout = "0" + Convert.ToString(branchin)
        End If


        If supplierin >= 10 Then
            supplierout = Convert.ToString(supplierin)
        Else
            supplierout = "0" + Convert.ToString(supplierin)
        End If
    End Function

    Public Function getid_fromnumber(ByVal number As String, ByRef outid As Int32, ByRef outError As String, Optional ByVal Match_plate As Int32 = 0) As Boolean

        Dim berror As Boolean
        berror = Me.stripitemnumber(number)

        If berror Then
            outid = 0
            outError = "Wrong item number syntex, try xxxx-xxxxx"
            Return False
        End If

        Dim oDG_search As New iDac.cls_sql_read

        oDG_search._connection_string = Me._connection_string '' Application("connection")._connection_string
        oDG_search._tablename = "vv_gemstones_full"

        Dim branch, supplier As String

        Me.recode_branch_supplier(Me._branch_no, Me._supplier_no, branch, supplier)

        oDG_search.transact_read("select id,platetype from inv_inventory where itemnumber ='" + Convert.ToString(branch) + "-" + Convert.ToString(supplier) + "-" + Convert.ToString(Me._item_no) + "'")


        Dim oData As DataTable = oDG_search._datatable

        If oData.Rows.Count = 0 Then
            outid = 0
            outError = "Item not found"
        Else
            If Match_plate > 0 Then
                If Match_plate = oData.Rows(0).Item("platetype") Then
                    outid = oData.Rows(0).Item("id")
                    Exit Function
                Else
                    outid = 0
                    outError = "This is not a Gemstone item number"
                End If

            Else
                outid = oData.Rows(0).Item("id")
            End If

        End If

        Return False
    End Function

    Public Function UnicodeItemNumber(ByRef number As String) As Int32
        If number.StartsWith("#") Then

        Else
            number = Trim(Regex.Replace(number, "(\d\d)-?(\d\d)-(\d{5})", "$1-$2-$3"))
        End If

    End Function
    Public Function UnicodeItemNumber(ByVal number As String, ByRef branchid As Int32, ByRef supplierid As Int32, ByRef itemnumber As Int32) As Int32
        If number.StartsWith("#") Then
            branchid = Convert.ToInt32(Regex.Match(number, "#(\d\d)(\d\d)", RegexOptions.Singleline).Groups(1).Value)
            supplierid = Convert.ToInt32(Regex.Match(number, "#(\d\d)(\d\d)", RegexOptions.Singleline).Groups(2).Value)
            itemnumber = 0
        Else
            branchid = Convert.ToInt32(Regex.Match(number, "(\d\d)-?(\d\d)-(\d{5})", RegexOptions.Singleline).Groups(1).Value)
            supplierid = Convert.ToInt32(Regex.Match(number, "(\d\d)-?(\d\d)-(\d{5})", RegexOptions.Singleline).Groups(2).Value)
            itemnumber = Convert.ToInt32(Regex.Match(number, "(\d\d)-?(\d\d)-(\d{5})", RegexOptions.Singleline).Groups(3).Value)

        End If

    End Function

End Class
