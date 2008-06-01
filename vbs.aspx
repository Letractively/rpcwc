<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" %>

<script runat="server">

</script>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <h4>
        Vacation Bible School</h4>
    <p>
        The VBS will take place on June 30–July 3 at 9:30–11:30am. The theme is "Jesus,
        My Savior and My Friend." The lessons will cover: Jesus Forgives the Sin of a Paralyzed
        Man, Jesus Cares for His Disciples in a Storm, Jesus Meets a Samaritan Woman, Jesus
        Heals the Centurion's Servant, Jesus Answers a Lawyer's Question. Kids can expect
        guest "visits" from Biblical characters from these stories. The age range is kids
        from age 3 to 5th grade. We will be providing nursery for kids under 3 who attend.</p>
    <p>
        Free snacks, fun games, crafts and activities daily.</p>
    <asp:HyperLink NavigateUrl="vbsregistration.aspx" Text="Click Here" Target="_blank"
        runat="server" />
    to register. Free VBS T shirt if you register by June 25.
</asp:Content>
