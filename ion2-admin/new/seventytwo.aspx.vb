Imports System.Text.RegularExpressions
Partial Class seventytwo
    Inherits System.Web.UI.Page
    Public wgprice As Decimal

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

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_go.Click, btn_go2.Click, Button1.Click

        'On Error Resume Next

        'Dim viewer_sql As New iDac.cls_sql_read

        'Dim hash As New Hashtable
        'Dim sSql As String = "select id from inv_inventory where platetype = 3 and id != 3618"
        ''' Dim ssql = "exec usp_displayallusers ''"
        'Dim ostringfunc As New iFunctions.cls_string



        'viewer_sql._connection_string = Application("config").connection_string
        'viewer_sql._tablename = "inv_jewelry"


        'viewer_sql.transact_read(sSql)

        'Dim oData As DataTable = viewer_sql._datatable

        'Dim oTmpPlateLogics As New ion_two.cls_inventory_lgc
        'oTmpPlateLogics._connection_string = Application("config").connection_string
        'oTmpPlateLogics._dbtype = Application("config").connection_string_type


        'Dim oTmpInventory As New ion_two.cls_inventory_lgc
        'oTmpInventory._connection_string = Application("config").connection_string
        'oTmpInventory._dbtype = Application("config").connection_string_type


        'For Each row As DataRow In oData.Rows
        '    Dim oPlate As New ion_two.skl_inventory
        '    oTmpInventory.read(row("id"), oPlate)

        '    Dim omodels As New ion_two.cls_models
        '    Dim hash1 As New Hashtable
        '    Dim hash2 As New Hashtable
        '    omodels.GetInfoFromStoneExtended(oPlate._subplate._stone_extended, hash2)
        '    omodels.GetInfoFromTitle(oPlate._subplate.jewel_title, hash1)

        '    Dim cs_carat_weight As String = hash2("cs_carat_weight")
        '    Dim ss_carat_weight As String = hash2("ss_carat_weight")
        '    Dim total_carat_weight As String

        '    Dim color As String = hash1("color")
        '    Dim clarity As String = hash1("clarity")

        '    If color = "" Then color = hash2("color")

        '    If clarity = "" Then clarity = hash2("clarity")


        '    If hash1("totalcarat") = "" Then
        '        total_carat_weight = Format(Convert.ToDecimal(cs_carat_weight) + Convert.ToDecimal(ss_carat_weight), "####0.00")
        '    Else
        '        total_carat_weight = hash1("totalcarat")

        '    End If


        '    If clarity = String.Empty Then
        '        clarity = ""

        '        ''Me.report.Text += "<br>" + oPlate._itemnumber + "<br>"
        '    End If

        '    If color = String.Empty Then
        '        color = ""

        '        ''Me.report.Text += "<br>" + oPlate._itemnumber + "<br>"
        '    End If

        '    Dim ojewel_extended As New ion_two.skl_jewel_extended

        '    ojewel_extended.inventory_id = oPlate._id

        '    If oPlate._subplate.jewel_extended.indexof("je_defaultmodel::1") > -1 Then
        '        '' oPlate._subplate.jewel_extended = "sid::2|je_stoneweight::" + cs_carat_weight + "|je_sidestoneweight::" + ss_carat_weight + "|je_totalstoneweight::" + total_carat_weight + "|je_stonew::0|je_stoneh::0|je_stoned::0|je_stonecolor::" + color + "|je_stonecolorfree::|je_stoneclarity::" + clarity + "|je_stoneclarityfree::|je_defaultmodel::1"
        '        '    Dim ojewel_extended As New ion_two.skl_jewel_extended
        '        ojewel_extended.cs_weight = Convert.ToDecimal(cs_carat_weight)
        '        ojewel_extended.ss_weight = Convert.ToDecimal(ss_carat_weight)
        '        ojewel_extended.total_weight = Convert.ToDecimal(total_carat_weight)
        '        ojewel_extended.measure_1 = 0
        '        ojewel_extended.measure_2 = 0
        '        ojewel_extended.measure_3 = 0

        '        ojewel_extended.color = color
        '        ojewel_extended.clarity = clarity

        '        ojewel_extended.color_freetxt = ""
        '        ojewel_extended.clarity_freetxt = ""

        '        ojewel_extended.default_model = True








        '    Else


        '        ojewel_extended.cs_weight = Convert.ToDecimal(cs_carat_weight)
        '        ojewel_extended.ss_weight = Convert.ToDecimal(ss_carat_weight)
        '        ojewel_extended.total_weight = Convert.ToDecimal(total_carat_weight)
        '        ojewel_extended.measure_1 = 0
        '        ojewel_extended.measure_2 = 0
        '        ojewel_extended.measure_3 = 0

        '        ojewel_extended.color = color
        '        ojewel_extended.clarity = clarity

        '        ojewel_extended.color_freetxt = ""
        '        ojewel_extended.clarity_freetxt = ""

        '        ojewel_extended.default_model = False



        '        ''  oPlate._subplate.jewel_extended = "sid::2|je_stoneweight::" + cs_carat_weight + "|je_sidestoneweight::" + ss_carat_weight + "|je_totalstoneweight::" + total_carat_weight + "|je_stonew::0|je_stoneh::0|je_stoned::0|je_stonecolor::" + color + "|je_stonecolorfree::|je_stoneclarity::" + clarity + "|je_stoneclarityfree::"
        '    End If

        '    oPlate._subplate._jewel_extended = ojewel_extended

        '    ''jewel_extended

        '    Dim ojelgk As New ion_two.cls_jewel_extended_lgc
        '    ojelgk._connection_string = Application("config").connection_string
        '    ojelgk._dbtype = Application("config").connection_string_type


        '    Dim oTransaction As New iDac.cls_T_transaction
        '    oTransaction._connection_string = ojelgk._connection_string
        '    oTransaction._dbtype = ojelgk._dbtype
        '    oTransaction.start()



        '    ojelgk.insert(ojewel_extended)

        '    Dim oTransactor_3 As New iDac.cls_T_transactor
        '    oTransactor_3._connection_string = ojelgk._connection_string
        '    oTransactor_3._dbtype = ojelgk._dbtype

        '    '--- Prepare and load table 2
        '    Dim oTable3 As New iDac.cls_cll_datatables
        '    oTable3._datatable = ojelgk._datatable
        '    oTransactor_3._i_cll_datatables.Add(oTable3)

        '    '--- Assign the transaction to the transactor
        '    oTransactor_3._transaction = oTransaction._transaction

        '    '--- Write Table
        '    oTransactor_3.transact_insert()


        '    oTransaction.close()

        '    ''   oTmpInventory.update(oPlate)

        '    ''sid::2|je_stoneweight::1.01|je_sidestoneweight::1.46|je_totalstoneweight::2.47|je_stonew::6.5|je_stoneh::6.5|je_stoned::6.5|je_stonecolor::H|je_stonecolorfree::|je_stoneclarity::SI2|je_stoneclarityfree::

        '    ''specifications
        '    Session("idid") = oPlate._id

        'Next




    End Sub

    Function WhiteGold()
        Dim bError As Boolean = False
        Dim oPlateSkelet As New ion_two.skl_inventory

        '--- Define logics and get the plate
        Dim oTmpPlateLogics As New ion_two.cls_inventory_lgc
        oTmpPlateLogics._connection_string = Application("config").connection_string
        oTmpPlateLogics._dbtype = Application("config").connection_string_type

        Dim onumber As New ion_two.cls_itemnumber
        onumber._connection_string = Application("config").connection_string
        onumber._dbtype = Application("config").connection_string_type
        Dim itemid As Int32
        onumber.getid_fromnumber(Me.txt_whitegold.Text, itemid, bError)
        oTmpPlateLogics.read(itemid, oPlateSkelet)

        Me.UpdateIsPartOf(itemid)


        '' copy part of the white gold
        Dim ModPlate As New ion_two.skl_inventory

        ModPlate = oPlateSkelet
        ModPlate._subplate._jewel_extended.is_partof_model = True

        Dim title As String = oPlateSkelet._subplate.jewel_title
        Dim cs_desc As String = oPlateSkelet._subplate._jewel_extended.cs_desc
        Dim ss_desc As String = oPlateSkelet._subplate._jewel_extended.ss_desc

        Dim ebaytitle As String = oPlateSkelet.opthash("ebaytitle")
        Dim price As Decimal = oPlateSkelet._purchase_price
        Dim extended As String = oPlateSkelet._subplate.jewel_extended
        Me.wgprice = price
        ''1
        Me.SetPrice(price * 1.03, ModPlate)
        Me.ReplaceColorClarity("H", "SI2", ModPlate, title, cs_desc, ss_desc, ebaytitle, extended)
        oTmpPlateLogics.insert(ModPlate)
        ''2
        Me.SetPrice(price * 1.05 * 1.03, ModPlate)
        Me.ReplaceColorClarity("G", "SI2", ModPlate, title, cs_desc, ss_desc, ebaytitle, extended)
        oTmpPlateLogics.insert(ModPlate)

        ''3
        Me.SetPrice(price * 1.18965, ModPlate)
        Me.ReplaceColorClarity("F", "SI2", ModPlate, title, cs_desc, ss_desc, ebaytitle, extended)
        oTmpPlateLogics.insert(ModPlate)

        ''4
        Me.SetPrice(price * 1.284822, ModPlate)
        Me.ReplaceColorClarity("E", "SI2", ModPlate, title, cs_desc, ss_desc, ebaytitle, extended)
        oTmpPlateLogics.insert(ModPlate)

        ''5
        Me.SetPrice(price * 1.4133042, ModPlate)
        Me.ReplaceColorClarity("D", "SI2", ModPlate, title, cs_desc, ss_desc, ebaytitle, extended)
        oTmpPlateLogics.insert(ModPlate)


        ''6
        Me.SetPrice(price * 1.1, ModPlate)
        Me.ReplaceColorClarity("I", "SI1", ModPlate, title, cs_desc, ss_desc, ebaytitle, extended)
        oTmpPlateLogics.insert(ModPlate)

        ''7
        Me.SetPrice(price * 1.133, ModPlate)
        Me.ReplaceColorClarity("H", "SI1", ModPlate, title, cs_desc, ss_desc, ebaytitle, extended)
        oTmpPlateLogics.insert(ModPlate)

        ''8
        Me.SetPrice(price * 1.18965, ModPlate)
        Me.ReplaceColorClarity("G", "SI1", ModPlate, title, cs_desc, ss_desc, ebaytitle, extended)
        oTmpPlateLogics.insert(ModPlate)

        ''9
        Me.SetPrice(price * 1.308615, ModPlate)
        Me.ReplaceColorClarity("F", "SI1", ModPlate, title, cs_desc, ss_desc, ebaytitle, extended)
        oTmpPlateLogics.insert(ModPlate)


        ''10
        Me.SetPrice(price * 1.4133042, ModPlate)
        Me.ReplaceColorClarity("E", "SI1", ModPlate, title, cs_desc, ss_desc, ebaytitle, extended)
        oTmpPlateLogics.insert(ModPlate)

        ''11
        Me.SetPrice(price * 1.55463462, ModPlate)
        Me.ReplaceColorClarity("D", "SI1", ModPlate, title, cs_desc, ss_desc, ebaytitle, extended)
        oTmpPlateLogics.insert(ModPlate)


        ''12
        Me.SetPrice(price * 1.2364, ModPlate)
        Me.ReplaceColorClarity("I", "VS2", ModPlate, title, cs_desc, ss_desc, ebaytitle, extended)
        oTmpPlateLogics.insert(ModPlate)

        ''13
        Me.SetPrice(price * 1.273492, ModPlate)
        Me.ReplaceColorClarity("H", "VS2", ModPlate, title, cs_desc, ss_desc, ebaytitle, extended)
        oTmpPlateLogics.insert(ModPlate)

        ''14
        Me.SetPrice(price * 1.3371666, ModPlate)
        Me.ReplaceColorClarity("G", "VS2", ModPlate, title, cs_desc, ss_desc, ebaytitle, extended)
        oTmpPlateLogics.insert(ModPlate)

        ''15
        Me.SetPrice(price * 1.47088326, ModPlate)
        Me.ReplaceColorClarity("F", "VS2", ModPlate, title, cs_desc, ss_desc, ebaytitle, extended)
        oTmpPlateLogics.insert(ModPlate)

        ''16
        Me.SetPrice(price * 1.5885539208, ModPlate)
        Me.ReplaceColorClarity("E", "VS2", ModPlate, title, cs_desc, ss_desc, ebaytitle, extended)
        oTmpPlateLogics.insert(ModPlate)

        ''17
        Me.SetPrice(price * 1.74740931288, ModPlate)
        Me.ReplaceColorClarity("D", "VS2", ModPlate, title, cs_desc, ss_desc, ebaytitle, extended)
        oTmpPlateLogics.insert(ModPlate)

        ''18
        Me.SetPrice(price * 1.347676, ModPlate)
        Me.ReplaceColorClarity("I", "VS1", ModPlate, title, cs_desc, ss_desc, ebaytitle, extended)
        oTmpPlateLogics.insert(ModPlate)

        ''19
        Me.SetPrice(price * 1.38810628, ModPlate)
        Me.ReplaceColorClarity("H", "VS1", ModPlate, title, cs_desc, ss_desc, ebaytitle, extended)
        oTmpPlateLogics.insert(ModPlate)


        ''20
        Me.SetPrice(price * 1.457511594, ModPlate)
        Me.ReplaceColorClarity("G", "VS1", ModPlate, title, cs_desc, ss_desc, ebaytitle, extended)
        oTmpPlateLogics.insert(ModPlate)


        ''21
        Me.SetPrice(price * 1.6032627534, ModPlate)
        Me.ReplaceColorClarity("F", "VS1", ModPlate, title, cs_desc, ss_desc, ebaytitle, extended)
        oTmpPlateLogics.insert(ModPlate)

        ''22
        Me.SetPrice(price * 1.731523773672, ModPlate)
        Me.ReplaceColorClarity("E", "VS1", ModPlate, title, cs_desc, ss_desc, ebaytitle, extended)
        oTmpPlateLogics.insert(ModPlate)

        ''23
        Me.SetPrice(price * 1.9046761510392, ModPlate)
        Me.ReplaceColorClarity("D", "VS1", ModPlate, title, cs_desc, ss_desc, ebaytitle, extended)
        oTmpPlateLogics.insert(ModPlate)

        Me.UpdateIsPartOf(itemid)

    End Function

    Function YellowGold()
        Dim bError As Boolean = False
        Dim oPlateSkelet As New ion_two.skl_inventory

        '--- Define logics and get the plate
        Dim oTmpPlateLogics As New ion_two.cls_inventory_lgc
        oTmpPlateLogics._connection_string = Application("config").connection_string
        oTmpPlateLogics._dbtype = Application("config").connection_string_type

        Dim onumber As New ion_two.cls_itemnumber
        onumber._connection_string = Application("config").connection_string
        onumber._dbtype = Application("config").connection_string_type
        Dim itemid As Int32
        onumber.getid_fromnumber(Me.txt_yellowgold.Text, itemid, bError)
        oTmpPlateLogics.read(itemid, oPlateSkelet)


        '' copy part of the white gold
        Dim ModPlate As New ion_two.skl_inventory

        ModPlate = oPlateSkelet
        ModPlate._subplate._jewel_extended.is_partof_model = True
        Dim title As String = oPlateSkelet._subplate.jewel_title
        Dim cs_desc As String = oPlateSkelet._subplate._jewel_extended.cs_desc
        Dim ss_desc As String = oPlateSkelet._subplate._jewel_extended.ss_desc
        Dim ebaytitle As String = oPlateSkelet.opthash("ebaytitle")
        Dim price As Decimal = oPlateSkelet._purchase_price
        Dim extended As String = oPlateSkelet._subplate.jewel_extended


        ''1
        Me.SetPrice(price * 1.03, ModPlate)
        Me.ReplaceColorClarity("H", "SI2", ModPlate, title, cs_desc, ss_desc, ebaytitle, extended)
        oTmpPlateLogics.insert(ModPlate)
        ''2
        Me.SetPrice(price * 1.05 * 1.03, ModPlate)
        Me.ReplaceColorClarity("G", "SI2", ModPlate, title, cs_desc, ss_desc, ebaytitle, extended)
        oTmpPlateLogics.insert(ModPlate)

        ''3
        Me.SetPrice(price * 1.18965, ModPlate)
        Me.ReplaceColorClarity("F", "SI2", ModPlate, title, cs_desc, ss_desc, ebaytitle, extended)
        oTmpPlateLogics.insert(ModPlate)

        ''4
        Me.SetPrice(price * 1.284822, ModPlate)
        Me.ReplaceColorClarity("E", "SI2", ModPlate, title, cs_desc, ss_desc, ebaytitle, extended)
        oTmpPlateLogics.insert(ModPlate)

        ''5
        Me.SetPrice(price * 1.4133042, ModPlate)
        Me.ReplaceColorClarity("D", "SI2", ModPlate, title, cs_desc, ss_desc, ebaytitle, extended)
        oTmpPlateLogics.insert(ModPlate)


        ''6
        Me.SetPrice(price * 1.1, ModPlate)
        Me.ReplaceColorClarity("I", "SI1", ModPlate, title, cs_desc, ss_desc, ebaytitle, extended)
        oTmpPlateLogics.insert(ModPlate)

        ''7
        Me.SetPrice(price * 1.133, ModPlate)
        Me.ReplaceColorClarity("H", "SI1", ModPlate, title, cs_desc, ss_desc, ebaytitle, extended)
        oTmpPlateLogics.insert(ModPlate)

        ''8
        Me.SetPrice(price * 1.18965, ModPlate)
        Me.ReplaceColorClarity("G", "SI1", ModPlate, title, cs_desc, ss_desc, ebaytitle, extended)
        oTmpPlateLogics.insert(ModPlate)

        ''9
        Me.SetPrice(price * 1.308615, ModPlate)
        Me.ReplaceColorClarity("F", "SI1", ModPlate, title, cs_desc, ss_desc, ebaytitle, extended)
        oTmpPlateLogics.insert(ModPlate)


        ''10
        Me.SetPrice(price * 1.4133042, ModPlate)
        Me.ReplaceColorClarity("E", "SI1", ModPlate, title, cs_desc, ss_desc, ebaytitle, extended)
        oTmpPlateLogics.insert(ModPlate)

        ''11
        Me.SetPrice(price * 1.55463462, ModPlate)
        Me.ReplaceColorClarity("D", "SI1", ModPlate, title, cs_desc, ss_desc, ebaytitle, extended)
        oTmpPlateLogics.insert(ModPlate)


        ''12
        Me.SetPrice(price * 1.2364, ModPlate)
        Me.ReplaceColorClarity("I", "VS2", ModPlate, title, cs_desc, ss_desc, ebaytitle, extended)
        oTmpPlateLogics.insert(ModPlate)

        ''13
        Me.SetPrice(price * 1.273492, ModPlate)
        Me.ReplaceColorClarity("H", "VS2", ModPlate, title, cs_desc, ss_desc, ebaytitle, extended)
        oTmpPlateLogics.insert(ModPlate)

        ''14
        Me.SetPrice(price * 1.3371666, ModPlate)
        Me.ReplaceColorClarity("G", "VS2", ModPlate, title, cs_desc, ss_desc, ebaytitle, extended)
        oTmpPlateLogics.insert(ModPlate)

        ''15
        Me.SetPrice(price * 1.47088326, ModPlate)
        Me.ReplaceColorClarity("F", "VS2", ModPlate, title, cs_desc, ss_desc, ebaytitle, extended)
        oTmpPlateLogics.insert(ModPlate)

        ''16
        Me.SetPrice(price * 1.5885539208, ModPlate)
        Me.ReplaceColorClarity("E", "VS2", ModPlate, title, cs_desc, ss_desc, ebaytitle, extended)
        oTmpPlateLogics.insert(ModPlate)

        ''17
        Me.SetPrice(price * 1.74740931288, ModPlate)
        Me.ReplaceColorClarity("D", "VS2", ModPlate, title, cs_desc, ss_desc, ebaytitle, extended)
        oTmpPlateLogics.insert(ModPlate)

        ''18
        Me.SetPrice(price * 1.347676, ModPlate)
        Me.ReplaceColorClarity("I", "VS1", ModPlate, title, cs_desc, ss_desc, ebaytitle, extended)
        oTmpPlateLogics.insert(ModPlate)

        ''19
        Me.SetPrice(price * 1.38810628, ModPlate)
        Me.ReplaceColorClarity("H", "VS1", ModPlate, title, cs_desc, ss_desc, ebaytitle, extended)
        oTmpPlateLogics.insert(ModPlate)


        ''20
        Me.SetPrice(price * 1.457511594, ModPlate)
        Me.ReplaceColorClarity("G", "VS1", ModPlate, title, cs_desc, ss_desc, ebaytitle, extended)
        oTmpPlateLogics.insert(ModPlate)


        ''21
        Me.SetPrice(price * 1.6032627534, ModPlate)
        Me.ReplaceColorClarity("F", "VS1", ModPlate, title, cs_desc, ss_desc, ebaytitle, extended)
        oTmpPlateLogics.insert(ModPlate)

        ''22
        Me.SetPrice(price * 1.731523773672, ModPlate)
        Me.ReplaceColorClarity("E", "VS1", ModPlate, title, cs_desc, ss_desc, ebaytitle, extended)
        oTmpPlateLogics.insert(ModPlate)

        ''23
        Me.SetPrice(price * 1.9046761510392, ModPlate)
        Me.ReplaceColorClarity("D", "VS1", ModPlate, title, cs_desc, ss_desc, ebaytitle, extended)
        oTmpPlateLogics.insert(ModPlate)

        Me.UpdateIsPartOf(itemid)
    End Function



    Function Platinum()
        Dim bError As Boolean = False
        Dim oPlateSkelet As New ion_two.skl_inventory

        '--- Define logics and get the plate
        Dim oTmpPlateLogics As New ion_two.cls_inventory_lgc
        oTmpPlateLogics._connection_string = Application("config").connection_string
        oTmpPlateLogics._dbtype = Application("config").connection_string_type

        Dim onumber As New ion_two.cls_itemnumber
        onumber._connection_string = Application("config").connection_string
        onumber._dbtype = Application("config").connection_string_type
        Dim itemid As Int32
        onumber.getid_fromnumber(Me.txt_platinum.Text, itemid, bError)
        oTmpPlateLogics.read(itemid, oPlateSkelet)


        '' copy part of the white gold
        Dim ModPlate As New ion_two.skl_inventory

        ModPlate = oPlateSkelet
        ModPlate._subplate._jewel_extended.is_partof_model = True
        Dim title As String = oPlateSkelet._subplate.jewel_title
        Dim cs_desc As String = oPlateSkelet._subplate._jewel_extended.cs_desc
        Dim ss_desc As String = oPlateSkelet._subplate._jewel_extended.ss_desc
        Dim ebaytitle As String = oPlateSkelet.opthash("ebaytitle")
        Dim extended As String = oPlateSkelet._subplate.jewel_extended
        Dim price As Decimal = Me.wgprice

        Dim deltaprice As Decimal = oPlateSkelet._purchase_price - Me.wgprice
        ''1
        Me.SetPrice(price * 1.03 + deltaprice, ModPlate)
        Me.ReplaceColorClarity("H", "SI2", ModPlate, title, cs_desc, ss_desc, ebaytitle, extended)
        oTmpPlateLogics.insert(ModPlate)
        ''2
        Me.SetPrice(price * 1.05 * 1.03 + deltaprice, ModPlate)
        Me.ReplaceColorClarity("G", "SI2", ModPlate, title, cs_desc, ss_desc, ebaytitle, extended)
        oTmpPlateLogics.insert(ModPlate)

        ''3
        Me.SetPrice(price * 1.18965 + deltaprice, ModPlate)
        Me.ReplaceColorClarity("F", "SI2", ModPlate, title, cs_desc, ss_desc, ebaytitle, extended)
        oTmpPlateLogics.insert(ModPlate)

        ''4
        Me.SetPrice(price * 1.284822 + deltaprice, ModPlate)
        Me.ReplaceColorClarity("E", "SI2", ModPlate, title, cs_desc, ss_desc, ebaytitle, extended)
        oTmpPlateLogics.insert(ModPlate)

        ''5
        Me.SetPrice(price * 1.4133042 + deltaprice, ModPlate)
        Me.ReplaceColorClarity("D", "SI2", ModPlate, title, cs_desc, ss_desc, ebaytitle, extended)
        oTmpPlateLogics.insert(ModPlate)


        ''6
        Me.SetPrice(price * 1.1 + deltaprice, ModPlate)
        Me.ReplaceColorClarity("I", "SI1", ModPlate, title, cs_desc, ss_desc, ebaytitle, extended)
        oTmpPlateLogics.insert(ModPlate)

        ''7
        Me.SetPrice(price * 1.133 + deltaprice, ModPlate)
        Me.ReplaceColorClarity("H", "SI1", ModPlate, title, cs_desc, ss_desc, ebaytitle, extended)
        oTmpPlateLogics.insert(ModPlate)

        ''8
        Me.SetPrice(price * 1.18965 + deltaprice, ModPlate)
        Me.ReplaceColorClarity("G", "SI1", ModPlate, title, cs_desc, ss_desc, ebaytitle, extended)
        oTmpPlateLogics.insert(ModPlate)

        ''9
        Me.SetPrice(price * 1.308615 + deltaprice, ModPlate)
        Me.ReplaceColorClarity("F", "SI1", ModPlate, title, cs_desc, ss_desc, ebaytitle, extended)
        oTmpPlateLogics.insert(ModPlate)


        ''10
        Me.SetPrice(price * 1.4133042 + deltaprice, ModPlate)
        Me.ReplaceColorClarity("E", "SI1", ModPlate, title, cs_desc, ss_desc, ebaytitle, extended)
        oTmpPlateLogics.insert(ModPlate)

        ''11
        Me.SetPrice(price * 1.55463462 + deltaprice, ModPlate)
        Me.ReplaceColorClarity("D", "SI1", ModPlate, title, cs_desc, ss_desc, ebaytitle, extended)
        oTmpPlateLogics.insert(ModPlate)


        ''12
        Me.SetPrice(price * 1.2364 + deltaprice, ModPlate)
        Me.ReplaceColorClarity("I", "VS2", ModPlate, title, cs_desc, ss_desc, ebaytitle, extended)
        oTmpPlateLogics.insert(ModPlate)

        ''13
        Me.SetPrice(price * 1.273492 + deltaprice, ModPlate)
        Me.ReplaceColorClarity("H", "VS2", ModPlate, title, cs_desc, ss_desc, ebaytitle, extended)
        oTmpPlateLogics.insert(ModPlate)

        ''14
        Me.SetPrice(price * 1.3371666 + deltaprice, ModPlate)
        Me.ReplaceColorClarity("G", "VS2", ModPlate, title, cs_desc, ss_desc, ebaytitle, extended)
        oTmpPlateLogics.insert(ModPlate)

        ''15
        Me.SetPrice(price * 1.47088326 + deltaprice, ModPlate)
        Me.ReplaceColorClarity("F", "VS2", ModPlate, title, cs_desc, ss_desc, ebaytitle, extended)
        oTmpPlateLogics.insert(ModPlate)

        ''16
        Me.SetPrice(price * 1.5885539208 + deltaprice, ModPlate)
        Me.ReplaceColorClarity("E", "VS2", ModPlate, title, cs_desc, ss_desc, ebaytitle, extended)
        oTmpPlateLogics.insert(ModPlate)

        ''17
        Me.SetPrice(price * 1.74740931288 + deltaprice, ModPlate)
        Me.ReplaceColorClarity("D", "VS2", ModPlate, title, cs_desc, ss_desc, ebaytitle, extended)
        oTmpPlateLogics.insert(ModPlate)

        ''18
        Me.SetPrice(price * 1.347676 + deltaprice, ModPlate)
        Me.ReplaceColorClarity("I", "VS1", ModPlate, title, cs_desc, ss_desc, ebaytitle, extended)
        oTmpPlateLogics.insert(ModPlate)

        ''19
        Me.SetPrice(price * 1.38810628 + deltaprice, ModPlate)
        Me.ReplaceColorClarity("H", "VS1", ModPlate, title, cs_desc, ss_desc, ebaytitle, extended)
        oTmpPlateLogics.insert(ModPlate)


        ''20
        Me.SetPrice(price * 1.457511594 + deltaprice, ModPlate)
        Me.ReplaceColorClarity("G", "VS1", ModPlate, title, cs_desc, ss_desc, ebaytitle, extended)
        oTmpPlateLogics.insert(ModPlate)


        ''21
        Me.SetPrice(price * 1.6032627534 + deltaprice, ModPlate)
        Me.ReplaceColorClarity("F", "VS1", ModPlate, title, cs_desc, ss_desc, ebaytitle, extended)
        oTmpPlateLogics.insert(ModPlate)

        ''22
        Me.SetPrice(price * 1.731523773672 + deltaprice, ModPlate)
        Me.ReplaceColorClarity("E", "VS1", ModPlate, title, cs_desc, ss_desc, ebaytitle, extended)
        oTmpPlateLogics.insert(ModPlate)

        ''23
        Me.SetPrice(price * 1.9046761510392 + deltaprice, ModPlate)
        Me.ReplaceColorClarity("D", "VS1", ModPlate, title, cs_desc, ss_desc, ebaytitle, extended)
        oTmpPlateLogics.insert(ModPlate)

        Me.UpdateIsPartOf(itemid)
    End Function

    Function RoseGold()
        Dim bError As Boolean = False
        Dim oPlateSkelet As New ion_two.skl_inventory

        '--- Define logics and get the plate
        Dim oTmpPlateLogics As New ion_two.cls_inventory_lgc
        oTmpPlateLogics._connection_string = Application("config").connection_string
        oTmpPlateLogics._dbtype = Application("config").connection_string_type

        Dim onumber As New ion_two.cls_itemnumber
        onumber._connection_string = Application("config").connection_string
        onumber._dbtype = Application("config").connection_string_type
        Dim itemid As Int32
        onumber.getid_fromnumber(Me.txt_rose.Text, itemid, bError)
        oTmpPlateLogics.read(itemid, oPlateSkelet)


        '' copy part of the white gold
        Dim ModPlate As New ion_two.skl_inventory

        ModPlate = oPlateSkelet
        ModPlate._subplate._jewel_extended.is_partof_model = True
        Dim title As String = oPlateSkelet._subplate.jewel_title
        Dim cs_desc As String = oPlateSkelet._subplate._jewel_extended.cs_desc
        Dim ss_desc As String = oPlateSkelet._subplate._jewel_extended.ss_desc
        Dim ebaytitle As String = oPlateSkelet.opthash("ebaytitle")
        Dim price As Decimal = oPlateSkelet._purchase_price
        Dim extended As String = oPlateSkelet._subplate.jewel_extended
        ''  Me.wgprice = price
        ''1
        Me.SetPrice(price * 1.03, ModPlate)
        Me.ReplaceColorClarity("H", "SI2", ModPlate, title, cs_desc, ss_desc, ebaytitle, extended)
        oTmpPlateLogics.insert(ModPlate)
        ''2
        Me.SetPrice(price * 1.05 * 1.03, ModPlate)
        Me.ReplaceColorClarity("G", "SI2", ModPlate, title, cs_desc, ss_desc, ebaytitle, extended)
        oTmpPlateLogics.insert(ModPlate)

        ''3
        Me.SetPrice(price * 1.18965, ModPlate)
        Me.ReplaceColorClarity("F", "SI2", ModPlate, title, cs_desc, ss_desc, ebaytitle, extended)
        oTmpPlateLogics.insert(ModPlate)

        ''4
        Me.SetPrice(price * 1.284822, ModPlate)
        Me.ReplaceColorClarity("E", "SI2", ModPlate, title, cs_desc, ss_desc, ebaytitle, extended)
        oTmpPlateLogics.insert(ModPlate)

        ''5
        Me.SetPrice(price * 1.4133042, ModPlate)
        Me.ReplaceColorClarity("D", "SI2", ModPlate, title, cs_desc, ss_desc, ebaytitle, extended)
        oTmpPlateLogics.insert(ModPlate)


        ''6
        Me.SetPrice(price * 1.1, ModPlate)
        Me.ReplaceColorClarity("I", "SI1", ModPlate, title, cs_desc, ss_desc, ebaytitle, extended)
        oTmpPlateLogics.insert(ModPlate)

        ''7
        Me.SetPrice(price * 1.133, ModPlate)
        Me.ReplaceColorClarity("H", "SI1", ModPlate, title, cs_desc, ss_desc, ebaytitle, extended)
        oTmpPlateLogics.insert(ModPlate)

        ''8
        Me.SetPrice(price * 1.18965, ModPlate)
        Me.ReplaceColorClarity("G", "SI1", ModPlate, title, cs_desc, ss_desc, ebaytitle, extended)
        oTmpPlateLogics.insert(ModPlate)

        ''9
        Me.SetPrice(price * 1.308615, ModPlate)
        Me.ReplaceColorClarity("F", "SI1", ModPlate, title, cs_desc, ss_desc, ebaytitle, extended)
        oTmpPlateLogics.insert(ModPlate)


        ''10
        Me.SetPrice(price * 1.4133042, ModPlate)
        Me.ReplaceColorClarity("E", "SI1", ModPlate, title, cs_desc, ss_desc, ebaytitle, extended)
        oTmpPlateLogics.insert(ModPlate)

        ''11
        Me.SetPrice(price * 1.55463462, ModPlate)
        Me.ReplaceColorClarity("D", "SI1", ModPlate, title, cs_desc, ss_desc, ebaytitle, extended)
        oTmpPlateLogics.insert(ModPlate)


        ''12
        Me.SetPrice(price * 1.2364, ModPlate)
        Me.ReplaceColorClarity("I", "VS2", ModPlate, title, cs_desc, ss_desc, ebaytitle, extended)
        oTmpPlateLogics.insert(ModPlate)

        ''13
        Me.SetPrice(price * 1.273492, ModPlate)
        Me.ReplaceColorClarity("H", "VS2", ModPlate, title, cs_desc, ss_desc, ebaytitle, extended)
        oTmpPlateLogics.insert(ModPlate)

        ''14
        Me.SetPrice(price * 1.3371666, ModPlate)
        Me.ReplaceColorClarity("G", "VS2", ModPlate, title, cs_desc, ss_desc, ebaytitle, extended)
        oTmpPlateLogics.insert(ModPlate)

        ''15
        Me.SetPrice(price * 1.47088326, ModPlate)
        Me.ReplaceColorClarity("F", "VS2", ModPlate, title, cs_desc, ss_desc, ebaytitle, extended)
        oTmpPlateLogics.insert(ModPlate)

        ''16
        Me.SetPrice(price * 1.5885539208, ModPlate)
        Me.ReplaceColorClarity("E", "VS2", ModPlate, title, cs_desc, ss_desc, ebaytitle, extended)
        oTmpPlateLogics.insert(ModPlate)

        ''17
        Me.SetPrice(price * 1.74740931288, ModPlate)
        Me.ReplaceColorClarity("D", "VS2", ModPlate, title, cs_desc, ss_desc, ebaytitle, extended)
        oTmpPlateLogics.insert(ModPlate)

        ''18
        Me.SetPrice(price * 1.347676, ModPlate)
        Me.ReplaceColorClarity("I", "VS1", ModPlate, title, cs_desc, ss_desc, ebaytitle, extended)
        oTmpPlateLogics.insert(ModPlate)

        ''19
        Me.SetPrice(price * 1.38810628, ModPlate)
        Me.ReplaceColorClarity("H", "VS1", ModPlate, title, cs_desc, ss_desc, ebaytitle, extended)
        oTmpPlateLogics.insert(ModPlate)


        ''20
        Me.SetPrice(price * 1.457511594, ModPlate)
        Me.ReplaceColorClarity("G", "VS1", ModPlate, title, cs_desc, ss_desc, ebaytitle, extended)
        oTmpPlateLogics.insert(ModPlate)


        ''21
        Me.SetPrice(price * 1.6032627534, ModPlate)
        Me.ReplaceColorClarity("F", "VS1", ModPlate, title, cs_desc, ss_desc, ebaytitle, extended)
        oTmpPlateLogics.insert(ModPlate)

        ''22
        Me.SetPrice(price * 1.731523773672, ModPlate)
        Me.ReplaceColorClarity("E", "VS1", ModPlate, title, cs_desc, ss_desc, ebaytitle, extended)
        oTmpPlateLogics.insert(ModPlate)

        ''23
        Me.SetPrice(price * 1.9046761510392, ModPlate)
        Me.ReplaceColorClarity("D", "VS1", ModPlate, title, cs_desc, ss_desc, ebaytitle, extended)
        oTmpPlateLogics.insert(ModPlate)

        Me.UpdateIsPartOf(itemid)
    End Function

    Function WhiteGold_NoStoneChange()
        Dim bError As Boolean = False
        Dim oPlateSkelet As New ion_two.skl_inventory

        '--- Define logics and get the plate
        Dim oTmpPlateLogics As New ion_two.cls_inventory_lgc
        oTmpPlateLogics._connection_string = Application("config").connection_string
        oTmpPlateLogics._dbtype = Application("config").connection_string_type

        Dim onumber As New ion_two.cls_itemnumber
        onumber._connection_string = Application("config").connection_string
        onumber._dbtype = Application("config").connection_string_type
        Dim itemid As Int32
        onumber.getid_fromnumber(Me.txt_whitegold.Text, itemid, bError)
        oTmpPlateLogics.read(itemid, oPlateSkelet)


        '' copy part of the white gold
        Dim ModPlate As New ion_two.skl_inventory

        ModPlate = oPlateSkelet
        ModPlate._subplate._jewel_extended.is_partof_model = True

        Dim title As String = oPlateSkelet._subplate.jewel_title
        Dim cs_desc As String = oPlateSkelet._subplate._jewel_extended.cs_desc
        Dim ss_desc As String = oPlateSkelet._subplate._jewel_extended.ss_desc
        Dim ebaytitle As String = oPlateSkelet.opthash("ebaytitle")
        Dim price As Decimal = oPlateSkelet._purchase_price
        Dim extended As String = oPlateSkelet._subplate.jewel_extended
        Me.wgprice = price
        ''1
        Me.SetPrice(price * 1.01, ModPlate)
        Me.ReplaceColorClarity("H", "SI2", ModPlate, title, cs_desc, ss_desc, ebaytitle, extended)
        oTmpPlateLogics.insert(ModPlate)
        ''2
        Me.SetPrice(price * 1.01 ^ 2, ModPlate)
        Me.ReplaceColorClarity("G", "SI2", ModPlate, title, cs_desc, ss_desc, ebaytitle, extended)
        oTmpPlateLogics.insert(ModPlate)

        ''3
        Me.SetPrice(price * 1.01 ^ 3, ModPlate)
        Me.ReplaceColorClarity("F", "SI2", ModPlate, title, cs_desc, ss_desc, ebaytitle, extended)
        oTmpPlateLogics.insert(ModPlate)

        ''4
        Me.SetPrice(price * 1.01 ^ 4, ModPlate)
        Me.ReplaceColorClarity("E", "SI2", ModPlate, title, cs_desc, ss_desc, ebaytitle, extended)
        oTmpPlateLogics.insert(ModPlate)

        ''5
        Me.SetPrice(price * 1.01 ^ 5, ModPlate)
        Me.ReplaceColorClarity("D", "SI2", ModPlate, title, cs_desc, ss_desc, ebaytitle, extended)
        oTmpPlateLogics.insert(ModPlate)


        ''6
        Me.SetPrice(price * 1.01, ModPlate)
        Me.ReplaceColorClarity("I", "SI1", ModPlate, title, cs_desc, ss_desc, ebaytitle, extended)
        oTmpPlateLogics.insert(ModPlate)

        ''7
        Me.SetPrice(price * 1.01 ^ 2, ModPlate)
        Me.ReplaceColorClarity("H", "SI1", ModPlate, title, cs_desc, ss_desc, ebaytitle, extended)
        oTmpPlateLogics.insert(ModPlate)

        ''8
        Me.SetPrice(price * 1.01 ^ 3, ModPlate)
        Me.ReplaceColorClarity("G", "SI1", ModPlate, title, cs_desc, ss_desc, ebaytitle, extended)
        oTmpPlateLogics.insert(ModPlate)

        ''9
        Me.SetPrice(price * 1.01 ^ 4, ModPlate)
        Me.ReplaceColorClarity("F", "SI1", ModPlate, title, cs_desc, ss_desc, ebaytitle, extended)
        oTmpPlateLogics.insert(ModPlate)


        ''10
        Me.SetPrice(price * 1.01 ^ 5, ModPlate)
        Me.ReplaceColorClarity("E", "SI1", ModPlate, title, cs_desc, ss_desc, ebaytitle, extended)
        oTmpPlateLogics.insert(ModPlate)

        ''11
        Me.SetPrice(price * 1.01 ^ 6, ModPlate)
        Me.ReplaceColorClarity("D", "SI1", ModPlate, title, cs_desc, ss_desc, ebaytitle, extended)
        oTmpPlateLogics.insert(ModPlate)


        ''12
        Me.SetPrice(price * 1.01 ^ 2, ModPlate)
        Me.ReplaceColorClarity("I", "VS2", ModPlate, title, cs_desc, ss_desc, ebaytitle, extended)
        oTmpPlateLogics.insert(ModPlate)

        ''13
        Me.SetPrice(price * 1.01 ^ 3, ModPlate)
        Me.ReplaceColorClarity("H", "VS2", ModPlate, title, cs_desc, ss_desc, ebaytitle, extended)
        oTmpPlateLogics.insert(ModPlate)

        ''14
        Me.SetPrice(price * 1.01 ^ 4, ModPlate)
        Me.ReplaceColorClarity("G", "VS2", ModPlate, title, cs_desc, ss_desc, ebaytitle, extended)
        oTmpPlateLogics.insert(ModPlate)

        ''15
        Me.SetPrice(price * 1.01 ^ 5, ModPlate)
        Me.ReplaceColorClarity("F", "VS2", ModPlate, title, cs_desc, ss_desc, ebaytitle, extended)
        oTmpPlateLogics.insert(ModPlate)

        ''16
        Me.SetPrice(price * 1.01 ^ 6, ModPlate)
        Me.ReplaceColorClarity("E", "VS2", ModPlate, title, cs_desc, ss_desc, ebaytitle, extended)
        oTmpPlateLogics.insert(ModPlate)

        ''17
        Me.SetPrice(price * 1.01 ^ 7, ModPlate)
        Me.ReplaceColorClarity("D", "VS2", ModPlate, title, cs_desc, ss_desc, ebaytitle, extended)
        oTmpPlateLogics.insert(ModPlate)

        ''18
        Me.SetPrice(price * 1.01 ^ 3, ModPlate)
        Me.ReplaceColorClarity("I", "VS1", ModPlate, title, cs_desc, ss_desc, ebaytitle, extended)
        oTmpPlateLogics.insert(ModPlate)

        ''19
        Me.SetPrice(price * 1.01 ^ 4, ModPlate)
        Me.ReplaceColorClarity("H", "VS1", ModPlate, title, cs_desc, ss_desc, ebaytitle, extended)
        oTmpPlateLogics.insert(ModPlate)


        ''20
        Me.SetPrice(price * 1.01 ^ 5, ModPlate)
        Me.ReplaceColorClarity("G", "VS1", ModPlate, title, cs_desc, ss_desc, ebaytitle, extended)
        oTmpPlateLogics.insert(ModPlate)


        ''21
        Me.SetPrice(price * 1.01 ^ 6, ModPlate)
        Me.ReplaceColorClarity("F", "VS1", ModPlate, title, cs_desc, ss_desc, ebaytitle, extended)
        oTmpPlateLogics.insert(ModPlate)

        ''22
        Me.SetPrice(price * 1.01 ^ 7, ModPlate)
        Me.ReplaceColorClarity("E", "VS1", ModPlate, title, cs_desc, ss_desc, ebaytitle, extended)
        oTmpPlateLogics.insert(ModPlate)

        ''23
        Me.SetPrice(price * 1.01 ^ 8, ModPlate)
        Me.ReplaceColorClarity("D", "VS1", ModPlate, title, cs_desc, ss_desc, ebaytitle, extended)
        oTmpPlateLogics.insert(ModPlate)

        Me.UpdateIsPartOf(itemid)
    End Function

    Function YellowGold_NoStoneChange()
        Dim bError As Boolean = False
        Dim oPlateSkelet As New ion_two.skl_inventory

        '--- Define logics and get the plate
        Dim oTmpPlateLogics As New ion_two.cls_inventory_lgc
        oTmpPlateLogics._connection_string = Application("config").connection_string
        oTmpPlateLogics._dbtype = Application("config").connection_string_type

        Dim onumber As New ion_two.cls_itemnumber
        onumber._connection_string = Application("config").connection_string
        onumber._dbtype = Application("config").connection_string_type
        Dim itemid As Int32
        onumber.getid_fromnumber(Me.txt_yellowgold.Text, itemid, bError)
        oTmpPlateLogics.read(itemid, oPlateSkelet)


        '' copy part of the white gold
        Dim ModPlate As New ion_two.skl_inventory

        ModPlate = oPlateSkelet
        ModPlate._subplate._jewel_extended.is_partof_model = True
        Dim title As String = oPlateSkelet._subplate.jewel_title
        Dim cs_desc As String = oPlateSkelet._subplate._jewel_extended.cs_desc
        Dim ss_desc As String = oPlateSkelet._subplate._jewel_extended.ss_desc
        Dim ebaytitle As String = oPlateSkelet.opthash("ebaytitle")
        Dim price As Decimal = oPlateSkelet._purchase_price
        Dim extended As String = oPlateSkelet._subplate.jewel_extended


        ''1
        Me.SetPrice(price * 1.01, ModPlate)
        Me.ReplaceColorClarity("H", "SI2", ModPlate, title, cs_desc, ss_desc, ebaytitle, extended)
        oTmpPlateLogics.insert(ModPlate)
        ''2
        Me.SetPrice(price * 1.01 ^ 2, ModPlate)
        Me.ReplaceColorClarity("G", "SI2", ModPlate, title, cs_desc, ss_desc, ebaytitle, extended)
        oTmpPlateLogics.insert(ModPlate)

        ''3
        Me.SetPrice(price * 1.01 ^ 3, ModPlate)
        Me.ReplaceColorClarity("F", "SI2", ModPlate, title, cs_desc, ss_desc, ebaytitle, extended)
        oTmpPlateLogics.insert(ModPlate)

        ''4
        Me.SetPrice(price * 1.01 ^ 4, ModPlate)
        Me.ReplaceColorClarity("E", "SI2", ModPlate, title, cs_desc, ss_desc, ebaytitle, extended)
        oTmpPlateLogics.insert(ModPlate)

        ''5
        Me.SetPrice(price * 1.01 ^ 5, ModPlate)
        Me.ReplaceColorClarity("D", "SI2", ModPlate, title, cs_desc, ss_desc, ebaytitle, extended)
        oTmpPlateLogics.insert(ModPlate)


        ''6
        Me.SetPrice(price * 1.01, ModPlate)
        Me.ReplaceColorClarity("I", "SI1", ModPlate, title, cs_desc, ss_desc, ebaytitle, extended)
        oTmpPlateLogics.insert(ModPlate)

        ''7
        Me.SetPrice(price * 1.01 ^ 2, ModPlate)
        Me.ReplaceColorClarity("H", "SI1", ModPlate, title, cs_desc, ss_desc, ebaytitle, extended)
        oTmpPlateLogics.insert(ModPlate)

        ''8
        Me.SetPrice(price * 1.01 ^ 3, ModPlate)
        Me.ReplaceColorClarity("G", "SI1", ModPlate, title, cs_desc, ss_desc, ebaytitle, extended)
        oTmpPlateLogics.insert(ModPlate)

        ''9
        Me.SetPrice(price * 1.01 ^ 4, ModPlate)
        Me.ReplaceColorClarity("F", "SI1", ModPlate, title, cs_desc, ss_desc, ebaytitle, extended)
        oTmpPlateLogics.insert(ModPlate)


        ''10
        Me.SetPrice(price * 1.01 ^ 5, ModPlate)
        Me.ReplaceColorClarity("E", "SI1", ModPlate, title, cs_desc, ss_desc, ebaytitle, extended)
        oTmpPlateLogics.insert(ModPlate)

        ''11
        Me.SetPrice(price * 1.01 ^ 6, ModPlate)
        Me.ReplaceColorClarity("D", "SI1", ModPlate, title, cs_desc, ss_desc, ebaytitle, extended)
        oTmpPlateLogics.insert(ModPlate)


        ''12
        Me.SetPrice(price * 1.01 ^ 2, ModPlate)
        Me.ReplaceColorClarity("I", "VS2", ModPlate, title, cs_desc, ss_desc, ebaytitle, extended)
        oTmpPlateLogics.insert(ModPlate)

        ''13
        Me.SetPrice(price * 1.01 ^ 3, ModPlate)
        Me.ReplaceColorClarity("H", "VS2", ModPlate, title, cs_desc, ss_desc, ebaytitle, extended)
        oTmpPlateLogics.insert(ModPlate)

        ''14
        Me.SetPrice(price * 1.01 ^ 4, ModPlate)
        Me.ReplaceColorClarity("G", "VS2", ModPlate, title, cs_desc, ss_desc, ebaytitle, extended)
        oTmpPlateLogics.insert(ModPlate)

        ''15
        Me.SetPrice(price * 1.01 ^ 5, ModPlate)
        Me.ReplaceColorClarity("F", "VS2", ModPlate, title, cs_desc, ss_desc, ebaytitle, extended)
        oTmpPlateLogics.insert(ModPlate)

        ''16
        Me.SetPrice(price * 1.01 ^ 6, ModPlate)
        Me.ReplaceColorClarity("E", "VS2", ModPlate, title, cs_desc, ss_desc, ebaytitle, extended)
        oTmpPlateLogics.insert(ModPlate)

        ''17
        Me.SetPrice(price * 1.01 ^ 7, ModPlate)
        Me.ReplaceColorClarity("D", "VS2", ModPlate, title, cs_desc, ss_desc, ebaytitle, extended)
        oTmpPlateLogics.insert(ModPlate)

        ''18
        Me.SetPrice(price * 1.01 ^ 3, ModPlate)
        Me.ReplaceColorClarity("I", "VS1", ModPlate, title, cs_desc, ss_desc, ebaytitle, extended)
        oTmpPlateLogics.insert(ModPlate)

        ''19
        Me.SetPrice(price * 1.01 ^ 4, ModPlate)
        Me.ReplaceColorClarity("H", "VS1", ModPlate, title, cs_desc, ss_desc, ebaytitle, extended)
        oTmpPlateLogics.insert(ModPlate)


        ''20
        Me.SetPrice(price * 1.01 ^ 5, ModPlate)
        Me.ReplaceColorClarity("G", "VS1", ModPlate, title, cs_desc, ss_desc, ebaytitle, extended)
        oTmpPlateLogics.insert(ModPlate)


        ''21
        Me.SetPrice(price * 1.01 ^ 6, ModPlate)
        Me.ReplaceColorClarity("F", "VS1", ModPlate, title, cs_desc, ss_desc, ebaytitle, extended)
        oTmpPlateLogics.insert(ModPlate)

        ''22
        Me.SetPrice(price * 1.01 ^ 7, ModPlate)
        Me.ReplaceColorClarity("E", "VS1", ModPlate, title, cs_desc, ss_desc, ebaytitle, extended)
        oTmpPlateLogics.insert(ModPlate)

        ''23
        Me.SetPrice(price * 1.01 ^ 8, ModPlate)
        Me.ReplaceColorClarity("D", "VS1", ModPlate, title, cs_desc, ss_desc, ebaytitle, extended)
        oTmpPlateLogics.insert(ModPlate)

        Me.UpdateIsPartOf(itemid)
    End Function



    Function Platinum_NoStoneChange()
        Dim bError As Boolean = False
        Dim oPlateSkelet As New ion_two.skl_inventory

        '--- Define logics and get the plate
        Dim oTmpPlateLogics As New ion_two.cls_inventory_lgc
        oTmpPlateLogics._connection_string = Application("config").connection_string
        oTmpPlateLogics._dbtype = Application("config").connection_string_type

        Dim onumber As New ion_two.cls_itemnumber
        onumber._connection_string = Application("config").connection_string
        onumber._dbtype = Application("config").connection_string_type
        Dim itemid As Int32
        onumber.getid_fromnumber(Me.txt_platinum.Text, itemid, bError)
        oTmpPlateLogics.read(itemid, oPlateSkelet)


        '' copy part of the white gold
        Dim ModPlate As New ion_two.skl_inventory

        ModPlate = oPlateSkelet
        ModPlate._subplate._jewel_extended.is_partof_model = True
        Dim title As String = oPlateSkelet._subplate.jewel_title
        Dim cs_desc As String = oPlateSkelet._subplate._jewel_extended.cs_desc
        Dim ss_desc As String = oPlateSkelet._subplate._jewel_extended.ss_desc
        Dim ebaytitle As String = oPlateSkelet.opthash("ebaytitle")
        Dim extended As String = oPlateSkelet._subplate.jewel_extended
        Dim price As Decimal = Me.wgprice

        Dim deltaprice As Decimal = oPlateSkelet._purchase_price - Me.wgprice
        ''1
        Me.SetPrice(price * 1.01 + deltaprice, ModPlate)
        Me.ReplaceColorClarity("H", "SI2", ModPlate, title, cs_desc, ss_desc, ebaytitle, extended)
        oTmpPlateLogics.insert(ModPlate)
        ''2
        Me.SetPrice(price * 1.01 ^ 2 + deltaprice, ModPlate)
        Me.ReplaceColorClarity("G", "SI2", ModPlate, title, cs_desc, ss_desc, ebaytitle, extended)
        oTmpPlateLogics.insert(ModPlate)

        ''3
        Me.SetPrice(price * 1.01 ^ 3 + deltaprice, ModPlate)
        Me.ReplaceColorClarity("F", "SI2", ModPlate, title, cs_desc, ss_desc, ebaytitle, extended)
        oTmpPlateLogics.insert(ModPlate)

        ''4
        Me.SetPrice(price * 1.01 ^ 4 + deltaprice, ModPlate)
        Me.ReplaceColorClarity("E", "SI2", ModPlate, title, cs_desc, ss_desc, ebaytitle, extended)
        oTmpPlateLogics.insert(ModPlate)

        ''5
        Me.SetPrice(price * 1.01 ^ 5 + deltaprice, ModPlate)
        Me.ReplaceColorClarity("D", "SI2", ModPlate, title, cs_desc, ss_desc, ebaytitle, extended)
        oTmpPlateLogics.insert(ModPlate)


        ''6
        Me.SetPrice(price * 1.01 + deltaprice, ModPlate)
        Me.ReplaceColorClarity("I", "SI1", ModPlate, title, cs_desc, ss_desc, ebaytitle, extended)
        oTmpPlateLogics.insert(ModPlate)

        ''7
        Me.SetPrice(price * 1.01 ^ 2 + deltaprice, ModPlate)
        Me.ReplaceColorClarity("H", "SI1", ModPlate, title, cs_desc, ss_desc, ebaytitle, extended)
        oTmpPlateLogics.insert(ModPlate)

        ''8
        Me.SetPrice(price * 1.01 ^ 3 + deltaprice, ModPlate)
        Me.ReplaceColorClarity("G", "SI1", ModPlate, title, cs_desc, ss_desc, ebaytitle, extended)
        oTmpPlateLogics.insert(ModPlate)

        ''9
        Me.SetPrice(price * 1.01 ^ 4 + deltaprice, ModPlate)
        Me.ReplaceColorClarity("F", "SI1", ModPlate, title, cs_desc, ss_desc, ebaytitle, extended)
        oTmpPlateLogics.insert(ModPlate)


        ''10
        Me.SetPrice(price * 1.01 ^ 5 + deltaprice, ModPlate)
        Me.ReplaceColorClarity("E", "SI1", ModPlate, title, cs_desc, ss_desc, ebaytitle, extended)
        oTmpPlateLogics.insert(ModPlate)

        ''11
        Me.SetPrice(price * 1.01 ^ 6 + deltaprice, ModPlate)
        Me.ReplaceColorClarity("D", "SI1", ModPlate, title, cs_desc, ss_desc, ebaytitle, extended)
        oTmpPlateLogics.insert(ModPlate)


        ''12
        Me.SetPrice(price * 1.01 ^ 2 + deltaprice, ModPlate)
        Me.ReplaceColorClarity("I", "VS2", ModPlate, title, cs_desc, ss_desc, ebaytitle, extended)
        oTmpPlateLogics.insert(ModPlate)

        ''13
        Me.SetPrice(price * 1.01 ^ 3 + deltaprice, ModPlate)
        Me.ReplaceColorClarity("H", "VS2", ModPlate, title, cs_desc, ss_desc, ebaytitle, extended)
        oTmpPlateLogics.insert(ModPlate)

        ''14
        Me.SetPrice(price * 1.01 ^ 4 + deltaprice, ModPlate)
        Me.ReplaceColorClarity("G", "VS2", ModPlate, title, cs_desc, ss_desc, ebaytitle, extended)
        oTmpPlateLogics.insert(ModPlate)

        ''15
        Me.SetPrice(price * 1.01 ^ 5 + deltaprice, ModPlate)
        Me.ReplaceColorClarity("F", "VS2", ModPlate, title, cs_desc, ss_desc, ebaytitle, extended)
        oTmpPlateLogics.insert(ModPlate)

        ''16
        Me.SetPrice(price * 1.01 ^ 6 + deltaprice, ModPlate)
        Me.ReplaceColorClarity("E", "VS2", ModPlate, title, cs_desc, ss_desc, ebaytitle, extended)
        oTmpPlateLogics.insert(ModPlate)

        ''17
        Me.SetPrice(price * 1.01 ^ 7 + deltaprice, ModPlate)
        Me.ReplaceColorClarity("D", "VS2", ModPlate, title, cs_desc, ss_desc, ebaytitle, extended)
        oTmpPlateLogics.insert(ModPlate)

        ''18
        Me.SetPrice(price * 1.01 ^ 3 + deltaprice, ModPlate)
        Me.ReplaceColorClarity("I", "VS1", ModPlate, title, cs_desc, ss_desc, ebaytitle, extended)
        oTmpPlateLogics.insert(ModPlate)

        ''19
        Me.SetPrice(price * 1.01 ^ 4 + deltaprice, ModPlate)
        Me.ReplaceColorClarity("H", "VS1", ModPlate, title, cs_desc, ss_desc, ebaytitle, extended)
        oTmpPlateLogics.insert(ModPlate)


        ''20
        Me.SetPrice(price * 1.01 ^ 5 + deltaprice, ModPlate)
        Me.ReplaceColorClarity("G", "VS1", ModPlate, title, cs_desc, ss_desc, ebaytitle, extended)
        oTmpPlateLogics.insert(ModPlate)


        ''21
        Me.SetPrice(price * 1.01 ^ 6 + deltaprice, ModPlate)
        Me.ReplaceColorClarity("F", "VS1", ModPlate, title, cs_desc, ss_desc, ebaytitle, extended)
        oTmpPlateLogics.insert(ModPlate)

        ''22
        Me.SetPrice(price * 1.01 ^ 7 + deltaprice, ModPlate)
        Me.ReplaceColorClarity("E", "VS1", ModPlate, title, cs_desc, ss_desc, ebaytitle, extended)
        oTmpPlateLogics.insert(ModPlate)

        ''23
        Me.SetPrice(price * 1.01 ^ 8 + deltaprice, ModPlate)
        Me.ReplaceColorClarity("D", "VS1", ModPlate, title, cs_desc, ss_desc, ebaytitle, extended)
        oTmpPlateLogics.insert(ModPlate)

        Me.UpdateIsPartOf(itemid)
    End Function

    Function RoseGold_NoStoneChange()
        Dim bError As Boolean = False
        Dim oPlateSkelet As New ion_two.skl_inventory

        '--- Define logics and get the plate
        Dim oTmpPlateLogics As New ion_two.cls_inventory_lgc
        oTmpPlateLogics._connection_string = Application("config").connection_string
        oTmpPlateLogics._dbtype = Application("config").connection_string_type

        Dim onumber As New ion_two.cls_itemnumber
        onumber._connection_string = Application("config").connection_string
        onumber._dbtype = Application("config").connection_string_type
        Dim itemid As Int32
        onumber.getid_fromnumber(Me.txt_rose.Text, itemid, bError)
        oTmpPlateLogics.read(itemid, oPlateSkelet)


        '' copy part of the white gold
        Dim ModPlate As New ion_two.skl_inventory

        ModPlate = oPlateSkelet
        ModPlate._subplate._jewel_extended.is_partof_model = True
        Dim title As String = oPlateSkelet._subplate.jewel_title
        Dim cs_desc As String = oPlateSkelet._subplate._jewel_extended.cs_desc
        Dim ss_desc As String = oPlateSkelet._subplate._jewel_extended.ss_desc
        Dim ebaytitle As String = oPlateSkelet.opthash("ebaytitle")
        Dim price As Decimal = oPlateSkelet._purchase_price
        Dim extended As String = oPlateSkelet._subplate.jewel_extended
        ''  Me.wgprice = price
        ''1
        Me.SetPrice(price * 1.01, ModPlate)
        Me.ReplaceColorClarity("H", "SI2", ModPlate, title, cs_desc, ss_desc, ebaytitle, extended)
        oTmpPlateLogics.insert(ModPlate)
        ''2
        Me.SetPrice(price * 1.01 ^ 2, ModPlate)
        Me.ReplaceColorClarity("G", "SI2", ModPlate, title, cs_desc, ss_desc, ebaytitle, extended)
        oTmpPlateLogics.insert(ModPlate)

        ''3
        Me.SetPrice(price * 1.01 ^ 3, ModPlate)
        Me.ReplaceColorClarity("F", "SI2", ModPlate, title, cs_desc, ss_desc, ebaytitle, extended)
        oTmpPlateLogics.insert(ModPlate)

        ''4
        Me.SetPrice(price * 1.01 ^ 4, ModPlate)
        Me.ReplaceColorClarity("E", "SI2", ModPlate, title, cs_desc, ss_desc, ebaytitle, extended)
        oTmpPlateLogics.insert(ModPlate)

        ''5
        Me.SetPrice(price * 1.01 ^ 5, ModPlate)
        Me.ReplaceColorClarity("D", "SI2", ModPlate, title, cs_desc, ss_desc, ebaytitle, extended)
        oTmpPlateLogics.insert(ModPlate)


        ''6
        Me.SetPrice(price * 1.01, ModPlate)
        Me.ReplaceColorClarity("I", "SI1", ModPlate, title, cs_desc, ss_desc, ebaytitle, extended)
        oTmpPlateLogics.insert(ModPlate)

        ''7
        Me.SetPrice(price * 1.01 ^ 2, ModPlate)
        Me.ReplaceColorClarity("H", "SI1", ModPlate, title, cs_desc, ss_desc, ebaytitle, extended)
        oTmpPlateLogics.insert(ModPlate)

        ''8
        Me.SetPrice(price * 1.01 ^ 3, ModPlate)
        Me.ReplaceColorClarity("G", "SI1", ModPlate, title, cs_desc, ss_desc, ebaytitle, extended)
        oTmpPlateLogics.insert(ModPlate)

        ''9
        Me.SetPrice(price * 1.01 ^ 4, ModPlate)
        Me.ReplaceColorClarity("F", "SI1", ModPlate, title, cs_desc, ss_desc, ebaytitle, extended)
        oTmpPlateLogics.insert(ModPlate)


        ''10
        Me.SetPrice(price * 1.01 ^ 5, ModPlate)
        Me.ReplaceColorClarity("E", "SI1", ModPlate, title, cs_desc, ss_desc, ebaytitle, extended)
        oTmpPlateLogics.insert(ModPlate)

        ''11
        Me.SetPrice(price * 1.01 ^ 6, ModPlate)
        Me.ReplaceColorClarity("D", "SI1", ModPlate, title, cs_desc, ss_desc, ebaytitle, extended)
        oTmpPlateLogics.insert(ModPlate)


        ''12
        Me.SetPrice(price * 1.01 ^ 2, ModPlate)
        Me.ReplaceColorClarity("I", "VS2", ModPlate, title, cs_desc, ss_desc, ebaytitle, extended)
        oTmpPlateLogics.insert(ModPlate)

        ''13
        Me.SetPrice(price * 1.01 ^ 3, ModPlate)
        Me.ReplaceColorClarity("H", "VS2", ModPlate, title, cs_desc, ss_desc, ebaytitle, extended)
        oTmpPlateLogics.insert(ModPlate)

        ''14
        Me.SetPrice(price * 1.01 ^ 4, ModPlate)
        Me.ReplaceColorClarity("G", "VS2", ModPlate, title, cs_desc, ss_desc, ebaytitle, extended)
        oTmpPlateLogics.insert(ModPlate)

        ''15
        Me.SetPrice(price * 1.01 ^ 5, ModPlate)
        Me.ReplaceColorClarity("F", "VS2", ModPlate, title, cs_desc, ss_desc, ebaytitle, extended)
        oTmpPlateLogics.insert(ModPlate)

        ''16
        Me.SetPrice(price * 1.01 ^ 6, ModPlate)
        Me.ReplaceColorClarity("E", "VS2", ModPlate, title, cs_desc, ss_desc, ebaytitle, extended)
        oTmpPlateLogics.insert(ModPlate)

        ''17
        Me.SetPrice(price * 1.01 ^ 7, ModPlate)
        Me.ReplaceColorClarity("D", "VS2", ModPlate, title, cs_desc, ss_desc, ebaytitle, extended)
        oTmpPlateLogics.insert(ModPlate)

        ''18
        Me.SetPrice(price * 1.01 ^ 3, ModPlate)
        Me.ReplaceColorClarity("I", "VS1", ModPlate, title, cs_desc, ss_desc, ebaytitle, extended)
        oTmpPlateLogics.insert(ModPlate)

        ''19
        Me.SetPrice(price * 1.01 ^ 4, ModPlate)
        Me.ReplaceColorClarity("H", "VS1", ModPlate, title, cs_desc, ss_desc, ebaytitle, extended)
        oTmpPlateLogics.insert(ModPlate)


        ''20
        Me.SetPrice(price * 1.01 ^ 5, ModPlate)
        Me.ReplaceColorClarity("G", "VS1", ModPlate, title, cs_desc, ss_desc, ebaytitle, extended)
        oTmpPlateLogics.insert(ModPlate)


        ''21
        Me.SetPrice(price * 1.01 ^ 6, ModPlate)
        Me.ReplaceColorClarity("F", "VS1", ModPlate, title, cs_desc, ss_desc, ebaytitle, extended)
        oTmpPlateLogics.insert(ModPlate)

        ''22
        Me.SetPrice(price * 1.01 ^ 7, ModPlate)
        Me.ReplaceColorClarity("E", "VS1", ModPlate, title, cs_desc, ss_desc, ebaytitle, extended)
        oTmpPlateLogics.insert(ModPlate)

        ''23
        Me.SetPrice(price * 1.01 ^ 8, ModPlate)
        Me.ReplaceColorClarity("D", "VS1", ModPlate, title, cs_desc, ss_desc, ebaytitle, extended)
        oTmpPlateLogics.insert(ModPlate)

        Me.UpdateIsPartOf(itemid)
    End Function

    Function WhiteGold_Gem_Type1()
        Dim bError As Boolean = False
        Dim oPlateSkelet As New ion_two.skl_inventory

        '--- Define logics and get the plate
        Dim oTmpPlateLogics As New ion_two.cls_inventory_lgc
        oTmpPlateLogics._connection_string = Application("config").connection_string
        oTmpPlateLogics._dbtype = Application("config").connection_string_type

        Dim onumber As New ion_two.cls_itemnumber
        onumber._connection_string = Application("config").connection_string
        onumber._dbtype = Application("config").connection_string_type
        Dim itemid As Int32
        onumber.getid_fromnumber(Me.txt_whitegold_gem_1.Text, itemid, bError)
        oTmpPlateLogics.read(itemid, oPlateSkelet)

        Dim oextra As New ion_two.cls_jewerly_extra
        oextra.get_stone_extended_string(oPlateSkelet._subplate._stone_extended)


        '' copy part of the white gold
        Dim ModPlate As New ion_two.skl_inventory

        ModPlate = oPlateSkelet
        ModPlate._subplate._jewel_extended.is_partof_model = True
        Dim title As String = oPlateSkelet._subplate.jewel_title
        Dim extra As String = oPlateSkelet._subplate._stone_extended
        Dim ebaytitle As String = oPlateSkelet.opthash("ebaytitle")
        Dim price As Decimal = oPlateSkelet._purchase_price
        Dim cs_desc As String = oPlateSkelet._subplate._jewel_extended.cs_desc
        Dim ss_desc As String = oPlateSkelet._subplate._jewel_extended.ss_desc
        Dim note As String = oPlateSkelet._notes
        Dim stone_extended As String = oPlateSkelet._subplate._stone_extended




        Me.wgprice = price
        ''1
        Me.SetPrice(price * 1.03, ModPlate)
        Me.ReplaceCaratWeight(0.05, ModPlate, title, extra, ebaytitle, cs_desc, ss_desc, stone_extended, note)
        '' Me.ReplaceColorClarity("H", "SI2", ModPlate, title, cs_desc,ss_desc, ebaytitle,extended)
        oTmpPlateLogics.insert(ModPlate)
        ''2
        Me.SetPrice(price * 1.05 * 1.03, ModPlate)
        Me.ReplaceCaratWeight(0.1, ModPlate, title, extra, ebaytitle, cs_desc, ss_desc, stone_extended, note)
        oTmpPlateLogics.insert(ModPlate)

        '''3
        Me.SetPrice(price * 1.18965, ModPlate)
        Me.ReplaceCaratWeight(0.15, ModPlate, title, extra, ebaytitle, cs_desc, ss_desc, stone_extended, note)
        oTmpPlateLogics.insert(ModPlate)

        '''4
        Me.SetPrice(price * 1.284822, ModPlate)
        Me.ReplaceCaratWeight(0.2, ModPlate, title, extra, ebaytitle, cs_desc, ss_desc, stone_extended, note)
        oTmpPlateLogics.insert(ModPlate)

        '''5
        Me.SetPrice(price * 1.4133042, ModPlate)
        Me.ReplaceCaratWeight(0.25, ModPlate, title, extra, ebaytitle, cs_desc, ss_desc, stone_extended, note)
        oTmpPlateLogics.insert(ModPlate)


        ''6
        Me.SetPrice(price * 1.1 * 1.3636, ModPlate)
        Me.ReplaceCaratWeight(0.3, ModPlate, title, extra, ebaytitle, cs_desc, ss_desc, stone_extended, note)
        oTmpPlateLogics.insert(ModPlate)

        ''7
        Me.SetPrice(price * 1.133 * 1.3636, ModPlate)
        Me.ReplaceCaratWeight(0.35, ModPlate, title, extra, ebaytitle, cs_desc, ss_desc, stone_extended, note)
        oTmpPlateLogics.insert(ModPlate)

        ''8
        Me.SetPrice(price * 1.18965 * 1.3636, ModPlate)
        Me.ReplaceCaratWeight(0.4, ModPlate, title, extra, ebaytitle, cs_desc, ss_desc, stone_extended, note)
        oTmpPlateLogics.insert(ModPlate)

        ''9
        Me.SetPrice(price * 1.308615 * 1.3636, ModPlate)
        Me.ReplaceCaratWeight(0.45, ModPlate, title, extra, ebaytitle, cs_desc, ss_desc, stone_extended, note)
        oTmpPlateLogics.insert(ModPlate)


        ''10
        Me.SetPrice(price * 1.4133042 * 1.3636, ModPlate)
        Me.ReplaceCaratWeight(0.5, ModPlate, title, extra, ebaytitle, cs_desc, ss_desc, stone_extended, note)
        oTmpPlateLogics.insert(ModPlate)

        ''11
        Me.SetPrice(price * 1.55463462 * 1.3636, ModPlate)
        Me.ReplaceCaratWeight(0.55, ModPlate, title, extra, ebaytitle, cs_desc, ss_desc, stone_extended, note)
        oTmpPlateLogics.insert(ModPlate)

        Me.UpdateIsPartOf(itemid)
        '''12
        'Me.SetPrice(price * 1.2364, ModPlate)
        'Me.ReplaceColorClarity("I", "VS2", ModPlate, title, cs_desc,ss_desc, ebaytitle,extended)
        'oTmpPlateLogics.insert(ModPlate)

        '''13
        'Me.SetPrice(price * 1.273492, ModPlate)
        'Me.ReplaceColorClarity("H", "VS2", ModPlate, title, cs_desc,ss_desc, ebaytitle,extended)
        'oTmpPlateLogics.insert(ModPlate)

        '''14
        'Me.SetPrice(price * 1.3371666, ModPlate)
        'Me.ReplaceColorClarity("G", "VS2", ModPlate, title, cs_desc,ss_desc, ebaytitle,extended)
        'oTmpPlateLogics.insert(ModPlate)

        '''15
        'Me.SetPrice(price * 1.47088326, ModPlate)
        'Me.ReplaceColorClarity("F", "VS2", ModPlate, title, cs_desc,ss_desc, ebaytitle,extended)
        'oTmpPlateLogics.insert(ModPlate)

        '''16
        'Me.SetPrice(price * 1.5885539208, ModPlate)
        'Me.ReplaceColorClarity("E", "VS2", ModPlate, title, cs_desc,ss_desc, ebaytitle,extended)
        'oTmpPlateLogics.insert(ModPlate)

        '''17
        'Me.SetPrice(price * 1.74740931288, ModPlate)
        'Me.ReplaceColorClarity("D", "VS2", ModPlate, title, cs_desc,ss_desc, ebaytitle,extended)
        'oTmpPlateLogics.insert(ModPlate)

        '''18
        'Me.SetPrice(price * 1.347676, ModPlate)
        'Me.ReplaceColorClarity("I", "VS1", ModPlate, title, cs_desc,ss_desc, ebaytitle,extended)
        'oTmpPlateLogics.insert(ModPlate)

        '''19
        'Me.SetPrice(price * 1.38810628, ModPlate)
        'Me.ReplaceColorClarity("H", "VS1", ModPlate, title, cs_desc,ss_desc, ebaytitle,extended)
        'oTmpPlateLogics.insert(ModPlate)


        '''20
        'Me.SetPrice(price * 1.457511594, ModPlate)
        'Me.ReplaceColorClarity("G", "VS1", ModPlate, title, cs_desc,ss_desc, ebaytitle,extended)
        'oTmpPlateLogics.insert(ModPlate)


        '''21
        'Me.SetPrice(price * 1.6032627534, ModPlate)
        'Me.ReplaceColorClarity("F", "VS1", ModPlate, title, cs_desc,ss_desc, ebaytitle,extended)
        'oTmpPlateLogics.insert(ModPlate)

        '''22
        'Me.SetPrice(price * 1.731523773672, ModPlate)
        'Me.ReplaceColorClarity("E", "VS1", ModPlate, title, cs_desc,ss_desc, ebaytitle,extended)
        'oTmpPlateLogics.insert(ModPlate)

        '''23
        'Me.SetPrice(price * 1.9046761510392, ModPlate)
        'Me.ReplaceColorClarity("D", "VS1", ModPlate, title, cs_desc,ss_desc, ebaytitle,extended)
        'oTmpPlateLogics.insert(ModPlate)


    End Function

    Function YellowGold_Gem_Type1()
        Dim bError As Boolean = False
        Dim oPlateSkelet As New ion_two.skl_inventory

        '--- Define logics and get the plate
        Dim oTmpPlateLogics As New ion_two.cls_inventory_lgc
        oTmpPlateLogics._connection_string = Application("config").connection_string
        oTmpPlateLogics._dbtype = Application("config").connection_string_type

        Dim onumber As New ion_two.cls_itemnumber
        onumber._connection_string = Application("config").connection_string
        onumber._dbtype = Application("config").connection_string_type
        Dim itemid As Int32
        onumber.getid_fromnumber(Me.txt_yellowgold_gem_1.Text, itemid, bError)
        oTmpPlateLogics.read(itemid, oPlateSkelet)

        Dim oextra As New ion_two.cls_jewerly_extra
        oextra.get_stone_extended_string(oPlateSkelet._subplate._stone_extended)


        '' copy part of the white gold
        Dim ModPlate As New ion_two.skl_inventory

        ModPlate = oPlateSkelet
        ModPlate._subplate._jewel_extended.is_partof_model = True
        Dim title As String = oPlateSkelet._subplate.jewel_title
        Dim extra As String = oPlateSkelet._subplate._stone_extended
        Dim ebaytitle As String = oPlateSkelet.opthash("ebaytitle")
        Dim price As Decimal = oPlateSkelet._purchase_price
        Dim cs_desc As String = oPlateSkelet._subplate._jewel_extended.cs_desc
        Dim ss_desc As String = oPlateSkelet._subplate._jewel_extended.ss_desc
        Dim note As String = oPlateSkelet._notes
        Dim stone_extended As String = oPlateSkelet._subplate._stone_extended




        ''  Me.wgprice = price
        ''1
        Me.SetPrice(price * 1.03, ModPlate)
        Me.ReplaceCaratWeight(0.05, ModPlate, title, extra, ebaytitle, cs_desc, ss_desc, stone_extended, note)
        '' Me.ReplaceColorClarity("H", "SI2", ModPlate, title, cs_desc,ss_desc, ebaytitle,extended)
        oTmpPlateLogics.insert(ModPlate)
        ''2
        Me.SetPrice(price * 1.05 * 1.03, ModPlate)
        Me.ReplaceCaratWeight(0.1, ModPlate, title, extra, ebaytitle, cs_desc, ss_desc, stone_extended, note)
        oTmpPlateLogics.insert(ModPlate)

        '''3
        Me.SetPrice(price * 1.18965, ModPlate)
        Me.ReplaceCaratWeight(0.15, ModPlate, title, extra, ebaytitle, cs_desc, ss_desc, stone_extended, note)
        oTmpPlateLogics.insert(ModPlate)

        '''4
        Me.SetPrice(price * 1.284822, ModPlate)
        Me.ReplaceCaratWeight(0.2, ModPlate, title, extra, ebaytitle, cs_desc, ss_desc, stone_extended, note)
        oTmpPlateLogics.insert(ModPlate)

        '''5
        Me.SetPrice(price * 1.4133042, ModPlate)
        Me.ReplaceCaratWeight(0.25, ModPlate, title, extra, ebaytitle, cs_desc, ss_desc, stone_extended, note)
        oTmpPlateLogics.insert(ModPlate)


        ''6
        Me.SetPrice(price * 1.1 * 1.3636, ModPlate)
        Me.ReplaceCaratWeight(0.3, ModPlate, title, extra, ebaytitle, cs_desc, ss_desc, stone_extended, note)
        oTmpPlateLogics.insert(ModPlate)

        ''7
        Me.SetPrice(price * 1.133 * 1.3636, ModPlate)
        Me.ReplaceCaratWeight(0.35, ModPlate, title, extra, ebaytitle, cs_desc, ss_desc, stone_extended, note)
        oTmpPlateLogics.insert(ModPlate)

        ''8
        Me.SetPrice(price * 1.18965 * 1.3636, ModPlate)
        Me.ReplaceCaratWeight(0.4, ModPlate, title, extra, ebaytitle, cs_desc, ss_desc, stone_extended, note)
        oTmpPlateLogics.insert(ModPlate)

        ''9
        Me.SetPrice(price * 1.308615 * 1.3636, ModPlate)
        Me.ReplaceCaratWeight(0.45, ModPlate, title, extra, ebaytitle, cs_desc, ss_desc, stone_extended, note)
        oTmpPlateLogics.insert(ModPlate)


        ''10
        Me.SetPrice(price * 1.4133042 * 1.3636, ModPlate)
        Me.ReplaceCaratWeight(0.5, ModPlate, title, extra, ebaytitle, cs_desc, ss_desc, stone_extended, note)
        oTmpPlateLogics.insert(ModPlate)

        ''11
        Me.SetPrice(price * 1.55463462 * 1.3636, ModPlate)
        Me.ReplaceCaratWeight(0.55, ModPlate, title, extra, ebaytitle, cs_desc, ss_desc, stone_extended, note)
        oTmpPlateLogics.insert(ModPlate)

        Me.UpdateIsPartOf(itemid)
        '''12
        'Me.SetPrice(price * 1.2364, ModPlate)
        'Me.ReplaceColorClarity("I", "VS2", ModPlate, title, cs_desc,ss_desc, ebaytitle,extended)
        'oTmpPlateLogics.insert(ModPlate)

        '''13
        'Me.SetPrice(price * 1.273492, ModPlate)
        'Me.ReplaceColorClarity("H", "VS2", ModPlate, title, cs_desc,ss_desc, ebaytitle,extended)
        'oTmpPlateLogics.insert(ModPlate)

        '''14
        'Me.SetPrice(price * 1.3371666, ModPlate)
        'Me.ReplaceColorClarity("G", "VS2", ModPlate, title, cs_desc,ss_desc, ebaytitle,extended)
        'oTmpPlateLogics.insert(ModPlate)

        '''15
        'Me.SetPrice(price * 1.47088326, ModPlate)
        'Me.ReplaceColorClarity("F", "VS2", ModPlate, title, cs_desc,ss_desc, ebaytitle,extended)
        'oTmpPlateLogics.insert(ModPlate)

        '''16
        'Me.SetPrice(price * 1.5885539208, ModPlate)
        'Me.ReplaceColorClarity("E", "VS2", ModPlate, title, cs_desc,ss_desc, ebaytitle,extended)
        'oTmpPlateLogics.insert(ModPlate)

        '''17
        'Me.SetPrice(price * 1.74740931288, ModPlate)
        'Me.ReplaceColorClarity("D", "VS2", ModPlate, title, cs_desc,ss_desc, ebaytitle,extended)
        'oTmpPlateLogics.insert(ModPlate)

        '''18
        'Me.SetPrice(price * 1.347676, ModPlate)
        'Me.ReplaceColorClarity("I", "VS1", ModPlate, title, cs_desc,ss_desc, ebaytitle,extended)
        'oTmpPlateLogics.insert(ModPlate)

        '''19
        'Me.SetPrice(price * 1.38810628, ModPlate)
        'Me.ReplaceColorClarity("H", "VS1", ModPlate, title, cs_desc,ss_desc, ebaytitle,extended)
        'oTmpPlateLogics.insert(ModPlate)


        '''20
        'Me.SetPrice(price * 1.457511594, ModPlate)
        'Me.ReplaceColorClarity("G", "VS1", ModPlate, title, cs_desc,ss_desc, ebaytitle,extended)
        'oTmpPlateLogics.insert(ModPlate)


        '''21
        'Me.SetPrice(price * 1.6032627534, ModPlate)
        'Me.ReplaceColorClarity("F", "VS1", ModPlate, title, cs_desc,ss_desc, ebaytitle,extended)
        'oTmpPlateLogics.insert(ModPlate)

        '''22
        'Me.SetPrice(price * 1.731523773672, ModPlate)
        'Me.ReplaceColorClarity("E", "VS1", ModPlate, title, cs_desc,ss_desc, ebaytitle,extended)
        'oTmpPlateLogics.insert(ModPlate)

        '''23
        'Me.SetPrice(price * 1.9046761510392, ModPlate)
        'Me.ReplaceColorClarity("D", "VS1", ModPlate, title, cs_desc,ss_desc, ebaytitle,extended)
        'oTmpPlateLogics.insert(ModPlate)
    End Function

    Function RoseGold_Gem_Type1()
        Dim bError As Boolean = False
        Dim oPlateSkelet As New ion_two.skl_inventory

        '--- Define logics and get the plate
        Dim oTmpPlateLogics As New ion_two.cls_inventory_lgc
        oTmpPlateLogics._connection_string = Application("config").connection_string
        oTmpPlateLogics._dbtype = Application("config").connection_string_type

        Dim onumber As New ion_two.cls_itemnumber
        onumber._connection_string = Application("config").connection_string
        onumber._dbtype = Application("config").connection_string_type
        Dim itemid As Int32
        onumber.getid_fromnumber(Me.txt_rosegold_gem_1.Text, itemid, bError)
        oTmpPlateLogics.read(itemid, oPlateSkelet)

        Dim oextra As New ion_two.cls_jewerly_extra
        oextra.get_stone_extended_string(oPlateSkelet._subplate._stone_extended)


        '' copy part of the white gold
        Dim ModPlate As New ion_two.skl_inventory

        ModPlate = oPlateSkelet
        ModPlate._subplate._jewel_extended.is_partof_model = True
        Dim title As String = oPlateSkelet._subplate.jewel_title
        Dim extra As String = oPlateSkelet._subplate._stone_extended
        Dim ebaytitle As String = oPlateSkelet.opthash("ebaytitle")
        Dim price As Decimal = oPlateSkelet._purchase_price
        Dim cs_desc As String = oPlateSkelet._subplate._jewel_extended.cs_desc
        Dim ss_desc As String = oPlateSkelet._subplate._jewel_extended.ss_desc
        Dim note As String = oPlateSkelet._notes
        Dim stone_extended As String = oPlateSkelet._subplate._stone_extended




        ''  Me.wgprice = price
        ''1
        Me.SetPrice(price * 1.03, ModPlate)
        Me.ReplaceCaratWeight(0.05, ModPlate, title, extra, ebaytitle, cs_desc, ss_desc, stone_extended, note)
        '' Me.ReplaceColorClarity("H", "SI2", ModPlate, title, cs_desc,ss_desc, ebaytitle,extended)
        oTmpPlateLogics.insert(ModPlate)
        ''2
        Me.SetPrice(price * 1.05 * 1.03, ModPlate)
        Me.ReplaceCaratWeight(0.1, ModPlate, title, extra, ebaytitle, cs_desc, ss_desc, stone_extended, note)
        oTmpPlateLogics.insert(ModPlate)

        '''3
        Me.SetPrice(price * 1.18965, ModPlate)
        Me.ReplaceCaratWeight(0.15, ModPlate, title, extra, ebaytitle, cs_desc, ss_desc, stone_extended, note)
        oTmpPlateLogics.insert(ModPlate)

        '''4
        Me.SetPrice(price * 1.284822, ModPlate)
        Me.ReplaceCaratWeight(0.2, ModPlate, title, extra, ebaytitle, cs_desc, ss_desc, stone_extended, note)
        oTmpPlateLogics.insert(ModPlate)

        '''5
        Me.SetPrice(price * 1.4133042, ModPlate)
        Me.ReplaceCaratWeight(0.25, ModPlate, title, extra, ebaytitle, cs_desc, ss_desc, stone_extended, note)
        oTmpPlateLogics.insert(ModPlate)

        ''6
        Me.SetPrice(price * 1.1 * 1.3636, ModPlate)
        Me.ReplaceCaratWeight(0.3, ModPlate, title, extra, ebaytitle, cs_desc, ss_desc, stone_extended, note)
        oTmpPlateLogics.insert(ModPlate)

        ''7
        Me.SetPrice(price * 1.133 * 1.3636, ModPlate)
        Me.ReplaceCaratWeight(0.35, ModPlate, title, extra, ebaytitle, cs_desc, ss_desc, stone_extended, note)
        oTmpPlateLogics.insert(ModPlate)

        ''8
        Me.SetPrice(price * 1.18965 * 1.3636, ModPlate)
        Me.ReplaceCaratWeight(0.4, ModPlate, title, extra, ebaytitle, cs_desc, ss_desc, stone_extended, note)
        oTmpPlateLogics.insert(ModPlate)

        ''9
        Me.SetPrice(price * 1.308615 * 1.3636, ModPlate)
        Me.ReplaceCaratWeight(0.45, ModPlate, title, extra, ebaytitle, cs_desc, ss_desc, stone_extended, note)
        oTmpPlateLogics.insert(ModPlate)


        ''10
        Me.SetPrice(price * 1.4133042 * 1.3636, ModPlate)
        Me.ReplaceCaratWeight(0.5, ModPlate, title, extra, ebaytitle, cs_desc, ss_desc, stone_extended, note)
        oTmpPlateLogics.insert(ModPlate)

        ''11
        Me.SetPrice(price * 1.55463462 * 1.3636, ModPlate)
        Me.ReplaceCaratWeight(0.55, ModPlate, title, extra, ebaytitle, cs_desc, ss_desc, stone_extended, note)
        oTmpPlateLogics.insert(ModPlate)

        Me.UpdateIsPartOf(itemid)
        '''12
        'Me.SetPrice(price * 1.2364, ModPlate)
        'Me.ReplaceColorClarity("I", "VS2", ModPlate, title, cs_desc,ss_desc, ebaytitle,extended)
        'oTmpPlateLogics.insert(ModPlate)

        '''13
        'Me.SetPrice(price * 1.273492, ModPlate)
        'Me.ReplaceColorClarity("H", "VS2", ModPlate, title, cs_desc,ss_desc, ebaytitle,extended)
        'oTmpPlateLogics.insert(ModPlate)

        '''14
        'Me.SetPrice(price * 1.3371666, ModPlate)
        'Me.ReplaceColorClarity("G", "VS2", ModPlate, title, cs_desc,ss_desc, ebaytitle,extended)
        'oTmpPlateLogics.insert(ModPlate)

        '''15
        'Me.SetPrice(price * 1.47088326, ModPlate)
        'Me.ReplaceColorClarity("F", "VS2", ModPlate, title, cs_desc,ss_desc, ebaytitle,extended)
        'oTmpPlateLogics.insert(ModPlate)

        '''16
        'Me.SetPrice(price * 1.5885539208, ModPlate)
        'Me.ReplaceColorClarity("E", "VS2", ModPlate, title, cs_desc,ss_desc, ebaytitle,extended)
        'oTmpPlateLogics.insert(ModPlate)

        '''17
        'Me.SetPrice(price * 1.74740931288, ModPlate)
        'Me.ReplaceColorClarity("D", "VS2", ModPlate, title, cs_desc,ss_desc, ebaytitle,extended)
        'oTmpPlateLogics.insert(ModPlate)

        '''18
        'Me.SetPrice(price * 1.347676, ModPlate)
        'Me.ReplaceColorClarity("I", "VS1", ModPlate, title, cs_desc,ss_desc, ebaytitle,extended)
        'oTmpPlateLogics.insert(ModPlate)

        '''19
        'Me.SetPrice(price * 1.38810628, ModPlate)
        'Me.ReplaceColorClarity("H", "VS1", ModPlate, title, cs_desc,ss_desc, ebaytitle,extended)
        'oTmpPlateLogics.insert(ModPlate)


        '''20
        'Me.SetPrice(price * 1.457511594, ModPlate)
        'Me.ReplaceColorClarity("G", "VS1", ModPlate, title, cs_desc,ss_desc, ebaytitle,extended)
        'oTmpPlateLogics.insert(ModPlate)


        '''21
        'Me.SetPrice(price * 1.6032627534, ModPlate)
        'Me.ReplaceColorClarity("F", "VS1", ModPlate, title, cs_desc,ss_desc, ebaytitle,extended)
        'oTmpPlateLogics.insert(ModPlate)

        '''22
        'Me.SetPrice(price * 1.731523773672, ModPlate)
        'Me.ReplaceColorClarity("E", "VS1", ModPlate, title, cs_desc,ss_desc, ebaytitle,extended)
        'oTmpPlateLogics.insert(ModPlate)

        '''23
        'Me.SetPrice(price * 1.9046761510392, ModPlate)
        'Me.ReplaceColorClarity("D", "VS1", ModPlate, title, cs_desc,ss_desc, ebaytitle,extended)
        'oTmpPlateLogics.insert(ModPlate)
    End Function

    Function Platinum_Gem_Type1()
        Dim bError As Boolean = False
        Dim oPlateSkelet As New ion_two.skl_inventory

        '--- Define logics and get the plate
        Dim oTmpPlateLogics As New ion_two.cls_inventory_lgc
        oTmpPlateLogics._connection_string = Application("config").connection_string
        oTmpPlateLogics._dbtype = Application("config").connection_string_type

        Dim onumber As New ion_two.cls_itemnumber
        onumber._connection_string = Application("config").connection_string
        onumber._dbtype = Application("config").connection_string_type
        Dim itemid As Int32
        onumber.getid_fromnumber(Me.txt_platinum_gem_1.Text, itemid, bError)
        oTmpPlateLogics.read(itemid, oPlateSkelet)

        Dim oextra As New ion_two.cls_jewerly_extra
        oextra.get_stone_extended_string(oPlateSkelet._subplate._stone_extended)


        '' copy part of the white gold
        Dim ModPlate As New ion_two.skl_inventory

        ModPlate = oPlateSkelet
        ModPlate._subplate._jewel_extended.is_partof_model = True
        Dim title As String = oPlateSkelet._subplate.jewel_title
        Dim extra As String = oPlateSkelet._subplate._stone_extended
        Dim ebaytitle As String = oPlateSkelet.opthash("ebaytitle")
        Dim price As Decimal = Me.wgprice
        Dim cs_desc As String = oPlateSkelet._subplate._jewel_extended.cs_desc
        Dim ss_desc As String = oPlateSkelet._subplate._jewel_extended.ss_desc
        Dim note As String = oPlateSkelet._notes
        Dim stone_extended As String = oPlateSkelet._subplate._stone_extended

        Dim deltaprice As Decimal = oPlateSkelet._purchase_price - Me.wgprice


        ''  Me.wgprice = price
        ''1
        Me.SetPrice(price * 1.03 + deltaprice, ModPlate)
        Me.ReplaceCaratWeight(0.05, ModPlate, title, extra, ebaytitle, cs_desc, ss_desc, stone_extended, note)
        '' Me.ReplaceColorClarity("H", "SI2", ModPlate, title, cs_desc,ss_desc, ebaytitle,extended)
        oTmpPlateLogics.insert(ModPlate)
        ''2
        Me.SetPrice(price * 1.05 * 1.03 + deltaprice, ModPlate)
        Me.ReplaceCaratWeight(0.1, ModPlate, title, extra, ebaytitle, cs_desc, ss_desc, stone_extended, note)
        oTmpPlateLogics.insert(ModPlate)

        '''3
        Me.SetPrice(price * 1.18965 + deltaprice, ModPlate)
        Me.ReplaceCaratWeight(0.15, ModPlate, title, extra, ebaytitle, cs_desc, ss_desc, stone_extended, note)
        oTmpPlateLogics.insert(ModPlate)

        '''4
        Me.SetPrice(price * 1.284822 + deltaprice, ModPlate)
        Me.ReplaceCaratWeight(0.2, ModPlate, title, extra, ebaytitle, cs_desc, ss_desc, stone_extended, note)
        oTmpPlateLogics.insert(ModPlate)

        '''5
        Me.SetPrice(price * 1.4133042 + deltaprice, ModPlate)
        Me.ReplaceCaratWeight(0.25, ModPlate, title, extra, ebaytitle, cs_desc, ss_desc, stone_extended, note)
        oTmpPlateLogics.insert(ModPlate)

        ''6
        Me.SetPrice(price * 1.5 + deltaprice, ModPlate)
        Me.ReplaceCaratWeight(0.3, ModPlate, title, extra, ebaytitle, cs_desc, ss_desc, stone_extended, note)
        oTmpPlateLogics.insert(ModPlate)

        ''7
        Me.SetPrice(price * 1.133 * 1.3636 + deltaprice, ModPlate)
        Me.ReplaceCaratWeight(0.35, ModPlate, title, extra, ebaytitle, cs_desc, ss_desc, stone_extended, note)
        oTmpPlateLogics.insert(ModPlate)

        ''8
        Me.SetPrice(price * 1.18965 * 1.3636 + deltaprice, ModPlate)
        Me.ReplaceCaratWeight(0.4, ModPlate, title, extra, ebaytitle, cs_desc, ss_desc, stone_extended, note)
        oTmpPlateLogics.insert(ModPlate)

        ''9
        Me.SetPrice(price * 1.308615 * 1.3636 + deltaprice, ModPlate)
        Me.ReplaceCaratWeight(0.45, ModPlate, title, extra, ebaytitle, cs_desc, ss_desc, stone_extended, note)
        oTmpPlateLogics.insert(ModPlate)


        ''10
        Me.SetPrice(price * 1.4133042 * 1.3636 + deltaprice, ModPlate)
        Me.ReplaceCaratWeight(0.5, ModPlate, title, extra, ebaytitle, cs_desc, ss_desc, stone_extended, note)
        oTmpPlateLogics.insert(ModPlate)

        ''11
        Me.SetPrice(price * 1.55463462 * 1.3636 + deltaprice, ModPlate)
        Me.ReplaceCaratWeight(0.55, ModPlate, title, extra, ebaytitle, cs_desc, ss_desc, stone_extended, note)
        oTmpPlateLogics.insert(ModPlate)

        Me.UpdateIsPartOf(itemid)

    End Function
    Private Sub btn_go_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_go.Click
        If Not Me.chk_nocschange.Checked Then
            If Me.txt_yellowgold.Text <> "" Then
                Me.YellowGold()
            End If
            If Me.txt_whitegold.Text <> "" Then
                Me.WhiteGold()
            End If
            If Me.txt_platinum.Text <> "" Then

                Me.Platinum()
            End If
            If Me.txt_rose.Text <> "" Then
                Me.RoseGold()
            End If
        Else
            If Me.txt_yellowgold.Text <> "" Then
                Me.YellowGold_NoStoneChange()
            End If
            If Me.txt_whitegold.Text <> "" Then
                Me.WhiteGold_NoStoneChange()
            End If
            If Me.txt_platinum.Text <> "" Then

                Me.Platinum_NoStoneChange()
            End If
            If Me.txt_rose.Text <> "" Then
                Me.RoseGold_NoStoneChange()
            End If
        End If

    End Sub

    Function SetPrice(ByVal price As Decimal, ByRef oplate As ion_two.skl_inventory)

        Dim nPurchasePrice As Decimal = price / 100
        oplate._purchase_price = price
        oplate._sell_price = nPurchasePrice * Application("defaults").inv_sellprice
        oplate._dealer_price = oplate._sell_price * 0.8
        oplate._appraisal_price = nPurchasePrice * Application("defaults").inv_appraisalprice
        oplate._special_sell_price = nPurchasePrice * Application("defaults").inv_spc_sellprice
        oplate._special_dealer_price = nPurchasePrice * Application("defaults").inv_spc_dealerprice

    End Function

    Function ReplaceColorClarity(ByVal color As String, ByVal clarity As String, ByRef oplate As ion_two.skl_inventory, ByVal title As String, ByVal cs_desc As String, ByVal ss_desc As String, ByVal ebaytitle As String, ByVal extended As String)


        oplate._subplate.jewel_title = title.Replace("I/SI2", color + "/" + clarity)

        If ebaytitle <> "" Then
            oplate.opthash("ebaytitle") = ebaytitle.Replace("I/SI2", color + "/" + clarity)
        End If


        If Me.chk_nocschange.Checked = False Then
            ''  oplate._subplate._stone_extended = extra.Replace("I/SI2", color + "/" + clarity)
            oplate._subplate._jewel_extended.ss_desc = ss_desc.Replace("I/SI2", color + "/" + clarity)
            oplate._subplate._jewel_extended.cs_desc = cs_desc.Replace("I/SI2", color + "/" + clarity)
            ''   oplate._subplate.jewel_extended = extended.Replace("::I|", "::" + color + "|")
            oplate._subplate._jewel_extended.color = color
            oplate._subplate._jewel_extended.clarity = clarity


            ''    oplate._subplate.jewel_extended = extended.Replace("::SI2|", "::" + clarity + "|")

        Else
            oplate._subplate._jewel_extended.ss_desc = ss_desc.Replace("I/SI2", color + "/" + clarity)
            oplate._subplate._jewel_extended.ss_color = color
            oplate._subplate._jewel_extended.ss_clarity = clarity


            '' oplate._subplate._stone_extended = extra.Replace("I/SI2", color + "/" + clarity)
            'Dim oextra As New ion_two.cls_jewerly_extra

            'oextra.get_stone_extended_string(extra)

            ''oplate._subplate._stone_extended = extra.Replace(oPlateSkelet._subplate._jewel_extended.ss_desc, oPlateSkelet._subplate._jewel_extended.ss_desc.Replace("I/SI2", color + "/" + clarity))


        End If

        '' Dim clarity2 As String
        ''  Dim color2 As String

        '' If Regex.Matches(d_title.Text, "\s(\w{1})/(\w{1,4})\s").Count > 0 Then
        ''clarity = Regex.Match(d_title.Text, "\s(\w{1})/(\w{1,4})\s").Groups(1).Value
        '' color = Regex.Match(d_title.Text, "\s(\w{1})/(\w{1,4})\s").Groups(2).Value
        ''   End If


    End Function

    Function ReplaceCaratWeight(ByVal caratadd As Decimal, ByRef oplate As ion_two.skl_inventory, ByVal title As String, ByVal extra As String, ByVal ebaytitle As String, ByVal cs_desc As String, ByVal ss_desc As String, ByVal stone_extended As String, ByVal note As String)

        Dim carat_weight_cs As String
        Dim carat_weight_ss As String

        If Regex.Matches(cs_desc, "\d{1,3}\.?\d{1,3}?(?=\sCt|\sCT)").Count > 0 Then
            carat_weight_cs = Regex.Matches(cs_desc, "\d{1,3}\.?\d{1,3}?(?=\sCt|\sCT)")(0).Value

        End If

        If Regex.Matches(ss_desc, "\d{1,3}\.?\d{1,3}?(?=\sCt|\sCT)").Count > 0 Then
            carat_weight_ss = Regex.Matches(ss_desc, "\d{1,3}\.?\d{1,3}?(?=\sCt|\sCT)")(0).Value

        End If

        Dim total_carat As Decimal = Convert.ToDecimal(caratadd) + Convert.ToDecimal(carat_weight_cs) + Convert.ToDecimal(carat_weight_ss)

        Dim total_carat_str As String = Format(total_carat, "####0.00")

        Dim old_total_carat As String = Regex.Matches(title, "\d{1,3}\.?\d{1,3}?(?=\sCt|\sCT)")(0).Value



        oplate._subplate.jewel_title = title.Replace(old_total_carat, total_carat_str)

        If ebaytitle <> "" Then
            oplate.opthash("ebaytitle") = ebaytitle.Replace(old_total_carat, total_carat_str)
        End If

        oplate._subplate._jewel_extended.cs_desc = cs_desc.Replace(carat_weight_cs, Format(carat_weight_cs + caratadd, "####0.00"))
        ''   oplate._subplate._stone_extended = stone_extended.Replace(carat_weight_ss, Format(carat_weight_ss + 0.5, "####00.00"))

        oplate._subplate._jewel_extended.total_weight = total_carat
        oplate._subplate._jewel_extended.cs_weight = carat_weight_cs + caratadd
        oplate._subplate._jewel_extended.ss_weight = carat_weight_ss


        oplate._notes = note.Replace(old_total_carat, total_carat_str)




        '' Dim cs_extended_string = oplate._subplate._stone_extended.split("|")(0)

        ''  regex.Replace(cs_extended_string,"\d{1,3}\.?\d{1,3}?(?=\sCt|\sCT)","




        'oplate._subplate._stone_extended = extra.Replace("I/SI2", Color + "/" + clarity)

        ''oplate._subplate._jewel_extended = 


    End Function


    Private Sub btn_go2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_go2.Click
        If Me.txt_yellowgold_gem_1.Text <> "" Then
            Me.YellowGold_Gem_Type1()
        End If
        If Me.txt_whitegold_gem_1.Text <> "" Then
            Me.WhiteGold_Gem_Type1()
        End If
        If Me.txt_platinum_gem_1.Text <> "" Then

            Me.Platinum_Gem_Type1()
        End If
        If Me.txt_rosegold_gem_1.Text <> "" Then
            Me.RoseGold_Gem_Type1()
        End If

    End Sub

    Function UpdateIsPartOf(ByVal itemid As Int32)
        Dim osql As New iDac.cls_T_command

        osql._connection_string = Application("config").connection_string
        osql._dbtype = Application("config").connection_string_type

        osql._sqlstring = "update inv_jewel_extended set is_partof_model = 1 where inventory_id = " + itemid.ToString

        osql.transact_command()

    End Function

    Private Sub txt_whitegold_gem_1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_whitegold_gem_1.TextChanged
        If Me.txt_whitegold_gem_1.Text <> "" Then
            '' Dim oPlateSkelet As New ion_two.skl_inventory
            Dim bError As Boolean = False
            '--- Define logics and get the plate
            'Dim oTmpPlateLogics As New ion_two.cls_inventory_lgc
            'oTmpPlateLogics._connection_string = Application("config").connection_string
            'oTmpPlateLogics._dbtype = Application("config").connection_string_type

            Dim onumber As New ion_two.cls_itemnumber
            onumber._connection_string = Application("config").connection_string
            onumber._dbtype = Application("config").connection_string_type
            Dim itemid As Int32
            onumber.getid_fromnumber(Me.txt_whitegold_gem_1.Text, itemid, bError)

            Dim opictures As New ion_two.cls_pictures
            opictures.load("http://www.twin-diamonds.com", "https://www.twin-diamonds.com")


            Dim oTmpInventory As New ion_two.cls_inventory_lgc
            oTmpInventory._connection_string = Application("config").connection_string
            oTmpInventory._dbtype = Application("config").connection_string_type

            Dim oPlate As New ion_two.skl_lst_inventory
            oTmpInventory.load(itemid, oPlate, opictures)



            ''   oTmpPlateLogics.read(itemid, oPlateSkelet)

            Me.preview_img.ImageUrl = oPlate._picture_pic
        End If
    End Sub

    Private Sub picupdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles picupdate.Click


        If Me.txt_whitegold.Text <> "" Then
            '' Dim oPlateSkelet As New ion_two.skl_inventory
            Dim bError As Boolean = False
            '--- Define logics and get the plate
            'Dim oTmpPlateLogics As New ion_two.cls_inventory_lgc
            'oTmpPlateLogics._connection_string = Application("config").connection_string
            'oTmpPlateLogics._dbtype = Application("config").connection_string_type

            Dim onumber As New ion_two.cls_itemnumber
            onumber._connection_string = Application("config").connection_string
            onumber._dbtype = Application("config").connection_string_type
            Dim itemid As Int32
            onumber.getid_fromnumber(Me.txt_whitegold.Text, itemid, bError)

            Dim opictures As New ion_two.cls_pictures
            opictures.load("http://www.twin-diamonds.com", "https://www.twin-diamonds.com")


            Dim oTmpInventory As New ion_two.cls_inventory_lgc
            oTmpInventory._connection_string = Application("config").connection_string
            oTmpInventory._dbtype = Application("config").connection_string_type

            Dim oPlate As New ion_two.skl_lst_inventory
            oTmpInventory.load(itemid, oPlate, opictures)



            ''   oTmpPlateLogics.read(itemid, oPlateSkelet)

            Me.preview_img.ImageUrl = oPlate._icon_pic
        End If


        If Me.txt_whitegold.Text <> "" Then
            '' Dim oPlateSkelet As New ion_two.skl_inventory
            Dim bError As Boolean = False
            '--- Define logics and get the plate
            'Dim oTmpPlateLogics As New ion_two.cls_inventory_lgc
            'oTmpPlateLogics._connection_string = Application("config").connection_string
            'oTmpPlateLogics._dbtype = Application("config").connection_string_type

            Dim onumber As New ion_two.cls_itemnumber
            onumber._connection_string = Application("config").connection_string
            onumber._dbtype = Application("config").connection_string_type
            Dim itemid As Int32
            onumber.getid_fromnumber(Me.txt_yellowgold.Text, itemid, bError)

            Dim opictures As New ion_two.cls_pictures
            opictures.load("http://www.twin-diamonds.com", "https://www.twin-diamonds.com")


            Dim oTmpInventory As New ion_two.cls_inventory_lgc
            oTmpInventory._connection_string = Application("config").connection_string
            oTmpInventory._dbtype = Application("config").connection_string_type

            Dim oPlate As New ion_two.skl_lst_inventory
            oTmpInventory.load(itemid, oPlate, opictures)



            ''   oTmpPlateLogics.read(itemid, oPlateSkelet)

            Me.preview_img2.ImageUrl = oPlate._icon_pic
        End If


        If Me.txt_whitegold.Text <> "" Then
            '' Dim oPlateSkelet As New ion_two.skl_inventory
            Dim bError As Boolean = False
            '--- Define logics and get the plate
            'Dim oTmpPlateLogics As New ion_two.cls_inventory_lgc
            'oTmpPlateLogics._connection_string = Application("config").connection_string
            'oTmpPlateLogics._dbtype = Application("config").connection_string_type

            Dim onumber As New ion_two.cls_itemnumber
            onumber._connection_string = Application("config").connection_string
            onumber._dbtype = Application("config").connection_string_type
            Dim itemid As Int32
            onumber.getid_fromnumber(Me.txt_platinum.Text, itemid, bError)

            Dim opictures As New ion_two.cls_pictures
            opictures.load("http://www.twin-diamonds.com", "https://www.twin-diamonds.com")


            Dim oTmpInventory As New ion_two.cls_inventory_lgc
            oTmpInventory._connection_string = Application("config").connection_string
            oTmpInventory._dbtype = Application("config").connection_string_type

            Dim oPlate As New ion_two.skl_lst_inventory
            oTmpInventory.load(itemid, oPlate, opictures)



            ''   oTmpPlateLogics.read(itemid, oPlateSkelet)

            Me.preview_img3.ImageUrl = oPlate._icon_pic
        End If



        If Me.txt_whitegold.Text <> "" Then
            '' Dim oPlateSkelet As New ion_two.skl_inventory
            Dim bError As Boolean = False
            '--- Define logics and get the plate
            'Dim oTmpPlateLogics As New ion_two.cls_inventory_lgc
            'oTmpPlateLogics._connection_string = Application("config").connection_string
            'oTmpPlateLogics._dbtype = Application("config").connection_string_type

            Dim onumber As New ion_two.cls_itemnumber
            onumber._connection_string = Application("config").connection_string
            onumber._dbtype = Application("config").connection_string_type
            Dim itemid As Int32
            onumber.getid_fromnumber(Me.txt_rose.Text, itemid, bError)

            Dim opictures As New ion_two.cls_pictures
            opictures.load("http://www.twin-diamonds.com", "https://www.twin-diamonds.com")


            Dim oTmpInventory As New ion_two.cls_inventory_lgc
            oTmpInventory._connection_string = Application("config").connection_string
            oTmpInventory._dbtype = Application("config").connection_string_type

            Dim oPlate As New ion_two.skl_lst_inventory
            oTmpInventory.load(itemid, oPlate, opictures)



            ''   oTmpPlateLogics.read(itemid, oPlateSkelet)

            Me.preview_img4.ImageUrl = oPlate._icon_pic
        End If




    End Sub
End Class
