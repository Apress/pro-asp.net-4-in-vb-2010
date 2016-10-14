<%@ Page Language="VB" AutoEventWireup="false" Inherits="Membership.CreateUser" Codebehind="CreateUser.aspx.vb" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
   <title></title>
</head>
<body>
   <form id="form1" runat="server">
   <div>
      <asp:CreateUserWizard ID="RegisterUser" runat="server"
         BorderStyle="ridge" BackColor="aquamarine">
         <TitleTextStyle Font-Bold="true" Font-Names="Verdana" />
         <%-- <WizardSteps>
             <asp:CreateUserWizardStep runat="server" />
             <asp:CompleteWizardStep runat="server" />
          </WizardSteps>
         --%>
         <WizardSteps>
            <asp:WizardStep ID="NameStep" AllowReturn="true">
               Firstname:
               <asp:TextBox ID="FirstnameText" runat="server" /><br />
               Lastname:
               <asp:TextBox ID="LastnameText" runat="server" /><br />
               Age:
               <asp:TextBox ID="AgeText" runat="server" />
            </asp:WizardStep>
            <asp:CreateUserWizardStep ID="CreateUserWizardStep1"
               runat="server">
            </asp:CreateUserWizardStep>
            <asp:CompleteWizardStep runat="server">
               <ContentTemplate>
                  Your account has been successfully created.
                  <asp:Button ID="ContinueButton" CommandName="Continue"
                     runat="server" Text="Continue" />
               </ContentTemplate>
            </asp:CompleteWizardStep>
         </WizardSteps>
      </asp:CreateUserWizard>
   </div>
   </form>
</body>
</html>
