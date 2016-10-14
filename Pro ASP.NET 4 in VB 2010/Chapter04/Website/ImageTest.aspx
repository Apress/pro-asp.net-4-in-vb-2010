<%@ Page Language="VB" AutoEventWireup="false"
   CodeFile="ImageTest.aspx.vb" Inherits="ImageTest" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
   <title>UImage Test</title>
</head>
<body>
   <form id="form1" runat="server">
   <div>
      <asp:ImageButton ID="ImageButton1" Style="z-index: 101;
         left: 18px; position: absolute; top: 21px"
         runat="server" ImageUrl="button.png" OnClick="ImageButton1_Click">
      </asp:ImageButton>
      <asp:Label ID="lblResult" Style="z-index: 102;
         left: 24px; position: absolute; top: 163px"
         runat="server" Height="60px" Width="393px"></asp:Label>
   </div>
   </form>
</body>
</html>
