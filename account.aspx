<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" Title="Reformed Presbyterian Church &mdash; Change Your Password" %>

<script runat="server">

</script>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div style="padding-bottom:1em">Currently logged in: <asp:LoginName Font-Bold="true" runat="server" /></div>

<asp:ChangePassword ID="ChangePasswordControl" runat="server">
<TitleTextStyle ForeColor="#B7D87D"
    Font-Size="14px"
    Font-Bold="true" />
</asp:ChangePassword>
</asp:Content>

