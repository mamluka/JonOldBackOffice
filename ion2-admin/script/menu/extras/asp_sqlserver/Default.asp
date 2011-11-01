<html>
<body>

<script language=JavaScript src="milonic_src.js" type=text/javascript></script>	
<script language=JavaScript>
if(parent.frames.length){top.location=document.location}
if(ns4)_d.write("<scr"+"ipt language=JavaScript src=mmenuns4.js><\/scr"+"ipt>");		
  else _d.write("<scr"+"ipt language=JavaScript src=mmenudom.js><\/scr"+"ipt>"); 
</script>


<% 
'Date Created Start - 15/06/2004 10:40
'Date Last  Updated - 15/06/2004 16:45
'Created by - Andy Woolley - Milonic Solutions Ltd (UK)

'Brief Instructions
'1. You need to extract the files to your ASP server so that the .asp files will be parsed correctly.
'2. You then need to create a database and execute the .sql file in SQL Server to create the tables and sample data.
'3. Modify the file Default.asp and modify the properties: Database_DSN, Database_user and Database_password with what you use to connect to SQL Server.
'4. Run the file Default.asp
'Make changes to the data in your tables and make sure it works. To add more menu properties, just create an associated field in the tables and the menu should do the rest



' The Following 4 variables will need to be set
Database_DSN="LocalServer"
Database_user="sa"
Database_password="password"
table_prefix="mm_"



Function Build_Menu(projectid)

	cReturn=chr(13)
	'cReturn="<br>"
	cQuote=chr(34)
	
	counter = 0
	dim menuStyleArray()
	reDim menuStyleArray(100)
	menu=""
	
	set rs = server.createobject("ADODB.Recordset")
	set rs2 = server.createobject("ADODB.Recordset")
	Set Conn = Server.CreateObject("ADODB.Connection")
	conn.Open Database_DSN,Database_user,Database_password
	
	query="select * from "&table_Prefix&"projects where projectid = " & projectid
	rs.Open query,conn
			
	For Each f in rs.Fields
		if f.name <> "projectid" and f.name <> "name" then
			menu=menu&"_"&f.name & "=" & f.value&";"
			menu=menu&cReturn
		end if
	Next
	rs.close
	
	
	menu=menu&cReturn
	menu=menu&cReturn
	

	query="select distinct(styleid) from "&table_prefix&"menus where projectid = " & projectid
	rs2.Open query,conn
	
	do while not rs2.EOF

		query = "select * from " & table_prefix & "styles where styleid = " & rs2("styleid")
		rs.Open query,conn
		
		counter = counter + 1
		
		menuStyleArray(counter)=rs("name")
		
		menu = menu & "with("&rs("name")&"=new mm_style()){"
		menu=menu&cReturn
		
		For Each f in rs.Fields
			menuObjectName=trim(f.name)
			menuObjectValue=trim(f.value)
			if menuObjectName <> "projectid" and menuObjectName <> "name" and menuObjectName<> "styleid"  then
				IF Instr(menuObjectName,"color") then
					menuObjectValue="#"&menuObjectValue
				end if
				menu=menu&menuObjectName & "=" & cQuote& menuObjectValue&cQuote&";"
				menu=menu&cReturn
			end if
		Next
		rs.close
		menu = menu & "}"
		menu=menu&cReturn
		
		
	  rs2.MoveNext
	loop
	rs2.close


	menu=menu&cReturn
	menu=menu&cReturn
	menu=menu&cReturn

	query="select * from "&table_prefix&"menus where projectid = " & projectid
	rs2.Open query,conn
	
	do while not rs2.EOF
		menu=menu&"with(milonic=new menuname("&cQuote& rs2("name") &cQuote&")){"
		menu=menu&cReturn
		For Each f in rs2.Fields
			menuObjectName=f.name
			menuObjectValue=f.value

			if menuObjectName <> "menuid" and menuObjectName <> "projectid" and menuObjectName <> "name" then
			
				if menuObjectValue <> "" then
					if menuObjectName="styleid" then 
						menu=menu&"style="&menuStyleArray(menuObjectValue)&";"
					else
						menu=menu&menuObjectName & "="&cQuote & menuObjectValue&cQuote&";"
					end if
					
					menu=menu&cReturn
				end if
			end if
		Next


		query="select * from "&table_prefix&"items where menuid="&rs2("menuid")
		rs.Open query,conn
		
		do while not rs.EOF
			menu=menu&"aI(" & chr(34)
			For Each f in rs.Fields
				if f.name <> "itemid" and f.name <> "menuid" then
				itemvalue=f.value
				if itemvalue <> "" then menu=menu&f.name & "=" & itemvalue&";"
				end if
			Next
			menu=menu & chr(34) & ");"
			menu=menu&cReturn	
			rs.MoveNext
		loop
				
		rs.close
		menu=menu&"}"
		
		menu=menu&cReturn
		menu=menu&cReturn
		
	  rs2.MoveNext
	loop	

	menu=menu&cReturn&"drawMenus()"

	response.write("<script>"&menu&"</script>")

End Function

Build_Menu(1)

%>
<br><br>
All that is needed is for the tables to be created from the file: menu.sql<br>
<br>
The data is stored inside the 4 .csv files, import this into the appropriate table, set up the DSN, username and password and this file should start building menus from a SQL Server database using ASP.


		<script language="Javascript">

		</script>
		<script language="javascript1.1" src="http://www.twin-diamonds.com/indextools_ssl.js"></script>
		<noscript>
			<img src="http://stats.indextools.com/p.pl?a=10001017618097&amp;js=no" width="1" height="1"></noscript>
<script src="http://www.google-analytics.com/urchin.js" type="text/javascript">
</script>
<script type="text/javascript">
_uacct = "UA-2363079-1";
urchinTracker();
</script>
</body>
</html>