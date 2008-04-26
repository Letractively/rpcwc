<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
 Title="Reformed Presbyterian Church &mdash; Member Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

<p><h2>Member Login</h2></p>

<form name="form1" method="post" action="">
 <table width="13%" border="0">
 <tr>
 <td>Username</td>
 <td><input name="password" type="text" id="password" size="7"></td>
 </tr>
 <tr>
 <td>Password</td>
 <td><input name="textfield" type="text" size="7"></td>
 </tr>
 <tr>
 </tr>
 <tr>
 <td><input type="image" name="submit" align="center" src="images/submit.gif" border="0" /></td>
 </tr>
 </table>
</form>
</asp:Content>
