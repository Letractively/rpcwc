<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    Title="Reformed Presbyterian Church &mdash; 314 Ministry House" %>
    
<asp:Content ID="Content2" ContentPlaceHolderID="HeadContent" runat="server">
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
    <h4>
        314 Ministry House</h4>
    <p>
        God is growing us, in terms of both church family and church facility. Take a look
        at the following documents to see what God is doing and how you might be involved.</p>
    <div><a href="~/314.aspx" runat="server">Pastoral Letter</a></div>
    <div><a href="~/i_see.aspx" runat="server">I See</a></div>
    <div><a href="~/gallery_314.aspx" runat="server">Photo Gallery</a></div>
    <br />
    
    <h3>
        Capital Campaign</h3>
    <div><a href="~/RIPE.pdf" rel="External" runat="server">RIPE Brochure</a></div>
    <div><a href="~/Taste.pdf" rel="External" runat="server">TASTE Devotional</a></div>
    <div><a href="~/grapemeter.html" runat="server" target="_blank">Grape Meter</a></div>
</asp:Content>
