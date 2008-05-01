<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" Title="Sermon Blog Maintenance Screen"
    ValidateRequest="false" %>

<script type="text/C#" runat="server">
    public void Inserting(Object source, SqlDataSourceCommandEventArgs eventArgs)
    {
        eventArgs.Command.Parameters["@pubDate"].Value = ((Calendar)FormView1.FindControl("DatePicker")).SelectedDate;
        eventArgs.Command.Parameters["@title"].Value = ((TextBox)FormView1.FindControl("SermonTitle")).Text;
    }
    
    public void UploadFile(Object source, CommandEventArgs eventArgs)
    {
        FileUpload FileControl = (FileUpload)FormView1.FindControl("FileControl");
        Calendar DatePicker = (Calendar)FormView1.FindControl("DatePicker");
        
        if (FileControl.PostedFile != null && FileControl.PostedFile.ContentLength > 0)
        {
            String filename = DatePicker.SelectedDate.ToString("yyyy.MM.dd") + ".mp3";
            String saveLocation = Server.MapPath("../../sermons") + "\\" + filename;
            try
            {
                FileControl.PostedFile.SaveAs(saveLocation);
                status.InnerHtml = "Uploaded Succesfully";
                status.Style.Add(HtmlTextWriterStyle.Color, "Red");

                BlogMaintenanceSqlDataSource.InsertParameters["link"].DefaultValue = "sermons/" + filename;
                BlogMaintenanceSqlDataSource.InsertParameters["size"].DefaultValue = FileControl.PostedFile.ContentLength.ToString();
                BlogMaintenanceSqlDataSource.InsertParameters["type"].DefaultValue = "audio/mpeg3";
                //BlogMaintenanceSqlDataSource.Insert();
                FormView1.InsertItem(false);
            }
            catch (Exception exception)
            {
                status.InnerHtml = "Error: " + exception;
                status.Style.Add(HtmlTextWriterStyle.Color, "Red");
            }
        }
        else
        {
            status.InnerHtml = "Please select a file to upload.";
            status.Style.Add(HtmlTextWriterStyle.Color, "Red");
        }        
    }
</script>

<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:SqlDataSource ID="BlogMaintenanceSqlDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:RPC %>"
        SelectCommand="getSermonBlogForMaintenance" SelectCommandType="StoredProcedure"
        InsertCommand="insertSermonBlog" InsertCommandType="StoredProcedure" UpdateCommand="updateSermonBlog"
        UpdateCommandType="StoredProcedure" OnInserting="Inserting"
        DeleteCommand="deleteSermonBlogEntry" DeleteCommandType="StoredProcedure">
        <InsertParameters>
            <asp:Parameter Name="channelId" DefaultValue="1" />
            <asp:Parameter Name="title" Type="String" />
            <asp:Parameter Name="author" DefaultValue='Dr. Stanley D. Gale' />
            <asp:Parameter Name="pubDate" />
            <asp:Parameter Name="description" Type="String" />
            <asp:Parameter Name="sermonTextReference" Type="String" />
            <asp:Parameter Name="link" />
            <asp:Parameter Name="size" />
            <asp:Parameter Name="type" />
        </InsertParameters>
        <DeleteParameters>
            <asp:Parameter Name="id" />
        </DeleteParameters>
    </asp:SqlDataSource>
    <br />
    <asp:FormView ID="FormView1" runat="server" AllowPaging="True" DataKeyNames="id"
        DataSourceID="BlogMaintenanceSqlDataSource">
        <EmptyDataTemplate>
            <asp:LinkButton ID="NewButton" runat="server" CausesValidation="False" CommandName="New"
                Text="New" />
        </EmptyDataTemplate>
        <EditItemTemplate>
            ID:
            <asp:Label ID="idLabel" runat="server" Text='<%# Bind("id") %>' Enabled="false" />
            <br />
            Sermon Title:
            <asp:TextBox ID="titleTextBox" runat="server" Text='<%# Bind("title") %>' />
            <br />
            Sermon Text:
            <asp:TextBox ID="sermonTextReferenceTextBox" runat="server" Text='<%# Bind("sermonTextReference") %>' />
            <br />
            Date Preached:
            <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("pubDate") %>' Enabled="false" />
            <br />
            Blog Entry:
            <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("description") %>' Rows="10"
                Wrap="true" Columns="100" TextMode="MultiLine" />
            <br />
            <asp:LinkButton ID="UpdateButton" runat="server" CausesValidation="False" CommandName="Update"
                Text="Update" />
            &nbsp;<asp:LinkButton ID="UpdateCancelButton" runat="server" CausesValidation="False"
                CommandName="Cancel" Text="Cancel" />
        </EditItemTemplate>
        <InsertItemTemplate>
            <asp:Label ID="DatePickerLabel1" AssociatedControlID="DatePicker" Text="Date Preached: "
                runat="server" /><asp:Calendar ID="DatePicker" SelectedDate='<%# Bind("pubDate") %>'
                    runat="server" />
            <br />
            <br />
            <asp:Label ID="SermonTitleLabel1" AssociatedControlID="SermonTitle" Text="Title: "
                runat="server" /><asp:TextBox ID="SermonTitle" Text='<%# Bind("title") %>' runat="server" /><br />
            <br />
            <asp:Label ID="ScriptureReferenceLabel1" AssociatedControlID="ScriptureReference"
                Text="Scripture Reference: " runat="server" /><asp:TextBox ID="ScriptureReference"
                    Text='<%# Bind("sermonTextReference") %>' runat="server" /><br />
            <br />
            <asp:Label ID="FileControlLabel" AssociatedControlID="FileControl" Text="File: "
                runat="server" /><asp:FileUpload ID="FileControl" runat="server" /><br />
            <br />
            <asp:Label ID="BlogEntry1" AssociatedControlID="Description" Text="Blog Entry: " runat="server" /><asp:TextBox
                ID="Description" runat="server" Text='<%# Bind("description") %>' Rows="10" Wrap="true"
                Columns="50" TextMode="MultiLine" />
                <br />
            <asp:LinkButton ID="InsertButton" runat="server" OnCommand="UploadFile" Text="Insert"
                CausesValidation="false" />
            &nbsp;<asp:LinkButton ID="InsertCancelButton" runat="server" CausesValidation="False"
                CommandName="Cancel" Text="Cancel" />
        </InsertItemTemplate>
        <ItemTemplate>
            <b>ID</b>:
            <asp:Label ID="idLabel" runat="server" Text='<%# Eval("id") %>' />
            <br />
            <b>Title</b>:
            <asp:Label ID="titleLabel" runat="server" Text='<%# Bind("title") %>' />
            <br />
            <b>Sermon Text</b>:
            <asp:Label ID="sermonTextReferenceLabel" runat="server" Text='<%# Bind("sermonTextReference") %>' />
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
            <asp:Label ID="descriptionLabel" runat="server" Text='<%# Bind("description") %>' />
            <br />
            <asp:LinkButton ID="NewButton" runat="server" CausesValidation="False" CommandName="New"
                Text="New" />
            &nbsp;<asp:LinkButton ID="EditButton" runat="server" CausesValidation="False" CommandName="Edit"
                Text="Edit" />
            &nbsp;<asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Delete"
                Text="Delete" />
        </ItemTemplate>
        <PagerTemplate>
            <table>
                <tr>
                    <td>
                        <asp:LinkButton ID="FirstButton" CommandName="Page" CommandArgument="First" Text="Newest"
                            runat="server" />
                    </td>
                    <td>
                        <asp:LinkButton ID="PrevButton" CommandName="Page" CommandArgument="Prev" Text="Newer"
                            runat="server" />
                    </td>
                    <td>
                        <asp:LinkButton ID="NextButton" CommandName="Page" CommandArgument="Next" Text="Older"
                            runat="server" />
                    </td>
                    <td>
                        <asp:LinkButton ID="LastButton" CommandName="Page" CommandArgument="Last" Text="Oldest"
                            runat="server" />
                    </td>
                </tr>
            </table>
        </PagerTemplate>
    </asp:FormView>
    
    <div id="status" runat="server" />
</asp:Content>
