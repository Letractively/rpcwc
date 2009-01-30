<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" CodeFile="~/community.aspx.cs"
    Inherits="rpcwc.web.NewsAndNotes" AutoEventWireup="true" Title="Reformed Presbyterian Church &mdash; RPC News &amp; Notes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <h4>
        RPC Notes &amp; News</h4>
    <p>
        <em>Note: Due to privacy concerns, contact, email and address information will not be
            displayed on this page. Please contact the church office for the information.</em></p>
    <asp:Repeater DataSourceID="RPCNewsAndNotesObjectDataSource" runat="server">
        <ItemTemplate>
            <h3 style="text-align: left;border-bottom: solid 1px #ccc;"><%# DataBinder.Eval(Container.DataItem, "Title") %></h3>
            <p>
                <%# DataBinder.Eval(Container.DataItem, "Content")%>
            </p>
        </ItemTemplate>
    </asp:Repeater>
    <asp:ObjectDataSource ID="RPCNewsAndNotesObjectDataSource" TypeName="rpcwc.bo.NewsAndNotesManager" SelectMethod="findAllNewsAndNotesActive"
        EnableCaching="false" OnObjectCreating="SetObjectDataSourceInstance" runat="server" />
</asp:Content>
