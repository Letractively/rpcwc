<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    Title="Reformed Presbyterian Church &mdash; Blog Commends" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <br />

    <asp:SqlDataSource ID="BlogSqlDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:RPC %>"
        SelectCommand="getSermonBlogPKWhere" SelectCommandType="StoredProcedure">
        <SelectParameters>
            <asp:QueryStringParameter QueryStringField="id" Name="item_id" />
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="BlogCommentsSqlDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:RPC %>"
        SelectCommand="getSermonBlogCommentsPKWhere" SelectCommandType="StoredProcedure">
        <SelectParameters>
            <asp:QueryStringParameter QueryStringField="id" Name="item_id" />
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:GridView ID="BlogGridView" runat="server" DataSourceID="BlogSqlDataSource" AutoGenerateColumns="False"
        ShowHeader="False" CellPadding="4" GridLines="None">
        <Columns>
            <asp:TemplateField>
                <ItemTemplate>
                    <h4>
                        <%# Eval("sermonTextReference") %><%# Eval("Title")%></h4>
                    <p>
                        <%# Eval("description")%></p>
                    <div class="blogtagline">
                        written by
                        <%# Eval("Author")%>
                        on
                        <%# Convert.ToDateTime(Eval("pubDate")).ToShortDateString()%>
                    </div>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    <br />
    <div id="comments">
        <h2>
            Comments</h2>
        <asp:GridView ID="GridView1" runat="server" DataSourceID="BlogCommentsSqlDataSource"
            AutoGenerateColumns="False" ShowHeader="False" CellPadding="4" GridLines="None">
            <Columns>
                <asp:TemplateField>
                    <ItemTemplate>
                        <div class="comment-wrapper">
                            <a name='comment_<%# Eval("item_id") %>'></a>
                            <div class="comment-content">
                                <p>
                                    <%# Eval("comment")%></p>
                            </div>
                            <div class="comment-footer">
                                posted by
                                <%# Eval("Author")%>
                                [<a href='#comment_<%# Eval("item_id") %>'>link</a>]</div>
                        </div>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
    <asp:Label ID="man" runat="server" />
</asp:Content>
