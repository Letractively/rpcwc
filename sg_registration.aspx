<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="~/sg_registration.aspx.cs" Inherits="rpcwc.web.SmallGroup.Registration"
    Title="Reformed Presbyterian Church &mdash; Cluster Group Registration" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <h4>
        RPC Cluster Group Registration</h4>
    <p>
		If you would like to be part of a Cluster Group, please complete the form below and someone will be in contact with you.
    </p>
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
        <asp:TableRow ID="TableRow5" runat="server">
            <asp:TableCell ID="TableCell9" runat="server">
                <label for="email">
                    Email:
                </label>
            </asp:TableCell>
            <asp:TableCell ID="TableCell10" runat="server">
                <input name="email" type="text" id="email" />
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow ID="TableRow6" runat="server">
            <asp:TableCell ID="TableCell11" runat="server">
                <label for="phone">
                    Phone:
                </label>
            </asp:TableCell>
            <asp:TableCell ID="TableCell12" runat="server">
                <input name="phone" type="text" id="phone" />
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
