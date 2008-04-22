<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" Title="Sermon Blog Maintenance Screen" %>

<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:SqlDataSource ID="BlogMaintenanceSqlDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:RPC %>"
        SelectCommand="getSermonBlogForMaintenance" SelectCommandType="StoredProcedure" InsertCommand="insertSermonBlog"
        InsertCommandType="StoredProcedure" UpdateCommand="updateSermonBlog" UpdateCommandType="StoredProcedure">
        <InsertParameters>
            <asp:Parameter Name="title" Type="String" />
            <asp:Parameter Name="pubDate" Type="DateTime" />
            <asp:Parameter Name="description" Type="String" />
            <asp:Parameter Name="sermonText" Type="String" />
        </InsertParameters>
        </asp:SqlDataSource>
    
    <br />
    <asp:FormView ID="FormView1" runat="server" AllowPaging="True" 
        DataKeyNames="id" DataSourceID="BlogMaintenanceSqlDataSource">
        <EditItemTemplate>
            ID:
            <asp:Label ID="idLabel" runat="server" Text='<%# Bind("id") %>' Enabled="false" />
            <br />
            Sermon Title:
            <asp:TextBox ID="titleTextBox" runat="server" Text='<%# Bind("title") %>' />
            <br />
            Sermon Text:
            <asp:TextBox ID="sermonTextReferenceTextBox" runat="server" 
                Text='<%# Bind("sermonTextReference") %>' />
            <br />
            Date Preached:
            <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("pubDate") %>' Enabled="false" />
            <br />
            Blog Entry:
            <asp:TextBox ID="TextBox2" runat="server" 
                Text='<%# Bind("description") %>' Rows="10" Wrap="true" Columns="100" 
                TextMode="MultiLine" />
            <br />
            <asp:LinkButton ID="UpdateButton" runat="server" CausesValidation="True" 
                CommandName="Update" Text="Update" />
            &nbsp;<asp:LinkButton ID="UpdateCancelButton" runat="server" 
                CausesValidation="False" CommandName="Cancel" Text="Cancel" />
        </EditItemTemplate>
        <InsertItemTemplate>     
            Sermon Title:
            <asp:TextBox ID="titleTextBox" runat="server" Text='<%# Bind("title") %>' />
            <br />
            Sermon Text:
            <asp:TextBox ID="sermonTextReferenceTextBox" runat="server" 
                Text='<%# Bind("sermonText") %>' />
            <br />
            Date Preached:
            <asp:TextBox ID="pubDateTextBox" runat="server" Text='<%# Bind("pubDate") %>' />
            <br />
            Blog Entry:
            <asp:TextBox ID="descriptionTextBox" runat="server" 
                Text='<%# Bind("description") %>' Rows="10" Wrap="true" Columns="100" 
                TextMode="MultiLine" />
            <br />
            <asp:LinkButton ID="InsertButton" runat="server" CausesValidation="True" 
                CommandName="Insert" Text="Insert" />
            &nbsp;<asp:LinkButton ID="InsertCancelButton" runat="server" 
                CausesValidation="False" CommandName="Cancel" Text="Cancel" />
        </InsertItemTemplate>
        <ItemTemplate>
            <b>ID</b>:
            <asp:Label ID="idLabel" runat="server" Text='<%# Eval("id") %>' />
            <br />
            <b>Title</b>:
            <asp:Label ID="titleLabel" runat="server" Text='<%# Bind("title") %>' />
            <br />
            <b>Sermon Text</b>:
            <asp:Label ID="sermonTextReferenceLabel" runat="server" 
                Text='<%# Bind("sermonTextReference") %>' />
            <br />
            <!--Preacher:
            <asp:Label ID="authorLabel" runat="server" Text='<%# Bind("author") %>' />
            <br />-->
            <!--Link:
            <asp:Label ID="linkLabel" runat="server" Text='<%# Bind("link") %>' />
            <br /> -->
            <b>Date Preached</b>:
            <asp:Label ID="pubDateLabel" runat="server" Text='<%# Bind("pubDate") %>' />
            <br />
            <b>Blog Entry</b>:
            <asp:Label ID="descriptionLabel" runat="server" 
                Text='<%# Bind("description") %>' />
            <br />
            <asp:LinkButton ID="NewButton" runat="server" CausesValidation="False" 
                CommandName="New" Text="New" />
            &nbsp;<asp:LinkButton ID="EditButton" runat="server" CausesValidation="False" 
                CommandName="Edit" Text="Edit" />
        </ItemTemplate>                
        <PagerTemplate>
                  <table>
                    <tr>
                      <td><asp:LinkButton ID="FirstButton" CommandName="Page" CommandArgument="First" Text="Newest" RunAt="server"/></td>
                      <td><asp:LinkButton ID="PrevButton"  CommandName="Page" CommandArgument="Prev"  Text="Newer"  RunAt="server"/></td>
                      <td><asp:LinkButton ID="NextButton"  CommandName="Page" CommandArgument="Next"  Text="Older"  RunAt="server"/></td>
                      <td><asp:LinkButton ID="LastButton"  CommandName="Page" CommandArgument="Last"  Text="Oldest" RunAt="server"/></td>
                    </tr>
                  </table>
                </PagerTemplate>
    </asp:FormView>
</asp:Content>
