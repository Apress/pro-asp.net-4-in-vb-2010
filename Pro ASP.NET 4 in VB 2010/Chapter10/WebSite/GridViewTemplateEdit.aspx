<%@ Page Language="VB" AutoEventWireup="false" CodeFile="GridViewTemplateEdit.aspx.vb"
    Inherits="GridViewTemplateEdit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:SqlDataSource ID="sourceEmployees" runat="server" ConnectionString="<%$ ConnectionStrings:Northwind %>"
            ProviderName="System.Data.SqlClient" SelectCommand="SELECT EmployeeID, FirstName, LastName, Title, City, Country, Notes, Address, Region, PostalCode, HomePhone, TitleOfCourtesy FROM Employees"
            UpdateCommand="UPDATE Employees SET Notes=@Notes WHERE EmployeeID=@EmployeeID">
        </asp:SqlDataSource>
        <asp:GridView ID="gridEmployees" runat="server" CellPadding="4"
            DataSourceID="sourceEmployees" Font-Names="Verdana" Font-Size="Small"
            ForeColor="#333333" GridLines="None" AutoGenerateColumns="False"
            Width="498px" BorderStyle="Groove" DataKeyNames="EmployeeID">
            <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
            <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
            <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
            <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:TemplateField HeaderText="Employees">
                    <ItemTemplate>
                        <b>
                            <%# Eval("EmployeeID") %>
                            -
                            <%# Eval("TitleOfCourtesy") %>
                            <%# Eval("FirstName") %>
                            <%# Eval("LastName") %>
                        </b>
                        <hr />
                        <small><i>
                            <%# Eval("Address") %><br />
                            <%# Eval("City") %>,
                            <%# Eval("Country") %>,
                            <%# Eval("PostalCode") %><br />
                            <%# Eval("HomePhone") %></i>
                            <br />
                            <br />
                            <%# Eval("Notes") %>
                        </small>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <b>
                            <%# Eval("EmployeeID") %>
                            -                       
                            <%# Eval("TitleOfCourtesy") %>                            
                            <%# Eval("FirstName") %>
                            <%# Eval("LastName") %>
                        </b>
                        <hr />
                        <small><i>
                            <%# Eval("Address") %><br />
                            <%# Eval("City") %>,
                            <%# Eval("Country") %>,
                            <%# Eval("PostalCode") %><br />
                            <%# Eval("HomePhone") %></i>
                            <br />
                            <br />
                            <asp:TextBox Text='<%# Bind("Notes") %>' runat="server" ID="textBox"
                                Font-Names="Verdana" Font-Size="XX-Small" Height="40px" TextMode="MultiLine"
                                Width="413px" />
                        </small>
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:CommandField ShowEditButton="true" />
            </Columns>
        </asp:GridView>
    </div>
    </form>
</body>
</html>
