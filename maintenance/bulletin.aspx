<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" Title="Untitled Page" 
CodeFile="bulletin.aspx.cs" Inherits="maintenance_bulletin"%>

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
(CHANNEL_ID, TITLE, AUTHOR, PUBDATE, ACTIVE) VALUES (@channelId, '', 'raymond.rishty', @pubDate, @active)"
        OnInserting="OnInserting">
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
            <asp:TemplateField HeaderText="PDF File">
            <ItemTemplate>
                <a href="../bulletins/<%# Convert.ToDateTime(Eval("pubDate")).ToString("yyyy-MM-dd") %>.pdf"><%# Convert.ToDateTime(Eval("pubDate")).ToString("yyyy-MM-dd") %>.pdf</a>
            </ItemTemplate>
            <InsertItemTemplate>
                <asp:FileUpload ID="bulletinPdf" runat="server" />
            </InsertItemTemplate>
            </asp:TemplateField>
        </Fields>
    </asp:DetailsView>
    <div ID="status" runat="server" />
</asp:Content>

