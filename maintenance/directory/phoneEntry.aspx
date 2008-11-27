<%@ Page Language="C#" AutoEventWireup="true" CodeFile="phoneEntry.aspx.cs" Inherits="maintenance_directory_phoneEntry" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <h4>Person Maintenance</h4>
    
    <h3>Details:</h3>
    <asp:Table ID="Table1" runat="server">
        <asp:TableRow ID="TableRow6" runat="server">
            <asp:TableCell ID="TableCell13" runat="server">
                <asp:Label ID="Label7" AssociatedControlID="FirstName" Text="First Name" runat="server" /></asp:TableCell>
            <asp:TableCell ID="TableCell14" runat="server">
                <asp:TextBox ID="FirstName" runat="server" /></asp:TableCell>
        </asp:TableRow>
        <asp:TableRow ID="TableRow1" runat="server">
            <asp:TableCell ID="TableCell1" runat="server">
                <asp:Label ID="Label6" AssociatedControlID="LastName" Text="Last Name" runat="server" /></asp:TableCell>
            <asp:TableCell ID="TableCell2" runat="server">
                <asp:TextBox ID="LastName" runat="server" /></asp:TableCell>
        </asp:TableRow>
    </asp:Table>
    <br />
    
    <h3>Person phones:</h3>
    <asp:Table ID="PhoneTable" runat="server">
    </asp:Table>
    <br />
    
    <h3>Person emails:</h3>
    <asp:Table ID="EmailTable" runat="server">
    </asp:Table>    
    </div>
    </form>
</body>
</html>
