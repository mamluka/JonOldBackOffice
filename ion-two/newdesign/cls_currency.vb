Public Class cls_currency
    Inherits iFoundation.cls_logics_sub

    Sub New()
        Me._tablename = "sys_currency"

    End Sub

    Function ReadAllCurrency(ByRef CurrencyArray As ArrayList)
        Dim viewer_sql As New iDac.cls_sql_read
        Dim sSql As String = "select * from sys_currency"

        viewer_sql._connection_string = Me._connection_string
        viewer_sql.transact_read(sSql)

        Dim oData As DataTable = viewer_sql._datatable

        For Each row As DataRow In oData.Rows
            Dim ocurrency_obj As New skl_currency

            Me.ReadCurrencyByRow(row, ocurrency_obj)

            CurrencyArray.Add(ocurrency_obj)
        Next


    End Function


    Function ReadCurrencyByRow(ByVal Row As DataRow, ByRef oDataTable As skl_currency) As Boolean
        On Error GoTo ErrorHandler

        '--- local definitions
        Dim bError As Boolean = False



        '--- Map to Skeleton
        Dim oTmpDataRow As DataRow = Row

        oDataTable.id = oTmpDataRow("id")
        oDataTable.code = oTmpDataRow("code")

        oDataTable.description = oTmpDataRow("description")
        oDataTable.rate = oTmpDataRow("rate")
        oDataTable.symbol = oTmpDataRow("symbol")
        oDataTable.update_date = oTmpDataRow("update_date")

        If oDataTable.symbol = "ILS" Then oDataTable.symbol = "₪"
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


    Function ReadCurrencyByCode(ByVal code As String, ByRef oDataTable As skl_currency) As Boolean
        On Error GoTo ErrorHandler

        '--- local definitions
        Dim bError As Boolean = False

        '--- Get Item
        Dim oReadTransactor As New iDac.cls_T_read
        oReadTransactor._connection_string = Me._connection_string
        oReadTransactor._dbtype = Me._dbtype
        oReadTransactor._tablename = Me._tablename
        oReadTransactor._searchfield = "code"
        Dim SqlString As String = "select * from sys_currency where code = '" + code + "'"
        bError = oReadTransactor.transact_read(SqlString)
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
        oDataTable.code = oTmpDataRow("code")

        oDataTable.description = oTmpDataRow("description")
        oDataTable.rate = oTmpDataRow("rate")
        oDataTable.symbol = oTmpDataRow("symbol")
        oDataTable.update_date = oTmpDataRow("update_date")

        If oDataTable.symbol = "ILS" Then oDataTable.symbol = "₪"
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

    Function UpdateCurrencyById(ByRef oDataTable As skl_currency) As Boolean
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

        oTmpDataRow("rate") = oDataTable.rate



        '--- Assign datatable
        Me._datatable = oTmpDataTable

        Dim oTransactor As New iDac.cls_T_transactor
        oTransactor._connection_string = Me._connection_string
        oTransactor._dbtype = Me._dbtype

        '--- Prepare and load table 1
        Dim oTable1 As New iDac.cls_cll_datatables
        oTable1._datatable = oTmpDataTable
        oTransactor._i_cll_datatables.Add(oTable1)

        bError = oTransactor.transact_update
        If bError Then
            Me._err_number = oTransactor._err_number
            Me._err_description = oTransactor._err_description
            Me._err_source = oTransactor._err_source
            Return True
        End If

        Return False
        Exit Function

ErrorHandler:
        Me._err_number = Err.Number
        Me._err_description = Err.Description
        Me._err_source = Err.Source
        Return True

    End Function

    Function UpdatePlateByCode(ByVal code As String, ByRef oplate As Object) As Boolean

        Dim ocurrency_obj As New skl_currency
        Me.ReadCurrencyByCode(code, ocurrency_obj)

        oplate._sell_price *= ocurrency_obj.rate

    End Function

    Function UpdateCurrencyForUserById(ByVal id As Int32, ByVal code As String) As Boolean
        On Error GoTo ErrorHandler

        '--- local definitions
        Dim bError As Boolean = False

        Dim oTransaction As New iDac.cls_T_transaction
        oTransaction._connection_string = Me._connection_string
        oTransaction._dbtype = Me._dbtype



        Dim oDacCommand As New iDac.cls_T_command
        oDacCommand._connection_string = Me._connection_string
        oDacCommand._dbtype = Me._dbtype
        oDacCommand._transaction = oTransaction._transaction
        oDacCommand._sqlstring = "update dbo.usr_CUSTOMERS set default_currency='" + code + "' where id=" + Convert.ToString(id) + ""
        bError = oDacCommand.transact_command
        If bError Then
            Me._err_number = oDacCommand._err_number
            Me._err_description = oDacCommand._err_description
            Me._err_source = oDacCommand._err_source
            Return True
        End If

        Return False
        Exit Function

ErrorHandler:
        Me._err_number = Err.Number
        Me._err_description = Err.Description
        Me._err_source = Err.Source
        Return True
    End Function

    Function GetCodeByUserId(ByVal userid As Int32) As String
        On Error GoTo ErrorHandler
        Dim bError As Boolean = False

        Dim oTmpDac As New iDac.cls_T_read
        oTmpDac._connection_string = Me._connection_string
        oTmpDac._dbtype = Me._dbtype
        bError = oTmpDac.transact_read("select default_currency from usr_CUSTOMERS where id=" + userid.ToString)
        If bError Then
            Me._err_number = oTmpDac._err_number
            Me._err_description = oTmpDac._err_description
            Me._err_source = oTmpDac._err_source
            Return True
        End If


        '--- Put Datatable into DataView
        Return oTmpDac._datatable.Rows(0)("default_currency")

ErrorHandler:
        Me._err_number = Err.Number
        Me._err_description = Err.Description
        Me._err_source = Err.Source
        Return True
    End Function


    Function GetSymbolByCode(ByVal code As String) As String

        Select Case code
            Case "USD"
                Return "$"
            Case "GBP"
                Return "£"
            Case "EUR"
                Return "€"
            Case "AUD"
                Return "AUD"
            Case "CAD"
                Return "CAD"
            Case "ILS"
                Return "₪"
            Case Else
                Return "$"

        End Select



    End Function

End Class



Public Class skl_currency

    Public id As Int32
    Public code As String = ""
    Public description As String = ""
    Public rate As Decimal = 1
    Public symbol As String = ""
    Public update_date As DateTime = Now

End Class
