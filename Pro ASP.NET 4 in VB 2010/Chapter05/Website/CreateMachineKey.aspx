<%@ Page Language="VB" AutoEventWireup="false" 
CodeFile="CreateMachineKey.aspx.vb" Inherits="CreateMachineKey" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" 
"http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Create a Machine Key</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>    
        <asp:Button ID="CreateKey" runat="server" 
            Text="Create a Machine Key" />
            <br /><br />
        <asp:Label ID="Label1" runat="server" Text="Key Length:  " />
        <asp:TextBox ID="KeyLength" runat="server">128</asp:TextBox>
                   <br /><br />
        <asp:Label ID="theKey" runat="server" Text="N/A" />
    </div>
    </form>
</body>
</html>
