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
    <asp:GridView ID="PrayerGridView" DataSourceID="PrayerDataSource" AutoGenerateColumns="False"
        
        OnRowCreated="setBold" BorderStyle="None" Width="100%" runat="server" GridLines="None">
        <Columns>
            <asp:TemplateField>
                <ItemTemplate>
                    <div style="text-align: right; border-bottom: solid 1px #ccc">
                        <h3 style="float: right">
                            <%# Eval("author")%></h3>&nbsp;</div>
                    <br clear="all" />
                    <p style="text-align:justify">
                        <%# Eval("description")%></p>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>
