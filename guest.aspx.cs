using System;
using System.Text;
using System.Web.UI;
using rpcwc.bo;
using rpcwc.vo.Directory;
using rpcwc.web.email;

namespace rpcwc.web
{
    public partial class Guest : Page
    {
        protected EmailSender _emailSender;
        public GuestRegistrationManager GuestRegistrationManager { get; set; }

        public String Name { get; set; }

        public rpcwc.vo.Directory.GuestRegistration BuildFormObject()
        {
            GuestRegistration contact = new GuestRegistration();

            contact.Name = Request.Form["Name"];
            contact.Address = Request.Form["Address"];
            contact.phone = Request.Form["phone"];
            contact.email = Request.Form["email"];

            bool visited = false;
            bool college = false;
            Boolean.TryParse(Request.Form["visited"], out visited);
            contact.visited = visited;
            DateTime visitDate = DateTime.Now;
            if (Request.Form["visitDate"] != null && !"".Equals(Request.Form["visitDate"]))
            {
                DateTime.TryParse(Request.Form["visitDate"], out visitDate);
            }
            contact.visitDate = visitDate;
            Boolean.TryParse(Request.Form["college"], out college);
            contact.college = college;
            contact.howhear = Request.Form["howhear"];
            contact.contactme = "checked".Equals(Request.Form["contactme"]);
            contact.faith = "checked".Equals(Request.Form["faith"]);
            contact.churchhome = "checked".Equals(Request.Form["churchhome"]);
            contact.worship = "checked".Equals(Request.Form["worship"]);
            contact.teaching = "checked".Equals(Request.Form["teaching"]);
            contact.youth = "checked".Equals(Request.Form["youth"]);
            contact.service = "checked".Equals(Request.Form["service"]);
            contact.love = "checked".Equals(Request.Form["love"]);
            contact.evangelism = "checked".Equals(Request.Form["evangelism"]);
            contact.othertext = Request.Form["othertext"];
            contact.commentsprayer = Request.Form["commentsprayer"];

            return contact;
        }

        public void Submit(Object source, EventArgs eventArgs)
        {
            GuestRegistration contact = BuildFormObject();
            
            //try
            //{
                SaveContact(contact);
            //}
            //catch
            //{
                //SendEmail(contact);
            //}
            Response.Redirect("guestresponse.aspx");
        }

        private void SaveContact(GuestRegistration contact)
        {
            GuestRegistrationManager.SaveGuestRegistration(contact);
        }

        private void SendEmail(GuestRegistration contact)
        {
            String ccEmail = contact.email;
            StringBuilder body = new StringBuilder();
            body.Append("Name: ");
            body.Append(contact.Name);
            body.Append("\n");
            body.Append("Address: ");
            body.Append(contact.Address);
            body.Append("\n");
            body.Append("Telephone: ");
            body.Append(contact.phone);
            body.Append("\n");
            body.Append("Email address: ");
            body.Append(contact.email);
            body.Append("\n");
            body.Append("Have they visited the church: ");
            body.Append(contact.visited);
            body.Append("\n");
            body.Append("Visit date: ");
            body.Append(contact.visitDate);
            body.Append("\n");
            body.Append("College student: ");
            body.Append(contact.college);
            body.Append("\n");
            body.Append("How hear about the church: ");
            body.Append(contact.howhear);
            body.Append("\n");
            body.Append("Please contact me: ");
            body.Append(contact.contactme);
            body.Append("\n");
            body.Append("Know more about Christ: ");
            body.Append(contact.faith);
            body.Append("\n");
            body.Append("Looking for church home: ");
            body.Append(contact.churchhome);
            body.Append("\n");
            body.Append("Worship style: ");
            body.Append(contact.worship);
            body.Append("\n");
            body.Append("Biblical teaching: ");
            body.Append(contact.teaching);
            body.Append("\n");
            body.Append("Youth ministry: ");
            body.Append(contact.youth);
            body.Append("\n");
            body.Append("Opportunity to serve: ");
            body.Append(contact.service);
            body.Append("\n");
            body.Append("Warm and loving church: ");
            body.Append(contact.love);
            body.Append("\n");
            body.Append("Evangelistic: ");
            body.Append(contact.evangelism);
            body.Append("\n");
            body.Append("Other: ");
            body.Append(contact.othertext);
            body.Append("\n");
            body.Append("Comments and Prayer: ");
            body.Append(contact.commentsprayer);
            body.Append("\n");
            emailSender.sendEmail(null, "Reformed Presbyterian Church Guest Registration", body.ToString());
        }

        public EmailSender emailSender
        {
            get { return _emailSender; }
            set { _emailSender = value; }
        }
    }
}
