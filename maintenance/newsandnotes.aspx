﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" ValidateRequest="false" %>

<script runat="server">
    public void SetParams(Object source, SqlDataSourceCommandEventArgs eventArgs)
    {
        eventArgs.Command.Parameters["@author"].Value = Membership.GetUser().UserName;
    }
</script>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:SqlDataSource ID="RPCNewsAndNotesDataSource" ConnectionString="<%$ ConnectionStrings:RPC %>"
        SelectCommand="findNewsAndNotesMaintenance" SelectCommandType="StoredProcedure"
        UpdateCommand="updateNewsAndNotes" UpdateCommandType="StoredProcedure" InsertCommand="createNewsAndNotesEntry"
        InsertCommandType="StoredProcedure" OnInserting="SetParams" DeleteCommand="deleteNewsAndNotesEntry"
        DeleteCommandType="StoredProcedure" runat="server">
        <SelectParameters>
            <asp:Parameter Name="channelId" DefaultValue="10" />
        </SelectParameters>
        <InsertParameters>
            <asp:Parameter Name="channelId" DefaultValue="10" />
            <asp:Parameter Name="title" DefaultValue=" " />
            <asp:Parameter Name="author" />
            <asp:Parameter Name="description" />
            <asp:Parameter Name="active" />
        </InsertParameters>
        <UpdateParameters>
            <asp:Parameter Name="itemId" />
            <asp:Parameter Name="active" />
            <asp:Parameter Name="description" />
        </UpdateParameters>
        <DeleteParameters>
            <asp:Parameter Name="itemId" />
        </DeleteParameters>
    </asp:SqlDataSource>
    <asp:DetailsView ID="DetailsView1" AutoGenerateRows="false" AutoGenerateEditButton="true"
        AutoGenerateDeleteButton="true" AutoGenerateInsertButton="true" AllowPaging="true"
        DataSourceID="RPCNewsAndNotesDataSource" DataKeyNames="itemId" runat="server">
        <Fields>
            <asp:TemplateField ShowHeader="false">
                <ItemTemplate>
                    <%# Eval("description") %>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox1" runat="server" Columns="50" Rows="10" Text='<%# Bind("description") %>'
                        TextMode="MultiLine"></asp:TextBox>
                </EditItemTemplate>
            </asp:TemplateField>
            <asp:CheckBoxField ShowHeader="true" HeaderText="Active" DataField="active" />
        </Fields>
    </asp:DetailsView>
</asp:Content>
