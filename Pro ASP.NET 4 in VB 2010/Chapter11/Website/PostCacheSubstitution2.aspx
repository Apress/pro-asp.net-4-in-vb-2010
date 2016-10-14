<%@ Page Language="VB" AutoEventWireup="false" CodeFile="PostCacheSubstitution2.aspx.vb" Inherits="PostCacheSubstitution2" %>

<%@ OutputCache Duration="60" VaryByParam="None" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.1//EN" "http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        This date is cached with the page:
       <asp:Label ID="lblDate" runat="server"></asp:Label><br />
		This date is not:
		   
        <asp:Substitution ID="Substitution1" runat="server" MethodName="GetDate" />
        <br />
        <br />
        <asp:Button ID="Button1" runat="server" Text="Refresh" />
    </div>
    </form>
</body>
</html>
