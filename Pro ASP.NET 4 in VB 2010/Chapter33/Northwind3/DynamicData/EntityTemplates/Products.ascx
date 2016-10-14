<%@ Control Language="VB" AutoEventWireup="false" CodeFile="Products.ascx.vb" 
   Inherits="DynamicData_EntityTemplates_Products" %>
<tr class="td">
    <td class="DDLightHeader">
        <asp:Label ID="Label1" runat="server" Text="Product Name" />
    </td>
    <td>
        <asp:DynamicControl ID="DynamicControl1" runat="server" DataField="ProductName" />
    </td>
</tr>
<tr class="td">
    <td class="DDLightHeader">
        <asp:Label ID="Label2" runat="server" Text="Price per Unit" />
    </td>
    <td>
        <asp:DynamicControl ID="DynamicControl2" runat="server" DataField="UnitPrice" />
    </td>
</tr>
<tr class="td">
    <td class="DDLightHeader">
        <asp:Label ID="Label3" runat="server" Text="Discontinued?" />
    </td>
    <td>
        <asp:DynamicControl ID="DynamicControl3" runat="server" DataField="Discontinued" />
    </td>
</tr>
<tr class="td">
    <td class="DDLightHeader">
        <asp:Label ID="Label4" runat="server" Text="Units in Stock" />
    </td>
    <td>
        <asp:DynamicControl ID="DynamicControl4" runat="server" DataField="UnitsInStock" />
    </td>
</tr>
