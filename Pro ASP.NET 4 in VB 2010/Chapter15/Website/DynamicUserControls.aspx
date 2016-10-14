<%@ Page Language="VB" AutoEventWireup="false" CodeFile="DynamicUserControls.aspx.vb" Inherits="DynamicUserControls" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
     <div style="border-style: ridge; border-color: inherit; border-width: 1px; 
        padding: 10px; FONT-SIZE: x-small; MARGIN: 10px; WIDTH: 300px; 
        FONT-FAMILY: Verdana; BACKGROUND-COLOR: #F5F5DC; height: 100px;"
			id="div1" runat="server">				
			<asp:DropDownList id="lstControls1" runat="server" Width="215px" AutoPostBack="True">
				<asp:ListItem Value="(None)">(None)</asp:ListItem>
				<asp:ListItem Value="Header.ascx">Header</asp:ListItem>
				<asp:ListItem Value="SimpleTimeDisplay.ascx">SimpleTimeDisplay</asp:ListItem>
			</asp:DropDownList>
			<br />
			<asp:PlaceHolder id="PlaceHolder1" runat="server"></asp:PlaceHolder>
			<br /><br />
			<asp:Label id="PanelLabel1" runat="server" Font-Italic="True" EnableViewState="False">Panel with custom content</asp:Label>
		</div>
    </form>
</body>
</html>
