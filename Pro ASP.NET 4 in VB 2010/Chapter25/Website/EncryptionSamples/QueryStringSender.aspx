﻿<%@ Page Language="VB" AutoEventWireup="false" CodeFile="QueryStringSender.aspx.vb" Inherits="QueryStringSender" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    Enter some data here: <asp:TextBox runat="server" ID="MyData" />
    <br />
    <br />
    <asp:Button ID="SendCommand" runat="server" Text="Send Info"  />
    </div>
    </form>
</body>
</html>
