Imports System.Xml
Partial Class combo
    Inherits System.Web.UI.UserControl

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
    Function Start(ByVal opt As Hashtable)
        Me.intlabel.Text = opt("title")

        If opt("loadtype") = 1 Then
            Me.LoadComboDB(opt)
        ElseIf opt("loadtype") = 2 Then
            Me.LoadComboXML(opt)

        End If

    End Function
    Function AddItem(ByVal text As String, ByVal value As String, Optional ByVal index As Int32 = -1)
        If index = -1 Then
            If value = "last" Then
                Me.intcombo.Items.Add(New WebControls.ListItem(text, Me.intcombo.Items.Count.ToString))
            Else
                Me.intcombo.Items.Add(New WebControls.ListItem(text, value))
            End If

        Else
            Me.intcombo.Items.Insert(index, New WebControls.ListItem(text, value))
        End If

    End Function
    Function ReplaceItem(ByVal text As String, ByVal value As String, ByVal index As Int32)
        Me.intcombo.Items(index).Value = value
        Me.intcombo.Items(index).Text = text

    End Function

    Function LoadComboDB(ByVal opt As Hashtable)

        Dim oFillcombo As New cls_datareader
        Dim oError As New cls_error
        oFillcombo.config = Application("config")

        oFillcombo.combobox = Me.intcombo
        oFillcombo.sqlstring = "select id, lang" & Session("user").language & "_longdescr from " + opt("table") + " order by sortorder"
        oFillcombo.showfield = "lang" & Session("user").language & "_longdescr"
        oFillcombo.fill_combo()

        'oFillcombo.combobox = Me.intcombo
        'oFillcombo.sqlstring = "select id, lang" & Session("user").language & "_longdescr from " + opt("table") + " order by sortorder"
        'oFillcombo.showfield = "lang" & Session("user").language & "_longdescr"
        'oFillcombo.bind_combo()

    End Function
    Function LoadComboXML(ByVal opt As Hashtable)
        Dim oxml As New ion_two.cls_nd_xmlread
        oxml.xml_file = Server.MapPath(opt("xmlfile"))
        oxml.Load()
        Dim items As XmlNodeList = oxml.GetNodes_ByPath("combo[@id='" + opt("comboid") + "']/item")
        Dim i As Int32 = 0
        For Each item As XmlNode In items

            Me.intcombo.Items.Add(New WebControls.ListItem(item.InnerText, item.Attributes("val").InnerText))
            If Not IsNothing(item.Attributes("default")) Then

                Me.intcombo.SelectedIndex = i
            End If
            i += 1

        Next

    End Function

End Class
