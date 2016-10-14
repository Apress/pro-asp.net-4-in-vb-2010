<%@ Page Language="VB" AutoEventWireup="true" 
CodeFile= "~/PageFlow.aspx.vb" Inherits="PageFlow"%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" 
"http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Page Flow</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
         <asp:Label id="lblInfo" runat="server" EnableViewState="False">
         </asp:Label>         
         <asp:Button id="Button1" runat="server"
          OnClick="Button1_Click" Text="Button"></asp:Button>
    </div>
    </form>
</body>
</html>