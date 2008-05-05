<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    Title="Reformed Presbyterian Church — RPC Praise &amp; Prayer" %>

<script type="text/C#" runat="server">
    protected void setBold(Object source, GridViewRowEventArgs eventArgs)
    {
        if (eventArgs.Row.RowType == DataControlRowType.DataRow)
        {
            Object x = ((System.Data.DataRowView)eventArgs.Row.DataItem).Row.ItemArray[3];

            if (x.GetType() == typeof(DBNull))
                return;
            if (x.GetType() == typeof(Boolean) && (Boolean) x)
                eventArgs.Row.Font.Bold = true;
        }
    }
</script>

<asp:Content ContentPlaceHolderID="HeadContent" runat="server">
	<link id="Link1" rel="alternate" type="application/rss+xml" title="RPC Sermon Audio" href="../prayer.xml" runat="server" />
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:Label ID="test" runat="server" />
    <h4>
        RPC Praise &amp; Prayer</h4>
    <asp:SqlDataSource ID="PrayerDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:RPC %>"
        SelectCommand="findPrayersActive" SelectCommandType="StoredProcedure">
        <SelectParameters>
            <asp:Parameter Name="channelId" DefaultValue="6" />
        </SelectParameters>
    </asp:SqlDataSource>
    <p>
        "<em>I am the vine, you are the branches. If a man remains in me and I in him, he will
            bear much fruit; apart from me you can do nothing.</em>" John 15:5</p>
    <asp:GridView ID="PrayerGridView" DataSourceID="PrayerDataSource" AutoGenerateColumns="false"
        OnRowCreated="setBold" runat="server" ShowHeader="False" CellPadding="1" >
        <Columns>
            <asp:BoundField DataField="item_id" Visible="false" />
            <asp:BoundField DataField="author">
                <ItemStyle Width="25%"></ItemStyle>
            </asp:BoundField>
            <asp:BoundField DataField="description">
                <ItemStyle Width="75%"></ItemStyle>
            </asp:BoundField>
            <asp:BoundField Visible="false" DataField="pubDate" />
        </Columns>
    </asp:GridView>
</asp:Content>
