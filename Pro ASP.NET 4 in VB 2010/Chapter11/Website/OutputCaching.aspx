﻿<%@ Page Language="VB" AutoEventWireup="false" CodeFile="OutputCaching.aspx.vb" Inherits="OutputCaching" %>
<%@ OutputCache Duration="20" VaryByParam="None" %>
<%--<%@ OutputCache Duration="90" VaryByParam="*" %>--%>
<%--<%@ OutputCache Duration="90" VaryByParam="ProductID" %>--%>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.1//EN" "http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Label ID="lblDate" runat="server" Font-Bold="False" Font-Names="Verdana"
            Font-Size="XX-Large" ForeColor="#003300"></asp:Label><br />
        <br />
        <asp:Button ID="Button1" runat="server" Text="Refresh" />    
    </div>
    </form>
</body>
</html>