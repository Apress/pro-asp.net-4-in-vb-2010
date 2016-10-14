<%@ Control Language="VB" AutoEventWireup="false"
   CodeFile="Customers.ascx.vb" Inherits="Customers" %>
<asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False"
   DataKeyNames="CustomerID" DataSourceID="SqlDataSource1"
   EmptyDataText="There are no data records to display."
   AllowPaging="True" AllowSorting="True" 
   PageSize="5" BackColor="#CCCCCC" 
   BorderColor="#999999" BorderStyle="Solid" 
   BorderWidth="3px" CellPadding="4" 
   CellSpacing="2" ForeColor="Black">
   <Columns>
      <asp:BoundField DataField="CustomerID" HeaderText="ID"
         ReadOnly="True" 
         SortExpression="CustomerID" />
      <asp:BoundField DataField="CompanyName" HeaderText="Company"
         SortExpression="CompanyName" />
      <asp:BoundField DataField="ContactFirstname" HeaderText="First Name"
         SortExpression="ContactFirstname" />
      <asp:BoundField DataField="ContactLastname" HeaderText="Last Name"
         SortExpression="ContactLastname" />
      <asp:BoundField DataField="PhoneNumber" HeaderText="Phone"
         SortExpression="PhoneNumber" />
      <asp:BoundField DataField="EmailAddress" 
         HeaderText="Email" 
         SortExpression="EmailAddress" />
      <asp:BoundField DataField="WebSite"
         HeaderText="WebSite" 
         SortExpression="WebSite" />
      <asp:BoundField DataField="Address" HeaderText="Address"
         SortExpression="Address" 
         Visible="False" />
      <asp:BoundField DataField="ZipCode" 
         HeaderText="ZipCode" 
         SortExpression="ZipCode" Visible="False" />
      <asp:BoundField DataField="City" 
         HeaderText="City" SortExpression="City" 
         Visible="False" />
      <asp:BoundField DataField="Country" 
         HeaderText="Country" 
         SortExpression="Country" Visible="False" />
   </Columns>
   <FooterStyle BackColor="#CCCCCC" />
   <HeaderStyle BackColor="Black" 
      Font-Bold="True" ForeColor="White" />
   <PagerStyle BackColor="#CCCCCC" 
      ForeColor="Black" HorizontalAlign="Left" />
   <RowStyle BackColor="White" />
   <SelectedRowStyle BackColor="#000099" 
      Font-Bold="True" ForeColor="White" />
   <SortedAscendingCellStyle BackColor="#F1F1F1" />
   <SortedAscendingHeaderStyle BackColor="#808080" />
   <SortedDescendingCellStyle BackColor="#CAC9C9" />
   <SortedDescendingHeaderStyle BackColor="#383838" />
</asp:GridView>
<asp:SqlDataSource ID="SqlDataSource1" runat="server"
   ConnectionString="<%$ ConnectionStrings:WebPartsTestConnectionString1 %>"
   DeleteCommand="DELETE FROM [Customer] WHERE [CustomerID] = @CustomerID"
   InsertCommand="INSERT INTO [Customer] ([CustomerID], [CompanyName], [ContactFirstname], [ContactLastname], [PhoneNumber], [EmailAddress], [Address], [ZipCode], [City], [Country], [WebSite]) VALUES (@CustomerID, @CompanyName, @ContactFirstname, @ContactLastname, @PhoneNumber, @EmailAddress, @Address, @ZipCode, @City, @Country, @WebSite)"
   ProviderName="<%$ ConnectionStrings:WebPartsTestConnectionString1.ProviderName %>"
   SelectCommand="SELECT [CustomerID], [CompanyName], [ContactFirstname], [ContactLastname], [PhoneNumber], [EmailAddress], [Address], [ZipCode], [City], [Country], [WebSite] FROM [Customer]"
   UpdateCommand="UPDATE [Customer] SET [CompanyName] = @CompanyName, [ContactFirstname] = @ContactFirstname, [ContactLastname] = @ContactLastname, [PhoneNumber] = @PhoneNumber, [EmailAddress] = @EmailAddress, [Address] = @Address, [ZipCode] = @ZipCode, [City] = @City, [Country] = @Country, [WebSite] = @WebSite WHERE [CustomerID] = @CustomerID">
   <DeleteParameters>
      <asp:Parameter Name="CustomerID" Type="String" />
   </DeleteParameters>
   <InsertParameters>
      <asp:Parameter Name="CustomerID" Type="String" />
      <asp:Parameter Name="CompanyName" Type="String" />
      <asp:Parameter Name="ContactFirstname" Type="String" />
      <asp:Parameter Name="ContactLastname" Type="String" />
      <asp:Parameter Name="PhoneNumber" Type="String" />
      <asp:Parameter Name="EmailAddress" Type="String" />
      <asp:Parameter Name="Address" Type="String" />
      <asp:Parameter Name="ZipCode" Type="String" />
      <asp:Parameter Name="City" Type="String" />
      <asp:Parameter Name="Country" Type="String" />
      <asp:Parameter Name="WebSite" Type="String" />
   </InsertParameters>
   <UpdateParameters>
      <asp:Parameter Name="CompanyName" Type="String" />
      <asp:Parameter Name="ContactFirstname" Type="String" />
      <asp:Parameter Name="ContactLastname" Type="String" />
      <asp:Parameter Name="PhoneNumber" Type="String" />
      <asp:Parameter Name="EmailAddress" Type="String" />
      <asp:Parameter Name="Address" Type="String" />
      <asp:Parameter Name="ZipCode" Type="String" />
      <asp:Parameter Name="City" Type="String" />
      <asp:Parameter Name="Country" Type="String" />
      <asp:Parameter Name="WebSite" Type="String" />
      <asp:Parameter Name="CustomerID" Type="String" />
   </UpdateParameters>
</asp:SqlDataSource>
