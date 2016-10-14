<%@ Page Language="VB" AutoEventWireup="false" CodeFile="SqlDataSourceUpdateStoredProc.aspx.vb" Inherits="SqlDataSourceUpdateStoredProc" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
     <div>
        <asp:SqlDataSource ID="sourceEmployees" runat="server"
         ConnectionString="<%$ ConnectionStrings:Northwind %>"
         SelectCommand="SELECT EmployeeID, FirstName, LastName, TitleOfCourtesy FROM Employees" 
         UpdateCommand="UpdateEmployee" UpdateCommandType="StoredProcedure"
        >           
          <UpdateParameters>
              <asp:Parameter Name="EmployeeID" Type="Int32" />
              <asp:Parameter Name="TitleOfCourtesy" Type="String" />
              <asp:Parameter Name="LastName" Type="String" />
              <asp:Parameter Name="FirstName" Type="String" />
          </UpdateParameters>
        </asp:SqlDataSource>
        <br />
        
        <asp:GridView ID="GridView1" runat="server" DataSourceID="sourceEmployees" CellPadding="4"
         Font-Names="Verdana" Font-Size="Small" ForeColor="#333333" GridLines="None"
         DataKeyNames="EmployeeID" EnableSortingAndPagingCallbacks="True" PageSize="5"
         AutoGenerateEditButton="True">          
            <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
            <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
            <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
            <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
            <AlternatingRowStyle BackColor="White" />               
        </asp:GridView>        
    </div>
    </form>
</body>
</html>
