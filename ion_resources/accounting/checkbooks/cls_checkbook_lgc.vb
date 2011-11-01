Public Class cls_checkbook_lgc
    Private m_error_no As Integer
    Private m_error_desc As String
    Private m_error_source As String
    Private m_connection_string As String
    Private m_payment_id As Int32

    '####################################################################################
    Function insert_payment(ByRef oCheckbook As cls_checkbook) As Boolean
        'On Error GoTo ErrorHandler

        '--- local definitions
        Dim bError As Boolean = False

        '--- Get Dataset
        Dim oTmpDataset As DataSet = New ion_resources.ds_checkbook()
        Dim oTmpPayments As DataTable
        If oCheckbook.currency_id = 1 Then  '--- USD
            oTmpPayments = oTmpDataset.Tables("acc_CHECKBOOK_USD")

        ElseIf oCheckbook.currency_id = 2 Then '--- ILS
            oTmpPayments = oTmpDataset.Tables("acc_CHECKBOOK_ILS")

        End If


        '--- Assign Order
        Dim oTmpDataRow As DataRow
        oTmpDataRow = oTmpPayments.NewRow

        'oTmpDataRow("id") = 1
        oTmpDataRow("description") = System.Convert.ToString(oCheckbook.description)
        oTmpDataRow("paymentdate") = System.Convert.ToDateTime(oCheckbook.paymentdate)
        oTmpDataRow("checknumber") = System.Convert.ToInt32(oCheckbook.checknumber)
        oTmpDataRow("account") = System.Convert.ToUInt32(oCheckbook.account)
        oTmpDataRow("nameto") = System.Convert.ToString(oCheckbook.nameto)
        oTmpDataRow("checkdate") = System.Convert.ToDateTime(oCheckbook.checkdate)
        oTmpDataRow("cashed") = System.Convert.ToBoolean(oCheckbook.cashed)
        oTmpDataRow("amount") = System.Convert.ToDecimal(oCheckbook.amount)
        oTmpDataRow("notes") = System.Convert.ToString(oCheckbook.notes)
        oTmpDataRow("LastModify_Date") = Date.Now
        oTmpDataRow("LastModify_User") = System.Convert.ToString(oCheckbook.LastModify_User)
        oTmpDataRow("LastModify_User_Id") = System.Convert.ToInt32(oCheckbook.LastModify_User_id)

        oTmpPayments.Rows.Add(oTmpDataRow)

        '--- define system object
        Dim oSystem As ion_resources.cls_system = New ion_resources.cls_system()
        oSystem.connection_string = Me.connection_string
        oSystem.dataset = oTmpDataset

        Dim oTmpBroker As New ion_resources.cls_checkbook_brk()
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
    Function get_payment(ByVal nPaymentId As Int32, ByRef oCheckbook As cls_checkbook) As Boolean
        'On Error GoTo ErrorHandler

        '--- local definitions
        Dim bError As Boolean = False

        '--- define system object
        Dim oSystem As ion_resources.cls_system = New ion_resources.cls_system()
        oSystem.connection_string = Me.connection_string
        oSystem.dataset = New ion_resources.ds_checkbook()


        Dim oTmpBroker As New ion_resources.cls_checkbook_brk()
        bError = oTmpBroker.get_payment(nPaymentId, oSystem)
        If bError Then
            Me.error_no = oSystem.error_no
            Me.error_desc = oSystem.error_desc
            Me.error_source = oSystem.error_source
            Return True
            Exit Function
        End If

        oCheckbook.checkbook_dataset = oSystem.dataset
        Dim oPaymentTable As DataTable = oCheckbook.checkbook_dataset.Tables(0)

        '--- Current Record
        Dim oPaymentRecord As DataRow = oPaymentTable.Rows(0)

        oCheckbook.id = oPaymentRecord("id")
        oCheckbook.description = oPaymentRecord("description")
        oCheckbook.paymentdate = oPaymentRecord("paymentdate")
        oCheckbook.checknumber = oPaymentRecord("checknumber")
        oCheckbook.account = oPaymentRecord("account")
        oCheckbook.nameto = oPaymentRecord("nameto")
        oCheckbook.checkdate = oPaymentRecord("checkdate")
        oCheckbook.cashed = oPaymentRecord("cashed")
        oCheckbook.amount = oPaymentRecord("amount")
        oCheckbook.notes = oPaymentRecord("notes")
        oCheckbook.LastModify_Date = oPaymentRecord("lastmodify_date")
        oCheckbook.LastModify_User = oPaymentRecord("lastmodify_user")
        oCheckbook.LastModify_User_id = oPaymentRecord("lastmodify_user_id")

        Return False
        Exit Function

ErrorHandler:
        Me.error_no = Err.Number
        Me.error_desc = Err.Description
        Me.error_source = Err.Source
        Return True

    End Function

    '####################################################################################
    Function update_payment(ByRef oCheckbook As cls_checkbook) As Boolean
        'On Error GoTo ErrorHandler

        '--- local definitions
        Dim bError As Boolean = False

        '--- Get Dataset
        Dim oTmpDataset As DataSet = oCheckbook.checkbook_dataset
        Dim oPaymentTable As DataTable = oCheckbook.checkbook_dataset.Tables(0)


        '--- Assign Order
        Dim oTmpDataRow As DataRow
        oTmpDataRow = oPaymentTable.Rows(0)

        'oTmpDataRow("id") = 1
        oTmpDataRow("description") = System.Convert.ToString(oCheckbook.description)
        oTmpDataRow("paymentdate") = System.Convert.ToDateTime(oCheckbook.paymentdate)
        oTmpDataRow("checknumber") = System.Convert.ToInt32(oCheckbook.checknumber)
        oTmpDataRow("account") = System.Convert.ToUInt32(oCheckbook.account)
        oTmpDataRow("nameto") = System.Convert.ToString(oCheckbook.nameto)
        oTmpDataRow("checkdate") = System.Convert.ToDateTime(oCheckbook.checkdate)
        oTmpDataRow("cashed") = System.Convert.ToBoolean(oCheckbook.cashed)
        oTmpDataRow("amount") = System.Convert.ToDecimal(oCheckbook.amount)
        oTmpDataRow("notes") = System.Convert.ToString(oCheckbook.notes)
        oTmpDataRow("LastModify_Date") = Date.Now
        oTmpDataRow("LastModify_User") = System.Convert.ToString(oCheckbook.LastModify_User)
        oTmpDataRow("LastModify_User_Id") = System.Convert.ToInt32(oCheckbook.LastModify_User_id)


        '--- define system object
        Dim oSystem As ion_resources.cls_system = New ion_resources.cls_system()
        oSystem.connection_string = Me.connection_string
        oSystem.dataset = oTmpDataset

        Dim oTmpBroker As New ion_resources.cls_checkbook_brk()
        oTmpBroker.payment_id = oCheckbook.id
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
