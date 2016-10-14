<%@ Page Language="VB" AutoEventWireup="false" CodeFile="NavigationList.aspx.vb"
    Inherits="NavigationAdvanced_NavigationList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:SiteMapDataSource ID="SiteMapDataSource1" runat="server" ShowStartingNode="false"
                StartFromCurrentNode="true" />
            <asp:GridView ID="listNavLinks" runat="server" DataSourceID="SiteMapDataSource1"
                AutoGenerateColumns="false" ShowHeader="false" BackColor="Linen" CellPadding="5">
                <Columns>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <a href='<%# Eval("Url") %>' target='<%# Eval("[target]") %>'>
                                <%# Eval("Title") %>
                            </a>
                            <br />
                            <p style="margin: 0px; font-size: x-small;">
                                <%# Eval("Description") %>
                            </p>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            &nbsp;
            <br />
            <asp:LinkButton ID="cmdUp" runat="server">Go Up</asp:LinkButton>
        </div>
    </form>
</body>
</html>
