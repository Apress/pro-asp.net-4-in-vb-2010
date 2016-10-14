<%@ Page Language="VB" AutoEventWireup="false"
   CodeFile="AutoCompleteTextBox.aspx.vb" Inherits="AutoCompleteTextBox" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit"
   TagPrefix="asp" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
   <title></title>
   <link href="StyleSheet.css" rel="stylesheet" type="text/css" />
</head>
<body>
   <form id="form1" runat="server">
   <div>
      <asp:ToolkitScriptManager ID="ToolkitScriptManager1"
         runat="server">
      </asp:ToolkitScriptManager>
      Enter at least two letters (such as "Ma").
      <br />
      <br />
        <asp:AutoCompleteExtender ID="autoComplete1" runat="server"
        TargetControlID="txtName" ServiceMethod="GetNames" MinimumPrefixLength="2">
        </asp:AutoCompleteExtender>
      Contact Name:
      <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
   </div>
   </form>
</body>
</html>
