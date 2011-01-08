<%@ Control Language="C#" ClassName="mainmenu"  %>

<script type="text/C#" runat="server">
    public void SetExternalLinks(Object source, EventArgs eventArgs)
    {
        MenuItem mnaItem = mainMenuControl.FindItem("Missions/Mission to North America");
        if (mnaItem != null)
        {
            mnaItem.Target = "_blank";
            mnaItem = null;
        }
        MenuItem mtwItem = mainMenuControl.FindItem("Missions/Mission to the World");
        if (mtwItem != null)
        {
            mtwItem.Target = "_blank";
            mtwItem = null;
        }
        MenuItem chopItem = mainMenuControl.FindItem("Prayer/Community Houses of Prayer");
        if (chopItem != null)
        {
            chopItem.Target = "_blank";
            chopItem = null;
        }
    }
</script>

    <asp:Menu
            ID="mainMenuControl"
            runat="server"
            DataSourceID="MainMenuSiteMapDataSource"
            Orientation="Horizontal"
            StaticEnableDefaultPopOutImage="False"
            Width="100%"
            CssClass="mainMenuTable" OnPreRender="SetExternalLinks">
        <DynamicMenuStyle
            BorderColor="Black"
            BorderWidth="1px" />
        <DynamicMenuItemStyle
            CssClass="mainMenuDynamicItem" />
    </asp:Menu>
<div id="Div1">
</div>
<asp:SiteMapDataSource ID="MainMenuSiteMapDataSource" runat="server" ShowStartingNode="False"
    StartingNodeUrl="~/mainmenu.aspx" />
