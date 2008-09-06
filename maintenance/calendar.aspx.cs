using System;
using System.Collections;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using Spring.Context;
using Spring.Context.Support;
using rpcwc.bo;

public partial class maintenance_calendar : Page
{
 /*   
    private IDictionary dates;
    private CalendarManager _calendarManager;

    public maintenance_calendar()
    {
        IApplicationContext context = ContextRegistry.GetContext();
        calendarManager = (CalendarManager)context.GetObject("CalendarManager");
    }

    protected void SelectionChanged(object sender, EventArgs eventArgs)
    {
        Server.Transfer(String.Format("{0}?selectedDate={1}", "calendar.aspx", SmallCalendarControl.SelectedDate.ToShortDateString()));
    }

    protected void UpdateDescription(object sender, EventArgs eventArgs)
    {
    }

    void editButton_Command(object sender, CommandEventArgs e)
    {
        Server.Transfer(String.Format("{0}?selectedDate={1}&itemId={2}", "calendarEdit.aspx", SmallCalendarControl.SelectedDate.ToShortDateString(), (String)e.CommandArgument));

        

    }

    private WebControl findEventsForDay(DateTime dateTime)
    {
        IList eventList = calendarManager.findEventsForDay(SmallCalendarControl.SelectedDate.Date);

        WebControl eventControl = new WebControl(HtmlTextWriterTag.Div);
        eventControl.Controls.Add(CalendarUtil.getDateHeader(SmallCalendarControl.SelectedDate.Date));

        foreach (Event oneEvent in eventList)
        {
            eventControl.Controls.Add(CalendarUtil.createEventControlMaintenance(oneEvent, new CommandEventHandler(editButton_Command)));
        }

        return eventControl;
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


        if (selectedDate != null && selectedDate.Ticks != 0)// && getEventCalendarEntry(eventCalendar, SmallCalendarControl.SelectedDate.Date) != null)
        {
            EventInfo.Controls.Add(findEventsForDay(selectedDate));
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
  * */
}
