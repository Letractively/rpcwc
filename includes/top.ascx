<%@ Control Language="C#" ClassName="top" %>

<script type="text/C#" runat="server">
public void LogOff(Object source, CommandEventArgs eventArgs)
{
    FormsAuthentication.SignOut();
    //loginview
}
</script>

<asp:LoginView ID="loginview" runat="server">
<LoggedInTemplate>
<span style="float:right;color:White;">
<a href="~/logoff.aspx" runat="server">Log off</a> | <a href="~/account.aspx" runat="server">My account</a>
</span>
</LoggedInTemplate>
<AnonymousTemplate>
<span style="float:right;color:White;">
<a id="A1" href="~/login.aspx" runat="server">Log on</a>
</span>
</AnonymousTemplate>
</asp:LoginView>