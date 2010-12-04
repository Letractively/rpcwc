using System;
using System.Net.Mail;

/// <summary>
/// Summary description for EmailSender
/// </summary>
namespace rpcwc.web.email
{
    public class EmailSender
    {
        protected String _pastorEmail;
        protected String _officeEmail;
        protected string _toEmail;
        protected string _fromEmail;
        protected string _password;
        protected int _smtpClientPort;
        protected string _smtpClientHost;

        public void sendEmail(String ccEmail, String subject, String body)
        {
            MailMessage objEmail = new MailMessage();
            objEmail.To.Add(toEmail);
            if (ccEmail != null && ccEmail.Length > 0)
                objEmail.CC.Add(ccEmail);

            objEmail.From = new MailAddress(fromEmail);
            objEmail.Body = body;
            objEmail.Subject = subject;

            SmtpClient client = new SmtpClient();
            client.EnableSsl = true;
            client.Port = smtpClientPort;
            client.Host = smtpClientHost;
            client.Credentials = new System.Net.NetworkCredential(fromEmail, password);
            client.Send(objEmail);

        }

        public void sendEmail(String toEmail, String ccEmail, String subject, String body)
        {
            MailMessage objEmail = new MailMessage();
            objEmail.To.Add(toEmail);
            if (ccEmail != null && ccEmail.Length > 0)
                objEmail.CC.Add(ccEmail);

            objEmail.From = new MailAddress(fromEmail);
            objEmail.Body = body;
            objEmail.Subject = subject;

            SmtpClient client = new SmtpClient();
            client.EnableSsl = true;
            client.Port = smtpClientPort;
            client.Host = smtpClientHost;
            client.Credentials = new System.Net.NetworkCredential(fromEmail, password);
            client.Send(objEmail);

        }

        public void sendHtmlEmail(String toEmail, String ccEmail, String subject, String body)
        {
            MailMessage objEmail = new MailMessage();
            objEmail.To.Add(toEmail);
            if (ccEmail != null && ccEmail.Length > 0)
                objEmail.CC.Add(ccEmail);

            objEmail.From = new MailAddress(fromEmail);
            objEmail.Body = body;
            objEmail.Subject = subject;
            objEmail.IsBodyHtml = true;

            SmtpClient client = new SmtpClient();
            client.EnableSsl = true;
            client.Port = smtpClientPort;
            client.Host = smtpClientHost;
            client.Credentials = new System.Net.NetworkCredential(fromEmail, password);
            client.Send(objEmail);

        }

        public string toEmail
        {
            get { return _toEmail; }
            set { _toEmail = value; }
        }

        public string pastorEmail
        {
            get { return _pastorEmail; }
            set { _pastorEmail = value; }
        }

        public string officeEmail
        {
            get { return _officeEmail; }
            set { _officeEmail = value; }
        }

        public string fromEmail
        {
            get { return _fromEmail; }
            set { _fromEmail = value; }
        }

        public string password
        {
            get { return _password; }
            set { _password = value; }
        }

        public int smtpClientPort
        {
            get { return _smtpClientPort; }
            set { _smtpClientPort = value; }
        }

        public string smtpClientHost
        {
            get { return _smtpClientHost; }
            set { _smtpClientHost = value; }
        }
    }
}
