_menuCloseDelay=400           // The time delay for menus to remain visible on mouse out
_menuOpenDelay=0            // The time delay before menus open on mouse over
_subOffsetTop=0              // Sub menu top offset
_subOffsetLeft=0            // Sub menu left offset

/// Style Definitions ///

with(subStyle=new mm_style()){
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
subimagepadding="0 0 0 10";
high3dcolor="#FFFFFF"; //"#edf3ee";
low3dcolor="#367E45";
swap3d=1;
headerbgcolor="#548959";
headercolor="#f2f2ff";
//overfilter="Pixelate(squares=20, duration=0.3)";
//outfilter="Pixelate(squares=20, duration=0.3)";
}

/// Submenu Definitions ///

with(milonic=new menuname("sub1")){
style=subStyle;
aI("text=Sub1.1;showmenu=sub1.1;");
aI("text=Sub1.2;showmenu=sub1.2;");
aI("text=Sub1.3;showmenu=sub1.3;");
aI("text=Sub1.4;showmenu=sub1.4;");
}

with(milonic=new menuname("sub2")){
style=subStyle;
aI("text=Sub2.1;showmenu=sub1.1;");
aI("text=Sub2.2;showmenu=sub1.2;");
aI("text=Sub2.3;showmenu=sub1.3;");
aI("text=Sub2.4;showmenu=sub1.4;");
}

with(milonic=new menuname("sub3")){
style=subStyle;
aI("text=Sub3.1;showmenu=sub1.1;");
aI("text=Sub3.2;showmenu=sub1.2;");
aI("text=Sub3.3;showmenu=sub1.3;");
aI("text=Sub3.4;showmenu=sub1.4;");
}

with(milonic=new menuname("sub4")){
style=subStyle;
aI("text=Sub4.1;showmenu=sub1.1;");
aI("text=Sub4.2;showmenu=sub1.2;");
aI("text=Sub4.3;showmenu=sub1.3;");
aI("text=Sub4.4;showmenu=sub1.4;");
}

with(milonic=new menuname("sub1.1")){
style=subStyle;
aI("text=Open page1;url=page1.htm;");
aI("text=Open page2;url=page2.htm;");
}

with(milonic=new menuname("sub1.2")){
style=subStyle;
aI("text=Open page1;url=page1.htm;");
aI("text=Open page2;url=page2.htm;");
aI("text=Open page3;url=page3.htm;");
}

with(milonic=new menuname("sub1.3")){
style=subStyle;
aI("text=Open page1;url=page1.htm;");
aI("text=Open page2;url=page2.htm;");
aI("text=Open page3;url=page3.htm;");
aI("text=Open page4;url=page4.htm;");
}

with(milonic=new menuname("sub1.4")){
style=subStyle;
aI("text=Open page1;url=page1.htm;");
aI("text=Open page2;url=page2.htm;");
aI("text=Open page3;url=page3.htm;");
aI("text=Open page4;url=page4.htm;");
aI("text=Open page5;url=page5.htm;target=_new;");
}

drawMenus();

