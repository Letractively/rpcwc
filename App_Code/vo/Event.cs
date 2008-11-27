using System;

/// <summary>
/// Summary description for Event
/// </summary>
namespace rpcwc.vo
{
    public class Event : RPCVO, IComparable<Event>
    {
        private DateTime _date;
        private DateTime _endDate;
        private String _title;
        private String _description;
        private String _author;
        private bool _allDayEvent;
        private bool _specialEvent;

        public Event()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        #region IComparable<Event> Members

        public int CompareTo(Event other)
        {
            return date.CompareTo(other.date);
        }

        #endregion

        public DateTime date
        {
            get { return _date; }
            set { _date = value; }
        }
        public DateTime endDate
        {
            get { return _endDate; }
            set { _endDate = value; }
        }
        public String title
        {
            get { return _title; }
            set { _title = value; }
        }
        public String description
        {
            get { return _description; }
            set { _description = value; }
        }
        public String author
        {
            get { return _author; }
            set { _author = value; }
        }
        public bool allDayEvent
        {
            get { return _allDayEvent; }
            set { _allDayEvent = value; }
        }
        public bool specialEvent
        {
            get { return _specialEvent; }
            set { _specialEvent = value; }
        }
    }
}
