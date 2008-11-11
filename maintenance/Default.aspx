<%@ Page Language="C#" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">

</script>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <ul>
    <li><a href="~/maintenance/access/Default.aspx" runat="server">User Access</a>
        <ul>
            <li><a href="~/maintenance/access/user.aspx" runat="server">User Maintenance</a></li>
            <li><a href="~/maintenance/access/role.aspx" runat="server">Role Maintenance</a></li>
            <li><a href="~/maintenance/access/user_role.aspx" runat="server">User-Role Maintenance</a></li>
        </ul>
    </li>
    <li><a href="~/maintenance/blog/default.aspx" runat="server">Sermon Blog Maintenance</a></li>
    <!--<li><a href="~/maintenance/sermon.aspx" runat="server">Sermon Audio Maintenance</a></li>-->
    <li><a href="~/maintenance/cache.aspx" runat="server">Cache Maintenance</a></li>
    <!--<li><a href="~/maintenance/calendar.aspx" runat="server">Event Calendar Maintenance</a></li>-->
    <li><a href="~/maintenance/alert.aspx" runat="server">News/Alert Maintenance</a></li>
    <li><a href="~/maintenance/bulletin.aspx" runat="server">Bulletin Maintenance</a></li>
    <li><a href="~/maintenance/prayer.aspx" runat="server">Prayer Maintenance</a></li>
    <li><a href="RestartApplication.aspx" runat="server">Restart Application</a></li>
    </ul>
    </div>
    </form>
</body>
</html>
