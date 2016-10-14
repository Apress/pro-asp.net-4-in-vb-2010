<%@ Page Language="VB" AutoEventWireup="false" CodeFile="SqlInjection.aspx.vb" Inherits="SqlInjection" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
     Enter Customer ID: 
    <br />
    <asp:TextBox id="txtID" runat="server">ALFKI</asp:TextBox>
    <br />
	<asp:Button id="cmdGetRecords" 
	  runat="server" Text="Get Records" ></asp:Button>
	<br /><br />
	<asp:GridView id="GridView1" 
	  runat="server" Width="392px" Height="123px" Font-Names="Verdana" Font-Size="X-Small"></asp:GridView>
    </div>
    </form>
</body>
</html>
