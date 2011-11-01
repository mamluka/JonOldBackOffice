<?
/*
Milonic DHTML/PHP Menu Sitemap builder version 2.0 - September 1 2006
mm_dataminer.php
*/

//$globalValues=Array();
//$menus=Array();
//$styles=Array();
//$filedata="";


$dataRetrieved=0;
$_S=Array();
$_M=Array();
$_I=Array();

function extractStyleName($data)
{
	global $filedata;
	$pos=miner_getInnerStrpos($data, "(", "=");
	$text=substr($data,$pos[0]+1, $pos[1]-2);
	$pos=miner_getInnerStrpos($data, "with(", "mm_style(");
	$filedata=substr($filedata,0,$pos[0]).substr($filedata,$pos[1]+9,strlen($filedata));
	return $text;
}

function extractMenuName($data){
	if(substr($data,0,1)=="(")$data=substr($data,1,strlen($data));
	$pos=miner_getInnerStrpos($data, "(\"", "\")");
	$text=substr($data,$pos[0]+1, $pos[1]-2);
	$text=ereg_replace("\"", "", $text);
	return $text;
}


function getThisFile(){
	$getThisFile=$_SERVER['SCRIPT_NAME'];
	$pos=strrpos($getThisFile,"/");
	if($pos)$getThisFile=substr($getThisFile,$pos+1);
	return $getThisFile;
}


function getThisFolder(){
	$thisfile=getThisFile();
	$thisFolder=$_SERVER['SCRIPT_NAME'];
	if(strlen($thisfile)>0)$thisFolder=ereg_replace($thisfile,"",$thisFolder);
	return $thisFolder;
}



function createMenuStyleCSS()
{
	global $styles;
	$cssoutput="<style>";
	$styleproperties="";
	foreach ($styles as $key => $value) 
	{
		foreach ($value as $cssproperty => $cssvalue) 
		{
			if($cssproperty=="stylename")$stylename=$cssvalue;
			if($cssproperty=="offcolor")$styleproperties.="color:$cssvalue;";
			if($cssproperty=="offbgcolor")$styleproperties.="background-color:$cssvalue;";
			if($cssproperty=="fontfamily")$styleproperties.="font-family:$cssvalue;";
			if($cssproperty=="fontsize")$styleproperties.="font-size:$cssvalue;";
		}
		$cssoutput.= ".".$stylename."{".$styleproperties."}";
		
	}	
	$cssoutput.="</style>";
	echo $cssoutput;
}



$RitemsArray=Array();
function getRecursiveItemsByMenuname($menuname, $datafile, $level=0, $counter=1){
	global $menus,$RitemsArray;
	$menus=getMenusFromData($datafile);
	//echo "<HR>".count($menus)."<HR>";
	for($a=0;$a<count($menus);$a++){
		if($menus[$a]['menuname']==$menuname){
			for($b=0;$b<count($menus[$a]['items']);$b++){
				$RitemsArray[]['level']=$level;
				$RitemsArray[count($RitemsArray)-1]['data']=$menus[$a]['items'][$b];
				$RitemsArray[count($RitemsArray)-1]['data']['menu']=$a;
				if(isset($menus[$a]['items'][$b]['showmenu'])&& $menus[$a]['items'][$b]['showmenu'])
				{
					getRecursiveItemsByMenuname($menus[$a]['items'][$b]['showmenu'],$datafile,$level+1, $counter,$datafile);
				}
				
			}
		}
		
	}
	return $RitemsArray;
}





function getFormatedMenuDataFromFile($menufile){
	global $globalValues, $styles, $menus, $filedata;
	$menus=Array();
	
	if(!$menufile)$menufile="menu_data.js";
	if (ereg("://", $menufile)){
		$handle = fopen($menufile, "rb");
		$contents = '';
		if($handle){
			while (!feof($handle)){
				$contents .= fread($handle, 8192);
			}
		}
		fclose($handle);
		$filedata=$contents;
	}
	else{
		$menufile=$_SERVER['DOCUMENT_ROOT'].$menufile;
		$contents = '';
		if ($handle=fopen($menufile, "rb")){
	            while(!feof($file)){
				$contents .= fread($handle, 8192);
			}
		}
		fclose($handle);
		$filedata=$contents;
	}

	if(strlen($filedata)>1)	{
		$filedata=stripslashes($filedata);
		$filedata=ereg_replace("://",":¬¬",$filedata);
		$filedata=miner_replaceInnerText($filedata, "\"", "\"", ";", "¬", 1);
		$filedata=miner_chopInnerText($filedata, "/*", "*/", 1, 0);
		$filedata=miner_chopInnerText($filedata, "//", "\r", 1, 0);
		$filedata=ereg_replace("\t","",$filedata);
		$filedata=miner_replaceInnerText($filedata, "\"", "\"", "with", "_H_T_I_W_", 1);
		$filedata=miner_replaceInnerText($filedata, "\"", "\"", "{", "_OPEN_CUR_BRA_CKET_", 1);
		$filedata=miner_replaceInnerText($filedata, "\"", "\"", "}", "_CLOSE_CUR_BRA_CKET_", 1);
		$filedata=ereg_replace("\n",";",$filedata);
		$filedata=ereg_replace("\r",";",$filedata);
		$filedata=ereg_replace(" {2,}", " ", $filedata);	
		$filedata=ereg_replace(" ;",";",$filedata);
		$filedata=ereg_replace("; ",";",$filedata);
		$filedata=ereg_replace("= ","=",$filedata);
		$filedata=ereg_replace(" =","=",$filedata);
		$filedata=ereg_replace(":¬¬","://",$filedata);
		
		$globalValues["_menuCloseDelay"]=extractPair("_menuCloseDelay",$filedata);
		$globalValues["_menuOpenDelay"]=extractPair("_menuOpenDelay",$filedata);
		$globalValues["_subOffsetTop"]=extractPair("_subOffsetTop",$filedata);
		$globalValues["_subOffsetLeft"]=extractPair("_subOffsetLeft",$filedata);
		$globalValues["disableMouseMove"]=extractPair("disableMouseMove",$filedata);
		$globalValues["ignoreCollisions"]=extractPair("ignoreCollisions",$filedata);
		$globalValues["horizontalMenuDelay"]=extractPair("horizontalMenuDelay",$filedata);
		$globalValues["retainClickValue"]=extractPair("retainClickValue",$filedata);
		$globalValues["closeAllOnClick"]=extractPair("closeAllOnClick",$filedata);
		$globalValues["noSubImageSpacing"]=extractPair("noSubImageSpacing",$filedata);
		$globalValues["includeTabIndex"]=extractPair("includeTabIndex",$filedata);
		$globalValues["buildAllMenus"]=extractPair("buildAllMenus",$filedata);
		$globalValues["_CFix"]=extractPair("_CFix",$filedata);
		$globalValues["blankPath"]=extractPair("blankPath",$filedata);
		$globalValues["_scrollUpImage"]=extractPair("_scrollUpImage",$filedata);
		$globalValues["_scrollDownImage"]=extractPair("_scrollDownImage",$filedata);
		$globalValues["_scrollAmount"]=extractPair("_scrollAmount",$filedata);
		$globalValues["_scrollDelay"]=extractPair("_scrollDelay",$filedata);

		$data=split("with",$filedata);
		
		$stylecount=0;
		$menucount=0;
		//echo count($data);
		for($a=0;$a<count($data);$a++)
		{
		
			if(eregi("new mm_style\(\)", $data[$a]))
			{
				$stylename=extractStyleName($data[$a]);
				$styles[$stylecount]["stylename"]=$stylename;
				$props=miner_getInnerText($data[$a], "{", "}");
				$propsar=split(";",$props);
				for($b=0;$b<count($propsar);$b++){
					$pos=strpos($propsar[$b],"=");
					if($pos){
						$key=substr($propsar[$b],0,$pos);
						$styles[$stylecount][$key]=extractPair($key,$data[$a]);
					}
				}
				$stylecount++;
			}
			
			
			if(eregi("new menuname\(", $data[$a]))
			{
				$menuname=extractMenuName($data[$a]);
				$menus[$menucount]["menuname"]=$menuname;
				$props=miner_getInnerText($data[$a], "{", "}");
				$propsar=split(";",$props);
				
				
				$itemnumber=0;
				for($b=0;$b<count($propsar);$b++){
					if(substr($propsar[$b],0,3)=="aI("){
						$aitext=substr(miner_getInnerText($propsar[$b], "\"", "\""),1,strlen($propsar[$b])-6);
						$aiparts=split("¬",$aitext);
						for($c=0;$c<count($aiparts);$c++){
							$pos=strpos($aiparts[$c],"=");
							if($pos){
								$key=substr($aiparts[$c],0,$pos);
								$val=substr($aiparts[$c],$pos+1,strlen($aiparts[$c]));
								$menus[$menucount]['items'][$itemnumber][$key]=$val;
								$lastGoodItem=$itemnumber;
								$lastGoodKey=$key;
							}
							else{
								if($aiparts[$c]){
									$menus[$menucount]['items'][$lastGoodItem][$lastGoodKey].=";".$aiparts[$c];								
								}
							}
						}
						$itemnumber++;
					}
					else{
						$pos=strpos($propsar[$b],"=");
						if($pos){
							$key=substr($propsar[$b],0,$pos);
							$menus[$menucount][$key]=extractPair($key,$data[$a]);
						}
					}
				}
				$menucount++;
			}
		
		}
		
	}
	return $filedata;
}





function getMenusFromData($datafile)
{
	global $_M;
	$menus=Array();
	$menucount=0;
	$data=split("with",$datafile);
	
	for($a=0;$a<count($data);$a++)
	{
		if(eregi("new menuname\(", $data[$a]))
		{
			$menuname=extractMenuName($data[$a]);
			$menus[$menucount]["menuname"]=$menuname;
			$props=miner_getInnerText($data[$a], "{", "}");
			$propsar=split(";",$props);
			
			$itemnumber=0;
			for($b=0;$b<count($propsar);$b++){
				if(substr($propsar[$b],0,3)=="aI("){
					$aitext=substr(miner_getInnerText($propsar[$b], "\"", "\""),1,strlen($propsar[$b])-6);
					$aiparts=split("¬",$aitext);
					$menus[$menucount]['items'][$itemnumber]['menu']=$menucount+count($_M);
					for($c=0;$c<count($aiparts);$c++){
						$pos=strpos($aiparts[$c],"=");
						if($pos){
							$key=substr($aiparts[$c],0,$pos);
							$val=substr($aiparts[$c],$pos+1,strlen($aiparts[$c]));
							$val=ereg_replace("_H_T_I_W_","with",$val);
							$menus[$menucount]['items'][$itemnumber][$key]=$val;
							$lastGoodItem=$itemnumber;
							$lastGoodKey=$key;
						}
						else{
							if($aiparts[$c]){
								$menus[$menucount]['items'][$lastGoodItem][$lastGoodKey].=";".$aiparts[$c];								
							}
						}
					}
					$itemnumber++;
				}
				else{
					$pos=strpos($propsar[$b],"=");
					if($pos){
						$key=substr($propsar[$b],0,$pos);
						$menus[$menucount][$key]=extractPair($key,$data[$a]);
					}
				}
			}
			$menucount++;
		}
	
	}	
	return $menus;
}



function getSiteMapData($datafile)
{
	global $globalValues, $styles, $menus, $useMenuStyles;
	$oldlevel=0;
	$menus="";
	$data=getFormatedMenuDataFromFile($datafile);
	
	echo "<PRE style='color:red;background:#c0c0c0'>$data</PRE>";
	
	$output="";	
	$mainmenus=getMainMenus();
	//echo count($mainmenus)."<HR>";

	if($useMenuStyles)createMenuStyleCSS();

	for($a=0;$a<count($mainmenus);$a++)$items=getRecursiveItemsByMenuname($mainmenus[$a]);
	//echo count($items)."<HR>";
	$output.="<UL>";
	for($a=0;$a<count($items);$a++)
	{		
		$leveldifference=$items[$a]['level']-$oldlevel;	
		if($leveldifference>0)for($x=0;$x<$leveldifference;$x++)$output.= "<UL>\n";
		if($leveldifference<0)for($x=0;$x>$leveldifference;$x--)$output.= "</UL>\n";

		$item=$items[$a]['data'];
		
		$itemHTML="";
		if($item['text'])
		{
			$itemHTML=ereg_replace("_H_T_I_W_","with",$item['text']);
			if(isset($item['image'])&&$item['image'])$itemHTML="<img src=".$item['image']." border=0>".$itemHTML;
		}
		else
		{
			
		}
		
		if(isset($item['url'])&&$item['url'])$itemHTML="<a href=".$item['url'].">".$itemHTML."</a>";
	
		$mstyle=$menus[$item['menu']]['style'];
	
		$output.= "<LI class=$mstyle>$itemHTML\n";
		$oldlevel=$items[$a]['level'];
	}
	$output.="</UL>";
	
	return $output;	
}


function getGlobalsFromData($datafile)
{
	$menuGlobals=Array();
	$menuGlobals["_menuCloseDelay"]=extractPair("_menuCloseDelay",$datafile);
	$menuGlobals["_menuOpenDelay"]=extractPair("_menuOpenDelay",$datafile);
	$menuGlobals["_subOffsetTop"]=extractPair("_subOffsetTop",$datafile);
	$menuGlobals["_subOffsetLeft"]=extractPair("_subOffsetLeft",$datafile);
	$menuGlobals["disableMouseMove"]=extractPair("disableMouseMove",$datafile);
	$menuGlobals["ignoreCollisions"]=extractPair("ignoreCollisions",$datafile);
	$menuGlobals["horizontalMenuDelay"]=extractPair("horizontalMenuDelay",$datafile);
	$menuGlobals["retainClickValue"]=extractPair("retainClickValue",$datafile);
	$menuGlobals["closeAllOnClick"]=extractPair("closeAllOnClick",$datafile);
	$menuGlobals["noSubImageSpacing"]=extractPair("noSubImageSpacing",$datafile);
	$menuGlobals["includeTabIndex"]=extractPair("includeTabIndex",$datafile);
	$menuGlobals["buildAllMenus"]=extractPair("buildAllMenus",$datafile);
	$menuGlobals["_CFix"]=extractPair("_CFix",$datafile);
	$menuGlobals["blankPath"]=extractPair("blankPath",$datafile);
	$menuGlobals["_scrollUpImage"]=extractPair("_scrollUpImage",$datafile);
	$menuGlobals["_scrollDownImage"]=extractPair("_scrollDownImage",$datafile);
	$menuGlobals["_scrollAmount"]=extractPair("_scrollAmount",$datafile);
	$menuGlobals["_scrollDelay"]=extractPair("_scrollDelay",$datafile);	
	return $menuGlobals;
}










################################################################################


function getStylesFromData($datafile)
{
	$styles=Array();
	$stylecount=0;
	$data=split("with",$datafile);
	for($a=0;$a<count($data);$a++)
	{
		if(eregi("new mm_style\(\)", $data[$a]))
		{
			$stylename=extractStyleName($data[$a]);
			$styles[$stylecount]["stylename"]=$stylename;
			$props=miner_getInnerText($data[$a], "{", "}");
			$propsar=split(";",$props);
			for($b=0;$b<count($propsar);$b++){
				$pos=strpos($propsar[$b],"=");
				if($pos){
					$key=substr($propsar[$b],0,$pos);
					$styles[$stylecount][$key]=extractPair($key,$data[$a]);
				}
			}
			$stylecount++;
		}
	}
	return $styles;	
}



function extractPair($data, $filedata){
	if(!strpos($filedata, $data))return "";
	$data=ereg_replace(" =","=",$data);
	$data=ereg_replace("= ","=",$data);
	$text=miner_getInnerText($filedata, $data."=", ";");
	$text=substr($text,strlen($data)+1,strrpos($text,";")-strlen($data)-1);
	$filedata=miner_chopInnerText($filedata, $data, ";", 0,0);
	$text=ereg_replace("\"", "", $text);
	return $text;
}


function miner_replaceInnerText($haystack, $startNeedle, $endNeedle, $needle, $newneedle, $loopthru=0)
{
	/*
		This function replaces text inside a specified block of text
	*/
	$pstr=$haystack;
	$pos=miner_getInnerStrpos($haystack,$startNeedle, $endNeedle);
	if(is_numeric($pos[0]) && is_numeric($pos[1])){
		if($loopthru){
			$tstr=$haystack;
			$pstr="";
			while(is_numeric($pos[0]) && is_numeric($pos[1])){
				$istr=substr($tstr,$pos[0],$pos[1]);
				$istr=ereg_replace($needle,$newneedle,$istr);
				$pstr.=substr($tstr,0,$pos[0]).$istr;
				$tstr=substr($tstr,$pos[0]+$pos[1],strlen($tstr));
				$pos=miner_getInnerStrpos($tstr, $startNeedle, $endNeedle);
			}
			$pstr.=substr($tstr,0,strlen($tstr));	
		}
		else{
			
			$pstr=substr($haystack,$pos[0],$pos[1]);
			$pstr=ereg_replace($needle,$newneedle,$pstr);
			$pstr=substr($haystack,0,$pos[0]).$pstr.substr($haystack,$pos[1]+$pos[0],strlen($haystack));		
		}
	}
	return $pstr;
}

function miner_getInnerStrpos($haystack, $startNeedle, $endNeedle)
{
	$pos1=strpos($haystack, $startNeedle);
	$startNeedleWidth=strlen($startNeedle);
	$tstr=substr($haystack,$pos1+$startNeedleWidth,strlen($haystack));
	$pos2=strpos($tstr, $endNeedle);
	if(is_numeric($pos2))$pos2=$pos2+strlen($startNeedle)+strlen($endNeedle);
	$spos[0]=$pos1;
	$spos[1]=$pos2;
	return $spos;
}



function miner_chopInnerText($haystack, $startNeedle, $endNeedle, $loopthru=1, $keepvars=0)
{
	$pstr=$haystack;
	$pos=miner_getInnerStrpos($haystack, $startNeedle, $endNeedle);
	
	if(is_numeric($pos[0]) && is_numeric($pos[1])){
		if($loopthru){	
			$tstr=$pstr;
			$pstr="";
			while(is_numeric($pos[0]) && is_numeric($pos[1])){
				if($keepvars){
					$pstr.=substr($tstr,0,$pos[0]+strlen($startNeedle));
					$tstr=substr($tstr,$pos[0]+$pos[1],strlen($tstr));
				}
				else{
					$pstr.=substr($tstr,0,$pos[0]);
					$tstr=substr($tstr,$pos[0]+$pos[1],strlen($tstr));
				}
				$pos=miner_getInnerStrpos($tstr, $startNeedle, $endNeedle);
			}
			
			$pstr.=substr($tstr,0,strlen($tstr)+1);
		}
		else{
			if($keepvars){
				$pstr=substr($haystack,0,$pos[0]+strlen($startNeedle));
				$pstr.=substr($haystack,$pos[1]+$pos[0]-strlen($endNeedle),strlen($haystack));					
			}
			else{
				$pstr=substr($haystack,0,$pos[0]);
				$pstr.=substr($haystack,$pos[1]+$pos[0],strlen($haystack));					
			}
		}
	}
	return $pstr;
}
function miner_getInnerText($haystack, $startNeedle, $endNeedle, $includeNeedles=1)
{
	$pos=miner_getInnerStrpos($haystack,$startNeedle, $endNeedle);	
	$pstr=substr($haystack,$pos[0],$pos[1]);
	if(!$includeNeedles){
		$pstr=substr($pstr,strlen($startNeedle),strlen($pstr));
		$pstr=substr($pstr,0,strlen($pstr)-strlen($endNeedle));
	}
	return $pstr;
}


function getDocumentRoot(){
	 $docRoot=$_SERVER['DOCUMENT_ROOT'];
	 if(substr($docRoot,-1)!="/")$docRoot.="/";
	 return $docRoot;
}


function getMenuTextFromDataFile($filename)
{
	$filedata="";
	if (ereg("://", $filename)){
		$handle = fopen($filename, "rb");
	}
	else
	{
		//$filename=getDocumentRoot().$filename;
		//echo $filename;
		$handle = fopen($filename, "rb");
	}

	$contents="";
	if ($handle){		
		while(!feof($handle))
		{
			$contents .= fread($handle, 8192);
		}
	}
	else
	{
		echo "<br><b>Couldn't open file: $filename</b><br>";
		return;
	}	
	fclose($handle);
	$filedata=$contents;



	if(strlen($filedata)>1)	{
		$filedata=stripslashes($filedata);
		$filedata=ereg_replace("://",":¬¬",$filedata);
		$filedata=miner_replaceInnerText($filedata, "\"", "\"", ";", "¬", 1);
		$filedata=miner_chopInnerText($filedata, "/*", "*/", 1, 0);
		$filedata=miner_chopInnerText($filedata, "//", "\r", 1, 0);
		$filedata=ereg_replace("\t","",$filedata);
		$filedata=miner_replaceInnerText($filedata, "\"", "\"", "with", "_H_T_I_W_", 1);
		$filedata=miner_replaceInnerText($filedata, "\"", "\"", "{", "_OPEN_CUR_BRA_CKET_", 1);
		$filedata=miner_replaceInnerText($filedata, "\"", "\"", "}", "_CLOSE_CUR_BRA_CKET_", 1);
		$filedata=ereg_replace("\n",";",$filedata);
		$filedata=ereg_replace("\r",";",$filedata);
		$filedata=ereg_replace(" {2,}", " ", $filedata);
		$filedata=ereg_replace(" ;",";",$filedata);
		$filedata=ereg_replace("; ",";",$filedata);
		$filedata=ereg_replace("= ","=",$filedata);
		$filedata=ereg_replace(" =","=",$filedata);
		$filedata=ereg_replace(":¬¬","://",$filedata);
		$filedata=ereg_replace(";{2,}", ";", $filedata);
	}

	return $filedata;
}


function getMenuData($reset=0)
{
	global $_S;
	global $_M;
	global $_I;
	global $dataRetrieved;
	global $menuDataFile;
	
	if(!$dataRetrieved||$reset==1)
	{
		$_M = Array();
		$_S = Array();
		$_I = Array();
		$menuCounter=0;
		$styleCounter=0;
		$itemCounter=0;
				
		for($df=0;$df<count($menuDataFile);$df++)
		{
			$dataText=getMenuTextFromDataFile($menuDataFile[$df]);
			
			$styles=getStylesFromData($dataText);
			for($a=0;$a<count($styles);$a++)
			{
				$_S[$styleCounter]=Array();
				foreach ($styles[$a] as $key => $value)
				{
					$_S[$styleCounter][$key]=$value;
				}
				$styleCounter++;
			}
			

			$menus=getMenusFromData($dataText);
			for($a=0;$a<count($menus);$a++){
				$_M[$menuCounter]=Array();
				foreach ($menus[$a] as $key => $value)
				{
					$_M[$menuCounter][$key]=$value;
				}
				$menuCounter++;
			}
			
		}
	}
	$dataRetrieved=1;
}









function getItemsByMenu($mnu)
{
	global $_M, $_S, $_I;
	$items=$_M[$mnu]['items'];
	for($a=0;$a<count($items);$a++)
	{
		echo "$items[$a]<br>";
	}
}

function getMenuByName($menuname)
{
	global $_M, $_S, $_I;
	for($a=0;$a<count($_M);$a++)
	{
		if($menuname==$_M[$a]['menuname'])return $a;
	}
	return -1;
}




$dataMinerOutput="";  // Global Variable for containing details of output


function outputSitemapItems($mnu)
{
	global $_M,$dataMinerOutput;
	$dataMinerOutput.="<UL>\n";
	$items=$_M[$mnu]['items'];
	for($a=0;$a<count($items);$a++)
	{	
		$dataMinerOutput.="<li>\n";
		if(isset($items[$a]['showmenu'])&&$items[$a]['showmenu'])
		{
			$dataMinerOutput.=$items[$a]['text']."\n";
			outputSitemapItems(getMenuByName($items[$a]['showmenu']));
		}
		else
		{
			if(isset($items[$a]['url'])&&$items[$a]['url'])
			{
				$dataMinerOutput.="<a href=".$items[$a]['url'].">".$items[$a]['text']."</a>\n";
			}
			else
			{
				$dataMinerOutput.="".$items[$a]['text']."\n";
			}
		}
	}
	$dataMinerOutput.="</UL>\n";
}


function outputAsSiteMap($datafile=null)
{
	global $_M,$dataMinerOutput;
	$mainmenus=getMainMenus();
	for($a=0;$a<count($mainmenus);$a++)
	{
		$dataMinerOutput="";
		outputSitemapItems($mainmenus[$a]);
		echo $dataMinerOutput;
		echo "<HR>";
	}
}


























function outputNoScriptItems($mnu)
{
	global $_M,$dataMinerOutput;
	$items=$_M[$mnu]['items'];
	
	$dataMinerOutput.="";
	for($a=0;$a<count($items);$a++)
	{
		if(isset($_M[$mnu]['orientation'])&& $_M[$mnu]['orientation'])
		{
			if($a==0)$dataMinerOutput.="<table border=0 cellpadding=0 cellspacing=0><tr>";
			
			$lnk=$items[$a]['text'];
			if(isset($items[$a]['url'])&&$items[$a]['url'])
			{
				$lnk="<a href=".$items[$a]['url'].">".$items[$a]['text']."";
			}
			
			$dataMinerOutput.="<td valign=top><b>$lnk</b>";
			
			if(isset($items[$a]['showmenu'])&&$items[$a]['showmenu'])
			{
				outputSitemapItems(getMenuByName($items[$a]['showmenu']));
			}
			
			$dataMinerOutput.="</td>";
			
			if($a==count($items))$dataMinerOutput.="</tr></table>";
		}
	}
	$dataMinerOutput.="";
}


function outputAsNoScript($datafile=null)
{
	global $_M,$dataMinerOutput;
	$mainmenus=getMainMenus();
	for($a=0;$a<count($mainmenus);$a++)
	{
		// Need to get system to scan through menus see if they are horiz or vert and draw TABLE for horiz or UL for vertical
		$dataMinerOutput="";		
		outputNoScriptItems($mainmenus[$a]);
		echo $dataMinerOutput;
		echo "<HR>";
	}
}























function getStyles()
{
	global $_S;
	getMenuData();
	return $_S;
}


function showStyles($datafile)
{
	global $_M, $_S, $_I;
	$styles=getStyles();
	
	for($a=0;$a<count($styles);$a++)
	{
		echo "<b>".$_S[$a]['stylename']."</b><br>";
		foreach ($_S[$a] as $key => $value)
		{
			if(!is_numeric($value))$value="\"".$value."\"";
			echo "<b>$key</b>=$value;<br />\n";	
		}
		echo "<HR>";
	}	
}





















function getMainMenus()
{
	global $_M, $_S, $_I;
	getMenuData();
	$mainmenus = Array();
	for($a=0;$a<count($_M);$a++)
	{
		if(isset($_M[$a]['alwaysvisible'])&&$_M[$a]['alwaysvisible'])$mainmenus[]=$a;
	}
	return $mainmenus;
}

function showMainMenus()
{
	global $_M, $_S, $_I;
	$mainmenus=getMainMenus();
	
	for($a=0;$a<count($mainmenus);$a++)
	{
		echo "<b>".$_M[$a]['menuname']."</b><br>";
		foreach ($_M[$a] as $key => $value)
		{
			echo "$key=$value<br>";
		}
		echo "<HR>";		
	}
}























function getItems()
{
	global $_M;
	getMenuData();
	$items=Array();
	$itemCounter=0;
	for($a=0;$a<count($_M);$a++)
	{
		foreach ($_M[$a]['items'] as $key1 => $value1)
		{
			foreach ($value1 as $key => $value)
			{
				$items[$itemCounter][$key]=$value;
			}
			$itemCounter++;
		}
	}
	return $items;
}


function showItems()
{
	$items=getItems();
	for($a=0;$a<count($items);$a++)
	{
		foreach ($items[$a] as $key => $value)
		{
			echo "$key=$value  ";
		}
		echo "<br>";
	}
}



























function getAllMenus()
{
	global $_M;
	getMenuData();
	return $_M;
}

function showAllMenus($datafile)
{
	global $_M, $_S, $_I;
	$menus=getAllMenus();
	
	for($a=0;$a<count($menus);$a++)
	{
		echo "<b>".$_M[$a]['menuname']."</b><br>";
		foreach ($_M[$a] as $key => $value)
		{
			echo "$key=$value<br>";
		}
		echo "<HR>";		
	}	
}



















function showMenusAndItems($datafile)
{
	global $_M, $_S, $_I;
	getMenuData();
	
	for($a=0;$a<count($_M);$a++)
	{
		echo "<b>".$_M[$a]['menuname']."</b><br>";
		foreach ($_M[$a] as $key => $value)
		{
			echo ".....$key=$value<br>";
		}
		
		foreach ($_M[$a]['items'] as $key1 => $value1)
		{
			echo "...........";
			foreach ($value1 as $key => $value)
			{
				echo "$key=$value--";
			}
			echo "<br>";
		}		
	}
	echo "<hr>";	
}



function newShowMenus()
{
	global $_M, $_S, $_I;
	getMenuData();
	
	for($a=0;$a<count($_S);$a++)
	{
		echo "<b>".$_S[$a]['stylename']."</b><br>";
		foreach ($_S[$a] as $key => $value)
		{
			echo ".....$key=$value<br>";
		}
	}
	
	echo "<HR>";
	
	for($a=0;$a<count($_M);$a++)
	{
		echo "<b>".$_M[$a]['menuname']."</b><br>";
		foreach ($_M[$a] as $key => $value)
		{
			echo ".....$key=$value<br>";
		}
		
		foreach ($_M[$a]['items'] as $key1 => $value1)
		{
			echo "..........";
			foreach ($value1 as $key => $value)
			{
				echo "$key=$value--";
			}
			echo "<br>";
		}		
	}
}



?>