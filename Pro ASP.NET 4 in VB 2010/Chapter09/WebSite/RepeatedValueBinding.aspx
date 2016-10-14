<%@ Page Language="VB" AutoEventWireup="false" CodeFile="RepeatedValueBinding.aspx.vb" Inherits="RepeatedValueBinding" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <table width="100%">
		<tr>
			<td>
				<select runat="server" ID="Select1" size="3" DataTextField="Key" DataValueField="Value"
					name="Select1"></select>
			</td>
			<td>
				<select runat="server" ID="Select2" DataTextField="Key" DataValueField="Value" name="Select2"></select>
			</td>
			<td>
				<asp:ListBox runat="server" ID="Listbox1" Size="3" DataTextField="Key" DataValueField="Value" />
			</td>
			<td>
				<asp:DropDownList runat="server" ID="DropdownList1" DataTextField="Key" DataValueField="Value" />
			</td>
			<td>
				<asp:RadioButtonList runat="server" ID="OptionList1" DataTextField="Key" DataValueField="Value" />
			</td>
			<td>
				<asp:CheckBoxList runat="server" ID="CheckList1" DataTextField="Key" DataValueField="Value" />
			</td>
		</tr>
	</table>
	<asp:Button runat="server" Text="Get Selection" ID="cmdGetSelection"  />
	
	<br /><br />
	<asp:Literal runat="server" ID="Result" EnableViewState="False" />
    </div>
    </form>
</body>
</html>
