<%@ Page Language="VB" AutoEventWireup="false"
   CodeFile="CalendarTest.aspx.vb" Inherits="CalendarTest" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
   <title>Calendar Test</title>
</head>
<body>
   <form id="form1" runat="server">
   <div>
      <asp:Calendar runat="server" ID="Calendar1" ForeColor="#663399"
         BackColor="#FFFFCC" OnSelectionChanged="Calendar1_SelectionChanged"
         BorderColor="#FFCC66" BorderWidth="1px" DayNameFormat="Shortest"
         Font-Names="Verdana" Font-Size="8pt" Height="200px"
         SelectionMode="DayWeekMonth" ShowGridLines="True"
         Width="220px">
         <SelectedDayStyle BackColor="#CCCCFF" Font-Bold="True" />
         <SelectorStyle BackColor="#FFCC66" />
         <TodayDayStyle BackColor="#FFCC66" ForeColor="White" />
         <OtherMonthDayStyle ForeColor="#CC9966" />
         <NextPrevStyle Font-Size="9pt" ForeColor="#FFFFCC" />
         <DayHeaderStyle BackColor="#FFCC66" Font-Bold="True"
            Height="1px" />
         <TitleStyle BackColor="#990000" Font-Bold="True"
            Font-Size="9pt" ForeColor="#FFFFCC" />
      </asp:Calendar>
      <br />
      <asp:Label ID="lblDates" runat="server"></asp:Label>
   </div>
   </form>
</body>
</html>
