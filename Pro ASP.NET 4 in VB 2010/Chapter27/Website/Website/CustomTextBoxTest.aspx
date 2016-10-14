<%@ Page Language="VB" AutoEventWireup="false"
   CodeFile="CustomTextBoxTest.aspx.vb" Inherits="CustomTextBoxTest" %>

<%@ Register TagPrefix="apress" Namespace="CustomServerControlsLibrary.CustomServerControlsLibrary"
   Assembly="CustomServerControlsLibrary" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
   <title>Untitled Page</title>
</head>
<body>
   <form id="form1" runat="server">
   <div>
      <apress:CustomTextBox ID="CustomTextBox1" runat="server" />
      <asp:Button ID="Button1" runat="server" Text="Submit" />
      <br /><br />
      <asp:Label ID="Label1" runat="server" Text="" />
   </div>
   </form>
</body>
</html>
