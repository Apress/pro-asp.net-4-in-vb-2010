<%@ Page Language="VB" AutoEventWireup="false" Inherits="MembershipAPI._Default" Codebehind="Default.aspx.vb" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
   <title>Untitled Page</title>
</head>
<body>
   <form id="form1" runat="server">
   <div>
      <asp:GridView ID="UsersGridView" runat="server"
         DataKeyNames="UserName" AutoGenerateColumns="False">
         <Columns>
            <asp:BoundField DataField="UserName" HeaderText="Username" />
            <asp:BoundField DataField="Email" HeaderText="Email" />
            <asp:BoundField DataField="LastActivityDate" HeaderText="Last Activity Date" />
            <asp:CommandField ShowSelectButton="True" />
         </Columns>
      </asp:GridView>
      <br />
      Selected User:<br />
      <table border="1" bordercolor="blue">
         <tr>
            <td>
               Username:
            </td>
            <td>
               <asp:Label ID="UsernameLabel" runat="server" />
            </td>
         </tr>
         <tr>
            <td>
               Email:
            </td>
            <td>
               <asp:TextBox ID="EmailText" runat="server" />
            </td>
         </tr>
         <tr>
            <td>
               Password Question:
            </td>
            <td>
               <asp:Label ID="PwdQuestionLabel" runat="server" />
            </td>
         </tr>
         <tr>
            <td>
               Last Login Date:
            </td>
            <td>
               <asp:Label ID="LastLoginLabel" runat="server" />
            </td>
         </tr>
         <tr>
            <td>
               Comment:
            </td>
            <td>
               <asp:TextBox ID="CommentText" runat="server" TextMode="multiline" />
            </td>
         </tr>
         <tr>
            <td>
               <asp:CheckBox ID="IsApprovedCheck" runat="server"
                  Text="Approved" />
            </td>
            <td>
               <asp:CheckBox ID="IsLockedOutCheck" runat="Server"
                  Text="Locked Out" />
            </td>
         </tr>
      </table>
      <br />
      <asp:Button ID="ActionUpdateUser" runat="server"
         Text="Update User" />
   </div>
   </form>
</body>
</html>
