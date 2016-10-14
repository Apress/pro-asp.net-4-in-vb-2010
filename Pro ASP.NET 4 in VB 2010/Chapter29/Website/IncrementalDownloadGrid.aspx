﻿<%@ Page Language="VB" AutoEventWireup="false"
   CodeFile="IncrementalDownloadGrid.aspx.vb"
   Inherits="IncrementalDownloadGrid" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
   <title></title>
    <script type="text/javascript">
       function GetBookImage(img, url) {
          // Detach the event handler (we'll make just one attempt).
          img.onload = null;
          // Try to get the picture.
          img.src = 'GetBookImage.aspx?isbn=' + url;
       }
</script>
</head>
<body>
   <form id="form1" runat="server">
   <div>
      <asp:GridView ID="DataGrid1" runat="server" AutoGenerateColumns="False"
         BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px"
         BackColor="White" CellPadding="4" Font-Names="Verdana"
         Width="100%" Font-Size="X-Small">
         <SelectedRowStyle Font-Bold="True" ForeColor="#663399"
            BackColor="#FFCC66"></SelectedRowStyle>
         <RowStyle ForeColor="#330099" BackColor="White">
         </RowStyle>
         <HeaderStyle Font-Bold="True" ForeColor="#FFFFCC"
            BackColor="#990000"></HeaderStyle>
         <FooterStyle ForeColor="#330099" BackColor="#FFFFCC">
         </FooterStyle>
         <Columns>
            <asp:BoundField DataField="Title" HeaderText="Title">
            </asp:BoundField>
            <asp:BoundField DataField="isbn" HeaderText="ISBN">
            </asp:BoundField>
            <asp:BoundField DataField="Publisher" HeaderText="Publisher">
            </asp:BoundField>
            <asp:TemplateField>
               <HeaderTemplate>
                  Book Cover
               </HeaderTemplate>
               <ItemTemplate>
                  <img src="UnknownBook.gif" alt="Book" onerror="this.src='Unknownbook.gif';"
                     onload="GetBookImage(this, '<%# DataBinder.Eval(Container.DataItem, "isbn") %>');">
               </ItemTemplate>
            </asp:TemplateField>
         </Columns>
      </asp:GridView>
   </div>
   </form>
</body>
</html>
