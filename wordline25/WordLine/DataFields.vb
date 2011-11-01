Public Class DataFields
    Private view As WordLine.StrArr = New WordLine.StrArr(3)
    Private color_gem As WordLine.StrArr = New WordLine.StrArr(68)
    Private color_diam As WordLine.StrArr = New WordLine.StrArr(35)
    Private jeweltype_jewel As WordLine.StrArr = New WordLine.StrArr(11)
    Private jewelsubtype_jewel As WordLine.StrArr = New WordLine.StrArr(30)
    Private metal_jewel As WordLine.StrArr = New WordLine.StrArr(15)
    Private origin_gem As WordLine.StrArr = New WordLine.StrArr(27)
    Private shape_diam As WordLine.StrArr = New WordLine.StrArr(30)
    Private shape_gem As WordLine.StrArr = New WordLine.StrArr(27)
    Private stonetype_diam As WordLine.StrArr = New WordLine.StrArr(3)
    Private stonetype_gem As WordLine.StrArr = New WordLine.StrArr(26)
    Private clarity_diam As WordLine.StrArr = New WordLine.StrArr(21)
    Private weight As WordLine.StrArr = New WordLine.StrArr(3)
        '
    Private color_gem_base As WordLine.StrArr = New WordLine.StrArr(14)
    Private color_diam_base As WordLine.StrArr = New WordLine.StrArr(8)
    Private jeweltype_jewel_base As WordLine.StrArr = New WordLine.StrArr(9)
    Private jewelsubtype_jewel_base As WordLine.StrArr = New WordLine.StrArr(23)
    Private metal_jewel_base As WordLine.StrArr = New WordLine.StrArr(2)
    Private origin_gem_base As WordLine.StrArr = New WordLine.StrArr(25)
    Private shape_diam_base As WordLine.StrArr = New WordLine.StrArr(26)
    Private shape_gem_base As WordLine.StrArr = New WordLine.StrArr(22)
    Private stonetype_diam_base As WordLine.StrArr = New WordLine.StrArr(1)
    Private stonetype_gem_base As WordLine.StrArr = New WordLine.StrArr(22)
    Private clarity_diam_base As WordLine.StrArr = New WordLine.StrArr(13)
    Private weight_base As WordLine.StrArr = New WordLine.StrArr(6)

    Public ReadOnly Property views() As WordLine.StrArr
        Get
            Return view
        End Get
    End Property

    Public ReadOnly Property colors_gem() As WordLine.StrArr
        Get
            Return color_gem
        End Get
    End Property

    Public ReadOnly Property colors_gem_base() As WordLine.StrArr
        Get
            Return color_gem_base
        End Get
    End Property

    Public ReadOnly Property colors_diam() As WordLine.StrArr
        Get
            Return color_diam
        End Get
    End Property

    Public ReadOnly Property colors_diam_base() As WordLine.StrArr
        Get
            Return color_diam_base
        End Get
    End Property

    Public ReadOnly Property jeweltype_jewels() As WordLine.StrArr
        Get
            Return jeweltype_jewel
        End Get
    End Property

    Public ReadOnly Property jeweltype_jewels_base() As WordLine.StrArr
        Get
            Return jeweltype_jewel_base
        End Get
    End Property

    Public ReadOnly Property jewelsubtype_jewels() As WordLine.StrArr
        Get
            Return jewelsubtype_jewel
        End Get
    End Property

    Public ReadOnly Property jewelsubtype_jewels_base() As WordLine.StrArr
        Get
            Return jewelsubtype_jewel_base
        End Get
    End Property

    Public ReadOnly Property metal_jewels() As WordLine.StrArr
        Get
            Return metal_jewel
        End Get
    End Property

    Public ReadOnly Property metal_jewels_base() As WordLine.StrArr
        Get
            Return metal_jewel_base
        End Get
    End Property

    Public ReadOnly Property origin_gems() As WordLine.StrArr
        Get
            Return origin_gem
        End Get
    End Property

    Public ReadOnly Property origin_gems_base() As WordLine.StrArr
        Get
            Return origin_gem_base
        End Get
    End Property

    Public ReadOnly Property shape_diams() As WordLine.StrArr
        Get
            Return shape_diam
        End Get
    End Property

    Public ReadOnly Property shape_diams_base() As WordLine.StrArr
        Get
            Return shape_diam_base
        End Get
    End Property

    Public ReadOnly Property shape_gems() As WordLine.StrArr
        Get
            Return shape_gem
        End Get
    End Property

    Public ReadOnly Property shape_gems_base() As WordLine.StrArr
        Get
            Return shape_gem_base
        End Get
    End Property

    Public ReadOnly Property stonetype_diams() As WordLine.StrArr
        Get
            Return stonetype_diam
        End Get
    End Property

    Public ReadOnly Property stonetype_diams_base() As WordLine.StrArr
        Get
            Return stonetype_diam_base
        End Get
    End Property

    Public ReadOnly Property stonetype_gems() As WordLine.StrArr
        Get
            Return stonetype_gem
        End Get
    End Property

    Public ReadOnly Property stonetype_gems_base() As WordLine.StrArr
        Get
            Return stonetype_gem_base
        End Get
    End Property

    Public ReadOnly Property clarity_diams() As WordLine.StrArr
        Get
            Return clarity_diam
        End Get
    End Property

    Public ReadOnly Property clarity_diams_base() As WordLine.StrArr
        Get
            Return clarity_diam_base
        End Get
    End Property

    Public ReadOnly Property weights() As WordLine.StrArr
        Get
            Return weight
        End Get
    End Property

    Public ReadOnly Property weights_base() As WordLine.StrArr
        Get
            Return weight_base
        End Get
    End Property

    Private Sub bstr()
        '
        views.ar.SetValue("diamview", 2)
        views.ar.SetValue("gemview", 1)
        views.ar.SetValue("jewview", 0)
        '    [inv_COLOR_GEM]
        '       fildsname = "LANG1_SHORTDESCR"
        color_gem.ar.SetValue("", 0)
        color_gem.ar.SetValue("-", 1)
        color_gem.ar.SetValue("Most finest Royal blue", 2)
        color_gem.ar.SetValue("Most finest Navy blue", 3)
        color_gem.ar.SetValue("Extra Fine Royal blue", 4)
        color_gem.ar.SetValue("Extra Fine Navy blue", 5)
        color_gem.ar.SetValue("Fine Royal blue", 6)
        color_gem.ar.SetValue("Fine Navy blue", 7)
        color_gem.ar.SetValue("Top Royal blue", 8)
        color_gem.ar.SetValue("Royal blue", 9)
        color_gem.ar.SetValue("Navy blue", 10)
        color_gem.ar.SetValue("Medium Royal blue", 11)
        color_gem.ar.SetValue("Medium Navy blue", 12)
        color_gem.ar.SetValue("Most finest Lemon Yellow", 13)
        color_gem.ar.SetValue("Most finest Golden Yellow", 14)
        color_gem.ar.SetValue("Extra Fine Lemon Yellow", 15)
        color_gem.ar.SetValue("Extra Fine Golden Yellow", 16)
        color_gem.ar.SetValue("Fine Lemon Yellow", 17)
        color_gem.ar.SetValue("Fine Golden Yellow", 18)
        color_gem.ar.SetValue("Top Lemon Yellow", 19)
        color_gem.ar.SetValue("Top Golden Yellow", 20)
        color_gem.ar.SetValue("Royal Lemon Yellow", 21)
        color_gem.ar.SetValue("Navy Golden Yellow", 22)
        color_gem.ar.SetValue("Medium Lemon Yellow", 23)
        color_gem.ar.SetValue("Medium Golden Yellow", 24)
        color_gem.ar.SetValue("Most finest Pink", 25)
        color_gem.ar.SetValue("Extra Fine Pink", 26)
        color_gem.ar.SetValue("Fine Pink", 27)
        color_gem.ar.SetValue("Top Pink", 28)
        color_gem.ar.SetValue("Pink", 29)
        color_gem.ar.SetValue("Most finest Pigeon blood Red", 30)
        color_gem.ar.SetValue("Most finest Red", 31)
        color_gem.ar.SetValue("Extra Fine Pigeon blood Red", 32)
        color_gem.ar.SetValue("Extra Fine Red", 33)
        color_gem.ar.SetValue("Fine Pigeon blood Red", 34)
        color_gem.ar.SetValue("Fine Red", 35)
        color_gem.ar.SetValue("Top Pigeon blood Red", 36)
        color_gem.ar.SetValue("Top Red", 37)
        color_gem.ar.SetValue("Pigeon blood Red", 38)
        color_gem.ar.SetValue("Red", 39)
        color_gem.ar.SetValue("Medium Pigeon blood Red", 40)
        color_gem.ar.SetValue("Medium Red", 41)
        color_gem.ar.SetValue("Most finest Grass green", 42)
        color_gem.ar.SetValue("Most finest Olive green", 43)
        color_gem.ar.SetValue("Extra Fine Grass green", 44)
        color_gem.ar.SetValue("Extra Fine Olive green", 45)
        color_gem.ar.SetValue("Fine Grass green", 46)
        color_gem.ar.SetValue("Fine Olive green", 47)
        color_gem.ar.SetValue("Top Grass green", 48)
        color_gem.ar.SetValue("Top Olive green", 49)
        color_gem.ar.SetValue("Grass green", 50)
        color_gem.ar.SetValue("Olive green", 51)
        color_gem.ar.SetValue("Medium Grass green", 52)
        color_gem.ar.SetValue("Medium Olive green", 53)
        color_gem.ar.SetValue("Blue", 54)
        color_gem.ar.SetValue("Sky blue", 55)
        color_gem.ar.SetValue("Purple", 56)
        color_gem.ar.SetValue("Yellowish Olive Grass green", 57)
        color_gem.ar.SetValue("Yellowish Grass green", 58)
        color_gem.ar.SetValue("Blueish Olive Grass green", 59)
        color_gem.ar.SetValue("Blueish Grass green", 60)
        color_gem.ar.SetValue("Green", 61)
        color_gem.ar.SetValue("Brown", 62)
        color_gem.ar.SetValue("Color change", 63)
        color_gem.ar.SetValue("Finest Purple", 64)
        color_gem.ar.SetValue("Finest Blueish Purple", 65)
        color_gem.ar.SetValue("Extra Fine", 66)
        color_gem.ar.SetValue("Fine", 67)
        '''
        color_gem_base.ar.SetValue("blue", 0)
        color_gem_base.ar.SetValue("Yellow", 1)
        color_gem_base.ar.SetValue("Pink", 2)
        color_gem_base.ar.SetValue("Red", 3)
        color_gem_base.ar.SetValue("green", 4)
        color_gem_base.ar.SetValue("Purple", 5)
        color_gem_base.ar.SetValue("Lemon", 6)
        color_gem_base.ar.SetValue("Golden", 7)
        color_gem_base.ar.SetValue("Pigeon", 8)
        color_gem_base.ar.SetValue("blood", 9)
        color_gem_base.ar.SetValue("Grass", 10)
        color_gem_base.ar.SetValue("Olive", 11)
        color_gem_base.ar.SetValue("Brown", 12)
        color_gem_base.ar.SetValue("Color", 13)


        ' [inv_COLOR_DIAM] 
        ' LANG1_SHORTDESCR()
        color_diam.ar.SetValue("", 0)
        color_diam.ar.SetValue("-", 1)
        color_diam.ar.SetValue("D", 2)
        color_diam.ar.SetValue("E", 3)
        color_diam.ar.SetValue("F", 4)
        color_diam.ar.SetValue("G", 5)
        color_diam.ar.SetValue("H", 6)
        color_diam.ar.SetValue("I", 7)
        color_diam.ar.SetValue("J", 8)
        color_diam.ar.SetValue("K", 9)
        color_diam.ar.SetValue("L", 10)
        color_diam.ar.SetValue("M", 11)
        color_diam.ar.SetValue("N", 12)
        color_diam.ar.SetValue("Fancy", 13)
        color_diam.ar.SetValue("Fancy Light Yellow", 14)
        color_diam.ar.SetValue("Fancy Yellow", 15)
        color_diam.ar.SetValue("Fancy Intense Yellow", 16)
        color_diam.ar.SetValue("Fancy Light Orange", 17)
        color_diam.ar.SetValue("Fancy Orange", 18)
        color_diam.ar.SetValue("Fancy Intense Orange", 19)
        color_diam.ar.SetValue("Fancy Light Pink", 20)
        color_diam.ar.SetValue("Fancy Pink", 21)
        color_diam.ar.SetValue("Fancy Intense Pink", 22)
        color_diam.ar.SetValue("Fancy Light Blue", 23)
        color_diam.ar.SetValue("Fancy Blue", 24)
        color_diam.ar.SetValue("Fancy Intence Blue", 25)
        color_diam.ar.SetValue("Fancy Light Green", 26)
        color_diam.ar.SetValue("Fancy Green", 27)
        color_diam.ar.SetValue("Fancy Intense Green", 28)
        color_diam.ar.SetValue("Fancy Light Brown", 29)
        color_diam.ar.SetValue("Fancy Brown", 30)
        color_diam.ar.SetValue("Fancy Intense Brown", 31)
        color_diam.ar.SetValue("Fancy Cognac", 32)
        color_diam.ar.SetValue("Fancy Champagne", 33)
        color_diam.ar.SetValue("Fancy (see note)", 34)
        '''
        color_diam_base.ar.SetValue("Yellow", 0)
        color_diam_base.ar.SetValue("Orange", 1)
        color_diam_base.ar.SetValue("Pink", 2)
        color_diam_base.ar.SetValue("blue", 3)
        color_diam_base.ar.SetValue("Green", 4)
        color_diam_base.ar.SetValue("Brown", 5)
        color_diam_base.ar.SetValue("Cognac", 6)
        color_diam_base.ar.SetValue("Champagne", 7)


        ' [inv_JEWELTYPE_JEWEL] 
        '        LANG1_SHORTDESCR
        jeweltype_jewel.ar.SetValue("", 0)
        jeweltype_jewel.ar.SetValue("", 1)
        jeweltype_jewel.ar.SetValue("Ring", 2)
        jeweltype_jewel.ar.SetValue("Earrings", 3)
        jeweltype_jewel.ar.SetValue("Necklace", 4)
        jeweltype_jewel.ar.SetValue("Broach", 5)
        jeweltype_jewel.ar.SetValue("Pendant", 6)
        jeweltype_jewel.ar.SetValue("Watch", 7)
        jeweltype_jewel.ar.SetValue("Bracelet", 8)
        jeweltype_jewel.ar.SetValue("Custom Jewelry", 9)
        jeweltype_jewel.ar.SetValue("Setting", 10)
        '''
        jeweltype_jewel_base.ar.SetValue("Ring", 0)
        jeweltype_jewel_base.ar.SetValue("Earrings", 1)
        jeweltype_jewel_base.ar.SetValue("Necklace", 2)
        jeweltype_jewel_base.ar.SetValue("Broach", 3)
        jeweltype_jewel_base.ar.SetValue("Pendant", 4)
        jeweltype_jewel_base.ar.SetValue("Watch", 5)
        jeweltype_jewel_base.ar.SetValue("Bracelet", 6)
        jeweltype_jewel_base.ar.SetValue("Custom", 7)
        jeweltype_jewel_base.ar.SetValue("Setting", 8)


        ' [inv_JEWELSUBTYPE_JEWEL] 
        '        LANG1_SHORTDESCR
        jewelsubtype_jewel.ar.SetValue("", 0)
        jewelsubtype_jewel.ar.SetValue("Solitaire", 1)
        jewelsubtype_jewel.ar.SetValue("", 2)
        jewelsubtype_jewel.ar.SetValue("Antique", 3)
        jewelsubtype_jewel.ar.SetValue("Three Stone", 4)
        jewelsubtype_jewel.ar.SetValue("Fashion", 5)
        jewelsubtype_jewel.ar.SetValue("Band", 6)
        jewelsubtype_jewel.ar.SetValue("Hoop", 7)
        jewelsubtype_jewel.ar.SetValue("Stud", 8)
        jewelsubtype_jewel.ar.SetValue("Drop", 9)
        jewelsubtype_jewel.ar.SetValue("Antique", 10)
        jewelsubtype_jewel.ar.SetValue("Link", 11)
        jewelsubtype_jewel.ar.SetValue("Multi stone", 12)
        jewelsubtype_jewel.ar.SetValue("Antique", 13)
        jewelsubtype_jewel.ar.SetValue("Fashion", 14)
        jewelsubtype_jewel.ar.SetValue("Omega", 15)
        jewelsubtype_jewel.ar.SetValue("Drop", 16)
        jewelsubtype_jewel.ar.SetValue("Heart", 17)
        jewelsubtype_jewel.ar.SetValue("Antique", 18)
        jewelsubtype_jewel.ar.SetValue("Fashion", 19)
        jewelsubtype_jewel.ar.SetValue("Antique", 20)
        jewelsubtype_jewel.ar.SetValue("Fashion", 21)
        jewelsubtype_jewel.ar.SetValue("Cable", 22)
        jewelsubtype_jewel.ar.SetValue("Cuff", 23)
        jewelsubtype_jewel.ar.SetValue("Link", 24)
        jewelsubtype_jewel.ar.SetValue("Bangle", 25)
        jewelsubtype_jewel.ar.SetValue("Tennis", 26)
        jewelsubtype_jewel.ar.SetValue("Multi Stone", 27)
        jewelsubtype_jewel.ar.SetValue("Antique", 28)
        jewelsubtype_jewel.ar.SetValue("Fashion", 29)
        '''
        jewelsubtype_jewel_base.ar.SetValue("Solitaire", 0)
        jewelsubtype_jewel_base.ar.SetValue("Antique", 1)
        jewelsubtype_jewel_base.ar.SetValue("Three", 2)
        jewelsubtype_jewel_base.ar.SetValue("Fashion", 3)
        jewelsubtype_jewel_base.ar.SetValue("Band", 4)
        jewelsubtype_jewel_base.ar.SetValue("Hoop", 5)
        jewelsubtype_jewel_base.ar.SetValue("Stud", 6)
        jewelsubtype_jewel_base.ar.SetValue("Drop", 7)
        jewelsubtype_jewel_base.ar.SetValue("Link", 8)
        jewelsubtype_jewel_base.ar.SetValue("Omega", 9)
        jewelsubtype_jewel_base.ar.SetValue("Heart", 10)
        jewelsubtype_jewel_base.ar.SetValue("Cable", 11)
        jewelsubtype_jewel_base.ar.SetValue("Cuff", 12)
        jewelsubtype_jewel_base.ar.SetValue("Bangle", 13)
        jewelsubtype_jewel_base.ar.SetValue("Tennis", 14)
        jewelsubtype_jewel_base.ar.SetValue("Multi", 15)
        jewelsubtype_jewel_base.ar.SetValue("Earring", 16)
        jewelsubtype_jewel_base.ar.SetValue("Necklace", 17)
        jewelsubtype_jewel_base.ar.SetValue("Broach", 18)
        jewelsubtype_jewel_base.ar.SetValue("Pendant", 19)
        jewelsubtype_jewel_base.ar.SetValue("Watch", 20)
        jewelsubtype_jewel_base.ar.SetValue("Bracelet", 21)
        jewelsubtype_jewel_base.ar.SetValue("Custom", 22)

        ' [inv_METAL_JEWEL] 
        '        LANG1_SHORTDESCR
        metal_jewel.ar.SetValue("", 0)
        metal_jewel.ar.SetValue("-", 1)
        metal_jewel.ar.SetValue("Platinum", 2)
        metal_jewel.ar.SetValue("Yellow  Gold 9 Karat", 3)
        metal_jewel.ar.SetValue("Yellow  Gold 14 Karat", 4)
        metal_jewel.ar.SetValue("Yellow  Gold 18 Karat", 5)
        metal_jewel.ar.SetValue("Yellow Gold 22 Karat", 6)
        metal_jewel.ar.SetValue("White Gold 9 Karat", 7)
        metal_jewel.ar.SetValue("White Gold 14 Karat", 8)
        metal_jewel.ar.SetValue("White Gold 18 Karat", 9)
        metal_jewel.ar.SetValue("White Gold 22 Karat", 10)
        metal_jewel.ar.SetValue("White/Yellow Gold 9 Karat", 11)
        metal_jewel.ar.SetValue("White/Yellow Gold 14 Karat", 12)
        metal_jewel.ar.SetValue("White/Yellow Gold 18 Karat", 13)
        metal_jewel.ar.SetValue("White/Yellow Gold 22 Karat", 14)
        '''
        metal_jewel_base.ar.SetValue("Platinum", 0)
        metal_jewel_base.ar.SetValue("Gold", 1)

        '[inv_ORIGIN_GEM] 
        '        LANG1_SHORTDESCR
        origin_gem.ar.SetValue("", 0)
        origin_gem.ar.SetValue("-", 1)
        origin_gem.ar.SetValue("Sri Lanka (Ceylon)", 2)
        origin_gem.ar.SetValue("Burma", 3)
        origin_gem.ar.SetValue("Colombia", 4)
        origin_gem.ar.SetValue("Kanchna-Buri, TL", 5)
        origin_gem.ar.SetValue("Muzo, Colombia", 6)
        origin_gem.ar.SetValue("Coscuez, Colombia", 7)
        origin_gem.ar.SetValue("Zambia, Africa", 8)
        origin_gem.ar.SetValue("Brazil", 9)
        origin_gem.ar.SetValue("Russia", 10)
        origin_gem.ar.SetValue("Ural, Russia", 11)
        origin_gem.ar.SetValue("Thailand (Siam)", 12)
        origin_gem.ar.SetValue("Chanta-Buri, TL", 13)
        origin_gem.ar.SetValue("Zanskar, Kashmir", 14)
        origin_gem.ar.SetValue("Chantabun, Siam", 15)
        origin_gem.ar.SetValue("Battambang, Siam", 16)
        origin_gem.ar.SetValue("Mogok, Burma", 17)
        origin_gem.ar.SetValue("Mong-Hsu, Burma", 18)
        origin_gem.ar.SetValue("Phailin, Cambodia", 19)
        origin_gem.ar.SetValue("Australia", 20)
        origin_gem.ar.SetValue("Africa", 21)
        origin_gem.ar.SetValue("Madagascar, Africa", 22)
        origin_gem.ar.SetValue("Tanzania, Africa", 23)
        origin_gem.ar.SetValue("Rhodesia, Africa", 24)
        origin_gem.ar.SetValue("India", 25)
        origin_gem.ar.SetValue("Namibia", 26)
        '''
        origin_gem_base.ar.SetValue("Ceylon", 0)
        origin_gem_base.ar.SetValue("Burma", 1)
        origin_gem_base.ar.SetValue("Colombia", 2)
        origin_gem_base.ar.SetValue("Kanchna-Buri", 3)
        origin_gem_base.ar.SetValue("Muzo", 4)
        origin_gem_base.ar.SetValue("Coscuez", 5)
        origin_gem_base.ar.SetValue("Zambia", 6)
        origin_gem_base.ar.SetValue("Brazil", 7)
        origin_gem_base.ar.SetValue("Russia", 8)
        origin_gem_base.ar.SetValue("Ural", 9)
        origin_gem_base.ar.SetValue("Thailand", 10)
        origin_gem_base.ar.SetValue("Chanta-Buri", 11)
        origin_gem_base.ar.SetValue("Kashmir", 12)
        origin_gem_base.ar.SetValue("Chantabun", 13)
        origin_gem_base.ar.SetValue("Battambang", 14)
        origin_gem_base.ar.SetValue("Mogok", 15)
        origin_gem_base.ar.SetValue("Mong-Hsu", 16)
        origin_gem_base.ar.SetValue("Phailin", 17)
        origin_gem_base.ar.SetValue("Australia", 18)
        origin_gem_base.ar.SetValue("Africa", 19)
        origin_gem_base.ar.SetValue("Madagascar", 20)
        origin_gem_base.ar.SetValue("Tanzania", 21)
        origin_gem_base.ar.SetValue("Rhodesia", 22)
        origin_gem_base.ar.SetValue("India", 23)
        origin_gem_base.ar.SetValue("Namibia", 24)

        ' [inv_SHAPE_DIAM] 
        '       LANG1_SHORTDESCR
        shape_diam.ar.SetValue("", 0)
        shape_diam.ar.SetValue("-", 1)
        shape_diam.ar.SetValue("Round Cut", 2)
        shape_diam.ar.SetValue("Princess Cut", 3)
        shape_diam.ar.SetValue("Radiant Cut", 4)
        shape_diam.ar.SetValue("Emerald Cut", 5)
        shape_diam.ar.SetValue("Marquise Cut", 6)
        shape_diam.ar.SetValue("Oval Cut", 7)
        shape_diam.ar.SetValue("Pear Cut", 8)
        shape_diam.ar.SetValue("Trillian Cut", 9)
        shape_diam.ar.SetValue("Cushion Cut", 10)
        shape_diam.ar.SetValue("Square Cut", 11)
        shape_diam.ar.SetValue("Heart Shape Cut", 12)
        shape_diam.ar.SetValue("Round Cabochon Cut", 13)
        shape_diam.ar.SetValue("Oval Cabochon Cut", 14)
        shape_diam.ar.SetValue("Baguette Cut", 15)
        shape_diam.ar.SetValue("Taper Cut", 16)
        shape_diam.ar.SetValue("Asscher Cut", 17)
        shape_diam.ar.SetValue("Sugar Loaf Cut", 18)
        shape_diam.ar.SetValue("Fancy Cut", 19)
        shape_diam.ar.SetValue("Butterfly Cut", 20)
        shape_diam.ar.SetValue("Heart Cabochon Cut", 21)
        shape_diam.ar.SetValue("Fantasy Cut", 22)
        shape_diam.ar.SetValue("Mix Cut", 23)
        shape_diam.ar.SetValue("Rough", 24)
        shape_diam.ar.SetValue("Trapeze", 25)
        shape_diam.ar.SetValue("Trapezoids", 26)
        shape_diam.ar.SetValue("Half Moon Cut", 27)
        shape_diam.ar.SetValue("Shield Cut", 28)
        shape_diam.ar.SetValue("Triangle Cut", 29)
        '''
        shape_diam_base.ar.SetValue("Round", 0)
        shape_diam_base.ar.SetValue("Princess", 1)
        shape_diam_base.ar.SetValue("Radiant", 2)
        shape_diam_base.ar.SetValue("Emerald", 3)
        shape_diam_base.ar.SetValue("Marquise", 4)
        shape_diam_base.ar.SetValue("Oval", 5)
        shape_diam_base.ar.SetValue("Pear", 6)
        shape_diam_base.ar.SetValue("Trillian", 7)
        shape_diam_base.ar.SetValue("Cushion", 8)
        shape_diam_base.ar.SetValue("Square", 9)
        shape_diam_base.ar.SetValue("Shape", 10)
        shape_diam_base.ar.SetValue("Cabochon", 11)
        shape_diam_base.ar.SetValue("Baguette", 12)
        shape_diam_base.ar.SetValue("Taper", 13)
        shape_diam_base.ar.SetValue("Asscher", 14)
        shape_diam_base.ar.SetValue("Sugar", 15)
        shape_diam_base.ar.SetValue("Butterfly", 16)
        shape_diam_base.ar.SetValue("Heart", 17)
        shape_diam_base.ar.SetValue("Fantasy", 18)
        shape_diam_base.ar.SetValue("Mix", 19)
        shape_diam_base.ar.SetValue("Rough", 20)
        shape_diam_base.ar.SetValue("Trapeze", 21)
        shape_diam_base.ar.SetValue("Trapezoids", 22)
        shape_diam_base.ar.SetValue("Moon", 23)
        shape_diam_base.ar.SetValue("Shield", 24)
        shape_diam_base.ar.SetValue("Triangle", 25)


        ' [inv_SHAPE_GEM] 
        '       LANG1_SHORTDESCR
        shape_gem.ar.SetValue("", 0)
        shape_gem.ar.SetValue("-", 1)
        shape_gem.ar.SetValue("Round Cut", 2)
        shape_gem.ar.SetValue("Princess Cut", 3)
        shape_gem.ar.SetValue("Radiant Cut", 4)
        shape_gem.ar.SetValue("Emerald Cut", 5)
        shape_gem.ar.SetValue("Marquise Cut", 6)
        shape_gem.ar.SetValue("Oval Cut", 7)
        shape_gem.ar.SetValue("Pear Cut", 8)
        shape_gem.ar.SetValue("Trillion Cut", 9)
        shape_gem.ar.SetValue("Cushion Cut", 10)
        shape_gem.ar.SetValue("Square Cut", 11)
        shape_gem.ar.SetValue("Heart Shape Cut", 12)
        shape_gem.ar.SetValue("Round Cabochon Cut", 13)
        shape_gem.ar.SetValue("Oval Cabochon Cut", 14)
        shape_gem.ar.SetValue("Baguette Cut", 15)
        shape_gem.ar.SetValue("Taper Cut", 16)
        shape_gem.ar.SetValue("Asscher Cut", 17)
        shape_gem.ar.SetValue("Sugar Loaf Cut", 18)
        shape_gem.ar.SetValue("Fancy Cut", 19)
        shape_gem.ar.SetValue("Butterfly Cut", 20)
        shape_gem.ar.SetValue("Heart Cabochon Cut", 21)
        shape_gem.ar.SetValue("Fantasy Cut", 22)
        shape_gem.ar.SetValue("Mix Cut", 23)
        shape_gem.ar.SetValue("Princess-Emerald cut", 24)
        shape_gem.ar.SetValue("Rough", 25)
        shape_gem.ar.SetValue("Horse Head", 26)
        '''
        shape_gem_base.ar.SetValue("Round", 0)
        shape_gem_base.ar.SetValue("Princess", 1)
        shape_gem_base.ar.SetValue("Radiant", 2)
        shape_gem_base.ar.SetValue("Emerald", 3)
        shape_gem_base.ar.SetValue("Marquise", 4)
        shape_gem_base.ar.SetValue("Oval", 5)
        shape_gem_base.ar.SetValue("Pear", 6)
        shape_gem_base.ar.SetValue("Trillion", 7)
        shape_gem_base.ar.SetValue("Cushion", 8)
        shape_gem_base.ar.SetValue("Square", 9)
        shape_gem_base.ar.SetValue("Heart", 10)
        shape_gem_base.ar.SetValue("Cabochon", 11)
        shape_gem_base.ar.SetValue("Baguette", 12)
        shape_gem_base.ar.SetValue("Taper", 13)
        shape_gem_base.ar.SetValue("Asscher", 14)
        shape_gem_base.ar.SetValue("Sugar", 15)
        shape_gem_base.ar.SetValue("Butterfly", 16)
        shape_gem_base.ar.SetValue("Fantasy", 17)
        shape_gem_base.ar.SetValue("Mix", 18)
        shape_gem_base.ar.SetValue("Princess", 19)
        shape_gem_base.ar.SetValue("Rough", 20)
        shape_gem_base.ar.SetValue("Horse", 21)


        ' [inv_STONETYPE_DIAM] 
        '        LANG1_SHORTDESCR
        stonetype_diam.ar.SetValue("", 0)
        stonetype_diam.ar.SetValue("Diamond", 1)
        stonetype_diam.ar.SetValue("Fancy Diamond", 2)
        '''
        stonetype_diam_base.ar.SetValue("Diamond", 0)

        ' [inv_STONETYPE_GEM] 
        '     LANG1_SHORTDESCR
        stonetype_gem.ar.SetValue("", 0)
        stonetype_gem.ar.SetValue("Natural Ruby", 1)
        stonetype_gem.ar.SetValue("Natural Sapphire", 2)
        stonetype_gem.ar.SetValue("Natural Emerald", 3)
        stonetype_gem.ar.SetValue("Natural Alexandrite", 4)
        stonetype_gem.ar.SetValue("Natural Garnet", 5)
        stonetype_gem.ar.SetValue("Natural Aquamarine", 6)
        stonetype_gem.ar.SetValue("Natural Citrine", 7)
        stonetype_gem.ar.SetValue("Natural Spinel", 8)
        stonetype_gem.ar.SetValue("Natural Tanzanite", 9)
        stonetype_gem.ar.SetValue("Natural Topaz", 10)
        stonetype_gem.ar.SetValue("Natural Tourmaline", 11)
        stonetype_gem.ar.SetValue("Natural Tsavorite", 12)
        stonetype_gem.ar.SetValue("Natural Turquoise", 13)
        stonetype_gem.ar.SetValue("Natural Black Opal", 14)
        stonetype_gem.ar.SetValue("Natural Opal", 15)
        stonetype_gem.ar.SetValue("Natural Kunzite", 16)
        stonetype_gem.ar.SetValue("Natural Rubilite", 17)
        stonetype_gem.ar.SetValue("", 18)
        stonetype_gem.ar.SetValue("Natural Amethyst", 19)
        stonetype_gem.ar.SetValue("Natural Peridot", 20)
        stonetype_gem.ar.SetValue("Natural Chrysoberyl", 21)
        stonetype_gem.ar.SetValue("Natural Christoberyl Garnet", 22)
        stonetype_gem.ar.SetValue("Natural Emaille in Gold", 23)
        stonetype_gem.ar.SetValue("Natural Emaille", 24)
        stonetype_gem.ar.SetValue("Natural Bergl", 25)
        '''
        stonetype_gem_base.ar.SetValue("Ruby", 0)
        stonetype_gem_base.ar.SetValue("Sapphire", 1)
        stonetype_gem_base.ar.SetValue("Emerald", 2)
        stonetype_gem_base.ar.SetValue("Alexandrite", 3)
        stonetype_gem_base.ar.SetValue("Garnet", 4)
        stonetype_gem_base.ar.SetValue("Aquamarine", 5)
        stonetype_gem_base.ar.SetValue("Citrine", 6)
        stonetype_gem_base.ar.SetValue("Spinel", 7)
        stonetype_gem_base.ar.SetValue("Tanzanite", 8)
        stonetype_gem_base.ar.SetValue("Topaz", 9)
        stonetype_gem_base.ar.SetValue("Tourmaline", 10)
        stonetype_gem_base.ar.SetValue("Tsavorite", 11)
        stonetype_gem_base.ar.SetValue("Turquoise", 12)
        stonetype_gem_base.ar.SetValue("Opal", 13)
        stonetype_gem_base.ar.SetValue("Kunzite", 14)
        stonetype_gem_base.ar.SetValue("Rubilite", 15)
        stonetype_gem_base.ar.SetValue("Amethyst", 16)
        stonetype_gem_base.ar.SetValue("Peridot", 17)
        stonetype_gem_base.ar.SetValue("Chrysoberyl", 18)
        stonetype_gem_base.ar.SetValue("Garnet", 19)
        stonetype_gem_base.ar.SetValue("Emaille", 20)
        stonetype_gem_base.ar.SetValue("Bergl", 21)


        '       LANG1_SHORTDESCR()
        'inv_CLARITY_DIAM

        clarity_diam.ar.SetValue("-", 0)
        clarity_diam.ar.SetValue("F", 1)
        clarity_diam.ar.SetValue("IF", 2)
        clarity_diam.ar.SetValue("VVS1", 3)
        clarity_diam.ar.SetValue("VVS2", 4)
        clarity_diam.ar.SetValue("VS1", 5)
        clarity_diam.ar.SetValue("VS2", 6)
        clarity_diam.ar.SetValue("SI1", 7)
        clarity_diam.ar.SetValue("SI2", 8)
        clarity_diam.ar.SetValue("SI3", 9)
        clarity_diam.ar.SetValue("I1", 10)
        clarity_diam.ar.SetValue("I2", 11)
        clarity_diam.ar.SetValue("I3", 12)
        clarity_diam.ar.SetValue("Reject", 13)
        clarity_diam.ar.SetValue("If (enhanced)", 14)
        clarity_diam.ar.SetValue("VVS1(enhanced)", 15)
        clarity_diam.ar.SetValue("VVS2(enhanced)", 16)
        clarity_diam.ar.SetValue("VS1(enhanced)", 17)
        clarity_diam.ar.SetValue("VS2(enhanced)", 18)
        clarity_diam.ar.SetValue("SI1(enhanced)", 19)
        clarity_diam.ar.SetValue("SI2(enhanced)", 20)
        '''
        clarity_diam_base.ar.SetValue("F", 0)
        clarity_diam_base.ar.SetValue("IF", 1)
        clarity_diam_base.ar.SetValue("VVS1", 2)
        clarity_diam_base.ar.SetValue("VVS2", 3)
        clarity_diam_base.ar.SetValue("VS1", 4)
        clarity_diam_base.ar.SetValue("VS2", 5)
        clarity_diam_base.ar.SetValue("SI1", 6)
        clarity_diam_base.ar.SetValue("SI2", 7)
        clarity_diam_base.ar.SetValue("SI3", 8)
        clarity_diam_base.ar.SetValue("I1", 9)
        clarity_diam_base.ar.SetValue("I2", 10)
        clarity_diam_base.ar.SetValue("I3", 11)
        clarity_diam_base.ar.SetValue("Reject", 12)

        '''''''''''
        '        weight.ar.SetValue("weight from ggg to hhh ct.", 0)
        weight.ar.SetValue("weight from %% to %% ct.", 0)
        weight.ar.SetValue("weight less %% ct.", 1)
        weight.ar.SetValue("weight more %% ct.", 2)
        '''
        weight_base.ar.SetValue("more", 0)
        weight_base.ar.SetValue("less", 1)
        weight_base.ar.SetValue("weight", 2)
        weight_base.ar.SetValue("ct.", 3)
        weight_base.ar.SetValue("from", 4)
        weight_base.ar.SetValue("to", 5)

    End Sub

    Public Sub New()
        Me.bstr()
    End Sub

    Protected Overrides Sub Finalize()
        view = Nothing
        color_gem = Nothing
        color_diam = Nothing
        jeweltype_jewel = Nothing
        jewelsubtype_jewel = Nothing
        metal_jewel = Nothing
        origin_gem = Nothing
        shape_diam = Nothing
        shape_gem = Nothing
        stonetype_diam = Nothing
        stonetype_gem = Nothing
        clarity_diam = Nothing
        weight = Nothing
        '
        color_gem_base = Nothing
        color_diam_base = Nothing
        jeweltype_jewel_base = Nothing
        jewelsubtype_jewel_base = Nothing
        metal_jewel_base = Nothing
        origin_gem_base = Nothing
        shape_diam_base = Nothing
        shape_gem_base = Nothing
        stonetype_diam_base = Nothing
        stonetype_gem_base = Nothing
        clarity_diam_base = Nothing
        weight_base = Nothing
        '
        MyBase.Finalize()

    End Sub

End Class
