Imports System.Text.RegularExpressions
Public Class cls_seo
    Inherits iFoundation.cls_error

    Public _title As String
    Public _description As String
    Public _keywords As String
    Public _abstract As String
    Public _type As Int16

    Sub New()
        Me._title = ""
        Me._keywords = ""
        Me._description = ""
        Me._abstract = ""
        Me._type = 0    '-- 1=diamonds 2=fancy-diamonds 3=emeralds 4=sapphire 5=ruby 6=semi-precious 7=jewelry
    End Sub

    Public Function getSEO_home(ByVal cWorkingDomain As String) As Boolean
        On Error GoTo ErrorHandler

        '--- Strip WWW from domain
        cWorkingDomain = Me.stripwww(cWorkingDomain)


        '---
        Select Case cWorkingDomain

            Case "diamonds-diamonds.com"
                Me._type = 1
                Me._title = "diamond, diamonds, loose diamond, wholesale diamond, engagement rings and discount jewelry | DIAMONDS-DIAMONDS.COM"
                Me._keywords = "diamond, diamonds, loose diamonds, wholesale diamonds, diamond engagement ring"
                Me._description = "For an incomparable selection of fine jewelry, high quality diamonds and Fancy diamonds, shop our site. Also diamond jewelry, diamond rings, nacklace, earrings"
                Me._abstract = "wholesaler of diamond, loose diamonds, diamond rings, diamond earrings, diamond engagement jewelry, diamond anniversary jewelry and other diamond bridal jewelry"

            Case "cyber-diamond.com"
                Me._type = 1
                Me._title = "loose diamond, diamond, diamonds, diamond ring, wholesale diamond and discount jewelry | CYBER-DIAMONDS.COM"
                Me._keywords = "loose diamonds, diamonds, diamond, diamond ring, wholesale diamonds, cheap diamonds"
                Me._description = "For an incomparable selection of fine jewelry, high quality loose diamonds and loose Fancy diamonds, shop our site. Also diamond jewelry, diamond rings, nacklace, stud earrings"
                Me._abstract = "wholesaler of diamond, loose diamonds, diamond rings, diamond earrings, diamond engagement jewelry, diamond anniversary jewelry and other diamond bridal jewelry"

            Case "world-diamond.com"
                Me._type = 1
                Me._title = "diamonds, diamond, wholesale diamond, gemstone jewelry, fancy diamond and discount jewelry | WORLD-DIAMOND.COM"
                Me._keywords = "diamond, diamonds, wholesale diamond, gemstone jewelry, jewelry, fancy diamonds"
                Me._description = "For an incomparable selection of fine jewelry, high quality diamonds and Fancy diamonds, shop our site, diamond jewelry. Also diamond rings, nacklace, earrings"
                Me._abstract = "wholesaler of diamond, loose diamonds, diamond rings, diamond earrings, diamond engagement jewelry, diamond anniversary jewelry and other diamond bridal jewelry"

            Case "cyber-jewel.com"
                Me._type = 7
                Me._title = "wholesale diamond, diamond jewelry, diamond, diamond ring, engagement ring and discount jewelry | CYBER-JEWEL.COM"
                Me._keywords = "wholesale diamond, diamond jewelry, diamonds, diamond ring, engagement ring, fancy diamond"
                Me._description = "For an incomparable selection of fine jewelry, high quality diamonds and Fancy diamonds as wholesale prices, shop our site. Also diamond jewelry, diamond rings, nacklace, earrings"
                Me._abstract = "Diamond rings, gemstones, sapphires, rubies, emeralds and more available at great prices from CYBER-JEWEL.COM. Select from our wide variety of jewelry, including rings, bracelets and necklaces"

            Case "1diamond1.com"
                Me._type = 1
                Me._title = "jewelry, jewelry gift, diamond ring, diamond jewelry, fine jewelry and discount jewelry | 1DIAMOND1.COM "
                Me._keywords = "jewelry, jewelry gift, diamond ring, diamond jewelry, fine jewelry, pink diamond rings"
                Me._description = "For an incomparable selection of fine jewelry, high quality diamonds and Fancy diamonds, shop our site. Also engagement jewelry, diamond rings, nacklaces, stud earrings"
                Me._abstract = "wholesaler of fine jewelry, custom jewelry, engagement jewelry, anniversary jewelry including engagement rings, three stone diamond rings and other bridal jewelry"

            Case "1st-diamond.com"
                Me._type = 2
                Me._title = "fancy diamonds, black diamond, blue diamond, diamond and discount jewelry | 1ST-DIAMOND.COM"
                Me._keywords = "fancy diamond, fancy colored diamond, pink diamond, blue diamond, diamonds, diamond, black diamond, fine jewelry"
                Me._description = "For an incomparable selection of high quality diamonds and Fancy diamonds, shop our site. Also engagement jewelry, diamond rings, nacklaces, stud earrings"
                Me._abstract = "wholesaler of fancy diamonds, loose fancy diamonds, colored diamonds, yellow diamond, blue diamond, red diamond, pink diamond, green diamond, diamond engagement jewelry, diamond anniversary jewelry and other diamond bridal jewelry"

            Case "emerald4life.com"
                Me._type = 3
                Me._title = "emerald, emerald ring, gem stone, emeralds, columbian emeralds, emerald jewelry and discount jewelry | EMERALD4LIFE.COM "
                Me._keywords = "emerald, emeralds, emerald ring, gemstones, columbian emeralds, emerald gems, loose emeralds"
                Me._description = "For an incomparable selection of high quality Emeralds and Emerald Jewelry, shop our site. Also engagement jewelry, diamond rings, nacklaces, stud earrings"
                Me._abstract = "wholesaler of emeralds, loose emeralds, Colombian emeralds, Zambian emeralds, emerald rings, emerald earrings and emerald jewelry"

            Case "sapphire4life.com"
                Me._type = 4
                Me._title = "sapphire, sapphire ring, sapphires, pink sapphires, sapphire gems, white sapphire and discount jewelry | SAPPHIRE4LIFE.COM"
                Me._keywords = "sapphire, sapphires, sapphire ring, sapphire jewelry, gem stone,pink sapphire, sapphire ring, ruby sapphire, sapphire jewelry"
                Me._description = "For an incomparable selection of high quality Sapphires and Sapphire Jewelry, shop our site. Also engagement jewelry, diamond rings, nacklaces, stud earrings"
                Me._abstract = "wholesaler of sapphires, loose sapphires, blue sapphire, yellow sapphire, sapphire rings, sapphire earrings, Ceylon sapphires, Kashmir sapphires and sapphire jewelry"

            Case "ruby4life.com"
                Me._type = 5
                Me._title = "ruby, ruby ring, rubies, burma rubies, gemstones, ruby gemstone, ruby jewelry and discount jewelry | RUBY4LIFE.COM"
                Me._keywords = "ruby, rubies, ruby ring, ruby jewelry, gem stone, earring, ring, ruby earring, red ruby"
                Me._description = "For an incomparable selection of high quality Rubies and Ruby Jewelry, shop our site. Also engagement jewelry, diamond rings, nacklaces, stud earrings"
                Me._abstract = "wholesaler of rubies, loose rubies, ruby rings, ruby earrings, thai rubies, burma rubies, mogok rubies and ruby jewelry"

            Case "aaa-diamond.com"
                Me._type = 5
                Me._title = "ruby, rubies, ruby ring, ruby jewelry, gem stone, ruby earring, ring and discount jewelry |-DIAMOND.COM "
                Me._keywords = "ruby, rubies, ruby ring, ruby jewelry, gem stone, earring, ring, ruby earring, red ruby"
                Me._description = "For an incomparable selection of high quality Rubies and Ruby Jewelry, shop our site. Also engagement jewelry, diamond rings, nacklaces, stud earrings"
                Me._abstract = "wholesaler of rubies, loose rubies, ruby rings, ruby earrings, thai rubies, burma rubies, mogok rubies and ruby jewelry"

            Case "aaaaadiamond.com"
                Me._type = 4
                Me._title = "sapphire, sapphires, sapphire ring, sapphire jewelry, gemstone and discount jewelry | AAAAADIAMOND.COM"
                Me._keywords = "sapphire, sapphires, sapphire ring, sapphire jewelry, gem stone,pink sapphire, sapphire ring, ruby sapphire, sapphire jewelry"
                Me._description = "For an incomparable selection of high quality Sapphires and Sapphire Jewelry, shop our site. Also engagement jewelry, diamond rings, rings, stud earrings"
                Me._abstract = "wholesaler of sapphires, loose sapphires, blue sapphire, yellow sapphire, sapphire rings, sapphire earrings, Ceylon sapphires, Kashmir sapphires and sapphire jewelry"

            Case "carat-diamond.com"
                Me._type = 3
                Me._title = "emerald, emeralds, emerald ring, emerald jewelry, gemstone, earring and discount jewelry | CARAT-DIAMOND.COM"
                Me._keywords = "emerald, emeralds, emerald ring, emerald jewelry, gemstone, earrings, stud earrings"
                Me._description = "For an incomparable selection of high quality Emeralds and Emerald Jewelry, shop our site. Also engagement jewelry, diamond rings, earrings, stud earrings"
                Me._abstract = "wholesaler of emeralds, loose emeralds, Colombian emeralds, Zambian emeralds, emerald rings, emerald earrings and emerald jewelry"

            Case "diam4you.com"
                Me._type = 7
                Me._title = "diamond ring, emerald ring, sapphire ring, ring, earring, fancy diamond and discount jewelry | DIAM4YOU.COM"
                Me._keywords = "diamond rings, emerald rings, sapphire rings, gemstone ring, rings, earrings, fancy diamonds"
                Me._description = "For an incomparable selection of fine jewelry, high quality diamonds and Fancy diamonds, shop our site. Also diamond jewelry, diamond rings, broaches, earrings"
                Me._abstract = "wholesaler of fine jewelry, custom jewelry, engagement jewelry, anniversary jewelry including engagement rings, three stone diamond rings and other bridal jewelry"

            Case "diamond1000.com"
                Me._type = 7
                Me._title = "jewelry, jewelry store, diamond jewelry, ruby jewelry, emerald jewelry, wholesale jewelry and discount jewelry | DIAMOND1000.COM"
                Me._keywords = "jewelry, jewellery, diamond jewely, ruby jewelry, emerald jewelry, sapphire jewelry"
                Me._description = "For an incomparable selection of fine jewelry, high quality diamonds and Fancy diamonds, shop our site. Also diamond jewelry, diamond rings, nacklace, stud earrings"
                Me._abstract = "wholesaler of fine jewelry, custom jewelry, engagement jewelry, anniversary jewelry including engagement rings, three stone diamond rings and other bridal jewelry"

            Case "diamond-rush.com"
                Me._type = 3
                Me._title = "emerald, emerald ring, gemstones, columbian emerald, emerald jewelry and discount jewelry | DIAMOND-RUSH.COM"
                Me._keywords = "emeralds, emerald ring, gemstones, columbian emerald, emerald gems"
                Me._description = "For an incomparable selection of high quality Emeralds and Emerald Jewelry, shop our site. Also engagement jewelry, diamond rings, earrings, stud earrings"
                Me._abstract = "wholesaler of emeralds, loose emeralds, Colombian emeralds, Zambian emeralds, emerald rings, emerald earrings and emerald jewelry"

            Case "diamonds-exchange.com"
                Me._type = 4
                Me._title = "sapphire, sapphire ring, sapphire earring, sapphire jewelry and discount jewelry | DIAMONDS-EXCHANGE.COM"
                Me._keywords = "sapphires, sapphire, sapphire earring, sapphire jewelry, sapphire gemstone, blue sapphire"
                Me._description = "For an incomparable selection of high quality Sapphires and Sapphire Jewelry, shop our site. Also engagement jewelry, diamond rings, nacklaces, stud earrings"
                Me._abstract = "wholesaler of sapphires, loose sapphires, blue sapphire, yellow sapphire, sapphire rings, sapphire earrings, Ceylon sapphires, Kashmir sapphires and sapphire jewelry"

            Case "your-diamond.com"
                Me._type = 5
                Me._title = "ruby, rubies, ruby ring, ruby jewelry, ruby earring and discount jewelry | YOUR-DIAMOND.COM"
                Me._keywords = "ruby, rubies, ruby ring, ruby jewelry, ruby earring, ruby gemstone"
                Me._description = "For an incomparable selection of high quality Rubies and Ruby Jewelry, shop our site. Also engagement jewelry, diamond rings, nacklaces, stud earrings"
                Me._abstract = "wholesaler of rubies, loose rubies, ruby rings, ruby earrings, thai rubies, burma rubies, mogok rubies and ruby jewelry"

            Case "gem-deal.com"
                Me._type = 7
                Me._title = "jewelry, gemstone, deal, rings, earrings, necklaces, credit card deal | GEM-DEAL.COM"
                Me._keywords = "jewelry deal, gemstone deal, deal, rings, earrings, necklaces"
                Me._description = "For an incomparable selection of high quality Jewelry and Diamond Jewelry, shop our site. Also engagement jewelry, diamond rings, earrings, stud earrings"
                Me._abstract = "wholesaler of fine jewelry, custom jewelry, engagement jewelry, anniversary jewelry including engagement rings, three stone diamond rings and other bridal jewelry"

            Case "sapphire4you.com"
                Me._type = 4
                Me._title = "sapphire, sapphires, loose sapphires, sapphire ring, pink sapphires, yellow sapphire and discount jewelry | from SAPPHIRE4LIFE.COM"
                Me._keywords = "sapphire, sapphires, sapphire ring, sapphire jewelry, gem stone,pink sapphire, sapphire ring, ruby sapphire, sapphire jewelry"
                Me._description = "For an incomparable selection of high quality Sapphires and Sapphire Jewelry, shop our site. Also engagement jewelry, diamond rings, nacklaces, stud earrings"
                Me._abstract = "wholesaler of sapphires, loose sapphires, blue sapphire, yellow sapphire, sapphire rings, sapphire earrings, Ceylon sapphires, Kashmir sapphires and sapphire jewelry"

            Case "ruby4you.com"
                Me._type = 5
                Me._title = "ruby, rubies, loose rubies, ruby ring, rubies, burma rubies, ruby gemstone, ruby jewelry and discount jewelry | RUBY4LIFE.COM"
                Me._keywords = "ruby, rubies, ruby ring, ruby jewelry, gem stone, earring, ring, ruby earring, red ruby"
                Me._description = "For an incomparable selection of high quality Rubies and Ruby Jewelry, shop our site. Also engagement jewelry, diamond rings, nacklaces, stud earrings"
                Me._abstract = "wholesaler of rubies, loose rubies, ruby rings, ruby earrings, thai rubies, burma rubies, mogok rubies and ruby jewelry"

            Case "emerald4you.com"
                Me._type = 3
                Me._title = "emerald, emeralds, loose emerald, emerald ring, gem stone, columbian emeralds, emerald jewelry and discount jewelry | EMERALD4LIFE.COM "
                Me._keywords = "emerald, emeralds, emerald ring, gemstones, columbian emeralds, emerald gems, loose emeralds"
                Me._description = "For an incomparable selection of high quality Emeralds and Emerald Jewelry, shop our site. Also engagement jewelry, diamond rings, nacklaces, stud earrings"
                Me._abstract = "wholesaler of emeralds, loose emeralds, Colombian emeralds, Zambian emeralds, emerald rings, emerald earrings and emerald jewelry"

            Case Else
                Me._type = 4
                Me._title = "diamond, emerald, sapphire, ruby, fancy diamond, fine jewelry and discount jewelry | Twin-Diamonds.com"
                Me._keywords = "diamonds, diamond ring, rings, diamond engagement ring, ruby, emerald, emerald, emeralds,sapphire ring, emerald ring, fancy diamonds, engagement rings, wedding rings, anniversary rings, sapphires, saphire, jewelry, loose diamonds, semi-precious, semi-precious stones"
                Me._description = "diamonds, diamond rings and gemstones, including emeralds, sapphires and rubies, available from Twin-Diamonds.com. Browse our wide selection of diamond jewelry and gemstone jewelry"
                Me._abstract = "wholesaler of diamond jewelry, gem stones, sapphires, rubies, emeralds, fancy diamonds and fine jewelry"

        End Select


        '--- Everything id OK *
        Return False
        Exit Function

ErrorHandler:
        Me._err_number = Err.Number
        Me._err_description = Err.Description
        Me._err_source = Err.Source
        Return True

    End Function


    Public Function getSEO_categories(ByVal cWorkingDomain As String, ByVal nPlate As Int16, ByVal nCategory As Int16) As Boolean
        On Error GoTo ErrorHandler

        '--- Strip WWW from domain
        cWorkingDomain = Me.stripwww(cWorkingDomain)

        '---
        Select Case nPlate

            Case 1   '- Diamonds
                Select Case nCategory
                    Case 1       '- Diamonds
                        Me._type = 1
                        Me._title = "diamonds, diamond, loose diamonds, diamond ring, wholesale diamonds, diamond engagement ring, buy diamonds, gem stone | Twin-Diamonds.com"
                        Me._keywords = "diamonds, diamond, loose diamonds, diamond ring, wholesale diamonds, diamond engagement ring, buy diamonds, gem stone, loose diamond, diamond jewelry, diamond earring, wholesale diamonds"
                        Me._description = "diamonds, including loose diamonds, diamond engagement rings and diamond earrings, diamond stud earrings all available from Twin-Diamonds.com at wholesale prices. Select from our wide range of diamonds and diamond jewelry, diamond engagement rings, diamond anniversary rings and bridal jewelry"
                        Me._abstract = "Twin-Diamonds is a wholesaler of diamond, loose diamonds, diamond rings, diamond earrings, diamond engagement jewelry, diamond anniversary jewelry and other diamond bridal jewelry"

                    Case 2       '- Fancy Diamonds
                        Me._type = 2
                        Me._title = "fancy diamonds, loose fancy diamonds, fancy colored diamonds, yellow diamonds, pink diamonds, blue diamonds | Twin-Diamonds.com"
                        Me._keywords = "fancy diamonds, loose fancy diamonds, fancy colored diamonds, yellow diamonds, pink diamonds, blue diamonds, gem stone, fancy diamond ring, colored diamonds"
                        Me._description = "fancy diamonds, fancy colored diamonds, including fancy pink diamonds and fancy yellow diamonds, available from Twin-Diamonds.com at wholesale prices. Browse our wide range of colored diamonds, fancy diamonds, blue diamonds, red diamonds, green diamonds and pink diamonds"
                        Me._abstract = "Twin-Diamonds is a wholesaler of fancy diamonds, loose fancy diamonds, colored diamonds, yellow diamond, blue diamond, red diamond, pink diamond, green diamond, diamond engagement jewelry, diamond anniversary jewelry and other diamond bridal jewelry"

                End Select


            Case 2   '-- Gemstones
                Select Case nCategory
                    Case 3       '- Rubies
                        Me._type = 5
                        Me._title = "ruby, rubies, loose rubies, ruby ring, ruby sapphire, ruby and sapphire, ruby jewelry, ruby earrings, gem stone | Twin-Diamonds.com"
                        Me._keywords = "ruby, rubies, loose rubies, ruby ring, ruby sapphire, ruby and sapphire, ruby jewelry, ruby earrings, gem stone, thai ruby, burma ruby, mogok ruby, ruby gem stone, ruby bracelet, ruby sapphire"
                        Me._description = "rubies, loose rubies, including ruby rings, ruby earrings and other ruby jewelry, available from Twin-Diamonds.com at wholesale prices. The largest online gem stone selection. Browse our wide variety of red rubies, loose rubies, thai rubies, burma rubies, mogok ruby, ruby rings and ruby jewelry"
                        Me._abstract = "Twin-Diamonds is a wholesaler of rubies, loose rubies, ruby rings, ruby earrings, thai rubies, burma rubies, mogok rubies and ruby jewelry"

                    Case 4       '- Sapphires
                        Me._type = 4
                        Me._title = "sapphire, sapphires, loose sapphires, blue sapphires, pink sapphire, sapphire ring, sapphire jewelry, pink sapphire rings, sapphire earrings, gem stone | Twin-Diamonds.com"
                        Me._keywords = "sapphire, sapphires, loose sapphires, blue sapphires, pink sapphire, sapphire ring, sapphire jewelry, pink sapphire rings, gem stone, Ceylon sapphire, Kashmir sapphire, sapphire gem stone, sapphire bracelet, sapphire earrings"
                        Me._description = "sapphires, loose sapphires, including sapphire rings, sapphire earrings and other sapphire jewelry, available from Twin-Diamonds.com at wholesale prices. The largest online gem stone selection. Browse our wide variety of blue sapphires, loose sapphires, ceylon sapphires, kashmir sapphires, sapphire rings and sapphire jewelry"
                        Me._abstract = "Twin-Diamonds is a wholesaler of sapphires, loose sapphires, blue sapphire, yellow sapphire, sapphire rings, sapphire earrings, Ceylon sapphires, Kashmir sapphires and sapphire jewelry"

                    Case 5       '- Emeralds
                        Me._type = 3
                        Me._title = "emerald, emeralds, emerald ring, loose emeralds, emerald cut, emerald earrings, emerald jewelry, gem stone | Twin-Diamonds.com"
                        Me._keywords = "emerald, emeralds, emerald ring, loose emeralds, emerald cut, emerald earrings, emerald jewelry, gem stone, Colombian emerald, Zambian emerald, emerald gem stone, emerald bracelet"
                        Me._description = "emeralds, loose emeralds including emerald rings, emerald earrings and other emerald jewelry, available from Twin-Diamonds.com at wholesale prices. The largest online gem stone selection. Browse our wide variety of green emeralds, loose emeralds, Colombian emeralds, Zambian emeralds, emerald rings and emerald jewelry at our online store"
                        Me._abstract = "Twin-Diamonds is a wholesaler of emeralds, loose emeralds, Colombian emeralds, Zambian emeralds, emerald rings, emerald earrings and emerald jewelry"


                    Case 6       '- Semi-Precious
                        Me._type = 6
                        Me._title = "tanzanite, aquamarine, semi precious stones, semi precious gem stones, semi precious jewelry, gem stone | Twin-Diamonds.com"
                        Me._keywords = "tanzanite, aquamarine, semi precious stones, semi precious gem stones, semi precious jewelry, gem stone, garnet, tourmaline, semi precious rings, semi precious earrings, opal, black opal"
                        Me._description = "semi precious stones, including tanzanite rings and tanzanite jewelry, available from Twin-Diamonds.com at wholesale prices. The largest online gem stone selection. Browse our wide range of tanzanite, garnet, aquamarine, tourmaline and alexandrite jewelry and gem stones in different shapes and sizes"
                        Me._abstract = "Twin-Diamonds is a wholesaler of semi precious gem stones including tanzanite, tanzanite jewelry, aquamarine, garnet, tourmaline, alexandrite and other semi precious gem stones and jewelry"

                End Select

            Case 3   '- Jewelry
                Select Case nCategory
                    Case 7       '- Jewelry
                        Me._type = 7
                        Me._title = "jewelry, wholesale jewelry, jewelry stores, gold jewelry, fashion jewelry, engagement jewelry, fine jewelry | Twin-Diamonds.com"
                        Me._keywords = "jewelry, wholesale jewelry, jewelry stores, gold jewelry, fashion jewelry, engagement jewelry, fine jewelry, anniversary jewelry, bridal jewelry, jewelry wholesale, italian jewelry, custom jewelry."
                        Me._description = "jewelry, including fine jewelry such as diamond rings, diamond engagement rings, sapphire rings and more, all from Twin-Diamonds.com at wholesale prices. Browse our jewelry store today and find solitaire diamond rings, three stone rings, diamond engagement jewelry, anniversary jewelry and bridal jewelry at wholesale jewelry at great prices."
                        Me._abstract = "Twin-Diamonds is a wholesaler of fine jewelry, custom jewelry, engagement jewelry, anniversary jewelry including engagement rings, three stone diamond rings and other bridal jewelry"

                End Select


            Case 11   '- New Items
                Me._type = 4
                Me._title = "hot item new, item jewelry new, special offer, special holiday offer,store special, from Twin-Diamonds.com"
                Me._keywords = "jewelry, wholesale jewelry, jewelry stores, gold jewelry, fashion jewelry, engagement jewelry, fine jewelry, anniversary jewelry, bridal jewelry, jewelry wholesale, italian jewelry, custom jewelry."
                Me._description = "jewelry, including fine jewelry such as diamond rings, diamond engagement rings, sapphire rings and more, all from Twin-Diamonds.com at wholesale prices. Browse our jewelry store today and find solitaire diamond rings, three stone rings, diamond engagement jewelry, anniversary jewelry and bridal jewelry at wholesale jewelry at great prices."
                Me._abstract = "Twin-Diamonds is a wholesaler of fine jewelry, custom jewelry, engagement jewelry, anniversary jewelry including engagement rings, three stone diamond rings and other bridal jewelry"

            Case 12    '- Special Items
                Me._type = 4
                Me._title = "discount jewelry, specials wholesale prices, wholesale jewelry, discount sapphires, from Twin-Diamonds.com"
                Me._keywords = "jewelry, wholesale jewelry, jewelry stores, gold jewelry, fashion jewelry, engagement jewelry, fine jewelry, anniversary jewelry, bridal jewelry, jewelry wholesale, italian jewelry, custom jewelry."
                Me._description = "jewelry, including fine jewelry such as diamond rings, diamond engagement rings, sapphire rings and more, all from Twin-Diamonds.com at wholesale prices. Browse our jewelry store today and find solitaire diamond rings, three stone rings, diamond engagement jewelry, anniversary jewelry and bridal jewelry at wholesale jewelry at great prices."
                Me._abstract = "Twin-Diamonds is a wholesaler of fine jewelry, custom jewelry, engagement jewelry, anniversary jewelry including engagement rings, three stone diamond rings and other bridal jewelry"

            Case 13    '- Search Result
                Me._type = 4
                Me._title = "discount jewelry, specials wholesale prices, diamonds, fancy diamonds, fine jewelry and gemstones, from Twin-Diamonds.com"
                Me._keywords = "jewelry, wholesale jewelry, jewelry stores, gold jewelry, fashion jewelry, engagement jewelry, fine jewelry, anniversary jewelry, bridal jewelry, jewelry wholesale, italian jewelry, custom jewelry."
                Me._description = "jewelry, including fine jewelry such as diamond rings, diamond engagement rings, sapphire rings and more, all from Twin-Diamonds.com at wholesale prices. Browse our jewelry store today and find solitaire diamond rings, three stone rings, diamond engagement jewelry, anniversary jewelry and bridal jewelry at wholesale jewelry at great prices."
                Me._abstract = "Twin-Diamonds is a wholesaler of fine jewelry, custom jewelry, engagement jewelry, anniversary jewelry including engagement rings, three stone diamond rings and other bridal jewelry"

            Case 14      '- Semi-Precious
                Me._type = 6
                Me._title = "tanzanite, aquamarine, semi precious stones, semi precious gem stones, semi precious jewelry, gem stone | Twin-Diamonds.com"
                Me._keywords = "tanzanite, aquamarine, semi precious stones, semi precious gem stones, semi precious jewelry, gem stone, garnet, tourmaline, semi precious rings, semi precious earrings, opal, black opal"
                Me._description = "semi precious stones, including tanzanite rings and tanzanite jewelry, available from Twin-Diamonds.com at wholesale prices. The largest online gem stone selection. Browse our wide range of tanzanite, garnet, aquamarine, tourmaline and alexandrite jewelry and gem stones in different shapes and sizes"
                Me._abstract = "Twin-Diamonds is a wholesaler of semi precious gem stones including tanzanite, tanzanite jewelry, aquamarine, garnet, tourmaline, alexandrite and other semi precious gem stones and jewelry"


        End Select


        '--- Everything id OK *
        Return False
        Exit Function

ErrorHandler:
        Me._err_number = Err.Number
        Me._err_description = Err.Description
        Me._err_source = Err.Source
        Return True

    End Function

    Public Function get_list_intro(ByVal nMode As Int16, ByVal nCat As Int16, ByVal cDomain As String, ByRef cText As String) As Boolean
        On Error GoTo ErrorHandler
        Dim bError As Boolean = False


        If nCat = 1 Then   '--- Diamonds
            cText = "<a href='" + cDomain + "/diamonds.aspx' class='small_link'>Diamond</a> <a href='" + cDomain + "/jewelry.aspx' class='small_link'>jewelry</a>, including <a href='" + cDomain + "/diamonds.aspx' class='small_link'>loose diamonds</a>, <a href='" + cDomain + "/jewelry.aspx' class='small_link'>diamond rings</a> and <a href='" + cDomain + "/jewelry.aspx' class='small_link'>diamond earrings</a>, are now available from <a href='" + cDomain + "/default.aspx' class='small_link'>Twin-Diamonds.com</a>.<br>"
            cText = cText + "<a href='" + cDomain + "/diamonds.aspx' class='small_link'>Diamonds</a> make the perfect gift for any occasion and <a href='" + cDomain + "/default.aspx' class='small_link'>Twin-Diamonds</a> offers you a wide selection including <a href='" + cDomain + "/diamonds.aspx' class='small_link'>loose diamonds</a>, <a href='" + cDomain + "/jewelry.aspx' class='small_link'>diamond engagement rings</a>, and more at wholesale prices."

        ElseIf nCat = 2 Then   '--- Fancy Diamonds
            cText = "<a href='" + cDomain + "/fancy-diamonds.aspx' class='small_link'>Fancy colored diamonds</a>, including <a href='" + cDomain + "/fancy-diamonds.aspx' class='small_link'>fancy yellow diamonds</a> and <a href='" + cDomain + "/diamonds/fancy-diamonds-loose.aspx' class='small_link'>fancy pink diamonds</a> and more, available from <a href='" + cDomain + "/default.aspx' class='small_link'>Twin-Diamonds.com</a>. Our wide range of <a href='" + cDomain + "/fancy-diamonds.aspx' class='small_link'>fancy diamonds</a> comes in a variety of fancy shapes."
            cText = cText + " Learn more about <a href='http://www.gem-resource.com/gemology/diamond.htm' target='_blank' class='small_link'>diamonds</a> on our <a href='http://www.gem-resource.com/gemology/diamond.htm' target='_blank' class='small_link'>diamond information</a> page."

        ElseIf nCat = 4 Then   '--- Sapphires
            cText = cText + "<a href='" + cDomain + "/sapphires.aspx' class='small_link'>Sapphires</a>, including <a href='" + cDomain + "/jewelry.aspx' class='small_link'>sapphire jewelry</a> in different shapes, available from <a href='" + cDomain + "/default.aspx' class='small_link'>Twin-Diamonds.com</a>. <br>"
            cText = cText + "Find <a href='" + cDomain + "/sapphires.aspx' class='small_link'>sapphire</a> <a href='" + cDomain + "/diamonds.aspx' class='small_link'>diamonds</a>, including <a href='" + cDomain + "/gem-stones/sapphires-loose.aspx' class='small_link'>pink sapphires</a>, <a href='" + cDomain + "/gem-stones/sapphires-loose.aspx' class='small_link'>blue sapphires</a>, and more today from <a href='" + cDomain + "/default.aspx' class='small_link'>Twin-Diamonds.com</a>.<br>"
            cText = cText + "A <a href='" + cDomain + "/sapphires.aspx' class='small_link'>sapphire</a>, one of the most beautiful gemstones in the world, is a wonderful gift for any occasion.<br>"
            cText = cText + "Learn more about <a href='http://www.gem-resource.com/gemology/sapphire.htm' target='_blank' class='small_link'>Sapphires</a> from our <a href='http://www.gem-resource.com/gemology/sapphire.htm' target='_blank' class='small_link'>Gem Resource</a> page."

        ElseIf nCat = 3 Then   '--- Rubies
            cText = cText + "<a href='" + cDomain + "/rubies.aspx' class='small_link'>Rubies</a>, which symbolize love, are now available to you at affordable prices.<br>"
            cText = cText + "Whether you're looking for a <a href='" + cDomain + "/rubies.aspx' class='small_link'>ruby</a> that is oval shaped, or a pear shaped <a href='" + cDomain + "/rubies.aspx' class='small_link'>ruby</a>, select your <a href='" + cDomain + "/gem-stones/rubies-loose.aspx' class='small_link'>ruby</a> from our <a href='" + cDomain + "/jewelry.aspx' class='small_link'>ruby jewelry</a> today and you won't be disappointed. <br>"
            cText = cText + "Browse our ruby page, or learn more about <a href='http://www.gem-resource.com/gemology/ruby.htm' target='_blank' class='small_link'>Rubies</a> from our <a href='http://www.gem-resource.com/gemology/ruby.htm' target='_blank' class='small_link'>Gem Resource</a> page."

        ElseIf nCat = 5 Then  '--- Emeralds
            cText = "<a href='" + cDomain + "/emeralds.aspx' class='small_link'>Emeralds</a>, <a href='" + cDomain + "/jewelry.aspx' class='small_link'>emerald rings</a>, and more <a href='" + cDomain + "/jewelry.aspx' class='small_link'>emerald jewelry</a> are now available to you from <a href='" + cDomain + "/default.aspx' class='small_link'>Twin-Diamonds.com</a>.<br>"
            cText = cText + " The <a href='" + cDomain + "/emeralds.aspx' class='small_link'>emerald</a>, which is naturally an <a href='" + cDomain + "/emeralds.aspx' class='small_link'>emerald</a> green color, is the May birthstone.<br>"
            cText = cText + "Whether you're looking for a <a href='" + cDomain + "/gem-stones/emeralds-loose.aspx' class='small_link'>loose emerald</a>, or an <a href='" + cDomain + "/jewelry.aspx' class='small_link'>emerald engagement ring</a>, <a href='" + cDomain + "/default.aspx' class='small_link'>Twin-Diamonds.com</a> has the <a href='" + cDomain + "/gem-stones/emeralds-loose.aspx' class='small_link'>emerald</a> for you.<br>"
            cText = cText + "For more information about <a href='http://www.gem-resource.com/gemology/emerald.htm' target='_blank' class='small_link'>Emeralds</a>, please read our emerald education page at <a href='http://www.gem-resource.com/gemology/emerald.htm' target='_blank' class='small_link'>Gem resource</a> "

        ElseIf nCat = 6 Then  '--- Semi Presious
            cText = "Our <a href='" + cDomain + "/semi-precious.aspx' class='small_link'>Semi Precious</a> gemstones are of the finest quality, we sell <a href='" + cDomain + "/listitem.aspx?mode=2&st=Tanzanite' class='small_link'>Tanzanite</a>, <a href='" + cDomain + "/listitem.aspx?mode=2&st=Tourmaline' class='small_link'>Tourmaline</a>, <a href='" + cDomain + "/listitem.aspx?mode=2&st=Alexandrite' class='small_link'>Alexandrite</a>, <a href='" + cDomain + "/listitem.aspx?mode=2&st=Opal&r2=0' class='small_link'>Opal</a>, <a href='" + cDomain + "/listitem.aspx?mode=2&st=Black%20Opal' class='small_link'>Black Opal</a> and many more."
            cText = cText + "Learn more about <a href='http://www.gem-resource.com/gemology/tanzanite.htm' target='_blank' class='small_link'>Semi Precious gemstones</a> from our <a href='http://www.gem-resource.com/gemology/tanzanite.htm' target='_blank' class='small_link'>Gem Resource</a> page."

        ElseIf nCat = 7 Then   '--- Jewelry
            cText = "<a href='" + cDomain + "/jewelry.aspx' class='small_link'>Jewelry</a>, including <a href='" + cDomain + "/jewelry.aspx' class='small_link'>fine jewelry</a> such as <a href='" + cDomain + "/jewelry/jewelry-rings.aspx' class='small_link'>engagement ring</a>, <a href='" + cDomain + "/jewelry/jewelry-rings.aspx' class='small_link'>Solitaire ring</a>, <a href='" + cDomain + "/jewelry/jewelry-rings.aspx' class='small_link'>three stone rings</a> and more, available from <a href='" + cDomain + "/default.aspx' class='small_link'>Twin-Diamonds.com</a>. Browse through our wide range of <a href='" + cDomain + "/jewelry.aspx' class='small_link'>jewelry</a> and find <a href='" + cDomain + "/jewelry.aspx' class='small_link'>wholesale jewelry</a> at discounted prices"

        ElseIf nMode = 11 Then  '--- New Items
            cText = "<a href='" + cDomain + "/new-items.aspx' class='small_link'>New selection</a> of items including <a href='" + cDomain + "/emeralds.aspx' class='small_link'>Emeralds</a>, <a href='" + cDomain + "/rubies.aspx' class='small_link'>Rubies</a>, <a href='" + cDomain + "/sapphires.aspx' class='small_link'>Sapphires</a>, <a href='" + cDomain + "/diamonds.aspx' class='small_link'>Diamonds</a>, <a href='" + cDomain + "/fancy-diamonds.aspx' class='small_link'>Fancy Diamonds</a> and <a href='" + cDomain + "/jewelry.aspx' class='small_link'>Fine Jewelry</a> added to our inventory."

        ElseIf nMode = 12 Then  '--- Special
            cText = "<a href='" + cDomain + "/emeralds.aspx' class='small_link'>Emeralds</a>, <a href='" + cDomain + "/rubies.aspx' class='small_link'>Rubies</a>, <a href='" + cDomain + "/sapphires.aspx' class='small_link'>Sapphires</a>, <a href='" + cDomain + "/diamonds.aspx' class='small_link'>Diamonds</a>, <a href='" + cDomain + "/fancy-diamonds.aspx' class='small_link'>Fancy Diamonds</a> and <a href='" + cDomain + "/jewelry.aspx' class='small_link'>Fine Jewelry</a> at wholesale discount rates, very attractive prices."
        End If

        Return False
        Exit Function

ErrorHandler:
        Me._err_number = Err.Number
        Me._err_description = Err.Description
        Me._err_source = Err.Source
        Return True

    End Function


    Private Function get_SEOplate(ByVal nPlate As Int16) As Boolean
        On Error GoTo ErrorHandler


        '---
        Select Case nPlate

            Case 1   '- Diamonds


            Case 2   '- Gemstones


            Case 3   '- Jewelry

        End Select

        '--- Everything is OK *
        Return False
        Exit Function

ErrorHandler:
        Me._err_number = Err.Number
        Me._err_description = Err.Description
        Me._err_source = Err.Source
        Return True

    End Function

    Function stripwww(ByVal cDomain As String) As String

        cDomain = cDomain.ToLower

        '--- Strip http
        cDomain = Me.striphttp(cDomain)


        If cDomain.StartsWith("www.") Then
            Return Mid(cDomain, 5)
        End If

        Return cDomain

    End Function

    Function striphttp(ByVal cDomain As String) As String

        cDomain = cDomain.ToLower

        If cDomain.StartsWith("http://") Then
            Return Mid(cDomain, 8)
        End If

        Return cDomain

    End Function

    Function CreateISAPILink(ByVal desc As String, ByVal plate As Int32, ByVal id As Int32) As String
        Dim ostringfunc As New iFunctions.cls_string
        desc = desc.Replace("<br>", " ").Replace("<BR>", " ")
        desc = desc.Replace("&", " and")
        desc = desc.Replace("\", "-")
        desc = desc.Replace("/", "-")
        ''  desc = desc.Replace(".", "")
        desc = desc.Replace("Ct.", "Carat")
        desc = ostringfunc.ClearHTMLTagsReturn(Trim(desc))
        desc = Trim(desc)
        desc = desc.Replace(" ", "-")
        desc = desc.Replace(".", "-")
        desc = desc.Replace("{", "")
        desc = desc.Replace(")", "")
        desc = desc.Replace(",", "-")
        desc = Regex.Replace(desc, "[-]+", "-")
        desc = desc.Replace("--", "-")
        desc = desc.Replace("..", ".")
        ''desc = desc.Replace
        desc += "-ID" + id.ToString
        desc += ".html"
        Select Case plate
            Case 1
                Return "/diamond/" + desc
            Case 2
                Return "/gemstone/" + desc
            Case 3
                Return "/jewelry/" + desc

        End Select

        Return desc

        ''ostringfunc.ClearHTMLTagsReturn(Trim(desc).Replace("<br>", " ").Replace("<BR>", " ")).Replace(" ", "-").replace("--", "-") + "-ID" + oPlate._id.ToString.ToUpper
    End Function

    Function CreateISAPILinkModel(ByVal desc As String, ByVal plate As Int32, ByVal id As Int32) As String
        Dim ostringfunc As New iFunctions.cls_string
        desc = desc.Replace("<br>", " ").Replace("<BR>", " ")
        desc = desc.Replace("&", " and")
        desc = desc.Replace("\", "-")
        desc = desc.Replace("/", "-")
        ''  desc = desc.Replace(".", "")
        desc = desc.Replace("Ct.", "Carat")
        desc = ostringfunc.ClearHTMLTagsReturn(Trim(desc))
        desc = Trim(desc)
        desc = desc.Replace(" ", "-")
        desc = desc.Replace(".", "-")
        desc = desc.Replace("{", "")
        desc = desc.Replace(")", "")
        desc = desc.Replace(",", "-")
        desc = Regex.Replace(desc, "[-]+", "-")
        desc = desc.Replace("--", "-")
        desc = desc.Replace("..", ".")
        ''desc = desc.Replace
        desc += "-IDMODEL" + id.ToString
        desc += ".html"
        Select Case plate
            Case 1
                Return "/diamond/" + desc
            Case 2
                Return "/gemstone/" + desc
            Case 3
                Return "/jewelry/" + desc

        End Select

        Return desc

        ''ostringfunc.ClearHTMLTagsReturn(Trim(desc).Replace("<br>", " ").Replace("<BR>", " ")).Replace(" ", "-").replace("--", "-") + "-ID" + oPlate._id.ToString.ToUpper
    End Function

    Function CreateISAPILinkEnhanced(ByVal desc As String, ByVal plate As Int32, ByVal id As Int32) As String
        Dim ostringfunc As New iFunctions.cls_string
        desc = desc.Replace("<br>", " ").Replace("<BR>", " ")
        desc = desc.Replace("&", " and")
        desc = desc.Replace("\", "-")
        desc = desc.Replace("/", "-")
        ''  desc = desc.Replace(".", "")
        desc = desc.Replace("Ct.", "Carat")
        desc = ostringfunc.ClearHTMLTagsReturn(Trim(desc))
        desc = Trim(desc)
        desc = desc.Replace(" ", "-")
        desc = desc.Replace(".", "-")
        desc = desc.Replace("{", "")
        desc = desc.Replace(")", "")
        desc = desc.Replace(",", "-")
        desc = Regex.Replace(desc, "[-]+", "-")
        desc = desc.Replace("--", "-")
        desc = desc.Replace("..", ".")
        ''desc = desc.Replace
        desc += "-IDENHANCED" + id.ToString
        desc += ".html"
        Select Case plate
            Case 1
                Return "/diamond/" + desc
            Case 2
                Return "/gemstone/" + desc
            Case 3
                Return "/jewelry/" + desc

        End Select

        Return desc

        ''ostringfunc.ClearHTMLTagsReturn(Trim(desc).Replace("<br>", " ").Replace("<BR>", " ")).Replace(" ", "-").replace("--", "-") + "-ID" + oPlate._id.ToString.ToUpper
    End Function

End Class
