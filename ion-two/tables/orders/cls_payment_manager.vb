Public Class cls_payment_manager
    Public conn_string As String
    Public db_type As String


    Function get_init_details(ByVal order_id As Int32, ByRef grand_total As Decimal, ByRef already_payed As Decimal, ByRef cc_valid As Boolean, ByRef user_id As Int32, ByRef pay_coll As ArrayList)



        Dim sSql As String
        Dim sql_search As New iDac.cls_sql_read



        '--- Define information to read
        Dim oTmpDataBroker As New iDac.cls_T_datareader
        oTmpDataBroker._dbtype = Me.db_type
        oTmpDataBroker._connection_string = Me.conn_string
        oTmpDataBroker._table = "acc_ORDERS"

        Dim cSQL As String

        cSQL = "select amnt_grandtotal from acc_ORDERS where id=" + Convert.ToString(order_id)


        '--- Define records
        Dim oField1 As New iDac.cls_cll_datareader
        oField1._field = "amnt_grandtotal"


        oTmpDataBroker._fields.Add(oField1)

        '' oField1 = Nothing

        '--- Get info
        oTmpDataBroker.read(cSQL)


        '--- Fill results
        If oTmpDataBroker._hasresult Then
            '' Dim a, b, c As String
            Dim ostringfunc As New iFunctions.cls_string
            grand_total = oTmpDataBroker._fields.Item(1)._result()

        End If


        cSQL = "select sum(amount_total) as payment_made from acc_CASHFLOW  where master = 0 and  order_id = " + Convert.ToString(order_id)


        oField1._field = "payment_made"


        oTmpDataBroker._fields.Add(oField1)

        '' oField1 = Nothing

        '--- Get info
        oTmpDataBroker.read(cSQL)


        '--- Fill results
        If oTmpDataBroker._hasresult Then
            '' Dim a, b, c As String
            If Convert.IsDBNull(oTmpDataBroker._fields.Item(1)._result()) Then
                already_payed = 0
            Else
                already_payed = oTmpDataBroker._fields.Item(1)._result()
            End If


        End If








        cSQL = "select sum(case when payment_type=1 and approved =1 then 1 else 0 end) as cc_valid  from acc_cashflow where  master = 1 and order_id = " + Convert.ToString(order_id)


        oField1._field = "cc_valid"


        oTmpDataBroker._fields.Add(oField1)

        ''  oField1 = Nothing

        '--- Get info
        oTmpDataBroker.read(cSQL)


        '--- Fill results
        If oTmpDataBroker._hasresult Then
            '' Dim a, b, c As String
            If Convert.IsDBNull(oTmpDataBroker._fields.Item(1)._result()) Then
                cc_valid = False
            Else
                cc_valid = Convert.ToBoolean(oTmpDataBroker._fields.Item(1)._result())
            End If
        End If



        cSQL = "select user_id from acc_cashflow where master = 1 and order_id = " + Convert.ToString(order_id)


        oField1._field = "user_id"


        oTmpDataBroker._fields.Add(oField1)

        oField1 = Nothing

        '--- Get info
        oTmpDataBroker.read(cSQL)


        '--- Fill results
        If oTmpDataBroker._hasresult Then
            '' Dim a, b, c As String

            user_id = oTmpDataBroker._fields.Item(1)._result()

        End If




        sql_search._connection_string = Me.conn_string
        sql_search._tablename = "acc_cashflow"
        ''   sql_search._datatable = Application("connection")._connection_string_type

        sSql = "select payment_type,CONVERT(VARCHAR(8), payment_date, 3) as payment_date,amount_total from acc_cashflow where master = 0 and order_id = " + Convert.ToString(order_id)

        sql_search.transact_read(sSql)

        Dim oData As DataTable = sql_search._datatable

        If oData.Rows.Count > 0 Then
            Dim i
            For i = 0 To oData.Rows.Count - 1

                Dim tmp_payment As New payment_item
                tmp_payment.id = i + 1
                tmp_payment.payment_date = oData.Rows(i).Item("payment_date")
                Select Case oData.Rows(i).Item("payment_type")
                    Case 1
                        tmp_payment.payment_method = "Cradit Card"
                    Case 2
                        tmp_payment.payment_method = "Money Transfer"
                    Case 3
                        tmp_payment.payment_method = "Bank Cheque"
                End Select

                Dim ostringfunc As New iFunctions.cls_string
                ostringfunc.format_currency(oData.Rows(i).Item("amount_total"), tmp_payment.amount_formatted, " $")

                pay_coll.Add(tmp_payment)
            Next


        End If


        ''load items for master payment to save time entrigng data




    End Function
    Function userid_byorderid(ByVal order_id As Int32, ByRef user_id As Int32)
        '--- Define information to read
        Dim oTmpDataBroker As New iDac.cls_T_datareader
        oTmpDataBroker._dbtype = Me.db_type
        oTmpDataBroker._connection_string = Me.conn_string
        oTmpDataBroker._table = "acc_ORDERS"

        Dim cSQL As String

        cSQL = "select user_id from acc_ORDERS where id=" + Convert.ToString(order_id)


        '--- Define records
        Dim oField1 As New iDac.cls_cll_datareader
        oField1._field = "user_id"


        oTmpDataBroker._fields.Add(oField1)

        '' oField1 = Nothing

        '--- Get info
        oTmpDataBroker.read(cSQL)


        '--- Fill results
        If oTmpDataBroker._hasresult Then
            '' Dim a, b, c As String
            Dim ostringfunc As New iFunctions.cls_string
            user_id = oTmpDataBroker._fields.Item(1)._result()

        End If
    End Function
    Function load_master_details(ByVal order_id As Int32, ByRef opayment As ion_two.skl_cashflow)

        Dim sSql As String
        Dim sql_search As New iDac.cls_sql_read

        sql_search._connection_string = Me.conn_string
        sql_search._tablename = "acc_cashflow"

        sSql = "select * from acc_cashflow where master = 1 and order_id = " + Convert.ToString(order_id)

        sql_search.transact_read(sSql)

        Dim oData As DataTable = sql_search._datatable

        If oData.Rows.Count > 0 Then

            ''cc all other redundent
            opayment._payment_type = oData.Rows(0).Item("payment_type")
            Select Case opayment._payment_type

                Case 1
                    opayment._cc_exp_month = oData.Rows(0).Item("cc_exp_month")
                    opayment._cc_exp_year = oData.Rows(0).Item("cc_exp_year")
                    opayment._cc_cvv = oData.Rows(0).Item("cc_cvv")
                    opayment._cc_type_id = oData.Rows(0).Item("cc_type_id")
                    opayment._cc_name = oData.Rows(0).Item("cc_name")
                    opayment._cc_number = oData.Rows(0).Item("cc_number")

                    ''wire
                Case 2
                    opayment._mt_bank = oData.Rows(0).Item("mt_bank")
                    opayment._mt_name = oData.Rows(0).Item("mt_name")
                    opayment._mt_account = oData.Rows(0).Item("mt_account")
                    opayment._mt_code = oData.Rows(0).Item("mt_code")

                    ''check
                Case 3
                    opayment._cq_account = oData.Rows(0).Item("cq_account")
                    opayment._cq_bank = oData.Rows(0).Item("cq_bank")
                    opayment._cq_date = oData.Rows(0).Item("cq_date")
                    opayment._cq_name = oData.Rows(0).Item("cq_name")
            End Select

            opayment._user_id = oData.Rows(0).Item("user_id")
            opayment._order_id = oData.Rows(0).Item("order_id")


        End If

    End Function

    Function load_details_byid(ByVal payment_id As Int32, ByRef opayment As ion_two.skl_cashflow)

        Dim sSql As String
        Dim sql_search As New iDac.cls_sql_read

        sql_search._connection_string = Me.conn_string
        sql_search._tablename = "acc_cashflow"

        sSql = "select * from acc_cashflow where master = 1 and oid = " + Convert.ToString(payment_id)

        sql_search.transact_read(sSql)

        Dim oData As DataTable = sql_search._datatable

        If oData.Rows.Count > 0 Then

            ''cc all other redundent
            opayment._payment_type = oData.Rows(0).Item("payment_type")
            Select Case opayment._payment_type

                Case 1
                    opayment._cc_exp_month = oData.Rows(0).Item("cc_exp_month")
                    opayment._cc_exp_year = oData.Rows(0).Item("cc_exp_year")
                    opayment._cc_cvv = oData.Rows(0).Item("cc_cvv")
                    opayment._cc_type_id = oData.Rows(0).Item("cc_type_id")
                    opayment._cc_name = oData.Rows(0).Item("cc_name")
                    opayment._cc_number = oData.Rows(0).Item("cc_number")

                    ''wire
                Case 2
                    opayment._mt_bank = oData.Rows(0).Item("mt_bank")
                    opayment._mt_name = oData.Rows(0).Item("mt_name")
                    opayment._mt_account = oData.Rows(0).Item("mt_account")
                    opayment._mt_code = oData.Rows(0).Item("mt_code")

                    ''check
                Case 3
                    opayment._cq_account = oData.Rows(0).Item("cq_account")
                    opayment._cq_bank = oData.Rows(0).Item("cq_bank")
                    opayment._cq_date = oData.Rows(0).Item("cq_date")
                    opayment._cq_name = oData.Rows(0).Item("cq_name")
            End Select

            opayment._user_id = oData.Rows(0).Item("user_id")
            opayment._order_id = oData.Rows(0).Item("order_id")


        End If

    End Function
    Function set_cc_status(ByVal order_id As Int32, ByVal cc_status As Boolean)
        Dim osql As New iDac.cls_T_command
        osql._dbtype = Me.db_type
        osql._connection_string = Me.conn_string
        osql._sqlstring = "update acc_cashflow set approved =" + Convert.ToString(Convert.ToByte(cc_status)) + " where master = 1 and order_id =" + Convert.ToString(order_id)
        osql.transact_command()



       





    End Function

    Public Class payment_item
        Public payment_method As String
        Public id As Int32
        Public payment_date As String
        Public amount_formatted As String

    End Class

End Class




