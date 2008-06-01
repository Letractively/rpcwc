<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" ValidateRequest="false" %>

<script runat="server">
</script>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:SqlDataSource id="RPCNewsAndNotesDataSource" ConnectionString="<%$ ConnectionStrings:RPC %>"
        SelectCommand="findNewsAndNotesMaintenance" SelectCommandType="StoredProcedure"
        UpdateCommand="updateNewsAndNotes" UpdateCommandType="StoredProcedure"
        runat="server">
        <SelectParameters>
            <asp:Parameter Name="channelId" DefaultValue="10" />
        </SelectParameters>
        <UpdateParameters>
            <asp:Parameter Name="itemId" />
            <asp:Parameter Name="active" />
            <asp:Parameter Name="description" />
        </UpdateParameters>
    </asp:SqlDataSource>
    <asp:DetailsView ID="DetailsView1" AutoGenerateRows="false" AutoGenerateEditButton="true" AutoGenerateInsertButton="true" AllowPaging="true" DataSourceID="RPCNewsAndNotesDataSource" DataKeyNames="itemId" runat="server">
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

