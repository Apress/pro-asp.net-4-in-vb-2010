<%@ Page Language="VB" AutoEventWireup="false" CodeFile="GridViewFormattingEvents.aspx.vb" Inherits="GridViewFormattingEvents" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
     <div>
        <asp:SqlDataSource ID="sourceEmployees" runat="server" ProviderName="System.Data.SqlClient" ConnectionString="<%$ ConnectionStrings:Northwind %>" SelectCommand="SELECT EmployeeID, FirstName, LastName, TitleOfCourtesy, City FROM Employees" ></asp:SqlDataSource>
        <br />
        
        <asp:GridView ID="gridEmployees" runat="server" DataSourceID="sourceEmployees"
         Font-Names="Verdana" Font-Size="Small" GridLines="Horizontal" AutoGenerateColumns="False"
          DataKeyNames="EmployeeID" EnableSortingAndPagingCallbacks="True" PageSize="5"
           HorizontalAlign="Justify" >
            <HeaderStyle BorderColor="Black" BorderStyle="Solid" BorderWidth="2px" BackColor="Bisque" HorizontalAlign="Left" />
            
            <Columns>
                <asp:BoundField DataField="EmployeeID" HeaderText="ID" InsertVisible="False"
                    ReadOnly="True" SortExpression="EmployeeID" >
                    <ItemStyle HorizontalAlign="Left" Width="75px" />
                </asp:BoundField>
                <asp:BoundField DataField="FirstName" HeaderText="First Name" SortExpression="FirstName" >
                    <ItemStyle Width="100px" />
                </asp:BoundField>
                <asp:BoundField DataField="LastName" HeaderText="Last Name" SortExpression="LastName" >
                    <ItemStyle Width="100px" />
                </asp:BoundField>
                <asp:BoundField DataField="TitleOfCourtesy" HeaderText="Title Of Courtesy" SortExpression="TitleOfCourtesy" >
                    <ItemStyle Width="75px" />
                </asp:BoundField>
                <asp:BoundField DataField="City" HeaderText="City" SortExpression="City" >
                    <ItemStyle Width="100px" />
                </asp:BoundField>
            </Columns>
        </asp:GridView>  
    </div>
    </form>
</body>
</html>
