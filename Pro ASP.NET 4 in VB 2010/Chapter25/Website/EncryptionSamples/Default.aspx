<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Default.aspx.vb" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <asp:LoginView runat="server" ID="MainLoginView">
        <AnonymousTemplate>
            <asp:Login ID="MainLogin" runat="server" />
            <br />
            Users in database: MeTwo, MeThree, MeFour
            <br />
            Password: aaaaaa&
        </AnonymousTemplate>
        <LoggedInTemplate>
            Credit Card: <asp:TextBox ID="CreditCardText" runat="server" /><br />
            Street: <asp:TextBox ID="StreetText" runat="server" /><br />
            Zip Code: <asp:TextBox ID="ZipCodeText" runat="server" /><br />
            City: <asp:TextBox ID="CityText" runat="server" /><br />
            <asp:Button runat="server" ID="LoadCommand" Text="Load" OnClick="LoadCommand_Click" />&nbsp;
            <asp:Button runat="server" ID="SaveCommand" Text="Save" OnClick="SaveCommand_Click" />
        </LoggedInTemplate>
    </asp:LoginView>
    </div>
    </form>
</body>
</html>
