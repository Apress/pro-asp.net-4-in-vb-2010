<%@ Page Language="VB" AutoEventWireup="false"
   CodeFile="MultipleViews.aspx.vb" Inherits="ViewsAndWizards_MultipleViews" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
   <title>Untitled Page</title>
</head>
<body>
   <form id="form1" runat="server">
   <div>
      <asp:DropDownList ID="DropDownList1" runat="server"
         Width="235px" AutoPostBack="True">
      </asp:DropDownList>
      <hr />
      <br />
      <asp:MultiView ID="MultiView1" runat="server"
         ActiveViewIndex="0">
         <asp:View ID="View1" runat="server">
            <b>Showing View #1</b><br />
            <br />
            <asp:Image ID="Image1" runat="server" ImageUrl="~/cookies.jpg" />
            <br />
            <br />
            <asp:Button ID="cmdView1Next" runat="server" Text="Next >"
               CommandName="NextView" />
         </asp:View>
         <asp:View ID="View2" runat="server">
            <b>Showing View #2</b><br />
            <br />
            Text content.
            <asp:Button ID="View2Prev" runat="server" Text="< Prev"
               CommandName="PrevView" />
            <asp:Button ID="View2Next" runat="server" Text="Next >"
               CommandName="NextView" />
         </asp:View>
         <asp:View ID="View3" runat="server">
            <b>Showing View #3</b><br />
            <br />
            <asp:Calendar ID="Calendar1" runat="server"></asp:Calendar>
            <asp:Button ID="View3Prev" runat="server" Text="< Prev"
               CommandName="PrevView" />
         </asp:View>
      </asp:MultiView>
   </div>
   </form>
</body>
</html>
