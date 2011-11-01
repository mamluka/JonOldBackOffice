Public Class cls_grid
	Inherits iFoundation.cls_error_connection

	Public _grid As System.Web.UI.WebControls.DataGrid
	Public _sqlstring As String
	Public _dataset As DataSet

	Public Function load() As Boolean
		On Error GoTo ErrorHandler
		Dim bError As Boolean = False

		'--- Instantiat Grid broker
		Dim oGridBroker As New iDac.cls_T_grid
		oGridBroker._connection_string = Me._connection_string
		oGridBroker._dbtype = Me._dbtype
		oGridBroker._sqlstring = Me._sqlstring
		bError = oGridBroker.init()

		'--- Define dataset and bind grid
		Dim oDataset As DataSet
		Me._dataset = New DataSet("tmpdataset")
		oGridBroker._dataadapter.Fill(Me._dataset)

		Me._grid.DataSource = Me._dataset

		'--- Set page if neccery
		If Me._dataset.Tables(0).Rows.Count <= Me._grid.PageSize Then
			Me._grid.CurrentPageIndex = 0
		End If

		Me._grid.DataBind()

		Return False
		Exit Function

ErrorHandler:
		Me._err_number = Err.Number
		Me._err_description = Err.Description
		Me._err_source = Err.Source
		Return True

	End Function


	Public Function bind() As Boolean

		Me._grid.DataBind()

	End Function



End Class
