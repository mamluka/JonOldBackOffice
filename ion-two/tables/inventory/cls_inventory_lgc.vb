Imports System.Text.RegularExpressions
Imports System.Web
Public Class cls_inventory_lgc
    Inherits iFoundation.cls_logics
    Public nullval As DBNull
    Public currencyID As String
    Sub New()

        If Not IsNothing(HttpContext.Current.Session("user")) Then
            Me.currencyID = HttpContext.Current.Session("user")._currencyID
        Else
            Me.currencyID = "USD"
        End If
        '--- Set working table
        Me._tablename = "inv_INVENTORY"

        '--- Get module name
        Dim oTmpStack As New System.Diagnostics.StackFrame
        Me._module = oTmpStack.GetMethod.ReflectedType.FullName()

    End Sub

    Function insert(ByRef oDataTable As skl_inventory) As Boolean
        On Error GoTo ErrorHandler

        '--- local definitions
        Dim bError As Boolean = False

        '--- Get last Itemnumber for supplier
        Dim nTmpItem_no As Int32 = 0
        Dim oTmpSupplierFunctions As New ion_two.cls_supplier_no
        oTmpSupplierFunctions._connection_string = Me._connection_string
        oTmpSupplierFunctions._dbtype = Me._dbtype
        bError = oTmpSupplierFunctions.get_counter(oDataTable._branchnumber, oDataTable._suppliernumber, nTmpItem_no)
        If bError Then
            Me._err_number = oTmpSupplierFunctions._err_number
            Me._err_description = oTmpSupplierFunctions._err_description
            Me._err_source = oTmpSupplierFunctions._err_source
            Return True
        End If
        oDataTable._itemnumberint = nTmpItem_no
        oTmpSupplierFunctions = Nothing

        '--- Construct ItemNumber
        Dim oTmpItemNumberFunctions As New ion_two.cls_itemnumber
        bError = oTmpItemNumberFunctions.get_number(oDataTable._branchnumber, oDataTable._suppliernumber, nTmpItem_no)
        If bError Then
            Me._err_number = oTmpItemNumberFunctions._err_number
            Me._err_description = oTmpItemNumberFunctions._err_description
            Me._err_source = oTmpItemNumberFunctions._err_source
            Return True
        End If
        oDataTable._itemnumber = oTmpItemNumberFunctions._itemnumber_full
        oTmpItemNumberFunctions = Nothing


        '--- Get Dataset
        Dim oTmpDataset As DataSet = New ion_two.ds_inventory
        Dim oTmpDataTable As DataTable = oTmpDataset.Tables(_tablename)

        '--- Assign Order
        Dim oTmpDataRow As DataRow
        oTmpDataRow = oTmpDataTable.NewRow

        oTmpDataRow("PLATETYPE") = oDataTable._platetype
        oTmpDataRow("CATEGORY_ID") = oDataTable._category_id
        oTmpDataRow("SUBCATEGORY_ID") = oDataTable._subcategory_id
        oTmpDataRow("LOCATION_ID") = oDataTable._location_id
        oTmpDataRow("BRANCHNUMBER") = oDataTable._branchnumber
        oTmpDataRow("SUPPLIERNUMBER") = oDataTable._suppliernumber
        oTmpDataRow("ITEMNUMBERINT") = oDataTable._itemnumberint
        oTmpDataRow("ITEMNUMBER") = oDataTable._itemnumber
        oTmpDataRow("ITEMCODE") = oDataTable._itemcode
        oTmpDataRow("SHOPSTATUS") = oDataTable._active
        oTmpDataRow("ITEMDELETED") = oDataTable._deleted
        oTmpDataRow("NO_ORDERALONE") = oDataTable._no_orderalone
        oTmpDataRow("NO_PUBLICAUCTION") = oDataTable._no_publicauction
        oTmpDataRow("STATUS_ID") = oDataTable._status_id
        oTmpDataRow("LANG1_DESCRIPTION") = oDataTable._lang1_description
        oTmpDataRow("LANG2_DESCRIPTION") = oDataTable._lang2_description
        oTmpDataRow("LANG3_DESCRIPTION") = oDataTable._lang3_description
        oTmpDataRow("LANG4_DESCRIPTION") = oDataTable._lang4_description
        oTmpDataRow("LANG5_DESCRIPTION") = oDataTable._lang5_description
        oTmpDataRow("LANG6_DESCRIPTION") = oDataTable._lang6_description
        oTmpDataRow("CREATEDATE") = oDataTable._createdate
        oTmpDataRow("ONPROCESS") = oDataTable._onprocess
        oTmpDataRow("ONAUCTION") = oDataTable._onauction
        oTmpDataRow("ONSPECIAL") = oDataTable._onspecial
        oTmpDataRow("ONSPECIAL_FROM_DATE") = oDataTable._onspecial_from_date
        oTmpDataRow("ONSPECIAL_TO_DATE") = oDataTable._onspecial_to_date
        oTmpDataRow("QTYONSTOCK_CUR") = oDataTable._qtyonstock_cur
        oTmpDataRow("QTYONSTOCK_MIN") = oDataTable._qtyonstock_min
        oTmpDataRow("PURCHASE_PRICE") = oDataTable._purchase_price
        oTmpDataRow("APPRAISAL_PRICE") = oDataTable._appraisal_price
        oTmpDataRow("DEALER_PRICE") = oDataTable._dealer_price
        oTmpDataRow("SELL_PRICE") = oDataTable._sell_price
        oTmpDataRow("SPECIAL_SELL_PRICE") = oDataTable._special_sell_price
        oTmpDataRow("SPECIAL_DEALER_PRICE") = oDataTable._special_dealer_price
        oTmpDataRow("NOTES") = oDataTable._notes
        oTmpDataRow("ICON_NAME") = oDataTable._icon_pic
        oTmpDataRow("PICTURE_NAME") = oDataTable._picture_pic
        oTmpDataRow("PICTURE_HIRES_NAME") = oDataTable._picture_hires_pic
        oTmpDataRow("CERTIFICATE_NAME") = oDataTable._certificate_pic
        oTmpDataRow("MOVIE_NAME") = oDataTable._movie_pic
        oTmpDataRow("GALLERY_NAME") = oDataTable._gallery_pic
        oTmpDataRow("BANNER_NAME") = oDataTable._banner_pic
        oTmpDataRow("SIMILAR_ITEMS") = oDataTable._similar_items
        oTmpDataRow("INDEXWORDS") = oDataTable._indexwords
        oTmpDataRow("REMARKS") = oDataTable._remarks
        oTmpDataRow("CLUB_ITEM") = oDataTable._club_item
        oTmpDataRow("AUTOGENERATED") = oDataTable._autogenerated
        oTmpDataRow("ITEM_SOLD") = oDataTable._item_sold
        oTmpDataRow("SMARTSORT") = oDataTable._smartsort_txt
        oTmpDataRow("onbargain") = oDataTable.onbargain
        oTmpDataRow("samplepic") = oDataTable.samplepic
        oTmpDataRow("has_movie") = oDataTable.has_movie
        oTmpDataRow("has_white_gold") = oDataTable.has_white_gold
        oTmpDataRow("has_yellow_gold") = oDataTable.has_yellow_gold
        oTmpDataRow("ONEBAY") = False
        oTmpDataRow("EBAYID") = ""

        '--- Handle Audit
        oTmpDataRow("LASTMODIFY_DATE") = Date.Now
        oTmpDataRow("LASTMODIFY_USER") = oDataTable._lastmodify_user
        oTmpDataRow("LASTMODIFY_USER_ID") = oDataTable._lastmodify_user_id
        oTmpDataRow("auction_price") = oDataTable.auction_price
        oTmpDataRow("release_date") = oDataTable.release_date
        oTmpDataRow("onfeatured") = oDataTable.featured

        Dim ostringfunc As New iFunctions.cls_string
        oTmpDataRow("opthash") = ostringfunc.Hash2String(oDataTable.opthash, "|", "::")


        oTmpDataTable.Rows.Add(oTmpDataRow)


        '--- Get the correct SUB plate logics
        Dim oTmpPlate As New ion_two.cls_plate
        bError = oTmpPlate.get_plateobject(oDataTable._platetype)
        If bError Then
            Me._err_number = oTmpPlate._err_number
            Me._err_description = oTmpPlate._err_description
            Me._err_source = oTmpPlate._err_source
            Return True
        End If

        '--- Load SubPlate into a datatable
        Dim oTmpSubPlate As Object = oTmpPlate._logics
        oTmpSubPlate._connection_string = Me._connection_string
        oTmpSubPlate._dbtype = Me._dbtype
        bError = oTmpSubPlate.insert(oDataTable._subplate)
        If bError Then
            Me._err_number = oTmpSubPlate._err_number
            Me._err_description = oTmpSubPlate._err_description
            Me._err_source = oTmpSubPlate._err_source
            Return True
        End If


        '### Start transaction
        Dim oTransaction As New iDac.cls_T_transaction
        oTransaction._connection_string = Me._connection_string
        oTransaction._dbtype = Me._dbtype
        bError = oTransaction.start()
        If bError Then
            Me._err_number = oTransaction._err_number
            Me._err_description = oTransaction._err_description
            Me._err_source = oTransaction._err_source
            Return True
        End If

        '### Set MAIN plate and an ID
        '--- Instantiate the Transactor
        Dim oTransactor_1 As New iDac.cls_T_transactor
        oTransactor_1._connection_string = Me._connection_string
        oTransactor_1._dbtype = Me._dbtype

        '--- Prepare and load table 1
        Dim oTable1 As New iDac.cls_cll_datatables
        oTable1._datatable = oTmpDataTable
        oTransactor_1._i_cll_datatables.Add(oTable1)

        '--- Assign the transaction to the transactor
        oTransactor_1._transaction = oTransaction._transaction

        '--- Write Table
        bError = oTransactor_1.transact_insert
        If bError Then
            oTransaction._transaction.Rollback()
            Me._err_number = oTransactor_1._err_number
            Me._err_description = oTransactor_1._err_description
            Me._err_source = oTransactor_1._err_source
            Return True
        End If
        '###

        '--- Prepare SUBplate
        Dim nInventory_id As Int32 = oTransactor_1._i_cll_datatables(1)._info(1)._id
        Dim oTmpSubPlateDatarow As DataRow = oTmpSubPlate._datatable.rows.item(0)
        oTmpSubPlateDatarow("inventory_id") = nInventory_id

        '--- Assign ID to return
        oDataTable._id = nInventory_id


        '### Set SUB plate and an ID
        '--- Instantiate the Transactor
        Dim oTransactor_2 As New iDac.cls_T_transactor
        oTransactor_2._connection_string = Me._connection_string
        oTransactor_2._dbtype = Me._dbtype

        '--- Prepare and load table 2
        Dim oTable2 As New iDac.cls_cll_datatables
        oTable2._datatable = oTmpSubPlate._datatable
        oTransactor_2._i_cll_datatables.Add(oTable2)

        '--- Assign the transaction to the transactor
        oTransactor_2._transaction = oTransaction._transaction

        '--- Write Table
        bError = oTransactor_2.transact_insert
        If bError Then
            oTransaction._transaction.Rollback()
            Me._err_number = oTransactor_2._err_number
            Me._err_description = oTransactor_2._err_description
            Me._err_source = oTransactor_2._err_source
            Return True
        End If
        '###

        If oDataTable._platetype = 3 Then
            ''exit jewel extended

            '' dim 

            Dim oTmpSJewelExtended As New cls_jewel_extended_lgc
            oTmpSJewelExtended._connection_string = Me._connection_string
            oTmpSJewelExtended._dbtype = Me._dbtype

            oDataTable._subplate._jewel_extended.inventory_id = nInventory_id

            bError = oTmpSJewelExtended.insert(oDataTable._subplate._jewel_extended)
            If bError Then
                Me._err_number = oTmpSJewelExtended._err_number
                Me._err_description = oTmpSJewelExtended._err_description
                Me._err_source = oTmpSJewelExtended._err_source
                Return True
            End If


            ''    Dim nInventory_id As Int32 = oTransactor_1._i_cll_datatables(1)._info(1)._id
            'Dim oTmpJewelExtended As DataRow = oTmpSJewelExtended._datatable.Rows.Item(0)
            'oTmpSubPlateDatarow("inventory_id") = nInventory_id

            '--- Assign ID to return
            ''  oTmpSJewelExtended. = nInventory_id

            '--- Instantiate the Transactor
            Dim oTransactor_3 As New iDac.cls_T_transactor
            oTransactor_3._connection_string = Me._connection_string
            oTransactor_3._dbtype = Me._dbtype

            '--- Prepare and load table 2
            Dim oTable3 As New iDac.cls_cll_datatables
            oTable3._datatable = oTmpSJewelExtended._datatable
            oTransactor_3._i_cll_datatables.Add(oTable3)

            '--- Assign the transaction to the transactor
            oTransactor_3._transaction = oTransaction._transaction

            '--- Write Table
            bError = oTransactor_3.transact_insert
            If bError Then
                oTransaction._transaction.Rollback()
                Me._err_number = oTransactor_3._err_number
                Me._err_description = oTransactor_3._err_description
                Me._err_source = oTransactor_3._err_source
                Return True
            End If

        End If
        '--- Update Supplier item counter
        Dim oTmpCounter As New ion_two.cls_supplier_no
        oTmpCounter._connection_string = Me._connection_string
        oTmpCounter._dbtype = Me._dbtype
        oTmpCounter._transaction = oTransaction._transaction

        bError = oTmpCounter.set_counter(oDataTable._branchnumber, oDataTable._suppliernumber, oDataTable._itemnumberint)
        If bError Then
            oTransaction._transaction.Rollback()
            Me._err_number = oTmpCounter._err_number
            Me._err_description = oTmpCounter._err_description
            Me._err_source = oTmpCounter._err_source
            Return True
        End If


        '--- Close the transaction
        bError = oTransaction.close()
        If bError Then
            Me._err_number = oTransaction._err_number
            Me._err_description = oTransaction._err_description
            Me._err_source = oTransaction._err_source
            Return True
        End If

        '### End transaction

        oTable1 = Nothing
        oTransactor_1 = Nothing
        oTransactor_2 = Nothing
        oTransaction = Nothing

        Return False
        Exit Function

ErrorHandler:
        Me._err_number = Err.Number
        Me._err_description = Err.Description
        Me._err_source = Err.Source
        Return True
    End Function

    Function read(ByVal nId As Int32, ByRef oDataTable As skl_inventory) As Boolean
        On Error GoTo ErrorHandler

        '--- local definitions
        Dim bError As Boolean = False

        '--- Get Item
        Dim oReadTransactor As New iDac.cls_T_read
        oReadTransactor._connection_string = Me._connection_string
        oReadTransactor._dbtype = Me._dbtype
        oReadTransactor._tablename = Me._tablename
        bError = oReadTransactor.transact_read(nId)
        If bError Then
            Me._err_number = oReadTransactor._err_number
            Me._err_description = oReadTransactor._err_description
            Me._err_source = oReadTransactor._err_source
            Return True
        End If

        '--- Return Error if no records were fatched
        If oReadTransactor._datatable.Rows.Count = 0 Then
            Err.Raise(7003, Me._module + ":read", "No records fetched.")
        End If

        '--- Map to Skeleton
        Dim oTmpDataRow As DataRow
        oTmpDataRow = oReadTransactor._datatable.Rows(0)
        oDataTable._id = oTmpDataRow("id")
        oDataTable._platetype = oTmpDataRow("PLATETYPE")

        oDataTable._category_id = oTmpDataRow("CATEGORY_ID")
        oDataTable._subcategory_id = oTmpDataRow("SUBCATEGORY_ID")
        oDataTable._location_id = oTmpDataRow("LOCATION_ID")
        oDataTable._branchnumber = oTmpDataRow("BRANCHNUMBER")
        oDataTable._suppliernumber = oTmpDataRow("SUPPLIERNUMBER")
        oDataTable._itemnumberint = oTmpDataRow("ITEMNUMBERINT")
        oDataTable._itemnumber = oTmpDataRow("ITEMNUMBER")
        oDataTable._itemcode = oTmpDataRow("ITEMCODE")
        oDataTable._active = oTmpDataRow("SHOPSTATUS")
        oDataTable._deleted = oTmpDataRow("ITEMDELETED")
        oDataTable._no_orderalone = oTmpDataRow("NO_ORDERALONE")
        oDataTable._no_publicauction = oTmpDataRow("NO_PUBLICAUCTION")
        oDataTable._status_id = oTmpDataRow("STATUS_ID")
        oDataTable._lang1_description = oTmpDataRow("LANG1_DESCRIPTION")
        oDataTable._lang2_description = oTmpDataRow("LANG2_DESCRIPTION")
        oDataTable._lang3_description = oTmpDataRow("LANG3_DESCRIPTION")
        oDataTable._lang4_description = oTmpDataRow("LANG4_DESCRIPTION")
        oDataTable._lang5_description = oTmpDataRow("LANG5_DESCRIPTION")
        oDataTable._lang6_description = oTmpDataRow("LANG6_DESCRIPTION")
        oDataTable._createdate = oTmpDataRow("CREATEDATE")
        oDataTable._onprocess = oTmpDataRow("ONPROCESS")
        oDataTable._onauction = oTmpDataRow("ONAUCTION")
        oDataTable._onspecial = oTmpDataRow("ONSPECIAL")
        oDataTable._onspecial_from_date = oTmpDataRow("ONSPECIAL_FROM_DATE")
        oDataTable._onspecial_to_date = oTmpDataRow("ONSPECIAL_TO_DATE")
        oDataTable._qtyonstock_cur = oTmpDataRow("QTYONSTOCK_CUR")
        oDataTable._qtyonstock_min = oTmpDataRow("QTYONSTOCK_MIN")
        oDataTable._purchase_price = oTmpDataRow("PURCHASE_PRICE")
        oDataTable._appraisal_price = oTmpDataRow("APPRAISAL_PRICE")
        oDataTable._dealer_price = oTmpDataRow("DEALER_PRICE")
        oDataTable._sell_price = oTmpDataRow("SELL_PRICE")
        oDataTable._special_sell_price = oTmpDataRow("SPECIAL_SELL_PRICE")
        oDataTable._special_dealer_price = oTmpDataRow("SPECIAL_DEALER_PRICE")
        oDataTable._notes = oTmpDataRow("NOTES")
        oDataTable._icon_pic = oTmpDataRow("ICON_NAME")
        oDataTable._picture_pic = oTmpDataRow("PICTURE_NAME")
        oDataTable._picture_hires_pic = oTmpDataRow("PICTURE_HIRES_NAME")
        oDataTable._certificate_pic = oTmpDataRow("CERTIFICATE_NAME")
        oDataTable._movie_pic = oTmpDataRow("MOVIE_NAME")
        oDataTable._gallery_pic = oTmpDataRow("GALLERY_NAME")
        oDataTable._banner_pic = oTmpDataRow("BANNER_NAME")
        oDataTable._similar_items = oTmpDataRow("SIMILAR_ITEMS")
        oDataTable._indexwords = oTmpDataRow("INDEXWORDS")
        oDataTable._remarks = oTmpDataRow("REMARKS")
        oDataTable._club_item = oTmpDataRow("CLUB_ITEM")
        oDataTable._autogenerated = oTmpDataRow("AUTOGENERATED")
        oDataTable._item_sold = oTmpDataRow("ITEM_SOLD")
        oDataTable.has_movie = oTmpDataRow("has_movie")
        oDataTable.has_white_gold = oTmpDataRow("has_white_gold")
        oDataTable.has_yellow_gold = oTmpDataRow("has_yellow_gold")
        If ((oDataTable._category_id = 7) And (oDataTable._subcategory_id = 31)) Then
            On Error Resume Next
            oDataTable._middlestone = oTmpDataRow.Item("MIDDLESTONE")
        End If

        If Not Convert.IsDBNull(oTmpDataRow.Item("smartsort")) Then
            oDataTable._smartsort_txt = oTmpDataRow.Item("smartsort")
        End If

        If Not Convert.IsDBNull(oTmpDataRow.Item("release_date")) Then
            oDataTable.release_date = oTmpDataRow.Item("release_Date")

        End If

        If Not Convert.IsDBNull(oTmpDataRow.Item("auction_price")) Then
            oDataTable.auction_price = oTmpDataRow.Item("auction_price")

        End If

        If Not Convert.IsDBNull(oTmpDataRow.Item("onbargain")) Then
            oDataTable.onbargain = oTmpDataRow.Item("onbargain")

        End If


        If Not Convert.IsDBNull(oTmpDataRow.Item("samplepic")) Then
            oDataTable.samplepic = oTmpDataRow.Item("samplepic")

        End If

        If Not Convert.IsDBNull(oTmpDataRow.Item("onfeatured")) Then
            oDataTable.featured = oTmpDataRow.Item("onfeatured")

        End If

        If Not Convert.IsDBNull(oTmpDataRow.Item("opthash")) Then
            Dim ostringfunc As New iFunctions.cls_string
            oDataTable.opthash = ostringfunc.HashfromString(oTmpDataRow.Item("opthash"), "|", "::")

        End If

        ''priceing conversion

        Dim ocurrency As New cls_currency
        ocurrency._connection_string = Me._connection_string
        ocurrency._dbtype = Me._dbtype
        Dim ocurrency_obj As New skl_currency

        ocurrency.ReadCurrencyByCode(Me.currencyID, ocurrency_obj)

        oDataTable._sell_price *= ocurrency_obj.rate
        oDataTable._dealer_price *= ocurrency_obj.rate
        oDataTable._special_dealer_price *= ocurrency_obj.rate
        oDataTable._special_sell_price *= ocurrency_obj.rate
        oDataTable._purchase_price *= ocurrency_obj.rate

        oDataTable._sell_price = Math.Round(oDataTable._sell_price)
        oDataTable._dealer_price = Math.Round(oDataTable._dealer_price)
        oDataTable._special_dealer_price = Math.Round(oDataTable._special_dealer_price)
        oDataTable._special_sell_price = Math.Round(oDataTable._special_sell_price)
        oDataTable._purchase_price = Math.Round(oDataTable._purchase_price)



        '--- Handle Audit
        oDataTable._lastmodify_date = oTmpDataRow("LASTMODIFY_DATE")
        oDataTable._lastmodify_user = oTmpDataRow("LASTMODIFY_USER")
        oDataTable._lastmodify_user_id = oTmpDataRow("LASTMODIFY_USER_ID")

        '--- cleanup
        oTmpDataRow = Nothing

        '--- Get subplate
        If oDataTable._platetype > 0 Then

            '--- Get SUB-Plate Sekelet and logics
            Dim oTmpPlate As New ion_two.cls_plate
            bError = oTmpPlate.get_plateobject(oDataTable._platetype)
            If bError Then
                Me._err_number = oTmpPlate._err_number
                Me._err_description = oTmpPlate._err_description
                Me._err_source = oTmpPlate._err_source
            End If

            '--- Define
            Dim oTmpSubPlate As New Object
            oTmpSubPlate = oTmpPlate._skelet

            '---
            Dim oTmpSubPateLogics As New Object
            oTmpSubPateLogics = oTmpPlate._logics


            oTmpSubPateLogics._connection_string = Me._connection_string
            oTmpSubPateLogics._dbtype = Me._dbtype
            bError = oTmpSubPateLogics.read(nId, oTmpSubPlate)
            If bError Then
                Me._err_number = oTmpSubPateLogics._err_number
                Me._err_description = oTmpSubPateLogics._err_description
                Me._err_source = oTmpSubPateLogics._err_source
                Return True
            End If

            oDataTable._subplate = oTmpSubPlate

            ''load jewel extended
            If oDataTable._platetype = 3 Then

                Dim oTmpJewelExtended_lgc As New cls_jewel_extended_lgc
                Dim oTmpJewelExtended As New skl_jewel_extended
                oTmpJewelExtended_lgc._connection_string = Me._connection_string
                oTmpJewelExtended_lgc._dbtype = Me._dbtype
                bError = oTmpJewelExtended_lgc.read(nId, oTmpJewelExtended)
                If bError Then
                    Me._err_number = oTmpJewelExtended_lgc._err_number
                    Me._err_description = oTmpJewelExtended_lgc._err_description
                    Me._err_source = oTmpJewelExtended_lgc._err_source
                    Return True
                End If

                oDataTable._subplate._jewel_extended = oTmpJewelExtended


            End If


            oTmpPlate = Nothing
            oTmpSubPateLogics = Nothing
        End If

        Return False
        Exit Function

ErrorHandler:
        Me._err_number = Err.Number
        Me._err_description = Err.Description
        Me._err_source = Err.Source
        Return True
    End Function

    Function update(ByRef oDataTable As skl_inventory, Optional ByVal replicate As Boolean = False) As Boolean
        On Error GoTo ErrorHandler

        '--- local definitions
        Dim bError As Boolean = False

        '--- CUSTOM ERROR: Return Error if ID not passed in skeleton
        If oDataTable._id <= 0 Then
            Err.Raise(7006, Me._module + ":update", "No ID passed with skeleton.")
        End If

        Dim oTmpTransact As New iDac.cls_T_read
        oTmpTransact._connection_string = Me._connection_string
        oTmpTransact._dbtype = Me._dbtype
        oTmpTransact._tablename = Me._tablename
        bError = oTmpTransact.transact_read(oDataTable._id)
        If bError Then
            Me._err_number = oTmpTransact._err_number
            Me._err_description = oTmpTransact._err_description
            Me._err_source = oTmpTransact._err_source
            Return True
        End If

        '--- Get DataTable
        Dim oTmpDataTable As DataTable = oTmpTransact._datatable

        '--- Assign Order
        Dim oTmpDataRow As DataRow
        oTmpDataRow = oTmpDataTable.Rows(0)

        oDataTable._itemnumber = oTmpDataRow("ITEMNUMBER")

        'oTmpDataRow("PLATETYPE") = oDataTable._platetype
        oTmpDataRow("CATEGORY_ID") = oDataTable._category_id
        oTmpDataRow("SUBCATEGORY_ID") = oDataTable._subcategory_id
        oTmpDataRow("LOCATION_ID") = oDataTable._location_id
        'oTmpDataRow("BRANCHNUMBER") = oDataTable._branchnumber
        'oTmpDataRow("SUPPLIERNUMBER") = oDataTable._suppliernumber
        'oTmpDataRow("ITEMNUMBERINT") = oDataTable._itemnumberint
        'oTmpDataRow("ITEMNUMBER") = oDataTable._itemnumber
        oTmpDataRow("ITEMCODE") = oDataTable._itemcode
        oTmpDataRow("SHOPSTATUS") = oDataTable._active
        oTmpDataRow("ITEMDELETED") = oDataTable._deleted
        oTmpDataRow("NO_ORDERALONE") = oDataTable._no_orderalone
        oTmpDataRow("NO_PUBLICAUCTION") = oDataTable._no_publicauction
        oTmpDataRow("STATUS_ID") = oDataTable._status_id
        oTmpDataRow("LANG1_DESCRIPTION") = oDataTable._lang1_description
        oTmpDataRow("LANG2_DESCRIPTION") = oDataTable._lang2_description
        oTmpDataRow("LANG3_DESCRIPTION") = oDataTable._lang3_description
        oTmpDataRow("LANG4_DESCRIPTION") = oDataTable._lang4_description
        oTmpDataRow("LANG5_DESCRIPTION") = oDataTable._lang5_description
        oTmpDataRow("LANG6_DESCRIPTION") = oDataTable._lang6_description
        'oTmpDataRow("CREATEDATE") = oDataTable._createdate
        oTmpDataRow("ONPROCESS") = oDataTable._onprocess
        oTmpDataRow("ONAUCTION") = oDataTable._onauction
        oTmpDataRow("ONSPECIAL") = oDataTable._onspecial
        oTmpDataRow("ONSPECIAL_FROM_DATE") = oDataTable._onspecial_from_date
        oTmpDataRow("ONSPECIAL_TO_DATE") = oDataTable._onspecial_to_date
        oTmpDataRow("QTYONSTOCK_CUR") = oDataTable._qtyonstock_cur
        oTmpDataRow("QTYONSTOCK_MIN") = oDataTable._qtyonstock_min
        If Not replicate Then
            oTmpDataRow("PURCHASE_PRICE") = oDataTable._purchase_price
            oTmpDataRow("APPRAISAL_PRICE") = oDataTable._appraisal_price
            oTmpDataRow("DEALER_PRICE") = oDataTable._dealer_price
            oTmpDataRow("SELL_PRICE") = oDataTable._sell_price
            oTmpDataRow("SPECIAL_SELL_PRICE") = oDataTable._special_sell_price
            oTmpDataRow("SPECIAL_DEALER_PRICE") = oDataTable._special_dealer_price
        End If
        oTmpDataRow("NOTES") = oDataTable._notes
        oTmpDataRow("ICON_NAME") = oDataTable._icon_pic
        oTmpDataRow("PICTURE_NAME") = oDataTable._picture_pic
        oTmpDataRow("PICTURE_HIRES_NAME") = oDataTable._picture_hires_pic
        oTmpDataRow("CERTIFICATE_NAME") = oDataTable._certificate_pic
        oTmpDataRow("MOVIE_NAME") = oDataTable._movie_pic
        oTmpDataRow("GALLERY_NAME") = oDataTable._gallery_pic
        oTmpDataRow("BANNER_NAME") = oDataTable._banner_pic
        oTmpDataRow("SIMILAR_ITEMS") = oDataTable._similar_items
        oTmpDataRow("INDEXWORDS") = oDataTable._indexwords
        oTmpDataRow("REMARKS") = oDataTable._remarks
        oTmpDataRow("CLUB_ITEM") = oDataTable._club_item
        oTmpDataRow("AUTOGENERATED") = oDataTable._autogenerated
        oTmpDataRow("ITEM_SOLD") = oDataTable._item_sold
        oTmpDataRow("SMARTSORT") = oDataTable._smartsort_txt
        oTmpDataRow("release_date") = oDataTable.release_date
        oTmpDataRow("auction_price") = oDataTable.auction_price
        oTmpDataRow("onbargain") = oDataTable.onbargain
        oTmpDataRow("samplepic") = oDataTable.samplepic
        oTmpDataRow("onfeatured") = oDataTable.featured
        oTmpDataRow("has_movie") = oDataTable.has_movie
        oTmpDataRow("has_yellow_gold") = oDataTable.has_yellow_gold
        oTmpDataRow("has_white_gold") = oDataTable.has_white_gold

        If Not replicate Then

            Dim ostringfunc As New iFunctions.cls_string
            oTmpDataRow("opthash") = ostringfunc.Hash2String(oDataTable.opthash, "|", "::")
        End If
        '--- Handle Audit
        oTmpDataRow("LASTMODIFY_DATE") = Date.Now
        oTmpDataRow("LASTMODIFY_USER") = oDataTable._lastmodify_user
        oTmpDataRow("LASTMODIFY_USER_ID") = Me._user_id



        '--- Get the correct SUB plate logics
        Dim oTmpPlate As New ion_two.cls_plate
        bError = oTmpPlate.get_plateobject(oDataTable._platetype)
        If bError Then
            Me._err_number = oTmpPlate._err_number
            Me._err_description = oTmpPlate._err_description
            Me._err_source = oTmpPlate._err_source
            Return True
        End If

        '--- Load SubPlate into a datatable
        Dim oTmpSubPlate As Object = oTmpPlate._logics
        oTmpSubPlate._connection_string = Me._connection_string
        oTmpSubPlate._dbtype = Me._dbtype
        bError = oTmpSubPlate.update(oDataTable._subplate, replicate)
        If bError Then
            Me._err_number = oTmpSubPlate._err_number
            Me._err_description = oTmpSubPlate._err_description
            Me._err_source = oTmpSubPlate._err_source
            Return True
        End If


        '--- Instantiate the Transactor
        Dim oTransactor As New iDac.cls_T_transactor
        oTransactor._connection_string = Me._connection_string
        oTransactor._dbtype = Me._dbtype

        '--- Prepare and load table 1
        Dim oTable1 As New iDac.cls_cll_datatables
        oTable1._datatable = oTmpDataTable
        oTransactor._i_cll_datatables.Add(oTable1)

        '--- Prepare and load table 2
        Dim oTable2 As New iDac.cls_cll_datatables
        oTable2._datatable = oTmpSubPlate._datatable
        oTransactor._i_cll_datatables.Add(oTable2)

        If Not replicate Then
            If oDataTable._platetype = 3 Then
                '--- Load SubPlate into a datatable
                Dim oTmpJewelExtended_lgc As New cls_jewel_extended_lgc
                ''  Dim oTmpJewelExtended As New skl_jewel_extended
                oTmpJewelExtended_lgc._connection_string = Me._connection_string
                oTmpJewelExtended_lgc._dbtype = Me._dbtype
                bError = oTmpJewelExtended_lgc.update(oDataTable._subplate._jewel_extended)
                If bError Then
                    Me._err_number = oTmpJewelExtended_lgc._err_number
                    Me._err_description = oTmpJewelExtended_lgc._err_description
                    Me._err_source = oTmpJewelExtended_lgc._err_source
                    Return True
                End If

                ''  oDataTable._subplate._jewel_extended = oTmpJewelExtended

                Dim oTable3 As New iDac.cls_cll_datatables
                oTable3._datatable = oTmpJewelExtended_lgc._datatable
                oTransactor._i_cll_datatables.Add(oTable3)
            End If
        End If


        bError = oTransactor.transact_update
        If bError Then
            Me._err_number = oTransactor._err_number
            Me._err_description = oTransactor._err_description
            Me._err_source = oTransactor._err_source
            Return True
        End If

        oTable1 = Nothing
        oTable2 = Nothing
        oTransactor = Nothing
        oTmpSubPlate = Nothing

        Return False
        Exit Function

ErrorHandler:
        Me._err_number = Err.Number
        Me._err_description = Err.Description
        Me._err_source = Err.Source
        Return True

    End Function
    Public Overloads Function load(ByVal nId As Int32, ByRef oDataTable As skl_lst_inventory, Optional ByVal oPictures As ion_two.cls_pictures = Nothing, Optional ByVal bIsdealer As Boolean = False, Optional ByVal bSSL As Boolean = False, Optional ByVal cPicDir As String = "") As Boolean
        On Error GoTo ErrorHandler
        Dim bError As Boolean = False

        '--- If we are search-loading
        If nId > 0 Then

            '--- Get plate
            Dim nPlate As Int32
            Dim oTmpPlate As New ion_two.cls_plate
            oTmpPlate._connection_string = Me._connection_string
            oTmpPlate._dbtype = Me._dbtype
            bError = oTmpPlate.get_platefromid(nId)
            If bError Then
                Me._err_number = oTmpPlate._err_number
                Me._err_description = oTmpPlate._err_description
                Me._err_source = oTmpPlate._err_source
                Return True
            End If

            '--- Get the correct SQL string
            Dim cSQL As String
            Select Case oTmpPlate._number
                Case 1
                    cSQL = "select * from vv_diamonds_full where id = " + System.Convert.ToString(nId)
                Case 2
                    cSQL = "select * from vv_gemstones_full where id = " + System.Convert.ToString(nId)
                Case 3
                    cSQL = "select * from vv_jewelry_full where id = " + System.Convert.ToString(nId)
            End Select


            '--- get Record
            Dim oIdac As New iDac.cls_T_read
            oIdac._connection_string = Me._connection_string
            oIdac._dbtype = Me._dbtype
            bError = oIdac.transact_read(cSQL)
            If bError Then
                Me._err_number = oIdac._err_number
                Me._err_description = oIdac._err_description
                Me._err_source = oIdac._err_source
                Return True
            End If

            '--- Get convert ROW into Readable table
            bError = Me.load(1, oIdac._datatable.Rows(0), oDataTable, oPictures, bIsdealer, bSSL, cPicDir)
            If bError Then
                Me._err_number = Err.Number
                Me._err_description = Err.Description
                Me._err_source = Err.Source
                Return True
            End If

        End If


        Return False
        Exit Function

ErrorHandler:
        Me._err_number = Err.Number
        Me._err_description = Err.Description
        Me._err_source = Err.Source
        Return True

    End Function


    Public Overloads Function load(ByVal nMode As Int16, ByVal oDataRow As DataRow, ByRef oDataTable As skl_lst_inventory, Optional ByVal oPictures As ion_two.cls_pictures = Nothing, Optional ByVal bIsdealer As Boolean = False, Optional ByVal bSSL As Boolean = False, Optional ByVal cPicDir As String = "") As Boolean
        On Error GoTo ErrorHandler
        Dim bError As Boolean = False



        oDataTable._id = oDataRow.Item("id")
        oDataTable._platetype = oDataRow.Item("platetype")
        oDataTable._branchnumber = oDataRow.Item("branchnumber")
        oDataTable._suppliernumber = oDataRow.Item("suppliernumber")
        oDataTable._itemnumber = oDataRow.Item("itemnumber")
        oDataTable._itemcode = oDataRow.Item("itemcode")
        oDataTable._category_id = oDataRow.Item("category_id")
        oDataTable._subcategory_id = oDataRow.Item("subcategory_id")
        oDataTable._active = oDataRow.Item("shopstatus")
        oDataTable._no_orderalone = oDataRow.Item("no_orderalone")
        oDataTable._no_publicauction = oDataRow.Item("no_publicauction")
        oDataTable._lang1_description = oDataRow.Item("description1")
        oDataTable._lang2_description = oDataRow.Item("description2")
        oDataTable._lang3_description = oDataRow.Item("description3")
        oDataTable._lang4_description = oDataRow.Item("description4")
        oDataTable._lang5_description = oDataRow.Item("description5")
        oDataTable._lang6_description = oDataRow.Item("description6")
        oDataTable._onprocess = oDataRow.Item("onprocess")
        oDataTable._onauction = oDataRow.Item("onauction")
        oDataTable._onspecial = oDataRow.Item("onspecial")
        oDataTable._onspecial_from_date = oDataRow.Item("onspecial_from_date")
        oDataTable._onspecial_to_date = oDataRow.Item("onspecial_to_date")
        oDataTable._location = oDataRow.Item("location")
        oDataTable._status = oDataRow.Item("status")
        oDataTable._club_item = oDataRow.Item("clubitem")
        oDataTable._itemnumberint = oDataRow.Item("itemnoint")
        oDataTable._createdate = oDataRow.Item("createdate")
        oDataTable._subcategory_name = oDataRow("subcategory_name")
        oDataTable._category_name = oDataRow("category_name")
        oDataTable._appraisal_price = oDataRow.Item("appraisal_price")
        oDataTable._dealer_price = oDataRow.Item("dealer_price")
        oDataTable._sell_price = oDataRow.Item("sell_price")
        oDataTable._special_sell_price = oDataRow.Item("special_sell_price")
        oDataTable._special_dealer_price = oDataRow.Item("special_dealer_price")
        oDataTable._qtyonstock_cur = oDataRow.Item("qtyonstock_cur")
        oDataTable._qtyonstock_min = oDataRow.Item("qtyonstock_min")
        oDataTable._item_sold = oDataRow.Item("item_sold")
        oDataTable._picture_hires_pic = oDataRow.Item("picture_hires_name")
        oDataTable._movie_pic = oDataRow.Item("movie_name")
        oDataTable._certificate_pic = oDataRow.Item("certificate_name")
        oDataTable._gallery_pic = oDataRow.Item("gallery_name")

        oDataTable._banner_pic = oDataRow.Item("banner_name")

        If Not Convert.IsDBNull(oDataRow.Item("smartsort")) Then
            oDataTable._smartsort_txt = oDataRow.Item("smartsort")
        End If
        '' this is added to prevent errors middle stone is present only inside jwwelry
        If ((oDataTable._category_id = 7) And (oDataTable._subcategory_id = 31)) Then
            On Error Resume Next
            oDataTable._middlestone = oDataRow.Item("MIDDLESTONE")
        End If

        If Not Convert.IsDBNull(oDataRow.Item("release_date")) Then
            oDataTable.release_date = oDataRow.Item("release_Date")

        End If

        If Not Convert.IsDBNull(oDataRow.Item("auction_price")) Then
            oDataTable.auction_price = oDataRow.Item("auction_price")

        End If

        If Not Convert.IsDBNull(oDataRow.Item("onbargain")) Then
            oDataTable.onbargain = oDataRow.Item("onbargain")

        End If

        If Not Convert.IsDBNull(oDataRow.Item("samplepic")) Then
            oDataTable.samplepic = oDataRow.Item("samplepic")

        End If
        If Not Convert.IsDBNull(oDataRow.Item("onfeatured")) Then
            oDataTable.featured = oDataRow.Item("onfeatured")

        End If

        If Not Convert.IsDBNull(oDataRow.Item("opthash")) Then
            Dim ostringfunc As New iFunctions.cls_string
            oDataTable.opthash = ostringfunc.HashfromString(oDataRow.Item("opthash"), "|", "::")

        End If

        '--- Format currency
        Dim oStringFunctions As New iFunctions.cls_string
        bError = oStringFunctions.format_currency(oDataTable._appraisal_price, oDataTable._s_appraisal_price, "us$")
        bError = oStringFunctions.format_currency(oDataTable._dealer_price, oDataTable._s_dealer_price, "us$")
        bError = oStringFunctions.format_currency(oDataTable._sell_price, oDataTable._s_sell_price, "us$")
        bError = oStringFunctions.format_currency(oDataTable._special_sell_price, oDataTable._s_special_sell_price, "us$")
        bError = oStringFunctions.format_currency(oDataTable._special_dealer_price, oDataTable._s_special_dealer_price, "us$")
        oStringFunctions = Nothing

        '--- Get collection
        Dim oTmpStringFunction As New iFunctions.cls_string
        bError = oTmpStringFunction.string2collection(oDataRow.Item("similar_items"), oDataTable._similar_items)
        If bError Then
            Me._err_number = oTmpStringFunction._err_number
            Me._err_description = oTmpStringFunction._err_description
            Me._err_source = oTmpStringFunction._err_source
            Return True
        End If
        oTmpStringFunction = Nothing


        '--- Get proper paths
        If Not oPictures Is Nothing Then

            oPictures._ssl = bSSL

            bError = oPictures.format_picture(oPictures, oDataTable._category_id, 1, oDataRow.Item("icon_name"), oDataTable._is_icon)
            oDataTable._icon_pic = oPictures._result
            oDataTable._ssl_icon_pic = oPictures._path_ssl

            bError = oPictures.format_picture(oPictures, oDataTable._category_id, 2, oDataRow.Item("picture_name"), oDataTable._is_picture)
            oDataTable._picture_pic = oPictures._result
            oDataTable._picture_pic_direct = cPicDir + oPictures._direct_path

            bError = oPictures.format_picture(oPictures, oDataTable._category_id, 3, oDataRow.Item("picture_hires_name"), oDataTable._is_hires)
            oDataTable._picture_hires_pic = oPictures._result

            bError = oPictures.format_picture(oPictures, oDataTable._category_id, 4, oDataRow.Item("gallery_name"), oDataTable._is_gallery)
            oDataTable._gallery_pic = oPictures._result

            bError = oPictures.format_picture(oPictures, oDataTable._category_id, 5, oDataRow.Item("banner_name"), oDataTable._is_banner)
            oDataTable._banner_pic = oPictures._result

            bError = oPictures.format_picture(oPictures, oDataTable._category_id, 6, oDataRow.Item("movie_name"), oDataTable._is_movie)
            oDataTable._movie_pic = oPictures._result

            bError = oPictures.format_picture(oPictures, oDataTable._category_id, 7, oDataRow.Item("certificate_name"), oDataTable._is_report)
            oDataTable._certificate_pic = oPictures._result
        End If

        '--- if we are searching on plate not MIX mode
        If nMode < 10 Then
            oDataTable._notes = oDataRow.Item("notes")

        End If

        '--- Get SUBplate
        Dim oTmpPlate As New ion_two.cls_plate
        bError = oTmpPlate.get_plateobject(oDataTable._platetype)
        If bError Then
            Me._err_number = oTmpPlate._err_number
            Me._err_description = oTmpPlate._err_description
            Me._err_source = oTmpPlate._err_source
            Return True
        End If

        '--- Load SUBplate
        Dim oTmpPlateLogics As Object = oTmpPlate._logics
        Dim oTmpSubplate As Object = oTmpPlate._lst_skelet
        oTmpPlateLogics._connection_string = Me._connection_string
        oTmpPlateLogics._dbtype = Me._dbtype
        bError = oTmpPlateLogics.load(nMode, oDataRow, oTmpSubplate, oPictures, bIsdealer, bSSL)
        If bError Then
            Me._err_number = oTmpPlateLogics._err_number
            Me._err_description = oTmpPlateLogics._err_description
            Me._err_source = oTmpPlateLogics._err_source
            Return True
        End If

        '--- Assign SUBPLATE
        oDataTable._subplate = oTmpSubplate

        ''load jewel extended
        If oDataTable._platetype = 3 Then
            '--- get Record
            Dim oIdac As New iDac.cls_T_read
            oIdac._connection_string = Me._connection_string
            oIdac._dbtype = Me._dbtype
            bError = oIdac.transact_read("select * from inv_jewel_extended where inventory_id = " + oDataTable._id.ToString)
            If bError Then
                Me._err_number = oIdac._err_number
                Me._err_description = oIdac._err_description
                Me._err_source = oIdac._err_source
                Return True
            End If


            Dim oTmpJewelExtended_lgc As New cls_jewel_extended_lgc
            Dim oTmpJewelExtended As New skl_jewel_extended
            oTmpJewelExtended_lgc._connection_string = Me._connection_string
            oTmpJewelExtended_lgc._dbtype = Me._dbtype
            bError = oTmpJewelExtended_lgc.load(oIdac._datatable.Rows(0), oTmpJewelExtended)
            If bError Then
                Me._err_number = oTmpJewelExtended_lgc._err_number
                Me._err_description = oTmpJewelExtended_lgc._err_description
                Me._err_source = oTmpJewelExtended_lgc._err_source
                Return True
            End If

            oDataTable._subplate._jewel_extended = oTmpJewelExtended


        End If




        '--- Get Description
        Dim oTmpDescription As New ion_two.cons_description
        bError = oTmpDescription.construct(oDataTable)
        If bError Then
            Me._err_number = oTmpDescription._err_number
            Me._err_description = oTmpDescription._err_description
            Me._err_source = oTmpDescription._err_source
            Return True
        End If
        '--- Assign description
        oDataTable._item_description = oTmpDescription._description
        oDataTable._item_description_round = oTmpDescription._description_round


        oDataTable._item_description_extended = oTmpDescription._description_extended

        '####
        oDataTable._item_description_title = oTmpDescription._description_round

        '--- <br> striped description
        Dim oString_functions As New iFunctions.cls_string
        bError = oString_functions.strip_html("<br>", oDataTable._item_description_title)
        If bError Then
            Me._err_number = oString_functions._err_number
            Me._err_description = oString_functions._err_description
            Me._err_source = oString_functions._err_source
            Return True
        End If

        '--- <b> striped description
        bError = oString_functions.strip_html("<b>", oDataTable._item_description_title)
        If bError Then
            Me._err_number = oString_functions._err_number
            Me._err_description = oString_functions._err_description
            Me._err_source = oString_functions._err_source
            Return True
        End If

        '--- </b> striped description
        bError = oString_functions.strip_html("</b>", oDataTable._item_description_title)
        If bError Then
            Me._err_number = oString_functions._err_number
            Me._err_description = oString_functions._err_description
            Me._err_source = oString_functions._err_source
            Return True
        End If
        '####

        '--- Do Pricing   
        Dim se_price As Decimal = 0
        If oDataTable._platetype = 3 Then
            If oDataTable._subplate.se_relateditem_id > 0 Then
                Dim oseitem As New ion_two.cls_stone_exchange
                Dim str As String
                oseitem.Conn_String = Me._connection_string
                oseitem.db_type = Me._dbtype
                oseitem.load_stone_exchange_byid(oDataTable._subplate.se_relateditem_id, se_price)
            End If
        End If

        Dim ocurrency As New cls_currency
        ocurrency._connection_string = Me._connection_string
        ocurrency._dbtype = Me._dbtype
        Dim ocurrency_obj As New skl_currency

        ocurrency.ReadCurrencyByCode(Me.currencyID, ocurrency_obj)
        oDataTable._appraisal_price *= ocurrency_obj.rate
        oDataTable._sell_price *= ocurrency_obj.rate
        oDataTable._dealer_price *= ocurrency_obj.rate
        oDataTable._purchase_price *= ocurrency_obj.rate
        oDataTable._special_dealer_price *= ocurrency_obj.rate
        oDataTable._special_sell_price *= ocurrency_obj.rate





        Dim oPrice As New ion_two.cons_price
        oPrice._isdealer = bIsdealer
        oPrice._sell_price = oDataTable._sell_price + se_price
        oPrice._isspecial = oDataTable._onspecial
        oPrice._special_from = oDataTable._onspecial_from_date
        oPrice._special_to = oDataTable._onspecial_to_date
        oPrice._dealer_price = oDataTable._dealer_price + se_price
        oPrice._special_dealer_price = oDataTable._special_dealer_price + se_price
        oPrice._special_sell_price = oDataTable._special_sell_price + se_price
        oPrice._onbargain = oDataTable.onbargain

        bError = oPrice.get_price_html()
        If bError Then
            Me._err_number = oTmpDescription._err_number
            Me._err_description = oTmpDescription._err_description
            Me._err_source = oTmpDescription._err_source
            Return True
        End If
        bError = oPrice.get_price()
        If bError Then
            Me._err_number = oTmpDescription._err_number
            Me._err_description = oTmpDescription._err_description
            Me._err_source = oTmpDescription._err_source
            Return True
        End If
        oDataTable._pricing = oPrice

        '--- Release
        oString_functions = Nothing
        oTmpPlate = Nothing
        oTmpPlateLogics = Nothing
        oDataRow = Nothing
        oTmpDescription = Nothing
        oPictures = Nothing
        oPrice = Nothing

        Return False
        Exit Function

ErrorHandler:
        Me._err_number = Err.Number
        Me._err_description = Err.Description
        Me._err_source = Err.Source
        Return True

    End Function

    Public Overloads Function load_idex(ByVal idex_id As Int64, ByRef oDataTable As cls_idexPlateItem) As Boolean
        On Error GoTo ErrorHandler
        Dim bError As Boolean = False
        Dim csql As String = "select * from inv_idex where idex_id = " + idex_id.ToString
        Dim oIdac As New iDac.cls_T_read
        oIdac._connection_string = Me._connection_string
        oIdac._dbtype = Me._dbtype
        bError = oIdac.transact_read(csql)
        If bError Then
            Me._err_number = oIdac._err_number
            Me._err_description = oIdac._err_description
            Me._err_source = oIdac._err_source
            Return True
        End If





        Dim oDataRow As DataRow = oIdac._datatable.Rows(0)


        oDataTable.itemid = Me.ProtectFromNull(oDataRow.Item("idex_id"))
        oDataTable.location = Me.ProtectFromNull(oDataRow.Item("country"))
        oDataTable.certificate = "-" ''Me.ProtectFromNull(oDataRow.Item("certificate"))
        oDataTable.certificate_number = "-" ''Me.ProtectFromNull(oDataRow.Item("certificate"))
        oDataTable.certificate_path = Me.ProtectFromNull(oDataRow.Item("certificate_path"))
        oDataTable.clarity = Me.ProtectFromNull(oDataRow.Item("clarity"))
        oDataTable.color = Me.ProtectFromNull(oDataRow.Item("color"))
        oDataTable.crown_height = Me.ProtectFromNull(oDataRow.Item("crown_height"))
        oDataTable.culet = Me.ProtectFromNull(oDataRow.Item("culet"))
        oDataTable.girdle = Me.ProtectFromNull(oDataRow.Item("girdle"))
        oDataTable.graining = Me.ProtectFromNull(oDataRow.Item("graining"))
        oDataTable.make = Me.ProtectFromNull(oDataRow.Item("make"))
        oDataTable.measurements = Me.ProtectFromNull(oDataRow.Item("measurements"))
        oDataTable.pavilion = Me.ProtectFromNull(oDataRow.Item("pavilion"))
        oDataTable.polish = Me.ProtectFromNull(oDataRow.Item("polish"))
        oDataTable.ppc = Me.ProtectFromNull(oDataRow.Item("ppc"), 1)
        oDataTable.price = Me.ProtectFromNull(oDataRow.Item("sell_price"))
        oDataTable.shape = Me.ProtectFromNull(oDataRow.Item("shape"))
        oDataTable.supplier = Me.ProtectFromNull(oDataRow.Item("supplier"))
        oDataTable.symmetry = Me.ProtectFromNull(oDataRow.Item("symmetry"))
        oDataTable.table_width = Me.ProtectFromNull(oDataRow.Item("table_width"))
        oDataTable.total_depth = Me.ProtectFromNull(oDataRow.Item("total_depth"))
        oDataTable.weight = Me.ProtectFromNull(oDataRow.Item("weight"))
        oDataTable.fluorescence = Me.ProtectFromNull(oDataRow.Item("fluorescence"))

        Dim ostringfunc As New iFunctions.cls_string
        ostringfunc.format_currency(oDataTable.price, oDataTable.price_formatted, " $")
        ostringfunc.format_decimal(oDataTable.weight, oDataTable.weight_formatted, " Ct.")


        oDataTable._item_description = "<strong>" + oDataTable.weight_formatted + "</strong><br>"

        oDataTable._item_description += "Diamond<br>"
        oDataTable._item_description += "<strong>" + oDataTable.shape + " Cut</strong><br>"
        oDataTable._item_description += oDataTable.color + "/" + oDataTable.clarity + "<br>"
        '' oDataTable._item_description += oDataTable.certificate

        oDataTable._itemnumber = oDataTable.itemid
        oDataTable._id = oDataTable.itemid


        oDataTable.culet = Regex.Replace(oDataTable.culet, "^N$|^Non$|^None$", "None", RegexOptions.IgnoreCase)
        oDataTable.graining = Regex.Replace(oDataTable.graining, "^N$|^Non$|^None$", "None", RegexOptions.IgnoreCase)
        oDataTable.fluorescence = Regex.Replace(oDataTable.fluorescence, "^N$|^Non$|^None$", "None", RegexOptions.IgnoreCase)
        Dim tmp As New ArrayList
        For Each match As Match In Regex.Matches(oDataTable.measurements, "\d{1,}\.?(\d{1,3})?")
            tmp.Add(match.Value)

        Next

        oDataTable.measurements = Join(tmp.ToArray, "x")

        oDataTable.certificate_path = oDataTable.certificate_path.Replace(",", "-")


        Select Case oDataTable.shape.ToLower
            Case "round"
                oDataTable._icon_pic = "/pic/newstruct/idex/item_icons/13.jpg"
                oDataTable._picture_pic = "/pic/newstruct/idex/item_pics/13.jpg"
            Case "oval"
                oDataTable._icon_pic = "/pic/newstruct/idex/item_icons/11.jpg"
                oDataTable._picture_pic = "/pic/newstruct/idex/item_pics/11.jpg"
            Case "emerald"
                oDataTable._icon_pic = "/pic/newstruct/idex/item_icons/7.jpg"
                oDataTable._picture_pic = "/pic/newstruct/idex/item_pics/7.jpg"
            Case "pear"
                oDataTable._icon_pic = "/pic/newstruct/idex/item_icons/9.jpg"
                oDataTable._picture_pic = "/pic/newstruct/idex/item_pics/9.jpg"
            Case "marquise"
                oDataTable._icon_pic = "/pic/newstruct/idex/item_icons/10.jpg"
                oDataTable._picture_pic = "/pic/newstruct/idex/item_pics/10.jpg"
            Case "asscher"
                oDataTable._icon_pic = "/pic/newstruct/idex/item_icons/8.jpg"
                oDataTable._picture_pic = "/pic/newstruct/idex/item_pics/8.jpg"
            Case "radiant"
                oDataTable._icon_pic = "/pic/newstruct/idex/item_icons/6.jpg"
                oDataTable._picture_pic = "/pic/newstruct/idex/item_pics/6.jpg"
            Case "heart"
                oDataTable._icon_pic = "/pic/newstruct/idex/item_icons/15.jpg"
                oDataTable._picture_pic = "/pic/newstruct/idex/item_pics/15.jpg"
            Case "princess"
                oDataTable._icon_pic = "/pic/newstruct/idex/item_icons/5.jpg"
                oDataTable._picture_pic = "/pic/newstruct/idex/item_pics/5.jpg"
        End Select

        If oDataTable.certificate_path <> "-" Then
            oDataTable._is_report = True
            oDataTable._certificate_pic = oDataTable.certificate_path
        End If




        Return False
        Exit Function

ErrorHandler:
        Me._err_number = Err.Number
        Me._err_description = Err.Description
        Me._err_source = Err.Source
        Return True

    End Function

    Function load_collection(ByVal cSQLstring As String, ByRef oItems As Collection) As Boolean
        On Error GoTo ErrorHandler
        Dim bError As Boolean = False

        '--- Get Item
        Dim oReadTransactor As New iDac.cls_T_read
        oReadTransactor._connection_string = Me._connection_string
        oReadTransactor._dbtype = Me._dbtype
        oReadTransactor._tablename = Me._tablename
        bError = oReadTransactor.transact_read(cSQLstring)
        If bError Then
            Me._err_number = oReadTransactor._err_number
            Me._err_description = oReadTransactor._err_description
            Me._err_source = oReadTransactor._err_source
        End If

        '--- Return Error if no records were fatched
        If oReadTransactor._datatable.Rows.Count = 0 Then
            Err.Raise(7003, Me._module + ":read", "No records fetched.")
        End If

        '--- Map to Skeleton
        Dim oTmpDataRow As DataRow
        Dim oDataTable As New skl_box_item

        Dim nLoop As Int16
        For nLoop = 0 To oReadTransactor._datatable.Rows.Count - 1

            oItems.Add(oReadTransactor._datatable.Rows(nLoop)(0))

        Next

        '--- cleanup
        oTmpDataRow = Nothing

        Return False
        Exit Function

ErrorHandler:
        Me._err_number = Err.Number
        Me._err_description = Err.Description
        Me._err_source = Err.Source
        Return True
    End Function

    Public Function ProtectFromNull(ByVal value As Object, Optional ByVal type_override As Int32 = 0) As Object
        Select Case type_override
            Case 0
                If Convert.IsDBNull(value) Then
                    Return "-"
                Else
                    Return value
                End If
            Case 1 ''int/decimal
                If Convert.IsDBNull(value) Then
                    Return 0
                Else
                    Return value
                End If

        End Select




    End Function
End Class
