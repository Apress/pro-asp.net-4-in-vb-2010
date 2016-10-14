<%@ Page Title="" Language="VB" MasterPageFile="~/Views/Shared/Site.Master" 
   Inherits="System.Web.Mvc.ViewPage(Of BasicMVCApplication.ExtendedModel.Models.ProductListWrapper)" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent"
   runat="server">
   Edit
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent"
   runat="server">
   <h2>Edit</h2>
   <% Using Html.BeginForm()%>
   <fieldset>
      <legend>Edit Product Details</legend>
      <%= Html.ValidationSummary(
             "Edit was unsuccessful. Please correct the errors and try again."
             )%>
      <table>
         <tr><td>
               Product Name:
         </td><td>
               <%: Html.TextBoxFor(Function(model) model.Product.ProductName)%>
         </td></tr>
         <tr><td>
               Supplier:
         </td><td>
               <%: Html.DropDownListFor(Function(model) model.SelectedSupplier, ViewData("suppliers"))%>
         </td></tr>
         <tr><td>
               Category:
         </td><td>
               <%: Html.DropDownListFor(Function(model) model.SelectedCategory, ViewData("categories"))  %>
         </td></tr>
         <tr><td>
               Quantity per Unit:
         </td><td>
               <%: Html.TextBoxFor(Function(model) model.Product.QuantityPerUnit)%>
         </td></tr>
         <tr><td>
               Unit Price:
         </td><td>
               <%: Html.TextBoxFor(Function(model) model.product.UnitPrice,
                  New With {.Value = String.Format("{0:f2}", Model.product.UnitPrice)})%>
         </td></tr>
         <tr><td>
               Units in Stock:
         </td><td>
               <%: Html.TextBoxFor(Function(model) model.Product.UnitsInStock)%>
         </td></tr>
         <tr><td>
               Units on Order:
         </td><td>
               <%: Html.TextBoxFor(Function(model) model.Product.UnitsOnOrder)%>
         </td></tr>
         <tr><td>
               Reorder Level:
         </td><td>
               <%: Html.TextBoxFor(Function(model) model.Product.ReorderLevel)%>
               <br />
               <%: Html.ValidationMessageFor(Function(model) model.product.ReorderLevel)%>
         </td></tr>
         <tr><td>
               Discontinued:
         </td><td>
               <%: Html.CheckBoxFor(Function(model) model.Product.Discontinued)%>
         </td></tr>
      </table>
   </fieldset>
   <p>
      <input type="submit" value="Save" />
   </p>
   <% End Using%>
   <div>
      <%: Html.ActionLink("Back to List", "Index") %>
   </div>
</asp:Content>
