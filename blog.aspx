<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    Title="Reformed Presbyterian Church &mdash; Sermon Blog" CodeFile="~/blog.aspx.cs"
    Inherits="rpcwc.web.Blog" %>

<%@ Import Namespace="rpcwc.bo" %>
<%@ Import Namespace="Spring.Context" %>
<%@ Import Namespace="Spring.Context.Support" %>

<script type="text/C#" runat="server">
    public void SetDAOInstance(Object source, ObjectDataSourceEventArgs eventArgs)
    {
        eventArgs.ObjectInstance = (Object) blogManager;
    }
</script>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ObjectDataSource ID="BlogDataSource" TypeName="rpcwc.bo.BlogManager" OnObjectCreating="SetDAOInstance"
        SelectMethod="getBlogEntries" runat="server"></asp:ObjectDataSource>
    <asp:GridView ID="GridView" DataSourceID="BlogDataSource" AutoGenerateColumns="true"
        runat="server">
        <Columns>
        </Columns>
    </asp:GridView>
</asp:Content>
