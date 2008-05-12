<%@ Page Language="C#" MasterPageFile="~/maintenance/access/accessMaintenance.master"
CodeFile="user.aspx.cs" Inherits="maintenance_access_user"
    AutoEventWireup="true" Title="User Maintenance" %>

<asp:Content ContentPlaceHolderID="head" runat="server">

    <script type="text/C#" runat="server">
    </script>

</asp:Content>
<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:CreateUserWizard ID="CreateUserWizard1" LoginCreatedUser="false"  runat="server"
        OnCreatedUser="getAllUsers" RequireEmail="False">
        <WizardSteps>
            <asp:CreateUserWizardStep ID="CreateUserWizardStep1" Title="Create a new user" runat="server">
            </asp:CreateUserWizardStep>
            <asp:CompleteWizardStep ID="CompleteWizardStep1" runat="server">
            </asp:CompleteWizardStep>
        </WizardSteps>
    </asp:CreateUserWizard>
    <asp:ListBox ID="UserList" OnInit="getAllUsers" OnSelectedIndexChanged="UserSelected" runat="server" />
    <asp:ChangePassword ID="ChangePassword" runat="server" />
</asp:Content>
