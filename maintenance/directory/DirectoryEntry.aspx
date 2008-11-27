<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="DirectoryEntry.aspx.cs" Inherits="rpcwc.web.Maintenance.maintenance_directory_DirectoryEntry" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <h4>Directory Maintenance</h4>
    
    <h3>Details:</h3>
    <asp:Table runat="server">
        <asp:TableRow runat="server">
            <asp:TableCell ID="TableCell1" runat="server">
                <asp:Label ID="Label6" AssociatedControlID="LastName" Text="Last Name" runat="server" /></asp:TableCell>
            <asp:TableCell ID="TableCell2" runat="server">
                <asp:TextBox ID="LastName" runat="server" /></asp:TableCell>
        </asp:TableRow>
        <asp:TableRow ID="TableRow1" runat="server">
            <asp:TableCell ID="TableCell3" runat="server">
                <asp:Label ID="Label5" AssociatedControlID="Address1" Text="Address1" runat="server" /></asp:TableCell>
            <asp:TableCell ID="TableCell4" runat="server">
                <asp:TextBox ID="Address1" runat="server" /></asp:TableCell>
        </asp:TableRow>
        <asp:TableRow ID="TableRow2" runat="server">
            <asp:TableCell ID="TableCell5" runat="server">
                <asp:Label ID="Label4" AssociatedControlID="Address2" Text="Address2" runat="server" /></asp:TableCell>
            <asp:TableCell ID="TableCell6" runat="server">
                <asp:TextBox ID="Address2" runat="server" /></asp:TableCell>
        </asp:TableRow>
        <asp:TableRow ID="TableRow4" runat="server">
            <asp:TableCell ID="TableCell9" runat="server">
                <asp:Label ID="Label3" AssociatedControlID="City" Text="City" runat="server" /></asp:TableCell>
            <asp:TableCell ID="TableCell10" runat="server">
                <asp:TextBox ID="City" runat="server" /></asp:TableCell>
        </asp:TableRow>
        <asp:TableRow ID="TableRow3" runat="server">
            <asp:TableCell ID="TableCell7" runat="server">
                <asp:Label ID="Label2" AssociatedControlID="State" Text="State" runat="server" /></asp:TableCell>
            <asp:TableCell ID="TableCell8" runat="server">
                <asp:TextBox ID="State" runat="server" /></asp:TableCell>
        </asp:TableRow>
        <asp:TableRow ID="TableRow5" runat="server">
            <asp:TableCell ID="TableCell11" runat="server">
                <asp:Label ID="Label1" AssociatedControlID="Zip" Text="Zip" runat="server" /></asp:TableCell>
            <asp:TableCell ID="TableCell12" runat="server">
                <asp:TextBox ID="Zip" runat="server" /></asp:TableCell>
        </asp:TableRow>
    </asp:Table>
    <br />
    
    <h3>Family members:</h3>
    <asp:Table ID="PersonTable" runat="server">
    </asp:Table>
    <br />
    
    <h3>Family phones:</h3>
    <asp:Table ID="PhoneTable" runat="server">
    </asp:Table>
    <br />
    
    <h3>Family emails:</h3>
    <asp:Table ID="EmailTable" runat="server">
    </asp:Table>
    
</asp:Content>
