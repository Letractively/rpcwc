using System;
using System.Collections;
using System.Web.UI.WebControls;

public partial class SmallCalendar : System.Web.UI.Page
{
    private IList dates;

    protected void UpdateDescription(object sender, EventArgs eventArgs)
    {        
        if (SmallCalendarControl.SelectedDate.Date != null && SmallCalendarControl.SelectedDate.Ticks != 0)// && getEventCalendarEntry(eventCalendar, SmallCalendarControl.SelectedDate.Date) != null)
        {
            WebControl eventControl = CalendarManager.findEvent(SmallCalendarControl.SelectedDate.Date);
            EventInfo.Controls.Add(eventControl);
        }
    }

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

    protected void Page_Init(object sender, EventArgs eventArgs)
    {
    }

    protected void VisibleMonthChanged(object sender, MonthChangedEventArgs eventArgs)
    {
        dates = CalendarManager.findDatesByMonth(eventArgs.NewDate.Year, eventArgs.NewDate.Month);
    }

    protected void Page_Load(object sender, EventArgs eventArgs)
    {
        DateTime selectedDate = new DateTime();

        if (DateTime.TryParse(Request.QueryString["selectedDate"], out selectedDate))
        {
            SmallCalendarControl.VisibleDate = selectedDate;
            SmallCalendarControl.SelectedDate = selectedDate;
        }

        if (SmallCalendarControl.VisibleDate.Ticks == 0)
        {
            dates = CalendarManager.findDatesByMonth(DateTime.Today.Year, DateTime.Today.Month);
        }
        else
        {
            dates = CalendarManager.findDatesByMonth(SmallCalendarControl.VisibleDate.Year, SmallCalendarControl.VisibleDate.Month);
        }
    }  

    private ArrayList getEventCalendarEntry(EventCalendar eventCalendar, DateTime date)
    {
        return (ArrayList) eventCalendar.events[date];
    }
}
