<%@ Page Language="VB" AutoEventWireup="false" CodeFile="GenericLogin.aspx.vb" Inherits="GenericLogin" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
   <div style="text-align: center; height: 298px;">
    Please Log into the System<br />
            <asp:Panel ID="MainPanel" 
         runat="server" BorderColor="Silver" BorderStyle="Solid"
                BorderWidth="1px" Height="272px" 
         Width="389px">
                <br />
                <table border="0" cellpadding="0" 
                   cellspacing="0" width="100%" 
                   style="height: 165px">
                    <tr>
                        <td style="height:43px; width:30%">
                          User Name:</td>
                        <td style="height:43px; width:70%">
                            <asp:TextBox ID="UsernameText" runat="server" Width="80%"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="UsernameRequiredValidator" runat="server" ControlToValidate="UsernameText"
                                ErrorMessage="*"></asp:RequiredFieldValidator>
                            <br />
                            <asp:RegularExpressionValidator ID="UsernameValidator" runat="server" ControlToValidate="UsernameText"
                                ErrorMessage="Invalid username" ValidationExpression="[\w| ]*"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr>
                        <td style="height:26px; width:30%">
                            Password:</td>
                        <td style="height:26px; width:70%">
                            <asp:TextBox ID="PasswordText" runat="server" TextMode="Password" Width="80%"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="PwdRequiredValidator" runat="server" ControlToValidate="PasswordText"
                                ErrorMessage="*"></asp:RequiredFieldValidator>
                            <br />
                            <asp:RegularExpressionValidator ID="PwdValidator" runat="server" ControlToValidate="PasswordText"
                                ErrorMessage="Invalid password" ValidationExpression='[\w| !"�$%&amp;/()=\-?\*]*'></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                </table>
                <br />
                <asp:Button ID="LoginAction" runat="server"  Text="Login" />&nbsp;<asp:Button
                    ID="RegisterAction" runat="server"  Text="Register" /><br />
                <asp:Label ID="LegendStatus" runat="server" EnableViewState="false" Text=""></asp:Label></asp:Panel>
        </div>
    </form>
</body>
</html>
