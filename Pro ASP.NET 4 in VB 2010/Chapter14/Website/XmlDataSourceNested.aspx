<%@ Page Language="VB" AutoEventWireup="false" CodeFile="XmlDataSourceNested.aspx.vb"
    Inherits="XmlDataSourceNested" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Nested Grids</title>
    <style type="text/css">
    body {
    font-family: Verdana;
    font-size: small;
    }
    blockquote {
    margin-bottom: 1px;
    margin-top: 1px;
    }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:XmlDataSource ID="sourceDVD" runat="server" DataFile="~/DvdList.xml"></asp:XmlDataSource>
            <asp:GridView ID="gridview1" runat="server" AutoGenerateColumns="False" DataSourceID="sourceDVD"
                BorderStyle="Groove" BorderWidth="2px" CellPadding="4" ForeColor="#333333" GridLines="None"
                Width="279px">
                <Columns>
                    <asp:TemplateField HeaderText="DVD">
                        <ItemTemplate>
                            <b>
                                <%#XPath("Title")%>
                            </b>
                            <br />
                            <%#XPath("Director")%>
                            <br />
                            <br />
                            <i>Starring...</i><br />
                            <blockquote>
                                <asp:GridView ID="GridView2" runat="server" 
                                    AutoGenerateColumns="False" 
                                    DataSource='<%# XPathSelect("Starring/Star") %>'
                                    ShowHeader="False" GridLines="None">
                                    <Columns>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <%#XPath(".")%>
                                                <br />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </blockquote>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <RowStyle BackColor="#EFF3FB" />
                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <EditRowStyle BackColor="#2461BF" />
                <AlternatingRowStyle BackColor="White" />
            </asp:GridView>
        </div>
    </form>
</body>
</html>
