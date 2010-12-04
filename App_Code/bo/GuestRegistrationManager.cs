using rpcwc.vo.Directory;
using rpcwc.dao;
using System.Collections.Generic;
using System;
using System.Runtime.Remoting.Messaging;
using rpcwc.web.email;
using System.Text;
using System.Collections;
using rpcwc.dao;

namespace rpcwc.bo
{
    public class GuestRegistrationManager
    {
        public IGuestRegistrationDAO GuestRegistrationDAO { get; set; }
        public EmailSender EmailSender { get; set; }
        private GetReportDelegate _getReportDelegate;

        private GetReportDelegate getReportDelegate
        {
            get
            {
                if (_getReportDelegate == null)
                {
                    _getReportDelegate = GetReport;
                }
                return _getReportDelegate;
            }
        }

        public void SaveGuestRegistration(GuestRegistration guestRegistration)
        {
            GuestRegistrationDAO.SaveGuestRegistration(guestRegistration);
        }

        public void GenerateReport(string reportName)
        {
            IAsyncResult result = getReportDelegate.BeginInvoke(reportName, new System.AsyncCallback(SendReport), null);
        }

        delegate void SendReportDelegate(IAsyncResult result);

        public void SendReport(IAsyncResult result)
        {
            IList<GuestRegistration> guestRegistrations = getReportDelegate.EndInvoke(result);
            if (guestRegistrations.Count == 0)
            {
                return;
            }

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<table border=\"1\">");

            sb.AppendLine("<tr>");
            sb.AppendLine("<td>Name</td>");
            sb.AppendLine("<td>Address</td>");
            sb.AppendLine("<td>phone</td>");
            sb.AppendLine("<td>email</td>");
            sb.AppendLine("<td>visited</td>");
            sb.AppendLine("<td>visitDate</td>");
            sb.AppendLine("<td>college</td>");
            sb.AppendLine("<td>newtoarea</td>");
            sb.AppendLine("<td>howhear</td>");
            sb.AppendLine("<td>contactme</td>");
            sb.AppendLine("<td>faith</td>");
            sb.AppendLine("<td>churchhome</td>");
            sb.AppendLine("<td>worship</td>");
            sb.AppendLine("<td>teaching</td>");
            sb.AppendLine("<td>youth</td>");
            sb.AppendLine("<td>service</td>");
            sb.AppendLine("<td>love</td>");
            sb.AppendLine("<td>evangelism</td>");
            sb.AppendLine("<td>othertext</td>");
            sb.AppendLine("<td>commentsprayer</td>");
            sb.AppendLine("<td>createDate</td>");
            sb.AppendLine("<td>createUser</td>");
            sb.AppendLine("<td>lastUpdateDate</td>");
            sb.AppendLine("<td>lastUpdateUser</td>");
            sb.AppendLine("</tr>");

            foreach (GuestRegistration guestRegistration in guestRegistrations)
            {
                sb.AppendLine("<tr>");
                sb.Append("<td>").Append(guestRegistration.Name).AppendLine("</td>");
                sb.Append("<td>").Append(guestRegistration.Address).AppendLine("</td>");
                sb.Append("<td>").Append(guestRegistration.phone).AppendLine("</td>");
                sb.Append("<td>").Append(guestRegistration.email).AppendLine("</td>");
                sb.Append("<td>").Append(guestRegistration.visited ? "x" : "").AppendLine("</td>");
                sb.Append("<td>").Append(guestRegistration.visitDate).AppendLine("</td>");
                sb.Append("<td>").Append(guestRegistration.college ? "x" : "").AppendLine("</td>");
                sb.Append("<td>").Append(guestRegistration.newtoarea ? "x" : "").AppendLine("</td>");
                sb.Append("<td>").Append(guestRegistration.howhear).AppendLine("</td>");
                sb.Append("<td>").Append(guestRegistration.contactme ? "x" : "").AppendLine("</td>");
                sb.Append("<td>").Append(guestRegistration.faith ? "x" : "").AppendLine("</td>");
                sb.Append("<td>").Append(guestRegistration.churchhome ? "x" : "").AppendLine("</td>");
                sb.Append("<td>").Append(guestRegistration.worship ? "x" : "").AppendLine("</td>");
                sb.Append("<td>").Append(guestRegistration.teaching ? "x" : "").AppendLine("</td>");
                sb.Append("<td>").Append(guestRegistration.youth ? "x" : "").AppendLine("</td>");
                sb.Append("<td>").Append(guestRegistration.service ? "x" : "").AppendLine("</td>");
                sb.Append("<td>").Append(guestRegistration.love ? "x" : "").AppendLine("</td>");
                sb.Append("<td>").Append(guestRegistration.evangelism ? "x" : "").AppendLine("</td>"); 
                sb.Append("<td>").Append(guestRegistration.othertext).AppendLine("</td>");
                sb.Append("<td>").Append(guestRegistration.commentsprayer).AppendLine("</td>");
                sb.Append("<td>").Append(guestRegistration.createDate).AppendLine("</td>");
                sb.Append("<td>").Append(guestRegistration.createUser).AppendLine("</td>");
                sb.Append("<td>").Append(guestRegistration.lastUpdateDate).AppendLine("</td>");
                sb.Append("<td>").Append(guestRegistration.lastUpdateUser).AppendLine("</td>");
                sb.AppendLine("</tr>");
            }
            sb.AppendLine("</table>");
            EmailSender.sendHtmlEmail("greetingministry@rpcwc.org", null, "guest reg report", sb.ToString());

            foreach (GuestRegistration guestRegistration in guestRegistrations)
            {
                GuestRegistrationDAO.TagGuest(guestRegistration, DaoConstants.GuestTags.InitialReportGenerated);
            }
        }

        delegate IList<GuestRegistration> GetReportDelegate(string reportName);

        public IList<GuestRegistration> GetReport(string reportName)
        {
            return GuestRegistrationDAO.GetReport(reportName);
        }
    }
}