<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="Default.aspx.cs" Inherits="_Default" Title="Reformed Presbyterian Church" %>
<%@ Register TagName="AlertMarquee" TagPrefix="rpc" Src="~/includes/marqueealert.ascx" %>    
    
<script type="text/C#" runat="server">
    protected void SetBold(object sender, DayRenderEventArgs eventArgs)
    {
        if (dates.Contains(eventArgs.Day.Date))
        {
            eventArgs.Day.IsSelectable = true;
            eventArgs.Cell.Font.Bold = true;
        }
        else
        {
            eventArgs.Day.IsSelectable = false;
        }
    }

    protected void VisibleMonthChanged(object sender, MonthChangedEventArgs eventArgs)
    {
        dates = CalendarManager.findDatesByMonth(eventArgs.NewDate.Year, eventArgs.NewDate.Month);
    }

    protected void Page_Load(object sender, EventArgs eventArgs)
    {
        if (SmallCalendarControl.VisibleDate.Ticks == 0)
        {
            dates = CalendarManager.findDatesByMonth(DateTime.Today.Year, DateTime.Today.Month);
        }
        else
        {
            dates = CalendarManager.findDatesByMonth(SmallCalendarControl.VisibleDate.Year, SmallCalendarControl.VisibleDate.Month);
        }
    }

    protected void DisplayCalendar(object sender, EventArgs eventArgs)
    {
        Server.Transfer(String.Format("{0}?selectedDate={1}", "calendar.aspx", SmallCalendarControl.SelectedDate.ToShortDateString()));
    }
    
</script>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <rpc:AlertMarquee runat="server" />
    <table style="width:390;border:0px;margin:auto;">
        <tr>
            <td width="190" valign="top">
                <p>
                    <a href="~/letterpastor.aspx" runat="server">
                        <img src="~/images/welcome.gif" width="190" height="162" border="0" alt="Visitor Information"
                            runat="server" /></a></p>
                <p style="text-align: center;">
                    <strong><a href="letterpastor.aspx" runat="server">Visitor Information</a></strong></p>
            </td>
            <td width="10">
                &nbsp;
            </td>
            <td width="190" valign="top">
                <p>
                    <a href="godsgoodnews.aspx" runat="server">
                        <img src="~/images/ggn.gif" width="190" height="162" border="0" alt="The Message of Life"
                            runat="server" /></a></p>
                <p style="text-align: center;">
                    <strong><a href="godsgoodnews.aspx" runat="server">The Message of Life</a></strong></p>
            </td>
        </tr>
        <tr>
            <td valign="top">
                <p>
                    <asp:Calendar ID="SmallCalendarControl" DayNameFormat="Shortest" 
                        BorderColor="#CCCCFF" BorderWidth="1px"
                        Font-Names="Verdana" Font-Size="8pt" ForeColor="#336699"
                        Height="162px" Width="190px" ShowGridLines="True"
                        OnDayRender="SetBold" OnVisibleMonthChanged="VisibleMonthChanged" OnSelectionChanged="DisplayCalendar"
                        runat="server">
                        <SelectedDayStyle BackColor="#B7D87D" ForeColor="White" Font-Bold="True" />
                        <SelectorStyle BackColor="#FFFFFF" ForeColor="#B7D87D" />
                        <OtherMonthDayStyle ForeColor="#6699CC" />
                        <NextPrevStyle Font-Size="9pt" ForeColor="#CCCCFF" />
                        <DayHeaderStyle BackColor="#B7D87D" ForeColor="#FFFFFF" Font-Bold="True" Height="1px" />
                        <TitleStyle BackColor="#446A7D" Font-Bold="False" Font-Size="9pt" ForeColor="#FFFFFF" />
                    </asp:Calendar>
                </p>
                <p style="text-align: center;">
                    <strong><a href="~/calendar.aspx" runat="server">Church Calendar</a></strong></p>
            </td>
            <td>
                &nbsp;
            </td>
            <td valign="top">
                <p style="padding-top:1em;">
                    <img src="~/images/upcoming.gif" width="190" height="162" alt="Upcoming Events"
                        runat="server" /></p>
                <p style="text-align: center;">
                    <strong><a href="~/upcomingevents.aspx" runat="server">Upcoming Events</a></strong></p>
            </td>
        </tr>
    </table>
</asp:Content>
