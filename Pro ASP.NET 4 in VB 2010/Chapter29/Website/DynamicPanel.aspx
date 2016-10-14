<%@ Page Language="VB" AutoEventWireup="false"
   CodeFile="DynamicPanel.aspx.vb" Inherits="DynamicPanel" %>

<%@ Register Assembly="JavaScriptCustomControls"
   Namespace="DynamicControls" TagPrefix="apress" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
   <title></title>
</head>
<body>
   <form id="form1" runat="server">
   <div>
      <apress:DynamicPanel runat="server" ID="Panel1"
         OnRefreshing="Panel1_Refreshing" Style="padding-right: 10px;
         padding-left: 10px; padding-bottom: 10px; padding-top: 10px"
         BorderColor="Red" BorderWidth="2px">
         <br />
         <asp:Label ID="Label1" runat="server" Font-Bold="False"
            Font-Names="Verdana" Font-Size="X-Large"></asp:Label>
         <br />
         <br />
      </apress:DynamicPanel>
      <br />
      <apress:DynamicPanelRefreshLink runat="server"
         ID="link1" PanelID="Panel1">Click To Refresh</apress:DynamicPanelRefreshLink>
   </div>
   </form>
</body>
</html>
