<%@ Control Language="VB" AutoEventWireup="false"
   CodeFile="LinkTable.ascx.vb" Inherits="LinkTable" %>
<table cellpadding="2" width="100%" border="1">
   <tr>
      <td>
         <p style="margin: 8px">
            <asp:Label ID="lblTitle" Font-Size="Small" Font-Names="Verdana"
               Font-Bold="True" ForeColor="#C00000" runat="server">
                    [Title Goes Here]
            </asp:Label></p>
      </td>
   </tr>
   <tr>
      <td>
         <asp:GridView ID="gridLinkList" runat="server"
            OnRowCommand="gridLinkList_RowCommand"  AutoGenerateColumns="false"
            ShowHeader="false" GridLines="None">
            <Columns>
               <asp:TemplateField>
                  <ItemTemplate>
                     <img height="23" src="exclaim.gif" alt="Menu Item"
                        style="vertical-align: middle" />
                     <asp:LinkButton ID="lnk" Font-Names="Verdana"
                        Font-Size="XX-Small" ForeColor="#0000cd" runat="server"
                        Text='<%# DataBinder.Eval(Container.DataItem, "Text") %>'
                           CommandArgument=
                              '<%# DataBinder.Eval(Container.DataItem, "Url") %>'>
                     </asp:LinkButton>
                  </ItemTemplate>
               </asp:TemplateField>
            </Columns>
         </asp:GridView>
      </td>
   </tr>
</table>
