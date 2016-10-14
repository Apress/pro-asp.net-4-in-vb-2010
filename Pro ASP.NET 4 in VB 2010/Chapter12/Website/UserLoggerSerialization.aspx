<%@ Page Language="VB" AutoEventWireup="false" CodeFile="UserLoggerSerialization.aspx.vb" Inherits="UserLoggerSerialization" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
     <asp:Button id="Button1" runat="server"
				Width="90px" Text="Post Back"></asp:Button>			
			<asp:Button id="cmdRead" runat="server"
				Width="90px" Text="Read Log" ></asp:Button>
			<asp:Button id="cmdDelete" runat="server"
			     Width="90px" Text="Delete Log" ></asp:Button>
			
			<br /><br />	
			<div style="padding: 10px;border-style: dotted;border-width: 1px;background-color: #FFFFCC;">
		    <asp:Label id="lblInfo" runat="server"></asp:Label>
		    </div>
    </div>
    </form>
</body>
</html>
