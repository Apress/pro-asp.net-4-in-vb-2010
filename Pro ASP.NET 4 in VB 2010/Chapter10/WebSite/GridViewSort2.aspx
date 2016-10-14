<%@ Page Language="VB" AutoEventWireup="false" CodeFile="GridViewSort2.aspx.vb" Inherits="GridViewSort2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
   <div style="font-size: smaller; font-family: Verdana">
        <asp:ObjectDataSource ID="sourceEmployees" runat="server" SelectMethod="GetEmployees"
            TypeName="DatabaseComponent.DatabaseComponent.EmployeeDB" SortParameterName="sortExpression"></asp:ObjectDataSource>
            
        Choose a sort mode:&nbsp;<asp:DropDownList ID="lstSorts" runat="server" Font-Names="Verdana" AutoPostBack="True" Width="309px">
            <asp:ListItem>EmployeeID</asp:ListItem>
            <asp:ListItem>LastName, FirstName</asp:ListItem>
            <asp:ListItem>TitleOfCourtesy, FirstName, LastName</asp:ListItem>
        </asp:DropDownList><br />
        <br />
        <asp:GridView ID="gridEmployees" runat="server" CellPadding="4" DataSourceID="sourceEmployees"
            Font-Names="Verdana" Font-Size="Small" ForeColor="#333333" GridLines="None"
             
              PageSize="2" AutoGenerateColumns="False" Width="454px">
            <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
            <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
            <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
            <HeaderStyle BackColor="BurlyWood" Font-Bold="True" ForeColor="White" />
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField DataField="EmployeeID" HeaderText="EmployeeID" SortExpression="EmployeeID" />
                <asp:BoundField DataField="FirstName" HeaderText="FirstName" SortExpression="FirstName" />
                <asp:BoundField DataField="LastName" HeaderText="LastName" SortExpression="LastName" />
                <asp:BoundField DataField="TitleOfCourtesy" HeaderText="TitleOfCourtesy" SortExpression="TitleOfCourtesy" />
            </Columns>
        </asp:GridView>
    </div>
    </form>
</body>
</html>
