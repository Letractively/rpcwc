<%@ Page Language="C#" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">
    public void ExportToExcel(object source, EventArgs eventArgs)
    {
        DataGrid dataGrid = new DataGrid();
        System.IO.TextWriter textWriter = new System.IO.StringWriter();
        HtmlTextWriter writer = new HtmlTextWriter(textWriter);

        dataGrid.DataSource = VBSRegistrationSQLDataSource;

        dataGrid.DataBind();
        dataGrid.RenderControl(writer);
        
        Response.ContentType = "application/vnd.ms-excel";
        EnableViewState = false;
        Response.Write(textWriter.ToString());
        Response.End();
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
                    VBS Registrations</h3>
                <div style="text-align: right;">
                    <asp:LinkButton runat="server" OnCommand="ExportToExcel">Export to Excel</asp:LinkButton>
                </div>
                <div style="overflow: auto">
                    <asp:SqlDataSource ID="VBSRegistrationSQLDataSource" ConnectionString="<%$ ConnectionStrings:RPC %>"
                        SelectCommand="SELECT * FROM VBS_REGISTRATION" runat="server" />
                    <asp:GridView ID="VBSRegistrationGridView" DataSourceID="VBSRegistrationSQLDataSource"
                        runat="server" AutoGenerateColumns="False">
                        <Columns>
                            <asp:BoundField DataField="child1NAME" HeaderText="Child 1 Name" SortExpression="child1NAME" />
                            <asp:BoundField DataField="child1age" HeaderText="Child 1 Age" SortExpression="child1age" />
                            <asp:BoundField DataField="child1gradecompleted" HeaderText="Child 1 Grade Completed"
                                SortExpression="child1gradecompleted" />
                            <asp:BoundField DataField="child1birthdate" HeaderText="Child 1 Birth Date" SortExpression="child1birthdate" />
                            <asp:BoundField DataField="child1tshirtsize" HeaderText="Child 1 T-Shirt Size" SortExpression="child1tshirtsize" />
                            <asp:BoundField DataField="child2NAME" HeaderText="Child 2 Name" SortExpression="child2NAME" />
                            <asp:BoundField DataField="child2age" HeaderText="Child 2 Age" SortExpression="child2age" />
                            <asp:BoundField DataField="child2gradecompleted" HeaderText="Child 2 Grade Completed"
                                SortExpression="child2gradecompleted" />
                            <asp:BoundField DataField="child2birthdate" HeaderText="Child 2 Birth Date" SortExpression="child2birthdate" />
                            <asp:BoundField DataField="child2tshirtsize" HeaderText="Child 2 T-Shirt Size" SortExpression="child2tshirtsize" />
                            <asp:BoundField DataField="child3NAME" HeaderText="Child 3 Name" SortExpression="child3NAME" />
                            <asp:BoundField DataField="child3age" HeaderText="Child 3 Age" SortExpression="child3age" />
                            <asp:BoundField DataField="child3gradecompleted" HeaderText="Child 3 Grade Completed"
                                SortExpression="child3gradecompleted" />
                            <asp:BoundField DataField="child3birthdate" HeaderText="Child 3 Birth Date" SortExpression="child3birthdate" />
                            <asp:BoundField DataField="child3tshirtsize" HeaderText="Child 3 T-Shirt Size" SortExpression="child3tshirtsize" />
                            <asp:BoundField DataField="address" HeaderText="Address" SortExpression="address" />
                            <asp:BoundField DataField="citystatezip" HeaderText="City / State / Zip" SortExpression="citystatezip" />
                            <asp:BoundField DataField="parentguardian" HeaderText="Parent / Guardian" SortExpression="parentguardian" />
                            <asp:BoundField DataField="phonehome" HeaderText="Home Phone" SortExpression="phonehome" />
                            <asp:BoundField DataField="phonework" HeaderText="Work Phone" SortExpression="phonework" />
                            <asp:BoundField DataField="emercontact" HeaderText="Emergency Contact" SortExpression="emercontact" />
                            <asp:BoundField DataField="emerphone" HeaderText="Emergency Phone" SortExpression="emerphone" />
                            <asp:BoundField DataField="invitedby" HeaderText="Invited By" SortExpression="invitedby" />
                            <asp:CheckBoxField DataField="regattendrpc" HeaderText="Regular RPC Attender" SortExpression="regattendrpc" />
                            <asp:CheckBoxField DataField="regattendchurch" HeaderText="Regular Church Attender"
                                SortExpression="regattendchurch" />
                            <asp:BoundField DataField="registerdate" HeaderText="Register Date" SortExpression="registerdate" />
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
        </div>
    </div>
    </form>
</body>
</html>
