<%@ Page Language="VB" AutoEventWireup="false" CodeFile="DataSetXml.aspx.vb" Inherits="DataSetXml" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>DataSet To XML</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>
                Data from SQL Server</h2>
            <asp:DataGrid ID="Datagrid1" runat="server" HeaderStyle-Font-Bold="true">
            </asp:DataGrid><br />
            <br />
            <h2>
                Data from the XML file</h2>
            <asp:DataGrid ID="Datagrid2" runat="server" HeaderStyle-Font-Bold="true">
            </asp:DataGrid>
        </div>
    </form>
</body>
</html>
