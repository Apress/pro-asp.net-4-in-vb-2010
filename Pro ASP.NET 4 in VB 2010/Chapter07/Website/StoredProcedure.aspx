<%@ Page Language="VB" AutoEventWireup="false" CodeFile="StoredProcedure.aspx.vb" Inherits="StoredProcedure" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>    
        <asp:Label ID="Label1" runat="server" Text="Title:  "></asp:Label>
        <asp:TextBox ID="theTitle" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="Label2" runat="server" Text="First Name:  "></asp:Label>
        <asp:TextBox ID="lastName" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="Label3" runat="server" Text="Last Name:  "></asp:Label>
        <asp:TextBox ID="firstName" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="Button1" runat="server" Text="Add to Database" />
        <br />
        <br />
        <asp:Label ID="Label4" runat="server" Text="Result:  "></asp:Label>
        <asp:Literal ID="HtmlContent" runat="server"></asp:Literal>
    </div>
    </form>
</body>
</html>
