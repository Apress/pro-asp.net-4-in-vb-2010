<%@ Page Language="VB" AutoEventWireup="false" CodeFile="XmlDataSourceSimple.aspx.vb"
    Inherits="XmlDataSourceSimple" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:XmlDataSource ID="XmlDataSimple" runat="server" DataFile="DvdList.xml" />
        <asp:GridView ID="GridView1" runat="server" DataSourceID="sourceDVD" />
    </div>
    <div>
        <asp:XmlDataSource ID="sourceDVD" runat="server" DataFile="DvdList.xml">
        </asp:XmlDataSource>
        <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False"
            DataSourceID="sourceDVD">
            <Columns>
                <asp:BoundField DataField="ID" 
                    HeaderText="ID" SortExpression="ID" />
                <asp:BoundField DataField="Category" 
                    HeaderText="Category" SortExpression="Category" />
            </Columns>
        </asp:GridView>
    </div>
    </form>
</body>
</html>
