<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" Title="Reformed Presbyterian Church — God's Good News" %>

<script runat="server">

</script>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <h4>
        God's Good News</h4>
    <table style="width: 100%; text-align: center">
        <tr>
            <td style="padding-bottom: 2em;">
                <img src="images/goodnews/creation.gif" width="100" runat="server" alt="Creation" />
            </td>
            <td style="padding-bottom: 2em;">
                <img id="Img1" src="images/goodnews/alienation.gif" width="100" runat="server" alt="Alienation" />
            </td>
            <td style="padding-bottom: 2em;">
                <img id="Img3" src="images/goodnews/initiation.gif" width="100" runat="server" alt="Initiation" />
            </td>
        </tr>
        <tr>
            <td>
                <img id="Img2" src="images/goodnews/obligation.gif" width="100" runat="server" alt="Obligation" />
            </td>
            <td>
                <img id="Img4" src="images/goodnews/restoration.gif" width="100" runat="server" alt="Restoration" />
            </td>
            <td>
                <img id="Img5" src="images/goodnews/respond.gif" width="100" runat="server" alt="R__" />
            </td>
        </tr>
    </table>
    <br />
    <div style="text-align:right">
        <a href="creation.aspx" runat="server">Click to read about God's Good News</a>
    </div>
</asp:Content>
