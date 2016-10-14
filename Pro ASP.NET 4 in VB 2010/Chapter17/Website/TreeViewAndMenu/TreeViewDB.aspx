<%@ Page Language="VB" AutoEventWireup="false"
   CodeFile="TreeViewDB.aspx.vb" Inherits="TreeViewAndMenu_TreeViewDB" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
   <title>Untitled Page</title>
</head>
<body>
   <form id="form1" runat="server">
   <div>
      <asp:Label ID="lblInfo" runat="server" EnableViewState="False" />
      <br />
      <br />
      <asp:TreeView ID="TreeView1" runat="server" HoverNodeStyle-Font-Underline="true"
         ShowExpandCollapse="true" NodeIndent="0">
         <LevelStyles>
            <asp:TreeNodeStyle ChildNodesPadding="10" Font-Bold="true"
               Font-Size="12pt" ForeColor="DarkGreen" />
            <asp:TreeNodeStyle ChildNodesPadding="5" Font-Bold="true"
               Font-Size="10pt" />
            <asp:TreeNodeStyle ChildNodesPadding="5" Font-Underline="true"
               Font-Size="10pt" />
         </LevelStyles>
      </asp:TreeView>
      <asp:SqlDataSource ID="sourceCategories" runat="server"
         ConnectionString="<%$ ConnectionStrings:Northwind %>"
         SelectCommand="SELECT * FROM [Categories]" />
   </div>
   </form>
</body>
</html>
