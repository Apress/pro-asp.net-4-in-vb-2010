<%@ Page Language="VB" AutoEventWireup="false"
   CodeFile="LinkControlTest.aspx.vb" Inherits="LinkControlTest" %>

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
      <br />
      <br />
      Using the LinkControl.vb control ...
      <br />
      <br />
      <apress:LinkControl ID="LinkControl1" runat="server" />
      <br />
      <br />
      Using the LinkWebControl.vb control ...
      <br />
      <br />
      <apress:LinkWebControl ID="LinkWebControl1" runat="server"
         BackColor="#FFFF80" Font-Names="Verdana" Font-Size="Large"
         ForeColor="#C00000" Text="Click to visit Apress"
         HyperLink="http://www.apress.com"></apress:LinkWebControl>
      <br />
      <br />
      <asp:Label ID="lblHtml" runat="server" Text=""></asp:Label>
   </div>
   </form>
</body>
</html>
