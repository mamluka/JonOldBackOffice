_menuCloseDelay=0;           // The time delay for menus to remain visible on mouse out
_menuOpenDelay=0;            // The time delay before menus open on mouse over
_subOffsetTop=0;             // Sub menu top offset
_subOffsetLeft=-130;            // Sub menu left offset

/// Style Definitions ///

with(mainStyleHoriz=new mm_style()){
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
subimage="submenu_arrow_down-off.gif";
onsubimage="submenu_arrow_down-on.gif";
high3dcolor="#FFFFFF";
low3dcolor="#367E45";
swap3d=1;
}

// Main Menu

with(milonic=new menuname("mainMenuHoriz")){
style=mainStyleHoriz;
top=0;
left=129;
orientation="horizontal";
alwaysvisible=1;
aI("text=Home;url=body.htm;target=body;");
aI("text=Top 1;showmenu=sub1;target=body;onfunction=openSubmenu();offfunction=closeSubmenu();");
aI("text=Top 2;showmenu=sub2;target=body;onfunction=openSubmenu();offfunction=closeSubmenu();");
aI("text=Top 3;showmenu=sub3;target=body;onfunction=openSubmenu();offfunction=closeSubmenu();");
aI("text=Google in Body;url=http://www.google.com/;target=body;")
aI("text=Google in New;url=http://www.google.com/;target=_new;")
}

drawMenus();

