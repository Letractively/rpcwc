<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    Title="Reformed Presbyterian Church &mdash; Guest Registration" %>

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
    <form id="form1" name="form1" method="post" action="~/guestregister.aspx">
    <p>
        Name</p>
    <p>
        <label>
            <input name="name" type="text" id="name" />
        </label>
    </p>
    <p>
        Address</p>
    <p>
        <input name="address" type="text" id="address" />
    </p>
    <p>
        Phone</p>
    <p>
        <input name="phone" type="text" id="phone" />
    </p>
    <p>
        Email</p>
    <p>
        <input name="email" type="text" id="email" />
    </p>
    <p>
        Have you visited with us?
        <label>
            <br />
            <select name="visited" size="1" id="visited">
                <option value="none">Please select</option>
                <option value="Yes">Yes</option>
                <option value="No">No</option>
            </select>
        </label>
    </p>
    <p>
        Are you a college student?<br />
        <select name="college" size="1" id="college">
            <option value="none">Please select</option>
            <option value="Yes">Yes</option>
            <option value="No">No</option>
        </select>
    </p>
    <p>
        How did you hear about RPC?</p>
    <p>
        <label>
            <select name="howhear" size="1" id="howhear">
                <option>Please select</option>
                <option value="Family or friend">Family or friend</option>
                <option value="Website">Website</option>
                <option value="Traveled by the church">Traveled by the church</option>
                <option value="Phone book">Phone book</option>
                <option value="Other">Other</option>
            </select>
        </label>
    </p>
    <h3>
        <p>
            Please check all that apply</p>
    </h3>
    <p>
        <input name="contactme" type="checkbox" id="contactme" value="checkbox" />
        I'd like someone from the church to contact me</p>
    <p>
        <input name="faith" type="checkbox" id="faith" value="checkbox" />
        I'd like to know more about what it means to come to a personal faith in Jesus Christ</p>
    <p>
        <input name="churchhome" type="checkbox" id="churchhome" value="checkbox" />
        I'm looking for a church home</p>
    <h3>
        <p>
            My priorities in a church home are:</p>
    </h3>
    <p>
        <input name="worship" type="checkbox" id="worship" value="checkbox" />
        Worship style</p>
    <p>
        <input name="teaching" type="checkbox" id="teaching" value="checkbox" />
        Biblical teaching</p>
    <p>
        <input name="youth" type="checkbox" id="youth" value="checkbox" />
        Youth ministry</p>
    <p>
        <input name="service" type="checkbox" id="service" value="checkbox" />
        Opportunities to serve</p>
    <p>
        <input name="love" type="checkbox" id="love" value="checkbox" />
        Warm and loving</p>
    <p>
        <input name="evangelism" type="checkbox" id="evangelism" value="checkbox" />
        Evangelistic
    </p>
    <p>
        <input name="other" type="checkbox" id="other" value="checkbox" />
        Other</p>
    <p>
        <label>
            <input name="othertext" type="text" id="othertext" />
        </label>
    </p>
    <h3>
        <p>
            Comments and Prayer Requests</p>
    </h3>
    <p>
        <label>
            <textarea name="commentsprayer" cols="50" rows="15" id="commentsprayer"></textarea>
        </label>
    </p>
    <p>
        <label>
            <input type="submit" name="Submit" value="Submit" />
        </label>
    </p>
    </form>
</asp:Content>
