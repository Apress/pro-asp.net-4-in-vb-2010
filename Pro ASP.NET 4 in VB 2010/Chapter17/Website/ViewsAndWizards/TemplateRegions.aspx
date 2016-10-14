<%@ Page Language="VB" AutoEventWireup="false"
   CodeFile="TemplateRegions.aspx.vb" Inherits="TemplateRegions" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
   <title></title>
</head>
<body>
   <form id="form1" runat="server">
   <div>
      <asp:Wizard ID="Wizard1" runat="server" Height="243px"
         Width="437px" BorderColor="Black" 
         BorderStyle="Solid" 
         style="text-align: center; font-size: large">
         <WizardSteps>
            <asp:WizardStep runat="server" Title="Step 1">
               Wizard Step Area
            </asp:WizardStep>
            <asp:WizardStep runat="server" Title="Step 2">
            </asp:WizardStep>
         </WizardSteps>
         <NavigationStyle BackColor="#FFFF66" />
         <SideBarStyle VerticalAlign="Top" 
            BackColor="#CCCCFF" />
         <HeaderStyle BackColor="#CCFFFF" />
         <HeaderTemplate>
            <i>Header Template</i><br />
            <br />
         </HeaderTemplate>
         <SideBarTemplate>
            SideBar Template
            <br />
            <asp:ListView ID="sideBarList" runat="server">
               <LayoutTemplate>
                  <div id="ItemPlaceHolder" runat="server" />
               </LayoutTemplate>
               <ItemTemplate>
                  <asp:LinkButton ID="sideBarButton" runat="server"
                     Text="Button" /><br />
               </ItemTemplate>
            </asp:ListView>
         </SideBarTemplate>
         <StartNavigationTemplate>
            <i>Start Navigation Template</i><br />
            <asp:Button ID="StartPrevButton" runat="server"
               CommandName="MovePrev" Text="Prev" />
            <asp:Button ID="StartNextButton" runat="server"
               CommandName="MoveNext" Text="Next" />
         </StartNavigationTemplate>
         <StepNavigationTemplate>
            <i>Step Navigation Template</i><br />
            <asp:Button ID="StepPreviousButton" runat="server"
               CausesValidation="False" CommandName="MovePrevious"
               Text="Previous" />
            <asp:Button ID="StepNextButton" runat="server"
               CommandName="MoveNext" Text="Next" />
         </StepNavigationTemplate>
         <FinishNavigationTemplate>
            <i>Finish Navigation Template</i><br />
            <asp:Button ID="FinishPreviousButton" runat="server"
               CausesValidation="False" CommandName="MovePrevious"
               Text="Previous" />
            <asp:Button ID="FinishButton" runat="server" CommandName="MoveComplete"
               Text="Finish" />
         </FinishNavigationTemplate>
      </asp:Wizard>
   </div>
   </form>
</body>
</html>
