<%@ Page Language="VB" AutoEventWireup="false" CodeFile="TreeViewDbOnDemand.aspx.vb" Inherits="TreeViewAndMenu_TreeViewDbOnDemand" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
<link href="Styles.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Label ID="lblInfo" runat="server" EnableViewState="False"></asp:Label>
        <br />
        <br />
        <asp:TreeView ID="TreeView1" runat="server" >
        </asp:TreeView>
    <asp:SqlDataSource ID="sourceCategories" runat="server" ConnectionString="<%$ ConnectionStrings:Northwind %>"
            ProviderName="System.Data.SqlClient" SelectCommand="SELECT * FROM Categories"></asp:SqlDataSource>
        <asp:SqlDataSource ID="sourceProducts" runat="server" ConnectionString="<%$ ConnectionStrings:Northwind %>"
            ProviderName="System.Data.SqlClient" SelectCommand="SELECT * FROM Products">
        </asp:SqlDataSource>
    </div>
    </form>
</body>
</html>
