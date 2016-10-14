<%@ Page Language="VB" AutoEventWireup="false" CodeFile="FileBrowser.aspx.vb" Inherits="FileBrowser" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
     <div
    style="padding: 5px; BORDER-RIGHT: 2px groove; BORDER-TOP: 2px groove; FONT-SIZE: xx-small; Z-INDEX: 101; LEFT: 16px; BORDER-LEFT: 2px groove; BORDER-BOTTOM: 2px groove; FONT-FAMILY: Verdana; "   >
    <asp:Button id="cmdUp"  runat="server"	Width="81px" Text="Move Up..." Height="23px" />
        &nbsp; &nbsp;<asp:label id="lblCurrentDir" runat="server" Font-Italic="True">Currently showing </asp:label><br />
        <br />
        <table style="width: 100%">
            <tr>
                <td valign="top" >
        <asp:GridView ID="gridDirList" runat="server" AutoGenerateColumns="False" 
        Width="418px" GridLines="None" CellPadding="0" CellSpacing="1" DataKeyNames="FullName">
            <HeaderStyle Font-Bold="True" BackColor="#CCFFFF" HorizontalAlign="Left"></HeaderStyle>
            <Columns>
                <asp:TemplateField>
                    <ItemTemplate>
                        <img src="folder.jpg" alt="Folder" />
                    </ItemTemplate>
                    <HeaderStyle Width="20px" />
                </asp:TemplateField>
                <asp:ButtonField DataTextField="Name" CommandName="Select" HeaderText="Name">
                    <HeaderStyle Width="200px" />
                </asp:ButtonField>
                <asp:BoundField HeaderText="Size" >
                    <HeaderStyle Width="50px" />
                </asp:BoundField>
                <asp:BoundField DataField="LastWriteTime" HeaderText="Last Modified" />
            </Columns>
        </asp:GridView>
        <asp:GridView ID="gridFileList" runat="server" AutoGenerateColumns="False"  Width="417px" GridLines="None" CellPadding="0" CellSpacing="1" DataKeyNames="FullName">
             <SelectedRowStyle BackColor="#C0FFFF"></SelectedRowStyle>
        	<HeaderStyle Font-Size="1px"></HeaderStyle>
            <Columns>
              <asp:TemplateField>
							<HeaderStyle Width="20px"></HeaderStyle>
							<ItemTemplate>
								<img src="file.jpg" alt="File" />
							</ItemTemplate>
				</asp:TemplateField>
						<asp:ButtonField DataTextField="Name" CommandName="Select">
							<HeaderStyle Width="200px"></HeaderStyle>
						</asp:ButtonField>
						<asp:BoundField DataField="Length">
							<HeaderStyle Width="50px"></HeaderStyle>
						</asp:BoundField>
						<asp:BoundField DataField="LastWriteTime"></asp:BoundField>
						            </Columns>
        </asp:GridView>
                </td>
               
                <td valign="top">
        <asp:FormView id="formFileDetails" runat="server" Font-Size="XX-Small">
        
					<ItemTemplate>
						<b>File:
							<%# DataBinder.Eval(Container.DataItem, "FullName") %>
						</b>
						<br>
						Created at
						<%# DataBinder.Eval(Container.DataItem, "CreationTime") %>
						<br>
						Last updated at
						<%# DataBinder.Eval(Container.DataItem, "LastWriteTime") %>
						<br>
						Last accessed at
						<%# DataBinder.Eval(Container.DataItem, "LastAccessTime") %>
						<br>
						<i>
							<%# DataBinder.Eval(Container.DataItem, "Attributes") %>
						</i>
						<br>
						<%# DataBinder.Eval(Container.DataItem, "Length") %>
						bytes.
						<hr>
						<%# GetVersionInfoString(DataBinder.Eval(Container.DataItem, "FullName")) %>
					</ItemTemplate>
				</asp:FormView></td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
