<%@ Page Async="true" Language="VB" AutoEventWireup="false" CodeFile="SimpleAsyncPage.aspx.vb" Inherits="SimpleAsyncPage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        This page uses asynchronous completion to execute a slow (30 second) task. To see
        how it works, watch the Output window in Visual Studio. You'll see that the first part of the page lifecycle
        is executed on a different thread than the last part.<br />
        <br />
        Keep in mind that this is an example of asynchronous pages, but it doesn't improve
        scalability because both asynchronous delegates and ASP.NET borrow from the same
        pool.
    </div>
    </form>
</body>
</html>
