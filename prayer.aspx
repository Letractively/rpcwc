<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="~/prayer.aspx.cs" Inherits="rpcwc.web.PrayerPage"
    Title="Reformed Presbyterian Church" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <h4>
        How Can We Pray For You?</h4>
    <asp:Table Width="100%" runat="server">
        <asp:TableRow runat="server">
            <asp:TableCell runat="server">
                <asp:Label ID="Label4" AssociatedControlID="name" Text="Name" runat="server" /></asp:TableCell>
            <asp:TableCell ID="TableCell1" runat="server">
                <asp:TextBox ID="name" MaxLength="50" runat="server" /></asp:TableCell>
        </asp:TableRow>
        <asp:TableRow ID="TableRow1" runat="server">
            <asp:TableCell ID="TableCell2" runat="server">
                <asp:Label ID="Label5" AssociatedControlID="Email" Text="Email" runat="server" /></asp:TableCell>
            <asp:TableCell ID="TableCell3" runat="server">
                <asp:TextBox ID="Email" MaxLength="50" runat="server" /></asp:TableCell>
        </asp:TableRow>
        <asp:TableRow ID="TableRow2" runat="server">
            <asp:TableCell ID="TableCell4" runat="server">
                <asp:Label ID="Label1" AssociatedControlID="Subject" Text="Subject" runat="server" /></asp:TableCell>
            <asp:TableCell ID="TableCell5" runat="server">
                <asp:TextBox ID="Subject" MaxLength="50" runat="server" /></asp:TableCell>
        </asp:TableRow>
        <asp:TableRow ID="TableRow3" runat="server">
            <asp:TableCell ID="TableCell6" runat="server">
                <asp:Label ID="Label2" AssociatedControlID="phone" Text="Phone" runat="server" /></asp:TableCell>
            <asp:TableCell ID="TableCell7" runat="server">
                <asp:TextBox ID="phone" MaxLength="50" runat="server" /></asp:TableCell>
        </asp:TableRow>
        <asp:TableRow ID="TableRow4" runat="server">
            <asp:TableCell ColumnSpan="2" ID="TableCell9" runat="server">
                <asp:RadioButtonList ID="Status" RepeatDirection="Horizontal" RepeatLayout="Table"
                    runat="server">
                    <asp:ListItem Value="newRequest" Selected="True" Text="New Request" />
                    <asp:ListItem Value="updatedRequest" Text="Updated Request" />
                </asp:RadioButtonList>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow ID="TableRow5" runat="server">
            <asp:TableCell ColumnSpan="2" ID="TableCell8" runat="server">
                <asp:Label ID="Label3" AssociatedControlID="prayer" Text="Prayer" runat="server" /><br />
                <asp:TextBox ID="prayer" TextMode="MultiLine" Rows="8" runat="server" />
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow ID="TableRow6" runat="server">
            <asp:TableCell ColumnSpan="2" ID="TableCell10" runat="server">
                <asp:LinkButton Text="Submit" CommandName="Submit" OnClick="Submit" runat="server" />
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
    <br />
    <asp:Label ID="ErrorLabel" runat="server" />
</asp:Content>
