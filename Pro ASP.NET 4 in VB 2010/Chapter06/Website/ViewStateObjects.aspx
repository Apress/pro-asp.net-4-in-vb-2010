<%@ Page Language="VB" AutoEventWireup="false" CodeFile="ViewStateObjects.aspx.vb" Inherits="ViewStateObjects" %>
<%--Copy into the statement above to turn Trace on.--%>
<%--Trace="true"--%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <table>
		    <tr>
			    <th>Description</th>
			    <th>Value</th>
		    </tr>
		    <tr>
			    <td>Name:</td>
			    <td>
				    <asp:TextBox runat="server" Width="200px" ID="Name" />
			    </td>
		    </tr>
		    <tr>
			    <td>ID:</td>
			    <td>
				    <asp:TextBox runat="server" Width="200px" ID="EmpID" />
			    </td>
		    </tr>
		    <tr>
			    <td>Age:</td>
			    <td>
				    <asp:TextBox runat="server" Width="200px" ID="Age" />
			    </td>
		    </tr>
		    <tr>
			    <td>E-mail:</td>
			    <td>
				    <asp:TextBox runat="server" Width="200px" ID="Email" />
			    </td>
		    </tr>
		    <tr>
			    <td>Password:</td>
			    <td>
				    <asp:TextBox TextMode="Password" runat="server" Width="200px" ID="Password" />
			    </td>
		    </tr>
		</table>
		<br />
		<asp:Button runat="server" Text="Save" ID="cmdSave"  />&nbsp;
		<asp:Button id="cmdRestore" runat="server" Text="Restore" ></asp:Button><br />
        <br />
        <asp:Label ID="lblResults" runat="server"></asp:Label>
    </div>
    </form>
</body>
</html>
