<%@ Page Language="VB" AutoEventWireup="false" CodeFile="CSSStyles.aspx.vb" Inherits="Themes_CSSStyles" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
    <link href="StyleSheet.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Label CssClass="heading1" ID="Label1" runat="server" Text="This Label Uses heading1"></asp:Label>
        <br />
        This is sample unformatted text.<br />
        &nbsp;<br />
        <asp:Label CssClass="heading2" ID="Label2" runat="server" Text="This Label Uses heading2"></asp:Label>
        <br />
        Here's more unformatted text.<br />
        <br />
        &nbsp;<div class="blockText" id="DIV1" runat="server">
            This control uses the blockText style. This control uses the blockText style. This
            control uses the blockText style. This control uses the blockText style.
        </div>
    </div>
    </form>
</body>
</html>
