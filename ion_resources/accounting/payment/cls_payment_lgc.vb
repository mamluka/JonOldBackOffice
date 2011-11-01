Public Class cls_payment_lgc

	Private m_error_no As Integer
	Private m_error_desc As String
	Private m_error_source As String
	Private m_connection_string As String
	Private m_payment_id As Int32

    '####################################################################################
    Function insert_payment(ByRef oPayment As cls_payment) As Boolean
        'On Error GoTo ErrorHandler

        '--- local definitions
        Dim bError As Boolean = False

        '--- Get Dataset
        Dim oTmpDataset As DataSet = New ion_resources.ds_cashflow()
        Dim oTmpPayments As DataTable = oTmpDataset.Tables("acc_CASHFLOW")

        '--- Assign Order
        Dim oTmpDataRow As DataRow
        oTmpDataRow = oTmpPayments.NewRow

        'oTmpDataRow("id") = 1
        oTmpDataRow("payment_type") = System.Convert.ToInt16(oPayment.payment_type)
        oTmpDataRow("payment_date") = Date.Now

        oTmpDataRow("order_id") = System.Convert.ToInt32(oPayment.order_id)
        oTmpDataRow("user_id") = System.Convert.ToInt32(oPayment.user_id)
        oTmpDataRow("master") = System.Convert.ToBoolean(oPayment.master)

        oTmpDataRow("cc_type_id") = System.Convert.ToInt32(oPayment.cc_type_id)
        oTmpDataRow("cc_name") = System.Convert.ToString(oPayment.cc_name)
        oTmpDataRow("cc_number") = System.Convert.ToString(oPayment.cc_number)
        oTmpDataRow("cc_cvv") = System.Convert.ToString(oPayment.cc_cvv)
        oTmpDataRow("cc_exp_year") = System.Convert.ToString(oPayment.cc_exp_year)
        oTmpDataRow("cc_exp_month") = System.Convert.ToString(oPayment.cc_exp_month)
        oTmpDataRow("cc_user_ssn") = System.Convert.ToString(oPayment.cc_user_ssn)
        oTmpDataRow("cc_confirmation") = System.Convert.ToString(oPayment.cc_confermation)
        oTmpDataRow("cc_clubmember") = System.Convert.ToBoolean(oPayment.cc_clubmember)
        oTmpDataRow("cc_cleared") = System.Convert.ToBoolean(oPayment.cc_cleared)
        oTmpDataRow("cc_batch") = System.Convert.ToString(oPayment.cc_batch)

        oTmpDataRow("mt_bank") = System.Convert.ToString(oPayment.mt_bank)
        oTmpDataRow("mt_name") = System.Convert.ToString(oPayment.mt_name)
        oTmpDataRow("mt_account") = System.Convert.ToString(oPayment.mt_account)
        oTmpDataRow("mt_code") = System.Convert.ToString(oPayment.mt_code)

        oTmpDataRow("cq_bank") = System.Convert.ToString(oPayment.cq_bank)
        oTmpDataRow("cq_name") = System.Convert.ToString(oPayment.cq_name)
        oTmpDataRow("cq_account") = System.Convert.ToString(oPayment.cq_account)
        oTmpDataRow("cq_date") = System.Convert.ToDateTime(oPayment.cq_date)

        oTmpDataRow("received") = System.Convert.ToBoolean(oPayment.received)
        oTmpDataRow("received_date") = System.Convert.ToDateTime(oPayment.received_date)
        oTmpDataRow("approved") = System.Convert.ToBoolean(oPayment.approved)
        oTmpDataRow("approved_date") = System.Convert.ToDateTime(oPayment.approved_date)
        oTmpDataRow("amount_total") = System.Convert.ToDecimal(oPayment.amount_total)
        oTmpDataRow("amount_interest") = System.Convert.ToDecimal(oPayment.amount_interest)
        oTmpDataRow("amount_actual") = System.Convert.ToDecimal(oPayment.amount_actual)
        oTmpDataRow("amount_costs") = System.Convert.ToDecimal(oPayment.amount_costs)
        oTmpDataRow("LastModify_Date") = Date.Now
        oTmpDataRow("LastModify_User") = System.Convert.ToString(oPayment.LastModify_User)
        oTmpDataRow("LastModify_User_Id") = System.Convert.ToInt32(oPayment.LastModify_User_id)
        oTmpDataRow("notes") = System.Convert.ToString(oPayment.notes)

        oTmpPayments.Rows.Add(oTmpDataRow)

        '--- define system object
        Dim oSystem As ion_resources.cls_system = New ion_resources.cls_system()
        oSystem.connection_string = Me.connection_string
        oSystem.dataset = oTmpDataset

        Dim oTmpBroker As New ion_resources.cls_payment_brk()
        bError = oTmpBroker.insert_payment(oSystem)
        If bError Then
            Me.error_no = oSystem.error_no
            Me.error_desc = oSystem.error_desc
            Me.error_source = oSystem.error_source
            Return True
            Exit Function
        End If

        '--- Receive 
        Me.payment_id = oTmpBroker.payment_id


        oTmpBroker = Nothing
        oSystem = Nothing

        Return False
        Exit Function

ErrorHandler:
        Me.error_no = Err.Number
        Me.error_desc = Err.Description
        Me.error_source = Err.Source
        Return True

    End Function


    '####################################################################################
    Function get_payment(ByVal nPaymentId As Int32, ByRef oPayment As cls_payment) As Boolean
        'On Error GoTo ErrorHandler

        '--- local definitions
        Dim bError As Boolean = False

        '--- define system object
        Dim oSystem As ion_resources.cls_system = New ion_resources.cls_system()
        oSystem.connection_string = Me.connection_string
        oSystem.dataset = New ion_resources.ds_cashflow()


        Dim oTmpBroker As New ion_resources.cls_payment_brk()
        bError = oTmpBroker.get_payment(nPaymentId, oSystem)
        If bError Then
            Me.error_no = oSystem.error_no
            Me.error_desc = oSystem.error_desc
            Me.error_source = oSystem.error_source
            Return True
            Exit Function
        End If

        oPayment.payment_dataset = oSystem.dataset
        Dim oPayments As DataTable = oSystem.dataset.Tables("acc_CASHFLOW")

        '--- Current Record
        Dim oPayment_record As DataRow = oPayments.Rows(0)

        oPayment.id = oPayment_record("id")
        oPayment.payment_type = oPayment_record("payment_type")
        oPayment.payment_date = oPayment_record("payment_date")
        oPayment.order_id = oPayment_record("order_id")
        oPayment.user_id = oPayment_record("user_id")
        oPayment.cc_type_id = oPayment_record("cc_type_id")
        oPayment.cc_name = oPayment_record("cc_name")
        oPayment.cc_number = oPayment_record("cc_number")
        oPayment.cc_cvv = oPayment_record("cc_cvv")
        oPayment.cc_exp_year = oPayment_record("cc_exp_year")
        oPayment.cc_exp_month = oPayment_record("cc_exp_month")
        oPayment.cc_user_ssn = oPayment_record("cc_user_ssn")
        oPayment.cc_confermation = oPayment_record("cc_confirmation")
        oPayment.cc_clubmember = oPayment_record("cc_clubmember")
        oPayment.cc_cleared = oPayment_record("cc_cleared")
        oPayment.cc_batch = oPayment_record("cc_batch")

        oPayment.mt_bank = oPayment_record("mt_bank")
        oPayment.mt_name = oPayment_record("mt_name")
        oPayment.mt_account = oPayment_record("mt_account")
        oPayment.mt_code = oPayment_record("mt_code")
        oPayment.cq_bank = oPayment_record("cq_bank")
        oPayment.cq_account = oPayment_record("cq_account")
        oPayment.cq_name = oPayment_record("cq_name")
        oPayment.cq_date = oPayment_record("cq_date")
        oPayment.master = oPayment_record("master")
        oPayment.received = oPayment_record("received")
        oPayment.received_date = oPayment_record("received_date")
        oPayment.approved = oPayment_record("approved")
        oPayment.approved_date = oPayment_record("approved_date")
        oPayment.amount_total = oPayment_record("amount_total")
        oPayment.amount_interest = oPayment_record("amount_interest")
        oPayment.amount_actual = oPayment_record("amount_actual")
        oPayment.amount_costs = oPayment_record("amount_costs")
        oPayment.notes = oPayment_record("notes")
        oPayment.LastModify_User_id = oPayment_record("LastModify_User_id")
        oPayment.LastModify_User = oPayment_record("LastModify_User")
        oPayment.LastModify_Date = oPayment_record("LastModify_Date")



        Return False
        Exit Function

ErrorHandler:
        Me.error_no = Err.Number
        Me.error_desc = Err.Description
        Me.error_source = Err.Source
        Return True

    End Function


    '####################################################################################
    Function update_payment(ByRef oPayment As cls_payment) As Boolean
        'On Error GoTo ErrorHandler

        '--- local definitions
        Dim bError As Boolean = False

        '--- Get Dataset
        Dim oTmpDataset As DataSet = oPayment.payment_dataset
        Dim oTmpPayments As DataTable = oTmpDataset.Tables("acc_CASHFLOW")


        '--- Assign Order
        Dim oTmpDataRow As DataRow
        oTmpDataRow = oTmpPayments.Rows(0)

        oTmpDataRow("payment_type") = System.Convert.ToInt16(oPayment.payment_type)
        oTmpDataRow("payment_date") = System.Convert.ToDateTime(oPayment.payment_date)

        oTmpDataRow("order_id") = System.Convert.ToInt32(oPayment.order_id)
        oTmpDataRow("user_id") = System.Convert.ToInt32(oPayment.user_id)
        oTmpDataRow("master") = System.Convert.ToBoolean(oPayment.master)

        oTmpDataRow("cc_type_id") = System.Convert.ToInt32(oPayment.cc_type_id)
        oTmpDataRow("cc_name") = System.Convert.ToString(oPayment.cc_name)
        oTmpDataRow("cc_number") = System.Convert.ToString(oPayment.cc_number)
        oTmpDataRow("cc_cvv") = System.Convert.ToString(oPayment.cc_cvv)
        oTmpDataRow("cc_exp_year") = System.Convert.ToString(oPayment.cc_exp_year)
        oTmpDataRow("cc_exp_month") = System.Convert.ToString(oPayment.cc_exp_month)
        oTmpDataRow("cc_user_ssn") = System.Convert.ToString(oPayment.cc_user_ssn)
        oTmpDataRow("cc_confirmation") = System.Convert.ToString(oPayment.cc_confermation)
        oTmpDataRow("cc_clubmember") = System.Convert.ToBoolean(oPayment.cc_clubmember)
        oTmpDataRow("cc_cleared") = System.Convert.ToBoolean(oPayment.cc_cleared)
        oTmpDataRow("cc_batch") = System.Convert.ToString(oPayment.cc_batch)

        oTmpDataRow("mt_bank") = System.Convert.ToString(oPayment.mt_bank)
        oTmpDataRow("mt_name") = System.Convert.ToString(oPayment.mt_name)
        oTmpDataRow("mt_account") = System.Convert.ToString(oPayment.mt_account)
        oTmpDataRow("mt_code") = System.Convert.ToString(oPayment.mt_code)

        oTmpDataRow("cq_bank") = System.Convert.ToString(oPayment.cq_bank)
        oTmpDataRow("cq_name") = System.Convert.ToString(oPayment.cq_name)
        oTmpDataRow("cq_account") = System.Convert.ToString(oPayment.cq_account)
        oTmpDataRow("cq_date") = System.Convert.ToDateTime(oPayment.cq_date)

        oTmpDataRow("received") = System.Convert.ToBoolean(oPayment.received)
        oTmpDataRow("received_date") = System.Convert.ToDateTime(oPayment.received_date)
        oTmpDataRow("approved") = System.Convert.ToBoolean(oPayment.approved)
        oTmpDataRow("approved_date") = System.Convert.ToDateTime(oPayment.approved_date)
        oTmpDataRow("amount_total") = System.Convert.ToDecimal(oPayment.amount_total)
        oTmpDataRow("amount_interest") = System.Convert.ToDecimal(oPayment.amount_interest)
        oTmpDataRow("amount_actual") = System.Convert.ToDecimal(oPayment.amount_actual)
        oTmpDataRow("amount_costs") = System.Convert.ToDecimal(oPayment.amount_costs)

        oTmpDataRow("LastModify_Date") = Date.Now
        oTmpDataRow("LastModify_User") = oPayment.LastModify_User
        oTmpDataRow("LastModify_User_Id") = oPayment.LastModify_User_id

        oTmpDataRow("notes") = System.Convert.ToString(oPayment.notes)


        '--- define system object
        Dim oSystem As ion_resources.cls_system = New ion_resources.cls_system()
        oSystem.connection_string = Me.connection_string
        oSystem.dataset = oTmpDataset

        Dim oTmpBroker As New ion_resources.cls_payment_brk()
        oTmpBroker.payment_id = oPayment.id
        bError = oTmpBroker.update_payment(oSystem)
        If bError Then
            Me.error_no = oSystem.error_no
            Me.error_desc = oSystem.error_desc
            Me.error_source = oSystem.error_source
            Return True
            Exit Function
        End If

        '--- Receive 
        Me.payment_id = oTmpBroker.payment_id


        oTmpBroker = Nothing
        oSystem = Nothing


        Return False
        Exit Function

ErrorHandler:
        Me.error_no = Err.Number
        Me.error_desc = Err.Description
        Me.error_source = Err.Source
        Return True

    End Function




    Public Property error_no() As Integer
        Get
            Return m_error_no
        End Get

        Set(ByVal Value As Integer)
            m_error_no = Value
        End Set
    End Property

    Public Property error_desc() As String
        Get
            Return m_error_desc
        End Get

        Set(ByVal Value As String)
            m_error_desc = Value
        End Set
    End Property

    Public Property error_source() As String
        Get
            Return m_error_source
        End Get

        Set(ByVal Value As String)
            m_error_source = Value
        End Set
    End Property

    Public Property connection_string() As String
        Get
            Return m_connection_string
        End Get

        Set(ByVal Value As String)
            m_connection_string = Value
        End Set
    End Property

    Public Property payment_id() As Int32
        Get
            Return m_payment_id
        End Get

        Set(ByVal Value As Int32)
            m_payment_id = Value
        End Set
    End Property

End Class
