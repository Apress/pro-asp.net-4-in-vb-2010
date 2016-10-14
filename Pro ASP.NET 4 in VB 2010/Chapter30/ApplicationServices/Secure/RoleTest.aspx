﻿<%@ Page Language="VB" AutoEventWireup="false"
   CodeFile="RoleTest.aspx.vb" Inherits="Secure_RoleTest" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
   <title></title>
   <link href="../StyleSheet.css" rel="stylesheet"
      type="text/css" />
   <script type="text/javascript">
      function pageLoad() {
         // The page is loading. Get the current user's roles.
         Sys.Services.RoleService.load(onLoadRolesCompleted, onLoadRolesFailed, null);
      }

      function onLoadRolesCompleted(result, userContext, methodName) {
         // The roles have been retrieved.
         // Test role membership and configure the page.
         if (Sys.Services.RoleService.isUserInRole("Administrator")) {
            $get("adminControls").style.display = "block";
         }
      }

      function onLoadRolesFailed(error, userContext, methodName) {
         alert(error.get_message());
      }
   </script>
</head>
<body>
   <form id="form1" runat="server">
   <div>
      This is standard content for all to see.
   </div>
   <br />
   <div id="adminControls" style="display: none;
      background-color: Lime">
      <b>Only Administrators see this content.</b>
   </div>
   <asp:ScriptManager ID="ScriptManager1" runat="server">
   </asp:ScriptManager>
   </form>
</body>
</html>
