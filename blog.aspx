<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    Title="Reformed Presbyterian Church &mdash; Sermon Blog" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <br />

    <script runat="server">
        protected void BlogRowCreated(Object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                BlogCommentsSqlDataSource.SelectParameters["item_id"].DefaultValue = BlogGridView.DataKeys[0].Value.ToString();
                blogid.Value = BlogGridView.DataKeys[0].Value.ToString();
                //man.Value = BlogGridView.DataKeys[0].Value.ToString();
                //BlogCommentsSqlDataSource.SelectParameters.UpdateValues(Context, (Control)sender);
            }
        }

        protected void SubmitComments(Object sender, EventArgs e)
        {
            BlogCommentsSqlDataSource.InsertParameters.UpdateValues(Context, (Control)sender);
            BlogCommentsSqlDataSource.Insert();
        }
    </script>

    <asp:SqlDataSource ID="BlogSqlDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:RPC %>"
        SelectCommand="getSermonBlog" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
        

    <asp:SqlDataSource ID="BlogCommentsSqlDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:RPC %>"
        SelectCommand="getSermonBlogCommentsPKWhere" SelectCommandType="StoredProcedure"
        InsertCommand="insertSermonBlogComments" InsertCommandType="StoredProcedure">
        <SelectParameters>
            <asp:Parameter Name="item_id" Type="Int16" />
        </SelectParameters>
        <InsertParameters>
            <asp:ControlParameter ControlID="blogid" PropertyName="Value" Name="id" Type="Int16" />
            <asp:ControlParameter ControlID="Email" Name="title" Type="String" />
            <asp:ControlParameter ControlID="Name" Name="author" Type="String" />
            <asp:ControlParameter ControlID="CommentText" Name="comment" Type="String" />
        </InsertParameters>
    </asp:SqlDataSource>
    <asp:GridView ID="BlogGridView" runat="server" DataSourceID="BlogSqlDataSource" AllowPaging="True"
        AutoGenerateColumns="False" OnRowCreated="BlogRowCreated" DataKeyNames="id"
        PageSize="1" ShowHeader="False" CellPadding="4" GridLines="None" Width="100%" >
        <PagerSettings NextPageText="Older" PreviousPageText="Newer" Mode="NextPrevious" />
        <Columns>
            <asp:TemplateField>
                <ItemTemplate>
                    <h4>
                        <a href="sermons/<%# Convert.ToDateTime(Eval("pubDate")).ToString("yyyy.MM.dd")%>.mp3"><%# Eval("sermonTextReference") %><%# Eval("Title")%></a></h4>
                    <p>
                        <%# Eval("description")%></p>
                    <div class="blogtagline">
                        written by
                        <%# Eval("Author")%>
                        on
                        <%# Convert.ToDateTime(Eval("pubDate")).ToShortDateString()%>
                        |
                        <asp:LinkButton ID="button1" class="link" CommandArgument='<%# Eval("id") %>'
                            runat="server">
                    [<%# Eval("commentCount") %> Comments]
                        </asp:LinkButton>
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
            AutoGenerateColumns="False" ShowHeader="False" CellPadding="4" GridLines="None" 
                            Width="100%" >
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
        <div style="padding: 1em;">
        <span style="font-weight: bold">Leave a comment</span><br /><br />
        <asp:HiddenField ID="blogid" runat="server" />
        <asp:TextBox ID="Name" runat="server" /> <asp:Label AssociatedControlID="Name" Text="Name (required)" runat="server" /><br /><br />
        <asp:TextBox ID="Email" runat="server" /> <asp:Label AssociatedControlID="Email" Text="Email (required &mdash; will not be published)" runat="server" /><br /><br />
        <asp:TextBox ID="CommentText" Rows="10" Columns="50" TextMode="MultiLine" runat="server" /><br /><br />
        <asp:Button Text="Submit Comment" OnCommand="SubmitComments" runat="server" />
        </div>
    </div>
</asp:Content>
