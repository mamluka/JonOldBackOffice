Public Class cls_books_lgc
	Inherits iFoundation.cls_error_connection

	Public Function insert(ByVal oGeneral As Collection, ByVal oSuppliers As Collection) As Boolean
		On Error GoTo ErrorHandler
		Dim bError As Boolean = False


		'--- SET supplier books
		Dim oBooks_suppliers_logics As New ion_two.cls_books_suppliers_lgc
		oBooks_suppliers_logics._connection_string = Me._connection_string
		oBooks_suppliers_logics._dbtype = Me._dbtype
		oBooks_suppliers_logics._idac_transaction = Me._idac_transaction
		bError = oBooks_suppliers_logics.insert(oSuppliers)
		If bError Then
			Me._idac_transaction._transaction.Rollback()
			Me._err_number = oBooks_suppliers_logics._err_number
			Me._err_description = oBooks_suppliers_logics._err_description
			Me._err_source = oBooks_suppliers_logics._err_source
			Return True
		End If


		'--- SET General books
		Dim oBooks_general_logics As New ion_two.cls_books_general_lgc
		oBooks_general_logics._connection_string = Me._connection_string
		oBooks_general_logics._dbtype = Me._dbtype
		oBooks_general_logics._idac_transaction = Me._idac_transaction
		bError = oBooks_general_logics.insert(oSuppliers)
		If bError Then
			Me._idac_transaction._transaction.Rollback()
			Me._err_number = oBooks_general_logics._err_number
			Me._err_description = oBooks_general_logics._err_description
			Me._err_source = oBooks_general_logics._err_source
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

End Class
