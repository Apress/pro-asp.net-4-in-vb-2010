<%@ Page Language="VB" AutoEventWireup="false"
   CodeFile="AdTest.aspx.vb" Inherits="AdTest" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
   <title>AdTest</title>
</head>
<body>
   <form id="form1" runat="server">
   <div>
      <asp:AdRotator ID="AdRotator1" runat="server"
         Target="_blank" AdvertisementFile="ads.xml"
         OnAdCreated="AdRotator1_AdCreated"></asp:AdRotator>
      <br />
      <br />
      <asp:HyperLink ID="lnkBanner" runat="server">HyperLink</asp:HyperLink>
   </div>
   </form>
</body>
</html>
