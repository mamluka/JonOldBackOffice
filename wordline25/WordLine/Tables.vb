Public Class Tables
    Private dm0 As WordLine.StrArr = New WordLine.StrArr(14)
    Private jw0 As WordLine.StrArr = New WordLine.StrArr(30)
    Private gm0 As WordLine.StrArr = New WordLine.StrArr(24)
    Private dmp As WordLine.StrArr = New WordLine.StrArr(2)
    Private jwp As WordLine.StrArr = New WordLine.StrArr(2)
    Private gmp As WordLine.StrArr = New WordLine.StrArr(2)
    Private word(2, 300) As String

    Private Sub tblword()
        ''''''''''
        word(0, 0) = "Africa"
        word(0, 1) = "Alexandrite"
        word(0, 2) = "Amethyst"
        word(0, 3) = "And"
        word(0, 4) = "Antique"
        word(0, 5) = "Any"
        word(0, 6) = "Aquamarine"
        word(0, 7) = "Asscher"
        word(0, 8) = "Australia"
        word(0, 9) = "Baguettet"
        word(0, 10) = "Band"
        word(0, 11) = "Bangle"
        word(0, 12) = "Battambang"
        word(0, 13) = "between"
        word(0, 14) = "Bergl"
        word(0, 15) = "Black"
        word(0, 16) = "blood"
        word(0, 17) = "blue"
        word(0, 18) = "Blueish"
        word(0, 19) = "Bracelet"
        word(0, 20) = "Brazil"
        word(0, 21) = "Broach"
        word(0, 22) = "Brown"
        word(0, 23) = "Brownish"
        word(0, 24) = "BUCHARI"
        word(0, 25) = "Burma"
        word(0, 26) = "Butterfly"
        word(0, 27) = "Cable"
        word(0, 28) = "Cabochon"
        word(0, 29) = "Cambodia"
        word(0, 30) = "Cartier"
        word(0, 31) = "Ceylon"
        word(0, 32) = "Champagne"
        word(0, 33) = "Chanell"
        word(0, 34) = "Chantabun"
        word(0, 35) = "Chanta-Buri"
        word(0, 36) = "change"
        word(0, 37) = "Chrysoberyl"
        word(0, 38) = "Citrine"
        word(0, 39) = "Cognac"
        word(0, 40) = "Colombia"
        word(0, 41) = "Color"
        word(0, 42) = "ColorLess"
        word(0, 43) = "Coscuez"
        word(0, 44) = "Cuff"
        word(0, 45) = "Cushion"
        word(0, 46) = "Custom"
        word(0, 47) = "Cut"
        word(0, 48) = "darkish"
        word(0, 49) = "Deep"
        word(0, 50) = "Design"
        word(0, 51) = "Diamond"
        word(0, 52) = "Diamonds"
        word(0, 53) = "Drop"
        word(0, 54) = "Earring"
        word(0, 55) = "Earrings"
        word(0, 56) = "Emaille"
        word(0, 57) = "Emerald"
        word(0, 58) = "Emeralds"
        word(0, 59) = "Enhanced"
        word(0, 60) = "Excellent"
        word(0, 61) = "Extra"
        word(0, 62) = "Extrimly"
        word(0, 63) = "Faceted"
        word(0, 64) = "Faint"
        word(0, 65) = "Fair"
        word(0, 66) = "Fancy"
        word(0, 67) = "Fantasy"
        word(0, 68) = "Fashion"
        word(0, 69) = "Fine"
        word(1, 69) = "finest"
        word(0, 70) = "finest"
        word(0, 71) = "Free"
        word(0, 72) = "Garnet"
        word(0, 73) = "Glass"
        word(0, 74) = "Gold"
        word(0, 75) = "Golden"
        word(0, 76) = "Good"
        word(0, 77) = "Grass"
        word(0, 78) = "Grayish"
        word(0, 79) = "green"
        word(0, 80) = "Greenish"
        word(0, 81) = "Half"
        word(0, 82) = "Hand"
        word(0, 83) = "Head"
        word(0, 84) = "Heart"
        word(0, 85) = "High"
        word(0, 86) = "Hoop"
        word(0, 87) = "Horse"
        word(0, 88) = "In"
        word(0, 89) = "India"
        word(0, 90) = "Intense"
        word(0, 91) = "Jewelry"
        word(0, 92) = "Kanchna-Buri"
        word(0, 93) = "Karat"
        word(0, 94) = "Kashmir"
        word(0, 95) = "Kunzite"
        word(0, 96) = "Large"
        word(0, 97) = "Lauran"
        word(0, 98) = "Lemon"
        word(0, 99) = "Light"
        word(0, 100) = "line"
        word(0, 101) = "Link"
        word(0, 102) = "Loaf"
        word(0, 103) = "Made"
        word(0, 104) = "Madagascar"
        word(0, 105) = "Marquise"
        word(0, 106) = "Medium"
        word(0, 107) = "Minus"
        word(0, 108) = "Misc."
        word(0, 109) = "Mix"
        word(0, 110) = "Mogok"
        word(0, 111) = "Mong-Hsu"
        word(0, 112) = "Moon"
        word(0, 113) = "Most"
        word(0, 114) = "Mountings"
        word(0, 115) = "Multi"
        word(0, 116) = "Muzo"
        word(0, 117) = "Namibia"
        word(0, 118) = "Navy"
        word(0, 119) = "Necklace"
        word(0, 120) = "None"
        word(0, 121) = "of"
        word(0, 122) = "Oil"
        word(0, 123) = "Olive"
        word(0, 124) = "Omega"
        word(0, 125) = "Opal"
        word(0, 126) = "Orange"
        word(0, 127) = "Orangy"
        word(0, 128) = "Original"
        word(0, 129) = "Oval"
        word(0, 130) = "Pear"
        word(0, 131) = "Pendant"
        word(0, 132) = "Peridot"
        word(0, 133) = "Phailin"
        word(0, 134) = "Pigeon"
        word(0, 135) = "Pink"
        word(0, 136) = "Pinkish"
        word(0, 137) = "Platinum"
        word(0, 138) = "Polished"
        word(0, 139) = "Poor"
        word(0, 140) = "Precious"
        word(0, 141) = "Princess"
        word(0, 142) = "Purple"
        word(0, 143) = "Purplish"
        word(0, 144) = "Radiant"
        word(0, 145) = "Red"
        word(0, 146) = "Rhodesia"
        word(0, 147) = "Ring"
        word(0, 148) = "Rough"
        word(0, 149) = "Round"
        word(0, 150) = "Royal"
        word(0, 151) = "Rubies"
        word(0, 152) = "Rubilite"
        word(0, 153) = "Ruby"
        word(0, 154) = "Russia"
        word(0, 155) = "Saint"
        word(0, 156) = "Sapphire"
        word(0, 157) = "Sapphires"
        word(0, 158) = "Semi"
        word(0, 159) = "Setting"
        word(0, 160) = "shape"
        word(0, 161) = "Shield"
        word(0, 162) = "Siam"
        word(0, 163) = "Sky"
        word(0, 164) = "Slightly"
        word(0, 165) = "Small"
        word(0, 166) = "Solitaire"
        word(0, 167) = "Spinel"
        word(0, 168) = "Square"
        word(0, 169) = "Sri Lanka"
        word(0, 170) = "Strong"
        word(0, 171) = "Stone"
        word(0, 172) = "Stud"
        word(0, 173) = "Sugar"
        word(0, 174) = "Tanzania"
        word(0, 175) = "Tanzanite"
        word(0, 176) = "Taper"
        word(0, 177) = "Tennis"
        word(0, 178) = "Thailand"
        word(0, 179) = "the"
        word(0, 180) = "Thermally"
        word(0, 181) = "thick"
        word(0, 182) = "Thin"
        word(0, 183) = "Three"
        word(0, 184) = "TL"
        word(0, 185) = "Top"
        word(0, 186) = "Topaz"
        word(0, 187) = "Tourmaline"
        word(0, 188) = "Trapeze"
        word(0, 189) = "Trapezoids"
        word(0, 190) = "treatment"
        word(0, 191) = "Triangle"
        word(0, 192) = "Trillian"
        word(0, 193) = "Trillion"
        word(0, 194) = "Tsavorite"
        word(0, 195) = "Turquoise"
        word(0, 196) = "Twin"
        word(0, 197) = "Yellow"
        word(0, 198) = "Yellowish"
        word(0, 199) = "Very"
        word(0, 200) = "Watch"
        word(0, 201) = "White"
        word(0, 202) = "White/Yellow"
        word(0, 203) = "Ural"
        word(0, 204) = "Yves"
        word(0, 205) = "Zambia"
        word(0, 206) = "Zanskar"
        word(0, 207) = "Gem"
        word(0, 208) = "D"
        word(0, 209) = "E"
        word(0, 210) = "F"
        word(0, 211) = "G"
        word(0, 212) = "H"
        word(0, 213) = "I"
        word(0, 214) = "J"
        word(0, 215) = "K"
        word(0, 216) = "L"
        word(0, 217) = "M"
        word(0, 218) = "N"
        word(0, 219) = "IF"
        word(0, 220) = "VVS1"
        word(0, 221) = "VVS2"
        word(0, 222) = "VS1"
        word(0, 223) = "VS2"
        word(0, 224) = "SI1"
        word(0, 225) = "SI2"
        word(0, 226) = "SI3"
        word(0, 227) = "I1"
        word(0, 228) = "I2"
        word(0, 229) = "I3"
        word(0, 230) = "Reject"
        word(0, 231) = "weight"
        word(0, 232) = "from"
        word(0, 233) = "to"
        word(0, 234) = "ct."
        word(0, 235) = "less"
        word(0, 236) = "more"
        word(0, 237) = "than"
        word(0, 238) = "gemstone"
        ''''''''''''''
        gm0.ar.SetValue("Ruby", 0)
        gm0.ar.SetValue("Sapphire", 1)
        gm0.ar.SetValue("Emerald", 2)
        gm0.ar.SetValue("Alexandrite", 3)
        gm0.ar.SetValue("Garnet", 4)
        gm0.ar.SetValue("Aquamarine", 5)
        gm0.ar.SetValue("Citrine", 6)
        gm0.ar.SetValue("Spinel", 7)
        gm0.ar.SetValue("Tanzanite", 8)
        gm0.ar.SetValue("Topaz", 9)
        gm0.ar.SetValue("Tourmaline", 10)
        gm0.ar.SetValue("Tsavorite", 11)
        gm0.ar.SetValue("Turquoise", 12)
        gm0.ar.SetValue("Opal", 13)
        gm0.ar.SetValue("Kunzite", 14)
        gm0.ar.SetValue("Rubilite", 15)
        gm0.ar.SetValue("Amethyst", 16)
        gm0.ar.SetValue("Peridot", 17)
        gm0.ar.SetValue("Chrysoberyl", 18)
        gm0.ar.SetValue("Garnet", 19)
        gm0.ar.SetValue("Emaille", 20)
        gm0.ar.SetValue("Bergl", 21)
        gm0.ar.SetValue("Stone", 22)
        gm0.ar.SetValue("Gemstone", 23)
        '''''
        gmp.ar.SetValue("", 0)
        gmp.ar.SetValue("", 1)
        ''''''''''''''
        jw0.ar.SetValue("Ring", 0)
        jw0.ar.SetValue("Earrings", 1)
        jw0.ar.SetValue("Necklace", 2)
        jw0.ar.SetValue("Broach", 3)
        jw0.ar.SetValue("Pendant", 4)
        jw0.ar.SetValue("Watch", 5)
        jw0.ar.SetValue("Bracelet", 6)
        jw0.ar.SetValue("Custom", 7)
        jw0.ar.SetValue("Setting", 8)
        jw0.ar.SetValue("Solitaire", 9)
        jw0.ar.SetValue("Antique", 10)
        jw0.ar.SetValue("Three Stone", 11)
        jw0.ar.SetValue("Band", 12)
        jw0.ar.SetValue("Hoop", 13)
        jw0.ar.SetValue("Stud", 14)
        jw0.ar.SetValue("Drop", 15)
        jw0.ar.SetValue("Fashion", 16)
        jw0.ar.SetValue("Omega", 17)
        jw0.ar.SetValue("Drop", 18)
        jw0.ar.SetValue("Heart", 19)
        jw0.ar.SetValue("Cable", 20)
        jw0.ar.SetValue("Cuff", 21)
        jw0.ar.SetValue("Link", 22)
        jw0.ar.SetValue("Bangle", 23)
        jw0.ar.SetValue("Tennis", 24)
        jw0.ar.SetValue("Multi Stone", 25)
        jw0.ar.SetValue("Mountings", 26)
        jw0.ar.SetValue("Gold", 27)
        jw0.ar.SetValue("Jwelry", 28)
        jw0.ar.SetValue("Present", 29)
        '''''
        jwp.ar.SetValue("", 0)
        jwp.ar.SetValue("", 1)
        ''''''''''''''''''
        dm0.ar.SetValue("F", 0)
        dm0.ar.SetValue("IF", 1)
        dm0.ar.SetValue("VVS1", 2)
        dm0.ar.SetValue("VVS2", 3)
        dm0.ar.SetValue("VS1", 4)
        dm0.ar.SetValue("VS2", 5)
        dm0.ar.SetValue("SI1", 6)
        dm0.ar.SetValue("SI2", 7)
        dm0.ar.SetValue("SI3", 8)
        dm0.ar.SetValue("I1", 9)
        dm0.ar.SetValue("I2", 10)
        dm0.ar.SetValue("I3", 11)
        dm0.ar.SetValue("Reject", 12)
        dm0.ar.SetValue("Diamond", 13)
        '''''
        dmp.ar.SetValue("", 0)
        dmp.ar.SetValue("", 1)


    End Sub

    Public Function conworda(ByVal data As String) As String
        Dim i, j As Integer
        Dim proma As String
        '
        conworda = ""
        For i = 0 To 250
            For j = 0 To 0
                If StrComp(data, word(j, i), CompareMethod.Text) = 0 Then
                    Return word(0, i)
                End If
            Next j
        Next i
        '
    End Function

    Private Function contab(ByRef data As String) As String
        Dim i, j As Integer
        Dim proma As String
        '
        contab = ""
        '
        For i = 0 To jw0.ar.Length - 1
            If StrComp(data, jw0.ar.GetValue(i), CompareMethod.Text) = 0 Then
                Return "jewel"
            End If
        Next i
        '
        For i = 0 To dm0.ar.Length - 1
            If StrComp(data, dm0.ar.GetValue(i), CompareMethod.Text) = 0 Then
                Return "diam"
            End If
        Next i
        '
        For i = 0 To gm0.ar.Length - 1
            If StrComp(data, gm0.ar.GetValue(i), CompareMethod.Text) = 0 Then
                Return "gem"
            End If
        Next i
        ''''''''''''''
        '
        For i = 0 To jwp.ar.Length - 1
            If StrComp(data, jw0.ar.GetValue(i), CompareMethod.Text) = 0 Then
                data = ""
                Return "jewel"
            End If
        Next i
        '
        For i = 0 To dmp.ar.Length - 1
            If StrComp(data, dm0.ar.GetValue(i), CompareMethod.Text) = 0 Then
                data = ""
                Return "diam"
            End If
        Next i
        '
        For i = 0 To gmp.ar.Length - 1
            If StrComp(data, gm0.ar.GetValue(i), CompareMethod.Text) = 0 Then
                data = ""
                Return "gem"
            End If
        Next i
        '
    End Function

    Public Sub cntb(ByVal data As String, ByRef fp As String)
        Dim pri As String
        '
        If fp <> "jewel" Then
            pri = Me.contab(data)
            If pri = "jewel" Or Len(fp) = 0 Then
                fp = pri
            End If
        End If
        '
    End Sub

    Public Sub New()
        Me.tblword()
    End Sub

    Protected Overrides Sub Finalize()
        dm0 = Nothing
        gm0 = Nothing
        jw0 = Nothing
        dmp = Nothing
        gmp = Nothing
        jwp = Nothing
        MyBase.Finalize()
    End Sub

End Class
