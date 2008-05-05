<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    Title="Reformed Presbyterian Church &mdash; Church Bulletin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <h4>
        Church Bulletins</h4>
    <p>
        Click on a date to view a PDF file that contains the church bulletin for that Sunday.</p>
    <asp:SqlDataSource ID="BulletinDataSource" ConnectionString="<%$ ConnectionStrings:RPC %>"
        runat="server" SelectCommand="SELECT pubDate FROM item WHERE (channel_id = @channelId) ORDER BY pubDate Desc"
        SelectCommandType="Text">
        <SelectParameters>
            <asp:Parameter Name="channelId" DefaultValue="7" />
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:DataList DataSourceID="BulletinDataSource" runat="server">
        <ItemTemplate>
            <p>
                <a href="bulletins/<%# Convert.ToDateTime(Eval("pubDate")).ToString("yyyy-MM-dd") %>.pdf">
                    <%# Convert.ToDateTime(Eval("pubDate")).ToString("MMMM d, yyyy") %></a></p>
        </ItemTemplate>
    </asp:DataList>
</asp:Content>
