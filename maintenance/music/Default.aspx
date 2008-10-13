<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="Default.aspx.cs" Inherits="maintenance_music_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <h4>
        RPC Music Upload page</h4>
    <asp:Label AssociatedControlID="FileUploadControl" Text="Song File" runat="server" />
    <asp:FileUpload runat="server" ID="FileUploadControl" />
    <asp:RadioButtonList ID="RadioButtonListControl" AutoPostBack="false" runat="server">
        <asp:ListItem Text="Piano" Value="piano" />
        <asp:ListItem Text="Lead" Value="lead" />
    </asp:RadioButtonList>
    <asp:LinkButton Text="Submit" OnCommand="UploadMusicFile" runat="server" />
</asp:Content>
