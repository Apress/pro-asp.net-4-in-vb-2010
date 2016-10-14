<%@ Page Language="VB" AutoEventWireup="false" CodeFile="CrossPageSource.aspx.vb"
    Inherits="CrossPageSource" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>CrossPage1</title>
</head>
<body>
    <form ID="form1" runat="server">
    <div>
        Type something here:
        <asp:TextBox runat="server" ID="txt1"></asp:TextBox>
        &nbsp;
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
            ControlToValidate="txt1" EnableClientScript="False" 
            ErrorMessage="This is a required field."></asp:RequiredFieldValidator><br />
        <br />
        <asp:Button runat="server" ID="cmdPost" PostBackUrl="CrossPageTarget.aspx"
            Text="Cross-Page Postback" />
        <asp:Button runat="server" ID="cmdTransfer" Text="Manual Transfer" />
    </div>
    </form>
</body>
</html>
