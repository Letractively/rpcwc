<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
CodeFile="sermon.aspx.cs" Inherits="maintenance_sermon" Title="Sermon Audio Maintenance Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:SqlDataSource ID="SermonSqlDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:RPC %>"
        SelectCommand="getSermonAudioList" SelectCommandType="StoredProcedure"
        InsertCommand="insertSermonAudio" InsertCommandType="StoredProcedure"
        DeleteCommand="deleteSermonAudio" DeleteCommandType="StoredProcedure">
        <InsertParameters>
            <asp:ControlParameter ControlID="DatePicker" Name="date" />
            <asp:Parameter Name="author" DefaultValue="Dr. Stanley D. Gale" />
            <asp:ControlParameter ControlID="SermonTitle" Name="title" />
            <asp:ControlParameter ControlID="ScriptureReference" Name="reference" />
        </InsertParameters>
        <DeleteParameters>
            <asp:Parameter Name="id" />
        </DeleteParameters>
    </asp:SqlDataSource>

    <asp:Label ID="DatePickerLabel1" AssociatedControlID="DatePicker" Text="Date Preached: " runat="server" /><asp:Calendar ID="DatePicker" runat="server" /><br /><br />
    <asp:Label ID="SermonTitleLabel1" AssociatedControlID="SermonTitle" Text="Title: " runat="server" /><asp:TextBox ID="SermonTitle" runat="server" /><br /><br />
    <asp:Label ID="ScriptureReferenceLabel1" AssociatedControlID="ScriptureReference" Text="Scripture Reference: " runat="server" /><asp:TextBox ID="ScriptureReference" runat="server" /><br /><br />
    <asp:Label ID="FileControlLabel" AssociatedControlID="FileControl" Text="File: " runat="server" /><asp:FileUpload ID="FileControl" runat="server" /><br /><br />
    
    <div id="status" runat="server" />

</asp:Content>

