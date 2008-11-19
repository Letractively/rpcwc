using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI.WebControls;
using System.Web.UI;
using rpcwc.vo.directory;

/// <summary>
/// Summary description for DirectoryHelper
/// </summary>
namespace rpcwc.web
{
    public class DirectoryHelper
    {
        public static WebControl makeCell(Directory directory)
        {
            WebControl td = new WebControl(HtmlTextWriterTag.Td);
            td.BorderWidth = Unit.Pixel(1);
            td.Style.Add(HtmlTextWriterStyle.Padding, "1em");
            td.Style.Add(HtmlTextWriterStyle.VerticalAlign, "top");

            Label address1 = new Label();
            address1.Text = directory.address1;
            Label address2 = new Label();
            address2.Text = directory.address2;
            Label citystatezip = new Label();
            if (directory.city != null && !directory.city.Equals(""))
                citystatezip.Text = directory.city + ", ";
            citystatezip.Text += directory.state + " " + directory.zip;

            td.Controls.Add(makeLastName(directory));
            td.Controls.Add(makeFirstNames(directory));
            td.Controls.Add(makeAddress(directory));
            td.Controls.Add(makeGeneralEmails(directory));
            td.Controls.Add(makePersonEmails(directory));
            td.Controls.Add(makeGeneralPhones(directory));
            td.Controls.Add(makePersonPhones(directory));

            return td;
        }

        private static Control makeGeneralEmails(Directory directory)
        {
            WebControl emailSection = new WebControl(HtmlTextWriterTag.Div);

            if (directory.emails == null)
                return emailSection;

            foreach (Email email in directory.emails)
            {
                emailSection.Controls.Add(makeGeneralEmail(email));
            }

            return emailSection;
        }

        private static Control makePersonEmails(Directory directory)
        {
            WebControl emailSection = new WebControl(HtmlTextWriterTag.Div);

            if (directory.persons == null || directory.persons.Count == 0)
                return emailSection;

            foreach (Person person in directory.persons)
            {
                foreach (Email email in person.emails)
                {
                    emailSection.Controls.Add(makePersonEmail(email, person.firstName));
                }
            }

            return emailSection;
        }

        private static Control makeGeneralPhones(Directory directory)
        {
            WebControl phoneSection = new WebControl(HtmlTextWriterTag.Div);

            if (directory.phones == null)
                return phoneSection;

            foreach (Phone phone in directory.phones)
            {
                phoneSection.Controls.Add(makeGeneralPhone(phone));
            }

            return phoneSection;
        }

        private static Control makePersonPhones(Directory directory)
        {
            WebControl phoneSection = new WebControl(HtmlTextWriterTag.Div);

            if (directory.persons == null || directory.persons.Count == 0)
                return phoneSection;

            foreach (Person person in directory.persons)
            {
                foreach (Phone phone in person.phones)
                {
                    phoneSection.Controls.Add(makePersonPhone(phone, person.firstName));
                }
            }

            return phoneSection;
        }

        private static WebControl makePersonEmail(Email email, String personFirstName)
        {
            WebControl emailDiv = new WebControl(HtmlTextWriterTag.Span);
            Label emailType = new Label();
            emailType.Font.Italic = true;
            if (email.emailType != null && !email.emailType.Equals(""))
                emailType.Text = personFirstName + "—" + email.emailType + ": ";
            else
                emailType.Text = personFirstName + ": ";
            emailDiv.Controls.Add(emailType);
            emailDiv.Controls.Add(makeEmail(email));
            emailDiv.Controls.Add(new WebControl(HtmlTextWriterTag.Br));

            return emailDiv;
        }

        private static WebControl makeGeneralEmail(Email email)
        {
            WebControl emailDiv = new WebControl(HtmlTextWriterTag.Span);
            if (email.emailType != null && !email.emailType.Equals(""))
            {
                Label emailType = new Label();
                emailType.Font.Italic = true;
                emailType.Text = "(" + email.emailType + ": ";
                emailDiv.Controls.Add(emailType);
            }
            emailDiv.Controls.Add(makeEmail(email));
            emailDiv.Controls.Add(new WebControl(HtmlTextWriterTag.Br));

            return emailDiv;
        }

        private static Control makeEmail(Email email)
        {
            HyperLink address = new HyperLink();
            address.NavigateUrl = "mailto:" + email.emailAddress;
            address.Text = email.emailAddress;
            return address;
        }

        private static WebControl makePersonPhone(Phone phone, String personFirstName)
        {
            WebControl phoneDiv = new WebControl(HtmlTextWriterTag.Span);
            Label phoneType = new Label();
            phoneType.Font.Italic = true;
            if (phone.phoneType != null && !phone.phoneType.Equals(""))
                phoneType.Text = personFirstName + "—" + phone.phoneType + ": ";
            else
                phoneType.Text = personFirstName + ": ";
            phoneDiv.Controls.Add(phoneType);
            Label phoneNumber = new Label();
            phoneNumber.Text = phone.phoneNumber;
            phoneDiv.Controls.Add(phoneNumber);
            phoneDiv.Controls.Add(new WebControl(HtmlTextWriterTag.Br));

            return phoneDiv;
        }

        private static WebControl makeGeneralPhone(Phone phone)
        {
            WebControl phoneDiv = new WebControl(HtmlTextWriterTag.Span);
            if (phone.phoneType != null && !phone.phoneType.Equals(""))
            {
                Label phoneType = new Label();
                phoneType.Font.Italic = true;
                phoneType.Text = phone.phoneType + ": ";
                phoneDiv.Controls.Add(phoneType);
            }
            Label phoneNumber = new Label();
            phoneNumber.Text = phone.phoneNumber;
            phoneDiv.Controls.Add(phoneNumber);
            phoneDiv.Controls.Add(new WebControl(HtmlTextWriterTag.Br));

            return phoneDiv;
        }

        private static Control makeAddress(Directory directory)
        {
            WebControl address = new WebControl(HtmlTextWriterTag.Div);
            if (directory.address1 == null || directory.address1.Equals(""))
                return address;

            Label address1 = new Label();
            address1.Text = directory.address1;
            Label address2 = new Label();
            address2.Text = directory.address2;
            Label citystatezip = new Label();
            if (directory.city != null && !directory.city.Equals(""))
                citystatezip.Text = directory.city + ", ";

            citystatezip.Text += directory.state + " " + directory.zip;

            address.Controls.Add(address1);
            address.Controls.Add(new WebControl(HtmlTextWriterTag.Br));
            if (directory.address2 != null)
            {
                address.Controls.Add(address2);
                address.Controls.Add(new WebControl(HtmlTextWriterTag.Br));
            }
            address.Controls.Add(citystatezip);

            return address;
        }

        private static Control makeLastName(Directory directory)
        {
            WebControl lastNameSpan = new WebControl(HtmlTextWriterTag.Span);
            Label lastName = new Label();
            lastName.Text = directory.lastName;
            lastName.Font.Bold = true;

            lastNameSpan.Controls.Add(lastName);
            lastNameSpan.Controls.Add(new WebControl(HtmlTextWriterTag.Br));

            return lastNameSpan;
        }

        private static Control makeFirstNamesx(Directory directory)
        {
            WebControl firstNameSpan = new WebControl(HtmlTextWriterTag.Span);
            if (directory.persons == null || directory.persons.Count == 0)
                return firstNameSpan;

            Label firstNames = new Label();
            /*
            firstNames.Text = makeFirstName(directory, 0);

            if (directory.persons.Count > 1)
                firstNames.Text += ",";

            for (int i = 1; i < directory.persons.Count - 1; i++)
            {
                firstNames.Text += " " + makeFirstName(directory, i) + ",";
            }

            if (directory.persons.Count > 1)
                firstNames.Text += " & " + makeFirstName(directory, directory.persons.Count - 1);

            firstNameSpan.Controls.Add(firstNames);
            firstNameSpan.Controls.Add(new WebControl(HtmlTextWriterTag.Br));
            */
            return firstNameSpan;
        }

        private static Control makeFirstNames(Directory directory)
        {
            WebControl firstNameSpan = new WebControl(HtmlTextWriterTag.Span);
            if (directory.persons == null || directory.persons.Count == 0)
                return firstNameSpan;

            /*Label comma = new Label();
            Label space = new Label();
            Label ampersand = new Label();

            comma.Text = ",";
            ampersand.Text = " & ";*/



            Label firstNames = new Label();

            firstNames.Controls.Add(makeFirstName(directory, 0));

            if (directory.persons.Count > 1)
                firstNames.Controls.Add(getComma());

            for (int i = 1; i < directory.persons.Count - 1; i++)
            {
                firstNames.Controls.Add(getSpace());
                firstNames.Controls.Add(makeFirstName(directory, i));
                firstNames.Controls.Add(getComma());
            }

            if (directory.persons.Count > 1)
            {
                firstNames.Controls.Add(getAmpersand());
                firstNames.Controls.Add(makeFirstName(directory, directory.persons.Count - 1));
            }

            firstNameSpan.Controls.Add(firstNames);
            firstNameSpan.Controls.Add(new WebControl(HtmlTextWriterTag.Br));

            return firstNameSpan;
        }

        private static Control getAmpersand()
        {
            Label ampersand = new Label();
            ampersand.Text = " & ";
            return ampersand;
        }

        private static Control getComma()
        {
            Label comma = new Label();
            comma.Text = ",";
            return comma;
        }

        private static Control getSpace()
        {
            Label space = new Label();
            space.Text = " ";
            return space;
        }

        private static Control makeFirstName(Directory directory, int p)
        {
            Label personLabel = new Label();
            Person person = (Person)directory.persons[p];
            personLabel.Font.Italic = person.isMember;
            personLabel.Text = person.firstName;// +(person.isMember ? "*" : "");
            return personLabel;
        }

        private static string makeFirstNamex(Directory directory, int p)
        {
            Person person = (Person)directory.persons[p];
            return person.firstName + (person.isMember ? "*" : "");
        }
    }
}