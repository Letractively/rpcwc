<%@ Control Language="C#" ClassName="mainmenu"  %>

<script type="text/C#" runat="server">
    public void SetExternalLinks(Object source, EventArgs eventArgs)
    {
        mainMenuControl.FindItem("Missions/Mission to North America").Target = "_blank";
        mainMenuControl.FindItem("Missions/Mission to the World").Target = "_blank";
        mainMenuControl.FindItem("Prayer/Community Houses of Prayer").Target = "_blank";
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
