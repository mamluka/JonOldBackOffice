Public Class StrArr
    Private par As System.Array

    Public Sub New()

    End Sub

    Public Sub New(ByVal n As Integer)
        par = Array.CreateInstance(GetType(String), n)
    End Sub

    Public Sub New(ByVal stp As System.Type, _
                   ByVal n As Integer)
        par = Array.CreateInstance(stp, n)
    End Sub

    Public Property ar() As System.Array
        Get
            Return par
        End Get
        Set(ByVal Value As System.Array)
            par = Value
        End Set
    End Property

    Public Sub Clear()
        par.Clear(par, 0, par.Length)
    End Sub

    Public Sub Copy(ByVal value As System.Array)
        par = value.Clone
    End Sub

    Public Sub Copy11(ByVal value As System.Array)
        Dim i As Integer
        For i = 0 To value.Length - 1
            par.SetValue(value.GetValue(i), i)
        Next
    End Sub

    Protected Overrides Sub Finalize()
        par = Nothing
        MyBase.Finalize()
    End Sub

End Class
