<%@ Page Language="VB" AutoEventWireup="false" CodeFile="TreeViewDB_XML.aspx.vb" Inherits="TreeViewAndMenu_TreeViewDB_XML" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
<link href="Styles.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:TreeView ID="TreeView1" runat="server" DataSourceID="sourceDbXml" >
        </asp:TreeView>
    
    </div>
        <asp:XmlDataSource ID="sourceDbXml" runat="server"></asp:XmlDataSource>
    </form>
</body>
</html>
