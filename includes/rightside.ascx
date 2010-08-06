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
<asp:Panel id="RecommendedReading" OnPreRender="GetRecommendedReading" runat="server">
</asp:Panel>
<br />
<a href="http://www.facebook.com/pages/West-Chester-PA/The-Reformed-Presbyterian-Church-of-West-Chester/80304337298" target="_blank" rel="External">
    <img src="~/images/facebook.png" width="72" height="22" alt="Facebook" runat="server" />
</a>
<br />
