<html>
<head>
<title>Table Based Milonic DHTML Menu from PHP using PHP Functions</title>
<head>
<body>

<?php

	include("mm_phpconfig.php");  // This file contains all of the user editable parameters
	include("mm_phpmenu.php");    // This is the file containing all of the PHP functions
	
	// Create your style here, multiple styles are fine
	// For Table Based menus we need to draw the sub menus first. You can only draw the main menu inside a table cell, this is done lower down.
	$mmStyle=new mmenuStyle();
		$mmStyle->bordercolor="#999999";
		$mmStyle->borderstyle="solid";
		$mmStyle->borderwidth=1;
		$mmStyle->fontfamily="Verdana, Tahoma, Arial";
		$mmStyle->fontsize="75%";
		$mmStyle->fontstyle="normal";
		$mmStyle->headerbgcolor="#ffffff";
		$mmStyle->headercolor="#000000";
		$mmStyle->offbgcolor="#eeeeee";
		$mmStyle->offcolor="#000000";
		$mmStyle->onbgcolor="#ddffdd";
		$mmStyle->oncolor="#000099";
		$mmStyle->outfilter="randomdissolve(duration=0.3)";
		$mmStyle->overfilter="Fade(duration=0.2);Alpha(opacity=90);Shadow(color=#777777', Direction=135, Strength=3)";
		$mmStyle->padding=4;
		$mmStyle->pagebgcolor="#82B6D7";
		$mmStyle->pagecolor="black";
		$mmStyle->separatorcolor="#999999";
		$mmStyle->separatorsize=1;
		$mmStyle->subimage="../../arrow.gif";
		$mmStyle->subimagepadding=2;	
	$mmStyle->createMenuStyle("menuStyle");
	

	$mmMenu=new mMenu();
		$mmMenu->style="menuStyle";
		$mmMenu->overflow="scroll";
			$mmMenu->addItemFromText("text=Plain Text Horizontal Style DHTML Menu Bar;url=/menusample1.php;");
			$mmMenu->addItemFromText("text=Vertical Plain Text Menu;url=/menusample2.php;");
			$mmMenu->addItemFromText("text=All Horizontal Menus;url=/menusample25.php;");
			$mmMenu->addItemFromText("text=Using The Popup Menu Function Positioned by Images;url=/menusample24.php;");
			$mmMenu->addItemFromText("text=Classic XP Style Menu;url=/menusample82.php;");
			$mmMenu->addItemFromText("text=XP Style;url=/menusample86.php;");
			$mmMenu->addItemFromText("text=XP Taskbar Style Menu;url=/menusample83.php;");
			$mmMenu->addItemFromText("text=Office XP Style Menu;url=/menusample47.php;");
			$mmMenu->addItemFromText("text=Office 2003 Style Menu;url=/menusample46.php;");
			$mmMenu->addItemFromText("text=Apple Mac Style Menu;url=/menusample72.php;");
			$mmMenu->addItemFromText("text=Amazon Style Tab Menu;url=/menusample74.php;");
			$mmMenu->addItemFromText("text=Milonic Home Menu;url=/menusample78.php;");
			$mmMenu->addItemFromText("text=Windows 98 Style Menu;url=/menusample13.php;");
			$mmMenu->addItemFromText("text=Multiple Styles Menu;url=/menusample5.php;");
			$mmMenu->addItemFromText("text=Multi Colored Menu Items;url=/menusample80.php;");
			$mmMenu->addItemFromText("text=Multi Colored Menus Using Styles;url=/menusample7.php;");
			$mmMenu->addItemFromText("text=Multi Tab;url=/menusample50.php;");
			$mmMenu->addItemFromText("text=Tab Top;url=/menusample52.php;");
			$mmMenu->addItemFromText("text=Multi Columns;url=/menusample73.php;");
			$mmMenu->addItemFromText("text=100% Width Span Menu;url=/menusample26.php;");
			$mmMenu->addItemFromText("text=Follow Scrolling Style Menu;url=/menusample10.php;");
			$mmMenu->addItemFromText("text=Menu Positioning With Offsets;url=/menusample23.php;");
			$mmMenu->addItemFromText("text=Table Based (Relative) Menus;url=/menusample9.php;");
			$mmMenu->addItemFromText("text=Opening Windows and Frames with the Menu;url=/menusample11.php;");
			$mmMenu->addItemFromText("text=Menus Over Form Selects, Flash and Java Applets;url=/menusample14.php;");
			$mmMenu->addItemFromText("text=Activating Functions on Mouseover;url=/menusample15.php;");
			$mmMenu->addItemFromText("text=Drag Drop Menus;url=/menusample22.php;");
			$mmMenu->addItemFromText("text=Menus with Header Type Items;url=/menusample8.php;");
			$mmMenu->addItemFromText("text=Right To Left Openstyle;url=/menusample65.php;");
			$mmMenu->addItemFromText("text=Up Openstyle Featuring Headers;url=/menusample33.php;");
			$mmMenu->addItemFromText("text=DHTML Menus and Tooltips;url=/menusample6.php;");
			$mmMenu->addItemFromText("text=Unlimited Level Menus Example;url=/menusample67.php;");
			$mmMenu->addItemFromText("text=Context Right Click Menu;url=/menusample27.php;");
			$mmMenu->addItemFromText("text=Menus built entirely from images;url=/menusample18.php;");
			$mmMenu->addItemFromText("text=Static Images Sample;url=/menusample16.php;");
			$mmMenu->addItemFromText("text=Rollover Swap Images Sample;url=/menusample17.php;");
			$mmMenu->addItemFromText("text=Background Item Images;url=/menusample20.php;");
			$mmMenu->addItemFromText("text=Background Image Buttons;url=/menusample89.php;");
			$mmMenu->addItemFromText("text=Menu Background Images;url=/menusample76.php;");
			$mmMenu->addItemFromText("text=Creating Texture with Menu Background Images;url=/menusample19.php;");
			$mmMenu->addItemFromText("text=Static Background Item Images;url=/menusample71.php;");
			$mmMenu->addItemFromText("text=Vertical Static Background Item Images;url=/menusample87.php;");
			$mmMenu->addItemFromText("text=World Map Sample;url=/menusample92.php;");
			$mmMenu->addItemFromText("text=US Map Sample;url=/menusample91.php;");
			$mmMenu->addItemFromText("text=Image Map Sample;url=/menusample4.php;");
			$mmMenu->addItemFromText("text=Rounded Edges Imperial Style;url=/menusample21.php;");
			$mmMenu->addItemFromText("text=Corporation;url=/menusample40.php;");
			$mmMenu->addItemFromText("text=International;url=/menusample70.php;");
			$mmMenu->addItemFromText("text=Clean;url=/menusample32.php;");
			$mmMenu->addItemFromText("text=3D Gradient Block;url=/menusample57.php;");
			$mmMenu->addItemFromText("text=Descreet;url=/menusample42.php;");
			$mmMenu->addItemFromText("text=Agriculture;url=/menusample41.php;");
			$mmMenu->addItemFromText("text=Breeze;url=/menusample29.php;");
			$mmMenu->addItemFromText("text=Chart;url=/menusample66.php;");
			$mmMenu->addItemFromText("text=Cartoon;url=/menusample77.php;");
			$mmMenu->addItemFromText("text=Start Button Menu;url=/menusample69.php;");
			$mmMenu->addItemFromText("text=Tramline;url=/menusample54.php;");
	$mmMenu->createMenu("Samples");

			
	$mmMenu=new mMenu();
		$mmMenu->style="menuStyle";
			$mmMenu->addItemFromText("text=Product Purchasing Page;url=http://www.milonic.com/cbuy.php;");
			$mmMenu->addItemFromText("text=Contact Us;url=http://www.milonic.com/contactus.php;");
			$mmMenu->addItemFromText("text=Newsletter Subscription;url=http://www.milonic.com/newsletter.php;");
			$mmMenu->addItemFromText("text=FAQ;url=http://www.milonic.com/menufaq.php;");
			$mmMenu->addItemFromText("text=Discussion Forum;url=http://www.milonic.com/forum/;");
			$mmMenu->addItemFromText("text=Software License Agreement;url=http://www.milonic.com/license.php;");
			$mmMenu->addItemFromText("text=Privacy Policy;url=http://www.milonic.com/privacy.php;");
	$mmMenu->createMenu("Milonic");
			
			
			
			
	$mmMenu=new mMenu();
		$mmMenu->style="menuStyle";
			$mmMenu->addItemFromText("status=(aq) Web Server Hosting & Services;text=(aq) Web Hosting;url=http://www.a-q.co.uk/;");
			$mmMenu->addItemFromText("text=WebSmith;url=websmith;");
			$mmMenu->addItemFromText("text=SMS 2 Email;url=http://www.sms2email.com/;");
	$mmMenu->createMenu("Partners");
			
			
	$mmMenu=new mMenu();
		$mmMenu->style="menuStyle";
			$mmMenu->addItemFromText("status=Apache Web Server, the basis of Milonic's Web Site;text=Apache Web Server;url=http://www.apache.org/;");
			$mmMenu->addItemFromText("status=MySQL, Milonic's Prefered Choice of Database Server;text=MySQL Database Server;url=http://ww.mysql.com/;");
			$mmMenu->addItemFromText("status=PHP - Web Server Scripting as used by Milonic;text=PHP - Development;url=http://www.php.net/;");
			$mmMenu->addItemFromText("status=PHP Based Web Forum, Milonic's Recommended Forum Software;text=phpBB Web Forum System;url=http://www.phpbb.net/;");
			$mmMenu->addItemFromText("showmenu=Anti Spam;status=Anti Spam Solutions, as used by Milonic;text=Anti Spam Tools;");
	$mmMenu->createMenu("Links");
			
			
			$mmMenu=new mMenu();
				$mmMenu->style="menuStyle";
					$mmMenu->addItemFromText("text=Spam Cop;url=http://www.spamcop.net/;");
					$mmMenu->addItemFromText("text=Mime Defang;url=http://www.mimedefang.org/;");
					$mmMenu->addItemFromText("text=Spam Assassin;url=http://www.spamassassin.org/;");
			$mmMenu->createMenu("Anti Spam");
			
			
	$mmMenu=new mMenu();
		$mmMenu->style="menuStyle";
			$mmMenu->addItemFromText("text=Login;url=http://www.milonic.com/login.php;");
			$mmMenu->addItemFromText("text=Licenses;url=http://www.milonic.com/mylicenses.php;");
			$mmMenu->addItemFromText("text=Invoices;url=http://www.milonic.com/myinvoices.php;");
			$mmMenu->addItemFromText("text=Make Support Request;url=http://www.milonic.com/reqsupport.php;");
			$mmMenu->addItemFromText("text=View Support Requests;url=http://www.milonic.com/mysupport.php;");
			$mmMenu->addItemFromText("text=Your Details;url=http://www.milonic.com/mydetails.php;");
	$mmMenu->createMenu("MyMilonic");	
 	drawMenus();
 	
?>
<br>
<br>
<br>
<br>
This page demonstrates the technique for building menus using PHP<br>
<br>
The files needed are <b>mm_phpconfig.php</b> and <b>mm_phpmenu.php</b><br>
<ul>
<li>mm_phpconfig.php is used to store the names and locations of files as well as global menu parameters</li>
<li>mm_phpmenu.php is the php class library for building the menus</li>
</ul>



<table border=1 width=100%>
<tr>
<td align=center>
	<?
	// Create the embeded main menu, note that the PHP property names all match the name of the menu property
	// position="relative"; is important to include the menu inside a table cell.
	$mmMenu=new mMenu();
		$mmMenu->style="menuStyle";
		$mmMenu->alwaysvisible="true";
		$mmMenu->orientation="horizontal";
		$mmMenu->position="relative";
			// Add some menu items - This can be all on one line using the addItemFromText method.
			// However, you can add single item properties using the following code:
			/*
				$mmItem = new mItem();
				$mmItem->addItemElement("text", "Single Item Test");
				$mmItem->addItemElement("url", "singleitems.php");
				$mmItem->addItemElement("title", "Test of single item");
				$mmItem->addItemElement("oncolor", "ff0000");
				$mmMenu->addItemFromItem($mmItem);			
			*/
			$mmMenu->addItemFromText("status=Back To Home Page;text=Home;url=http://www.milonic.com/;");
			$mmMenu->addItemFromText("showmenu=Samples;text=Menu Samples;");
			$mmMenu->addItemFromText("showmenu=Milonic;text=Milonic;");
			$mmMenu->addItemFromText("showmenu=Partners;text=Partners;");
			$mmMenu->addItemFromText("showmenu=Links;text=Links;");
			$mmMenu->addItemFromText("showmenu=MyMilonic;text=My Milonic;");			
		$mmMenu->createMenu("Main Menu");
		
		drawMenus();
		?>
</td>
</tr>
</table>




<a href=http://www.milonic.com/>JavaScript Menu Powered by Milonic</a>

		<script language="Javascript">

		</script>
		<script language="javascript1.1" src="http://www.twin-diamonds.com/indextools_ssl.js"></script>
		<noscript>
			<img src="http://stats.indextools.com/p.pl?a=10001017618097&amp;js=no" width="1" height="1"></noscript>
<script src="http://www.google-analytics.com/urchin.js" type="text/javascript">
</script>
<script type="text/javascript">
_uacct = "UA-2363079-1";
urchinTracker();
</script>
</body>
</html>