Public Class cls_serverstats_lgc
    Inherits ion_resources.cls_base_lgc

    Function insert(ByRef oServerStats As cls_serverstats) As Boolean
        On Error GoTo ErrorHandler

        '--- local definitions
        Dim bError As Boolean = False

        '--- Get Dataset
        Dim oTmpDataset As DataSet = New ion_resources.ds_serverstats()
        Dim oTmpTable As DataTable = oTmpDataset.Tables("sys_SERVERSTATS")

        '--- Assign Order
        Dim oTmpDataRow As DataRow
        oTmpDataRow = oTmpTable.NewRow

        oTmpDataRow("serverup_site") = System.Convert.ToDateTime(oServerStats.serverup_site)
        oTmpDataRow("sessions_site") = System.Convert.ToInt32(oServerStats.sessions_site)
        oTmpDataRow("serverup_back") = System.Convert.ToDateTime(oServerStats.serverup_back)
        oTmpDataRow("sessions_back") = System.Convert.ToInt32(oServerStats.sessions_back)

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
    Function getrec(ByVal nId As Int32, ByRef oServerStats As cls_serverstats) As Boolean
        On Error GoTo ErrorHandler

        '--- local definitions
        Dim bError As Boolean = False

        '--- define Broker
        Dim oTmpBroker As New ion_resources.cls_db_broker()
        oTmpBroker.connection_string = Me.connection_string
        oTmpBroker.dataset = New ion_resources.ds_serverstats()

        bError = oTmpBroker.getrec(nId)
        If bError Then
            Me.error_no = oTmpBroker.error_no
            Me.error_desc = oTmpBroker.error_desc
            Me.error_source = oTmpBroker.error_source
            Return True
            Exit Function
        End If

        '--- Assign the dataset to the instance
        oServerStats.dataset = oTmpBroker.dataset

        '--- Fillup
        Dim oTable As DataTable = oTmpBroker.dataset.Tables("sys_SERVERSTATS")

        '--- Current Record
        Dim oRecord As DataRow = oTable.Rows(0)

        oServerStats.id = oRecord("id")
        oServerStats.serverup_site = oRecord("serverup_site")
        oServerStats.sessions_site = oRecord("sessions_site")
        oServerStats.serverup_back = oRecord("serverup_back")
        oServerStats.sessions_back = oRecord("sessions_back")

        Return False
        Exit Function

ErrorHandler:
        Me.error_no = Err.Number
        Me.error_desc = Err.Description
        Me.error_source = Err.Source
        Return True

    End Function


    '###################################################################################
    Function update(ByRef oServerStats As cls_serverstats) As Boolean
        On Error GoTo ErrorHandler

        '--- local definitions
        Dim bError As Boolean = False

        '--- Get Dataset
        Dim oTmpDataset As DataSet = oServerStats.dataset
        Dim oTmpTable As DataTable = oTmpDataset.Tables("sys_SERVERSTATS")


        '--- Assign Order
        Dim oTmpDataRow As DataRow
        oTmpDataRow = oTmpTable.Rows(0)

        oTmpDataRow("serverup_site") = System.Convert.ToDateTime(oServerStats.serverup_site)
        oTmpDataRow("sessions_site") = System.Convert.ToInt32(oServerStats.sessions_site)
        oTmpDataRow("serverup_back") = System.Convert.ToDateTime(oServerStats.serverup_back)
        oTmpDataRow("sessions_back") = System.Convert.ToInt32(oServerStats.sessions_back)

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
