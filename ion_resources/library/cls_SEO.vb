Public Class cls_SEO

	Public _error_number As Int32
	Public _error_source As String
	Public _error_description As String

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
		Me._type = 0		  '-- 1=diamonds 2=fancy-diamonds 3=emeralds 4=sapphire 5=ruby 6=semi-precious 7=jewelry
	End Sub


	Public Function getSEO_home(ByVal cWorkingDomain As String) As Boolean
		On Error GoTo ErrorHandler

		'--- Strip WWW from domain
		cWorkingDomain = Me.stripwww(cWorkingDomain)


		'---
		Select Case cWorkingDomain

			Case "diamonds-diamonds.com"
				Me._type = 1
				Me._title = "diamond, diamonds, loose diamond, wholesale diamond, engagement ring, from DIAMONDS-DIAMONDS.COM"
				Me._keywords = "diamond, diamonds, loose diamonds, wholesale diamonds, diamond engagement ring"
				Me._description = "For an incomparable selection of fine jewelry, high quality diamonds and Fancy diamonds, shop our site. Also diamond jewelry, diamond rings, nacklace, earrings"
				Me._abstract = "Diamond jewelry, gemstones, sapphires, rubies, emeralds and more available at great prices from DIAMONDS-DIAMONDS.COM. Select from our wide variety of jewelry, including rings, bracelets and necklaces"

			Case "cyber-diamond.com"
				Me._type = 1
				Me._title = "loose diamond, diamond, diamonds, diamond ring, wholesale diamond, cheap diamonds, from CYBER-DIAMONDS.COM"
				Me._keywords = "loose diamonds, diamonds, diamond, diamond ring, wholesale diamonds, cheap diamonds"
				Me._description = "For an incomparable selection of fine jewelry, high quality loose diamonds and loose Fancy diamonds, shop our site. Also diamond jewelry, diamond rings, nacklace, stud earrings"
				Me._abstract = "Diamond jewelry, loose diamonds, sapphires, rubies, emeralds and more available at great prices from CYBER-DIAMONDS.COM. Select from our wide variety of jewelry, including rings, bracelets and necklaces"

			Case "world-diamond.com"
				Me._type = 1
				Me._title = "diamonds, diamond, wholesale diamond, gemstone jewelry, fancy diamond, from WORLD-DIAMOND.COM"
				Me._keywords = "diamond, diamonds, wholesale diamond, gemstone jewelry, jewelry, fancy diamonds"
				Me._description = "For an incomparable selection of fine jewelry, high quality diamonds and Fancy diamonds, shop our site, diamond jewelry. Also diamond rings, nacklace, earrings"
				Me._abstract = "Diamond earrings, wholesale diamonds, sapphires, rubies, emeralds and more available at great prices from WORLD-DIAMOND.COM. Select from our wide variety of jewelry, including rings, bracelets and necklaces"

			Case "cyber-jewel.com"
				Me._type = 7
				Me._title = "wholesale diamond, diamond jewelry, diamond, diamond ring, engagement ring, at CYBER-JEWEL.COM"
				Me._keywords = "wholesale diamond, diamond jewelry, diamonds, diamond ring, engagement ring, fancy diamond"
				Me._description = "For an incomparable selection of fine jewelry, high quality diamonds and Fancy diamonds as wholesale prices, shop our site. Also diamond jewelry, diamond rings, nacklace, earrings"
				Me._abstract = "Diamond rings, gemstones, sapphires, rubies, emeralds and more available at great prices from CYBER-JEWEL.COM. Select from our wide variety of jewelry, including rings, bracelets and necklaces"

			Case "1diamond1.com"
				Me._type = 1
				Me._title = "jewelry, jewelry gift, diamond ring, diamond jewelry, fine jewelry, from 1DIAMOND1.COM "
				Me._keywords = "jewelry, jewelry gift, diamond ring, diamond jewelry, fine jewelry, pink diamond rings"
				Me._description = "For an incomparable selection of fine jewelry, high quality diamonds and Fancy diamonds, shop our site. Also engagement jewelry, diamond rings, nacklaces, stud earrings"
				Me._abstract = "Diamond jewelry, gemstones, sapphires, rubies, emeralds and more available at great prices from 1DIAMOND1.COM. Select from our wide variety of jewelry, including rings, bracelets and necklaces"

			Case "1st-diamond.com"
				Me._type = 2
				Me._title = "fancy diamonds, black diamond, blue diamond, diamond, from 1ST-DIAMOND.COM"
				Me._keywords = "fancy diamond, fancy colored diamond, pink diamond, blue diamond, diamonds, diamond, black diamond, fine jewelry"
				Me._description = "For an incomparable selection of high quality diamonds and Fancy diamonds, shop our site. Also engagement jewelry, diamond rings, nacklaces, stud earrings"
				Me._abstract = "Fancy Diamond jewelry, fancy diamonds, sapphires, rubies, emeralds and more available at great prices from 1ST-DIAMOND.COM. Select from our wide variety of jewelry, including engagement rings, bracelets and necklaces"

			Case "emerald4life.com"
				Me._type = 3
				Me._title = "emerald, emerald ring, gem stone, emeralds, columbian emeralds, emerald jewelry, from EMERALD4LIFE.COM "
				Me._keywords = "emerald, emeralds, emerald ring, gemstones, columbian emeralds, emerald gems, loose emeralds"
				Me._description = "For an incomparable selection of high quality Emeralds and Emerald Jewelry, shop our site. Also engagement jewelry, diamond rings, nacklaces, stud earrings"
				Me._abstract = "emerald jewelry, gemstones, sapphires, rubies, emeralds and more available at great prices from EMERALD4LIFE.COM. Select from our wide variety of jewelry, including rings, earrings and necklaces"

			Case "sapphire4life.com"
				Me._type = 4
				Me._title = "sapphire, sapphire ring, sapphires, pink sapphires, sapphire gems, white sapphire, from SAPPHIRE4LIFE.COM"
				Me._keywords = "sapphire, sapphires, sapphire ring, sapphire jewelry, gem stone,pink sapphire, sapphire ring, ruby sapphire, sapphire jewelry"
				Me._description = "For an incomparable selection of high quality Sapphires and Sapphire Jewelry, shop our site. Also engagement jewelry, diamond rings, nacklaces, stud earrings"
				Me._abstract = "Sapphire jewelry, gemstones, sapphires, rubies, emeralds and more available at great prices from SAPPHIRE4LIFE.COM. Select from our wide variety of jewelry, including rings, bracelets and necklaces"

			Case "ruby4life.com"
				Me._type = 5
				Me._title = "ruby, ruby ring, rubies, burma rubies, gemstones, ruby gemstone, ruby jewelry, from RUBY4LIFE.COM"
				Me._keywords = "ruby, rubies, ruby ring, ruby jewelry, gem stone, earring, ring, ruby earring, red ruby"
				Me._description = "For an incomparable selection of high quality Rubies and Ruby Jewelry, shop our site. Also engagement jewelry, diamond rings, nacklaces, stud earrings"
				Me._abstract = "Diamond jewelry, gemstones, sapphires, rubies, emeralds and more available at great prices from RUBY4LIFE.COM. Select from our wide variety of jewelry, including engagementrings, earrings and necklaces"

			Case "aaa-diamond.com"
				Me._type = 5
				Me._title = "ruby, rubies, ruby ring, ruby jewelry, gem stone, ruby earring, ring, at AAA-DIAMOND.COM "
				Me._keywords = "ruby, rubies, ruby ring, ruby jewelry, gem stone, earring, ring, ruby earring, red ruby"
				Me._description = "For an incomparable selection of high quality Rubies and Ruby Jewelry, shop our site. Also engagement jewelry, diamond rings, nacklaces, stud earrings"
				Me._abstract = "Ruby jewelry, gemstones, sapphires, rubies, emeralds and more available at great prices from AAA-DIAMOND.COM. Select from our wide variety of jewelry, including rings, earrings and necklaces"

			Case "aaaaadiamond.com"
				Me._type = 4
				Me._title = "sapphire, sapphires, sapphire ring, sapphire jewelry, gemstone, from AAAAADIAMOND.COM"
				Me._keywords = "sapphire, sapphires, sapphire ring, sapphire jewelry, gem stone,pink sapphire, sapphire ring, ruby sapphire, sapphire jewelry"
				Me._description = "For an incomparable selection of high quality Sapphires and Sapphire Jewelry, shop our site. Also engagement jewelry, diamond rings, rings, stud earrings"
				Me._abstract = "Sapphire jewelry, gemstones, sapphires, rubies, emeralds and more available at great prices from AAAAADIAMOND.COM. Select from our wide variety of jewelry, including engagement rings, bracelets and necklaces"

			Case "carat-diamond.com"
				Me._type = 3
				Me._title = "emerald, emeralds, emerald ring, emerald jewelry, gemstone, earring, from CARAT-DIAMOND.COM"
				Me._keywords = "emerald, emeralds, emerald ring, emerald jewelry, gemstone, earrings, stud earrings"
				Me._description = "For an incomparable selection of high quality Emeralds and Emerald Jewelry, shop our site. Also engagement jewelry, diamond rings, earrings, stud earrings"
				Me._abstract = "Emerlad jewelry, gemstones, sapphires, rubies, emeralds and more available at great prices from CARAT-DIAMOND.COM. Select from our wide variety of jewelry, including rings, bracelets and earrings"

			Case "diam4you.com"
				Me._type = 7
				Me._title = "diamond ring, emerald ring, sapphire ring, ring, earring, fancy diamond, from DIAM4YOU.COM"
				Me._keywords = "diamond rings, emerald rings, sapphire rings, gemstone ring, rings, earrings, fancy diamonds"
				Me._description = "For an incomparable selection of fine jewelry, high quality diamonds and Fancy diamonds, shop our site. Also diamond jewelry, diamond rings, broaches, earrings"
				Me._abstract = "Diamond jewelry, gemstones, sapphires, rubies, emeralds and more available at great prices from DIAM4YOU.COM. Select from our wide variety of jewelry, including rings, earrings and necklaces"

			Case "diamond1000.com"
				Me._type = 7
				Me._title = "jewelry, jewelry store, diamond jewelry, ruby jewelry, emerald jewelry, wholesale jewelry, from DIAMOND1000.COM"
				Me._keywords = "jewelry, jewellery, diamond jewely, ruby jewelry, emerald jewelry, sapphire jewelry"
				Me._description = "For an incomparable selection of fine jewelry, high quality diamonds and Fancy diamonds, shop our site. Also diamond jewelry, diamond rings, nacklace, stud earrings"
				Me._abstract = "Diamond jewelry, gemstones, sapphires, rubies, emeralds and more available at great prices from CYBER-DIAMONDS.COM. Select from our wide variety of jewelry, including engagement rings, bracelets and necklaces"

			Case "diamond-rush.com"
				Me._type = 3
				Me._title = "emerald, emerald ring, gemstones, columbian emerald, emerald jewelry, from DIAMOND-RUSH.COM"
				Me._keywords = "emeralds, emerald ring, gemstones, columbian emerald, emerald gems"
				Me._description = "For an incomparable selection of high quality Emeralds and Emerald Jewelry, shop our site. Also engagement jewelry, diamond rings, earrings, stud earrings"
				Me._abstract = "Emerald jewelry, gemstones, sapphires, rubies, emeralds and more available at great prices from DIAMOND1000.COM. Select from our wide variety of jewelry, including rings, bracelets and earrings"

			Case "diamonds-exchange.com"
				Me._type = 4
				Me._title = "sapphire, sapphire ring, sapphire earring, sapphire jewelry, at DIAMONDS-EXCHANGE.COM"
				Me._keywords = "sapphires, sapphire, sapphire earring, sapphire jewelry, sapphire gemstone, blue sapphire"
				Me._description = "For an incomparable selection of high quality Sapphires and Sapphire Jewelry, shop our site. Also engagement jewelry, diamond rings, nacklaces, stud earrings"
				Me._abstract = "Sapphire jewelry, gemstones, sapphires, rubies, emeralds and more available at great prices from DIAMONDS-EXCHANGE.COM. Select from our wide variety of jewelry, including earrings, bracelets and necklaces"

			Case "your-diamond.com"
				Me._type = 5
				Me._title = "ruby, rubies, ruby ring, ruby jewelry, ruby earring, at YOUR-DIAMOND.COM"
				Me._keywords = "ruby, rubies, ruby ring, ruby jewelry, ruby earring, ruby gemstone"
				Me._description = "For an incomparable selection of high quality Rubies and Ruby Jewelry, shop our site. Also engagement jewelry, diamond rings, nacklaces, stud earrings"
				Me._abstract = "Ruby jewelry, gemstones, sapphires, rubies, emeralds and more available at great prices from YOUR-DIAMOND.COM. Select from our wide variety of jewelry, including engagement rings, bracelets and necklaces"

			Case "gem-deal.com"
				Me._type = 7
				Me._title = "jewelry, gemstone, deal, rings, earrings, necklaces, credit card deal, at GEM-DEAL.COM"
				Me._keywords = "jewelry deal, gemstone deal, deal, rings, earrings, necklaces"
				Me._description = "For an incomparable selection of high quality Jewelry and Diamond Jewelry, shop our site. Also engagement jewelry, diamond rings, earrings, stud earrings"
				Me._abstract = "Discount jewelry, gemstones, sapphires, rubies, emeralds and more available at great prices from GEM-DEAL.COM. Select from our wide variety of jewelry, including rings, earrings and necklaces"

			Case "sapphire4you.com"
				Me._type = 4
				Me._title = "sapphire, sapphire ring, sapphires, pink sapphires, sapphire gems, white sapphire, from SAPPHIRE4LIFE.COM"
				Me._keywords = "sapphire, sapphires, sapphire ring, sapphire jewelry, gem stone,pink sapphire, sapphire ring, ruby sapphire, sapphire jewelry"
				Me._description = "For an incomparable selection of high quality Sapphires and Sapphire Jewelry, shop our site. Also engagement jewelry, diamond rings, nacklaces, stud earrings"
				Me._abstract = "Sapphire jewelry, gemstones, sapphires, rubies, emeralds and more available at great prices from SAPPHIRE4LIFE.COM. Select from our wide variety of jewelry, including rings, bracelets and necklaces"

			Case "ruby4you.com"
				Me._type = 5
				Me._title = "ruby, ruby ring, rubies, burma rubies, gemstones, ruby gemstone, ruby jewelry, from RUBY4LIFE.COM"
				Me._keywords = "ruby, rubies, ruby ring, ruby jewelry, gem stone, earring, ring, ruby earring, red ruby"
				Me._description = "For an incomparable selection of high quality Rubies and Ruby Jewelry, shop our site. Also engagement jewelry, diamond rings, nacklaces, stud earrings"
				Me._abstract = "Diamond jewelry, gemstones, sapphires, rubies, emeralds and more available at great prices from RUBY4LIFE.COM. Select from our wide variety of jewelry, including engagementrings, earrings and necklaces"

			Case "emerald4you.com"
				Me._type = 3
				Me._title = "emerald, emerald ring, gem stone, emeralds, columbian emeralds, emerald jewelry, from EMERALD4LIFE.COM "
				Me._keywords = "emerald, emeralds, emerald ring, gemstones, columbian emeralds, emerald gems, loose emeralds"
				Me._description = "For an incomparable selection of high quality Emeralds and Emerald Jewelry, shop our site. Also engagement jewelry, diamond rings, nacklaces, stud earrings"
				Me._abstract = "emerald jewelry, gemstones, sapphires, rubies, emeralds and more available at great prices from EMERALD4LIFE.COM. Select from our wide variety of jewelry, including rings, earrings and necklaces"

			Case Else
				Me._type = 4
				Me._title = "emerald, sapphire, ruby, diamond, fancy diamond, fine jewelry, from Twin-Diamonds.com"
				Me._keywords = "diamonds, diamond ring,diamond engagement ring, rubies, ruby, emerald, emrald, emeralds,sapphire ring,emerald ring,fancy diamonds,colored diamonds,gemstones, sapphires, saphire, jewelry, loose diamonds, semi-precious, semi-precious stones"
				Me._description = "Diamonds and gemstones, including emeralds, sapphires and rubies, available from Twin-Diamonds.com. Browse our wide selection of diamond jewelry and gemstone jewelry"
				Me._abstract = "Diamond jewelry, gemstones, sapphires, rubies, emeralds and more available at great prices from Twin-Diamonds.com. Select from our wide variety of jewelry, including rings, bracelets and necklaces"

		End Select


		'--- Everything id OK *
		Return False
		Exit Function

ErrorHandler:

		'--- when object is called in external DLL
		Me._error_number = Err.Number
		Me._error_source = Err.Source
		Me._error_description = Err.Description
		Return True


	End Function

	Public Function getSEO_categories(ByVal cWorkingDomain As String, ByVal nPlate As Int16, ByVal nCategory As Int16) As Boolean
		On Error GoTo ErrorHandler

		'--- Strip WWW from domain
		cWorkingDomain = Me.stripwww(cWorkingDomain)


		'---
		Select Case nPlate

			Case 1			'- Diamonds
				Select Case nCategory
					Case 1					  '- Diamonds
						Me._type = 1
						Me._title = "diamond, diamonds, loose diamonds, diamond ring, diamond engagement ring, from Twin-Diamonds.com"
						Me._keywords = "loose diamond, diamond, diamond ring, diamond engagement ring, diamonds, diamond earrings, wholesale diamonds, diamond jewelry"
						Me._description = "Diamonds, including loose diamonds, diamond engagement rings and diamond earrings, available from Twin-Diamonds.com. Select from our wide range of diamond jewelry at great prices today."
						Me._abstract = "Diamond rings, loose diamonds, earrings and more diamond jewelry available from Twin-Diamonds.com. Wholesale diamonds at affordable prices from Twin-Diamonds.com"

					Case 2					  '- Fancy Diamonds
						Me._type = 2
						Me._title = "fancy diamond, fancy colored diamond, fancy yellow diamond, fancy color diamond, from Twin-Diamonds.com"
						Me._keywords = "fancy colored diamonds, fancy diamonds, fancy yellow diamond, fancy pink diamonds, blue diamonds fancy, natural fancy color diamond, fancy diamond black, dimonds, Dimonds,whole sale dimonds"
						Me._description = "Fancy diamonds, fancy colored diamonds, including fancy pink diamonds and fancy yellow diamonds, available from Twin-Diamonds.com. Browse our wide range of diamonds, fancy diamonds, blue diamonds and red diamonds."
						Me._abstract = "Fancy cut diamonds, including fancy blue diamond, available from Twin-Diamonds.com. Purchase a fancy diamond at wholesale prices. Wide stock of diamond jewelry and gemstones available."

				End Select


			Case 2			'-- Gemstones
				Select Case nCategory
					Case 3					  '- Rubies
						Me._type = 5
						Me._title = "ruby, rubies, ruby ring, loose rubies, ruby sapphire, ruby's, ruby red, ruby ring, ruby jewelry, from Twin-Diamonds.com"
						Me._keywords = "ruby, ruby and sapphire, rubies, ruby sapphire, ruby's, ruby red, ruby and saphire, ruby rings, loose rubies, ruby saphire, ruby ring, sapphire ruby, ruby jewelry, ruby pair, ruby set, ruby pear,orange ruby, brown ruby, red ruby, ruby engagement rings, rubi, ruby and sapphire"
						Me._description = "Rubies, including loose rubies, ruby rings and other ruby jewelry, available from Twin-Diamonds.com. Browse our wide variety of red rubies, loose rubies, ruby rings and ruby jewelry."
						Me._abstract = "Rubies, ruby rings, ruby earrings and loose rubies available from Twin-Diamonds.com. Select one of our rubies as a gift for any occasion."

					Case 4					  '- Sapphires
						Me._type = 4
						Me._title = "sapphire, sapphires, sapphire ring, blue sapphire, pink sapphires, loose sapphires, yellow sapphires, ceylon sapphires, from Twin-Diamonds.com"
						Me._keywords = "sapphire, sapphires, blue sapphires, pink sapphires, star sapphires, ceylon sapphires, white sapphires, loose sapphires, yellow sapphires, gemstones sapphires, buying sapphires, kashmir sapphires, not heated, sapphire rings, loose sapphires"
						Me._description = "Sapphires, including loose sapphires, sapphire rings and other sapphire jewelry, available from Twin-Diamonds.com. Browse our wide variety of blue sapphires, loose sapphires, sapphire rings and sapphire jewelry."
						Me._abstract = "Sapphire, including sapphire rings, sapphire engagement rings and more, available from Twin-Diamonds.com. Wide variety of sapphires including blue sapphires, pink and more."

					Case 5					  '- Emeralds
						Me._type = 3
						Me._title = "emerald, emeralds, emerald earring, loose emeralds, emerald jewelry, emeralds for sale, from Twin-Diamonds.com"
						Me._keywords = "emerald, emeralds, emerald rings, emrald, emerald jewelry, emerald cut diamonds, emerald greens, emerald engagement rings, emerald princess, emerald pendants, emeralds loose, emeralds pairs, emeralds sets ,emerald parcels, wholesale emeralds, emeraldgem, emerald bracelet, emerald princess"
						Me._description = "Emeralds, including loose emeralds, emerald rings and other emerald jewelry, available from Twin-Diamonds.com. Browse our wide variety of green emeralds, loose emeralds, emerald rings and emerald jewelry."
						Me._abstract = "Emerald rings, including emerald cut diamonds and emerald engagement rings, available at wholesale prices from Twin-Diamonds.com. Diamonds, sapphires, rubies and other jewelry also available."


					Case 6					  '- Semi-Precious
						Me._type = 6
						Me._title = "tanzanite, tsavorite, semi precious stones, semi precious stone, semi precious gemstones, from Twin-Diamonds.com"
						Me._keywords = "gemstones, precious gemstones, wholesale gemstones, ruby gemstones, gemstones wholesale, blue gemstones,opal gemstones"
						Me._description = "Semi precious stones, including Tanzanite rings and more Tsvorite jewelry, available from Twin-Diamonds.com at great prices. Wide range of Tanzanite and Alexandrite jewelry in different shapes and sizes"
						Me._abstract = "Tanzanite rings, including emerald cut Tsvorite and Tanzanite engagement rings, available at wholesale prices from Twin-Diamonds.com. Diamonds, sapphires, Alexandriet and other jewelry also available."

				End Select

			Case 3			'- Jewelry
				Select Case nCategory
					Case 7					  '- Jewelry
						Me._type = 7
						Me._title = "jewelry, gold jewelry, jewelry store, wholesale jewelry, fine jewelry, costume jewelry, from Twin-Diamonds.com"
						Me._keywords = "jewelry, body jewelry, jewelry stores, jewelry making, costume jewelry, jewelry store, gold jewelry, jewelry exchange, wholesale jewelry, fine jewelry, antique jewelry, diamond jewelry, wholesale jewelry"
						Me._description = "Jewelry, including fine jewelry such as ruby rings, sapphire rings and more, from Twin-Diamonds.com. Browse our jewelry store today and find wholesale jewelry at great prices."
						Me._abstract = "Jewelry, including antique jewelry and antique jewelry, available from Twin-Diamonds.com. Engagement rings, antique rings, three stone rings and more discount jewelry available at wholesale prices."

				End Select


			Case 11			'- New Items
				Me._type = 4
				Me._title = "hot item new, item jewelry new, special offer, special holiday offer,store special, from Twin-Diamonds.com"
				Me._keywords = "jewelry, body jewelry, jewelry stores, jewelry making, costume jewelry, jewelry store, gold jewelry, jewelry exchange, wholesale jewelry, fine jewelry, antique jewelry, diamond jewelry, wholesale jewelry"
				Me._description = "Jewelry, including fine jewelry such as ruby rings, sapphire rings and more, from Twin-Diamonds.com. Browse our jewelry store today and find wholesale jewelry at great prices."
				Me._abstract = "Jewelry, including antique jewelry and antique jewelry, available from Twin-Diamonds.com. Engagement rings, antique rings, three stone rings and more discount jewelry available at wholesale prices."

			Case 12			 '- Special Items
				Me._type = 4
				Me._title = "discount jewelry, specials wholesale prices, wholesale jewelry, discount sapphires, from Twin-Diamonds.com"
				Me._keywords = "Discount Sapphires, Specials wholesale prices, Jewelry Stores, jewelry, jewlery stores, wholesale jewelry, antique jewlerycostume jewelry, antique jewelry,jewellery, discount jewelry,engagement rings,engagment rings"
				Me._description = "Discount jewelry such as ruby rings, sapphire rings and more, from Twin-Diamonds.com. Browse our jewelry store today and find wholesale jewelry at great prices."
				Me._abstract = "discount, Emeralds, Sapphires and Rubies available from Twin-Diamonds.com. Engagement rings, antique rings, three stone rings and more discount jewelry available at wholesale prices."

			Case 13			 '- Search Result
				Me._type = 4
				Me._title = "discount jewelry, specials wholesale prices, diamonds, fancy diamonds, fine jewelry and gemstones, from Twin-Diamonds.com"
				Me._keywords = "diamonds,dimond,diamond rings,diamond engagement rings,rubies,ruby,emerald,emrald,emeralds,sapphire ring,emerald ring,fancy diamonds,colored diamonds,gemstones, sapphires,saphire,jewelry,loose diamonds,semi-precious,semi-precious stones"
				Me._description = "Diamonds and gemstones, including emeralds, sapphires and rubies, available from Twin-Diamonds.com. Browse our wide selection of diamond jewelry and gemstone jewelry"
				Me._abstract = "Diamond jewelry, gemstones, sapphires, rubies, emeralds and more available at great prices from Twin-Diamonds.com. Select from our wide variety of jewelry, including rings, bracelets and necklaces"

		End Select


		'--- Everything id OK *
		Return False
		Exit Function

ErrorHandler:

		'--- when object is called in external DLL
		Me._error_number = Err.Number
		Me._error_source = Err.Source
		Me._error_description = Err.Description
		Return True



	End Function

	Private Function get_SEOplate(ByVal nPlate As Int16) As Boolean
		On Error GoTo ErrorHandler


		'---
		Select Case nPlate

			Case 1			'- Diamonds


			Case 2			'- Gemstones


			Case 3			'- Jewelry

		End Select

		'--- Everything id OK *
		Return False
		Exit Function

ErrorHandler:

		'--- when object is called in external DLL
		Me._error_number = Err.Number
		Me._error_source = Err.Source
		Me._error_description = Err.Description
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


End Class
