

function CreateQSfromHash(hash) {
	var arr = new Array()
	for (var key in hash.hashtable) {
		arr.push(key+'='+hash.hashtable[key])
	}
	if (arr.length > 0) {
	return '?'+arr.join('&')
	} else {
		
		return ''
	}
		
	
}

function GetCheckIMGbyBoolean(bool) {
	if (bool == 1 ) {
		return '/pic/newconst/inventory/base/checkmark.gif'
	}
	else {
		return '/pic/newconst/inventory/base/xmark.gif'
	}
}


function GetHashArrayFromStr(str,itemdelim,valdelim) {
	
	var item_array = str.split(itemdelim)
	var tmpArray = new Object()
	for (var i=0;i<item_array.length;i++) {

		tmpArray[item_array[i].split(valdelim)[0]] = item_array[i].split(valdelim)[1]
		
	}
	
	return tmpArray
	
	
}

function GetStrFromHash(hash,itemdelim,valdelim) {
	
	var item_array = new Array()
	for ( var key in hash ) {
		
		item_array.push(key + valdelim + hash[key])
		
	}
	
	return item_array.join(itemdelim)
	
}



function Hashtable(){
    this.clear = hashtable_clear;
    this.containsKey = hashtable_containsKey;
    this.containsValue = hashtable_containsValue;
    this.get = hashtable_get;
    this.isEmpty = hashtable_isEmpty;
    this.keys = hashtable_keys;
    this.put = hashtable_put;
    this.remove = hashtable_remove;
    this.size = hashtable_size;
    this.toString = hashtable_toString;
    this.values = hashtable_values;
    this.hashtable = new Array();
}

/*=======Private methods for internal use only========*/

function hashtable_clear(){
    this.hashtable = new Array();
}

function hashtable_containsKey(key){
    var exists = false;
    for (var i in this.hashtable) {
        if (i == key && this.hashtable[i] != null) {
            exists = true;
            break;
        }
    }
    return exists;
}

function hashtable_containsValue(value){
    var contains = false;
    if (value != null) {
        for (var i in this.hashtable) {
            if (this.hashtable[i] == value) {
                contains = true;
                break;
            }
        }
    }
    return contains;
}

function hashtable_get(key){
    return this.hashtable[key];
}

function hashtable_isEmpty(){
    return (parseInt(this.size()) == 0) ? true : false;
}

function hashtable_keys(){
    var keys = new Array();
    for (var i in this.hashtable) {
        if (this.hashtable[i] != null)
            keys.push(i);
    }
    return keys;
}

function hashtable_put(key, value){
    if (key == null || value == null) {
        throw "NullPointerException {" + key + "},{" + value + "}";
    }else{
        this.hashtable[key] = value;
    }
}

function hashtable_remove(key){
    var rtn = this.hashtable[key];
    this.hashtable[key] = null;
    return rtn;
}

function hashtable_size(){
    var size = 0;
    for (var i in this.hashtable) {
        if (this.hashtable[i] != null)
            size ++;
    }
    return size;
}

function hashtable_toString(){
    var result = "";
    for (var i in this.hashtable)
    {     
        if (this.hashtable[i] != null)
            result += "{" + i + "},{" + this.hashtable[i] + "}\n";  
    }
    return result;
}

function hashtable_values(){
    var values = new Array();
    for (var i in this.hashtable) {
        if (this.hashtable[i] != null)
            values.push(this.hashtable[i]);
    }
    return values;
}

function getAnchorPosition(anchorname) {
	// This function will return an Object with x and y properties
	var useWindow=false;
	var coordinates=new Object();
	var x=0,y=0;
	// Browser capability sniffing
	var use_gebi=false, use_css=false, use_layers=false;
	if (document.getElementById) { use_gebi=true; }
	else if (document.all) { use_css=true; }
	else if (document.layers) { use_layers=true; }
	// Logic to find position
 	if (use_gebi && document.all) {
		x=AnchorPosition_getPageOffsetLeft(document.all[anchorname]);
		y=AnchorPosition_getPageOffsetTop(document.all[anchorname]);
		}
	else if (use_gebi) {
		var o=document.getElementById(anchorname);
		x=AnchorPosition_getPageOffsetLeft(o);
		y=AnchorPosition_getPageOffsetTop(o);
		}
 	else if (use_css) {
		x=AnchorPosition_getPageOffsetLeft(document.all[anchorname]);
		y=AnchorPosition_getPageOffsetTop(document.all[anchorname]);
		}
	else if (use_layers) {
		var found=0;
		for (var i=0; i<document.anchors.length; i++) {
			if (document.anchors[i].name==anchorname) { found=1; break; }
			}
		if (found==0) {
			coordinates.x=0; coordinates.y=0; return coordinates;
			}
		x=document.anchors[i].x;
		y=document.anchors[i].y;
		}
	else {
		coordinates.x=0; coordinates.y=0; return coordinates;
		}
	coordinates.x=x;
	coordinates.y=y;
	return coordinates;
	}

// getAnchorWindowPosition(anchorname)
//   This function returns an object having .x and .y properties which are the coordinates
//   of the named anchor, relative to the window
function getAnchorWindowPosition(anchorname) {
	var coordinates=getAnchorPosition(anchorname);
	var x=0;
	var y=0;
	if (document.getElementById) {
		if (isNaN(window.screenX)) {
			x=coordinates.x-document.body.scrollLeft+window.screenLeft;
			y=coordinates.y-document.body.scrollTop+window.screenTop;
			}
		else {
			x=coordinates.x+window.screenX+(window.outerWidth-window.innerWidth)-window.pageXOffset;
			y=coordinates.y+window.screenY+(window.outerHeight-24-window.innerHeight)-window.pageYOffset;
			}
		}
	else if (document.all) {
		x=coordinates.x-document.body.scrollLeft+window.screenLeft;
		y=coordinates.y-document.body.scrollTop+window.screenTop;
		}
	else if (document.layers) {
		x=coordinates.x+window.screenX+(window.outerWidth-window.innerWidth)-window.pageXOffset;
		y=coordinates.y+window.screenY+(window.outerHeight-24-window.innerHeight)-window.pageYOffset;
		}
	coordinates.x=x;
	coordinates.y=y;
	return coordinates;
	}

// Functions for IE to get position of an object
function AnchorPosition_getPageOffsetLeft (el) {
	var ol=el.offsetLeft;
	while ((el=el.offsetParent) != null) { ol += el.offsetLeft; }
	return ol;
	}
function AnchorPosition_getWindowOffsetLeft (el) {
	return AnchorPosition_getPageOffsetLeft(el)-document.body.scrollLeft;
	}	
function AnchorPosition_getPageOffsetTop (el) {
	var ot=el.offsetTop;
	while((el=el.offsetParent) != null) { ot += el.offsetTop; }
	return ot;
	}
function AnchorPosition_getWindowOffsetTop (el) {
	return AnchorPosition_getPageOffsetTop(el)-document.body.scrollTop;
	}
	

var PosMill = {
	
	CenterByView: function(w,h) {
		
		if (typeof(w) == 'object') {
		
		var w1 = w.offsetWidth
		var h1 = w.offsetHeight
		
		var pos = new Object()
		var h2 = document.body.clientHeight
		var w2 = document.body.clientWidth
		
//		alert(w2)
	
		pos.x = w2/2 - w1/2
		pos.y = h2/2 - h1/2+document.body.scrollTop
		
		//alert(pos.y)

			PosMill.InforcePos(w,pos)
			return 0
		}
		
		var pos = new Object()
		var h2 = document.body.clientHeight
		var w2 = document.body.clientWidth
		
//		alert(w2)
	
		pos.x = w2/2 - w/2
		pos.y = h2/2 - h/2+document.body.scrollTop

		return pos
		
	},
	Center2Object: function(object1,object2) {
		
			var pos = getAnchorPosition(object2.id)
			w = object2.offsetWidth
			h = object2.offsetHeight
			
			w2 = object1.offsetWidth
			h2 = object1.offsetHeight
			
			x = pos.x + w/2 - w2/2
			y = pos.y + h/2 - h2/2
			
			
			
			return { x:x,y:y }
		
	},
	InforcePos: function (obj,pos) {
		
		obj.style.position='absolute'
		obj.style.left = pos.x
		obj.style.top = pos.y
		
		
	},
	
	InforcePosParams: function (obj,x,y) {
		
		obj.style.position='absolute'
		obj.style.left = x
		obj.style.top = y
		
		
	},
	
	AlignObjectCenterHeight: function (posAtom1,h) {
		
		posAtom2 = new posXYWH()
		
		posAtom2.y = posAtom1.y-h/2
		
		return posAtom2
		
	},
	
	InforcePageTop : function(posAtom,offsety) {
		

	
		if ( posAtom.y <= document.body.scrollTop || posAtom.y <=offsety ) {
			
			posAtom.y= document.body.scrollTop+offsety
			
		}
		
		return posAtom
		
	}
	
/*	,
	PageBoundries*/
	
	
	
	
	
}
function posXYWH() {
	var x
	var y
	var w
	var h
	this.LoadbyID = function(obj) {
		if (typeof(obj) == 'object') {
			var div=obj
			var pos = AJS.absolutePosition(obj)
		}
		else {
			var div = document.getElementById(obj)
			var pos  = getAnchorPosition(obj)
		}
		
		
		this.x = pos.x
		this.y = pos.y
		this.w = div.offsetWidth
		this.h = div.offsetHeight
	}
	this.ReCalcWithOffset=function(offsetx,offsety) {
		this.x+=offsetx
		this.y+=offsety
	}
}
