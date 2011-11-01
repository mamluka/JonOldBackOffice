Public Class cls_rate
    Inherits iFoundation.cls_logics_sub
    Public Class metal_prices
        Public platinum As Decimal
        Public YG9 As Decimal
        Public YG14 As Decimal
        Public YG18 As Decimal
        Public YG22 As Decimal
        Public WG9 As Decimal
        Public WG14 As Decimal
        Public WG18 As Decimal
        Public WG22 As Decimal
        Public WYG9 As Decimal
        Public WYG14 As Decimal
        Public WYG18 As Decimal
        Public WYG22 As Decimal



        Sub New()
            platinum = 0
            YG9 = 0
            YG14 = 0
            YG18 = 0
            YG22 = 0
            WG9 = 0
            WG14 = 0
            WG18 = 0
            WG22 = 0
            WYG9 = 0
            WYG14 = 0
            WYG18 = 0
            WYG22 = 0
        End Sub
    End Class
    Public Function get_metal_rate(ByVal type As String) As Int32
        Select Case type
            Case "Platinum"
                Return 40
            Case "Yellow Gold 9 Karat"
                Return 10
            Case "Yellow Gold 14 Karat"
                Return 14
            Case "Yellow Gold 18 Karat"
                Return 20
            Case "Yellow Gold 22 Karat"
                Return 20
            Case "White Gold 9 Karat"
                Return 10
            Case "White Gold 14 Karat"
                Return 14
            Case "White Gold 18 Karat"
                Return 20
            Case "White Gold 22 Karat"
                Return 20
            Case "White/Yellow Gold 9 Karat"
                Return 10
            Case "White/Yellow Gold 14 Karat"
                Return 14
            Case "White/Yellow Gold 18 Karat"
                Return 20
            Case "White/Yellow Gold 22 Karat"
                Return 20
        End Select
        ''def
        Return 20

    End Function
End Class
