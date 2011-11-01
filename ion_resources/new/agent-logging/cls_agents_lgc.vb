Public Class cls_agents_lgc
    Inherits ion_resources.cls_base_lgc

    Function insert(ByVal oAgents As cls_agents) As Boolean
        On Error GoTo ErrorHandler

        '--- local definitions
        Dim bError As Boolean = False

        '--- Get Dataset
        Dim oTmpDataset As DataSet = New ion_resources.ds_agents()
        Dim oTmpTable As DataTable
        oTmpTable = oTmpDataset.Tables("log_AGENTS")


        '--- Assign Order
        Dim oTmpDataRow As DataRow
        oTmpDataRow = oTmpTable.NewRow


        oTmpDataRow("sessionid") = System.Convert.ToString(oAgents.sessionid)
        oTmpDataRow("date_time") = System.Convert.ToDateTime(oAgents.date_time)
        oTmpDataRow("refferer") = System.Convert.ToString(oAgents.refferer)
        oTmpDataRow("lang") = System.Convert.ToString(oAgents.lang)
        oTmpDataRow("remote_ip") = System.Convert.ToString(oAgents.remote_ip)
        oTmpDataRow("remote_name") = System.Convert.ToString(oAgents.remote_name)
        oTmpDataRow("remote_browser") = System.Convert.ToString(oAgents.remote_browser)
        oTmpDataRow("user_agent") = System.Convert.ToString(oAgents.user_agent)
        oTmpDataRow("spider_id") = System.Convert.ToInt32(oAgents.spider_id)

        oTmpTable.Rows.Add(oTmpDataRow)

        '--- define Broker
        Dim oTmpBroker As New ion_resources.cls_db_broker()
        oTmpBroker.dataset = oTmpDataset
        oTmpBroker.connection_string = Me.connection_string
        oTmpBroker.tablename = "log_AGENTS"


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



End Class
