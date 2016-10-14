<%@ Page Language="VB" AutoEventWireup="false" CodeFile="~/DynamicButton.aspx.vb" Inherits="DynamicButton" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        The Panel:
        <asp:Panel ID="Panel1" runat="server">
        </asp:Panel>
        <br />
        The PlaceHolder:
        <asp:PlaceHolder ID="PlaceHolder1" runat="server"><br />
        </asp:PlaceHolder>
        <br />
        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
        <br />
        <br />
        <asp:Button ID="removeButton" runat="server" 
            Text="Remove the Button" />
        <asp:Button ID="createButton" runat="server"
         Text="Create the Button" />
        <br />
    </div>
    </form>
</body>
</html>
