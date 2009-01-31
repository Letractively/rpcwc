using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using rpcwc.web.email;
using System.Text;

/// <summary>
/// Summary description for prayer
/// </summary>
namespace rpcwc.web
{
    public partial class PrayerPage : Page
    {
        private EmailSender _emailSender;

        protected void Submit(object source, EventArgs eventArgs)
        {
            try
            {
                String fromEmail = Email.Text;
                String subject = BuildSubject(Status.SelectedValue, Subject.Text);
                StringBuilder stringBuilder = new StringBuilder();
                stringBuilder.AppendLine(subject);
                stringBuilder.AppendLine();
                stringBuilder.AppendLine(name.Text);
                stringBuilder.AppendLine(phone.Text);
                stringBuilder.AppendLine(DateTime.Now.ToShortDateString());
                stringBuilder.AppendLine();
                stringBuilder.AppendLine(prayer.Text);
                EmailSender.sendEmail(EmailSender.pastorEmail, fromEmail, subject, stringBuilder.ToString());
                Server.Transfer("prayerresponse.aspx");
            }
            catch (Exception)
            {
                ErrorLabel.Style.Add(HtmlTextWriterStyle.Color, "Red");
                ErrorLabel.Text = "An error occurred while attempting to send your prayer request." +
                    " Please email " + EmailSender.pastorEmail + " to send in your request.";
            }

        }

        private static string BuildSubject(String status, String subject)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append(status == "updatedRequest" ? "Updated" : "New");
            stringBuilder.Append(" Prayer Request: ");
            stringBuilder.Append(subject);

            return stringBuilder.ToString();
        }

        public EmailSender EmailSender
        {
            get { return _emailSender; }
            set { _emailSender = value; }
        }
    }
}
