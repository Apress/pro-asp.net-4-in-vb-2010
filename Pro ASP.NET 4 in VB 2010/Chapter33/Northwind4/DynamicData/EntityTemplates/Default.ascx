<%@ Control Language="VB" CodeFile="Default.ascx.vb" Inherits="DefaultEntityTemplate" %>

<asp:EntityTemplate runat="server" ID="EntityTemplate1">
    <ItemTemplate>
        <tr class="td">
            <td class="DDLightHeader">
                <asp:Label ID="Label1" runat="server" Text="Field name:" />
            </td>
            <td>
                <asp:Label ID="Label2" runat="server" OnInit="Label_Init" />
            </td>
            <td class="DDLightHeader">
                <asp:Label ID="Label3" runat="server" Text="Field value:" />
            </td>
            <td>
                <asp:DynamicControl ID="DynamicControl1" 
                runat="server" OnInit="DynamicControl_Init" />
            </td>
        </tr>
    </ItemTemplate>
</asp:EntityTemplate>


