using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using rpcwc.vo;
using rpcwc.web;
using System.Collections;

/// <summary>
/// Summary description for CalendarUtil
/// </summary>
public class CalendarUtil
{
    public static Control getDateHeader(DateTime date)
    {
        WebControl h4 = new WebControl(HtmlTextWriterTag.H4);
        Label label = new Label();
        label.Text = date.ToString("MMMM d, yyyy");
        h4.Controls.Add(label);

        return h4;
    }

    public static EventControl createEventControl(Event calendarEvent)
    {
        EventControl eventControl = new EventControl();

        if (!calendarEvent.allDayEvent)
        {
            WebControl timeHeader = new WebControl(HtmlTextWriterTag.H3);
            timeHeader.Attributes.Add("style", "border-bottom:solid 1px #ccc");
            Label timeLabel = new Label();
            timeLabel.Text = calendarEvent.date.ToShortTimeString();
            if (calendarEvent.endDate != null &&
                calendarEvent.endDate.CompareTo(calendarEvent.date) > 0 &&
                calendarEvent.endDate.Date.CompareTo(calendarEvent.date.Date) == 0)
                timeLabel.Text = calendarEvent.date.ToShortTimeString() + " &ndash; " + calendarEvent.endDate.ToShortTimeString();
            timeHeader.Controls.Add(timeLabel);
            eventControl.Controls.Add(timeHeader);

            eventControl.Controls.Add(new WebControl(HtmlTextWriterTag.Br));
        }

        Label titleLabel = new Label();
        titleLabel.Text = calendarEvent.title;
        titleLabel.Style.Add(HtmlTextWriterStyle.FontWeight, "bold");
        eventControl.Controls.Add(titleLabel);

        if (calendarEvent.description != null)
        {
            eventControl.Controls.Add(new WebControl(HtmlTextWriterTag.Br));
            Label descriptionLabel = new Label();
            descriptionLabel.Text = calendarEvent.description;
            eventControl.Controls.Add(descriptionLabel);
        }

        eventControl.Controls.Add(new WebControl(HtmlTextWriterTag.Br));
        eventControl.Controls.Add(new WebControl(HtmlTextWriterTag.Br));

        return eventControl;
    }

    public static EventControl createEventControlMaintenance(Event calendarEvent, CommandEventHandler commandEventHandler)
    {
        EventControl eventControl = new EventControl();

        Panel panel = new Panel();

        if (!calendarEvent.allDayEvent)
        {
            WebControl timeHeader = new WebControl(HtmlTextWriterTag.H3);
            Label timeLabel = new Label();
            timeLabel.Text = calendarEvent.date.ToShortTimeString();
            timeHeader.Controls.Add(timeLabel);
            timeHeader.Style.Add("float", "left");
            panel.Controls.Add(timeHeader);
        }

        Label editLabel = new Label();
        LinkButton editButton = new LinkButton();
        editButton.Command += commandEventHandler;
        editButton.CommandArgument = calendarEvent.id.ToString();
        //editButton.ID = "editButton";
        editButton.Text = "[edit]";
        editLabel.Controls.Add(editButton);
        editLabel.Style.Add("float", "right");
        panel.Controls.Add(editLabel);

        eventControl.Controls.Add(panel);
        WebControl lineBreak = new WebControl(HtmlTextWriterTag.Br);
        lineBreak.Attributes.Add("clear", "all");
        eventControl.Controls.Add(lineBreak);

        Panel panel2 = new Panel();

        Label titleLabel = new Label();
        titleLabel.Text = calendarEvent.title;
        titleLabel.Style.Add(HtmlTextWriterStyle.FontWeight, "bold");
        panel2.Controls.Add(titleLabel);

        if (calendarEvent.description != null)
        {
            panel2.Controls.Add(new WebControl(HtmlTextWriterTag.Br));
            Label descriptionLabel = new Label();
            descriptionLabel.Text = calendarEvent.description;
            panel2.Controls.Add(descriptionLabel);
        }

        eventControl.Controls.Add(panel2);

        eventControl.Controls.Add(new WebControl(HtmlTextWriterTag.Br));
        eventControl.Controls.Add(new WebControl(HtmlTextWriterTag.Br));

        return eventControl;
    }

    public class EventByDateMapKeyCreator : CollectionUtils.MapKeyCreator<DateTime, Event>
    {
        public DateTime createKey(Event obj)
        {
            return obj.date.Date;
        }
    }

    public class DateComparer : IComparer
    {

        #region IComparer Members

        public int Compare(object x, object y)
        {
            DateTime dateTime1 = (DateTime) x;
            DateTime dateTime2 = (DateTime) y;
            return (dateTime1).CompareTo(dateTime2);
        }

        #endregion
    }
}
