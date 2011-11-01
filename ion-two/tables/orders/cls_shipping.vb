Public Class cls_shipping
	Inherits iFoundation.cls_error_connection

	Public _state_vat As Decimal
	Public _state_courier_amnt As Decimal
	Public _state_courier_days As Int16
	Public _state_ems_amnt As Decimal
	Public _state_ems_days As Int16
	Public _state_fedex_amnt As Decimal
	Public _state_fedex_days As Int16
	Public _country_vat As Decimal
	Public _country_courier_amnt As Decimal
	Public _country_courier_days As Int16
	Public _country_ems_amnt As Decimal
	Public _country_ems_days As Int16
	Public _country_fedex_amnt As Decimal
	Public _country_fedex_days As Int16
	Public _total_vat As Decimal
	Public _total_courier_amnt As Decimal
	Public _total_courier_days As Int16
	Public _total_ems_amnt As Decimal
	Public _total_ems_days As Int16
	Public _total_fedex_amnt As Decimal
    Public _total_fedex_days As Int16
    Public _convertrate As Decimal = 1

	Sub New()
		Me._state_vat = 0
		Me._state_courier_amnt = 0
		Me._state_courier_days = 0
		Me._state_ems_amnt = 0
		Me._state_ems_days = 0
		Me._state_fedex_amnt = 0
		Me._state_fedex_days = 0
		Me._country_vat = 0
		Me._country_courier_amnt = 0
		Me._country_courier_days = 0
		Me._country_ems_amnt = 0
		Me._country_ems_days = 0
		Me._country_fedex_amnt = 0
		Me._country_fedex_days = 0
		Me._total_vat = 0
		Me._total_courier_amnt = 0
		Me._total_courier_days = 0
		Me._total_ems_amnt = 0
		Me._total_ems_days = 0
		Me._total_fedex_amnt = 0
		Me._total_fedex_days = 0
	End Sub

	Public Function get_shipping(ByVal nCountry_id As Int32, ByVal nState_id As Int32) As Boolean
		On Error GoTo ErrorHandler
		Dim bError As Boolean = False

		'--- get COUNTRY SHIPPING
		If nCountry_id > 0 Then
			bError = Me.get_shipping_country(nCountry_id)
			If bError Then
				Me._err_number = Err.Number
				Me._err_description = Err.Description
				Me._err_source = Err.Source
				Return True
			End If
		End If

		'--- get COUNTRY SHIPPING
		If nState_id > 0 Then
			bError = Me.get_shipping_state(nState_id)
			If bError Then
				Me._err_number = Err.Number
				Me._err_description = Err.Description
				Me._err_source = Err.Source
				Return True
			End If
		End If

		'--- Total
		Me._total_vat = Me._state_vat + Me._country_vat
		Me._total_courier_amnt = Me._state_courier_amnt + Me._country_courier_amnt
		Me._total_courier_days = Me._state_courier_days + Me._country_courier_days
		Me._total_ems_amnt = Me._state_ems_amnt + Me._country_ems_amnt
		Me._total_ems_days = Me._state_ems_days + Me._country_ems_days
		Me._total_fedex_amnt = Me._state_fedex_amnt + Me._country_fedex_amnt
		Me._total_fedex_days = Me._state_fedex_days + Me._country_fedex_days


		Return False
		Exit Function

ErrorHandler:
		Me._err_number = Err.Number
		Me._err_description = Err.Description
		Me._err_source = Err.Source
		Return True

	End Function

	Private Function get_shipping_state(ByVal nState_id As Int32) As Boolean
		On Error GoTo ErrorHandler
		Dim bError As Boolean = False

		'--- Define information to read
		Dim oTmpDataBroker As New iDac.cls_T_datareader
		oTmpDataBroker._dbtype = Me._dbtype
		oTmpDataBroker._connection_string = Me._connection_string
		oTmpDataBroker._table = "sys_STATE"
		oTmpDataBroker._id = 0

		Dim cSQL As String
		cSQL = "select id, vat, courier_charges, courier_time, ems_charges, ems_time, fedex_charges, fedex_time  from sys_state where ID =" & nState_id

		'--- Define records
		Dim oField1 As New iDac.cls_cll_datareader
		oField1._field = "id"
		oTmpDataBroker._fields.Add(oField1)
		oField1 = Nothing

		Dim oField2 As New iDac.cls_cll_datareader
		oField2._field = "vat"
		oTmpDataBroker._fields.Add(oField2)
		oField2 = Nothing

		Dim oField3 As New iDac.cls_cll_datareader
		oField3._field = "courier_charges"
		oTmpDataBroker._fields.Add(oField3)
		oField3 = Nothing

		Dim oField4 As New iDac.cls_cll_datareader
		oField4._field = "courier_time"
		oTmpDataBroker._fields.Add(oField4)
		oField4 = Nothing

		Dim oField5 As New iDac.cls_cll_datareader
		oField5._field = "ems_charges"
		oTmpDataBroker._fields.Add(oField5)
		oField5 = Nothing

		Dim oField6 As New iDac.cls_cll_datareader
		oField6._field = "ems_time"
		oTmpDataBroker._fields.Add(oField6)
		oField6 = Nothing

		Dim oField7 As New iDac.cls_cll_datareader
		oField7._field = "fedex_charges"
		oTmpDataBroker._fields.Add(oField7)
		oField7 = Nothing

		Dim oField8 As New iDac.cls_cll_datareader
		oField8._field = "fedex_time"
		oTmpDataBroker._fields.Add(oField8)
		oField8 = Nothing


		'--- Get info
		bError = oTmpDataBroker.read(cSQL)
		If bError Then
			Me._err_number = oTmpDataBroker._err_number
			Me._err_description = oTmpDataBroker._err_description
			Me._err_source = oTmpDataBroker._err_source
			Return True
		End If

		'--- Fill results
		Me._state_vat = oTmpDataBroker._fields.Item(2)._result
		Me._state_courier_amnt = oTmpDataBroker._fields.Item(3)._result
		Me._state_courier_days = oTmpDataBroker._fields.Item(4)._result
		Me._state_ems_amnt = oTmpDataBroker._fields.Item(5)._result
		Me._state_ems_days = oTmpDataBroker._fields.Item(6)._result
		Me._state_fedex_amnt = oTmpDataBroker._fields.Item(7)._result
		Me._state_fedex_days = oTmpDataBroker._fields.Item(8)._result

		Return False
		Exit Function

ErrorHandler:
		Me._err_number = Err.Number
		Me._err_description = Err.Description
		Me._err_source = Err.Source
		Return True

	End Function

	Private Function get_shipping_country(ByVal nCountry_id As Int32) As Boolean
		On Error GoTo ErrorHandler
		Dim bError As Boolean = False

		'--- Define information to read
		Dim oTmpDataBroker As New iDac.cls_T_datareader
		oTmpDataBroker._dbtype = Me._dbtype
		oTmpDataBroker._connection_string = Me._connection_string
		oTmpDataBroker._table = "sys_COUNTRY"
		oTmpDataBroker._id = 0

		Dim cSQL As String
		cSQL = "select id, vat, courier_charges, courier_time, ems_charges, ems_time, fedex_charges, fedex_time  from sys_country where ID =" & nCountry_id

		'--- Define records
		Dim oField1 As New iDac.cls_cll_datareader
		oField1._field = "id"
		oTmpDataBroker._fields.Add(oField1)
		oField1 = Nothing

		Dim oField2 As New iDac.cls_cll_datareader
		oField2._field = "vat"
		oTmpDataBroker._fields.Add(oField2)
		oField2 = Nothing

		Dim oField3 As New iDac.cls_cll_datareader
		oField3._field = "courier_charges"
		oTmpDataBroker._fields.Add(oField3)
		oField3 = Nothing

		Dim oField4 As New iDac.cls_cll_datareader
		oField4._field = "courier_time"
		oTmpDataBroker._fields.Add(oField4)
		oField4 = Nothing

		Dim oField5 As New iDac.cls_cll_datareader
		oField5._field = "ems_charges"
		oTmpDataBroker._fields.Add(oField5)
		oField5 = Nothing

		Dim oField6 As New iDac.cls_cll_datareader
		oField6._field = "ems_time"
		oTmpDataBroker._fields.Add(oField6)
		oField6 = Nothing

		Dim oField7 As New iDac.cls_cll_datareader
		oField7._field = "fedex_charges"
		oTmpDataBroker._fields.Add(oField7)
		oField7 = Nothing

		Dim oField8 As New iDac.cls_cll_datareader
		oField8._field = "fedex_time"
		oTmpDataBroker._fields.Add(oField8)
		oField8 = Nothing


		'--- Get info
		bError = oTmpDataBroker.read(cSQL)
		If bError Then
			Me._err_number = oTmpDataBroker._err_number
			Me._err_description = oTmpDataBroker._err_description
			Me._err_source = oTmpDataBroker._err_source
			Return True
		End If

		'--- Fill results
		Me._country_vat = oTmpDataBroker._fields.Item(2)._result
		Me._country_courier_amnt = oTmpDataBroker._fields.Item(3)._result
		Me._country_courier_days = oTmpDataBroker._fields.Item(4)._result
		Me._country_ems_amnt = oTmpDataBroker._fields.Item(5)._result
		Me._country_ems_days = oTmpDataBroker._fields.Item(6)._result
		Me._country_fedex_amnt = oTmpDataBroker._fields.Item(7)._result
		Me._country_fedex_days = oTmpDataBroker._fields.Item(8)._result

		Return False
		Exit Function

ErrorHandler:
		Me._err_number = Err.Number
		Me._err_description = Err.Description
		Me._err_source = Err.Source
		Return True
	End Function
    Function get_fixedprice_bytype(ByVal shippingid As Int32, ByRef price As Decimal)
        Select Case shippingid
            Case 1
                price = 0
            Case 2
                price = 39
            Case 3
                price = 179
            Case 4
                price = 49
            Case 5 '' free slot
                price = 0
            Case Else
                price = 0
        End Select

        price *= Me._convertrate

    End Function

End Class
