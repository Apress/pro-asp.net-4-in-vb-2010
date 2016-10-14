<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Asymmetric.aspx.vb" Inherits="Asymmetric" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div style="text-align: center">
        <asp:Panel ID="MainPanel" runat="server" BorderStyle="Solid" BorderWidth="1px" Width="100%">
            <table border="0" width="100%">
                <tr>
                    <td style="text-align: left">
                        Step 1:<br />
                        Generate Encryption Key</td>
                    <td style="text-align: left">
                        <asp:LinkButton ID="GenerateKeyCommand" runat="server" >Generate Key</asp:LinkButton><br />
                        <asp:TextBox ID="PublicKeyText" runat="server" Rows="5" TextMode="MultiLine" 
						Columns="40" Width="600px"></asp:TextBox></td>
                </tr>
                <tr>
                    <td style="text-align: left">
                        Step 2:<br />
                        Clear-text data</td>
                    <td style="text-align: left">
                        <asp:TextBox ID="ClearDataText" runat="server" Rows="5" TextMode="MultiLine" 
						Width="600px" Columns="40"></asp:TextBox></td>
                </tr>
                <tr>
                    <td style="text-align: left">
                        Step 3:<br />
                        Encrypted data</td>
                    <td style="text-align: left">
                        <asp:TextBox ID="EncryptedDataText" runat="server" Rows="5" TextMode="MultiLine"
                            Width="600px" Columns="40"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>
                    </td>
                    <td>
                        <asp:LinkButton ID="EncryptCommand" runat="server" >Encrypt</asp:LinkButton>&nbsp;<asp:LinkButton
                            ID="DecryptCommand" runat="server" >Decrypt</asp:LinkButton>&nbsp;<asp:LinkButton
                                ID="ClearCommand" runat="server" >Clear</asp:LinkButton></td>
                </tr>
            </table>
        </asp:Panel>
    
    </div>
    </form>
</body>
</html>
