﻿<%@ Page Language="VB" AutoEventWireup="false" CodeFile="ChangePassword.aspx.vb" Inherits="Restricted_ChangePassword" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
<div style="text-align: center">
        <asp:ChangePassword ID="ChangePwdCtrl" runat="server"
                            BorderStyle="groove" BackColor="aliceblue">
            <MailDefinition From="pwd@apress.com"
                            Subject="Changes in your profile"
                            Priority="high" />
            <TitleTextStyle Font-Bold="true" Font-Underline="true" 
                            Font-Names="Verdana" ForeColor="blue" />
        </asp:ChangePassword>    
    </div>
    </form>
</body>
</html>
