﻿<%@ Page Language="VB" AutoEventWireup="false" CodeFile="TimedRefresh.aspx.vb" Inherits="TimedRefresh" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <img src="lava_lamp.gif" alt="Lava Lamp" /><br />
        <br />
        <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="True">
        </asp:ScriptManager>
        <br />
        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <div style="padding-right: 20px; padding-left: 20px; padding-bottom: 20px; padding-top: 20px;
                    background-color: lightyellow">
                    <asp:Label ID="Label1" runat="server" Font-Bold="True"></asp:Label>
                    <br />
                    This time refreshes automatically every 1 second.<br />
                    <br />
                    <asp:Button ID="Button1" runat="server" Text="Refresh Time" />
                </div>
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="TimerControl1" EventName="Tick" />
            </Triggers>            
        </asp:UpdatePanel>
        
        <asp:Timer ID="TimerControl1" runat="server" Interval="1000" OnTick="TimerControl1_Tick">
        </asp:Timer>
        <br />
        &nbsp; &nbsp;<asp:Label ID="Label2" runat="server" Font-Bold="True"></asp:Label><br />
                    <asp:Button ID="Button2" runat="server" Text="Refresh Time" />
    </div>
    </form>
</body>
</html>
