	var mygrid = null

var ListItems = {
		
		LoadGrid:function(page) {
			mygrid = new dhtmlXGridObject('dataGrid')
			mygrid.setImagePath('/script/grid/imgs/');
			mygrid.setHeader("Icon, Act.,Item #,Type,Weight,,Shape,Sell Price,,Spc.,Commends");
			mygrid.setInitWidths("70,30,100,130,80,30,120,80,20,30,222")
			//mygrid.enablePaging(true,40,null,'gridPaging',false); 
			mygrid.setColAlign("center,center,left,left,right,left,left,right,left,center,left")
			mygrid.setColTypes("ro,ro,ro,ro,ro,ro,ro,ro,ro,ro,ro");
			mygrid.setColSorting("str,str,str,str,int,str,str,int,str,str,str") 		
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
			
			
		var _ajax = AJS.getRequest('/ajax/inventory_ajax.aspx?count=1',null,null,'xml')
		
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
								mygrid.loadXML('/ajax/inventory_ajax.aspx?page='+i)
						}
						
					}
								   
				}				   
		 )
		 
		_ajax.sendReq()
		
		
			//starts with page =1
			mygrid.loadXML('/ajax/inventory_ajax.aspx?page='+page)
	}
	,
	PreformSearch:function() {
		//this is implicelt function for this only not general
		var hash = new Hashtable()
		var itemnumber = AJS.$('itemnumber').value
		var type = AJS.$('bo_type_intcombo').options[AJS.$('bo_type_intcombo').selectedIndex].text
		var shape = AJS.$('bo_shape_intcombo').options[AJS.$('bo_shape_intcombo').selectedIndex].text
		
		var w_from  = AJS.$('w_from').value
		var w_to  = AJS.$('w_to').value
		
		var p_from = AJS.$('p_from').value
		var p_to = AJS.$('p_to').value
		
		var active = AJS.$('bo_active').checked
		var special = AJS.$('bo_special').checked
		var pictures = AJS.$('bo_pictures').checked
		
		
		if ( itemnumber != '') {
			hash.put('itemnumber',itemnumber)
		}
		
		
		if ( type != 'N/A') {
			hash.put('type',type)
		}
		
		if ( shape != 'N/A') {
			hash.put('shape',shape)
		}
		
		if (w_from != '') {
			if ( w_to == '' ) {
				hash.put('weight',w_from+'to'+w_from)
			}
			else {
				hash.put('weight',w_from+'to'+w_to)
			}
		}
		
		if (p_from != '') {
			if ( p_to == '' ) {
				hash.put('price',p_from+'to'+p_from)
			}
			else {
				hash.put('price',p_from+'to'+p_to)
			}
		}
		
		if (active) {
			hash.put('active','1')
		}
		
		if (special) {
			hash.put('onspecial','1')
		}
		
		if (pictures) {
			hash.put('pictures','1')
		}
		
	
		
		var _ajax = AJS.getRequest('/ajax/inventory_ajax.aspx'+CreateQSfromHash(hash)+'&count=1',null,null,'xml')
		
				//alert('/ajax/ajax_db.aspx?req='+req+'&id='+id+'&hashstr='+hashstr)
		_ajax.addCallback(AJS.bind( function(xmlroot) { 
								   
						var items = parseInt(xmlroot.getElementsByTagName('count')[0].text)
						if (items > 0 ) {
						//	items = 4
							pages = (items % 100 == 0 ) ? items/100 : (items - items % 100 ) / 100 + 1 
							var pagesContainer = AJS.$('gridPaging')
							pagesContainer.innerHTML='';
							for (var i=1;i <= pages;i++) {
								var pagelink = AJS.A()
								pagelink.href='javascript:void(0)'
								pagelink.onclick = _click(i,this.qs)
								pagelink.innerHTML=i + ' '
								AJS.ACN(pagesContainer,pagelink)
							}
						
						}
						
					function _click(i,qs) {
						//alert(qs)
						return function() {
								mygrid.clearAll()
								mygrid.loadXML('/ajax/inventory_ajax.aspx'+qs+'&page='+i)
						}
						
					}
								   
				},{qs:CreateQSfromHash(hash)} )	)
		_ajax.sendReq()
		
		
		mygrid.clearAll()
		
		
		
		
		
		//alert('/ajax/inventory_ajax.aspx'+CreateQSfromHash(hash))
		
		mygrid.loadXML('/ajax/inventory_ajax.aspx'+CreateQSfromHash(hash)+'&page=1')
		
			

		
		//ListItems.HoverPicture('sdfsdf',AJS.$('bo_type_intcombo'))
		
		
	}
	,
	HoverPicture:function(picsrc,obj) {
		
		if  (AJS.$('bo_hoverpicture') ) { AJS.removeElement(AJS.$('bo_hoverpicture')) } 
		
		var imgdiv = AJS.DIV()
		
		AJS.AEV(imgdiv,'click',function() { ListItems.KillHoverPicture() } )
		
		imgdiv.style.backgroundColor='white'
		imgdiv.style.border='1px black dotted'
		
		imgdiv.id='bo_hoverpicture'
		var img = AJS.IMG()
		img.style.margin='10'
		//AJS.AEV(img,'load',function() {  } )
		img.src=picsrc
		var pos = new posXYWH()
		
		pos.LoadbyID(obj)
		PosMill.InforcePosParams(imgdiv,pos.x,pos.y+10)
		
		AJS.ACN(imgdiv,img)
		AJS.ACN(AJS.getBody(),imgdiv)
		
		
	},
	KillHoverPicture:function() {
		if  (AJS.$('bo_hoverpicture') ) { AJS.removeElement(AJS.$('bo_hoverpicture')) } 
	},
	ActivateItem:function(obj,id) {
		
		var hash = new Array()
		hash['active'] = (obj['active']  == '1') ? 0 : 1
		
		AJAXMill.SendtoDB(1,id,hash,AJS.bind(function(answer) {
													  
				var obj = this.obj
		
				if (obj['active']  == '1' ) {
				
					obj.src = GetCheckIMGbyBoolean(0)
					obj['active']='0'
				} else {
					
					obj.src = GetCheckIMGbyBoolean(1)
					obj['active']='1'
					
					
				}
			} , { obj:obj } ) )  
	
	},
	ActivateItemCheckBox:function(obj,id) {
		var hash = new Array()
		hash['active'] = ( obj.checked  == false ) ? 0 : 1
		
		AJAXMill.SendtoDB(1,id,hash,AJS.bind(function(answer) {
													  
				var obj = this.obj
		
				if (obj['active']  == '1' ) {
				
					obj.src = GetCheckIMGbyBoolean(0)
					obj['active']='0'
				} else {
					
					obj.src = GetCheckIMGbyBoolean(1)
					obj['active']='1'
					
					
				}
			} , { obj:obj } ) )  
	},
	DefaultItemCheckBox:function(obj,id) {
		var hash = new Array()
		hash['default'] = ( obj.checked  == false ) ? 0 : 1
		
		AJAXMill.SendtoDB(2,id,hash,AJS.bind(function(answer) {
													  
				var obj = this.obj
		
				if (obj['default']  == '1' ) {
				
					obj.src = GetCheckIMGbyBoolean(0)
					obj['default']='0'
				} else {
					
					obj.src = GetCheckIMGbyBoolean(1)
					obj['default']='1'
					
					
				}
			} , { obj:obj } ) )  
	},
	BindFormToEnterSubmit:function() {
		var fields = document.forms[0].elements
		for (var i=0;i<fields.length;i++) {
			if (fields[i]['bindenter'] == 'true') {
				AJS.AEV(fields[i],'keyup',function() {
					
						if (event.keyCode == 13) {
							ListItems.PreformSearch()
						}
					
					}
				)		
			}
		}
		
	}
	
	
	
	
}
// JavaScript Document