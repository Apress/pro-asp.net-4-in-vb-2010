<%@ Page Language="VB" AutoEventWireup="true" CodeFile="ImagesFromDatabase.aspx.vb" Inherits="ImagesFromDatabase" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:GridView id="GridView" runat="server" Font-Names="Verdana" Font-Size="X-Small" DataSourceID="SqlDataSource1">
            <Columns>
                <asp:TemplateField>
                <ItemTemplate>
    			<table border='1'>
						<tr>
							<td>
                            <img src='ImageFromDB.ashx?ID=<%# DataBinder.Eval(Container.DataItem, "pub_id") %>' alt="Logo" />
                            </td>
						</tr>
					</table>
					<b>
						<%# Eval("pub_name") %>
					</b>
					<br>
					<%# Eval("city") %>
					,
					<%# Eval("state") %>
					,
					<%# Eval("country") %>
					<br>
					<br>
				</ItemTemplate>	
            </asp:TemplateField>
            </Columns>
		</asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" 
         ConnectionString="<%$ ConnectionStrings:Pubs %>"
          SelectCommand="SELECT * FROM publishers"
        runat="server"></asp:SqlDataSource>
    </div>
    </form>
</body>
</html>
