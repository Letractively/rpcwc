<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
 Title="Reformed Presbyterian Church &mdash; Useful Links" %>
 
<asp:Content ContentPlaceHolderID="HeadContent" runat="server">
<script type="text/javascript">
function externalLinks() {
    if (!document.getElementsByTagName) return;
    var anchors = document.getElementsByTagName("a");
    for (var i=0; i<anchors.length; i++)
    {
        var anchor = anchors[i];
        if (anchor.getAttribute("href") &&
            anchor.getAttribute("rel") == "External")
        anchor.target = "_blank";
    }
}

window.onload = externalLinks;
</script>
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
<h4>Useful Links</h4>
<div><a href="http://www.byfaithonline.com/" rel="External">By Faith On-Line</a></div>
<div><a href="http://www.rpcb.org/childcat.html" rel="External">Children's Catechism</a></div>
<div><a href="http://www.ccef.org" rel="External">Christian Counseling Education Foundation</a></div>
<div><a href="http://www.chopministry.net/" rel="External">Community Houses of Prayer</a></div>
<div><a href="http://www.cyberhymnal.org/" rel="External">Cyber Hymnal</a></div>
<div><a href="http://www.gnpcb.org/esv/" rel="External">ESV Bible</a></div>
<div><a href="http://www.myparuchia.com/" rel="External">Fellowship of Ailbe</a> (spiritual renewal)</div>
<div><a href="http://www.ligonier.org/" rel="External">Ligonier Ministry</a> (ministry of R. C. Sproul)</div>
<div><a href="http://www.pcanet.org/" rel="External">Presbyterian Church in America</a> (denomination)</div>
<div><a href="http://www.west-chester.com/" rel="External">West Chester</a> (local community information)</div>
<div><a href="http://www.reformed.org/documents/wcf_with_proofs/" rel="External">Westminster Confession of Faith</a></div>
<div><a href="http://opc.org/lc.html" rel="External">Westminster Larger Catechism</a></div>
<div><a href="http://www.reformed.org/documents/wsc/" rel="External">Westminster Shorter Catechism</a></div>
<div><a href="http://www.wts.edu/" rel="External">Westminster Theological Seminary</a></div>
<div><a href="http://www.wtsbooks.com/" rel="External">WTS Books</a> (bookstore)</div>
<div><a href="http://www.wts.edu/resources/media.html?paramType=audio" rel="External">Westminster Theological Seminary Media</a></div>
<div><a href="http://www.worldmag.com/" rel="External">World Magazine</a></div>
<div><a href="http://www.harvestusa.org/" rel="External">Harvest USA</a> (help in sexual purity)</div>
<div><a href="http://www.pca-mna.org/fiftydaysofprayer.php" rel="External">PCA &rsquo;50 days of Prayer&rsquo;</a></div>
<div><a href="http://www.pluggedinonline.com/" rel="External">Plugged In</a> (Movie Reviews)</div>
<div><a href="http://www.igracemusic.com/hymnbook/home.html" rel="External">RUF Hymnbook</a></div>
<div><a href="http://www.ccli.com/" rel="External">CCLI USA</a></div>
</asp:Content>
