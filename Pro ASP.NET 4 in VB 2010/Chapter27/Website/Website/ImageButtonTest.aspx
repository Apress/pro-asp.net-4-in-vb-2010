<%@ Page Language="VB" AutoEventWireup="false"
   CodeFile="ImageButtonTest.aspx.vb" Inherits="ImageButtonTest" %>

<%@ Register Assembly="CustomServerControlsLibrary"
   Namespace="CustomServerControlsLibrary.CustomServerControlsLibrary"
   TagPrefix="apress" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
   <title>Untitled Page</title>
</head>
<body>
   <form id="form1" runat="server">
   <div>
      <apress:CustomImageButton ID="CustomImageButton1"
         runat="server" />
      <p>
         <asp:Label ID="Label1" runat="server" Text="" /></p>
   </div>
   </form>
</body>
</html>
