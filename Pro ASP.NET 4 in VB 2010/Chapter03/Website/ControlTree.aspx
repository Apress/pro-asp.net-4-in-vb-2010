<%@ Page Language="VB" AutoEventWireup="false" CodeFile="ControlTree.aspx.vb"
    Inherits="ControlTree" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.1 Transitional//EN" 
"http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>Controls</title>
</head>
<body>
    <p>
        <i>This is static HTML (not a web control).</i></p>
    <form id="theControls" method="post" runat="server">
    <div>
        <asp:Panel ID="MainPanel" runat="server" Height="112px">
            <p>
                <asp:Button ID="Button1" runat="server" Text="Button1" />
                <asp:Button ID="Button2" runat="server" Text="Button2" />
                <asp:Button ID="Button3" runat="server" Text="Button3" /></p>
            <p>
                <asp:Label ID="Label1" runat="server" Width="48px">
              Name:</asp:Label>
                <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox></p>
        </asp:Panel>
        <p>
            <asp:Button ID="Button4" runat="server" Text="Button4" /></p>
        <p>
            <i>This is static HTML (not a web control).</i></p>
    </div>
    </form>
</body>
</html>
