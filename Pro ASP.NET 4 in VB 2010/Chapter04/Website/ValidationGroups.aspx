<%@ Page Language="VB" AutoEventWireup="false" CodeFile="ValidationGroups.aspx.vb" Inherits="ValidationGroups" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" 
"http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Validation Groups</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Panel Height="70px" ID="Panel1" runat="server" 
            Width="255px" BorderWidth="2px">
            <asp:TextBox ID="TextBox1" runat="server" ValidationGroup="Group1" />
            <asp:RequiredFieldValidator ErrorMessage="*Required" ID="RequiredFieldValidator1"
                runat="server" ValidationGroup="Group1" ControlToValidate="TextBox1" />
            <asp:Button ID="Button1" runat="server" Text="Validate Group1"
                ValidationGroup="Group1" />
        </asp:Panel>
        <br />
        <asp:Panel Height="70px" ID="Panel2" runat="server" Width="255px" BorderWidth="2px">
            <asp:TextBox ID="TextBox2" runat="server" ValidationGroup="Group2" />
            <asp:RequiredFieldValidator ErrorMessage="*Required" ID="RequiredFieldValidator2"
                runat="server" ValidationGroup="Group2" ControlToValidate="TextBox2" />
            <asp:Button ID="Button2" runat="server" Text="Validate Group2"
                ValidationGroup="Group2" />
        </asp:Panel>
        <br />
        <asp:Panel Height="70px" ID="Panel3" runat="server" 
            Width="341px" BorderWidth="2px">
            <asp:TextBox ID="TextBox3" runat="server"  />
            <asp:RequiredFieldValidator ErrorMessage="*Required" ID="RequiredFieldValidator3"
                runat="server" ControlToValidate="TextBox3" />
            <asp:Button ID="Button3" runat="server" Text="Validate TextBox3 - No Group" />
        </asp:Panel>
        <br />
        <br />
        <asp:Button ID="cmdValidateAll"
            runat="server" Text="Validate Programmatically" 
            Width="300px" />
       <br />
        <asp:Button ID="cmdNoPgmValidate" 
            runat="server" Text="No Programmatic Validation" 
            Width="300px" />
        <br />
        <br />
        <asp:Label EnableViewState="False" ID="Label1" runat="server"></asp:Label>
    </div>
    </form>
</body>
</html>
