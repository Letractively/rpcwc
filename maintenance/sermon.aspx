<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
CodeFile="sermon.aspx.cs" Inherits="maintenance_sermon" Title="Sermon Audio Maintenance Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Label ID="DatePickerLabel1" AssociatedControlID="DatePicker" Text="Date Preached: " runat="server" /><asp:Calendar ID="DatePicker" runat="server" /><br /><br />
    <asp:Label ID="FileControlLabel" AssociatedControlID="FileControl" Text="File: " runat="server" /><asp:FileUpload ID="FileControl" runat="server" /><br /><br />
    <asp:LinkButton Text="Submit" OnCommand="Submit" runat="server" />

    
    <div id="status" runat="server" />

</asp:Content>

