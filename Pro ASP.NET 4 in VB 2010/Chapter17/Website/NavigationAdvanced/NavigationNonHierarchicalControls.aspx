<%@ Page Language="VB" AutoEventWireup="false" CodeFile="NavigationNonHierarchicalControls.aspx.vb" Inherits="NavigationAdvanced_NavigationNonHierarchicalControls" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
     <asp:DropDownList ID="lstParent" runat="server" DataTextField="Title"
            Width="165px" AutoPostBack="True" DataValueField="Url" OnSelectedIndexChanged="Nav_SelectedIndexChanged">
        </asp:DropDownList>
        <br />
        <asp:ListBox ID="lstChild" runat="server" Width="164px" AutoPostBack="True" DataTextField="Title" DataValueField="Url" OnSelectedIndexChanged="Nav_SelectedIndexChanged"></asp:ListBox><br />
        &nbsp;
    
    </div>
    </form>
</body>
</html>
