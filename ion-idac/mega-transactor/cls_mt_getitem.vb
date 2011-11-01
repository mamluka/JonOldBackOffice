Imports System.Data.SqlClient

Public Class cls_mt_getitem
	Inherits cls_mt_error

	Private m_id As Int32
	Private m_tablename As String
	Private m_datatable As DataTable

	Function get_item() As Boolean
		On Error GoTo ErrorHandler
		Dim bError As Boolean = False


		'--- Create connection
		Dim oConnection As SqlConnection
		oConnection = New SqlConnection(Me.connection_string)

		Dim oDataAdapter1 As SqlDataAdapter = New SqlDataAdapter
		oDataAdapter1.TableMappings.Add("Table", Me.tablename)

		oConnection.Open()

		Dim oSQLcmd1 As SqlCommand = New SqlCommand("select * from " + Me.tablename + " where id=" & Me.id, oConnection)
		oSQLcmd1.CommandType = CommandType.Text
		oDataAdapter1.SelectCommand = oSQLcmd1


		Dim oDS As DataSet = New DataSet("ds_tmp")
		oDataAdapter1.Fill(oDS)

		'--- Close connection
		oConnection.Close()


		'--- assign dattable
		Me.DataTable = oDS.Tables(0)
		If Me.DataTable.Rows.Count <= 0 Then
			Err.Raise(10100, "cls_mt_getitem", "Record not found")
		End If

		'--- release objects
		oConnection = Nothing
		oDataAdapter1 = Nothing
		oDS = Nothing
		oSQLcmd1 = Nothing


		Return False
		Exit Function

ErrorHandler:
		Me.error_no = Err.Number
		Me.error_desc = Err.Description
		Me.error_source = Err.Source
		Return True


	End Function


	Public Property id() As Int32
		Get
			Return m_id
		End Get

		Set(ByVal Value As Int32)
			m_id = Value
		End Set
	End Property

	Public Property DataTable() As DataTable
		Get
			Return m_datatable
		End Get

		Set(ByVal Value As DataTable)
			m_datatable = Value
		End Set
	End Property

	Public Property tablename() As String
		Get
			Return m_tablename
		End Get

		Set(ByVal Value As String)
			m_tablename = Value
		End Set
	End Property

End Class

