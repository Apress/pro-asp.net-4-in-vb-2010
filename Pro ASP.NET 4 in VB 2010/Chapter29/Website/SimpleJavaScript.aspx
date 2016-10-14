<%@ Page Language="VB" AutoEventWireup="false"
   CodeFile="SimpleJavaScript.aspx.vb" Inherits="SimpleJavaScript" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
   <title></title>
</head>
<body>
   <form id="form1" runat="server">
   <div>
      A:
      <asp:TextBox ID="TextBox1" runat="server" AutoPostBack="True"></asp:TextBox>
      <br />
      B:
      <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
   </div>
   </form>
</body>
</html>
