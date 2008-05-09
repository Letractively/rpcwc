using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

/// <summary>
/// Summary description for EventControl
/// </summary>
public class EventControl : WebControl
{
    public EventControl(Event calendarEvent)
        : base(HtmlTextWriterTag.Div)
	{
        if (!calendarEvent.allDayEvent)
        {
            WebControl timeHeader = new WebControl(HtmlTextWriterTag.H3);
            Label timeLabel = new Label();
            timeLabel.Text = calendarEvent.date.ToShortTimeString();
            timeHeader.Controls.Add(timeLabel);
            this.Controls.Add(timeHeader);

            this.Controls.Add(new WebControl(HtmlTextWriterTag.Br));
        }
        
        Label titleLabel = new Label();
        titleLabel.Text = calendarEvent.title;
        titleLabel.Style.Add(HtmlTextWriterStyle.FontWeight, "bold");
        this.Controls.Add(titleLabel);

        this.Controls.Add(new WebControl(HtmlTextWriterTag.Br));
        
        Label descriptionLabel = new Label();
        descriptionLabel.Text = calendarEvent.description;
        this.Controls.Add(descriptionLabel);

        this.Controls.Add(new WebControl(HtmlTextWriterTag.Br));
        this.Controls.Add(new WebControl(HtmlTextWriterTag.Br));
		//
		// TODO: Add constructor logic here
		//
	}
}
