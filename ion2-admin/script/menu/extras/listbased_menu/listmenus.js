/*
   Milonic DHTML Menu HTML Unordered List Based Module version 2.1 - August 3 2006
   This module is only compatible with the Milonic DHTML Menu version 5.7 or higher

   Copyright 2004 (c) Milonic Solutions Limited. All Rights Reserved.
   This is a commercial software product, please visit http://www.milonic.com/ for more information.
   
   The object of this module is to enable data entered as a HTML un-ordered list to be used inside menus.
   Data for menu items is taken from HTML Lists and used for menus. Styles are created as normal DHTML Menus and referenced as a CSS classname.
*/

_lpss=0
_y3=new Array();
function buildListMenu(_mnu,_sty,_prps)
{	
	_lpss++
	if(_lpss==1)
	{
		_y5=0;
		_y1=0;
		for(_a=0;_a<_d.links.length;_a++){
		_y4=_d.links[_a];
			pE=_y4.parentNode;
			if(pE.tagName=="LI"){
				while(pE){
					if(pE.tagName=="UL"){
						if(!pE.menuId)
						{
							pE.menuId="mmenu"+_y5;
							if(pE.id==_mnu)pE.style.display="none"
							_y3[_y5]=new Array();
							if(_y1)_y3[_y1][_y3[_y1].length-1]+=";showmenu=listmenu"+_y5+";";
							if(pE.className)_y3[_y5].mS=pE.className

							if(pE.parentNode.tagName!="LI")
							{
								_y3[_y5].mM=1
								msMenu=pE.id
							}
							_y3[_y5].msMenu=msMenu							
							_y5++;
						}
						break;
					}
					pE=pE.parentNode;
				}
				if(pE)
				{
					_y1=pE.menuId.substr(5,3);
					if(sfri||ie)txt=_y4.innerHTML;else txt=_y4.text;
					_y3[_y1][_y3[_y1].length]="text="+txt.replace(/\"/g,"\\'")+";"		
					if(_y4.href.substr(_y4.href.length-1,1)!="#")_y3[_y1][_y3[_y1].length-1]+="url="+_y4+";"
				}
			}
		}
	}
	_y6="";
	for(_a=0;_a<_y3.length;_a++){
		if(_y3[_a].msMenu==_mnu)
		{
			_mN="listmenu"+_a
			if(_y3[_a].mM)_mN=_mnu
			_y6+="with(milonic=new menuname('"+_mN+"')){"
			if(_y3[_a].mS)_y6+="style="+_y3[_a].mS+";";else _y6+="style="+_sty+";";
			if(_y3[_a].mM)_y6+=_prps;
			for(_b=0;_b<_y3[_a].length;_b++){_y6+="aI(\""+_y3[_a][_b].replace(/\"/g,"'")+";\");\n"}
			_y6+="}"
		}
	}
	_d.write("<script>"+_y6.replace(/\n/g,"")+"drawMenus();<\/script>")
}