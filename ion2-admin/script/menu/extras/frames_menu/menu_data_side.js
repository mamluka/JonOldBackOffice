_menuCloseDelay=0;           // The time delay for menus to remain visible on mouse out
_menuOpenDelay=0;            // The time delay before menus open on mouse over
_subOffsetTop=0;             // Sub menu top offset
_subOffsetLeft=0;            // Sub menu left offset

/// Style Definitions ///

with(mainStyleVert=new mm_style()){
onbgcolor="#9EE3A9";
oncolor="#1D3B23";
offbgcolor="#61A76D";
offcolor="#F7F9F7";
bordercolor="#367E45";
borderstyle="solid";
borderwidth=1;
separatorcolor="#325235";
separatorsize=2;
padding=4;
fontsize=12;
fontstyle="normal";
fontfamily="Verdana, Tahoma, Arial";
subimage="submenu_arrow_right-off.gif";
onsubimage="submenu_arrow_right-on.gif";
high3dcolor="#FFFFFF";
low3dcolor="#367E45";
swap3d=1;
}

// Main

with(milonic=new menuname("mainMenuVert")){
style=mainStyleVert;
top=50;
left=0;
itemwidth=127;
alwaysvisible=1;
aI("text=Home;url=body.htm;target=body;");
aI("text=Side 1;showmenu=sub1;target=body;onfunction=openSubmenu();offfunction=closeSubmenu();");
aI("text=Side 2;showmenu=sub2;target=body;onfunction=openSubmenu();offfunction=closeSubmenu();");
aI("text=Side 3;showmenu=sub3;target=body;onfunction=openSubmenu();offfunction=closeSubmenu();");
aI("text=Side 4 + Link;showmenu=sub4;url=page4.htm;target=body;onfunction=openSubmenu();offfunction=closeSubmenu();");
aI("text=page5.htm in<br>a new window;url=page5.htm;target=_new;");
}

drawMenus();

