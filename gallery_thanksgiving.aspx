<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    Title="Reformed Presbyterian Church &mdash; Thanksgiving Photo Gallery" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <h4>
        <p>
            Photo Gallery</p>
    </h4>
    <p>
        Select a photo gallery from the drop-down menu, then click a thumbnail for a larger
        image.</p>
    <table>
        <td width="18%">
            <div align="center">
                <a href="photogallery.aspx" onclick="return clickreturnvalue()" onmouseover="dropdownmenu(this, event, menu_gallery, '150px')"
                    onmouseout="delayhidemenu()">Select Photo Gallery</a></div>
        </td>
    </table>
    <h3>
        <p>
            Thanksgiving Dinner</p>
    </h3>
    <table width="400" border="0">
        <tr>
            <td>
                <a href="~/images/photo_g1_001.gif" class="thickbox" runat="server">
                    <img src="~/images/photo_g1_001.gif" width="100" height="67" border="0" /></a>
            </td>
            <td>
                <a href="~/images/photo_g1_002.gif" class="thickbox" runat="server">
                    <img src="~/images/photo_g1_002.gif" width="100" height="67" border="0" /></a>
            </td>
            <td>
                <a href="~/images/photo_g1_003.gif" class="thickbox" runat="server">
                    <img src="~/images/photo_g1_003.gif" width="100" height="67" border="0" /></a>
            </td>
        </tr>
        <tr>
            <td>
                <a href="~/images/photo_g1_001.gif" class="thickbox" runat="server">
                    <img src="~/images/photo_g1_001.gif" width="100" height="67" border="0" /></a>
            </td>
            <td>
                <a href="~/images/photo_g1_002.gif" class="thickbox" runat="server">
                    <img src="~/images/photo_g1_002.gif" width="100" height="67" border="0" /></a>
            </td>
            <td>
                <a href="~/images/photo_g1_003.gif" class="thickbox" runat="server">
                    <img src="~/images/photo_g1_003.gif" width="100" height="67" border="0" /></a>
            </td>
        </tr>
        <tr>
            <td>
                <a href="~/images/photo_g1_001.gif" class="thickbox" runat="server">
                    <img src="~/images/photo_g1_001.gif" width="100" height="67" border="0" /></a>
            </td>
            <td>
                <a href="~/images/photo_g1_002.gif" class="thickbox" runat="server">
                    <img src="~/images/photo_g1_002.gif" width="100" height="67" border="0" /></a>
            </td>
            <td>
                <a href="~/images/photo_g1_003.gif" class="thickbox" runat="server">
                    <img src="~/images/photo_g1_003.gif" width="100" height="67" border="0" /></a>
            </td>
        </tr>
    </table>
</asp:Content>
