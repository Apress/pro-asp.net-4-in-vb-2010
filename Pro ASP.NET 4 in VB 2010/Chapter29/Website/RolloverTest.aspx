<%@ Page Language="VB" AutoEventWireup="false"
   CodeFile="RolloverTest.aspx.vb" Inherits="RolloverTest" %>

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
      <cc1:RollOverButton id="RollOverButton1" runat="server"
         Width="134px" Height="36px" MouseOverImageUrl="buttonMouseOver.jpg"
         ImageUrl="buttonOriginal.jpg" OnImageClicked="RollOverButton1_ImageClicked">
      </cc1:RollOverButton>
      <br />
      <br />
      <cc1:RollOverButton id="RollOverButton2" runat="server"
         Width="134px" Height="36px" MouseOverImageUrl="buttonMouseOver.jpg"
         ImageUrl="buttonOriginal.jpg" OnImageClicked="RollOverButton1_ImageClicked">
      </cc1:RollOverButton>
   </div>
   </form>
</body>
</html>
