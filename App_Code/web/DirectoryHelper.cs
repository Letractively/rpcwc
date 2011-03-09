using System;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using rpcwc.vo.directory;
using Google.GData.Photos;

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
            //td.BorderWidth = Unit.Pixel(1);
            td.Style.Add(HtmlTextWriterStyle.Padding, "1em");
            td.Style.Add(HtmlTextWriterStyle.VerticalAlign, "top");
            td.CssClass += "vcard";

            Panel textPanel = new Panel();
            textPanel.Style.Add("float", "left");
            Panel namePanel = new Panel();
            namePanel.CssClass += "n ";
            namePanel.CssClass += "fn ";
            namePanel.Controls.Add(makeLastName(directory));
            namePanel.Controls.Add(makeFirstNames(directory));
            textPanel.Controls.Add(namePanel);
            textPanel.Controls.Add(makeAddress(directory));
            textPanel.Controls.Add(makeGeneralEmails(directory));
            textPanel.Controls.Add(makePersonEmails(directory));
            textPanel.Controls.Add(makeGeneralPhones(directory));
            textPanel.Controls.Add(makePersonPhones(directory));
            td.Controls.Add(textPanel);
            if (directory.photo != null && directory.photo.Id != null && directory.photo.PicasaEntry != null)
            {
                Panel picturePanel = new Panel();
                picturePanel.Style.Add("float", "right");
                picturePanel.Controls.Add(makeGeneralPhoto(directory));
                td.Controls.Add(picturePanel);
            }

            return td;
        }

        public static Control makeGeneralPhoto(Directory directory)
        {
            Panel panel = new Panel();

            WebControl link = new WebControl(HtmlTextWriterTag.A);
            link.Attributes.Add("href", (String) directory.photo.PicasaEntry.Media.Thumbnails[1].Attributes["url"]/*(String) entry.Media.Content.Attributes["url"]*/);
            link.CssClass = "thickbox";

            Image image = new Image();
            image.CssClass += "photo";
            image.AlternateText = directory.photo.Title;

            image.ImageUrl = (String)directory.photo.PicasaEntry.Media.Thumbnails[0].Attributes["url"].ToString();
            image.Height = int.Parse((String)directory.photo.PicasaEntry.Media.Thumbnails[0].Attributes["height"]);
            image.Width = int.Parse((String)directory.photo.PicasaEntry.Media.Thumbnails[0].Attributes["width"]);

            link.Controls.Add(image);
            panel.Controls.Add(link);
            panel.Style.Add(HtmlTextWriterStyle.TextAlign, "center");

            return panel;
        }

        public static Control makeGeneralEmails(Directory directory)
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

        public static Control makePersonEmails(Directory directory)
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

        public static Control makeGeneralPhones(Directory directory)
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

        public static Control makePersonPhones(Directory directory)
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
            Panel emailDiv = new Panel();
            emailDiv.CssClass += "email";
            Label emailType = new Label();
            //emailType.CssClass += "type";
            emailType.Font.Italic = true;
            if (email.emailType != null && !email.emailType.Equals(""))
            {

                HtmlControl emailTypeAbbr = new HtmlGenericControl("abbr");
                emailTypeAbbr.Attributes.Add("class", "type");
                emailTypeAbbr.Attributes.Add("title", email.emailType.ToLower());
                emailTypeAbbr.Controls.Add(new LiteralControl(email.emailType));

                emailType.Controls.Add(new LiteralControl(personFirstName));
                emailType.Controls.Add(new LiteralControl("—"));
                emailType.Controls.Add(emailTypeAbbr);
                emailType.Controls.Add(new LiteralControl(": "));
            }
            else
                emailType.Text = personFirstName + ": ";
            emailDiv.Controls.Add(emailType);
            emailDiv.Controls.Add(makeEmail(email));
            //emailDiv.Controls.Add(new WebControl(HtmlTextWriterTag.Br));

            return emailDiv;
        }

        private static WebControl makeGeneralEmail(Email email)
        {
            Panel emailDiv = new Panel();
            emailDiv.CssClass += "email";
            if (email.emailType != null && !email.emailType.Equals(""))
            {
                Label emailType = new Label();
                emailType.CssClass += "type";
                emailType.Font.Italic = true;
                emailType.Controls.Add(new LiteralControl("("));

                HtmlControl emailTypeAbbr = new HtmlGenericControl("abbr");
                emailTypeAbbr.Attributes.Add("class", "type");
                emailTypeAbbr.Attributes.Add("title", email.emailType.ToLower());
                emailTypeAbbr.Controls.Add(new LiteralControl(email.emailType));

                emailType.Controls.Add(new LiteralControl(")"));
                emailDiv.Controls.Add(emailType);
            }
            emailDiv.Controls.Add(makeEmail(email));
            //emailDiv.Controls.Add(new WebControl(HtmlTextWriterTag.Br));

            return emailDiv;
        }

        private static Control makeEmail(Email email)
        {
            HyperLink address = new HyperLink();
            address.CssClass += "value";
            address.NavigateUrl = "mailto:" + email.emailAddress;
            address.Text = email.emailAddress;
            return address;
        }

        private static WebControl makePersonPhone(Phone phone, String personFirstName)
        {
            Panel phoneDiv = new Panel();
            phoneDiv.CssClass += "tel";
            Label phoneType = new Label();
            phoneType.Font.Italic = true;
            if (phone.phoneType != null && !phone.phoneType.Equals(""))
            {
                phoneType.Controls.Add(new LiteralControl(personFirstName + "—"));

                HtmlControl phoneTypeAbbr = new HtmlGenericControl("abbr");
                phoneTypeAbbr.Attributes.Add("class","type");
                phoneTypeAbbr.Attributes.Add("title",phone.phoneType.ToLower());
                LiteralControl phoneTypeText = new LiteralControl(phone.phoneType);
                phoneTypeAbbr.Controls.Add(phoneTypeText);
                phoneType.Controls.Add(phoneTypeAbbr);

                phoneType.Controls.Add(new LiteralControl(": "));
            }
            else
            {
                phoneType.Text = personFirstName + ": ";
            }
            phoneDiv.Controls.Add(phoneType);
            Label phoneNumber = new Label();
            phoneNumber.CssClass += "value";
            phoneNumber.Text = phone.phoneNumber;
            phoneDiv.Controls.Add(phoneNumber);
            //phoneDiv.Controls.Add(new WebControl(HtmlTextWriterTag.Br));

            return phoneDiv;
        }

        private static WebControl makeGeneralPhone(Phone phone)
        {
            Panel phoneDiv = new Panel();
            phoneDiv.CssClass += "tel";
            if (phone.phoneType != null && !phone.phoneType.Equals(""))
            {
                Label phoneType = new Label();

                HtmlControl phoneTypeAbbr = new HtmlGenericControl("abbr");
                phoneTypeAbbr.Attributes.Add("class", "type");
                phoneTypeAbbr.Attributes.Add("title", phone.phoneType.ToLower());
                LiteralControl phoneTypeText = new LiteralControl(phone.phoneType);
                phoneTypeAbbr.Controls.Add(phoneTypeText);
                phoneType.Controls.Add(phoneTypeAbbr);
                phoneType.Controls.Add(new LiteralControl(": "));
                phoneType.Font.Italic = true;
                phoneDiv.Controls.Add(phoneType);
            }
            Label phoneNumber = new Label();
            phoneNumber.CssClass += "value";
            phoneNumber.Text = phone.phoneNumber;
            phoneDiv.Controls.Add(phoneNumber);
            //phoneDiv.Controls.Add(new WebControl(HtmlTextWriterTag.Br));

            return phoneDiv;
        }

        public static Control makeAddress(Directory directory)
        {
            Panel address = new Panel();
            address.CssClass += "adr";
            if (directory.address1 == null || directory.address1.Equals(""))
                return address;

            Panel address1 = new Panel();
            address1.CssClass += "street-address";
            Label address1Txt = new Label();
            address1Txt.Text = directory.address1;
            address1.Controls.Add(address1Txt);
            address.Controls.Add(address1);


            Panel address2 = new Panel();
            address2.CssClass += "extended-address";
            Label address2Txt = new Label();
            address2Txt.Text = directory.address2;
            address2.Controls.Add(address2Txt);
            if (directory.address2 != null)
            {
                address.Controls.Add(address2);
                //address.Controls.Add(new WebControl(HtmlTextWriterTag.Br));
            }

            Panel citystatezip = new Panel();
            if (directory.city != null && !directory.city.Equals(""))
            {
                Label cityTxt = new Label();
                cityTxt.CssClass += "locality";
                cityTxt.Text = directory.city;
                citystatezip.Controls.Add(cityTxt);
                citystatezip.Controls.Add(new LiteralControl(", "));
            }

            Label stateTxt = new Label();
            stateTxt.CssClass += "region";
            stateTxt.Text = directory.state;
            citystatezip.Controls.Add(stateTxt);
            citystatezip.Controls.Add(new LiteralControl(", "));

            Label zipTxt = new Label();
            zipTxt.CssClass += "postal-code";
            zipTxt.Text = directory.zip;
            citystatezip.Controls.Add(zipTxt);

            address.Controls.Add(citystatezip);

            return address;
        }

        public static Control makeLastName(Directory directory)
        {
            WebControl lastNameSpan = new Panel();
            lastNameSpan.CssClass += "family-name";
            Label lastName = new Label();
            lastName.Text = directory.lastName;
            lastName.Font.Bold = true;

            lastNameSpan.Controls.Add(lastName);
            //lastNameSpan.Controls.Add(new WebControl(HtmlTextWriterTag.Br));

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

        public static Control makeFirstNames(Directory directory)
        {
            WebControl firstNameSpan = new Panel();
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
            //firstNameSpan.Controls.Add(new WebControl(HtmlTextWriterTag.Br));

            return firstNameSpan;
        }

        private static Control getAmpersand()
        {
            Label ampersand = new Label();
            ampersand.Text = " &amp; ";
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