<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    Title="Reformed Presbyterian Church &mdash; Upcoming Events"
    CodeFile="~/upcomingevents.aspx.cs" Inherits="rpcwc.web.UpcomingEvents"%>

<%@ Import Namespace="rpcwc.bo" %>
<%@ Import Namespace="Spring.Context" %>
<%@ Import Namespace="Spring.Context.Support" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <h4>
        Upcoming Events</h4>
    <asp:ObjectDataSource ID="EventsDataSource"
        SelectMethod="findSpecialEventsFuture"
        TypeName="rpcwc.bo.CalendarManager"
        OnObjectCreating="SetObjectDataSourceInstance"
        runat="server" />
    <asp:GridView ID="EventsGridView" DataSourceID="EventsDataSource" AutoGenerateColumns="False"
        BorderStyle="None" Width="100%" runat="server" GridLines="None">
        <Columns>
            <asp:TemplateField>
                <ItemTemplate>
                    <div style="text-align: right; border-bottom: solid 1px #ccc">
                        <h3 style="float: left">
                            <%# Eval("title")%></h3>
                        <%# ((DateTime)Eval("date")).ToString("MMMM d, yyyy") %></div>
                    <br clear="all" />
                    <p>
                        <%# Eval("description")%></p>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>
