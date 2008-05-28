using System;
using System.Collections;
using System.Web.UI;
using System.Web.UI.WebControls;
using Spring.Context;
using Spring.Context.Support;

public partial class SmallCalendar : System.Web.UI.Page
{
    private IDictionary dates;
    private CalendarManager _calendarManager;

    public SmallCalendar()
    {
        IApplicationContext context = ContextRegistry.GetContext();
        calendarManager = (CalendarManager)context.GetObject("CalendarManager");
    }

    protected void SelectionChanged(object sender, EventArgs eventArgs)
    {
        SmallCalendarControl.VisibleDate = SmallCalendarControl.SelectedDate;
    }

    protected void UpdateDescription(object sender, EventArgs eventArgs)
    {
        if (SmallCalendarControl.SelectedDate.Date != null && SmallCalendarControl.SelectedDate.Ticks != 0)// && getEventCalendarEntry(eventCalendar, SmallCalendarControl.SelectedDate.Date) != null)
        {
            WebControl eventControl = calendarManager.findEvent(SmallCalendarControl.SelectedDate.Date);
            EventInfo.Controls.Add(eventControl);
        }
    }

    protected void SetBold(object sender, DayRenderEventArgs eventArgs)
    {
        if (dates.Contains(eventArgs.Day.Date))
        {
            eventArgs.Day.IsSelectable = true;
            eventArgs.Cell.Font.Bold = true;
            ((LiteralControl)eventArgs.Cell.Controls[0]).Text = (String)dates[eventArgs.Day.Date];
            eventArgs.Cell.ToolTip = (String) dates[eventArgs.Day.Date];
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
        dates = calendarManager.findDatesByMonth(eventArgs.NewDate.Year, eventArgs.NewDate.Month);
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
            dates = calendarManager.findDatesByMonth(DateTime.Today.Year, DateTime.Today.Month);
        }
        else
        {
            dates = calendarManager.findDatesByMonth(SmallCalendarControl.VisibleDate.Year, SmallCalendarControl.VisibleDate.Month);
        }
    }  

    private ArrayList getEventCalendarEntry(EventCalendar eventCalendar, DateTime date)
    {
        return (ArrayList) eventCalendar.events[date];
    }

    public CalendarManager calendarManager
    {
        get
        {
            return _calendarManager;
        }
        set
        {
            _calendarManager = value;
        }
    }
}
