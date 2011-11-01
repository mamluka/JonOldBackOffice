Partial Class additem
    Inherits System.Web.UI.Page




#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()

        Dim bError As Boolean = False

        bError = fill_cmb_plate()

        Dim oFillcombo As cls_datareader
        oFillcombo = New cls_datareader()

        oFillcombo.config = Application("config")

        oFillcombo.combobox = Me.cmb_branch
        oFillcombo.sqlstring = "select id, branch from sys_BRANCH where active = 1 order by sortorder"
        oFillcombo.showfield = "branch"
        bError = oFillcombo.bind_combo()

        oFillcombo = Nothing

    End Sub

#End Region

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Put user code to initialize the page here
        '--- Set culture of form
        System.Threading.Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.CreateSpecificCulture(Request.UserLanguages(0))
        System.Threading.Thread.CurrentThread.CurrentUICulture = New System.Globalization.CultureInfo(Request.UserLanguages(0))



        'If Not Page.IsPostBack Then
        '--- Show selection buttons
        cmb_branch.Enabled = True
        cmb_platetype.Enabled = True
        btn_select.Enabled = True

        '--- Show plate
        Me.tbl_plate.Visible = True

        'End If

    End Sub

    Private Sub btn_select_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_select.Click

        '--- mode 1= ADD 2=EDIT
        If Me.cmb_platetype.SelectedItem.Value > 0 Then

            '--- Make selection bar disabled
            cmb_branch.Enabled = False
            cmb_platetype.Enabled = False
            btn_select.Enabled = False

            '--- Activate Plate
            Me.tbl_plate.Visible = True

            'Me.tbl_plate.Visible = True
            Server.Transfer("additem.aspx?mode=1&plate=" & Me.cmb_platetype.SelectedItem.Value & "&branch=" & Me.cmb_branch.SelectedItem.Value)

        End If

    End Sub

    Private Function fill_cmb_plate() As Boolean

        Me.cmb_platetype.Items.Add("Please select")
        Me.cmb_platetype.Items(0).Value = 0

        Me.cmb_platetype.Items.Add("Diamond")
        Me.cmb_platetype.Items(1).Value = 1

        Me.cmb_platetype.Items.Add("Gem stones")
        Me.cmb_platetype.Items(2).Value = 2

        Me.cmb_platetype.Items.Add("Jewelry")
        Me.cmb_platetype.Items(3).Value = 3

    End Function

End Class


