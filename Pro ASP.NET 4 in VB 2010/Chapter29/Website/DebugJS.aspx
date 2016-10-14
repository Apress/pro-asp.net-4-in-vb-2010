<%@ Page Language="VB" AutoEventWireup="false"
   CodeFile="DebugJS.aspx.vb" Inherits="DebugJS" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
   <title></title>
</head>
<body>
   <script type="text/javascript">
      function ShowAlert() {
         window.alert("This window diplayed through JavaScript")
      }
   </script>
   <form id="form1" runat="server">
   <div>
      <asp:TextBox ID="TextBox1" runat="server" onmouseover="ShowAlert()" />
   </div>
   </form>
</body>
</html>
