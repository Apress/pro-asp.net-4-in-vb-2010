<%@ Page Language="VB" AutoEventWireup="false"
   CodeFile="MenuTemplates.aspx.vb" Inherits="TreeViewAndMenu_MenuTemplates" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
   <title>Untitled Page</title>
</head>
<body>
   <form id="form1" runat="server">
   <div>
      <asp:Menu ID="Menu1" runat="server" DataSourceID="SiteMapDataSource1">
         <StaticItemTemplate>
            <%# Eval("Text") %><br />
            <small>
               <%#GetDescriptionFromTitle(DirectCast(Container.DataItem, MenuItem).Text)%></small>
         </StaticItemTemplate>
         <DynamicItemTemplate>
            <%# Eval("Text") %><br />
            <small>
               <%#GetDescriptionFromTitle(DirectCast(Container.DataItem, MenuItem).Text)%></small>
         </DynamicItemTemplate>
      </asp:Menu>
      <asp:SiteMapDataSource ID="SiteMapDataSource1"
         runat="server" />
   </div>
   </form>
</body>
</html>
