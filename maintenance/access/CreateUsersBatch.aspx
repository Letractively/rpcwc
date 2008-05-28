<%@ Page Language="C#" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">
    public void buttonclick(Object source, CommandEventArgs eventArgs)
    {
        System.IO.StreamReader reader = new System.IO.StreamReader(file.PostedFile.InputStream);
        while (!reader.EndOfStream)
        {
            String line = reader.ReadLine();
            try
            {
                Membership.CreateUser(line, line);
            }
            catch (Exception)
            {
            }
        }
    }
    public void assignuserstorole(Object source, CommandEventArgs eventArgs)
    {
        MembershipUserCollection users = Membership.GetAllUsers();
        foreach (MembershipUser user in users)
        {
            String item = user.UserName;
            try
            {
                String password = user.ResetPassword();
                user.ChangePasswordQuestionAndAnswer(password, "x", "y");
                try
                {
                    user.ChangePassword(password, user.UserName);
                    item += " " + user.GetPassword("y");
                }
                catch (Exception)
                {
                    //password = "x";
                    item += " x";
                }
            }
            catch (Exception)
            {
                item += "error setting qa";   
            }
            
            thebox.Items.Add(item);
            
        }
    }
</script>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:FileUpload ID="file" runat="server" />
        <asp:LinkButton ID="button" runat="server" OnCommand="buttonclick" Text="Create Users" />
        <asp:LinkButton ID="LinkButton1" runat="server" OnCommand="assignuserstorole" Text="Assign all users as member" />
        <asp:ListBox ID="thebox" runat="server" Rows="150"></asp:ListBox>
    </div>
    </form>
</body>
</html>
