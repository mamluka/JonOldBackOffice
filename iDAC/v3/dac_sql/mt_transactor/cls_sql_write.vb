Imports System.Data.SqlClient

Friend Class cls_sql_write
	Inherits cls_error

	'--- USED BY MT_TRANSACTOR
	'---
	'--- This module saves tables.
	'--- If a DATATABLE is passed then the DATATABLE is saved
	'--- If a DATASET is passed then the DATASET is saved
	'---
	'--- The ID of the record handeled should be found in ME.O_ID

	Public _i_connection_string As String
	Public _o_id As Int32
	Public _i_transaction As SqlTransaction
	Public _i_datatable As DataTable	 '-- We can use OR  datatable OR Dataset

	Function WriteTable() As Boolean
		On Error GoTo ErrorHandler
		Dim bError As Boolean = False


		'--- Prepare the dataadapter
		Dim oDataAdapter As New SqlDataAdapter
		oDataAdapter.TableMappings.Add("Table", Me._i_datatable.TableName)
		oDataAdapter.SelectCommand = New SqlCommand("select * from " + Me._i_datatable.TableName + " where 0=1", Me._i_transaction.Connection)
		oDataAdapter.SelectCommand.Transaction = Me._i_transaction

		'--- prepare the command builder
		Dim oCommandBuilder As SqlCommandBuilder
		oCommandBuilder = New SqlCommandBuilder(oDataAdapter)


        AddHandler oDataAdapter.RowUpdated, New SqlRowUpdatedEventHandler(AddressOf OnRowUpdated)

		oDataAdapter.UpdateCommand = oCommandBuilder.GetUpdateCommand

		oDataAdapter.Update(Me._i_datatable)

		'Dim oDatasetChanges As DataSet = Me.i_datatable.DataSet
		'oDataAdapter.Update(oDatasetChanges)

        RemoveHandler oDataAdapter.RowUpdated, New SqlRowUpdatedEventHandler(AddressOf OnRowUpdated)

		'--- Release objects
		oDataAdapter = Nothing
		oCommandBuilder = Nothing


		Return False
		Exit Function

ErrorHandler:
		Me._err_number = Err.Number
		Me._err_description = Err.Description
		Me._err_source = Err.Source
		Return True

	End Function

	Sub OnRowUpdated(ByVal sender As Object, ByVal args As SqlRowUpdatedEventArgs)
		' Include a variable and a command to retrieve the identity value from the Access database.
		Dim newID As Integer = 0
		Dim idCMD As SqlCommand = New SqlCommand("SELECT @@IDENTITY", Me._i_transaction.Connection)

        If args.StatementType = StatementType.Insert Then
            idCMD.Transaction = Me._i_transaction
            If Not Convert.IsDBNull(idCMD.ExecuteScalar()) Then
                Me._o_id = CInt(idCMD.ExecuteScalar())
            End If
        End If
	End Sub

End Class