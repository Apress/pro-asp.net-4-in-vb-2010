<%@ Page Language="VB" AutoEventWireup="false" CodeFile="CustomProviderTest.aspx.vb" Inherits= "ComplexTypes" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        This application uses Windows authentication (although you could easily switch it
        to forms authentication, if you supply the required login page and authentication
        logic.<br />
        <br />
        When you first request this page, your user account will not have a matching profile.
        However, when you click Save, the profile provider will create a new record in the
        custom Users table (assuming it exists) with the supplied address information. You
        can then retrieve or update this information on subsequent visits.<br />
        <br />
        <asp:LoginName ID="LoginName1" runat="server" FormatString="Logged in as: {0}" />
        <br />
        <br />
        <table>
            <tr>
                <td style="width: 99px">
                    Name:</td>
                <td>
                    <asp:TextBox ID="txtName" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 99px">
                    Street:</td>
                <td>
                    <asp:TextBox ID="txtStreet" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 99px">
                    City:</td>
                <td>
                    <asp:TextBox ID="txtCity" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 99px">
                    Zip Code:</td>
                <td>
                    <asp:TextBox ID="txtZip" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 99px">
                    State:</td>
                <td>
                    <asp:TextBox ID="txtState" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 99px">
                    Country:</td>
                <td>
                    <asp:TextBox ID="txtCountry" runat="server"></asp:TextBox></td>
            </tr>
        </table>    
        <br />
        <asp:Button ID="cmdGet" runat="server"  Text="Get" />
        <asp:Button ID="cmdSave" runat="server"  Text="Save" />        
    </div>
    </form>
</body>
</html>
