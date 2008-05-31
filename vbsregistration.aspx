<%@ Page Title="" Language="C#" %>

<%@ Import Namespace="System.Net.Mail" %>
<%@ Import Namespace="System.Data" %>

<script type="text/C#" runat="server">
    public void Submit(object source, EventArgs eventArgs)
    {
        VBSDataSource.InsertParameters.Add("child1NAME", child1name.Text);
        VBSDataSource.InsertParameters.Add("child1age", child1age.Text);
        VBSDataSource.InsertParameters.Add("child1gradecompleted", child1gradecompleted.Text);
        VBSDataSource.InsertParameters.Add("child1birthdate", child1birthdate.Text);
        VBSDataSource.InsertParameters.Add("child1tshirtsize", child1tshirtsize.Text);
        VBSDataSource.InsertParameters.Add("child2NAME", child2name.Text);
        VBSDataSource.InsertParameters.Add("child2age", child2age.Text);
        VBSDataSource.InsertParameters.Add("child2gradecompleted", child2gradecompleted.Text);
        VBSDataSource.InsertParameters.Add("child2birthdate", child2birthdate.Text);
        VBSDataSource.InsertParameters.Add("child2tshirtsize", child2tshirtsize.Text);
        VBSDataSource.InsertParameters.Add("child3NAME", child3name.Text);
        VBSDataSource.InsertParameters.Add("child3age", child3age.Text);
        VBSDataSource.InsertParameters.Add("child3gradecompleted", child3gradecompleted.Text);
        VBSDataSource.InsertParameters.Add("child3birthdate", child3birthdate.Text);
        VBSDataSource.InsertParameters.Add("child3tshirtsize", child3tshirtsize.Text);
        VBSDataSource.InsertParameters.Add("address", address.Text);
        VBSDataSource.InsertParameters.Add("citystatezip", citystatezip.Text);
        VBSDataSource.InsertParameters.Add("parentguardian", parentguardian.Text);
        VBSDataSource.InsertParameters.Add("phonehome", phonehome.Text);
        VBSDataSource.InsertParameters.Add("phonework", phonework.Text);
        VBSDataSource.InsertParameters.Add("emercontact", emercontact.Text);
        VBSDataSource.InsertParameters.Add("emerphone", emerphone.Text);
        VBSDataSource.InsertParameters.Add("invitedby", invitedby.Text);
        VBSDataSource.InsertParameters.Add("regattendrpc", regattendrpc.Checked.ToString());
        VBSDataSource.InsertParameters.Add("regattendchurch", regattendchurch.Checked.ToString());
        VBSDataSource.Insert();
    }

    public void DisplayCompleteMessage(object soruce, EventArgs eventArgs)
    {
        MessageText.Visible = true;
    }
        
</script>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-type" content="text/html; charset=UTF-8" />
    <title>Reformed Presbyterian Church of West Chester, PA</title>
    <meta http-equiv="Content-Language" content="en-us" />
    <meta http-equiv="imagetoolbar" content="no" />
    <meta name="MSSmartTagsPreventParsing" content="true" />
    <link id="Link1" rel="stylesheet" type="text/css" href="~/css/master.css" runat="server" />
    <link id="Link2" rel="stylesheet" type="text/css" href="~/css/thickbox.css" media="screen"
        runat="server" />
    <link id="Link3" rel="stylesheet" type="text/css" href="~/css/esvtext.css" runat="server" />

    <script type="text/javascript" src="scripts/jquery.js"></script>

    <script type="text/javascript" src="scripts/thickbox.js"></script>

    <!-- The following are for site traffic analysis -->

    <script type="text/javascript">
        var gaJsHost = (("https:" == document.location.protocol) ? "https://ssl." : "http://www.");
        document.write(unescape("%3Cscript src='" + gaJsHost + "google-analytics.com/ga.js' type='text/javascript'%3E%3C/script%3E"));
    </script>

    <script type="text/javascript">
        var pageTracker = _gat._getTracker("UA-3375098-2");
        pageTracker._initData();
        pageTracker._trackPageview();
    </script>

</head>
<body>
    <form id="Form1" runat="server">
    <div id="page-container">
        <div style="padding-bottom: 2em; background: #6D8A98;">
        </div>
        <div id="content_combined" style="width: 100%">
            <div id="main_content">
                <h3>
                    Vacation Bible School Registration form
                </h3>
                <asp:Table Width="100%" runat="server">  
                    <asp:TableRow runat="server">
                        <asp:TableCell runat="server">
                            1)
                            <asp:Label AssociatedControlID="child1name" runat="server" Text="Name" />
                        </asp:TableCell>
                        <asp:TableCell runat="server">
                            <asp:TextBox ID="child1name" runat="server" />
                        </asp:TableCell>
                        <asp:TableCell runat="server">
                            <asp:Label AssociatedControlID="child1age" runat="server" Text="Age" />
                        </asp:TableCell>
                        <asp:TableCell runat="server">
                            <asp:TextBox ID="child1age" Columns="2" runat="server" />
                        </asp:TableCell>
                        <asp:TableCell runat="server">
                            <asp:Label AssociatedControlID="child1gradecompleted" runat="server" Text="Grade Completed" />
                        </asp:TableCell>
                        <asp:TableCell runat="server">
                            <asp:TextBox ID="child1gradecompleted" Columns="2" runat="server" />
                        </asp:TableCell>
                        <asp:TableCell runat="server">
                            <asp:Label ID="Label3" AssociatedControlID="child1birthdate" runat="server" Text="Birthdate" />
                        </asp:TableCell>
                        <asp:TableCell runat="server">
                            <asp:TextBox ID="child1birthdate" runat="server" />
                        </asp:TableCell>
                        <asp:TableCell ID="TableCell2" runat="server">
                            <asp:Label ID="Label20" AssociatedControlID="child1tshirtsize" runat="server" Text="T-Shirt size" />
                        </asp:TableCell>
                        <asp:TableCell ID="TableCell3" runat="server">
                            <asp:TextBox ID="child1tshirtsize" Columns="3" runat="server" />
                        </asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow runat="server">
                        <asp:TableCell runat="server">
                            2)
                            <asp:Label ID="Label1" AssociatedControlID="child2name" runat="server" Text="Name" />
                        </asp:TableCell>
                        <asp:TableCell runat="server">
                            <asp:TextBox ID="child2name" runat="server" />
                        </asp:TableCell>
                        <asp:TableCell runat="server">
                            <asp:Label ID="Label2" AssociatedControlID="child2age" runat="server" Text="Age" />
                        </asp:TableCell>
                        <asp:TableCell runat="server">
                            <asp:TextBox ID="child2age" Columns="2" runat="server" />
                        </asp:TableCell>
                        <asp:TableCell runat="server">
                            <asp:Label ID="Label4" AssociatedControlID="child2gradecompleted" runat="server"
                                Text="Grade Completed" />
                        </asp:TableCell>
                        <asp:TableCell runat="server">
                            <asp:TextBox ID="child2gradecompleted" Columns="2" runat="server" />
                        </asp:TableCell>
                        <asp:TableCell runat="server">
                            <asp:Label ID="Label5" AssociatedControlID="child2birthdate" runat="server" Text="Birthdate" />
                        </asp:TableCell>
                        <asp:TableCell runat="server">
                            <asp:TextBox ID="child2birthdate" runat="server" />
                        </asp:TableCell>
                        <asp:TableCell ID="TableCell4" runat="server">
                            <asp:Label ID="Label21" AssociatedControlID="child2tshirtsize" runat="server" Text="T-Shirt size" />
                        </asp:TableCell>
                        <asp:TableCell ID="TableCell5" runat="server">
                            <asp:TextBox ID="child2tshirtsize" Columns="3" runat="server" />
                        </asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow runat="server">
                        <asp:TableCell runat="server">
                            3)
                            <asp:Label ID="Label6" AssociatedControlID="child3name" runat="server" Text="Name" />
                        </asp:TableCell>
                        <asp:TableCell runat="server">
                            <asp:TextBox ID="child3name" runat="server" />
                        </asp:TableCell>
                        <asp:TableCell runat="server">
                            <asp:Label ID="Label7" AssociatedControlID="child3age" runat="server" Text="Age" />
                        </asp:TableCell>
                        <asp:TableCell runat="server">
                            <asp:TextBox ID="child3age" Columns="2" runat="server" />
                        </asp:TableCell>
                        <asp:TableCell runat="server">
                            <asp:Label ID="Label8" AssociatedControlID="child3gradecompleted" runat="server"
                                Text="Grade Completed" />
                        </asp:TableCell>
                        <asp:TableCell runat="server">
                            <asp:TextBox ID="child3gradecompleted" Columns="2" runat="server" />
                        </asp:TableCell>
                        <asp:TableCell runat="server">
                            <asp:Label ID="Label9" AssociatedControlID="child3birthdate" runat="server" Text="Birthdate" />
                        </asp:TableCell>
                        <asp:TableCell runat="server">
                            <asp:TextBox ID="child3birthdate" runat="server" />
                        </asp:TableCell>
                        <asp:TableCell ID="TableCell6" runat="server">
                            <asp:Label ID="Label22" AssociatedControlID="child3tshirtsize" runat="server" Text="T-Shirt size" />
                        </asp:TableCell>
                        <asp:TableCell ID="TableCell7" runat="server">
                            <asp:TextBox ID="child3tshirtsize" Columns="3" runat="server" />
                        </asp:TableCell>
                    </asp:TableRow>
                </asp:table>
                <asp:Table runat="server" Width="100%">
                    <asp:TableRow runat="server">
                        <asp:TableCell runat="server">
                            <asp:Label ID="Label12" AssociatedControlID="address" runat="server" Text="Address" />
                        </asp:TableCell>
                        <asp:TableCell runat="server">
                            <asp:TextBox ID="address" runat="server" />
                        </asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow runat="server">
                        <asp:TableCell runat="server">
                            <asp:Label ID="Label13" AssociatedControlID="citystatezip" runat="server" Text="City/State/Zip" />
                        </asp:TableCell>
                        <asp:TableCell runat="server">
                            <asp:TextBox ID="citystatezip" runat="server" />
                        </asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow runat="server">
                        <asp:TableCell runat="server">
                            <asp:Label ID="Label14" AssociatedControlID="parentguardian" runat="server" Text="Parent(s)/Guardian" />
                        </asp:TableCell>
                        <asp:TableCell runat="server">
                            <asp:TextBox ID="parentguardian" runat="server" />
                        </asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow runat="server">
                        <asp:TableCell runat="server">Phone</asp:TableCell>
                        <asp:TableCell runat="server">
                            <asp:Label ID="Label15" AssociatedControlID="phonehome" runat="server" Text="(home)" />
                        </asp:TableCell>
                        <asp:TableCell runat="server">
                            <asp:TextBox ID="phonehome" runat="server" />
                        </asp:TableCell>
                        <asp:TableCell runat="server">
                            <asp:Label ID="Label10" AssociatedControlID="phonework" runat="server" Text="(work)" />
                        </asp:TableCell>
                        <asp:TableCell runat="server">
                            <asp:TextBox ID="phonework" runat="server" />
                        </asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow runat="server">
                        <asp:TableCell ColumnSpan="2" runat="server">
                            <asp:Label ID="Label16" AssociatedControlID="emercontact" runat="server" Text="Emergency Contact (other than parent/guardian)" />
                        </asp:TableCell>
                        <asp:TableCell runat="server">
                            <asp:TextBox ID="emercontact" runat="server" />
                        </asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow runat="server">
                        <asp:TableCell runat="server">
                            <asp:Label ID="Label17" AssociatedControlID="emerphone" runat="server" Text="Emergency Phone" />
                        </asp:TableCell>
                        <asp:TableCell runat="server">
                            <asp:TextBox ID="emerphone" runat="server" />
                        </asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow runat="server">
                        <asp:TableCell runat="server">
                            <asp:Label ID="Label18" AssociatedControlID="invitedby" runat="server" Text="Invited By" />
                        </asp:TableCell>
                        <asp:TableCell runat="server">
                            <asp:TextBox ID="invitedby" runat="server" />
                        </asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow runat="server">
                        <asp:TableCell ColumnSpan="1" runat="server">
                            <asp:Label ID="Label11" AssociatedControlID="regattendrpc" runat="server" Text="Regularly attend RPC?" />
                        </asp:TableCell>
                        <asp:TableCell runat="server">
                            <asp:CheckBox ID="regattendrpc" runat="server" />
                        </asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow runat="server">
                        <asp:TableCell ID="TableCell1" ColumnSpan="1" runat="server">
                            <asp:Label ID="Label19" AssociatedControlID="regattendchurch" runat="server" Text="Regularly attend different church?" />
                        </asp:TableCell>
                        <asp:TableCell runat="server">
                            <asp:CheckBox ID="regattendchurch" runat="server" />
                        </asp:TableCell>
                    </asp:TableRow>
                </asp:Table>
                <asp:LinkButton OnCommand="Submit" Text="Submit" runat="server" />
                <asp:Panel ID="MessageText" Visible="false" runat="server">
                    <div style="text-align: center;">
                        <asp:Label ForeColor="Red" runat="server">Registration Complete</asp:Label>
                    </div>
                </asp:Panel>
            </div>
        </div>
    </div>
    <asp:SqlDataSource ID="VBSDataSource" InsertCommand="vbsRegister" InsertCommandType="StoredProcedure"
        OnInserted="DisplayCompleteMessage" ConnectionString="<%$ ConnectionStrings:RPC %>"
        runat="server"></asp:SqlDataSource>
    </form>
</body>
</html>
