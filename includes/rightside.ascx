<%@ Control Language="C#" ClassName="rightside" %>

<script type="text/C#" runat="server">
    public void SetExternalLinks(Object source, DataListItemEventArgs eventArgs)
    {
        if (eventArgs.Item.ItemType == ListItemType.Item ||
            eventArgs.Item.ItemType == ListItemType.AlternatingItem)
        {
            if (((SiteMapNode)eventArgs.Item.DataItem).Url.Equals("http://www.gnpcb.org/esv/devotions"))
                ((HyperLink)eventArgs.Item.FindControl("Link")).Target = "_blank";
        }
    }
</script>

<h2>
    Church Resources</h2>
    <asp:DataList ID="ResourceMenuControl" DataSourceID="SiteMapSource" OnItemCreated="SetExternalLinks" runat="server" Width="100%">
        <ItemTemplate>
            <asp:HyperLink id="Link" NavigateUrl='<%# Eval("Url") %>' runat="server"><%# Eval("Title") %></asp:HyperLink>
        </ItemTemplate>
    </asp:DataList>
<asp:SiteMapDataSource ID="SiteMapSource" runat="server" StartingNodeUrl="~/resources.aspx" ShowStartingNode="false" />
<br />
<h2>
    Recommended Reading</h2>
<br />
<a href="http://www.wtsbooks.com/product-exec/product_id/5190/nm/Prayer_of_Jehoshaphat_Seeing_Beyond_Life_s_Storms_Paperback_">
    <img src="~/images/jehoshaphat.jpg" alt="" width="80" height="120" runat="server" /></a>
<br />
