/*
Copyright Scand LLC http://www.scbr.com
To use this component please contact info@scbr.com to obtain license

*/function dhtmlXGridFromTable(obj){
 if(typeof(obj)!='object')
 obj = document.getElementById(obj);

 var w=document.createElement("DIV");
 w.setAttribute("width",obj.getAttribute("gridWidth")||(obj.offsetWidth+"px"));
 w.setAttribute("height",obj.getAttribute("gridHeight")||(obj.offsetHeight+"px"));

 var mr=obj;
 var drag=obj.getAttribute("dragAndDrop");

 mr.parentNode.insertBefore(w,mr);
 var f=mr.getAttribute("name")||("name_"+(new Date()).valueOf());

 var windowf=new dhtmlXGridObject(w);
 windowf.setImagePath(mr.getAttribute("imgpath")||"");

 var hrow=mr.rows[0];
 var za="";
 var zb="";
 var zc="";
 var zd="";
 var ze="";

 for(var i=0;i<hrow.cells.length;i++){
 za+=(za?",":"")+hrow.cells[i].innerHTML;
 zb+=(zb?",":"")+(parseInt(hrow.cells[i].getAttribute("width")||hrow.cells[i].offsetWidth));
 zc+=(zc?",":"")+(hrow.cells[i].getAttribute("align")||"left");
 zd+=(zd?",":"")+(hrow.cells[i].getAttribute("type")||"ed");
 ze+=(ze?",":"")+(hrow.cells[i].getAttribute("sort")||"str");
}

 windowf.setHeader(za);
 windowf.setInitWidths(zb)
 windowf.setColAlign(zc)
 windowf.setColTypes(zd);
 windowf.setColSorting(ze);
 if(obj.getAttribute("gridHeight")=="auto")
 windowf.enableAutoHeigth(true);

 if(obj.getAttribute("multiline"))windowf.enableMultiline(true);

 var lmn=mr.getAttribute("lightnavigation");
 if(lmn)windowf.enableLightMouseNavigation(lmn);

 var evr=mr.getAttribute("evenrow");
 var uevr=mr.getAttribute("unevenrow");

 if(evr||uevr)windowf.enableAlterCss(evr,uevr);
 if(drag)windowf.enableDragAndDrop(true);

 windowf.init();

 
 var n_l=mr.rows.length;
 for(var j=1;j<n_l;j++){
 var r=mr.rows[1];
 r.idd=r.id;
 if((!r.idd)||(windowf.rowsAr[r.idd]))
 r.idd=obj.id+"_"+j;
 windowf.rowsCol[windowf.rowsCol.length]=r;
 windowf.rowsAr[r.idd]=r;
 r.grid=windowf;

 if(evr)
 if((j%2)==1)
 r.className=evr;
 else
 r.className=uevr;


 windowf.obj.rows[0].parentNode.appendChild(r);
 for(var x=0;x<r.cells.length;x++)
 r.cells[x]._cellIndex=x;
 if(_isFF)
 for(var i=r.childNodes.length-1;i>=0;i--)
 if(r.childNodes[i].nodeType!=1)
 r.removeChild(r.childNodes[i]);

 if(drag)
 for(var i=r.childNodes.length-1;i>=0;i--)
 windowf.dragger.addDraggableItem(r.childNodes[i],windowf);
}

 mr.parentNode.removeChild(mr);

 if(obj.getAttribute("forceCellTypes"))
 for(var i=0;i<windowf.cellType.length;i++)
 if((windowf.cellType[i]=="ra")||(windowf.cellType[i]=="ch")||(windowf.cellType[i]=="img"))
 for(var j=0;j<windowf.rowsCol.length;j++)
 windowf.cells2(j,i).setValue(windowf.rowsCol[j].cells[i].innerHTML);

 windowf.setSizes();
 window[f]=windowf;
 return windowf;

}

function dhx_init_grids(){
 var z=document.getElementsByTagName("table");
 for(var a=0;a<z.length;a++)
 if(z[a].className=="dhtmlxGrid"){
 dhtmlXGridFromTable(z[a]);
 
}
}

if(window.addEventListener)window.addEventListener("load",dhx_init_grids,false);
else if(window.attachEvent)window.attachEvent("onload",dhx_init_grids);




