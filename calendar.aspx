<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="~/calendar.aspx.cs" Inherits="SmallCalendar" Title="Reformed Presbyterian Church &mdash; Special Events Calendar"
    EnableViewState="true" EnableSessionState="True" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table style="width: 100%;">
        <tr>
            <td style="vertical-align: top">
                <asp:Calendar ID="SmallCalendarControl" runat="server" BorderColor="#CCCCFF" BorderWidth="1px"
                    DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="#336699"
                    Height="200px" ShowGridLines="True" Width="220px" OnPreRender="UpdateDescription"
                    OnDayRender="SetBold" OnSelectionChanged="SelectionChanged" OnVisibleMonthChanged="VisibleMonthChanged" >
                    <SelectedDayStyle BackColor="#B7D87D" ForeColor="White" Font-Bold="True" />
                    <SelectorStyle BackColor="#FFFFFF" ForeColor="#B7D87D" />
                    <OtherMonthDayStyle ForeColor="#6699CC" />
                    <NextPrevStyle Font-Size="9pt" ForeColor="#CCCCFF" />
                    <DayHeaderStyle BackColor="#B7D87D" ForeColor="#FFFFFF" Font-Bold="True" Height="1px" />
                    <TitleStyle BackColor="#446A7D" Font-Bold="False" Font-Size="9pt" ForeColor="#FFFFFF" />
                </asp:Calendar>
            </td>
            <td style="width: 100%; padding: 0 1em 0 1em; vertical-align: top;"  runat="server">
                <asp:PlaceHolder runat="server" ID="EventInfo" /> 
            </td>
        </tr>
    </table>
</asp:Content>
