<%@ Page Language="C#" AutoEventWireup="true"
    CodeFile="Default.aspx.cs" Inherits="rpcwc.web._Default" Title="Reformed Presbyterian Church" %>

<%@ Register TagName="AlertMarquee" TagPrefix="rpc" Src="~/includes/marqueealert.ascx" %>
<%@ Import Namespace="Spring.Context" %>
<%@ Import Namespace="Spring.Context.Support" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <rpc:AlertMarquee runat="server" />
    <table style="width: 390; border: 0px; margin: auto;">
        <tr>
            <td width="190" valign="top">
                <p>
                    <a href="~/letterpastor.aspx" runat="server">
                        <img src="~/images/welcome2.jpg" width="190" height="162" border="0" alt="Visitor Information"
                            style="padding-top: 9px; padding-bottom: 10px;" runat="server" /></a></p>
                <p style="text-align: center;">
                    <strong><a href="letterpastor.aspx" runat="server">Visitor Information</a></strong></p>
            </td>
            <td width="10">
                &nbsp;
            </td>
            <td width="190" valign="top">
                <p>
                    <a href="sermon.aspx?label=Fall 2014" runat="server">
                        <img src="~/images/sermon/fall2014_tall.png" width="190" height="162" border="0" alt="Jesus in Judges"
                            style="padding-top: 9px; padding-bottom: 10px;" runat="server" /></a></p>
                <p style="text-align: center;">
                    <strong><a href="sermon.aspx?label=Fall 2014" runat="server">Current Sermon Series</a></strong></p>
            </td>
        </tr>
        <tr>
            <td width="190" valign="top">
                <p>
                    <a id="A2" href="godsgoodnews.aspx" runat="server">
                        <img id="Img2" src="~/images/ggncover.jpg" width="190" height="162" border="0" alt="The Message of Life"
                            style="padding-top: 9px; padding-bottom: 3px;" runat="server" /></a></p>
                <p style="text-align: center;">
                    <strong><a id="A3" href="godsgoodnews.aspx" runat="server">The Message of Life</a></strong></p>
            </td>
            <td width="10">
                &nbsp;
            </td>
            <td width="190" valign="top">
                <p>
                    <a id="A1" href="storyhour.aspx" runat="server">
                        <img id="Img1" src="~/images/storyhour_sm.png" width="190" height="162" border="0" alt="Children's Story Hour"
                            style="padding-top: 9px; padding-bottom: 3px;" runat="server" /></a></p>
                <p style="text-align: center;">
                    <strong><a id="A4" href="storyhour.aspx" runat="server">Children's Story Hour</a></strong></p>
            </td>
        </tr>
    </table>
</asp:Content>
