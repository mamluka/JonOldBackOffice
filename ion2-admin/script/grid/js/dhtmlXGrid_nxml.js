/*
Copyright Scand LLC http://www.scbr.com
To use this component please contact info@scbr.com to obtain license

*/ 

 
dhtmlXGridObject.prototype.useCSV = function(path){
 if(!this._csv_loadXML){
 this._csv_loadXML=this.loadXML;
 this._csv_loadXMLString=this.loadXMLString;
 this.loadXML=this.loadCSVFile;
 this.loadXMLString=this.loadCSVFile;
}
}


 
dhtmlXGridObject.prototype.loadCSVFile = function(path){
 this.xmlLoader = new dtmlXMLLoaderObject(this._onCSVFileLoad,this);
 this.xmlLoader.loadXML(path);
}
dhtmlXGridObject.prototype._onCSVFileLoad=function(obj,b,c,d,xml){
 var z=this.xmlDoc.responseText;
 obj.loadCSVString(z);
}

 
dhtmlXGridObject.prototype.enableCSVAutoID = function(mode){
 this._csvAID=convertStringToBoolean(mode);
}
 
dhtmlXGridObject.prototype.enableCSVHeader = function(mode){
 this._csvHdr=convertStringToBoolean(mode);
 if(this._csvHdr)this.enableCSVAutoID(true);
}

 
dhtmlXGridObject.prototype.setCSVDelimiter = function(str){
 this._csvDelim=(str||this._csvDelim);
 this._csvDelimX=this._csvDelim.charCodeAt(0);
 var trans=[0,1,2,3,4,5,6,7,8,9,"A","B","C","D","E","F"];
 this._csvDelimX="\\x"+trans[Math.floor(this._csvDelimX/16)]+""+trans[(this._csvDelimX%16)];
}

 
dhtmlXGridObject.prototype.loadCSVString = function(str){
 if(!this._csvDelimX)this.setCSVDelimiter();
 var r1=new RegExp("^([^"+this._csvDelimX+"]+)"+this._csvDelimX);
 var r2=new RegExp("\n([^"+this._csvDelimX+"]+)"+this._csvDelimX,"g");
 var r3=new RegExp(""+this._csvDelimX+"","g");
 if(this._csvHdr){
 hdr=str.substr(0,str.indexOf("\n"));
 str=str.substr(str.indexOf("\n")+1);
 hdr="<head><beforeInit><call command='setHeader'><param>"+hdr.replace(new RegExp(this._csvDelimX),",")+"</param></call><call command='init'></call></beforeInit></head>";
}
 if(this._csvAID){
 str=str.replace(r1,"<row><cell><![CDATA[$1]]></cell><cell><![CDATA[");
 str=str.replace(r2,"]]></cell></row><row id=''><cell><![CDATA[$1]]></cell><cell><![CDATA[");
}
 else{
 str=str.replace(r1,"<row id='$1'><cell><![CDATA[");
 str=str.replace(r2,"]]></cell></row><row id='$1'><cell><![CDATA[");
}

 str=str.replace(r3,"]]></cell><cell><![CDATA[");
 str="<?xml version='1.0'?><rows>"+(this._csvHdr?(hdr+str):str)+"]]></cell></row></rows>";
 this.xmlLoader = new dtmlXMLLoaderObject(this.doLoadDetails,window,true,this.no_cashe);
 this.xmlLoader.loadXMLString(str);
}

 
dhtmlXGridObject.prototype.serializeToCSV = function(name){
 this.editStop()
 if(this._mathSerialization)
 this._agetm="getMathValue";
 else this._agetm="getValue";

 var out="";
 
 var i=0;
 var leni=(this._dload)?this.rowsBuffer[0].length:this.rowsCol.length;
 for(i;i<leni;i++){
 var r = this.rowsCol[i];
 var temp=this._serializeRowToCVS(r,i)
 out+= temp;
 if(temp!="")out+= "\n";
}

 return out;
}

 
dhtmlXGridObject.prototype._serializeRowToCVS = function(r,i){
 var out = new Array();

 if((!r)||(r._sRow)||(r._rLoad)){
 if(this.rowsBuffer[1][i]){
 var r=this.rowsBuffer[1][i];
 if(!this._csvAID)
 out[out.length]=r.getAttribute("id");
 for(var j=0;j<r.childNodes.length;j++){
 if(r.childNodes[j].tagName=="cell"){
 var c=r.childNodes[j];
 out[out.length]=c.firstChild?c.firstChild.nodeValue:"";
}}

}
 return out;
}

 if(!this._csvAID)
 out[out.length]=r.idd;


 
 var changeFl=false;
 for(var jj=0;jj<r.childNodes.length;jj++)
 if((!this._srClmn)||(this._srClmn[jj])){
 var cvx=r.childNodes[jj];
 

 var zx=this.cells(r.idd,cvx._cellIndex);
 if(zx.cell)
 zxVal=zx[this._agetm]();
 else zxVal="";


 if((this._chAttr)&&(zx.wasChanged()))
 changeFl=true;

 out[out.length]=((zxVal===null)?"":zxVal)
 
 if((this._ecspn)&&(cvx.colSpan)){
 cvx=cvx.colSpan-1;
 for(var u=0;u<cvx;u++)
 out[out.length] = "";
}
 

}
 if((this._onlChAttr)&&(!changeFl))return "";
 return out.join(this._csvDelim);
}

dhtmlXGridObject.prototype.toClipBoard=function(val){
 if(window.clipboardData)
 window.clipboardData.setData("Text",val);
 else
(new Clipboard()).copy(val);

}
dhtmlXGridObject.prototype.fromClipBoard=function(){
 if(window.clipboardData)
 return window.clipboardData.getData("Text");
 else
 return(new Clipboard()).paste();
}

 
dhtmlXGridObject.prototype.cellToClipboard = function(rowId,cellInd){
 if((!rowId)||(!cellInd)){
 if(!this.selectedRows[0])return;
 rowId=this.selectedRows[0].idd;
 cellInd=this.cell._cellIndex;
}
 var ed=this.cells(rowId,cellInd);
 this.toClipBoard(ed.getLabel?ed.getLabel():ed.getValue());
}

 
dhtmlXGridObject.prototype.updateCellFromClipboard = function(rowId,cellInd){
 if((!rowId)||(!cellInd)){
 if(!this.selectedRows[0])return;
 rowId=this.selectedRows[0].idd;
 cellInd=this.cell._cellIndex;
}
 var ed=this.cells(rowId,cellInd);
 ed[ed.setLabeL?"setLabeL":"setValue"](this.fromClipBoard());
}

 
dhtmlXGridObject.prototype.rowToClipboard = function(rowId){
 var out="";
 if(this._mathSerialization)
 this._agetm="getMathValue";
 else this._agetm="getValue";
 if(rowId)
 out=this._serializeRowToCVS(this.getRowById(rowId));
 else
 for(var i=0;i<this.selectedRows.length;i++){
 if(out)out+="\n";
 out+=this._serializeRowToCVS(this.selectedRows[i]);
}
 this.toClipBoard(out);
}

 
dhtmlXGridObject.prototype.updateRowFromClipboard = function(rowId){
 var csv=this.fromClipBoard();
 if(!csv)return;
 if(rowId)
 var r=this.getRowById(rowId);
 else
 var r=this.selectedRows[0];
 if(!r)return;
 csv=csv.split(this._csvDelim);
 for(var i=1;i<csv.length;i++){
 var ed=this.cells3(r,i-1);
 ed[ed.setLabeL?"setLabeL":"setValue"](csv[i]);
}
}

 
dhtmlXGridObject.prototype.addRowFromClipboard = function(){
 var csv=this.fromClipBoard();
 if(!csv)return;
 var z=csv.split("\n");
 for(var i=0;i<z.length;i++)
 if(z[i]){
 csv=z[i].split(this._csvDelim);
 this.addRow(csv[0],csv.slice(1));
}
}

 
dhtmlXGridObject.prototype.gridToClipboard = function(){
 this.toClipBoard(this.serializeToCSV());
}

 
dhtmlXGridObject.prototype.gridFromClipboard = function(){
 var csv=this.fromClipBoard();
 if(!csv)return;
 this.loadCSVString(csv);
}

 
dhtmlXGridObject.prototype.getXLS = function(path){
 if(!this.xslform){
 this.xslform=document.createElement("FORM");
 this.xslform.action=(path||"")+"xls.php";
 this.xslform.method="post";
 this.xslform.target=(_isIE?"_blank":"");
 document.body.appendChild(this.xslform);
 var i1=document.createElement("INPUT");
 i1.type="hidden";
 i1.name="csv";
 this.xslform.appendChild(i1);
 var i2=document.createElement("INPUT");
 i2.type="hidden";
 i2.name="csv_header";
 this.xslform.appendChild(i2);
}
 var cvs = this.serializeToCSV();
 this.xslform.childNodes[0].value = cvs;
 var cvs_header = [];
 var l = this._cCount;
 for(var i=0;i<l;i++){
 cvs_header.push(this.getHeaderCol(i));
}
 cvs_header = cvs_header.join(',');
 this.xslform.childNodes[1].value = cvs_header;
 this.xslform.submit();
}

 
dhtmlXGridObject.prototype.printView = function(path){
 var html = '<table width="100%" border="2px" cellpadding="0" cellspacing="0">';
 var row_length = this.rowsCol.length;
 var col_length = this._cCount;
 var width = this._printWidth();

 html+= '<tr>';
 for(var i=0;i<col_length;i++){
 html+= '<td width="'+width[i]+'%" style="padding-left:2px;padding-right:2px;background-color:lightgray;">'+this.getHeaderCol(i)+'</td>';
}
 html+= '</tr>';

 for(var i=0;i<row_length;i++){
 html+= '<tr>';
 for(var j=0;j<col_length;j++){
 var value = this.cells(this.rowsCol[i].idd,j).getValue();
 var color = this.columnColor[j]?'background-color:'+this.columnColor[j]+';':'';
 var align = this.cellAlign[j]?'text-align:'+this.cellAlign[j]+';':'';
 html+= '<td style="padding-left:2px;padding-right:2px;'+color+align+'">'+value+'</td>';
}
 html+= '</tr>';
}

 html+= '</table>';
 var d = window.open('','_blank');
 d.document.write(html);
 d.document.close();
}
dhtmlXGridObject.prototype._printWidth=function(){
 var width = [];
 var total_width = 0;
 for(var i=0;i<this._cCount;i++){
 var w = this.getColWidth(i);
 width.push(w);
 total_width+= w;
}
 var percent_width = [];
 var total_percent_width = 0;
 for(var i=0;i<width.length;i++){
 var p = Math.floor((width[i]/total_width)*100);
 total_percent_width+= p;
 percent_width.push(p);
}
 percent_width[percent_width.length-1]+= 100-total_percent_width;
 return percent_width;
}
 
dhtmlXGridObject.prototype.loadObject = function(obj){
}


 
dhtmlXGridObject.prototype.loadJSONFile = function(path){
}


 
dhtmlXGridObject.prototype.serializeToObject = function(){
}

 
dhtmlXGridObject.prototype.serializeToJSON = function(){
}





