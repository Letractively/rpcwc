<%@ Control Language="C#" ClassName="rightside" CodeFile="rightside.ascx.cs" Inherits="RightSide" %>

<script type="text/C#" runat="server">
    public void SetExternalLinks(Object source, DataListItemEventArgs eventArgs)
    {
        try
        {
            if (eventArgs.Item.ItemType == ListItemType.Item ||
                eventArgs.Item.ItemType == ListItemType.AlternatingItem)
            {
                if (((SiteMapNode)eventArgs.Item.DataItem).Url.Equals("http://www.gnpcb.org/esv/devotions"))
                    ((HyperLink)eventArgs.Item.FindControl("Link")).Target = "_blank";
            }
        }
        catch (Exception)
        {
        }
    }

    public delegate void MarkAsRead(Int16 num);
    
    public void ItemDataBound(Object source, RepeaterItemEventArgs eventArgs)
    {
        Object itemId = DataBinder.Eval(eventArgs.Item.DataItem, "item_id");
        MarkAsRead markAsRead;
        markAsRead = new MarkAsRead(recommendedReadingsDAO.MarkAsRead);
        markAsRead.BeginInvoke((Int16) itemId, null, null);
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
<asp:SqlDataSource ID="RecommendedReadingDataSource" ConnectionString="<%$ ConnectionStrings:RPC %>"
 SelectCommand="findRecommendedReading" SelectCommandType="StoredProcedure" runat="server">
    <SelectParameters>
        <asp:Parameter Name="channelId" DefaultValue="9" />
    </SelectParameters>
</asp:SqlDataSource>
<br />
<h2>
    Recommended Reading</h2>
<br />
<asp:Repeater ID="Repeater1" OnItemDataBound="ItemDataBound" DataSourceID="RecommendedReadingDataSource" runat="server">
<ItemTemplate>
<a href="<%# DataBinder.Eval(Container.DataItem, "link")%>"><img src="<%# DataBinder.Eval(Container.DataItem, "url")%>" alt="<%# DataBinder.Eval(Container.DataItem, "title")%>" /></a>
</ItemTemplate>
</asp:Repeater>
<br />
