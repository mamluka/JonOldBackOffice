Public Class cls_help
	Inherits iFoundation.cls_error_connection

	Public _module As String
	Public _description As String
	Public _helptext As String

	Sub New()
		Me._module = ""
		Me._description = ""
		Me._helptext = ""
	End Sub

	Public Function read(ByVal nId As Int32) As Boolean
		On Error GoTo ErrorHandler
		Dim bError As Boolean = False

		'--- Define information to read
		Dim oTmpDataBroker As New iDac.cls_T_datareader
		oTmpDataBroker._dbtype = Me._dbtype
		oTmpDataBroker._connection_string = Me._connection_string
		oTmpDataBroker._table = "sys_help"
		oTmpDataBroker._id = nId

		'--- Define records
		Dim oField1 As New iDac.cls_cll_datareader
		oField1._field = "id"
		oTmpDataBroker._fields.Add(oField1)
		oField1 = Nothing

		Dim oField2 As New iDac.cls_cll_datareader
		oField2._field = "mdl"
		oTmpDataBroker._fields.Add(oField2)
		oField2 = Nothing

		Dim oField3 As New iDac.cls_cll_datareader
		oField3._field = "description"
		oTmpDataBroker._fields.Add(oField3)
		oField3 = Nothing

		Dim oField4 As New iDac.cls_cll_datareader
		oField4._field = "helptext"
		oTmpDataBroker._fields.Add(oField4)
		oField4 = Nothing


		'--- Get info
		bError = oTmpDataBroker.read()
		If bError Then
			Me._err_number = oTmpDataBroker._err_number
			Me._err_description = oTmpDataBroker._err_description
			Me._err_source = oTmpDataBroker._err_source
			Return True
		End If

		'--- Fill results
		nId = oTmpDataBroker._fields.Item(1)._result
		Me._module = oTmpDataBroker._fields.Item(2)._result
		Me._description = oTmpDataBroker._fields.Item(3)._result
		Me._helptext = oTmpDataBroker._fields.Item(4)._result

		Return False
		Exit Function

ErrorHandler:

		'--- register the error
		Me._err_number = Err.Number
		Me._err_description = Err.Description
		Me._err_source = Err.Source
		Return True

	End Function


End Class
