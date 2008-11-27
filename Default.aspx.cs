using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using rpcwc.bo;
using rpcwc.vo;

namespace rpcwc.web
{
    public partial class _Default : System.Web.UI.Page
    {
        protected IDictionary<DateTime, IList<Event>> dates;
        private CalendarManager _calendarManager;

        protected void SetBold(object sender, DayRenderEventArgs eventArgs)
        {
            if (dates.ContainsKey(eventArgs.Day.Date))
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
            dates = calendarManager.findDatesByMonth(eventArgs.NewDate.Year, eventArgs.NewDate.Month);
        }

        protected void Page_Load(object sender, EventArgs eventArgs)
        {
            if (SmallCalendarControl.VisibleDate.Ticks == 0)
            {
                dates = calendarManager.findDatesByMonth(DateTime.Today.Year, DateTime.Today.Month);
            }
            else
            {
                dates = calendarManager.findDatesByMonth(SmallCalendarControl.VisibleDate.Year, SmallCalendarControl.VisibleDate.Month);
            }
        }

        protected void DisplayCalendar(object sender, EventArgs eventArgs)
        {
            Server.Transfer(String.Format("{0}?selectedDate={1}", "calendar.aspx", SmallCalendarControl.SelectedDate.ToShortDateString()));
        }

        public CalendarManager calendarManager
        {
            get { return _calendarManager; }
            set { _calendarManager = value; }
        }
    }
}
