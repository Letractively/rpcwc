<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    Title="Reformed Presbyterian Church" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <h4>
        The Reformed Presbyterian Church Grapevine</h4>
    <div style="margin-left: auto; margin-right: auto; text-align: center;">
        <asp:HyperLink ID="HyperLink3" ImageUrl="images/newsletter_2011_fall.png" NavigateUrl="newsletter/2011_Fall.pdf"
            Text="Fall 2011" runat="server" Width="250" Height="323" /><br />
        <asp:HyperLink ID="HyperLink4" NavigateUrl="newsletter/2011_Fall.pdf" Text="Click to download the Fall 2011 Newsletter"
            runat="server" />
    </div>
    <div style="margin-left: auto; margin-right: auto; text-align: center;">
        <asp:HyperLink ID="HyperLink1" ImageUrl="images/newsletter_2009_spring.jpg" NavigateUrl="newsletter/2009_Spring.pdf"
            Text="Spring 2009" runat="server" Width="250" Height="323" /><br />
        <asp:HyperLink ID="HyperLink2" NavigateUrl="newsletter/2009_Spring.pdf" Text="Click to download the Winter/Spring 2009 Newsletter"
            runat="server" />
    </div>
    <div style="margin-left: auto; margin-right: auto; text-align: center;">
        <asp:HyperLink ID="NewsletterLink" ImageUrl="images/newsletter_2008_fall.jpg" NavigateUrl="newsletter/2008_Fall.pdf"
            Text="Fall 2008" runat="server" Width="250" Height="323" /><br />
        <asp:HyperLink NavigateUrl="newsletter/2008_Fall.pdf" Text="Click to download the Fall 2008 Newsletter"
            runat="server" />
    </div>
</asp:Content>
