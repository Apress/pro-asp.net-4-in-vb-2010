<%@ Page Title="" Language="VB" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage(Of BasicMVCApplication.Product)" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Create
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Create</h2>

    <%-- The following line works around an ASP.NET compiler warning --%>
    <%: ""%>
    <% Using Html.BeginForm()%>
        <%: Html.ValidationSummary(True) %>
        <fieldset>
            <legend>Fields</legend>
            
            <div class="editor-label">
                <%: Html.LabelFor(Function(model) model.ProductID) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(Function(model) model.ProductID) %>
                <%: Html.ValidationMessageFor(Function(model) model.ProductID) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(Function(model) model.ProductName) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(Function(model) model.ProductName) %>
                <%: Html.ValidationMessageFor(Function(model) model.ProductName) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(Function(model) model.SupplierID) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(Function(model) model.SupplierID) %>
                <%: Html.ValidationMessageFor(Function(model) model.SupplierID) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(Function(model) model.CategoryID) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(Function(model) model.CategoryID) %>
                <%: Html.ValidationMessageFor(Function(model) model.CategoryID) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(Function(model) model.QuantityPerUnit) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(Function(model) model.QuantityPerUnit) %>
                <%: Html.ValidationMessageFor(Function(model) model.QuantityPerUnit) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(Function(model) model.UnitPrice) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(Function(model) model.UnitPrice) %>
                <%: Html.ValidationMessageFor(Function(model) model.UnitPrice) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(Function(model) model.UnitsInStock) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(Function(model) model.UnitsInStock) %>
                <%: Html.ValidationMessageFor(Function(model) model.UnitsInStock) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(Function(model) model.UnitsOnOrder) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(Function(model) model.UnitsOnOrder) %>
                <%: Html.ValidationMessageFor(Function(model) model.UnitsOnOrder) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(Function(model) model.ReorderLevel) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(Function(model) model.ReorderLevel) %>
                <%: Html.ValidationMessageFor(Function(model) model.ReorderLevel) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(Function(model) model.Discontinued) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(Function(model) model.Discontinued) %>
                <%: Html.ValidationMessageFor(Function(model) model.Discontinued) %>
            </div>
            
            <p>
                <input type="submit" value="Create" />
            </p>
        </fieldset>

    <% End Using %>

    <div>
        <%: Html.ActionLink("Back to List", "Index") %>
    </div>

</asp:Content>

