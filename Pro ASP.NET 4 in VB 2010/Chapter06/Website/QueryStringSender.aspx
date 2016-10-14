<%@ Page Language="VB" AutoEventWireup="false" CodeFile="QueryStringSender.aspx.vb"
    Inherits="QueryStringSender" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Button ID="cmdLarge" Style="z-index: 102; left: 8px; position: absolute;
            top: 80px" runat="server" Text="Large Text Version" Width="144px">
        </asp:Button>
        <asp:Button ID="cmdNormal" Style="z-index: 103; left: 24px; top: 184px"
            runat="server" Text="Normal Version" Width="144px">
        </asp:Button>
        <asp:Button ID="cmdSmall" Style="z-index: 103; left: 8px; position: absolute;
            top: 48px" runat="server" Text="Small Text Version" Width="144px">
        </asp:Button>
    </div>
    </form>
</body>
</html>
