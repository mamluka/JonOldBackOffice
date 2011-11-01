Public Class cls_creditcard
	Inherits iFoundation.cls_error_connection

	Public _name As String
	Public _id As Int32
	Public _extracharges As Decimal
	Public _arrivaldays As Int16
	Public _providercode As Int16

	Sub New()
		Me._name = ""
		Me._extracharges = 0
		Me._arrivaldays = 0
		Me._providercode = 0
	End Sub

	Public Function get_cc_info(ByVal nId As Int32) As Boolean
		On Error GoTo ErrorHandler
		Dim bError As Boolean = False

		'--- Define information to read
		Dim oTmpDataBroker As New iDac.cls_T_datareader
		oTmpDataBroker._dbtype = Me._dbtype
		oTmpDataBroker._connection_string = Me._connection_string
		oTmpDataBroker._table = "acc_CREDITCARD"
		oTmpDataBroker._id = nId

		'--- Define records
		Dim oField1 As New iDac.cls_cll_datareader
		oField1._field = "id"
		oTmpDataBroker._fields.Add(oField1)
		oField1 = Nothing

		Dim oField2 As New iDac.cls_cll_datareader
		oField2._field = "extracharges"
		oTmpDataBroker._fields.Add(oField2)
		oField2 = Nothing

		Dim oField3 As New iDac.cls_cll_datareader
		oField3._field = "arrivaldays"
		oTmpDataBroker._fields.Add(oField3)
		oField3 = Nothing

		Dim oField4 As New iDac.cls_cll_datareader
		oField4._field = "providercode"
		oTmpDataBroker._fields.Add(oField4)
		oField4 = Nothing

		Dim oField5 As New iDac.cls_cll_datareader
		oField5._field = "LANG1_SHORTDESCR"
		oTmpDataBroker._fields.Add(oField5)
		oField5 = Nothing

		'--- Get info
		bError = oTmpDataBroker.read()
		If bError Then
			Me._err_number = oTmpDataBroker._err_number
			Me._err_description = oTmpDataBroker._err_description
			Me._err_source = oTmpDataBroker._err_source
			Return True
		End If

		'--- Fill results
		Me._id = oTmpDataBroker._fields.Item(1)._result
		Me._extracharges = oTmpDataBroker._fields.Item(2)._result
		Me._arrivaldays = oTmpDataBroker._fields.Item(3)._result
		Me._providercode = oTmpDataBroker._fields.Item(4)._result
		Me._name = oTmpDataBroker._fields.Item(5)._result

		Return False
		Exit Function

ErrorHandler:
		Me._err_number = Err.Number
		Me._err_description = Err.Description
		Me._err_source = Err.Source
		Return True

	End Function

End Class
