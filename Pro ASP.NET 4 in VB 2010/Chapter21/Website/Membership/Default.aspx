﻿<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Default.aspx.vb" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h1>Anonymous access allowed</h1>
        <a href="Restricted/SecuredPage.aspx">Secured Page</a><br />
        <asp:LoginStatus ID="LoginStatus1" runat="server"
             LoginText="Sign In"
             LogoutText="Sign Out"
             LogoutPageUrl="~/Default.aspx" 
             LogoutAction="Redirect" />
        <p>
           Different content is displayed based on your login-state
        <asp:LoginView ID="LoginViewCtrl" runat="server" >
            <AnonymousTemplate>
                <h2>You are anonymous</h2>
            </AnonymousTemplate>
            <LoggedInTemplate>
                <h2>You are logged in</h2>
                Submit your comment: <asp:TextBox runat="server" ID="CommentText" /><br />
                <asp:Button runat="server" ID="SubmitCommentAction" Text="Submit" />
            </LoggedInTemplate>
            <RoleGroups>
            </RoleGroups>
        </asp:LoginView>
        </p>    
    </div>
    </form>
</body>
</html>
