<%@ Page Language="VB" AutoEventWireup="false" Inherits="Membership.Register" Codebehind="Register.aspx.vb" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>

        <asp:CreateUserWizard ID="RegisterUser" runat="server"
                              BorderStyle="ridge" BackColor="aquamarine" >
            <TitleTextStyle Font-Bold="True" Font-Names="Verdana" />
            <WizardSteps>
                <asp:WizardStep AllowReturn="true" ID="NameStep">
                    Firstname:
                    <asp:TextBox ID="FirstnameText" runat="server" /><br />
                    Lastname:
                    <asp:TextBox ID="LastnameText" runat="server" /><br />
                    Age:
                    <asp:TextBox ID="AgeText" runat="server" />
                </asp:WizardStep>
                <asp:CreateUserWizardStep ID="CreateUserWizardStep1" runat="server">      
                    <ContentTemplate>
                        <div align="right">
                        <font face="Courier New">
                        Username:
                        <asp:TextBox ID="UserName" runat="server" /><br />
                        Password:
                        <asp:TextBox ID="Password" runat="server" TextMode="Password" /><br />
                        Conform Password:
                        <asp:TextBox ID="ConfirmPassword" runat="server" TextMode="Password" /><br />
                        Email: 
                        <asp:TextBox ID="Email" runat="server" /><br />
                        Security Question:
                        <asp:TextBox ID="Question" runat="server" /><br />
                        Security Answer:
                        <asp:TextBox ID="Answer" runat="server" /><br />
                        <asp:Literal ID="ErrorMessage" runat="server" EnableViewState="False" />
                        </font>
                        </div>
                    </ContentTemplate>
                </asp:CreateUserWizardStep>
                <asp:CompleteWizardStep ID="CompleteWizardStep1" runat="server">
                    <ContentTemplate>
                        Your account has been successfully created.</td>
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
