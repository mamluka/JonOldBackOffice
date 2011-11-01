Public Class cls_help_lgc
    Inherits ion_resources.cls_base_lgc

    Function insert(ByRef oHelp As cls_help) As Boolean
        On Error GoTo ErrorHandler

        '--- local definitions
        Dim bError As Boolean = False

        '--- Get Dataset
        Dim oTmpDataset As DataSet = New ion_resources.ds_help()
        Dim oTmpTable As DataTable = oTmpDataset.Tables("sys_HELP")

        '--- Assign Order
        Dim oTmpDataRow As DataRow
        oTmpDataRow = oTmpTable.NewRow

        oTmpDataRow("keyword") = System.Convert.ToString(oHelp.keyword)
        oTmpDataRow("help_header") = System.Convert.ToString(oHelp.help_header)
        oTmpDataRow("help_text") = System.Convert.ToString(oHelp.text)

        'oTmpDataRow("active") = True
        'oTmpDataRow("deleted") = False
        'oTmpDataRow("u_date_created") = Date.Now
        'oTmpDataRow("u_user_created") = System.Convert.ToString(oHelp.user_created)
        'oTmpDataRow("u_date_modified") = Date.Now
        'oTmpDataRow("u_user_modified") = System.Convert.ToString(oHelp.user_created)
        'oTmpDataRow("u_ip_modified") = System.Convert.ToString(oHelp.ip)

        oTmpTable.Rows.Add(oTmpDataRow)


        '--- define Broker
        Dim oTmpBroker As New ion_resources.cls_db_broker()
        oTmpBroker.dataset = oTmpDataset
        oTmpBroker.connection_string = Me.connection_string
        bError = oTmpBroker.insert
        If bError Then
            Me.error_no = oTmpBroker.error_no
            Me.error_desc = oTmpBroker.error_desc
            Me.error_source = oTmpBroker.error_source
            Return True
            Exit Function
        End If

        '--- Receive 
        Me.id = oTmpBroker.id

        oTmpBroker = Nothing

        Return False
        Exit Function

ErrorHandler:
        Me.error_no = Err.Number
        Me.error_desc = Err.Description
        Me.error_source = Err.Source
        Return True

    End Function


    '###################################################################################
    Function getrec(ByVal nId As Int32, ByRef oHelp As cls_help) As Boolean
        On Error GoTo ErrorHandler

        '--- local definitions
        Dim bError As Boolean = False

        '--- define Broker
        Dim oTmpBroker As New ion_resources.cls_db_broker()
        oTmpBroker.connection_string = Me.connection_string
        oTmpBroker.dataset = New ion_resources.ds_help()

        bError = oTmpBroker.getrec(nId)
        If bError Then
            Me.error_no = oTmpBroker.error_no
            Me.error_desc = oTmpBroker.error_desc
            Me.error_source = oTmpBroker.error_source
            Return True
            Exit Function
        End If

        '--- Assign the dataset to the instance
        oHelp.dataset = oTmpBroker.dataset

        '--- Fillup
        Dim oTable As DataTable = oTmpBroker.dataset.Tables("sys_HELP")

        '--- Current Record
        Dim oRecord As DataRow = oTable.Rows(0)

        oHelp.id = oRecord("id")
        oHelp.keyword = oRecord("keyword")
        oHelp.help_header = oRecord("help_header")
        oHelp.text = oRecord("help_text")

        'oHelp.active = oRecord("active")
        'oHelp.deleted = oRecord("deleted")
        'oHelp.date_created = oRecord("u_date_created")
        'oHelp.date_modified = oRecord("u_date_modified")
        'oHelp.user_created = oRecord("u_user_created")
        'oHelp.user_modified = oRecord("u_user_modified")
        'oHelp.ip = oRecord("u_ip_modified")


        Return False
        Exit Function

ErrorHandler:
        Me.error_no = Err.Number
        Me.error_desc = Err.Description
        Me.error_source = Err.Source
        Return True

    End Function


    '###################################################################################
    Function update(ByRef oHelp As cls_help) As Boolean
        On Error GoTo ErrorHandler

        '--- local definitions
        Dim bError As Boolean = False

        '--- Get Dataset
        Dim oTmpDataset As DataSet = oHelp.dataset
        Dim oTmpTable As DataTable = oTmpDataset.Tables("sys_HELP")


        '--- Assign Order
        Dim oTmpDataRow As DataRow
        oTmpDataRow = oTmpTable.Rows(0)

        oTmpDataRow("keyword") = System.Convert.ToString(oHelp.keyword)
        oTmpDataRow("help_header") = System.Convert.ToString(oHelp.help_header)
        oTmpDataRow("help_text") = System.Convert.ToString(oHelp.text)

        'oTmpDataRow("active") = True
        'oTmpDataRow("deleted") = False
        'oTmpDataRow("u_date_created") = Date.Now
        'oTmpDataRow("u_user_created") = System.Convert.ToString(oHelp.user_created)
        'oTmpDataRow("u_date_modified") = Date.Now
        'oTmpDataRow("u_user_modified") = System.Convert.ToString(oHelp.user_created)
        'oTmpDataRow("u_ip_modified") = System.Convert.ToString(oHelp.ip)


        '--- define broker object
        Dim oTmpBroker As New ion_resources.cls_db_broker()
        oTmpBroker.dataset = oTmpDataset
        oTmpBroker.connection_string = Me.connection_string
        bError = oTmpBroker.update()
        If bError Then
            Me.error_no = Me.error_no
            Me.error_desc = Me.error_desc
            Me.error_source = Me.error_source
            Return True
            Exit Function
        End If

        '--- Receive 
        Me.id = oTmpBroker.id

        oTmpBroker = Nothing

        Return False
        Exit Function

ErrorHandler:
        Me.error_no = Err.Number
        Me.error_desc = Err.Description
        Me.error_source = Err.Source
        Return True

    End Function



End Class
