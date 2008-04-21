﻿<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    Title="Event Calendar Maintenance Page" %>
    
<script type="text/C#" runat="server">
    protected void setBold(Object source, GridViewRowEventArgs eventArgs)
    {
        if (eventArgs.Row.RowType == DataControlRowType.DataRow)
        {
            DateTime date = (DateTime)((System.Data.DataRowView)eventArgs.Row.DataItem).Row.ItemArray[2];

            if (date.CompareTo(DateTime.Now.AddDays(-7)) >= 0)
                eventArgs.Row.Font.Bold = true;
        }
    }

    protected void setParams(Object sender, SqlDataSourceSelectingEventArgs e)
    {
        e.Command.Parameters["@startDate"].Value = DateTime.Now.AddDays(-14);
    }
</script>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    
    <asp:SqlDataSource ID="PrayerDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:RPC %>"
        SelectCommand="getPrayerList" SelectCommandType="StoredProcedure" OnSelecting="setParams"
        UpdateCommand="updatePrayerRequest" UpdateCommandType="StoredProcedure"
        InsertCommand="createPrayerRequest" InsertCommandType="StoredProcedure">
        <SelectParameters>
            <asp:Parameter Name="channelId" DefaultValue="6" />
            <asp:Parameter Name="startDate" />
        </SelectParameters>
        <UpdateParameters>
            <asp:Parameter Name="item_id" />
            <asp:Parameter Name="author" />
            <asp:Parameter Name="pubDate" Type="DateTime" />
            <asp:Parameter Name="description" />
        </UpdateParameters>
        <InsertParameters>
            <asp:Parameter Name="channelId" DefaultValue="6" />
            <asp:Parameter Name="author" />
            <asp:Parameter Name="pubDate" Type="DateTime" />
            <asp:Parameter Name="description" />
        </InsertParameters>
    </asp:SqlDataSource>
    <table>
        <asp:DetailsView ID="PrayerDetails" DataSourceID="PrayerDataSource" runat="server"
            AutoGenerateRows="False" AutoGenerateInsertButton="True" AutoGenerateDeleteButton="True"
            AutoGenerateEditButton="True" DataKeyNames="item_id" AllowPaging="True" PagerSettings-Mode="NumericFirstLast">
            <PagerSettings Mode="NumericFirstLast"></PagerSettings>
            <Fields>
                <asp:BoundField DataField="item_id" HeaderText="ID" SortExpression="item_id" Visible="false" />
                <asp:BoundField DataField="pubDate" HeaderText="Date" SortExpression="pubDate" DataFormatString="{0:MM/dd/yyyy}" />
                <asp:BoundField DataField="author" HeaderText="Author" SortExpression="author" />
                <asp:TemplateField HeaderText="Description" SortExpression="description">
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("description") %>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox1" runat="server" Columns="50" Rows="10" Text='<%# Bind("description") %>'
                            TextMode="MultiLine"></asp:TextBox>
                    </EditItemTemplate>
                    <InsertItemTemplate>
                        <asp:TextBox ID="TextBox1" runat="server" Columns="50" Rows="10" Text='<%# Bind("description") %>'
                            TextMode="MultiLine"></asp:TextBox>
                    </InsertItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="title" HeaderText="Title" SortExpression="title" Visible="false" />
            </Fields>
        </asp:DetailsView>
    </table>
    <div style="height: 20em">
    </div>
</asp:Content>