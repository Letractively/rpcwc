<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    Title="Reformed Presbyterian Church &mdash; Sermon Audio" CodeFile="sermon.aspx.cs"
    Inherits="rpcwc.web.SermonPage" %>

<asp:Content ContentPlaceHolderID="HeadContent" runat="server">
    <link rel="alternate" type="application/rss+xml" title="RPC Sermon Audio" href="podcast.xml"
        runat="server" />
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <h4 style="text-align: center">
        Sermon Archive
    </h4>
    <p style="text-align: center;">
        <img src="~/images/stangale.gif" width="300" height="150" alt="Pastor Stanley D. Gale"
            runat="server" /></p>
    <asp:Panel ID="BlogHolder" runat="server" />
    <%--
    <asp:SqlDataSource ID="SermonSqlDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:RPC %>"
        SelectCommand="getSermonAudioList" SelectCommandType="StoredProcedure" InsertCommand="insertSermonAudio"
        InsertCommandType="StoredProcedure" DeleteCommand="deleteSermonAudio" DeleteCommandType="StoredProcedure">
        <InsertParameters>
            <asp:ControlParameter ControlID="DatePicker" Name="date" />
            <asp:Parameter Name="author" DefaultValue="Dr. Stanley D. Gale" />
            <asp:ControlParameter ControlID="SermonTitle" Name="title" />
            <asp:ControlParameter ControlID="ScriptureReference" Name="reference" />
        </InsertParameters>
        <DeleteParameters>
            <asp:Parameter Name="id" />
        </DeleteParameters>
    </asp:SqlDataSource>
    <asp:GridView ID="SermonGridView" DataSourceID="SermonSqlDataSource" runat="server"
        AllowPaging="True" Width="100%" AutoGenerateColumns="False" DataKeyNames="id">
        <Columns>
            <asp:BoundField DataField="id" HeaderText="id" InsertVisible="False" ReadOnly="True"
                SortExpression="id" Visible="False" />
            <asp:TemplateField>
                <ItemTemplate>
                    <a href='sermonblog.aspx?item_id=<%#Eval("id") %>'><%# Eval("title") %></a>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="author" HeaderText="Preacher" SortExpression="author" />
            <asp:BoundField DataField="pubDate" HeaderText="Date Preached" SortExpression="pubDate"
                DataFormatString="{0:MM/dd/yyyy}" />
            <asp:BoundField DataField="sermonTextReference" HeaderText="Scripture" SortExpression="sermonTextReference" />
        </Columns>
    </asp:GridView>--%>
</asp:Content>
