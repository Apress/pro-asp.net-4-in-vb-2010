<%@ Page Language="VB" AutoEventWireup="false" CodeFile="ImageMap.aspx.vb" Inherits="ImageMap" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:ImageMap ID="ImageMap1" runat="server" ImageUrl="CoverShot.png" HotSpotMode="PostBack" >
            <asp:RectangleHotSpot Top="10" Left="10" Bottom="238" Right="292" PostBackValue="Cover" />
            <asp:RectangleHotSpot Top="20" Left="259" Bottom="32" Right="662" PostBackValue="Name" />
            <asp:RectangleHotSpot Top="260" Left="294" 
               Bottom="274" Right="462" 
               PostBackValue="Author" />
        </asp:ImageMap>
        <br />
        <br />
        <asp:Label ID="Label1" runat="server" Style="font-size: x-large" Text="Label"></asp:Label>
    </div>
    </form>
</body>
</html>

