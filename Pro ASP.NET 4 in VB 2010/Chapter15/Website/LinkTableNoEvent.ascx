<%@ Control Language="VB" AutoEventWireup="false"
   CodeFile="LinkTableNoEvent.ascx.vb" Inherits="LinkTableNoEvent" %>
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
         <asp:GridView id="gridLinkList" runat="server"
           AutoGenerateColumns="false" ShowHeader="false" GridLines="None">
            <Columns>
              <asp:TemplateField>
                <ItemTemplate>
                  <img height="23" src="exclaim.gif"
                    alt="Menu Item" style="vertical-align: middle" />
                  <asp:HyperLink id="lnk" NavigateUrl=
                   '<%# DataBinder.Eval(Container.DataItem, "Url") %>'
                   Font-Names="Verdana" Font-Size="XX-Small" ForeColor="#0000cd"
                   Text='<%# DataBinder.Eval(Container.DataItem, "Text") %>'
                   runat="server" />
                </ItemTemplate>
              </asp:TemplateField>
            </Columns>
          </asp:GridView>
      </td>
   </tr>
</table>
