Imports System.Web.UI.WebControls
Public Class cls_dyn_scripts
    Public Function RedirectWithMsg(ByVal msg As String, ByVal url As String, ByRef lit As Literal, Optional ByVal time As String = "1500") As Boolean

        '' Dim lit As New Literal

        Dim functext As String

        functext = vbNewLine + "FancyMsgBox('" + msg + "'," + time + ",null,null,function() { RedirectToPage('" + url + "') } );" + vbNewLine

        lit.Text += functext

    End Function
    ''Public Function FancyBox
    Public Function Txt2P(ByVal text As String, ByVal align As String)
        Return "<p align=\'" + align + "\'>" + text + "</p>"
    End Function
    Public Function WrapLitWithASPExec(ByRef lit As Literal)

        ''Dim tmplit As String = lit.Text
        lit.Text = "<script>function ASPExec() { " + lit.Text + " }</script>"

    End Function

    Public Function WrapLitWithControlScript(ByRef lit As Literal)

        ''Dim tmplit As String = lit.Text
        lit.Text = "<script>function ControlASPExec() {" + lit.Text + " }</script>"

    End Function

    Public Function FancyBox(ByVal msg As String, ByRef lit As Literal, Optional ByVal time As String = "1500") As Boolean

        '' Dim lit As New Literal

        Dim functext As String

        functext = vbNewLine + "FancyMsgBox('" + msg + "'," + time + ",null,null,null );" + vbNewLine

        lit.Text += functext

    End Function
End Class
