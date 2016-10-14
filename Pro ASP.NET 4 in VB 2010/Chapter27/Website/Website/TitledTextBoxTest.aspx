<%@ Page Language="VB" AutoEventWireup="false" CodeFile="TitledTextBoxTest.aspx.vb" Inherits="TitledTextBoxTest" %>
<%@ Register TagPrefix="apress" Namespace="CustomServerControlsLibrary.CustomServerControlsLibrary"
  Assembly="CustomServerControlsLibrary" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
       <apress:TitledTextBox ID="TitledTextBox1" runat="server" Title="Who's a Great Publisher: " 
            Text="Your Answer Here!" BackColor="#FF99CC" />
       <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
    </div>
    </form>
</body>
</html>
