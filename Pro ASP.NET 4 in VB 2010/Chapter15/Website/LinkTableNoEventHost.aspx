<%@ Page Language="VB" AutoEventWireup="false" CodeFile="LinkTableNoEventHost.aspx.vb" Inherits="LinkTableNoEventHost" %>

<%@ Register Src="LinkTableNoEvent.ascx" TagName="LinkTable" TagPrefix="ucl" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="lblInfo" runat="server" />
            <ucl:LinkTable ID="LinkTable1" runat="server" />
        </div>
    </form>
</body>
</html>
