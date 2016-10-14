<%@ Page Title="" Language="VB" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage(Of BasicMVCApplication.Product)" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Details
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Details</h2>

    <fieldset>
        <legend>Fields</legend>
        
        <div class="display-label">ProductID</div>
        <div class="display-field"><%: Model.ProductID %></div>
        
        <div class="display-label">ProductName</div>
        <div class="display-field"><%: Model.ProductName %></div>
        
        <div class="display-label">SupplierID</div>
        <div class="display-field"><%: Model.SupplierID %></div>
        
        <div class="display-label">CategoryID</div>
        <div class="display-field"><%: Model.CategoryID %></div>
        
        <div class="display-label">QuantityPerUnit</div>
        <div class="display-field"><%: Model.QuantityPerUnit %></div>
        
        <div class="display-label">UnitPrice</div>
        <div class="display-field"><%: String.Format("{0:F}", Model.UnitPrice) %></div>
        
        <div class="display-label">UnitsInStock</div>
        <div class="display-field"><%: Model.UnitsInStock %></div>
        
        <div class="display-label">UnitsOnOrder</div>
        <div class="display-field"><%: Model.UnitsOnOrder %></div>
        
        <div class="display-label">ReorderLevel</div>
        <div class="display-field"><%: Model.ReorderLevel %></div>
        
        <div class="display-label">Discontinued</div>
        <div class="display-field"><%: Model.Discontinued %></div>
        
    </fieldset>
    <p>

        <%: Html.ActionLink("Edit", "Edit", New With {.id = Model.ProductID})%> |
        <%: Html.ActionLink("Back to List", "Index") %>
    </p>

</asp:Content>

