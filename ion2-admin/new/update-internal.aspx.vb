Imports System.Text.RegularExpressions
Partial Class update_internal
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub

    'NOTE: The following placeholder declaration is required by the Web Form Designer.
    'Do not delete or move it.
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub

#End Region

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Put user code to initialize the page here
    End Sub

    Private Sub features_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles features.Click

        'On Error Resume Next

        Dim viewer_sql As New iDac.cls_sql_read

        Dim hash As New Hashtable
        Dim sSql As String = "select id from inv_inventory where platetype = 3 and id != 3618 "
        '' Dim ssql = "exec usp_displayallusers ''"
        Dim ostringfunc As New iFunctions.cls_string



        viewer_sql._connection_string = Application("config").connection_string
        viewer_sql._tablename = "inv_jewelry"


        viewer_sql.transact_read(sSql)

        Dim oData As DataTable = viewer_sql._datatable

        Dim oTmpPlateLogics As New ion_two.cls_inventory_lgc
        oTmpPlateLogics._connection_string = Application("config").connection_string
        oTmpPlateLogics._dbtype = Application("config").connection_string_type


        Dim oTmpInventory As New ion_two.cls_inventory_lgc
        oTmpInventory._connection_string = Application("config").connection_string
        oTmpInventory._dbtype = Application("config").connection_string_type


        For Each row As DataRow In oData.Rows
            Dim oPlate As New ion_two.skl_inventory
            oTmpInventory.read(row("id"), oPlate)

            Dim oextra As New ion_two.cls_jewerly_extra
            'oextra.load_extra_metal(oPlate._subplate._extra_metal, Me.extra_metal_list)
            'oextra.load_extra_stone(oPlate._subplate._extra_stone, Me.extra_stone_list)
            '' oextra.DecodeExtraStoneString(oPlate._subplate._extra_stone, Me.extra_list)
            oextra.get_stone_extended_string(oPlate._subplate._stone_extended)



            Dim omodels As New ion_two.cls_models
            Dim hash1 As New Hashtable
            Dim hash2 As New Hashtable
            omodels.GetInfoFromStoneExtended(oPlate._subplate._jewel_extended, hash2)
            omodels.GetInfoFromTitle(oPlate._subplate.jewel_title, hash1)

            Dim cs_carat_weight As String = hash2("cs_carat_weight")
            Dim ss_carat_weight As String = hash2("ss_carat_weight")
            Dim total_carat_weight As String

            Dim color As String = hash1("color")
            Dim clarity As String = hash1("clarity")

            If color = "" Then color = hash2("color")

            If clarity = "" Then clarity = hash2("clarity")


            If hash1("totalcarat") = "" Then
                total_carat_weight = Format(Convert.ToDecimal(cs_carat_weight) + Convert.ToDecimal(ss_carat_weight), "####0.00")
            Else
                total_carat_weight = hash1("totalcarat")

            End If


            If clarity = String.Empty Then
                clarity = ""

                ''Me.report.Text += "<br>" + oPlate._itemnumber + "<br>"
            End If

            If color = String.Empty Then
                color = ""

                ''Me.report.Text += "<br>" + oPlate._itemnumber + "<br>"
            End If

            Dim ojewel_extended As ion_two.skl_jewel_extended = oPlate._subplate._jewel_extended

            ojewel_extended.inventory_id = oPlate._id

            'If oPlate._subplate.jewel_extended.indexof("je_defaultmodel::1") > -1 Then
            '    '' oPlate._subplate.jewel_extended = "sid::2|je_stoneweight::" + cs_carat_weight + "|je_sidestoneweight::" + ss_carat_weight + "|je_totalstoneweight::" + total_carat_weight + "|je_stonew::0|je_stoneh::0|je_stoned::0|je_stonecolor::" + color + "|je_stonecolorfree::|je_stoneclarity::" + clarity + "|je_stoneclarityfree::|je_defaultmodel::1"
            '    '    Dim ojewel_extended As New ion_two.skl_jewel_extended
            '    ojewel_extended.cs_weight = Convert.ToDecimal(cs_carat_weight)
            '    ojewel_extended.ss_weight = Convert.ToDecimal(ss_carat_weight)
            '    ojewel_extended.total_weight = Convert.ToDecimal(total_carat_weight)
            '    ojewel_extended.measure_1 = 0
            '    ojewel_extended.measure_2 = 0
            '    ojewel_extended.measure_3 = 0

            '    ojewel_extended.color = color
            '    ojewel_extended.clarity = clarity

            '    ojewel_extended.color_freetxt = ""
            '    ojewel_extended.clarity_freetxt = ""

            '    ojewel_extended.default_model = True








            'Else


            '    ojewel_extended.cs_weight = Convert.ToDecimal(cs_carat_weight)
            '    ojewel_extended.ss_weight = Convert.ToDecimal(ss_carat_weight)
            '    ojewel_extended.total_weight = Convert.ToDecimal(total_carat_weight)
            '    ojewel_extended.measure_1 = 0
            '    ojewel_extended.measure_2 = 0
            '    ojewel_extended.measure_3 = 0

            '    ojewel_extended.color = color
            '    ojewel_extended.clarity = clarity

            '    ojewel_extended.color_freetxt = ""
            '    ojewel_extended.clarity_freetxt = ""

            '    ojewel_extended.default_model = False



            '    ''  oPlate._subplate.jewel_extended = "sid::2|je_stoneweight::" + cs_carat_weight + "|je_sidestoneweight::" + ss_carat_weight + "|je_totalstoneweight::" + total_carat_weight + "|je_stonew::0|je_stoneh::0|je_stoned::0|je_stonecolor::" + color + "|je_stonecolorfree::|je_stoneclarity::" + clarity + "|je_stoneclarityfree::"
            'End If

            If Not ((oextra.c_desc = "") And (oextra.s_desc = "")) Then '' if totally empty

                If (oextra.c_desc <> "") And (oextra.s_desc <> "") Then

                    ojewel_extended.cs_desc = oextra.c_desc
                    ojewel_extended.cs_cut = oextra.c_cut
                    ojewel_extended.cs_type = oextra.c_type


                    ojewel_extended.ss_desc = oextra.s_desc
                    ojewel_extended.ss_cut = oextra.s_cut
                    ojewel_extended.ss_type = oextra.s_type


                    ojewel_extended.has_sidestones = True

                ElseIf (oextra.c_desc <> "") And (oextra.s_desc = "") Then


                    ojewel_extended.cs_desc = oextra.c_desc
                    ojewel_extended.cs_cut = oextra.c_cut
                    ojewel_extended.cs_type = oextra.c_type

                    ojewel_extended.has_sidestones = False

                ElseIf (oextra.c_desc = "") And (oextra.s_desc <> "") Then
                    ojewel_extended.ss_desc = oextra.s_desc
                    ojewel_extended.ss_cut = oextra.s_cut
                    ojewel_extended.ss_type = oextra.s_type

                    ojewel_extended.has_sidestones = True


                End If

                If Not oextra.c_type.ToLower.IndexOf("diamond") > -1 Then
                    ojewel_extended.is_gemstone = True
                End If

            Else
                ''none is

            End If
            ojewel_extended.ss_color = hash2("ss_color")
            ojewel_extended.ss_clarity = hash2("ss_clarity")

            If hash2("ss_color") = String.Empty Then
                ojewel_extended.ss_color = ""
            End If
            If hash2("ss_clarity") = String.Empty Then
                ojewel_extended.ss_clarity = ""
            End If



            oPlate._subplate._jewel_extended = ojewel_extended

            ''jewel_extended

            Dim ojelgk As New ion_two.cls_jewel_extended_lgc
            ojelgk._connection_string = Application("config").connection_string
            ojelgk._dbtype = Application("config").connection_string_type


            Dim oTransaction As New iDac.cls_T_transaction
            oTransaction._connection_string = ojelgk._connection_string
            oTransaction._dbtype = ojelgk._dbtype
            oTransaction.start()



            ojelgk.update(ojewel_extended)

            Dim oTransactor_3 As New iDac.cls_T_transactor
            oTransactor_3._connection_string = ojelgk._connection_string
            oTransactor_3._dbtype = ojelgk._dbtype

            '--- Prepare and load table 2
            Dim oTable3 As New iDac.cls_cll_datatables
            oTable3._datatable = ojelgk._datatable
            oTransactor_3._i_cll_datatables.Add(oTable3)

            '--- Assign the transaction to the transactor
            oTransactor_3._transaction = oTransaction._transaction

            '--- Write Table
            oTransactor_3.transact_update()


            oTransaction.close()

            ''   oTmpInventory.update(oPlate)

            ''sid::2|je_stoneweight::1.01|je_sidestoneweight::1.46|je_totalstoneweight::2.47|je_stonew::6.5|je_stoneh::6.5|je_stoned::6.5|je_stonecolor::H|je_stonecolorfree::|je_stoneclarity::SI2|je_stoneclarityfree::

            ''specifications


        Next
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim viewer_sql As New iDac.cls_sql_read

        Dim hash As New Hashtable
        Dim sSql As String = "select * from inv_inventory where platetype = 3 and id != 3618 and id> 12000 and id < 14001 "
        '' Dim ssql = "exec usp_displayallusers ''"
        Dim ostringfunc As New iFunctions.cls_string



        viewer_sql._connection_string = Application("config").connection_string
        viewer_sql._tablename = "inv_jewelry"


        viewer_sql.transact_read(sSql)

        Dim oData As DataTable = viewer_sql._datatable


        Dim array As New ArrayList



        For Each row As DataRow In oData.Rows

            If row("itemcode") <> "" Then

                Dim viewer_sql2 As New iDac.cls_sql_read


                Dim sSql2 As String = "select * from vv_jewelry_full where itemcode='" + row("itemcode") + "' and id >" + (row("id") - 100).ToString + " and id < " + (row("id") + 100).ToString
                '' Dim ssql = "exec usp_displayallusers ''"




                viewer_sql2._connection_string = Application("config").connection_string
                '' viewer_sql._tablename = "vv_jewelry_full"


                viewer_sql2.transact_read(sSql2)

                Dim oData2 As DataTable = viewer_sql2._datatable

                Dim total As Int32 = oData2.Rows.Count

                If total > 7 Then

                    Dim osql As New iDac.cls_T_command

                    osql._connection_string = Application("config").connection_string
                    osql._dbtype = Application("config").connection_string_type

                    osql._sqlstring = "update inv_jewel_extended set is_partof_model = 1 where inventory_id = " + row("id").ToString

                    osql.transact_command()

                Else
                    Dim osql As New iDac.cls_T_command

                    osql._connection_string = Application("config").connection_string
                    osql._dbtype = Application("config").connection_string_type

                    osql._sqlstring = "update inv_jewel_extended set is_partof_model = 0 where inventory_id = " + row("id").ToString

                    osql.transact_command()
                End If
            Else
                Dim osql As New iDac.cls_T_command

                osql._connection_string = Application("config").connection_string
                osql._dbtype = Application("config").connection_string_type

                osql._sqlstring = "update inv_jewel_extended set is_partof_model = 0 where inventory_id = " + row("id").ToString

                osql.transact_command()

            End If



        Next


    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click

        Dim viewer_sql As New iDac.cls_sql_read

        Dim hash As New Hashtable
        Dim sSql As String = "select * from inv_jewel_extended where ss_desc != '' and is_partof_model =1 "
        '' Dim ssql = "exec usp_displayallusers ''"
        Dim ostringfunc As New iFunctions.cls_string



        viewer_sql._connection_string = Application("config").connection_string
        viewer_sql._tablename = "inv_jewelry"


        viewer_sql.transact_read(sSql)

        Dim oData As DataTable = viewer_sql._datatable


        Dim array As New ArrayList



        For Each row As DataRow In oData.Rows

            Dim omodels As New ion_two.cls_models
            Dim hash1 As New Hashtable
            Dim hash2 As New Hashtable

            Dim ostoneext As New ion_two.skl_jewel_extended
            ostoneext.ss_desc = row("ss_desc")
            omodels.GetInfoFromStoneExtended(ostoneext, hash2)
            ''    omodels.GetInfoFromTitle(oPlate._subplate.jewel_title, hash1)
            If hash2("ss_color") <> "" Then

                Dim osql As New iDac.cls_T_command

                osql._connection_string = Application("config").connection_string
                osql._dbtype = Application("config").connection_string_type

                osql._sqlstring = "update inv_jewel_extended set ss_color='" + hash2("ss_color") + "' , ss_clarity='" + hash2("ss_clarity") + "' where inventory_id = " + row("inventory_id").ToString

                osql.transact_command()
            End If

        Next


    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles update_collection.Click

        Dim oTmpCombo As New iFunctions.cls_combo
        oTmpCombo._connection_string = Application("config").connection_string
        oTmpCombo._dbtype = Application("config").connection_string_type


        oTmpCombo._combobox = New WebControls.DropDownList
        oTmpCombo._sqlstring = "select id, lang" & Session("user").language & "_longdescr from inv_COLLECTION_JEWEL order by sortorder"
        oTmpCombo._textfield = "lang" & Session("user").language & "_longdescr"
        oTmpCombo._valuefield = "id"
        oTmpCombo._addrow = ""
        oTmpCombo.BindCombo()


        Dim viewer_sql As New iDac.cls_sql_read

        Dim hash As New Hashtable
        Dim sSql As String = "select * from inv_inventory inner join inv_jewel_extended on inv_inventory.id = inv_jewel_extended.inventory_id inner join inv_jewelry on inv_jewelry.inventory_id = inv_inventory.id where default_model =1 and shopstatus =1 and jewel_title like '%''%'"
        '' Dim ssql = "exec usp_displayallusers ''"
        Dim ostringfunc As New iFunctions.cls_string



        viewer_sql._connection_string = Application("config").connection_string
        viewer_sql._tablename = "inv_jewelry"


        viewer_sql.transact_read(sSql)

        Dim oData As DataTable = viewer_sql._datatable


        Dim array As New ArrayList



        For Each row As DataRow In oData.Rows

            Dim collection_id As Int32 = 0
            Dim items As ListItemCollection = oTmpCombo._combobox.Items

            For Each item As WebControls.ListItem In items

                If row("jewel_title").tolower.indexof("'" + item.Text.ToLower) > -1 Then
                    collection_id = Convert.ToInt32(item.Value)
                End If

            Next

            If collection_id > 1 Then
                Dim osql As New iDac.cls_T_command

                osql._connection_string = Application("config").connection_string
                osql._dbtype = Application("config").connection_string_type

                osql._sqlstring = "update inv_jewelry set collection_id=" + collection_id.ToString + " where inventory_id = " + row("id").ToString

                osql.transact_command()
            End If

        Next


    End Sub

    Private Sub update_collection_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles update_collection.Click

    End Sub
End Class
