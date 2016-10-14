<%@ Page Language="VB" AutoEventWireup="false"
   CodeFile="login.aspx.vb" Inherits="login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
   <title>Untitled Page</title>
<link href="MyStyles.css" rel="stylesheet" type="text/css" />
</head>
<body>
   <form id="form1" runat="server">
   <div style="text-align: center">
      <asp:Login ID="Login1" runat="server" BackColor="#E3EAEB"
         BorderColor="#E6E2D8" BorderPadding="4" BorderStyle="Solid"
         BorderWidth="1px" Font-Names="Verdana" Font-Size="0.8em"
         ForeColor="#333333" TextLayout="TextOnTop"
         HelpPageText="Additional Help"
         HelpPageUrl="HelpMe.htm" 
         InstructionText="Please enter your user name and password for <br>logging into the system.">
         <TextBoxStyle CssClass="MyLoginTextBoxStyle" />
         <%--<TextBoxStyle Font-Size="0.8em" />--%>
         <LoginButtonStyle BackColor="White" BorderColor="#C5BBAF"
            BorderStyle="Solid" BorderWidth="1px" Font-Names="Verdana"
            Font-Size="0.8em" ForeColor="#1C5E55" />
         <InstructionTextStyle Font-Italic="True" ForeColor="Black" />
         <TitleTextStyle BackColor="#1C5E55" Font-Bold="True"
            Font-Size="0.9em" ForeColor="White" />
      </asp:Login>
   </div>
   </form>
</body>
</html>
