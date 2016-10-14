<%@ Page Language="VB" AutoEventWireup="false"
   CodeFile="EventTracker.aspx.vb" Inherits="EventTracker" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" 
"http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
   <title>Event Tracker</title>
</head>
<body>
   <form id="form1" runat="server">
   <div>
      <h3>
         List of events:</h3>
      <asp:ListBox ID="lstEvents" runat="server" Height="107px"
         Width="355px" />
      <br />
      <br />
      <br />
      <h3>
         Controls being monitored for change events:</h3>
      <asp:TextBox ID="txt" runat="server" AutoPostBack="True"
         OnTextChanged="CtrlChanged" /><br />
      <br />
      <asp:CheckBox ID="chk" runat="server" AutoPostBack="True"
         OnCheckedChanged="CtrlChanged" /><br />
      <br />
      <asp:RadioButton ID="opt1" runat="server" GroupName="Sample"
         AutoPostBack="True" OnCheckedChanged="CtrlChanged" />
      <asp:RadioButton ID="opt2" runat="server" GroupName="Sample"
         AutoPostBack="True" OnCheckedChanged="CtrlChanged" />
   </div>
   </form>
</body>
</html>
