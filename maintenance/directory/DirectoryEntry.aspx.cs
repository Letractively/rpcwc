using System;
using System.Collections.Generic;
using rpcwc.bo;
using rpcwc.vo.directory;
using rpcwc.bo.cache;
using System.Web.UI.WebControls;
using System.Web.UI;

namespace rpcwc.web.Maintenance
{
    public partial class maintenance_directory_DirectoryEntry : System.Web.UI.Page
    {
        private DirectoryCache _directoryCache;

        protected void Page_Load(object sender, EventArgs e)
        {
            String directoryId = Request.Params["id"];
            Directory directoryEntry = DirectoryCache.FindDirectoryEntryPk(directoryId);
            LastName.Text = directoryEntry.lastName;
            Address1.Text = directoryEntry.address1;
            Address2.Text = directoryEntry.address2;
            City.Text = directoryEntry.city;
            State.Text = directoryEntry.state;
            Zip.Text = directoryEntry.zip;

            foreach (Person person in directoryEntry.persons)
            {
                TableRow tableRow = new TableRow();
                TableCell tableCell = new TableCell();
                tableCell.Controls.Add(new LiteralControl(person.firstName + " "));
                HyperLink hyperLink = new HyperLink();
                hyperLink.Text = "(edit)";
                hyperLink.NavigateUrl = String.Format("personEntry.aspx?directoryEntryId={0}&id={1}", directoryId, person.id);
                tableCell.Controls.Add(hyperLink);
                tableRow.Controls.Add(tableCell);
                PersonTable.Controls.Add(tableRow);
            }

            TableRow createPersonTableRow = new TableRow();
            TableCell createPersonTableCell = new TableCell();
            HyperLink createPersonHyperLink = new HyperLink();
            createPersonHyperLink.Text = "Add";
            createPersonHyperLink.NavigateUrl = String.Format("createPersonEntry.aspx?directoryId={0}", directoryEntry.id);
            createPersonTableCell.Controls.Add(createPersonHyperLink);
            createPersonTableRow.Controls.Add(createPersonTableCell);
            PersonTable.Controls.Add(createPersonTableRow);

            foreach (Phone phone in directoryEntry.phones)
            {
                TableRow tableRow = new TableRow();
                TableCell tableCell = new TableCell();
                tableCell.Controls.Add(new LiteralControl(String.Format("{0} ", phone.phoneNumber)));
                if (phone.phoneType != null && !phone.phoneType.Equals(""))
                    tableCell.Controls.Add(new LiteralControl(String.Format("({0}) ", phone.phoneType)));
                
                HyperLink hyperLink = new HyperLink();
                hyperLink.Text = "(edit)";
                hyperLink.NavigateUrl = String.Format("phoneEntry.aspx?directoryEntryId={0}&id={1}", directoryId, phone.id);
                tableCell.Controls.Add(hyperLink);
                tableRow.Controls.Add(tableCell);
                PhoneTable.Controls.Add(tableRow);
            }

            TableRow createPhoneTableRow = new TableRow();
            TableCell createPhoneTableCell = new TableCell();
            HyperLink createPhoneHyperLink = new HyperLink();
            createPhoneHyperLink.Text = "Add";
            createPhoneHyperLink.NavigateUrl = String.Format("createPhoneEntry.aspx?directoryId={0}", directoryEntry.id);
            createPhoneTableCell.Controls.Add(createPhoneHyperLink);
            createPhoneTableRow.Controls.Add(createPhoneTableCell);
            PhoneTable.Controls.Add(createPhoneTableRow);

            foreach (Email email in directoryEntry.emails)
            {
                TableRow tableRow = new TableRow();
                TableCell tableCell = new TableCell();
                tableCell.Controls.Add(new LiteralControl(String.Format("{0} ", email.emailAddress)));
                if (email.emailType != null && !email.emailType.Equals(""))
                    tableCell.Controls.Add(new LiteralControl(String.Format("({0}) ", email.emailType)));
                HyperLink hyperLink = new HyperLink();
                hyperLink.Text = "(edit)";
                hyperLink.NavigateUrl = String.Format("emailEntry.aspx?directoryEntryId={0}&id={1}", directoryId, email.id);
                tableCell.Controls.Add(hyperLink);
                tableRow.Controls.Add(tableCell);
                EmailTable.Controls.Add(tableRow);
            }

            TableRow createEmailTableRow = new TableRow();
            TableCell createEmailTableCell = new TableCell();
            HyperLink createEmailHyperLink = new HyperLink();
            createEmailHyperLink.Text = "Add";
            createEmailHyperLink.NavigateUrl = String.Format("createEmailEntry.aspx?directoryId={0}", directoryEntry.id);
            createEmailTableCell.Controls.Add(createEmailHyperLink);
            createEmailTableRow.Controls.Add(createEmailTableCell);
            EmailTable.Controls.Add(createEmailTableRow);
        }

        public DirectoryCache DirectoryCache
        {
            get { return _directoryCache; }
            set { _directoryCache = value; }
        }
    }
}
