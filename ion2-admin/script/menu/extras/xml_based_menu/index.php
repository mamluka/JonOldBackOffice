<?

function replaceInnerText($haystack, $startNeedle, $endNeedle, $needle, $newneedle, $loopthru=0)
{
	/*
		This function replaces text inside a specified block of text
	*/
	$pstr=$haystack;
	$pos=getInnerStrpos($haystack,$startNeedle, $endNeedle);
	if(is_numeric($pos[0]) && is_numeric($pos[1])){
		if($loopthru){
			$tstr=$haystack;
			$pstr="";
			while(is_numeric($pos[0]) && is_numeric($pos[1]))
			{
				$istr=substr($tstr,$pos[0],$pos[1]);
				
				//echo "<pre>$istr</pre>";
				
				$istr=ereg_replace($needle,$newneedle,$istr);
				
				$pstr.=substr($tstr,0,$pos[0]).$istr;
				$tstr=substr($tstr,$pos[0]+$pos[1],strlen($tstr));
	
				$pos=getInnerStrpos($tstr, $startNeedle, $endNeedle);
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



function getInnerStrpos($haystack, $startNeedle, $endNeedle)
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

	
	function chopInnerText($haystack, $startNeedle, $endNeedle, $loopthru=1, $keepvars=0)
{
	/* 
		This function returns a specified string with the text removed between the specified start string and end string.
		
		$haystack is the string you want manipulating
		$startNeedle is the starting point to look for
	 	$endNeedle is the point at which text stops being deleted
	 	if $loopthru is true, loops through the text until no other $start_txt to $end_txt can be found
	 	$keepvars leaves the $startNeedle and $endNeedle variables in the text string
	*/	

	$pstr=$haystack;
	$pos=getInnerStrpos($haystack, $startNeedle, $endNeedle);
	
	if(is_numeric($pos[0]) && is_numeric($pos[1]))
	{
		if($loopthru)
		{	
			$tstr=$pstr;
			$pstr="";
			while(is_numeric($pos[0]) && is_numeric($pos[1]))
			{
				if($keepvars)
				{
					$pstr.=substr($tstr,0,$pos[0]+strlen($startNeedle));
					$tstr=substr($tstr,$pos[0]+$pos[1],strlen($tstr));
				}
				else
				{
					$pstr.=substr($tstr,0,$pos[0]);
					$tstr=substr($tstr,$pos[0]+$pos[1],strlen($tstr));
				}
				$pos=getInnerStrpos($tstr, $startNeedle, $endNeedle);
			}
			
			$pstr.=substr($tstr,0,strlen($tstr)+1);
		}
		else
		{
			if($keepvars)
			{
				$pstr=substr($haystack,0,$pos[0]+strlen($startNeedle));
				$pstr.=substr($haystack,$pos[1]+$pos[0]-strlen($endNeedle),strlen($haystack));					
			}
			else
			{
				$pstr=substr($haystack,0,$pos[0]);
				$pstr.=substr($haystack,$pos[1]+$pos[0],strlen($haystack));					
			}
		}
	}
	return $pstr;
}

	
	function fileContents($filename)
	{
		$file=fopen($filename, "r");
		
		$dFF="";
		
		while(!feof($file))
		{
			$dFF .= fread($file, 4096);
		}
		
		return $dFF;
	}
	
	$ftext=fileContents("menu.xml");
	
	$level=0;
	
	$ftext=ereg_replace("\r","",$ftext);
	$ftext=ereg_replace("\n","",$ftext);
		

	$ftext = chopInnerText($ftext, "<!--", "-->", 1, 0);
	$ftext = chopInnerText($ftext, "<?", "?>", 1, 0);


	$xmlA=split("<",$ftext);
	

	$menucode="";
	$endlevel=-1;
	for($a=1;$a<count($xmlA);$a++)
	{
		$level++;
		$newLevel=false;
		$tbs="";
			
		if(substr($xmlA[$a],0,1)=="?")
		{
			
		}
		else if(substr($xmlA[$a],0,1)=="/")
		{
			if($level>1)
			{
				$level--;
				$newLevel=true;	
				if($level<$endlevel)
				{
					$splitProp=split(">",substr($xmlA[$a],1,strlen($xmlA[$a])));
					if($splitProp[0]=="style" || $splitProp[0]=="menu")$menucode.="}\n\n";
					if($splitProp[0]=="menuitem")$menucode.="\");\n";
					//echo "END - '$splitProp[0]'";
					
					//$menucode.="}";	
				}
				//$menucode.=";<br>";	
				$endlevel=$level;
			}
		}
		else
		{
			$splitProp=split(">",$xmlA[$a]);
			
			if(count($splitProp)==2 && ord($splitProp[1])>32)
			{
				//$xmlA[$a]="<b><font color=green>$splitProp[0]</font></b><font color=black><b>=</b></font><font color=darkblue><b>$splitProp[1]</b></font></b>";
				if($old!="menuitem")
				{
					if($splitProp[0]=="style")
					{
						$menucode.="$splitProp[0]=$splitProp[1];\n";	
					}
					else
					{
						$menucode.="$splitProp[0]=\"$splitProp[1]\";\n";	
					}
					
				}
				else
				{
					$menucode.="$splitProp[0]=$splitProp[1];";	
				}
				
			}
			else
			{
				$old=$splitProp[0];
				$splitProp=split(" ",$splitProp[0]);
				if(count($splitProp)==1)
				{
					//$xmlA[$a]="<font color=cyan><b>New Object = $splitProp[0]</b></font>";

					if($splitProp[0]=="menuitem")
					{
						$menucode.="aI(\"";
					}
				}
				else
				{
					$old = replaceInnerText($old, "\"", "\"", "=", "MILONICEQUALS", 1);
					$old = replaceInnerText($old, "\"", "\"", " ", "MILONICSPACE", 1);
					
					$old = replaceInnerText($old, "'", "'", "=", "MILONICEQUALS", 1);
					$old = replaceInnerText($old, "'", "'", " ", "MILONICSPACE", 1);
					
					$old=ereg_replace("\"","",$old);
					$old=ereg_replace("'","",$old);

					$splitProp=split(" ",$old);
					
					//$xmlA[$a]="<font color=pink><b>$splitProp[0]</b></font>";
					
					
					
					for($b=1;$b<count($splitProp);$b++)
					{
						$prop=split("=",$splitProp[$b]);
						$prop[1]=ereg_replace("MILONICEQUALS","=",$prop[1]);
						$prop[1]=ereg_replace("MILONICSPACE"," ",$prop[1]);
						for($tabs=1;$tabs<$level;$tabs++)$tbs=$tbs."&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;";
						//$xmlA[$a].="<br>$tbs $level <font color=blue><b>$prop[0]</font> = <font color=brown>$prop[1] </b></font>";
						
						if($prop[0]=="menuCloseDelay"||$prop[0]=="menuOpenDelay"||$prop[0]=="subOffsetTop"||$prop[0]=="subOffsetLeft") 
						{
							$menucode.="_$prop[0]=".$prop[1].";\n";
						}
						
						$tbs="";
						
						//echo $splitProp[0];
						
						if($splitProp[0]=="style")$menucode.="with($prop[1]=new mm_style()){\n";	
						
						if($splitProp[0]=="menu")
						{
							$menucode.="with(milonic=new menuname(\"$prop[1]\")){\n";	
						}
						
					}					
				}
			}
			
			for($tabs=1;$tabs<$level;$tabs++)$tbs=$tbs."&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;";
			//echo "$tbs <font color=red><b>$level</b></font> $xmlA[$a] <br>";
		}
	
		if($newLevel)
		{
			$level--;
		}
	}


$pathToCodeFiles="../../";
$file_milonicsrc="milonic_src.js";
$file_mmenudom="mmenudom.js";
$file_mmenuns4="mmenuns4.js";



echo "

<script src=\"$pathToCodeFiles$file_milonicsrc\" type=\"text/javascript\"></script>	
<script type=\"text/javascript\">
if(ns4)_d.write(\"<scr\"+\"ipt language=JavaScript src=$pathToCodeFiles$file_mmenuns4><\/scr\"+\"ipt>\");		
  else _d.write(\"<scr\"+\"ipt language=JavaScript src=$pathToCodeFiles$file_mmenudom><\/scr\"+\"ipt>\"); 
</script>
";

echo "<script type=\"text/javascript\">";

echo $menucode.";drawMenus();</script>";

echo "<a href=http://www.milonic.com/>JavaScript Menu Powered by Milonic</a>
<BR><BR><BR><BR><BR><BR><BR>
This menu is built using the file <a href=menu.xml>menu.xml</a>
";
?>