<%@ Page Language="VB" AutoEventWireup="false"
   CodeFile="FocusAndDefault.aspx.vb" Inherits="FocusAndDefault" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
   <title>Focus and Default Button</title>
</head>
<body>
   <form id="form1" defaultbutton="cmdDefaultButton"
   runat="server">
   <div>
      <div>
         TextBox1:
         <asp:TextBox ID="TextBox1" runat="server" AccessKey="1"></asp:TextBox>
         <br />
         TextBox2:
         <asp:TextBox ID="TextBox2" runat="server" AccessKey="2"></asp:TextBox>
         <br />
         <br />
         <asp:Button ID="cmdSetFocus1" Text="Set Focus #1"
            runat="server" />
         <asp:Button ID="cmdSetFocus2" Text="Set Focus #2"
            runat="server" />
         <asp:Button ID="cmdSubmit" runat="server" Text="Submit" />
         <hr />
         <asp:Label ID="Label1" runat="Server" EnableViewState="False" />
         <br />
         ' When the Enter key is press, the event code for this control is executed
         <asp:Button ID="cmdDefaultButton" runat="server"
            Text="Default Button" />
      </div>
   </div>
   </form>
</body>
</html>
