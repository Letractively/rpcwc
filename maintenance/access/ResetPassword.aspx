<%@ Page Language="C#" MasterPageFile="~/maintenance/access/accessMaintenance.master" Title="Untitled Page" %>

<script runat="server">
    public void getAllUsers(Object source, EventArgs eventArgs)
    {
        UserList.Items.Clear();
        MembershipUserCollection users = Membership.GetAllUsers();
        foreach (MembershipUser user in users)
        {
            if (!Membership.ValidateUser(user.UserName, user.UserName))
                UserList.Items.Add(user.UserName);
        }
    }
    
    protected void ResetPassword(Object source, CommandEventArgs eventArgs)
    {
        foreach (ListItem listItem in UserList.Items)
        {
            if (listItem.Selected)
            {
                MembershipUserCollection users = Membership.FindUsersByName(listItem.Value);
                foreach (MembershipUser user in users)
                {
                    String password = user.ResetPassword();
                    user.ChangePassword(password, user.UserName);
                }
            }
        }
    }
</script>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
   <asp:ListBox ID="UserList" OnInit="getAllUsers" SelectionMode="Multiple" runat="server" />
        <asp:Button ID="Button1" OnCommand="ResetPassword" runat="server"/>
</asp:Content>

