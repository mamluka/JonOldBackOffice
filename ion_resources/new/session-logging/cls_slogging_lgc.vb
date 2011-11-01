Public Class cls_slogging_lgc
    Inherits ion_resources.cls_base_lgc

    Function insert(ByVal nDB As Int16, ByVal oSlogging As cls_slogging) As Boolean
        On Error GoTo ErrorHandler

        '--- local definitions
        Dim bError As Boolean = False

        '--- Get Dataset
        Dim oTmpDataset As DataSet = New ion_resources.ds_slogging()
        Dim oTmpTable As DataTable

        If nDB = 1 Then '-- SITE
            oTmpTable = oTmpDataset.Tables("log_SESSIONS_site")

        Else
            oTmpTable = oTmpDataset.Tables("log_SESSIONS_back")

        End If


        '--- Assign Order
        Dim oTmpDataRow As DataRow
        oTmpDataRow = oTmpTable.NewRow


        oTmpDataRow("sessionid") = System.Convert.ToString(oSlogging.sessionid)
        oTmpDataRow("date_time") = System.Convert.ToDateTime(oSlogging.date_time)
        oTmpDataRow("refferer_url") = System.Convert.ToString(oSlogging.refferer_url)
        oTmpDataRow("browser_language") = System.Convert.ToString(oSlogging.browser_language)
        oTmpDataRow("user_id") = System.Convert.ToInt32(oSlogging.user_id)
        oTmpDataRow("user_name") = System.Convert.ToString(oSlogging.user_name)
        oTmpDataRow("user_email") = System.Convert.ToString(oSlogging.user_email)
        oTmpDataRow("last_visit") = System.Convert.ToDateTime(oSlogging.last_visit)
        oTmpDataRow("visit_count") = System.Convert.ToInt32(oSlogging.visit_count)
        oTmpDataRow("remote_ip") = System.Convert.ToString(oSlogging.remote_ip)
        oTmpDataRow("campaign") = System.Convert.ToString(oSlogging.campaign)
        oTmpDataRow("user_agent") = System.Convert.ToString(oSlogging.user_agent)
        oTmpDataRow("spider_id") = System.Convert.ToInt32(oSlogging.spider_id)

        oTmpTable.Rows.Add(oTmpDataRow)

        '--- define Broker
        Dim oTmpBroker As New ion_resources.cls_slogging_brk()
        oTmpBroker.dataset = oTmpDataset
        oTmpBroker.connection_string = Me.connection_string
        If nDB = 1 Then
            oTmpBroker.tablename = "log_SESSIONS_site"

        Else
            oTmpBroker.tablename = "log_SESSIONS_back"
        End If

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
