<%@ Page Language="VB" AutoEventWireup="false" CodeFile="XmlDataSourceXPath.aspx.vb" Inherits="XmlDataSourceXPath" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:XmlDataSource ID="sourceDVD" runat="server" DataFile="~/DvdList.xml" XPath="/DvdList/DVD/Starring/Star">
        </asp:XmlDataSource>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="sourceDVD">
            <Columns>
                <asp:TemplateField>
                    <ItemTemplate>
                        <%# XPath(".")%>
                        <br />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>    
    </div>
    </form>
</body>
</html>
