<%@ Page Language="VB" AutoEventWireup="false" CodeFile="SimpleTypes.aspx.vb" Inherits="SimpleTypes" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table >
            <tr>
                <td style="width: 99px" >
                    First Name:
                </td>
                <td >
                    <asp:TextBox ID="txtFirst" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 99px" >
                    Last Name:</td>
                <td >
                    <asp:TextBox ID="txtLast" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 99px; height: 182px" >
                    Date of Birth:&nbsp;
                </td>
                <td style="height: 182px"  >
                    <asp:Calendar ID="Calendar1" runat="server"></asp:Calendar>
                </td>
            </tr>
        </table>
        <br />
        <br />
        <asp:Button ID="cmdShow" runat="server" Text="Show Profile Data" />&nbsp;
        <asp:Button ID="cmdSet" runat="server" Text="Set Profile Data" /><br />
        <br />
        <br />
        &nbsp;<div style="background-color:Lime; border-right: 2px solid; border-top: 2px solid; border-left: 2px solid; border-bottom: 2px solid;">
        <asp:Label ID="lbl" runat="server" EnableViewState="False" Font-Bold="True"></asp:Label></div>    
    </div>
    </form>
</body>
</html>
