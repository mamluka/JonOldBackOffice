Public Class cls_functions_slogging
    Inherits ion_resources.cls_base_general


    Public Function compare_agent(ByVal cCompareString As String, ByRef nSpider_id As Int32) As Boolean
        On Error GoTo ErrorHandler

        '--- Define local vars
        Dim bError As Boolean = False

        '--- Define Connection String
        Dim bConnection_open As Boolean = False
        Dim bDatareader_open As Boolean = False
        Dim cSQL As String
        cSQL = "select * from sys_USERAGENT"
        Dim objConn As New SqlClient.SqlConnection(Me.connection_string)
        Dim cSQLstring As SqlClient.SqlCommand = New SqlClient.SqlCommand(cSQL, objConn)
        objConn.Open()
        bConnection_open = True

        Dim dr_Reader As SqlClient.SqlDataReader = cSQLstring.ExecuteReader()
        bDatareader_open = True

        Dim cSearchKey As String
        While dr_Reader.Read()

            cSearchKey = dr_Reader.Item("searchkey")
            If InStr(1, LCase(cCompareString), Trim(LCase(cSearchKey)), CompareMethod.Text) > 0 Then
                nSpider_id = dr_Reader.Item("id")
                Exit While
            End If


        End While

        objConn.Close()
        dr_Reader.Close()

        Return False
        Exit Function

ErrorHandler:
        If bDatareader_open Then
            dr_Reader.Close()
        End If
        If bConnection_open Then
            objConn.Close()
        End If

        '--- register the error
        Me.error_no = Err.Number
        Me.error_desc = Err.Description
        Me.error_source = Err.Source
        Return True

    End Function


End Class
