<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" Title="Untitled Page" %>

<script runat="server">
    public void Page_Load(Object source, EventArgs eventArgs)
    {
        FormsAuthentication.SignOut();
        Page.Response.Redirect("login.aspx");
    }
</script>