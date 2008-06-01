<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    Title="Reformed Presbyterian Church &mdash; RPC News &amp; Notes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <h4>
        RPC Notes &amp; News</h4>
    <p>
        <em>Note: Due to privacy concerns, contact, email and address information will not be
            displayed on this page. Please contact the church office for the information.</em></p>
    <asp:Repeater DataSourceID="RPCNewsAndNotesDataSource" runat="server">
        <ItemTemplate>
            <p>
                <%# DataBinder.Eval(Container.DataItem, "description") %>
            </p>
        </ItemTemplate>
    </asp:Repeater>
    <asp:SqlDataSource id="RPCNewsAndNotesDataSource" ConnectionString="<%$ ConnectionStrings:RPC %>"
    SelectCommand="findNewsAndNotesActive" SelectCommandType="StoredProcedure"
    runat="server">
        <SelectParameters>
            <asp:Parameter Name="channelId" DefaultValue="10" />
        </SelectParameters>
    </asp:SqlDataSource>
</asp:Content>
<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="HeadContent">
    <style type="text/css">
        .style1
        {
            border-collapse: collapse;
            font-size: 10.0pt;
            font-family: "Times New Roman";
            border-style: none;
            border-color: inherit;
            border-width: medium;
            margin-left: 5.4pt;
        }
    </style>
</asp:Content>
