Public Class cls_feedbacks_lgc
    Private m_error_no As Integer
    Private m_error_desc As String
    Private m_error_source As String
    Private m_connection_string As String
    Private m_id As Int32

    '####################################################################################
    Function insert_feedback(ByRef oFeedback As cls_feedback) As Boolean
        'On Error GoTo ErrorHandler

        '--- local definitions
        Dim bError As Boolean = False

        '--- Get Dataset
        Dim oTmpDataset As DataSet = New ion_resources.ds_feedbacks()
        Dim oTmpPayments As DataTable
        oTmpPayments = oTmpDataset.Tables("usr_FEEDBACKS")


        '--- Assign Order
        Dim oTmpDataRow As DataRow
        oTmpDataRow = oTmpPayments.NewRow

        'oTmpDataRow("id") = 1
        oTmpDataRow("user_id") = System.Convert.ToInt32(oFeedback.user_id)
        oTmpDataRow("user_name") = System.Convert.ToString(oFeedback.user_name)
        oTmpDataRow("user_email") = System.Convert.ToString(oFeedback.user_email)
        oTmpDataRow("showemail") = System.Convert.ToBoolean(oFeedback.showemail)
        oTmpDataRow("active") = False
        oTmpDataRow("deleted") = False
        oTmpDataRow("createdate") = Today.Now
        oTmpDataRow("text") = System.Convert.ToString(oFeedback.text)
        oTmpDataRow("country") = System.Convert.ToString(oFeedback.country)
        oTmpDataRow("state") = System.Convert.ToString(oFeedback.state)
        oTmpDataRow("item1_id") = System.Convert.ToInt32(oFeedback.item1_id)
        oTmpDataRow("item2_id") = System.Convert.ToInt32(oFeedback.item2_id)
        oTmpDataRow("item3_id") = System.Convert.ToInt32(oFeedback.item3_id)

        oTmpPayments.Rows.Add(oTmpDataRow)

        '--- define system object
        Dim oSystem As ion_resources.cls_system = New ion_resources.cls_system()
        oSystem.connection_string = Me.connection_string
        oSystem.dataset = oTmpDataset

        Dim oTmpBroker As New ion_resources.cls_feedbacks_brk()
        bError = oTmpBroker.insert(oSystem)
        If bError Then
            Me.error_no = oSystem.error_no
            Me.error_desc = oSystem.error_desc
            Me.error_source = oSystem.error_source
            Return True
            Exit Function
        End If

        '--- Receive 
        Me.id = oTmpBroker.id

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
    Function get_payment(ByVal nId As Int32, ByRef oFeedback As cls_feedback) As Boolean
        'On Error GoTo ErrorHandler

        '--- local definitions
        Dim bError As Boolean = False

        '--- define system object
        Dim oSystem As ion_resources.cls_system = New ion_resources.cls_system()
        oSystem.connection_string = Me.connection_string
        oSystem.dataset = New ion_resources.ds_feedbacks()


        Dim oTmpBroker As New ion_resources.cls_feedbacks_brk()
        bError = oTmpBroker.getrec(nId, oSystem)
        If bError Then
            Me.error_no = oSystem.error_no
            Me.error_desc = oSystem.error_desc
            Me.error_source = oSystem.error_source
            Return True
            Exit Function
        End If

        oFeedback.dataset = oSystem.dataset
        Dim oTable As DataTable = oFeedback.dataset.Tables(0)

        '--- Current Record
        Dim oRecord As DataRow = oTable.Rows(0)

        oFeedback.id = oRecord("id")
        oFeedback.user_id = oRecord("user_id")
        oFeedback.user_name = oRecord("user_name")
        oFeedback.user_email = oRecord("user_email")
        oFeedback.showemail = oRecord("shaowemail")
        oFeedback.active = oRecord("active")
        oFeedback.delete = oRecord("deleted")
        oFeedback.createdate = oRecord("createdate")
        oFeedback.text = oRecord("text")
        oFeedback.country = oRecord("country")
        oFeedback.state = oRecord("state")
        oFeedback.item1_id = oRecord("item1_id")
        oFeedback.item2_id = oRecord("item2_id")
        oFeedback.item3_id = oRecord("item3_id")

        Return False
        Exit Function

ErrorHandler:
        Me.error_no = Err.Number
        Me.error_desc = Err.Description
        Me.error_source = Err.Source
        Return True

    End Function

    '####################################################################################
    Function update_payment(ByRef oFeedback As cls_feedback) As Boolean
        'On Error GoTo ErrorHandler

        '--- local definitions
        Dim bError As Boolean = False

        '--- Get Dataset
        Dim oTmpDataset As DataSet = oFeedback.dataset
        Dim oTable As DataTable = oFeedback.dataset.Tables(0)


        '--- Assign Order
        Dim oTmpDataRow As DataRow
        oTmpDataRow = oTable.Rows(0)

        'oTmpDataRow("id") = 1
        oTmpDataRow("user_id") = System.Convert.ToInt32(oFeedback.user_id)
        oTmpDataRow("user_name") = System.Convert.ToString(oFeedback.user_name)
        oTmpDataRow("user_email") = System.Convert.ToString(oFeedback.user_email)
        oTmpDataRow("showemail") = System.Convert.ToBoolean(oFeedback.showemail)
        oTmpDataRow("active") = False
        oTmpDataRow("deleted") = False
        oTmpDataRow("createdate") = Today.Now
        oTmpDataRow("text") = System.Convert.ToString(oFeedback.text)
        oTmpDataRow("country") = System.Convert.ToString(oFeedback.country)
        oTmpDataRow("state") = System.Convert.ToString(oFeedback.state)
        oTmpDataRow("item1_id") = System.Convert.ToInt32(oFeedback.item1_id)
        oTmpDataRow("item2_id") = System.Convert.ToInt32(oFeedback.item2_id)
        oTmpDataRow("item3_id") = System.Convert.ToInt32(oFeedback.item3_id)


        '--- define system object
        Dim oSystem As ion_resources.cls_system = New ion_resources.cls_system()
        oSystem.connection_string = Me.connection_string
        oSystem.dataset = oTmpDataset

        Dim oTmpBroker As New ion_resources.cls_feedbacks_brk()
        oTmpBroker.id = oFeedback.id
        bError = oTmpBroker.update(oSystem)
        If bError Then
            Me.error_no = oSystem.error_no
            Me.error_desc = oSystem.error_desc
            Me.error_source = oSystem.error_source
            Return True
            Exit Function
        End If

        '--- Receive 
        Me.id = oTmpBroker.id


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

    Public Property id() As Int32
        Get
            Return m_id
        End Get

        Set(ByVal Value As Int32)
            m_id = Value
        End Set
    End Property


End Class
