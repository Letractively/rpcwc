<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    Title="Reformed Presbyterian Church &mdash; Login" %>
<script type="text/C#" runat="server">
    public void Page_Load(Object source, EventArgs eventArgs)
    {
        if (Request.QueryString["ReturnUrl"] != null)
        {
            Instruction.Visible = true;
        }
    }
</script>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:Label ID="Instruction" Visible="false" runat="server">This page requires you to be logged in. Please log in to view the page.</asp:Label>
    <asp:LoginView ID="LoginView1" runat="server">
        <AnonymousTemplate>
            <asp:Login ID="Login1" runat="server" VisibleWhenLoggedIn="False">
            </asp:Login>
        </AnonymousTemplate>
        <LoggedInTemplate>
            Logged in as
            <asp:LoginName ID="LoginName1" runat="server" />. Click to
            <asp:LoginStatus ID="LoginStatus1" runat="server" /> or <asp:HyperLink ID="ChangePasswordLink" NavigateUrl="account.aspx" Text="change your password" runat="server" />
        </LoggedInTemplate>
    </asp:LoginView>
</asp:Content>
