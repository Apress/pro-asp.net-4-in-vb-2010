<%@ Page Language="VB" AutoEventWireup="false" CodeFile="MembershipTests.aspx.vb" Inherits="MembershipTests" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        Username: <asp:TextBox ID="UserNameText" runat="server" /><br />
        <asp:Button runat="server" ID="DeleteUser" Text="Delete"  />
        <asp:Button runat="server" ID="FindByName" Text="Find By Name" />
        <asp:Button runat="server" ID="FindByEmail" Text="Find By Email" />
        <asp:Button runat="server" ID="GetAllUsers" Text="Get All" />
        <asp:Button runat="server" ID="GetUser" Text="Get User"  />
        <asp:Button runat="server" ID="GetUserNameByEmail" Text="Get Name Of Email" />
        <asp:Button runat="server" ID="UpdateUser" Text="Update"  />
        <hr />
        <asp:Label runat="server" ID="ResultsLabel" />
    </div>
    </form>
</body>
</html>
