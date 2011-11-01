/*
   Milonic DHTML Menu - Menu Editing API Module mm_menueditapi.js version 3.5 - January 3 2007
   This module is only compatible with the Milonic DHTML Menu version 5.764 or higher

   Copyright 2005 (c) Milonic Solutions Limited. All Rights Reserved.
   This is a commercial software product, please visit http://www.milonic.com/ for more information.

Syntax:

mm_createNewMenus()                                    --  mm_createNewMenus();
mm_cloneMenu("Menu Name To Copy",copyItems)            --  mm_cloneMenu("Main Menu",0); ####Coming Soon####
mm_addMenu()                                           --  mm_addMenu();
mm_getChildMenus(menuRef)                              --  mm_getChildMenus("sub Menu"); // Set the global variable rCM to contain all child menus and rCI to contain all Child Items
mm_deleteChildMenus(menuRef)                           --  mm_deleteChildMenus(3);
mm_deleteMenu(menuRef)                                 --  mm_deleteMenu("Sub Menu To Delete");
mm_insertItem(menuRef,itemNumber,'aI Text',noRebuild)  --  mm_insertItem('Main Menu',2,'text=New Item;url=test.html;offcolor=yellow;offbgcolor=darkblue;'); // Inserts a new item at position 2 in Main Menu
mm_addItemByItemRef(itemRef,'aI Text')                 --  mm_addItemByItemRef(22,'text=New Item;url=test.html;');
mm_editItem(menuRef,itemNumber,'aI Text',noRebuild)    --  mm_editItem('MainMenu',4,'text=Item;url=index.php');  // Modifies the details of menu item 4 in Main Menu
mm_editItemByItemRef(itemRef,'aI Text')                --  mm_editItemByItemRef (22,'text=New Text;fontweight=bold;');
mm_deleteItem(menuRef,itemNumber)                      --  mm_deleteItem('Main Menu',3);  Removes third item in Main Menu
mm_deleteItemByText(itemText)                          --  mm_deleteItemByText('Item Text');  Removes item in Menu by its text
mm_deleteItemByItemRef(itemRef)                        --  mm_deleteItemByItemRef(24);
mm_shiftItem(itemRef,numberOfShifts)                   --  mm_shiftItem(12,-1);
mm_returnItemPos(itemRef)                              --  mm_returnItemPos(22);
mm_sortItems(menuRef,orderRef)                         --  mm_sortItems(1,1); orderRef is 1(one) for A-Z and 0(zero) is Z-A
mm_replace('itemProperty','findtext','replacewith')    --  mm_replace('url','[userid]','28154');
mm_returnMenuItemCount(menuRef)                        --  mm_returnMenuItemCount("Main Menu");
mm_changeMenuStyle(menuRef,style)                      --  mm_changeMenuStyle("Main Menu",xpMenuStyle);
mm__p8MenuFormatting(menuRef,)
*/


function makeUnique(ar)
{
	ar.sort()
	var ao=[]
	oldI=_n
	for(var a=0;a<ar.length;a++){
		if(oldI!=ar[a])ao[ao.length]=ar[a]
		oldI=ar[a]
	}
	return ao
}

function getStyles()
{
	var ar=[]
	for(var a=0;a<_m.length;a++)ar[ar.length]=_m[a][6].text
	return makeUnique(ar);
}


function getMainMenus()
{
	var ar=[]
	for(var a=0;a<_m.length;a++)if(_m[a][7])ar[ar.length]=a
	return ar;
}

function fixMenuProperty(n,v)
{
	if(isNaN(v))v="\""+v+"\""
	var o=n+"="+v+";\n"
	return o
}

function fixItemProperty(n,v)
{
	var o=n+"="+v+";";
	return o
}


function createMenuObject($m)
{
	var h="";
	var M=_m[$m]
	h+="with(milonic=new menuname(\""+M[1]+"\")){\n"
	h+="style="+M[6].text+";\n"
	for(_cO in _$M)
	{
		var v=M[_$M[_cO]]
		if(_cO!="items"&&_cO!="name"&&_cO!="style"&&_cO!="mm_callItem"&&_cO!="mm_obj_ref"&&_cO!="mm_built")if(v)h+=fixMenuProperty(_cO,v)
	}
	
	for(var b=0;b<M[0].length;b++)
	{
		h+="aI(\"";
		for(_cO in _$S)
		{
			var I=_mi[M[0][b]]
			if(I[_$S[_cO]])
			{
				if(eval("M[6]."+_cO)!=I[_$S[_cO]] && I[_$S[_cO]]!="mminsert"  && I[_$S[_cO]]!="aaa();" && _cO!="menu")
				h+=_cO+"="+ I[_$S[_cO]]+";"
			}
		}
		h+="\");\n";
	}
	h+="}\n\n";
	return h
}


function getAdoptedMenus()
{
	var ar=[]

	for(var a=0;a<_mi.length;a++)
	{
		if(_mi[a][3]&&_mi[a][3]!="mminsert")
		{
			var M=$h(_mi[a][3])
			if(M)ar[ar.length]=M
		}
	}
	
	return ar
}

function getOrphanMenus()
{
	var ar=[]
	return ar
}



function createDataFile()
{
	var h=""

	if(_W._menuCloseDelay)h+="_menuCloseDelay="+_menuCloseDelay+";\n"
	if(_W._menuOpenDelay)h+="_menuOpenDelay="+_menuOpenDelay+";\n"
	if(_W._subOffsetTop)h+="_subOffsetTop="+_subOffsetTop+";\n"
	if(_W._subOffsetLeft)h+="_subOffsetLeft="+_subOffsetLeft+";\n"
	if(_W.contextObject)h+="contextObject="+contextObject+";\n"
	if(_W.disableMouseMove)h+="disableMouseMove="+disableMouseMove+";\n"
	if(_W.resetAutoOpen)h+="resetAutoOpen="+resetAutoOpen+";\n"
	if(_W.buildAfterLoad)h+="buildAfterLoad="+buildAfterLoad+";\n"
	if(_W.horizontalMenuDelay)h+="horizontalMenuDelay="+horizontalMenuDelay+";\n"
	if(_W.forgetClickValue)h+="forgetClickValue="+forgetClickValue+";\n"
	if(_W.fixMozillaZIndex)h+="fixMozillaZIndex="+fixMozillaZIndex+";\n"
	if(_W.inResizeMode)h+="inResizeMode="+inResizeMode+";\n"
	if(_W.noSubImageSpacing)h+="noSubImageSpacing="+noSubImageSpacing+";\n"
	if(_W.noTabIndex)h+="noTabIndex="+noTabIndex+";\n"
	if(_W.buildAllMenus)h+="buildAllMenus="+buildAllMenus+";\n"
	if(_W.disablePagePath)h+="disablePagePath="+disablePagePath+";\n"
	if(_W._CFix)h+="_CFix="+_CFix+";\n"
	
	h+="\n";

	var s=getStyles()
	for(var a=0;a<s.length;a++)
	{
		var _w = eval(s[a])
		h+="with("+s[a]+"=new mm_style()){\n"
		for(_cO in _w)
		{
			if(_w[_cO]&&_w[_cO]!=""&&_cO!="text"&&_cO!="built"&&_cO!="65"&&_cO!="64"&&_cO!="63")if(_w[_cO])h+=fixMenuProperty(_cO,_w[_cO])
		}
		h+="}\n\n";
	}
		
	mainMenus=getMainMenus();
	
	orphanMenus=getOrphanMenus();
	
	//alert(mainMenus)
	//alert(adoptedMenus)
	//alert(orphanMenus)
	
	for(var a=0;a<mainMenus.length;a++)
	{
		h+=createMenuObject(a);
	}


	adoptedMenus=getAdoptedMenus();
	//alert(adoptedMenus)
	for(var a=0;a<adoptedMenus.length;a++)
	{
		//alert(adoptedMenus[a])
		h+=createMenuObject(adoptedMenus[a]);
	}

	
	
	//alert(h)	
	h+="drawMenus();\n\n";
	$c("menudatafile").innerHTML=h.replace(/\n/g,"<br>") 
}



function mm_changeMenuStyle()
{
	var s,i,O,m,N,P;
	g=arguments;
	if(g[1]){
		if(isNaN(g[1]))m=$h(g[1]); else m=g[1]
		mm__p8MenuFormatting(g[1],g[2])
	}
	
	mm_init()
	N=[]
	if(m){
		if(g[2]){
			mm_getChildMenus(m)
			for(a=0;a<rCM.length;a++)N[N.length]=$h(rCM[a]);
		}
		else{
			N[N.length]=m
		}
	}
	else{
		for(a=0;a<_m.length;a++)N[N.length]=a
	}
	
	rCI=[]
	for(a=0;a<N.length;a++){
		for(b=0;b<_m[N[a]][0].length;b++){
			rCI[rCI.length]=_m[N[a]][0][b]
		}
	}
	
	for(a=0;a<rCI.length;a++){
		I=_mi[rCI[a]]
		for($i in _$S){
			if(!I[_$S[$i]])
			{
				if(g[0][$i] && g[0][$i]!= "")I[_$S[$i]]=g[0][$i]
			}
		}
	}
	

	s=g[0]
	for(a=0;a<N.length;a++){
		P=N[a]
		_gm=$c("menu"+P)
		O=_gm.style
		O.borderColor=s.bordercolor?s.bordercolor:"";
		O.borderWidth=s.borderwidth?s.borderwidth:0;
		O.borderStyle=s.borderstyle?s.borderstyle:"";
		O.background=s.offbgcolor?s.offbgcolor:"";
		O.filter=null
		_m[P][15]=s.overfilter?s.overfilter:"";
		_m[P][16]=s.outfilter?s.outfilter:"";
		_m[P][6]=g[0]
		_m[P][23]=0
		O.backgroundImage=s.menubgimage?"url("+s.menubgimage+")":"";
		if(s.high3dcolor&&s.low3dcolor){
			O.borderBottomColor=s.low3dcolor
			O.borderRightColor=s.low3dcolor
			O.borderTopColor=s.high3dcolor
			O.borderLeftColor=s.high3dcolor
		}	
		_mg=_mi[_m[P][0][0]][68]
		if(_mg||_mg==0)O.padding=_mg
		_m[P][6][65]=$pU(O.borderWidth)	
		if(_m[P][7]||O.visibility==$6){
			_gm.innerHTML=o$(P)
			$z(P)
		}
	}
}

function mm_init()
{
	rCI=[]
	rCM=[]
}


function mm__p8MenuFormatting()
{
	var s,i,g,m,N,p;
	g=arguments;
	if(g[0]){
		if(isNaN(g[0]))m=$h(g[0]); else m=g[0]
	}
	
	mm_init()
	N=[]
	if(m){
		if(g[1]){
			mm_getChildMenus(m)
			for(a=0;a<rCM.length;a++)N[N.length]=$h(rCM[a]);
		}
		else{
			N[N.length]=m
		}
	}
	else{
		for(a=0;a<_m.length;a++)N[N.length]=a
	}
	
	rCI=[]
	for(a=0;a<N.length;a++){
		for(b=0;b<_m[N[a]][0].length;b++){
			rCI[rCI.length]=_m[N[a]][0][b]
		}
	}
	
	for($i in _$S){
		s=_$S[$i];
		for(a=0;a<rCI.length;a++){
			i=_mi[rCI[a]]
			if(s>3&&i[s])				
				if(i[s]==_m[i[0]][6][$i])i[s]=null
		}
	}	

	for(a=0;a<N.length;a++){
		P=N[a]
		_m[P][15]=""
		_m[P][16]=""
		_gm=$c("menu"+P)
		g=_gm.style
		g.backgroundImage="";
		g.backgroundColor="";
		g.borderColor="";
		g.borderWidth="";
		g.borderStyle="";
		g.filter=null;
		g.borderBottomColor="";
		g.borderRightColor="";
		g.borderTopColor="";
		g.borderLeftColor="";
		g.padding="";
		
		if(_m[P][7]||g.visibility==$6){
			_gm.innerHTML=o$(P)
			$z(P)
		}
	}
	
}



function mm_cloneMenu()
{


}

function mm_returnMenuItemCount(m)
{
	if(isNaN(m))m=$h(m)
	return _m[m][0].length
}


function mm_replace(h,n,r){
	h=$tL(h)
	for(var x=0;x<_mi.length;x++)if(_mi[x][_$S[h]])_mi[x][_$S[h]]=_mi[x][_$S[h]].replace(n,r)
	for(var x=0;x<_m.length;x++)_rbMenus(x)
}

function mm_returnItemPos(i){
	var M=_m[_mi[i][0]][0]
	for(var a=0;a<M.length;a++)if(M[a]==i)return a;
	return -1
}

function _gM3nu(m){
	if(isNaN(m))_mN=$h(m); else _mN=m
	return _mN
}

function _rbMenus(m){
	for(var r=0;r<_m.length;r++){
		_m[r][23]=0;
		_gm=$c("menu"+r)
		if(!_gm)return
		if(_gm.style.visibility==$6||_m[r][7]){
			_gm.innerHTML=o$(r);
			p$(r);
			_mcnt--;
		}
		else{
			_gm.innerHTML="";
			$z(m);
		}
	}
}

function _eMD(d) { 
	_it=d.split(":"); 
	return _it[1].replace(/;/g,"") 
} 

function mm_deleteItemByItemRef(r){
	$m=_mi[r][0]
	_mis=_m[$m][0]
	for(var b=0;b<_mis.length;b++)if(_mis[b]==r)mm_deleteItem($m, b+1)
}


function mm_deleteItemByText(t){
	for(var b=0;b<_mi.length;b++)if(_mi[b][1]==t)mm_deleteItemByItemRef(b)
}

function reverseSort(a, b){
if(a>b)return -1;
if(a<b)return 1;
return 0 
} 


function mm_sortItems(m,o){
	m=_gM3nu(m)
	var a=[]
	var ta=[];
	for(var b=0;b<_m[m][0].length;b++){
		var i=_m[m][0][b]
		a[a.length]=_mi[i][1]+"#@`}#`"+b
	}	
	if(o==1)a.sort(); else a.sort(reverseSort);
	var cnt=_m[m][0][0]
	for(var b=0;b<a.length;b++){
		var z=a[b].split("#@`}#`")
		var I=_m[m][0][z[1]]
		ta[cnt]=[]
		for(var x=0;x<_mi[I].length;x++)ta[cnt][x]=_mi[I][x]
		cnt++
	}
	for(var b=0;b<_m[m][0].length;b++){		
		I=_m[m][0][b]
		for(var x=0;x<_mi[_m[m][0][z[1]]].length;x++)_mi[I][x]=ta[I][x]
	}
	_rbMenus(m)	
}



function mm_addItemByItemRef(a,i){
	var $m=_mi[a][0]
	_mis=_m[$m][0]
	
	for(var b=0;b<_mis.length;b++){
		if(_mis[b]==a){
			mm_insertItem($m, (b+1), i);
			return
		}
		
	}
}

function mm_editItemByItemRef(i,t){
	$m=_mi[i][0]
	_mis=_m[$m][0]
	for(var b=0;b<_mis.length;b++)if(_mis[b]==i)mm_editItem($m, b, t)
}

function mm_deleteItem(_mN, _iN){
	_mnO=_gM3nu(_mN)
	_ii=_m[_mnO][0][_iN-1];
	_tA=[];
	for(_r=0;_r<_mi.length;_r++){
		if(_r!=_ii)_tA[_tA.length]=_mi[_r];
	}
	_mi=_tA;
	_tA=[];
	_cnt=0;
	for(_r=0;_r<_m[_mnO][0].length;_r++){
		if(_m[_mnO][0][_r]!=_ii){
			_tA[_tA.length]=_m[_mnO][0][_cnt];
			_cnt++;
		}
	}
	_m[_mnO][0]=_tA;
	for(_r=_mnO+1;_r<_m.length;_r++){
		for(_p=0;_p<_m[_r][0].length;_p++){
			_m[_r][0][_p]--;
		}
	}
	_rbMenus(_mnO);
}

function _zeroShift(m,i){
	var b=_m[m][0].length-1
	_blB=_bl
	for(var a=0;a<b;a++){
		if(i==0)mm_shiftItem(_blB,-1,1)
		_blB--
	}
}

_mmiI_TO=_n
function mm_insertItem()
{
	var r=arguments
	_mN=r[0];
	_iN=r[1];
	_aI=r[2];
	_mn=_gM3nu(_mN)
	_ii=_m[_mn][0][_iN-1];
	if(_ii+" "==$u)_ii=_m[_mn][0][_m[_mn][0].length-1];
	_tA=[];
	for(_r=0;_r<_mi.length;_r++){
		if(_r==_ii){
			_tA[_tA.length]=_mi[_r];
			_c=_mn;
			_x=_m[_c];
			_bl=_ii;
			f_(_aI);
			//udtb("in "+ _bl + " - " +_m[_mn][0] + " - " + _iN)
		}
		_tA[_tA.length]=_mi[_r];
	}
	_mi=_tA;
	for(_r=0;_r<_m.length;_r++){
		_tA=[];
		for(_p=0;_p<_mi.length;_p++){
			if(_mi[_p][0]==_r)_tA[_tA.length]=_p;
		}
		_m[_r][0]=_tA;
	}
	
	if(_startM){
		_mmiI_TO=$P(_mmiI_TO)	
		_mmiI_TO=_StO("_zeroShift("+_mn+","+_iN+");_rbMenus("+_mn+")",150);
		return
	}
	_zeroShift(_mn,_iN)
	if(!r[3])_rbMenus(_mn)
}





function mm_editItem()
{
	var r=arguments
	_mN=r[0];
	_iN=r[1];
	i=r[2];
	_mnO=_gM3nu(_mN)
	_ii=_m[_mnO][0][_iN];
	i=i.split(";");
	_sc=""
	for(var a=0;a<i.length;a++){		
		var p=i[a].indexOf("`");
		if(p!=-1){
			_sc=";"
			_tI=i[a]
			if(p==i[a].lastIndexOf("`")){
				for(var b=a;b<i.length;b++){
					if(i[b+1]){
						_tI+=";"+i[b+1];
						a++;
						if(i[b+1].indexOf("`")!=-1)b=i.length;
					}
				}
			}
			i[a]=_tI.replace(/`/g,"")
		}

		p=i[a].indexOf("=");	
		if(p==-1){
			if(i[a])_si=_si+";"+i[a]+_sc
		}
		else{
			_si=i[a].slice(p+1);
			_w=i[a].slice(0,p);	
			if(_w=="showmenu")_si=$tL(_si)
		}
		_mi[_ii][_$S[_w]]=_si;
	}
	if(!r[3])_rbMenus(_mnO);

}


function mm_shiftItem(){
	// i: itemRef to shift
	// s: number of shifts
	//rB: DO NOT rebuild the menu (makes things faster)
	var g=arguments, i=g[0],s=g[1],rB=g[2]
	$m=_mi[i][0]
	_mni=_m[$m][0]
	_sWi=(i+s)
	if(_sWi>=_mni[0]&&_sWi<=_mni[_mni.length-1]){
		var t=[]
		for(var r=0;r<_mi[i].length;r++){
			t[r]=_mi[i][r]
			_mi[i][r]=_mi[_sWi][r]
			_mi[_sWi][r]=t[r]
		}
		if(!rB){
			_rbMenus($m)
			selectedItem=_sWi
			h$(selectedItem)
		}
		
	}
}

function mm_addMenu()
{	
	var a=arguments
	var n=_m.length;
	with(milonic=new menuname("newmenu"+n)){
		style=a[0];
		alwaysvisible=true;
		if(a[1])eval(a[1])
		_itemProps=""
		if(a[2])_itemProps=a[2]
		_bl=_mi.length
		aI("text=New Item;"+_itemProps);
	}
	mm_createNewMenus();
	popup("newmenu"+n,1)
	return n;
}


function mm_createNewMenus() { 
	$r();
	_startM=0
	for(var y=_mcnt;y<_m.length;y++) { 
		var M=_m[y]
		var o=_d.createElement("div") 
		o.id="menu"+y 
		o.onmouseout=new Function("$I()"); 
		o.onmouseover=new Function("$J("+y+")"); 
		o.onselectstart=new Function("return _f"); 
		if(_dB.appendChild){
			_dB.appendChild(o) 
			o$(y,0) 
			o.className=_cls 
			var n=o.style 
			if(M[17])n.width=M[17]+"px"
			if(M[24])n.height=M[24]+"px"
			if(_ofb)n.background=_eMD(_ofb) 
			if(p_)n.border=_eMD(p_) 
			o.style.zindex=999 
			o.style.visibility=_visi 
			if(n_)n.position=_eMD(n_) 
			if($k)n.top=_eMD($k) 
			if($l)n.left=_eMD($l) 
			if(_bgimg)n.backgroundImage=_eMD(_bgimg);
			if(_mbgc)n.background=_eMD(_mbgc) 
			M[23]=0 
		}
	} 
} 

function mm_deleteMenu(m)
{
	m=_gM3nu(m)
	if(_m[m]){
		_mLth=_m[m][0].length
		for(var r=1;r<_mLth+1;r++)mm_deleteItem(m, 1)
	}
	var t=[]
	for(var r=0;r<m;r++)t[r]=_m[r]
	_gmo=$c("menu"+m)
	if(!_gmo)return
	_gmo.id="mm_deleted"
	_dB.removeChild(_gmo)
	for(var r=m+1;r<_m.length;r++){
		for(var q=0;q<_m[r][0].length;q++)_mi[_m[r][0][q]][0]=_mi[_m[r][0][q]][0]-1
		t[r-1]=_m[r]
		$c("menu"+(r)).id="menu"+(r-1)
		if($c("mmlink"+(r)))$c("mmlink"+(r)).id="mmlink"+(r-1)
	}
	_trueItemRef=-1
	_m=t
	_itemRef=-1
	_mcnt--
	_mn=_mcnt-1
}

rCM=[]
rCI=[]
function mm_getChildMenus(m){
	m=_gM3nu(m)
	if(m+" "==$u)return
	if(rCM.length==0)rCM[rCM.length]=_m[m][1]
	for(var a=0;a<_m[m][0].length;a++){
		var i=_m[m][0][a]
		var I=_mi[i]
		rCI[rCI.length]=i
		if(I[3]){
			rCM[rCM.length]=I[3]
			mm_getChildMenus(I[3])
		}
	}
}

function mm_deleteChildMenus(m){
	mm_init()	
	mm_getChildMenus(m)
	for(var a=0;a<rCM.length;a++){
		mm_deleteMenu(rCM[a])
	}
	
}


function showObjProps(_w)
{
	a=document.getElementById("objProps")
	if(!a)
	{
		var a=document.createElement("div")
		a.id="objProps" 
		if(document.body.appendChild)
		{
			document.body.appendChild(a)
			a.style.position="absolute"
			a.style.border="1px solid gray"
			a.style.padding=4
			a.style.top=200
			a.style.left=100
			a.style.height=350
			a.style.width=350
			a.style.fontFamily="verdana"
			a.style.fontSize="10px"
			a.style.overflow="scroll"
			a.style.background="white"
			
		}

	}
	
	var h=""
	for(_cO in _w)
	{
		if(_w[_cO]!="")
		h+=_cO+" - '" +_w[_cO]+"'<br>"
	}
	h.replace(/ /g,"&nbsp;") 
	a.innerHTML=h
}