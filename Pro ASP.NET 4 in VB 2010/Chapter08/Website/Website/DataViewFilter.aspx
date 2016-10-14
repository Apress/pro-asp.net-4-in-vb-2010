<%@ Page Language="VB" AutoEventWireup="false" CodeFile="DataViewFilter.aspx.vb" Inherits="DataViewFilter" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>DataViewFilter</title>
</head>
<body>
    <form method="post" runat="server" ID="Form1">
    <div>
			Filter = <b>"ProductName = 'Chocolade' "</b>
			<br /><br />
			<asp:GridView runat="server" ID="Datagrid1" HeaderStyle-Font-Bold="true" />
			<br />
			Filter = <b>"UnitsInStock = 0 AND UnitsOnOrder = 0"</b>
			<br /><br />
			<asp:GridView runat="server" ID="Datagrid2" HeaderStyle-Font-Bold="true" />
			<br />
			Filter = <b>"ProductName LIKE 'P%'"</b>
			<br /><br />
			<asp:GridView runat="server" ID="Datagrid3" HeaderStyle-Font-Bold="true" />
		</div>		
    </form>
</body>
</html>
