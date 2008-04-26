<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" Title="Reformed Presbyterian Church &mdash; Easter Sundae Outing Photo Gallery" %>

<script runat="server">

</script>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <h4>
        Easter Sunday, March 15, 2008 Photo Gallery</h4>
    <p>
        Click on the the small photo to view the photo at full size.
    </p>
    <table class="photogallery" width="400" border="0">
        <tr>
            <td>
                <a href="~/images/easter1L.jpg" runat="server" class="thickbox">
                    <img src="~/images/easter1.gif" runat="server" alt="" width="100" height="67" border="0" /></a>
            </td>
            <td>
                <a href="~/images/easter2L.jpg" runat="server" class="thickbox">
                    <img src="~/images/easter2.gif" runat="server" alt="" width="100" height="67" border="0" /></a>
            </td>
            <td>
                <a href="~/images/easter3L.jpg" runat="server" class="thickbox">
                    <img src="~/images/easter3.gif" runat="server" alt="" width="100" height="67" border="0" /></a>
            </td>
        </tr>
        <tr>
            <td>
                <a href="~/images/easter4L.jpg" runat="server" class="thickbox">
                    <img src="~/images/easter4.gif" runat="server" alt="" width="100" height="67" border="0" /></a>
            </td>
            <td>
            </td>
            <td>
            </td>
        </tr>
    </table>
</asp:Content>
