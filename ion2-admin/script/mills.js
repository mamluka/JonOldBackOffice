// JavaScript Document
var AJAXMill = {
				SendtoDB:function(req,id,hash,callback) {
					var hashstr = GetStrFromHash(hash,'|','::')
					var _ajax = AJS.getRequest('/ajax/ajax_db.aspx?req='+req+'&id='+id+'&hashstr='+hashstr)
					//alert('/ajax/ajax_db.aspx?req='+req+'&id='+id+'&hashstr='+hashstr)
					_ajax.addCallback(callback)
					_ajax.sendReq()
				}
}