/*
Copyright Scand LLC http://www.scbr.com
To use this component please contact info@scbr.com to obtain license

*/ 

 
function eXcell_cntr(cell){
 this.cell = cell;
 this.grid = this.cell.parentNode.grid;
 if((this.grid.setOnOpenEndHandler)&&(!this.grid._ex_cntr_ready)){
 this.grid._ex_cntr_ready=true;
 this.grid.setOnOpenEndHandler(function(id){
 this.resetCounter(0);
 
});
}

 this.edit = function(){}
 this.getValue = function(){
 return this.cell.parentNode.rowIndex;
}
 this.setValue = function(val){
 this.cell.style.paddingRight = "2px";
 var cell=this.cell;
 window.setTimeout(function(){
 var val=cell.parentNode.rowIndex;
 cell.innerHTML = val;
 if(cell.parentNode.grid._fake)cell.parentNode.grid._fake.cells(cell.parentNode.idd,cell._cellIndex).setValue(val);
 cell=null;
},100);
}
}
dhtmlXGridObject.prototype.resetCounter=function(ind){
 for(var i=0;i<this.rowsCol.length;i++)
 this.rowsCol[i].cells[ind].innerHTML=i+1;
}
eXcell_cntr.prototype = new eXcell;

