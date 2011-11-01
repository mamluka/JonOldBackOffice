Module inventory_functions

    Public Function UpdatePictureRecord(ByVal nId, ByVal cPictureName, ByVal nMode, ByVal cConnectionString) As Boolean
        On Error GoTo ErrorHandler

        '--- Define local vars
        Dim bError As Boolean = False


        '--- Define Connection String
        Dim objConn As New SqlClient.SqlConnection(cConnectionString)
        Dim cSQLstring As SqlClient.SqlCommand

        Select Case nMode
            Case 1         '--- Picture
                cSQLstring = New SqlClient.SqlCommand("update inv_inventory set picture_name = '" & cPictureName & "' where id=" & nId, objConn)
            Case 2         '--- HiRes Picture
                cSQLstring = New SqlClient.SqlCommand("update inv_inventory set picture_hires_name = '" & cPictureName & "' where id=" & nId, objConn)
            Case 3         '--- Icon
                cSQLstring = New SqlClient.SqlCommand("update inv_inventory set icon_name = '" & cPictureName & "' where id=" & nId, objConn)
            Case 4         '--- Movie
                cSQLstring = New SqlClient.SqlCommand("update inv_inventory set movie_name = '" & cPictureName & "' where id=" & nId, objConn)
            Case 5         '--- Certificate
                cSQLstring = New SqlClient.SqlCommand("update inv_inventory set certificate_name = '" & cPictureName & "' where id=" & nId, objConn)
            Case 6            '--- Gallery
                cSQLstring = New SqlClient.SqlCommand("update inv_inventory set gallery_name = '" & cPictureName & "' where id=" & nId, objConn)
            Case 7            '--- Banner
                cSQLstring = New SqlClient.SqlCommand("update inv_inventory set banner_name = '" & cPictureName & "' where id=" & nId, objConn)

        End Select
        objConn.Open()

        Dim dr_Reader As SqlClient.SqlDataReader = cSQLstring.ExecuteReader()

        If dr_Reader.RecordsAffected <> 1 Then
            bError = True
        End If

        objConn.Close()
        dr_Reader.Close()

        Return bError
        Exit Function


ErrorHandler:
        Return True

    End Function

    Public Function UpdateMetalMediaRecord(ByVal nId As Int32, ByVal type As String, ByVal cConnectionString As String) As Boolean
        On Error GoTo ErrorHandler

        '--- Define local vars
        Dim bError As Boolean = False


        '--- Define Connection String
        Dim objConn As New SqlClient.SqlConnection(cConnectionString)
        Dim cSQLstring As SqlClient.SqlCommand

        Select Case type
            Case "yg"         '--- Picture
                cSQLstring = New SqlClient.SqlCommand("update inv_inventory set has_yellow_gold = 1 where id=" & nId, objConn)
            Case "wg"       '--- HiRes Picture
                cSQLstring = New SqlClient.SqlCommand("update inv_inventory set has_white_gold = 1  where id=" & nId, objConn)

        End Select
        objConn.Open()

        Dim dr_Reader As SqlClient.SqlDataReader = cSQLstring.ExecuteReader()

        If dr_Reader.RecordsAffected <> 1 Then
            bError = True
        End If

        objConn.Close()
        dr_Reader.Close()

        Return bError
        Exit Function

ErrorHandler:
        Return True
    End Function

    Public Function UpdateMovieRecord(ByVal nId As Int32, ByVal type As String, ByVal cConnectionString As String) As Boolean
        On Error GoTo ErrorHandler

        '--- Define local vars
        Dim bError As Boolean = False


        '--- Define Connection String
        Dim objConn As New SqlClient.SqlConnection(cConnectionString)
        Dim cSQLstring As SqlClient.SqlCommand


        cSQLstring = New SqlClient.SqlCommand("update inv_inventory set has_movie = 1 where id=" & nId, objConn)
          


        objConn.Open()

        Dim dr_Reader As SqlClient.SqlDataReader = cSQLstring.ExecuteReader()

        If dr_Reader.RecordsAffected <> 1 Then
            bError = True
        End If

        objConn.Close()
        dr_Reader.Close()

        Return bError
        Exit Function

ErrorHandler:
        Return True
    End Function



End Module
