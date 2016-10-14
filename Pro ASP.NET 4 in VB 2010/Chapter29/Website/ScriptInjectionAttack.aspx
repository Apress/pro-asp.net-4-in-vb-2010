<%@ Page Language="VB" AutoEventWireup="false" 
   CodeFile="ScriptInjectionAttack.aspx.vb" Inherits="ScriptInjectionAttack" %>

<%--<%@ Page Language="VB" AutoEventWireup="false" ValidateRequest="false" 
   CodeFile="ScriptInjectionAttack.aspx.vb" Inherits="ScriptInjectionAttack" %>--%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
   <title></title>
</head>
<body>
   <form id="form1" runat="server">
   <div>
      <asp:TextBox ID="txtInput" runat="server" 
         Width="388px">
      &lt;script&gt;alert('Script Injection');&lt;/script&gt;
      </asp:TextBox>
      <br />
      <asp:Button ID="cmdSubmit" runat="server" Text="Submit"
         OnClick="cmdSubmit_Click"></asp:Button>
      <br />
      <br />
      <asp:Label ID="lblInfo" runat="server"></asp:Label>
   </div>
   </form>
</body>
</html>
