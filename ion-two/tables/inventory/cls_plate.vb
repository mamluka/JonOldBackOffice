Public Class cls_plate
	Inherits iFoundation.cls_error_connection

	Public _number As Int16
	Public _skelet As Object
	Public _lst_skelet As Object
	Public _logics As Object

	Sub New()
		Me._number = 0
		Me._skelet = Nothing
		Me._logics = Nothing
		Me._lst_skelet = Nothing
	End Sub

	Public Function get_platefromid(ByVal nId As Int32) As Boolean
		On Error GoTo ErrorHandler
		Dim bError As Boolean = False

		'---
		Dim nPlate As String = ""

		'--- Define information to read
		Dim oTmpDataBroker As New iDac.cls_T_datareader
		oTmpDataBroker._dbtype = Me._dbtype
		oTmpDataBroker._connection_string = Me._connection_string
		oTmpDataBroker._table = "inv_INVENTORY"
		oTmpDataBroker._id = nId

		'--- Define records
		Dim oField1 As New iDac.cls_cll_datareader
		oField1._field = "id"
		oTmpDataBroker._fields.Add(oField1)
		oField1 = Nothing

		Dim oField2 As New iDac.cls_cll_datareader
		oField2._field = "platetype"
		oTmpDataBroker._fields.Add(oField2)
		oField2 = Nothing

		'--- Get info
		bError = oTmpDataBroker.read()
		If bError Then
			Me._err_number = oTmpDataBroker._err_number
			Me._err_description = oTmpDataBroker._err_description
			Me._err_source = oTmpDataBroker._err_source
			Return True
		End If

		If Not oTmpDataBroker._hasresult Then
			Err.Raise(7006, "cls_plate", "No records returned")
		End If

		'--- Fill results
		nId = oTmpDataBroker._fields.Item(1)._result
		nPlate = oTmpDataBroker._fields.Item(2)._result

		'--- Load
		bError = Me.get_plateobject(nPlate)
		If bError Then
			Me._err_number = Err.Number
			Me._err_description = Err.Description
			Me._err_source = Err.Source
			Return True
		End If

		Return False
		Exit Function

ErrorHandler:
		Me._err_number = Err.Number
		Me._err_description = Err.Description
		Me._err_source = Err.Source
		Return True

	End Function

	Public Function get_plateobject(ByVal nNumber As Int16) As Boolean
		On Error GoTo ErrorHandler

		'--- local definitions
		Dim bError As Boolean = False

		Select Case nNumber
			Case 1
				Me._number = 1
				'--- Define Skeleton
				Dim oTmpSkelet As New skl_diamond
				Me._skelet = oTmpSkelet

				'--- Define Listing Skeleton
				Dim oTmpLstSkelet As New skl_lst_diamond
				Me._lst_skelet = oTmpLstSkelet

				'--- Define Logics
				Dim oTmpLogics As New cls_diamond_lgc
				Me._logics = oTmpLogics

				oTmpSkelet = Nothing
				oTmpLstSkelet = Nothing
				oTmpLogics = Nothing

			Case 2
				Me._number = 2
				'--- Define Skeleton
				Dim oTmpSkelet As New skl_gemstone
				Me._skelet = oTmpSkelet

				'--- Define Listing Skeleton
				Dim oTmpLstSkelet As New skl_lst_gemstone
				Me._lst_skelet = oTmpLstSkelet

				'--- Define Logics
				Dim oTmpLogics As New cls_gemstone_lgc
				Me._logics = oTmpLogics

				oTmpSkelet = Nothing
				oTmpLstSkelet = Nothing
				oTmpLogics = Nothing

			Case 3
				Me._number = 3
				'--- Define Skeleton
				Dim oTmpSkelet As New skl_jewelry
				Me._skelet = oTmpSkelet

				'--- Define Listing Skeleton
				Dim oTmpLstSkelet As New skl_lst_jewelry
				Me._lst_skelet = oTmpLstSkelet

				'--- Define Logics
				Dim oTmpLogics As New cls_jewelry_lgc
				Me._logics = oTmpLogics

				oTmpSkelet = Nothing
				oTmpLstSkelet = Nothing
				oTmpLogics = Nothing

			Case Else
				Me._number = 0
				'--- Define Skeleton
				Me._skelet = Nothing
				Me._lst_skelet = Nothing
				Me._logics = Nothing


		End Select

		Return False
		Exit Function

ErrorHandler:
		Me._err_number = Err.Number
		Me._err_description = Err.Description
		Me._err_source = Err.Source
		Return True

	End Function



End Class
