<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="~/sg_registration.aspx.cs" Inherits="rpcwc.web.SmallGroup.Registration"
    Title="Reformed Presbyterian Church &mdash; Cluster Group Registration" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <h4>
        2008 RPC Cluster Group Registration</h4>
    <p>
        In June leaders in the Cluster Group ministry met to evaluate the value and workings
        of this small group ministry of RPC.&nbsp; The uniform consensus indicated that
        Clusters are integral in <b>individual spiritual formation</b>, in <b>building community</b>
        and in <b>assimilation</b> of those new to RPC.&nbsp;
    </p>
    <p>
        Some <b>changes</b> were also recommended and approved by the Session.&nbsp; Beginning
        this fall each group will decide its own meeting schedule (e.g., weekly, bi-weekly)
        and will decide its own curriculum approved by Session.&nbsp; The two suggested
        offerings this year are The Gospel of Mark (using the New Life study guide) or the
        book <i>In Christ Alone</i> by Sinclair Ferguson.</p>
    <p>
        More information on these materials as well as a more detailed description of the
        RPC Cluster ministry will be posted under ‘Small Groups’ on the church website (www.rpcwc.org).
    </p>
    <p>
        <span>Clusters resume meeting the week of September 21<sup>st</sup>.&nbsp; There are
            <b>three options</b> for involvement.<o:p></o:p></span></p>
    <ol>
        <li>If you are already part of a Cluster contact your Cluster leader to indicate your
            continuing interest and to find the out the time and place of the first meeting.</li>
        <li>If you were not part of a Cluster last year but would like to join an existing group,
            contact that Cluster leader.</li>
        <li>If you were not in a Cluster last year but would like to be part of a newly formed
            group, complete the information below and give it to Pastor Gale.</li>
    </ol>
    <table>
        <asp:TableRow ID="TableRow1" runat="server">
            <asp:TableCell ID="TableCell1" runat="server">
                <label for="name">
                    Name:
                </label>
            </asp:TableCell>
            <asp:TableCell ID="TableCell2" runat="server">
                <input name="name" type="text" id="name" />
            </asp:TableCell>
        </asp:TableRow>
    </table>
    <p>
        <b>Preferences:</b></p>
    <table>
        <asp:TableRow ID="TableRow2" runat="server">
            <asp:TableCell ID="TableCell3" runat="server">
                <label for="dayofweek">
                    Day of Week:
                </label>
            </asp:TableCell>
            <asp:TableCell ID="TableCell4" runat="server">
                <input name="dayofweek" type="text" id="Text1" />
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow ID="TableRow3" runat="server">
            <asp:TableCell ID="TableCell5" runat="server">
                <label for="dayorevening">
                    Day or evening:
                </label>
            </asp:TableCell>
            <asp:TableCell ID="TableCell6" runat="server">
                <input name="dayorevening" type="radio" value="day" /> Day&nbsp;
                <input name="dayorevening" type="radio" value="evening" /> Evening
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow ID="TableRow4" runat="server">
            <asp:TableCell ID="TableCell7" runat="server">
                <label for="locale">
                    Locale:
                </label>
            </asp:TableCell>
            <asp:TableCell ID="TableCell8" runat="server">
                <input name="locale" type="text" id="Text2" /> (leave blank if no preference)
            </asp:TableCell>
        </asp:TableRow>
    </table>
    <p>
        <asp:LinkButton ID="submit" OnCommand="Submit" Text="Submit" runat="server" />
    </p>
</asp:Content>
<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="HeadContent">
    <style type="text/css">
        h1
        {
            margin-bottom: .0001pt;
            text-align: center;
            page-break-after: avoid;
            font-size: 12.0pt;
            font-family: Arial;
            margin-left: 0in;
            margin-right: 0in;
            margin-top: 0in;
        }
    </style>
</asp:Content>
