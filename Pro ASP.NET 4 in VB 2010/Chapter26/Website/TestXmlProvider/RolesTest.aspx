<%@ Page Language="VB" AutoEventWireup="false" CodeFile="RolesTest.aspx.vb" Inherits="RolesTest" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
 Rolename: <asp:TextBox ID="RoleNameText" runat="server" /><br />
        Username: <asp:TextBox ID="UserNameText" runat="server" /><br />
        <asp:Button runat="server" ID="DeleteRole" Text="Delete" />
        <asp:Button runat="server" ID="FindUsersInRole" Text="Find Users In Role" />
        <asp:Button runat="server" ID="GetAll" Text="Get All Roles" />
        <asp:Button runat="server" ID="GetRolesForUser" Text="Get Roles For User" />
        <asp:Button runat="server" ID="GetUsersInRole" Text="Get Users In Role" />
        <asp:Button runat="server" ID="IsUserInRole" Text="Is User In Role" />
        <asp:Button runat="server" ID="AddUserToRole" Text="Add User To Role"  />
        <asp:Button runat="server" ID="RemoveUserFromRole" Text="Remove User From Role" />
        <hr />
        <asp:Label runat="server" ID="ResultsLabel" />    
    </div>
    </form>
</body>
</html>
