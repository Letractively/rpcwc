<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    Title="Reformed Presbyterian Church &mdash; Sermon Audio" CodeFile="sermon.aspx.cs"
    Inherits="rpcwc.web.SermonPage" %>

<asp:Content ContentPlaceHolderID="HeadContent" runat="server">
    <link rel="alternate" type="application/rss+xml" title="RPC Sermon Audio" href="podcast.xml"
        runat="server" />
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <h4 style="text-align: center">
        Sermon Archive
    </h4>
    <p style="text-align: center;">
        <img src="~/images/SDG pic1-1.jpg" width="150" height="144" alt="Pastor Stanley D. Gale"
            runat="server" /></p>
    
    <!-- Let's populate this programmatically (see code-behind) -->
    <asp:Panel ID="BlogHolder" runat="server" />
</asp:Content>
