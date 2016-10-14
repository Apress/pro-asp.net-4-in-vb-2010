<%@ Page Language="VB" AutoEventWireup="false"
   CodeFile="Default.aspx.vb" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
   <title>Untitled Page</title>
</head>
<body>
   <form id="form1" runat="server">
   <div>
      <h1>
         Welcome to the provider test application</h1>
      <asp:LoginView runat="server" ID="MainLoginView">
         <AnonymousTemplate>
            <asp:Login ID="MainLogin" runat="server" />
            <p>
               Users: Quiet Urp, Snow White, Robbin Hood</p>
            <p>
               Passwords: aaaaaa&</p>
         </AnonymousTemplate>
         <LoggedInTemplate>
            <asp:LoginStatus ID="MainStatus" runat="server" />
            <asp:Button ID="PostbackCommand" Text="Postback"
               runat="server" OnClick="PostbackCommand_OnClick" />
         </LoggedInTemplate>
      </asp:LoginView>
      <asp:Label ID="ResultsLabel" runat="server" />
   </div>
   </form>
</body>
</html>
