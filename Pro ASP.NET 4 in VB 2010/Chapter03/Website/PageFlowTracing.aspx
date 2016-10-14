<%@ Page Language="VB" AutoEventWireup="false" CodeFile="~/PageFlowTracing.aspx.vb"
    Inherits="PageFlowTracing" Trace="true" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" 
"http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Label ID="lblInfo" runat="server" EnableViewState="False">
        </asp:Label>&nbsp;
        <br />
        <br />
        <asp:Button ID="Button1" runat="server" 
        Text="Button" OnClick="Button1_Click">
        </asp:Button>
        <br />
        <br />
    </div>
    </form>
</body>
</html>
