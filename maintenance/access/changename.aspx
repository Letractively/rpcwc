<%@ Page Language="C#" MasterPageFile="~/maintenance/access/accessMaintenance.master"
    Title="Untitled Page" %>

<script runat="server">
    public void getAllUsers(Object source, EventArgs eventArgs)
    {
        UserList.Items.Clear();
        MembershipUserCollection users = Membership.GetAllUsers();
        foreach (MembershipUser user in users)
        {
            UserList.Items.Add(user.UserName);
        }
    }

    protected void UserSelected(Object source, CommandEventArgs eventArgs)
    {
        OldUsername.Text = UserList.SelectedValue;
    }

    protected void ChangeName(Object source, CommandEventArgs eventArgs)
    {
        NameChangeDataSource.UpdateParameters["UserName"].DefaultValue = OldUsername.Text;
        NameChangeDataSource.UpdateParameters["NewUserName"].DefaultValue = NewUsername.Text;
        NameChangeDataSource.Update();
    }
</script>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:SqlDataSource ID="NameChangeDataSource" UpdateCommand="UPDATE dbo.aspnet_Users WITH (ROWLOCK) SET UserName = @NewUserName, loweredusername=LOWER(@NewUserName) WHERE @UserName = UserName"
        UpdateCommandType="Text"
        ConnectionString="<%$ ConnectionStrings:RPC %>"
        runat="server">
        <UpdateParameters>
            <asp:Parameter Name="UserName" />
            <asp:Parameter Name="NewUserName" />
        </UpdateParameters>
        </asp:SqlDataSource>
        <div style="float:left">
    <asp:ListBox ID="UserList" OnInit="getAllUsers" runat="server" />
        <asp:Button OnCommand="UserSelected" runat="server"/>
        </div>
        
        <div style="float:right">
    <asp:Label AssociatedControlID="OldUsername" runat="server" /><asp:TextBox ID="OldUsername"
        runat="server" /><br />
    <asp:Label ID="Label1" AssociatedControlID="NewUsername" runat="server" /><asp:TextBox
        ID="NewUsername" runat="server" />
    <asp:Button OnCommand="ChangeName" runat="server" />
    </div>
</asp:Content>
