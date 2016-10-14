<%@ Page Language="VB" AutoEventWireup="false" CodeFile="CookieMgmt.aspx.vb" Inherits="CookieMgmt" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Button ID="Button1" runat="server" 
            Text="Create Cookie" />
    
        <br />
        <br />
        <asp:Button ID="Button2" runat="server" 
            Text="Retrieve Cookie" Width="176px" />
        <br />
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="Button3" runat="server" 
            Text="Delete Cookie" />
             </div>
    </form>
</body>
</html>
