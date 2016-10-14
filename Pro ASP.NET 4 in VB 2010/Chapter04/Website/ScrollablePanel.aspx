<%@ Page Language="VB" AutoEventWireup="false"
   CodeFile="ScrollablePanel.aspx.vb" Inherits="ScrollablePanel" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
   <title></title>
</head>
<body>
   <form id="Form1" runat="server">
   <div>
      <asp:Panel ID="Panel1" runat="server" Height="75px"
         Width="278px" BorderStyle="Solid" BorderWidth="1px"
         ScrollBars="Auto">
         This scrolls.
         <br />
         <br />
         <asp:Button ID="Button1" runat="server" Text="Button" />
         <br />
         <asp:Button ID="Button2" runat="server" Text="Button" />
         <br />
         ...
      </asp:Panel>
   </div>
   </form>
</body>
</html>
