// JavaScript Document
var OrderList = {
	LoadGrid:function(page) {
		
			mygrid = new dhtmlXGridObject('dataGrid')
			mygrid.setImagePath('/script/grid/imgs/');
			mygrid.setHeader("Order,Date,Invoice,Customer Name,Email,Status,Total,,Commends");
			mygrid.setInitWidths("50,100,50,150,200,100,80,20,173")
			//mygrid.enablePaging(true,40,null,'gridPaging',false); 
			mygrid.setColAlign("center,center,left,left,left,left,right,left,left")
			mygrid.setColTypes("ro,ro,ro,ro,ro,ro,ro,ro,ro");
			mygrid.setColSorting("int,date,str,str,int,str,int,str,str") 		
			mygrid.init();
			mygrid.setOnLoadingEnd( function() {
								AJS.hideElement(AJS.$('loadDiv'))	
				}
			)
			mygrid.setOnLoadingStart( function() {			
					AJS.showElement(AJS.$('loadDiv'))	
					var pos = PosMill.Center2Object(AJS.$('loadDiv'),AJS.$('dataGrid'))
					pos.y-=300
					PosMill.InforcePos(AJS.$('loadDiv'),pos)
					

				}
			)
			
			
		var _ajax = AJS.getRequest('/ajax/orders_ajax.aspx?count=1',null,null,'xml')
		
				//alert('/ajax/ajax_db.aspx?req='+req+'&id='+id+'&hashstr='+hashstr)
		_ajax.addCallback(function(xmlroot) { 
								   
						var items = parseInt(xmlroot.getElementsByTagName('count')[0].text)
						if (items > 0 ) {
						//	items = 4
						pages = (items % 100 == 0 ) ? items/100 : (items - items % 100 ) / 100 + 1 
						var pagesContainer = AJS.$('gridPaging')
						for (var i=1;i <= pages;i++) {
							var pagelink = AJS.A()
							pagelink.href='javascript:void(0)'
							pagelink.onclick = _click(i)
							pagelink.innerHTML=i + ' '
							AJS.ACN(pagesContainer,pagelink)
						}
						
						}
						
					function _click(i) {
						
						return function() {
								mygrid.clearAll()
								mygrid.loadXML('/ajax/orders_ajax.aspx?page='+i)
						}
						
					}
								   
				}				   
		 )
		 
		_ajax.sendReq()
		
		
			//starts with page =1
			mygrid.loadXML('/ajax/orders_ajax.aspx?page='+page)
	},
	PreformSearch:function() {
		
		var hash = new Hashtable()
		var ordernumber = AJS.$('ordernumber').value
		var itemnumber = AJS.$('itemnumber').value
		var email = AJS.$('email').value
		
		if (ordernumber != '' ) {
			hash.put('ordernumber',ordernumber)
		}
		
		if (email != '' ) {
			hash.put('email',email)
		}
		
		if (itemnumber != '' ) {
			hash.put('itemnumber',itemnumber)
		}
		
		mygrid.clearAll()
		
		
		
		
		
		//alert('/ajax/inventory_ajax.aspx'+CreateQSfromHash(hash))
		
		mygrid.loadXML('/ajax/orders_ajax.aspx'+CreateQSfromHash(hash)+'&page=1')
		
		
		
		
		
	}
	
}