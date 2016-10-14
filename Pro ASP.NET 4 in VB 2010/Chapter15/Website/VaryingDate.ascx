<%@ Control Language="VB" AutoEventWireup="false" CodeFile="VaryingDate.ascx.vb" Inherits="VaryingDate" %>
<%@ OutputCache Duration="30" VaryByControl="lstMode" %>

<asp:DropDownList ID="lstMode" runat="server" Width="187px">
<asp:ListItem>Large</asp:ListItem>
<asp:ListItem>Small</asp:ListItem>
<asp:ListItem>Medium</asp:ListItem>
</asp:DropDownList>&nbsp;<br />
<asp:Button ID="Button1" Text="Submit" runat="Server" />
<br /><br />

Control generated at:<br />
<asp:Label ID="TimeMsg" runat="server" />