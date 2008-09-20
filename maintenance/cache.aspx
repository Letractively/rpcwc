<%@ Page Title="Cache Maintenance" Language="C#" AutoEventWireup="true" CodeFile="cache.aspx.cs" Inherits="rpcwc.web.Maintenance.CacheMaintenance" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
</head>
<body>
    <form id="form1" runat="server">
    <h2>Cache Info</h2>
    
    <asp:Panel id="CacheInfo" runat="server">
    
    </asp:Panel>
    <br />
    <asp:LinkButton ID="BeginRefreshersLink" Text="Begin Refresher Job" OnCommand="BeginRefresherJob" runat="server"/>
    </form>
</body>
</html>
