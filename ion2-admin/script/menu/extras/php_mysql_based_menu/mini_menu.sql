#
# Table structure for table `mm_items`
#

CREATE TABLE `mm_items` (
  `itemid` int(11) NOT NULL auto_increment,
  `menuid` int(11) NOT NULL default '0',
  `text` text,
  `url` varchar(255) default NULL,
  `showmenu` varchar(40) default NULL,
  PRIMARY KEY  (`itemid`)
) TYPE=MyISAM AUTO_INCREMENT=50 ;

#
# Dumping data for table `mm_items`
#

INSERT INTO `mm_items` VALUES (1, 1, 'MILONIC', 'http://www.milonic.com', NULL);
INSERT INTO `mm_items` VALUES (2, 1, 'Sample Menus', NULL, 'Menu Samples');
INSERT INTO `mm_items` VALUES (3, 1, 'About Milonic', NULL, 'About Milonic');
INSERT INTO `mm_items` VALUES (4, 1, 'Partners', NULL, 'Partners');
INSERT INTO `mm_items` VALUES (5, 1, 'Links', NULL, 'Links');
INSERT INTO `mm_items` VALUES (6, 2, 'Horizontal Navigational Menu', NULL, NULL);
INSERT INTO `mm_items` VALUES (7, 2, 'Vertical Navigational Menu', '/menusample2.php', NULL);
INSERT INTO `mm_items` VALUES (8, 2, 'All Horizontal Menus', '/menusample25.php', NULL);
INSERT INTO `mm_items` VALUES (9, 2, 'Using the popup function Fixed Position', '/menusample3.php', NULL);
INSERT INTO `mm_items` VALUES (10, 2, 'Using the popup Positioned by Images', 'menusample24.php', NULL);
INSERT INTO `mm_items` VALUES (11, 2, 'Image Map Sample', 'menusample4.php', NULL);
INSERT INTO `mm_items` VALUES (12, 2, 'Multiple Styles', 'menusample5.php', NULL);
INSERT INTO `mm_items` VALUES (13, 2, 'Menus and Tool Tips', 'menusample6.php', NULL);
INSERT INTO `mm_items` VALUES (14, 2, 'Multiple Colored Menus', 'menusample7.php', NULL);
INSERT INTO `mm_items` VALUES (15, 2, 'Menu Items as Headers', 'menusample8.php', NULL);
INSERT INTO `mm_items` VALUES (16, 2, 'Windows XP Style Menus', 'menusample12.php', NULL);
INSERT INTO `mm_items` VALUES (17, 2, 'Windows 98 Style Menus', 'menusample13.php', NULL);
INSERT INTO `mm_items` VALUES (18, 2, 'Relative Positioning (Table Bound)', 'menusample9.php', NULL);
INSERT INTO `mm_items` VALUES (19, 2, 'Follow Scrolling', 'menusample10.php', NULL);
INSERT INTO `mm_items` VALUES (20, 2, 'Opening Windows & Frames', 'menusample11.php', NULL);
INSERT INTO `mm_items` VALUES (21, 2, 'Hiding DIVs when displaying menus', 'menusample14.php', NULL);
INSERT INTO `mm_items` VALUES (22, 2, 'Activating MouseOver & MouseOut Functions', 'menusample15.php', NULL);
INSERT INTO `mm_items` VALUES (23, 2, 'Dynamic Dragable Menus', 'menusample22.php', NULL);
INSERT INTO `mm_items` VALUES (24, 2, 'Positioning with screenposition & offsets', 'menusample23.php', NULL);
INSERT INTO `mm_items` VALUES (25, 2, '100% Width Span Menu', 'menusample26.php', NULL);
INSERT INTO `mm_items` VALUES (26, 2, 'Context Right Click Menu', 'menusample27.php', NULL);
INSERT INTO `mm_items` VALUES (27, 2, 'Static Images Sample', 'menusample16.php', NULL);
INSERT INTO `mm_items` VALUES (28, 2, 'Rollover/swap Images', 'menusample17.php', NULL);
INSERT INTO `mm_items` VALUES (29, 2, 'Menus built from images', 'menusample18.php', NULL);
INSERT INTO `mm_items` VALUES (30, 2, 'Images as Menu Backgrounds', 'menusample19.php', NULL);
INSERT INTO `mm_items` VALUES (31, 2, 'Background Menu Item Images', 'menusample20.php', NULL);
INSERT INTO `mm_items` VALUES (32, 3, 'Product Purchasing Page', 'http://www.milonic.com/cbuy.php', NULL);
INSERT INTO `mm_items` VALUES (33, 3, 'Contact Us', 'http://www.milonic.com/contactus.php', NULL);
INSERT INTO `mm_items` VALUES (34, 3, 'Newsletter Subscription', 'http://www.milonic.com/newsletter.php', NULL);
INSERT INTO `mm_items` VALUES (35, 3, 'FAQ', 'http://www.milonic.com/menufaq.php', NULL);
INSERT INTO `mm_items` VALUES (36, 3, 'Discussion Forum', 'http://www.milonic.com/forum/', NULL);
INSERT INTO `mm_items` VALUES (37, 3, 'Software License Agreement', 'http://www.milonic.com/license.php', NULL);
INSERT INTO `mm_items` VALUES (38, 3, 'Privacy Policy', 'http://www.milonic.com/privacy.php', NULL);
INSERT INTO `mm_items` VALUES (39, 4, '(aq) Web Hosting', 'http://www.a-q.co.uk/', NULL);
INSERT INTO `mm_items` VALUES (40, 4, 'SMS 2 Email', 'http://www.sms2email.com/', NULL);
INSERT INTO `mm_items` VALUES (41, 4, 'WebSmith', 'http://www.websmith.com/', NULL);
INSERT INTO `mm_items` VALUES (42, 5, 'Apache Web Server', 'http://www.apache.org/', NULL);
INSERT INTO `mm_items` VALUES (43, 5, 'MySQL Database Server', 'http://ww.mysql.com/', NULL);
INSERT INTO `mm_items` VALUES (44, 5, 'PHP - Development', 'http://www.php.net/', NULL);
INSERT INTO `mm_items` VALUES (45, 5, 'phpBB Web Forum System', 'http://www.phpbb.net/', NULL);
INSERT INTO `mm_items` VALUES (46, 5, 'Anti Spam Tools', '', 'antispam');
INSERT INTO `mm_items` VALUES (47, 6, 'Spam Cop', 'http://www.spamcop.net/', NULL);
INSERT INTO `mm_items` VALUES (48, 6, 'Mime Defang', 'http://www.mimedefang.org/', NULL);
INSERT INTO `mm_items` VALUES (49, 6, 'Spam Assassin', 'http://www.spamassassin.org/', NULL);

# --------------------------------------------------------

#
# Table structure for table `mm_menus`
#

CREATE TABLE `mm_menus` (
  `menuid` int(11) NOT NULL auto_increment,
  `projectid` int(11) NOT NULL default '0',
  `styleid` int(11) NOT NULL default '0',
  `name` varchar(40) NOT NULL default '',
  `alwaysvisible` tinyint(1) default NULL,
  `orientation` tinyint(1) default NULL,
  `overflow` varchar(20) default NULL,
  PRIMARY KEY  (`menuid`)
) TYPE=MyISAM AUTO_INCREMENT=7 ;

#
# Dumping data for table `mm_menus`
#

INSERT INTO `mm_menus` VALUES (1, 1, 1, 'Main Menu', 1, 1, NULL);
INSERT INTO `mm_menus` VALUES (2, 1, 1, 'Menu Samples', NULL, NULL, 'scroll');
INSERT INTO `mm_menus` VALUES (3, 1, 1, 'About Milonic', NULL, NULL, NULL);
INSERT INTO `mm_menus` VALUES (4, 1, 1, 'Partners', NULL, NULL, NULL);
INSERT INTO `mm_menus` VALUES (5, 1, 1, 'Links', NULL, NULL, NULL);
INSERT INTO `mm_menus` VALUES (6, 1, 1, 'AntiSpam', NULL, NULL, NULL);

# --------------------------------------------------------

#
# Table structure for table `mm_projects`
#

CREATE TABLE `mm_projects` (
  `projectid` int(11) NOT NULL auto_increment,
  `menuCloseDelay` int(11) NOT NULL default '500',
  `menuOpenDelay` int(11) NOT NULL default '150',
  `subOffsetTop` tinyint(1) NOT NULL default '0',
  `subOffsetLeft` tinyint(1) NOT NULL default '0',
  `name` varchar(100) default NULL,
  PRIMARY KEY  (`projectid`)
) TYPE=MyISAM AUTO_INCREMENT=2 ;

#
# Dumping data for table `mm_projects`
#

INSERT INTO `mm_projects` VALUES (1, 500, 150, 2, -3, 'Minimalist Menu');

# --------------------------------------------------------

#
# Table structure for table `mm_styles`
#

CREATE TABLE `mm_styles` (
  `styleid` int(11) NOT NULL auto_increment,
  `name` varchar(40) NOT NULL default '',
  `oncolor` varchar(6) default NULL,
  `onbgcolor` varchar(6) default NULL,
  `offcolor` varchar(6) default NULL,
  `offbgcolor` varchar(6) default NULL,
  `padding` tinyint(4) default NULL,
  `separatorsize` tinyint(4) default NULL,
  `borderwidth` tinyint(4) default NULL,
  `fontfamily` varchar(25) default NULL,
  `fontsize` varchar(6) default NULL,
  PRIMARY KEY  (`styleid`)
) TYPE=MyISAM AUTO_INCREMENT=2 ;

#
# Dumping data for table `mm_styles`
#

INSERT INTO `mm_styles` VALUES (1, 'miniStyle', 'FFFFFF', '4F8EB6', '000000', 'FFFFFF', 3, 1, 1, 'verdana', '10px');
    