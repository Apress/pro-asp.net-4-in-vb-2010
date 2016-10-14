﻿<%@ Page Language="VB" AutoEventWireup="false" CodeFile="SimpleStyledRepeaterTest.aspx.vb" Inherits="SimpleStyledRepeaterTest" %>
<%@ Register TagPrefix="apress" Namespace="CustomServerControlsLibrary.CustomServerControlsLibrary"
  Assembly="CustomServerControlsLibrary" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
     <div>     
<apress:SimpleStyledRepeater id="sample" runat="server" repeatcount="10">
  <AlternatingItemStyle Font-Bold="True" BorderStyle="Solid" BorderWidth="1px"
   ForeColor="White" BackColor="Red"></AlternatingItemStyle>
  <HeaderStyle Font-Italic="True" BackColor="#FFFFC0"></HeaderStyle>
  <AlternatingItemTemplate>
    Item <%# Container.Index %> of <%# Container.Total%>
  </AlternatingItemTemplate>

  <ItemTemplate>
    <hr />Item <%# Container.Index %> of <%# Container.Total%><br /><hr />
  </ItemTemplate>
  <HeaderTemplate>
    Now showing <%# Container.Total %> Items for your viewing pleasure.<br />
  </HeaderTemplate> 
</apress:SimpleStyledRepeater>

    </div>
    </form>
</body>
</html>
