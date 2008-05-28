<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" Title="Untitled Page" %>

<script runat="server">
    public void Add(Object source, CommandEventArgs commandEventArgs)
    {
    }
</script>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:SqlDataSource ID="BulletinDataSource" ConnectionString="<%$ ConnectionStrings:RPC %>"
        runat="server" SelectCommand="findBulletinsActive"
        SelectCommandType="StoredProcedure"
        InsertCommand="
INSERT INTO ITEM
(CHANNEL_ID, TITLE, AUTHOR, PUBDATE, ACTIVE) VALUES (@channelId, '', 'raymond.rishty', @pubDate, @active)">
        <SelectParameters>
            <asp:Parameter Name="channelId" DefaultValue="7" />
        </SelectParameters>
        <InsertParameters>
            <asp:Parameter Name="channelId" DefaultValue="7" />
            <asp:Parameter Name="pubDate" Type="DateTime" />
            <asp:Parameter Name="active" DefaultValue="True" Type="Boolean" />
        </InsertParameters>
    </asp:SqlDataSource>
    <asp:DetailsView ID="BulletinDataGrid" DataSourceID="BulletinDataSource" 
        AllowPaging="True" AutoGenerateInsertButton="True" 
        runat="server" AutoGenerateRows="False">
        <Fields>
            <asp:BoundField DataField="pubDate" HeaderText="Date" />
        </Fields>
    </asp:DetailsView>
</asp:Content>

