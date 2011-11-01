Imports System.Web
Public Class cls_string
    Inherits iFoundation.cls_error
    Public currencyID = HttpContext.Current.Session("user")._currencyID
    Public currency_symbol As String
    Sub New()

        Select Case Me.currencyID
            Case "USD"
                Me.currency_symbol = "$"
            Case "GBP"
                Me.currency_symbol = "£"
            Case "EUR"
                Me.currency_symbol = "€"
            Case "AUD"
                Me.currency_symbol = "AUD"
            Case "CAD"
                Me.currency_symbol = "CAD"
            Case "ILS"
                Me.currency_symbol = "₪"
            Case Else
                Me.currency_symbol = "$"

        End Select
    End Sub
    Public Function strip_html(ByVal cHtml As String, ByRef cString As String) As Boolean
        On Error GoTo ErrorHandler
        Dim bError As Boolean = False

        Dim cTmpstring As String = ""
        Dim cHalf1 As String = ""
        Dim cHalf2 As String = ""
        Dim bDone As Boolean = True
        Dim nLoop As Int16
        For nLoop = 1 To cString.Length - 1
            cTmpstring = cString.Substring(nLoop, cHtml.Length)
            If LCase(cTmpstring) = LCase(cHtml) Then
                cHalf1 = cString.Substring(0, nLoop)
                cHalf2 = cString.Substring(nLoop + cHtml.Length)
                cString = cHalf1 + cHalf2
                bDone = False
                Exit For
            End If

            If (cString.Length - nLoop) <= cHtml.Length Then
                Exit For
            End If

        Next


        If Not bDone Then
            Me.strip_html(cHtml, cString)
        End If


        Return False
        Exit Function

ErrorHandler:
        Me._err_number = Err.Number
        Me._err_description = Err.Description
        Me._err_source = Err.Source
        Return True

    End Function

    Public Function text2string(ByRef cString As String) As Boolean
        On Error GoTo ErrorHandler
        Dim bError As Boolean = False

        Dim bIsText As Boolean = False
        Dim cChr As String = ""
        Dim cHalf1 As String = ""
        Dim cHalf2 As String = ""

        Dim nLoop As Int32
        For nLoop = 1 To cString.Length
            '--- get next character
            cChr = cString.Substring(nLoop, 1)

            '--- check character
            bIsText = False
            bError = Me.istext(2, cChr, bIsText)
            If bError Then
                Return True
            End If

            If Not bIsText Then
                cHalf1 = cString.Substring(1, nLoop - 1)
                cHalf2 = cString.Substring(nLoop + 1)
                cString = cHalf1 + cHalf2
            End If
        Next

        Return False
        Exit Function

ErrorHandler:
        Me._err_number = Err.Number
        Me._err_description = Err.Description
        Me._err_source = Err.Source
        Return True

    End Function
    Public Function istext(ByVal nMode As Int16, ByVal cChracter As String, ByRef bIstext As Boolean) As Boolean
        On Error GoTo ErrorHandler
        Dim bError As Boolean = False

        Dim cText_1 As String
        Dim cText_2 As String
        cText_1 = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890~!@#$%^&*()_+|`,.;:][}{<> - "
        cText_2 = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890()- "


        Dim nLoop As Int16 = 0
        Dim cWorkingString As String
        bIstext = False


        '--- select proper mode
        Select Case nMode
            Case 1
                cWorkingString = cText_1

            Case 2
                cWorkingString = cText_2

        End Select


        '--- check string
        For nLoop = 1 To cWorkingString.Length - 1
            If cWorkingString.Substring(nLoop, 1) = cChracter Then
                bIstext = True
                Exit For
            End If
        Next


        Return False
        Exit Function

ErrorHandler:
        Me._err_number = Err.Number
        Me._err_description = Err.Description
        Me._err_source = Err.Source
        Return True

    End Function

    Public Function string2collection(ByVal cTmpString As String, ByRef oTmpCollection As Collection) As Boolean
        '--- turns a string seperated with comma into collection
        On Error GoTo ErrorHandler
        Dim bError As Boolean = False

        cTmpString = cTmpString + ","
        oTmpCollection = New Collection
        Dim cTmpResult As String

        Do
            cTmpResult = Me.strip(cTmpString)

            If IsNumeric(cTmpResult) Then
                oTmpCollection.Add(oTmpCollection)
                cTmpResult = ""
            End If
        Loop While cTmpString <> ""

        Return False
        Exit Function

ErrorHandler:
        Me._err_number = Err.Number
        Me._err_description = Err.Description
        Me._err_source = Err.Source
        Return True

    End Function

    Private Function strip(ByRef cTmpString As String) As String
        '--- called from string2collection

        Dim cTmpMagazin As String
        Dim nLoop As Int32

        For nLoop = 1 To Len(cTmpString)

            If Mid(cTmpString, nLoop, 1) <> "," Then
                cTmpMagazin = cTmpMagazin + Mid(cTmpString, nLoop, 1)
            Else
                cTmpString = Mid(cTmpString, nLoop + 1)
                Return cTmpMagazin
            End If

        Next

    End Function

    Public Function format_currency(ByVal nInString As Decimal, ByRef cOutString As String, Optional ByVal cAddString As String = "") As Boolean
        On Error GoTo ErrorHandler
        Dim bError As Boolean = False
        If Me.currency_symbol <> "" And cAddString <> "" Then
            cOutString = Format(nInString, "##,##0") + " " + Trim(Me.currency_symbol)
        Else
            If cAddString <> "" Then
                cOutString = Format(nInString, "##,##0") + " " + Trim(cAddString)
            Else
                cOutString = Format(nInString, "##,##0")
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

    Public Function deformat_currency(ByVal nInString As String, ByRef cOutdecimal As Decimal, Optional ByVal cAddString As String = "") As Boolean
        On Error GoTo ErrorHandler
        Dim bError As Boolean = False
        If cAddString.Length > 0 Then
            nInString = nInString.Remove(nInString.Length - cAddString.Length, cAddString.Length)
            nInString = nInString.Replace(",", "")

        Else
            nInString = nInString.Remove(nInString.Length - 3, 3)
            nInString = nInString.Replace(",", "")

        End If

        cOutdecimal = Convert.ToDecimal(nInString)


        Return False
        Exit Function

ErrorHandler:
        Me._err_number = Err.Number
        Me._err_description = Err.Description
        Me._err_source = Err.Source
        Return True

    End Function

    Public Function format_decimal(ByVal nInString As Decimal, ByRef cOutString As String, Optional ByVal cAddString As String = "") As Boolean
        On Error GoTo ErrorHandler
        Dim bError As Boolean = False

        If cAddString <> "" Then
            cOutString = Format(nInString, "##,##0.00") + " " + Trim(cAddString)
        Else
            cOutString = Format(nInString, "##,##0.00")
        End If


        Return False
        Exit Function

ErrorHandler:
        Me._err_number = Err.Number
        Me._err_description = Err.Description
        Me._err_source = Err.Source
        Return True

    End Function
    Public Function format_decimal_return(ByVal nInString As Decimal, Optional ByVal cAddString As String = "") As String
        'On Error GoTo ErrorHandler
        'Dim bError As Boolean = False

        If cAddString <> "" Then
            Return Format(nInString, "##,##0.00") + " " + Trim(cAddString)
        Else
            Return Format(nInString, "##,##0.00")
        End If


        Return False
        Exit Function

        'ErrorHandler:
        '        Me._err_number = Err.Number
        '        Me._err_description = Err.Description
        '        Me._err_source = Err.Source
        '        Return True

    End Function

    Public Function get_params_fromstr(ByVal Str As String, ByRef outStrColl As ArrayList) As Boolean
        On Error GoTo ErrorHandler
        Dim bError As Boolean = False

        If Str.IndexOf("|") = 0 Then
            Str = Mid(Str, 2, Str.Length)
        End If

        Do Until Str.Length = 0

            outStrColl.Add(Mid(Str, 1, Str.IndexOf("|")))
            Str = Mid(Str, Str.IndexOf("|") + 2, Str.Length)

        Loop

        Return False
        Exit Function

ErrorHandler:
        Me._err_number = Err.Number
        Me._err_description = Err.Description
        Me._err_source = Err.Source
        Return True

    End Function

    Public Function reformat_size(ByVal SizeStr As String, ByRef OutSize As String) As Boolean
        On Error GoTo ErrorHandler
        Dim bError As Boolean = False


        Dim i, j As Int32

        'Do Until SizeStr.Length > 0

        Dim tmpStrArray As New ArrayList

        ''sizestr=sizestr.Replace(

        'Loop


        For i = 1 To SizeStr.Length
            If IsNumeric(Mid(SizeStr, i, 1)) Then
                For j = i + 1 To SizeStr.Length
                    If Not ((IsNumeric(Mid(SizeStr, j, 1))) Or (Mid(SizeStr, j, 1) = ".")) Then
                        tmpStrArray.Add((Mid(SizeStr, i, j - i)))
                        i = j
                        Exit For
                    End If
                Next
            End If

            ''i = 8
        Next

        If tmpStrArray.Count = 1 Then
            OutSize = tmpStrArray.Item(0) + "x" + tmpStrArray.Item(0)
        Else
            OutSize = tmpStrArray.Item(0) + "x" + tmpStrArray.Item(1)
        End If



        Return False
        Exit Function

ErrorHandler:
        Me._err_number = Err.Number
        Me._err_description = Err.Description
        Me._err_source = Err.Source
        Return True

    End Function
    Public Function ClearHTMLTags(ByRef strHTML)
        'Variables used in the function

        Dim strTagLess As String

        '---------------------------------------
        strTagLess = strHTML
        'Move the string into a private variable
        'within the function
        '---------------------------------------

        '---------------------------------------
        ''  regEx = System.Text.RegularExpressions.Regex    'Creates a regexp object		
        strTagLess = System.Text.RegularExpressions.Regex.Replace(strTagLess, "<[^>]*>", " ")
        ''regEx.IgnoreCase = True
        'Don't give frat about case sensitivity

        '---------------------------------------	

        '---------------------------------------
        strHTML = strTagLess
        'The results are passed back
        '---------------------------------------
    End Function
    Public Function ClearHTMLTagsReturn(ByVal strHTML)
        'Variables used in the function

        Dim strTagLess As String

        '---------------------------------------
        strTagLess = strHTML
        'Move the string into a private variable
        'within the function
        '---------------------------------------

        '---------------------------------------
        ''  regEx = System.Text.RegularExpressions.Regex    'Creates a regexp object		
        strTagLess = System.Text.RegularExpressions.Regex.Replace(strTagLess, "<[^>]*>", " ")
        ''regEx.IgnoreCase = True
        'Don't give frat about case sensitivity

        '---------------------------------------	

        '---------------------------------------
        Return strTagLess
        'The results are passed back
        '---------------------------------------
    End Function

    Public Function Hash2String(ByVal hash As Hashtable, ByVal itemdelim As String, ByVal valdelim As String) As String
        Dim tmpstr As String = ""
        Dim tmpArray As New ArrayList
        For Each key As String In hash.Keys
            tmpArray.Add(key + valdelim + Convert.ToString(hash(key)))
        Next

        tmpstr = Join(tmpArray.ToArray, itemdelim)


        Return tmpstr

    End Function

    Public Function HashfromString(ByVal str As String, ByVal itemdelim As String, ByVal valdelim As String) As Hashtable
        If str.IndexOf(valdelim) = -1 Then
            Return New Hashtable
        End If
        Dim hash As New Hashtable
        Dim tmpVals() As String = Split(str, itemdelim)
        For Each val As String In tmpVals

            hash.Add(Split(val, valdelim)(0), Split(val, valdelim)(1))

        Next

        Return hash

    End Function

    Public Function CreateJSFunc(ByVal funcname As String, ByVal jsparams As ArrayList, Optional ByVal nonstrings As String = "") As String
        Dim rtn As String
        Dim tmp_jsparams As New ArrayList
        rtn = funcname + "("


        For Each obj As Object In jsparams
            If obj.GetType().Name = "String" And Convert.ToString(obj) <> "this" And Convert.ToString(obj) <> "null" And nonstrings.IndexOf(Convert.ToString(obj)) = -1 Then
                tmp_jsparams.Add("'" + Convert.ToString(obj) + "'")
            Else
                tmp_jsparams.Add(obj)
            End If
        Next

        rtn += Join(tmp_jsparams.ToArray, ",") + ")"

        Return rtn
    End Function

    Public Function EncodeQuaryString(ByVal hash As Hashtable) As String
        Dim tmpstr As String
        Dim tmparray As New ArrayList



        For Each key As String In hash.Keys
            If Not IsNothing(hash(key)) Then
                If hash(key).ToString <> "" Then
                    tmparray.Add(key + "=" + hash(key).ToString)
                End If
            End If
        Next



        tmpstr = "?" + Join(tmparray.ToArray, "&")

        Return tmpstr
    End Function

    Public Function EncodeQuaryString(ByVal array As ArrayList) As String
        Dim tmpstr As String
        Dim tmparray As New ArrayList



        For Each key As String In array
            If key.ToString <> "" Then
                tmparray.Add(key)
            End If

        Next

        tmpstr = "?" + Join(tmparray.ToArray, "&")

        Return tmpstr
    End Function

    Function EncodeProblematicChars(ByVal str As String) As String
        If str.Length = 0 Then Exit Function
        str = str.Replace("#", "^ledder^")
        str = str.Replace(">", "^right^")
        str = str.Replace("<", "^left^")
        str = str.Replace("?", "^qust^")

        Return str




    End Function

    Function DecodeProblematicChars(ByVal str As String) As String

        If str.Length = 0 Then Exit Function
        str = str.Replace("^ledder^", "#")
        str = str.Replace("^right^", ">")
        str = str.Replace("^left^", "<")
        str = str.Replace("^qust^", "?")

        Return str
    End Function

    Function CreateCascadeByArray(ByVal array As ArrayList, ByRef outarray As ArrayList, Optional ByVal startstr As String = "")
        Dim i As Int32
        For i = 0 To array.Count - 1
            If i = 0 Then
                outarray.Add(startstr + array(i))
            Else
                outarray.Add(outarray(outarray.Count - 1) + " and " + array(i))
            End If

        Next
    End Function


    Public Function MakeStringForJS(ByVal str As String) As String
        str = str.Replace("'", "\'")
        Return str
    End Function

End Class
