<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
 Title="Reformed Presbyterian Church" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
<script type="text/javascript">

/***********************************************
* AnyLink Drop Down Menu- © Dynamic Drive (www.dynamicdrive.com)
* This notice MUST stay intact for legal use
* Visit http://www.dynamicdrive.com/ for full source code
***********************************************/

//Contents for menu 1
var menu1=new Array()
menu1[0]='<a href="ss_desc.aspx">Description</a>'
menu1[1]='<a href="ss_classes.aspx">Classes/Location</a>'
menu1[2]='<a href="ss_adult.aspx">Adult Classes</a>'
menu1[3]='<a href="ss_childrens.aspx">Childrens Classes</a>'

//Contents for menu 2
var menu2=new Array()
menu2[0]='<a href="sg_clusterletter.aspx">Cluster Letter</a>'
menu2[1]='<a href="sg_clusteroverview.aspx">Cluster Overview</a>'
menu2[2]='<a href="sg_studyforms.aspx">Current Study</a>'
menu2[3]='<a href="sg_location.aspx">Cluster Groups</a>'
menu2[4]='<a href="sg_registration.aspx">Registration</a>'

//Contents for menu 3
var menu3=new Array()
menu3[0]='<a href="min_women.aspx">Women</a>'
menu3[1]='<a href="min_men.aspx">Men</a>'
menu3[2]='<a href="min_child.aspx">Children</a>'
menu3[3]='<a href="min_youth.aspx">Youth</a>'
menu3[4]='<a href="min_covenant_keepers.aspx">Covenant Keepers</a>'
menu3[5]='<a href="min_rpc_supperclubs.aspx">RPC Supper Clubs</a>'

//Contents for menu 4
var menu4=new Array()
menu4[0]='<a href="missions.aspx">Missionaries</a>'
menu4[1]='<a href="http://www.pca-mna.org">Mission to North America</a>'
menu4[2]='<a href="http://www.mtw.org/home/site/templates/splash.asp">Mission to the World</a>'

//Contents for menu 5
var menu5=new Array()
menu5[0]='<a href="prayer.aspx">Prayer Requests</a>'
menu5[1]='<a href="http://www.chopministry.net/" target="_blank">CHOP</a>'
menu5[2]='<a href="epguide.aspx">Ephesians Prayer Guide</a>'
menu5[3]='<a href="weeklyprayer.aspsx">Weekly Prayer List</a>'

//Contents for menu 6
var menu6=new Array()
menu6[0]='<a href="menu6_item1.aspx">Item 1</a>'
menu6[1]='<a href="menu6_item2.aspx">Item 2</a>'
menu6[2]='<a href="menu6_item3.aspx">Item 3</a>'
menu6[3]='<a href="menu6_item4.aspx">Item 4</a>'

//Contents for menu 7
var menu7=new Array()
menu7[0]='<a href="menu7_item1.aspx">Item 1</a>'
menu7[1]='<a href="menu7_item2.aspx">Item 2</a>'
menu7[2]='<a href="menu7_item3.aspx">Item 3</a>'
menu7[3]='<a href="menu7_item4.aspx">Item 4</a>'

//Contents for menu 8
var menu_gallery=new Array()
menu_gallery[0]='<a href="gallery_pagent.aspx">Christmas Pagent</a>'
menu_gallery[1]='<a href="gallery_picnic.aspx">Church Picnic</a>'
menu_gallery[2]='<a href="gallery_thanksgiving.aspx">Thanksgiving Dinner</a>'

var menuwidth='200px' //default menu width
var menubgcolor='lightyellow' //menu bgcolor
var disappeardelay=250 //menu disappear speed onmouseout (in miliseconds)
var hidemenu_onclick="yes" //hide menu when user clicks within menu?

/////No further editting needed

var ie4=document.all
var ns6=document.getElementById&&!document.all

if (ie4||ns6)
document.write('<div id="dropmenudiv" style="visibility:hidden;width:'+menuwidth+';background-color:'+menubgcolor+'" onmouseover="clearhidemenu()" onmouseout="dynamichide(event)"></div>')

function getposOffset(what, offsettype){
var totaloffset=(offsettype=="left")? what.offsetLeft : what.offsetTop;
var parentEl=what.offsetParent;
while (parentEl!=null){
totaloffset=(offsettype=="left")? totaloffset+parentEl.offsetLeft : totaloffset+parentEl.offsetTop;
parentEl=parentEl.offsetParent;
}
return totaloffset;
}


function showhide(obj, e, visible, hidden, menuwidth){
if (ie4||ns6)
dropmenuobj.style.left=dropmenuobj.style.top="-500px"
if (menuwidth!=""){
dropmenuobj.widthobj=dropmenuobj.style
dropmenuobj.widthobj.width=menuwidth
}
if (e.type=="click" && obj.visibility==hidden || e.type=="mouseover")
obj.visibility=visible
else if (e.type=="click")
obj.visibility=hidden
}

function iecompattest(){
return (document.compatMode && document.compatMode!="BackCompat")? document.documentElement : document.body
}

function clearbrowseredge(obj, whichedge){
var edgeoffset=0
if (whichedge=="rightedge"){
var windowedge=ie4 && !window.opera? iecompattest().scrollLeft+iecompattest().clientWidth-15 : window.pageXOffset+window.innerWidth-15
dropmenuobj.contentmeasure=dropmenuobj.offsetWidth
if (windowedge-dropmenuobj.x < dropmenuobj.contentmeasure)
edgeoffset=dropmenuobj.contentmeasure-obj.offsetWidth
}
else{
var topedge=ie4 && !window.opera? iecompattest().scrollTop : window.pageYOffset
var windowedge=ie4 && !window.opera? iecompattest().scrollTop+iecompattest().clientHeight-15 : window.pageYOffset+window.innerHeight-18
dropmenuobj.contentmeasure=dropmenuobj.offsetHeight
if (windowedge-dropmenuobj.y < dropmenuobj.contentmeasure){ //move up?
edgeoffset=dropmenuobj.contentmeasure+obj.offsetHeight
if ((dropmenuobj.y-topedge)<dropmenuobj.contentmeasure) //up no good either?
edgeoffset=dropmenuobj.y+obj.offsetHeight-topedge
}
}
return edgeoffset
}

function populatemenu(what){
if (ie4||ns6)
dropmenuobj.innerHTML=what.join("")
}


function dropdownmenu(obj, e, menucontents, menuwidth){
if (window.event) event.cancelBubble=true
else if (e.stopPropagation) e.stopPropagation()
clearhidemenu()
dropmenuobj=document.getElementById? document.getElementById("dropmenudiv") : dropmenudiv
populatemenu(menucontents)

if (ie4||ns6){
showhide(dropmenuobj.style, e, "visible", "hidden", menuwidth)

dropmenuobj.x=getposOffset(obj, "left")
dropmenuobj.y=getposOffset(obj, "top")
dropmenuobj.style.left=dropmenuobj.x-clearbrowseredge(obj, "rightedge")+"px"
dropmenuobj.style.top=dropmenuobj.y-clearbrowseredge(obj, "bottomedge")+obj.offsetHeight+"px"
}

return clickreturnvalue()
}

function clickreturnvalue(){
if (ie4||ns6) return false
else return true
}

function contains_ns6(a, b) {
while (b.parentNode)
if ((b = b.parentNode) == a)
return true;
return false;
}

function dynamichide(e){
if (ie4&&!dropmenuobj.contains(e.toElement))
delayhidemenu()
else if (ns6&&e.currentTarget!= e.relatedTarget&& !contains_ns6(e.currentTarget, e.relatedTarget))
delayhidemenu()
}

function hidemenu(e){
if (typeof dropmenuobj!="undefined"){
if (ie4||ns6)
dropmenuobj.style.visibility="hidden"
}
}

function delayhidemenu(){
if (ie4||ns6)
delayhide=setTimeout("hidemenu()",disappeardelay)
}

function clearhidemenu(){
if (typeof delayhide!="undefined")
clearTimeout(delayhide)
}

if (hidemenu_onclick=="yes")
document.onclick=hidemenu

</script>
</asp:Content>
