
Public Class cls_auction
    Public conn_string As String
    Public db_type As String
    Function get_minbid(ByVal itemid As Int32, ByVal auction_minprice As Decimal, ByRef min_bid As Decimal)

        Dim sql_eng As New iDac.cls_sql_read


        Dim sSql As String = "select * from inv_auction where itemid = " + Convert.ToString(itemid) + " order by current_price desc"
        '' Dim ssql = "exec usp_displayallusers ''"




        sql_eng._connection_string = Me.conn_string
        sql_eng._tablename = "inv_auction"


        sql_eng.transact_read(sSql)

        Dim oData As DataTable = sql_eng._datatable

        If oData.Rows.Count > 0 Then
            min_bid = oData.Rows(0).Item("current_price")
        Else
            min_bid = auction_minprice
        End If


    End Function
    ''this function given an itemid and a max_bid will return true if it's the highest price
    Function check_topmax_bid(ByVal itemid As Int32, ByVal max_bid As Decimal, ByRef isTop As Boolean)

        Dim oTmpDataBroker As New iDac.cls_T_datareader
        oTmpDataBroker._dbtype = Me.db_type
        oTmpDataBroker._connection_string = Me.conn_string
        oTmpDataBroker._table = "inv_auction"
        Dim cSQL As String

        cSQL = "select count(max_price) as max_price from inv_auction where max_price >= " + Convert.ToString(max_bid) + " and itemid = " + Convert.ToString(itemid)

        '--- Define records
        Dim oField1 As New iDac.cls_cll_datareader
        oField1._field = "max_price"

     
        oTmpDataBroker._fields.Add(oField1)

        oField1 = Nothing

        '--- Get info
        oTmpDataBroker.read(cSQL)


        '--- Fill results
        If oTmpDataBroker._hasresult Then


            If oTmpDataBroker._fields.Item(1)._result = 0 Then
                isTop = True
            Else
                isTop = False
            End If


            ''bExist = True
        End If

    End Function
    Function get_currentprice(ByVal itemid As Int32, ByVal auction_minprice As Decimal, ByRef current_price As Decimal)


        Dim oTmpDataBroker As New iDac.cls_T_datareader
        oTmpDataBroker._dbtype = Me.db_type
        oTmpDataBroker._connection_string = Me.conn_string
        oTmpDataBroker._table = "inv_auction"
        Dim cSQL As String

        cSQL = "select top 1 current_price from inv_auction where itemid = " + Convert.ToString(itemid) + " order  by current_price desc"

        '--- Define records
        Dim oField1 As New iDac.cls_cll_datareader
        oField1._field = "current_price"


        oTmpDataBroker._fields.Add(oField1)

        oField1 = Nothing

        '--- Get info
        oTmpDataBroker.read(cSQL)


        '--- Fill results
        If oTmpDataBroker._hasresult Then


            current_price = oTmpDataBroker._fields.Item(1)._result + 50

        Else
            current_price = auction_minprice + 50
        ''bExist = True
        End If


    End Function

    Function write_bid(ByVal itemid As Int32, ByVal email As String, ByVal max_bid As Decimal, ByVal current_price As Decimal)
        Dim osql As New iDac.cls_T_command
        osql._connection_string = Me.conn_string
        osql._dbtype = Me.db_type
        osql._sqlstring = "insert into inv_auction values ('" + email + "'," + Convert.ToString(itemid) + "," + Convert.ToString(max_bid) + "," + Convert.ToString(current_price) + ",0)"
        osql.transact_command()



    End Function

    Function get_emails_byamount(ByVal itemid As Int32, ByVal price As Decimal, ByRef emails As ArrayList)

        Dim sql_eng As New iDac.cls_sql_read


        Dim sSql As String = "select email from inv_auction where itemid = " + Convert.ToString(itemid) + " and max_price < " + Convert.ToString(price) + "and outbidded = 0"
        '' Dim ssql = "exec usp_displayallusers ''"




        sql_eng._connection_string = Me.conn_string
        sql_eng._tablename = "inv_auction"


        sql_eng.transact_read(sSql)

        Dim oData As DataTable = sql_eng._datatable

        If oData.Rows.Count > 0 Then

            Dim i As Int32

            For i = 0 To oData.Rows.Count - 1
                emails.Add(oData.Rows(i).Item("email"))
            Next

        End If


    End Function
    Function set_outbidded_byamount(ByVal itemid As Int32, ByVal price As Decimal)
        Dim osql As New iDac.cls_T_command
        osql._connection_string = Me.conn_string
        osql._dbtype = Me.db_type
        osql._sqlstring = "update inv_auction set outbidded = 1 where itemid = " + Convert.ToString(itemid) + " and max_price < " + Convert.ToString(price)
        osql.transact_command()
    End Function

    Function get_topbid_byid(ByVal itemid As Int32, ByRef topBid As Decimal)


        Dim oTmpDataBroker As New iDac.cls_T_datareader
        oTmpDataBroker._dbtype = Me.db_type
        oTmpDataBroker._connection_string = Me.conn_string
        oTmpDataBroker._table = "inv_auction"
        Dim cSQL As String

        cSQL = "select top 1 max_price from inv_auction where itemid = " + Convert.ToString(itemid) + " order  by max_price desc"

        '--- Define records
        Dim oField1 As New iDac.cls_cll_datareader
        oField1._field = "max_price"


        oTmpDataBroker._fields.Add(oField1)

        oField1 = Nothing

        '--- Get info
        oTmpDataBroker.read(cSQL)


        '--- Fill results
        If oTmpDataBroker._hasresult Then


            topBid = oTmpDataBroker._fields.Item(1)._result

        Else
            topBid = 0
            ''bExist = True
        End If
    End Function

    Function update_currentprice_bytopbid(ByVal itemid As Int32, ByVal max_bid As Decimal)
        Dim tmpTopBid As Decimal

        Me.get_topbid_byid(itemid, tmpTopBid)


        Dim osql As New iDac.cls_T_command
        osql._connection_string = Me.conn_string
        osql._dbtype = Me.db_type
        osql._sqlstring = "update inv_auction set current_price = " + Convert.ToString(max_bid) + " where itemid = " + Convert.ToString(itemid) + " and max_price = " + Convert.ToString(tmpTopBid)
        osql.transact_command()

    End Function


End Class
