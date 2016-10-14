<%@ Page Language="VB" AutoEventWireup="false" CodeFile="CustomDependencyTest.aspx.vb" Inherits="CustomDependencyTest" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.1//EN" "http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Button ID="cmdModify" runat="server" OnClick="cmdModfiy_Click"
            Text="Send Message" Width="103px" />
        <asp:Button ID="cmdGetItem" runat="server" Height="24px" OnClick="cmdGetItem_Click"
            Text="Check for Item"
            Width="103px" />
            <br /><br />
        <asp:Label ID="lblInfo" runat="server" BackColor="LightYellow" BorderStyle="Groove"
            BorderWidth="2px" Width="480px"></asp:Label>
    
    </div>
    </form>
</body>
</html>
