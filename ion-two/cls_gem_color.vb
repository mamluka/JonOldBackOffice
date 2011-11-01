Public Class cls_gem_color
    Inherits iFoundation.cls_error_connection

    Public conn_string As String
    Public language As String '' the combo stuff
    Public color_str As String

    Function getcolor_byid(ByVal stone_type As Int32, ByVal color_genre As Int32, ByVal color_index As Int32) As Boolean
        On Error GoTo ErrorHandler
        Dim bError As Boolean = False

        Dim tmpArgArray As New ArrayList
        Dim tmpExcludeArray As New ArrayList

        Select Case stone_type
            Case 1 '' emerald
                Select Case color_index
                    Case 1 '' light and medium
                        If color_genre = 1 Then '' grass green
                            tmpArgArray.Add("Medium grass green%")
                            tmpArgArray.Add("Grass%green%light%")
                            Me.color_str = Me.make_sql_bycolor(tmpArgArray)
                        Else
                            tmpArgArray.Add("Medium olive green%")
                            tmpArgArray.Add("olive%green%light%")
                            Me.color_str = Me.make_sql_bycolor(tmpArgArray)
                        End If
                    Case 2 '' regular color
                        If color_genre = 1 Then '' grass green
                            tmpArgArray.Add("Grass green%")
                            tmpExcludeArray.Add("%light%")
                            Me.color_str = Me.make_sql_bycolor(tmpArgArray, tmpExcludeArray)
                        Else
                            tmpArgArray.Add("Olive green%")
                            tmpExcludeArray.Add("%light%")
                            Me.color_str = Me.make_sql_bycolor(tmpArgArray, tmpExcludeArray)
                        End If

                    Case 3 '' fine top
                        If color_genre = 1 Then '' grass green
                            tmpArgArray.Add("Top grass green%")
                            tmpArgArray.Add("Fine grass green%")
                            tmpExcludeArray.Add("%deep%")
                            ''     tmpArgArray.Add("Top grass green%deep%")
                            ''      tmpArgArray.Add("Fine grass green%deep%")
                            Me.color_str = Me.make_sql_bycolor(tmpArgArray, tmpExcludeArray)
                        Else
                            tmpArgArray.Add("Top olive green%")
                            tmpArgArray.Add("Fine olive green%")
                            tmpExcludeArray.Add("%deep%")
                            Me.color_str = Me.make_sql_bycolor(tmpArgArray, tmpExcludeArray)
                        End If
                    Case 4 '' fine top dark darkish
                        If color_genre = 1 Then '' grass green
                            ''   tmpArgArray.Add("Top grass green%")
                            ''   tmpArgArray.Add("Fine grass green%")
                            tmpArgArray.Add("Top grass green%deep%")
                            tmpArgArray.Add("Fine grass green%deep%")
                            Me.color_str = Me.make_sql_bycolor(tmpArgArray)
                        Else
                            ''   tmpArgArray.Add("Top olive green%")
                            'tmpArgArray.Add("Fine olive green%")
                            tmpArgArray.Add("Top olive green%deep%")
                            tmpArgArray.Add("Fine olive green%deep%")
                            Me.color_str = Me.make_sql_bycolor(tmpArgArray)
                        End If
                    Case 5 '' extra - most
                        If color_genre = 1 Then '' grass green
                            tmpArgArray.Add("extra fine grass green%")
                            tmpArgArray.Add("most finest grass green%")
                            tmpExcludeArray.Add("%deep%")
                            ''     tmpArgArray.Add("Top grass green%deep%")
                            ''      tmpArgArray.Add("Fine grass green%deep%")
                            Me.color_str = Me.make_sql_bycolor(tmpArgArray, tmpExcludeArray)
                        Else
                            tmpArgArray.Add("extra fine olive green%")
                            tmpArgArray.Add("most finest olive green%")
                            tmpExcludeArray.Add("%deep%")
                            Me.color_str = Me.make_sql_bycolor(tmpArgArray, tmpExcludeArray)
                        End If
                    Case 6 '' extra - most '' deep
                        If color_genre = 1 Then '' grass green
                            tmpArgArray.Add("extra fine grass green%deep%")
                            tmpArgArray.Add("most finest grass green%deep%")
                            ''     tmpArgArray.Add("Top grass green%deep%")
                            ''      tmpArgArray.Add("Fine grass green%deep%")
                            Me.color_str = Me.make_sql_bycolor(tmpArgArray)
                        Else
                            tmpArgArray.Add("extra fine olive green%deep%")
                            tmpArgArray.Add("most finest olive green%deep%")
                            Me.color_str = Me.make_sql_bycolor(tmpArgArray)
                        End If
                        ''CASE 6 is grade top of the line is not to here it's handeled before
                End Select



            Case 2 '' sapphire
                Select Case color_index
                    Case 1 '' light and medium
                        If color_genre = 1 Then '' royal blue
                            tmpArgArray.Add("Medium royal blue%")
                            tmpArgArray.Add("royal%blue%light%")
                            Me.color_str = Me.make_sql_bycolor(tmpArgArray)
                        Else
                            tmpArgArray.Add("Medium navy blue%")
                            tmpArgArray.Add("navy%blue%light%")
                            Me.color_str = Me.make_sql_bycolor(tmpArgArray)
                        End If
                    Case 2 '' regular color
                        If color_genre = 1 Then '' royal blue
                            tmpArgArray.Add("royal blue%")
                            tmpExcludeArray.Add("%light%")
                            Me.color_str = Me.make_sql_bycolor(tmpArgArray, tmpExcludeArray)
                        Else
                            tmpArgArray.Add("navy blue%")
                            tmpExcludeArray.Add("%light%")
                            Me.color_str = Me.make_sql_bycolor(tmpArgArray, tmpExcludeArray)
                        End If

                    Case 3 '' fine top
                        If color_genre = 1 Then '' royal blue
                            tmpArgArray.Add("Top royal blue%")
                            tmpArgArray.Add("Fine royal blue%")
                            tmpExcludeArray.Add("%deep%")
                            ''     tmpArgArray.Add("Top royal blue%deep%")
                            ''      tmpArgArray.Add("Fine royal blue%deep%")
                            Me.color_str = Me.make_sql_bycolor(tmpArgArray, tmpExcludeArray)
                        Else
                            tmpArgArray.Add("Top navy blue%")
                            tmpArgArray.Add("Fine navy blue%")
                            tmpExcludeArray.Add("%deep%")
                            Me.color_str = Me.make_sql_bycolor(tmpArgArray, tmpExcludeArray)
                        End If
                    Case 4 '' fine top dark darkish
                        If color_genre = 1 Then '' royal blue
                            ''   tmpArgArray.Add("Top royal blue%")
                            ''   tmpArgArray.Add("Fine royal blue%")
                            tmpArgArray.Add("Top royal blue%deep%")
                            tmpArgArray.Add("Fine royal blue%deep%")
                            Me.color_str = Me.make_sql_bycolor(tmpArgArray)
                        Else
                            ''   tmpArgArray.Add("Top navy blue%")
                            'tmpArgArray.Add("Fine navy blue%")
                            tmpArgArray.Add("Top navy blue%deep%")
                            tmpArgArray.Add("Fine navy blue%deep%")
                            Me.color_str = Me.make_sql_bycolor(tmpArgArray)
                        End If
                    Case 5 '' extra - most
                        If color_genre = 1 Then '' royal blue
                            tmpArgArray.Add("extra fine royal blue%")
                            tmpArgArray.Add("most finestst royal blue%")
                            tmpExcludeArray.Add("%deep%")
                            ''     tmpArgArray.Add("Top royal blue%deep%")
                            ''      tmpArgArray.Add("Fine royal blue%deep%")
                            Me.color_str = Me.make_sql_bycolor(tmpArgArray, tmpExcludeArray)
                        Else
                            tmpArgArray.Add("extra fine navy blue%")
                            tmpArgArray.Add("most finest navy blue%")
                            tmpExcludeArray.Add("%deep%")
                            Me.color_str = Me.make_sql_bycolor(tmpArgArray, tmpExcludeArray)
                        End If
                    Case 6 '' extra - most '' deep
                        If color_genre = 1 Then '' royal blue
                            tmpArgArray.Add("extra fine royal blue%deep%")
                            tmpArgArray.Add("most finest royal blue%deep%")
                            ''     tmpArgArray.Add("Top royal blue%deep%")
                            ''      tmpArgArray.Add("Fine royal blue%deep%")
                            Me.color_str = Me.make_sql_bycolor(tmpArgArray)
                        Else
                            tmpArgArray.Add("extra fine navy blue%deep%")
                            tmpArgArray.Add("most finest navy blue%deep%")
                            Me.color_str = Me.make_sql_bycolor(tmpArgArray)
                        End If
                        ''CASE 6 is grade top of the line is not to here it's handeled before
                End Select


            Case 3 '' pink sapphire
                Select Case color_index
                    Case 1 '' light and medium

                        tmpArgArray.Add("Pink%")
                        tmpArgArray.Add("Pink%light%")
                        Me.color_str = Me.make_sql_bycolor(tmpArgArray)

                    Case 2 '' regular color
                        tmpArgArray.Add("Top pink%")
                        tmpArgArray.Add("Fine pink%")
                        tmpExcludeArray.Add("%deep%")
                        Me.color_str = Me.make_sql_bycolor(tmpArgArray)



                    Case 3 '' fine top
                        tmpArgArray.Add("Top pink%deep")
                        tmpArgArray.Add("Fine pink%deep")
                        ''tmpExcludeArray.Add("%deep%")
                        ''     tmpArgArray.Add("Top royal blue%deep%")
                        ''      tmpArgArray.Add("Fine royal blue%deep%")
                        Me.color_str = Me.make_sql_bycolor(tmpArgArray, tmpExcludeArray)

                    Case 4 '' fine top dark darkish
                        ''   tmpArgArray.Add("Top royal blue%")
                        ''   tmpArgArray.Add("Fine royal blue%")
                        tmpArgArray.Add("extra fine pink%")
                        tmpArgArray.Add("most finest pink%")
                        tmpExcludeArray.Add("%deep%")
                        Me.color_str = Me.make_sql_bycolor(tmpArgArray)

                    Case 5 '' extra - most '' deep
                        tmpArgArray.Add("extra fine pink%deep%")
                        tmpArgArray.Add("most finest pink%deep%")
                        ''     tmpArgArray.Add("Top royal blue%deep%")
                        ''      tmpArgArray.Add("Fine royal blue%deep%")
                        Me.color_str = Me.make_sql_bycolor(tmpArgArray)

                        ''CASE 6 is grade top of the line is not to here it's handeled before
                    Case 6
                        Me.color_str = "(grade like 'Top of the line') and "
                End Select


            Case 4 '' yellow sapphire
                Select Case color_index
                    Case 1 '' light and medium
                        If color_genre = 1 Then '' lemon yellow
                            tmpArgArray.Add("Medium lemon yellow%")
                            tmpArgArray.Add("lemon%yellow%light%")
                            Me.color_str = Me.make_sql_bycolor(tmpArgArray)
                        Else
                            tmpArgArray.Add("Medium golden yellow%")
                            tmpArgArray.Add("golden%yellow%light%")
                            Me.color_str = Me.make_sql_bycolor(tmpArgArray)
                        End If
 

                    Case 2 '' fine top
                        If color_genre = 1 Then '' lemon yellow
                            tmpArgArray.Add("Top lemon yellow%")
                            tmpArgArray.Add("Fine lemon yellow%")
                            tmpExcludeArray.Add("%deep%")
                            ''     tmpArgArray.Add("Top lemon yellow%deep%")
                            ''      tmpArgArray.Add("Fine lemon yellow%deep%")
                            Me.color_str = Me.make_sql_bycolor(tmpArgArray, tmpExcludeArray)
                        Else
                            tmpArgArray.Add("Top golden yellow%")
                            tmpArgArray.Add("Fine golden yellow%")
                            tmpExcludeArray.Add("%deep%")
                            Me.color_str = Me.make_sql_bycolor(tmpArgArray, tmpExcludeArray)
                        End If
                    Case 3 '' fine top dark darkish
                        If color_genre = 1 Then '' lemon yellow
                            ''   tmpArgArray.Add("Top lemon yellow%")
                            ''   tmpArgArray.Add("Fine lemon yellow%")
                            tmpArgArray.Add("Top lemon yellow%deep%")
                            tmpArgArray.Add("Fine lemon yellow%deep%")
                            Me.color_str = Me.make_sql_bycolor(tmpArgArray)
                        Else
                            ''   tmpArgArray.Add("Top golden  yellow%")
                            'tmpArgArray.Add("Fine golden  yellow%")
                            tmpArgArray.Add("Top golden yellow%deep%")
                            tmpArgArray.Add("Fine golden yellow%deep%")
                            Me.color_str = Me.make_sql_bycolor(tmpArgArray)
                        End If
                    Case 4 '' extra - most
                        If color_genre = 1 Then '' lemon yellow
                            tmpArgArray.Add("extra fine lemon yellow%")
                            tmpArgArray.Add("most finest lemon yellow%")
                            tmpExcludeArray.Add("%deep%")
                            ''     tmpArgArray.Add("Top lemon yellow%deep%")
                            ''      tmpArgArray.Add("Fine lemon yellow%deep%")
                            Me.color_str = Me.make_sql_bycolor(tmpArgArray, tmpExcludeArray)
                        Else
                            tmpExcludeArray.Add("%deep%")
                            tmpArgArray.Add("extra fine golden yellow%")
                            tmpArgArray.Add("most finest golden yellow%")
                            Me.color_str = Me.make_sql_bycolor(tmpArgArray, tmpExcludeArray)
                        End If
                    Case 5 '' extra - most '' deep
                        If color_genre = 1 Then '' lemon yellow
                            tmpArgArray.Add("extra fine lemon yellow%deep%")
                            tmpArgArray.Add("most finest lemon yellow%deep%")
                            ''     tmpArgArray.Add("Top lemon yellow%deep%")
                            ''      tmpArgArray.Add("Fine lemon yellow%deep%")
                            Me.color_str = Me.make_sql_bycolor(tmpArgArray)
                        Else
                            tmpArgArray.Add("extra fine golden yellow%deep%")
                            tmpArgArray.Add("most finest golden yellow%deep%")
                            Me.color_str = Me.make_sql_bycolor(tmpArgArray)
                        End If
                    Case 6
                        Me.color_str = "(grade like 'Top of the line') and "
                        ''CASE 6 is grade top of the line is not to here it's handeled before
                End Select

            Case 5 '' ruby

                Select Case color_index
                    Case 1 '' light and medium
                        If color_genre = 1 Then '' pigeon blood red
                            tmpArgArray.Add("Medium pigeon blood red%")
                            tmpArgArray.Add("pigeon blood%light%")
                            Me.color_str = Me.make_sql_bycolor(tmpArgArray)
                        Else
                            tmpArgArray.Add("Medium Red%")
                            tmpArgArray.Add("light%")
                            Me.color_str = Me.make_sql_bycolor(tmpArgArray)
                        End If
                    Case 2 '' regular color
                        If color_genre = 1 Then '' pigeon blood red
                            tmpArgArray.Add("pigeon blood red%")
                            tmpExcludeArray.Add("%light%")
                            Me.color_str = Me.make_sql_bycolor(tmpArgArray, tmpExcludeArray)
                        Else
                            tmpArgArray.Add("Red%")
                            tmpExcludeArray.Add("%pigeon%")
                            tmpExcludeArray.Add("%light%")
                            Me.color_str = Me.make_sql_bycolor(tmpArgArray, tmpExcludeArray)
                        End If

                    Case 3 '' fine top
                        If color_genre = 1 Then '' pigeon blood red
                            tmpArgArray.Add("Top pigeon blood red%")
                            tmpArgArray.Add("Fine pigeon blood red%")
                            tmpExcludeArray.Add("%deep%")
                            ''     tmpArgArray.Add("Top pigeon blood red%deep%")
                            ''      tmpArgArray.Add("Fine pigeon blood red%deep%")
                            Me.color_str = Me.make_sql_bycolor(tmpArgArray, tmpExcludeArray)
                        Else
                            tmpArgArray.Add("Top red%")
                            tmpArgArray.Add("Fine red%")
                            tmpExcludeArray.Add("%pigeon%")
                            tmpExcludeArray.Add("%deep%")
                            Me.color_str = Me.make_sql_bycolor(tmpArgArray, tmpExcludeArray)
                        End If
                    Case 4 '' fine top dark darkish
                        If color_genre = 1 Then '' pigeon blood red
                            ''   tmpArgArray.Add("Top pigeon blood red%")
                            ''   tmpArgArray.Add("Fine pigeon blood red%")
                            tmpArgArray.Add("Top pigeon blood red%deep%")
                            tmpArgArray.Add("Fine pigeon blood red%deep%")
                            Me.color_str = Me.make_sql_bycolor(tmpArgArray)
                        Else
                            ''   tmpArgArray.Add("Top navy blue%")
                            'tmpArgArray.Add("Fine navy blue%")
                            Me.color_str = Me.make_sql_bycolor(tmpArgArray)
                        End If
                    Case 5 '' extra - most
                        If color_genre = 1 Then '' pigeon blood red
                            tmpArgArray.Add("extra fine pigeon blood red%")
                            tmpArgArray.Add("most finest pigeon blood red%")
                            ''     tmpArgArray.Add("Top pigeon blood red%deep%")
                            ''      tmpArgArray.Add("Fine pigeon blood red%deep%")
                            tmpExcludeArray.Add("%deep%")
                            Me.color_str = Me.make_sql_bycolor(tmpArgArray, tmpExcludeArray)
                        Else
                            tmpArgArray.Add("extra fine red%")
                            tmpArgArray.Add("most finest red%")
                            tmpExcludeArray.Add("%deep%")
                            Me.color_str = Me.make_sql_bycolor(tmpArgArray, tmpExcludeArray)
                        End If
                    Case 6 '' extra - most '' deep
                        If color_genre = 1 Then '' pigeon blood red
                            tmpArgArray.Add("extra fine pigeon blood red%deep%")
                            tmpArgArray.Add("most finest pigeon blood red%deep%")
                            ''     tmpArgArray.Add("Top pigeon blood red%deep%")
                            ''      tmpArgArray.Add("Fine pigeon blood red%deep%")
                            Me.color_str = Me.make_sql_bycolor(tmpArgArray)
                        Else
                            tmpArgArray.Add("extra fine navy blue%deep%")
                            tmpArgArray.Add("most finest navy blue%deep%")
                            Me.color_str = Me.make_sql_bycolor(tmpArgArray)
                        End If
                        ''CASE 6 is grade top of the line is not to here it's handeled before
                End Select
        End Select

        'If (stone_type = 5) And (color_genre = 2) Then

        '    Me.color_str = Me.color_str.Insert(0, "(")
        '    Me.color_str += " and (colorfrom not like '%pigeon%'))"

        'End If

        'Dim rtablecoll As New Collection

        'Dim oDG_search As New iDac.cls_sql_read

        'oDG_search._connection_string = Me.conn_string '' Application("connection")._connection_string
        'oDG_search._tablename = "inv_COLOR_GEM"

        'Dim sqlstr As String

        'sqlstr = "select id ,lang" + Me.language + "_longdescr  from inv_COLOR_GEM where "
        'If color_genre = 1 Then
        '    Select Case stone_type
        '        Case 1
        '            sqlstr += "lang" + Me.language + "_longdescr like '%GRASS GREEN%' ORDER BY ID"
        '        Case 2
        '            sqlstr += "lang" + Me.language + "_longdescr like '%ROYAL BLUE%' ORDER BY ID"
        '        Case 3
        '            sqlstr += "lang" + Me.language + "_longdescr like '%Pink%' ORDER BY ID"
        '        Case 4
        '            sqlstr += "lang" + Me.language + "_longdescr like '%LEMON YELLOW%' ORDER BY ID"
        '        Case 5
        '            sqlstr += "lang" + Me.language + "_longdescr like '%pigeon blood RED%' ORDER BY ID"
        '    End Select
        'Else
        '    Select Case stone_type
        '        Case 1
        '            sqlstr += "lang" + Me.language + "_longdescr like '%OLIVE GREEN%' ORDER BY ID"
        '        Case 2
        '            sqlstr += "lang" + Me.language + "_longdescr like '%NAVY BLUE%' ORDER BY ID"
        '        Case 3
        '            sqlstr += "lang" + Me.language + "_longdescr like '%Pink%' ORDER BY ID"
        '        Case 4
        '            sqlstr += "lang" + Me.language + "_longdescr like '%GOLDEN YELLOW%' ORDER BY ID"
        '        Case 5
        '            sqlstr += "(lang" + Me.language + "_longdescr like '%RED%') and ((lang" + Me.language + "_longdescr not like '%pigeon blood%') ORDER BY ID"
        '    End Select

        'End If

        'oDG_search.transact_read(sqlstr)

        'Dim oData As DataTable = oDG_search._datatable

        'Me.color_str = oData.Rows(color_index).Item(1)



        Return False

ErrorHandler:
        Me._err_number = Err.Number
        Me._err_description = Err.Description
        Me._err_source = Err.Source
        Return True

    End Function
    Function make_sql_bycolor(ByVal str As ArrayList, Optional ByVal excludestr As ArrayList = Nothing) As String
        Dim tmpstr As String

        Dim i As Int32
        tmpstr = "("
        For i = 0 To str.Count - 1
            If i = str.Count - 1 Then
                tmpstr += " (lower(colorfrom) like '" + str.Item(i).tolower + "'))"
                Exit For

            End If
            tmpstr += "(lower(colorfrom) like '" + str.Item(i).tolower + "') or "

        Next

        If Not excludestr Is Nothing Then
            tmpstr = tmpstr.Insert(1, "(")
            tmpstr += " and ("

            For i = 0 To excludestr.Count - 1
                If i = excludestr.Count - 1 Then
                    tmpstr += "(lower(colorfrom) not like '" + excludestr.Item(i).tolower + "')))"
                    Exit For
                End If
                tmpstr += "(lower(colorfrom) not like '" + excludestr.Item(i).tolower + "') or "

            Next

        End If


        make_sql_bycolor = tmpstr + " and "

    End Function
End Class
