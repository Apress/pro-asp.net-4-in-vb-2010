<%@ Page Language="VB" AutoEventWireup="false" CodeFile="MenuDb.aspx.vb" Inherits="TreeViewAndMenu_MenuDb" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <asp:Label ID="lblInfo" runat="server"></asp:Label><br />
        <br />
        <asp:Menu ID="Menu1" runat="server" BackColor="#FFFBD6" DynamicHorizontalOffset="2"
            Font-Names="Verdana" Font-Size="0.8em" ForeColor="#990000" 
            StaticSubMenuIndent="10px" StaticPopOutImageUrl="~/arrowitem.gif" StaticDisplayLevels="2">
            <StaticSelectedStyle BackColor="#FFCC66" />
            <StaticMenuItemStyle HorizontalPadding="5px" VerticalPadding="2px" />
            <DynamicHoverStyle BackColor="#990000" Font-Bold="False" ForeColor="White" />
            <DynamicMenuStyle BackColor="#FFFBD6" />
            <DynamicSelectedStyle BackColor="#FFCC66" />
            <DynamicMenuItemStyle HorizontalPadding="5px" VerticalPadding="2px" />
            <StaticHoverStyle BackColor="#990000" Font-Bold="False" ForeColor="White" />
            <LevelMenuItemStyles>
                <asp:MenuItemStyle BackColor="Blue" Font-Bold="True" Font-Underline="False" ForeColor="White" />
            </LevelMenuItemStyles>
        </asp:Menu>
        &nbsp;<br />
    </div>
    </form>
</body>
</html>
