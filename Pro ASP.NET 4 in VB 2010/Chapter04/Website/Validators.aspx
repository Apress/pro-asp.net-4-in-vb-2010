<%@ Page Language="VB" AutoEventWireup="false"
   CodeFile="Validators.aspx.vb" Inherits="Validators" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" 
"http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
   <title>Validators</title>
   <script type="text/javascript">
      function EmpIDClientValidate(ctl, args) {
         // the value is a multiple of 5 if the module by 5 is 0
         args.IsValid = (args.Value % 5 == 0);
      }
   </script>
   <style type="text/css">
      .style1
      {
         width: 186px;
      }
      .style2
      {
         height: 26px;
         width: 186px;
      }
   </style>
</head>
<body>
   <form id="form1" runat="server">
   <div>
      <table>
         <tr>
            <td class="style1">
               Description
            </td>
            <td />
         </tr>
         <tr>
            <td class="style1">
               Name:
            </td>
            <td>
               <asp:TextBox runat="server" Width="200px" ID="Name" />
               <asp:RequiredFieldValidator runat="server" ID="ValidateName"
                  ControlToValidate="Name" ErrorMessage="Name is required"
                  Display="dynamic">*
               </asp:RequiredFieldValidator>
               <asp:RegularExpressionValidator runat="server"
                  ID="ValidateName2" ControlToValidate="Name"
                  ValidationExpression="[a-z A-Z]*" ErrorMessage="Name cannot contain digits"
                  Display="dynamic">*
               </asp:RegularExpressionValidator>
            </td>
         </tr>
         <tr>
            <td class="style1">
               ID (multiple of 5):
            </td>
            <td>
               <asp:TextBox runat="server" Width="200px" ID="EmpID" />
               <asp:RequiredFieldValidator runat="server" ID="ValidateEmpID"
                  ControlToValidate="EmpID" ErrorMessage="ID is required"
                  Display="dynamic">*
               </asp:RequiredFieldValidator>
               <asp:CustomValidator runat="server" ID="ValidateEmpID2"
                  ControlToValidate="EmpID" ClientValidationFunction="EmpIDClientValidate"
                  ErrorMessage="ID must be a multiple of 5" Display="dynamic"
                  OnServerValidate="ValidateEmpID2_ServerValidate">*
               </asp:CustomValidator>
            </td>
         </tr>
         <tr>
            <td class="style1">
               Day off:<br />
               <small>05/13/11-07/04/11</small>
            </td>
            <td>
               <asp:TextBox runat="server" Width="200px" ID="DayOff" />
               <asp:RequiredFieldValidator runat="server" ID="ValidateDayOff"
                  ControlToValidate="DayOff" ErrorMessage="Day Off is required"
                  Display="dynamic">*
               </asp:RequiredFieldValidator>
               <asp:RangeValidator runat="server" ID="ValidateDayOff2"
                  ControlToValidate="DayOff" MinimumValue="05/13/11"
                  MaximumValue="07/04/11" Type="Date" ErrorMessage="Day Off is not within the valid interval"
                  Display="dynamic" SetFocusOnError="True">*
               </asp:RangeValidator>
            </td>
         </tr>
         <tr>
            <td class="style1">
               Age&nbsp<small>( >= 18 )</small>:
            </td>
            <td>
               <asp:TextBox runat="server" Width="200px" ID="Age" />
               <asp:RequiredFieldValidator runat="server" ControlToValidate="Age"
                  ErrorMessage="Age is required" Display="dynamic"
                  ID="Requiredfieldvalidator1">*
               </asp:RequiredFieldValidator>
               <asp:CompareValidator runat="server" ID="ValidateAge"
                  ControlToValidate="Age" ValueToCompare="18"
                  Type="Integer" Operator="GreaterThanEqual"
                  ErrorMessage="You must be at least 18 years old"
                  Display="dynamic">*
               </asp:CompareValidator>
            </td>
         </tr>
         <tr>
            <td class="style2">
               E-mail:
            </td>
            <td style="height: 26px">
               <asp:TextBox runat="server" Width="200px" ID="Email" />
               <asp:RequiredFieldValidator runat="server" ControlToValidate="Email"
                  ErrorMessage="E-mail is required" Display="dynamic"
                  ID="Requiredfieldvalidator2">*
               </asp:RequiredFieldValidator>
               <asp:RegularExpressionValidator runat="server"
                  ID="ValidateEmail" ControlToValidate="Email"
                  ValidationExpression=".*@.{2,}\..{2,}" ErrorMessage="E-mail is not in a valid format"
                  Display="dynamic">*
               </asp:RegularExpressionValidator>
            </td>
         </tr>
         <tr>
            <td class="style1">
               Password:
            </td>
            <td>
               <asp:TextBox TextMode="Password" runat="server"
                  Width="200px" ID="Password" />
               <asp:RequiredFieldValidator runat="server" ControlToValidate="Password"
                  ErrorMessage="Password is required" Display="dynamic"
                  ID="Requiredfieldvalidator3">            
						<img src="imgError.gif" alt="Missing required field." />
               </asp:RequiredFieldValidator>
            </td>
         </tr>
         <tr>
            <td class="style1">
               Re-enter Password:
            </td>
            <td>
               <asp:TextBox runat="server" TextMode="Password"
                  Width="200px" ID="Password2" />
               <asp:RequiredFieldValidator runat="server" ControlToValidate="Password2"
                  ErrorMessage="Password2 is required" Display="dynamic"
                  ID="Requiredfieldvalidator4">
						<img src="imgError.gif" alt="Missing required field." />
               </asp:RequiredFieldValidator>
               <asp:CompareValidator runat="server" ControlToValidate="Password2"
                  ControlToCompare="Password" Type="String" ErrorMessage="The passwords don't match"
                  Display="dynamic" ID="Comparevalidator1">                      
						<img src="imgError.gif" alt="Fields don't match." />
               </asp:CompareValidator>
            </td>
         </tr>
      </table>
      <br />
      <asp:Button runat="server" Text="Submit" ID="Submit"
         OnClick="Submit_Click" /><br />
      <br />
      <asp:CheckBox runat="server" ID="chkEnableValidators"
         Checked="True" AutoPostBack="True" Text="Validators enabled"
         OnCheckedChanged="OptionsChanged" />
      <br />
      <asp:CheckBox runat="server" ID="chkEnableClientSide"
         Checked="True" AutoPostBack="True" Text="Client-side validation enabled"
         OnCheckedChanged="OptionsChanged" />
      <br />
      <asp:CheckBox runat="server" ID="chkShowSummary"
         Checked="True" AutoPostBack="True" Text="Show summary"
         OnCheckedChanged="OptionsChanged" />
      <br />
      <asp:CheckBox runat="server" ID="chkShowMsgBox"
         Checked="False" AutoPostBack="True" Text="Show message box"
         OnCheckedChanged="OptionsChanged" />
      <asp:ValidationSummary runat="server" ID="Summary"
         DisplayMode="BulletList" HeaderText="Please review the following errors:"
         ShowSummary="true" />
      <br />
      <asp:Label runat="server" ID="Result" ForeColor="magenta"
         Font-Bold="true" EnableViewState="False" />
             <br />
      <br />
      <asp:Button ID="Button1" runat="server" 
         CausesValidation="False" 
         Text="Explicit Validation" Width="164px" />
      <br />
      <asp:Label ID="lblMessage" runat="server"></asp:Label>
   </div>
   </form>
</body>
</html>
