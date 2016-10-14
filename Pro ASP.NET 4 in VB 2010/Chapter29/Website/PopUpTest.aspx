<%@ Page Language="VB" AutoEventWireup="false"
   CodeFile="PopUpTest.aspx.vb" Inherits="PopUpTest" %>
<%@ Register Assembly="JavaScriptCustomControls"
 Namespace="CustomServerControlsLibrary" TagPrefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
   <title></title>
</head>
<body>
   <form id="form1" runat="server">
   <div>
      <cc1:PopUp id="PopUp1" runat="server" url="PopUpAd.aspx"
         scrollbars="True" resizable="True" />
   </div>
   </form>
</body>
</html>
