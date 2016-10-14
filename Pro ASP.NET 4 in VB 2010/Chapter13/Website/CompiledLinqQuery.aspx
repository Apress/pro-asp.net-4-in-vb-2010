<%@ Page Language="VB" AutoEventWireup="false" CodeFile="CompiledLinqQuery.aspx.vb" Inherits="CompiledLinqQuery" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:GridView ID="GridView1" runat="server">
        </asp:GridView>
        <asp:DropDownList ID="DropDownList1" runat="server" 
            Width="234px" AutoPostBack="True">
            <asp:ListItem Value="London"></asp:ListItem>
            <asp:ListItem Value="Madrid"></asp:ListItem>
            <asp:ListItem Value="Seattle"></asp:ListItem>
            <asp:ListItem Value="Paris"></asp:ListItem>
            <asp:ListItem Value="San Francisco"></asp:ListItem>
        </asp:DropDownList>
    </div>
    </form>
</body>
</html>
