<%@ Page Language="VB" AutoEventWireup="false" CodeFile="CreateTest.aspx.vb" Inherits="CreateTest" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
<div>
        <asp:CreateUserWizard ID="CreateUserWizard1" runat="server" LoginCreatedUser="False">
            <WizardSteps>
                <asp:CreateUserWizardStep ID="CreateUserWizardStep1" runat="server">
                </asp:CreateUserWizardStep>
                <asp:CompleteWizardStep ID="CompleteWizardStep1" runat="server">
                </asp:CompleteWizardStep>
            </WizardSteps>
        </asp:CreateUserWizard>
        <hr />
        Create New Role: <asp:TextBox runat="server" ID="RoleNameText" />&nbsp;
        <asp:Button ID="AddRoleCommand" runat="server" Text="Add Role" />
    </div>    </form>
</body>
</html>
