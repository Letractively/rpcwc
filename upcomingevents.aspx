<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    Title="Reformed Presbyterian Church &mdash; Upcoming Events" %>

<script type="text/C#" runat="server">
    protected void SetParams(Object source, SqlDataSourceSelectingEventArgs eventArgs)
    {
        eventArgs.Command.Parameters["@startDate"].Value = DateTime.Now;
        eventArgs.Command.Parameters["@endDate"].Value = DateTime.Now.AddYears(1);
    }
</script>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <h4>
        Upcoming Events</h4>
    <asp:SqlDataSource ID="EventsDataSource" SelectCommand="SELECT pubDate, title, description FROM CALENDAR WHERE pubDate BETWEEN @startDate AND @endDate ORDER BY pubDate"
        SelectCommandType="Text" ConnectionString="<%$ ConnectionStrings:RPC %>" OnSelecting="SetParams"
        runat="server">
        <SelectParameters>
            <asp:Parameter Name="startDate" Type="DateTime" />
            <asp:Parameter Name="endDate" Type="DateTime" />
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:GridView ID="EventsGridView" DataSourceID="EventsDataSource" AutoGenerateColumns="False"
        BorderStyle="None" Width="100%" runat="server" GridLines="None">
        <Columns>
            <asp:TemplateField>
                <ItemTemplate>
                    <div style="text-align: right; border-bottom: solid 1px #ccc">
                        <h3 style="float: left">
                            <%# Eval("title")%></h3>
                        <%# ((DateTime)Eval("pubDate")).ToString("MMMM d, yyyy") %></div>
                    <br clear="all" />
                    <p>
                        <%# Eval("description")%></p>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>
