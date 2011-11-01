Public Class cls_books_lgc
    Private m_error_no As Integer
    Private m_error_desc As String
    Private m_error_source As String
	Private m_connection_string As String
	Private m_transaction As System.Data.SqlClient.SqlTransaction
	Private m_connection As System.Data.SqlClient.SqlConnection

    Function insert_books(ByRef oBooks_cll As ion_resources.cls_books_cll) As Boolean
		On Error GoTo ErrorHandler

        '--- local definitions
        Dim bError As Boolean = False

        '--- Get Dataset
        Dim oTmpDataset As DataSet = New ion_resources.ds_books()

        '--- Define tables
        Dim oTmpGeneral As DataTable = oTmpDataset.Tables("acc_GENERAL_BOOKS")
        Dim oTmpSuppliers As DataTable = oTmpDataset.Tables("acc_SUPPLIERS_BOOKS")
        Dim oTmpInventory As DataTable = oTmpDataset.Tables("inv_INVENTORY")

        '--- 
        Dim oTmpDataRow As DataRow

        '--- Prepare General
        Dim nLoop_1 As Int16
        For nLoop_1 = 1 To oBooks_cll.general.Count
            oTmpDataRow = oTmpGeneral.NewRow

            oTmpDataRow("trs_id") = oBooks_cll.general(nLoop_1).trs_id
            oTmpDataRow("order_id") = oBooks_cll.general(nLoop_1).order_id
            oTmpDataRow("account_id") = oBooks_cll.general(nLoop_1).account_id
            oTmpDataRow("trs_date") = oBooks_cll.general(nLoop_1).trs_date
            oTmpDataRow("description") = oBooks_cll.general(nLoop_1).description
            oTmpDataRow("rate_ils") = oBooks_cll.general(nLoop_1).rate_ils
            oTmpDataRow("amount") = oBooks_cll.general(nLoop_1).amount
            oTmpDataRow("LastModify_date") = oBooks_cll.general(nLoop_1).LastModify_date
            oTmpDataRow("LastModify_user") = oBooks_cll.general(nLoop_1).LastModify_user
            oTmpDataRow("LastModify_user_id") = oBooks_cll.general(nLoop_1).LastModify_user_id

            oTmpGeneral.Rows.Add(oTmpDataRow)
        Next


        '--- Prepare Suppliers
        Dim nLoop_2 As Int16
        For nLoop_2 = 1 To oBooks_cll.suppliers.Count
            oTmpDataRow = oTmpSuppliers.NewRow

            oTmpDataRow("trs_id") = oBooks_cll.suppliers(nLoop_2).trs_id
            oTmpDataRow("order_id") = oBooks_cll.suppliers(nLoop_2).order_id
            oTmpDataRow("item_id") = oBooks_cll.suppliers(nLoop_2).item_id
            oTmpDataRow("item_qty") = oBooks_cll.suppliers(nLoop_2).item_qty
            oTmpDataRow("supplier_id2") = oBooks_cll.suppliers(nLoop_2).supplier_id2
            oTmpDataRow("trs_date") = oBooks_cll.suppliers(nLoop_2).trs_date
            oTmpDataRow("description") = oBooks_cll.suppliers(nLoop_2).description
            oTmpDataRow("rate_ils") = oBooks_cll.general(nLoop_2).rate_ils
            oTmpDataRow("amount") = oBooks_cll.suppliers(nLoop_2).amount
            oTmpDataRow("LastModify_date") = oBooks_cll.suppliers(nLoop_2).LastModify_date
            oTmpDataRow("LastModify_user") = oBooks_cll.suppliers(nLoop_2).LastModify_user
            oTmpDataRow("LastModify_user_id") = oBooks_cll.suppliers(nLoop_2).LastModify_user_id

            oTmpSuppliers.Rows.Add(oTmpDataRow)
        Next



		'--- Instantiate the Transactor
		Dim oTransactor As New ion_idac.cls_mt_transactor
		oTransactor.connection_string = Me.connection_string

		'--- Prepare and load table 1
		Dim oTable1 As New ion_idac.cls_cll_datatables
		oTable1.datatable = oTmpGeneral
		oTransactor.i_cll_datatables.Add(oTable1)

		'--- Prepare and load table 2
		Dim oTable2 As New ion_idac.cls_cll_datatables
		oTable2.datatable = oTmpSuppliers
		oTransactor.i_cll_datatables.Add(oTable2)

		'--- Assign transaction
		oTransactor.transaction = Me.transaction
		oTransactor.connection = Me.connection

		bError = oTransactor.transact_insert
		If bError Then
			Me.error_no = oTransactor.error_no
			Me.error_desc = oTransactor.error_desc
			Me.error_source = oTransactor.error_source
			Return True
		End If

		oTable1 = Nothing
		oTable2 = Nothing
		oTransactor = Nothing


		Return False
		Exit Function

ErrorHandler:
		Me.error_no = Err.Number
		Me.error_desc = Err.Description
		Me.error_source = Err.Source
		Return True

    End Function


    'TODO: wright function to delete transaction



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

	Public Property transaction() As System.Data.SqlClient.SqlTransaction
		Get
			Return m_transaction
		End Get

		Set(ByVal Value As System.Data.SqlClient.SqlTransaction)
			m_transaction = Value
		End Set
	End Property

	Public Property connection() As System.Data.SqlClient.SqlConnection
		Get
			Return m_connection
		End Get

		Set(ByVal Value As System.Data.SqlClient.SqlConnection)
			m_connection = Value
		End Set
	End Property

End Class
