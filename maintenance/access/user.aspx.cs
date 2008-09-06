using System;
using System.Collections;
using System.Web.Security;
using System.Web.UI.WebControls;

public partial class maintenance_access_user : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request["__EVENTARGUMENT"] != null && Request["__EVENTARGUMENT"] == "deleteUser")
        {
            Membership.DeleteUser(UserList.SelectedValue);
            getAllUsers();
        }

        UserList.Attributes.Add("ondblclick", ClientScript.GetPostBackEventReference(UserList, "deleteUser"));
    }

    protected void getAllUsers(Object source, EventArgs eventArgs)
    {
        getAllUsers();
    }

    protected void getAllUsers()
    {
        UserList.Items.Clear();
        MembershipUserCollection users = Membership.GetAllUsers();
        foreach (MembershipUser user in users)
        {
            UserList.Items.Add(user.UserName);
        }
    }

    protected void UserSelected(Object source, EventArgs eventArgs)
    {
        String userName = UserList.SelectedValue;
        /*
        MembershipUserCollection users = Membership.FindUsersByName(userName);
        if (users.Count == 0)
            return;

        MembershipUser user = (MembershipUser)users.GetEnumerator().Current;
        */
        ChangePassword.UserName = userName;
    }
}
