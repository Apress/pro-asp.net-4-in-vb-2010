<%@ Page Language="VB" %>
<%@ Register Src="SimpleTimeDisplay.ascx" TagName="TimeDisplay" TagPrefix="apress" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <apress:TimeDisplay ID="myTimeDisplay" runat="server" />
    </div>
    </form>
</body>
</html>
