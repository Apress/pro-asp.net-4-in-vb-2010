<%@ Page Language="VB" AutoEventWireup="false"
   CodeFile="Default.aspx.vb" Inherits="_Default" %>

<%@ Register Src="Customers.ascx" TagName="Customers"
   TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
   <title></title>
</head>
<body>
   <form id="form1" runat="server">
   <div>
      <asp:WebPartManager ID="MyPartManager" runat="server" />
      <table style="width: 100%" >
         <tr valign="middle" style="background: #00ccff">
            <td colspan="2">
               <span style="font-size: 16pt; font-family: Verdana">
                  <strong>Welcome to Web Part pages!</strong>
               </span>
            </td>
            <td style="height: 22px">
            <asp:Menu ID="PartsMenu" runat="server"
                      
                  OnMenuItemClick="PartsMenu_MenuItemClick" 
                  BackColor="#B5C7DE" 
                  DynamicHorizontalOffset="2" 
                  Font-Names="Verdana" Font-Size="0.8em" 
                  ForeColor="#284E98" 
                  StaticSubMenuIndent="10px">
               <DynamicHoverStyle BackColor="#284E98" 
                  ForeColor="White" />
               <DynamicMenuItemStyle HorizontalPadding="5px" 
                  VerticalPadding="2px" />
               <DynamicMenuStyle BackColor="#B5C7DE" />
               <DynamicSelectedStyle BackColor="#507CD1" />
               <StaticHoverStyle BackColor="#284E98" 
                  ForeColor="White" />
               <StaticMenuItemStyle HorizontalPadding="5px" 
                  VerticalPadding="2px" />
               <StaticSelectedStyle BackColor="#507CD1" />
            </asp:Menu>
            </td>
         </tr>
         <tr valign="top">
            <td style="width: 20%">
               <asp:CatalogZone ID="SimpleCatalog" runat="server" >
               <ZoneTemplate>
                  <asp:PageCatalogPart runat="server" ID="MyCatalog" >
                  </asp:PageCatalogPart>
                  </ZoneTemplate>
               </asp:CatalogZone>
            </td>
            <td style="width: 60%">
               <asp:WebPartZone ID="MainZone" 
                  runat="server">
                  <ZoneTemplate>
                     <uc1:Customers ID="Customers1" runat="server" />
                  </ZoneTemplate>

               </asp:WebPartZone>
            </td>
            <td style="width: 20%">
               <asp:WebPartZone ID="HelpZone" runat="server">
                  <ZoneTemplate>
                     <asp:Calendar runat="server" ID="MyCalendar" />
                     <asp:FileUpload ID="FileUpload1" runat="server" />
                  </ZoneTemplate>
               </asp:WebPartZone>
            </td>
         </tr>
      </table>
   </div>
   </form>
</body>
</html>
