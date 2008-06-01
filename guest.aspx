<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    Title="Reformed Presbyterian Church &mdash; Guest Registration" %>

<%@ Import Namespace="System.Net.Mail" %>

<script type="text/C#" runat="server">
    public void Submit(Object source, EventArgs eventArgs)
    {
        MailMessage objEmail = new MailMessage();
        objEmail.To.Add(new MailAddress("raymond.rishty@gmail.com"));
        try
        {
            objEmail.From = new MailAddress( Request.Form["Email"]);
        }
        catch { }
        /*objEmail.Cc = txtCc.Text;*/
        objEmail.Subject = "Guest Registration";
        StringBuilder body = new StringBuilder();
        body.Append("Name: ");
        body.Append(Request.Form["Name"]);
        body.Append("\n");
        body.Append("Address: ");
        body.Append(Request.Form["Address"]);
        body.Append("\n");
        body.Append("Telephone: ");
        body.Append(Request.Form["phone"]);
        body.Append("\n");
        body.Append("Email address: ");
        body.Append(Request.Form["email"]);
        body.Append("\n");
        body.Append("Have they visited the church: ");
        body.Append(Request.Form["visited"]);
        body.Append("\n");
        body.Append("College student: ");
        body.Append(Request.Form["college"]);
        body.Append("\n");
        body.Append("How hear about the church: ");
        body.Append(Request.Form["howhear"]);
        body.Append("\n");
        body.Append("Please contact me: ");
        body.Append(Request.Form["contactme"]);
        body.Append("\n");
        body.Append("Know more about Christ: ");
        body.Append(Request.Form["faith"]);
        body.Append("\n");
        body.Append("Looking for church home: ");
        body.Append(Request.Form["churchhome"]);
        body.Append("\n");
        body.Append("Worship style: ");
        body.Append(Request.Form["worship"]);
        body.Append("\n");
        body.Append("Biblical teaching: ");
        body.Append(Request.Form["teaching"]);
        body.Append("\n");
        body.Append("Youth ministry: ");
        body.Append(Request.Form["youth"]);
        body.Append("\n");
        body.Append("Opportunity to serve: ");
        body.Append(Request.Form["service"]);
        body.Append("\n");
        body.Append("Warm and loving church: ");
        body.Append(Request.Form["love"]);
        body.Append("\n");
        body.Append("Interested in evangelism: ");
        body.Append(Request.Form["evangelism"]);
        body.Append("\n");
        body.Append("Other: ");
        body.Append(Request.Form["othertext"]);
        body.Append("\n");
        body.Append("Comments and Prayer: ");
        body.Append(Request.Form["commentprayer"]);
        body.Append("\n");
        objEmail.Body = body.ToString();
        objEmail.Subject = "Reformed Presbyterian Church Guest Registration";
        

        //send form to 

        //$recipient = "rpcwc@ccil.org\n"; 
        //$subject = "Reformed Presbyterian Church Guest Registration"; 
        //$mailheaders = "From: $_POST[email]\n";   

        //txtComments.Text;
        //objEmail.Priority = MailPriority.High;

        try
        {
            Response.Write(objEmail.Body);
            SmtpClient client = new SmtpClient();
            client.Send(objEmail);
            //SmtpMail.Send(objEmail);
            Response.Redirect("guestresponse.aspx");
        }
        catch (Exception exc)
        {
            Response.Write("Send failure: " + exc.ToString());
        }
    }
</script>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <h4>
        RPC Guest Registration
    </h4>
    <p>
        Welcome to RPC. If you have not done so recently, please take a moment to complete
        the following information so that we can know you. Upon clicking the Submit button
        below, your registration will be sent to Pastor Stan Gale's email address. He will
        followup with you shortly thereafter.</p>
    <p>
        We value your confidentiality and privacy. Please withhold submitting any personal
        information via this form that you would consider sensitive and speak to Dr. Gale
        about it directly at 610-696-3482.</p>
    <form id="form1" name="form1" method="post" action="~/guestresponse.aspx">
    <table>
        <asp:TableRow runat="server">
            <asp:TableCell runat="server">
                <label for="name">
                    Name:
                </label>
            </asp:TableCell>
            <asp:TableCell runat="server">
                <input name="name" type="text" id="name" />
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow runat="server">
            <asp:TableCell runat="server">
                <label for="address">
                    Address:
                </label>
            </asp:TableCell>
            <asp:TableCell runat="server">
                <input name="address" type="text" id="address" />
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow runat="server">
            <asp:TableCell runat="server">
                <label for="phone">
                    Phone:
                </label>
            </asp:TableCell>
            <asp:TableCell runat="server">
                <input name="phone" type="text" id="phone" />
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow runat="server">
            <asp:TableCell runat="server">
                <label for="email">
                    Email:
                </label>
            </asp:TableCell>
            <asp:TableCell runat="server">
                <asp:TextBox id="email" runat="server" />
            </asp:TableCell>
        </asp:TableRow>
    </table>
    <table>
        <asp:TableRow runat="server">
            <asp:TableCell runat="server">
                <label for="visited">
                    Have you visited with us?</label>
            </asp:TableCell>
            <asp:TableCell runat="server">
                <select name="visited" size="1" id="visited">
                    <option value="none">Please select</option>
                    <option value="Yes">Yes</option>
                    <option value="No">No</option>
                </select>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow runat="server">
            <asp:TableCell runat="server">
                <label for="college">
                    Are you a college student?</label>
            </asp:TableCell>
            <asp:TableCell runat="server">
                <select name="college" size="1" id="college">
                    <option value="none">Please select</option>
                    <option value="Yes">Yes</option>
                    <option value="No">No</option>
                </select>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow runat="server">
            <asp:TableCell runat="server">
                <label for="howhear">
                    How did you hear about RPC?</label>
            </asp:TableCell>
            <asp:TableCell runat="server">
                <select name="howhear" size="1" id="howhear">
                    <option>Please select</option>
                    <option value="Family or friend">Family or friend</option>
                    <option value="Website">Website</option>
                    <option value="Traveled by the church">Traveled by the church</option>
                    <option value="Phone book">Phone book</option>
                    <option value="Other">Other</option>
                </select>
            </asp:TableCell>
        </asp:TableRow>
    </table>
    <h3>
        Please check all that apply
    </h3>
    <p>
        <input name="contactme" type="checkbox" id="contactme" value="checkbox" />
        <label for="contactme">
            I'd like someone from the church to contact me</label>
    </p>
    <p>
        <input name="faith" type="checkbox" id="faith" value="checkbox" />
        <label for="faith">
            I'd like to know more about what it means to come to a personal faith in Jesus Christ</label></p>
    <p>
        <input name="churchhome" type="checkbox" id="churchhome" value="checkbox" />
        <label for="churchhome">
            I'm looking for a church home</label></p>
    <h3>
        My priorities in a church home are:
    </h3>
    <p>
        <input name="worship" type="checkbox" id="worship" value="checkbox" />
        <label for="worship">
            Worship style</label></p>
    <p>
        <input name="teaching" type="checkbox" id="teaching" value="checkbox" />
        <label for="teaching">
            Biblical teaching</label></p>
    <p>
        <input name="youth" type="checkbox" id="youth" value="checkbox" />
        <label for="youth">
            Youth ministry</label></p>
    <p>
        <input name="service" type="checkbox" id="service" value="checkbox" />
        <label for="service">
            Opportunities to serve</label></p>
    <p>
        <input name="love" type="checkbox" id="love" value="checkbox" />
        <label for="love">
            Warm and loving</label></p>
    <p>
        <input name="evangelism" type="checkbox" id="evangelism" value="checkbox" />
        <label for="evangelism">
            Evangelistic</label>
    </p>
    <p>
        <input name="other" type="checkbox" id="other" value="checkbox" />
        <label for="other">
            Other</label>&nbsp;
        <input name="othertext" type="text" id="othertext" />
    </p>
    <h3>
        <label for="commentsprayer">
            Comments and Prayer Requests
        </label>
    </h3>
    <p>
        <textarea name="commentsprayer" cols="50" rows="15" id="commentsprayer"></textarea>
    </p>
    <p>
        <asp:LinkButton ID="submit" OnCommand="Submit" Text="Submit" runat="server" />
    </p>
    </form>
</asp:Content>
