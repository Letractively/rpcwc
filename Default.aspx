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
                            runat="server" /></a></p>
                <p style="text-align: center;">
                    <strong><a href="letterpastor.aspx" runat="server">Visitor Information</a></strong></p>
            </td>
            <td width="10">
                &nbsp;
            </td>
            <td width="190" valign="top">
                <p>
                    <a href="sermon.aspx?label=Spring 2013" runat="server">
                        <img src="~/images/sermon/spring2013.jpg" width="190" height="162" border="0" alt="The Pilgrim's Journey: Psalms Of Ascent: Spring/Summer 2013"
                            style="padding-top: 9px; padding-bottom: 10px;" runat="server" /></a></p>
                <p style="text-align: center;">
                    <strong><a href="sermon.aspx?label=Spring 2013" runat="server">Current Sermon Series</a></strong></p>
            </td>
        </tr>
        <tr>
            <td valign="top">
                <p style="padding-bottom: 0em;">
                    <asp:Calendar ID="SmallCalendarControl" DayNameFormat="Shortest" BorderColor="#CCCCFF"
                        BorderWidth="1px" Font-Names="Verdana" Font-Size="8pt" ForeColor="#336699" Height="162px"
                        Width="190px" ShowGridLines="True" OnDayRender="SetBold" OnVisibleMonthChanged="VisibleMonthChanged"
                        OnSelectionChanged="DisplayCalendar" runat="server">
                        <SelectedDayStyle BackColor="#B7D87D" ForeColor="White" Font-Bold="True" />
                        <SelectorStyle BackColor="#FFFFFF" ForeColor="#B7D87D" />
                        <OtherMonthDayStyle ForeColor="#6699CC" />
                        <NextPrevStyle Font-Size="9pt" ForeColor="#CCCCFF" />
                        <DayHeaderStyle BackColor="#B7D87D" ForeColor="#FFFFFF" Font-Bold="True" Height="1px" />
                        <TitleStyle BackColor="#446A7D" Font-Bold="False" Font-Size="9pt" ForeColor="#FFFFFF" />
                    </asp:Calendar>
                </p>
                <p style="padding-top: 1em; text-align: center;">
                    <strong><a id="A4" href="~/calendar.aspx" runat="server">Church Calendar</a></strong></p>
            </td>
            <td width="10">
                &nbsp;
            </td>
            <td width="190" valign="top">
                <p>
                    <a id="A2" href="godsgoodnews.aspx" runat="server">
                        <img id="Img2" src="~/images/ggncover.jpg" width="190" height="147" border="0" alt="The Message of Life"
                            runat="server" /></a></p>
                <p style="text-align: center;">
                    <strong><a id="A3" href="godsgoodnews.aspx" runat="server">The Message of Life</a></strong></p>
            </td>
        </tr>
    </table>
</asp:Content>
