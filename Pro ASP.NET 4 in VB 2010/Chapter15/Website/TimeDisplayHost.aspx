<%@ Page Language="VB" %>
<%@ Register Src="TimeDisplay.ascx" TagName="TimeDisplay" TagPrefix="apress" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>

        <apress:TimeDisplay ID="TimeDisplay1" runat="server" 
        Format="dddd, dd MMMM yyyy HH:mm:ss tt (GMT z)" /> 
        <br />
        <br />
        <apress:TimeDisplay ID="TimeDisplay2" runat="server" />
 
    </div>
    </form>
</body>
</html>
