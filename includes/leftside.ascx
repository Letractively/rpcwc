<%@ Control Language="C#" ClassName="leftside" %>

<script type="text/C#" runat="server">
    public void SetExternalLinks(Object source, DataListItemEventArgs eventArgs)
    {
        try
        {
            if (eventArgs.Item.ItemType == ListItemType.Item ||
                eventArgs.Item.ItemType == ListItemType.AlternatingItem)
            {
                if (((SiteMapNode)eventArgs.Item.DataItem).Url.Contains("brochure.pdf"))
                    ((HyperLink)eventArgs.Item.FindControl("Link")).Target = "_blank";
            }
        }
        catch (Exception)
        {
        }
    }
</script>

<asp:SiteMapDataSource ID="SiteMapSourceWelcome" runat="server" StartingNodeUrl="~/welcome.aspx"
    ShowStartingNode="false" />
<asp:SiteMapDataSource ID="SiteMapSourceAboutUs" runat="server" StartingNodeUrl="~/aboutussection.aspx"
    ShowStartingNode="false" />
<h2>
    Welcome</h2>
<asp:DataList ID="DataList1" DataSourceID="SiteMapSourceWelcome" OnItemCreated="SetExternalLinks" runat="server" Width="100%">
    <ItemTemplate>
        <asp:HyperLink NavigateUrl='<%# Eval("Url") %>' ID="Link" runat="server">
            <%# Eval("Title") %></asp:HyperLink>
    </ItemTemplate>
</asp:DataList>
<br />
<h2>
    About Us</h2>
<asp:DataList ID="DataList2" DataSourceID="SiteMapSourceAboutUs" on OnItemCreated="SetExternalLinks" runat="server" Width="100%">
    <ItemTemplate>
        <asp:HyperLink NavigateUrl='<%# Eval("Url") %>' ID="Link" runat="server">
            <%# Eval("Title") %></asp:HyperLink>
    </ItemTemplate>
</asp:DataList>
<br />
<p>
    <strong><a href="../314house.aspx" runat="server">314 Ministry House</a></strong></p>
<p>
    <a href="http://www.adobe.com/products/acrobat/readstep2.html" target="_blank">
        <img src="../images/reader_icon.gif" alt="Click here to download Adobe Reader" width="34"
            height="40" border="0" longdesc="http://www.adobe.com/products/acrobat/readstep2.html" runat="server" /></a>
</p>
