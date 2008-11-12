<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    Title="Reformed Presbyterian Church" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <h4>
        The Reformed Presbyterian Church Grapevine</h4>
    <div style="margin-left: auto; margin-right: auto; text-align: center;">
        <asp:HyperLink ID="NewsletterLink" ImageUrl="images/newsletter_2008_fall.jpg" NavigateUrl="newsletter/2008_Fall.pdf"
            Text="Fall 2008" runat="server" /><br />
        <asp:HyperLink NavigateUrl="newsletter/2008_Fall.pdf" Text="Click to download the Fall 2008 Newsletter"
            runat="server" />
    </div>
</asp:Content>
