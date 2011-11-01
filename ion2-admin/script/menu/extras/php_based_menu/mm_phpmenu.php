<?php

/*

   Milonic DHTML Menu PHP Function Module  mm_phpmenu.php version 1.5 - January 22 2007
   This module is only compatible with the Milonic DHTML Menu version 5.62 or higher

   Copyright 2005 (c) Milonic Solutions Limited. All Rights Reserved.
   This is a commercial software product, please visit http://www.milonic.com/ for more information.

*/

$menuData="";

class mmenuStyle
{
	
	function createMenuStyle($styleName)
	{
		global $menuData;
		$styleArray=get_object_vars($this);
		$menuData.="with($styleName=new mm_style()){\n";
		
		foreach ($styleArray as $k => $v) 
		{
			if(ereg("color",$k))
			{
				if(substr($v,0,1)!="#" && is_numeric("0x".$v))$v="#".$v;
			}
			
			$menuData.= "$k=\"$v\";\n";
		}
   
		$menuData.= "}\n\n";
	}
}




class mMenu
{
	var $menuItems;
	function createMenu($menuName)
	{
		global $menuData;
		$menuArray=get_object_vars($this);

		$menuData.= "with(milonic=new menuname(\"$menuName\")){\n";
		$tempMenuItems="";
		foreach ($menuArray as $k => $v) 
		{
			global $menuData;
			if($k!="menuItems")
			{
				if($k=="style")
				{
					$menuData.= "$k=$v;\n";
				}
				else
				{
					$menuData.= "$k=\"$v\";\n";
				}
				
			}
			else
			{
				if($k=="menuItems")$tempMenuItems=$v;
			}
		}
   
   		$menuData.= $tempMenuItems."\n";
		$menuData.= "}\n\n";
	}
	
	
	function addItemFromText($itemText)
	{
		global $menuData;
		$this->menuItems.="aI(\"".$itemText . "\");\n";	
	}
	

	function addItemFromItem($menuItem)
	{
		global $menuData;
		$tempVar="";
		foreach ($menuItem as $k => $v) 
		{
			if(ereg("color",$k))
			{
				if(substr($v,0,1)!="#" && is_numeric("0x".$v))$v="#".$v;
			}			
			
			$tempVar.="$k=$v;";
		}
		$this->menuItems.="aI(\"".$tempVar . "\");\n";	
	}	
	
}


class mItem
{
	function addItemElement($mtype,$mval)
	{
		$this->$mtype=$mval;
	}
}



function drawMenuCode()
{
	global $menuVars,$menuCodeDrawn;
	if($menuCodeDrawn==0)
	{
		echo "
<script language=\"JavaScript\" src=\"$menuVars[pathToCodeFiles]$menuVars[file_milonicsrc]\" type=\"text/javascript\"></script>	
<script language=\"JavaScript\" src=\"$menuVars[pathToCodeFiles]$menuVars[file_mmenudom]\" type=\"text/javascript\"></script>	
		";
}
	flush();
	$menuCodeDrawn++;
}


$drawCount=0;
$menuCodeDrawn=0;

function drawMenus()
{
	global $menuData, $menuVars, $drawCount, $menuCodeDrawn, $mmMenu;
	if($menuCodeDrawn==0)drawMenuCode();
	echo "<script>\n";
	if($drawCount==0)
	{
		foreach ($menuVars as $k => $v) 
		{
			if($k!="pathToCodeFiles"&&$k!="file_milonicsrc"&&$k!="file_mmenudom"&&$k!="file_mmenuns4")
			{
				echo "_$k=$v;\n";
			}
		}
	}
	echo $menuData;
	echo "drawMenus();\n";
	echo "</script>\n";	
	$drawCount++;
	$menuData="";
	$mmMenu=null;
	flush();
}


function commitMenus()
{
	drawMenuCode();
	drawMenus();
}





function runquery($query)
{
	global $adminEmail,$sendErrorReports;
	
	if (!($qry = mysql_query($query))) 
	{ 
		$hostname=gethostbyaddr($_SERVER[REMOTE_ADDR]);	
		echo "<br> MySQL Error - " . mysql_errno() . ": " . mysql_error() . "<br>"; 
		$mailbody = "
		IP Addr: $_SERVER[REMOTE_ADDR]
		Browser: $_SERVER[HTTP_USER_AGENT]
		
		Page: $_SERVER[SCRIPT_FILENAME]?$_SERVER[QUERY_STRING]
		Date: " . date("D F j, Y, G:i:s") . "
		
		Host: $hostname
		Server: $_SERVER[HTTP_HOST]
		
		Referer: $_SERVER[HTTP_REFERER]			
		
				
		MySQL Error - " . mysql_errno() . ": " . mysql_error() ."
		
		\n\n
		----------------------------------------
		Query: $query
		----------------------------------------";
		$headers = "From: datamenu1@milonic.com";
		$subject = "Milonic Data Menu Error";
		if($sendErrorReports)mail($adminEmail, $subject, $mailbody, $headers);
	}
	return $qry;
}

function doquery($query)
{
	global $adminEmail,$sendErrorReports;

	if (!($qry = mysql_query($query))) 
	{ 
		$hostname=gethostbyaddr($_SERVER['REMOTE_ADDR']);
		echo "<br> MySQL Error - " . mysql_errno() . ": " . mysql_error() . "<br>"; 
		$mailbody = "
		IP Addr: $_SERVER[REMOTE_ADDR]
		Browser: $_SERVER[HTTP_USER_AGENT]
		
		Page: $_SERVER[SCRIPT_FILENAME]?$_SERVER[QUERY_STRING]
		Date: " . date("D F j, Y, G:i:s") . "
		
		Host: $hostname
		Server: $_SERVER[HTTP_HOST]
		
		Referer: $_SERVER[HTTP_REFERER]


		MySQL Error - " . mysql_errno() . ": " . mysql_error() ."
		
		\n\n
		----------------------------------------
		Query: $query
		----------------------------------------";
		$headers = "From: datamenu1@milonic.com";
		$subject = "Milonic Data Menu Error";
		if($sendErrorReports)mail($adminEmail, $subject, $mailbody, $headers);
	}
	else
	{
		if (!ereg("^update", $query)) return mysql_fetch_array($qry);
	}
}


function buildMySQLMenu($menuProjectID)
{
	global $table_prefix, $menuVars, $dbHost, $dbUser, $dbPasswd, $dbName;
	
	if (!mysql_pconnect($dbHost,$dbUser,$dbPasswd)) 
	{
		die("Couldn't connect to the database server $MySQLServer<br><br>");
	}
	else
	{
		mysql_select_db($dbName);
	}
	
	// Properties
	
	$query="select * from ".$table_prefix."projects where projectid = $menuProjectID";
	$ar=doquery($query);
	

	
	if(!$ar)die("Could not find menu project");
	
	$menuVars['menuCloseDelay']=$ar['menuCloseDelay'];
	$menuVars['menuOpenDelay']=$ar['menuOpenDelay'];
	$menuVars['subOffsetTop']=$ar['subOffsetTop'];
	$menuVars['subOffsetLeft']=$ar['subOffsetLeft'];

	
	$query="select distinct(styleid) from ".$table_prefix."menus where projectid = $menuProjectID";
	$sqry=runquery($query);
	
	$styles=array();
	
	while ($sar = mysql_fetch_array($sqry))
	{	
		$query="select * from ".$table_prefix."styles where styleid=$sar[styleid]";
		$ar=doquery($query);
		
		$mmStyle=new mmenuStyle();
		$sysCtr=0;
		foreach ($ar as $k => $v) 
		{
			if($sysCtr==1)$sysCtr=0; else $sysCtr=1;
			if($sysCtr==0)
			{
				if($k!="styleid" && $k!="name" && $v)$mmStyle->$k=$v;
			}
		}
	
		$mmStyle->createMenuStyle($ar['name']);
		$styles[$sar['styleid']]=$ar['name'];
	}	
	
	
	
	
	
	
	$query="select * from ".$table_prefix."menus where projectid = $menuProjectID";
	$mqry=runquery($query);
	
	while ($mar = mysql_fetch_array($mqry))
	{
		$sysCtr=0;
		$mmMenu=new mMenu();	
		foreach ($mar as $k => $v) 
		{
			if($sysCtr==1)$sysCtr=0; else $sysCtr=1;
			if($sysCtr==0)
			{
				if(($k!="menuid" && $k!="projectid" && $k!="name") && $v)
				{
					if($k=="styleid")
					{
						$k="style";
						$v=$styles[$mar['styleid']];
					}
		
					$mmMenu->$k=$v;
				}
			}
		}	
	
		
		$sysCtr=0;
		$query="select * from ".$table_prefix."items where menuid=$mar[menuid]";
		$iqry=runquery($query);
		while ($iar = mysql_fetch_array($iqry))
		{
			$mmItem = new mItem();
			$andy=0;
			foreach ($iar as $k => $v) 
			{
				if($sysCtr==1)$sysCtr=0; else $sysCtr=1;
	
				if($sysCtr==0)
				{
					if(($k!="menuid" && $k!="itemid") && $v)
					{
						$mmItem->addItemElement($k, $v);
						
					}
	
				}
				
				
			}	
			$mmMenu->addItemFromItem($mmItem);
		}
	
		
				
	$mmMenu->createMenu($mar['name']);
	}

	commitMenus();
}

?>