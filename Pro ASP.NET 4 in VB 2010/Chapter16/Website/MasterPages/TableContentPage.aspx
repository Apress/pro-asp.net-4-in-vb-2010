<%@ Page Language="VB" MasterPageFile="TableMaster.master" AutoEventWireup="false"
    CodeFile="TableContentPage.aspx.vb" Inherits="MasterPages_TableContentPage" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    Your content goes in this cell.<br />
    <asp:Button ID="cmdShow" runat="server" Text="Show"  />
    <asp:Button ID="cmdHide" runat="server" Text="Hide"  /></asp:Content>
