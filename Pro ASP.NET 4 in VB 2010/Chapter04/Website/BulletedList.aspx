<%@ Page Language="VB" AutoEventWireup="false"
   CodeFile="BulletedList.aspx.vb" Inherits="BulletedList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" 
"http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
   <title>BulletedList</title>
</head>
<body>
   <form id="form1" runat="server">
   <div>
      Bullet styles:<br />
      <br />
      <asp:BulletedList BulletStyle="Numbered" DisplayMode="LinkButton"
         ID="BulletedList1" runat="server">
      </asp:BulletedList>
      <asp:Label ID="Label1" runat="server" Text="No Selection" />
   </div>
   </form>
</body>
</html>
