﻿<%@ Page Language="vb" AutoEventWireup="false"
   CodeBehind="Login1.aspx.vb" Inherits="Membership.Login2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
   <title>Untitled Page</title>
</head>
<body>
   <form id="form1" runat="server">
   <div style="text-align: center">
      <asp:Login ID="LoginCtrl" runat="server" BackColor="aliceblue"
         BorderColor="Black" BorderStyle="double" OnLoginError="LoginCtrl_LoginError"
         PasswordRecoveryUrl="~/PwdRecoverTemplate.aspx">
         <LayoutTemplate>
            <h4>
               Log-In to the System</h4>
            <table>
               <tr>
                  <td>
                     Username:
                  </td>
                  <td>
                     <asp:TextBox ID="UserName" runat="server" />
                     <asp:RequiredFieldValidator ID="UserNameRequired"
                        runat="server" ControlToValidate="UserName"
                        ErrorMessage="*" ValidationGroup="Login1" />
                     <asp:RegularExpressionValidator ID="UsernameValidator"
                        runat="server" ControlToValidate="UserName"
                        ValidationExpression="[\w| ]*" ErrorMessage="Invalid Username"
                        ValidationGroup="Login1" />
                  </td>
               </tr>
               <tr>
                  <td>
                     Password:
                  </td>
                  <td>
                     <asp:TextBox ID="Password" runat="server" TextMode="Password" />
                     <asp:RequiredFieldValidator ID="PasswordRequired"
                        runat="server" ControlToValidate="Password"
                        ErrorMessage="*" ValidationGroup="Login1" />
                     <asp:RegularExpressionValidator ID="RegularExpressionValidator1"
                        runat="server" ControlToValidate="Password"
                        ValidationExpression='[\w| !"@§$%&amp;/()=\-?\*]*'
                        ErrorMessage="Invalid Password" ValidationGroup="Login1" />
                  </td>
               </tr>
            </table>
            <asp:CheckBox ID="RememberMe" runat="server" Text="Remember Me" /><br />
            <asp:Literal ID="FailureText" runat="server" /><br />
            <asp:Button ID="Login" CommandName="Login" runat="server"
               Text="Login" ValidationGroup="Login1" />
         </LayoutTemplate>
      </asp:Login>
      <br />
      <asp:Login ID="OtherLoginCtrl" runat="server"
         BackColor="aliceblue" BorderColor="Black" BorderStyle="double"
         PasswordRecoveryUrl="~/pwdrecover.aspx" OnAuthenticate="OtherLoginCtrl_Authenticate">
         <LayoutTemplate>
            <%--<font face="Courier New">--%>
            Access Key:&nbsp;<asp:TextBox ID="AccessKey" runat="server" /><br />
            Username:&nbsp;&nbsp;&nbsp;<asp:TextBox ID="UserName"
               runat="server" /><br />
            Password:&nbsp;&nbsp;&nbsp;<asp:TextBox ID="Password"
               runat="server" TextMode="password" Width="149px" /><br />
            <asp:Button runat="server" ID="Login1" CommandName="Login1"
               Text="Login" />
            <%--</font>--%>
         </LayoutTemplate>
      </asp:Login>
   </div>
   </form>
</body>
</html>
