<%@ Page Language="VB" AutoEventWireup="false"
   CodeFile="HotSpotDemo.aspx.vb" Inherits="HotSpotDemo" %>

<%@ Register TagPrefix="chs" Namespace="CustomHotSpots" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
   <title></title>
</head>
<body>
   <form id="form1" runat="server">
   <div>
      <asp:ImageMap ID="ImageMap1" runat="server" ImageUrl="CoverShot.png">
         <chs:TriangleHotSpot AlternateText="Triangle"
            NavigateUrl="http://en.wikipedia.org/wiki/Windows_Presentation_Foundation"
            X="200" Y="100" Height="150" Width="150" />
      </asp:ImageMap>
   </div>
   </form>
</body>
</html>
