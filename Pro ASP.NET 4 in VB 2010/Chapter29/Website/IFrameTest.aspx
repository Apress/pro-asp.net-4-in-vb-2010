<%@ Page Language="VB" AutoEventWireup="false"
   CodeFile="IFrameTest.aspx.vb" Inherits="IFrameTest" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
   <title></title>
</head>
<body>
   <form id="form1" runat="server">
   <div>
       <iframe id="IFrame1" width="100%" height="100"
         src="page.aspx" frameborder="no" scrolling="no" 
         runat="server" />
      <iframe id="IFrame2" width="100%" height="300"
         src="IncrementalDownloadGrid.aspx" frameborder="yes"
         runat="server" />
   </div>
   </form>
</body>
</html>
