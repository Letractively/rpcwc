<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    Title="Reformed Presbyterian Church &mdash; Contact Us" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <h4>
        Phone and Email Contact</h4>
    <table width="480" border="0">
        <tr>
            <td valign="top">
                <p>
                    312 West Union Street<br />
                    West Chester, PA 19382<br />
                    <br />
                    610-696-3482<br />
                    <br />
                    Pastor Stan Gale's Email<br />
                    <a href="mailto:pastor@rpcwc.org" target="_blank">pastor@rpcwc.org</a>
                </p>
                <p>
                    Church Office<br />
                    <a href="mailto:rpc_office@juno.com">rpc_office@juno.com</a>
                </p>
                <p>
                    <a href="contactus_p.aspx" runat="server" target="_blank">Print this page</a></p>
            </td>
            <td valign="top">
                <div style="text-align:right">
                    <img src="~/images/cellphone.gif" width="300" height="200" alt="" runat="server" /></div>
            </td>
        </tr>
    </table>
</asp:Content>
